using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class RateAppointment : Form
    {
        APPOINTMENT apToPrint = new APPOINTMENT();
        int docID = 0;
        public RateAppointment(int id)
        {
            InitializeComponent();
            label5.Hide();
            txtRating.Hide();
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                docID = db.APPOINTMENT.Where(x => x.appointment_id == id).FirstOrDefault().doctor_id;
                apToPrint = db.APPOINTMENT.Where(x => x.appointment_id == id).FirstOrDefault();
            }
            GetFields();

        }

        void GetFields()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                txtId.Text = apToPrint.appointment_id.ToString();
                txtName.Text = db.DOCTOR.Where(x => x.doctor_id == docID).FirstOrDefault().name;
                txtBegin.Text = apToPrint.start_time.ToString();
                txtEnd.Text = apToPrint.end_time.ToString();
                if (apToPrint.patient_rating != 0)
                {
                    label5.Show();
                    txtRating.Show();
                    txtRating.Text = apToPrint.patient_rating.ToString();

                    numRating.Hide();
                    btnRate.Hide();
                    label3.Hide();
                }
            }
        }

        private void FormClosedAction(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private void btnRate_Click(object sender, System.EventArgs e)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                db.APPOINTMENT.Where(x => x.appointment_id == apToPrint.appointment_id).FirstOrDefault().patient_rating = (double)numRating.Value;
                apToPrint.patient_rating = (double)numRating.Value;
                SaveDBChanges(db);
            }
            GetFields();
            MessageBox.Show("Оцінка успішно додана!");
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

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            PrintInfo();
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
    }
}
