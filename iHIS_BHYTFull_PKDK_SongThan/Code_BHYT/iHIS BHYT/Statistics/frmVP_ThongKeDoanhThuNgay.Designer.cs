namespace Ps.Clinic.Statistics
{
    partial class frmVP_ThongKeDoanhThuNgay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_ThongKeDoanhThuNgay));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tabResult = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageTH = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_result_KCB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_CDHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_XN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountKCB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountCDHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PTTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_TC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountPTTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_VC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountVC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_GIUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_NHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountNha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_AmountGIUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageCT = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_ResultDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView_ResultDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_detail_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_detail_AmountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_detail_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_detail_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_detail_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_detail_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_detail_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.btnPrintGrid = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.dllNgay = new UserControlDate.dllNgay();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.col_result_PostingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabResult)).BeginInit();
            this.tabResult.SuspendLayout();
            this.tabPageTH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            this.tabPageCT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ResultDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ResultDetail)).BeginInit();
            this.pnSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.tabResult);
            this.groupControl2.Controls.Add(this.pnSearch);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(934, 577);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông tin lấy báo cáo";
            // 
            // tabResult
            // 
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Location = new System.Drawing.Point(354, 27);
            this.tabResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedTabPage = this.tabPageTH;
            this.tabResult.Size = new System.Drawing.Size(578, 548);
            this.tabResult.TabIndex = 1055;
            this.tabResult.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageTH,
            this.tabPageCT});
            this.tabResult.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabResult_SelectedPageChanged);
            // 
            // tabPageTH
            // 
            this.tabPageTH.Controls.Add(this.gridControl_Result);
            this.tabPageTH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageTH.Name = "tabPageTH";
            this.tabPageTH.Size = new System.Drawing.Size(571, 513);
            this.tabPageTH.Text = "Tổng hợp";
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
            this.gridControl_Result.Size = new System.Drawing.Size(571, 513);
            this.gridControl_Result.TabIndex = 1054;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_result_KCB,
            this.col_result_CDHA,
            this.col_result_XN,
            this.col_result_AmountKCB,
            this.col_result_PostingDate,
            this.col_result_AmountCDHA,
            this.col_result_AmountXN,
            this.col_result_AmountThuoc,
            this.col_result_AmountTotal,
            this.col_result_PTTT,
            this.col_result_TC,
            this.col_result_AmountPTTT,
            this.col_result_AmountTC,
            this.col_result_VC,
            this.col_result_AmountVC,
            this.col_result_GIUONG,
            this.col_result_NHA,
            this.col_result_AmountNha,
            this.col_result_AmountGIUONG,
            this.col_result_PostingTime});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServicePrice", null, "{0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.AllowFindPanel = false;
            this.gridView_Result.OptionsFind.FindFilterColumns = "";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // col_result_KCB
            // 
            this.col_result_KCB.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_KCB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_KCB.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_KCB.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_KCB.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_KCB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_KCB.Caption = "Khám bệnh";
            this.col_result_KCB.DisplayFormat.FormatString = "#,#";
            this.col_result_KCB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_KCB.FieldName = "KCB";
            this.col_result_KCB.Name = "col_result_KCB";
            this.col_result_KCB.OptionsColumn.AllowEdit = false;
            this.col_result_KCB.OptionsColumn.AllowFocus = false;
            this.col_result_KCB.OptionsColumn.ReadOnly = true;
            this.col_result_KCB.Visible = true;
            this.col_result_KCB.VisibleIndex = 2;
            this.col_result_KCB.Width = 65;
            // 
            // col_result_CDHA
            // 
            this.col_result_CDHA.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_CDHA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_CDHA.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_CDHA.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_CDHA.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_CDHA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_CDHA.Caption = "CĐHA";
            this.col_result_CDHA.DisplayFormat.FormatString = "#,#";
            this.col_result_CDHA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_CDHA.FieldName = "CDHA";
            this.col_result_CDHA.Name = "col_result_CDHA";
            this.col_result_CDHA.OptionsColumn.AllowEdit = false;
            this.col_result_CDHA.OptionsColumn.AllowFocus = false;
            this.col_result_CDHA.OptionsColumn.ReadOnly = true;
            this.col_result_CDHA.Visible = true;
            this.col_result_CDHA.VisibleIndex = 3;
            this.col_result_CDHA.Width = 45;
            // 
            // col_result_XN
            // 
            this.col_result_XN.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_XN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_XN.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_XN.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_XN.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_XN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_XN.Caption = "Xét nghiệm";
            this.col_result_XN.DisplayFormat.FormatString = "#,#";
            this.col_result_XN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_XN.FieldName = "XN";
            this.col_result_XN.Name = "col_result_XN";
            this.col_result_XN.OptionsColumn.AllowEdit = false;
            this.col_result_XN.OptionsColumn.AllowFocus = false;
            this.col_result_XN.OptionsColumn.ReadOnly = true;
            this.col_result_XN.Visible = true;
            this.col_result_XN.VisibleIndex = 4;
            this.col_result_XN.Width = 65;
            // 
            // col_result_AmountKCB
            // 
            this.col_result_AmountKCB.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountKCB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountKCB.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountKCB.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountKCB.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountKCB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountKCB.Caption = "T.Tiền Khám bệnh";
            this.col_result_AmountKCB.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountKCB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountKCB.FieldName = "AmountKCB";
            this.col_result_AmountKCB.Name = "col_result_AmountKCB";
            this.col_result_AmountKCB.OptionsColumn.AllowEdit = false;
            this.col_result_AmountKCB.OptionsColumn.AllowFocus = false;
            this.col_result_AmountKCB.OptionsColumn.ReadOnly = true;
            this.col_result_AmountKCB.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountKCB", "{0:#,#}")});
            this.col_result_AmountKCB.Visible = true;
            this.col_result_AmountKCB.VisibleIndex = 10;
            this.col_result_AmountKCB.Width = 98;
            // 
            // col_result_PostingDate
            // 
            this.col_result_PostingDate.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_PostingDate.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_PostingDate.Caption = "Ngày";
            this.col_result_PostingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_result_PostingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_result_PostingDate.FieldName = "PostingDate";
            this.col_result_PostingDate.Name = "col_result_PostingDate";
            this.col_result_PostingDate.OptionsColumn.AllowEdit = false;
            this.col_result_PostingDate.OptionsColumn.AllowFocus = false;
            this.col_result_PostingDate.OptionsColumn.ReadOnly = true;
            this.col_result_PostingDate.Visible = true;
            this.col_result_PostingDate.VisibleIndex = 0;
            this.col_result_PostingDate.Width = 90;
            // 
            // col_result_AmountCDHA
            // 
            this.col_result_AmountCDHA.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountCDHA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountCDHA.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountCDHA.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountCDHA.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountCDHA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountCDHA.Caption = "T.Tiền CĐHA";
            this.col_result_AmountCDHA.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountCDHA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountCDHA.FieldName = "AmountCDHA";
            this.col_result_AmountCDHA.Name = "col_result_AmountCDHA";
            this.col_result_AmountCDHA.OptionsColumn.AllowEdit = false;
            this.col_result_AmountCDHA.OptionsColumn.AllowFocus = false;
            this.col_result_AmountCDHA.OptionsColumn.ReadOnly = true;
            this.col_result_AmountCDHA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountCDHA", "{0:#,#}")});
            this.col_result_AmountCDHA.Visible = true;
            this.col_result_AmountCDHA.VisibleIndex = 11;
            this.col_result_AmountCDHA.Width = 76;
            // 
            // col_result_AmountXN
            // 
            this.col_result_AmountXN.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountXN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountXN.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountXN.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountXN.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountXN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountXN.Caption = "T.Tiền Xét nghiệm";
            this.col_result_AmountXN.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountXN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountXN.FieldName = "AmountXN";
            this.col_result_AmountXN.Name = "col_result_AmountXN";
            this.col_result_AmountXN.OptionsColumn.AllowEdit = false;
            this.col_result_AmountXN.OptionsColumn.AllowFocus = false;
            this.col_result_AmountXN.OptionsColumn.ReadOnly = true;
            this.col_result_AmountXN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountXN", "{0:#,#}")});
            this.col_result_AmountXN.Visible = true;
            this.col_result_AmountXN.VisibleIndex = 12;
            this.col_result_AmountXN.Width = 103;
            // 
            // col_result_AmountThuoc
            // 
            this.col_result_AmountThuoc.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountThuoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountThuoc.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountThuoc.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountThuoc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountThuoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountThuoc.Caption = "T.Tiền Thuốc";
            this.col_result_AmountThuoc.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountThuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountThuoc.FieldName = "AmountThuoc";
            this.col_result_AmountThuoc.Name = "col_result_AmountThuoc";
            this.col_result_AmountThuoc.OptionsColumn.AllowEdit = false;
            this.col_result_AmountThuoc.OptionsColumn.AllowFocus = false;
            this.col_result_AmountThuoc.OptionsColumn.ReadOnly = true;
            this.col_result_AmountThuoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountThuoc", "{0:#,#}")});
            this.col_result_AmountThuoc.Visible = true;
            this.col_result_AmountThuoc.VisibleIndex = 18;
            this.col_result_AmountThuoc.Width = 106;
            // 
            // col_result_AmountTotal
            // 
            this.col_result_AmountTotal.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.col_result_AmountTotal.AppearanceCell.Options.UseForeColor = true;
            this.col_result_AmountTotal.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountTotal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountTotal.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountTotal.Caption = "Tổng";
            this.col_result_AmountTotal.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountTotal.FieldName = "AmountTotal";
            this.col_result_AmountTotal.Name = "col_result_AmountTotal";
            this.col_result_AmountTotal.OptionsColumn.AllowEdit = false;
            this.col_result_AmountTotal.OptionsColumn.AllowFocus = false;
            this.col_result_AmountTotal.OptionsColumn.ReadOnly = true;
            this.col_result_AmountTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountTotal", "{0:#,#}")});
            this.col_result_AmountTotal.Visible = true;
            this.col_result_AmountTotal.VisibleIndex = 19;
            this.col_result_AmountTotal.Width = 115;
            // 
            // col_result_PTTT
            // 
            this.col_result_PTTT.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_PTTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_PTTT.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_PTTT.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_PTTT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_PTTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_PTTT.Caption = "PTTT";
            this.col_result_PTTT.DisplayFormat.FormatString = "#,#";
            this.col_result_PTTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_PTTT.FieldName = "PTTT";
            this.col_result_PTTT.Name = "col_result_PTTT";
            this.col_result_PTTT.OptionsColumn.AllowEdit = false;
            this.col_result_PTTT.OptionsColumn.AllowFocus = false;
            this.col_result_PTTT.OptionsColumn.ReadOnly = true;
            this.col_result_PTTT.Visible = true;
            this.col_result_PTTT.VisibleIndex = 5;
            this.col_result_PTTT.Width = 57;
            // 
            // col_result_TC
            // 
            this.col_result_TC.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_TC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_TC.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_TC.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_TC.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_TC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_TC.Caption = "Tiêm chủng";
            this.col_result_TC.DisplayFormat.FormatString = "#,#";
            this.col_result_TC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_TC.FieldName = "TC";
            this.col_result_TC.Name = "col_result_TC";
            this.col_result_TC.OptionsColumn.AllowEdit = false;
            this.col_result_TC.OptionsColumn.AllowFocus = false;
            this.col_result_TC.OptionsColumn.ReadOnly = true;
            this.col_result_TC.Visible = true;
            this.col_result_TC.VisibleIndex = 9;
            // 
            // col_result_AmountPTTT
            // 
            this.col_result_AmountPTTT.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountPTTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountPTTT.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountPTTT.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountPTTT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountPTTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountPTTT.Caption = "T.PTTT";
            this.col_result_AmountPTTT.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountPTTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountPTTT.FieldName = "AmountPTTT";
            this.col_result_AmountPTTT.Name = "col_result_AmountPTTT";
            this.col_result_AmountPTTT.OptionsColumn.AllowEdit = false;
            this.col_result_AmountPTTT.OptionsColumn.AllowFocus = false;
            this.col_result_AmountPTTT.OptionsColumn.ReadOnly = true;
            this.col_result_AmountPTTT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountPTTT", "{0:#,#}")});
            this.col_result_AmountPTTT.Visible = true;
            this.col_result_AmountPTTT.VisibleIndex = 13;
            this.col_result_AmountPTTT.Width = 88;
            // 
            // col_result_AmountTC
            // 
            this.col_result_AmountTC.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountTC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountTC.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountTC.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountTC.AppearanceHeader.Options.UseTextOptions = true;
            this.col_result_AmountTC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountTC.Caption = "T.Tiêm chủng";
            this.col_result_AmountTC.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountTC.FieldName = "AmountTC";
            this.col_result_AmountTC.Name = "col_result_AmountTC";
            this.col_result_AmountTC.OptionsColumn.AllowEdit = false;
            this.col_result_AmountTC.OptionsColumn.AllowFocus = false;
            this.col_result_AmountTC.OptionsColumn.ReadOnly = true;
            this.col_result_AmountTC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountTC", "{0:#,#}")});
            this.col_result_AmountTC.Visible = true;
            this.col_result_AmountTC.VisibleIndex = 17;
            this.col_result_AmountTC.Width = 92;
            // 
            // col_result_VC
            // 
            this.col_result_VC.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_VC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_VC.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_VC.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_VC.Caption = "Vận chuyển";
            this.col_result_VC.DisplayFormat.FormatString = "#,#";
            this.col_result_VC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_VC.FieldName = "VC";
            this.col_result_VC.Name = "col_result_VC";
            this.col_result_VC.OptionsColumn.AllowEdit = false;
            this.col_result_VC.OptionsColumn.AllowFocus = false;
            this.col_result_VC.OptionsColumn.ReadOnly = true;
            this.col_result_VC.Visible = true;
            this.col_result_VC.VisibleIndex = 6;
            // 
            // col_result_AmountVC
            // 
            this.col_result_AmountVC.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountVC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountVC.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountVC.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountVC.Caption = "T.Tiền V.Chuyển";
            this.col_result_AmountVC.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountVC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountVC.FieldName = "AmountVC";
            this.col_result_AmountVC.Name = "col_result_AmountVC";
            this.col_result_AmountVC.OptionsColumn.AllowEdit = false;
            this.col_result_AmountVC.OptionsColumn.AllowFocus = false;
            this.col_result_AmountVC.OptionsColumn.ReadOnly = true;
            this.col_result_AmountVC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountVC", "{0:#,#}")});
            this.col_result_AmountVC.Visible = true;
            this.col_result_AmountVC.VisibleIndex = 14;
            this.col_result_AmountVC.Width = 116;
            // 
            // col_result_GIUONG
            // 
            this.col_result_GIUONG.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_GIUONG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_GIUONG.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_GIUONG.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_GIUONG.Caption = "P.Giường";
            this.col_result_GIUONG.DisplayFormat.FormatString = "#,#";
            this.col_result_GIUONG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_GIUONG.FieldName = "GIUONG";
            this.col_result_GIUONG.Name = "col_result_GIUONG";
            this.col_result_GIUONG.OptionsColumn.AllowEdit = false;
            this.col_result_GIUONG.OptionsColumn.AllowFocus = false;
            this.col_result_GIUONG.OptionsColumn.ReadOnly = true;
            this.col_result_GIUONG.Visible = true;
            this.col_result_GIUONG.VisibleIndex = 7;
            // 
            // col_result_NHA
            // 
            this.col_result_NHA.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_NHA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_NHA.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_NHA.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_NHA.Caption = "Nha khoa";
            this.col_result_NHA.DisplayFormat.FormatString = "#,#";
            this.col_result_NHA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_NHA.FieldName = "NHA";
            this.col_result_NHA.Name = "col_result_NHA";
            this.col_result_NHA.OptionsColumn.AllowEdit = false;
            this.col_result_NHA.OptionsColumn.AllowFocus = false;
            this.col_result_NHA.OptionsColumn.ReadOnly = true;
            this.col_result_NHA.Visible = true;
            this.col_result_NHA.VisibleIndex = 8;
            // 
            // col_result_AmountNha
            // 
            this.col_result_AmountNha.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountNha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountNha.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountNha.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountNha.Caption = "T.Tiền N.Khoa";
            this.col_result_AmountNha.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountNha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountNha.Name = "col_result_AmountNha";
            this.col_result_AmountNha.OptionsColumn.AllowEdit = false;
            this.col_result_AmountNha.OptionsColumn.AllowFocus = false;
            this.col_result_AmountNha.OptionsColumn.ReadOnly = true;
            this.col_result_AmountNha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", "{0:#,#}")});
            this.col_result_AmountNha.Visible = true;
            this.col_result_AmountNha.VisibleIndex = 16;
            this.col_result_AmountNha.Width = 101;
            // 
            // col_result_AmountGIUONG
            // 
            this.col_result_AmountGIUONG.AppearanceCell.Options.UseTextOptions = true;
            this.col_result_AmountGIUONG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_result_AmountGIUONG.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_AmountGIUONG.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_AmountGIUONG.Caption = "T.Tiền P.Giường";
            this.col_result_AmountGIUONG.DisplayFormat.FormatString = "#,#";
            this.col_result_AmountGIUONG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_AmountGIUONG.FieldName = "AmountGIUONG";
            this.col_result_AmountGIUONG.Name = "col_result_AmountGIUONG";
            this.col_result_AmountGIUONG.OptionsColumn.AllowEdit = false;
            this.col_result_AmountGIUONG.OptionsColumn.AllowFocus = false;
            this.col_result_AmountGIUONG.OptionsColumn.ReadOnly = true;
            this.col_result_AmountGIUONG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountGIUONG", "{0:#,#}")});
            this.col_result_AmountGIUONG.Visible = true;
            this.col_result_AmountGIUONG.VisibleIndex = 15;
            this.col_result_AmountGIUONG.Width = 107;
            // 
            // tabPageCT
            // 
            this.tabPageCT.Controls.Add(this.gridControl_ResultDetail);
            this.tabPageCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCT.Name = "tabPageCT";
            this.tabPageCT.Size = new System.Drawing.Size(570, 514);
            this.tabPageCT.Text = "Chi tiết";
            // 
            // gridControl_ResultDetail
            // 
            this.gridControl_ResultDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_ResultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ResultDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_ResultDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ResultDetail.MainView = this.gridView_ResultDetail;
            this.gridControl_ResultDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_ResultDetail.Name = "gridControl_ResultDetail";
            this.gridControl_ResultDetail.Size = new System.Drawing.Size(570, 514);
            this.gridControl_ResultDetail.TabIndex = 1055;
            this.gridControl_ResultDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ResultDetail});
            // 
            // gridView_ResultDetail
            // 
            this.gridView_ResultDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_detail_Quantity,
            this.col_detail_AmountTotal,
            this.col_detail_ServiceCode,
            this.col_detail_ServiceName,
            this.col_detail_ServiceCategoryCode,
            this.col_detail_ServiceCategoryName,
            this.col_detail_ServiceGroupName});
            this.gridView_ResultDetail.GridControl = this.gridControl_ResultDetail;
            this.gridView_ResultDetail.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_ResultDetail.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountTotal", null, "{0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0})),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", null, "Số lượng: {0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.gridView_ResultDetail.Name = "gridView_ResultDetail";
            this.gridView_ResultDetail.OptionsFind.AllowFindPanel = false;
            this.gridView_ResultDetail.OptionsFind.FindFilterColumns = "";
            this.gridView_ResultDetail.OptionsView.ShowFooter = true;
            // 
            // col_detail_Quantity
            // 
            this.col_detail_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_detail_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_detail_Quantity.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_detail_Quantity.AppearanceHeader.Options.UseForeColor = true;
            this.col_detail_Quantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_detail_Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_detail_Quantity.Caption = "Số lượng";
            this.col_detail_Quantity.DisplayFormat.FormatString = "#,#";
            this.col_detail_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_detail_Quantity.FieldName = "Quantity";
            this.col_detail_Quantity.Name = "col_detail_Quantity";
            this.col_detail_Quantity.OptionsColumn.AllowEdit = false;
            this.col_detail_Quantity.OptionsColumn.AllowFocus = false;
            this.col_detail_Quantity.OptionsColumn.ReadOnly = true;
            this.col_detail_Quantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Số lượng: {0:#,#}")});
            this.col_detail_Quantity.Visible = true;
            this.col_detail_Quantity.VisibleIndex = 3;
            this.col_detail_Quantity.Width = 65;
            // 
            // col_detail_AmountTotal
            // 
            this.col_detail_AmountTotal.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.col_detail_AmountTotal.AppearanceCell.Options.UseForeColor = true;
            this.col_detail_AmountTotal.AppearanceCell.Options.UseTextOptions = true;
            this.col_detail_AmountTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_detail_AmountTotal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_detail_AmountTotal.AppearanceHeader.Options.UseForeColor = true;
            this.col_detail_AmountTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.col_detail_AmountTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_detail_AmountTotal.Caption = "Tổng";
            this.col_detail_AmountTotal.DisplayFormat.FormatString = "#,#";
            this.col_detail_AmountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_detail_AmountTotal.FieldName = "AmountTotal";
            this.col_detail_AmountTotal.Name = "col_detail_AmountTotal";
            this.col_detail_AmountTotal.OptionsColumn.AllowEdit = false;
            this.col_detail_AmountTotal.OptionsColumn.AllowFocus = false;
            this.col_detail_AmountTotal.OptionsColumn.ReadOnly = true;
            this.col_detail_AmountTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountTotal", "Tổng {0:#,#}")});
            this.col_detail_AmountTotal.Visible = true;
            this.col_detail_AmountTotal.VisibleIndex = 4;
            this.col_detail_AmountTotal.Width = 96;
            // 
            // col_detail_ServiceCode
            // 
            this.col_detail_ServiceCode.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_detail_ServiceCode.AppearanceHeader.Options.UseForeColor = true;
            this.col_detail_ServiceCode.Caption = "Mã dịch vụ";
            this.col_detail_ServiceCode.FieldName = "ServiceCode";
            this.col_detail_ServiceCode.Name = "col_detail_ServiceCode";
            this.col_detail_ServiceCode.OptionsColumn.AllowEdit = false;
            this.col_detail_ServiceCode.OptionsColumn.AllowFocus = false;
            this.col_detail_ServiceCode.OptionsColumn.ReadOnly = true;
            this.col_detail_ServiceCode.Visible = true;
            this.col_detail_ServiceCode.VisibleIndex = 0;
            this.col_detail_ServiceCode.Width = 93;
            // 
            // col_detail_ServiceName
            // 
            this.col_detail_ServiceName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_detail_ServiceName.AppearanceHeader.Options.UseForeColor = true;
            this.col_detail_ServiceName.Caption = "Dịch vụ";
            this.col_detail_ServiceName.FieldName = "ServiceName";
            this.col_detail_ServiceName.Name = "col_detail_ServiceName";
            this.col_detail_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_detail_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_detail_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_detail_ServiceName.Visible = true;
            this.col_detail_ServiceName.VisibleIndex = 1;
            this.col_detail_ServiceName.Width = 239;
            // 
            // col_detail_ServiceCategoryCode
            // 
            this.col_detail_ServiceCategoryCode.Caption = "Mã loại DV";
            this.col_detail_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.col_detail_ServiceCategoryCode.Name = "col_detail_ServiceCategoryCode";
            // 
            // col_detail_ServiceCategoryName
            // 
            this.col_detail_ServiceCategoryName.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_detail_ServiceCategoryName.AppearanceHeader.Options.UseForeColor = true;
            this.col_detail_ServiceCategoryName.Caption = "Loại dịch vụ";
            this.col_detail_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_detail_ServiceCategoryName.Name = "col_detail_ServiceCategoryName";
            this.col_detail_ServiceCategoryName.OptionsColumn.AllowEdit = false;
            this.col_detail_ServiceCategoryName.OptionsColumn.AllowFocus = false;
            this.col_detail_ServiceCategoryName.OptionsColumn.ReadOnly = true;
            this.col_detail_ServiceCategoryName.Visible = true;
            this.col_detail_ServiceCategoryName.VisibleIndex = 2;
            this.col_detail_ServiceCategoryName.Width = 232;
            // 
            // col_detail_ServiceGroupName
            // 
            this.col_detail_ServiceGroupName.Caption = "Nhóm dịch vụ";
            this.col_detail_ServiceGroupName.FieldName = "ServiceGroupName";
            this.col_detail_ServiceGroupName.Name = "col_detail_ServiceGroupName";
            this.col_detail_ServiceGroupName.OptionsColumn.AllowEdit = false;
            this.col_detail_ServiceGroupName.OptionsColumn.AllowFocus = false;
            this.col_detail_ServiceGroupName.OptionsColumn.ReadOnly = true;
            this.col_detail_ServiceGroupName.Visible = true;
            this.col_detail_ServiceGroupName.VisibleIndex = 5;
            this.col_detail_ServiceGroupName.Width = 73;
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.btnPrintGrid);
            this.pnSearch.Controls.Add(this.butPrint);
            this.pnSearch.Controls.Add(this.dllNgay);
            this.pnSearch.Controls.Add(this.butOK);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSearch.Location = new System.Drawing.Point(2, 27);
            this.pnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(352, 548);
            this.pnSearch.TabIndex = 1053;
            // 
            // btnPrintGrid
            // 
            this.btnPrintGrid.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPrintGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGrid.Image")));
            this.btnPrintGrid.Location = new System.Drawing.Point(237, 107);
            this.btnPrintGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintGrid.Name = "btnPrintGrid";
            this.btnPrintGrid.Size = new System.Drawing.Size(104, 32);
            this.btnPrintGrid.TabIndex = 1054;
            this.btnPrintGrid.Text = "In theo Grid";
            this.btnPrintGrid.Click += new System.EventHandler(this.btnPrintGrid_Click);
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(166, 107);
            this.butPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(70, 32);
            this.butPrint.TabIndex = 1053;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(3, 4);
            this.dllNgay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(342, 90);
            this.dllNgay.TabIndex = 1052;
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(71, 107);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(93, 32);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // col_result_PostingTime
            // 
            this.col_result_PostingTime.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.col_result_PostingTime.AppearanceHeader.Options.UseForeColor = true;
            this.col_result_PostingTime.Caption = "Giờ";
            this.col_result_PostingTime.FieldName = "PostingTime";
            this.col_result_PostingTime.Name = "col_result_PostingTime";
            this.col_result_PostingTime.Visible = true;
            this.col_result_PostingTime.VisibleIndex = 1;
            // 
            // frmVP_ThongKeDoanhThuNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVP_ThongKeDoanhThuNgay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVP_ThongKeDoanhThuNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabResult)).EndInit();
            this.tabResult.ResumeLayout(false);
            this.tabPageTH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            this.tabPageCT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ResultDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ResultDetail)).EndInit();
            this.pnSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private UserControlDate.dllNgay dllNgay;
        private System.Windows.Forms.Panel pnSearch;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_KCB;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_CDHA;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_XN;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountKCB;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PostingDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountCDHA;
        private DevExpress.XtraEditors.SimpleButton btnPrintGrid;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountXN;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountTotal;
        private DevExpress.XtraTab.XtraTabControl tabResult;
        private DevExpress.XtraTab.XtraTabPage tabPageTH;
        private DevExpress.XtraTab.XtraTabPage tabPageCT;
        private DevExpress.XtraGrid.GridControl gridControl_ResultDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ResultDetail;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_AmountTotal;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_ServiceCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PTTT;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_TC;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountPTTT;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountTC;
        private DevExpress.XtraGrid.Columns.GridColumn col_detail_ServiceGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_VC;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountVC;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_GIUONG;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_NHA;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountNha;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_AmountGIUONG;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PostingTime;
    }
}