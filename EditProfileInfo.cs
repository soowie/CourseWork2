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
    public partial class EditProfileInfo : Form
    {
        PATIENT patient;
        int ID;
        PatientWindow window;

        public EditProfileInfo()
        {
            InitializeComponent();
        }

        public EditProfileInfo(int id, PatientWindow window)
        {
            InitializeComponent();
            ID = id;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                patient = db.PATIENT.Where(x => x.patient_id == ID).FirstOrDefault();
                txtName.Text = patient.name;
                dtpBirthday.Value = patient.date_of_birth;
                txtEmail.Text = patient.email;
                txtPhone.Text = patient.phone_number;
            }

            this.window = window;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                patient = db.PATIENT.Where(x => x.patient_id == ID).FirstOrDefault();
                patient.name = txtName.Text;
                patient.date_of_birth = dtpBirthday.Value;
                patient.email = txtEmail.Text;
                var patientSameEmail = db.PATIENT.Where(x => x.email == patient.email).FirstOrDefault();
                if (patientSameEmail != null && !db.ACCOUNT.Where(s => s.account_id == patientSameEmail.account_id).FirstOrDefault<ACCOUNT>().is_deleted)
                {
                    MessageBox.Show("Така пошта вже зайнята!");
                    return;
                }
                patient.phone_number = txtPhone.Text;
                db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                SaveDBChanges(db);
            }
            MessageBox.Show("Зміни вдалі!");
            Close();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете видалити цей акаунт?", "Видалення аккаунту", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    var acc = db.ACCOUNT.Where(x => x.account_id == patient.account_id).FirstOrDefault();
                    var entryAcc = db.Entry(acc);
                    if (entryAcc.State == System.Data.Entity.EntityState.Detached)
                    {
                        db.ACCOUNT.Attach(acc);
                    }
                    acc.is_deleted = true;
                    SaveDBChanges(db);
                    MessageBox.Show("Видалення вдале!");
                    window.Close();
                    AuthorizationForm af = new AuthorizationForm();
                    af.Show();
                    this.Close();
                    this.Close();
                    
                }
            }
        }
    }
}
