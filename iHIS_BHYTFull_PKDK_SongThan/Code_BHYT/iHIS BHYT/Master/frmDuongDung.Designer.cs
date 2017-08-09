namespace Ps.Clinic.Master
{
    partial class frmDuongDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuongDung));
            this.gridControl_Usage = new DevExpress.XtraGrid.GridControl();
            this.gridView_Usage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_UsageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UsageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_BHYT_MaDuongDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSchLKup_UsageBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSchLKupView_UsageBHYT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsage_UsageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsage_UsageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpin_STT = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSchLKup_UsageBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSchLKupView_UsageBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_STT)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Usage
            // 
            this.gridControl_Usage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Usage.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Usage.MainView = this.gridView_Usage;
            this.gridControl_Usage.Name = "gridControl_Usage";
            this.gridControl_Usage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSpin_STT,
            this.repSchLKup_UsageBHYT});
            this.gridControl_Usage.Size = new System.Drawing.Size(516, 322);
            this.gridControl_Usage.TabIndex = 2;
            this.gridControl_Usage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Usage});
            this.gridControl_Usage.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Usage_ProcessGridKey);
            // 
            // gridView_Usage
            // 
            this.gridView_Usage.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Usage.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Usage.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Usage.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Usage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Usage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_UsageCode,
            this.col_UsageName,
            this.col_BHYT_MaDuongDung,
            this.col_STT});
            this.gridView_Usage.GridControl = this.gridControl_Usage;
            this.gridView_Usage.Name = "gridView_Usage";
            this.gridView_Usage.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục đường dùng của thuốc, VTYT.";
            this.gridView_Usage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Usage.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Usage.OptionsFind.FindFilterColumns = "UsageName";
            this.gridView_Usage.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Usage.OptionsView.ShowFooter = true;
            this.gridView_Usage.OptionsView.ShowGroupPanel = false;
            this.gridView_Usage.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Usage_InvalidRowException);
            this.gridView_Usage.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Usage_ValidateRow);
            // 
            // col_UsageCode
            // 
            this.col_UsageCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_UsageCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UsageCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UsageCode.AppearanceHeader.Options.UseFont = true;
            this.col_UsageCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UsageCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UsageCode.Caption = "Mã";
            this.col_UsageCode.FieldName = "UsageCode";
            this.col_UsageCode.Name = "col_UsageCode";
            this.col_UsageCode.OptionsColumn.AllowEdit = false;
            this.col_UsageCode.OptionsColumn.AllowSize = false;
            this.col_UsageCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UsageCode", "Count: {0:#,#}")});
            this.col_UsageCode.Visible = true;
            this.col_UsageCode.VisibleIndex = 0;
            this.col_UsageCode.Width = 67;
            // 
            // col_UsageName
            // 
            this.col_UsageName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UsageName.AppearanceHeader.Options.UseFont = true;
            this.col_UsageName.Caption = "Tên đường dùng";
            this.col_UsageName.FieldName = "UsageName";
            this.col_UsageName.Name = "col_UsageName";
            this.col_UsageName.Visible = true;
            this.col_UsageName.VisibleIndex = 1;
            this.col_UsageName.Width = 250;
            // 
            // col_BHYT_MaDuongDung
            // 
            this.col_BHYT_MaDuongDung.AppearanceCell.Options.UseTextOptions = true;
            this.col_BHYT_MaDuongDung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_BHYT_MaDuongDung.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_BHYT_MaDuongDung.AppearanceHeader.Options.UseFont = true;
            this.col_BHYT_MaDuongDung.AppearanceHeader.Options.UseTextOptions = true;
            this.col_BHYT_MaDuongDung.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_BHYT_MaDuongDung.Caption = "Mã Đ. Dùng (BYT)";
            this.col_BHYT_MaDuongDung.ColumnEdit = this.repSchLKup_UsageBHYT;
            this.col_BHYT_MaDuongDung.FieldName = "BHYT_MaDuongDung";
            this.col_BHYT_MaDuongDung.Name = "col_BHYT_MaDuongDung";
            this.col_BHYT_MaDuongDung.Visible = true;
            this.col_BHYT_MaDuongDung.VisibleIndex = 2;
            this.col_BHYT_MaDuongDung.Width = 126;
            // 
            // repSchLKup_UsageBHYT
            // 
            this.repSchLKup_UsageBHYT.AutoHeight = false;
            this.repSchLKup_UsageBHYT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSchLKup_UsageBHYT.Name = "repSchLKup_UsageBHYT";
            this.repSchLKup_UsageBHYT.NullText = "";
            this.repSchLKup_UsageBHYT.View = this.repSchLKupView_UsageBHYT;
            // 
            // repSchLKupView_UsageBHYT
            // 
            this.repSchLKupView_UsageBHYT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsage_UsageCode,
            this.colUsage_UsageName});
            this.repSchLKupView_UsageBHYT.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSchLKupView_UsageBHYT.Name = "repSchLKupView_UsageBHYT";
            this.repSchLKupView_UsageBHYT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSchLKupView_UsageBHYT.OptionsView.ShowGroupPanel = false;
            // 
            // colUsage_UsageCode
            // 
            this.colUsage_UsageCode.Caption = "Mã";
            this.colUsage_UsageCode.FieldName = "UsageCode";
            this.colUsage_UsageCode.Name = "colUsage_UsageCode";
            this.colUsage_UsageCode.Visible = true;
            this.colUsage_UsageCode.VisibleIndex = 0;
            this.colUsage_UsageCode.Width = 96;
            // 
            // colUsage_UsageName
            // 
            this.colUsage_UsageName.Caption = "Đường dùng";
            this.colUsage_UsageName.FieldName = "UsageName";
            this.colUsage_UsageName.Name = "colUsage_UsageName";
            this.colUsage_UsageName.Visible = true;
            this.colUsage_UsageName.VisibleIndex = 1;
            this.colUsage_UsageName.Width = 872;
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
            this.col_STT.ColumnEdit = this.repSpin_STT;
            this.col_STT.FieldName = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 3;
            this.col_STT.Width = 57;
            // 
            // repSpin_STT
            // 
            this.repSpin_STT.AutoHeight = false;
            this.repSpin_STT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpin_STT.MaxLength = 1000;
            this.repSpin_STT.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.repSpin_STT.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repSpin_STT.Name = "repSpin_STT";
            // 
            // frmDuongDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 322);
            this.Controls.Add(this.gridControl_Usage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDuongDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo đường dùng thuốc, vtyt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDuongDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSchLKup_UsageBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSchLKupView_UsageBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_STT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Usage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Usage;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsageCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsageName;
        private DevExpress.XtraGrid.Columns.GridColumn col_BHYT_MaDuongDung;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpin_STT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSchLKup_UsageBHYT;
        private DevExpress.XtraGrid.Views.Grid.GridView repSchLKupView_UsageBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn colUsage_UsageCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUsage_UsageName;
    }
}