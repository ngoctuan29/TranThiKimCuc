namespace Ps.Clinic.ViewPopup
{
    partial class frmTheKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheKho));
            this.repCheckItem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupResult = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountExists = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_WorkingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ExportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Content = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnParameter = new DevExpress.XtraEditors.PanelControl();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_ItemList = new DevExpress.XtraGrid.GridControl();
            this.gridView_ItemList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colList_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colList_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colList_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colList_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colList_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colList_CheckAll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.ViewGrid = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.col_EmployeeCodeExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeCodeImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeNameReceive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupResult)).BeginInit();
            this.groupResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnParameter)).BeginInit();
            this.pnParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // repCheckItem
            // 
            this.repCheckItem.AutoHeight = false;
            this.repCheckItem.DisplayValueChecked = "1";
            this.repCheckItem.DisplayValueGrayed = "0";
            this.repCheckItem.DisplayValueUnchecked = "0";
            this.repCheckItem.Name = "repCheckItem";
            this.repCheckItem.ValueChecked = 1;
            this.repCheckItem.ValueGrayed = "0";
            this.repCheckItem.ValueUnchecked = 0;
            // 
            // groupResult
            // 
            this.groupResult.Controls.Add(this.gridControl_Result);
            this.groupResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResult.Location = new System.Drawing.Point(441, 0);
            this.groupResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupResult.Name = "groupResult";
            this.groupResult.Size = new System.Drawing.Size(724, 647);
            this.groupResult.TabIndex = 2;
            this.groupResult.Text = "Chi tiết nhập xuất thuốc";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Result.Location = new System.Drawing.Point(2, 25);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(720, 620);
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
            this.col_AmountImport,
            this.col_AmountExport,
            this.col_AmountEnd,
            this.col_ItemCategoryName,
            this.col_GroupName,
            this.col_AmountExists,
            this.col_WorkingDate,
            this.col_ImportDate,
            this.col_ExportDate,
            this.col_Content,
            this.col_Note,
            this.col_EmployeeCodeExport,
            this.col_EmployeeCodeImport,
            this.col_EmployeeNameReceive});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsBehavior.Editable = false;
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 0;
            this.col_ItemCode.Width = 70;
            // 
            // col_ItemName
            // 
            this.col_ItemName.Caption = "Tên thuốc - vtyt";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.OptionsColumn.AllowEdit = false;
            this.col_ItemName.OptionsColumn.AllowFocus = false;
            this.col_ItemName.OptionsColumn.ReadOnly = true;
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 1;
            this.col_ItemName.Width = 206;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.Caption = "ĐVT";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.col_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.col_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 2;
            this.col_UnitOfMeasureName.Width = 61;
            // 
            // col_AmountImport
            // 
            this.col_AmountImport.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountImport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountImport.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountImport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountImport.Caption = "Nhập";
            this.col_AmountImport.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountImport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountImport.FieldName = "AmountImport";
            this.col_AmountImport.Name = "col_AmountImport";
            this.col_AmountImport.OptionsColumn.AllowEdit = false;
            this.col_AmountImport.OptionsColumn.AllowFocus = false;
            this.col_AmountImport.OptionsColumn.ReadOnly = true;
            this.col_AmountImport.Visible = true;
            this.col_AmountImport.VisibleIndex = 7;
            this.col_AmountImport.Width = 72;
            // 
            // col_AmountExport
            // 
            this.col_AmountExport.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountExport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountExport.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountExport.Caption = "Xuất";
            this.col_AmountExport.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountExport.FieldName = "AmountExport";
            this.col_AmountExport.Name = "col_AmountExport";
            this.col_AmountExport.OptionsColumn.AllowEdit = false;
            this.col_AmountExport.OptionsColumn.AllowFocus = false;
            this.col_AmountExport.OptionsColumn.ReadOnly = true;
            this.col_AmountExport.Visible = true;
            this.col_AmountExport.VisibleIndex = 8;
            this.col_AmountExport.Width = 68;
            // 
            // col_AmountEnd
            // 
            this.col_AmountEnd.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.Caption = "Tồn cuối";
            this.col_AmountEnd.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountEnd.FieldName = "AmountEnd";
            this.col_AmountEnd.Name = "col_AmountEnd";
            this.col_AmountEnd.OptionsColumn.ReadOnly = true;
            this.col_AmountEnd.UnboundExpression = "[DauKi] + [Nhap] - [Xuat]";
            this.col_AmountEnd.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.Caption = "Loại";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.OptionsColumn.AllowEdit = false;
            this.col_ItemCategoryName.OptionsColumn.AllowFocus = false;
            this.col_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 11;
            this.col_ItemCategoryName.Width = 177;
            // 
            // col_GroupName
            // 
            this.col_GroupName.Caption = "Nhóm";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.OptionsColumn.AllowEdit = false;
            this.col_GroupName.OptionsColumn.AllowFocus = false;
            this.col_GroupName.OptionsColumn.ReadOnly = true;
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 12;
            this.col_GroupName.Width = 201;
            // 
            // col_AmountExists
            // 
            this.col_AmountExists.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountExists.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountExists.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountExists.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountExists.Caption = "Tồn";
            this.col_AmountExists.DisplayFormat.FormatString = "{0:#,###}";
            this.col_AmountExists.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountExists.FieldName = "AmountExists";
            this.col_AmountExists.Name = "col_AmountExists";
            this.col_AmountExists.Visible = true;
            this.col_AmountExists.VisibleIndex = 9;
            // 
            // col_WorkingDate
            // 
            this.col_WorkingDate.Caption = "Ngày";
            this.col_WorkingDate.FieldName = "WorkingDate";
            this.col_WorkingDate.Name = "col_WorkingDate";
            this.col_WorkingDate.Visible = true;
            this.col_WorkingDate.VisibleIndex = 3;
            this.col_WorkingDate.Width = 82;
            // 
            // col_ImportDate
            // 
            this.col_ImportDate.Caption = "Ngày nhập";
            this.col_ImportDate.FieldName = "ImportDate";
            this.col_ImportDate.Name = "col_ImportDate";
            this.col_ImportDate.Visible = true;
            this.col_ImportDate.VisibleIndex = 4;
            this.col_ImportDate.Width = 85;
            // 
            // col_ExportDate
            // 
            this.col_ExportDate.Caption = "Ngày xuất";
            this.col_ExportDate.FieldName = "ExportDate";
            this.col_ExportDate.Name = "col_ExportDate";
            this.col_ExportDate.Visible = true;
            this.col_ExportDate.VisibleIndex = 5;
            this.col_ExportDate.Width = 73;
            // 
            // col_Content
            // 
            this.col_Content.Caption = "Nội dung";
            this.col_Content.FieldName = "Content";
            this.col_Content.Name = "col_Content";
            this.col_Content.Visible = true;
            this.col_Content.VisibleIndex = 6;
            this.col_Content.Width = 148;
            // 
            // col_Note
            // 
            this.col_Note.Caption = "Ghi chú";
            this.col_Note.FieldName = "Note";
            this.col_Note.Name = "col_Note";
            this.col_Note.Visible = true;
            this.col_Note.VisibleIndex = 10;
            this.col_Note.Width = 147;
            // 
            // pnParameter
            // 
            this.pnParameter.Controls.Add(this.btnRefesh);
            this.pnParameter.Controls.Add(this.gridControl_ItemList);
            this.pnParameter.Controls.Add(this.dateTo);
            this.pnParameter.Controls.Add(this.dateFrom);
            this.pnParameter.Controls.Add(this.lkupKho);
            this.pnParameter.Controls.Add(this.ViewGrid);
            this.pnParameter.Controls.Add(this.butPrint);
            this.pnParameter.Controls.Add(this.butCount);
            this.pnParameter.Controls.Add(this.labelControl3);
            this.pnParameter.Controls.Add(this.labelControl2);
            this.pnParameter.Controls.Add(this.labelControl4);
            this.pnParameter.Controls.Add(this.labelControl1);
            this.pnParameter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnParameter.Location = new System.Drawing.Point(0, 0);
            this.pnParameter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnParameter.Name = "pnParameter";
            this.pnParameter.Size = new System.Drawing.Size(441, 647);
            this.pnParameter.TabIndex = 0;
            // 
            // btnRefesh
            // 
            this.btnRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefesh.Location = new System.Drawing.Point(404, 62);
            this.btnRefesh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(26, 28);
            this.btnRefesh.TabIndex = 1021;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // gridControl_ItemList
            // 
            this.gridControl_ItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_ItemList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_ItemList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_ItemList.Location = new System.Drawing.Point(7, 91);
            this.gridControl_ItemList.MainView = this.gridView_ItemList;
            this.gridControl_ItemList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_ItemList.Name = "gridControl_ItemList";
            this.gridControl_ItemList.Size = new System.Drawing.Size(422, 511);
            this.gridControl_ItemList.TabIndex = 1020;
            this.gridControl_ItemList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ItemList});
            // 
            // gridView_ItemList
            // 
            this.gridView_ItemList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colList_ItemCategoryName,
            this.colList_ItemCode,
            this.colList_ItemName,
            this.colList_UnitOfMeasureName,
            this.colList_GroupName,
            this.colList_CheckAll});
            this.gridView_ItemList.GridControl = this.gridControl_ItemList;
            this.gridView_ItemList.GroupPanelText = "Nhóm dữ liệu";
            this.gridView_ItemList.Name = "gridView_ItemList";
            this.gridView_ItemList.OptionsView.ColumnAutoWidth = false;
            this.gridView_ItemList.OptionsView.ShowFooter = true;
            // 
            // colList_ItemCategoryName
            // 
            this.colList_ItemCategoryName.Caption = "Loại thuốc";
            this.colList_ItemCategoryName.FieldName = "ItemCategoryName";
            this.colList_ItemCategoryName.Name = "colList_ItemCategoryName";
            this.colList_ItemCategoryName.OptionsColumn.AllowEdit = false;
            this.colList_ItemCategoryName.OptionsColumn.AllowFocus = false;
            this.colList_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.colList_ItemCategoryName.Visible = true;
            this.colList_ItemCategoryName.VisibleIndex = 4;
            this.colList_ItemCategoryName.Width = 177;
            // 
            // colList_ItemCode
            // 
            this.colList_ItemCode.Caption = "Mã thuốc";
            this.colList_ItemCode.FieldName = "ItemCode";
            this.colList_ItemCode.Name = "colList_ItemCode";
            this.colList_ItemCode.OptionsColumn.AllowEdit = false;
            this.colList_ItemCode.OptionsColumn.AllowFocus = false;
            this.colList_ItemCode.OptionsColumn.ReadOnly = true;
            this.colList_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "{0:#,#}")});
            this.colList_ItemCode.Visible = true;
            this.colList_ItemCode.VisibleIndex = 1;
            this.colList_ItemCode.Width = 83;
            // 
            // colList_ItemName
            // 
            this.colList_ItemName.Caption = "Tên thuốc";
            this.colList_ItemName.FieldName = "ItemName";
            this.colList_ItemName.Name = "colList_ItemName";
            this.colList_ItemName.OptionsColumn.AllowEdit = false;
            this.colList_ItemName.OptionsColumn.AllowFocus = false;
            this.colList_ItemName.OptionsColumn.ReadOnly = true;
            this.colList_ItemName.Visible = true;
            this.colList_ItemName.VisibleIndex = 2;
            this.colList_ItemName.Width = 212;
            // 
            // colList_UnitOfMeasureName
            // 
            this.colList_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.colList_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colList_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.colList_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colList_UnitOfMeasureName.Caption = "ĐVT";
            this.colList_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.colList_UnitOfMeasureName.Name = "colList_UnitOfMeasureName";
            this.colList_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.colList_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.colList_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.colList_UnitOfMeasureName.Visible = true;
            this.colList_UnitOfMeasureName.VisibleIndex = 3;
            this.colList_UnitOfMeasureName.Width = 68;
            // 
            // colList_GroupName
            // 
            this.colList_GroupName.Caption = "Nhóm thuốc";
            this.colList_GroupName.FieldName = "GroupName";
            this.colList_GroupName.Name = "colList_GroupName";
            this.colList_GroupName.OptionsColumn.AllowEdit = false;
            this.colList_GroupName.OptionsColumn.AllowFocus = false;
            this.colList_GroupName.OptionsColumn.ReadOnly = true;
            this.colList_GroupName.Visible = true;
            this.colList_GroupName.VisibleIndex = 5;
            this.colList_GroupName.Width = 196;
            // 
            // colList_CheckAll
            // 
            this.colList_CheckAll.AppearanceCell.Options.UseTextOptions = true;
            this.colList_CheckAll.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colList_CheckAll.AppearanceHeader.Options.UseTextOptions = true;
            this.colList_CheckAll.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colList_CheckAll.Caption = "Chọn";
            this.colList_CheckAll.ColumnEdit = this.repCheckItem;
            this.colList_CheckAll.FieldName = "CheckAll";
            this.colList_CheckAll.Name = "colList_CheckAll";
            this.colList_CheckAll.Visible = true;
            this.colList_CheckAll.VisibleIndex = 0;
            this.colList_CheckAll.Width = 34;
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(296, 10);
            this.dateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dateTo.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.dateTo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dateTo.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateTo.Size = new System.Drawing.Size(133, 22);
            this.dateTo.TabIndex = 1019;
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(65, 10);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dateFrom.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.dateFrom.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dateFrom.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateFrom.Size = new System.Drawing.Size(141, 22);
            this.dateFrom.TabIndex = 1018;
            // 
            // lkupKho
            // 
            this.lkupKho.Location = new System.Drawing.Point(65, 37);
            this.lkupKho.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.lkupKho.Size = new System.Drawing.Size(364, 22);
            this.lkupKho.TabIndex = 10;
            this.lkupKho.EditValueChanged += new System.EventHandler(this.lkupKho_EditValueChanged);
            // 
            // ViewGrid
            // 
            this.ViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ViewGrid.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.ViewGrid.Enabled = false;
            this.ViewGrid.Image = ((System.Drawing.Image)(resources.GetObject("ViewGrid.Image")));
            this.ViewGrid.Location = new System.Drawing.Point(325, 608);
            this.ViewGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewGrid.Name = "ViewGrid";
            this.ViewGrid.Size = new System.Drawing.Size(94, 33);
            this.ViewGrid.TabIndex = 5;
            this.ViewGrid.Text = "In Grid";
            this.ViewGrid.Click += new System.EventHandler(this.ViewGrid_Click);
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Enabled = false;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(225, 608);
            this.butPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(94, 33);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butCount
            // 
            this.butCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(124, 608);
            this.butCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(100, 33);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Lấy dữ liệu";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(231, 14);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 17);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Đến ngày :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 14);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Từ ngày :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 68);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(151, 17);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Danh sách thuốc - VTTH";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kho :";
            // 
            // col_EmployeeCodeExport
            // 
            this.col_EmployeeCodeExport.Caption = "nhân viên xuất";
            this.col_EmployeeCodeExport.FieldName = "EmployeeCodeExport";
            this.col_EmployeeCodeExport.Name = "col_EmployeeCodeExport";
            this.col_EmployeeCodeExport.Visible = true;
            this.col_EmployeeCodeExport.VisibleIndex = 13;
            // 
            // col_EmployeeCodeImport
            // 
            this.col_EmployeeCodeImport.Caption = "gridColumn2";
            this.col_EmployeeCodeImport.FieldName = "EmployeeCodeImport";
            this.col_EmployeeCodeImport.Name = "col_EmployeeCodeImport";
            this.col_EmployeeCodeImport.Visible = true;
            this.col_EmployeeCodeImport.VisibleIndex = 14;
            // 
            // col_EmployeeNameReceive
            // 
            this.col_EmployeeNameReceive.Caption = "Người nhận";
            this.col_EmployeeNameReceive.FieldName = "EmployeeNameReceive";
            this.col_EmployeeNameReceive.Name = "col_EmployeeNameReceive";
            this.col_EmployeeNameReceive.Visible = true;
            this.col_EmployeeNameReceive.VisibleIndex = 15;
            // 
            // frmTheKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 647);
            this.Controls.Add(this.groupResult);
            this.Controls.Add(this.pnParameter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTheKho";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo nhập xuất tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.repCheckItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupResult)).EndInit();
            this.groupResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnParameter)).EndInit();
            this.pnParameter.ResumeLayout(false);
            this.pnParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnParameter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountImport;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountExport;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountEnd;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraGrid.GridControl gridControl_ItemList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ItemList;
        private DevExpress.XtraGrid.Columns.GridColumn colList_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colList_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colList_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colList_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn colList_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colList_CheckAll;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupResult;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountExists;
        private DevExpress.XtraGrid.Columns.GridColumn col_WorkingDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ImportDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ExportDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_Content;
        private DevExpress.XtraGrid.Columns.GridColumn col_Note;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckItem;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.SimpleButton ViewGrid;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCodeExport;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCodeImport;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeNameReceive;
    }
}