namespace Ps.Clinic.Master
{
    partial class frmThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuoc));
            this.gridControl_Item = new DevExpress.XtraGrid.GridControl();
            this.gridView_Item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UsageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemGridLookUpEdit_Usage = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ItemGridLookUpEditView_Usage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_UsageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_UsageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemGridLookUpEdit_UoM = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ItemGridLookUpEditView_UoM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_UoMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_UoM_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Packed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemGridLookUpEdit_Packed = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_Packed_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_QtyOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SalesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Unit_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_BHYTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemGridLookUpEdit_Item_Category = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ItemGridLookUpEditView_Item_Category = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_ItemCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_SafelyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ListBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit_ListBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_RepositoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Check_RepositoryCode = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.col_EmloyeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RateBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CountryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_Country = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchView_Country = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRepCountry_CountryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepCountry_CountryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProducerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_Producer = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchView_Producer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRefProduct_ProducerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefProduct_ProducerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefProduct_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DisparityPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ListService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit_ListService = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_VendorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Check_VendorCode = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.col_STTBCBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SODKGP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLKupItems_BHYT = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repViewLKupItems_BHYT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemBHYT_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_SO_DANG_KY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_TEN_THUOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_MA_HOAT_CHAT_TT40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_HOAT_CHAT_TT40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_HOAT_CHAT_SODK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_MA_DUONG_DUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_DUONG_DUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_HAM_LUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_DONG_GOI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_HANG_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBHYT_NUOC_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STTQDPK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_QUYCACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Generic_BD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repcbx_Generic_BD = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.col_VENCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkup_VEN = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Active_TT40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SalesPrice_Retail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureCode_Medi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSlkup_UnitOfMeasureCode_Medi = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSlkup_UnitOfMeasureCode_MediView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colViewUOMCode_Medi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViewUOMName_Medi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Converted_Medi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChk_Converted_Medi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.btnInGird = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Packed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Item_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_Item_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_ListBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Check_RepositoryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_Country)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_Country)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_Producer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_Producer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_ListService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Check_VendorCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKupItems_BHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewLKupItems_BHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repcbx_Generic_BD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkup_VEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSlkup_UnitOfMeasureCode_Medi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSlkup_UnitOfMeasureCode_MediView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChk_Converted_Medi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Item
            // 
            this.gridControl_Item.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Item.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Item.MainView = this.gridView_Item;
            this.gridControl_Item.Name = "gridControl_Item";
            this.gridControl_Item.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemGridLookUpEdit_Usage,
            this.ItemGridLookUpEdit_UoM,
            this.ItemGridLookUpEdit_Item_Category,
            this.ItemCheckEdit_Status,
            this.rep_Check_RepositoryCode,
            this.ItemCheckEdit_ListBHYT,
            this.ItemCheckEdit_ListService,
            this.rep_Check_VendorCode,
            this.ItemGridLookUpEdit_Packed,
            this.repcbx_Generic_BD,
            this.repLkup_VEN,
            this.repLKupItems_BHYT,
            this.repSearch_Producer,
            this.repSearch_Country,
            this.repSlkup_UnitOfMeasureCode_Medi,
            this.repChk_Converted_Medi});
            this.gridControl_Item.Size = new System.Drawing.Size(1251, 575);
            this.gridControl_Item.TabIndex = 2;
            this.gridControl_Item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Item});
            this.gridControl_Item.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Item_ProcessGridKey);
            // 
            // gridView_Item
            // 
            this.gridView_Item.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Item.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Item.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Item.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Item.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCode,
            this.col_ItemName,
            this.col_ItemContent,
            this.col_Active,
            this.col_UsageCode,
            this.col_UnitOfMeasureCode,
            this.col_Packed,
            this.col_QtyOfMeasure,
            this.col_SalesPrice,
            this.col_Unit_Price,
            this.col_BHYTPrice,
            this.col_ItemCategoryCode,
            this.col_Status,
            this.col_SafelyQuantity,
            this.col_ListBHYT,
            this.col_RepositoryCode,
            this.col_EmloyeeCode,
            this.col_RateBHYT,
            this.col_CountryCode,
            this.col_ProducerCode,
            this.col_Note,
            this.col_DisparityPrice,
            this.col_ListService,
            this.col_VendorCode,
            this.col_STTBCBHYT,
            this.col_SODKGP,
            this.col_STTQDPK,
            this.col_QUYCACH,
            this.col_Generic_BD,
            this.col_VENCode,
            this.col_Active_TT40,
            this.col_SalesPrice_Retail,
            this.col_UnitOfMeasureCode_Medi,
            this.col_Converted_Medi});
            this.gridView_Item.GridControl = this.gridControl_Item;
            this.gridView_Item.Name = "gridView_Item";
            this.gridView_Item.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Thuốc & VTYT).";
            this.gridView_Item.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Item.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Item.OptionsFind.AlwaysVisible = true;
            this.gridView_Item.OptionsFind.FindFilterColumns = "ItemName;Active";
            this.gridView_Item.OptionsView.ColumnAutoWidth = false;
            this.gridView_Item.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Item.OptionsView.ShowFooter = true;
            this.gridView_Item.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_Item_RowStyle);
            this.gridView_Item.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Item_InvalidRowException);
            this.gridView_Item.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Item_ValidateRow);
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_ItemCode.AppearanceCell.Options.UseFont = true;
            this.col_ItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.col_ItemCode.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Width = 62;
            // 
            // col_ItemName
            // 
            this.col_ItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ItemName.Caption = "Tên - nội dung";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.OptionsColumn.AllowMove = false;
            this.col_ItemName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.col_ItemName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Count: {0:#,#}")});
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 1;
            this.col_ItemName.Width = 180;
            // 
            // col_ItemContent
            // 
            this.col_ItemContent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemContent.AppearanceHeader.Options.UseFont = true;
            this.col_ItemContent.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ItemContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ItemContent.Caption = "Hàm lượng";
            this.col_ItemContent.FieldName = "ItemContent";
            this.col_ItemContent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_ItemContent.Name = "col_ItemContent";
            this.col_ItemContent.Visible = true;
            this.col_ItemContent.VisibleIndex = 2;
            this.col_ItemContent.Width = 79;
            // 
            // col_Active
            // 
            this.col_Active.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Active.AppearanceHeader.Options.UseFont = true;
            this.col_Active.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Active.Caption = "Hoạt chất";
            this.col_Active.FieldName = "Active";
            this.col_Active.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_Active.Name = "col_Active";
            this.col_Active.OptionsColumn.AllowMove = false;
            this.col_Active.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.col_Active.Visible = true;
            this.col_Active.VisibleIndex = 3;
            this.col_Active.Width = 94;
            // 
            // col_UsageCode
            // 
            this.col_UsageCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UsageCode.AppearanceHeader.Options.UseFont = true;
            this.col_UsageCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UsageCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UsageCode.Caption = "Đường dùng";
            this.col_UsageCode.ColumnEdit = this.ItemGridLookUpEdit_Usage;
            this.col_UsageCode.FieldName = "UsageCode";
            this.col_UsageCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_UsageCode.Name = "col_UsageCode";
            this.col_UsageCode.OptionsColumn.AllowMove = false;
            this.col_UsageCode.Visible = true;
            this.col_UsageCode.VisibleIndex = 5;
            this.col_UsageCode.Width = 80;
            // 
            // ItemGridLookUpEdit_Usage
            // 
            this.ItemGridLookUpEdit_Usage.AutoHeight = false;
            this.ItemGridLookUpEdit_Usage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemGridLookUpEdit_Usage.Name = "ItemGridLookUpEdit_Usage";
            this.ItemGridLookUpEdit_Usage.NullText = "Chọn";
            this.ItemGridLookUpEdit_Usage.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ItemGridLookUpEdit_Usage.View = this.ItemGridLookUpEditView_Usage;
            // 
            // ItemGridLookUpEditView_Usage
            // 
            this.ItemGridLookUpEditView_Usage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_UsageCode,
            this.view_UsageName});
            this.ItemGridLookUpEditView_Usage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ItemGridLookUpEditView_Usage.Name = "ItemGridLookUpEditView_Usage";
            this.ItemGridLookUpEditView_Usage.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ItemGridLookUpEditView_Usage.OptionsView.ShowGroupPanel = false;
            // 
            // view_UsageCode
            // 
            this.view_UsageCode.Caption = "Mã";
            this.view_UsageCode.FieldName = "UsageCode";
            this.view_UsageCode.Name = "view_UsageCode";
            this.view_UsageCode.OptionsColumn.ShowCaption = false;
            // 
            // view_UsageName
            // 
            this.view_UsageName.Caption = "Tên";
            this.view_UsageName.FieldName = "UsageName";
            this.view_UsageName.Name = "view_UsageName";
            this.view_UsageName.OptionsColumn.ShowCaption = false;
            this.view_UsageName.Visible = true;
            this.view_UsageName.VisibleIndex = 0;
            // 
            // col_UnitOfMeasureCode
            // 
            this.col_UnitOfMeasureCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitOfMeasureCode.AppearanceHeader.Options.UseFont = true;
            this.col_UnitOfMeasureCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureCode.Caption = "ĐVT";
            this.col_UnitOfMeasureCode.ColumnEdit = this.ItemGridLookUpEdit_UoM;
            this.col_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.col_UnitOfMeasureCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_UnitOfMeasureCode.Name = "col_UnitOfMeasureCode";
            this.col_UnitOfMeasureCode.OptionsColumn.AllowMove = false;
            this.col_UnitOfMeasureCode.Visible = true;
            this.col_UnitOfMeasureCode.VisibleIndex = 6;
            this.col_UnitOfMeasureCode.Width = 54;
            // 
            // ItemGridLookUpEdit_UoM
            // 
            this.ItemGridLookUpEdit_UoM.AutoHeight = false;
            this.ItemGridLookUpEdit_UoM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemGridLookUpEdit_UoM.Name = "ItemGridLookUpEdit_UoM";
            this.ItemGridLookUpEdit_UoM.NullText = "Chọn";
            this.ItemGridLookUpEdit_UoM.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ItemGridLookUpEdit_UoM.View = this.ItemGridLookUpEditView_UoM;
            // 
            // ItemGridLookUpEditView_UoM
            // 
            this.ItemGridLookUpEditView_UoM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_UoMCode,
            this.view_UoM_Name});
            this.ItemGridLookUpEditView_UoM.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ItemGridLookUpEditView_UoM.Name = "ItemGridLookUpEditView_UoM";
            this.ItemGridLookUpEditView_UoM.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ItemGridLookUpEditView_UoM.OptionsView.ShowGroupPanel = false;
            // 
            // view_UoMCode
            // 
            this.view_UoMCode.Caption = "Mã";
            this.view_UoMCode.FieldName = "UnitOfMeasureCode";
            this.view_UoMCode.Name = "view_UoMCode";
            this.view_UoMCode.OptionsColumn.ShowCaption = false;
            // 
            // view_UoM_Name
            // 
            this.view_UoM_Name.Caption = "Tên";
            this.view_UoM_Name.FieldName = "UnitOfMeasureName";
            this.view_UoM_Name.Name = "view_UoM_Name";
            this.view_UoM_Name.OptionsColumn.ShowCaption = false;
            this.view_UoM_Name.Visible = true;
            this.view_UoM_Name.VisibleIndex = 0;
            // 
            // col_Packed
            // 
            this.col_Packed.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Packed.AppearanceHeader.Options.UseFont = true;
            this.col_Packed.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Packed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Packed.Caption = "Đóng gói";
            this.col_Packed.ColumnEdit = this.ItemGridLookUpEdit_Packed;
            this.col_Packed.FieldName = "Packed";
            this.col_Packed.Name = "col_Packed";
            this.col_Packed.Visible = true;
            this.col_Packed.VisibleIndex = 8;
            this.col_Packed.Width = 76;
            // 
            // ItemGridLookUpEdit_Packed
            // 
            this.ItemGridLookUpEdit_Packed.AutoHeight = false;
            this.ItemGridLookUpEdit_Packed.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemGridLookUpEdit_Packed.Name = "ItemGridLookUpEdit_Packed";
            this.ItemGridLookUpEdit_Packed.NullText = "";
            this.ItemGridLookUpEdit_Packed.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ItemGridLookUpEdit_Packed.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_Packed_Name});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // view_Packed_Name
            // 
            this.view_Packed_Name.Caption = "Đơn vị";
            this.view_Packed_Name.FieldName = "UnitOfMeasureName";
            this.view_Packed_Name.Name = "view_Packed_Name";
            this.view_Packed_Name.Visible = true;
            this.view_Packed_Name.VisibleIndex = 0;
            // 
            // col_QtyOfMeasure
            // 
            this.col_QtyOfMeasure.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_QtyOfMeasure.AppearanceHeader.Options.UseFont = true;
            this.col_QtyOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.col_QtyOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_QtyOfMeasure.Caption = "SL Quy đổi";
            this.col_QtyOfMeasure.FieldName = "QtyOfMeasure";
            this.col_QtyOfMeasure.Name = "col_QtyOfMeasure";
            this.col_QtyOfMeasure.Visible = true;
            this.col_QtyOfMeasure.VisibleIndex = 9;
            this.col_QtyOfMeasure.Width = 71;
            // 
            // col_SalesPrice
            // 
            this.col_SalesPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_SalesPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SalesPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SalesPrice.AppearanceHeader.Options.UseFont = true;
            this.col_SalesPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SalesPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SalesPrice.Caption = "Giá dịch vụ";
            this.col_SalesPrice.DisplayFormat.FormatString = "#,#.#";
            this.col_SalesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SalesPrice.FieldName = "SalesPrice";
            this.col_SalesPrice.Name = "col_SalesPrice";
            this.col_SalesPrice.Visible = true;
            this.col_SalesPrice.VisibleIndex = 12;
            this.col_SalesPrice.Width = 85;
            // 
            // col_Unit_Price
            // 
            this.col_Unit_Price.AppearanceCell.Options.UseTextOptions = true;
            this.col_Unit_Price.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Unit_Price.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Unit_Price.AppearanceHeader.Options.UseFont = true;
            this.col_Unit_Price.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Unit_Price.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Unit_Price.Caption = "Giá mua";
            this.col_Unit_Price.DisplayFormat.FormatString = "#,#.#";
            this.col_Unit_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Unit_Price.FieldName = "UnitPrice";
            this.col_Unit_Price.Name = "col_Unit_Price";
            this.col_Unit_Price.Visible = true;
            this.col_Unit_Price.VisibleIndex = 10;
            this.col_Unit_Price.Width = 87;
            // 
            // col_BHYTPrice
            // 
            this.col_BHYTPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_BHYTPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_BHYTPrice.AppearanceHeader.Options.UseFont = true;
            this.col_BHYTPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_BHYTPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_BHYTPrice.Caption = "Giá BHYT";
            this.col_BHYTPrice.DisplayFormat.FormatString = "#,#.#";
            this.col_BHYTPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_BHYTPrice.FieldName = "BHYTPrice";
            this.col_BHYTPrice.Name = "col_BHYTPrice";
            this.col_BHYTPrice.Visible = true;
            this.col_BHYTPrice.VisibleIndex = 11;
            this.col_BHYTPrice.Width = 86;
            // 
            // col_ItemCategoryCode
            // 
            this.col_ItemCategoryCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCategoryCode.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCategoryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ItemCategoryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_ItemCategoryCode.Caption = "Phân loại";
            this.col_ItemCategoryCode.ColumnEdit = this.ItemGridLookUpEdit_Item_Category;
            this.col_ItemCategoryCode.FieldName = "ItemCategoryCode";
            this.col_ItemCategoryCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_ItemCategoryCode.Name = "col_ItemCategoryCode";
            this.col_ItemCategoryCode.Visible = true;
            this.col_ItemCategoryCode.VisibleIndex = 0;
            this.col_ItemCategoryCode.Width = 125;
            // 
            // ItemGridLookUpEdit_Item_Category
            // 
            this.ItemGridLookUpEdit_Item_Category.AutoHeight = false;
            this.ItemGridLookUpEdit_Item_Category.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemGridLookUpEdit_Item_Category.Name = "ItemGridLookUpEdit_Item_Category";
            this.ItemGridLookUpEdit_Item_Category.NullText = "Chọn";
            this.ItemGridLookUpEdit_Item_Category.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ItemGridLookUpEdit_Item_Category.View = this.ItemGridLookUpEditView_Item_Category;
            // 
            // ItemGridLookUpEditView_Item_Category
            // 
            this.ItemGridLookUpEditView_Item_Category.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_ItemCategoryCode,
            this.view_ItemCategoryName});
            this.ItemGridLookUpEditView_Item_Category.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ItemGridLookUpEditView_Item_Category.Name = "ItemGridLookUpEditView_Item_Category";
            this.ItemGridLookUpEditView_Item_Category.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ItemGridLookUpEditView_Item_Category.OptionsView.ShowGroupPanel = false;
            // 
            // view_ItemCategoryCode
            // 
            this.view_ItemCategoryCode.Caption = "Mã";
            this.view_ItemCategoryCode.FieldName = "ItemCategoryCode";
            this.view_ItemCategoryCode.Name = "view_ItemCategoryCode";
            this.view_ItemCategoryCode.OptionsColumn.ShowCaption = false;
            // 
            // view_ItemCategoryName
            // 
            this.view_ItemCategoryName.Caption = "Tên";
            this.view_ItemCategoryName.FieldName = "ItemCategoryName";
            this.view_ItemCategoryName.Name = "view_ItemCategoryName";
            this.view_ItemCategoryName.OptionsColumn.ShowCaption = false;
            this.view_ItemCategoryName.Visible = true;
            this.view_ItemCategoryName.VisibleIndex = 0;
            // 
            // col_Status
            // 
            this.col_Status.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Status.AppearanceHeader.Options.UseFont = true;
            this.col_Status.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Status.Caption = "Hide";
            this.col_Status.ColumnEdit = this.ItemCheckEdit_Status;
            this.col_Status.FieldName = "Status";
            this.col_Status.Name = "col_Status";
            this.col_Status.OptionsColumn.AllowMove = false;
            this.col_Status.Visible = true;
            this.col_Status.VisibleIndex = 26;
            this.col_Status.Width = 53;
            // 
            // ItemCheckEdit_Status
            // 
            this.ItemCheckEdit_Status.AutoHeight = false;
            this.ItemCheckEdit_Status.DisplayValueChecked = "1";
            this.ItemCheckEdit_Status.DisplayValueGrayed = "0";
            this.ItemCheckEdit_Status.DisplayValueUnchecked = "0";
            this.ItemCheckEdit_Status.Name = "ItemCheckEdit_Status";
            this.ItemCheckEdit_Status.ValueChecked = 1;
            this.ItemCheckEdit_Status.ValueGrayed = 0;
            this.ItemCheckEdit_Status.ValueUnchecked = 0;
            // 
            // col_SafelyQuantity
            // 
            this.col_SafelyQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_SafelyQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SafelyQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SafelyQuantity.AppearanceHeader.Options.UseFont = true;
            this.col_SafelyQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SafelyQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SafelyQuantity.Caption = "Hạn mức tồn";
            this.col_SafelyQuantity.DisplayFormat.FormatString = "#,#";
            this.col_SafelyQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SafelyQuantity.FieldName = "SafelyQuantity";
            this.col_SafelyQuantity.Name = "col_SafelyQuantity";
            this.col_SafelyQuantity.OptionsColumn.AllowMove = false;
            this.col_SafelyQuantity.Visible = true;
            this.col_SafelyQuantity.VisibleIndex = 17;
            this.col_SafelyQuantity.Width = 89;
            // 
            // col_ListBHYT
            // 
            this.col_ListBHYT.AppearanceCell.Options.UseTextOptions = true;
            this.col_ListBHYT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ListBHYT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ListBHYT.AppearanceHeader.Options.UseFont = true;
            this.col_ListBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ListBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ListBHYT.Caption = "DM BHYT";
            this.col_ListBHYT.ColumnEdit = this.ItemCheckEdit_ListBHYT;
            this.col_ListBHYT.FieldName = "ListBHYT";
            this.col_ListBHYT.Name = "col_ListBHYT";
            this.col_ListBHYT.Visible = true;
            this.col_ListBHYT.VisibleIndex = 15;
            this.col_ListBHYT.Width = 69;
            // 
            // ItemCheckEdit_ListBHYT
            // 
            this.ItemCheckEdit_ListBHYT.AutoHeight = false;
            this.ItemCheckEdit_ListBHYT.DisplayValueChecked = "1";
            this.ItemCheckEdit_ListBHYT.DisplayValueGrayed = "0";
            this.ItemCheckEdit_ListBHYT.DisplayValueUnchecked = "0";
            this.ItemCheckEdit_ListBHYT.Name = "ItemCheckEdit_ListBHYT";
            this.ItemCheckEdit_ListBHYT.ValueChecked = 1;
            this.ItemCheckEdit_ListBHYT.ValueGrayed = "0";
            this.ItemCheckEdit_ListBHYT.ValueUnchecked = 0;
            // 
            // col_RepositoryCode
            // 
            this.col_RepositoryCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RepositoryCode.AppearanceHeader.Options.UseFont = true;
            this.col_RepositoryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RepositoryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RepositoryCode.Caption = "Kho";
            this.col_RepositoryCode.ColumnEdit = this.rep_Check_RepositoryCode;
            this.col_RepositoryCode.FieldName = "RepositoryCode";
            this.col_RepositoryCode.Name = "col_RepositoryCode";
            this.col_RepositoryCode.OptionsColumn.AllowMove = false;
            this.col_RepositoryCode.Visible = true;
            this.col_RepositoryCode.VisibleIndex = 21;
            this.col_RepositoryCode.Width = 195;
            // 
            // rep_Check_RepositoryCode
            // 
            this.rep_Check_RepositoryCode.AutoHeight = false;
            this.rep_Check_RepositoryCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_Check_RepositoryCode.Name = "rep_Check_RepositoryCode";
            // 
            // col_EmloyeeCode
            // 
            this.col_EmloyeeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_EmloyeeCode.AppearanceHeader.Options.UseFont = true;
            this.col_EmloyeeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmloyeeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmloyeeCode.Caption = "Người nhập";
            this.col_EmloyeeCode.FieldName = "EmloyeeCode";
            this.col_EmloyeeCode.Name = "col_EmloyeeCode";
            // 
            // col_RateBHYT
            // 
            this.col_RateBHYT.AppearanceCell.Options.UseTextOptions = true;
            this.col_RateBHYT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_RateBHYT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RateBHYT.AppearanceHeader.Options.UseFont = true;
            this.col_RateBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RateBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RateBHYT.Caption = "Tỉ lệ BHYT";
            this.col_RateBHYT.DisplayFormat.FormatString = "#,##";
            this.col_RateBHYT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_RateBHYT.FieldName = "RateBHYT";
            this.col_RateBHYT.Name = "col_RateBHYT";
            this.col_RateBHYT.Visible = true;
            this.col_RateBHYT.VisibleIndex = 14;
            // 
            // col_CountryCode
            // 
            this.col_CountryCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_CountryCode.AppearanceHeader.Options.UseFont = true;
            this.col_CountryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_CountryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_CountryCode.Caption = "Nước sản xuất";
            this.col_CountryCode.ColumnEdit = this.repSearch_Country;
            this.col_CountryCode.FieldName = "CountryCode";
            this.col_CountryCode.Name = "col_CountryCode";
            this.col_CountryCode.OptionsColumn.AllowMove = false;
            this.col_CountryCode.Width = 155;
            // 
            // repSearch_Country
            // 
            this.repSearch_Country.AutoHeight = false;
            this.repSearch_Country.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearch_Country.Name = "repSearch_Country";
            this.repSearch_Country.View = this.repSearchView_Country;
            // 
            // repSearchView_Country
            // 
            this.repSearchView_Country.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRepCountry_CountryCode,
            this.colRepCountry_CountryName});
            this.repSearchView_Country.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchView_Country.Name = "repSearchView_Country";
            this.repSearchView_Country.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchView_Country.OptionsView.ShowGroupPanel = false;
            // 
            // colRepCountry_CountryCode
            // 
            this.colRepCountry_CountryCode.Caption = "Mã";
            this.colRepCountry_CountryCode.FieldName = "CountryCode";
            this.colRepCountry_CountryCode.Name = "colRepCountry_CountryCode";
            this.colRepCountry_CountryCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colRepCountry_CountryCode.Visible = true;
            this.colRepCountry_CountryCode.VisibleIndex = 0;
            // 
            // colRepCountry_CountryName
            // 
            this.colRepCountry_CountryName.Caption = "Nước Sản Xuất";
            this.colRepCountry_CountryName.FieldName = "CountryName";
            this.colRepCountry_CountryName.Name = "colRepCountry_CountryName";
            this.colRepCountry_CountryName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colRepCountry_CountryName.Visible = true;
            this.colRepCountry_CountryName.VisibleIndex = 1;
            // 
            // col_ProducerCode
            // 
            this.col_ProducerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ProducerCode.AppearanceHeader.Options.UseFont = true;
            this.col_ProducerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProducerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProducerCode.Caption = "Hãng sản xuất";
            this.col_ProducerCode.ColumnEdit = this.repSearch_Producer;
            this.col_ProducerCode.FieldName = "ProducerCode";
            this.col_ProducerCode.Name = "col_ProducerCode";
            this.col_ProducerCode.OptionsColumn.AllowMove = false;
            this.col_ProducerCode.Visible = true;
            this.col_ProducerCode.VisibleIndex = 18;
            this.col_ProducerCode.Width = 153;
            // 
            // repSearch_Producer
            // 
            this.repSearch_Producer.AutoHeight = false;
            this.repSearch_Producer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearch_Producer.Name = "repSearch_Producer";
            this.repSearch_Producer.NullText = "";
            this.repSearch_Producer.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repSearch_Producer.View = this.repSearchView_Producer;
            // 
            // repSearchView_Producer
            // 
            this.repSearchView_Producer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRefProduct_ProducerCode,
            this.colRefProduct_ProducerName,
            this.colRefProduct_Hide});
            this.repSearchView_Producer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchView_Producer.Name = "repSearchView_Producer";
            this.repSearchView_Producer.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchView_Producer.OptionsView.ShowGroupPanel = false;
            // 
            // colRefProduct_ProducerCode
            // 
            this.colRefProduct_ProducerCode.Caption = "Mã";
            this.colRefProduct_ProducerCode.FieldName = "ProducerCode";
            this.colRefProduct_ProducerCode.Name = "colRefProduct_ProducerCode";
            this.colRefProduct_ProducerCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRefProduct_ProducerCode.Visible = true;
            this.colRefProduct_ProducerCode.VisibleIndex = 0;
            this.colRefProduct_ProducerCode.Width = 132;
            // 
            // colRefProduct_ProducerName
            // 
            this.colRefProduct_ProducerName.Caption = "Hãng Sản Xuất";
            this.colRefProduct_ProducerName.FieldName = "ProducerName";
            this.colRefProduct_ProducerName.Name = "colRefProduct_ProducerName";
            this.colRefProduct_ProducerName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRefProduct_ProducerName.Visible = true;
            this.colRefProduct_ProducerName.VisibleIndex = 1;
            this.colRefProduct_ProducerName.Width = 946;
            // 
            // colRefProduct_Hide
            // 
            this.colRefProduct_Hide.Caption = "Hide";
            this.colRefProduct_Hide.FieldName = "Hide";
            this.colRefProduct_Hide.Name = "colRefProduct_Hide";
            // 
            // col_Note
            // 
            this.col_Note.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Note.AppearanceHeader.Options.UseFont = true;
            this.col_Note.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Note.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Note.Caption = "Ghi chú";
            this.col_Note.FieldName = "Note";
            this.col_Note.Name = "col_Note";
            this.col_Note.Visible = true;
            this.col_Note.VisibleIndex = 20;
            this.col_Note.Width = 165;
            // 
            // col_DisparityPrice
            // 
            this.col_DisparityPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_DisparityPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DisparityPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DisparityPrice.AppearanceHeader.Options.UseFont = true;
            this.col_DisparityPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DisparityPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DisparityPrice.Caption = "Phụ thu BHYT";
            this.col_DisparityPrice.DisplayFormat.FormatString = "#,#.#";
            this.col_DisparityPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_DisparityPrice.FieldName = "DisparityPrice";
            this.col_DisparityPrice.Name = "col_DisparityPrice";
            this.col_DisparityPrice.Visible = true;
            this.col_DisparityPrice.VisibleIndex = 30;
            this.col_DisparityPrice.Width = 95;
            // 
            // col_ListService
            // 
            this.col_ListService.AppearanceCell.Options.UseTextOptions = true;
            this.col_ListService.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ListService.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ListService.AppearanceHeader.Options.UseFont = true;
            this.col_ListService.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ListService.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ListService.Caption = "Dịch vụ";
            this.col_ListService.ColumnEdit = this.ItemCheckEdit_ListService;
            this.col_ListService.FieldName = "ListService";
            this.col_ListService.Name = "col_ListService";
            this.col_ListService.Visible = true;
            this.col_ListService.VisibleIndex = 16;
            this.col_ListService.Width = 63;
            // 
            // ItemCheckEdit_ListService
            // 
            this.ItemCheckEdit_ListService.AutoHeight = false;
            this.ItemCheckEdit_ListService.DisplayValueChecked = "1";
            this.ItemCheckEdit_ListService.DisplayValueGrayed = "0";
            this.ItemCheckEdit_ListService.DisplayValueUnchecked = "0";
            this.ItemCheckEdit_ListService.Name = "ItemCheckEdit_ListService";
            this.ItemCheckEdit_ListService.ValueChecked = 1;
            this.ItemCheckEdit_ListService.ValueGrayed = 0;
            this.ItemCheckEdit_ListService.ValueUnchecked = 0;
            // 
            // col_VendorCode
            // 
            this.col_VendorCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_VendorCode.AppearanceHeader.Options.UseFont = true;
            this.col_VendorCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_VendorCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_VendorCode.Caption = "Nhà CC";
            this.col_VendorCode.ColumnEdit = this.rep_Check_VendorCode;
            this.col_VendorCode.FieldName = "VendorCode";
            this.col_VendorCode.Name = "col_VendorCode";
            this.col_VendorCode.Visible = true;
            this.col_VendorCode.VisibleIndex = 19;
            this.col_VendorCode.Width = 161;
            // 
            // rep_Check_VendorCode
            // 
            this.rep_Check_VendorCode.AutoHeight = false;
            this.rep_Check_VendorCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_Check_VendorCode.Name = "rep_Check_VendorCode";
            // 
            // col_STTBCBHYT
            // 
            this.col_STTBCBHYT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_STTBCBHYT.AppearanceHeader.Options.UseFont = true;
            this.col_STTBCBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STTBCBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STTBCBHYT.Caption = "STT báo cáo BHYT";
            this.col_STTBCBHYT.FieldName = "STTBCBHYT";
            this.col_STTBCBHYT.Name = "col_STTBCBHYT";
            this.col_STTBCBHYT.Visible = true;
            this.col_STTBCBHYT.VisibleIndex = 23;
            this.col_STTBCBHYT.Width = 123;
            // 
            // col_SODKGP
            // 
            this.col_SODKGP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SODKGP.AppearanceHeader.Options.UseFont = true;
            this.col_SODKGP.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SODKGP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SODKGP.Caption = "Số ĐK giấy phép";
            this.col_SODKGP.ColumnEdit = this.repLKupItems_BHYT;
            this.col_SODKGP.FieldName = "SODKGP";
            this.col_SODKGP.Name = "col_SODKGP";
            this.col_SODKGP.Visible = true;
            this.col_SODKGP.VisibleIndex = 24;
            this.col_SODKGP.Width = 101;
            // 
            // repLKupItems_BHYT
            // 
            this.repLKupItems_BHYT.AutoHeight = false;
            this.repLKupItems_BHYT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLKupItems_BHYT.Name = "repLKupItems_BHYT";
            this.repLKupItems_BHYT.NullText = "";
            this.repLKupItems_BHYT.View = this.repViewLKupItems_BHYT;
            // 
            // repViewLKupItems_BHYT
            // 
            this.repViewLKupItems_BHYT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemBHYT_STT,
            this.colItemBHYT_SO_DANG_KY,
            this.colItemBHYT_TEN_THUOC,
            this.colItemBHYT_MA_HOAT_CHAT_TT40,
            this.colItemBHYT_HOAT_CHAT_TT40,
            this.colItemBHYT_HOAT_CHAT_SODK,
            this.colItemBHYT_MA_DUONG_DUNG,
            this.colItemBHYT_DUONG_DUNG,
            this.colItemBHYT_HAM_LUONG,
            this.colItemBHYT_DONG_GOI,
            this.colItemBHYT_HANG_SX,
            this.colItemBHYT_NUOC_SX});
            this.repViewLKupItems_BHYT.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repViewLKupItems_BHYT.Name = "repViewLKupItems_BHYT";
            this.repViewLKupItems_BHYT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repViewLKupItems_BHYT.OptionsView.ColumnAutoWidth = false;
            this.repViewLKupItems_BHYT.OptionsView.ShowGroupPanel = false;
            // 
            // colItemBHYT_STT
            // 
            this.colItemBHYT_STT.AppearanceCell.Options.UseTextOptions = true;
            this.colItemBHYT_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemBHYT_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemBHYT_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemBHYT_STT.Caption = "STT";
            this.colItemBHYT_STT.FieldName = "STT";
            this.colItemBHYT_STT.Name = "colItemBHYT_STT";
            this.colItemBHYT_STT.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_STT.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_STT.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_STT.Visible = true;
            this.colItemBHYT_STT.VisibleIndex = 0;
            this.colItemBHYT_STT.Width = 63;
            // 
            // colItemBHYT_SO_DANG_KY
            // 
            this.colItemBHYT_SO_DANG_KY.Caption = "Số Đăng Ký";
            this.colItemBHYT_SO_DANG_KY.FieldName = "SO_DANG_KY";
            this.colItemBHYT_SO_DANG_KY.Name = "colItemBHYT_SO_DANG_KY";
            this.colItemBHYT_SO_DANG_KY.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_SO_DANG_KY.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_SO_DANG_KY.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_SO_DANG_KY.Visible = true;
            this.colItemBHYT_SO_DANG_KY.VisibleIndex = 1;
            this.colItemBHYT_SO_DANG_KY.Width = 119;
            // 
            // colItemBHYT_TEN_THUOC
            // 
            this.colItemBHYT_TEN_THUOC.Caption = "Tên Tân Dược";
            this.colItemBHYT_TEN_THUOC.FieldName = "TEN_THUOC";
            this.colItemBHYT_TEN_THUOC.Name = "colItemBHYT_TEN_THUOC";
            this.colItemBHYT_TEN_THUOC.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_TEN_THUOC.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_TEN_THUOC.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_TEN_THUOC.Visible = true;
            this.colItemBHYT_TEN_THUOC.VisibleIndex = 2;
            this.colItemBHYT_TEN_THUOC.Width = 139;
            // 
            // colItemBHYT_MA_HOAT_CHAT_TT40
            // 
            this.colItemBHYT_MA_HOAT_CHAT_TT40.Caption = "Mã Hoạt Chất TT40";
            this.colItemBHYT_MA_HOAT_CHAT_TT40.FieldName = "MA_HOAT_CHAT_TT40";
            this.colItemBHYT_MA_HOAT_CHAT_TT40.Name = "colItemBHYT_MA_HOAT_CHAT_TT40";
            this.colItemBHYT_MA_HOAT_CHAT_TT40.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_MA_HOAT_CHAT_TT40.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_MA_HOAT_CHAT_TT40.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_MA_HOAT_CHAT_TT40.Visible = true;
            this.colItemBHYT_MA_HOAT_CHAT_TT40.VisibleIndex = 3;
            this.colItemBHYT_MA_HOAT_CHAT_TT40.Width = 138;
            // 
            // colItemBHYT_HOAT_CHAT_TT40
            // 
            this.colItemBHYT_HOAT_CHAT_TT40.Caption = "Hoạt Chất TT40";
            this.colItemBHYT_HOAT_CHAT_TT40.FieldName = "HOAT_CHAT_TT40";
            this.colItemBHYT_HOAT_CHAT_TT40.Name = "colItemBHYT_HOAT_CHAT_TT40";
            this.colItemBHYT_HOAT_CHAT_TT40.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_HOAT_CHAT_TT40.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_HOAT_CHAT_TT40.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_HOAT_CHAT_TT40.Visible = true;
            this.colItemBHYT_HOAT_CHAT_TT40.VisibleIndex = 4;
            this.colItemBHYT_HOAT_CHAT_TT40.Width = 140;
            // 
            // colItemBHYT_HOAT_CHAT_SODK
            // 
            this.colItemBHYT_HOAT_CHAT_SODK.Caption = "Hoạt Chất Số ĐK";
            this.colItemBHYT_HOAT_CHAT_SODK.FieldName = "HOAT_CHAT_SODK";
            this.colItemBHYT_HOAT_CHAT_SODK.Name = "colItemBHYT_HOAT_CHAT_SODK";
            this.colItemBHYT_HOAT_CHAT_SODK.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_HOAT_CHAT_SODK.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_HOAT_CHAT_SODK.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_HOAT_CHAT_SODK.Visible = true;
            this.colItemBHYT_HOAT_CHAT_SODK.VisibleIndex = 5;
            this.colItemBHYT_HOAT_CHAT_SODK.Width = 115;
            // 
            // colItemBHYT_MA_DUONG_DUNG
            // 
            this.colItemBHYT_MA_DUONG_DUNG.Caption = "Mã Đường Dùng";
            this.colItemBHYT_MA_DUONG_DUNG.FieldName = "MA_DUONG_DUNG";
            this.colItemBHYT_MA_DUONG_DUNG.Name = "colItemBHYT_MA_DUONG_DUNG";
            this.colItemBHYT_MA_DUONG_DUNG.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_MA_DUONG_DUNG.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_MA_DUONG_DUNG.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_MA_DUONG_DUNG.Visible = true;
            this.colItemBHYT_MA_DUONG_DUNG.VisibleIndex = 6;
            this.colItemBHYT_MA_DUONG_DUNG.Width = 103;
            // 
            // colItemBHYT_DUONG_DUNG
            // 
            this.colItemBHYT_DUONG_DUNG.Caption = "Đường Dùng";
            this.colItemBHYT_DUONG_DUNG.FieldName = "DUONG_DUNG";
            this.colItemBHYT_DUONG_DUNG.Name = "colItemBHYT_DUONG_DUNG";
            this.colItemBHYT_DUONG_DUNG.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_DUONG_DUNG.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_DUONG_DUNG.Visible = true;
            this.colItemBHYT_DUONG_DUNG.VisibleIndex = 7;
            this.colItemBHYT_DUONG_DUNG.Width = 97;
            // 
            // colItemBHYT_HAM_LUONG
            // 
            this.colItemBHYT_HAM_LUONG.Caption = "Hàm Lượng";
            this.colItemBHYT_HAM_LUONG.FieldName = "HAM_LUONG";
            this.colItemBHYT_HAM_LUONG.Name = "colItemBHYT_HAM_LUONG";
            this.colItemBHYT_HAM_LUONG.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_HAM_LUONG.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_HAM_LUONG.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_HAM_LUONG.Visible = true;
            this.colItemBHYT_HAM_LUONG.VisibleIndex = 8;
            this.colItemBHYT_HAM_LUONG.Width = 91;
            // 
            // colItemBHYT_DONG_GOI
            // 
            this.colItemBHYT_DONG_GOI.Caption = "Đóng Gói";
            this.colItemBHYT_DONG_GOI.FieldName = "DONG_GOI";
            this.colItemBHYT_DONG_GOI.Name = "colItemBHYT_DONG_GOI";
            this.colItemBHYT_DONG_GOI.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_DONG_GOI.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_DONG_GOI.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_DONG_GOI.Visible = true;
            this.colItemBHYT_DONG_GOI.VisibleIndex = 9;
            this.colItemBHYT_DONG_GOI.Width = 109;
            // 
            // colItemBHYT_HANG_SX
            // 
            this.colItemBHYT_HANG_SX.Caption = "Hãng SX";
            this.colItemBHYT_HANG_SX.FieldName = "HANG_SX";
            this.colItemBHYT_HANG_SX.Name = "colItemBHYT_HANG_SX";
            this.colItemBHYT_HANG_SX.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_HANG_SX.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_HANG_SX.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_HANG_SX.Visible = true;
            this.colItemBHYT_HANG_SX.VisibleIndex = 10;
            this.colItemBHYT_HANG_SX.Width = 109;
            // 
            // colItemBHYT_NUOC_SX
            // 
            this.colItemBHYT_NUOC_SX.Caption = "Nước SX";
            this.colItemBHYT_NUOC_SX.FieldName = "NUOC_SX";
            this.colItemBHYT_NUOC_SX.Name = "colItemBHYT_NUOC_SX";
            this.colItemBHYT_NUOC_SX.OptionsColumn.AllowEdit = false;
            this.colItemBHYT_NUOC_SX.OptionsColumn.AllowFocus = false;
            this.colItemBHYT_NUOC_SX.OptionsColumn.ReadOnly = true;
            this.colItemBHYT_NUOC_SX.Visible = true;
            this.colItemBHYT_NUOC_SX.VisibleIndex = 11;
            this.colItemBHYT_NUOC_SX.Width = 103;
            // 
            // col_STTQDPK
            // 
            this.col_STTQDPK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_STTQDPK.AppearanceHeader.Options.UseFont = true;
            this.col_STTQDPK.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STTQDPK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STTQDPK.Caption = "STT quyết định";
            this.col_STTQDPK.FieldName = "STTQDPK";
            this.col_STTQDPK.Name = "col_STTQDPK";
            this.col_STTQDPK.Visible = true;
            this.col_STTQDPK.VisibleIndex = 25;
            this.col_STTQDPK.Width = 96;
            // 
            // col_QUYCACH
            // 
            this.col_QUYCACH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_QUYCACH.AppearanceHeader.Options.UseFont = true;
            this.col_QUYCACH.AppearanceHeader.Options.UseTextOptions = true;
            this.col_QUYCACH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_QUYCACH.Caption = "Quy cách đóng gói";
            this.col_QUYCACH.FieldName = "QUYCACH";
            this.col_QUYCACH.Name = "col_QUYCACH";
            this.col_QUYCACH.Visible = true;
            this.col_QUYCACH.VisibleIndex = 22;
            this.col_QUYCACH.Width = 119;
            // 
            // col_Generic_BD
            // 
            this.col_Generic_BD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Generic_BD.AppearanceHeader.Options.UseFont = true;
            this.col_Generic_BD.Caption = "Generic/Biệt dược";
            this.col_Generic_BD.ColumnEdit = this.repcbx_Generic_BD;
            this.col_Generic_BD.FieldName = "Generic_BD";
            this.col_Generic_BD.Name = "col_Generic_BD";
            this.col_Generic_BD.Visible = true;
            this.col_Generic_BD.VisibleIndex = 27;
            this.col_Generic_BD.Width = 112;
            // 
            // repcbx_Generic_BD
            // 
            this.repcbx_Generic_BD.AutoHeight = false;
            this.repcbx_Generic_BD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repcbx_Generic_BD.Items.AddRange(new object[] {
            "",
            "B",
            "G"});
            this.repcbx_Generic_BD.Name = "repcbx_Generic_BD";
            // 
            // col_VENCode
            // 
            this.col_VENCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_VENCode.AppearanceHeader.Options.UseFont = true;
            this.col_VENCode.Caption = "VEN";
            this.col_VENCode.ColumnEdit = this.repLkup_VEN;
            this.col_VENCode.FieldName = "VENCode";
            this.col_VENCode.Name = "col_VENCode";
            this.col_VENCode.Visible = true;
            this.col_VENCode.VisibleIndex = 28;
            // 
            // repLkup_VEN
            // 
            this.repLkup_VEN.AutoHeight = false;
            this.repLkup_VEN.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkup_VEN.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VENCode", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VENName", "Ven")});
            this.repLkup_VEN.Name = "repLkup_VEN";
            // 
            // col_Active_TT40
            // 
            this.col_Active_TT40.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Active_TT40.AppearanceHeader.Options.UseFont = true;
            this.col_Active_TT40.Caption = "Mã BC BHYT";
            this.col_Active_TT40.FieldName = "Active_TT40";
            this.col_Active_TT40.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_Active_TT40.Name = "col_Active_TT40";
            this.col_Active_TT40.Visible = true;
            this.col_Active_TT40.VisibleIndex = 4;
            // 
            // col_SalesPrice_Retail
            // 
            this.col_SalesPrice_Retail.AppearanceCell.Options.UseTextOptions = true;
            this.col_SalesPrice_Retail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SalesPrice_Retail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SalesPrice_Retail.AppearanceHeader.Options.UseFont = true;
            this.col_SalesPrice_Retail.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SalesPrice_Retail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SalesPrice_Retail.Caption = "Giá bán lẻ";
            this.col_SalesPrice_Retail.DisplayFormat.FormatString = "#,#.#";
            this.col_SalesPrice_Retail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SalesPrice_Retail.FieldName = "SalesPrice_Retail";
            this.col_SalesPrice_Retail.Name = "col_SalesPrice_Retail";
            this.col_SalesPrice_Retail.Visible = true;
            this.col_SalesPrice_Retail.VisibleIndex = 13;
            this.col_SalesPrice_Retail.Width = 78;
            // 
            // col_UnitOfMeasureCode_Medi
            // 
            this.col_UnitOfMeasureCode_Medi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitOfMeasureCode_Medi.AppearanceHeader.Options.UseFont = true;
            this.col_UnitOfMeasureCode_Medi.Caption = "ĐVT K.Toa";
            this.col_UnitOfMeasureCode_Medi.ColumnEdit = this.repSlkup_UnitOfMeasureCode_Medi;
            this.col_UnitOfMeasureCode_Medi.FieldName = "UnitOfMeasureCode_Medi";
            this.col_UnitOfMeasureCode_Medi.Name = "col_UnitOfMeasureCode_Medi";
            this.col_UnitOfMeasureCode_Medi.Visible = true;
            this.col_UnitOfMeasureCode_Medi.VisibleIndex = 7;
            this.col_UnitOfMeasureCode_Medi.Width = 68;
            // 
            // repSlkup_UnitOfMeasureCode_Medi
            // 
            this.repSlkup_UnitOfMeasureCode_Medi.AutoHeight = false;
            this.repSlkup_UnitOfMeasureCode_Medi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSlkup_UnitOfMeasureCode_Medi.Name = "repSlkup_UnitOfMeasureCode_Medi";
            this.repSlkup_UnitOfMeasureCode_Medi.NullText = "...";
            this.repSlkup_UnitOfMeasureCode_Medi.View = this.repSlkup_UnitOfMeasureCode_MediView;
            // 
            // repSlkup_UnitOfMeasureCode_MediView
            // 
            this.repSlkup_UnitOfMeasureCode_MediView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colViewUOMCode_Medi,
            this.colViewUOMName_Medi});
            this.repSlkup_UnitOfMeasureCode_MediView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSlkup_UnitOfMeasureCode_MediView.Name = "repSlkup_UnitOfMeasureCode_MediView";
            this.repSlkup_UnitOfMeasureCode_MediView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSlkup_UnitOfMeasureCode_MediView.OptionsView.ShowGroupPanel = false;
            // 
            // colViewUOMCode_Medi
            // 
            this.colViewUOMCode_Medi.Caption = "ĐVT";
            this.colViewUOMCode_Medi.FieldName = "UnitOfMeasureCode";
            this.colViewUOMCode_Medi.Name = "colViewUOMCode_Medi";
            // 
            // colViewUOMName_Medi
            // 
            this.colViewUOMName_Medi.Caption = "Đơn vị";
            this.colViewUOMName_Medi.FieldName = "UnitOfMeasureName";
            this.colViewUOMName_Medi.Name = "colViewUOMName_Medi";
            this.colViewUOMName_Medi.Visible = true;
            this.colViewUOMName_Medi.VisibleIndex = 0;
            // 
            // col_Converted_Medi
            // 
            this.col_Converted_Medi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Converted_Medi.AppearanceCell.Options.UseFont = true;
            this.col_Converted_Medi.AppearanceCell.Options.UseTextOptions = true;
            this.col_Converted_Medi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Converted_Medi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Converted_Medi.AppearanceHeader.Options.UseFont = true;
            this.col_Converted_Medi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Converted_Medi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Converted_Medi.Caption = "Q.Đổi SL K.Toa";
            this.col_Converted_Medi.ColumnEdit = this.repChk_Converted_Medi;
            this.col_Converted_Medi.FieldName = "Converted_Medi";
            this.col_Converted_Medi.Name = "col_Converted_Medi";
            this.col_Converted_Medi.Visible = true;
            this.col_Converted_Medi.VisibleIndex = 29;
            this.col_Converted_Medi.Width = 92;
            // 
            // repChk_Converted_Medi
            // 
            this.repChk_Converted_Medi.AutoHeight = false;
            this.repChk_Converted_Medi.Name = "repChk_Converted_Medi";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.chkHide);
            this.groupControl1.Controls.Add(this.btnInGird);
            this.groupControl1.Controls.Add(this.butPrint);
            this.groupControl1.Controls.Add(this.gridControl_Item);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1255, 600);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục thuốc & vật tư y tế";
            // 
            // chkHide
            // 
            this.chkHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHide.AutoSize = true;
            this.chkHide.Location = new System.Drawing.Point(986, 31);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(95, 17);
            this.chkHide.TabIndex = 8;
            this.chkHide.Text = "DM đang dùng";
            this.chkHide.UseVisualStyleBackColor = true;
            this.chkHide.CheckedChanged += new System.EventHandler(this.chkHide_CheckedChanged);
            // 
            // btnInGird
            // 
            this.btnInGird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInGird.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnInGird.Image = ((System.Drawing.Image)(resources.GetObject("btnInGird.Image")));
            this.btnInGird.Location = new System.Drawing.Point(1089, 27);
            this.btnInGird.Name = "btnInGird";
            this.btnInGird.Size = new System.Drawing.Size(96, 23);
            this.btnInGird.TabIndex = 8;
            this.btnInGird.Text = "In theo Gird";
            this.btnInGird.Click += new System.EventHandler(this.btnInGird_Click);
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(1186, 27);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(67, 23);
            this.butPrint.TabIndex = 7;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // frmThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 600);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThuoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh sách thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Packed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Item_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_Item_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_ListBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Check_RepositoryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_Country)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_Country)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_Producer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_Producer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_ListService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Check_VendorCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKupItems_BHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewLKupItems_BHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repcbx_Generic_BD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkup_VEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSlkup_UnitOfMeasureCode_Medi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSlkup_UnitOfMeasureCode_MediView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChk_Converted_Medi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Item;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Item;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Active;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsageCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Unit_Price;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ItemGridLookUpEdit_Usage;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemGridLookUpEditView_Usage;
        private DevExpress.XtraGrid.Columns.GridColumn view_UsageCode;
        private DevExpress.XtraGrid.Columns.GridColumn view_UsageName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ItemGridLookUpEdit_UoM;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemGridLookUpEditView_UoM;
        private DevExpress.XtraGrid.Columns.GridColumn view_UoMCode;
        private DevExpress.XtraGrid.Columns.GridColumn view_UoM_Name;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ItemGridLookUpEdit_Item_Category;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemGridLookUpEditView_Item_Category;
        private DevExpress.XtraGrid.Columns.GridColumn view_ItemCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn view_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit_Status;
        private DevExpress.XtraGrid.Columns.GridColumn col_SalesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_SafelyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rep_Check_RepositoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmloyeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_BHYTPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_ListBHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit_ListBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn col_RateBHYT;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_CountryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProducerCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Note;
        private DevExpress.XtraGrid.Columns.GridColumn col_DisparityPrice;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.Columns.GridColumn col_ListService;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit_ListService;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rep_Check_VendorCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Packed;
        private DevExpress.XtraGrid.Columns.GridColumn col_QtyOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemContent;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ItemGridLookUpEdit_Packed;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn view_Packed_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_STTBCBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn col_SODKGP;
        private DevExpress.XtraGrid.Columns.GridColumn col_STTQDPK;
        private DevExpress.XtraGrid.Columns.GridColumn col_QUYCACH;
        private DevExpress.XtraEditors.SimpleButton btnInGird;
        private DevExpress.XtraGrid.Columns.GridColumn col_Generic_BD;
        private DevExpress.XtraGrid.Columns.GridColumn col_VENCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repcbx_Generic_BD;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLkup_VEN;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repLKupItems_BHYT;
        private DevExpress.XtraGrid.Views.Grid.GridView repViewLKupItems_BHYT;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_STT;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_SO_DANG_KY;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_TEN_THUOC;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_MA_HOAT_CHAT_TT40;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_HOAT_CHAT_TT40;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_HOAT_CHAT_SODK;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_MA_DUONG_DUNG;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_DUONG_DUNG;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_HAM_LUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_DONG_GOI;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_HANG_SX;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBHYT_NUOC_SX;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearch_Producer;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchView_Producer;
        private DevExpress.XtraGrid.Columns.GridColumn colRefProduct_ProducerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRefProduct_ProducerName;
        private DevExpress.XtraGrid.Columns.GridColumn colRefProduct_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearch_Country;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchView_Country;
        private DevExpress.XtraGrid.Columns.GridColumn colRepCountry_CountryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRepCountry_CountryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Active_TT40;
        private System.Windows.Forms.CheckBox chkHide;
        private DevExpress.XtraGrid.Columns.GridColumn col_SalesPrice_Retail;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureCode_Medi;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSlkup_UnitOfMeasureCode_Medi;
        private DevExpress.XtraGrid.Views.Grid.GridView repSlkup_UnitOfMeasureCode_MediView;
        private DevExpress.XtraGrid.Columns.GridColumn colViewUOMCode_Medi;
        private DevExpress.XtraGrid.Columns.GridColumn colViewUOMName_Medi;
        private DevExpress.XtraGrid.Columns.GridColumn col_Converted_Medi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChk_Converted_Medi;
    }
}