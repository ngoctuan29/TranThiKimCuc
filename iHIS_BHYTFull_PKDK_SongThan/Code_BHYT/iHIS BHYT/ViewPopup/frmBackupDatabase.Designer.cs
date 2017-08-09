namespace Ps.Clinic.ViewPopup
{
    partial class frmBackupDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupDatabase));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pnImageView = new DevExpress.XtraEditors.PanelControl();
            this.butPath = new DevExpress.XtraEditors.SimpleButton();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbUsername = new DevExpress.XtraEditors.LabelControl();
            this.butCANCEL = new DevExpress.XtraEditors.SimpleButton();
            this.psLogo = new System.Windows.Forms.PictureBox();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.picPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnImageView)).BeginInit();
            this.pnImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 191);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(418, 31);
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
            this.ribbon.Size = new System.Drawing.Size(418, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // pnImageView
            // 
            this.pnImageView.Controls.Add(this.butPath);
            this.pnImageView.Controls.Add(this.txtPath);
            this.pnImageView.Controls.Add(this.labelControl1);
            this.pnImageView.Controls.Add(this.lbUsername);
            this.pnImageView.Controls.Add(this.butCANCEL);
            this.pnImageView.Controls.Add(this.psLogo);
            this.pnImageView.Controls.Add(this.butOK);
            this.pnImageView.Controls.Add(this.picPreview);
            this.pnImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnImageView.Location = new System.Drawing.Point(0, 49);
            this.pnImageView.Name = "pnImageView";
            this.pnImageView.Size = new System.Drawing.Size(418, 142);
            this.pnImageView.TabIndex = 179;
            // 
            // butPath
            // 
            this.butPath.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butPath.Appearance.Options.UseForeColor = true;
            this.butPath.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.butPath.Location = new System.Drawing.Point(382, 48);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(26, 20);
            this.butPath.TabIndex = 185;
            this.butPath.Text = "...";
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(176, 48);
            this.txtPath.MenuManager = this.ribbon;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(200, 20);
            this.txtPath.TabIndex = 184;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(191, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 23);
            this.labelControl1.TabIndex = 103;
            this.labelControl1.Text = "Sao Lưu CSDL";
            // 
            // lbUsername
            // 
            this.lbUsername.Location = new System.Drawing.Point(112, 52);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(61, 13);
            this.lbUsername.TabIndex = 102;
            this.lbUsername.Text = "Đường dẫn :";
            // 
            // butCANCEL
            // 
            this.butCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("butCANCEL.Image")));
            this.butCANCEL.Location = new System.Drawing.Point(264, 88);
            this.butCANCEL.Name = "butCANCEL";
            this.butCANCEL.Size = new System.Drawing.Size(75, 32);
            this.butCANCEL.TabIndex = 8;
            this.butCANCEL.Text = "Hủy bỏ";
            this.butCANCEL.Click += new System.EventHandler(this.butCANCEL_Click);
            // 
            // psLogo
            // 
            this.psLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.psLogo.Image = ((System.Drawing.Image)(resources.GetObject("psLogo.Image")));
            this.psLogo.Location = new System.Drawing.Point(2, 2);
            this.psLogo.Name = "psLogo";
            this.psLogo.Size = new System.Drawing.Size(106, 138);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psLogo.TabIndex = 1;
            this.psLogo.TabStop = false;
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(176, 88);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(82, 32);
            this.butOK.TabIndex = 3;
            this.butOK.Text = "Đồng ý";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(2, 2);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(414, 138);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // frmBackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 222);
            this.Controls.Add(this.pnImageView);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackupDatabase";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Sao lưu cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnImageView)).EndInit();
            this.pnImageView.ResumeLayout(false);
            this.pnImageView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl pnImageView;
        private System.Windows.Forms.PictureBox picPreview;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private System.Windows.Forms.PictureBox psLogo;
        private DevExpress.XtraEditors.LabelControl lbUsername;
        private DevExpress.XtraEditors.SimpleButton butCANCEL;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.SimpleButton butPath;
    }
}