﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

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

            GetAppointmentsForDate(DateTime.Now);
        }

        void InitModel(int id)
        {
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                Cursor.Current = Cursors.WaitCursor;
                model = db.DOCTOR.Where(s => s.doctor_id == id).FirstOrDefault<DOCTOR>();
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

        void GetAppointmentsForDate(DateTime dt)
        {
            List<APPOINTMENT> ap = new List<APPOINTMENT>();
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                ap = db.APPOINTMENT.Where(s => DbFunctions.TruncateTime(s.start_time) == dt.Date && s.doctor_id == model.doctor_id).ToList();
            }
            var buttons = groupBox.Controls.OfType<RadioButton>().ToList();

            foreach (var item in ap)
            {
                string gotTime = item.start_time.ToString("HH:mm");
                var button = buttons.Where(s => s.Text == gotTime).FirstOrDefault();
                button.Enabled = false;
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
    }
}