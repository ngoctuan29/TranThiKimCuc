namespace Ps.Clinic.Statistics
{
    partial class frmBangKeChiTietThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangKeChiTietThuoc));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.sLookupItem = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDateto = new DevExpress.XtraEditors.DateEdit();
            this.txtDatefrom = new DevExpress.XtraEditors.DateEdit();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Shipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientBirthyear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MedicalRecordCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_QuantityExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SalesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DoiTuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_LK_ObjectCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Doctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_LKDocTor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Usage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLK_Usage = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Paid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sLookupItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatefrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_LK_ObjectCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_LKDocTor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLK_Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.sLookupItem);
            this.grMain.Controls.Add(this.txtDateto);
            this.grMain.Controls.Add(this.txtDatefrom);
            this.grMain.Controls.Add(this.lkupKho);
            this.grMain.Controls.Add(this.labelControl1);
            this.grMain.Controls.Add(this.butPrint);
            this.grMain.Controls.Add(this.labelControl4);
            this.grMain.Controls.Add(this.labelControl2);
            this.grMain.Controls.Add(this.butCount);
            this.grMain.Controls.Add(this.labelControl3);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(233, 647);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Thông số";
            // 
            // sLookupItem
            // 
            this.sLookupItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sLookupItem.EditValue = "";
            this.sLookupItem.Location = new System.Drawing.Point(68, 143);
            this.sLookupItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sLookupItem.Name = "sLookupItem";
            this.sLookupItem.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.sLookupItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sLookupItem.Properties.NullText = "";
            this.sLookupItem.Properties.View = this.searchLookUpEdit1View;
            this.sLookupItem.Size = new System.Drawing.Size(157, 22);
            this.sLookupItem.TabIndex = 12;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtDateto
            // 
            this.txtDateto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateto.EditValue = null;
            this.txtDateto.Location = new System.Drawing.Point(68, 106);
            this.txtDateto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDateto.Name = "txtDateto";
            this.txtDateto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateto.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateto.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDateto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateto.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtDateto.Size = new System.Drawing.Size(157, 22);
            this.txtDateto.TabIndex = 11;
            // 
            // txtDatefrom
            // 
            this.txtDatefrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatefrom.EditValue = null;
            this.txtDatefrom.Location = new System.Drawing.Point(68, 75);
            this.txtDatefrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDatefrom.Name = "txtDatefrom";
            this.txtDatefrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDatefrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDatefrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDatefrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDatefrom.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtDatefrom.Size = new System.Drawing.Size(157, 22);
            this.txtDatefrom.TabIndex = 11;
            // 
            // lkupKho
            // 
            this.lkupKho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupKho.Location = new System.Drawing.Point(68, 44);
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
            this.lkupKho.Size = new System.Drawing.Size(157, 22);
            this.lkupKho.TabIndex = 10;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 48);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kho :";
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(164, 171);
            this.butPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(61, 28);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 110);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 17);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Đến ngày :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 79);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Từ ngày :";
            // 
            // butCount
            // 
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(68, 171);
            this.butCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(96, 28);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Lấy dữ liệu";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 146);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 17);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Thuốc :";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Result.Location = new System.Drawing.Point(2, 25);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_LK_ObjectCode,
            this.rep_LKDocTor,
            this.repLK_Usage});
            this.gridControl_Result.Size = new System.Drawing.Size(922, 620);
            this.gridControl_Result.TabIndex = 1;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemName,
            this.col_UnitOfMeasureName,
            this.col_ItemCategoryName,
            this.col_GroupName,
            this.col_DateEnd,
            this.col_Shipment,
            this.col_Quantity,
            this.col_PatientCode,
            this.col_PatientName,
            this.col_PatientGenderName,
            this.col_PatientBirthyear,
            this.col_DepartmentName,
            this.col_MedicalRecordCode,
            this.col_QuantityExport,
            this.col_UnitPrice,
            this.col_SalesPrice,
            this.col_PostingDate,
            this.col_DoiTuong,
            this.col_Doctor,
            this.col_Usage,
            this.col_amount,
            this.col_Paid});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.AlwaysVisible = true;
            this.gridView_Result.OptionsFind.FindNullPrompt = "Nhập nội dung cần tìm";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
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
            this.col_ItemName.VisibleIndex = 6;
            this.col_ItemName.Width = 159;
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
            this.col_UnitOfMeasureName.VisibleIndex = 9;
            this.col_UnitOfMeasureName.Width = 45;
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
            this.col_ItemCategoryName.VisibleIndex = 17;
            this.col_ItemCategoryName.Width = 157;
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
            this.col_GroupName.VisibleIndex = 18;
            this.col_GroupName.Width = 139;
            // 
            // col_DateEnd
            // 
            this.col_DateEnd.Caption = "Hạn dùng";
            this.col_DateEnd.DisplayFormat.FormatString = "MM/yyyy";
            this.col_DateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_DateEnd.FieldName = "DateEnd";
            this.col_DateEnd.Name = "col_DateEnd";
            this.col_DateEnd.OptionsColumn.AllowEdit = false;
            this.col_DateEnd.OptionsColumn.AllowFocus = false;
            this.col_DateEnd.OptionsColumn.ReadOnly = true;
            this.col_DateEnd.Visible = true;
            this.col_DateEnd.VisibleIndex = 15;
            this.col_DateEnd.Width = 99;
            // 
            // col_Shipment
            // 
            this.col_Shipment.Caption = "Lô SX";
            this.col_Shipment.FieldName = "Shipment";
            this.col_Shipment.Name = "col_Shipment";
            this.col_Shipment.OptionsColumn.AllowEdit = false;
            this.col_Shipment.OptionsColumn.AllowFocus = false;
            this.col_Shipment.OptionsColumn.ReadOnly = true;
            this.col_Shipment.Visible = true;
            this.col_Shipment.VisibleIndex = 16;
            this.col_Shipment.Width = 98;
            // 
            // col_Quantity
            // 
            this.col_Quantity.Caption = "Số lượng";
            this.col_Quantity.DisplayFormat.FormatString = "#,#.##";
            this.col_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Quantity.Name = "col_Quantity";
            this.col_Quantity.OptionsColumn.AllowEdit = false;
            this.col_Quantity.OptionsColumn.AllowFocus = false;
            this.col_Quantity.OptionsColumn.ReadOnly = true;
            this.col_Quantity.Width = 56;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.Caption = "Mã BN";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 1;
            this.col_PatientCode.Width = 83;
            // 
            // col_PatientName
            // 
            this.col_PatientName.Caption = "Họ tên";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.OptionsColumn.AllowEdit = false;
            this.col_PatientName.OptionsColumn.AllowFocus = false;
            this.col_PatientName.OptionsColumn.ReadOnly = true;
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 2;
            this.col_PatientName.Width = 136;
            // 
            // col_PatientGenderName
            // 
            this.col_PatientGenderName.Caption = "Giới tính";
            this.col_PatientGenderName.FieldName = "PatientGenderName";
            this.col_PatientGenderName.Name = "col_PatientGenderName";
            this.col_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.col_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.col_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.col_PatientGenderName.Visible = true;
            this.col_PatientGenderName.VisibleIndex = 3;
            this.col_PatientGenderName.Width = 56;
            // 
            // col_PatientBirthyear
            // 
            this.col_PatientBirthyear.Caption = "Năm sinh";
            this.col_PatientBirthyear.FieldName = "PatientBirthyear";
            this.col_PatientBirthyear.Name = "col_PatientBirthyear";
            this.col_PatientBirthyear.OptionsColumn.AllowEdit = false;
            this.col_PatientBirthyear.OptionsColumn.AllowFocus = false;
            this.col_PatientBirthyear.OptionsColumn.ReadOnly = true;
            this.col_PatientBirthyear.Visible = true;
            this.col_PatientBirthyear.VisibleIndex = 4;
            this.col_PatientBirthyear.Width = 57;
            // 
            // col_DepartmentName
            // 
            this.col_DepartmentName.Caption = "Phòng khám";
            this.col_DepartmentName.FieldName = "DepartmentName";
            this.col_DepartmentName.Name = "col_DepartmentName";
            this.col_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_DepartmentName.OptionsColumn.ReadOnly = true;
            this.col_DepartmentName.Visible = true;
            this.col_DepartmentName.VisibleIndex = 5;
            this.col_DepartmentName.Width = 135;
            // 
            // col_MedicalRecordCode
            // 
            this.col_MedicalRecordCode.Caption = "MedicalRecordCode";
            this.col_MedicalRecordCode.FieldName = "MedicalRecordCode";
            this.col_MedicalRecordCode.Name = "col_MedicalRecordCode";
            // 
            // col_QuantityExport
            // 
            this.col_QuantityExport.Caption = "Số lượng";
            this.col_QuantityExport.DisplayFormat.FormatString = "#,#.##";
            this.col_QuantityExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_QuantityExport.FieldName = "QuantityExport";
            this.col_QuantityExport.Name = "col_QuantityExport";
            this.col_QuantityExport.OptionsColumn.AllowEdit = false;
            this.col_QuantityExport.OptionsColumn.AllowFocus = false;
            this.col_QuantityExport.OptionsColumn.ReadOnly = true;
            this.col_QuantityExport.Visible = true;
            this.col_QuantityExport.VisibleIndex = 10;
            this.col_QuantityExport.Width = 78;
            // 
            // col_UnitPrice
            // 
            this.col_UnitPrice.Caption = "Đơn giá";
            this.col_UnitPrice.DisplayFormat.FormatString = "#,#.####";
            this.col_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPrice.FieldName = "UnitPrice";
            this.col_UnitPrice.Name = "col_UnitPrice";
            this.col_UnitPrice.OptionsColumn.AllowEdit = false;
            this.col_UnitPrice.OptionsColumn.AllowFocus = false;
            this.col_UnitPrice.OptionsColumn.ReadOnly = true;
            this.col_UnitPrice.Visible = true;
            this.col_UnitPrice.VisibleIndex = 11;
            this.col_UnitPrice.Width = 81;
            // 
            // col_SalesPrice
            // 
            this.col_SalesPrice.Caption = "Giá bán";
            this.col_SalesPrice.DisplayFormat.FormatString = "#,#.####";
            this.col_SalesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SalesPrice.Name = "col_SalesPrice";
            this.col_SalesPrice.OptionsColumn.AllowEdit = false;
            this.col_SalesPrice.OptionsColumn.AllowFocus = false;
            this.col_SalesPrice.OptionsColumn.ReadOnly = true;
            this.col_SalesPrice.Visible = true;
            this.col_SalesPrice.VisibleIndex = 12;
            this.col_SalesPrice.Width = 77;
            // 
            // col_PostingDate
            // 
            this.col_PostingDate.Caption = "Ngày cấp";
            this.col_PostingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_PostingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_PostingDate.FieldName = "PostingDate";
            this.col_PostingDate.Name = "col_PostingDate";
            this.col_PostingDate.OptionsColumn.AllowEdit = false;
            this.col_PostingDate.OptionsColumn.AllowFocus = false;
            this.col_PostingDate.OptionsColumn.ReadOnly = true;
            this.col_PostingDate.Visible = true;
            this.col_PostingDate.VisibleIndex = 14;
            this.col_PostingDate.Width = 89;
            // 
            // col_DoiTuong
            // 
            this.col_DoiTuong.Caption = "Đối tượng";
            this.col_DoiTuong.ColumnEdit = this.rep_LK_ObjectCode;
            this.col_DoiTuong.FieldName = "ObjectCode";
            this.col_DoiTuong.Name = "col_DoiTuong";
            this.col_DoiTuong.Visible = true;
            this.col_DoiTuong.VisibleIndex = 8;
            // 
            // rep_LK_ObjectCode
            // 
            this.rep_LK_ObjectCode.AutoHeight = false;
            this.rep_LK_ObjectCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_LK_ObjectCode.DisplayMember = "ObjectName";
            this.rep_LK_ObjectCode.Name = "rep_LK_ObjectCode";
            this.rep_LK_ObjectCode.NullText = "Đối tượng";
            this.rep_LK_ObjectCode.ValueMember = "ObjectCode";
            // 
            // col_Doctor
            // 
            this.col_Doctor.Caption = "Bác sĩ";
            this.col_Doctor.ColumnEdit = this.rep_LKDocTor;
            this.col_Doctor.FieldName = "EmployeeCodeDoctor";
            this.col_Doctor.Name = "col_Doctor";
            this.col_Doctor.Visible = true;
            this.col_Doctor.VisibleIndex = 0;
            this.col_Doctor.Width = 133;
            // 
            // rep_LKDocTor
            // 
            this.rep_LKDocTor.AutoHeight = false;
            this.rep_LKDocTor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_LKDocTor.DisplayMember = "EmployeeName";
            this.rep_LKDocTor.Name = "rep_LKDocTor";
            this.rep_LKDocTor.NullText = "Bác sĩ";
            this.rep_LKDocTor.ValueMember = "EmployeeCode";
            // 
            // col_Usage
            // 
            this.col_Usage.Caption = "Đường dùng";
            this.col_Usage.ColumnEdit = this.repLK_Usage;
            this.col_Usage.FieldName = "UsageCode";
            this.col_Usage.Name = "col_Usage";
            this.col_Usage.Visible = true;
            this.col_Usage.VisibleIndex = 7;
            this.col_Usage.Width = 95;
            // 
            // repLK_Usage
            // 
            this.repLK_Usage.AutoHeight = false;
            this.repLK_Usage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLK_Usage.DisplayMember = "UsageName";
            this.repLK_Usage.Name = "repLK_Usage";
            this.repLK_Usage.NullText = "Đường dùng";
            this.repLK_Usage.ValueMember = "UsageCode";
            // 
            // col_amount
            // 
            this.col_amount.Caption = "Thành tiền";
            this.col_amount.DisplayFormat.FormatString = "#,#.####";
            this.col_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_amount.FieldName = "Amount";
            this.col_amount.Name = "col_amount";
            this.col_amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#.##}")});
            this.col_amount.Visible = true;
            this.col_amount.VisibleIndex = 13;
            this.col_amount.Width = 97;
            // 
            // col_Paid
            // 
            this.col_Paid.Caption = "Thanh Toán";
            this.col_Paid.FieldName = "Paid";
            this.col_Paid.Name = "col_Paid";
            this.col_Paid.Visible = true;
            this.col_Paid.VisibleIndex = 19;
            this.col_Paid.Width = 145;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl_Result);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(926, 647);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Báo cáo";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grMain);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1165, 647);
            this.splitContainerControl1.SplitterPosition = 233;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmBangKeChiTietThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 647);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBangKeChiTietThuoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo nhập xuất tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBangKeChiTietThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sLookupItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatefrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_LK_ObjectCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_LKDocTor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLK_Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_Shipment;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtDatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SearchLookUpEdit sLookupItem;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn col_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientBirthyear;
        private DevExpress.XtraGrid.Columns.GridColumn col_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_MedicalRecordCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_QuantityExport;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_SalesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_PostingDate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.DateEdit txtDateto;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn col_DoiTuong;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_LK_ObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Doctor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_LKDocTor;
        private DevExpress.XtraGrid.Columns.GridColumn col_Usage;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLK_Usage;
        private DevExpress.XtraGrid.Columns.GridColumn col_amount;
        private DevExpress.XtraGrid.Columns.GridColumn col_Paid;
    }
}