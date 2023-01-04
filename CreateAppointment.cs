using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

namespace AppointmentsService
{
    public partial class CreateAppointment : Form
    {
        DOCTOR model = new DOCTOR();
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
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                APPOINTMENT apmodel = new APPOINTMENT();
                apmodel.patient_id = PatientID;
                apmodel.doctor_id = model.doctor_id;
                var pickerdate = dateTimePicker1.Value;
                var selectedButton = groupBox.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
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
                Cursor.Current = Cursors.Default;
                if (MessageBox.Show("Запис створено. Чи бажаєте ви роздрукув?", "Друк талону про запис", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PrintInfo();
                }
            }
            GetAppointmentsForDate();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the font and draw the text
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString("Info!", font, Brushes.Black, 50, 50);
            e.Graphics.DrawString("LOOOOOl dsof]ksdoisaovdsaovhduhdapsovjn[uhpvciudsvnshdvbhsvnhbsudavbadsnvouhdafbpvisabdhvousadbpvnisadovbhuyasdbvhpisodbavusdabvps v\ncccccccccccc", font, Brushes.Black, 50, 100);
            e.Graphics.DrawString("xddd\n\nnot me", font, Brushes.Black, 50, 150);
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
    }
}
