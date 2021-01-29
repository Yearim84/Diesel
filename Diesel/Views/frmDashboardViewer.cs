using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diesel.Views
{
    public partial class frmDashboardViewer : DevExpress.XtraEditors.XtraForm
    {
        public frmDashboardViewer()
        {
            InitializeComponent();
        }

        private void loadDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Dashboard Files (*.xml)|*.xml"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(open.FileName))
                {
                    dashboardViewer1.LoadDashboard(open.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}