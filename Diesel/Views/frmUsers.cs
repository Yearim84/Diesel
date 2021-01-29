using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Diesel.Models;
using Diesel.Properties;
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

namespace Diesel.Views
{
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        private string sPk_id;
        private string sID_User;
        private string sID_Employee;
        private string sID_Role;
        private DataTable dtUsers;
        Dictionary<int, RepositoryItemButtonEdit> buttons = new Dictionary<int, RepositoryItemButtonEdit>();

        public frmUsers()
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(SaveUser);
            btnRoles.Click += new EventHandler(AddRole);
        }

        private void Clear()
        {
            cmbUser.SelectedIndex = -1;
            cmbRoles.SelectedIndex = -1;
        }

        private void FillEmployees()
        {
            dtUsers = new DataTable();
            string sCommand = "SELECT em.ID_Employee AS 'ID', us.ID_User AS 'ID USER', em.Name + ' ' + em.P_LastName + ' ' + em.M_LastName AS 'USER' " +
                                "FROM General.dbo.Employees em " +
                                "LEFT JOIN General.dbo.Users us ON us.ID_Employee = em.ID_Employee " +
                                "WHERE us.ID_User IS NOT NULL " +
                                "ORDER BY Name";
            dtUsers = SQL.Read(sCommand);            

            cmbUser.DataSource = null;
            cmbUser.ValueMember = "ID USER";
            cmbUser.DisplayMember = "USER";
            cmbUser.DataSource = dtUsers;
            cmbUser.SelectedIndex = -1;
        }

        public void FillRoles()
        {
            string sCommand = "SELECT ID_Role AS 'ID', Role AS 'ROLE' FROM Roles ORDER BY Role";
            DataTable dt = SQL.Read(sCommand);
            cmbRoles.DataSource = null;
            cmbRoles.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                cmbRoles.ValueMember = "ID";
                cmbRoles.DisplayMember = "ROLE";
                cmbRoles.DataSource = dt;
                cmbRoles.SelectedIndex = -1;
            }
        }

        private void LoadUsers()
        {
            DataTable dt = new DataTable();
            string sCommand = "SELECT du.pk_id AS 'ID', em.Name + ' ' + em.P_LastName + ' ' + em.M_LastName AS 'EMPLOYEE', rl.Role AS 'ROLE' " +
                                "FROM DieselUsers du " +
                                "LEFT JOIN General.dbo.Users us ON us.ID_User = du.ID_User " +
                                "LEFT JOIN Roles rl ON rl.ID_Role = du.role " +
                                "LEFT JOIN General.dbo.Employees em ON em.ID_Employee = us.ID_Employee";
            using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
            {
                using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            gcUsers.DataSource = dt;
            gvUsers.BestFitColumns();
            buttons = new Dictionary<int, RepositoryItemButtonEdit>();
            for (int i = 0; i < gvUsers.DataRowCount; i++)
            {
                int rowHandle = gvUsers.GetRowHandle(i);
                CreateActionBarRepositoryItemsForRow(rowHandle + 1);
            }
            gvUsers.Columns["ID"].Visible = false;
        }

        private void SaveUser(object sender, EventArgs e)
        {
            if (cmbUser.SelectedIndex > -1 && cmbRoles.SelectedIndex > -1)
            {
                string sMessage = "";
                string sCommand = "";
                if (Exists())
                {
                    sCommand = "UPDATE DieselUsers SET role = @sRole WHERE ID_User = @sID_User";
                    sMessage = "updated";
                }
                else
                {
                    sCommand = "INSERT INTO DieselUsers (pk_id, ID_User, role) VALUES (NEWID(), @sID_User, @sRole)";
                    sMessage = "added";
                }

                using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                {
                    using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sID_User", SqlDbType.NVarChar).Value = sID_User;
                        cmd.Parameters.Add("@sRole", SqlDbType.NVarChar).Value = sID_Role;
                        try
                        {
                            sqlConn.Open();
                            cmd.ExecuteNonQuery();
                            XtraMessageBox.Show($"User was successfully {sMessage}.", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            LoadUsers();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show($"There has been an error: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
        }

        private void DeleteUser(int rowHandle)
        {
            string sUser = gvUsers.GetRowCellValue(rowHandle - 1, "ID").ToString();

            if (XtraMessageBox.Show("You are about to eliminate this user.\nDo you want to continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sCommand = $"DELETE FROM DieselUsers WHERE pk_id = @sID";
                using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                {
                    using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sID", SqlDbType.NVarChar).Value = sUser;
                        try
                        {
                            sqlConn.Open();
                            cmd.ExecuteNonQuery();
                            XtraMessageBox.Show("The user was successfully deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show($"There has been an error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void GetUser(int rowHandle)
        {
            GridView view = gvUsers;
            try
            {
                sID_User = view.GetRowCellValue(rowHandle - 1, "ID").ToString();
                cmbUser.Text = view.GetRowCellValue(rowHandle - 1, "EMPLOYEE").ToString();
                cmbRoles.Text = view.GetRowCellValue(rowHandle - 1, "ROLE").ToString();                
            }
            catch { }
        }

        private bool Exists()
        {
            string sCommand = $"SELECT pk_id FROM DieselUsers WHERE ID_User = '{sID_User}'";
            DataTable dt = SQL.Read(sCommand);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddRole(object sender, EventArgs e)
        {
            MainViewModel.GetInstance().roles = new frmRoles();
            MainViewModel.GetInstance().roles.ShowDialog();
        }

        private void CreateActionBarRepositoryItemsForRow(int rowHandle)
        {
            RepositoryItemButtonEdit someActionBar = new RepositoryItemButtonEdit();
            someActionBar.Name = rowHandle.ToString();
            someActionBar.Buttons.Clear();

            EditorButton btn1 = new EditorButton(ButtonPredefines.Glyph);
            btn1.ImageOptions.Image = Resources.lapiz16x16;
            btn1.Caption = $"Edit-{rowHandle}";
            btn1.ToolTip = "Edit user";
            btn1.Click += (s, e) => { GetUser(rowHandle); };
            someActionBar.Buttons.Add(btn1);

            EditorButton btn = new EditorButton(ButtonPredefines.Glyph);
            btn.ImageOptions.Image = Resources.trash_can16x16;
            btn.Caption = $"Delete-{rowHandle}";
            btn.ToolTip = "Delete user";
            btn.Click += (s, e) => { DeleteUser(rowHandle); };
            someActionBar.Buttons.Add(btn);

            buttons.Add(rowHandle, someActionBar);
        }

        

        private void frmUsers_Load(object sender, EventArgs e)
        {
            FillEmployees();
            FillRoles();
            LoadUsers();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sID_User = cmbUser.SelectedValue.ToString();
            }
            catch
            {
                sID_User = null;
            }

        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sID_Role = cmbRoles.SelectedValue.ToString();
            }
            catch
            {
                sID_Role = null;
            }
        }

        private void gvUsers_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "EMPLOYEE")
                return;
            int rowHandle = e.RowHandle + 1;
            if (buttons.ContainsKey(rowHandle))
            {
                e.RepositoryItem = buttons[rowHandle];
            }
        }

        
    }
}