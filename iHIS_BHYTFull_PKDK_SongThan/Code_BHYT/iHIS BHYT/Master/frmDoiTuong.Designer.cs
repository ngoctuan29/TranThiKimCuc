namespace Ps.Clinic.Master
{
    partial class frmDoiTuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiTuong));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Object = new DevExpress.XtraGrid.GridControl();
            this.gridView_Object = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ObjectCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refObjectCard = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Object)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Object)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refObjectCard)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Object);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(921, 482);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục đối tượng bệnh nhân";
            // 
            // gridControl_Object
            // 
            this.gridControl_Object.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Object.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Object.MainView = this.gridView_Object;
            this.gridControl_Object.Name = "gridControl_Object";
            this.gridControl_Object.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refObjectCard});
            this.gridControl_Object.Size = new System.Drawing.Size(917, 457);
            this.gridControl_Object.TabIndex = 0;
            this.gridControl_Object.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Object});
            this.gridControl_Object.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Object_ProcessGridKey);
            // 
            // gridView_Object
            // 
            this.gridView_Object.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Object.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ObjectCode,
            this.col_ObjectName,
            this.col_ObjectCard});
            this.gridView_Object.GridControl = this.gridControl_Object;
            this.gridView_Object.Name = "gridView_Object";
            this.gridView_Object.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục đối tượng.";
            this.gridView_Object.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Object.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Object.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Object.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Object.OptionsView.ShowFooter = true;
            this.gridView_Object.OptionsView.ShowGroupPanel = false;
            this.gridView_Object.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Object_InvalidRowException);
            this.gridView_Object.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Object_ValidateRow);
            // 
            // col_ObjectCode
            // 
            this.col_ObjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_ObjectCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ObjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ObjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ObjectCode.Caption = "Mã đối tượng";
            this.col_ObjectCode.FieldName = "ObjectCode";
            this.col_ObjectCode.Name = "col_ObjectCode";
            this.col_ObjectCode.OptionsColumn.AllowEdit = false;
            this.col_ObjectCode.OptionsColumn.ReadOnly = true;
            this.col_ObjectCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ObjectCode", "Count: {0:#,#}")});
            this.col_ObjectCode.Visible = true;
            this.col_ObjectCode.VisibleIndex = 0;
            this.col_ObjectCode.Width = 98;
            // 
            // col_ObjectName
            // 
            this.col_ObjectName.Caption = "Tên diễn giải đối tượng";
            this.col_ObjectName.FieldName = "ObjectName";
            this.col_ObjectName.Name = "col_ObjectName";
            this.col_ObjectName.Visible = true;
            this.col_ObjectName.VisibleIndex = 1;
            this.col_ObjectName.Width = 686;
            // 
            // col_ObjectCard
            // 
            this.col_ObjectCard.AppearanceCell.Options.UseTextOptions = true;
            this.col_ObjectCard.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ObjectCard.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ObjectCard.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ObjectCard.Caption = "Nhập thẻ BHYT";
            this.col_ObjectCard.ColumnEdit = this.refObjectCard;
            this.col_ObjectCard.FieldName = "ObjectCard";
            this.col_ObjectCard.Name = "col_ObjectCard";
            this.col_ObjectCard.Visible = true;
            this.col_ObjectCard.VisibleIndex = 2;
            this.col_ObjectCard.Width = 117;
            // 
            // refObjectCard
            // 
            this.refObjectCard.AutoHeight = false;
            this.refObjectCard.DisplayValueChecked = "1";
            this.refObjectCard.DisplayValueGrayed = "0";
            this.refObjectCard.DisplayValueUnchecked = "0";
            this.refObjectCard.Name = "refObjectCard";
            this.refObjectCard.ValueChecked = 1;
            this.refObjectCard.ValueGrayed = 0;
            this.refObjectCard.ValueUnchecked = 0;
            // 
            // frmDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 482);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoiTuong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Object)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Object)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refObjectCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Object;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Object;
        private DevExpress.XtraGrid.Columns.GridColumn col_ObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ObjectCard;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refObjectCard;
    }
}