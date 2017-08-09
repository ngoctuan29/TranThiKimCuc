namespace Ps.Clinic.Master
{
    partial class frmDanhMucTinhThanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucTinhThanh));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Provincial = new DevExpress.XtraGrid.GridControl();
            this.gridView_Provincial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ProvincialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProvincialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RegionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.replkupRegion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_ProvincialIDBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Provincial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Provincial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replkupRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Provincial);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(921, 482);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục tỉnh thành phố";
            // 
            // gridControl_Provincial
            // 
            this.gridControl_Provincial.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Provincial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Provincial.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Provincial.MainView = this.gridView_Provincial;
            this.gridControl_Provincial.Name = "gridControl_Provincial";
            this.gridControl_Provincial.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.replkupRegion});
            this.gridControl_Provincial.Size = new System.Drawing.Size(917, 457);
            this.gridControl_Provincial.TabIndex = 0;
            this.gridControl_Provincial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Provincial});
            this.gridControl_Provincial.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Object_ProcessGridKey);
            // 
            // gridView_Provincial
            // 
            this.gridView_Provincial.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Provincial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ProvincialCode,
            this.col_ProvincialName,
            this.col_STT,
            this.col_RegionID,
            this.col_ProvincialIDBHYT});
            this.gridView_Provincial.GridControl = this.gridControl_Provincial;
            this.gridView_Provincial.Name = "gridView_Provincial";
            this.gridView_Provincial.NewItemRowText = "Nhập thêm mới tỉnh, thành phố!";
            this.gridView_Provincial.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Provincial.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Provincial.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Provincial.OptionsView.ShowFooter = true;
            this.gridView_Provincial.OptionsView.ShowGroupPanel = false;
            this.gridView_Provincial.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Object_InvalidRowException);
            this.gridView_Provincial.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Object_ValidateRow);
            // 
            // col_ProvincialCode
            // 
            this.col_ProvincialCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_ProvincialCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ProvincialCode.AppearanceHeader.Options.UseFont = true;
            this.col_ProvincialCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProvincialCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialCode.Caption = "Mã Tỉnh/T.Phố";
            this.col_ProvincialCode.FieldName = "ProvincialCode";
            this.col_ProvincialCode.Name = "col_ProvincialCode";
            this.col_ProvincialCode.OptionsColumn.AllowEdit = false;
            this.col_ProvincialCode.OptionsColumn.ReadOnly = true;
            this.col_ProvincialCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ObjectCode", "Count: {0:#,#}")});
            this.col_ProvincialCode.Visible = true;
            this.col_ProvincialCode.VisibleIndex = 0;
            this.col_ProvincialCode.Width = 96;
            // 
            // col_ProvincialName
            // 
            this.col_ProvincialName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ProvincialName.AppearanceHeader.Options.UseFont = true;
            this.col_ProvincialName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProvincialName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialName.Caption = "Tên Tỉnh/T.Phố";
            this.col_ProvincialName.FieldName = "ProvincialName";
            this.col_ProvincialName.Name = "col_ProvincialName";
            this.col_ProvincialName.Visible = true;
            this.col_ProvincialName.VisibleIndex = 1;
            this.col_ProvincialName.Width = 444;
            // 
            // col_STT
            // 
            this.col_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_STT.AppearanceHeader.Options.UseFont = true;
            this.col_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.Caption = "STT";
            this.col_STT.FieldName = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 2;
            this.col_STT.Width = 35;
            // 
            // col_RegionID
            // 
            this.col_RegionID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RegionID.AppearanceHeader.Options.UseFont = true;
            this.col_RegionID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RegionID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RegionID.Caption = "Vùng miền";
            this.col_RegionID.ColumnEdit = this.replkupRegion;
            this.col_RegionID.FieldName = "RegionID";
            this.col_RegionID.Name = "col_RegionID";
            this.col_RegionID.Visible = true;
            this.col_RegionID.VisibleIndex = 3;
            this.col_RegionID.Width = 129;
            // 
            // replkupRegion
            // 
            this.replkupRegion.AutoHeight = false;
            this.replkupRegion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.replkupRegion.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionID", 50, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionName", 120, "Vùng miền")});
            this.replkupRegion.Name = "replkupRegion";
            this.replkupRegion.NullText = "Vùng miền";
            // 
            // col_ProvincialIDBHYT
            // 
            this.col_ProvincialIDBHYT.AppearanceCell.Options.UseTextOptions = true;
            this.col_ProvincialIDBHYT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialIDBHYT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ProvincialIDBHYT.AppearanceHeader.Options.UseFont = true;
            this.col_ProvincialIDBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProvincialIDBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialIDBHYT.Caption = "Mã tỉnh BHYT";
            this.col_ProvincialIDBHYT.FieldName = "ProvincialIDBHYT";
            this.col_ProvincialIDBHYT.Name = "col_ProvincialIDBHYT";
            this.col_ProvincialIDBHYT.Visible = true;
            this.col_ProvincialIDBHYT.VisibleIndex = 4;
            // 
            // frmDanhMucTinhThanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 482);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucTinhThanh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucTinhThanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Provincial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Provincial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replkupRegion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Provincial;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Provincial;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProvincialCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProvincialName;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraGrid.Columns.GridColumn col_RegionID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit replkupRegion;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProvincialIDBHYT;
    }
}