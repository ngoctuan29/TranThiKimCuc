namespace Ps.Clinic.Master
{
    partial class frmLoaiVienPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiVienPhi));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Service_Category = new DevExpress.XtraGrid.GridControl();
            this.gridView_Service_Category = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Service_Group_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Service_Group_Code = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ref_View_Service_Group_Code = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_ServiceGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCategorySTT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_Group_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_View_Service_Group_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.butPrint);
            this.grMain.Controls.Add(this.panelControl2);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(666, 358);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục loại viện phí";
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butPrint.Appearance.Options.UseForeColor = true;
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(612, 0);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(51, 22);
            this.butPrint.TabIndex = 9;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl_Service_Category);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(662, 333);
            this.panelControl2.TabIndex = 6;
            // 
            // gridControl_Service_Category
            // 
            this.gridControl_Service_Category.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Service_Category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Service_Category.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Service_Category.MainView = this.gridView_Service_Category;
            this.gridControl_Service_Category.Name = "gridControl_Service_Category";
            this.gridControl_Service_Category.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_Service_Group_Code});
            this.gridControl_Service_Category.Size = new System.Drawing.Size(662, 333);
            this.gridControl_Service_Category.TabIndex = 0;
            this.gridControl_Service_Category.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Service_Category});
            this.gridControl_Service_Category.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Service_Category_ProcessGridKey);
            // 
            // gridView_Service_Category
            // 
            this.gridView_Service_Category.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Service_Category.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Service_Category.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Service_Category.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Service_Category.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServiceCategoryCode,
            this.col_ServiceCategoryName,
            this.col_Service_Group_Code,
            this.col_ServiceCategorySTT});
            this.gridView_Service_Category.GridControl = this.gridControl_Service_Category;
            this.gridView_Service_Category.GroupPanelText = "Nhóm loại viện phí theo nhóm!";
            this.gridView_Service_Category.Name = "gridView_Service_Category";
            this.gridView_Service_Category.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (loại viện phí).";
            this.gridView_Service_Category.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Service_Category.OptionsView.ShowFooter = true;
            this.gridView_Service_Category.OptionsView.ShowGroupPanel = false;
            this.gridView_Service_Category.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Service_Category_InvalidRowException);
            this.gridView_Service_Category.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Service_Category_ValidateRow);
            // 
            // col_ServiceCategoryCode
            // 
            this.col_ServiceCategoryCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_ServiceCategoryCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceCategoryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ServiceCategoryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceCategoryCode.Caption = "Mã loại viện phí";
            this.col_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.col_ServiceCategoryCode.Name = "col_ServiceCategoryCode";
            this.col_ServiceCategoryCode.OptionsColumn.AllowEdit = false;
            this.col_ServiceCategoryCode.OptionsColumn.AllowSize = false;
            this.col_ServiceCategoryCode.Width = 110;
            // 
            // col_ServiceCategoryName
            // 
            this.col_ServiceCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceCategoryName.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceCategoryName.Caption = "Tên loại viện phí";
            this.col_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_ServiceCategoryName.Name = "col_ServiceCategoryName";
            this.col_ServiceCategoryName.Visible = true;
            this.col_ServiceCategoryName.VisibleIndex = 1;
            this.col_ServiceCategoryName.Width = 498;
            // 
            // col_Service_Group_Code
            // 
            this.col_Service_Group_Code.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Service_Group_Code.AppearanceHeader.Options.UseFont = true;
            this.col_Service_Group_Code.Caption = "Nhóm viện phí";
            this.col_Service_Group_Code.ColumnEdit = this.ref_Service_Group_Code;
            this.col_Service_Group_Code.FieldName = "ServiceGroupCode";
            this.col_Service_Group_Code.Name = "col_Service_Group_Code";
            this.col_Service_Group_Code.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServiceGroupCode", "Count: {0:#,#}")});
            this.col_Service_Group_Code.Visible = true;
            this.col_Service_Group_Code.VisibleIndex = 0;
            this.col_Service_Group_Code.Width = 95;
            // 
            // ref_Service_Group_Code
            // 
            this.ref_Service_Group_Code.AutoHeight = false;
            this.ref_Service_Group_Code.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.ref_Service_Group_Code.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Service_Group_Code.Name = "ref_Service_Group_Code";
            this.ref_Service_Group_Code.NullText = "Y/c chọn...!";
            this.ref_Service_Group_Code.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ref_Service_Group_Code.View = this.ref_View_Service_Group_Code;
            // 
            // ref_View_Service_Group_Code
            // 
            this.ref_View_Service_Group_Code.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_ServiceGroupCode,
            this.view_ServiceGroupName});
            this.ref_View_Service_Group_Code.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ref_View_Service_Group_Code.Name = "ref_View_Service_Group_Code";
            this.ref_View_Service_Group_Code.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ref_View_Service_Group_Code.OptionsView.ShowGroupPanel = false;
            // 
            // view_ServiceGroupCode
            // 
            this.view_ServiceGroupCode.Caption = "Mã nhóm";
            this.view_ServiceGroupCode.FieldName = "ServiceGroupCode";
            this.view_ServiceGroupCode.Name = "view_ServiceGroupCode";
            this.view_ServiceGroupCode.Visible = true;
            this.view_ServiceGroupCode.VisibleIndex = 0;
            // 
            // view_ServiceGroupName
            // 
            this.view_ServiceGroupName.Caption = "Tên nhóm";
            this.view_ServiceGroupName.FieldName = "ServiceGroupName";
            this.view_ServiceGroupName.Name = "view_ServiceGroupName";
            this.view_ServiceGroupName.Visible = true;
            this.view_ServiceGroupName.VisibleIndex = 1;
            // 
            // col_ServiceCategorySTT
            // 
            this.col_ServiceCategorySTT.AppearanceCell.Options.UseTextOptions = true;
            this.col_ServiceCategorySTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceCategorySTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceCategorySTT.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceCategorySTT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ServiceCategorySTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceCategorySTT.Caption = "STT";
            this.col_ServiceCategorySTT.DisplayFormat.FormatString = "#,###";
            this.col_ServiceCategorySTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ServiceCategorySTT.FieldName = "STT";
            this.col_ServiceCategorySTT.Name = "col_ServiceCategorySTT";
            this.col_ServiceCategorySTT.Visible = true;
            this.col_ServiceCategorySTT.VisibleIndex = 2;
            this.col_ServiceCategorySTT.Width = 53;
            // 
            // frmLoaiVienPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 358);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoaiVienPhi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo loại viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoaiVienPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_Group_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_View_Service_Group_Code)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Service_Category;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Service_Category;
        private DevExpress.XtraGrid.Columns.GridColumn col_Service_Group_Code;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ref_Service_Group_Code;
        private DevExpress.XtraGrid.Views.Grid.GridView ref_View_Service_Group_Code;
        private DevExpress.XtraGrid.Columns.GridColumn view_ServiceGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn view_ServiceGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategorySTT;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton butPrint;
    }
}