namespace Ps.Clinic.Master
{
    partial class frmDMGoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMGoi));
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Package_Detail = new DevExpress.XtraGrid.GridControl();
            this.gridView_Package_Detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldetail_ServicePackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldetail_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Service = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_ref_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_ref_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_ref_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_ref_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldetail_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldetail_Serial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldetail_ServicePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grList = new DevExpress.XtraEditors.GroupControl();
            this.butPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_List = new DevExpress.XtraGrid.GridControl();
            this.gridView_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServicePackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServicePackageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Package_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Package_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grList)).BeginInit();
            this.grList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).BeginInit();
            this.pnTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.butPrint);
            this.grDetails.Controls.Add(this.gridControl_Package_Detail);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(669, 677);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "Chi tiết dịch vụ trong gói";
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(635, 2);
            this.butPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(30, 25);
            this.butPrint.TabIndex = 14;
            this.butPrint.ToolTip = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // gridControl_Package_Detail
            // 
            this.gridControl_Package_Detail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Package_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Package_Detail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Package_Detail.Location = new System.Drawing.Point(2, 26);
            this.gridControl_Package_Detail.MainView = this.gridView_Package_Detail;
            this.gridControl_Package_Detail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Package_Detail.Name = "gridControl_Package_Detail";
            this.gridControl_Package_Detail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_Service});
            this.gridControl_Package_Detail.Size = new System.Drawing.Size(665, 649);
            this.gridControl_Package_Detail.TabIndex = 13;
            this.gridControl_Package_Detail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Package_Detail});
            this.gridControl_Package_Detail.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Package_Detail_ProcessGridKey);
            // 
            // gridView_Package_Detail
            // 
            this.gridView_Package_Detail.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Package_Detail.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Package_Detail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Package_Detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldetail_ServicePackageCode,
            this.coldetail_ServiceCode,
            this.coldetail_RowID,
            this.coldetail_Serial,
            this.coldetail_ServicePrice});
            this.gridView_Package_Detail.GridControl = this.gridControl_Package_Detail;
            this.gridView_Package_Detail.Name = "gridView_Package_Detail";
            this.gridView_Package_Detail.NewItemRowText = "Chọn dịch vụ theo gói";
            this.gridView_Package_Detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Package_Detail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Package_Detail.OptionsView.ShowFooter = true;
            this.gridView_Package_Detail.OptionsView.ShowGroupPanel = false;
            this.gridView_Package_Detail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Package_Detail_InvalidRowException);
            this.gridView_Package_Detail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Package_Detail_ValidateRow);
            // 
            // coldetail_ServicePackageCode
            // 
            this.coldetail_ServicePackageCode.Caption = "Mã gói";
            this.coldetail_ServicePackageCode.FieldName = "ServicePackageCode";
            this.coldetail_ServicePackageCode.Name = "coldetail_ServicePackageCode";
            this.coldetail_ServicePackageCode.OptionsColumn.AllowEdit = false;
            this.coldetail_ServicePackageCode.OptionsColumn.AllowFocus = false;
            this.coldetail_ServicePackageCode.Width = 101;
            // 
            // coldetail_ServiceCode
            // 
            this.coldetail_ServiceCode.Caption = "Viện phí";
            this.coldetail_ServiceCode.ColumnEdit = this.rep_Service;
            this.coldetail_ServiceCode.FieldName = "ServiceCode";
            this.coldetail_ServiceCode.Name = "coldetail_ServiceCode";
            this.coldetail_ServiceCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServiceCode", "Count: {0:#,#}")});
            this.coldetail_ServiceCode.Visible = true;
            this.coldetail_ServiceCode.VisibleIndex = 0;
            this.coldetail_ServiceCode.Width = 371;
            // 
            // rep_Service
            // 
            this.rep_Service.AutoHeight = false;
            this.rep_Service.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_Service.Name = "rep_Service";
            this.rep_Service.NullText = "...";
            this.rep_Service.View = this.repositoryItemSearchLookUpEdit1View;
            this.rep_Service.EditValueChanged += new System.EventHandler(this.rep_Service_EditValueChanged);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grid_ref_ServiceCode,
            this.grid_ref_ServiceName,
            this.grid_ref_ServiceCategoryName,
            this.grid_ref_ServiceGroupName});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // grid_ref_ServiceCode
            // 
            this.grid_ref_ServiceCode.Caption = "Mã VP";
            this.grid_ref_ServiceCode.FieldName = "ServiceCode";
            this.grid_ref_ServiceCode.Name = "grid_ref_ServiceCode";
            this.grid_ref_ServiceCode.Visible = true;
            this.grid_ref_ServiceCode.VisibleIndex = 0;
            this.grid_ref_ServiceCode.Width = 162;
            // 
            // grid_ref_ServiceName
            // 
            this.grid_ref_ServiceName.Caption = "Tên viện phí";
            this.grid_ref_ServiceName.FieldName = "ServiceName";
            this.grid_ref_ServiceName.Name = "grid_ref_ServiceName";
            this.grid_ref_ServiceName.Visible = true;
            this.grid_ref_ServiceName.VisibleIndex = 1;
            this.grid_ref_ServiceName.Width = 166;
            // 
            // grid_ref_ServiceCategoryName
            // 
            this.grid_ref_ServiceCategoryName.Caption = "Loại Dịch Vụ, Kỹ thuật, ..";
            this.grid_ref_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.grid_ref_ServiceCategoryName.Name = "grid_ref_ServiceCategoryName";
            this.grid_ref_ServiceCategoryName.Visible = true;
            this.grid_ref_ServiceCategoryName.VisibleIndex = 2;
            this.grid_ref_ServiceCategoryName.Width = 172;
            // 
            // grid_ref_ServiceGroupName
            // 
            this.grid_ref_ServiceGroupName.Caption = "Nhóm dịch vụ, kỹ thuật, ...";
            this.grid_ref_ServiceGroupName.FieldName = "ServiceGroupName";
            this.grid_ref_ServiceGroupName.Name = "grid_ref_ServiceGroupName";
            this.grid_ref_ServiceGroupName.Visible = true;
            this.grid_ref_ServiceGroupName.VisibleIndex = 3;
            this.grid_ref_ServiceGroupName.Width = 160;
            // 
            // coldetail_RowID
            // 
            this.coldetail_RowID.Caption = "ID";
            this.coldetail_RowID.FieldName = "RowID";
            this.coldetail_RowID.Name = "coldetail_RowID";
            // 
            // coldetail_Serial
            // 
            this.coldetail_Serial.AppearanceCell.Options.UseTextOptions = true;
            this.coldetail_Serial.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldetail_Serial.AppearanceHeader.Options.UseTextOptions = true;
            this.coldetail_Serial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldetail_Serial.Caption = "STT";
            this.coldetail_Serial.DisplayFormat.FormatString = "0";
            this.coldetail_Serial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldetail_Serial.FieldName = "Serial";
            this.coldetail_Serial.Name = "coldetail_Serial";
            this.coldetail_Serial.Visible = true;
            this.coldetail_Serial.VisibleIndex = 1;
            this.coldetail_Serial.Width = 52;
            // 
            // coldetail_ServicePrice
            // 
            this.coldetail_ServicePrice.AppearanceCell.Options.UseTextOptions = true;
            this.coldetail_ServicePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldetail_ServicePrice.AppearanceHeader.Options.UseTextOptions = true;
            this.coldetail_ServicePrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldetail_ServicePrice.Caption = "Giá Dịch Vụ";
            this.coldetail_ServicePrice.DisplayFormat.FormatString = "#,#";
            this.coldetail_ServicePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldetail_ServicePrice.FieldName = "ServicePrice";
            this.coldetail_ServicePrice.Name = "coldetail_ServicePrice";
            this.coldetail_ServicePrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServicePrice", "T.Tiền={0:#,###.##}")});
            this.coldetail_ServicePrice.Visible = true;
            this.coldetail_ServicePrice.VisibleIndex = 2;
            this.coldetail_ServicePrice.Width = 130;
            // 
            // grList
            // 
            this.grList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grList.AppearanceCaption.Options.UseFont = true;
            this.grList.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grList.CaptionImage")));
            this.grList.Controls.Add(this.butPrintAll);
            this.grList.Controls.Add(this.gridControl_List);
            this.grList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grList.Location = new System.Drawing.Point(0, 0);
            this.grList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grList.Name = "grList";
            this.grList.Size = new System.Drawing.Size(422, 677);
            this.grList.TabIndex = 0;
            this.grList.Text = "Danh sách gói";
            // 
            // butPrintAll
            // 
            this.butPrintAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrintAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butPrintAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrintAll.Image = ((System.Drawing.Image)(resources.GetObject("butPrintAll.Image")));
            this.butPrintAll.Location = new System.Drawing.Point(387, 2);
            this.butPrintAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrintAll.Name = "butPrintAll";
            this.butPrintAll.Size = new System.Drawing.Size(30, 25);
            this.butPrintAll.TabIndex = 15;
            this.butPrintAll.ToolTip = "In Tất Cả";
            this.butPrintAll.Click += new System.EventHandler(this.butPrintAll_Click);
            // 
            // gridControl_List
            // 
            this.gridControl_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_List.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_List.Location = new System.Drawing.Point(2, 26);
            this.gridControl_List.MainView = this.gridView_List;
            this.gridControl_List.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_List.Name = "gridControl_List";
            this.gridControl_List.Size = new System.Drawing.Size(418, 649);
            this.gridControl_List.TabIndex = 0;
            this.gridControl_List.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_List});
            this.gridControl_List.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_List_ProcessGridKey);
            // 
            // gridView_List
            // 
            this.gridView_List.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_List.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_List.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_List.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_List.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServicePackageCode,
            this.col_ServicePackageName});
            this.gridView_List.GridControl = this.gridControl_List;
            this.gridView_List.Name = "gridView_List";
            this.gridView_List.NewItemRowText = "Tên gói cần khai báo";
            this.gridView_List.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_List.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_List.OptionsFind.FindFilterColumns = "ServicePackageName";
            this.gridView_List.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_List.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_List.OptionsView.ShowFooter = true;
            this.gridView_List.OptionsView.ShowGroupPanel = false;
            this.gridView_List.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_List.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_List_InvalidRowException);
            this.gridView_List.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_List_ValidateRow);
            this.gridView_List.Click += new System.EventHandler(this.gridView_List_Click);
            // 
            // col_ServicePackageCode
            // 
            this.col_ServicePackageCode.Caption = "Mã gói";
            this.col_ServicePackageCode.FieldName = "ServicePackageCode";
            this.col_ServicePackageCode.Name = "col_ServicePackageCode";
            this.col_ServicePackageCode.OptionsColumn.AllowEdit = false;
            this.col_ServicePackageCode.OptionsColumn.AllowFocus = false;
            this.col_ServicePackageCode.OptionsColumn.ReadOnly = true;
            this.col_ServicePackageCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServicePackageCode", "Count: {0:#,#}")});
            this.col_ServicePackageCode.Visible = true;
            this.col_ServicePackageCode.VisibleIndex = 0;
            this.col_ServicePackageCode.Width = 87;
            // 
            // col_ServicePackageName
            // 
            this.col_ServicePackageName.Caption = "Tên gói";
            this.col_ServicePackageName.FieldName = "ServicePackageName";
            this.col_ServicePackageName.Name = "col_ServicePackageName";
            this.col_ServicePackageName.Visible = true;
            this.col_ServicePackageName.VisibleIndex = 1;
            this.col_ServicePackageName.Width = 317;
            // 
            // pnTemplate
            // 
            this.pnTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnTemplate.Name = "pnTemplate";
            this.pnTemplate.Panel1.Controls.Add(this.grList);
            this.pnTemplate.Panel1.Text = "Panel1";
            this.pnTemplate.Panel2.Controls.Add(this.grDetails);
            this.pnTemplate.Panel2.Text = "Panel2";
            this.pnTemplate.Size = new System.Drawing.Size(1097, 677);
            this.pnTemplate.SplitterPosition = 362;
            this.pnTemplate.TabIndex = 5;
            this.pnTemplate.Text = "splitContainerControl1";
            // 
            // frmDMGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 677);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDMGoi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMGoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Package_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Package_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grList)).EndInit();
            this.grList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraEditors.GroupControl grList;
        private DevExpress.XtraGrid.GridControl gridControl_List;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_List;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServicePackageCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServicePackageName;
        private DevExpress.XtraEditors.SplitContainerControl pnTemplate;
        private DevExpress.XtraGrid.GridControl gridControl_Package_Detail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Package_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn coldetail_ServicePackageCode;
        private DevExpress.XtraGrid.Columns.GridColumn coldetail_ServiceCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rep_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn grid_ref_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn grid_ref_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn coldetail_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn coldetail_Serial;
        private DevExpress.XtraGrid.Columns.GridColumn coldetail_ServicePrice;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butPrintAll;
        private DevExpress.XtraGrid.Columns.GridColumn grid_ref_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn grid_ref_ServiceGroupName;
    }
}