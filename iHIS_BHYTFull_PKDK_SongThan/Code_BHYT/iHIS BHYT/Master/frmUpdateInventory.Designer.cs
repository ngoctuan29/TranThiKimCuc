namespace Ps.Clinic.Master
{
    partial class frmUpdateInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateInventory));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Detail = new DevExpress.XtraGrid.GridControl();
            this.gridView_Detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Details_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_WarehousingCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Item = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Details_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_UnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_UoM = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ref_view_UoM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_UoM_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_UoM_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_BHYTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_SalesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_Tax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_Scot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_TotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_Shipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Details_Check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Check = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Search = new DevExpress.XtraGrid.GridControl();
            this.gridView_Search = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_search_WarehousingCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Search_ImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Search_Seri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Search_InvoiceNnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Search_VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Search_RepositoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Search_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_chk_Status = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_Search_RepositoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.butSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_view_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Check)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_chk_Status)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupControl3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(376, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 600);
            this.panel2.TabIndex = 4;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl3.Controls.Add(this.gridControl_Detail);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(648, 600);
            this.groupControl3.TabIndex = 31;
            this.groupControl3.Text = "Chi tiết phiếu nhập";
            // 
            // gridControl_Detail
            // 
            this.gridControl_Detail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Detail.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Detail.MainView = this.gridView_Detail;
            this.gridControl_Detail.Name = "gridControl_Detail";
            this.gridControl_Detail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_Item,
            this.ref_UoM,
            this.ref_Check});
            this.gridControl_Detail.Size = new System.Drawing.Size(644, 578);
            this.gridControl_Detail.TabIndex = 16;
            this.gridControl_Detail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Detail});
            // 
            // gridView_Detail
            // 
            this.gridView_Detail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Details_RowID,
            this.col_Details_WarehousingCode,
            this.col_Details_ItemCode,
            this.col_Details_Active,
            this.col_Details_UnitOfMeasure,
            this.col_Details_Quantity,
            this.col_Details_UnitPrice,
            this.col_Details_BHYTPrice,
            this.col_Details_SalesPrice,
            this.col_Details_Amount,
            this.col_Details_Tax,
            this.col_Details_Scot,
            this.col_Details_TotalTax,
            this.col_Details_DateEnd,
            this.col_Details_Shipment,
            this.col_Details_Check});
            this.gridView_Detail.GridControl = this.gridControl_Detail;
            this.gridView_Detail.Name = "gridView_Detail";
            this.gridView_Detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsView.ColumnAutoWidth = false;
            this.gridView_Detail.OptionsView.ShowFooter = true;
            this.gridView_Detail.OptionsView.ShowGroupPanel = false;
            this.gridView_Detail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Detail_ValidateRow);
            this.gridView_Detail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_Detail_ValidatingEditor);
            // 
            // col_Details_RowID
            // 
            this.col_Details_RowID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_Details_RowID.AppearanceCell.Options.UseFont = true;
            this.col_Details_RowID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_Details_RowID.AppearanceHeader.Options.UseFont = true;
            this.col_Details_RowID.Caption = "RowID";
            this.col_Details_RowID.FieldName = "RowID";
            this.col_Details_RowID.Name = "col_Details_RowID";
            this.col_Details_RowID.OptionsColumn.AllowMove = false;
            // 
            // col_Details_WarehousingCode
            // 
            this.col_Details_WarehousingCode.Caption = "Code";
            this.col_Details_WarehousingCode.FieldName = "WarehousingCode";
            this.col_Details_WarehousingCode.Name = "col_Details_WarehousingCode";
            // 
            // col_Details_ItemCode
            // 
            this.col_Details_ItemCode.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.col_Details_ItemCode.AppearanceHeader.BorderColor = System.Drawing.Color.White;
            this.col_Details_ItemCode.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.col_Details_ItemCode.AppearanceHeader.Options.UseBackColor = true;
            this.col_Details_ItemCode.AppearanceHeader.Options.UseForeColor = true;
            this.col_Details_ItemCode.Caption = "Thuốc - vật tư y tế";
            this.col_Details_ItemCode.ColumnEdit = this.ref_Item;
            this.col_Details_ItemCode.FieldName = "ItemCode";
            this.col_Details_ItemCode.Name = "col_Details_ItemCode";
            this.col_Details_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_Details_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_Details_ItemCode.OptionsColumn.AllowMove = false;
            this.col_Details_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_Details_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Count : {0:#,#}")});
            this.col_Details_ItemCode.Visible = true;
            this.col_Details_ItemCode.VisibleIndex = 0;
            this.col_Details_ItemCode.Width = 178;
            // 
            // ref_Item
            // 
            this.ref_Item.AutoHeight = false;
            this.ref_Item.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ref_Item.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Item.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemCode", "Mã thuốc", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Tên thuốc - vật tư y tế"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Active", "Hoạt chất"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureName", "ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemCategoryName", "Loại", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BHYTPrice", "Giá BHYT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitPrice", "Giá", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SafelyQuantity", "Số lượng", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureCode", "Mã ĐVT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.ref_Item.Name = "ref_Item";
            this.ref_Item.NullText = "...";
            this.ref_Item.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // col_Details_Active
            // 
            this.col_Details_Active.AppearanceHeader.Options.UseFont = true;
            this.col_Details_Active.Caption = "Hoạt chất";
            this.col_Details_Active.FieldName = "Active";
            this.col_Details_Active.Name = "col_Details_Active";
            // 
            // col_Details_UnitOfMeasure
            // 
            this.col_Details_UnitOfMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_UnitOfMeasure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_UnitOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_UnitOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_UnitOfMeasure.Caption = "ĐVT";
            this.col_Details_UnitOfMeasure.ColumnEdit = this.ref_UoM;
            this.col_Details_UnitOfMeasure.FieldName = "UnitOfMeasureCode";
            this.col_Details_UnitOfMeasure.Name = "col_Details_UnitOfMeasure";
            this.col_Details_UnitOfMeasure.OptionsColumn.AllowMove = false;
            this.col_Details_UnitOfMeasure.OptionsColumn.AllowSize = false;
            this.col_Details_UnitOfMeasure.OptionsColumn.FixedWidth = true;
            this.col_Details_UnitOfMeasure.Visible = true;
            this.col_Details_UnitOfMeasure.VisibleIndex = 1;
            this.col_Details_UnitOfMeasure.Width = 60;
            // 
            // ref_UoM
            // 
            this.ref_UoM.AutoHeight = false;
            this.ref_UoM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_UoM.Name = "ref_UoM";
            this.ref_UoM.NullText = "...";
            this.ref_UoM.View = this.ref_view_UoM;
            // 
            // ref_view_UoM
            // 
            this.ref_view_UoM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_UoM_Code,
            this.view_UoM_Name});
            this.ref_view_UoM.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ref_view_UoM.Name = "ref_view_UoM";
            this.ref_view_UoM.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ref_view_UoM.OptionsView.ShowGroupPanel = false;
            // 
            // view_UoM_Code
            // 
            this.view_UoM_Code.Caption = "Mã ĐVT";
            this.view_UoM_Code.FieldName = "UnitOfMeasureCode";
            this.view_UoM_Code.Name = "view_UoM_Code";
            // 
            // view_UoM_Name
            // 
            this.view_UoM_Name.Caption = "Tên ĐVT";
            this.view_UoM_Name.FieldName = "UnitOfMeasureName";
            this.view_UoM_Name.Name = "view_UoM_Name";
            this.view_UoM_Name.Visible = true;
            this.view_UoM_Name.VisibleIndex = 0;
            // 
            // col_Details_Quantity
            // 
            this.col_Details_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_Quantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_Quantity.Caption = "Số lượng";
            this.col_Details_Quantity.DisplayFormat.FormatString = "#,#";
            this.col_Details_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_Quantity.FieldName = "Quantity";
            this.col_Details_Quantity.Name = "col_Details_Quantity";
            this.col_Details_Quantity.OptionsColumn.AllowMove = false;
            this.col_Details_Quantity.OptionsColumn.AllowSize = false;
            this.col_Details_Quantity.OptionsColumn.FixedWidth = true;
            this.col_Details_Quantity.Visible = true;
            this.col_Details_Quantity.VisibleIndex = 2;
            this.col_Details_Quantity.Width = 60;
            // 
            // col_Details_UnitPrice
            // 
            this.col_Details_UnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_UnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_UnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_UnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_UnitPrice.Caption = "Giá mua";
            this.col_Details_UnitPrice.DisplayFormat.FormatString = "#,#.#";
            this.col_Details_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_UnitPrice.FieldName = "UnitPrice";
            this.col_Details_UnitPrice.GroupFormat.FormatString = "#,#";
            this.col_Details_UnitPrice.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_UnitPrice.Name = "col_Details_UnitPrice";
            this.col_Details_UnitPrice.OptionsColumn.AllowMove = false;
            this.col_Details_UnitPrice.OptionsColumn.AllowSize = false;
            this.col_Details_UnitPrice.OptionsColumn.FixedWidth = true;
            this.col_Details_UnitPrice.Visible = true;
            this.col_Details_UnitPrice.VisibleIndex = 3;
            this.col_Details_UnitPrice.Width = 100;
            // 
            // col_Details_BHYTPrice
            // 
            this.col_Details_BHYTPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_BHYTPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_BHYTPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_BHYTPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_BHYTPrice.Caption = "Giá BHYT";
            this.col_Details_BHYTPrice.DisplayFormat.FormatString = "#,#";
            this.col_Details_BHYTPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_BHYTPrice.FieldName = "BHYTPrice";
            this.col_Details_BHYTPrice.Name = "col_Details_BHYTPrice";
            this.col_Details_BHYTPrice.Visible = true;
            this.col_Details_BHYTPrice.VisibleIndex = 4;
            this.col_Details_BHYTPrice.Width = 88;
            // 
            // col_Details_SalesPrice
            // 
            this.col_Details_SalesPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_SalesPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_SalesPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_SalesPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_SalesPrice.Caption = "Giá dịch vụ";
            this.col_Details_SalesPrice.DisplayFormat.FormatString = "#,#.#";
            this.col_Details_SalesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_SalesPrice.FieldName = "SalesPrice";
            this.col_Details_SalesPrice.GroupFormat.FormatString = "#,#";
            this.col_Details_SalesPrice.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_SalesPrice.Name = "col_Details_SalesPrice";
            this.col_Details_SalesPrice.OptionsColumn.AllowMove = false;
            this.col_Details_SalesPrice.OptionsColumn.AllowSize = false;
            this.col_Details_SalesPrice.OptionsColumn.FixedWidth = true;
            this.col_Details_SalesPrice.Visible = true;
            this.col_Details_SalesPrice.VisibleIndex = 5;
            this.col_Details_SalesPrice.Width = 100;
            // 
            // col_Details_Amount
            // 
            this.col_Details_Amount.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_Amount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_Amount.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_Amount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_Amount.Caption = "Thành tiền";
            this.col_Details_Amount.DisplayFormat.FormatString = "#,#.#";
            this.col_Details_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_Amount.FieldName = "Amount";
            this.col_Details_Amount.GroupFormat.FormatString = "#,#";
            this.col_Details_Amount.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_Amount.Name = "col_Details_Amount";
            this.col_Details_Amount.OptionsColumn.AllowMove = false;
            this.col_Details_Amount.OptionsColumn.AllowSize = false;
            this.col_Details_Amount.OptionsColumn.FixedWidth = true;
            this.col_Details_Amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Sum:{0:#,#.##}")});
            this.col_Details_Amount.Visible = true;
            this.col_Details_Amount.VisibleIndex = 6;
            this.col_Details_Amount.Width = 100;
            // 
            // col_Details_Tax
            // 
            this.col_Details_Tax.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_Tax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_Tax.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_Tax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_Tax.Caption = "Chiết khấu (%)";
            this.col_Details_Tax.DisplayFormat.FormatString = "#,#.##";
            this.col_Details_Tax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_Tax.FieldName = "Tax";
            this.col_Details_Tax.Name = "col_Details_Tax";
            this.col_Details_Tax.OptionsColumn.AllowMove = false;
            this.col_Details_Tax.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_Details_Tax.OptionsColumn.FixedWidth = true;
            this.col_Details_Tax.Visible = true;
            this.col_Details_Tax.VisibleIndex = 7;
            this.col_Details_Tax.Width = 91;
            // 
            // col_Details_Scot
            // 
            this.col_Details_Scot.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_Scot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_Scot.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_Scot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_Scot.Caption = "Tiền VAT";
            this.col_Details_Scot.DisplayFormat.FormatString = "#,#.#";
            this.col_Details_Scot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_Scot.FieldName = "Scot";
            this.col_Details_Scot.Name = "col_Details_Scot";
            this.col_Details_Scot.OptionsColumn.AllowEdit = false;
            this.col_Details_Scot.OptionsColumn.AllowFocus = false;
            this.col_Details_Scot.OptionsColumn.AllowMove = false;
            this.col_Details_Scot.OptionsColumn.AllowSize = false;
            this.col_Details_Scot.OptionsColumn.FixedWidth = true;
            this.col_Details_Scot.OptionsColumn.ReadOnly = true;
            this.col_Details_Scot.Visible = true;
            this.col_Details_Scot.VisibleIndex = 8;
            this.col_Details_Scot.Width = 100;
            // 
            // col_Details_TotalTax
            // 
            this.col_Details_TotalTax.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_TotalTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_TotalTax.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_TotalTax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_TotalTax.Caption = "Tổng tiền (VAT)";
            this.col_Details_TotalTax.DisplayFormat.FormatString = "#,#.#";
            this.col_Details_TotalTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Details_TotalTax.FieldName = "TotalTax";
            this.col_Details_TotalTax.Name = "col_Details_TotalTax";
            this.col_Details_TotalTax.OptionsColumn.AllowEdit = false;
            this.col_Details_TotalTax.OptionsColumn.AllowFocus = false;
            this.col_Details_TotalTax.OptionsColumn.AllowMove = false;
            this.col_Details_TotalTax.OptionsColumn.AllowSize = false;
            this.col_Details_TotalTax.OptionsColumn.FixedWidth = true;
            this.col_Details_TotalTax.OptionsColumn.ReadOnly = true;
            this.col_Details_TotalTax.Visible = true;
            this.col_Details_TotalTax.VisibleIndex = 9;
            this.col_Details_TotalTax.Width = 100;
            // 
            // col_Details_DateEnd
            // 
            this.col_Details_DateEnd.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_DateEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_DateEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_DateEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_DateEnd.Caption = "Date End";
            this.col_Details_DateEnd.DisplayFormat.FormatString = "MM/yyyy";
            this.col_Details_DateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_Details_DateEnd.FieldName = "DateEnd";
            this.col_Details_DateEnd.Name = "col_Details_DateEnd";
            this.col_Details_DateEnd.OptionsColumn.AllowMove = false;
            this.col_Details_DateEnd.OptionsColumn.AllowSize = false;
            this.col_Details_DateEnd.OptionsColumn.FixedWidth = true;
            this.col_Details_DateEnd.Visible = true;
            this.col_Details_DateEnd.VisibleIndex = 10;
            this.col_Details_DateEnd.Width = 60;
            // 
            // col_Details_Shipment
            // 
            this.col_Details_Shipment.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_Shipment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_Shipment.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_Shipment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Details_Shipment.Caption = "Lot No";
            this.col_Details_Shipment.FieldName = "Shipment";
            this.col_Details_Shipment.Name = "col_Details_Shipment";
            this.col_Details_Shipment.OptionsColumn.AllowSize = false;
            this.col_Details_Shipment.OptionsColumn.FixedWidth = true;
            this.col_Details_Shipment.Visible = true;
            this.col_Details_Shipment.VisibleIndex = 11;
            this.col_Details_Shipment.Width = 86;
            // 
            // col_Details_Check
            // 
            this.col_Details_Check.AppearanceCell.Options.UseTextOptions = true;
            this.col_Details_Check.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_Check.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Details_Check.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Details_Check.Caption = "Chọn";
            this.col_Details_Check.ColumnEdit = this.ref_Check;
            this.col_Details_Check.FieldName = "Check";
            this.col_Details_Check.Name = "col_Details_Check";
            this.col_Details_Check.Width = 38;
            // 
            // ref_Check
            // 
            this.ref_Check.AutoHeight = false;
            this.ref_Check.DisplayValueChecked = "1";
            this.ref_Check.DisplayValueGrayed = "0";
            this.ref_Check.DisplayValueUnchecked = "0";
            this.ref_Check.Name = "ref_Check";
            this.ref_Check.ValueChecked = 1;
            this.ref_Check.ValueGrayed = "0";
            this.ref_Check.ValueUnchecked = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 600);
            this.panel1.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gridControl_Search);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 39);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(376, 561);
            this.groupControl2.TabIndex = 30;
            this.groupControl2.Text = "Danh sách phiếu nhập";
            // 
            // gridControl_Search
            // 
            this.gridControl_Search.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Search.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Search.MainView = this.gridView_Search;
            this.gridControl_Search.Name = "gridControl_Search";
            this.gridControl_Search.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_chk_Status});
            this.gridControl_Search.Size = new System.Drawing.Size(372, 539);
            this.gridControl_Search.TabIndex = 2;
            this.gridControl_Search.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Search});
            // 
            // gridView_Search
            // 
            this.gridView_Search.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Search.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_search_WarehousingCode,
            this.col_Search_ImportDate,
            this.col_Search_Seri,
            this.col_Search_InvoiceNnumber,
            this.col_Search_VendorName,
            this.col_Search_RepositoryName,
            this.col_Search_Status,
            this.col_Search_RepositoryCode});
            this.gridView_Search.GridControl = this.gridControl_Search;
            this.gridView_Search.Name = "gridView_Search";
            this.gridView_Search.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Search.OptionsBehavior.Editable = false;
            this.gridView_Search.OptionsBehavior.ReadOnly = true;
            this.gridView_Search.OptionsCustomization.AllowFilter = false;
            this.gridView_Search.OptionsCustomization.AllowGroup = false;
            this.gridView_Search.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_Search.OptionsView.ColumnAutoWidth = false;
            this.gridView_Search.OptionsView.ShowGroupPanel = false;
            this.gridView_Search.Click += new System.EventHandler(this.gridView_Search_Click);
            // 
            // col_search_WarehousingCode
            // 
            this.col_search_WarehousingCode.Caption = "Số phiếu";
            this.col_search_WarehousingCode.FieldName = "WarehousingCode";
            this.col_search_WarehousingCode.Name = "col_search_WarehousingCode";
            this.col_search_WarehousingCode.OptionsColumn.AllowEdit = false;
            this.col_search_WarehousingCode.OptionsColumn.ReadOnly = true;
            this.col_search_WarehousingCode.Visible = true;
            this.col_search_WarehousingCode.VisibleIndex = 0;
            this.col_search_WarehousingCode.Width = 99;
            // 
            // col_Search_ImportDate
            // 
            this.col_Search_ImportDate.Caption = "Ngày nhập";
            this.col_Search_ImportDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_Search_ImportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_Search_ImportDate.FieldName = "ImportDate";
            this.col_Search_ImportDate.Name = "col_Search_ImportDate";
            this.col_Search_ImportDate.OptionsColumn.AllowEdit = false;
            this.col_Search_ImportDate.OptionsColumn.ReadOnly = true;
            this.col_Search_ImportDate.Visible = true;
            this.col_Search_ImportDate.VisibleIndex = 1;
            this.col_Search_ImportDate.Width = 72;
            // 
            // col_Search_Seri
            // 
            this.col_Search_Seri.Caption = "Seri";
            this.col_Search_Seri.FieldName = "Seri";
            this.col_Search_Seri.Name = "col_Search_Seri";
            this.col_Search_Seri.Width = 39;
            // 
            // col_Search_InvoiceNnumber
            // 
            this.col_Search_InvoiceNnumber.Caption = "Số hóa đơn";
            this.col_Search_InvoiceNnumber.FieldName = "InvoiceNnumber";
            this.col_Search_InvoiceNnumber.Name = "col_Search_InvoiceNnumber";
            this.col_Search_InvoiceNnumber.Width = 149;
            // 
            // col_Search_VendorName
            // 
            this.col_Search_VendorName.Caption = "Nhà cung cấp";
            this.col_Search_VendorName.FieldName = "VendorName";
            this.col_Search_VendorName.Name = "col_Search_VendorName";
            this.col_Search_VendorName.Width = 105;
            // 
            // col_Search_RepositoryName
            // 
            this.col_Search_RepositoryName.Caption = "Kho nhập";
            this.col_Search_RepositoryName.FieldName = "RepositoryName";
            this.col_Search_RepositoryName.Name = "col_Search_RepositoryName";
            this.col_Search_RepositoryName.OptionsColumn.AllowEdit = false;
            this.col_Search_RepositoryName.OptionsColumn.ReadOnly = true;
            this.col_Search_RepositoryName.Visible = true;
            this.col_Search_RepositoryName.VisibleIndex = 2;
            this.col_Search_RepositoryName.Width = 126;
            // 
            // col_Search_Status
            // 
            this.col_Search_Status.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Search_Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Search_Status.Caption = "Cập nhật kho";
            this.col_Search_Status.ColumnEdit = this.rep_chk_Status;
            this.col_Search_Status.FieldName = "Status";
            this.col_Search_Status.Name = "col_Search_Status";
            this.col_Search_Status.OptionsColumn.AllowEdit = false;
            this.col_Search_Status.OptionsColumn.ReadOnly = true;
            this.col_Search_Status.Visible = true;
            this.col_Search_Status.VisibleIndex = 3;
            this.col_Search_Status.Width = 78;
            // 
            // rep_chk_Status
            // 
            this.rep_chk_Status.AutoHeight = false;
            this.rep_chk_Status.DisplayValueChecked = "1";
            this.rep_chk_Status.DisplayValueGrayed = "0";
            this.rep_chk_Status.DisplayValueUnchecked = "0";
            this.rep_chk_Status.Name = "rep_chk_Status";
            this.rep_chk_Status.ValueChecked = 1;
            this.rep_chk_Status.ValueGrayed = 0;
            this.rep_chk_Status.ValueUnchecked = 0;
            // 
            // col_Search_RepositoryCode
            // 
            this.col_Search_RepositoryCode.Caption = "RepositoryCode";
            this.col_Search_RepositoryCode.FieldName = "RepositoryCode";
            this.col_Search_RepositoryCode.Name = "col_Search_RepositoryCode";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelControl16);
            this.panel3.Controls.Add(this.dtto);
            this.panel3.Controls.Add(this.butSearch);
            this.panel3.Controls.Add(this.dtfrom);
            this.panel3.Controls.Add(this.labelControl17);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 39);
            this.panel3.TabIndex = 29;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(3, 12);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(47, 13);
            this.labelControl16.TabIndex = 26;
            this.labelControl16.Text = "Từ ngày :";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd/MM/yyyy";
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(199, 9);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(93, 21);
            this.dtto.TabIndex = 27;
            // 
            // butSearch
            // 
            this.butSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSearch.Image = ((System.Drawing.Image)(resources.GetObject("butSearch.Image")));
            this.butSearch.Location = new System.Drawing.Point(293, 8);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(77, 23);
            this.butSearch.TabIndex = 24;
            this.butSearch.Text = "Tìm kiếm";
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "dd/MM/yyyy";
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(53, 9);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(86, 21);
            this.dtfrom.TabIndex = 28;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(142, 12);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(54, 13);
            this.labelControl17.TabIndex = 25;
            this.labelControl17.Text = "Đến ngày :";
            // 
            // frmUpdateInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpdateInventory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh sách thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUpdateInventory_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_view_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Check)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_chk_Status)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.DateTimePicker dtto;
        private DevExpress.XtraEditors.SimpleButton butSearch;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl_Search;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Search;
        private DevExpress.XtraGrid.Columns.GridColumn col_search_WarehousingCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_ImportDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_Seri;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_InvoiceNnumber;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_VendorName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_RepositoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_chk_Status;
        private DevExpress.XtraGrid.GridControl gridControl_Detail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_WarehousingCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_ItemCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Item;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Active;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_UnitOfMeasure;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ref_UoM;
        private DevExpress.XtraGrid.Views.Grid.GridView ref_view_UoM;
        private DevExpress.XtraGrid.Columns.GridColumn view_UoM_Code;
        private DevExpress.XtraGrid.Columns.GridColumn view_UoM_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_SalesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Tax;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Scot;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_TotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_DateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Shipment;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_Check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ref_Check;
        private DevExpress.XtraGrid.Columns.GridColumn col_Search_RepositoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Details_BHYTPrice;
    }
}