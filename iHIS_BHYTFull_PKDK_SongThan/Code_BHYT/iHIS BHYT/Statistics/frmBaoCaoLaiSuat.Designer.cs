namespace Ps.Clinic.Statistics
{
    partial class frmBaoCaoLaiSuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoLaiSuat));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_ResultTHMonth = new DevExpress.XtraGrid.GridControl();
            this.gridVIew_ResultTHMonth = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Month_MM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_TotalSale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_TotalBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_TotalInterest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Month_QuantityExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.butPrintGrid = new DevExpress.XtraEditors.SimpleButton();
            this.dtNgayMonth = new UserControlDateTimes.UserControlDateTimes();
            this.butPrintTHMonth = new DevExpress.XtraEditors.SimpleButton();
            this.butCountTHMonth = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ResultTHMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_ResultTHMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.gridControl_ResultTHMonth);
            this.grMain.Controls.Add(this.panelControl3);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(999, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Báo cáo lãi suất nhà thuốc";
            // 
            // gridControl_ResultTHMonth
            // 
            this.gridControl_ResultTHMonth.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_ResultTHMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ResultTHMonth.Location = new System.Drawing.Point(2, 60);
            this.gridControl_ResultTHMonth.MainView = this.gridVIew_ResultTHMonth;
            this.gridControl_ResultTHMonth.Name = "gridControl_ResultTHMonth";
            this.gridControl_ResultTHMonth.Size = new System.Drawing.Size(995, 464);
            this.gridControl_ResultTHMonth.TabIndex = 3;
            this.gridControl_ResultTHMonth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_ResultTHMonth});
            // 
            // gridVIew_ResultTHMonth
            // 
            this.gridVIew_ResultTHMonth.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Month_MM,
            this.col_Month_TotalSale,
            this.col_Month_TotalBuy,
            this.col_Month_ItemCode,
            this.col_Month_ItemName,
            this.col_Month_TotalInterest,
            this.col_Month_ItemCategoryName,
            this.col_Month_GroupName,
            this.col_Month_UnitOfMeasureName,
            this.col_Month_QuantityExport});
            this.gridVIew_ResultTHMonth.GridControl = this.gridControl_ResultTHMonth;
            this.gridVIew_ResultTHMonth.GroupPanelText = "Nhóm dữ liệu!";
            this.gridVIew_ResultTHMonth.Name = "gridVIew_ResultTHMonth";
            this.gridVIew_ResultTHMonth.OptionsFind.FindFilterColumns = "ItemName";
            this.gridVIew_ResultTHMonth.OptionsView.ColumnAutoWidth = false;
            this.gridVIew_ResultTHMonth.OptionsView.ShowFooter = true;
            this.gridVIew_ResultTHMonth.OptionsView.ShowGroupPanel = false;
            // 
            // col_Month_MM
            // 
            this.col_Month_MM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_MM.AppearanceHeader.Options.UseFont = true;
            this.col_Month_MM.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Month_MM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Month_MM.Caption = "Tháng";
            this.col_Month_MM.FieldName = "MM";
            this.col_Month_MM.Name = "col_Month_MM";
            this.col_Month_MM.OptionsColumn.AllowEdit = false;
            this.col_Month_MM.OptionsColumn.AllowFocus = false;
            this.col_Month_MM.OptionsColumn.ReadOnly = true;
            this.col_Month_MM.Visible = true;
            this.col_Month_MM.VisibleIndex = 0;
            this.col_Month_MM.Width = 72;
            // 
            // col_Month_TotalSale
            // 
            this.col_Month_TotalSale.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_TotalSale.AppearanceHeader.Options.UseFont = true;
            this.col_Month_TotalSale.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Month_TotalSale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Month_TotalSale.Caption = "Tổng tiền bán";
            this.col_Month_TotalSale.DisplayFormat.FormatString = "#,#.####";
            this.col_Month_TotalSale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Month_TotalSale.FieldName = "TotalSale";
            this.col_Month_TotalSale.Name = "col_Month_TotalSale";
            this.col_Month_TotalSale.OptionsColumn.AllowEdit = false;
            this.col_Month_TotalSale.OptionsColumn.AllowFocus = false;
            this.col_Month_TotalSale.OptionsColumn.ReadOnly = true;
            this.col_Month_TotalSale.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalSale", "{0:#,#.####}")});
            this.col_Month_TotalSale.Visible = true;
            this.col_Month_TotalSale.VisibleIndex = 8;
            this.col_Month_TotalSale.Width = 146;
            // 
            // col_Month_TotalBuy
            // 
            this.col_Month_TotalBuy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_TotalBuy.AppearanceHeader.Options.UseFont = true;
            this.col_Month_TotalBuy.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Month_TotalBuy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Month_TotalBuy.Caption = "Tổng tiền mua";
            this.col_Month_TotalBuy.DisplayFormat.FormatString = "#,#.####";
            this.col_Month_TotalBuy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Month_TotalBuy.FieldName = "TotalBuy";
            this.col_Month_TotalBuy.Name = "col_Month_TotalBuy";
            this.col_Month_TotalBuy.OptionsColumn.AllowEdit = false;
            this.col_Month_TotalBuy.OptionsColumn.AllowFocus = false;
            this.col_Month_TotalBuy.OptionsColumn.ReadOnly = true;
            this.col_Month_TotalBuy.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalBuy", "{0:#,#.####}")});
            this.col_Month_TotalBuy.Visible = true;
            this.col_Month_TotalBuy.VisibleIndex = 7;
            this.col_Month_TotalBuy.Width = 146;
            // 
            // col_Month_ItemCode
            // 
            this.col_Month_ItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_ItemCode.AppearanceHeader.Options.UseFont = true;
            this.col_Month_ItemCode.Caption = "Mã Thuốc";
            this.col_Month_ItemCode.FieldName = "ItemCode";
            this.col_Month_ItemCode.Name = "col_Month_ItemCode";
            this.col_Month_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_Month_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_Month_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_Month_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Khoản :")});
            this.col_Month_ItemCode.Visible = true;
            this.col_Month_ItemCode.VisibleIndex = 3;
            this.col_Month_ItemCode.Width = 100;
            // 
            // col_Month_ItemName
            // 
            this.col_Month_ItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_ItemName.AppearanceHeader.Options.UseFont = true;
            this.col_Month_ItemName.Caption = "Thuốc";
            this.col_Month_ItemName.FieldName = "ItemName";
            this.col_Month_ItemName.Name = "col_Month_ItemName";
            this.col_Month_ItemName.OptionsColumn.AllowEdit = false;
            this.col_Month_ItemName.OptionsColumn.AllowFocus = false;
            this.col_Month_ItemName.OptionsColumn.ReadOnly = true;
            this.col_Month_ItemName.Visible = true;
            this.col_Month_ItemName.VisibleIndex = 4;
            this.col_Month_ItemName.Width = 123;
            // 
            // col_Month_TotalInterest
            // 
            this.col_Month_TotalInterest.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_TotalInterest.AppearanceHeader.Options.UseFont = true;
            this.col_Month_TotalInterest.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Month_TotalInterest.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Month_TotalInterest.Caption = "Lãi suất";
            this.col_Month_TotalInterest.DisplayFormat.FormatString = "#,#.###";
            this.col_Month_TotalInterest.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Month_TotalInterest.FieldName = "TotalInterest";
            this.col_Month_TotalInterest.Name = "col_Month_TotalInterest";
            this.col_Month_TotalInterest.OptionsColumn.AllowEdit = false;
            this.col_Month_TotalInterest.OptionsColumn.AllowFocus = false;
            this.col_Month_TotalInterest.OptionsColumn.ReadOnly = true;
            this.col_Month_TotalInterest.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInterest", "{0:#,#.####}")});
            this.col_Month_TotalInterest.Visible = true;
            this.col_Month_TotalInterest.VisibleIndex = 9;
            this.col_Month_TotalInterest.Width = 140;
            // 
            // col_Month_ItemCategoryName
            // 
            this.col_Month_ItemCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_ItemCategoryName.AppearanceHeader.Options.UseFont = true;
            this.col_Month_ItemCategoryName.Caption = "Loại";
            this.col_Month_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_Month_ItemCategoryName.Name = "col_Month_ItemCategoryName";
            this.col_Month_ItemCategoryName.OptionsColumn.AllowEdit = false;
            this.col_Month_ItemCategoryName.OptionsColumn.AllowFocus = false;
            this.col_Month_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.col_Month_ItemCategoryName.Visible = true;
            this.col_Month_ItemCategoryName.VisibleIndex = 2;
            this.col_Month_ItemCategoryName.Width = 146;
            // 
            // col_Month_GroupName
            // 
            this.col_Month_GroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_GroupName.AppearanceHeader.Options.UseFont = true;
            this.col_Month_GroupName.Caption = "Nhóm";
            this.col_Month_GroupName.FieldName = "GroupName";
            this.col_Month_GroupName.Name = "col_Month_GroupName";
            this.col_Month_GroupName.OptionsColumn.AllowEdit = false;
            this.col_Month_GroupName.OptionsColumn.AllowFocus = false;
            this.col_Month_GroupName.OptionsColumn.ReadOnly = true;
            this.col_Month_GroupName.Visible = true;
            this.col_Month_GroupName.VisibleIndex = 1;
            this.col_Month_GroupName.Width = 134;
            // 
            // col_Month_UnitOfMeasureName
            // 
            this.col_Month_UnitOfMeasureName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_UnitOfMeasureName.AppearanceHeader.Options.UseFont = true;
            this.col_Month_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Month_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Month_UnitOfMeasureName.Caption = "ĐVT";
            this.col_Month_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_Month_UnitOfMeasureName.Name = "col_Month_UnitOfMeasureName";
            this.col_Month_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.col_Month_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.col_Month_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.col_Month_UnitOfMeasureName.Visible = true;
            this.col_Month_UnitOfMeasureName.VisibleIndex = 5;
            // 
            // col_Month_QuantityExport
            // 
            this.col_Month_QuantityExport.AppearanceCell.Options.UseTextOptions = true;
            this.col_Month_QuantityExport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Month_QuantityExport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Month_QuantityExport.AppearanceHeader.Options.UseFont = true;
            this.col_Month_QuantityExport.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Month_QuantityExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Month_QuantityExport.Caption = "Số lượng";
            this.col_Month_QuantityExport.DisplayFormat.FormatString = "#,###.##";
            this.col_Month_QuantityExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Month_QuantityExport.FieldName = "QuantityExport";
            this.col_Month_QuantityExport.Name = "col_Month_QuantityExport";
            this.col_Month_QuantityExport.OptionsColumn.AllowEdit = false;
            this.col_Month_QuantityExport.OptionsColumn.AllowFocus = false;
            this.col_Month_QuantityExport.OptionsColumn.ReadOnly = true;
            this.col_Month_QuantityExport.Visible = true;
            this.col_Month_QuantityExport.VisibleIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.butPrintGrid);
            this.panelControl3.Controls.Add(this.dtNgayMonth);
            this.panelControl3.Controls.Add(this.butPrintTHMonth);
            this.panelControl3.Controls.Add(this.butCountTHMonth);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 20);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(995, 40);
            this.panelControl3.TabIndex = 3;
            // 
            // butPrintGrid
            // 
            this.butPrintGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butPrintGrid.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrintGrid.Image = ((System.Drawing.Image)(resources.GetObject("butPrintGrid.Image")));
            this.butPrintGrid.Location = new System.Drawing.Point(834, 6);
            this.butPrintGrid.Name = "butPrintGrid";
            this.butPrintGrid.Size = new System.Drawing.Size(89, 26);
            this.butPrintGrid.TabIndex = 1051;
            this.butPrintGrid.Text = "In theo Grid";
            this.butPrintGrid.Click += new System.EventHandler(this.butPrintGrid_Click);
            // 
            // dtNgayMonth
            // 
            this.dtNgayMonth.Location = new System.Drawing.Point(3, 6);
            this.dtNgayMonth.Name = "dtNgayMonth";
            this.dtNgayMonth.Size = new System.Drawing.Size(640, 25);
            this.dtNgayMonth.TabIndex = 6;
            // 
            // butPrintTHMonth
            // 
            this.butPrintTHMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrintTHMonth.Image = ((System.Drawing.Image)(resources.GetObject("butPrintTHMonth.Image")));
            this.butPrintTHMonth.Location = new System.Drawing.Point(752, 6);
            this.butPrintTHMonth.Name = "butPrintTHMonth";
            this.butPrintTHMonth.Size = new System.Drawing.Size(81, 26);
            this.butPrintTHMonth.TabIndex = 5;
            this.butPrintTHMonth.Text = "In";
            this.butPrintTHMonth.Click += new System.EventHandler(this.butPrintTHMonth_Click);
            // 
            // butCountTHMonth
            // 
            this.butCountTHMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCountTHMonth.Image = ((System.Drawing.Image)(resources.GetObject("butCountTHMonth.Image")));
            this.butCountTHMonth.Location = new System.Drawing.Point(649, 6);
            this.butCountTHMonth.Name = "butCountTHMonth";
            this.butCountTHMonth.Size = new System.Drawing.Size(102, 26);
            this.butCountTHMonth.TabIndex = 4;
            this.butCountTHMonth.Text = "Lấy dữ liệu";
            this.butCountTHMonth.Click += new System.EventHandler(this.butCountTHMonth_Click);
            // 
            // frmBaoCaoLaiSuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 526);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoLaiSuat";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thống kê doanh thu nhà thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ResultTHMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_ResultTHMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_ResultTHMonth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_ResultTHMonth;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_MM;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_TotalSale;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_TotalBuy;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_TotalInterest;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Month_QuantityExport;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton butPrintGrid;
        private UserControlDateTimes.UserControlDateTimes dtNgayMonth;
        private DevExpress.XtraEditors.SimpleButton butPrintTHMonth;
        private DevExpress.XtraEditors.SimpleButton butCountTHMonth;
    }
}