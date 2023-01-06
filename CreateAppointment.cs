using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Media;
using RadioButton = System.Windows.Forms.RadioButton;
using Color = System.Drawing.Color;
using Brushes = System.Drawing.Brushes;
using System.Security.Cryptography;
using System.Data.Entity.Infrastructure;

namespace AppointmentsService
{
    public partial class CreateAppointment : Form
    {
        DOCTOR model = new DOCTOR();
        APPOINTMENT apToPrint = new APPOINTMENT();
        int PatientID;
        public CreateAppointment()
        {
            InitializeComponent();
        }

        public CreateAppointment(int id, int patientid)
        {
            PatientID = patientid;
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
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
                //                      .Count();
                //model.patients_count = distinctPatients;
                //SaveDBChanges(db);
                DEPARTMENT dep = db.DEPARTMENT.Where(s => s.department_id == model.department_id).FirstOrDefault();
                lblContacts.Text = $"Адреса: {dep.address};\nПоверх: {dep.floor}; Відділ: {dep.name}; Кабінет №{model.cabinet_number};\nМобільний телефон: {model.phone_number}; Електронна пошта: {model.email}";
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
                txtRating.Text = "N/A";
            }
            else
            {
                txtRating.Text = model.rating.ToString();
                if (model.rating >= 4.5) txtRating.BackColor = Color.OliveDrab;
                else if (model.rating >= 4 && model.rating < 4.5) txtRating.BackColor = Color.YellowGreen;
                else if (model.rating >= 3 && model.rating < 4) txtRating.BackColor = Color.Yellow;
                else if (model.rating >= 2 && model.rating < 3) txtRating.BackColor = Color.Orange;
                else if (model.rating >= 1 && model.rating < 2) txtRating.BackColor = Color.OrangeRed;
                else if (model.rating < 1)
                {
                    txtRating.BackColor = Color.Black;
                    txtRating.ForeColor = Color.White;
                }
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
            button.BackColor = Color.GreenYellow;
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

            foreach (var button in buttons)
            {
                if (new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, Int32.Parse(button.Text.Split(':')[0]), Int32.Parse(button.Text.Split(':')[1]), 0) < DateTime.Now)
                {
                    button.Enabled = button.Checked = false;
                    button.BackColor = Color.Red;
                }
            }

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
            if (dateTimePicker1.Value.AddDays(-1) >= dateTimePicker1.MinDate)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
            }
            else
            {
                dateTimePicker1.Value = dateTimePicker1.MinDate;
            }
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.AddDays(1) <= dateTimePicker1.MaxDate)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
            }
            else
            {
                dateTimePicker1.Value = dateTimePicker1.MaxDate;
            }
        }

        private void lblPatientCount_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedButton = groupBox.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            if (selectedButton == null)
            {
                MessageBox.Show("Оберіть хоча б один час!");
            }
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                APPOINTMENT apmodel = new APPOINTMENT();
                apmodel.patient_id = PatientID;
                apmodel.doctor_id = model.doctor_id;
                var pickerdate = dateTimePicker1.Value;
                
                int hrs = Convert.ToInt32(selectedButton.Text.Split(':')[0]);
                int mins = Convert.ToInt32(selectedButton.Text.Split(':')[1]);
                int minEnd = mins + 20;
                int secs = 0;
                DateTime dt1 = new DateTime(pickerdate.Year, pickerdate.Month, pickerdate.Day, hrs, mins, secs);
                DateTime dt2 = new DateTime(pickerdate.Year, pickerdate.Month, pickerdate.Day, hrs, minEnd, secs);
                apmodel.start_time = dt1;
                apmodel.end_time = dt2;
                if (db.APPOINTMENT.Where(x => x.doctor_id == apmodel.doctor_id && x.patient_id == apmodel.patient_id).Count() == 0)
                {
                    db.DOCTOR.SingleOrDefault(b => b.doctor_id == apmodel.doctor_id).patients_count++;
                }
                db.APPOINTMENT.Add(apmodel);
                db.PATIENT.SingleOrDefault(b => b.patient_id == apmodel.patient_id).appointments_overtime++; // increase appointment counter
                SaveDBChanges(db);
                apToPrint = apmodel;
                Cursor.Current = Cursors.Default;
                if (MessageBox.Show("Запис створено. Чи бажаєте ви роздрукувавти талон?", "Друк талону про запис", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PrintInfo();
                }
            }
            GetAppointmentsForDate();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            DOCTOR model;
            DEPARTMENT dep;
            PATIENT patient;
            int appCount;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                model = db.DOCTOR.SingleOrDefault(b => b.doctor_id == apToPrint.doctor_id);
                appCount = db.APPOINTMENT.Where(s => s.doctor_id == model.doctor_id).Count();
                patient = db.PATIENT.SingleOrDefault(b => b.patient_id == apToPrint.patient_id);
                dep = db.DEPARTMENT.SingleOrDefault(b => b.department_id == model.department_id);
            }
                
            string info = $"Лікар: {model.name}, {model.specialization}\nПошта: {model.email} , телефон: {model.phone_number}";
            string patInfo = $"{patient.name}\nВсього записів - {patient.appointments_overtime}\nПошта: {patient.email} , телефон: {patient.phone_number}";
            string appInfo = $"Запис створенo на дату {apToPrint.start_time}.\nВідділ: {dep.name}, {dep.address}\nПоверх {dep.floor}, кабінет № {model.cabinet_number}\n\n{info}";
            Font font1 = new Font("Arial", 14, FontStyle.Bold);
            Font font = new Font("Arial", 12);
            Font font2 = new Font("Segoe UI", 8, FontStyle.Bold);
            e.Graphics.DrawString($"Інформація талону №{apToPrint.appointment_id}", font1, Brushes.Black, 250, 50);
            e.Graphics.DrawString(appInfo, font, Brushes.Black, 50, 100);
            e.Graphics.DrawString(patInfo, font, Brushes.Black, 50, 270);
            e.Graphics.DrawString($"Лікарня \"Okhtyrka's Regional Hospital (ORH)\"", font, Brushes.Black, 220, 400);
            e.Graphics.DrawString($"Дата генерації талону: {DateTime.Now}", font2, Brushes.Black, 450, 430);
        }

        private void PrintInfo()
        {
            // Display the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Print the document
                printDocument1.Print();
            }
        }

        private void btnAutoAppointment_Click(object sender, EventArgs e)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                //var allappointments = db.APPOINTMENT.Where(b => b.start_time >= DateTime.Now).OrderBy(x => x.start_time).ToList();
                var allappointments = db.APPOINTMENT.Where(b => b.start_time >= DateTime.Now && b.doctor_id == model.doctor_id).OrderBy(x => x.start_time).ToList();
                List<DateTime> possibleTimesForDay = new List<DateTime>();

                possibleTimesForDay.Add(new DateTime(1, 1, 1, 11, 0, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 12, 0, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 13, 0, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 14, 0, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 15, 0, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 16, 0, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 17, 0, 0));

                possibleTimesForDay.Add(new DateTime(1, 1, 1, 11, 30, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 12, 30, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 13, 30, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 14, 30, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 15, 30, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 16, 30, 0));
                possibleTimesForDay.Add(new DateTime(1, 1, 1, 17, 30, 0));
                DateTime foundTime = DateTime.Now;
                bool didFind = false;
                DateTime startTime = DateTime.Now;
                while (startTime < dateTimePicker1.MaxDate)
                {
                    var timesForCurrentDate = possibleTimesForDay.Select(x => CreateDateFromTime(startTime.Year, startTime.Month, startTime.Day, x)).Where(x => x > DateTime.Now && allappointments.Select(m => m.start_time).Contains(x) == false).ToList();
                    if (timesForCurrentDate != null && timesForCurrentDate.Count != 0)
                    {
                        timesForCurrentDate.Sort();
                        foundTime = timesForCurrentDate[0];
                        didFind = true;
                        break;
                    }
                    else
                    {
                        startTime = startTime.AddDays(1);
                    }
                }
                if (didFind)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    APPOINTMENT apmodel = new APPOINTMENT();
                    apmodel.patient_id = PatientID;
                    apmodel.doctor_id = model.doctor_id;

                    apmodel.start_time = foundTime;
                    apmodel.end_time = foundTime.AddMinutes(20);
                    if (db.APPOINTMENT.Where(x => x.doctor_id == apmodel.doctor_id && x.patient_id == apmodel.patient_id).Count() == 0)
                    {
                        db.DOCTOR.SingleOrDefault(b => b.doctor_id == apmodel.doctor_id).patients_count++;
                    }
                    db.APPOINTMENT.Add(apmodel);
                    db.PATIENT.SingleOrDefault(b => b.patient_id == apmodel.patient_id).appointments_overtime++; // increase appointment counter
                    SaveDBChanges(db);
                    Cursor.Current = Cursors.Default;
                    apToPrint = apmodel;
                    if (MessageBox.Show($"Запис створено, ваш час: {foundTime}. Чи бажаєте ви роздрукувати талон?", "Друк талону про запис", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrintInfo();
                    }
                    GetAppointmentsForDate();
                }

            }
        }

        public static DateTime CreateDateFromTime(int year, int month, int day, DateTime time)
        {
            return new DateTime(year, month, day, time.Hour, time.Minute, 0);
        }
    }
}
