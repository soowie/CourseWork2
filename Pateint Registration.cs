using System;
using System.Data.Entity.Validation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class Pateint_Registration : Form
    {
        PATIENT model;
        ACCOUNT modelAcc;
        public Pateint_Registration()
        {
            InitializeComponent();
            model = new PATIENT();
            modelAcc = new ACCOUNT();
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
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            model.name = txtPatientFio.Text.Trim();
            model.date_of_birth = dateTimePicker.Value;
            model.email = txtPatientEmail.Text.Trim();
            model.appointments_overtime = 0;
            model.phone_number = Regex.Replace(txtPatientPhone.Text, @"\s+", "");

            modelAcc.login = txtPatientLogin.Text.Trim();
            modelAcc.password = txtPatientPass.Text.Trim();
            modelAcc.creation_date = DateTime.Now;
            modelAcc.type = "patient";
            Cursor.Current = Cursors.WaitCursor;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                db.ACCOUNT.Add(modelAcc);
                SaveDBChanges(db);
                model.account_id = modelAcc.account_id;
                db.PATIENT.Add(model);
                SaveDBChanges(db);
            }
            Cursor.Current = Cursors.Default;
            this.Close();
            MessageBox.Show($"Акаунт вдало створено. Ваш власний ID: {model.patient_id}");

        }
    }
}
