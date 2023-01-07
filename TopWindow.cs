using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AppointmentsService
{
    public partial class TopWindow : Form
    {
        public TopWindow()
        {
            InitializeComponent();
        }

        public TopWindow(int type, int id)
        {
            InitializeComponent();
            if (type == 1)
            {
                TopKind1();
            }
            else if (type == 2)
            {
                TopKind2();
            }
            else if (type == 3)
            {
                TopKind3(id);
            }
            else if (type == 4)
            {
                TopKind4();
            }
        }

        void TopKind1()
        {
            label1.Text = "Топ 5 лікарів за рейтингом";
            dgvTop.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from doc in db.DOCTOR
                             orderby doc.rating descending
                             select new
                             {
                                 doc_id = doc.doctor_id,
                                 doc_name = doc.name,
                                 doc_rating = doc.rating
                             }
                             ).Take(5).ToList();
                dgvTop.DataSource = query;
                dgvTop.Columns[0].Visible = false;
                dgvTop.Columns[1].HeaderText = "Ім'я лікаря";
                dgvTop.Columns[2].HeaderText = "Рейтинг";
                dgvTop.Refresh();
            }
        }

        void TopKind2()
        {
            label1.Text = "Топ 5 лікарів за кількістю записів";
            dgvTop.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from aps in db.APPOINTMENT
                             join doc in db.DOCTOR on aps.doctor_id equals doc.doctor_id
                             group aps by doc.name into grp
                             orderby grp.Count() descending
                             select new
                             {
                                 doc_id = grp.Key,
                                 count = grp.Count()
                             }
                             ).Take(5).ToList();
                dgvTop.DataSource = query;
                dgvTop.Columns[0].HeaderText = "Ім'я лікаря";
                dgvTop.Columns[1].HeaderText = "Кількість записів";
                dgvTop.Refresh();
            }
        }

        void TopKind3(int id)
        {
            label1.Text = "Топ 5 лікарів за кількістю ваших записів";
            dgvTop.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from aps in db.APPOINTMENT
                             where aps.patient_id == id
                             join doc in db.DOCTOR on aps.doctor_id equals doc.doctor_id
                             group aps by doc.name into grp
                             orderby grp.Count() descending
                             select new
                             {
                                 doc_name = grp.Key,
                                 count = grp.Count()
                             }
                             ).Take(5).ToList();
                dgvTop.DataSource = query;
                dgvTop.Columns[0].HeaderText = "Ім'я лікаря";
                dgvTop.Columns[1].HeaderText = "Кількість ваших записів";
                dgvTop.Refresh();
            }
        }

        void TopKind4()
        {
            label1.Text = "Топ 5 лікарів за досвідом";
            dgvTop.AutoGenerateColumns = true;
            using (CourseWorkAppointmentsEntities db = new CourseWorkAppointmentsEntities())
            {
                var query = (from doc in db.DOCTOR
                             orderby doc.experience descending
                             select new
                             {
                                 doc_id = doc.doctor_id,
                                 doc_name = doc.name,
                                 doc_experience = doc.experience
                             }
                             ).Take(5).ToList();
                dgvTop.DataSource = query;
                dgvTop.Columns[0].Visible = false;
                dgvTop.Columns[1].HeaderText = "Ім'я лікаря";
                dgvTop.Columns[2].HeaderText = "Досвід";
                dgvTop.Refresh();
            }
        }

        private void AdminDoctorChangePanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}
