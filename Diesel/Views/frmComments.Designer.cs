
namespace Diesel.Views
{
    partial class frmComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComments));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gbComments = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.meComments = new DevExpress.XtraEditors.MemoEdit();
            this.gbTruck = new System.Windows.Forms.GroupBox();
            this.lblTruck = new System.Windows.Forms.Label();
            this.gbLoadDate = new System.Windows.Forms.GroupBox();
            this.lblLoadDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.gbComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meComments.Properties)).BeginInit();
            this.gbTruck.SuspendLayout();
            this.gbLoadDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gbLoadDate);
            this.panelControl1.Controls.Add(this.gbTruck);
            this.panelControl1.Controls.Add(this.gbComments);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(715, 314);
            this.panelControl1.TabIndex = 0;
            // 
            // gbComments
            // 
            this.gbComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComments.Controls.Add(this.lblDate);
            this.gbComments.Controls.Add(this.btnSave);
            this.gbComments.Controls.Add(this.meComments);
            this.gbComments.Location = new System.Drawing.Point(12, 60);
            this.gbComments.Name = "gbComments";
            this.gbComments.Size = new System.Drawing.Size(691, 242);
            this.gbComments.TabIndex = 1;
            this.gbComments.TabStop = false;
            this.gbComments.Text = "Comments";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(78, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Comment Date";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(645, 194);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 1;
            // 
            // meComments
            // 
            this.meComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meComments.Location = new System.Drawing.Point(15, 40);
            this.meComments.Name = "meComments";
            this.meComments.Size = new System.Drawing.Size(624, 189);
            this.meComments.TabIndex = 0;
            // 
            // gbTruck
            // 
            this.gbTruck.Controls.Add(this.lblTruck);
            this.gbTruck.Location = new System.Drawing.Point(12, 5);
            this.gbTruck.Name = "gbTruck";
            this.gbTruck.Size = new System.Drawing.Size(176, 49);
            this.gbTruck.TabIndex = 2;
            this.gbTruck.TabStop = false;
            this.gbTruck.Text = "Truck";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruck.ForeColor = System.Drawing.Color.Gray;
            this.lblTruck.Location = new System.Drawing.Point(57, 17);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(63, 23);
            this.lblTruck.TabIndex = 0;
            this.lblTruck.Text = "Truck";
            // 
            // gbLoadDate
            // 
            this.gbLoadDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoadDate.Controls.Add(this.lblLoadDate);
            this.gbLoadDate.Location = new System.Drawing.Point(209, 5);
            this.gbLoadDate.Name = "gbLoadDate";
            this.gbLoadDate.Size = new System.Drawing.Size(494, 49);
            this.gbLoadDate.TabIndex = 2;
            this.gbLoadDate.TabStop = false;
            this.gbLoadDate.Text = "Load Date";
            // 
            // lblLoadDate
            // 
            this.lblLoadDate.AutoSize = true;
            this.lblLoadDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadDate.ForeColor = System.Drawing.Color.Gray;
            this.lblLoadDate.Location = new System.Drawing.Point(18, 17);
            this.lblLoadDate.Name = "lblLoadDate";
            this.lblLoadDate.Size = new System.Drawing.Size(106, 23);
            this.lblLoadDate.TabIndex = 0;
            this.lblLoadDate.Text = "Load Date";
            // 
            // frmComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 314);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmComments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comments";
            this.Load += new System.EventHandler(this.frmComments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.gbComments.ResumeLayout(false);
            this.gbComments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meComments.Properties)).EndInit();
            this.gbTruck.ResumeLayout(false);
            this.gbTruck.PerformLayout();
            this.gbLoadDate.ResumeLayout(false);
            this.gbLoadDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox gbComments;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.MemoEdit meComments;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox gbTruck;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.GroupBox gbLoadDate;
        private System.Windows.Forms.Label lblLoadDate;
    }
}