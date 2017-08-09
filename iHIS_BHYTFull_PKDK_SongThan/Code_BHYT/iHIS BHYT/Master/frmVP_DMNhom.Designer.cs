namespace Ps.Clinic.Master
{
    partial class frmVP_DMNhom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_DMNhom));
            this.gridControl_ServiceGroup = new DevExpress.XtraGrid.GridControl();
            this.gridView_ServiceGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_ServiceModule = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_ServiceSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupID_BHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reptxt_ServiceGroupCode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repsearch_GroupBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repsearch_GroupBHYT_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupBHYT_GroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupBHYT_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reptxt_ServiceGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearch_GroupBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearch_GroupBHYT_View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ServiceGroup
            // 
            this.gridControl_ServiceGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_ServiceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ServiceGroup.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ServiceGroup.MainView = this.gridView_ServiceGroup;
            this.gridControl_ServiceGroup.Name = "gridControl_ServiceGroup";
            this.gridControl_ServiceGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_ServiceModule,
            this.reptxt_ServiceGroupCode,
            this.repsearch_GroupBHYT});
            this.gridControl_ServiceGroup.Size = new System.Drawing.Size(1024, 600);
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
            this.col_ServiceGroupCode,
            this.col_ServiceGroupName,
            this.col_ServiceModuleCode,
            this.col_ServiceSTT,
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
            // col_ServiceGroupCode
            // 
            this.col_ServiceGroupCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_ServiceGroupCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceGroupCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceGroupCode.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceGroupCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ServiceGroupCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceGroupCode.Caption = "Mã Nhóm";
            this.col_ServiceGroupCode.ColumnEdit = this.reptxt_ServiceGroupCode;
            this.col_ServiceGroupCode.FieldName = "ServiceGroupCode";
            this.col_ServiceGroupCode.Name = "col_ServiceGroupCode";
            this.col_ServiceGroupCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_ServiceGroupCode.Visible = true;
            this.col_ServiceGroupCode.VisibleIndex = 0;
            this.col_ServiceGroupCode.Width = 77;
            // 
            // col_ServiceGroupName
            // 
            this.col_ServiceGroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceGroupName.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceGroupName.Caption = "Tên nhóm";
            this.col_ServiceGroupName.FieldName = "ServiceGroupName";
            this.col_ServiceGroupName.Name = "col_ServiceGroupName";
            this.col_ServiceGroupName.Visible = true;
            this.col_ServiceGroupName.VisibleIndex = 1;
            this.col_ServiceGroupName.Width = 281;
            // 
            // col_ServiceModuleCode
            // 
            this.col_ServiceModuleCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceModuleCode.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceModuleCode.Caption = "Phân hệ";
            this.col_ServiceModuleCode.ColumnEdit = this.rep_ServiceModule;
            this.col_ServiceModuleCode.FieldName = "ServiceModuleCode";
            this.col_ServiceModuleCode.Name = "col_ServiceModuleCode";
            this.col_ServiceModuleCode.Visible = true;
            this.col_ServiceModuleCode.VisibleIndex = 2;
            this.col_ServiceModuleCode.Width = 198;
            // 
            // rep_ServiceModule
            // 
            this.rep_ServiceModule.AutoHeight = false;
            this.rep_ServiceModule.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_ServiceModule.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleCode", "Mã Phân hệ", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleName", "Tên phân hệ")});
            this.rep_ServiceModule.Name = "rep_ServiceModule";
            this.rep_ServiceModule.NullText = "...";
            // 
            // col_ServiceSTT
            // 
            this.col_ServiceSTT.AppearanceCell.Options.UseTextOptions = true;
            this.col_ServiceSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ServiceSTT.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ServiceSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ServiceSTT.Caption = "STT";
            this.col_ServiceSTT.DisplayFormat.FormatString = "#,###";
            this.col_ServiceSTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ServiceSTT.FieldName = "STT";
            this.col_ServiceSTT.Name = "col_ServiceSTT";
            this.col_ServiceSTT.Visible = true;
            this.col_ServiceSTT.VisibleIndex = 4;
            this.col_ServiceSTT.Width = 29;
            // 
            // col_GroupID_BHYT
            // 
            this.col_GroupID_BHYT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GroupID_BHYT.AppearanceHeader.Options.UseFont = true;
            this.col_GroupID_BHYT.Caption = "Nhóm BC BHYT";
            this.col_GroupID_BHYT.ColumnEdit = this.repsearch_GroupBHYT;
            this.col_GroupID_BHYT.FieldName = "GroupID_BHYT";
            this.col_GroupID_BHYT.Name = "col_GroupID_BHYT";
            this.col_GroupID_BHYT.Visible = true;
            this.col_GroupID_BHYT.VisibleIndex = 3;
            this.col_GroupID_BHYT.Width = 191;
            // 
            // reptxt_ServiceGroupCode
            // 
            this.reptxt_ServiceGroupCode.AutoHeight = false;
            this.reptxt_ServiceGroupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.reptxt_ServiceGroupCode.Name = "reptxt_ServiceGroupCode";
            // 
            // repsearch_GroupBHYT
            // 
            this.repsearch_GroupBHYT.AutoHeight = false;
            this.repsearch_GroupBHYT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repsearch_GroupBHYT.Name = "repsearch_GroupBHYT";
            this.repsearch_GroupBHYT.NullText = "";
            this.repsearch_GroupBHYT.View = this.repsearch_GroupBHYT_View;
            // 
            // repsearch_GroupBHYT_View
            // 
            this.repsearch_GroupBHYT_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroupBHYT_GroupID,
            this.colGroupBHYT_GroupName});
            this.repsearch_GroupBHYT_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repsearch_GroupBHYT_View.Name = "repsearch_GroupBHYT_View";
            this.repsearch_GroupBHYT_View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repsearch_GroupBHYT_View.OptionsView.ShowGroupPanel = false;
            // 
            // colGroupBHYT_GroupID
            // 
            this.colGroupBHYT_GroupID.Caption = "ID";
            this.colGroupBHYT_GroupID.FieldName = "GroupID";
            this.colGroupBHYT_GroupID.Name = "colGroupBHYT_GroupID";
            this.colGroupBHYT_GroupID.Visible = true;
            this.colGroupBHYT_GroupID.VisibleIndex = 0;
            this.colGroupBHYT_GroupID.Width = 62;
            // 
            // colGroupBHYT_GroupName
            // 
            this.colGroupBHYT_GroupName.Caption = "Nhóm BHYT";
            this.colGroupBHYT_GroupName.FieldName = "GroupName";
            this.colGroupBHYT_GroupName.Name = "colGroupBHYT_GroupName";
            this.colGroupBHYT_GroupName.Visible = true;
            this.colGroupBHYT_GroupName.VisibleIndex = 1;
            this.colGroupBHYT_GroupName.Width = 899;
            // 
            // frmVP_DMNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.gridControl_ServiceGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVP_DMNhom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục nhóm viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhomVienPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reptxt_ServiceGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearch_GroupBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repsearch_GroupBHYT_View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ServiceGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ServiceGroup;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceModuleCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_ServiceModule;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceSTT;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupID_BHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reptxt_ServiceGroupCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repsearch_GroupBHYT;
        private DevExpress.XtraGrid.Views.Grid.GridView repsearch_GroupBHYT_View;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupBHYT_GroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupBHYT_GroupName;
    }
}