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
using Diesel.Models;
using System.Data.SqlClient;

namespace Diesel.Views
{
    public partial class frmProfile : DevExpress.XtraEditors.XtraForm
    {
        private string sEmployeeID;
        private string sRole;

        public frmProfile()
        {
            InitializeComponent();
            btnChange.Click += new EventHandler(ChangePassword);
        }

        private void LoadProfile()
        {
            sEmployeeID = MainViewModel.GetInstance().login.user.ID_User;
            
            lblEmployeeName.Text = MainViewModel.GetInstance().login.user.Employee;
            lblUserName.Text = MainViewModel.GetInstance().login.user.Username;
            lblRoleName.Text = MainViewModel.GetInstance().login.user.Role;
        }

        private void ChangePassword(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                string sPass = txtPassword.Text.Trim();
                bool bValidPassword = SecurePassword.IsSecure(sPass);
                sPass = SecurePassword.Hash(sPass);

                if (bValidPassword)
                {
                    string sCommand = "UPDATE General.dbo.Users SET Password = @sPass WHERE ID_Employee = @sID";
                    using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                    {
                        using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@sID", SqlDbType.NVarChar).Value = sEmployeeID;
                            cmd.Parameters.Add("@sPass", SqlDbType.NVarChar).Value = sPass;

                            try
                            {
                                sqlConn.Open();
                                cmd.ExecuteNonQuery();
                                XtraMessageBox.Show("Password successfully changed.", "Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtPassword.EditValue = null;
                                txtConfirmPassword.EditValue = null;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show($"There has been an error: {ex.Message}");
                            }
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Password do not match, please verify", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }
    }
}