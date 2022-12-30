﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AppointmentsService
{
    public partial class AdminDoctorChangePanel : Form
    {
        DOCTOR model = new DOCTOR();
        ACCOUNT modelAcc = new ACCOUNT();
        public AdminDoctorChangePanel()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
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

        void ClearTextBoxes()
        {
            model = new DOCTOR();
            modelAcc = new ACCOUNT();
            model.doctor_id = 0;
            modelAcc.account_id = 0;
            txtDoctorExperience.Text = txtDoctorSpecialization.Text = txtDoctorDepartment.Text = txtDoctorCabinet.Text = txtDoctorEmail.Text = txtDoctorFio.Text = txtDoctorInfo.Text = txtDoctorLogin.Text = txtDoctorPass.Text = txtDoctorPhone.Text = String.Empty;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearTextBoxes();
            PopulateDoctorDGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            model.name = txtDoctorFio.Text.Trim();
            model.information = txtDoctorInfo.Text.Trim();
            model.email = txtDoctorEmail.Text.Trim();
            model.specialization = txtDoctorSpecialization.Text.Trim();

            model.phone_number = Regex.Replace(txtDoctorPhone.Text, @"\s+", "");

            model.cabinet_number = Int32.Parse(txtDoctorCabinet.Text.Trim());
            model.experience = Int32.Parse(txtDoctorExperience.Text.Trim());
            model.department_id = Int32.Parse(txtDoctorDepartment.Text.Trim());

            modelAcc.login = txtDoctorLogin.Text.Trim();
            modelAcc.password = txtDoctorPass.Text.Trim();
            if (model.doctor_id == 0)
            {
                modelAcc.creation_date = DateTime.Now;
                modelAcc.type = "doctor";
            }
                
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                if (model.doctor_id == 0)
                {
                    //MessageBox.Show("adding acc");
                    db.ACCOUNT.Add(modelAcc);
                    SaveDBChanges(db);
                    model.account_id = modelAcc.account_id;
                    //MessageBox.Show("adding doc");
                    db.DOCTOR.Add(model);
                    MessageBox.Show("Added successfully!");
                }
                else
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(modelAcc).State = System.Data.Entity.EntityState.Modified;
                    MessageBox.Show("Changed successfully!");
                }
                SaveDBChanges(db);

            }
            ClearTextBoxes();
            PopulateDoctorDGV();
        }

        void PopulateDoctorDGV()
        {
            dgvCustomer.AutoGenerateColumns = false;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                dgvCustomer.DataSource = db.DOCTOR.ToList<DOCTOR>();
            }
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow.Index != -1)
            {
                model.doctor_id = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["doctor_id"].Value);
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    model = db.DOCTOR.Where(x => x.doctor_id == model.doctor_id).FirstOrDefault();
                    modelAcc = db.ACCOUNT.Where(x => x.account_id == model.account_id).FirstOrDefault();
                    txtDoctorCabinet.Text = model.cabinet_number.ToString();
                    txtDoctorDepartment.Text = model.department_id.ToString();
                    txtDoctorFio.Text = model.name.ToString();
                    txtDoctorSpecialization.Text = model.specialization.ToString();
                    txtDoctorExperience.Text = model.experience.ToString();
                    txtDoctorEmail.Text = model.email.ToString();
                    txtDoctorInfo.Text = model.information.ToString();
                    txtDoctorPhone.Text = model.phone_number.ToString();
                    txtDoctorLogin.Text = modelAcc.login.ToString();
                    txtDoctorPass.Text = modelAcc.password.ToString();
                }
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете видалити цей запис?","Видалення запису про лікаря", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
                {
                    var entry = db.Entry(model);
                    var entryAcc = db.Entry(modelAcc);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                    {
                        db.DOCTOR.Attach(model);
                    }
                    if (entryAcc.State == System.Data.Entity.EntityState.Detached)
                    {
                        db.ACCOUNT.Attach(modelAcc);
                    }
                    db.DOCTOR.Remove(model);
                    db.ACCOUNT.Remove(modelAcc);
                    SaveDBChanges(db);
                    PopulateDoctorDGV();
                    ClearTextBoxes();
                    MessageBox.Show("Видалення вдале!");
                }
            }
        }
    }
}