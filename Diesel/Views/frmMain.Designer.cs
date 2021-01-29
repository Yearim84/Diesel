
namespace Diesel.Views
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcDiesel = new DevExpress.XtraGrid.GridControl();
            this.gvDiesel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNewRow = new DevExpress.XtraEditors.SimpleButton();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.gbTrucks = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cmbTrucks = new System.Windows.Forms.ComboBox();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItemCatalogs = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItemLoadExcel = new DevExpress.XtraBars.BarSubItem();
            this.barSubItemDashboardDesigner = new DevExpress.XtraBars.BarSubItem();
            this.barSubItemDashboardViewer = new DevExpress.XtraBars.BarSubItem();
            this.barSubItemExit = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem10 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonLoadExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDashboardDesigner = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDashboardViewer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonExit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonUsers = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonProfile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDarkMode = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiesel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiesel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.gbControls.SuspendLayout();
            this.gbDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.gbTrucks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gcDiesel);
            this.panelControl1.Location = new System.Drawing.Point(0, 98);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1080, 486);
            this.panelControl1.TabIndex = 1;
            // 
            // gcDiesel
            // 
            this.gcDiesel.BackgroundImage = global::Diesel.Properties.Resources.logoTransp;
            this.gcDiesel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gcDiesel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDiesel.Location = new System.Drawing.Point(2, 2);
            this.gcDiesel.MainView = this.gvDiesel;
            this.gcDiesel.Name = "gcDiesel";
            this.gcDiesel.Size = new System.Drawing.Size(1076, 482);
            this.gcDiesel.TabIndex = 0;
            this.gcDiesel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDiesel});
            // 
            // gvDiesel
            // 
            this.gvDiesel.GridControl = this.gcDiesel;
            this.gvDiesel.Name = "gvDiesel";
            this.gvDiesel.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gvDiesel.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gvDiesel.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvDiesel.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvDiesel_RowCellStyle);
            this.gvDiesel.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvDiesel_CustomRowCellEdit);
            this.gvDiesel.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvDiesel_ShowingEditor);
            this.gvDiesel.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDiesel_CellValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(49, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.ToolTip = "Save";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.gbControls);
            this.panelControl2.Controls.Add(this.gbDate);
            this.panelControl2.Controls.Add(this.picLogo);
            this.panelControl2.Controls.Add(this.gbTrucks);
            this.panelControl2.Location = new System.Drawing.Point(0, 32);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1080, 60);
            this.panelControl2.TabIndex = 3;
            // 
            // gbControls
            // 
            this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControls.Controls.Add(this.btnExcel);
            this.gbControls.Controls.Add(this.btnSave);
            this.gbControls.Controls.Add(this.btnAddNewRow);
            this.gbControls.Location = new System.Drawing.Point(930, 3);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(140, 50);
            this.gbControls.TabIndex = 6;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // btnExcel
            // 
            this.btnExcel.ImageOptions.Image = global::Diesel.Properties.Resources.Excel32x32;
            this.btnExcel.Location = new System.Drawing.Point(95, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.ToolTip = "Export to Excel";
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewRow.ImageOptions.Image")));
            this.btnAddNewRow.Location = new System.Drawing.Point(3, 8);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAddNewRow.Size = new System.Drawing.Size(40, 40);
            this.btnAddNewRow.TabIndex = 4;
            this.btnAddNewRow.ToolTip = "Add New Row";
            this.btnAddNewRow.Visible = false;
            // 
            // gbDate
            // 
            this.gbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDate.Controls.Add(this.chkDate);
            this.gbDate.Controls.Add(this.lblFrom);
            this.gbDate.Controls.Add(this.lblTo);
            this.gbDate.Controls.Add(this.dtpTo);
            this.gbDate.Controls.Add(this.dtpFrom);
            this.gbDate.Location = new System.Drawing.Point(320, 3);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(403, 50);
            this.gbDate.TabIndex = 5;
            this.gbDate.TabStop = false;
            this.gbDate.Text = "Date";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(15, 21);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(15, 14);
            this.chkDate.TabIndex = 7;
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(40, 21);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(39, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(228, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.EditValue = null;
            this.dtpTo.Enabled = false;
            this.dtpTo.Location = new System.Drawing.Point(258, 18);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Size = new System.Drawing.Size(130, 20);
            this.dtpTo.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.EditValue = null;
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Location = new System.Drawing.Point(85, 18);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Size = new System.Drawing.Size(131, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Diesel.Properties.Resources.logoTransp;
            this.picLogo.Location = new System.Drawing.Point(5, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(149, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // gbTrucks
            // 
            this.gbTrucks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTrucks.Controls.Add(this.chkAll);
            this.gbTrucks.Controls.Add(this.cmbTrucks);
            this.gbTrucks.Location = new System.Drawing.Point(731, 3);
            this.gbTrucks.Name = "gbTrucks";
            this.gbTrucks.Size = new System.Drawing.Size(191, 50);
            this.gbTrucks.TabIndex = 1;
            this.gbTrucks.TabStop = false;
            this.gbTrucks.Text = "Truck";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(147, 21);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cmbTrucks
            // 
            this.cmbTrucks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTrucks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrucks.FormattingEnabled = true;
            this.cmbTrucks.Location = new System.Drawing.Point(19, 18);
            this.cmbTrucks.Name = "cmbTrucks";
            this.cmbTrucks.Size = new System.Drawing.Size(121, 21);
            this.cmbTrucks.TabIndex = 0;
            this.cmbTrucks.SelectedIndexChanged += new System.EventHandler(this.cmbTrucks_SelectedIndexChanged);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItemCatalogs,
            this.barSubItem3,
            this.barSubItemLoadExcel,
            this.barSubItemDashboardDesigner,
            this.barSubItemDashboardViewer,
            this.barSubItemExit,
            this.barSubItem8,
            this.barSubItem9,
            this.barSubItem10,
            this.barButtonLoadExcel,
            this.barButtonDashboardDesigner,
            this.barButtonDashboardViewer,
            this.barButtonExit,
            this.barButtonUsers,
            this.barButtonProfile,
            this.barButtonDarkMode});
            this.barManager1.MaxItemId = 17;
            this.barManager1.StatusBar = this.bar3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1080, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 561);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1080, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 530);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1080, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 530);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemCatalogs),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "File";
            this.barSubItem1.Id = 0;
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.LargeImage")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonLoadExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDashboardDesigner),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDashboardViewer),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonExit)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItemCatalogs
            // 
            this.barSubItemCatalogs.Caption = "Catalogs";
            this.barSubItemCatalogs.Id = 1;
            this.barSubItemCatalogs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.Image")));
            this.barSubItemCatalogs.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.LargeImage")));
            this.barSubItemCatalogs.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonUsers)});
            this.barSubItemCatalogs.Name = "barSubItemCatalogs";
            this.barSubItemCatalogs.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "About";
            this.barSubItem3.Id = 2;
            this.barSubItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem3.ImageOptions.Image")));
            this.barSubItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem3.ImageOptions.LargeImage")));
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonProfile),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDarkMode)});
            this.barSubItem3.Name = "barSubItem3";
            this.barSubItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItemLoadExcel
            // 
            this.barSubItemLoadExcel.Caption = "Load Excel";
            this.barSubItemLoadExcel.Id = 3;
            this.barSubItemLoadExcel.Name = "barSubItemLoadExcel";
            // 
            // barSubItemDashboardDesigner
            // 
            this.barSubItemDashboardDesigner.Caption = "Dashboard Designer";
            this.barSubItemDashboardDesigner.Id = 4;
            this.barSubItemDashboardDesigner.Name = "barSubItemDashboardDesigner";
            // 
            // barSubItemDashboardViewer
            // 
            this.barSubItemDashboardViewer.Caption = "Dashboard Viewer";
            this.barSubItemDashboardViewer.Id = 5;
            this.barSubItemDashboardViewer.Name = "barSubItemDashboardViewer";
            // 
            // barSubItemExit
            // 
            this.barSubItemExit.Caption = "Exit";
            this.barSubItemExit.Id = 6;
            this.barSubItemExit.Name = "barSubItemExit";
            // 
            // barSubItem8
            // 
            this.barSubItem8.Caption = "Users";
            this.barSubItem8.Id = 7;
            this.barSubItem8.Name = "barSubItem8";
            // 
            // barSubItem9
            // 
            this.barSubItem9.Caption = "Profile";
            this.barSubItem9.Id = 8;
            this.barSubItem9.Name = "barSubItem9";
            // 
            // barSubItem10
            // 
            this.barSubItem10.Caption = "Dark Mode";
            this.barSubItem10.Id = 9;
            this.barSubItem10.Name = "barSubItem10";
            // 
            // barButtonLoadExcel
            // 
            this.barButtonLoadExcel.Caption = "Load Excel";
            this.barButtonLoadExcel.Id = 10;
            this.barButtonLoadExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonLoadExcel.ImageOptions.Image")));
            this.barButtonLoadExcel.Name = "barButtonLoadExcel";
            this.barButtonLoadExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonLoadExcel_ItemClick);
            // 
            // barButtonDashboardDesigner
            // 
            this.barButtonDashboardDesigner.Caption = "Dashboard Designer";
            this.barButtonDashboardDesigner.Id = 11;
            this.barButtonDashboardDesigner.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonDashboardDesigner.ImageOptions.Image")));
            this.barButtonDashboardDesigner.Name = "barButtonDashboardDesigner";
            this.barButtonDashboardDesigner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDashboardDesigner_ItemClick);
            // 
            // barButtonDashboardViewer
            // 
            this.barButtonDashboardViewer.Caption = "Dashboard Viewer";
            this.barButtonDashboardViewer.Id = 12;
            this.barButtonDashboardViewer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonDashboardViewer.ImageOptions.Image")));
            this.barButtonDashboardViewer.Name = "barButtonDashboardViewer";
            this.barButtonDashboardViewer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDashboardViewer_ItemClick);
            // 
            // barButtonExit
            // 
            this.barButtonExit.Caption = "Exit";
            this.barButtonExit.Id = 13;
            this.barButtonExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonExit.ImageOptions.Image")));
            this.barButtonExit.Name = "barButtonExit";
            this.barButtonExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonExit_ItemClick);
            // 
            // barButtonUsers
            // 
            this.barButtonUsers.Caption = "Users";
            this.barButtonUsers.Id = 14;
            this.barButtonUsers.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonUsers.ImageOptions.Image")));
            this.barButtonUsers.Name = "barButtonUsers";
            this.barButtonUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonUsers_ItemClick);
            // 
            // barButtonProfile
            // 
            this.barButtonProfile.Caption = "Profile";
            this.barButtonProfile.Id = 15;
            this.barButtonProfile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonProfile.ImageOptions.Image")));
            this.barButtonProfile.Name = "barButtonProfile";
            this.barButtonProfile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonProfile_ItemClick);
            // 
            // barButtonDarkMode
            // 
            this.barButtonDarkMode.Caption = "Dark Mode";
            this.barButtonDarkMode.Id = 16;
            this.barButtonDarkMode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonDarkMode.Name = "barButtonDarkMode";
            this.barButtonDarkMode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDarkMode_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 584);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diesel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDiesel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiesel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.gbControls.ResumeLayout(false);
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.gbTrucks.ResumeLayout(false);
            this.gbTrucks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcDiesel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDiesel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.GroupBox gbTrucks;
        private System.Windows.Forms.ComboBox cmbTrucks;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.PictureBox picLogo;
        private DevExpress.XtraEditors.SimpleButton btnAddNewRow;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private DevExpress.XtraEditors.DateEdit dtpTo;
        private DevExpress.XtraEditors.DateEdit dtpFrom;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.GroupBox gbControls;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItemLoadExcel;
        private DevExpress.XtraBars.BarSubItem barSubItemDashboardDesigner;
        private DevExpress.XtraBars.BarSubItem barSubItemDashboardViewer;
        private DevExpress.XtraBars.BarSubItem barSubItemExit;
        private DevExpress.XtraBars.BarSubItem barSubItemCatalogs;
        private DevExpress.XtraBars.BarSubItem barSubItem8;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem9;
        private DevExpress.XtraBars.BarSubItem barSubItem10;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonLoadExcel;
        private DevExpress.XtraBars.BarButtonItem barButtonDashboardDesigner;
        private DevExpress.XtraBars.BarButtonItem barButtonDashboardViewer;
        private DevExpress.XtraBars.BarButtonItem barButtonExit;
        private DevExpress.XtraBars.BarButtonItem barButtonUsers;
        private DevExpress.XtraBars.BarButtonItem barButtonProfile;
        private DevExpress.XtraBars.BarButtonItem barButtonDarkMode;
    }
}