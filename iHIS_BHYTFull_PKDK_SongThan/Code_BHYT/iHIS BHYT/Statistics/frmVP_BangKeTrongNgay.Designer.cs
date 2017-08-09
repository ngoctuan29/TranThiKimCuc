namespace Ps.Clinic.Statistics
{
    partial class frmVP_BangKeTrongNgay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_BangKeTrongNgay));
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
            this.colResult_TotalSurcharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_Exemptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_EmployeeNameCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_CancelDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_BanksAccountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ReferenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ReasonCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_PatientReceiveClinic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.chkLoai = new DevExpress.XtraEditors.CheckEdit();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.controlDatetime = new UserControlDate.dllNgay();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.colResult_PostingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            this.pnSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoai.Properties)).BeginInit();
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
            this.colResult_PostingTime,
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
            this.colResult_TotalSurcharge,
            this.colResult_Exemptions,
            this.colResult_TotalAmount,
            this.colResult_TotalReal,
            this.colResult_EmployeeNameCancel,
            this.colResult_CancelDate,
            this.colResult_BanksAccountCode,
            this.colResult_ReferenceCode,
            this.colResult_ObjectCode,
            this.colResult_ReasonCancel,
            this.col_Result_PatientReceiveClinic});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServicePrice", null, "{0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.FindFilterColumns = "PatientCode;PatientName;PatientReceiveClinic";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            this.gridView_Result.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_Result_RowStyle);
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
            this.colResult_PatientName.Width = 198;
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
            this.colResult_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PatientCode", "{0:#,#}")});
            this.colResult_PatientCode.Visible = true;
            this.colResult_PatientCode.VisibleIndex = 2;
            this.colResult_PatientCode.Width = 97;
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
            this.colResult_PostingDate.Width = 94;
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
            this.colResult_ObjectName.Visible = true;
            this.colResult_ObjectName.VisibleIndex = 6;
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
            this.colResult_ShiftWork.VisibleIndex = 7;
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
            this.colResult_EmployeeName.VisibleIndex = 12;
            this.colResult_EmployeeName.Width = 119;
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
            this.colResult_CashierName.VisibleIndex = 13;
            this.colResult_CashierName.Width = 119;
            // 
            // colResult_TotalSurcharge
            // 
            this.colResult_TotalSurcharge.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_TotalSurcharge.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_TotalSurcharge.Caption = "Phụ thu";
            this.colResult_TotalSurcharge.DisplayFormat.FormatString = "#,#";
            this.colResult_TotalSurcharge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalSurcharge.FieldName = "TotalSurcharge";
            this.colResult_TotalSurcharge.Name = "colResult_TotalSurcharge";
            this.colResult_TotalSurcharge.OptionsColumn.AllowEdit = false;
            this.colResult_TotalSurcharge.OptionsColumn.AllowFocus = false;
            this.colResult_TotalSurcharge.OptionsColumn.ReadOnly = true;
            this.colResult_TotalSurcharge.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalSurcharge", "{0:#,#}")});
            this.colResult_TotalSurcharge.Visible = true;
            this.colResult_TotalSurcharge.VisibleIndex = 10;
            this.colResult_TotalSurcharge.Width = 85;
            // 
            // colResult_Exemptions
            // 
            this.colResult_Exemptions.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_Exemptions.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_Exemptions.Caption = "Miễn giảm";
            this.colResult_Exemptions.DisplayFormat.FormatString = "#,#";
            this.colResult_Exemptions.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_Exemptions.FieldName = "Exemptions";
            this.colResult_Exemptions.Name = "colResult_Exemptions";
            this.colResult_Exemptions.OptionsColumn.AllowEdit = false;
            this.colResult_Exemptions.OptionsColumn.AllowFocus = false;
            this.colResult_Exemptions.OptionsColumn.ReadOnly = true;
            this.colResult_Exemptions.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Exemptions", "{0:#,#}")});
            this.colResult_Exemptions.Visible = true;
            this.colResult_Exemptions.VisibleIndex = 9;
            this.colResult_Exemptions.Width = 101;
            // 
            // colResult_TotalAmount
            // 
            this.colResult_TotalAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_TotalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_TotalAmount.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_TotalAmount.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_TotalAmount.Caption = "Thành tiền";
            this.colResult_TotalAmount.DisplayFormat.FormatString = "#,#";
            this.colResult_TotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalAmount.FieldName = "TotalAmount";
            this.colResult_TotalAmount.Name = "colResult_TotalAmount";
            this.colResult_TotalAmount.OptionsColumn.AllowEdit = false;
            this.colResult_TotalAmount.OptionsColumn.AllowFocus = false;
            this.colResult_TotalAmount.OptionsColumn.ReadOnly = true;
            this.colResult_TotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "{0:#,#}")});
            this.colResult_TotalAmount.Visible = true;
            this.colResult_TotalAmount.VisibleIndex = 8;
            this.colResult_TotalAmount.Width = 98;
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
            this.colResult_TotalReal.DisplayFormat.FormatString = "#,#";
            this.colResult_TotalReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_TotalReal.FieldName = "TotalReal";
            this.colResult_TotalReal.Name = "colResult_TotalReal";
            this.colResult_TotalReal.OptionsColumn.AllowEdit = false;
            this.colResult_TotalReal.OptionsColumn.AllowFocus = false;
            this.colResult_TotalReal.OptionsColumn.ReadOnly = true;
            this.colResult_TotalReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalReal", "{0:#,#}")});
            this.colResult_TotalReal.Visible = true;
            this.colResult_TotalReal.VisibleIndex = 11;
            this.colResult_TotalReal.Width = 97;
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
            this.colResult_EmployeeNameCancel.Width = 118;
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
            this.colResult_CancelDate.Width = 103;
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
            this.colResult_ReasonCancel.Width = 139;
            // 
            // col_Result_PatientReceiveClinic
            // 
            this.col_Result_PatientReceiveClinic.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_Result_PatientReceiveClinic.AppearanceHeader.Options.UseForeColor = true;
            this.col_Result_PatientReceiveClinic.Caption = "Số vào hồ sơ";
            this.col_Result_PatientReceiveClinic.FieldName = "PatientReceiveClinic";
            this.col_Result_PatientReceiveClinic.Name = "col_Result_PatientReceiveClinic";
            this.col_Result_PatientReceiveClinic.OptionsColumn.AllowEdit = false;
            this.col_Result_PatientReceiveClinic.OptionsColumn.AllowFocus = false;
            this.col_Result_PatientReceiveClinic.OptionsColumn.ReadOnly = true;
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.chkLoai);
            this.pnSearch.Controls.Add(this.btnExcel);
            this.pnSearch.Controls.Add(this.controlDatetime);
            this.pnSearch.Controls.Add(this.butOK);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSearch.Location = new System.Drawing.Point(2, 27);
            this.pnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(349, 548);
            this.pnSearch.TabIndex = 1053;
            // 
            // chkLoai
            // 
            this.chkLoai.Location = new System.Drawing.Point(68, 101);
            this.chkLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkLoai.Name = "chkLoai";
            this.chkLoai.Properties.Caption = "Danh sách chưa thu";
            this.chkLoai.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chkLoai.Size = new System.Drawing.Size(143, 20);
            this.chkLoai.TabIndex = 1056;
            this.chkLoai.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(174, 132);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(104, 32);
            this.btnExcel.TabIndex = 1054;
            this.btnExcel.Text = "File Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // controlDatetime
            // 
            this.controlDatetime.BackColor = System.Drawing.Color.Transparent;
            this.controlDatetime.Location = new System.Drawing.Point(3, 4);
            this.controlDatetime.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(342, 90);
            this.controlDatetime.TabIndex = 1052;
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(63, 132);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(110, 32);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // colResult_PostingTime
            // 
            this.colResult_PostingTime.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_PostingTime.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_PostingTime.Caption = "Giờ";
            this.colResult_PostingTime.FieldName = "PostingTime";
            this.colResult_PostingTime.Name = "colResult_PostingTime";
            this.colResult_PostingTime.Visible = true;
            this.colResult_PostingTime.VisibleIndex = 1;
            // 
            // frmVP_BangKeTrongNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVP_BangKeTrongNgay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            this.pnSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLoai.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_EmployeeNameCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_CancelDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_BanksAccountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ReferenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ReasonCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalSurcharge;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_Exemptions;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_PatientReceiveClinic;
        private DevExpress.XtraEditors.CheckEdit chkLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PostingTime;
    }
}