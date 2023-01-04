using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class PasswordChanger : Form
    {

        public int PatientID;
        public PasswordChanger()
        {
            InitializeComponent();
        }

        public PasswordChanger(int patientid)
        {
            PatientID = patientid;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string prevPass;
            int accid;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                accid = db.PATIENT.Where(x => x.account_id == PatientID).FirstOrDefault().account_id;
                prevPass = db.ACCOUNT.Where(x => x.account_id == accid).FirstOrDefault().password;
            }
            if (txtPass.Text != txtPassConfirm.Text)
            {
                MessageBox.Show("Паролі не збігаються!");
            }
            else if (txtPass.Text != txtPassConfirm.Text)
            {
                MessageBox.Show("Паролі не збігаються!");
            }
            else
            {
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    db.ACCOUNT.Where(x => x.account_id == accid).FirstOrDefault().password = txtPass.Text;
                    SaveDBChanges(db);
                    MessageBox.Show("Пароль вдало змінено!");
                    Close();
                }
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
