namespace Ps.Clinic.Master
{
    partial class frmDanhMucKho
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
            DevExpress.XtraGrid.Columns.GridColumn col_RepositoryCode;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucKho));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RepositoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RepositoryGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_RepositoryGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_RepositorySatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_RepositoryDateReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_AllowAdded = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rep_ExportBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            col_RepositoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_RepositoryGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_AllowAdded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ExportBHYT)).BeginInit();
            this.SuspendLayout();
            // 
            // col_RepositoryCode
            // 
            col_RepositoryCode.AppearanceCell.Options.UseTextOptions = true;
            col_RepositoryCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            col_RepositoryCode.AppearanceHeader.Options.UseTextOptions = true;
            col_RepositoryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            col_RepositoryCode.Caption = "Mã kho";
            col_RepositoryCode.FieldName = "RepositoryCode";
            col_RepositoryCode.Name = "col_RepositoryCode";
            col_RepositoryCode.OptionsColumn.AllowEdit = false;
            col_RepositoryCode.OptionsColumn.AllowSize = false;
            col_RepositoryCode.OptionsColumn.ReadOnly = true;
            col_RepositoryCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RepositoryCode", "Count: {0:#,#}")});
            col_RepositoryCode.Visible = true;
            col_RepositoryCode.VisibleIndex = 0;
            col_RepositoryCode.Width = 65;
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Data);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(674, 362);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục kho";
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_Hide,
            this.rep_AllowAdded,
            this.rep_ExportBHYT,
            this.rep_RepositoryGroup});
            this.gridControl_Data.Size = new System.Drawing.Size(670, 337);
            this.gridControl_Data.TabIndex = 0;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            this.gridControl_Data.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Data_ProcessGridKey);
            // 
            // gridView_Data
            // 
            this.gridView_Data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            col_RepositoryCode,
            this.col_RepositoryName,
            this.col_RepositoryGroupCode,
            this.col_RepositorySatus,
            this.col_RepositoryDateReport});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục kho.";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Data.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Object_InvalidRowException);
            this.gridView_Data.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Data_ValidateRow);
            // 
            // col_RepositoryName
            // 
            this.col_RepositoryName.Caption = "Tên kho";
            this.col_RepositoryName.FieldName = "RepositoryName";
            this.col_RepositoryName.Name = "col_RepositoryName";
            this.col_RepositoryName.Visible = true;
            this.col_RepositoryName.VisibleIndex = 1;
            this.col_RepositoryName.Width = 406;
            // 
            // col_RepositoryGroupCode
            // 
            this.col_RepositoryGroupCode.Caption = "Nhóm kho";
            this.col_RepositoryGroupCode.ColumnEdit = this.rep_RepositoryGroup;
            this.col_RepositoryGroupCode.FieldName = "RepositoryGroupCode";
            this.col_RepositoryGroupCode.Name = "col_RepositoryGroupCode";
            this.col_RepositoryGroupCode.OptionsColumn.AllowSize = false;
            this.col_RepositoryGroupCode.Visible = true;
            this.col_RepositoryGroupCode.VisibleIndex = 2;
            this.col_RepositoryGroupCode.Width = 144;
            // 
            // rep_RepositoryGroup
            // 
            this.rep_RepositoryGroup.AutoHeight = false;
            this.rep_RepositoryGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_RepositoryGroup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryGroupName", "Tên nhóm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryGroupCode", "Mã nhóm", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.rep_RepositoryGroup.Name = "rep_RepositoryGroup";
            this.rep_RepositoryGroup.NullText = "..";
            this.rep_RepositoryGroup.ShowFooter = false;
            this.rep_RepositoryGroup.ShowHeader = false;
            // 
            // col_RepositorySatus
            // 
            this.col_RepositorySatus.AppearanceCell.Options.UseTextOptions = true;
            this.col_RepositorySatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RepositorySatus.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RepositorySatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RepositorySatus.Caption = "Khóa";
            this.col_RepositorySatus.ColumnEdit = this.rep_Hide;
            this.col_RepositorySatus.FieldName = "Hide";
            this.col_RepositorySatus.Name = "col_RepositorySatus";
            this.col_RepositorySatus.OptionsColumn.AllowSize = false;
            this.col_RepositorySatus.Visible = true;
            this.col_RepositorySatus.VisibleIndex = 3;
            this.col_RepositorySatus.Width = 39;
            // 
            // rep_Hide
            // 
            this.rep_Hide.AutoHeight = false;
            this.rep_Hide.DisplayValueChecked = "1";
            this.rep_Hide.DisplayValueGrayed = "0";
            this.rep_Hide.DisplayValueUnchecked = "0";
            this.rep_Hide.Name = "rep_Hide";
            this.rep_Hide.ValueChecked = 1;
            this.rep_Hide.ValueGrayed = 0;
            this.rep_Hide.ValueUnchecked = 0;
            // 
            // col_RepositoryDateReport
            // 
            this.col_RepositoryDateReport.Caption = "Ngày Lấy BC";
            this.col_RepositoryDateReport.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_RepositoryDateReport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_RepositoryDateReport.FieldName = "DateReport";
            this.col_RepositoryDateReport.Name = "col_RepositoryDateReport";
            this.col_RepositoryDateReport.Visible = true;
            this.col_RepositoryDateReport.VisibleIndex = 4;
            // 
            // rep_AllowAdded
            // 
            this.rep_AllowAdded.AutoHeight = false;
            this.rep_AllowAdded.DisplayValueChecked = "1";
            this.rep_AllowAdded.DisplayValueGrayed = "0";
            this.rep_AllowAdded.DisplayValueUnchecked = "0";
            this.rep_AllowAdded.Name = "rep_AllowAdded";
            this.rep_AllowAdded.ValueChecked = 1;
            this.rep_AllowAdded.ValueGrayed = 0;
            this.rep_AllowAdded.ValueUnchecked = 0;
            // 
            // rep_ExportBHYT
            // 
            this.rep_ExportBHYT.AutoHeight = false;
            this.rep_ExportBHYT.DisplayValueChecked = "1";
            this.rep_ExportBHYT.DisplayValueGrayed = "0";
            this.rep_ExportBHYT.DisplayValueUnchecked = "0";
            this.rep_ExportBHYT.Name = "rep_ExportBHYT";
            this.rep_ExportBHYT.ValueChecked = 1;
            this.rep_ExportBHYT.ValueGrayed = 0;
            this.rep_ExportBHYT.ValueUnchecked = 0;
            // 
            // frmDanhMucKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 362);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucKho";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_RepositoryGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_AllowAdded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ExportBHYT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositorySatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_AllowAdded;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_ExportBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryGroupCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_RepositoryGroup;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryDateReport;
    }
}