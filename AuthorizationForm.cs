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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
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

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = db.ACCOUNT.Where(s => s.login == txtLogin.Text && s.password == txtPassword.Text && s.is_deleted == false).FirstOrDefault<ACCOUNT>();
                Cursor.Current = Cursors.Default;
                if (query != null)
                {
                    if (query.type == "doctor")
                    {
                        MessageBox.Show("Успішний вхід в систему лікаря!");
                    }
                    else if (query.type == "patient")
                    {
                        PatientWindow pw = new PatientWindow(query.account_id);
                        pw.Show();
                        this.Close();
                        MessageBox.Show("Успішний вхід в систему пацієнта!");
                    }
                    else
                    {
                        AdminDoctorChangePanel adcp = new AdminDoctorChangePanel();
                        adcp.Show();
                        this.Close();
                        MessageBox.Show("Успішний вхід в систему адміністрування!");
                    }
                }
                else
                {
                    MessageBox.Show("Невірні дані для входу!");
                }
            }

        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            txtLogin.Text = txtPassword.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pateint_Registration pr = new Pateint_Registration();
            pr.ShowDialog();
        }
    }
}
