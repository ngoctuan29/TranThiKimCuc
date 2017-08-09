namespace Ps.Clinic.Master
{
    partial class frmDMKhoaphongBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMKhoaphongBHYT));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(612, 289);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaKhoa,
            this.col_TenKhoa,
            this.col_STT});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.NewItemRowText = "Khoa phòng theo BHYT";
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaKhoa
            // 
            this.col_MaKhoa.Caption = "Mã";
            this.col_MaKhoa.FieldName = "MaKhoa";
            this.col_MaKhoa.Name = "col_MaKhoa";
            this.col_MaKhoa.OptionsColumn.AllowEdit = false;
            this.col_MaKhoa.OptionsColumn.ReadOnly = true;
            this.col_MaKhoa.Visible = true;
            this.col_MaKhoa.VisibleIndex = 0;
            this.col_MaKhoa.Width = 68;
            // 
            // col_TenKhoa
            // 
            this.col_TenKhoa.Caption = "Tên khoa phòng";
            this.col_TenKhoa.FieldName = "TenKhoa";
            this.col_TenKhoa.Name = "col_TenKhoa";
            this.col_TenKhoa.OptionsColumn.AllowEdit = false;
            this.col_TenKhoa.OptionsColumn.ReadOnly = true;
            this.col_TenKhoa.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaKhoa", "{0:#,#}")});
            this.col_TenKhoa.Visible = true;
            this.col_TenKhoa.VisibleIndex = 1;
            this.col_TenKhoa.Width = 940;
            // 
            // col_STT
            // 
            this.col_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.Caption = "STT";
            this.col_STT.FieldName = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.OptionsColumn.AllowEdit = false;
            this.col_STT.OptionsColumn.ReadOnly = true;
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 2;
            this.col_STT.Width = 72;
            // 
            // frmDMKhoaphongBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 289);
            this.Controls.Add(this.gridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMKhoaphongBHYT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh mục lời dặn bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMKhoaphongBHYT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
    }
}