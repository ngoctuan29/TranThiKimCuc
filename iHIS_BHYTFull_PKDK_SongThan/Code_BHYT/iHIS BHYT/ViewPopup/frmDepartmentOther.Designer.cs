namespace Ps.Clinic.ViewPopup
{
    partial class frmDepartmentOther
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentOther));
            this.Lkupkhoaphong = new DevExpress.XtraEditors.LookUpEdit();
            this.btChonkham = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.butiClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkCongKham = new DevExpress.XtraEditors.CheckEdit();
            this.lkupCongKham = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.psLogo = new System.Windows.Forms.PictureBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Lkupkhoaphong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCongKham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupCongKham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Lkupkhoaphong
            // 
            this.Lkupkhoaphong.EditValue = "";
            this.Lkupkhoaphong.Location = new System.Drawing.Point(120, 55);
            this.Lkupkhoaphong.Name = "Lkupkhoaphong";
            this.Lkupkhoaphong.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.Lkupkhoaphong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Lkupkhoaphong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "Mã KP", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Tên khoa phòng")});
            this.Lkupkhoaphong.Properties.NullText = "Phòng khám";
            this.Lkupkhoaphong.Size = new System.Drawing.Size(224, 20);
            this.Lkupkhoaphong.TabIndex = 1006;
            // 
            // btChonkham
            // 
            this.btChonkham.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btChonkham.Image = ((System.Drawing.Image)(resources.GetObject("btChonkham.Image")));
            this.btChonkham.Location = new System.Drawing.Point(179, 136);
            this.btChonkham.Name = "btChonkham";
            this.btChonkham.Size = new System.Drawing.Size(83, 27);
            this.btChonkham.TabIndex = 1008;
            this.btChonkham.Text = "Đồng ý";
            this.btChonkham.Click += new System.EventHandler(this.btChonkham_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(123, 39);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(89, 13);
            this.labelControl21.TabIndex = 1010;
            this.labelControl21.Text = "Phòng chuyển đến";
            // 
            // butiClose
            // 
            this.butiClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butiClose.Image = ((System.Drawing.Image)(resources.GetObject("butiClose.Image")));
            this.butiClose.Location = new System.Drawing.Point(263, 136);
            this.butiClose.Name = "butiClose";
            this.butiClose.Size = new System.Drawing.Size(83, 27);
            this.butiClose.TabIndex = 1012;
            this.butiClose.Text = "Thoát";
            this.butiClose.Click += new System.EventHandler(this.butiClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.chkCongKham);
            this.groupControl1.Controls.Add(this.lkupCongKham);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.psLogo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.Lkupkhoaphong);
            this.groupControl1.Controls.Add(this.butiClose);
            this.groupControl1.Controls.Add(this.btChonkham);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(356, 184);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Chuyển đến phòng ...";
            // 
            // chkCongKham
            // 
            this.chkCongKham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCongKham.Location = new System.Drawing.Point(122, 114);
            this.chkCongKham.Name = "chkCongKham";
            this.chkCongKham.Properties.Caption = "Chuyển khám không thu tiền công khám";
            this.chkCongKham.Size = new System.Drawing.Size(224, 19);
            this.chkCongKham.TabIndex = 1074;
            this.chkCongKham.TabStop = false;
            // 
            // lkupCongKham
            // 
            this.lkupCongKham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupCongKham.EditValue = "";
            this.lkupCongKham.Location = new System.Drawing.Point(120, 93);
            this.lkupCongKham.Name = "lkupCongKham";
            this.lkupCongKham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupCongKham.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCode", "Ma", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceName", 120, "Chọn công khám...!"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "DepartmentCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupCongKham.Properties.NullText = "";
            this.lkupCongKham.Size = new System.Drawing.Size(226, 20);
            this.lkupCongKham.TabIndex = 1015;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.Location = new System.Drawing.Point(251, 167);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 1014;
            this.labelControl1.Text = "Powersoft Co., Ltd";
            // 
            // psLogo
            // 
            this.psLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.psLogo.Image = ((System.Drawing.Image)(resources.GetObject("psLogo.Image")));
            this.psLogo.Location = new System.Drawing.Point(2, 31);
            this.psLogo.Name = "psLogo";
            this.psLogo.Size = new System.Drawing.Size(115, 151);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psLogo.TabIndex = 1013;
            this.psLogo.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(124, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(184, 13);
            this.labelControl2.TabIndex = 1010;
            this.labelControl2.Text = "Dịch vụ thực hiện (cần chuyển nếu có)";
            // 
            // frmDepartmentOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 184);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepartmentOther";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng khám.";
            this.Load += new System.EventHandler(this.frmDepartmentOther_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lkupkhoaphong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCongKham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupCongKham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit Lkupkhoaphong;
        private DevExpress.XtraEditors.SimpleButton btChonkham;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.SimpleButton butiClose;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox psLogo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkupCongKham;
        private DevExpress.XtraEditors.CheckEdit chkCongKham;
    }
}