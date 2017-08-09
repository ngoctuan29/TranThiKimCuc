namespace Ps.Clinic.ViewPopup
{
    partial class frmBaoCao_ThongKeBenhNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao_ThongKeBenhNhan));
            this.TabMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageSummary = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_Summary = new DevExpress.XtraGrid.GridControl();
            this.gridView_Summary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Sum_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sum_Total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sum_WorkDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pageList = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IntroName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServicePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountExemption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_StatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TypeReceive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cbxService = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnPrintGrid = new DevExpress.XtraEditors.SimpleButton();
            this.chkPrintGroup = new DevExpress.XtraEditors.CheckEdit();
            this.chkGetReceive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dllNgay = new UserControlDate.dllNgay();
            this.lkupNhomDV = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).BeginInit();
            this.TabMain.SuspendLayout();
            this.pageSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Summary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Summary)).BeginInit();
            this.pageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGetReceive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(0, 0);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedTabPage = this.pageSummary;
            this.TabMain.Size = new System.Drawing.Size(699, 538);
            this.TabMain.TabIndex = 2;
            this.TabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageSummary,
            this.pageList});
            this.TabMain.Click += new System.EventHandler(this.TabMain_Click);
            // 
            // pageSummary
            // 
            this.pageSummary.Controls.Add(this.gridControl_Summary);
            this.pageSummary.Name = "pageSummary";
            this.pageSummary.Size = new System.Drawing.Size(693, 510);
            this.pageSummary.Text = "Tổng hợp";
            // 
            // gridControl_Summary
            // 
            this.gridControl_Summary.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Summary.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Summary.MainView = this.gridView_Summary;
            this.gridControl_Summary.Name = "gridControl_Summary";
            this.gridControl_Summary.Size = new System.Drawing.Size(693, 510);
            this.gridControl_Summary.TabIndex = 0;
            this.gridControl_Summary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Summary});
            // 
            // gridView_Summary
            // 
            this.gridView_Summary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Sum_DepartmentName,
            this.col_Sum_Total,
            this.col_Sum_WorkDate});
            this.gridView_Summary.GridControl = this.gridControl_Summary;
            this.gridView_Summary.Name = "gridView_Summary";
            this.gridView_Summary.OptionsView.ShowFooter = true;
            this.gridView_Summary.OptionsView.ShowGroupPanel = false;
            // 
            // col_Sum_DepartmentName
            // 
            this.col_Sum_DepartmentName.Caption = "Phòng khám";
            this.col_Sum_DepartmentName.FieldName = "DepartmentName";
            this.col_Sum_DepartmentName.Name = "col_Sum_DepartmentName";
            this.col_Sum_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_Sum_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_Sum_DepartmentName.OptionsColumn.ReadOnly = true;
            this.col_Sum_DepartmentName.Visible = true;
            this.col_Sum_DepartmentName.VisibleIndex = 1;
            this.col_Sum_DepartmentName.Width = 469;
            // 
            // col_Sum_Total
            // 
            this.col_Sum_Total.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Sum_Total.AppearanceCell.Options.UseFont = true;
            this.col_Sum_Total.AppearanceCell.Options.UseTextOptions = true;
            this.col_Sum_Total.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sum_Total.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Sum_Total.AppearanceHeader.Options.UseFont = true;
            this.col_Sum_Total.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sum_Total.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sum_Total.Caption = "Số bệnh";
            this.col_Sum_Total.FieldName = "Total";
            this.col_Sum_Total.Name = "col_Sum_Total";
            this.col_Sum_Total.OptionsColumn.AllowEdit = false;
            this.col_Sum_Total.OptionsColumn.AllowFocus = false;
            this.col_Sum_Total.OptionsColumn.ReadOnly = true;
            this.col_Sum_Total.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_Sum_Total.Visible = true;
            this.col_Sum_Total.VisibleIndex = 2;
            this.col_Sum_Total.Width = 122;
            // 
            // col_Sum_WorkDate
            // 
            this.col_Sum_WorkDate.Caption = "Ngày";
            this.col_Sum_WorkDate.FieldName = "WorkDate";
            this.col_Sum_WorkDate.Name = "col_Sum_WorkDate";
            this.col_Sum_WorkDate.OptionsColumn.AllowEdit = false;
            this.col_Sum_WorkDate.OptionsColumn.AllowFocus = false;
            this.col_Sum_WorkDate.OptionsColumn.ReadOnly = true;
            this.col_Sum_WorkDate.Visible = true;
            this.col_Sum_WorkDate.VisibleIndex = 0;
            this.col_Sum_WorkDate.Width = 115;
            // 
            // pageList
            // 
            this.pageList.Controls.Add(this.gridControl_result);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(693, 510);
            this.pageList.Text = "Chi tiết bệnh nhân";
            // 
            // gridControl_result
            // 
            this.gridControl_result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.Size = new System.Drawing.Size(693, 510);
            this.gridControl_result.TabIndex = 0;
            this.gridControl_result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_result});
            // 
            // gridView_result
            // 
            this.gridView_result.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.gridView_result.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.gridView_result.Appearance.Row.Options.UseFont = true;
            this.gridView_result.Appearance.Row.Options.UseForeColor = true;
            this.gridView_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PatientCode,
            this.col_PatientName,
            this.col_PatientGenderName,
            this.col_PatientBirthday,
            this.col_PostingDate,
            this.col_DepartmentName,
            this.col_IntroName,
            this.col_ServicePrice,
            this.col_AmountExemption,
            this.col_ServiceCode,
            this.col_ServiceName,
            this.col_StatusName,
            this.col_Reason,
            this.col_TypeReceive,
            this.col_PatientAge,
            this.col_PatientMobile,
            this.col_PatientAddress,
            this.col_ObjectName});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu !";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsView.ColumnAutoWidth = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientCode.Caption = "Mã BN";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 0;
            this.col_PatientCode.Width = 97;
            // 
            // col_PatientName
            // 
            this.col_PatientName.Caption = "Tên bệnh nhân";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.OptionsColumn.AllowEdit = false;
            this.col_PatientName.OptionsColumn.AllowFocus = false;
            this.col_PatientName.OptionsColumn.ReadOnly = true;
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 1;
            this.col_PatientName.Width = 168;
            // 
            // col_PatientGenderName
            // 
            this.col_PatientGenderName.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientGenderName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientGenderName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientGenderName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientGenderName.Caption = "Giới tính";
            this.col_PatientGenderName.FieldName = "PatientGenderName";
            this.col_PatientGenderName.Name = "col_PatientGenderName";
            this.col_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.col_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.col_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.col_PatientGenderName.Visible = true;
            this.col_PatientGenderName.VisibleIndex = 2;
            this.col_PatientGenderName.Width = 80;
            // 
            // col_PatientBirthday
            // 
            this.col_PatientBirthday.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientBirthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientBirthday.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientBirthday.Caption = "Ngày sinh";
            this.col_PatientBirthday.FieldName = "PatientBirthday";
            this.col_PatientBirthday.Name = "col_PatientBirthday";
            this.col_PatientBirthday.OptionsColumn.AllowEdit = false;
            this.col_PatientBirthday.OptionsColumn.AllowFocus = false;
            this.col_PatientBirthday.OptionsColumn.ReadOnly = true;
            this.col_PatientBirthday.Visible = true;
            this.col_PatientBirthday.VisibleIndex = 3;
            this.col_PatientBirthday.Width = 77;
            // 
            // col_PostingDate
            // 
            this.col_PostingDate.AppearanceCell.Options.UseTextOptions = true;
            this.col_PostingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PostingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PostingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PostingDate.Caption = "Ngày khám";
            this.col_PostingDate.FieldName = "CreateDate";
            this.col_PostingDate.Name = "col_PostingDate";
            this.col_PostingDate.OptionsColumn.AllowEdit = false;
            this.col_PostingDate.OptionsColumn.AllowFocus = false;
            this.col_PostingDate.OptionsColumn.ReadOnly = true;
            this.col_PostingDate.Visible = true;
            this.col_PostingDate.VisibleIndex = 9;
            this.col_PostingDate.Width = 115;
            // 
            // col_DepartmentName
            // 
            this.col_DepartmentName.Caption = "P.Khám";
            this.col_DepartmentName.FieldName = "DepartmentName";
            this.col_DepartmentName.Name = "col_DepartmentName";
            this.col_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_DepartmentName.OptionsColumn.ReadOnly = true;
            this.col_DepartmentName.Width = 108;
            // 
            // col_IntroName
            // 
            this.col_IntroName.Caption = "Người GT";
            this.col_IntroName.FieldName = "IntroName";
            this.col_IntroName.Name = "col_IntroName";
            this.col_IntroName.OptionsColumn.AllowEdit = false;
            this.col_IntroName.OptionsColumn.AllowFocus = false;
            this.col_IntroName.OptionsColumn.ReadOnly = true;
            this.col_IntroName.Width = 154;
            // 
            // col_ServicePrice
            // 
            this.col_ServicePrice.Caption = "Đơn giá";
            this.col_ServicePrice.DisplayFormat.FormatString = "#,#";
            this.col_ServicePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ServicePrice.FieldName = "ServicePrice";
            this.col_ServicePrice.Name = "col_ServicePrice";
            // 
            // col_AmountExemption
            // 
            this.col_AmountExemption.Caption = "Giảm giá";
            this.col_AmountExemption.DisplayFormat.FormatString = "#,#";
            this.col_AmountExemption.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountExemption.FieldName = "AmountExemption";
            this.col_AmountExemption.Name = "col_AmountExemption";
            // 
            // col_ServiceCode
            // 
            this.col_ServiceCode.Caption = "ServiceCode";
            this.col_ServiceCode.FieldName = "ServiceCode";
            this.col_ServiceCode.Name = "col_ServiceCode";
            // 
            // col_ServiceName
            // 
            this.col_ServiceName.Caption = "Dịch vụ";
            this.col_ServiceName.FieldName = "ServiceName";
            this.col_ServiceName.Name = "col_ServiceName";
            this.col_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_ServiceName.Visible = true;
            this.col_ServiceName.VisibleIndex = 7;
            this.col_ServiceName.Width = 178;
            // 
            // col_StatusName
            // 
            this.col_StatusName.Caption = "Tình trạng";
            this.col_StatusName.FieldName = "StatusName";
            this.col_StatusName.Name = "col_StatusName";
            this.col_StatusName.OptionsColumn.AllowEdit = false;
            this.col_StatusName.OptionsColumn.AllowFocus = false;
            this.col_StatusName.OptionsColumn.ReadOnly = true;
            this.col_StatusName.Width = 106;
            // 
            // col_Reason
            // 
            this.col_Reason.Caption = "Lý do";
            this.col_Reason.FieldName = "Reason";
            this.col_Reason.Name = "col_Reason";
            this.col_Reason.OptionsColumn.AllowEdit = false;
            this.col_Reason.OptionsColumn.AllowFocus = false;
            this.col_Reason.OptionsColumn.ReadOnly = true;
            this.col_Reason.Width = 106;
            // 
            // col_TypeReceive
            // 
            this.col_TypeReceive.Caption = "Tự đến - tái khám";
            this.col_TypeReceive.FieldName = "TypeReceive";
            this.col_TypeReceive.Name = "col_TypeReceive";
            this.col_TypeReceive.OptionsColumn.AllowEdit = false;
            this.col_TypeReceive.OptionsColumn.AllowFocus = false;
            this.col_TypeReceive.OptionsColumn.ReadOnly = true;
            // 
            // col_PatientAge
            // 
            this.col_PatientAge.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientAge.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientAge.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientAge.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientAge.Caption = "Tuổi";
            this.col_PatientAge.FieldName = "PatientAge";
            this.col_PatientAge.Name = "col_PatientAge";
            this.col_PatientAge.OptionsColumn.AllowEdit = false;
            this.col_PatientAge.OptionsColumn.AllowFocus = false;
            this.col_PatientAge.OptionsColumn.ReadOnly = true;
            this.col_PatientAge.Visible = true;
            this.col_PatientAge.VisibleIndex = 4;
            this.col_PatientAge.Width = 72;
            // 
            // col_PatientMobile
            // 
            this.col_PatientMobile.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientMobile.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientMobile.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientMobile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientMobile.Caption = "Số ĐT";
            this.col_PatientMobile.FieldName = "PatientMobile";
            this.col_PatientMobile.Name = "col_PatientMobile";
            this.col_PatientMobile.OptionsColumn.AllowEdit = false;
            this.col_PatientMobile.OptionsColumn.AllowFocus = false;
            this.col_PatientMobile.OptionsColumn.ReadOnly = true;
            this.col_PatientMobile.Visible = true;
            this.col_PatientMobile.VisibleIndex = 6;
            this.col_PatientMobile.Width = 118;
            // 
            // col_PatientAddress
            // 
            this.col_PatientAddress.Caption = "Địa chỉ";
            this.col_PatientAddress.FieldName = "PatientAddress";
            this.col_PatientAddress.Name = "col_PatientAddress";
            this.col_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_PatientAddress.OptionsColumn.ReadOnly = true;
            this.col_PatientAddress.Visible = true;
            this.col_PatientAddress.VisibleIndex = 5;
            this.col_PatientAddress.Width = 188;
            // 
            // col_ObjectName
            // 
            this.col_ObjectName.Caption = "Đối tượng";
            this.col_ObjectName.FieldName = "ObjectName";
            this.col_ObjectName.Name = "col_ObjectName";
            this.col_ObjectName.OptionsColumn.AllowEdit = false;
            this.col_ObjectName.OptionsColumn.AllowFocus = false;
            this.col_ObjectName.OptionsColumn.ReadOnly = true;
            this.col_ObjectName.Visible = true;
            this.col_ObjectName.VisibleIndex = 8;
            this.col_ObjectName.Width = 92;
            // 
            // butPrint
            // 
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(143, 191);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(67, 26);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(63, 191);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(79, 26);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.TabMain);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1007, 538);
            this.splitContainerControl1.SplitterPosition = 303;
            this.splitContainerControl1.TabIndex = 7;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cbxService);
            this.groupControl2.Controls.Add(this.btnPrintGrid);
            this.groupControl2.Controls.Add(this.chkPrintGroup);
            this.groupControl2.Controls.Add(this.chkGetReceive);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.dllNgay);
            this.groupControl2.Controls.Add(this.butPrint);
            this.groupControl2.Controls.Add(this.butOK);
            this.groupControl2.Controls.Add(this.lkupNhomDV);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(303, 538);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thông số báo cáo";
            // 
            // cbxService
            // 
            this.cbxService.Location = new System.Drawing.Point(63, 119);
            this.cbxService.Name = "cbxService";
            this.cbxService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxService.Properties.DropDownRows = 15;
            this.cbxService.Size = new System.Drawing.Size(233, 20);
            this.cbxService.TabIndex = 1056;
            // 
            // btnPrintGrid
            // 
            this.btnPrintGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGrid.Image")));
            this.btnPrintGrid.Location = new System.Drawing.Point(211, 191);
            this.btnPrintGrid.Name = "btnPrintGrid";
            this.btnPrintGrid.Size = new System.Drawing.Size(84, 26);
            this.btnPrintGrid.TabIndex = 1055;
            this.btnPrintGrid.Text = "In theo Grid";
            this.btnPrintGrid.Click += new System.EventHandler(this.btnPrintGrid_Click);
            // 
            // chkPrintGroup
            // 
            this.chkPrintGroup.Location = new System.Drawing.Point(59, 166);
            this.chkPrintGroup.Name = "chkPrintGroup";
            this.chkPrintGroup.Properties.Caption = "Nhóm dữ liệu theo bệnh nhân";
            this.chkPrintGroup.Size = new System.Drawing.Size(237, 19);
            this.chkPrintGroup.TabIndex = 1052;
            // 
            // chkGetReceive
            // 
            this.chkGetReceive.Location = new System.Drawing.Point(59, 143);
            this.chkGetReceive.Name = "chkGetReceive";
            this.chkGetReceive.Properties.Caption = "Lấy danh sách chỉ định từ tiếp nhận";
            this.chkGetReceive.Size = new System.Drawing.Size(237, 19);
            this.chkGetReceive.TabIndex = 1052;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 122);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 1050;
            this.labelControl1.Text = "Dịch vụ :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(2, 100);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 1050;
            this.labelControl3.Text = "Nhóm D.Vụ :";
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(5, 23);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(297, 73);
            this.dllNgay.TabIndex = 1045;
            // 
            // lkupNhomDV
            // 
            this.lkupNhomDV.EditValue = "0";
            this.lkupNhomDV.Location = new System.Drawing.Point(63, 97);
            this.lkupNhomDV.Name = "lkupNhomDV";
            this.lkupNhomDV.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lkupNhomDV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupNhomDV.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupCode", "ServiceGroupCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupName", "Nhóm dịch vụ")});
            this.lkupNhomDV.Properties.DropDownRows = 15;
            this.lkupNhomDV.Properties.NullText = "";
            this.lkupNhomDV.Size = new System.Drawing.Size(233, 20);
            this.lkupNhomDV.TabIndex = 1051;
            this.lkupNhomDV.EditValueChanged += new System.EventHandler(this.lkupNhomDV_EditValueChanged);
            // 
            // frmBaoCao_ThongKeBenhNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 538);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao_ThongKeBenhNhan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê bệnh nhân khám chữa bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoCao_ThongKeBenhNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).EndInit();
            this.TabMain.ResumeLayout(false);
            this.pageSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Summary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Summary)).EndInit();
            this.pageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGetReceive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraTab.XtraTabControl TabMain;
        private DevExpress.XtraTab.XtraTabPage pageList;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_PostingDate;
        private DevExpress.XtraTab.XtraTabPage pageSummary;
        private DevExpress.XtraGrid.GridControl gridControl_Summary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Summary;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sum_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sum_Total;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraGrid.Columns.GridColumn col_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_IntroName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServicePrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountExemption;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_StatusName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Reason;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sum_WorkDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_TypeReceive;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkGetReceive;
        private DevExpress.XtraEditors.CheckEdit chkPrintGroup;
        private DevExpress.XtraEditors.SimpleButton btnPrintGrid;
        private DevExpress.XtraEditors.LookUpEdit lkupNhomDV;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbxService;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientAge;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientMobile;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_ObjectName;
    }
}