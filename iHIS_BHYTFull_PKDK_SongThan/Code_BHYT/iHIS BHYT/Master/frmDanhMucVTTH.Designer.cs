namespace Ps.Clinic.Master
{
    partial class frmDanhMucVTTH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucVTTH));
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Service = new DevExpress.XtraGrid.GridControl();
            this.gridView_Service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_lst_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_lst_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_lst_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_lst_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemGridLookUpEdit_Service_Group = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_Service_Group_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_Service_Group_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ref_Service_CategoryCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_groupSerive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_categoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_categoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rep_DepartmentCode = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.rep_PatientType = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Detail = new DevExpress.XtraGrid.GridControl();
            this.gridView_Detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_tem_NormsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tem_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Item = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_tem_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tem_Instruction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tem_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tem_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_UoM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_tem_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tem_SalesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tem_BHYTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).BeginInit();
            this.pnTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Service_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_CategoryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_DepartmentCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_PatientType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_UoM)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTemplate
            // 
            this.pnTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnTemplate.Name = "pnTemplate";
            this.pnTemplate.Panel1.Controls.Add(this.groupList);
            this.pnTemplate.Panel1.Text = "Panel1";
            this.pnTemplate.Panel2.Controls.Add(this.grDetails);
            this.pnTemplate.Panel2.Text = "Panel2";
            this.pnTemplate.Size = new System.Drawing.Size(1024, 600);
            this.pnTemplate.SplitterPosition = 417;
            this.pnTemplate.TabIndex = 5;
            this.pnTemplate.Text = "splitContainerControl1";
            // 
            // groupList
            // 
            this.groupList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupList.AppearanceCaption.Options.UseForeColor = true;
            this.groupList.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupList.CaptionImage")));
            this.groupList.Controls.Add(this.gridControl_Service);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(417, 600);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "Danh sách dịch vụ";
            // 
            // gridControl_Service
            // 
            this.gridControl_Service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Service.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Service.MainView = this.gridView_Service;
            this.gridControl_Service.Name = "gridControl_Service";
            this.gridControl_Service.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemGridLookUpEdit_Service_Group,
            this.repositoryItemCheckEdit1,
            this.ref_Service_CategoryCode,
            this.repositoryItemGridLookUpEdit1,
            this.rep_DepartmentCode,
            this.rep_PatientType});
            this.gridControl_Service.Size = new System.Drawing.Size(413, 575);
            this.gridControl_Service.TabIndex = 4;
            this.gridControl_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Service});
            // 
            // gridView_Service
            // 
            this.gridView_Service.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Service.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Service.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Service.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Service.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_lst_ServiceGroupName,
            this.col_lst_ServiceCategoryName,
            this.col_lst_ServiceCode,
            this.col_lst_ServiceName});
            this.gridView_Service.GridControl = this.gridControl_Service;
            this.gridView_Service.Name = "gridView_Service";
            this.gridView_Service.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Service.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Service.OptionsFind.AlwaysVisible = true;
            this.gridView_Service.OptionsFind.FindFilterColumns = "ServiceName";
            this.gridView_Service.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_Service.OptionsView.ShowFooter = true;
            this.gridView_Service.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Service_KeyDown);
            this.gridView_Service.Click += new System.EventHandler(this.gridView_Service_Click);
            // 
            // col_lst_ServiceGroupName
            // 
            this.col_lst_ServiceGroupName.Caption = "Nhóm viện phí";
            this.col_lst_ServiceGroupName.FieldName = "ServiceGroupName";
            this.col_lst_ServiceGroupName.Name = "col_lst_ServiceGroupName";
            this.col_lst_ServiceGroupName.OptionsColumn.AllowEdit = false;
            this.col_lst_ServiceGroupName.OptionsColumn.ReadOnly = true;
            this.col_lst_ServiceGroupName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServiceGroupCode", "Count: {0:#,#}")});
            this.col_lst_ServiceGroupName.Visible = true;
            this.col_lst_ServiceGroupName.VisibleIndex = 0;
            this.col_lst_ServiceGroupName.Width = 105;
            // 
            // col_lst_ServiceCategoryName
            // 
            this.col_lst_ServiceCategoryName.Caption = "Loại viện phí";
            this.col_lst_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_lst_ServiceCategoryName.Name = "col_lst_ServiceCategoryName";
            this.col_lst_ServiceCategoryName.Visible = true;
            this.col_lst_ServiceCategoryName.VisibleIndex = 1;
            this.col_lst_ServiceCategoryName.Width = 115;
            // 
            // col_lst_ServiceCode
            // 
            this.col_lst_ServiceCode.Caption = "Mã viện phí";
            this.col_lst_ServiceCode.FieldName = "ServiceCode";
            this.col_lst_ServiceCode.Name = "col_lst_ServiceCode";
            this.col_lst_ServiceCode.OptionsColumn.AllowMove = false;
            this.col_lst_ServiceCode.OptionsColumn.AllowShowHide = false;
            // 
            // col_lst_ServiceName
            // 
            this.col_lst_ServiceName.Caption = "Tên dịch vụ";
            this.col_lst_ServiceName.FieldName = "ServiceName";
            this.col_lst_ServiceName.Name = "col_lst_ServiceName";
            this.col_lst_ServiceName.OptionsColumn.AllowMove = false;
            this.col_lst_ServiceName.OptionsColumn.AllowShowHide = false;
            this.col_lst_ServiceName.Visible = true;
            this.col_lst_ServiceName.VisibleIndex = 2;
            this.col_lst_ServiceName.Width = 244;
            // 
            // ItemGridLookUpEdit_Service_Group
            // 
            this.ItemGridLookUpEdit_Service_Group.AutoHeight = false;
            this.ItemGridLookUpEdit_Service_Group.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ItemGridLookUpEdit_Service_Group.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemGridLookUpEdit_Service_Group.Name = "ItemGridLookUpEdit_Service_Group";
            this.ItemGridLookUpEdit_Service_Group.NullText = "...";
            this.ItemGridLookUpEdit_Service_Group.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_Service_Group_Code,
            this.view_Service_Group_Name});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // view_Service_Group_Code
            // 
            this.view_Service_Group_Code.Caption = "Mã nhóm viện phí";
            this.view_Service_Group_Code.FieldName = "ServiceGroupCode";
            this.view_Service_Group_Code.Name = "view_Service_Group_Code";
            // 
            // view_Service_Group_Name
            // 
            this.view_Service_Group_Name.Caption = "Tên nhóm dịch vụ";
            this.view_Service_Group_Name.FieldName = "ServiceGroupName";
            this.view_Service_Group_Name.Name = "view_Service_Group_Name";
            this.view_Service_Group_Name.Visible = true;
            this.view_Service_Group_Name.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueGrayed = "0";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueGrayed = 0;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // ref_Service_CategoryCode
            // 
            this.ref_Service_CategoryCode.AutoHeight = false;
            this.ref_Service_CategoryCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Service_CategoryCode.Name = "ref_Service_CategoryCode";
            this.ref_Service_CategoryCode.NullText = "...";
            this.ref_Service_CategoryCode.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_groupSerive,
            this.col_categoryCode,
            this.col_categoryName});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // view_groupSerive
            // 
            this.view_groupSerive.Caption = "Nhóm";
            this.view_groupSerive.FieldName = "ServiceGroupCode";
            this.view_groupSerive.Name = "view_groupSerive";
            this.view_groupSerive.Visible = true;
            this.view_groupSerive.VisibleIndex = 0;
            // 
            // col_categoryCode
            // 
            this.col_categoryCode.Caption = "Mã loại";
            this.col_categoryCode.FieldName = "ServiceCategoryCode";
            this.col_categoryCode.Name = "col_categoryCode";
            // 
            // col_categoryName
            // 
            this.col_categoryName.Caption = "Nội dung";
            this.col_categoryName.FieldName = "ServiceCategoryName";
            this.col_categoryName.Name = "col_categoryName";
            this.col_categoryName.Visible = true;
            this.col_categoryName.VisibleIndex = 1;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // rep_DepartmentCode
            // 
            this.rep_DepartmentCode.AutoHeight = false;
            this.rep_DepartmentCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_DepartmentCode.Name = "rep_DepartmentCode";
            // 
            // rep_PatientType
            // 
            this.rep_PatientType.AutoHeight = false;
            this.rep_PatientType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_PatientType.Name = "rep_PatientType";
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.grDetails.AppearanceCaption.Options.UseForeColor = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.gridControl_Detail);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(602, 600);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "Chi tiết Thuốc, VTTH ";
            // 
            // gridControl_Detail
            // 
            this.gridControl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Detail.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Detail.MainView = this.gridView_Detail;
            this.gridControl_Detail.Name = "gridControl_Detail";
            this.gridControl_Detail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_Item,
            this.rep_UoM});
            this.gridControl_Detail.Size = new System.Drawing.Size(598, 575);
            this.gridControl_Detail.TabIndex = 13;
            this.gridControl_Detail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Detail});
            // 
            // gridView_Detail
            // 
            this.gridView_Detail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_tem_NormsCode,
            this.col_tem_ItemCode,
            this.col_tem_Quantity,
            this.col_tem_Instruction,
            this.col_tem_RowID,
            this.col_tem_UnitOfMeasureCode,
            this.col_tem_UnitPrice,
            this.col_tem_SalesPrice,
            this.col_tem_BHYTPrice});
            this.gridView_Detail.GridControl = this.gridControl_Detail;
            this.gridView_Detail.Name = "gridView_Detail";
            this.gridView_Detail.NewItemRowText = "Nhập chi tiết thuốc cho toa mẫu!";
            this.gridView_Detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Detail.OptionsView.ShowFooter = true;
            this.gridView_Detail.OptionsView.ShowGroupPanel = false;
            this.gridView_Detail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Detail_InvalidRowException);
            this.gridView_Detail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Detail_ValidateRow);
            this.gridView_Detail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Detail_KeyDown);
            // 
            // col_tem_NormsCode
            // 
            this.col_tem_NormsCode.Caption = "Mã định mức";
            this.col_tem_NormsCode.FieldName = "NormsCode";
            this.col_tem_NormsCode.Name = "col_tem_NormsCode";
            // 
            // col_tem_ItemCode
            // 
            this.col_tem_ItemCode.Caption = "Thuốc - VTTH";
            this.col_tem_ItemCode.ColumnEdit = this.ref_Item;
            this.col_tem_ItemCode.FieldName = "ItemCode";
            this.col_tem_ItemCode.Name = "col_tem_ItemCode";
            this.col_tem_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_tem_ItemCode.Visible = true;
            this.col_tem_ItemCode.VisibleIndex = 0;
            this.col_tem_ItemCode.Width = 253;
            // 
            // ref_Item
            // 
            this.ref_Item.AutoHeight = false;
            this.ref_Item.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ref_Item.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Item.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemCode", "Mã thuốc", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Tên thuốc"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Active", "Hoạt chất")});
            this.ref_Item.Name = "ref_Item";
            this.ref_Item.NullText = "...";
            this.ref_Item.EditValueChanged += new System.EventHandler(this.ref_Item_EditValueChanged);
            // 
            // col_tem_Quantity
            // 
            this.col_tem_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_tem_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_tem_Quantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_tem_Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_tem_Quantity.Caption = "SL";
            this.col_tem_Quantity.DisplayFormat.FormatString = "#,#";
            this.col_tem_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_tem_Quantity.FieldName = "Quantity";
            this.col_tem_Quantity.Name = "col_tem_Quantity";
            this.col_tem_Quantity.Visible = true;
            this.col_tem_Quantity.VisibleIndex = 2;
            this.col_tem_Quantity.Width = 72;
            // 
            // col_tem_Instruction
            // 
            this.col_tem_Instruction.Caption = "Cách dùng";
            this.col_tem_Instruction.FieldName = "Instruction";
            this.col_tem_Instruction.Name = "col_tem_Instruction";
            this.col_tem_Instruction.Visible = true;
            this.col_tem_Instruction.VisibleIndex = 3;
            this.col_tem_Instruction.Width = 276;
            // 
            // col_tem_RowID
            // 
            this.col_tem_RowID.Caption = "ID";
            this.col_tem_RowID.FieldName = "RowID";
            this.col_tem_RowID.Name = "col_tem_RowID";
            // 
            // col_tem_UnitOfMeasureCode
            // 
            this.col_tem_UnitOfMeasureCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_tem_UnitOfMeasureCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_tem_UnitOfMeasureCode.Caption = "ĐVT";
            this.col_tem_UnitOfMeasureCode.ColumnEdit = this.rep_UoM;
            this.col_tem_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.col_tem_UnitOfMeasureCode.Name = "col_tem_UnitOfMeasureCode";
            this.col_tem_UnitOfMeasureCode.OptionsColumn.ReadOnly = true;
            this.col_tem_UnitOfMeasureCode.Visible = true;
            this.col_tem_UnitOfMeasureCode.VisibleIndex = 1;
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
            // col_tem_UnitPrice
            // 
            this.col_tem_UnitPrice.Caption = "Đơn giá";
            this.col_tem_UnitPrice.DisplayFormat.FormatString = "#,#.##";
            this.col_tem_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_tem_UnitPrice.FieldName = "UnitPrice";
            this.col_tem_UnitPrice.Name = "col_tem_UnitPrice";
            this.col_tem_UnitPrice.OptionsColumn.AllowEdit = false;
            this.col_tem_UnitPrice.OptionsColumn.AllowFocus = false;
            this.col_tem_UnitPrice.OptionsColumn.ReadOnly = true;
            this.col_tem_UnitPrice.Visible = true;
            this.col_tem_UnitPrice.VisibleIndex = 4;
            // 
            // col_tem_SalesPrice
            // 
            this.col_tem_SalesPrice.Caption = "Giá bán";
            this.col_tem_SalesPrice.DisplayFormat.FormatString = "#,#.##";
            this.col_tem_SalesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_tem_SalesPrice.FieldName = "SalesPrice";
            this.col_tem_SalesPrice.Name = "col_tem_SalesPrice";
            this.col_tem_SalesPrice.OptionsColumn.AllowEdit = false;
            this.col_tem_SalesPrice.OptionsColumn.AllowFocus = false;
            this.col_tem_SalesPrice.OptionsColumn.ReadOnly = true;
            this.col_tem_SalesPrice.Visible = true;
            this.col_tem_SalesPrice.VisibleIndex = 5;
            // 
            // col_tem_BHYTPrice
            // 
            this.col_tem_BHYTPrice.Caption = "Giá BHYT";
            this.col_tem_BHYTPrice.DisplayFormat.FormatString = "#,#.##";
            this.col_tem_BHYTPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_tem_BHYTPrice.FieldName = "BHYTPrice";
            this.col_tem_BHYTPrice.Name = "col_tem_BHYTPrice";
            this.col_tem_BHYTPrice.OptionsColumn.AllowEdit = false;
            this.col_tem_BHYTPrice.OptionsColumn.AllowFocus = false;
            this.col_tem_BHYTPrice.OptionsColumn.ReadOnly = true;
            this.col_tem_BHYTPrice.Visible = true;
            this.col_tem_BHYTPrice.VisibleIndex = 6;
            // 
            // frmDanhMucVTTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucVTTH";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucVTTH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Service_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_CategoryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_DepartmentCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_PatientType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_UoM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl pnTemplate;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraGrid.GridControl gridControl_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Service;
        private DevExpress.XtraGrid.Columns.GridColumn col_lst_ServiceGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_lst_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_lst_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_lst_ServiceName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ItemGridLookUpEdit_Service_Group;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn view_Service_Group_Code;
        private DevExpress.XtraGrid.Columns.GridColumn view_Service_Group_Name;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ref_Service_CategoryCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn view_groupSerive;
        private DevExpress.XtraGrid.Columns.GridColumn col_categoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_categoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rep_DepartmentCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rep_PatientType;
        private DevExpress.XtraGrid.GridControl gridControl_Detail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_NormsCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_ItemCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Item;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_Instruction;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_UnitOfMeasureCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_UoM;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_SalesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_tem_BHYTPrice;
    }
}