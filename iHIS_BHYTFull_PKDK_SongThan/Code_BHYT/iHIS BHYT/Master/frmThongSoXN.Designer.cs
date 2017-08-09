namespace Ps.Clinic.Master
{
    partial class frmThongSoXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongSoXN));
            this.gridControl_Laboratory = new DevExpress.XtraGrid.GridControl();
            this.gridView_Laboratory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LaboratoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refUnit_Values = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.view_RefUnit_Values = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_Unit_Values = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Laboratory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Laboratory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refUnit_Values)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_RefUnit_Values)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Laboratory
            // 
            this.gridControl_Laboratory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Laboratory.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Laboratory.MainView = this.gridView_Laboratory;
            this.gridControl_Laboratory.Name = "gridControl_Laboratory";
            this.gridControl_Laboratory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refUnit_Values});
            this.gridControl_Laboratory.Size = new System.Drawing.Size(687, 360);
            this.gridControl_Laboratory.TabIndex = 2;
            this.gridControl_Laboratory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Laboratory});
            // 
            // gridView_Laboratory
            // 
            this.gridView_Laboratory.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Laboratory.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Laboratory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_LaboratoryName});
            this.gridView_Laboratory.GridControl = this.gridControl_Laboratory;
            this.gridView_Laboratory.Name = "gridView_Laboratory";
            this.gridView_Laboratory.NewItemRowText = "Thêm mới tên, nội dung của thông số xét nghiệm !";
            this.gridView_Laboratory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Laboratory.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Laboratory.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Laboratory.OptionsView.ShowFooter = true;
            this.gridView_Laboratory.OptionsView.ShowGroupPanel = false;
            this.gridView_Laboratory.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Laboratory_ValidateRow);
            this.gridView_Laboratory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Laboratory_KeyDown);
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "RowID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.Width = 98;
            // 
            // col_LaboratoryName
            // 
            this.col_LaboratoryName.Caption = "Tên - nội dung thông số";
            this.col_LaboratoryName.FieldName = "LaboratoryName";
            this.col_LaboratoryName.Name = "col_LaboratoryName";
            this.col_LaboratoryName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_LaboratoryName.Visible = true;
            this.col_LaboratoryName.VisibleIndex = 0;
            this.col_LaboratoryName.Width = 551;
            // 
            // refUnit_Values
            // 
            this.refUnit_Values.AutoHeight = false;
            this.refUnit_Values.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.refUnit_Values.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refUnit_Values.Name = "refUnit_Values";
            this.refUnit_Values.NullText = "...";
            this.refUnit_Values.View = this.view_RefUnit_Values;
            // 
            // view_RefUnit_Values
            // 
            this.view_RefUnit_Values.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_Unit_Values});
            this.view_RefUnit_Values.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.view_RefUnit_Values.Name = "view_RefUnit_Values";
            this.view_RefUnit_Values.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view_RefUnit_Values.OptionsView.ShowGroupPanel = false;
            // 
            // view_Unit_Values
            // 
            this.view_Unit_Values.Caption = "Đơn vị";
            this.view_Unit_Values.FieldName = "Unit_Values";
            this.view_Unit_Values.Name = "view_Unit_Values";
            this.view_Unit_Values.Visible = true;
            this.view_Unit_Values.VisibleIndex = 0;
            // 
            // frmThongSoXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 360);
            this.Controls.Add(this.gridControl_Laboratory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThongSoXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh mục thông số xét nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongSoXN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Laboratory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Laboratory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refUnit_Values)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_RefUnit_Values)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Laboratory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Laboratory;
        private DevExpress.XtraGrid.Columns.GridColumn col_LaboratoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit refUnit_Values;
        private DevExpress.XtraGrid.Views.Grid.GridView view_RefUnit_Values;
        private DevExpress.XtraGrid.Columns.GridColumn view_Unit_Values;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
    }
}