namespace Ps.Clinic.ViewPopup
{
    partial class frmCoSoTuTruc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoSoTuTruc));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butSearch = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Safety = new DevExpress.XtraGrid.GridControl();
            this.gridView_Safety = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchBHYT_ItemCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridViewBHYT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchBHYT_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_SalesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_BHYTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_SafelyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_AmountEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_AmountVirtual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_ListBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_RepositoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_RepositoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBHYT_RepositoryGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refUoM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_AmountEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Usage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repUsage = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Limited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refInstruction = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Safety)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Safety)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchBHYT_ItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refUoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refInstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lkupKho);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Controls.Add(this.butSearch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1075, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // lkupKho
            // 
            this.lkupKho.EditValue = "";
            this.lkupKho.Location = new System.Drawing.Point(44, 8);
            this.lkupKho.Name = "lkupKho";
            this.lkupKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupKho.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryCode", "Mã kho", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryName", 120, "Tên kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hide", "Hide", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryGroupCode", "GroupCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupKho.Properties.NullText = "Chọn Kho";
            this.lkupKho.Size = new System.Drawing.Size(383, 20);
            this.lkupKho.TabIndex = 12;
            this.lkupKho.EditValueChanged += new System.EventHandler(this.lkupKho_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Kho :";
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(519, 5);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(85, 23);
            this.butPrint.TabIndex = 1;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butSearch
            // 
            this.butSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSearch.Image = ((System.Drawing.Image)(resources.GetObject("butSearch.Image")));
            this.butSearch.Location = new System.Drawing.Point(433, 5);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(85, 23);
            this.butSearch.TabIndex = 0;
            this.butSearch.Text = "Xem Cơ Số";
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // gridControl_Safety
            // 
            this.gridControl_Safety.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Safety.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Safety.Location = new System.Drawing.Point(0, 33);
            this.gridControl_Safety.MainView = this.gridView_Safety;
            this.gridControl_Safety.Name = "gridControl_Safety";
            this.gridControl_Safety.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refUoM,
            this.refInstruction,
            this.repSearchBHYT_ItemCode,
            this.repUsage});
            this.gridControl_Safety.Size = new System.Drawing.Size(1075, 381);
            this.gridControl_Safety.TabIndex = 9;
            this.gridControl_Safety.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Safety});
            // 
            // gridView_Safety
            // 
            this.gridView_Safety.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Safety.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_Safety.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCode,
            this.col_UnitOfMeasureCode,
            this.col_AmountEnd,
            this.col_Usage,
            this.col_Limited});
            this.gridView_Safety.GridControl = this.gridControl_Safety;
            this.gridView_Safety.IndicatorWidth = 39;
            this.gridView_Safety.Name = "gridView_Safety";
            this.gridView_Safety.NewItemRowText = "Khai báo cơ số tủ trực";
            this.gridView_Safety.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Safety.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Safety.OptionsView.ShowGroupPanel = false;
            this.gridView_Safety.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Safety_InvalidRowException);
            this.gridView_Safety.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Safety_ValidateRow);
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.Caption = "Tên thuốc";
            this.col_ItemCode.ColumnEdit = this.repSearchBHYT_ItemCode;
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_ItemCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Khoản: {0:#,#}")});
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 0;
            this.col_ItemCode.Width = 250;
            // 
            // repSearchBHYT_ItemCode
            // 
            this.repSearchBHYT_ItemCode.AutoHeight = false;
            this.repSearchBHYT_ItemCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repSearchBHYT_ItemCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchBHYT_ItemCode.Name = "repSearchBHYT_ItemCode";
            this.repSearchBHYT_ItemCode.NullText = "";
            this.repSearchBHYT_ItemCode.View = this.gridViewBHYT;
            // 
            // gridViewBHYT
            // 
            this.gridViewBHYT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.searchBHYT_ItemName,
            this.searchBHYT_Active,
            this.searchBHYT_UnitOfMeasureName,
            this.searchBHYT_SalesPrice,
            this.searchBHYT_BHYTPrice,
            this.searchBHYT_SafelyQuantity,
            this.searchBHYT_ItemCategoryName,
            this.searchBHYT_ItemCode,
            this.searchBHYT_UnitOfMeasureCode,
            this.searchBHYT_AmountEnd,
            this.searchBHYT_AmountVirtual,
            this.searchBHYT_Note,
            this.searchBHYT_ListBHYT,
            this.searchBHYT_RepositoryName,
            this.searchBHYT_RepositoryCode,
            this.searchBHYT_RepositoryGroupCode});
            this.gridViewBHYT.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewBHYT.Name = "gridViewBHYT";
            this.gridViewBHYT.OptionsFind.FindFilterColumns = "Active;ItemName";
            this.gridViewBHYT.OptionsFind.FindNullPrompt = "Tìm theo hoạt chất và tên thuốc ...";
            this.gridViewBHYT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewBHYT.OptionsView.ColumnAutoWidth = false;
            this.gridViewBHYT.OptionsView.ShowGroupPanel = false;
            // 
            // searchBHYT_ItemName
            // 
            this.searchBHYT_ItemName.Caption = "Thuốc - VTTH";
            this.searchBHYT_ItemName.FieldName = "ItemName";
            this.searchBHYT_ItemName.Name = "searchBHYT_ItemName";
            this.searchBHYT_ItemName.OptionsColumn.AllowEdit = false;
            this.searchBHYT_ItemName.OptionsColumn.AllowFocus = false;
            this.searchBHYT_ItemName.OptionsColumn.ReadOnly = true;
            this.searchBHYT_ItemName.Visible = true;
            this.searchBHYT_ItemName.VisibleIndex = 0;
            this.searchBHYT_ItemName.Width = 175;
            // 
            // searchBHYT_Active
            // 
            this.searchBHYT_Active.Caption = "Hoạt Chất";
            this.searchBHYT_Active.FieldName = "Active";
            this.searchBHYT_Active.Name = "searchBHYT_Active";
            this.searchBHYT_Active.Visible = true;
            this.searchBHYT_Active.VisibleIndex = 1;
            this.searchBHYT_Active.Width = 136;
            // 
            // searchBHYT_UnitOfMeasureName
            // 
            this.searchBHYT_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.searchBHYT_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.searchBHYT_UnitOfMeasureName.Caption = "ĐVT";
            this.searchBHYT_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.searchBHYT_UnitOfMeasureName.Name = "searchBHYT_UnitOfMeasureName";
            this.searchBHYT_UnitOfMeasureName.Visible = true;
            this.searchBHYT_UnitOfMeasureName.VisibleIndex = 3;
            this.searchBHYT_UnitOfMeasureName.Width = 80;
            // 
            // searchBHYT_SalesPrice
            // 
            this.searchBHYT_SalesPrice.AppearanceCell.Options.UseTextOptions = true;
            this.searchBHYT_SalesPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.searchBHYT_SalesPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.searchBHYT_SalesPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.searchBHYT_SalesPrice.Caption = "Giá bán";
            this.searchBHYT_SalesPrice.DisplayFormat.FormatString = "#,#.#";
            this.searchBHYT_SalesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.searchBHYT_SalesPrice.FieldName = "SalesPrice";
            this.searchBHYT_SalesPrice.Name = "searchBHYT_SalesPrice";
            this.searchBHYT_SalesPrice.Width = 89;
            // 
            // searchBHYT_BHYTPrice
            // 
            this.searchBHYT_BHYTPrice.AppearanceCell.Options.UseTextOptions = true;
            this.searchBHYT_BHYTPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.searchBHYT_BHYTPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.searchBHYT_BHYTPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.searchBHYT_BHYTPrice.Caption = "Giá BHYT";
            this.searchBHYT_BHYTPrice.DisplayFormat.FormatString = "#,#.#";
            this.searchBHYT_BHYTPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.searchBHYT_BHYTPrice.FieldName = "BHYTPrice";
            this.searchBHYT_BHYTPrice.Name = "searchBHYT_BHYTPrice";
            this.searchBHYT_BHYTPrice.Width = 85;
            // 
            // searchBHYT_SafelyQuantity
            // 
            this.searchBHYT_SafelyQuantity.Caption = "Hạn mức";
            this.searchBHYT_SafelyQuantity.DisplayFormat.FormatString = "#,#.#";
            this.searchBHYT_SafelyQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.searchBHYT_SafelyQuantity.FieldName = "SafelyQuantity";
            this.searchBHYT_SafelyQuantity.Name = "searchBHYT_SafelyQuantity";
            // 
            // searchBHYT_ItemCategoryName
            // 
            this.searchBHYT_ItemCategoryName.Caption = "Loại thuốc";
            this.searchBHYT_ItemCategoryName.FieldName = "ItemCategoryName";
            this.searchBHYT_ItemCategoryName.Name = "searchBHYT_ItemCategoryName";
            this.searchBHYT_ItemCategoryName.Visible = true;
            this.searchBHYT_ItemCategoryName.VisibleIndex = 5;
            this.searchBHYT_ItemCategoryName.Width = 153;
            // 
            // searchBHYT_ItemCode
            // 
            this.searchBHYT_ItemCode.Caption = "ItemCode";
            this.searchBHYT_ItemCode.FieldName = "ItemCode";
            this.searchBHYT_ItemCode.Name = "searchBHYT_ItemCode";
            // 
            // searchBHYT_UnitOfMeasureCode
            // 
            this.searchBHYT_UnitOfMeasureCode.Caption = "UnitOfMeasureCode";
            this.searchBHYT_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.searchBHYT_UnitOfMeasureCode.Name = "searchBHYT_UnitOfMeasureCode";
            // 
            // searchBHYT_AmountEnd
            // 
            this.searchBHYT_AmountEnd.AppearanceCell.Options.UseTextOptions = true;
            this.searchBHYT_AmountEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.searchBHYT_AmountEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.searchBHYT_AmountEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.searchBHYT_AmountEnd.Caption = "Tồn kho";
            this.searchBHYT_AmountEnd.DisplayFormat.FormatString = "#,#.#";
            this.searchBHYT_AmountEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.searchBHYT_AmountEnd.FieldName = "AmountEnd";
            this.searchBHYT_AmountEnd.Name = "searchBHYT_AmountEnd";
            this.searchBHYT_AmountEnd.Visible = true;
            this.searchBHYT_AmountEnd.VisibleIndex = 4;
            this.searchBHYT_AmountEnd.Width = 76;
            // 
            // searchBHYT_AmountVirtual
            // 
            this.searchBHYT_AmountVirtual.Caption = "Tồn ảo";
            this.searchBHYT_AmountVirtual.DisplayFormat.FormatString = "#,#.#";
            this.searchBHYT_AmountVirtual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.searchBHYT_AmountVirtual.FieldName = "AmountVirtual";
            this.searchBHYT_AmountVirtual.Name = "searchBHYT_AmountVirtual";
            // 
            // searchBHYT_Note
            // 
            this.searchBHYT_Note.Caption = "Ghi chú";
            this.searchBHYT_Note.FieldName = "Note";
            this.searchBHYT_Note.Name = "searchBHYT_Note";
            // 
            // searchBHYT_ListBHYT
            // 
            this.searchBHYT_ListBHYT.AppearanceCell.Options.UseTextOptions = true;
            this.searchBHYT_ListBHYT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.searchBHYT_ListBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.searchBHYT_ListBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.searchBHYT_ListBHYT.Caption = "Thuốc BHYT";
            this.searchBHYT_ListBHYT.FieldName = "ListBHYT";
            this.searchBHYT_ListBHYT.Name = "searchBHYT_ListBHYT";
            this.searchBHYT_ListBHYT.OptionsColumn.AllowEdit = false;
            this.searchBHYT_ListBHYT.OptionsColumn.AllowFocus = false;
            this.searchBHYT_ListBHYT.OptionsColumn.ReadOnly = true;
            this.searchBHYT_ListBHYT.Visible = true;
            this.searchBHYT_ListBHYT.VisibleIndex = 2;
            this.searchBHYT_ListBHYT.Width = 69;
            // 
            // searchBHYT_RepositoryName
            // 
            this.searchBHYT_RepositoryName.Caption = "Kho";
            this.searchBHYT_RepositoryName.FieldName = "RepositoryName";
            this.searchBHYT_RepositoryName.Name = "searchBHYT_RepositoryName";
            this.searchBHYT_RepositoryName.OptionsColumn.AllowEdit = false;
            this.searchBHYT_RepositoryName.OptionsColumn.AllowFocus = false;
            this.searchBHYT_RepositoryName.OptionsColumn.ReadOnly = true;
            this.searchBHYT_RepositoryName.Visible = true;
            this.searchBHYT_RepositoryName.VisibleIndex = 6;
            this.searchBHYT_RepositoryName.Width = 153;
            // 
            // searchBHYT_RepositoryCode
            // 
            this.searchBHYT_RepositoryCode.Caption = "RepositoryCode";
            this.searchBHYT_RepositoryCode.FieldName = "RepositoryCode";
            this.searchBHYT_RepositoryCode.Name = "searchBHYT_RepositoryCode";
            // 
            // searchBHYT_RepositoryGroupCode
            // 
            this.searchBHYT_RepositoryGroupCode.Caption = "RepositoryGroupCode";
            this.searchBHYT_RepositoryGroupCode.FieldName = "RepositoryGroupCode";
            this.searchBHYT_RepositoryGroupCode.Name = "searchBHYT_RepositoryGroupCode";
            // 
            // col_UnitOfMeasureCode
            // 
            this.col_UnitOfMeasureCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureCode.Caption = "ĐVT";
            this.col_UnitOfMeasureCode.ColumnEdit = this.refUoM;
            this.col_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.col_UnitOfMeasureCode.Name = "col_UnitOfMeasureCode";
            this.col_UnitOfMeasureCode.OptionsColumn.AllowEdit = false;
            this.col_UnitOfMeasureCode.OptionsColumn.AllowFocus = false;
            this.col_UnitOfMeasureCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_UnitOfMeasureCode.OptionsColumn.ReadOnly = true;
            this.col_UnitOfMeasureCode.Visible = true;
            this.col_UnitOfMeasureCode.VisibleIndex = 1;
            this.col_UnitOfMeasureCode.Width = 78;
            // 
            // refUoM
            // 
            this.refUoM.AutoHeight = false;
            this.refUoM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refUoM.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureCode", "Mã ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureName", "Tên ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.refUoM.Name = "refUoM";
            this.refUoM.NullText = "...";
            // 
            // col_AmountEnd
            // 
            this.col_AmountEnd.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.Caption = "Tồn cuối";
            this.col_AmountEnd.DisplayFormat.FormatString = "#,###";
            this.col_AmountEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountEnd.FieldName = "AmountEnd";
            this.col_AmountEnd.Name = "col_AmountEnd";
            this.col_AmountEnd.Visible = true;
            this.col_AmountEnd.VisibleIndex = 4;
            this.col_AmountEnd.Width = 90;
            // 
            // col_Usage
            // 
            this.col_Usage.Caption = "Đ.Dùng";
            this.col_Usage.ColumnEdit = this.repUsage;
            this.col_Usage.FieldName = "UsageCode";
            this.col_Usage.Name = "col_Usage";
            this.col_Usage.OptionsColumn.AllowEdit = false;
            this.col_Usage.OptionsColumn.AllowFocus = false;
            this.col_Usage.OptionsColumn.ReadOnly = true;
            this.col_Usage.Visible = true;
            this.col_Usage.VisibleIndex = 2;
            this.col_Usage.Width = 156;
            // 
            // repUsage
            // 
            this.repUsage.AutoHeight = false;
            this.repUsage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repUsage.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UsageCode", "Usage", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UsageName", "Đường dùng")});
            this.repUsage.Name = "repUsage";
            this.repUsage.NullText = "";
            // 
            // col_Limited
            // 
            this.col_Limited.AppearanceCell.Options.UseTextOptions = true;
            this.col_Limited.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Limited.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Limited.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Limited.Caption = "Cơ số";
            this.col_Limited.DisplayFormat.FormatString = "#,###";
            this.col_Limited.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Limited.FieldName = "Quantity";
            this.col_Limited.Name = "col_Limited";
            this.col_Limited.Visible = true;
            this.col_Limited.VisibleIndex = 3;
            this.col_Limited.Width = 83;
            // 
            // refInstruction
            // 
            this.refInstruction.AutoHeight = false;
            this.refInstruction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refInstruction.Name = "refInstruction";
            // 
            // frmCoSoTuTruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 414);
            this.Controls.Add(this.gridControl_Safety);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCoSoTuTruc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo hạn mức tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCoSoTuTruc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Safety)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Safety)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchBHYT_ItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refUoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refInstruction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butSearch;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Safety;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Safety;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchBHYT_ItemCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_Active;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_SalesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_BHYTPrice;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_SafelyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_UnitOfMeasureCode;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_AmountEnd;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_AmountVirtual;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_Note;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_ListBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_RepositoryName;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_RepositoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn searchBHYT_RepositoryGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit refUoM;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox refInstruction;
        private DevExpress.XtraGrid.Columns.GridColumn col_Usage;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repUsage;
        private DevExpress.XtraGrid.Columns.GridColumn col_Limited;
    }
}