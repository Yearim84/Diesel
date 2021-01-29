using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diesel.Views;

namespace Diesel.Models
{
    public class MainViewModel
    {
        public frmLogin login { get; set; }
        public frmMain main { get; set; }
        public frmDashboard dashboard { get; set; }
        public frmDashboardViewer dashboardViewer { get; set; }
        public frmUsers users { get; set; }
        public frmRoles roles { get; set; }
        public frmProfile profile { get; set; }
        public frmComments comments { get; set; }

        private static MainViewModel instance;
        
        public MainViewModel()
        {
            instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
