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
using static System.Net.Mime.MediaTypeNames;

namespace AppointmentsService
{
    public partial class Form1 : Form
    {
            
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
            txtDoctorDepartment.Text = txtDoctorCabinet.Text = txtDoctorEmail.Text = txtDoctorFio.Text = txtDoctorInfo.Text = txtDoctorLogin.Text = txtDoctorPass.Text = txtDoctorPhone.Text = String.Empty;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DOCTOR model = new DOCTOR();
            ACCOUNT modelAcc = new ACCOUNT();

            model.doctor_id = 0;
            modelAcc.account_id = 0;

            model.name = txtDoctorFio.Text.Trim();
            model.information = txtDoctorInfo.Text.Trim();
            model.email = txtDoctorEmail.Text.Trim();

            model.phone_number = Regex.Replace(txtDoctorPhone.Text, @"\s+", "");

            model.cabinet_number = Int32.Parse(txtDoctorCabinet.Text.Trim());
            model.department_id = Int32.Parse(txtDoctorDepartment.Text.Trim());

            modelAcc.login = txtDoctorLogin.Text.Trim();
            modelAcc.password = txtDoctorPass.Text.Trim();
            modelAcc.creation_date = DateTime.Now;
            modelAcc.type = "doctor";
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                //MessageBox.Show("adding acc");
                db.ACCOUNT.Add(modelAcc);
                SaveDBChanges(db);
                model.account_id = modelAcc.account_id;
                //MessageBox.Show("adding doc");
                db.DOCTOR.Add(model);
                SaveDBChanges(db);
            }
            ClearTextBoxes();
            MessageBox.Show("Added successfully!");
        }
    }
}
