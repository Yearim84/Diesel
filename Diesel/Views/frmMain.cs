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
using ExcelDataReader;
using System.IO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Diesel.Properties;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using DevExpress.XtraGrid.Columns;

namespace Diesel.Views
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private string sID_Employee;
        private string sEmployee;
        private bool bFullControl;
        private bool bWrite;
        private bool bRead;        
        private bool bLoad;
        private bool bImport = false;
        private bool bDark = false;
        private DataTable dtDrivers;

        Dictionary<int, RepositoryItemButtonEdit> buttons = new Dictionary<int, RepositoryItemButtonEdit>();        

        public frmMain()
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(SaveData);            
            btnAddNewRow.Click += new EventHandler(AddNewRow);
            btnExcel.Click += new EventHandler(ExportToExcel);
        }

        #region Methods
        private void ValidateUser()
        {
            if (!bFullControl)
            {
                barSubItemCatalogs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                
                if (!bWrite)
                {
                    barButtonLoadExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barSubItemDashboardDesigner.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                                 
                }
            }
        }

        private void ClearGridView()
        {
            gcDiesel.DataSource = null;
            gvDiesel.Columns.Clear();
            //btnSave.Visible = false;            
            gvDiesel.OptionsSelection.MultiSelect = false;
            gvDiesel.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
        }

        private void FillTrucksCombo()
        {
            string sCommand = "SELECT pk_id AS 'ID', truck AS 'TRUCK' FROM General.dbo.Trucks WHERE truck <> 'N/A' ORDER BY truck";
            DataTable dt = SQL.Read(sCommand);
            cmbTrucks.DataSource = null;
            if (dt.Rows.Count > 0)
            {
                cmbTrucks.ValueMember = "ID";
                cmbTrucks.DisplayMember = "TRUCK";
                cmbTrucks.DataSource = dt.DefaultView;
                cmbTrucks.SelectedIndex = -1;
            }
        }

        private void FillDriversList()
        {
            string sCommand = "SELECT pk_id AS 'ID', driverName + ' ' + pat_surname + ' ' + mat_surname AS 'DRIVER' FROM General.dbo.Drivers ORDER BY driverName";
            dtDrivers = SQL.Read(sCommand);
        }
                
        private void LoadExcel()
        {
            btnAddNewRow.Visible = false;
            bLoad = true;
            OpenFileDialog open = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "Excel Files (*.xlsx, *.xls, *.csv)|*.xlsx; *.csv; *.xls"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (open.FileNames.Length > 0)
                    {
                        Enabled = false;
                        DataSet dsCSV = new DataSet();
                        DataSet dsExcel = new DataSet();
                        for (int i = 0; i < open.FileNames.Length; i++)
                        {
                            string sFileName = open.FileNames[i];
                            string sFileExtension = Path.GetExtension(sFileName);

                            switch (sFileExtension)
                            {
                                case ".csv":
                                    DataTable dtCSV = ImportCSV(sFileName);
                                    dtCSV.TableName = $"CSV-{i}";
                                    dsCSV.Tables.Add(dtCSV);
                                    break;

                                case ".xls":
                                    DataTable dtExcel = ImportExcel(sFileName).Tables[0];
                                    dtExcel.TableName = $"Excel-{i}";
                                    dsExcel.Merge(dtExcel);
                                    break;
                            }
                        }
                        ClearGridView();
                        gvDiesel.OptionsSelection.MultiSelect = true;
                        gvDiesel.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                        gcDiesel.DataSource = MergeTables(dsCSV, dsExcel);
                        gvDiesel.BestFitColumns();
                        gvDiesel.Columns["ID_TRUCK"].Visible = false;
                        gvDiesel.Columns["ID_DRIVER"].Visible = false;

                        buttons = new Dictionary<int, RepositoryItemButtonEdit>();
                        bImport = true;
                        Enabled = true;
                    }                    
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Enabled = true;
                }
            }
        }

        private DataTable ImportCSV(string sFile)
        {
            DataTable dtCSV = new DataTable();
            using (StreamReader reader = new StreamReader(sFile))
            {               
                string[] sHeaders = reader.ReadLine().Split(';');
                sHeaders = reader.ReadLine().Split(';');
                foreach(string header in sHeaders)
                {
                    string sHeader = header.Replace("\"", string.Empty);
                    sHeader = sHeader.Replace("\t", string.Empty);
                    dtCSV.Columns.Add(sHeader);
                }

                while(!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(';');
                    DataRow drRow = dtCSV.NewRow();
                    for (int i = 0; i < sHeaders.Length; i++)
                    {
                        string sRowValue = rows[i].Replace("\"", string.Empty);
                        sRowValue = sRowValue.Replace("\t", string.Empty);
                        drRow[i] = sRowValue;
                    }
                    dtCSV.Rows.Add(drRow);
                }
            }
            return dtCSV;
        }

        private DataSet ImportExcel(string sFile)
        {
            DataSet dsExcel = new DataSet();
            try
            {
                if (!string.IsNullOrEmpty(sFile))
                {
                    using (var stream = File.Open(sFile, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            dsExcel = reader.AsDataSet();                            
                        }
                    }
                    foreach (DataTable dt in dsExcel.Tables)
                    {
                        for (int i = 0; i <= 8; i++)
                        {
                            if (i == 8)
                            {
                                for (int j = 0; j < 36; j++)
                                {
                                    dt.Columns[j].ColumnName = dt.Rows[0][j].ToString();
                                }
                            }
                            dt.Rows.RemoveAt(0);
                        }
                        dt.AcceptChanges();
                    }                    
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"There has been an error opening the Excel file: {ex.Message}");
            }
            return dsExcel;
        }

        private DataTable MergeTables(DataSet dsCSV, DataSet dsExcel)
        {
            DataTable dtCSV = new DataTable();
            DataTable dtExcel = new DataTable();
            foreach (DataTable dt in dsCSV.Tables)
            {
                dtCSV.Merge(dt);
            }
            foreach (DataTable dt in dsExcel.Tables)
            {
                dtExcel.Merge(dt);
            }

            string sCommand = "SELECT pk_id AS 'ID_TRUCK', truck AS 'TRUCK', make AS 'MAKE', engine AS 'ENGINE', owner AS 'OWNER' FROM General.dbo.Trucks ORDER BY truck";
            DataTable dtTrucks = SQL.Read(sCommand);

            sCommand = "SELECT pk_id AS 'ID', driverName + ' ' + pat_surname + ' ' + mat_surname AS 'DRIVER', Comdata_Emp_Number AS 'COMDATA', Local_Emp_Number AS 'LOCAL', " +
                        "Comdata_Emp_Number2 AS 'COMDATA2' " +
                        "FROM General.dbo.Drivers ORDER BY driverName";
            DataTable dtDrivers = SQL.Read(sCommand);

            DataTable dtMerge = new DataTable();
            dtMerge.Columns.Add("DATE", typeof(string));
            dtMerge.Columns.Add("ID_DRIVER", typeof(string));
            dtMerge.Columns.Add("DRIVER", typeof(string));
            dtMerge.Columns.Add("EMP NUM", typeof(string));
            dtMerge.Columns.Add("CARD", typeof(string));
            dtMerge.Columns.Add("GALLONS", typeof(decimal));
            dtMerge.Columns.Add("FUEL COST", typeof(decimal));
            dtMerge.Columns.Add("ID_LOC", typeof(string));
            dtMerge.Columns.Add("TRUCK TYPE", typeof(string));
            dtMerge.Columns.Add("ID_TRUCK", typeof(string));
            dtMerge.Columns.Add("TRUCK", typeof(string));
            dtMerge.Columns.Add("ENGINE", typeof(string));
            dtMerge.Columns.Add("OWNER", typeof(string));
            dtMerge.Columns.Add("MILEAGE", typeof(Int64));
            dtMerge.Columns.Add("PLACE OF TRANSACTION", typeof(string));

            foreach (DataRow drRow in dtCSV.Rows)
            {
                string sID_Truck = "";
                string sTruck = "";
                string sID_Driver = "";
                string sMake = "";
                string sEngine = "";
                string sOwner = "";

                try
                {
                    sTruck = drRow["vehicle"].ToString();
                    DataRow[] drTruck = dtTrucks.Select($"TRUCK = '{sTruck}'");

                    sID_Truck = drTruck[0]["ID_TRUCK"].ToString();
                    sMake = drTruck[0]["MAKE"].ToString();
                    sEngine = drTruck[0]["ENGINE"].ToString();
                    sOwner = drTruck[0]["OWNER"].ToString();
                }
                catch (Exception ex) { }

                try
                {
                    string sDriverNumber = drRow["driver number"].ToString();
                    if (sDriverNumber.Length == 3)
                    {
                        sDriverNumber = $"0{sDriverNumber}";
                    }
                    else if (sDriverNumber.Length == 2)
                    {
                        sDriverNumber = $"00{sDriverNumber}";
                    }
                    else if (sDriverNumber.Length == 1)
                    {
                        sDriverNumber = $"000{sDriverNumber}";
                    }

                    if (!string.IsNullOrEmpty(sDriverNumber))
                    {
                        DataRow[] drDriver = dtDrivers.Select($"LOCAL = '{sDriverNumber}'");
                        sID_Driver = drDriver[0]["ID"].ToString();
                    }
                }
                catch (Exception ex) { }

                DataRow drMerge = dtMerge.NewRow();
                DateTime dDate = Convert.ToDateTime(drRow["date"]);
                drMerge["DATE"] = dDate.ToString("MM/dd/yyyy HH:mm");
                drMerge["ID_DRIVER"] = sID_Driver;
                drMerge["DRIVER"] = drRow["driver"];
                drMerge["EMP NUM"] = drRow["driver number"];
                drMerge["CARD"] = "N/A";
                drMerge["GALLONS"] = drRow["value"];
                drMerge["FUEL COST"] = 0;
                drMerge["ID_LOC"] = "LOCAL";
                drMerge["TRUCK TYPE"] = sMake;
                drMerge["ID_TRUCK"] = sID_Truck;
                drMerge["TRUCK"] = drRow["vehicle"];
                drMerge["ENGINE"] = sEngine;
                drMerge["OWNER"] = sOwner;
                try
                {
                    drMerge["MILEAGE"] = drRow["mileage/operating hours"];
                }
                catch
                {
                    drMerge["MILEAGE"] = 0;
                }
                drMerge["PLACE OF TRANSACTION"] = drRow["delivery point"];
                dtMerge.Rows.Add(drMerge);
            }

            foreach (DataRow drRow in dtExcel.Rows)
            {
                string sID_Truck = "";
                string sTruck = "";
                string sID_Driver = "";
                string sMake = "";
                string sEngine = "";
                string sOwner = "";

                try
                {
                    DataRow[] drTruck = dtTrucks.Select($"TRUCK = {drRow["Unit Number"].ToString()}");
                    sID_Truck = drTruck[0]["ID_TRUCK"].ToString();
                    sTruck = drTruck[0]["TRUCK"].ToString();
                    sMake = drTruck[0]["MAKE"].ToString();
                    sEngine = drTruck[0]["ENGINE"].ToString();
                    sOwner = drTruck[0]["OWNER"].ToString();
                }
                catch { }

                try
                {
                    string sDriverNumber = drRow["Employee Number"].ToString();
                    if (sDriverNumber.Length == 3)
                    {
                        sDriverNumber = $"0{sDriverNumber}";
                    }
                    else if (sDriverNumber.Length == 2)
                    {
                        sDriverNumber = $"00{sDriverNumber}";
                    }
                    else if (sDriverNumber.Length == 1)
                    {
                        sDriverNumber = $"000{sDriverNumber}";
                    }

                    if (!string.IsNullOrEmpty(sDriverNumber))
                    {
                        try
                        {
                            DataRow[] drDriver = dtDrivers.Select($"COMDATA = '{sDriverNumber}'");
                            sID_Driver = drDriver[0]["ID"].ToString();
                        }
                        catch
                        {
                            DataRow[] drDriver = dtDrivers.Select($"COMDATA2 = '{sDriverNumber}'");
                            sID_Driver = drDriver[0]["ID"].ToString();
                        }

                    }
                }
                catch (Exception ex)
                {

                }

                DateTime dDate = Convert.ToDateTime(drRow["Transaction Date"]);
                TimeSpan tsTime = TimeSpan.Parse(drRow["Transaction Time"].ToString());
                dDate = dDate.Date + tsTime;
                DataRow drMerge = dtMerge.NewRow();
                drMerge["DATE"] = dDate.ToString("MM/dd/yyyy HH:mm");
                drMerge["ID_DRIVER"] = sID_Driver;
                drMerge["DRIVER"] = drRow["Driver's Name"];
                drMerge["EMP NUM"] = drRow["Employee Number"];
                drMerge["CARD"] = drRow["Comchek Card Number"].ToString().Substring(drRow["Comchek Card Number"].ToString().Length - 4);
                drMerge["GALLONS"] = drRow["Number of Tractor Gallons"];
                drMerge["FUEL COST"] = drRow["Cost of Tractor Fuel"];
                drMerge["ID_LOC"] = "COMDATA";
                drMerge["TRUCK TYPE"] = sMake;
                drMerge["ID_TRUCK"] = sID_Truck;
                drMerge["TRUCK"] = drRow["Unit Number"];
                drMerge["ENGINE"] = sEngine;
                drMerge["OWNER"] = sOwner;
                try
                {
                    drMerge["MILEAGE"] = drRow["Hubometer Reading"];
                }
                catch
                {
                    drMerge["MILEAGE"] = 0;
                }
                string sCity = $"{drRow["Truck Stop City"]}, {drRow["Truck Stop State"]}";
                drMerge["PLACE OF TRANSACTION"] = sCity;
                dtMerge.Rows.Add(drMerge);
            }

            DataView view = dtMerge.DefaultView;
            view.Sort = "Truck ASC";
            dtMerge = view.ToTable();
            return dtMerge;
        }

        private void GetTruckData()
        {            
            bLoad = false;
            Enabled = false;
            string sCommand = "";
            string sCompCommand = "";
            
            if (chkDate.Checked)
            {
                if (dtpFrom.EditValue != null && dtpTo.EditValue != null)
                {
                    sCompCommand = $"WHERE Date >= '{dtpFrom.DateTime}' AND Date < '{dtpTo.DateTime.AddDays(1)}' ";
                }
                else
                {
                    sCompCommand = $"WHERE Date >= '{DateTime.Today}' AND Date < '{DateTime.Today.AddDays(1)}' ";
                }
            }            

            if (chkAll.Checked)
            {               
                sCommand = "SELECT dm.ID_Diesel AS 'ID', dm.Date AS 'DATE', dm.ID_Driver AS 'DRIVER', dm.Card AS 'CARD', " +
                            "dm.Gallons AS 'GALLONS', dm.Fuel_Cost AS 'FUEL COST', IIF(dm.Card = 'N/A', 'LOCAL', 'COMDATA') AS 'ID_LOC', tr.pk_id AS 'ID_TRUCK', tr.make AS 'TRUCK_TYPE', " +
                            "tr.truck AS 'TRUCK', dm.Mileage AS 'MILEAGE', '' AS 'PREVIOUS', '' AS 'MILES', '' AS 'MPG', '' AS 'AVERAGE', dm.PlaceOfTransaction AS 'PLACE OF TRANSACTION', " +
                            "dm.Suspect AS 'SUSPECT', '' AS 'CONTROLS' " +
                            "FROM Diesel_Main dm " +
                            "LEFT JOIN General.dbo.Trucks tr ON tr.pk_id = dm.ID_Truck " +
                            "LEFT JOIN General.dbo.Drivers dr ON dr.pk_id = dm.ID_Driver " +
                            $"{sCompCommand}" +
                            "ORDER BY tr.truck, dm.Date";
            }
            else
            {
                if (!string.IsNullOrEmpty(sCompCommand))
                {
                    sCompCommand = $"AND{sCompCommand.Substring(5)}";
                }                
                sCommand = "SELECT dm.ID_Diesel AS 'ID', dm.Date AS 'DATE', dm.ID_Driver AS 'DRIVER', dm.Card AS 'CARD', " +
                            "dm.Gallons AS 'GALLONS', dm.Fuel_Cost AS 'FUEL COST', IIF(dm.Card = 'N/A', 'LOCAL', 'COMDATA') AS 'ID_LOC', tr.pk_id AS 'ID_TRUCK', tr.make AS 'TRUCK_TYPE', " +
                            "tr.truck AS 'TRUCK', dm.Mileage AS 'MILEAGE', '' AS 'PREVIOUS', '' AS 'MILES', '' AS 'MPG', '' AS 'AVERAGE', dm.PlaceOfTransaction AS 'PLACE OF TRANSACTION', " +
                            "dm.Suspect AS 'SUSPECT', '' AS 'CONTROLS' " +
                            "FROM Diesel_Main dm " +
                            "LEFT JOIN General.dbo.Trucks tr ON tr.pk_id = dm.ID_Truck " +
                            "LEFT JOIN General.dbo.Drivers dr ON dr.pk_id = dm.ID_Driver " +
                            $"WHERE dm.ID_Truck = '{cmbTrucks.SelectedValue}' " +
                            $"{sCompCommand}" +
                            "ORDER BY dm.Date";
            }
            DataTable dt = SQL.Read(sCommand);
            GetMiles(dt);
            ClearGridView();
            gvDiesel.OptionsSelection.MultiSelect = true;
            gvDiesel.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            if (dt.Rows.Count > 0)
            {
                gcDiesel.DataSource = dt.DefaultView;
                gvDiesel.Columns["ID"].Visible = false;
                gvDiesel.Columns["ID_TRUCK"].Visible = false;                    
                gvDiesel.BestFitColumns();
                buttons = new Dictionary<int, RepositoryItemButtonEdit>();
                for (int i = 0; i < gvDiesel.DataRowCount; i++)
                {
                    int rowHandle = gvDiesel.GetRowHandle(i);
                    CreateActionBarRepositoryItemsForRow(rowHandle + 1);
                }
                btnAddNewRow.Visible = true;
            }
            bImport = false;
            Enabled = true;            
        }

        private void GetMiles(DataTable dt)
        {
            int nInit = 0;
            int nEnd = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Int64 nMiles = 0;
                Int64 nPrev = 0;
                decimal nMPG = 0;
                decimal nAVG = 0;
                if (i > 0)
                {
                    try
                    {                        
                        if (dt.Rows[i]["TRUCK"].ToString() == dt.Rows[i - 1]["TRUCK"].ToString())
                        {
                            nEnd++;
                            nPrev = Convert.ToInt64(dt.Rows[i - 1]["MILEAGE"]);

                            try
                            {
                                nMiles = Convert.ToInt64(dt.Rows[i]["MILEAGE"]) - nPrev;
                            }
                            catch { }

                            try
                            {
                                nMPG = Convert.ToDecimal(nMiles) / Convert.ToDecimal(dt.Rows[i]["GALLONS"]);
                            }
                            catch { }
                        }
                        else
                        {
                            nPrev = 0;
                            nMiles = 0;
                            nMPG = 0;
                            nInit = i;
                            nEnd = i;                            
                        }

                    }
                    catch { }
                }
                dt.Rows[i]["PREVIOUS"] = nPrev;
                dt.Rows[i]["MILES"] = nMiles;
                dt.Rows[i]["MPG"] = nMPG;
                if (i > nInit)
                {                    
                    decimal nMPGsum = 0;
                    for (int j = i; j >= nInit; j--)
                    {
                        nMPGsum += Convert.ToDecimal(dt.Rows[j]["MPG"]);
                        if (j == nInit)
                        {
                            nAVG = nMPGsum / (i - nInit);
                        }
                    }
                    dt.Rows[i]["AVERAGE"] = nAVG;
                }
            }
        }
        
        private void SaveData(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("You are about to save all data.\nDoyou want to continue?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Enabled = false;
                for (int i = 0; i < gvDiesel.DataRowCount; i++)
                {
                    string sID_Diesel = "";
                    try
                    {
                        sID_Diesel = gvDiesel.GetRowCellValue(i, "ID").ToString();
                    }
                    catch { }

                    string sID_Truck = "";
                    try
                    {
                        sID_Truck = gvDiesel.GetRowCellValue(i, "ID_TRUCK").ToString();
                    }
                    catch { }

                    string sID_Driver = "";
                    try
                    {
                        if (bImport)
                        {
                            sID_Driver = gvDiesel.GetRowCellValue(i, "ID_DRIVER").ToString();
                        }
                        else
                        {
                            sID_Driver = gvDiesel.GetRowCellValue(i, "DRIVER").ToString();
                        }
                    }
                    catch { }
                    DateTime dDate = Convert.ToDateTime(gvDiesel.GetRowCellValue(i, "DATE"));
                    string sCard = gvDiesel.GetRowCellValue(i, "CARD").ToString();
                    decimal nGallons = Convert.ToDecimal(gvDiesel.GetRowCellValue(i, "GALLONS"));
                    decimal nCost = Convert.ToDecimal(gvDiesel.GetRowCellValue(i, "FUEL COST"));
                    Int64 nMileage = 0;
                    try
                    {
                        nMileage = Convert.ToInt64(gvDiesel.GetRowCellValue(i, "MILEAGE"));
                    }
                    catch { }

                    int nMiles = 0;
                    try
                    {
                        nMiles = Convert.ToInt32(gvDiesel.GetRowCellValue(i, "MILES"));
                    }
                    catch { }

                    decimal nMPG = 0;
                    try
                    {
                        nMPG = Convert.ToDecimal(gvDiesel.GetRowCellValue(i, "MPG"));
                    }
                    catch { }

                    decimal nAVG = 0;
                    try
                    {
                        nAVG = Convert.ToDecimal(gvDiesel.GetRowCellValue(i, "AVERAGE"));
                    }
                    catch { }

                    Int64 nPrevious = 0;
                    try
                    {
                        nPrevious = Convert.ToInt64(gvDiesel.GetRowCellValue(i, "PREVIOUS"));
                    }
                    catch { }

                    string sPlace = gvDiesel.GetRowCellValue(i, "PLACE OF TRANSACTION").ToString();
                    bool bSuspect = false;
                    try
                    {
                        bSuspect = Convert.ToBoolean(gvDiesel.GetRowCellValue(i, "SUSPECT"));
                    }
                    catch { }

                    using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DieselMain", sqlConn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@sID_Diesel", SqlDbType.NVarChar).Value = !string.IsNullOrEmpty(sID_Diesel) ? sID_Diesel : (object)DBNull.Value;
                            cmd.Parameters.Add("@sID_Truck", SqlDbType.NVarChar).Value = sID_Truck;
                            cmd.Parameters.Add("@sID_Driver", SqlDbType.NVarChar).Value = sID_Driver;
                            cmd.Parameters.Add("@dDate", SqlDbType.DateTime).Value = dDate;
                            cmd.Parameters.Add("@sCard", SqlDbType.NVarChar).Value = sCard;
                            cmd.Parameters.Add("@nGallons", SqlDbType.Decimal).Value = nGallons;
                            cmd.Parameters.Add("@nCost", SqlDbType.Decimal).Value = nCost;
                            cmd.Parameters.Add("@nMileage", SqlDbType.BigInt).Value = nMileage;
                            cmd.Parameters.Add("@nMiles", SqlDbType.BigInt).Value = nMiles;
                            cmd.Parameters.Add("@nMPG", SqlDbType.Decimal).Value = nMPG;
                            cmd.Parameters.Add("@nAVG", SqlDbType.Decimal).Value = nAVG;
                            cmd.Parameters.Add("@sPlace", SqlDbType.NVarChar).Value = sPlace;
                            cmd.Parameters.Add("@bSuspect", SqlDbType.Bit).Value = bSuspect;
                            cmd.Parameters.Add("@sID_Employee", SqlDbType.NVarChar).Value = sID_Employee;
                            cmd.Parameters.Add("@bImport", SqlDbType.Bit).Value = bImport;

                            try
                            {
                                sqlConn.Open();
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
                XtraMessageBox.Show("Data successfully registered", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGridView();
                //btnSave.Visible = false;
                Enabled = true;
            }
        }

        private void SaveRow(int rowHandle)
        {
            string sID = gvDiesel.GetRowCellValue(rowHandle - 1, "ID").ToString();
            string sID_Truck = gvDiesel.GetRowCellValue(rowHandle - 1, "ID_TRUCK").ToString();
            string sID_Driver = gvDiesel.GetRowCellValue(rowHandle - 1, "DRIVER").ToString();
            DateTime dDate = Convert.ToDateTime(gvDiesel.GetRowCellValue(rowHandle - 1, "DATE").ToString());
            string sCard = gvDiesel.GetRowCellValue(rowHandle - 1, "CARD").ToString();            
            decimal nGallons = Convert.ToDecimal(gvDiesel.GetRowCellValue(rowHandle - 1, "GALLONS"));
            decimal nFuel = Convert.ToDecimal(gvDiesel.GetRowCellValue(rowHandle - 1, "FUEL COST").ToString());
            Int64 nMileage = Convert.ToInt64(gvDiesel.GetRowCellValue(rowHandle - 1, "MILEAGE"));
            string sPlace = gvDiesel.GetRowCellValue(rowHandle - 1, "PLACE OF TRANSACTION").ToString();
            string sEmployee = MainViewModel.GetInstance().login.user.ID_User;
            string sCommand = "";
            if (string.IsNullOrEmpty(sID))
            {
                sCommand = "INSERT INTO Diesel_Main (ID_Diesel, ID_Truck, ID_Driver, Date, Card, Gallons, Fuel_Cost, Mileage, PlaceOfTransaction, ID_Employee) " +
                            "VALUES(NEWID(), @sID_Truck, @sID_Driver, @dDate, @sCard, @nGallons, @nFuel_Cost, @nMileage, @sPlace, @sID_Employee)";
            }
            else
            {
                sCommand = "UPDATE Diesel_Main SET ID_Driver = @sID_Driver, ID_Truck = @sID_Truck, Gallons = @nGallons, Mileage = @nMileage WHERE ID_Diesel = @sID_Diesel";
            }
            using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
            {
                using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@sID_Diesel", SqlDbType.NVarChar).Value = sID;                    
                    cmd.Parameters.Add("@sID_Truck", SqlDbType.NVarChar).Value = sID_Truck;
                    cmd.Parameters.Add("@sID_Driver", SqlDbType.NVarChar).Value = sID_Driver;
                    cmd.Parameters.Add("@dDate", SqlDbType.DateTime).Value = dDate;
                    cmd.Parameters.Add("@sCard", SqlDbType.NVarChar).Value = sCard;
                    cmd.Parameters.Add("@nGallons", SqlDbType.Decimal).Value = nGallons;
                    cmd.Parameters.Add("@nFuel_Cost", SqlDbType.Decimal).Value = nFuel;
                    cmd.Parameters.Add("@nMileage", SqlDbType.BigInt).Value = nMileage;
                    cmd.Parameters.Add("@sPlace", SqlDbType.NVarChar).Value = sPlace;
                    cmd.Parameters.Add("@sID_Employee", SqlDbType.NVarChar).Value = sEmployee;

                    try
                    {
                        sqlConn.Open();
                        cmd.ExecuteNonQuery();
                        XtraMessageBox.Show("Row was successfully saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Registry could not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }            
        }               

        private void DeleteRow(int rowHandle)
        {
            string sID = gvDiesel.GetRowCellValue(rowHandle - 1, "ID").ToString();
            if (!string.IsNullOrEmpty(sID))
            {
                if (XtraMessageBox.Show("You are about to delete the selected row. Do you want to continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sCommand = "DELETE FROM Diesel_Main WHERE ID_Diesel = @sID";
                    using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                    {
                        using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@sID", SqlDbType.NVarChar).Value = sID;
                            try
                            {
                                sqlConn.Open();
                                cmd.ExecuteNonQuery();                                
                                GetTruckData();
                            }
                            catch
                            {
                                XtraMessageBox.Show("The row could not be deleted, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void RowComments(int rowHandle)
        {
            string sID = gvDiesel.GetRowCellValue(rowHandle - 1, "ID").ToString();
            string sTruck = gvDiesel.GetRowCellValue(rowHandle - 1, "TRUCK").ToString();
            DateTime dDate = Convert.ToDateTime(gvDiesel.GetRowCellValue(rowHandle - 1, "DATE"));
            MainViewModel.GetInstance().comments = new frmComments(sID, sTruck, dDate);
            MainViewModel.GetInstance().comments.ShowDialog();
        }

        private void AddNewRow(object sender, EventArgs e)
        {
            //bNewRow = true;
            int rowHandle = gvDiesel.RowCount;            
            gvDiesel.AddNewRow();
            CreateActionBarRepositoryItemsForRow(rowHandle + 1);            
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            if (gvDiesel.RowCount > 0)
            {
                SaveFileDialog save = new SaveFileDialog()
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx"
                };
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(save.FileName))
                    {
                        gvDiesel.ExportToXlsx(save.FileName);
                        if (XtraMessageBox.Show("Data was successfully exported to Excel Worksheet.\nDo you want to open it?", "Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(save.FileName);
                        }
                    }
                }
            }
        }

        private void CreateActionBarRepositoryItemsForRow(int rowHandle)
        {
            RepositoryItemButtonEdit someActionBar = new RepositoryItemButtonEdit();
            someActionBar.Name = rowHandle.ToString();
            someActionBar.Buttons.Clear();

            EditorButton btn = new EditorButton(ButtonPredefines.Glyph);
            btn.ImageOptions.Image = Resources.comentarios;
            btn.Caption = $"Comments-{rowHandle}";
            btn.ToolTip = "Row Comments";
            btn.Click += (s, e) => { RowComments(rowHandle); };
            someActionBar.Buttons.Add(btn);

            EditorButton btn1 = new EditorButton(ButtonPredefines.Glyph);
            btn1.ImageOptions.Image = Resources.trash_can16x16;
            btn1.Caption = $"Delete-{rowHandle}";
            btn1.ToolTip = "Delete row";
            btn1.Click += (s, e) => { DeleteRow(rowHandle); };
            someActionBar.Buttons.Add(btn1);
            
            buttons.Add(rowHandle, someActionBar);
        }                

        private void ChangeSkin(bool bActive)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            if (bActive)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark);
                barButtonDarkMode.Caption = "Light Mode";               
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
                barButtonDarkMode.Caption = "Dark Mode";                
            }
        }
        #endregion

        #region Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            sID_Employee = MainViewModel.GetInstance().login.user.ID_User;
            sEmployee = MainViewModel.GetInstance().login.user.Employee;
            bFullControl = MainViewModel.GetInstance().login.user.Full;
            bWrite = MainViewModel.GetInstance().login.user.Write;
            bRead = MainViewModel.GetInstance().login.user.Read;
            ValidateUser();
            FillTrucksCombo();
            FillDriversList();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainViewModel.GetInstance().login.Close();
        }
                
        private void cmbTrucks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrucks.SelectedIndex > -1)
            {
                GetTruckData();
            }
            else
            {
                ClearGridView();                
            }
        }

        private void gvDiesel_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.ColumnType == typeof(DateTime))
            {
                RepositoryItemDateEdit formatDate = new RepositoryItemDateEdit();
                formatDate.EditMask = "MM/dd/yyyy HH:mm";
                formatDate.Mask.UseMaskAsDisplayFormat = true;
                e.RepositoryItem = formatDate;
            }
            else
            {
                if (e.Column.FieldName == "MPG" || e.Column.FieldName == "AVERAGE")
                {
                    RepositoryItemTextEdit numFormat = new RepositoryItemTextEdit();
                    numFormat.AutoHeight = false;
                    numFormat.Mask.EditMask = "n2";
                    numFormat.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    numFormat.Mask.UseMaskAsDisplayFormat = true;
                    e.RepositoryItem = numFormat;
                }

                if (e.Column.FieldName == "MILEAGE" || e.Column.FieldName == "PREVIOUS" || e.Column.FieldName == "MILES")
                {
                    RepositoryItemTextEdit numFormat = new RepositoryItemTextEdit();
                    numFormat.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    numFormat.Mask.EditMask = @"#,###,##0";
                    numFormat.Mask.UseMaskAsDisplayFormat = true;
                    e.RepositoryItem = numFormat;
                }

                if (e.Column.FieldName == "DRIVER" && !bLoad)
                {                    
                    RepositoryItemLookUpEdit comboEditor = new RepositoryItemLookUpEdit();
                    comboEditor.DataSource = null;
                    comboEditor.PopulateColumns();
                    comboEditor.Columns.Add(new LookUpColumnInfo("ID", "ID"));
                    comboEditor.Columns.Add(new LookUpColumnInfo("DRIVER", "DRIVER"));
                    comboEditor.ValueMember = "ID";
                    comboEditor.DisplayMember = "DRIVER";
                    comboEditor.DataSource = dtDrivers;
                    comboEditor.ShowHeader = false;
                    comboEditor.ShowFooter = false;
                    comboEditor.ShowLines = false;
                    comboEditor.Columns["ID"].Visible = false;
                    e.RepositoryItem = comboEditor;
                    
                }
            }            

            if (e.Column.FieldName != "CONTROLS")
                return;
            int rowHandle = e.RowHandle + 1;
            if (buttons.ContainsKey(rowHandle))
            {
                e.RepositoryItem = buttons[rowHandle];
            }            
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                cmbTrucks.SelectedIndex = -1;
                cmbTrucks.Enabled = false;
                GetTruckData();
            }
            else
            {
                cmbTrucks.Enabled = true;
                ClearGridView();
            }
        }
                        
        private void gvDiesel_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "TRUCK")
            {
                DataTable dt = new DataTable();
                string sCellValue = e.Value.ToString();
                string sCommand = "SELECT pk_id AS 'ID', make AS 'MAKE' FROM General.dbo.Trucks WHERE truck = @sTruck";
                using (SqlConnection sqlConn = new SqlConnection(Constants.cn.Replace(@"\\", @"\")))
                {
                    using (SqlCommand cmd = new SqlCommand(sCommand, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@sTruck", SqlDbType.NVarChar).Value = sCellValue;
                        
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {                            
                            da.Fill(dt);
                        }                        
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    string sID_Truck = dt.Rows[0][0].ToString();
                    string sMake = dt.Rows[0][1].ToString();
                    view.SetRowCellValue(e.RowHandle, "ID_TRUCK", sID_Truck);
                    view.SetRowCellValue(e.RowHandle, "TRUCK TYPE", sMake);
                }
                else
                {
                    XtraMessageBox.Show("Truck does not exists, please verify", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.Column.FieldName == "MILEAGE" || e.Column.FieldName == "GALLONS")
            {
                try
                {
                    string sTruck = view.GetRowCellValue(e.RowHandle, "TRUCK").ToString();
                    string sLastTruck = view.GetRowCellValue(e.RowHandle - 1, "TRUCK").ToString();
                    decimal nGallons = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "GALLONS"));
                    int n = e.RowHandle;
                    decimal Sum = 0;
                    decimal AVG = 0;
                    if (sTruck == sLastTruck)
                    {
                        Int64 nActualMilleage = 0;
                        try
                        {
                            nActualMilleage = Convert.ToInt64(e.Value);
                        }
                        catch { }
                        Int64 nLastMileage = 0;
                        try
                        {
                            nLastMileage = Convert.ToInt64(view.GetRowCellValue(e.RowHandle - 1, "MILEAGE"));
                        }
                        catch { }
                                                
                        int nMiles = Convert.ToInt32(nActualMilleage) - Convert.ToInt32(nLastMileage);
                        decimal nMPG = nMiles / nGallons;

                        try
                        {
                            //Recalculate AVG
                            for (int i = 1; i < n; i++)
                            {
                                Sum += Convert.ToDecimal(view.GetRowCellValue(i, "MPG"));
                            }
                            Sum += nMPG;
                            AVG = Sum / n;
                        }
                        catch { }

                        view.SetRowCellValue(e.RowHandle, "MILES", nMiles);
                        view.SetRowCellValue(e.RowHandle, "MPG", nMPG);
                        view.SetRowCellValue(e.RowHandle, "AVERAGE", AVG);
                    }
                }
                catch { }
            }

            if (e.Column.FieldName == "")
            {

            }
        }

        private void gvDiesel_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string sField = e.Column.FieldName;
            if (sField == "TRUCK")
            {                
                string sCellValue = view.GetRowCellValue(e.RowHandle, "ID_TRUCK").ToString();
                
                if (string.IsNullOrEmpty(sCellValue))
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }            

            if (sField == "GALLONS" || sField == "TRUCK" || sField == "MILEAGE")
            {
                if (sField == "TRUCK")
                {
                    if (gvDiesel.IsRowSelected(e.RowHandle))
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                    }
                    else
                    {                        
                        e.Appearance.BackColor = Color.Gold;
                    }
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                if (bDark)
                {
                    e.Appearance.ForeColor = Color.Black;
                }                
            }
            
        }
                                                                                     
        private void gvDiesel_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            string sCol = view.FocusedColumn.FieldName;
            if (view.FocusedRowHandle == view.RowCount - 1 && string.IsNullOrEmpty(view.GetRowCellValue(view.FocusedRowHandle, sCol).ToString()))
            {
                if (sCol == "DATE" || sCol == "DRIVER" || sCol == "CARD" || sCol == "GALLONS" || sCol == "FUEL COST" || sCol == "TRUCK" || sCol == "MILEAGE" || 
                    sCol == "PLACE OF TRANSACTION" || sCol == "SUSPECT" || sCol == "CONTROLS")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (sCol == "DRIVER" || sCol == "GALLONS" || sCol == "TRUCK" || sCol == "MILEAGE" || sCol == "PLACE OF TRANSACTION" || sCol == "SUSPECT" || 
                    sCol == "CONTROLS")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
                
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.EditValue = null;
                dtpTo.EditValue = null;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }
                        
        private void barButtonLoadExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadExcel();
        }

        private void barButtonDashboardDesigner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainViewModel.GetInstance().dashboard = new frmDashboard();
            MainViewModel.GetInstance().dashboard.Show();
        }

        private void barButtonDashboardViewer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainViewModel.GetInstance().dashboardViewer = new frmDashboardViewer();
            MainViewModel.GetInstance().dashboardViewer.Show();
        }

        private void barButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainViewModel.GetInstance().users = new frmUsers();
            MainViewModel.GetInstance().users.ShowDialog();
        }

        private void barButtonProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainViewModel.GetInstance().profile = new frmProfile();
            MainViewModel.GetInstance().profile.ShowDialog();
        }

        private void barButtonDarkMode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bDark)
            {
                bDark = false;
            }
            else
            {
                bDark = true;
            }
            ChangeSkin(bDark);
        }
        #endregion
    }
}