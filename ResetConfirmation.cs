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
    public partial class ResetConfirmation : Form
    {
        PatientWindow _patientWindow;
        string confirmationcode;
        bool result = false;
        public ResetConfirmation()
        {
            InitializeComponent();
        }

        public ResetConfirmation(PatientWindow pw, string code)
        {
            _patientWindow = pw;
            confirmationcode = code;
            InitializeComponent();
        }

        private void ResetConfirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
            _patientWindow.PassAllowed = result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (confirmationcode == txtCode.Text)
            {
                result = true;
                Close();
            }
            else
            {
                label1.Text = "Код невірний!";
            }
        }
    }
}
