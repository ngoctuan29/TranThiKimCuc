namespace Ps.Clinic.ViewPopup
{
    partial class frmChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
            this.btAccept = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPasswordNew01 = new DevExpress.XtraEditors.TextEdit();
            this.txtPasswordNew = new DevExpress.XtraEditors.TextEdit();
            this.txtPasswordOld = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.psLogo = new System.Windows.Forms.PictureBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNew01.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAccept.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btAccept.Image = ((System.Drawing.Image)(resources.GetObject("btAccept.Image")));
            this.btAccept.Location = new System.Drawing.Point(205, 120);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(65, 23);
            this.btAccept.TabIndex = 3;
            this.btAccept.Text = "Đồng ý";
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(134, 42);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(65, 13);
            this.labelControl21.TabIndex = 1010;
            this.labelControl21.Text = "Mật khẩu cũ :";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.Location = new System.Drawing.Point(271, 120);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(65, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Thoát";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.txtPasswordNew01);
            this.groupControl1.Controls.Add(this.txtPasswordNew);
            this.groupControl1.Controls.Add(this.txtPasswordOld);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.psLogo);
            this.groupControl1.Controls.Add(this.btClose);
            this.groupControl1.Controls.Add(this.btAccept);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(350, 164);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Đổi mật khẩu";
            // 
            // txtPasswordNew01
            // 
            this.txtPasswordNew01.Location = new System.Drawing.Point(205, 84);
            this.txtPasswordNew01.Name = "txtPasswordNew01";
            this.txtPasswordNew01.Properties.MaxLength = 50;
            this.txtPasswordNew01.Properties.PasswordChar = '*';
            this.txtPasswordNew01.Size = new System.Drawing.Size(133, 20);
            this.txtPasswordNew01.TabIndex = 2;
            this.txtPasswordNew01.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordNew01_KeyDown);
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.Location = new System.Drawing.Point(205, 61);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.Properties.MaxLength = 50;
            this.txtPasswordNew.Properties.PasswordChar = '*';
            this.txtPasswordNew.Size = new System.Drawing.Size(133, 20);
            this.txtPasswordNew.TabIndex = 1;
            this.txtPasswordNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordNew_KeyDown);
            // 
            // txtPasswordOld
            // 
            this.txtPasswordOld.Location = new System.Drawing.Point(205, 39);
            this.txtPasswordOld.Name = "txtPasswordOld";
            this.txtPasswordOld.Properties.MaxLength = 50;
            this.txtPasswordOld.Properties.PasswordChar = '*';
            this.txtPasswordOld.Size = new System.Drawing.Size(133, 20);
            this.txtPasswordOld.TabIndex = 0;
            this.txtPasswordOld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordOld_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.Location = new System.Drawing.Point(247, 146);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 1016;
            this.labelControl1.Text = "Powersoft Co., Ltd";
            // 
            // psLogo
            // 
            this.psLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.psLogo.Image = ((System.Drawing.Image)(resources.GetObject("psLogo.Image")));
            this.psLogo.Location = new System.Drawing.Point(2, 31);
            this.psLogo.Name = "psLogo";
            this.psLogo.Size = new System.Drawing.Size(93, 131);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psLogo.TabIndex = 1015;
            this.psLogo.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(101, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 13);
            this.labelControl3.TabIndex = 1010;
            this.labelControl3.Text = "Xác nhận mật khẩu :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(129, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 1010;
            this.labelControl2.Text = "Mật khẩu mới :";
            // 
            // frmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 164);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNew01.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btAccept;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox psLogo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPasswordNew;
        private DevExpress.XtraEditors.TextEdit txtPasswordOld;
        private DevExpress.XtraEditors.TextEdit txtPasswordNew01;

    }
}