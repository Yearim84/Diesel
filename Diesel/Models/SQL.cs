using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diesel.Models
{
    public static class SQL
    {
        public static DataTable Read(string sQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(Constants.cn))
                {
                    using (SqlCommand cmd = new SqlCommand(sQuery, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"There has been an error: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}
