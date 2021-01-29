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
using System.Data.SqlClient;
using Diesel.Models;

namespace Diesel.Views
{
    public partial class frmComments : DevExpress.XtraEditors.XtraForm
    {
        private string ID_Diesel;
        private string sTruck;
        private DateTime dDate;
        private string ID_Comment;
        public frmComments(string ID_Diesel, string sTruck, DateTime dDate)
        {
            InitializeComponent();
            this.ID_Diesel = ID_Diesel;
            this.sTruck = sTruck;
            this.dDate = dDate;
            btnSave.Click += new EventHandler(SaveComments);
        }

        private void GetComments()
        {
            string sCommand = $"SELECT ID_Comment AS 'ID', ID_Diesel AS 'ID DIESEL', Comment AS 'COMMENT', Comment_Date AS 'DATE' FROM Diesel_Comments WHERE ID_Diesel = '{ID_Diesel}'";
            DataTable dt = SQL.Read(sCommand);
            if (dt.Rows.Count > 0)
            {
                ID_Comment = dt.Rows[0]["ID"].ToString();
                meComments.EditValue = dt.Rows[0]["COMMENT"].ToString();
                lblDate.Text = Convert.ToDateTime(dt.Rows[0]["DATE"]).ToLongDateString(); ;
            }
        }

        private void SaveComments(object sender, EventArgs e)
        {
            string sCommand = "";
            if (string.IsNullOrEmpty(ID_Comment))
            {
                sCommand = "INSERT INTO Diesel_Comments (ID_Comment, ID_Diesel, Comment, Comment_Date) VALUES (NEWID(), @sID_Diesel, @sComment, @dDate)";
            }
            else
            {
                sCommand = "UPDATE Diesel_Comments SET Comment = @sComment, Comment_Date = @dDate WHERE ID_Comment = @sID_Comment";
            }
            using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
            {
                using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@sID_Comment", SqlDbType.NVarChar).Value = !string.IsNullOrEmpty(ID_Comment) ? ID_Comment : (object)DBNull.Value;
                    cmd.Parameters.Add("@sID_Diesel", SqlDbType.NVarChar).Value = ID_Diesel;
                    cmd.Parameters.Add("@sComment", SqlDbType.NVarChar).Value = meComments.Text.Trim();
                    cmd.Parameters.Add("@dDate", SqlDbType.DateTime).Value = DateTime.Now;

                    try
                    {
                        sqlConn.Open();
                        cmd.ExecuteNonQuery();
                        XtraMessageBox.Show("Comment successfully inserted", "Comment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Comment could not be inserted. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            }
        

        private void frmComments_Load(object sender, EventArgs e)
        {
            lblTruck.Text = sTruck;
            lblLoadDate.Text = dDate.ToLongDateString();
            GetComments();
        }
    }
}