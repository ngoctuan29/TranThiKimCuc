namespace Ps.Clinic.Statistics
{
    partial class frmRpt_BacSiThucHien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_BacSiThucHien));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dtNgay = new UserControlDateTimes.UserControlDateTimes();
            this.rd02 = new System.Windows.Forms.RadioButton();
            this.rd03 = new System.Windows.Forms.RadioButton();
            this.rd01 = new System.Windows.Forms.RadioButton();
            this.mnoTitle = new DevExpress.XtraEditors.MemoEdit();
            this.lkPatientType = new DevExpress.XtraEditors.LookUpEdit();
            this.cbDepartment = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.chkList_Service = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkList_Category = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkList_Doctor = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkList_Group = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnoTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPatientType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Doctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Group)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.dtNgay);
            this.groupControl2.Controls.Add(this.rd02);
            this.groupControl2.Controls.Add(this.rd03);
            this.groupControl2.Controls.Add(this.rd01);
            this.groupControl2.Controls.Add(this.mnoTitle);
            this.groupControl2.Controls.Add(this.lkPatientType);
            this.groupControl2.Controls.Add(this.cbDepartment);
            this.groupControl2.Controls.Add(this.chkList_Service);
            this.groupControl2.Controls.Add(this.chkList_Category);
            this.groupControl2.Controls.Add(this.chkList_Doctor);
            this.groupControl2.Controls.Add(this.chkList_Group);
            this.groupControl2.Controls.Add(this.labelControl19);
            this.groupControl2.Controls.Add(this.butOK);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(795, 469);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông tin tìm kiếm";
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(5, 25);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(640, 25);
            this.dtNgay.TabIndex = 1043;
            // 
            // rd02
            // 
            this.rd02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rd02.AutoSize = true;
            this.rd02.Location = new System.Drawing.Point(231, 418);
            this.rd02.Name = "rd02";
            this.rd02.Size = new System.Drawing.Size(132, 17);
            this.rd02.TabIndex = 1042;
            this.rd02.Text = "Mẫu báo cáo tổng hợp";
            this.rd02.UseVisualStyleBackColor = true;
            // 
            // rd03
            // 
            this.rd03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rd03.AutoSize = true;
            this.rd03.Location = new System.Drawing.Point(80, 440);
            this.rd03.Name = "rd03";
            this.rd03.Size = new System.Drawing.Size(194, 17);
            this.rd03.TabIndex = 1042;
            this.rd03.Text = "Mẫu báo cáo tổng hợp theo dịch vụ";
            this.rd03.UseVisualStyleBackColor = true;
            // 
            // rd01
            // 
            this.rd01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rd01.AutoSize = true;
            this.rd01.Checked = true;
            this.rd01.Location = new System.Drawing.Point(80, 418);
            this.rd01.Name = "rd01";
            this.rd01.Size = new System.Drawing.Size(121, 17);
            this.rd01.TabIndex = 1042;
            this.rd01.TabStop = true;
            this.rd01.Text = "Mẫu báo cáo chi tiết";
            this.rd01.UseVisualStyleBackColor = true;
            // 
            // mnoTitle
            // 
            this.mnoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mnoTitle.Location = new System.Drawing.Point(80, 377);
            this.mnoTitle.Name = "mnoTitle";
            this.mnoTitle.Size = new System.Drawing.Size(283, 35);
            this.mnoTitle.TabIndex = 1041;
            // 
            // lkPatientType
            // 
            this.lkPatientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkPatientType.EditValue = "-1";
            this.lkPatientType.Location = new System.Drawing.Point(80, 355);
            this.lkPatientType.Name = "lkPatientType";
            this.lkPatientType.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.lkPatientType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkPatientType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkPatientType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkPatientType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "Bệnh nhân")});
            this.lkPatientType.Properties.NullText = "";
            this.lkPatientType.Size = new System.Drawing.Size(283, 20);
            this.lkPatientType.TabIndex = 1040;
            // 
            // cbDepartment
            // 
            this.cbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDepartment.EditValue = "";
            this.cbDepartment.Location = new System.Drawing.Point(80, 333);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDepartment.Size = new System.Drawing.Size(283, 20);
            this.cbDepartment.TabIndex = 1039;
            // 
            // chkList_Service
            // 
            this.chkList_Service.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkList_Service.Location = new System.Drawing.Point(445, 204);
            this.chkList_Service.Name = "chkList_Service";
            this.chkList_Service.Size = new System.Drawing.Size(345, 208);
            this.chkList_Service.TabIndex = 1038;
            // 
            // chkList_Category
            // 
            this.chkList_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkList_Category.Location = new System.Drawing.Point(80, 204);
            this.chkList_Category.Name = "chkList_Category";
            this.chkList_Category.Size = new System.Drawing.Size(283, 128);
            this.chkList_Category.TabIndex = 1038;
            this.chkList_Category.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkList_Category_ItemCheck);
            // 
            // chkList_Doctor
            // 
            this.chkList_Doctor.Location = new System.Drawing.Point(80, 57);
            this.chkList_Doctor.Name = "chkList_Doctor";
            this.chkList_Doctor.Size = new System.Drawing.Size(283, 141);
            this.chkList_Doctor.TabIndex = 1038;
            // 
            // chkList_Group
            // 
            this.chkList_Group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkList_Group.Location = new System.Drawing.Point(445, 57);
            this.chkList_Group.Name = "chkList_Group";
            this.chkList_Group.Size = new System.Drawing.Size(345, 141);
            this.chkList_Group.TabIndex = 1038;
            this.chkList_Group.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkList_Group_ItemCheck);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(5, 60);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(73, 13);
            this.labelControl19.TabIndex = 1035;
            this.labelControl19.Text = "B.Sĩ thực hiện :";
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(445, 435);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 29);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Xem báo cáo";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(403, 207);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Dịch vụ:";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Location = new System.Drawing.Point(6, 377);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Tiêu đề B.cáo: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(23, 358);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Bệnh nhân:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(7, 336);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ph. Thực hiện:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 207);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Loại dịch vụ:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(374, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Nhóm dịch vụ:";
            // 
            // frmRpt_BacSiThucHien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 469);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRpt_BacSiThucHien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRpt_BacSiThucHien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnoTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPatientType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Doctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Group)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        
        private DevExpress.XtraEditors.CheckedListBoxControl chkList_Category;
        private DevExpress.XtraEditors.CheckedListBoxControl chkList_Group;
        private DevExpress.XtraEditors.CheckedListBoxControl chkList_Doctor;
        private DevExpress.XtraEditors.CheckedListBoxControl chkList_Service;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbDepartment;
        public DevExpress.XtraEditors.LookUpEdit lkPatientType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit mnoTitle;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.RadioButton rd02;
        private System.Windows.Forms.RadioButton rd01;
        private System.Windows.Forms.RadioButton rd03;
        private UserControlDateTimes.UserControlDateTimes dtNgay;
    }
}