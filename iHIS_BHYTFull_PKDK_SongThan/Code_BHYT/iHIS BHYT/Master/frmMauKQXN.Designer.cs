namespace Ps.Clinic.Master
{
    partial class frmMauKQXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMauKQXN));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_LaboratoryResult = new DevExpress.XtraGrid.GridControl();
            this.gridView_LaboratoryResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_laboratory_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_laboratory_DescriptionResult = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_LaboratoryResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LaboratoryResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.Controls.Add(this.gridControl_LaboratoryResult);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(783, 454);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Mô tả kết quả xét nghiệm";
            // 
            // gridControl_LaboratoryResult
            // 
            this.gridControl_LaboratoryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_LaboratoryResult.Location = new System.Drawing.Point(2, 20);
            this.gridControl_LaboratoryResult.MainView = this.gridView_LaboratoryResult;
            this.gridControl_LaboratoryResult.Name = "gridControl_LaboratoryResult";
            this.gridControl_LaboratoryResult.Size = new System.Drawing.Size(779, 432);
            this.gridControl_LaboratoryResult.TabIndex = 0;
            this.gridControl_LaboratoryResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_LaboratoryResult});
            // 
            // gridView_LaboratoryResult
            // 
            this.gridView_LaboratoryResult.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_LaboratoryResult.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_LaboratoryResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_laboratory_RowID,
            this.col_laboratory_DescriptionResult});
            this.gridView_LaboratoryResult.GridControl = this.gridControl_LaboratoryResult;
            this.gridView_LaboratoryResult.Name = "gridView_LaboratoryResult";
            this.gridView_LaboratoryResult.NewItemRowText = "Nhập kết quả xét nghiệm!";
            this.gridView_LaboratoryResult.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_LaboratoryResult.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_LaboratoryResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_LaboratoryResult.OptionsView.ShowFooter = true;
            this.gridView_LaboratoryResult.OptionsView.ShowGroupPanel = false;
            this.gridView_LaboratoryResult.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_LaboratoryResult_InvalidRowException);
            this.gridView_LaboratoryResult.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_LaboratoryResult_ValidateRow);
            this.gridView_LaboratoryResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_LaboratoryResult_KeyDown);
            // 
            // col_laboratory_RowID
            // 
            this.col_laboratory_RowID.Caption = "Mã";
            this.col_laboratory_RowID.FieldName = "RowID";
            this.col_laboratory_RowID.Name = "col_laboratory_RowID";
            // 
            // col_laboratory_DescriptionResult
            // 
            this.col_laboratory_DescriptionResult.Caption = "Kết quả xét nghiệm";
            this.col_laboratory_DescriptionResult.FieldName = "DescriptionResult";
            this.col_laboratory_DescriptionResult.Name = "col_laboratory_DescriptionResult";
            this.col_laboratory_DescriptionResult.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowID", "Count: {0:#,#}")});
            this.col_laboratory_DescriptionResult.Visible = true;
            this.col_laboratory_DescriptionResult.VisibleIndex = 0;
            // 
            // frmMauKQXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 454);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMauKQXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Mẫu mô tả kết quả xét nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMauKQXN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_LaboratoryResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LaboratoryResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_LaboratoryResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_LaboratoryResult;
        private DevExpress.XtraGrid.Columns.GridColumn col_laboratory_DescriptionResult;
        private DevExpress.XtraGrid.Columns.GridColumn col_laboratory_RowID;
    }
}