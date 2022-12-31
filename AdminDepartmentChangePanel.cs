using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class AdminDepartmentChangePanel : Form
    {
        DEPARTMENT model = new DEPARTMENT();

        public AdminDepartmentChangePanel()
        {
            InitializeComponent();
        }

        private void AdminDepartmentChangePanel_Load(object sender, EventArgs e)
        {
            ClearTextBoxes();
            PopulateDepartmentDGV();
        }

        void PopulateDepartmentDGV()
        {
            dgvDepartment.AutoGenerateColumns = false;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                dgvDepartment.DataSource = db.DEPARTMENT.ToList<DEPARTMENT>();
            }
        }

        private void dgvDepartment_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDepartment.CurrentRow.Index != -1)
            {
                model.department_id = Convert.ToInt32(dgvDepartment.CurrentRow.Cells["department_id"].Value);
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    model = db.DEPARTMENT.Where(x => x.department_id == model.department_id).FirstOrDefault();
                    txtDepartmentName.Text = model.name;
                    txtDepartmentFloor.Text = model.floor.ToString();
                    txtDepartmentAddress.Text = model.address;
                }
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnGoDoctor_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AdminDoctorChangePanel>().Any())
            {
                Application.OpenForms.OfType<AdminDoctorChangePanel>().First().BringToFront();
            }
            else
            {
                AdminDoctorChangePanel f = new AdminDoctorChangePanel();
                f.Show();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            model.name = txtDepartmentName.Text.Trim();
            model.floor = Int32.Parse(txtDepartmentFloor.Text.Trim());
            model.address = txtDepartmentAddress.Text.Trim();

            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                if (model.department_id == 0)
                {
                    db.DEPARTMENT.Add(model);
                    MessageBox.Show("Added successfully!");
                }
                else
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    MessageBox.Show("Changed successfully!");
                }
                SaveDBChanges(db);

            }
            ClearTextBoxes();
            PopulateDepartmentDGV();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете видалити цей запис?", "Видалення запису про лікаря", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                    {
                        db.DEPARTMENT.Attach(model);
                    }
                    db.DEPARTMENT.Remove(model);
                    SaveDBChanges(db);
                    PopulateDepartmentDGV();
                    ClearTextBoxes();
                    MessageBox.Show("Видалення вдале!");
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        void SaveDBChanges(CourseWorkAppointmentsEntities db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    string str = string.Empty;
                    str += "Object: " + validationError.Entry.Entity.ToString();
                    str += "\n";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        str += err.ErrorMessage + "\n";
                    }
                    MessageBox.Show(str);
                }
            }
        }
        void ClearTextBoxes()
        {
            model = new DEPARTMENT();
            model.department_id = 0;
            txtDepartmentAddress.Text = "Сумська обл., м. Охтирка, вул. Київська 100";
            txtDepartmentFloor.Text = txtDepartmentName.Text = string.Empty;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void btnClearAddress_Click(object sender, EventArgs e)
        {
            txtDepartmentAddress.Text = string.Empty;
        }

        private void AdminDepartmentChangePanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}