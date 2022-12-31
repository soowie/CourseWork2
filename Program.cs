using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentsService
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var adminDoctorChangePanel = new AdminDoctorChangePanel();
            adminDoctorChangePanel.Show();
            Application.Run();  // Not application run without specific form
        }
    }
}
