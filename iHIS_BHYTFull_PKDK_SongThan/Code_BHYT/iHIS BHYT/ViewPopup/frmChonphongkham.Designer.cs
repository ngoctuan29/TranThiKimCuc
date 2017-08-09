namespace Ps.Clinic.ViewPopup
{
    partial class frmChonphongkham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonphongkham));
            this.Lkupkhoaphong = new DevExpress.XtraEditors.LookUpEdit();
            this.btChonkham = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.butiClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.psLogo = new System.Windows.Forms.PictureBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkupEmployee = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Lkupkhoaphong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupEmployee.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Lkupkhoaphong
            // 
            this.Lkupkhoaphong.EditValue = "";
            this.Lkupkhoaphong.Location = new System.Drawing.Point(177, 39);
            this.Lkupkhoaphong.Name = "Lkupkhoaphong";
            this.Lkupkhoaphong.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.Lkupkhoaphong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Lkupkhoaphong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "Mã KP", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Tên khoa phòng")});
            this.Lkupkhoaphong.Properties.NullText = "Phòng khám";
            this.Lkupkhoaphong.Size = new System.Drawing.Size(157, 20);
            this.Lkupkhoaphong.TabIndex = 1;
            this.Lkupkhoaphong.EditValueChanged += new System.EventHandler(this.Lkupkhoaphong_EditValueChanged);
            // 
            // btChonkham
            // 
            this.btChonkham.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btChonkham.Image = ((System.Drawing.Image)(resources.GetObject("btChonkham.Image")));
            this.btChonkham.Location = new System.Drawing.Point(177, 87);
            this.btChonkham.Name = "btChonkham";
            this.btChonkham.Size = new System.Drawing.Size(74, 25);
            this.btChonkham.TabIndex = 3;
            this.btChonkham.Text = "Đồng ý";
            this.btChonkham.Click += new System.EventHandler(this.btChonkham_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(106, 42);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(65, 13);
            this.labelControl21.TabIndex = 1010;
            this.labelControl21.Text = "Phòng khám :";
            // 
            // butiClose
            // 
            this.butiClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.butiClose.Image = ((System.Drawing.Image)(resources.GetObject("butiClose.Image")));
            this.butiClose.Location = new System.Drawing.Point(252, 87);
            this.butiClose.Name = "butiClose";
            this.butiClose.Size = new System.Drawing.Size(82, 25);
            this.butiClose.TabIndex = 4;
            this.butiClose.Text = "Thoát";
            this.butiClose.Click += new System.EventHandler(this.butiClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.psLogo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.lkupEmployee);
            this.groupControl1.Controls.Add(this.Lkupkhoaphong);
            this.groupControl1.Controls.Add(this.butiClose);
            this.groupControl1.Controls.Add(this.btChonkham);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(346, 156);
            this.groupControl1.TabIndex = 1016;
            this.groupControl1.Text = "Chọn phòng và bác sĩ khám";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(177, 138);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 13);
            this.labelControl1.TabIndex = 1014;
            this.labelControl1.Text = "Bệnh viện điện tử .NET";
            // 
            // psLogo
            // 
            this.psLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.psLogo.Image = ((System.Drawing.Image)(resources.GetObject("psLogo.Image")));
            this.psLogo.Location = new System.Drawing.Point(2, 23);
            this.psLogo.Name = "psLogo";
            this.psLogo.Size = new System.Drawing.Size(98, 131);
            this.psLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psLogo.TabIndex = 1013;
            this.psLogo.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(137, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 1010;
            this.labelControl2.Text = "Bác sĩ :";
            // 
            // lkupEmployee
            // 
            this.lkupEmployee.EditValue = "";
            this.lkupEmployee.Location = new System.Drawing.Point(177, 61);
            this.lkupEmployee.Name = "lkupEmployee";
            this.lkupEmployee.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkupEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupEmployee.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeName", "Bác sĩ")});
            this.lkupEmployee.Properties.NullText = "Bác sĩ";
            this.lkupEmployee.Size = new System.Drawing.Size(157, 20);
            this.lkupEmployee.TabIndex = 2;
            // 
            // frmChonphongkham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 156);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonphongkham";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng khám.";
            this.Load += new System.EventHandler(this.frmChonphongkham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lkupkhoaphong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupEmployee.Properties)).EndInit();
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
        public DevExpress.XtraEditors.LookUpEdit lkupEmployee;

    }
}