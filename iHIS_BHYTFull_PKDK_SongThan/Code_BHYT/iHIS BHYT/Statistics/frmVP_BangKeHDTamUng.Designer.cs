namespace Ps.Clinic.Statistics
{
    partial class frmVP_BangKeHDTamUng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_BangKeHDTamUng));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Counts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_WorkingDateOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeCodeOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLKEmployeeOrder = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_WorkingDateRePaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeCodeRePaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLKEmployeeRePaid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dllNgay = new UserControlDate.dllNgay();
            this.datePrint = new DevExpress.XtraEditors.DateEdit();
            this.chkCancel = new System.Windows.Forms.CheckBox();
            this.chkList_Object = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkList_Employee = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.rdNhanVien = new System.Windows.Forms.RadioButton();
            this.rdTheoNgay = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbEmployeeName = new DevExpress.XtraEditors.LabelControl();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.butExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKEmployeeOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKEmployeeRePaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePrint.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Object)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gridControl_Data);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(974, 689);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông tin báo cáo";
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Data.Location = new System.Drawing.Point(387, 27);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLKEmployeeOrder,
            this.repLKEmployeeRePaid});
            this.gridControl_Data.Size = new System.Drawing.Size(585, 660);
            this.gridControl_Data.TabIndex = 1040;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            // 
            // gridView_Data
            // 
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PatientName,
            this.col_PatientCode,
            this.col_ObjectName,
            this.col_AmountReal,
            this.col_Counts,
            this.col_Status,
            this.col_WorkingDateOrder,
            this.col_EmployeeCodeOrder,
            this.col_WorkingDateRePaid,
            this.col_EmployeeCodeRePaid});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.GroupPanelText = "Kéo cột vào đây để nhóm dữ liệu";
            this.gridView_Data.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmoutReal", null, "(Tổng tiền:{0:#,#.####})")});
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.OptionsView.ShowFooter = true;
            // 
            // col_PatientName
            // 
            this.col_PatientName.Caption = "Tên bệnh nhân";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 0;
            this.col_PatientName.Width = 138;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.Caption = "Mã bệnh nhân";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 1;
            this.col_PatientCode.Width = 77;
            // 
            // col_ObjectName
            // 
            this.col_ObjectName.Caption = "Đối tượng";
            this.col_ObjectName.FieldName = "ObjectName";
            this.col_ObjectName.Name = "col_ObjectName";
            this.col_ObjectName.Visible = true;
            this.col_ObjectName.VisibleIndex = 2;
            this.col_ObjectName.Width = 71;
            // 
            // col_AmountReal
            // 
            this.col_AmountReal.Caption = "Tiền tạm ứng";
            this.col_AmountReal.DisplayFormat.FormatString = "{0:#,#}";
            this.col_AmountReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountReal.FieldName = "AmountReal";
            this.col_AmountReal.Name = "col_AmountReal";
            this.col_AmountReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountReal", "{0:#,#}")});
            this.col_AmountReal.Visible = true;
            this.col_AmountReal.VisibleIndex = 5;
            this.col_AmountReal.Width = 105;
            // 
            // col_Counts
            // 
            this.col_Counts.Caption = "Lần đóng tiền";
            this.col_Counts.FieldName = "Counts";
            this.col_Counts.Name = "col_Counts";
            this.col_Counts.Visible = true;
            this.col_Counts.VisibleIndex = 4;
            this.col_Counts.Width = 67;
            // 
            // col_Status
            // 
            this.col_Status.Caption = "Trạng thái";
            this.col_Status.FieldName = "Status";
            this.col_Status.Name = "col_Status";
            this.col_Status.Visible = true;
            this.col_Status.VisibleIndex = 3;
            this.col_Status.Width = 79;
            // 
            // col_WorkingDateOrder
            // 
            this.col_WorkingDateOrder.Caption = "Ngày đóng tạm ứng";
            this.col_WorkingDateOrder.FieldName = "WorkingDateOrder";
            this.col_WorkingDateOrder.Name = "col_WorkingDateOrder";
            this.col_WorkingDateOrder.Visible = true;
            this.col_WorkingDateOrder.VisibleIndex = 6;
            this.col_WorkingDateOrder.Width = 109;
            // 
            // col_EmployeeCodeOrder
            // 
            this.col_EmployeeCodeOrder.Caption = "Nhân viên thu";
            this.col_EmployeeCodeOrder.ColumnEdit = this.repLKEmployeeOrder;
            this.col_EmployeeCodeOrder.FieldName = "EmployeeCodeOrder";
            this.col_EmployeeCodeOrder.Name = "col_EmployeeCodeOrder";
            this.col_EmployeeCodeOrder.Visible = true;
            this.col_EmployeeCodeOrder.VisibleIndex = 7;
            this.col_EmployeeCodeOrder.Width = 109;
            // 
            // repLKEmployeeOrder
            // 
            this.repLKEmployeeOrder.AutoHeight = false;
            this.repLKEmployeeOrder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLKEmployeeOrder.DisplayMember = "EmployeeName";
            this.repLKEmployeeOrder.Name = "repLKEmployeeOrder";
            this.repLKEmployeeOrder.NullText = "nhân viên";
            this.repLKEmployeeOrder.ValueMember = "EmployeeCode";
            // 
            // col_WorkingDateRePaid
            // 
            this.col_WorkingDateRePaid.Caption = "Ngày hoàn trả";
            this.col_WorkingDateRePaid.FieldName = "WorkingDateRePaid";
            this.col_WorkingDateRePaid.Name = "col_WorkingDateRePaid";
            this.col_WorkingDateRePaid.Visible = true;
            this.col_WorkingDateRePaid.VisibleIndex = 8;
            this.col_WorkingDateRePaid.Width = 129;
            // 
            // col_EmployeeCodeRePaid
            // 
            this.col_EmployeeCodeRePaid.Caption = "Nhân viên hoàn tiền";
            this.col_EmployeeCodeRePaid.ColumnEdit = this.repLKEmployeeRePaid;
            this.col_EmployeeCodeRePaid.FieldName = "EmployeeCodeRePaid";
            this.col_EmployeeCodeRePaid.Name = "col_EmployeeCodeRePaid";
            this.col_EmployeeCodeRePaid.Visible = true;
            this.col_EmployeeCodeRePaid.VisibleIndex = 9;
            this.col_EmployeeCodeRePaid.Width = 129;
            // 
            // repLKEmployeeRePaid
            // 
            this.repLKEmployeeRePaid.AutoHeight = false;
            this.repLKEmployeeRePaid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLKEmployeeRePaid.DisplayMember = "EmployeeName";
            this.repLKEmployeeRePaid.Name = "repLKEmployeeRePaid";
            this.repLKEmployeeRePaid.NullText = "";
            this.repLKEmployeeRePaid.ValueMember = "EmployeeCode";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Controls.Add(this.datePrint);
            this.panelControl2.Controls.Add(this.chkCancel);
            this.panelControl2.Controls.Add(this.chkList_Object);
            this.panelControl2.Controls.Add(this.chkList_Employee);
            this.panelControl2.Controls.Add(this.rdNhanVien);
            this.panelControl2.Controls.Add(this.rdTheoNgay);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.lbEmployeeName);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Controls.Add(this.butExcel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 27);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(385, 660);
            this.panelControl2.TabIndex = 1039;
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(7, 4);
            this.dllNgay.Margin = new System.Windows.Forms.Padding(5);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(353, 90);
            this.dllNgay.TabIndex = 1052;
            // 
            // datePrint
            // 
            this.datePrint.EditValue = null;
            this.datePrint.Location = new System.Drawing.Point(232, 590);
            this.datePrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.datePrint.Name = "datePrint";
            this.datePrint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePrint.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePrint.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datePrint.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePrint.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datePrint.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePrint.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.datePrint.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datePrint.Size = new System.Drawing.Size(124, 22);
            this.datePrint.TabIndex = 1043;
            this.datePrint.Visible = false;
            // 
            // chkCancel
            // 
            this.chkCancel.AutoSize = true;
            this.chkCancel.Location = new System.Drawing.Point(75, 591);
            this.chkCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCancel.Name = "chkCancel";
            this.chkCancel.Size = new System.Drawing.Size(98, 21);
            this.chkCancel.TabIndex = 1042;
            this.chkCancel.Text = "Biên lai huỷ";
            this.chkCancel.UseVisualStyleBackColor = true;
            this.chkCancel.Visible = false;
            // 
            // chkList_Object
            // 
            this.chkList_Object.Location = new System.Drawing.Point(69, 383);
            this.chkList_Object.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkList_Object.Name = "chkList_Object";
            this.chkList_Object.Size = new System.Drawing.Size(290, 169);
            this.chkList_Object.TabIndex = 1041;
            // 
            // chkList_Employee
            // 
            this.chkList_Employee.Location = new System.Drawing.Point(69, 96);
            this.chkList_Employee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkList_Employee.Name = "chkList_Employee";
            this.chkList_Employee.Size = new System.Drawing.Size(287, 279);
            this.chkList_Employee.TabIndex = 1040;
            // 
            // rdNhanVien
            // 
            this.rdNhanVien.AutoSize = true;
            this.rdNhanVien.Location = new System.Drawing.Point(235, 560);
            this.rdNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdNhanVien.Name = "rdNhanVien";
            this.rdNhanVien.Size = new System.Drawing.Size(124, 21);
            this.rdNhanVien.TabIndex = 1039;
            this.rdNhanVien.Text = "Theo nhân viên";
            this.rdNhanVien.UseVisualStyleBackColor = true;
            // 
            // rdTheoNgay
            // 
            this.rdTheoNgay.AutoSize = true;
            this.rdTheoNgay.Location = new System.Drawing.Point(100, 562);
            this.rdTheoNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdTheoNgay.Name = "rdTheoNgay";
            this.rdTheoNgay.Size = new System.Drawing.Size(95, 21);
            this.rdTheoNgay.TabIndex = 1039;
            this.rdTheoNgay.Text = "Theo ngày";
            this.rdTheoNgay.UseVisualStyleBackColor = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 386);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 17);
            this.labelControl1.TabIndex = 1035;
            this.labelControl1.Text = "Đối tượng :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(178, 593);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 1035;
            this.labelControl2.Text = "Ngày in :";
            // 
            // lbEmployeeName
            // 
            this.lbEmployeeName.Location = new System.Drawing.Point(7, 100);
            this.lbEmployeeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbEmployeeName.Name = "lbEmployeeName";
            this.lbEmployeeName.Size = new System.Drawing.Size(63, 16);
            this.lbEmployeeName.TabIndex = 1035;
            this.lbEmployeeName.Text = "Thu ngân :";
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(188, 622);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(94, 28);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butExcel
            // 
            this.butExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.Location = new System.Drawing.Point(283, 622);
            this.butExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(84, 28);
            this.butExcel.TabIndex = 5;
            this.butExcel.Text = "Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // frmVP_BangKeHDTamUng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 689);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVP_BangKeHDTamUng";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVP_BangKeHDTamUng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKEmployeeOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKEmployeeRePaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePrint.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Object)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butExcel;
        private DevExpress.XtraEditors.LabelControl lbEmployeeName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.RadioButton rdNhanVien;
        private System.Windows.Forms.RadioButton rdTheoNgay;
        private DevExpress.XtraEditors.CheckedListBoxControl chkList_Employee;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkList_Object;
        private System.Windows.Forms.CheckBox chkCancel;
        private DevExpress.XtraEditors.DateEdit datePrint;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountReal;
        private DevExpress.XtraGrid.Columns.GridColumn col_Counts;
        private DevExpress.XtraGrid.Columns.GridColumn col_Status;
        private DevExpress.XtraGrid.Columns.GridColumn col_WorkingDateOrder;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCodeOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLKEmployeeOrder;
        private DevExpress.XtraGrid.Columns.GridColumn col_WorkingDateRePaid;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCodeRePaid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLKEmployeeRePaid;
    }
}