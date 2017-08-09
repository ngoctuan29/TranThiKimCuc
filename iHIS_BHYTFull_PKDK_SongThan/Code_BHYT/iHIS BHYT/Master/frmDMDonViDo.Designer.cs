namespace Ps.Clinic.Master
{
    partial class frmDMDonViDo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMDonViDo));
            this.gridControl_Unit = new DevExpress.XtraGrid.GridControl();
            this.gridView_Unit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_UnitValuesName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Unit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Unit
            // 
            this.gridControl_Unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Unit.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Unit.MainView = this.gridView_Unit;
            this.gridControl_Unit.Name = "gridControl_Unit";
            this.gridControl_Unit.Size = new System.Drawing.Size(714, 341);
            this.gridControl_Unit.TabIndex = 2;
            this.gridControl_Unit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Unit});
            // 
            // gridView_Unit
            // 
            this.gridView_Unit.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Unit.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Unit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_UnitValuesName,
            this.col_RowID});
            this.gridView_Unit.GridControl = this.gridControl_Unit;
            this.gridView_Unit.Name = "gridView_Unit";
            this.gridView_Unit.NewItemRowText = "Thêm mới tên, nội dung của đơn vị đo cho xét nghiệm !";
            this.gridView_Unit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Unit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Unit.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Unit.OptionsView.ShowFooter = true;
            this.gridView_Unit.OptionsView.ShowGroupPanel = false;
            this.gridView_Unit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Unit_InvalidRowException);
            this.gridView_Unit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Unit_ValidateRow);
            this.gridView_Unit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Unit_KeyDown);
            // 
            // col_UnitValuesName
            // 
            this.col_UnitValuesName.Caption = "Chỉ số đo";
            this.col_UnitValuesName.FieldName = "UnitValuesName";
            this.col_UnitValuesName.Name = "col_UnitValuesName";
            this.col_UnitValuesName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UnitValuesCode", "Count: {0:#,#}")});
            this.col_UnitValuesName.Visible = true;
            this.col_UnitValuesName.VisibleIndex = 0;
            this.col_UnitValuesName.Width = 524;
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "Mã ID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.ReadOnly = true;
            this.col_RowID.Width = 48;
            // 
            // frmDMDonViDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 341);
            this.Controls.Add(this.gridControl_Unit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMDonViDo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục đơn vị đo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMDonViDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Unit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Unit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Unit;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitValuesName;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
    }
}