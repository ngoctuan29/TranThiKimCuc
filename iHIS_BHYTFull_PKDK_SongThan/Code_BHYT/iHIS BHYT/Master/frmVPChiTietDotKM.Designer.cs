namespace Ps.Clinic.Master
{
    partial class frmVPChiTietDotKM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVPChiTietDotKM));
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_ServiceCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchView_ServiceCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repCol_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCol_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCol_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCol_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCol_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IDSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RateSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPriceSales = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_ServiceCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_ServiceCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSearch_ServiceCode});
            this.gridControl_Data.Size = new System.Drawing.Size(968, 512);
            this.gridControl_Data.TabIndex = 3;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            this.gridControl_Data.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Data_ProcessGridKey);
            // 
            // gridView_Data
            // 
            this.gridView_Data.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Data.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServiceCode,
            this.col_IDSales,
            this.col_EmployeeCode,
            this.col_UnitPrice,
            this.col_RateSales,
            this.col_UnitPriceSales});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "Thêm dịch vụ khuyễn mãi ...";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Data_InvalidRowException);
            this.gridView_Data.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Data_ValidateRow);
            this.gridView_Data.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_Data_ValidatingEditor);
            // 
            // col_ServiceCode
            // 
            this.col_ServiceCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceCode.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ServiceCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceCode.Caption = "Dịch vụ, kỹ thuật";
            this.col_ServiceCode.ColumnEdit = this.repSearch_ServiceCode;
            this.col_ServiceCode.FieldName = "ServiceCode";
            this.col_ServiceCode.Name = "col_ServiceCode";
            this.col_ServiceCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServiceCode", "Khoản: {#,#}")});
            this.col_ServiceCode.Visible = true;
            this.col_ServiceCode.VisibleIndex = 0;
            this.col_ServiceCode.Width = 300;
            // 
            // repSearch_ServiceCode
            // 
            this.repSearch_ServiceCode.AutoHeight = false;
            this.repSearch_ServiceCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearch_ServiceCode.Name = "repSearch_ServiceCode";
            this.repSearch_ServiceCode.NullText = "";
            this.repSearch_ServiceCode.View = this.repSearchView_ServiceCode;
            this.repSearch_ServiceCode.EditValueChanged += new System.EventHandler(this.repSearch_ServiceCode_EditValueChanged);
            // 
            // repSearchView_ServiceCode
            // 
            this.repSearchView_ServiceCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repCol_ServiceCode,
            this.repCol_ServiceName,
            this.repCol_ServiceCategoryName,
            this.repCol_Chon,
            this.repCol_ServiceGroupName});
            this.repSearchView_ServiceCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchView_ServiceCode.Name = "repSearchView_ServiceCode";
            this.repSearchView_ServiceCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchView_ServiceCode.OptionsView.ColumnAutoWidth = false;
            this.repSearchView_ServiceCode.OptionsView.ShowGroupPanel = false;
            // 
            // repCol_ServiceCode
            // 
            this.repCol_ServiceCode.Caption = "Mã DV";
            this.repCol_ServiceCode.FieldName = "ServiceCode";
            this.repCol_ServiceCode.Name = "repCol_ServiceCode";
            this.repCol_ServiceCode.Visible = true;
            this.repCol_ServiceCode.VisibleIndex = 0;
            this.repCol_ServiceCode.Width = 65;
            // 
            // repCol_ServiceName
            // 
            this.repCol_ServiceName.Caption = "Nội dung";
            this.repCol_ServiceName.FieldName = "ServiceName";
            this.repCol_ServiceName.Name = "repCol_ServiceName";
            this.repCol_ServiceName.Visible = true;
            this.repCol_ServiceName.VisibleIndex = 1;
            this.repCol_ServiceName.Width = 183;
            // 
            // repCol_ServiceCategoryName
            // 
            this.repCol_ServiceCategoryName.Caption = "Loại Dịch Vụ";
            this.repCol_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.repCol_ServiceCategoryName.Name = "repCol_ServiceCategoryName";
            this.repCol_ServiceCategoryName.Visible = true;
            this.repCol_ServiceCategoryName.VisibleIndex = 2;
            this.repCol_ServiceCategoryName.Width = 145;
            // 
            // repCol_Chon
            // 
            this.repCol_Chon.Caption = "Chon";
            this.repCol_Chon.FieldName = "Chon";
            this.repCol_Chon.Name = "repCol_Chon";
            // 
            // repCol_ServiceGroupName
            // 
            this.repCol_ServiceGroupName.Caption = "Nhóm Dịch Vụ";
            this.repCol_ServiceGroupName.FieldName = "ServiceGroupName";
            this.repCol_ServiceGroupName.Name = "repCol_ServiceGroupName";
            this.repCol_ServiceGroupName.Visible = true;
            this.repCol_ServiceGroupName.VisibleIndex = 3;
            this.repCol_ServiceGroupName.Width = 148;
            // 
            // col_IDSales
            // 
            this.col_IDSales.AppearanceCell.Options.UseTextOptions = true;
            this.col_IDSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_IDSales.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_IDSales.AppearanceHeader.Options.UseFont = true;
            this.col_IDSales.AppearanceHeader.Options.UseTextOptions = true;
            this.col_IDSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_IDSales.Caption = "ID Đợt";
            this.col_IDSales.FieldName = "IDSales";
            this.col_IDSales.Name = "col_IDSales";
            this.col_IDSales.OptionsColumn.AllowEdit = false;
            this.col_IDSales.OptionsColumn.AllowFocus = false;
            this.col_IDSales.OptionsColumn.ReadOnly = true;
            this.col_IDSales.Width = 49;
            // 
            // col_EmployeeCode
            // 
            this.col_EmployeeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_EmployeeCode.AppearanceHeader.Options.UseFont = true;
            this.col_EmployeeCode.Caption = "User Cập Nhật";
            this.col_EmployeeCode.FieldName = "EmployeeCode";
            this.col_EmployeeCode.Name = "col_EmployeeCode";
            this.col_EmployeeCode.OptionsColumn.AllowEdit = false;
            this.col_EmployeeCode.OptionsColumn.AllowFocus = false;
            this.col_EmployeeCode.OptionsColumn.ReadOnly = true;
            this.col_EmployeeCode.Visible = true;
            this.col_EmployeeCode.VisibleIndex = 4;
            this.col_EmployeeCode.Width = 77;
            // 
            // col_UnitPrice
            // 
            this.col_UnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitPrice.AppearanceHeader.Options.UseFont = true;
            this.col_UnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.Caption = "Đơn giá";
            this.col_UnitPrice.DisplayFormat.FormatString = "#,#";
            this.col_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPrice.FieldName = "UnitPrice";
            this.col_UnitPrice.Name = "col_UnitPrice";
            this.col_UnitPrice.Visible = true;
            this.col_UnitPrice.VisibleIndex = 1;
            this.col_UnitPrice.Width = 100;
            // 
            // col_RateSales
            // 
            this.col_RateSales.AppearanceCell.Options.UseTextOptions = true;
            this.col_RateSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RateSales.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RateSales.AppearanceHeader.Options.UseFont = true;
            this.col_RateSales.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RateSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RateSales.Caption = "Tỉ lệ KM";
            this.col_RateSales.DisplayFormat.FormatString = "#,#";
            this.col_RateSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_RateSales.FieldName = "RateSales";
            this.col_RateSales.Name = "col_RateSales";
            this.col_RateSales.Visible = true;
            this.col_RateSales.VisibleIndex = 2;
            this.col_RateSales.Width = 48;
            // 
            // col_UnitPriceSales
            // 
            this.col_UnitPriceSales.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitPriceSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPriceSales.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitPriceSales.AppearanceHeader.Options.UseFont = true;
            this.col_UnitPriceSales.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitPriceSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPriceSales.Caption = "Giá KM";
            this.col_UnitPriceSales.DisplayFormat.FormatString = "#,#";
            this.col_UnitPriceSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPriceSales.FieldName = "UnitPriceSales";
            this.col_UnitPriceSales.Name = "col_UnitPriceSales";
            this.col_UnitPriceSales.Visible = true;
            this.col_UnitPriceSales.VisibleIndex = 3;
            this.col_UnitPriceSales.Width = 88;
            // 
            // frmVPChiTietDotKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 512);
            this.Controls.Add(this.gridControl_Data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVPChiTietDotKM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết khuyến mãi dịch vụ";
            this.Load += new System.EventHandler(this.frmVPChiTietDotKM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_ServiceCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_ServiceCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDSales;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearch_ServiceCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchView_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_RateSales;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPriceSales;
        private DevExpress.XtraGrid.Columns.GridColumn repCol_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn repCol_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn repCol_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn repCol_Chon;
        private DevExpress.XtraGrid.Columns.GridColumn repCol_ServiceGroupName;
    }
}