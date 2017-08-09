namespace Ps.Clinic.Master
{
    partial class frmDDDonViTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDDDonViTinh));
            this.gridControl_Unit = new DevExpress.XtraGrid.GridControl();
            this.gridView_Unit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_UnitOfRawName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfRawID = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridView_Unit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Unit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_UnitOfRawName,
            this.col_UnitOfRawID});
            this.gridView_Unit.GridControl = this.gridControl_Unit;
            this.gridView_Unit.Name = "gridView_Unit";
            this.gridView_Unit.NewItemRowText = "Thêm mới đơn vị tính nguyên liệu...";
            this.gridView_Unit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Unit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Unit.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Unit.OptionsView.ShowFooter = true;
            this.gridView_Unit.OptionsView.ShowGroupPanel = false;
            this.gridView_Unit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Unit_InvalidRowException);
            this.gridView_Unit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Unit_ValidateRow);
            this.gridView_Unit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Unit_KeyDown);
            // 
            // col_UnitOfRawName
            // 
            this.col_UnitOfRawName.Caption = "Đơn vị tính";
            this.col_UnitOfRawName.FieldName = "UnitOfRawName";
            this.col_UnitOfRawName.Name = "col_UnitOfRawName";
            this.col_UnitOfRawName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UnitValuesCode", "Count: {0:#,#}")});
            this.col_UnitOfRawName.Visible = true;
            this.col_UnitOfRawName.VisibleIndex = 0;
            this.col_UnitOfRawName.Width = 524;
            // 
            // col_UnitOfRawID
            // 
            this.col_UnitOfRawID.Caption = "Mã ID";
            this.col_UnitOfRawID.FieldName = "UnitOfRawID";
            this.col_UnitOfRawID.Name = "col_UnitOfRawID";
            this.col_UnitOfRawID.OptionsColumn.ReadOnly = true;
            this.col_UnitOfRawID.Width = 48;
            // 
            // frmDDDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 341);
            this.Controls.Add(this.gridControl_Unit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDDDonViTinh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục đơn vị đo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDDDonViTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Unit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Unit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Unit;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfRawName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfRawID;
    }
}