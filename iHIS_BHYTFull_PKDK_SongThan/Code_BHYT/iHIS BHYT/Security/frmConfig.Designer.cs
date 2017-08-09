namespace Ps.Clinic.Security
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.butConnect = new DevExpress.XtraEditors.SimpleButton();
            this.cbxServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtDataBaseName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbServerName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.ForeColor = System.Drawing.Color.DarkCyan;
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.AppearanceCaption.Options.UseForeColor = true;
            this.grMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grMain.Controls.Add(this.labelControl1);
            this.grMain.Controls.Add(this.labelControl8);
            this.grMain.Controls.Add(this.butExit);
            this.grMain.Controls.Add(this.butConnect);
            this.grMain.Controls.Add(this.cbxServerName);
            this.grMain.Controls.Add(this.txtPassword);
            this.grMain.Controls.Add(this.txtUserName);
            this.grMain.Controls.Add(this.txtDataBaseName);
            this.grMain.Controls.Add(this.labelControl5);
            this.grMain.Controls.Add(this.labelControl4);
            this.grMain.Controls.Add(this.labelControl2);
            this.grMain.Controls.Add(this.lbServerName);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Margin = new System.Windows.Forms.Padding(2);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(406, 203);
            this.grMain.TabIndex = 2;
            this.grMain.Text = "Thông tin kết nối";
            // 
            // butExit
            // 
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(261, 146);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(111, 34);
            this.butExit.TabIndex = 5;
            this.butExit.Text = "Thoát";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butConnect
            // 
            this.butConnect.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butConnect.Appearance.Options.UseFont = true;
            this.butConnect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.butConnect.Image = ((System.Drawing.Image)(resources.GetObject("butConnect.Image")));
            this.butConnect.Location = new System.Drawing.Point(115, 146);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(140, 34);
            this.butConnect.TabIndex = 4;
            this.butConnect.Text = "Kết Nối";
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // cbxServerName
            // 
            this.cbxServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxServerName.Location = new System.Drawing.Point(115, 54);
            this.cbxServerName.Name = "cbxServerName";
            this.cbxServerName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cbxServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxServerName.Size = new System.Drawing.Size(257, 20);
            this.cbxServerName.TabIndex = 0;
            this.cbxServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxServerName_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(115, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(257, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(115, 98);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUserName.Size = new System.Drawing.Size(257, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataBaseName.Location = new System.Drawing.Point(115, 76);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDataBaseName.Size = new System.Drawing.Size(257, 20);
            this.txtDataBaseName.TabIndex = 1;
            this.txtDataBaseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataBaseName_KeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(60, 123);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Mật khẩu :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(32, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(79, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Tên đăng nhập :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(58, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên CSDL :";
            // 
            // lbServerName
            // 
            this.lbServerName.Location = new System.Drawing.Point(43, 57);
            this.lbServerName.Name = "lbServerName";
            this.lbServerName.Size = new System.Drawing.Size(68, 13);
            this.lbServerName.TabIndex = 0;
            this.lbServerName.Text = "Tên máy chủ :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(115, 12);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(169, 25);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Conncet Database";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(115, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(218, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Hệ thống quản lý kết nối dữ liệu từ máy trạm!";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 203);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh viện điện tử .Net";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraEditors.SimpleButton butConnect;
        private DevExpress.XtraEditors.ComboBoxEdit cbxServerName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtDataBaseName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbServerName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}