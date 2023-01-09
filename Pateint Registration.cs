using System;
using System.Data.Entity.Validation;
using System.Linq;
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
            if (txtPatientPass.Text.Trim() != txtPatientPass2.Text.Trim())
            {
                MessageBox.Show("Паролі не співпадають!");
                return;
            }

            modelAcc.login = txtPatientLogin.Text.Trim();
            modelAcc.password = txtPatientPass.Text.Trim();
            modelAcc.creation_date = DateTime.Now;
            modelAcc.type = "patient";

            model.name = txtPatientFio.Text.Trim();
            model.date_of_birth = dateTimePicker.Value;
            model.email = txtPatientEmail.Text.Trim();
            model.appointments_overtime = 0;
            model.phone_number = Regex.Replace(txtPatientPhone.Text, @"\s+", "");

            Cursor.Current = Cursors.WaitCursor;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var patientSameEmail = db.PATIENT.Where(x => x.email == model.email).FirstOrDefault();
                if (patientSameEmail != null && !db.ACCOUNT.Where(s => s.account_id == patientSameEmail.account_id).FirstOrDefault<ACCOUNT>().is_deleted)
                {
                    MessageBox.Show("Така пошта вже зайнята!");
                    return;
                }
                var doctorSameEmail = db.DOCTOR.Where(x => x.email == model.email).FirstOrDefault();
                if (doctorSameEmail != null && !db.ACCOUNT.Where(s => s.account_id == doctorSameEmail.account_id).FirstOrDefault<ACCOUNT>().is_deleted)
                {
                    MessageBox.Show("Така пошта вже зайнята!");
                    return;
                }

                var query = db.ACCOUNT.Where(s => s.login == modelAcc.login && s.is_deleted == false).FirstOrDefault<ACCOUNT>();
                if (query == null)
                {
                    db.ACCOUNT.Add(modelAcc);
                    SaveDBChanges(db);
                    model.account_id = modelAcc.account_id;
                    db.PATIENT.Add(model);
                    SaveDBChanges(db);
                    Cursor.Current = Cursors.Default;
                    this.Close();
                    MessageBox.Show($"Акаунт вдало створено. Ваш власний ID: {model.patient_id}");
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Аккаунт під таким логіном вже інсує, оберіть інший логін!");
                }

            }
        }
    }
}
