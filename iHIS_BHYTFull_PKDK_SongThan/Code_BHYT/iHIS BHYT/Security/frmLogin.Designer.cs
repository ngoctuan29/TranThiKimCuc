namespace Ps.Clinic.Security
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtimeWorking = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboxWorkShift = new System.Windows.Forms.ComboBox();
            this.butCANCEL = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.lbVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbPassword = new DevExpress.XtraEditors.LabelControl();
            this.lbUsername = new DevExpress.XtraEditors.LabelControl();
            this.psLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeWorking.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeWorking.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grMain.AppearanceCaption.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.AppearanceCaption.Options.UseForeColor = true;
            this.grMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.labelControl4);
            this.grMain.Controls.Add(this.dtimeWorking);
            this.grMain.Controls.Add(this.labelControl5);
            this.grMain.Controls.Add(this.labelControl3);
            this.grMain.Controls.Add(this.labelControl1);
            this.grMain.Controls.Add(this.cboxWorkShift);
            this.grMain.Controls.Add(this.butCANCEL);
            this.grMain.Controls.Add(this.butOK);
            this.grMain.Controls.Add(this.txtPassword);
            this.grMain.Controls.Add(this.txtUsername);
            this.grMain.Controls.Add(this.lbVersion);
            this.grMain.Controls.Add(this.labelControl2);
            this.grMain.Controls.Add(this.lbPassword);
            this.grMain.Controls.Add(this.lbUsername);
            this.grMain.Controls.Add(this.psLogo);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(467, 190);
            this.grMain.TabIndex = 101;
            this.grMain.Text = "Bệnh viện điện tử .NET (POWERSOFT JSC) - Đăng Nhập";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(33, 160);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(110, 13);
            this.labelControl4.TabIndex = 112;
            this.labelControl4.Text = "Bệnh viện điện tử .NET";
            this.labelControl4.Visible = false;
            // 
            // dtimeWorking
            // 
            this.dtimeWorking.EditValue = null;
            this.dtimeWorking.Location = new System.Drawing.Point(240, 97);
            this.dtimeWorking.Name = "dtimeWorking";
            this.dtimeWorking.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.dtimeWorking.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtimeWorking.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dtimeWorking.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtimeWorking.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtimeWorking.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dtimeWorking.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtimeWorking.Size = new System.Drawing.Size(114, 20);
            this.dtimeWorking.TabIndex = 111;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(361, 101);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(20, 13);
            this.labelControl5.TabIndex = 110;
            this.labelControl5.Text = "Ca :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(164, 101);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 110;
            this.labelControl3.Text = "Ngày làm việc :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Location = new System.Drawing.Point(238, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 29);
            this.labelControl1.TabIndex = 107;
            this.labelControl1.Text = "Đăng nhập";
            // 
            // cboxWorkShift
            // 
            this.cboxWorkShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxWorkShift.FormattingEnabled = true;
            this.cboxWorkShift.Location = new System.Drawing.Point(383, 97);
            this.cboxWorkShift.Name = "cboxWorkShift";
            this.cboxWorkShift.Size = new System.Drawing.Size(68, 21);
            this.cboxWorkShift.TabIndex = 106;
            // 
            // butCANCEL
            // 
            this.butCANCEL.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.butCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("butCANCEL.Image")));
            this.butCANCEL.Location = new System.Drawing.Point(357, 123);
            this.butCANCEL.Name = "butCANCEL";
            this.butCANCEL.Size = new System.Drawing.Size(94, 40);
            this.butCANCEL.TabIndex = 8;
            this.butCANCEL.Text = "Hủy bỏ";
            this.butCANCEL.Click += new System.EventHandler(this.butCANCEL_Click);
            // 
            // butOK
            // 
            this.butOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOK.Appearance.Options.UseFont = true;
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(240, 123);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(114, 40);
            this.butOK.TabIndex = 3;
            this.butOK.Text = "Đồng ý";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(240, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.MaxLength = 50;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(211, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(240, 53);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUsername.Properties.MaxLength = 50;
            this.txtUsername.Size = new System.Drawing.Size(211, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // lbVersion
            // 
            this.lbVersion.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbVersion.Location = new System.Drawing.Point(321, 34);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(35, 13);
            this.lbVersion.TabIndex = 101;
            this.lbVersion.Text = "Version";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(240, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 101;
            this.labelControl2.Text = "Ngày cập nhật - ";
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(186, 78);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(51, 13);
            this.lbPassword.TabIndex = 101;
            this.lbPassword.Text = "Mật khẩu :";
            // 
            // lbUsername
            // 
            this.lbUsername.Location = new System.Drawing.Point(158, 56);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(79, 13);
            this.lbUsername.TabIndex = 101;
            this.lbUsername.Text = "Tên đăng nhập :";
            // 
            // psLogo
            // 
            this.psLogo.Image = ((System.Drawing.Image)(resources.GetObject("psLogo.Image")));
            this.psLogo.Location = new System.Drawing.Point(27, 34);
            this.psLogo.Name = "psLogo";
            this.psLogo.Size = new System.Drawing.Size(120, 120);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.psLogo.TabIndex = 0;
            this.psLogo.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 190);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeWorking.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeWorking.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private System.Windows.Forms.PictureBox psLogo;
        private DevExpress.XtraEditors.LabelControl lbPassword;
        private DevExpress.XtraEditors.LabelControl lbUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.SimpleButton butCANCEL;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private System.Windows.Forms.ComboBox cboxWorkShift;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LabelControl lbVersion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtimeWorking;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}