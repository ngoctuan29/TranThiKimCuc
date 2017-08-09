namespace Ps.Clinic.ViewPopup
{
    partial class frmChonKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonKho));
            this.btAccept = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.psLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAccept.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btAccept.Image = ((System.Drawing.Image)(resources.GetObject("btAccept.Image")));
            this.btAccept.Location = new System.Drawing.Point(136, 76);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(83, 23);
            this.btAccept.TabIndex = 1008;
            this.btAccept.Text = "Đồng ý";
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(102, 53);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(32, 13);
            this.labelControl21.TabIndex = 1010;
            this.labelControl21.Text = "Chọn :";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.Location = new System.Drawing.Point(223, 76);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(65, 23);
            this.btClose.TabIndex = 1012;
            this.btClose.Text = "Thoát";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lkupKho
            // 
            this.lkupKho.EditValue = "";
            this.lkupKho.Location = new System.Drawing.Point(137, 50);
            this.lkupKho.Name = "lkupKho";
            this.lkupKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupKho.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryCode", "Mã kho", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryName", "Tên kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hide", "Hide", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AllowAdded", "AllowAdded", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupKho.Properties.NullText = "";
            this.lkupKho.Size = new System.Drawing.Size(151, 20);
            this.lkupKho.TabIndex = 1014;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.psLogo);
            this.groupControl1.Controls.Add(this.btClose);
            this.groupControl1.Controls.Add(this.btAccept);
            this.groupControl1.Controls.Add(this.lkupKho);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(312, 130);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Kho xuất thuốc";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.Location = new System.Drawing.Point(197, 112);
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
            this.psLogo.Size = new System.Drawing.Size(76, 97);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psLogo.TabIndex = 1015;
            this.psLogo.TabStop = false;
            // 
            // frmChonKhoXuatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 130);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonKhoXuatBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Kho BHYT.";
            this.Load += new System.EventHandler(this.frmChonKhoXuatBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btAccept;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox psLogo;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}