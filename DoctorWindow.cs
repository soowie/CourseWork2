using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;

namespace AppointmentsService
{
    public partial class DoctorWindow : Form
    {
        int AccountID;
        DOCTOR model;
        DEPARTMENT dep;
        List<int> IdsToPrint = new List<int>();
        public DoctorWindow()
        {
            InitializeComponent();
        }

        public DoctorWindow(int accountID)
        {
            AccountID = accountID;
            InitializeComponent();
            InitInfo();
            PopulateAppointmentDGV();
        }

        void FindAccount()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                model = db.DOCTOR.Where(s => s.account_id == AccountID).FirstOrDefault<DOCTOR>();
                Cursor.Current = Cursors.Default;
            }
        }

        void InitInfo()
        {
            FindAccount();
            int appCount;
            
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                appCount = db.APPOINTMENT.Where(s => s.doctor_id == model.doctor_id).Count();
                dep = db.DEPARTMENT.Where(s => s.department_id == model.department_id).FirstOrDefault();
                Cursor.Current = Cursors.Default;
            }

            labelPatientInfo.Text = $"ID: {model.doctor_id}. {model.name}, {model.specialization}\nДосвід роботи (роки) - {model.experience}, всього записів - {appCount}, унікальних пацієнтів - {model.patients_count}\nПошта: {model.email} , телефон: {model.phone_number}\nВідділ: {dep.name}, {dep.address}, поверх {dep.floor}";
        }

        void PopulateAppointmentDGV()
        {
            dgvAppointment.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from apo in db.APPOINTMENT
                             where apo.doctor_id == model.doctor_id
                             join pat in db.PATIENT on apo.patient_id equals pat.patient_id
                             select new
                             {
                                 appointment_id = apo.appointment_id,
                                 patient = pat.name,
                                 patient_birthday = DbFunctions.TruncateTime(pat.date_of_birth),
                                 patient_phone = pat.phone_number,
                                 patient_email = pat.email,
                                 appointment_date = apo.start_time,
                                 rating = apo.patient_rating,
                                 status = apo.start_time < DateTime.Now ? "Прийнято" : "Заплановано"
                             }).ToList();
                dgvAppointment.DataSource = query;
                dgvAppointment.Columns[0].Visible = false;
                dgvAppointment.Refresh();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthorizationForm af = new AuthorizationForm();
            af.Show();
            Close();
        }

        private void FormClosedAction(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private void dgvAppointment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString() == "Прийнято")
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        void PopulateAppointmentDGVPlanned()
        {
            dgvAppointment.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from apo in db.APPOINTMENT
                             where apo.doctor_id == model.doctor_id && apo.start_time > DateTime.Now
                             join pat in db.PATIENT on apo.patient_id equals pat.patient_id
                             select new
                             {
                                 appointment_id = apo.appointment_id,
                                 patient = pat.name,
                                 patient_birthday = DbFunctions.TruncateTime(pat.date_of_birth),
                                 patient_phone = pat.phone_number,
                                 patient_email = pat.email,
                                 appointment_date = apo.start_time,
                                 rating = apo.patient_rating,
                                 status = "Заплановано"
                             }).ToList();
                dgvAppointment.DataSource = query;
                dgvAppointment.Columns[0].Visible = false;
                dgvAppointment.Refresh();
            }
        }

        void PopulateAppointmentDGVDone()
        {

            dgvAppointment.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from apo in db.APPOINTMENT
                             where apo.doctor_id == model.doctor_id && apo.start_time < DateTime.Now
                             join pat in db.PATIENT on apo.patient_id equals pat.patient_id
                             select new
                             {
                                 appointment_id = apo.appointment_id,
                                 patient = pat.name,
                                 patient_birthday = DbFunctions.TruncateTime(pat.date_of_birth),
                                 patient_phone = pat.phone_number,
                                 patient_email = pat.email,
                                 appointment_date = apo.start_time,
                                 rating = apo.patient_rating,
                                 status = "Прийнято"
                             }).ToList();
                dgvAppointment.DataSource = query;
                dgvAppointment.Columns[0].Visible = false;
                dgvAppointment.Refresh();
            }
        }

        private void checkRating_CheckedChanged(object sender, EventArgs e)
        {
            dgvAppointment.CurrentCell = null;
            if (checkRating.Checked)
            {
                foreach (DataGridViewRow row in dgvAppointment.Rows)
                    if (row.Cells["rating"].Value != null &&
                         row.Cells["rating"].Value.ToString() == "0")
                    {
                        row.Visible = false;
                    }
            }
            else
            {
                foreach (DataGridViewRow row in dgvAppointment.Rows)
                    if (row.Cells["rating"].Value != null &&
                         row.Cells["rating"].Value.ToString() == "0")
                    {
                        row.Visible = true;
                    }
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
            {
                PopulateAppointmentDGV();
                //searchBox_TextChanged(null, null);
            }
        }

        private void radioPlanned_CheckedChanged(object sender, EventArgs e)
        {

            if (radioPlanned.Checked)
            {
                PopulateAppointmentDGVPlanned();
                //searchBox_TextChanged(null, null);
            }

        }

        private void radioDone_CheckedChanged(object sender, EventArgs e)
        {

            if (radioDone.Checked)
            {
                PopulateAppointmentDGVDone();
                //searchBox_TextChanged(null, null);
            }
        }

        //private void searchBox_TextChanged(object sender, EventArgs e)
        //{
        //    dgvAppointment.ReadOnly = false;
        //    dgvAppointment.CurrentCell = null;
        //    foreach (DataGridViewRow row in dgvAppointment.Rows)
        //    {
        //        if (row.Cells["patient"].Value != null &&
        //            !string.IsNullOrEmpty(searchBox.Text) &&
        //            !row.Cells["patient"].Value.ToString().ToLower().Contains(searchBox.Text.ToLower()))
        //        {
        //            row.Visible = false;
        //        }
        //    }
        //}

        private void btnPrintPlan_Click(object sender, EventArgs e)
        {
            if (dgvAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б один запис!");
            }
            else
            {
                List<int> ids = new List<int>();
                foreach (DataGridViewRow item in dgvAppointment.SelectedRows)
                {
                    ids.Add(Convert.ToInt32(item.Cells[0].Value));
                }
                IdsToPrint = ids;
                PrintInfo();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int groupOffset = 110;
            Font font1 = new Font("Arial", 14, FontStyle.Bold);
            Font font = new Font("Arial", 12);
            Font font2 = new Font("Segoe UI", 8, FontStyle.Bold);
            string info = $"Інформація про записи на прйиом\nЛікар: {model.name}, {model.specialization}\nПошта: {model.email} , телефон: {model.phone_number}";
            e.Graphics.DrawString(info, font1, Brushes.Black, 50, 50);
            for (int i = 0; i < IdsToPrint.Count; i++)
            {
                PATIENT patient;
                APPOINTMENT apToPrint;
                int currentId = IdsToPrint[i];
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    apToPrint = db.APPOINTMENT.SingleOrDefault(s => s.appointment_id == currentId);
                    patient = db.PATIENT.SingleOrDefault(b => b.patient_id == apToPrint.patient_id);
                }
                
                string rate = apToPrint.patient_rating == 0 ? "Відсутня" : apToPrint.patient_rating.ToString();
                string status = apToPrint.start_time < DateTime.Now ? "Прийнято" : "Заплановано";
                string appInfo = $"{i+1}. Запис створенo на дату {apToPrint.start_time}. Оцінка корситувача: {rate}. Статус: {status}";
                string patInfo = $"Пацієнт ID{patient.patient_id}. {patient.name}\nПошта: {patient.email} , телефон: {patient.phone_number}";
                e.Graphics.DrawString(appInfo, font, Brushes.Black, 50, 100 + (i+1) * groupOffset);
                e.Graphics.DrawString(patInfo, font, Brushes.Black, 50, 130 + (i+1) * groupOffset);
            }
            e.Graphics.DrawString($"Лікарня \"Okhtyrka's Regional Hospital (ORH)\"", font, Brushes.Black, 220, 250 + IdsToPrint.Count * groupOffset);
            e.Graphics.DrawString($"Дата генерації талону: {DateTime.Now}", font2, Brushes.Black, 450, 280 + IdsToPrint.Count * groupOffset);

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
