namespace Ps.Clinic.Entry
{
    partial class frmSendSMSContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendSMSContent));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoiDung = new DevExpress.XtraEditors.MemoEdit();
            this.butSend = new DevExpress.XtraEditors.SimpleButton();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.txtDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.picPatient = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lbGioiTinh = new DevExpress.XtraEditors.LabelControl();
            this.lbHoTen = new DevExpress.XtraEditors.LabelControl();
            this.lbNgaySinh = new DevExpress.XtraEditors.LabelControl();
            this.lbTuoi = new DevExpress.XtraEditors.LabelControl();
            this.lbDiaChi = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 345);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(548, 31);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(548, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl11.Location = new System.Drawing.Point(125, 108);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(35, 14);
            this.labelControl11.TabIndex = 1020;
            this.labelControl11.Text = "Địa chỉ";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl10.Location = new System.Drawing.Point(414, 88);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(32, 14);
            this.labelControl10.TabIndex = 1018;
            this.labelControl10.Text = "Tuổi :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl8.Location = new System.Drawing.Point(113, 89);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(47, 13);
            this.labelControl8.TabIndex = 1017;
            this.labelControl8.Text = "Ngày sinh";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(189, 166);
            this.txtNoiDung.MenuManager = this.ribbon;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.txtNoiDung.Properties.Appearance.Options.UseFont = true;
            this.txtNoiDung.Properties.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(347, 145);
            this.txtNoiDung.TabIndex = 1026;
            this.txtNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoiDung_KeyDown);
            // 
            // butSend
            // 
            this.butSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSend.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butSend.Appearance.Options.UseFont = true;
            this.butSend.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSend.Image = ((System.Drawing.Image)(resources.GetObject("butSend.Image")));
            this.butSend.Location = new System.Drawing.Point(189, 317);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(86, 23);
            this.butSend.TabIndex = 1029;
            this.butSend.Text = "Gửi tin";
            this.butSend.ToolTip = "F2 - Lưu";
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butExit.Appearance.Options.UseFont = true;
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(281, 317);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(86, 23);
            this.butExit.TabIndex = 1030;
            this.butExit.Text = "Thoát";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(189, 142);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.txtDienThoai.Properties.Appearance.Options.UseFont = true;
            this.txtDienThoai.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.txtDienThoai.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDienThoai.Size = new System.Drawing.Size(347, 20);
            this.txtDienThoai.TabIndex = 1014;
            this.txtDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDienThoai_KeyDown);
            // 
            // picPatient
            // 
            this.picPatient.ErrorImage = global::Ps.Clinic.Properties.Resources.NoImgPatient;
            this.picPatient.Image = global::Ps.Clinic.Properties.Resources.NoImgPatient;
            this.picPatient.Location = new System.Drawing.Point(9, 55);
            this.picPatient.Name = "picPatient";
            this.picPatient.Size = new System.Drawing.Size(92, 105);
            this.picPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPatient.TabIndex = 1025;
            this.picPatient.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(165, 170);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 1020;
            this.labelControl1.Text = "(*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl2.Location = new System.Drawing.Point(182, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(4, 13);
            this.labelControl2.TabIndex = 1020;
            this.labelControl2.Text = ":";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl3.Location = new System.Drawing.Point(110, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 14);
            this.labelControl3.TabIndex = 1017;
            this.labelControl3.Text = "Họ && tên";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl4.Location = new System.Drawing.Point(419, 65);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 14);
            this.labelControl4.TabIndex = 1018;
            this.labelControl4.Text = "Giới :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl5.Location = new System.Drawing.Point(105, 145);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 14);
            this.labelControl5.TabIndex = 1020;
            this.labelControl5.Text = "Điện thoại";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl6.Location = new System.Drawing.Point(62, 170);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(98, 14);
            this.labelControl6.TabIndex = 1020;
            this.labelControl6.Text = "Nội dung tin nhắn";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Location = new System.Drawing.Point(165, 145);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(14, 13);
            this.labelControl7.TabIndex = 1020;
            this.labelControl7.Text = "(*)";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl9.Location = new System.Drawing.Point(182, 145);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(4, 13);
            this.labelControl9.TabIndex = 1020;
            this.labelControl9.Text = ":";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl12.Location = new System.Drawing.Point(182, 170);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(4, 13);
            this.labelControl12.TabIndex = 1020;
            this.labelControl12.Text = ":";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl13.Location = new System.Drawing.Point(182, 89);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(4, 13);
            this.labelControl13.TabIndex = 1020;
            this.labelControl13.Text = ":";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl14.Location = new System.Drawing.Point(182, 108);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(4, 13);
            this.labelControl14.TabIndex = 1020;
            this.labelControl14.Text = ":";
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbGioiTinh.Location = new System.Drawing.Point(450, 66);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(15, 13);
            this.lbGioiTinh.TabIndex = 1018;
            this.lbGioiTinh.Text = "GT";
            // 
            // lbHoTen
            // 
            this.lbHoTen.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbHoTen.Location = new System.Drawing.Point(192, 66);
            this.lbHoTen.Name = "lbHoTen";
            this.lbHoTen.Size = new System.Drawing.Size(33, 13);
            this.lbHoTen.TabIndex = 1018;
            this.lbHoTen.Text = "hoten";
            // 
            // lbNgaySinh
            // 
            this.lbNgaySinh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbNgaySinh.Location = new System.Drawing.Point(192, 89);
            this.lbNgaySinh.Name = "lbNgaySinh";
            this.lbNgaySinh.Size = new System.Drawing.Size(51, 13);
            this.lbNgaySinh.TabIndex = 1018;
            this.lbNgaySinh.Text = "ngaysinh";
            // 
            // lbTuoi
            // 
            this.lbTuoi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbTuoi.Location = new System.Drawing.Point(450, 89);
            this.lbTuoi.Name = "lbTuoi";
            this.lbTuoi.Size = new System.Drawing.Size(22, 13);
            this.lbTuoi.TabIndex = 1018;
            this.lbTuoi.Text = "tuoi";
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbDiaChi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbDiaChi.Location = new System.Drawing.Point(192, 108);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(344, 25);
            this.lbDiaChi.TabIndex = 1018;
            this.lbDiaChi.Text = "diachi";
            // 
            // frmSendSMS
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 376);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.picPatient);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbTuoi);
            this.Controls.Add(this.lbDiaChi);
            this.Controls.Add(this.lbNgaySinh);
            this.Controls.Add(this.lbHoTen);
            this.Controls.Add(this.lbGioiTinh);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendSMS";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Gửi Tin Nhắn Hẹn Khám Bệnh";
            this.Load += new System.EventHandler(this.frmSendSMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.MemoEdit txtNoiDung;
        private DevExpress.XtraEditors.SimpleButton butSend;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraEditors.TextEdit txtDienThoai;
        private System.Windows.Forms.PictureBox picPatient;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl lbGioiTinh;
        private DevExpress.XtraEditors.LabelControl lbHoTen;
        private DevExpress.XtraEditors.LabelControl lbNgaySinh;
        private DevExpress.XtraEditors.LabelControl lbTuoi;
        private DevExpress.XtraEditors.LabelControl lbDiaChi;
    }
}