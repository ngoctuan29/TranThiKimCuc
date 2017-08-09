namespace Ps.Clinic.Statistics
{
    partial class frmThongKeTheoCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeTheoCa));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.chkGetReceive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.controlDate = new UserControlDate.dllNgay();
            this.lkupNhomDV = new DevExpress.XtraEditors.LookUpEdit();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.pivotResult = new DevExpress.XtraPivotGrid.PivotGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGetReceive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Controls.Add(this.chkGetReceive);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.controlDate);
            this.panelControl1.Controls.Add(this.lkupNhomDV);
            this.panelControl1.Controls.Add(this.butOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(301, 490);
            this.panelControl1.TabIndex = 1045;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(194, 133);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(100, 26);
            this.butPrint.TabIndex = 1063;
            this.butPrint.Text = "Xuất file Excel";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // chkGetReceive
            // 
            this.chkGetReceive.Location = new System.Drawing.Point(90, 108);
            this.chkGetReceive.Name = "chkGetReceive";
            this.chkGetReceive.Properties.Caption = "Lấy danh sách chỉ định từ tiếp nhận";
            this.chkGetReceive.Size = new System.Drawing.Size(204, 19);
            this.chkGetReceive.TabIndex = 1060;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 1058;
            this.labelControl1.Text = "Nhóm dịch vụ";
            // 
            // controlDate
            // 
            this.controlDate.BackColor = System.Drawing.Color.Transparent;
            this.controlDate.Location = new System.Drawing.Point(3, 3);
            this.controlDate.Name = "controlDate";
            this.controlDate.Size = new System.Drawing.Size(294, 73);
            this.controlDate.TabIndex = 1057;
            // 
            // lkupNhomDV
            // 
            this.lkupNhomDV.EditValue = "";
            this.lkupNhomDV.Location = new System.Drawing.Point(90, 82);
            this.lkupNhomDV.Name = "lkupNhomDV";
            this.lkupNhomDV.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lkupNhomDV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupNhomDV.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupName", "Nhóm dịch vụ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupCode", "ServiceGroupCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupNhomDV.Properties.NullText = "";
            this.lkupNhomDV.Size = new System.Drawing.Size(204, 20);
            this.lkupNhomDV.TabIndex = 1059;
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(90, 133);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 26);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Xem số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // pivotResult
            // 
            this.pivotResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotResult.Location = new System.Drawing.Point(301, 0);
            this.pivotResult.Name = "pivotResult";
            this.pivotResult.Size = new System.Drawing.Size(644, 490);
            this.pivotResult.TabIndex = 1046;
            // 
            // frmThongKeTheoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 490);
            this.Controls.Add(this.pivotResult);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThongKeTheoCa";
            this.Text = "Thống Kê Bệnh Theo Ca Khám Bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeTheoCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGetReceive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotResult;
        private DevExpress.XtraEditors.CheckEdit chkGetReceive;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UserControlDate.dllNgay controlDate;
        private DevExpress.XtraEditors.LookUpEdit lkupNhomDV;
        private DevExpress.XtraEditors.SimpleButton butPrint;
    }
}