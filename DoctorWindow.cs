using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class DoctorWindow : Form
    {
        int AccountID;
        DOCTOR model;
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
            DEPARTMENT dep;
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

        //private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<string> chList = new List<string>();
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = dgvAppointment.DataSource;
        //    foreach (string s in checkedListBox1.CheckedItems)
        //    {
        //        chList.Add(s);
        //    }
        //    MessageBox.Show("ss");
        //    if ()
        //        if (chList.Contains("Лише заплановані"))
        //        {
        //            PopulateAppointmentDGVPlanned();
        //        }
        //        else if (chList.Contains("Лише минулі"))
        //        {
        //            PopulateAppointmentDGVDone();
        //        }
        //        else if (chList.Contains("Без оцінки"))
        //        {
        //            PopulateAppointmentDGVNotZero();
        //        }
        //}

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

        void PopulateAppointmentDGVNotZero()
        {
            dgvAppointment.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from apo in db.APPOINTMENT
                             where apo.doctor_id == model.doctor_id && apo.patient_rating != 0
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

        private void checkRating_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRating.Checked)
            {
                List<DataGridViewRow> RowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dgvAppointment.Rows)
                    if (row.Cells["rating"].Value != null &&
                         row.Cells["rating"].Value.ToString() == "0") row.Visible = false;
                //MessageBox.Show("Yes");
            }
            else
            {
                List<DataGridViewRow> RowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dgvAppointment.Rows)
                    if (row.Cells["rating"].Value != null &&
                         row.Cells["rating"].Value.ToString() == "0") row.Visible = true;
                //MessageBox.Show("No");
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
            {
                PopulateAppointmentDGV();
                checkRating_CheckedChanged(null, null);
            } 
        }

        private void radioPlanned_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPlanned.Checked)
            {
                PopulateAppointmentDGVPlanned();
                checkRating_CheckedChanged(null, null);
            }
                
        }

        private void radioDone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDone.Checked)
            {
                PopulateAppointmentDGVDone();
                checkRating_CheckedChanged(null, null);
            } 
        }
    }
}
