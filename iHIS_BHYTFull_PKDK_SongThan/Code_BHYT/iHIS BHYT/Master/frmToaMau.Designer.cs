namespace Ps.Clinic.Master
{
    partial class frmToaMau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToaMau));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_List = new DevExpress.XtraGrid.GridControl();
            this.gridView_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_SamplePrescriptionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SamplePrescriptionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SamplePrescriptionDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Detail = new DevExpress.XtraGrid.GridControl();
            this.gridView_Detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Detail_Sample_Prescription_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Item_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repslkup_Items = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repslkupView_Items = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colViewItem_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViewItem_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViewItem_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_DateOfIssues = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Morning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Noon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Afternoon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Evening = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Instruction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detal_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_UnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_UoM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Detail_UnitOfMeasureCode_Medi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repslkup_UnitOfMedi = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repslkup_UnitOfMedi_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUnitOfMedi_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitOfMedi_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Converted_Medi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkup_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkupView_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkup_UnitOfMedi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkup_UnitOfMedi_View)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.splitContainerControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1152, 481);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Khai báo danh sách toa mẫu";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 23);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl_List);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1148, 456);
            this.splitContainerControl1.SplitterPosition = 446;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_List
            // 
            this.gridControl_List.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_List.Location = new System.Drawing.Point(0, 0);
            this.gridControl_List.MainView = this.gridView_List;
            this.gridControl_List.Name = "gridControl_List";
            this.gridControl_List.Size = new System.Drawing.Size(446, 456);
            this.gridControl_List.TabIndex = 0;
            this.gridControl_List.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_List});
            this.gridControl_List.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_List_ProcessGridKey);
            // 
            // gridView_List
            // 
            this.gridView_List.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_List.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_List.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_SamplePrescriptionCode,
            this.col_SamplePrescriptionName,
            this.col_SamplePrescriptionDescription,
            this.col_EmployeeCode});
            this.gridView_List.GridControl = this.gridControl_List;
            this.gridView_List.Name = "gridView_List";
            this.gridView_List.NewItemRowText = "Nhập thêm mới toa mẫu mới!";
            this.gridView_List.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_List.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_List.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_List.OptionsView.ShowGroupPanel = false;
            this.gridView_List.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_List_FocusedRowChanged);
            this.gridView_List.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_List_InvalidRowException);
            this.gridView_List.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_List_ValidateRow);
            // 
            // col_SamplePrescriptionCode
            // 
            this.col_SamplePrescriptionCode.Caption = "Mã toa mẫu";
            this.col_SamplePrescriptionCode.FieldName = "SamplePrescriptionCode";
            this.col_SamplePrescriptionCode.Name = "col_SamplePrescriptionCode";
            this.col_SamplePrescriptionCode.OptionsColumn.AllowEdit = false;
            this.col_SamplePrescriptionCode.OptionsColumn.AllowFocus = false;
            this.col_SamplePrescriptionCode.OptionsColumn.ReadOnly = true;
            this.col_SamplePrescriptionCode.Visible = true;
            this.col_SamplePrescriptionCode.VisibleIndex = 0;
            this.col_SamplePrescriptionCode.Width = 68;
            // 
            // col_SamplePrescriptionName
            // 
            this.col_SamplePrescriptionName.Caption = "Tên - nội dung";
            this.col_SamplePrescriptionName.FieldName = "SamplePrescriptionName";
            this.col_SamplePrescriptionName.Name = "col_SamplePrescriptionName";
            this.col_SamplePrescriptionName.Visible = true;
            this.col_SamplePrescriptionName.VisibleIndex = 1;
            this.col_SamplePrescriptionName.Width = 207;
            // 
            // col_SamplePrescriptionDescription
            // 
            this.col_SamplePrescriptionDescription.Caption = "Ghi chú (Diễn giải)";
            this.col_SamplePrescriptionDescription.FieldName = "SamplePrescriptionDescription";
            this.col_SamplePrescriptionDescription.Name = "col_SamplePrescriptionDescription";
            this.col_SamplePrescriptionDescription.Visible = true;
            this.col_SamplePrescriptionDescription.VisibleIndex = 2;
            this.col_SamplePrescriptionDescription.Width = 64;
            // 
            // col_EmployeeCode
            // 
            this.col_EmployeeCode.Caption = "Nhân Viên";
            this.col_EmployeeCode.FieldName = "EmployeeCode";
            this.col_EmployeeCode.Name = "col_EmployeeCode";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Detail);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(697, 456);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết thuốc trong toa";
            // 
            // gridControl_Detail
            // 
            this.gridControl_Detail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Detail.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Detail.MainView = this.gridView_Detail;
            this.gridControl_Detail.Name = "gridControl_Detail";
            this.gridControl_Detail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_UoM,
            this.repslkup_Items,
            this.repslkup_UnitOfMedi});
            this.gridControl_Detail.Size = new System.Drawing.Size(693, 431);
            this.gridControl_Detail.TabIndex = 0;
            this.gridControl_Detail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Detail});
            this.gridControl_Detail.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Detail_ProcessGridKey);
            this.gridControl_Detail.EditorKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl_Detail_EditorKeyPress);
            // 
            // gridView_Detail
            // 
            this.gridView_Detail.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Detail.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Detail_Sample_Prescription_Code,
            this.col_Detail_Item_Code,
            this.col_Detail_DateOfIssues,
            this.col_Detail_Morning,
            this.col_Detail_Noon,
            this.col_Detail_Afternoon,
            this.col_Detail_Evening,
            this.col_Detail_Quantity,
            this.col_Detail_Instruction,
            this.col_Detal_RowID,
            this.col_Detail_UnitOfMeasure,
            this.col_Detail_UnitOfMeasureCode_Medi,
            this.col_Detail_Converted_Medi});
            this.gridView_Detail.GridControl = this.gridControl_Detail;
            this.gridView_Detail.Name = "gridView_Detail";
            this.gridView_Detail.NewItemRowText = "Nhập chi tiết thuốc cho toa mẫu!";
            this.gridView_Detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Detail.OptionsView.ShowFooter = true;
            this.gridView_Detail.OptionsView.ShowGroupPanel = false;
            this.gridView_Detail.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_Detail_InitNewRow);
            this.gridView_Detail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Detail_InvalidRowException);
            this.gridView_Detail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Detail_ValidateRow);
            this.gridView_Detail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView_Detail_KeyPress);
            this.gridView_Detail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_Detail_ValidatingEditor);
            // 
            // col_Detail_Sample_Prescription_Code
            // 
            this.col_Detail_Sample_Prescription_Code.Caption = "Mã toa mẫu";
            this.col_Detail_Sample_Prescription_Code.FieldName = "SamplePrescriptionCode";
            this.col_Detail_Sample_Prescription_Code.Name = "col_Detail_Sample_Prescription_Code";
            // 
            // col_Detail_Item_Code
            // 
            this.col_Detail_Item_Code.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Item_Code.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Item_Code.Caption = "Thuốc - vật tư y tế";
            this.col_Detail_Item_Code.ColumnEdit = this.repslkup_Items;
            this.col_Detail_Item_Code.FieldName = "ItemCode";
            this.col_Detail_Item_Code.Name = "col_Detail_Item_Code";
            this.col_Detail_Item_Code.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_Detail_Item_Code.Visible = true;
            this.col_Detail_Item_Code.VisibleIndex = 0;
            this.col_Detail_Item_Code.Width = 291;
            // 
            // repslkup_Items
            // 
            this.repslkup_Items.AutoHeight = false;
            this.repslkup_Items.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repslkup_Items.Name = "repslkup_Items";
            this.repslkup_Items.NullText = "";
            this.repslkup_Items.View = this.repslkupView_Items;
            this.repslkup_Items.Popup += new System.EventHandler(this.repslkup_Items_Popup);
            this.repslkup_Items.EditValueChanged += new System.EventHandler(this.repslkup_Items_EditValueChanged);
            // 
            // repslkupView_Items
            // 
            this.repslkupView_Items.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colViewItem_ItemCode,
            this.colViewItem_ItemName,
            this.colViewItem_Active});
            this.repslkupView_Items.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repslkupView_Items.Name = "repslkupView_Items";
            this.repslkupView_Items.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repslkupView_Items.OptionsView.ShowGroupPanel = false;
            // 
            // colViewItem_ItemCode
            // 
            this.colViewItem_ItemCode.Caption = "Mã thuốc";
            this.colViewItem_ItemCode.FieldName = "ItemCode";
            this.colViewItem_ItemCode.Name = "colViewItem_ItemCode";
            this.colViewItem_ItemCode.Visible = true;
            this.colViewItem_ItemCode.VisibleIndex = 0;
            // 
            // colViewItem_ItemName
            // 
            this.colViewItem_ItemName.Caption = "Thuốc - VTTH";
            this.colViewItem_ItemName.FieldName = "ItemName";
            this.colViewItem_ItemName.Name = "colViewItem_ItemName";
            this.colViewItem_ItemName.Visible = true;
            this.colViewItem_ItemName.VisibleIndex = 1;
            // 
            // colViewItem_Active
            // 
            this.colViewItem_Active.Caption = "Hoạt chất";
            this.colViewItem_Active.FieldName = "Active";
            this.colViewItem_Active.Name = "colViewItem_Active";
            this.colViewItem_Active.Visible = true;
            this.colViewItem_Active.VisibleIndex = 2;
            // 
            // col_Detail_DateOfIssues
            // 
            this.col_Detail_DateOfIssues.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_DateOfIssues.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_DateOfIssues.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_DateOfIssues.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_DateOfIssues.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_DateOfIssues.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_DateOfIssues.Caption = "Ngày cấp";
            this.col_Detail_DateOfIssues.DisplayFormat.FormatString = "#,#";
            this.col_Detail_DateOfIssues.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Detail_DateOfIssues.FieldName = "DateOfIssues";
            this.col_Detail_DateOfIssues.Name = "col_Detail_DateOfIssues";
            this.col_Detail_DateOfIssues.Visible = true;
            this.col_Detail_DateOfIssues.VisibleIndex = 2;
            this.col_Detail_DateOfIssues.Width = 67;
            // 
            // col_Detail_Morning
            // 
            this.col_Detail_Morning.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_Morning.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Morning.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Morning.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Morning.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_Morning.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Morning.Caption = "Sáng";
            this.col_Detail_Morning.FieldName = "Morning";
            this.col_Detail_Morning.Name = "col_Detail_Morning";
            this.col_Detail_Morning.Visible = true;
            this.col_Detail_Morning.VisibleIndex = 3;
            this.col_Detail_Morning.Width = 45;
            // 
            // col_Detail_Noon
            // 
            this.col_Detail_Noon.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_Noon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Noon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Noon.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Noon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_Noon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Noon.Caption = "Trưa";
            this.col_Detail_Noon.FieldName = "Noon";
            this.col_Detail_Noon.Name = "col_Detail_Noon";
            this.col_Detail_Noon.Visible = true;
            this.col_Detail_Noon.VisibleIndex = 4;
            this.col_Detail_Noon.Width = 37;
            // 
            // col_Detail_Afternoon
            // 
            this.col_Detail_Afternoon.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_Afternoon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Afternoon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Afternoon.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Afternoon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_Afternoon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Afternoon.Caption = "Chiều";
            this.col_Detail_Afternoon.FieldName = "Afternoon";
            this.col_Detail_Afternoon.Name = "col_Detail_Afternoon";
            this.col_Detail_Afternoon.Visible = true;
            this.col_Detail_Afternoon.VisibleIndex = 5;
            this.col_Detail_Afternoon.Width = 42;
            // 
            // col_Detail_Evening
            // 
            this.col_Detail_Evening.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_Evening.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Evening.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Evening.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Evening.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_Evening.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Evening.Caption = "Tối";
            this.col_Detail_Evening.FieldName = "Evening";
            this.col_Detail_Evening.Name = "col_Detail_Evening";
            this.col_Detail_Evening.Visible = true;
            this.col_Detail_Evening.VisibleIndex = 6;
            this.col_Detail_Evening.Width = 46;
            // 
            // col_Detail_Quantity
            // 
            this.col_Detail_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Quantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Quantity.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Quantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_Quantity.Caption = "Số lượng";
            this.col_Detail_Quantity.DisplayFormat.FormatString = "#,#";
            this.col_Detail_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Detail_Quantity.FieldName = "Quantity";
            this.col_Detail_Quantity.Name = "col_Detail_Quantity";
            this.col_Detail_Quantity.Visible = true;
            this.col_Detail_Quantity.VisibleIndex = 7;
            this.col_Detail_Quantity.Width = 68;
            // 
            // col_Detail_Instruction
            // 
            this.col_Detail_Instruction.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Instruction.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Instruction.Caption = "Cách dùng";
            this.col_Detail_Instruction.FieldName = "Instruction";
            this.col_Detail_Instruction.Name = "col_Detail_Instruction";
            this.col_Detail_Instruction.Visible = true;
            this.col_Detail_Instruction.VisibleIndex = 8;
            this.col_Detail_Instruction.Width = 159;
            // 
            // col_Detal_RowID
            // 
            this.col_Detal_RowID.Caption = "ID";
            this.col_Detal_RowID.FieldName = "RowID";
            this.col_Detal_RowID.Name = "col_Detal_RowID";
            // 
            // col_Detail_UnitOfMeasure
            // 
            this.col_Detail_UnitOfMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_UnitOfMeasure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_UnitOfMeasure.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_UnitOfMeasure.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_UnitOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_UnitOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_UnitOfMeasure.Caption = "ĐVT";
            this.col_Detail_UnitOfMeasure.ColumnEdit = this.rep_UoM;
            this.col_Detail_UnitOfMeasure.FieldName = "UnitOfMeasure";
            this.col_Detail_UnitOfMeasure.Name = "col_Detail_UnitOfMeasure";
            this.col_Detail_UnitOfMeasure.OptionsColumn.AllowEdit = false;
            this.col_Detail_UnitOfMeasure.OptionsColumn.AllowFocus = false;
            this.col_Detail_UnitOfMeasure.OptionsColumn.ReadOnly = true;
            this.col_Detail_UnitOfMeasure.Width = 61;
            // 
            // rep_UoM
            // 
            this.rep_UoM.AutoHeight = false;
            this.rep_UoM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_UoM.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureCode", "Mã ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureName", "Tên ĐVT")});
            this.rep_UoM.Name = "rep_UoM";
            this.rep_UoM.NullText = "...";
            // 
            // col_Detail_UnitOfMeasureCode_Medi
            // 
            this.col_Detail_UnitOfMeasureCode_Medi.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_UnitOfMeasureCode_Medi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_UnitOfMeasureCode_Medi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_UnitOfMeasureCode_Medi.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_UnitOfMeasureCode_Medi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_UnitOfMeasureCode_Medi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_UnitOfMeasureCode_Medi.Caption = "ĐVT K.Toa";
            this.col_Detail_UnitOfMeasureCode_Medi.ColumnEdit = this.repslkup_UnitOfMedi;
            this.col_Detail_UnitOfMeasureCode_Medi.FieldName = "UnitOfMeasureCode_Medi";
            this.col_Detail_UnitOfMeasureCode_Medi.Name = "col_Detail_UnitOfMeasureCode_Medi";
            this.col_Detail_UnitOfMeasureCode_Medi.Visible = true;
            this.col_Detail_UnitOfMeasureCode_Medi.VisibleIndex = 1;
            this.col_Detail_UnitOfMeasureCode_Medi.Width = 74;
            // 
            // repslkup_UnitOfMedi
            // 
            this.repslkup_UnitOfMedi.AutoHeight = false;
            this.repslkup_UnitOfMedi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repslkup_UnitOfMedi.Name = "repslkup_UnitOfMedi";
            this.repslkup_UnitOfMedi.NullText = "";
            this.repslkup_UnitOfMedi.View = this.repslkup_UnitOfMedi_View;
            // 
            // repslkup_UnitOfMedi_View
            // 
            this.repslkup_UnitOfMedi_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUnitOfMedi_UnitOfMeasureCode,
            this.colUnitOfMedi_UnitOfMeasureName});
            this.repslkup_UnitOfMedi_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repslkup_UnitOfMedi_View.Name = "repslkup_UnitOfMedi_View";
            this.repslkup_UnitOfMedi_View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repslkup_UnitOfMedi_View.OptionsView.ShowGroupPanel = false;
            // 
            // colUnitOfMedi_UnitOfMeasureCode
            // 
            this.colUnitOfMedi_UnitOfMeasureCode.Caption = "Mã";
            this.colUnitOfMedi_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.colUnitOfMedi_UnitOfMeasureCode.Name = "colUnitOfMedi_UnitOfMeasureCode";
            this.colUnitOfMedi_UnitOfMeasureCode.Visible = true;
            this.colUnitOfMedi_UnitOfMeasureCode.VisibleIndex = 0;
            // 
            // colUnitOfMedi_UnitOfMeasureName
            // 
            this.colUnitOfMedi_UnitOfMeasureName.Caption = "ĐVT";
            this.colUnitOfMedi_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.colUnitOfMedi_UnitOfMeasureName.Name = "colUnitOfMedi_UnitOfMeasureName";
            this.colUnitOfMedi_UnitOfMeasureName.Visible = true;
            this.colUnitOfMedi_UnitOfMeasureName.VisibleIndex = 1;
            // 
            // col_Detail_Converted_Medi
            // 
            this.col_Detail_Converted_Medi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Detail_Converted_Medi.AppearanceHeader.Options.UseFont = true;
            this.col_Detail_Converted_Medi.Caption = "Converted_Medi";
            this.col_Detail_Converted_Medi.FieldName = "Converted_Medi";
            this.col_Detail_Converted_Medi.Name = "col_Detail_Converted_Medi";
            this.col_Detail_Converted_Medi.Width = 101;
            // 
            // frmToaMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 481);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmToaMau";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo toa mẫu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmToaMau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkup_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkupView_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkup_UnitOfMedi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repslkup_UnitOfMedi_View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl_List;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_List;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Detail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn col_SamplePrescriptionCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_SamplePrescriptionName;
        private DevExpress.XtraGrid.Columns.GridColumn col_SamplePrescriptionDescription;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Sample_Prescription_Code;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Item_Code;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_DateOfIssues;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Morning;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Noon;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Afternoon;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Evening;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Instruction;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detal_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_UnitOfMeasure;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_UoM;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repslkup_Items;
        private DevExpress.XtraGrid.Views.Grid.GridView repslkupView_Items;
        private DevExpress.XtraGrid.Columns.GridColumn colViewItem_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colViewItem_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colViewItem_Active;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_UnitOfMeasureCode_Medi;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Converted_Medi;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repslkup_UnitOfMedi;
        private DevExpress.XtraGrid.Views.Grid.GridView repslkup_UnitOfMedi_View;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMedi_UnitOfMeasureCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMedi_UnitOfMeasureName;
    }
}