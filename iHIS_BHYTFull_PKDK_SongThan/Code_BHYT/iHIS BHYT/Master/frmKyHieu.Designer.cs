namespace Ps.Clinic.Master
{
    partial class frmKyHieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKyHieu));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Symbol = new DevExpress.XtraGrid.GridControl();
            this.gridView_Symbol = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Symbol_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Symbol_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Symbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Symbol)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Symbol);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(625, 340);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Khai báo ký hiệu";
            // 
            // gridControl_Symbol
            // 
            this.gridControl_Symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Symbol.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Symbol.MainView = this.gridView_Symbol;
            this.gridControl_Symbol.Name = "gridControl_Symbol";
            this.gridControl_Symbol.Size = new System.Drawing.Size(621, 315);
            this.gridControl_Symbol.TabIndex = 0;
            this.gridControl_Symbol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Symbol});
            // 
            // gridView_Symbol
            // 
            this.gridView_Symbol.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Symbol.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Symbol_Code,
            this.col_Symbol_Name});
            this.gridView_Symbol.GridControl = this.gridControl_Symbol;
            this.gridView_Symbol.Name = "gridView_Symbol";
            this.gridView_Symbol.NewItemRowText = "Nhập thêm mới ký hiệu!";
            this.gridView_Symbol.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Symbol.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Symbol.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Symbol.OptionsView.ShowFooter = true;
            this.gridView_Symbol.OptionsView.ShowGroupPanel = false;
            this.gridView_Symbol.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_Symbol_BeforeLeaveRow);
            // 
            // col_Symbol_Code
            // 
            this.col_Symbol_Code.AppearanceCell.Options.UseTextOptions = true;
            this.col_Symbol_Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Symbol_Code.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Symbol_Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Symbol_Code.Caption = "Mẫu ký hiệu";
            this.col_Symbol_Code.FieldName = "Symbol_Code";
            this.col_Symbol_Code.Name = "col_Symbol_Code";
            this.col_Symbol_Code.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Symbol_Code", "Count: {0:#,#}")});
            this.col_Symbol_Code.Visible = true;
            this.col_Symbol_Code.VisibleIndex = 0;
            this.col_Symbol_Code.Width = 137;
            // 
            // col_Symbol_Name
            // 
            this.col_Symbol_Name.Caption = "Nội dung - ghi chú";
            this.col_Symbol_Name.FieldName = "Symbol_Name";
            this.col_Symbol_Name.Name = "col_Symbol_Name";
            this.col_Symbol_Name.Visible = true;
            this.col_Symbol_Name.VisibleIndex = 1;
            this.col_Symbol_Name.Width = 851;
            // 
            // frmKyHieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 340);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKyHieu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bảng mô tả ký hiệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKyHieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Symbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Symbol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Symbol;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Symbol;
        private DevExpress.XtraGrid.Columns.GridColumn col_Symbol_Code;
        private DevExpress.XtraGrid.Columns.GridColumn col_Symbol_Name;
    }
}