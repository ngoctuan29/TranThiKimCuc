namespace Ps.Clinic.ViewPopup
{
    partial class frmXemChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemChiTiet));
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.butClose = new DevExpress.XtraEditors.SimpleButton();
            this.picPopup = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPopup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.Controls.Add(this.butClose);
            this.grDetails.Controls.Add(this.picPopup);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(829, 506);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "iHIS - Image Viewer";
            this.grDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.grDetails_Paint);
            this.grDetails.DoubleClick += new System.EventHandler(this.grDetails_DoubleClick);
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.Location = new System.Drawing.Point(753, 0);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Thoát";
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // picPopup
            // 
            this.picPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPopup.Location = new System.Drawing.Point(2, 23);
            this.picPopup.Name = "picPopup";
            this.picPopup.Size = new System.Drawing.Size(825, 481);
            this.picPopup.TabIndex = 1;
            // 
            // frmXemChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 506);
            this.ControlBox = false;
            this.Controls.Add(this.grDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXemChiTiet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin chi tiết của bệnh nhân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPatientDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPopup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraEditors.PictureEdit picPopup;
        private DevExpress.XtraEditors.SimpleButton butClose;
    }
}