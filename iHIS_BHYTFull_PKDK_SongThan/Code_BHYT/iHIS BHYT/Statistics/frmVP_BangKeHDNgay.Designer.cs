namespace Ps.Clinic.Statistics
{
    partial class frmVP_BangKeHDNgay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_BangKeHDNgay));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResult_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PatientBirthyear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_NoInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ShiftWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_CashierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_Exemptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_EmployeeNameCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_CancelDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_BanksAccountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ReferenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ReasonCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalBHYTPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_BHYTPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalSurcharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PatientPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PostingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DifferentPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Refund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.timeFrom = new DevExpress.XtraEditors.TimeEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.chk_TimeofDate = new System.Windows.Forms.CheckBox();
            this.cbxReport = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkCancel = new DevExpress.XtraEditors.CheckEdit();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.controlDatetime = new UserControlDate.dllNgay();
            this.btnPrintGrid = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.col_TotalAmountReal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            this.pnSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCancel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Controls.Add(this.pnSearch);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(934, 577);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Bảng kê doanh thu ngày";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_Result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(351, 27);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(581, 548);
            this.panelControl1.TabIndex = 1056;
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(581, 548);
            this.gridControl_Result.TabIndex = 1055;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResult_PatientName,
            this.colResult_PatientCode,
            this.colResult_PostingDate,
            this.colResult_PatientGenderName,
            this.colResult_PatientBirthyear,
            this.colResult_ObjectName,
            this.colResult_NoInvoice,
            this.colResult_ShiftWork,
            this.colResult_EmployeeName,
            this.colResult_CashierName,
            this.colResult_TotalAmount,
            this.colResult_Exemptions,
            this.colResult_TotalReal,
            this.colResult_EmployeeNameCancel,
            this.colResult_CancelDate,
            this.colResult_BanksAccountCode,
            this.colResult_ReferenceCode,
            this.colResult_ObjectCode,
            this.colResult_ReasonCancel,
            this.colResult_TotalBHYTPay,
            this.colResult_BHYTPay,
            this.colResult_TotalSurcharge,
            this.colResult_PatientPay,
            this.colResult_PostingTime,
            this.col_DifferentPay,
            this.col_TamUng,
            this.col_Refund,
            this.col_TotalAmountReal});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmoutReal", null, "(Tổng tiền:{0:#,#.####})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalReal", null, "(Thực thu: {0:#,#.####})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DifferentPay", null, "(Đồng chi trả: {0:#,#.####})")});
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.FindFilterColumns = "PatientCode;PatientName";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            this.gridView_Result.DoubleClick += new System.EventHandler(this.gridView_Result_DoubleClick);
            // 
            // colResult_PatientName
            // 
            this.colResult_PatientName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PatientName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PatientName.Caption = "Họ và tên";
            this.colResult_PatientName.FieldName = "PatientName";
            this.colResult_PatientName.Name = "colResult_PatientName";
            this.colResult_PatientName.OptionsColumn.AllowEdit = false;
            this.colResult_PatientName.OptionsColumn.AllowFocus = false;
            this.colResult_PatientName.OptionsColumn.ReadOnly = true;
            this.colResult_PatientName.Visible = true;
            this.colResult_PatientName.VisibleIndex = 3;
            this.colResult_PatientName.Width = 154;
            // 
            // colResult_PatientCode
            // 
            this.colResult_PatientCode.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PatientCode.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PatientCode.Caption = "Mã BN";
            this.colResult_PatientCode.FieldName = "PatientCode";
            this.colResult_PatientCode.Name = "colResult_PatientCode";
            this.colResult_PatientCode.OptionsColumn.AllowEdit = false;
            this.colResult_PatientCode.OptionsColumn.AllowFocus = false;
            this.colResult_PatientCode.OptionsColumn.ReadOnly = true;
            this.colResult_PatientCode.Visible = true;
            this.colResult_PatientCode.VisibleIndex = 2;
            this.colResult_PatientCode.Width = 87;
            // 
            // colResult_PostingDate
            // 
            this.colResult_PostingDate.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PostingDate.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PostingDate.Caption = "Ngày";
            this.colResult_PostingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colResult_PostingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colResult_PostingDate.FieldName = "PostingDate";
            this.colResult_PostingDate.Name = "colResult_PostingDate";
            this.colResult_PostingDate.OptionsColumn.AllowEdit = false;
            this.colResult_PostingDate.OptionsColumn.AllowFocus = false;
            this.colResult_PostingDate.OptionsColumn.ReadOnly = true;
            this.colResult_PostingDate.Visible = true;
            this.colResult_PostingDate.VisibleIndex = 0;
            this.colResult_PostingDate.Width = 82;
            // 
            // colResult_PatientGenderName
            // 
            this.colResult_PatientGenderName.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_PatientGenderName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_PatientGenderName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PatientGenderName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PatientGenderName.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_PatientGenderName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_PatientGenderName.Caption = "Giới tính";
            this.colResult_PatientGenderName.FieldName = "PatientGenderName";
            this.colResult_PatientGenderName.Name = "colResult_PatientGenderName";
            this.colResult_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.colResult_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.colResult_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.colResult_PatientGenderName.Visible = true;
            this.colResult_PatientGenderName.VisibleIndex = 4;
            this.colResult_PatientGenderName.Width = 61;
            // 
            // colResult_PatientBirthyear
            // 
            this.colResult_PatientBirthyear.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_PatientBirthyear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_PatientBirthyear.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PatientBirthyear.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PatientBirthyear.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_PatientBirthyear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_PatientBirthyear.Caption = "Năm sinh";
            this.colResult_PatientBirthyear.FieldName = "PatientBirthyear";
            this.colResult_PatientBirthyear.Name = "colResult_PatientBirthyear";
            this.colResult_PatientBirthyear.OptionsColumn.AllowEdit = false;
            this.colResult_PatientBirthyear.OptionsColumn.AllowFocus = false;
            this.colResult_PatientBirthyear.OptionsColumn.ReadOnly = true;
            this.colResult_PatientBirthyear.Visible = true;
            this.colResult_PatientBirthyear.VisibleIndex = 5;
            this.colResult_PatientBirthyear.Width = 68;
            // 
            // colResult_ObjectName
            // 
            this.colResult_ObjectName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ObjectName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ObjectName.Caption = "Đối tượng";
            this.colResult_ObjectName.FieldName = "ObjectName";
            this.colResult_ObjectName.Name = "colResult_ObjectName";
            this.colResult_ObjectName.OptionsColumn.AllowEdit = false;
            this.colResult_ObjectName.OptionsColumn.AllowFocus = false;
            this.colResult_ObjectName.OptionsColumn.ReadOnly = true;
            this.colResult_ObjectName.Width = 79;
            // 
            // colResult_NoInvoice
            // 
            this.colResult_NoInvoice.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_NoInvoice.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_NoInvoice.Caption = "Số HĐ";
            this.colResult_NoInvoice.FieldName = "NoInvoice";
            this.colResult_NoInvoice.Name = "colResult_NoInvoice";
            this.colResult_NoInvoice.OptionsColumn.AllowEdit = false;
            this.colResult_NoInvoice.OptionsColumn.AllowFocus = false;
            this.colResult_NoInvoice.OptionsColumn.ReadOnly = true;
            this.colResult_NoInvoice.Width = 86;
            // 
            // colResult_ShiftWork
            // 
            this.colResult_ShiftWork.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_ShiftWork.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_ShiftWork.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ShiftWork.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ShiftWork.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_ShiftWork.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_ShiftWork.Caption = "Ca";
            this.colResult_ShiftWork.FieldName = "ShiftWork";
            this.colResult_ShiftWork.Name = "colResult_ShiftWork";
            this.colResult_ShiftWork.OptionsColumn.AllowEdit = false;
            this.colResult_ShiftWork.OptionsColumn.AllowFocus = false;
            this.colResult_ShiftWork.OptionsColumn.ReadOnly = true;
            this.colResult_ShiftWork.Visible = true;
            this.colResult_ShiftWork.VisibleIndex = 6;
            this.colResult_ShiftWork.Width = 58;
            // 
            // colResult_EmployeeName
            // 
            this.colResult_EmployeeName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_EmployeeName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_EmployeeName.Caption = "Người thu";
            this.colResult_EmployeeName.FieldName = "EmployeeName";
            this.colResult_EmployeeName.Name = "colResult_EmployeeName";
            this.colResult_EmployeeName.OptionsColumn.AllowEdit = false;
            this.colResult_EmployeeName.OptionsColumn.AllowFocus = false;
            this.colResult_EmployeeName.OptionsColumn.ReadOnly = true;
            this.colResult_EmployeeName.Visible = true;
            this.colResult_EmployeeName.VisibleIndex = 17;
            this.colResult_EmployeeName.Width = 133;
            // 
            // colResult_CashierName
            // 
            this.colResult_CashierName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_CashierName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_CashierName.Caption = "Thu ngân";
            this.colResult_CashierName.FieldName = "CashierName";
            this.colResult_CashierName.Name = "colResult_CashierName";
            this.colResult_CashierName.OptionsColumn.AllowEdit = false;
            this.colResult_CashierName.OptionsColumn.AllowFocus = false;
            this.colResult_CashierName.OptionsColumn.ReadOnly = true;
            this.colResult_CashierName.Visible = true;
            this.colResult_CashierName.VisibleIndex = 18;
            this.colResult_CashierName.Width = 142;
            // 
            // colResult_TotalAmount
            // 
            this.colResult_TotalAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_TotalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalAmount.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_TotalAmount.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_TotalAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_TotalAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalAmount.Caption = "Thành tiền";
            this.colResult_TotalAmount.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_TotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalAmount.FieldName = "TotalAmount";
            this.colResult_TotalAmount.Name = "colResult_TotalAmount";
            this.colResult_TotalAmount.OptionsColumn.AllowEdit = false;
            this.colResult_TotalAmount.OptionsColumn.AllowFocus = false;
            this.colResult_TotalAmount.OptionsColumn.ReadOnly = true;
            this.colResult_TotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "{0:#,#}")});
            this.colResult_TotalAmount.Visible = true;
            this.colResult_TotalAmount.VisibleIndex = 7;
            this.colResult_TotalAmount.Width = 92;
            // 
            // colResult_Exemptions
            // 
            this.colResult_Exemptions.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_Exemptions.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_Exemptions.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_Exemptions.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_Exemptions.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_Exemptions.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_Exemptions.Caption = "Miễn giảm";
            this.colResult_Exemptions.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_Exemptions.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_Exemptions.FieldName = "Exemptions";
            this.colResult_Exemptions.Name = "colResult_Exemptions";
            this.colResult_Exemptions.OptionsColumn.AllowEdit = false;
            this.colResult_Exemptions.OptionsColumn.AllowFocus = false;
            this.colResult_Exemptions.OptionsColumn.ReadOnly = true;
            this.colResult_Exemptions.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Exemptions", "{0:#,#}")});
            this.colResult_Exemptions.Visible = true;
            this.colResult_Exemptions.VisibleIndex = 13;
            this.colResult_Exemptions.Width = 73;
            // 
            // colResult_TotalReal
            // 
            this.colResult_TotalReal.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_TotalReal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalReal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_TotalReal.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_TotalReal.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_TotalReal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalReal.Caption = "Thực thu";
            this.colResult_TotalReal.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_TotalReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalReal.FieldName = "TotalReal";
            this.colResult_TotalReal.Name = "colResult_TotalReal";
            this.colResult_TotalReal.OptionsColumn.AllowEdit = false;
            this.colResult_TotalReal.OptionsColumn.AllowFocus = false;
            this.colResult_TotalReal.OptionsColumn.ReadOnly = true;
            this.colResult_TotalReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalReal", "{0:#,#}")});
            this.colResult_TotalReal.Visible = true;
            this.colResult_TotalReal.VisibleIndex = 16;
            this.colResult_TotalReal.Width = 96;
            // 
            // colResult_EmployeeNameCancel
            // 
            this.colResult_EmployeeNameCancel.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_EmployeeNameCancel.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_EmployeeNameCancel.Caption = "Người hủy";
            this.colResult_EmployeeNameCancel.FieldName = "EmployeeNameCancel";
            this.colResult_EmployeeNameCancel.Name = "colResult_EmployeeNameCancel";
            this.colResult_EmployeeNameCancel.OptionsColumn.AllowEdit = false;
            this.colResult_EmployeeNameCancel.OptionsColumn.AllowFocus = false;
            this.colResult_EmployeeNameCancel.OptionsColumn.ReadOnly = true;
            this.colResult_EmployeeNameCancel.Visible = true;
            this.colResult_EmployeeNameCancel.VisibleIndex = 19;
            this.colResult_EmployeeNameCancel.Width = 102;
            // 
            // colResult_CancelDate
            // 
            this.colResult_CancelDate.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_CancelDate.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_CancelDate.Caption = "Ngày hủy";
            this.colResult_CancelDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colResult_CancelDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colResult_CancelDate.FieldName = "CancelDate";
            this.colResult_CancelDate.Name = "colResult_CancelDate";
            this.colResult_CancelDate.OptionsColumn.AllowEdit = false;
            this.colResult_CancelDate.OptionsColumn.AllowFocus = false;
            this.colResult_CancelDate.OptionsColumn.ReadOnly = true;
            this.colResult_CancelDate.Visible = true;
            this.colResult_CancelDate.VisibleIndex = 20;
            this.colResult_CancelDate.Width = 86;
            // 
            // colResult_BanksAccountCode
            // 
            this.colResult_BanksAccountCode.Caption = "BanksAccountCode";
            this.colResult_BanksAccountCode.FieldName = "BanksAccountCode";
            this.colResult_BanksAccountCode.Name = "colResult_BanksAccountCode";
            // 
            // colResult_ReferenceCode
            // 
            this.colResult_ReferenceCode.Caption = "ReferenceCode";
            this.colResult_ReferenceCode.FieldName = "ReferenceCode";
            this.colResult_ReferenceCode.Name = "colResult_ReferenceCode";
            // 
            // colResult_ObjectCode
            // 
            this.colResult_ObjectCode.Caption = "ObjectCode";
            this.colResult_ObjectCode.FieldName = "ObjectCode";
            this.colResult_ObjectCode.Name = "colResult_ObjectCode";
            // 
            // colResult_ReasonCancel
            // 
            this.colResult_ReasonCancel.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ReasonCancel.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ReasonCancel.Caption = "Lý do hủy";
            this.colResult_ReasonCancel.FieldName = "ReasonCancel";
            this.colResult_ReasonCancel.Name = "colResult_ReasonCancel";
            this.colResult_ReasonCancel.OptionsColumn.AllowEdit = false;
            this.colResult_ReasonCancel.OptionsColumn.AllowFocus = false;
            this.colResult_ReasonCancel.OptionsColumn.ReadOnly = true;
            this.colResult_ReasonCancel.Visible = true;
            this.colResult_ReasonCancel.VisibleIndex = 21;
            this.colResult_ReasonCancel.Width = 139;
            // 
            // colResult_TotalBHYTPay
            // 
            this.colResult_TotalBHYTPay.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_TotalBHYTPay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalBHYTPay.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_TotalBHYTPay.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_TotalBHYTPay.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_TotalBHYTPay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalBHYTPay.Caption = "Tổng BHYT";
            this.colResult_TotalBHYTPay.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_TotalBHYTPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalBHYTPay.FieldName = "TotalBHYTPay";
            this.colResult_TotalBHYTPay.Name = "colResult_TotalBHYTPay";
            this.colResult_TotalBHYTPay.OptionsColumn.AllowEdit = false;
            this.colResult_TotalBHYTPay.OptionsColumn.AllowFocus = false;
            this.colResult_TotalBHYTPay.OptionsColumn.ReadOnly = true;
            this.colResult_TotalBHYTPay.Visible = true;
            this.colResult_TotalBHYTPay.VisibleIndex = 8;
            this.colResult_TotalBHYTPay.Width = 110;
            // 
            // colResult_BHYTPay
            // 
            this.colResult_BHYTPay.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_BHYTPay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_BHYTPay.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_BHYTPay.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_BHYTPay.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_BHYTPay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_BHYTPay.Caption = "BHYT T.Toán";
            this.colResult_BHYTPay.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_BHYTPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_BHYTPay.FieldName = "BHYTPay";
            this.colResult_BHYTPay.Name = "colResult_BHYTPay";
            this.colResult_BHYTPay.OptionsColumn.AllowEdit = false;
            this.colResult_BHYTPay.OptionsColumn.AllowFocus = false;
            this.colResult_BHYTPay.OptionsColumn.ReadOnly = true;
            this.colResult_BHYTPay.Visible = true;
            this.colResult_BHYTPay.VisibleIndex = 9;
            this.colResult_BHYTPay.Width = 116;
            // 
            // colResult_TotalSurcharge
            // 
            this.colResult_TotalSurcharge.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_TotalSurcharge.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalSurcharge.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_TotalSurcharge.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_TotalSurcharge.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_TotalSurcharge.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalSurcharge.Caption = "Phụ thu";
            this.colResult_TotalSurcharge.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_TotalSurcharge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalSurcharge.FieldName = "TotalSurcharge";
            this.colResult_TotalSurcharge.Name = "colResult_TotalSurcharge";
            this.colResult_TotalSurcharge.OptionsColumn.AllowEdit = false;
            this.colResult_TotalSurcharge.OptionsColumn.AllowFocus = false;
            this.colResult_TotalSurcharge.OptionsColumn.ReadOnly = true;
            this.colResult_TotalSurcharge.Visible = true;
            this.colResult_TotalSurcharge.VisibleIndex = 11;
            this.colResult_TotalSurcharge.Width = 107;
            // 
            // colResult_PatientPay
            // 
            this.colResult_PatientPay.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_PatientPay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_PatientPay.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PatientPay.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PatientPay.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_PatientPay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_PatientPay.Caption = "Thu Phí";
            this.colResult_PatientPay.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_PatientPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_PatientPay.FieldName = "PatientPay";
            this.colResult_PatientPay.Name = "colResult_PatientPay";
            this.colResult_PatientPay.OptionsColumn.AllowEdit = false;
            this.colResult_PatientPay.OptionsColumn.AllowFocus = false;
            this.colResult_PatientPay.OptionsColumn.ReadOnly = true;
            this.colResult_PatientPay.Visible = true;
            this.colResult_PatientPay.VisibleIndex = 10;
            this.colResult_PatientPay.Width = 96;
            // 
            // colResult_PostingTime
            // 
            this.colResult_PostingTime.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_PostingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_PostingTime.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PostingTime.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PostingTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_PostingTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult_PostingTime.Caption = "Giờ";
            this.colResult_PostingTime.FieldName = "PostingTime";
            this.colResult_PostingTime.Name = "colResult_PostingTime";
            this.colResult_PostingTime.Visible = true;
            this.colResult_PostingTime.VisibleIndex = 1;
            this.colResult_PostingTime.Width = 51;
            // 
            // col_DifferentPay
            // 
            this.col_DifferentPay.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_DifferentPay.AppearanceHeader.Options.UseForeColor = true;
            this.col_DifferentPay.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DifferentPay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DifferentPay.Caption = "Đồng chi trả";
            this.col_DifferentPay.DisplayFormat.FormatString = "{0:#,#}";
            this.col_DifferentPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_DifferentPay.FieldName = "DifferentPay";
            this.col_DifferentPay.Name = "col_DifferentPay";
            this.col_DifferentPay.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DifferentPay", "{0:#,#}")});
            this.col_DifferentPay.Visible = true;
            this.col_DifferentPay.VisibleIndex = 12;
            this.col_DifferentPay.Width = 99;
            // 
            // col_TamUng
            // 
            this.col_TamUng.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_TamUng.AppearanceHeader.Options.UseForeColor = true;
            this.col_TamUng.Caption = "Tạm ứng";
            this.col_TamUng.DisplayFormat.FormatString = "{0:#,#}";
            this.col_TamUng.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TamUng.FieldName = "TotalPatientPay";
            this.col_TamUng.Name = "col_TamUng";
            this.col_TamUng.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPatientPay", "{0:#,#}")});
            this.col_TamUng.Visible = true;
            this.col_TamUng.VisibleIndex = 14;
            // 
            // col_Refund
            // 
            this.col_Refund.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_Refund.AppearanceHeader.Options.UseForeColor = true;
            this.col_Refund.Caption = "Tiền hoàn";
            this.col_Refund.DisplayFormat.FormatString = "{0:#,#}";
            this.col_Refund.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Refund.FieldName = "Refund";
            this.col_Refund.Name = "col_Refund";
            this.col_Refund.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Refund", "{0:#,#}")});
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.timeFrom);
            this.pnSearch.Controls.Add(this.timeStart);
            this.pnSearch.Controls.Add(this.chk_TimeofDate);
            this.pnSearch.Controls.Add(this.cbxReport);
            this.pnSearch.Controls.Add(this.labelControl2);
            this.pnSearch.Controls.Add(this.chkCancel);
            this.pnSearch.Controls.Add(this.btnExcel);
            this.pnSearch.Controls.Add(this.controlDatetime);
            this.pnSearch.Controls.Add(this.btnPrintGrid);
            this.pnSearch.Controls.Add(this.butOK);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSearch.Location = new System.Drawing.Point(2, 27);
            this.pnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(349, 548);
            this.pnSearch.TabIndex = 1053;
            // 
            // timeFrom
            // 
            this.timeFrom.EditValue = new System.DateTime(2017, 7, 17, 0, 0, 0, 0);
            this.timeFrom.Location = new System.Drawing.Point(233, 114);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeFrom.Size = new System.Drawing.Size(110, 22);
            this.timeFrom.TabIndex = 1059;
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2017, 7, 17, 0, 0, 0, 0);
            this.timeStart.Location = new System.Drawing.Point(77, 114);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeStart.Size = new System.Drawing.Size(112, 22);
            this.timeStart.TabIndex = 1059;
            // 
            // chk_TimeofDate
            // 
            this.chk_TimeofDate.AutoSize = true;
            this.chk_TimeofDate.Location = new System.Drawing.Point(10, 91);
            this.chk_TimeofDate.Name = "chk_TimeofDate";
            this.chk_TimeofDate.Size = new System.Drawing.Size(159, 21);
            this.chk_TimeofDate.TabIndex = 1058;
            this.chk_TimeofDate.Text = "Giờ mặc định theo ca";
            this.chk_TimeofDate.UseVisualStyleBackColor = true;
            this.chk_TimeofDate.CheckedChanged += new System.EventHandler(this.chk_TimeofDate_CheckedChanged);
            // 
            // cbxReport
            // 
            this.cbxReport.FormattingEnabled = true;
            this.cbxReport.Location = new System.Drawing.Point(65, 164);
            this.cbxReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxReport.Name = "cbxReport";
            this.cbxReport.Size = new System.Drawing.Size(275, 24);
            this.cbxReport.TabIndex = 1057;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 143);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 17);
            this.labelControl2.TabIndex = 1056;
            this.labelControl2.Text = "Tiêu đề báo cáo";
            // 
            // chkCancel
            // 
            this.chkCancel.Location = new System.Drawing.Point(67, 192);
            this.chkCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCancel.Name = "chkCancel";
            this.chkCancel.Properties.Caption = "Hóa đơn hủy";
            this.chkCancel.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chkCancel.Size = new System.Drawing.Size(122, 21);
            this.chkCancel.TabIndex = 1055;
            this.chkCancel.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(162, 222);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(89, 32);
            this.btnExcel.TabIndex = 1054;
            this.btnExcel.Text = "File Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // controlDatetime
            // 
            this.controlDatetime.BackColor = System.Drawing.Color.Transparent;
            this.controlDatetime.Location = new System.Drawing.Point(3, 4);
            this.controlDatetime.Margin = new System.Windows.Forms.Padding(5);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(342, 90);
            this.controlDatetime.TabIndex = 1052;
            // 
            // btnPrintGrid
            // 
            this.btnPrintGrid.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPrintGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGrid.Image")));
            this.btnPrintGrid.Location = new System.Drawing.Point(250, 222);
            this.btnPrintGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintGrid.Name = "btnPrintGrid";
            this.btnPrintGrid.Size = new System.Drawing.Size(90, 32);
            this.btnPrintGrid.TabIndex = 4;
            this.btnPrintGrid.Text = "In Grid";
            this.btnPrintGrid.Click += new System.EventHandler(this.btnPrintGrid_Click);
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(65, 222);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(97, 32);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // col_TotalAmountReal
            // 
            this.col_TotalAmountReal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_TotalAmountReal.AppearanceHeader.Options.UseForeColor = true;
            this.col_TotalAmountReal.Caption = "Tổng tiền";
            this.col_TotalAmountReal.DisplayFormat.FormatString = "{0:#,#}";
            this.col_TotalAmountReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TotalAmountReal.FieldName = "TotalAmoutReal";
            this.col_TotalAmountReal.Name = "col_TotalAmountReal";
            this.col_TotalAmountReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmoutReal", "{0:0.##}")});
            this.col_TotalAmountReal.Visible = true;
            this.col_TotalAmountReal.VisibleIndex = 15;
            this.col_TotalAmountReal.Width = 99;
            // 
            // frmVP_BangKeHDNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVP_BangKeHDNgay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVP_BangKeHDNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCancel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private UserControlDate.dllNgay controlDatetime;
        private System.Windows.Forms.Panel pnSearch;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PostingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PatientBirthyear;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_NoInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ShiftWork;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_CashierName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalReal;
        private DevExpress.XtraEditors.CheckEdit chkCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbxReport;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_EmployeeNameCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_CancelDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_BanksAccountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ReferenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ReasonCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_Exemptions;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalBHYTPay;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_BHYTPay;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalSurcharge;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PatientPay;
        private DevExpress.XtraEditors.SimpleButton btnPrintGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PostingTime;
        private DevExpress.XtraGrid.Columns.GridColumn col_DifferentPay;
        private DevExpress.XtraGrid.Columns.GridColumn col_TamUng;
        private DevExpress.XtraGrid.Columns.GridColumn col_Refund;
        private DevExpress.XtraEditors.TimeEdit timeFrom;
        private DevExpress.XtraEditors.TimeEdit timeStart;
        private System.Windows.Forms.CheckBox chk_TimeofDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_TotalAmountReal;
    }
}