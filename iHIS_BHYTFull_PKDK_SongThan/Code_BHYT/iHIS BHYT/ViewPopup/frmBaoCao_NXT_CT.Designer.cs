namespace Ps.Clinic.ViewPopup
{
    partial class frmBaoCao_NXT_CT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao_NXT_CT));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountBegin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountImportTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TotalQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountRepaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountRepaidVen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Shipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_BHYTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SalesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkQuantity = new DevExpress.XtraEditors.CheckEdit();
            this.lkupItem = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_lkupItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_lkupItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay = new UserControlDateTimes.UserControlDateTimes();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.butPrintBC = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.Controls.Add(this.gridControl_Result);
            this.grMain.Controls.Add(this.panelControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1314, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Báo cáo";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(2, 56);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(1310, 468);
            this.gridControl_Result.TabIndex = 1;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCode,
            this.col_ItemName,
            this.col_UnitOfMeasureName,
            this.col_AmountBegin,
            this.col_AmountImport,
            this.col_AmountImportTransfer,
            this.col_TotalQuantity,
            this.col_AmountTransfer,
            this.col_AmountExport,
            this.col_AmountRepaid,
            this.col_AmountRepaidVen,
            this.col_AmountEnd,
            this.col_ItemCategoryName,
            this.col_DateEnd,
            this.col_Shipment,
            this.col_BHYTPrice,
            this.col_SalesPrice,
            this.col_GroupName,
            this.col_UnitPrice});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCode.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 2;
            this.col_ItemCode.Width = 90;
            // 
            // col_ItemName
            // 
            this.col_ItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemName.Caption = "Tên thuốc - vtyt";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.OptionsColumn.AllowEdit = false;
            this.col_ItemName.OptionsColumn.AllowFocus = false;
            this.col_ItemName.OptionsColumn.ReadOnly = true;
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 3;
            this.col_ItemName.Width = 232;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseFont = true;
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.Caption = "ĐVT";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.col_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.col_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 4;
            this.col_UnitOfMeasureName.Width = 70;
            // 
            // col_AmountBegin
            // 
            this.col_AmountBegin.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountBegin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountBegin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountBegin.AppearanceHeader.Options.UseFont = true;
            this.col_AmountBegin.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountBegin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountBegin.Caption = "Tồn đầu";
            this.col_AmountBegin.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountBegin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountBegin.FieldName = "TotalQtyBegin";
            this.col_AmountBegin.Name = "col_AmountBegin";
            this.col_AmountBegin.OptionsColumn.AllowEdit = false;
            this.col_AmountBegin.OptionsColumn.AllowFocus = false;
            this.col_AmountBegin.OptionsColumn.ReadOnly = true;
            this.col_AmountBegin.Visible = true;
            this.col_AmountBegin.VisibleIndex = 5;
            this.col_AmountBegin.Width = 85;
            // 
            // col_AmountImport
            // 
            this.col_AmountImport.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountImport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountImport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountImport.AppearanceHeader.Options.UseFont = true;
            this.col_AmountImport.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountImport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountImport.Caption = "Nhập";
            this.col_AmountImport.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountImport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountImport.FieldName = "QtyImport";
            this.col_AmountImport.Name = "col_AmountImport";
            this.col_AmountImport.OptionsColumn.AllowEdit = false;
            this.col_AmountImport.OptionsColumn.AllowFocus = false;
            this.col_AmountImport.OptionsColumn.ReadOnly = true;
            this.col_AmountImport.Visible = true;
            this.col_AmountImport.VisibleIndex = 6;
            this.col_AmountImport.Width = 86;
            // 
            // col_AmountImportTransfer
            // 
            this.col_AmountImportTransfer.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountImportTransfer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountImportTransfer.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountImportTransfer.AppearanceHeader.Options.UseFont = true;
            this.col_AmountImportTransfer.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountImportTransfer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountImportTransfer.Caption = "Nhận C.Kho";
            this.col_AmountImportTransfer.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountImportTransfer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountImportTransfer.FieldName = "QtyImpTransfer";
            this.col_AmountImportTransfer.Name = "col_AmountImportTransfer";
            this.col_AmountImportTransfer.OptionsColumn.AllowEdit = false;
            this.col_AmountImportTransfer.OptionsColumn.AllowFocus = false;
            this.col_AmountImportTransfer.OptionsColumn.ReadOnly = true;
            this.col_AmountImportTransfer.Visible = true;
            this.col_AmountImportTransfer.VisibleIndex = 7;
            this.col_AmountImportTransfer.Width = 78;
            // 
            // col_TotalQuantity
            // 
            this.col_TotalQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_TotalQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_TotalQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_TotalQuantity.AppearanceHeader.Options.UseFont = true;
            this.col_TotalQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TotalQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_TotalQuantity.Caption = "Tổng";
            this.col_TotalQuantity.DisplayFormat.FormatString = "#,#.##";
            this.col_TotalQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TotalQuantity.FieldName = "TotalQuantity";
            this.col_TotalQuantity.Name = "col_TotalQuantity";
            this.col_TotalQuantity.OptionsColumn.AllowEdit = false;
            this.col_TotalQuantity.OptionsColumn.AllowFocus = false;
            this.col_TotalQuantity.OptionsColumn.ReadOnly = true;
            this.col_TotalQuantity.Visible = true;
            this.col_TotalQuantity.VisibleIndex = 8;
            this.col_TotalQuantity.Width = 90;
            // 
            // col_AmountTransfer
            // 
            this.col_AmountTransfer.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountTransfer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountTransfer.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountTransfer.AppearanceHeader.Options.UseFont = true;
            this.col_AmountTransfer.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountTransfer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountTransfer.Caption = "Chuyển kho";
            this.col_AmountTransfer.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountTransfer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountTransfer.FieldName = "QtyTransfer";
            this.col_AmountTransfer.Name = "col_AmountTransfer";
            this.col_AmountTransfer.OptionsColumn.AllowEdit = false;
            this.col_AmountTransfer.OptionsColumn.AllowFocus = false;
            this.col_AmountTransfer.OptionsColumn.ReadOnly = true;
            this.col_AmountTransfer.Visible = true;
            this.col_AmountTransfer.VisibleIndex = 9;
            this.col_AmountTransfer.Width = 91;
            // 
            // col_AmountExport
            // 
            this.col_AmountExport.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountExport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountExport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountExport.AppearanceHeader.Options.UseFont = true;
            this.col_AmountExport.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountExport.Caption = "Xuất BN";
            this.col_AmountExport.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountExport.FieldName = "QtyExport";
            this.col_AmountExport.Name = "col_AmountExport";
            this.col_AmountExport.OptionsColumn.AllowEdit = false;
            this.col_AmountExport.OptionsColumn.AllowFocus = false;
            this.col_AmountExport.OptionsColumn.ReadOnly = true;
            this.col_AmountExport.Visible = true;
            this.col_AmountExport.VisibleIndex = 10;
            this.col_AmountExport.Width = 84;
            // 
            // col_AmountRepaid
            // 
            this.col_AmountRepaid.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountRepaid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountRepaid.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountRepaid.AppearanceHeader.Options.UseFont = true;
            this.col_AmountRepaid.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountRepaid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountRepaid.Caption = "Trả kho";
            this.col_AmountRepaid.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountRepaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountRepaid.FieldName = "QtyRepaid";
            this.col_AmountRepaid.Name = "col_AmountRepaid";
            this.col_AmountRepaid.OptionsColumn.AllowEdit = false;
            this.col_AmountRepaid.OptionsColumn.AllowFocus = false;
            this.col_AmountRepaid.OptionsColumn.ReadOnly = true;
            this.col_AmountRepaid.Visible = true;
            this.col_AmountRepaid.VisibleIndex = 11;
            this.col_AmountRepaid.Width = 77;
            // 
            // col_AmountRepaidVen
            // 
            this.col_AmountRepaidVen.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountRepaidVen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountRepaidVen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountRepaidVen.AppearanceHeader.Options.UseFont = true;
            this.col_AmountRepaidVen.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountRepaidVen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountRepaidVen.Caption = "Trả NCC";
            this.col_AmountRepaidVen.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountRepaidVen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountRepaidVen.FieldName = "QtyRepaidVen";
            this.col_AmountRepaidVen.Name = "col_AmountRepaidVen";
            this.col_AmountRepaidVen.OptionsColumn.AllowEdit = false;
            this.col_AmountRepaidVen.OptionsColumn.AllowFocus = false;
            this.col_AmountRepaidVen.OptionsColumn.ReadOnly = true;
            this.col_AmountRepaidVen.Visible = true;
            this.col_AmountRepaidVen.VisibleIndex = 12;
            this.col_AmountRepaidVen.Width = 83;
            // 
            // col_AmountEnd
            // 
            this.col_AmountEnd.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountEnd.AppearanceHeader.Options.UseFont = true;
            this.col_AmountEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.Caption = "Tồn cuối";
            this.col_AmountEnd.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountEnd.FieldName = "TotalQuantityEnd";
            this.col_AmountEnd.Name = "col_AmountEnd";
            this.col_AmountEnd.OptionsColumn.AllowEdit = false;
            this.col_AmountEnd.OptionsColumn.AllowFocus = false;
            this.col_AmountEnd.OptionsColumn.ReadOnly = true;
            this.col_AmountEnd.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_AmountEnd.Visible = true;
            this.col_AmountEnd.VisibleIndex = 13;
            this.col_AmountEnd.Width = 85;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCategoryName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCategoryName.Caption = "Loại";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.OptionsColumn.AllowEdit = false;
            this.col_ItemCategoryName.OptionsColumn.AllowFocus = false;
            this.col_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 1;
            this.col_ItemCategoryName.Width = 169;
            // 
            // col_DateEnd
            // 
            this.col_DateEnd.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DateEnd.AppearanceHeader.Options.UseFont = true;
            this.col_DateEnd.Caption = "Hạn dùng";
            this.col_DateEnd.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_DateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_DateEnd.FieldName = "DateEnd";
            this.col_DateEnd.Name = "col_DateEnd";
            this.col_DateEnd.OptionsColumn.AllowEdit = false;
            this.col_DateEnd.OptionsColumn.AllowFocus = false;
            this.col_DateEnd.OptionsColumn.ReadOnly = true;
            this.col_DateEnd.Visible = true;
            this.col_DateEnd.VisibleIndex = 15;
            this.col_DateEnd.Width = 92;
            // 
            // col_Shipment
            // 
            this.col_Shipment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Shipment.AppearanceHeader.Options.UseFont = true;
            this.col_Shipment.Caption = "Lô";
            this.col_Shipment.FieldName = "Shipment";
            this.col_Shipment.Name = "col_Shipment";
            this.col_Shipment.OptionsColumn.AllowEdit = false;
            this.col_Shipment.OptionsColumn.AllowFocus = false;
            this.col_Shipment.OptionsColumn.ReadOnly = true;
            this.col_Shipment.Visible = true;
            this.col_Shipment.VisibleIndex = 16;
            this.col_Shipment.Width = 82;
            // 
            // col_BHYTPrice
            // 
            this.col_BHYTPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_BHYTPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_BHYTPrice.AppearanceHeader.Options.UseFont = true;
            this.col_BHYTPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_BHYTPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTPrice.Caption = "Giá BHYT";
            this.col_BHYTPrice.DisplayFormat.FormatString = "#,#.####";
            this.col_BHYTPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_BHYTPrice.FieldName = "UnitPrice";
            this.col_BHYTPrice.GroupFormat.FormatString = "{0:#,#.####}";
            this.col_BHYTPrice.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_BHYTPrice.Name = "col_BHYTPrice";
            this.col_BHYTPrice.OptionsColumn.AllowEdit = false;
            this.col_BHYTPrice.OptionsColumn.ReadOnly = true;
            this.col_BHYTPrice.Width = 95;
            // 
            // col_SalesPrice
            // 
            this.col_SalesPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_SalesPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SalesPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SalesPrice.AppearanceHeader.Options.UseFont = true;
            this.col_SalesPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SalesPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SalesPrice.Caption = "Giá Bán";
            this.col_SalesPrice.DisplayFormat.FormatString = "#,#.####";
            this.col_SalesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SalesPrice.FieldName = "SalesPrice";
            this.col_SalesPrice.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SalesPrice.Name = "col_SalesPrice";
            this.col_SalesPrice.OptionsColumn.AllowEdit = false;
            this.col_SalesPrice.OptionsColumn.AllowFocus = false;
            this.col_SalesPrice.OptionsColumn.ReadOnly = true;
            this.col_SalesPrice.Width = 89;
            // 
            // col_GroupName
            // 
            this.col_GroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GroupName.AppearanceHeader.Options.UseFont = true;
            this.col_GroupName.Caption = "Nhóm";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.OptionsColumn.AllowEdit = false;
            this.col_GroupName.OptionsColumn.AllowFocus = false;
            this.col_GroupName.OptionsColumn.ReadOnly = true;
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 0;
            this.col_GroupName.Width = 173;
            // 
            // col_UnitPrice
            // 
            this.col_UnitPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitPrice.AppearanceHeader.Options.UseFont = true;
            this.col_UnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.Caption = "Đơn giá";
            this.col_UnitPrice.DisplayFormat.FormatString = "#,#.####";
            this.col_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPrice.FieldName = "UnitPrice";
            this.col_UnitPrice.Name = "col_UnitPrice";
            this.col_UnitPrice.OptionsColumn.AllowEdit = false;
            this.col_UnitPrice.OptionsColumn.AllowFocus = false;
            this.col_UnitPrice.OptionsColumn.ReadOnly = true;
            this.col_UnitPrice.Visible = true;
            this.col_UnitPrice.VisibleIndex = 14;
            this.col_UnitPrice.Width = 83;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkQuantity);
            this.panelControl1.Controls.Add(this.lkupItem);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dtNgay);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lkupKho);
            this.panelControl1.Controls.Add(this.butPrintBC);
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Controls.Add(this.butCount);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1310, 36);
            this.panelControl1.TabIndex = 0;
            // 
            // chkQuantity
            // 
            this.chkQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkQuantity.Location = new System.Drawing.Point(997, 8);
            this.chkQuantity.Name = "chkQuantity";
            this.chkQuantity.Properties.Caption = "Tồn >0";
            this.chkQuantity.Size = new System.Drawing.Size(61, 19);
            this.chkQuantity.TabIndex = 20;
            // 
            // lkupItem
            // 
            this.lkupItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupItem.EditValue = "";
            this.lkupItem.Location = new System.Drawing.Point(874, 8);
            this.lkupItem.Name = "lkupItem";
            this.lkupItem.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkupItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupItem.Properties.NullText = "";
            this.lkupItem.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkupItem.Properties.View = this.searchLookUpEdit1View;
            this.lkupItem.Size = new System.Drawing.Size(117, 20);
            this.lkupItem.TabIndex = 19;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_lkupItemName,
            this.col_lkupItemCode});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // col_lkupItemName
            // 
            this.col_lkupItemName.Caption = "Thuốc - vtth";
            this.col_lkupItemName.FieldName = "ItemName";
            this.col_lkupItemName.Name = "col_lkupItemName";
            this.col_lkupItemName.Visible = true;
            this.col_lkupItemName.VisibleIndex = 0;
            // 
            // col_lkupItemCode
            // 
            this.col_lkupItemCode.Caption = "ItemCode";
            this.col_lkupItemCode.FieldName = "ItemCode";
            this.col_lkupItemCode.Name = "col_lkupItemCode";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(836, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Thuốc :";
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(3, 6);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(638, 25);
            this.dtNgay.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(647, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Kho :";
            // 
            // lkupKho
            // 
            this.lkupKho.EditValue = "";
            this.lkupKho.Location = new System.Drawing.Point(676, 8);
            this.lkupKho.Name = "lkupKho";
            this.lkupKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupKho.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryCode", "Mã kho", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryName", "Tên kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hide", "Hide", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryGroupCode", "GroupCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupKho.Properties.NullText = "Chọn Kho";
            this.lkupKho.Size = new System.Drawing.Size(157, 20);
            this.lkupKho.TabIndex = 11;
            this.lkupKho.EditValueChanged += new System.EventHandler(this.lkupKho_EditValueChanged);
            // 
            // butPrintBC
            // 
            this.butPrintBC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrintBC.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrintBC.Image = ((System.Drawing.Image)(resources.GetObject("butPrintBC.Image")));
            this.butPrintBC.Location = new System.Drawing.Point(1231, 6);
            this.butPrintBC.Name = "butPrintBC";
            this.butPrintBC.Size = new System.Drawing.Size(78, 23);
            this.butPrintBC.TabIndex = 5;
            this.butPrintBC.Text = "In báo cáo";
            this.butPrintBC.Click += new System.EventHandler(this.butPrintBC_Click);
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(1144, 6);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(86, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In theo Grid";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butCount
            // 
            this.butCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(1061, 6);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(82, 23);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Lấy dữ liệu";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // frmBaoCao_NXT_CT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 526);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao_NXT_CT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo nhập xuất tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoCao_NXT_CT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountBegin;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountImport;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountExport;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_Shipment;
        private DevExpress.XtraGrid.Columns.GridColumn col_BHYTPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_SalesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountRepaid;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountRepaidVen;
        private DevExpress.XtraGrid.Columns.GridColumn col_TotalQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountTransfer;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lkupItem;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UserControlDateTimes.UserControlDateTimes dtNgay;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraEditors.SimpleButton butPrintBC;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraGrid.Columns.GridColumn col_lkupItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_lkupItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountImportTransfer;
        private DevExpress.XtraEditors.CheckEdit chkQuantity;
    }
}