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
    public partial class CreateAppointment : Form
    {
        DOCTOR model;
        public CreateAppointment()
        {
            InitializeComponent();
        }

        public CreateAppointment(int id)
        {
            InitializeComponent();
            InitModel(id);
            InitRatingBox(model.rating);
        }

        void InitModel(int id)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                model = db.DOCTOR.Where(s => s.doctor_id == id).FirstOrDefault<DOCTOR>();
                Cursor.Current = Cursors.Default;
            }
            lblName.Text = "ID: "+ model.doctor_id+". "+model.name +", "+ model.specialization;
            txtInfo.Text = model.information;
            lblExp.Text = model.experience.ToString();
            lblPatientCount.Text = model.patients_count.ToString();

        }

        void InitRatingBox(double? rating)
        {
            if (rating.HasValue)
            {
                txtRating.Text = rating.Value.ToString();
                txtRating.ForeColor = Color.Black;
                if (rating >= 4.5) txtRating.BackColor = Color.OliveDrab;
                else if (rating >= 4 && rating < 4.5) txtRating.BackColor = Color.YellowGreen;
                else if (rating >= 3 && rating < 4) txtRating.BackColor = Color.Yellow;
                else if (rating >= 2 && rating < 3) txtRating.BackColor = Color.Orange;
                else if (rating >= 1 && rating < 2) txtRating.BackColor = Color.OrangeRed;
                else if (rating < 1)
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
    }
}
