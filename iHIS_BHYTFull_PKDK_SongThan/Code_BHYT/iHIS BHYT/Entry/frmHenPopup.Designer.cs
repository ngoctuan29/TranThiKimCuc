namespace Ps.Clinic.Entry
{
    partial class frmHenPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHenPopup));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.picPatient = new System.Windows.Forms.PictureBox();
            this.ma = new DevExpress.XtraEditors.TextEdit();
            this.ten = new DevExpress.XtraEditors.TextEdit();
            this.diachi = new DevExpress.XtraEditors.TextEdit();
            this.dienthoai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.loaituoi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.ngaysinh = new DevExpress.XtraEditors.TextEdit();
            this.cbgioitinh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.namsinh = new DevExpress.XtraEditors.TextEdit();
            this.tuoi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhichu = new DevExpress.XtraEditors.MemoEdit();
            this.cbPhongkham = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtNgayHen = new DevExpress.XtraEditors.DateEdit();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dienthoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaituoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaysinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbgioitinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namsinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhichu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPhongkham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayHen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayHen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 398);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(404, 31);
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
            this.ribbon.Size = new System.Drawing.Size(404, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // picPatient
            // 
            this.picPatient.ErrorImage = global::Ps.Clinic.Properties.Resources.NoImgPatient;
            this.picPatient.Image = global::Ps.Clinic.Properties.Resources.NoImgPatient;
            this.picPatient.Location = new System.Drawing.Point(71, 55);
            this.picPatient.Name = "picPatient";
            this.picPatient.Size = new System.Drawing.Size(96, 105);
            this.picPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPatient.TabIndex = 1025;
            this.picPatient.TabStop = false;
            // 
            // ma
            // 
            this.ma.Location = new System.Drawing.Point(71, 163);
            this.ma.Name = "ma";
            this.ma.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.ma.Properties.Appearance.Options.UseFont = true;
            this.ma.Properties.MaxLength = 8;
            this.ma.Size = new System.Drawing.Size(190, 20);
            this.ma.TabIndex = 1006;
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(71, 185);
            this.ten.Name = "ten";
            this.ten.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.ten.Properties.Appearance.Options.UseFont = true;
            this.ten.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.ten.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.ten.Size = new System.Drawing.Size(190, 20);
            this.ten.TabIndex = 1007;
            // 
            // diachi
            // 
            this.diachi.Location = new System.Drawing.Point(71, 229);
            this.diachi.Name = "diachi";
            this.diachi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.diachi.Properties.Appearance.Options.UseFont = true;
            this.diachi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.diachi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.diachi.Size = new System.Drawing.Size(327, 20);
            this.diachi.TabIndex = 1013;
            // 
            // dienthoai
            // 
            this.dienthoai.Location = new System.Drawing.Point(71, 251);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.dienthoai.Properties.Appearance.Options.UseFont = true;
            this.dienthoai.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.dienthoai.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dienthoai.Size = new System.Drawing.Size(129, 20);
            this.dienthoai.TabIndex = 1014;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl5.Location = new System.Drawing.Point(29, 166);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 14);
            this.labelControl5.TabIndex = 1023;
            this.labelControl5.Text = "Mã số :";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(246, 251);
            this.email.Name = "email";
            this.email.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.email.Properties.Appearance.Options.UseFont = true;
            this.email.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.email.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.email.Size = new System.Drawing.Size(152, 20);
            this.email.TabIndex = 1015;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl13.Location = new System.Drawing.Point(212, 254);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(31, 13);
            this.labelControl13.TabIndex = 1022;
            this.labelControl13.Text = "Email :";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl12.Location = new System.Drawing.Point(5, 254);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(63, 14);
            this.labelControl12.TabIndex = 1021;
            this.labelControl12.Text = "Điện thoại :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl6.Location = new System.Drawing.Point(22, 188);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 14);
            this.labelControl6.TabIndex = 1016;
            this.labelControl6.Text = "Họ tên :";
            // 
            // loaituoi
            // 
            this.loaituoi.Location = new System.Drawing.Point(345, 207);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.loaituoi.Properties.Appearance.Options.UseFont = true;
            this.loaituoi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.loaituoi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.loaituoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.loaituoi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.loaituoi.Size = new System.Drawing.Size(53, 20);
            this.loaituoi.TabIndex = 1012;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl11.Location = new System.Drawing.Point(25, 232);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(43, 14);
            this.labelControl11.TabIndex = 1020;
            this.labelControl11.Text = "Địa chỉ :";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl7.Location = new System.Drawing.Point(271, 188);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(27, 14);
            this.labelControl7.TabIndex = 1024;
            this.labelControl7.Text = "Giới :";
            // 
            // ngaysinh
            // 
            this.ngaysinh.EditValue = "";
            this.ngaysinh.Location = new System.Drawing.Point(71, 207);
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.ngaysinh.Properties.Appearance.Options.UseFont = true;
            this.ngaysinh.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.ngaysinh.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.ngaysinh.Properties.Mask.EditMask = "99/99/0000";
            this.ngaysinh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.ngaysinh.Size = new System.Drawing.Size(72, 20);
            this.ngaysinh.TabIndex = 1009;
            // 
            // cbgioitinh
            // 
            this.cbgioitinh.Location = new System.Drawing.Point(301, 185);
            this.cbgioitinh.Name = "cbgioitinh";
            this.cbgioitinh.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.cbgioitinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cbgioitinh.Properties.Appearance.Options.UseFont = true;
            this.cbgioitinh.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.cbgioitinh.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cbgioitinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbgioitinh.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbgioitinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbgioitinh.Size = new System.Drawing.Size(97, 20);
            this.cbgioitinh.TabIndex = 1008;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl10.Location = new System.Drawing.Point(266, 210);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(32, 14);
            this.labelControl10.TabIndex = 1018;
            this.labelControl10.Text = "Tuổi :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl8.Location = new System.Drawing.Point(14, 210);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(54, 13);
            this.labelControl8.TabIndex = 1017;
            this.labelControl8.Text = "Ngày sinh :";
            // 
            // namsinh
            // 
            this.namsinh.EditValue = "";
            this.namsinh.Location = new System.Drawing.Point(203, 207);
            this.namsinh.Name = "namsinh";
            this.namsinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.namsinh.Properties.Appearance.Options.UseFont = true;
            this.namsinh.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.namsinh.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.namsinh.Size = new System.Drawing.Size(58, 20);
            this.namsinh.TabIndex = 1010;
            // 
            // tuoi
            // 
            this.tuoi.Location = new System.Drawing.Point(301, 207);
            this.tuoi.Name = "tuoi";
            this.tuoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.tuoi.Properties.Appearance.Options.UseFont = true;
            this.tuoi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.tuoi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.tuoi.Size = new System.Drawing.Size(38, 20);
            this.tuoi.TabIndex = 1011;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl9.Location = new System.Drawing.Point(150, 210);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(50, 13);
            this.labelControl9.TabIndex = 1019;
            this.labelControl9.Text = "Năm sinh :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl1.Location = new System.Drawing.Point(3, 276);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 1021;
            this.labelControl1.Text = "Phòng khám :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl2.Location = new System.Drawing.Point(26, 300);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 1021;
            this.labelControl2.Text = "Ghi chú :";
            // 
            // txtGhichu
            // 
            this.txtGhichu.Location = new System.Drawing.Point(71, 295);
            this.txtGhichu.MenuManager = this.ribbon;
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.txtGhichu.Properties.Appearance.Options.UseFont = true;
            this.txtGhichu.Size = new System.Drawing.Size(327, 68);
            this.txtGhichu.TabIndex = 1026;
            // 
            // cbPhongkham
            // 
            this.cbPhongkham.Location = new System.Drawing.Point(71, 273);
            this.cbPhongkham.MenuManager = this.ribbon;
            this.cbPhongkham.Name = "cbPhongkham";
            this.cbPhongkham.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cbPhongkham.Properties.Appearance.Options.UseFont = true;
            this.cbPhongkham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPhongkham.Size = new System.Drawing.Size(129, 20);
            this.cbPhongkham.TabIndex = 1027;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl3.Location = new System.Drawing.Point(212, 276);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 1022;
            this.labelControl3.Text = "Ngày :";
            // 
            // dtNgayHen
            // 
            this.dtNgayHen.EditValue = null;
            this.dtNgayHen.Location = new System.Drawing.Point(246, 273);
            this.dtNgayHen.MenuManager = this.ribbon;
            this.dtNgayHen.Name = "dtNgayHen";
            this.dtNgayHen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.dtNgayHen.Properties.Appearance.Options.UseFont = true;
            this.dtNgayHen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayHen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayHen.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dtNgayHen.Size = new System.Drawing.Size(152, 20);
            this.dtNgayHen.TabIndex = 1028;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butSave.Appearance.Options.UseFont = true;
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(71, 369);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(63, 23);
            this.butSave.TabIndex = 1029;
            this.butSave.Text = "Lưu";
            this.butSave.ToolTip = "F2 - Lưu";
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butExit.Appearance.Options.UseFont = true;
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(135, 369);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 1030;
            this.butExit.Text = "Thoát";
            // 
            // frmHenPopup
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 429);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.dtNgayHen);
            this.Controls.Add(this.cbPhongkham);
            this.Controls.Add(this.txtGhichu);
            this.Controls.Add(this.picPatient);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.email);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.cbgioitinh);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHenPopup";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Thông Tin Hẹn Khám";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dienthoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaituoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaysinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbgioitinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namsinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhichu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPhongkham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayHen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayHen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private System.Windows.Forms.PictureBox picPatient;
        private DevExpress.XtraEditors.TextEdit ma;
        private DevExpress.XtraEditors.TextEdit ten;
        private DevExpress.XtraEditors.TextEdit diachi;
        private DevExpress.XtraEditors.TextEdit dienthoai;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit email;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.ComboBoxEdit loaituoi;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit ngaysinh;
        public DevExpress.XtraEditors.ComboBoxEdit cbgioitinh;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit namsinh;
        private DevExpress.XtraEditors.TextEdit tuoi;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtGhichu;
        private DevExpress.XtraEditors.ComboBoxEdit cbPhongkham;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtNgayHen;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butExit;
    }
}