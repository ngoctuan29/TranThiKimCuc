namespace Ps.Clinic.Master
{
    partial class frmPhanLoaiThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanLoaiThuoc));
            this.gridControl_Item_Category = new DevExpress.XtraGrid.GridControl();
            this.gridView_Item_Category = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_GroupCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Item_Category
            // 
            this.gridControl_Item_Category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Item_Category.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Item_Category.MainView = this.gridView_Item_Category;
            this.gridControl_Item_Category.Name = "gridControl_Item_Category";
            this.gridControl_Item_Category.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_GroupCode});
            this.gridControl_Item_Category.Size = new System.Drawing.Size(658, 328);
            this.gridControl_Item_Category.TabIndex = 2;
            this.gridControl_Item_Category.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Item_Category});
            this.gridControl_Item_Category.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Item_Category_ProcessGridKey);
            // 
            // gridView_Item_Category
            // 
            this.gridView_Item_Category.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Item_Category.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Item_Category.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Item_Category.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Item_Category.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCategoryCode,
            this.col_ItemCategoryName,
            this.col_GroupCode});
            this.gridView_Item_Category.GridControl = this.gridControl_Item_Category;
            this.gridView_Item_Category.Name = "gridView_Item_Category";
            this.gridView_Item_Category.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Nhóm thuốc).";
            this.gridView_Item_Category.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Item_Category.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Item_Category.OptionsFind.FindFilterColumns = "ItemCategoryName;ItemCategoryCode";
            this.gridView_Item_Category.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Item_Category.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Item_Category.OptionsView.ShowFooter = true;
            this.gridView_Item_Category.OptionsView.ShowGroupPanel = false;
            this.gridView_Item_Category.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Item_Category_InvalidRowException);
            this.gridView_Item_Category.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Item_Category_ValidateRow);
            // 
            // col_ItemCategoryCode
            // 
            this.col_ItemCategoryCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_ItemCategoryCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ItemCategoryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ItemCategoryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ItemCategoryCode.Caption = "Mã";
            this.col_ItemCategoryCode.FieldName = "ItemCategoryCode";
            this.col_ItemCategoryCode.Name = "col_ItemCategoryCode";
            this.col_ItemCategoryCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCategoryCode.OptionsColumn.AllowSize = false;
            this.col_ItemCategoryCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCategoryCode", "Count: {0:#,#}")});
            this.col_ItemCategoryCode.Visible = true;
            this.col_ItemCategoryCode.VisibleIndex = 0;
            this.col_ItemCategoryCode.Width = 69;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.Caption = "Tên diễn giải";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 1;
            this.col_ItemCategoryName.Width = 412;
            // 
            // col_GroupCode
            // 
            this.col_GroupCode.Caption = "Nhóm";
            this.col_GroupCode.ColumnEdit = this.rep_GroupCode;
            this.col_GroupCode.FieldName = "GroupCode";
            this.col_GroupCode.Name = "col_GroupCode";
            this.col_GroupCode.Visible = true;
            this.col_GroupCode.VisibleIndex = 2;
            this.col_GroupCode.Width = 161;
            // 
            // rep_GroupCode
            // 
            this.rep_GroupCode.AutoHeight = false;
            this.rep_GroupCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_GroupCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupCode", "Mã nhóm", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "Tên nhóm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleCode", "Mã phân hệ", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.rep_GroupCode.Name = "rep_GroupCode";
            this.rep_GroupCode.NullText = "...";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Item_Category);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(662, 353);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục - Phân nhóm thuốc";
            // 
            // frmPhanLoaiThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 353);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhanLoaiThuoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Phân loại thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhanLoaiThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Item_Category;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Item_Category;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_GroupCode;
    }
}