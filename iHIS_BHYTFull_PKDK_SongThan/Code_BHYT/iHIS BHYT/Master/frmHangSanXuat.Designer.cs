namespace Ps.Clinic.Master
{
    partial class frmHangSanXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangSanXuat));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Producer = new DevExpress.XtraGrid.GridControl();
            this.gridView_Producer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ProducerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProducerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refHide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Producer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Producer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refHide)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Producer);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(625, 348);
            this.grMain.TabIndex = 1;
            this.grMain.Text = "Danh sách hãng sản xuất";
            // 
            // gridControl_Producer
            // 
            this.gridControl_Producer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Producer.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Producer.MainView = this.gridView_Producer;
            this.gridControl_Producer.Name = "gridControl_Producer";
            this.gridControl_Producer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refHide});
            this.gridControl_Producer.Size = new System.Drawing.Size(621, 323);
            this.gridControl_Producer.TabIndex = 0;
            this.gridControl_Producer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Producer});
            this.gridControl_Producer.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Producer_ProcessGridKey);
            // 
            // gridView_Producer
            // 
            this.gridView_Producer.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Producer.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Producer.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Producer.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Producer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Producer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ProducerCode,
            this.col_ProducerName,
            this.col_Hide});
            this.gridView_Producer.GridControl = this.gridControl_Producer;
            this.gridView_Producer.Name = "gridView_Producer";
            this.gridView_Producer.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục hãng sản xuất.";
            this.gridView_Producer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Producer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Producer.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Producer.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Producer.OptionsView.ShowFooter = true;
            this.gridView_Producer.OptionsView.ShowGroupPanel = false;
            this.gridView_Producer.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Producer_InvalidRowException);
            this.gridView_Producer.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Producer_ValidateRow);
            // 
            // col_ProducerCode
            // 
            this.col_ProducerCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_ProducerCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProducerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProducerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProducerCode.Caption = "Mã Hãng";
            this.col_ProducerCode.FieldName = "ProducerCode";
            this.col_ProducerCode.Name = "col_ProducerCode";
            this.col_ProducerCode.OptionsColumn.AllowEdit = false;
            this.col_ProducerCode.OptionsColumn.ReadOnly = true;
            this.col_ProducerCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProducerCode", "Count: {0:#,#}")});
            this.col_ProducerCode.Visible = true;
            this.col_ProducerCode.VisibleIndex = 0;
            this.col_ProducerCode.Width = 99;
            // 
            // col_ProducerName
            // 
            this.col_ProducerName.Caption = "Tên Hãng";
            this.col_ProducerName.FieldName = "ProducerName";
            this.col_ProducerName.Name = "col_ProducerName";
            this.col_ProducerName.Visible = true;
            this.col_ProducerName.VisibleIndex = 1;
            this.col_ProducerName.Width = 830;
            // 
            // col_Hide
            // 
            this.col_Hide.AppearanceCell.Options.UseTextOptions = true;
            this.col_Hide.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.Caption = "Khóa";
            this.col_Hide.ColumnEdit = this.refHide;
            this.col_Hide.FieldName = "Hide";
            this.col_Hide.Name = "col_Hide";
            this.col_Hide.Visible = true;
            this.col_Hide.VisibleIndex = 2;
            this.col_Hide.Width = 43;
            // 
            // refHide
            // 
            this.refHide.AutoHeight = false;
            this.refHide.DisplayValueChecked = "1";
            this.refHide.DisplayValueGrayed = "0";
            this.refHide.DisplayValueUnchecked = "0";
            this.refHide.Name = "refHide";
            this.refHide.ValueChecked = 1;
            this.refHide.ValueGrayed = 0;
            this.refHide.ValueUnchecked = 0;
            // 
            // frmHangSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 348);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHangSanXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHangSanXuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHangSanXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Producer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Producer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refHide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Producer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Producer;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProducerCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProducerName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refHide;

    }
}