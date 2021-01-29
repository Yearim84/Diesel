
namespace Diesel.Views
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gbRole = new System.Windows.Forms.GroupBox();
            this.btnRoles = new DevExpress.XtraEditors.SimpleButton();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.gcUsers = new DevExpress.XtraGrid.GridControl();
            this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.gbRole.SuspendLayout();
            this.gbUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.gbUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gbRole);
            this.panelControl1.Controls.Add(this.gbUsers);
            this.panelControl1.Controls.Add(this.gbUser);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(474, 469);
            this.panelControl1.TabIndex = 1;
            // 
            // gbRole
            // 
            this.gbRole.Controls.Add(this.btnRoles);
            this.gbRole.Controls.Add(this.cmbRoles);
            this.gbRole.Location = new System.Drawing.Point(12, 86);
            this.gbRole.Name = "gbRole";
            this.gbRole.Size = new System.Drawing.Size(450, 68);
            this.gbRole.TabIndex = 3;
            this.gbRole.TabStop = false;
            this.gbRole.Text = "Role";
            // 
            // btnRoles
            // 
            this.btnRoles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRoles.ImageOptions.Image")));
            this.btnRoles.Location = new System.Drawing.Point(404, 14);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnRoles.Size = new System.Drawing.Size(40, 40);
            this.btnRoles.TabIndex = 2;
            // 
            // cmbRoles
            // 
            this.cmbRoles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbRoles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(20, 24);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(361, 24);
            this.cmbRoles.TabIndex = 1;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // gbUsers
            // 
            this.gbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUsers.Controls.Add(this.gcUsers);
            this.gbUsers.Location = new System.Drawing.Point(12, 160);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(450, 297);
            this.gbUsers.TabIndex = 2;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Users";
            // 
            // gcUsers
            // 
            this.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUsers.Location = new System.Drawing.Point(3, 17);
            this.gcUsers.MainView = this.gvUsers;
            this.gcUsers.Name = "gcUsers";
            this.gcUsers.Size = new System.Drawing.Size(444, 277);
            this.gcUsers.TabIndex = 0;
            this.gcUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsers});
            // 
            // gvUsers
            // 
            this.gvUsers.GridControl = this.gcUsers;
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvUsers.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvUsers.OptionsBehavior.ReadOnly = true;
            this.gvUsers.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvUsers.OptionsView.ShowGroupPanel = false;
            this.gvUsers.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvUsers_CustomRowCellEdit);
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.btnSave);
            this.gbUser.Controls.Add(this.cmbUser);
            this.gbUser.Location = new System.Drawing.Point(12, 12);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(450, 68);
            this.gbUser.TabIndex = 0;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "Name";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(404, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.ToolTip = "Add User";
            // 
            // cmbUser
            // 
            this.cmbUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(20, 22);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(361, 24);
            this.cmbUser.TabIndex = 0;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 469);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.gbRole.ResumeLayout(false);
            this.gbUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.gbUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox gbUser;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.GroupBox gbUsers;
        private DevExpress.XtraGrid.GridControl gcUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
        private System.Windows.Forms.GroupBox gbRole;
        private DevExpress.XtraEditors.SimpleButton btnRoles;
        private System.Windows.Forms.ComboBox cmbRoles;
    }
}