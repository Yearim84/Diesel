using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diesel.Views;
using Diesel.Models;

namespace Diesel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainViewModel viewModel = new MainViewModel();
            bool newInstance;            
            System.Threading.Mutex myMutex = new System.Threading.Mutex(true, "Diesel", out newInstance);
            if (newInstance)
            {
                Application.Run(new frmLogin());
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The app is already running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
