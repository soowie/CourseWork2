using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            labelPatientInfo.Text = model.patient_id + " " + model.name;
            PopulateDoctorDGV();
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

        void PopulateDoctorDGV()
        {
            //dgvDoctors.AutoGenerateColumns = false;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from doc in db.DOCTOR select new { doctor_id = doc.doctor_id,
                                                                name = doc.name,
                                                                specialization = doc.specialization,
                                                                rating = doc.rating,
                                                                experience = doc.experience,
                                                                patients_count = doc.patients_count}).ToList();
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
                CreateAppointment cp = new CreateAppointment(doctor_id);
                cp.ShowDialog();
            }
        }
    }
}
