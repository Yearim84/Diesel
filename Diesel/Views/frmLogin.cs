using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diesel.Models;

namespace Diesel.Views
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public Users user;
        public string sVersion;

        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += new EventHandler(Login);
            txtUser.KeyDown += new KeyEventHandler(LoginEnter);
            txtPassword.KeyDown += new KeyEventHandler(LoginEnter);
            sVersion = CurrentPublishedVersion();
        }

        private string CurrentPublishedVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return " V" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            else
            {
                return "";
            }
        }

        private void Login(object sender, EventArgs e)
        {
            Login();
        }

        private void LoginEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    Login();
                }
            }
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                XtraMessageBox.Show("Please type your user name and password then click \"Login\"", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                string sUser = txtUser.Text.Trim();
                string sPass = txtPassword.Text.Trim();
                using (SqlConnection sqlConn = new SqlConnection(Constants.cn))
                {
                    string sCommand = "SELECT em.ID_Employee AS 'ID', em.Name + ' ' + em.P_LastName + ' ' + em.M_LastName AS 'EMPLOYEE', us.Username AS 'USERNAME', " +
                                        "us.Password AS 'PASSWORD', us.FirstTime AS 'FIRST TIME', us.Status AS 'STATUS' " +
                                        "FROM General.dbo.Users us " +
                                        "LEFT JOIN General.dbo.Employees em ON em.ID_Employee = us.ID_Employee " +
                                        "WHERE Username = @sUser";
                    using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sUser", SqlDbType.NVarChar).Value = sUser;
                        try
                        {
                            sqlConn.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                        catch (Exception ex) { }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    user = new Users()
                    {
                        ID_User = dt.Rows[0]["ID"].ToString(),
                        Employee = dt.Rows[0]["EMPLOYEE"].ToString(),
                        Username = dt.Rows[0]["USERNAME"].ToString(),
                        Password = dt.Rows[0]["PASSWORD"].ToString(),
                        FirstTime = Convert.ToBoolean(dt.Rows[0]["FIRST TIME"]),
                        Status = Convert.ToBoolean(dt.Rows[0]["STATUS"])
                    };

                    if (SecurePassword.Verify(sPass, user.Password))
                    {
                        string sCommand = "SELECT rl.Role AS 'ROLE', rl.FullControl AS 'FULL', rl.[Read] AS 'READ', rl.Write AS 'WRITE' " +
                                            "FROM DieselUsers du " +
                                            "LEFT JOIN Roles rl ON rl.ID_Role = du.role " +
                                            "LEFT JOIN General.dbo.Users us ON us.ID_User = du.ID_User " +
                                            $"WHERE us.ID_Employee = '{user.ID_User}'";

                        DataTable dtRole = SQL.Read(sCommand);
                        if (dtRole.Rows.Count > 0)
                        {
                            user.Role = dtRole.Rows[0]["ROLE"].ToString();
                            user.Full = Convert.ToBoolean(dtRole.Rows[0]["FULL"]);                            
                            user.Read = Convert.ToBoolean(dtRole.Rows[0]["READ"]);
                            user.Write = Convert.ToBoolean(dtRole.Rows[0]["WRITE"]);
                            MainViewModel.GetInstance().login = this;
                            Hide();
                            MainViewModel.GetInstance().main = new frmMain();
                            MainViewModel.GetInstance().main.Show();
                        }
                        else
                        {
                            XtraMessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("The password is incorrect, please try again.", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                    }
                }
                else
                {
                    XtraMessageBox.Show("The user is incorrect, please try again.", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Text = $"Diesel Login {sVersion}";
            txtUser.Focus();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}