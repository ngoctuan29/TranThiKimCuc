namespace Ps.Clinic.ViewPopup
{
    partial class frmVP_VTTHKemTheo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_VTTHKemTheo));
            this.gridControl_Material = new DevExpress.XtraGrid.GridControl();
            this.gridView_Material = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Material_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repsearchMaterial_Item = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repItemChkListBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repsearchMaterial_ItemView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItem_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_SafelyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_ListBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_UsageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_UsageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Material_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Material_UoM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Material_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Material_ObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_ObjectCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Material_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Material_Usage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repMaterial_Usage = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupInfoMedical = new DevExpress.XtraEditors.GroupControl();
            this.butEdit = new DevExpress.XtraEditors.SimpleButton();
            this.butCancel = new DevExpress.XtraEditors.SimpleButton();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.butNew = new DevExpress.XtraEditors.SimpleButton();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Material)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Material)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearchMaterial_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemChkListBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearchMaterial_ItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Material_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_ObjectCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMaterial_Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfoMedical)).BeginInit();
            this.groupInfoMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Material
            // 
            this.gridControl_Material.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_Material.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Material.Location = new System.Drawing.Point(5, 27);
            this.gridControl_Material.MainView = this.gridView_Material;
            this.gridControl_Material.Name = "gridControl_Material";
            this.gridControl_Material.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_Material_UoM,
            this.ref_ObjectCode,
            this.repsearchMaterial_Item,
            this.repMaterial_Usage});
            this.gridControl_Material.Size = new System.Drawing.Size(1004, 459);
            this.gridControl_Material.TabIndex = 7;
            this.gridControl_Material.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Material});
            // 
            // gridView_Material
            // 
            this.gridView_Material.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Material.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Material_ItemCode,
            this.col_Material_UnitOfMeasureCode,
            this.col_Material_Quantity,
            this.col_Material_ObjectCode,
            this.col_Material_Note,
            this.col_Material_Usage});
            this.gridView_Material.GridControl = this.gridControl_Material;
            this.gridView_Material.Name = "gridView_Material";
            this.gridView_Material.NewItemRowText = "Nhập thuốc - vtth kèm theo";
            this.gridView_Material.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Material.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Material.OptionsFind.AllowFindPanel = false;
            this.gridView_Material.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Material.OptionsView.ShowFooter = true;
            this.gridView_Material.OptionsView.ShowGroupPanel = false;
            this.gridView_Material.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Material.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Material_InvalidRowException);
            this.gridView_Material.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Material_ValidateRow);
            this.gridView_Material.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Material_KeyDown);
            this.gridView_Material.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView_Material_KeyPress);
            // 
            // col_Material_ItemCode
            // 
            this.col_Material_ItemCode.Caption = "Tên thuốc";
            this.col_Material_ItemCode.ColumnEdit = this.repsearchMaterial_Item;
            this.col_Material_ItemCode.FieldName = "ItemCode";
            this.col_Material_ItemCode.Name = "col_Material_ItemCode";
            this.col_Material_ItemCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_Material_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Count: {0:#,#}")});
            this.col_Material_ItemCode.Visible = true;
            this.col_Material_ItemCode.VisibleIndex = 0;
            this.col_Material_ItemCode.Width = 279;
            // 
            // repsearchMaterial_Item
            // 
            this.repsearchMaterial_Item.AutoHeight = false;
            this.repsearchMaterial_Item.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repsearchMaterial_Item.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repsearchMaterial_Item.Name = "repsearchMaterial_Item";
            this.repsearchMaterial_Item.NullText = "";
            this.repsearchMaterial_Item.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemChkListBHYT});
            this.repsearchMaterial_Item.View = this.repsearchMaterial_ItemView;
            this.repsearchMaterial_Item.EditValueChanged += new System.EventHandler(this.repsearchMaterial_Item_EditValueChanged);
            // 
            // repItemChkListBHYT
            // 
            this.repItemChkListBHYT.AutoHeight = false;
            this.repItemChkListBHYT.DisplayValueChecked = "1";
            this.repItemChkListBHYT.DisplayValueGrayed = "0";
            this.repItemChkListBHYT.DisplayValueUnchecked = "0";
            this.repItemChkListBHYT.Name = "repItemChkListBHYT";
            this.repItemChkListBHYT.ValueChecked = 1;
            this.repItemChkListBHYT.ValueGrayed = 0;
            this.repItemChkListBHYT.ValueUnchecked = 0;
            // 
            // repsearchMaterial_ItemView
            // 
            this.repsearchMaterial_ItemView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItem_ItemCode,
            this.colItem_ItemName,
            this.colItem_UnitOfMeasureName,
            this.colItem_SafelyQuantity,
            this.colItem_ItemCategoryName,
            this.colItem_UnitOfMeasureCode,
            this.colItem_Active,
            this.colItem_Note,
            this.colItem_ListBHYT,
            this.colItem_UsageCode,
            this.colItem_UsageName});
            this.repsearchMaterial_ItemView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repsearchMaterial_ItemView.Name = "repsearchMaterial_ItemView";
            this.repsearchMaterial_ItemView.OptionsFind.FindFilterColumns = "Active;ItemName";
            this.repsearchMaterial_ItemView.OptionsFind.FindNullPrompt = "Tìm theo hoạt chất và tên thuốc...";
            this.repsearchMaterial_ItemView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repsearchMaterial_ItemView.OptionsView.ShowGroupPanel = false;
            // 
            // colItem_ItemCode
            // 
            this.colItem_ItemCode.Caption = "ItemCode";
            this.colItem_ItemCode.FieldName = "ItemCode";
            this.colItem_ItemCode.Name = "colItem_ItemCode";
            // 
            // colItem_ItemName
            // 
            this.colItem_ItemName.Caption = "Thuốc - vtth";
            this.colItem_ItemName.FieldName = "ItemName";
            this.colItem_ItemName.Name = "colItem_ItemName";
            this.colItem_ItemName.OptionsColumn.ReadOnly = true;
            this.colItem_ItemName.Visible = true;
            this.colItem_ItemName.VisibleIndex = 0;
            this.colItem_ItemName.Width = 181;
            // 
            // colItem_UnitOfMeasureName
            // 
            this.colItem_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.colItem_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.colItem_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem_UnitOfMeasureName.Caption = "ĐVT";
            this.colItem_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.colItem_UnitOfMeasureName.Name = "colItem_UnitOfMeasureName";
            this.colItem_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.colItem_UnitOfMeasureName.Visible = true;
            this.colItem_UnitOfMeasureName.VisibleIndex = 1;
            // 
            // colItem_SafelyQuantity
            // 
            this.colItem_SafelyQuantity.Caption = "Hạn mức tồn";
            this.colItem_SafelyQuantity.FieldName = "SafelyQuantity";
            this.colItem_SafelyQuantity.Name = "colItem_SafelyQuantity";
            this.colItem_SafelyQuantity.OptionsColumn.ReadOnly = true;
            // 
            // colItem_ItemCategoryName
            // 
            this.colItem_ItemCategoryName.Caption = "Loại thuốc";
            this.colItem_ItemCategoryName.FieldName = "ItemCategoryName";
            this.colItem_ItemCategoryName.Name = "colItem_ItemCategoryName";
            this.colItem_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.colItem_ItemCategoryName.Visible = true;
            this.colItem_ItemCategoryName.VisibleIndex = 4;
            this.colItem_ItemCategoryName.Width = 209;
            // 
            // colItem_UnitOfMeasureCode
            // 
            this.colItem_UnitOfMeasureCode.Caption = "UnitOfMeasureCode";
            this.colItem_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.colItem_UnitOfMeasureCode.Name = "colItem_UnitOfMeasureCode";
            // 
            // colItem_Active
            // 
            this.colItem_Active.Caption = "Hoạt chất";
            this.colItem_Active.FieldName = "Active";
            this.colItem_Active.Name = "colItem_Active";
            this.colItem_Active.OptionsColumn.ReadOnly = true;
            this.colItem_Active.Visible = true;
            this.colItem_Active.VisibleIndex = 2;
            this.colItem_Active.Width = 124;
            // 
            // colItem_Note
            // 
            this.colItem_Note.Caption = "Ghi chú";
            this.colItem_Note.FieldName = "Note";
            this.colItem_Note.Name = "colItem_Note";
            this.colItem_Note.OptionsColumn.ReadOnly = true;
            this.colItem_Note.Width = 38;
            // 
            // colItem_ListBHYT
            // 
            this.colItem_ListBHYT.AppearanceCell.Options.UseTextOptions = true;
            this.colItem_ListBHYT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem_ListBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.colItem_ListBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem_ListBHYT.Caption = "Thuốc BHYT";
            this.colItem_ListBHYT.ColumnEdit = this.repItemChkListBHYT;
            this.colItem_ListBHYT.FieldName = "ListBHYT";
            this.colItem_ListBHYT.Name = "colItem_ListBHYT";
            this.colItem_ListBHYT.OptionsColumn.ReadOnly = true;
            this.colItem_ListBHYT.Visible = true;
            this.colItem_ListBHYT.VisibleIndex = 3;
            this.colItem_ListBHYT.Width = 68;
            // 
            // colItem_UsageCode
            // 
            this.colItem_UsageCode.Caption = "UsageCode";
            this.colItem_UsageCode.FieldName = "UsageCode";
            this.colItem_UsageCode.Name = "colItem_UsageCode";
            // 
            // colItem_UsageName
            // 
            this.colItem_UsageName.Caption = "Đường dùng";
            this.colItem_UsageName.FieldName = "UsageName";
            this.colItem_UsageName.Name = "colItem_UsageName";
            this.colItem_UsageName.Visible = true;
            this.colItem_UsageName.VisibleIndex = 5;
            this.colItem_UsageName.Width = 185;
            // 
            // col_Material_UnitOfMeasureCode
            // 
            this.col_Material_UnitOfMeasureCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Material_UnitOfMeasureCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Material_UnitOfMeasureCode.Caption = "ĐVT";
            this.col_Material_UnitOfMeasureCode.ColumnEdit = this.ref_Material_UoM;
            this.col_Material_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.col_Material_UnitOfMeasureCode.Name = "col_Material_UnitOfMeasureCode";
            this.col_Material_UnitOfMeasureCode.OptionsColumn.AllowEdit = false;
            this.col_Material_UnitOfMeasureCode.OptionsColumn.AllowFocus = false;
            this.col_Material_UnitOfMeasureCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_Material_UnitOfMeasureCode.OptionsColumn.ReadOnly = true;
            this.col_Material_UnitOfMeasureCode.Visible = true;
            this.col_Material_UnitOfMeasureCode.VisibleIndex = 1;
            this.col_Material_UnitOfMeasureCode.Width = 71;
            // 
            // ref_Material_UoM
            // 
            this.ref_Material_UoM.AutoHeight = false;
            this.ref_Material_UoM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Material_UoM.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureCode", "Mã ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureName", "Tên ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.ref_Material_UoM.Name = "ref_Material_UoM";
            this.ref_Material_UoM.NullText = "...";
            // 
            // col_Material_Quantity
            // 
            this.col_Material_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_Material_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Material_Quantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Material_Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Material_Quantity.Caption = "SL";
            this.col_Material_Quantity.DisplayFormat.FormatString = "#,#.###";
            this.col_Material_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Material_Quantity.FieldName = "Quantity";
            this.col_Material_Quantity.Name = "col_Material_Quantity";
            this.col_Material_Quantity.OptionsColumn.AllowSize = false;
            this.col_Material_Quantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_Material_Quantity.Visible = true;
            this.col_Material_Quantity.VisibleIndex = 3;
            this.col_Material_Quantity.Width = 50;
            // 
            // col_Material_ObjectCode
            // 
            this.col_Material_ObjectCode.Caption = "Đối tượng";
            this.col_Material_ObjectCode.ColumnEdit = this.ref_ObjectCode;
            this.col_Material_ObjectCode.FieldName = "ObjectCode";
            this.col_Material_ObjectCode.Name = "col_Material_ObjectCode";
            this.col_Material_ObjectCode.Visible = true;
            this.col_Material_ObjectCode.VisibleIndex = 5;
            this.col_Material_ObjectCode.Width = 111;
            // 
            // ref_ObjectCode
            // 
            this.ref_ObjectCode.AutoHeight = false;
            this.ref_ObjectCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_ObjectCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjectCode", "Mã ĐT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjectName", "Đối tượng")});
            this.ref_ObjectCode.Name = "ref_ObjectCode";
            this.ref_ObjectCode.NullText = "...";
            // 
            // col_Material_Note
            // 
            this.col_Material_Note.Caption = "Ghi chú";
            this.col_Material_Note.FieldName = "Note";
            this.col_Material_Note.Name = "col_Material_Note";
            this.col_Material_Note.Visible = true;
            this.col_Material_Note.VisibleIndex = 4;
            this.col_Material_Note.Width = 197;
            // 
            // col_Material_Usage
            // 
            this.col_Material_Usage.Caption = "Đ.Dùng";
            this.col_Material_Usage.ColumnEdit = this.repMaterial_Usage;
            this.col_Material_Usage.FieldName = "UsageCode";
            this.col_Material_Usage.Name = "col_Material_Usage";
            this.col_Material_Usage.OptionsColumn.AllowEdit = false;
            this.col_Material_Usage.OptionsColumn.AllowFocus = false;
            this.col_Material_Usage.OptionsColumn.ReadOnly = true;
            this.col_Material_Usage.Visible = true;
            this.col_Material_Usage.VisibleIndex = 2;
            this.col_Material_Usage.Width = 114;
            // 
            // repMaterial_Usage
            // 
            this.repMaterial_Usage.AutoHeight = false;
            this.repMaterial_Usage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repMaterial_Usage.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UsageCode", "UsageCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UsageName", "Đường dùng")});
            this.repMaterial_Usage.Name = "repMaterial_Usage";
            this.repMaterial_Usage.NullText = "";
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(705, 492);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 1003;
            this.butSave.Text = "F3 - Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // groupInfoMedical
            // 
            this.groupInfoMedical.AppearanceCaption.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInfoMedical.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupInfoMedical.AppearanceCaption.Options.UseFont = true;
            this.groupInfoMedical.AppearanceCaption.Options.UseForeColor = true;
            this.groupInfoMedical.Controls.Add(this.butEdit);
            this.groupInfoMedical.Controls.Add(this.butCancel);
            this.groupInfoMedical.Controls.Add(this.butExit);
            this.groupInfoMedical.Controls.Add(this.butNew);
            this.groupInfoMedical.Controls.Add(this.gridControl_Material);
            this.groupInfoMedical.Controls.Add(this.butSave);
            this.groupInfoMedical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInfoMedical.Location = new System.Drawing.Point(0, 27);
            this.groupInfoMedical.Name = "groupInfoMedical";
            this.groupInfoMedical.Size = new System.Drawing.Size(1014, 519);
            this.groupInfoMedical.TabIndex = 1002;
            this.groupInfoMedical.Text = "Chi Tiết Thuốc - VTTH";
            // 
            // butEdit
            // 
            this.butEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butEdit.Image = ((System.Drawing.Image)(resources.GetObject("butEdit.Image")));
            this.butEdit.Location = new System.Drawing.Point(781, 492);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(75, 23);
            this.butEdit.TabIndex = 1012;
            this.butEdit.Text = "Sửa";
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.Location = new System.Drawing.Point(857, 492);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(77, 23);
            this.butCancel.TabIndex = 1011;
            this.butCancel.Text = "Hủy";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(935, 492);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 1008;
            this.butExit.Text = "Thoát";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butNew
            // 
            this.butNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butNew.Image = ((System.Drawing.Image)(resources.GetObject("butNew.Image")));
            this.butNew.Location = new System.Drawing.Point(626, 492);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(78, 23);
            this.butNew.TabIndex = 1007;
            this.butNew.Text = "F2 -Mới";
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1014, 27);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // frmVP_VTTHKemTheo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 546);
            this.Controls.Add(this.groupInfoMedical);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVP_VTTHKemTheo";
            this.Ribbon = this.ribbon;
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Định mức Thuốc - VTTH theo gói dịch vụ";
            this.Load += new System.EventHandler(this.frmVP_VTTHKemTheo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVP_VTTHKemTheo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Material)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Material)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearchMaterial_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemChkListBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearchMaterial_ItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Material_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_ObjectCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMaterial_Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfoMedical)).EndInit();
            this.groupInfoMedical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraGrid.GridControl gridControl_Material;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Material;
        private DevExpress.XtraGrid.Columns.GridColumn col_Material_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Material_UnitOfMeasureCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Material_UoM;
        private DevExpress.XtraGrid.Columns.GridColumn col_Material_Quantity;
        private DevExpress.XtraEditors.GroupControl groupInfoMedical;
        private DevExpress.XtraGrid.Columns.GridColumn col_Material_ObjectCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_ObjectCode;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraGrid.Columns.GridColumn col_Material_Note;
        private DevExpress.XtraEditors.SimpleButton butCancel;
        private DevExpress.XtraEditors.SimpleButton butEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repsearchMaterial_Item;
        private DevExpress.XtraGrid.Views.Grid.GridView repsearchMaterial_ItemView;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_SafelyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_UnitOfMeasureCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemChkListBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_Active;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_Note;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_ListBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn col_Material_Usage;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repMaterial_Usage;
        private DevExpress.XtraEditors.SimpleButton butNew;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_UsageCode;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_UsageName;
    }
}