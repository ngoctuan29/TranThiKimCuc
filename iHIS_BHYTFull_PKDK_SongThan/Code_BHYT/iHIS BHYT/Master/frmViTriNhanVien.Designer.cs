namespace Ps.Clinic.Master
{
    partial class frmViTriNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViTriNhanVien));
            this.gridControl_Position = new DevExpress.XtraGrid.GridControl();
            this.gridView_Position = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PositionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PositionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Position
            // 
            this.gridControl_Position.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Position.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Position.MainView = this.gridView_Position;
            this.gridControl_Position.Name = "gridControl_Position";
            this.gridControl_Position.Size = new System.Drawing.Size(616, 318);
            this.gridControl_Position.TabIndex = 1;
            this.gridControl_Position.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Position});
            this.gridControl_Position.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Position_ProcessGridKey);
            // 
            // gridView_Position
            // 
            this.gridView_Position.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Position.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Position.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Position.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PositionCode,
            this.col_PositionName});
            this.gridView_Position.GridControl = this.gridControl_Position;
            this.gridView_Position.Name = "gridView_Position";
            this.gridView_Position.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Cấp bật nhân viên).";
            this.gridView_Position.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Position.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Position.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Position.OptionsView.ShowFooter = true;
            this.gridView_Position.OptionsView.ShowGroupPanel = false;
            this.gridView_Position.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Position_ValidateRow);
            // 
            // col_PositionCode
            // 
            this.col_PositionCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_PositionCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_PositionCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PositionCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PositionCode.Caption = "Mã Vị Trí";
            this.col_PositionCode.FieldName = "PositionCode";
            this.col_PositionCode.Name = "col_PositionCode";
            this.col_PositionCode.OptionsColumn.AllowEdit = false;
            this.col_PositionCode.OptionsColumn.AllowFocus = false;
            this.col_PositionCode.OptionsColumn.FixedWidth = true;
            this.col_PositionCode.Width = 91;
            // 
            // col_PositionName
            // 
            this.col_PositionName.Caption = "Tên diễn giải";
            this.col_PositionName.FieldName = "PositionName";
            this.col_PositionName.Name = "col_PositionName";
            this.col_PositionName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_PositionName.Visible = true;
            this.col_PositionName.VisibleIndex = 0;
            this.col_PositionName.Width = 481;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Position);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(620, 343);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Danh mục - Cấp bật nhân viên";
            // 
            // frmViTriNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 343);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViTriNhanVien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục nhóm viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmViTriNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Position;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Position;
        private DevExpress.XtraGrid.Columns.GridColumn col_PositionCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PositionName;
        private DevExpress.XtraEditors.GroupControl groupControl1;

    }
}