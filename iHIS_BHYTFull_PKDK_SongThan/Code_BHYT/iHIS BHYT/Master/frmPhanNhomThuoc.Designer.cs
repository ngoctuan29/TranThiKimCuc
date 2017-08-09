namespace Ps.Clinic.Master
{
    partial class frmPhanNhomThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanNhomThuoc));
            this.gridControl_ServiceGroup = new DevExpress.XtraGrid.GridControl();
            this.gridView_ServiceGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_GroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_ServiceModule = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_GroupID_BHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repGroupID_BHYT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repGroupID_BHYT)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ServiceGroup
            // 
            this.gridControl_ServiceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ServiceGroup.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ServiceGroup.MainView = this.gridView_ServiceGroup;
            this.gridControl_ServiceGroup.Name = "gridControl_ServiceGroup";
            this.gridControl_ServiceGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_ServiceModule,
            this.repGroupID_BHYT});
            this.gridControl_ServiceGroup.Size = new System.Drawing.Size(646, 334);
            this.gridControl_ServiceGroup.TabIndex = 1;
            this.gridControl_ServiceGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ServiceGroup});
            this.gridControl_ServiceGroup.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_ServiceGroup_ProcessGridKey);
            // 
            // gridView_ServiceGroup
            // 
            this.gridView_ServiceGroup.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_ServiceGroup.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_ServiceGroup.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_ServiceGroup.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_ServiceGroup.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_ServiceGroup.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_ServiceGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_GroupCode,
            this.col_GroupName,
            this.col_ServiceModuleCode,
            this.col_GroupID_BHYT});
            this.gridView_ServiceGroup.GridControl = this.gridControl_ServiceGroup;
            this.gridView_ServiceGroup.Name = "gridView_ServiceGroup";
            this.gridView_ServiceGroup.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Nhóm viện phí).";
            this.gridView_ServiceGroup.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_ServiceGroup.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_ServiceGroup.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_ServiceGroup.OptionsView.ShowFooter = true;
            this.gridView_ServiceGroup.OptionsView.ShowGroupPanel = false;
            this.gridView_ServiceGroup.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ServiceGroup_ValidateRow);
            // 
            // col_GroupCode
            // 
            this.col_GroupCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_GroupCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GroupCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GroupCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GroupCode.Caption = "Mã Nhóm";
            this.col_GroupCode.FieldName = "GroupCode";
            this.col_GroupCode.Name = "col_GroupCode";
            this.col_GroupCode.OptionsColumn.AllowEdit = false;
            this.col_GroupCode.OptionsColumn.AllowFocus = false;
            this.col_GroupCode.OptionsColumn.ReadOnly = true;
            this.col_GroupCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "GroupCode", "Count: {0:#,#}")});
            this.col_GroupCode.Visible = true;
            this.col_GroupCode.VisibleIndex = 0;
            this.col_GroupCode.Width = 80;
            // 
            // col_GroupName
            // 
            this.col_GroupName.Caption = "Tên nhóm";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 1;
            this.col_GroupName.Width = 397;
            // 
            // col_ServiceModuleCode
            // 
            this.col_ServiceModuleCode.Caption = "Phân hệ";
            this.col_ServiceModuleCode.ColumnEdit = this.rep_ServiceModule;
            this.col_ServiceModuleCode.FieldName = "ServiceModuleCode";
            this.col_ServiceModuleCode.Name = "col_ServiceModuleCode";
            this.col_ServiceModuleCode.Visible = true;
            this.col_ServiceModuleCode.VisibleIndex = 2;
            this.col_ServiceModuleCode.Width = 158;
            // 
            // rep_ServiceModule
            // 
            this.rep_ServiceModule.AutoHeight = false;
            this.rep_ServiceModule.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_ServiceModule.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleCode", "Mã Phân hệ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleName", "Tên phân hệ")});
            this.rep_ServiceModule.Name = "rep_ServiceModule";
            this.rep_ServiceModule.NullText = "...";
            // 
            // col_GroupID_BHYT
            // 
            this.col_GroupID_BHYT.Caption = "Nhóm BHYT";
            this.col_GroupID_BHYT.ColumnEdit = this.repGroupID_BHYT;
            this.col_GroupID_BHYT.FieldName = "GroupID_BHYT";
            this.col_GroupID_BHYT.Name = "col_GroupID_BHYT";
            this.col_GroupID_BHYT.Visible = true;
            this.col_GroupID_BHYT.VisibleIndex = 3;
            this.col_GroupID_BHYT.Width = 163;
            // 
            // repGroupID_BHYT
            // 
            this.repGroupID_BHYT.AutoHeight = false;
            this.repGroupID_BHYT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repGroupID_BHYT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupID", "Mã nhóm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "Tên nhóm")});
            this.repGroupID_BHYT.Name = "repGroupID_BHYT";
            this.repGroupID_BHYT.NullText = "";
            // 
            // frmPhanNhomThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 334);
            this.Controls.Add(this.gridControl_ServiceGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhanNhomThuoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục nhóm viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhanNhomThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repGroupID_BHYT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ServiceGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ServiceGroup;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceModuleCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_ServiceModule;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupID_BHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repGroupID_BHYT;
    }
}