using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace AppointmentsService
{
    public partial class PatientWindow : Form
    {
        public PATIENT model;
        public int AccountID;
        public bool PassAllowed = false;
        public PatientWindow()
        {
            InitializeComponent();
        }

        public PatientWindow(int id)
        {
            AccountID = id;
            InitializeComponent();
            InitInfo();
            PopulateDoctorDGV();
            PopulateAppointmentDGV();
            dgvDoctors.Refresh();
            cmbDepartment.SelectedIndex = 0;
        }

        void InitInfo()
        {
            FindAccount();
            labelPatientInfo.Text = $"ID: {model.patient_id}. {model.name}\n{GetAgeFromDT(model.date_of_birth)} років, всього записів - {model.appointments_overtime}\nПошта: {model.email} , телефон: {model.phone_number}";
        }
        void FindAccount()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                model = db.PATIENT.Where(s => s.account_id == AccountID).FirstOrDefault<PATIENT>();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            AuthorizationForm af = new AuthorizationForm();
            af.Show();
            this.Close();
        }

        void SortTableRatingAsc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.rating ascending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTableRatingDesc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.rating descending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTableExperienceAsc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.experience ascending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTableExperienceDesc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.experience descending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTablePatientsAsc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.patients_count ascending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTablePatientsDesc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.patients_count descending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTableNameAsc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.name ascending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void SortTableNameDesc()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             orderby doc.name descending
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
                dgvDoctors.Refresh();
            }
        }

        void PopulateAppointmentDGV()
        {
            dgvAppointment.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from apo in db.APPOINTMENT
                             join doc in db.DOCTOR on apo.doctor_id equals doc.doctor_id
                             where apo.patient_id == model.patient_id
                             select new
                             {
                                 appointment_id = apo.appointment_id,
                                 doc = doc.name,
                                 appointment_date = apo.start_time,
                                 rating = apo.patient_rating
                             }).ToList();
                dgvAppointment.DataSource = query;
                dgvAppointment.Columns[0].Visible = false;
                dgvAppointment.Columns[1].HeaderText = "Ім'я доктора";
                dgvAppointment.Columns[2].HeaderText = "Дата запису";
                dgvAppointment.Columns[3].HeaderText = "Ваша оцінка";
                dgvAppointment.Refresh();
            }
        }

        void PopulateDoctorDGV()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                foreach (var item in db.DOCTOR)
                {
                    InitRating(item);
                }
                var query = (from doc in db.DOCTOR
                             join acc in db.ACCOUNT on doc.account_id equals acc.account_id
                             where acc.is_deleted == false
                             select new
                             {
                                 doctor_id = doc.doctor_id,
                                 name = doc.name,
                                 specialization = doc.specialization,
                                 rating = doc.rating,
                                 experience = doc.experience,
                                 patients_count = doc.patients_count
                             }).ToList();
                dgvDoctors.DataSource = query;
                dgvDoctors.Columns[0].Visible = false;
                dgvDoctors.Columns[1].HeaderText = "Ім'я доктора";
                dgvDoctors.Columns[2].HeaderText = "Спеціальність";
                dgvDoctors.Columns[3].HeaderText = "Рейтинг";
                dgvDoctors.Columns[4].HeaderText = "Досвід";
                dgvDoctors.Columns[5].HeaderText = "Кількість обслугованих пацієнтів";
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
                    db.DOCTOR.SingleOrDefault(b => b.doctor_id == doc.doctor_id).rating = Math.Round(list.Sum() / list.Count, 2);
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

        private void dgvAppointment_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAppointment.CurrentRow.Index != -1)
            {
                int appointment_id = Convert.ToInt32(dgvAppointment.CurrentRow.Cells["appointment_id"].Value);
                RateAppointment ra = new RateAppointment(appointment_id);
                ra.ShowDialog();
            }
            PopulateAppointmentDGV();
            PopulateDoctorDGV();
            InitInfo();
        }

        private void btnPassChange_Click(object sender, EventArgs e)
        {
            var smtpClient = new SmtpClient("smtp-relay.sendinblue.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("dd28112003dd@gmail.com", "psMU9v3C8VgbLhtn"),
                EnableSsl = true,
            };
            string resetcode = new Random().Next(0, 1000000).ToString("D6");
            smtpClient.Send("dd28112003dd@gmail.com", model.email, "Your code for password reset", resetcode);
            ResetConfirmation rc = new ResetConfirmation(this, resetcode);
            rc.ShowDialog();
            if (PassAllowed)
            {
                MessageBox.Show("Тепер Ви можете змінити пароль для акаунту!");
                PasswordChanger pc = new PasswordChanger(AccountID);
                pc.ShowDialog();
            }
            PassAllowed = false;
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            EditProfileInfo epi = new EditProfileInfo(model.patient_id, this);
            epi.ShowDialog();
            InitInfo();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoctors.Rows)
            {
                dgvDoctors.CurrentCell = null;
                if (row.Cells["name"].Value != null &&
                    row.Cells["name"].Value.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TopWindow tw = new TopWindow(1, model.patient_id);
            tw.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TopWindow tw = new TopWindow(2, model.patient_id);
            tw.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TopWindow tw = new TopWindow(3, model.patient_id);
            tw.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TopWindow tw = new TopWindow(4, model.patient_id);
            tw.ShowDialog();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedItem.ToString() == "Рейтингом")
            {
                if (checkBox1.Checked)
                {
                    SortTableRatingDesc();
                }
                else
                {
                    SortTableRatingAsc();
                }
            }
            else if (cmbDepartment.SelectedItem.ToString() == "Досвідом")
            {
                if (checkBox1.Checked)
                {
                    SortTableExperienceDesc();
                }
                else
                {
                    SortTableExperienceAsc();
                }
            }
            else if (cmbDepartment.SelectedItem.ToString() == "Кількістю пацієнтів")
            {
                if (checkBox1.Checked)
                {
                    SortTablePatientsDesc();
                }
                else
                {
                    SortTablePatientsAsc();
                }
            }
            else if (cmbDepartment.SelectedItem.ToString() == "Іменем")
            {
                if (checkBox1.Checked)
                {
                    SortTableNameDesc();
                }
                else
                {
                    SortTableNameAsc();
                }
            }
            searchBox_TextChanged(null, null);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cmbDepartment_SelectedIndexChanged(null, null);
        }
    }
}
