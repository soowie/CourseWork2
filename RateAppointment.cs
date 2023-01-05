using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace AppointmentsService
{
    public partial class RateAppointment : Form
    {
        APPOINTMENT model = new APPOINTMENT();
        int docID = 0;
        public RateAppointment(int id)
        {
            InitializeComponent();
            label5.Hide();
            txtRating.Hide();
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                docID = db.APPOINTMENT.Where(x => x.appointment_id == id).FirstOrDefault().doctor_id;
                model = db.APPOINTMENT.Where(x => x.appointment_id == id).FirstOrDefault();
            }
            GetFields();

        }

        void GetFields()
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                txtId.Text = model.appointment_id.ToString();
                txtName.Text = db.DOCTOR.Where(x => x.doctor_id == docID).FirstOrDefault().name;
                txtBegin.Text = model.start_time.ToString();
                txtEnd.Text = model.end_time.ToString();
                if (model.patient_rating != 0)
                {
                    label5.Show();
                    txtRating.Show();
                    txtRating.Text = model.patient_rating.ToString();

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
                db.APPOINTMENT.Where(x => x.appointment_id == model.appointment_id).FirstOrDefault().patient_rating = (double)numRating.Value;
                model.patient_rating = (double)numRating.Value;
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
    }
}
