namespace Ps.Clinic.ViewPopup
{
    partial class frmChonLoaiXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonLoaiXN));
            this.Lkupkhoaphong = new DevExpress.XtraEditors.LookUpEdit();
            this.btChonkham = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.butiClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.psLogo = new System.Windows.Forms.PictureBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkXetNghiem = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Lkupkhoaphong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkXetNghiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Lkupkhoaphong
            // 
            this.Lkupkhoaphong.Location = new System.Drawing.Point(158, 54);
            this.Lkupkhoaphong.Name = "Lkupkhoaphong";
            this.Lkupkhoaphong.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.Lkupkhoaphong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Lkupkhoaphong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "Mã KP", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Tên khoa phòng")});
            this.Lkupkhoaphong.Properties.NullText = "Chọn phòng ... ";
            this.Lkupkhoaphong.Size = new System.Drawing.Size(176, 20);
            this.Lkupkhoaphong.TabIndex = 1006;
            // 
            // btChonkham
            // 
            this.btChonkham.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btChonkham.Image = ((System.Drawing.Image)(resources.GetObject("btChonkham.Image")));
            this.btChonkham.Location = new System.Drawing.Point(158, 82);
            this.btChonkham.Name = "btChonkham";
            this.btChonkham.Size = new System.Drawing.Size(83, 23);
            this.btChonkham.TabIndex = 1008;
            this.btChonkham.Text = "Đồng ý";
            this.btChonkham.Click += new System.EventHandler(this.btChonkham_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(115, 57);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(37, 13);
            this.labelControl21.TabIndex = 1010;
            this.labelControl21.Text = "Phòng :";
            // 
            // butiClose
            // 
            this.butiClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butiClose.Image = ((System.Drawing.Image)(resources.GetObject("butiClose.Image")));
            this.butiClose.Location = new System.Drawing.Point(245, 82);
            this.butiClose.Name = "butiClose";
            this.butiClose.Size = new System.Drawing.Size(88, 23);
            this.butiClose.TabIndex = 1012;
            this.butiClose.Text = "Thoát";
            this.butiClose.Click += new System.EventHandler(this.butiClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.psLogo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.lkXetNghiem);
            this.groupControl1.Controls.Add(this.Lkupkhoaphong);
            this.groupControl1.Controls.Add(this.butiClose);
            this.groupControl1.Controls.Add(this.btChonkham);
            this.groupControl1.Location = new System.Drawing.Point(0, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(339, 159);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Chọn phòng - Loại XN lấy mẫu";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.Location = new System.Drawing.Point(221, 135);
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
            this.psLogo.Size = new System.Drawing.Size(107, 126);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psLogo.TabIndex = 1013;
            this.psLogo.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(115, 123);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 1010;
            this.labelControl2.Text = "Xét nghiệm :";
            this.labelControl2.Visible = false;
            // 
            // lkXetNghiem
            // 
            this.lkXetNghiem.Location = new System.Drawing.Point(181, 120);
            this.lkXetNghiem.Name = "lkXetNghiem";
            this.lkXetNghiem.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkXetNghiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkXetNghiem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryCode", "Mã Loại", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryName", "Loại xét nghiệm")});
            this.lkXetNghiem.Properties.NullText = "Loại xét nghiệm ... ";
            this.lkXetNghiem.Size = new System.Drawing.Size(34, 20);
            this.lkXetNghiem.TabIndex = 1006;
            this.lkXetNghiem.Visible = false;
            // 
            // frmChonLoaiXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 161);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonLoaiXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng khám.";
            this.Load += new System.EventHandler(this.frmChonLoaiXN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lkupkhoaphong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkXetNghiem.Properties)).EndInit();
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
        public DevExpress.XtraEditors.LookUpEdit lkXetNghiem;

    }
}