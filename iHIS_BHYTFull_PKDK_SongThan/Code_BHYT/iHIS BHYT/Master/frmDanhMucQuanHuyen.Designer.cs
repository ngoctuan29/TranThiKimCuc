namespace Ps.Clinic.Master
{
    partial class frmDanhMucQuanHuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucQuanHuyen));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_DistrictCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DistrictName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProvincialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.replkupProvincial = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replkupProvincial)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Data);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(921, 482);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục Quận/Huyện";
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.replkupProvincial});
            this.gridControl_Data.Size = new System.Drawing.Size(917, 457);
            this.gridControl_Data.TabIndex = 0;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            this.gridControl_Data.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Object_ProcessGridKey);
            // 
            // gridView_Data
            // 
            this.gridView_Data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_DistrictCode,
            this.col_DistrictName,
            this.col_STT,
            this.col_ProvincialCode});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "Nhập thêm mới quận/huyện ...";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Object_InvalidRowException);
            this.gridView_Data.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Object_ValidateRow);
            // 
            // col_DistrictCode
            // 
            this.col_DistrictCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_DistrictCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DistrictCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DistrictCode.AppearanceHeader.Options.UseFont = true;
            this.col_DistrictCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DistrictCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DistrictCode.Caption = "Mã Quận/Huyện";
            this.col_DistrictCode.FieldName = "DistrictCode";
            this.col_DistrictCode.Name = "col_DistrictCode";
            this.col_DistrictCode.OptionsColumn.AllowEdit = false;
            this.col_DistrictCode.OptionsColumn.ReadOnly = true;
            this.col_DistrictCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DistrictCode", "Tổng: {0:#,#}")});
            this.col_DistrictCode.Visible = true;
            this.col_DistrictCode.VisibleIndex = 0;
            this.col_DistrictCode.Width = 116;
            // 
            // col_DistrictName
            // 
            this.col_DistrictName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DistrictName.AppearanceHeader.Options.UseFont = true;
            this.col_DistrictName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DistrictName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DistrictName.Caption = "Tên Quận/Huyện";
            this.col_DistrictName.FieldName = "DistrictName";
            this.col_DistrictName.Name = "col_DistrictName";
            this.col_DistrictName.Visible = true;
            this.col_DistrictName.VisibleIndex = 2;
            this.col_DistrictName.Width = 426;
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
            this.col_STT.VisibleIndex = 3;
            this.col_STT.Width = 35;
            // 
            // col_ProvincialCode
            // 
            this.col_ProvincialCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ProvincialCode.AppearanceHeader.Options.UseFont = true;
            this.col_ProvincialCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProvincialCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialCode.Caption = "Tỉnh/Thành";
            this.col_ProvincialCode.ColumnEdit = this.replkupProvincial;
            this.col_ProvincialCode.FieldName = "ProvincialCode";
            this.col_ProvincialCode.Name = "col_ProvincialCode";
            this.col_ProvincialCode.Visible = true;
            this.col_ProvincialCode.VisibleIndex = 1;
            this.col_ProvincialCode.Width = 127;
            // 
            // replkupProvincial
            // 
            this.replkupProvincial.AutoHeight = false;
            this.replkupProvincial.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.replkupProvincial.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProvincialCode", 50, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProvincialName", 120, "Tỉnh/T.Phố")});
            this.replkupProvincial.Name = "replkupProvincial";
            this.replkupProvincial.NullText = "Tỉnh/Thành phố";
            // 
            // frmDanhMucQuanHuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 482);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucQuanHuyen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucQuanHuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replkupProvincial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_DistrictCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_DistrictName;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProvincialCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit replkupProvincial;
    }
}