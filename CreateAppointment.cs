using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

namespace AppointmentsService
{
    public partial class CreateAppointment : Form
    {
        DOCTOR model = new DOCTOR();
        public CreateAppointment()
        {
            InitializeComponent();
        }

        public CreateAppointment(int id)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            InitModel(id);
            GetAppointmentsForDate();
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

        void InitModel(int id)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                model = db.DOCTOR.Where(s => s.doctor_id == id).FirstOrDefault<DOCTOR>();
                //var distinctPatients = db.APPOINTMENT.Where(s => s.doctor_id == model.doctor_id)
                //                      .GroupBy(p => p.patient_id)
                //                      .Select(g => g.First())
                //                      .Count();
                //model.patients_count = distinctPatients;
                //SaveDBChanges(db);
                DEPARTMENT dep = db.DEPARTMENT.Where(s => s.department_id == model.department_id).FirstOrDefault();
                lblContacts.Text = $"Відділ: {dep.name}; Адреса: {dep.address}; Поверх: {dep.floor};\nКабінет №{model.cabinet_number}; Мобільний телефон: {model.phone_number}; Електронна пошта: {model.email}";
                InitRatingBox();
                Cursor.Current = Cursors.Default;
            }

            lblName.Text = "ID: " + model.doctor_id + ". " + model.name + ", " + model.specialization;
            txtInfo.Text = model.information;
            lblExp.Text = model.experience.ToString();
            lblPatientCount.Text = model.patients_count.ToString();
        }

        void InitRatingBox()
        {
            if (model.rating == null)
            {
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    List<double> list;
                    list = db.APPOINTMENT.Where(s => s.patient_rating != null && s.doctor_id == model.doctor_id).Select(s => s.patient_rating).ToList();
                    if (list.Count != 0)
                    {
                        model.rating = list.Sum() / list.Count;
                        txtRating.Text = model.rating.ToString();
                        txtRating.ForeColor = Color.Black;
                        if (model.rating >= 4.5) txtRating.BackColor = Color.OliveDrab;
                        else if (model.rating >= 4 && model.rating < 4.5) txtRating.BackColor = Color.YellowGreen;
                        else if (model.rating >= 3 && model.rating < 4) txtRating.BackColor = Color.Yellow;
                        else if (model.rating >= 2 && model.rating < 3) txtRating.BackColor = Color.Orange;
                        else if (model.rating >= 1 && model.rating < 2) txtRating.BackColor = Color.OrangeRed;
                        else if (model.rating < 1)
                        {
                            txtRating.BackColor = Color.Red;
                            txtRating.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        txtRating.Text = "N/A";
                    }

                }
            }
            else
            {
                txtRating.Text = "N/A";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRating_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtMyTextbox_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        RadioButton initButton(RadioButton button)
        {
            button.Enabled = true;
            button.BackColor = Color.Wheat;
            return button;
        }

        void GetAppointmentsForDate()
        {
            var buttons = groupBox.Controls.OfType<RadioButton>().Select(x => initButton(x)).ToList();
            List<APPOINTMENT> ap = new List<APPOINTMENT>();
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                ap = db.APPOINTMENT.Where(s => DbFunctions.TruncateTime(s.start_time) == dateTimePicker1.Value.Date && s.doctor_id == model.doctor_id).ToList();
                // витягнули всі записи за дату в аргументі
            }
             // отримали всі кнопки групбоксу

            foreach (var item in ap) // айтем же кожен запис на обрану дату
            {
                string gotTime = item.start_time.ToString("HH:mm"); // обрати лише час з запису
                var button = buttons.Where(s => s.Text == gotTime).FirstOrDefault(); // знайти копку саме з обраним часом
                button.Enabled = button.Checked = false;
                button.BackColor = Color.Red;
            }
        }

        private void CreateAppointment_Load(object sender, EventArgs e)
        {

        }

        private void FormClosedAction(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetAppointmentsForDate();
        }

        private void btnPrevDate_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.AddDays(-1) >= DateTime.Now)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }
    }
}
