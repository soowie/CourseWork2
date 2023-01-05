using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
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
    }
}
