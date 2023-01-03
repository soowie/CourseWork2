using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class PatientWindow : Form
    {
        public PATIENT model;
        public PatientWindow()
        {
            InitializeComponent();
        }

        public PatientWindow(int id)
        {
            InitializeComponent();
            FindAccount(id);
            InitInfo();
            PopulateDoctorDGV();
            PopulateAppointmentDGV();
            dgvDoctors.Refresh();
        }

        void InitInfo()
        {
            labelPatientInfo.Text = $"ID: {model.patient_id}. {model.name}\n{GetAgeFromDT(model.date_of_birth)} років, всього записів - {model.appointments_overtime}\nПошта: {model.email} , телефон: {model.phone_number}";
        }
        void FindAccount(int id)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                model = db.PATIENT.Where(s => s.account_id == id).FirstOrDefault<PATIENT>();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            AuthorizationForm af = new AuthorizationForm();
            af.Show();
            this.Close();
        }

        void PopulateAppointmentDGV()
        {
            dgvAppointment.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from apo in db.APPOINTMENT where apo.patient_id == model.patient_id
                             join doc in db.DOCTOR on apo.doctor_id equals doc.doctor_id
                             select new
                             {
                                 appointment_id = apo.appointment_id,
                                 doc = doc.name,
                                 appointment_date = apo.start_time,
                                 rating = apo.patient_rating
                             }).ToList();
                dgvAppointment.DataSource = query;
                dgvAppointment.Columns[0].Visible = false;
                dgvAppointment.Refresh();
            }
        }

        void PopulateDoctorDGV()
        {
            //dgvDoctors.AutoGenerateColumns = false;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from doc in db.DOCTOR
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                foreach (var item in db.DOCTOR.Where(x => x.rating == null))
                {
                    InitRating(item);
                }
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Refresh();
            }
        }

        private void dgvDoctors_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDoctors.CurrentRow.Index != -1)
            {
                int doctor_id = Convert.ToInt32(dgvDoctors.CurrentRow.Cells["doctor_id"].Value);
                CreateAppointment cp = new CreateAppointment(doctor_id, model.patient_id);
                cp.ShowDialog();
            }
            PopulateAppointmentDGV();
            PopulateDoctorDGV();
            InitInfo();
        }

        private void FormClosedAction(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private int GetAgeFromDT(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }

        void InitRating(DOCTOR doc)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                List<double> list;
                list = db.APPOINTMENT.Where(s => s.patient_rating != 0 && s.doctor_id == doc.doctor_id).Select(s => s.patient_rating).ToList();
                if (list.Count != 0)
                {
                    db.DOCTOR.SingleOrDefault(b => b.doctor_id == doc.doctor_id).rating = list.Sum() / list.Count;
                    SaveDBChanges(db);
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
    }
}
