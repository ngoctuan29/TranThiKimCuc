namespace Ps.Clinic.Statistics
{
    partial class frmVP_BangKeHDChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_BangKeHDChiTiet));
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
            this.colResult_CashierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ServiceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_DifferentPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_BanksAccountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_DepartmentNameOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_BHYTPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_DisparityAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PatientPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_PostingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServicePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colResult_CashierName,
            this.colResult_TotalAmount,
            this.colResult_ServiceAmount,
            this.colResult_DifferentPay,
            this.colResult_ServiceCode,
            this.colResult_ServiceName,
            this.colResult_BanksAccountCode,
            this.colResult_ServiceGroupName,
            this.colResult_ServiceCategoryName,
            this.colResult_DepartmentNameOrder,
            this.colResult_UnitOfMeasureName,
            this.colResult_BHYTPay,
            this.colResult_DisparityAmount,
            this.colResult_PatientPay,
            this.colResult_PostingTime,
            this.col_ServicePrice,
            this.col_Quantity});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", null, "(Tổng tiền: {0:#,#.####})"),
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
            this.colResult_PatientName.Width = 138;
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
            this.colResult_PostingDate.VisibleIndex = 1;
            this.colResult_PostingDate.Width = 76;
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
            this.colResult_ObjectName.VisibleIndex = 7;
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
            this.colResult_CashierName.VisibleIndex = 20;
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
            this.colResult_TotalAmount.Caption = "Tổng tiền";
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
            this.colResult_TotalAmount.VisibleIndex = 19;
            this.colResult_TotalAmount.Width = 92;
            // 
            // colResult_ServiceAmount
            // 
            this.colResult_ServiceAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_ServiceAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_ServiceAmount.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ServiceAmount.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ServiceAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_ServiceAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_ServiceAmount.Caption = "Thu Phí";
            this.colResult_ServiceAmount.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_ServiceAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_ServiceAmount.FieldName = "ServiceAmount";
            this.colResult_ServiceAmount.Name = "colResult_ServiceAmount";
            this.colResult_ServiceAmount.OptionsColumn.AllowEdit = false;
            this.colResult_ServiceAmount.OptionsColumn.AllowFocus = false;
            this.colResult_ServiceAmount.OptionsColumn.ReadOnly = true;
            this.colResult_ServiceAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServiceAmount", "{0:#,#}")});
            this.colResult_ServiceAmount.Visible = true;
            this.colResult_ServiceAmount.VisibleIndex = 16;
            this.colResult_ServiceAmount.Width = 107;
            // 
            // colResult_DifferentPay
            // 
            this.colResult_DifferentPay.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_DifferentPay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_DifferentPay.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_DifferentPay.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_DifferentPay.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_DifferentPay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_DifferentPay.Caption = "Đồng chi trả";
            this.colResult_DifferentPay.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_DifferentPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_DifferentPay.FieldName = "DifferentPay";
            this.colResult_DifferentPay.Name = "colResult_DifferentPay";
            this.colResult_DifferentPay.OptionsColumn.AllowEdit = false;
            this.colResult_DifferentPay.OptionsColumn.AllowFocus = false;
            this.colResult_DifferentPay.OptionsColumn.ReadOnly = true;
            this.colResult_DifferentPay.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DifferentPay", "{0:#,#}")});
            this.colResult_DifferentPay.Visible = true;
            this.colResult_DifferentPay.VisibleIndex = 18;
            this.colResult_DifferentPay.Width = 108;
            // 
            // colResult_ServiceCode
            // 
            this.colResult_ServiceCode.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ServiceCode.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ServiceCode.Caption = "Mã dịch vụ";
            this.colResult_ServiceCode.FieldName = "ServiceCode";
            this.colResult_ServiceCode.Name = "colResult_ServiceCode";
            this.colResult_ServiceCode.OptionsColumn.AllowEdit = false;
            this.colResult_ServiceCode.OptionsColumn.AllowFocus = false;
            this.colResult_ServiceCode.OptionsColumn.ReadOnly = true;
            this.colResult_ServiceCode.Visible = true;
            this.colResult_ServiceCode.VisibleIndex = 10;
            this.colResult_ServiceCode.Width = 68;
            // 
            // colResult_ServiceName
            // 
            this.colResult_ServiceName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ServiceName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ServiceName.Caption = "Dịch vụ/ Thuốc /Vật tư";
            this.colResult_ServiceName.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colResult_ServiceName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colResult_ServiceName.FieldName = "ServiceName";
            this.colResult_ServiceName.Name = "colResult_ServiceName";
            this.colResult_ServiceName.OptionsColumn.AllowEdit = false;
            this.colResult_ServiceName.OptionsColumn.AllowFocus = false;
            this.colResult_ServiceName.OptionsColumn.ReadOnly = true;
            this.colResult_ServiceName.Visible = true;
            this.colResult_ServiceName.VisibleIndex = 11;
            this.colResult_ServiceName.Width = 216;
            // 
            // colResult_BanksAccountCode
            // 
            this.colResult_BanksAccountCode.Caption = "BanksAccountCode";
            this.colResult_BanksAccountCode.FieldName = "BanksAccountCode";
            this.colResult_BanksAccountCode.Name = "colResult_BanksAccountCode";
            // 
            // colResult_ServiceGroupName
            // 
            this.colResult_ServiceGroupName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ServiceGroupName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ServiceGroupName.Caption = "Nhóm";
            this.colResult_ServiceGroupName.FieldName = "ServiceGroupName";
            this.colResult_ServiceGroupName.Name = "colResult_ServiceGroupName";
            this.colResult_ServiceGroupName.Visible = true;
            this.colResult_ServiceGroupName.VisibleIndex = 9;
            // 
            // colResult_ServiceCategoryName
            // 
            this.colResult_ServiceCategoryName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_ServiceCategoryName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_ServiceCategoryName.Caption = "Loại";
            this.colResult_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.colResult_ServiceCategoryName.Name = "colResult_ServiceCategoryName";
            this.colResult_ServiceCategoryName.Visible = true;
            this.colResult_ServiceCategoryName.VisibleIndex = 8;
            // 
            // colResult_DepartmentNameOrder
            // 
            this.colResult_DepartmentNameOrder.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_DepartmentNameOrder.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_DepartmentNameOrder.Caption = "Người chỉ định";
            this.colResult_DepartmentNameOrder.FieldName = "DepartmentNameOrder";
            this.colResult_DepartmentNameOrder.Name = "colResult_DepartmentNameOrder";
            this.colResult_DepartmentNameOrder.OptionsColumn.AllowEdit = false;
            this.colResult_DepartmentNameOrder.OptionsColumn.AllowFocus = false;
            this.colResult_DepartmentNameOrder.OptionsColumn.ReadOnly = true;
            this.colResult_DepartmentNameOrder.Visible = true;
            this.colResult_DepartmentNameOrder.VisibleIndex = 0;
            this.colResult_DepartmentNameOrder.Width = 139;
            // 
            // colResult_UnitOfMeasureName
            // 
            this.colResult_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_UnitOfMeasureName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_UnitOfMeasureName.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_UnitOfMeasureName.Caption = "Đơn vị tính";
            this.colResult_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.colResult_UnitOfMeasureName.Name = "colResult_UnitOfMeasureName";
            this.colResult_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.colResult_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.colResult_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.colResult_UnitOfMeasureName.Visible = true;
            this.colResult_UnitOfMeasureName.VisibleIndex = 12;
            this.colResult_UnitOfMeasureName.Width = 60;
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
            this.colResult_BHYTPay.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BHYTPay", "{0:#,#}")});
            this.colResult_BHYTPay.Visible = true;
            this.colResult_BHYTPay.VisibleIndex = 15;
            this.colResult_BHYTPay.Width = 116;
            // 
            // colResult_DisparityAmount
            // 
            this.colResult_DisparityAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colResult_DisparityAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_DisparityAmount.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colResult_DisparityAmount.AppearanceHeader.Options.UseForeColor = true;
            this.colResult_DisparityAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult_DisparityAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colResult_DisparityAmount.Caption = "Phụ thu";
            this.colResult_DisparityAmount.DisplayFormat.FormatString = "{0:#,#}";
            this.colResult_DisparityAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResult_DisparityAmount.FieldName = "DisparityAmount";
            this.colResult_DisparityAmount.Name = "colResult_DisparityAmount";
            this.colResult_DisparityAmount.OptionsColumn.AllowEdit = false;
            this.colResult_DisparityAmount.OptionsColumn.AllowFocus = false;
            this.colResult_DisparityAmount.OptionsColumn.ReadOnly = true;
            this.colResult_DisparityAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DisparityAmount", "{0:#,#}")});
            this.colResult_DisparityAmount.Visible = true;
            this.colResult_DisparityAmount.VisibleIndex = 17;
            this.colResult_DisparityAmount.Width = 107;
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
            this.colResult_PostingTime.Width = 51;
            // 
            // col_ServicePrice
            // 
            this.col_ServicePrice.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_ServicePrice.AppearanceHeader.Options.UseForeColor = true;
            this.col_ServicePrice.Caption = "Giá";
            this.col_ServicePrice.DisplayFormat.FormatString = "{0:#,#}";
            this.col_ServicePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ServicePrice.FieldName = "ServicePrice";
            this.col_ServicePrice.Name = "col_ServicePrice";
            this.col_ServicePrice.Visible = true;
            this.col_ServicePrice.VisibleIndex = 14;
            // 
            // col_Quantity
            // 
            this.col_Quantity.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_Quantity.AppearanceHeader.Options.UseForeColor = true;
            this.col_Quantity.Caption = "Số lượng";
            this.col_Quantity.DisplayFormat.FormatString = "{0:#,#}";
            this.col_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Quantity.FieldName = "Quantity";
            this.col_Quantity.Name = "col_Quantity";
            this.col_Quantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:#,#}")});
            this.col_Quantity.Visible = true;
            this.col_Quantity.VisibleIndex = 13;
            this.col_Quantity.Width = 52;
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
            this.timeFrom.Location = new System.Drawing.Point(233, 125);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeFrom.Size = new System.Drawing.Size(110, 22);
            this.timeFrom.TabIndex = 1062;
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2017, 7, 17, 0, 0, 0, 0);
            this.timeStart.Location = new System.Drawing.Point(72, 125);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeStart.Size = new System.Drawing.Size(117, 22);
            this.timeStart.TabIndex = 1061;
            // 
            // chk_TimeofDate
            // 
            this.chk_TimeofDate.AutoSize = true;
            this.chk_TimeofDate.Location = new System.Drawing.Point(10, 102);
            this.chk_TimeofDate.Name = "chk_TimeofDate";
            this.chk_TimeofDate.Size = new System.Drawing.Size(159, 21);
            this.chk_TimeofDate.TabIndex = 1060;
            this.chk_TimeofDate.Text = "Giờ mặc định theo ca";
            this.chk_TimeofDate.UseVisualStyleBackColor = true;
            this.chk_TimeofDate.CheckedChanged += new System.EventHandler(this.chk_TimeofDate_CheckedChanged);
            // 
            // cbxReport
            // 
            this.cbxReport.FormattingEnabled = true;
            this.cbxReport.Location = new System.Drawing.Point(72, 177);
            this.cbxReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxReport.Name = "cbxReport";
            this.cbxReport.Size = new System.Drawing.Size(275, 24);
            this.cbxReport.TabIndex = 1057;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 156);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 17);
            this.labelControl2.TabIndex = 1056;
            this.labelControl2.Text = "Tiêu đề báo cáo";
            // 
            // chkCancel
            // 
            this.chkCancel.Location = new System.Drawing.Point(74, 205);
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
            this.btnExcel.Location = new System.Drawing.Point(61, 236);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(89, 32);
            this.btnExcel.TabIndex = 1054;
            this.btnExcel.Text = "File Excel";
            this.btnExcel.Visible = false;
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
            this.btnPrintGrid.Location = new System.Drawing.Point(257, 235);
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
            this.butOK.Location = new System.Drawing.Point(157, 235);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(97, 32);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // frmVP_BangKeHDChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVP_BangKeHDChiTiet";
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
        private DevExpress.XtraGrid.Columns.GridColumn colResult_CashierName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_DifferentPay;
        private DevExpress.XtraEditors.CheckEdit chkCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbxReport;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_BanksAccountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_DepartmentNameOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_BHYTPay;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_DisparityAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PatientPay;
        private DevExpress.XtraEditors.SimpleButton btnPrintGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_PostingTime;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServicePrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_Quantity;
        private DevExpress.XtraEditors.TimeEdit timeFrom;
        private DevExpress.XtraEditors.TimeEdit timeStart;
        private System.Windows.Forms.CheckBox chk_TimeofDate;
    }
}