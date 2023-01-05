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
        public EditProfileInfo()
        {
            InitializeComponent();
        }

        public EditProfileInfo(int id)
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
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                patient = db.PATIENT.Where(x => x.patient_id == ID).FirstOrDefault();
                patient.name = txtName.Text;
                patient.date_of_birth = dtpBirthday.Value;
                patient.email = txtEmail.Text;
                patient.phone_number = txtPhone.Text;
                db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                SaveDBChanges(db);
            }
            MessageBox.Show("Зміни вдалі!");
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
    }
}
