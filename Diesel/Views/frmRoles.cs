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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Diesel.Properties;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace Diesel.Views
{
    public partial class frmRoles : DevExpress.XtraEditors.XtraForm
    {
        private string sID;
        Dictionary<int, RepositoryItemButtonEdit> buttons = new Dictionary<int, RepositoryItemButtonEdit>();
        public frmRoles()
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(Save);
            btnClear.Click += new EventHandler(Clear);                       
        }

        private void Clear()
        {
            sID = null;
            txtRole.EditValue = null;
            rbFullControl.Checked = false;
            rbRead.Checked = false;
            rbWrite.Checked = false;
        }

        private void Clear(object sender, EventArgs e)
        {
            Clear();
        }

        private void LoadRoles()
        {
            string sCommand = "SELECT ID_Role AS 'ID', Role AS 'ROLE', FullControl AS 'FULLCONTROL', [Read] AS 'READ', Write AS 'WRITE' " +
                                "FROM Roles ORDER BY Role";
            DataTable dt = SQL.Read(sCommand);
            gvRoles.OptionsBehavior.Editable = true;
            gcRoles.DataSource = null;
            gvRoles.Columns.Clear();
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(" ", typeof(string));
                gcRoles.DataSource = dt;
                gvRoles.Columns["ID"].Visible = false;
                
                buttons = new Dictionary<int, RepositoryItemButtonEdit>();
                for (int i = 0; i < gvRoles.DataRowCount; i++)
                {
                    int rowHandle = gvRoles.GetRowHandle(i);
                    CreateActionBarRepositoryItemsForRow(rowHandle + 1);
                }
                gvRoles.BestFitColumns();
            }                        
        }

        private void CreateActionBarRepositoryItemsForRow(int rowHandle)
        {
            RepositoryItemButtonEdit someActionBar = new RepositoryItemButtonEdit();
            someActionBar.Name = rowHandle.ToString();
            someActionBar.Buttons.Clear();
                       
            EditorButton btn1 = new EditorButton(ButtonPredefines.Glyph);
            btn1.ImageOptions.Image = Resources.lapiz16x16;
            btn1.Caption = $"Edit-{rowHandle}";
            btn1.ToolTip = "Edit role";
            btn1.Click += (s, e) => { GetRole(rowHandle); };
            someActionBar.Buttons.Add(btn1);

            EditorButton btn = new EditorButton(ButtonPredefines.Glyph);
            btn.ImageOptions.Image = Resources.trash_can16x16;
            btn.Caption = $"Delete-{rowHandle}";
            btn.ToolTip = "Delete role";
            btn.Click += (s, e) => { DeleteRole(rowHandle); };
            someActionBar.Buttons.Add(btn);

            buttons.Add(rowHandle, someActionBar);
        }

        private void GV_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                //GetRole(view, info);
            }

        }

        private void GetRole(int rowHandle)
        {
            GridView view = gvRoles;
            try
            {
                sID = view.GetRowCellValue(rowHandle - 1, "ID").ToString();
                txtRole.Text = view.GetRowCellValue(rowHandle - 1, "ROLE").ToString();
                rbFullControl.Checked = Convert.ToBoolean(view.GetRowCellValue(rowHandle - 1, "FULLCONTROL"));
                rbRead.Checked = Convert.ToBoolean(view.GetRowCellValue(rowHandle - 1, "READ"));
                rbWrite.Checked = Convert.ToBoolean(view.GetRowCellValue(rowHandle - 1, "WRITE"));
            }
            catch { }
        }

        private void Save(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRole.Text))
            {
                using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateDieselRoles", sqlConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sID_Role", SqlDbType.NVarChar).Value = !string.IsNullOrEmpty(sID) ? sID : (object)DBNull.Value;
                        cmd.Parameters.Add("@sRole", SqlDbType.NVarChar).Value = txtRole.Text.Trim();
                        cmd.Parameters.Add("@bFullControl", SqlDbType.Bit).Value = rbFullControl.Checked;
                        cmd.Parameters.Add("@bRead", SqlDbType.Bit).Value = rbRead.Checked;
                        cmd.Parameters.Add("@bWrite", SqlDbType.Bit).Value = rbWrite.Checked;
                        cmd.Parameters.Add("@bDelete", SqlDbType.Bit).Value = false;

                        try
                        {
                            sqlConn.Open();
                            cmd.ExecuteNonQuery();
                            XtraMessageBox.Show($"Role \"{txtRole.Text}\" has been saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            LoadRoles();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show($"There has been an error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("The Role field is missing, please verify.", "Data missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteRole(int rowHandle)
        {
            string sID_Role = gvRoles.GetRowCellValue(rowHandle - 1, "ID").ToString();
            if (XtraMessageBox.Show("You are about to eliminate this role.\nDo you want to continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sCommand = $"DELETE FROM Roles WHERE ID_Role = @sID";
                using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                {
                    using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sID", SqlDbType.NVarChar).Value = sID_Role;
                        try
                        {
                            sqlConn.Open();
                            cmd.ExecuteNonQuery();
                            XtraMessageBox.Show("The role was successfully deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRoles();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show($"There has been an error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void gvRoles_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != " ")
                return;
            int rowHandle = e.RowHandle + 1;
            if (buttons.ContainsKey(rowHandle))
            {
                e.RepositoryItem = buttons[rowHandle];
            }
        }

        private void frmRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainViewModel.GetInstance().users.FillRoles();
        }
    }
}