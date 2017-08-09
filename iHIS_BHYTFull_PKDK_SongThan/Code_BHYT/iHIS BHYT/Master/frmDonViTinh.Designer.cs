namespace Ps.Clinic.Master
{
    partial class frmDonViTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonViTinh));
            this.gridControl_Price = new DevExpress.XtraGrid.GridControl();
            this.gridView_Unit_Of_Measure = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_UnitOfMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Unit_Of_Measure)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Price
            // 
            this.gridControl_Price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Price.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Price.MainView = this.gridView_Unit_Of_Measure;
            this.gridControl_Price.Name = "gridControl_Price";
            this.gridControl_Price.Size = new System.Drawing.Size(1024, 600);
            this.gridControl_Price.TabIndex = 2;
            this.gridControl_Price.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Unit_Of_Measure});
            this.gridControl_Price.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Unit_Of_Measure_ProcessGridKey);
            // 
            // gridView_Unit_Of_Measure
            // 
            this.gridView_Unit_Of_Measure.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Unit_Of_Measure.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Unit_Of_Measure.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Unit_Of_Measure.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Unit_Of_Measure.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Unit_Of_Measure.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_UnitOfMeasureCode,
            this.col_UnitOfMeasureName});
            this.gridView_Unit_Of_Measure.GridControl = this.gridControl_Price;
            this.gridView_Unit_Of_Measure.Name = "gridView_Unit_Of_Measure";
            this.gridView_Unit_Of_Measure.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục đơn vị tính.";
            this.gridView_Unit_Of_Measure.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Unit_Of_Measure.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Unit_Of_Measure.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Unit_Of_Measure.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Unit_Of_Measure.OptionsView.ShowFooter = true;
            this.gridView_Unit_Of_Measure.OptionsView.ShowGroupPanel = false;
            this.gridView_Unit_Of_Measure.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Unit_Of_Measure_InvalidRowException);
            this.gridView_Unit_Of_Measure.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Unit_Of_Measure_ValidateRow);
            // 
            // col_UnitOfMeasureCode
            // 
            this.col_UnitOfMeasureCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitOfMeasureCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureCode.Caption = "Mã đơn vị tính";
            this.col_UnitOfMeasureCode.FieldName = "UnitOfMeasureCode";
            this.col_UnitOfMeasureCode.Name = "col_UnitOfMeasureCode";
            this.col_UnitOfMeasureCode.OptionsColumn.AllowEdit = false;
            this.col_UnitOfMeasureCode.OptionsColumn.AllowSize = false;
            this.col_UnitOfMeasureCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UnitOfMeasureCode", "Count: {0:#,#}")});
            this.col_UnitOfMeasureCode.Visible = true;
            this.col_UnitOfMeasureCode.VisibleIndex = 0;
            this.col_UnitOfMeasureCode.Width = 84;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.Caption = "Tên diễn giải đơn vị tính";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 1;
            this.col_UnitOfMeasureName.Width = 922;
            // 
            // frmDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.gridControl_Price);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDonViTinh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh sách đơn vị tính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDonViTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Unit_Of_Measure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Price;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Unit_Of_Measure;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
    }
}