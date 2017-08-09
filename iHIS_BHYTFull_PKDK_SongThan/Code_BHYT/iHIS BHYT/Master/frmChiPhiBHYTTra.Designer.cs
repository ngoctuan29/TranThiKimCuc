namespace Ps.Clinic.Master
{
    partial class frmChiPhiBHYTTra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiPhiBHYTTra));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_BHYTPay = new DevExpress.XtraGrid.GridControl();
            this.gridView_BHYTPay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_BHYTUnderPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_BHYTOnPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refObjectCard = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BHYTPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BHYTPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refObjectCard)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_BHYTPay);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(698, 355);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "BHYT Chi trả";
            // 
            // gridControl_BHYTPay
            // 
            this.gridControl_BHYTPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BHYTPay.Location = new System.Drawing.Point(2, 23);
            this.gridControl_BHYTPay.MainView = this.gridView_BHYTPay;
            this.gridControl_BHYTPay.Name = "gridControl_BHYTPay";
            this.gridControl_BHYTPay.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refObjectCard});
            this.gridControl_BHYTPay.Size = new System.Drawing.Size(694, 330);
            this.gridControl_BHYTPay.TabIndex = 0;
            this.gridControl_BHYTPay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_BHYTPay});
            // 
            // gridView_BHYTPay
            // 
            this.gridView_BHYTPay.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_BHYTPay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_BHYTUnderPrice,
            this.col_BHYTOnPrice});
            this.gridView_BHYTPay.GridControl = this.gridControl_BHYTPay;
            this.gridView_BHYTPay.Name = "gridView_BHYTPay";
            this.gridView_BHYTPay.NewItemRowText = "Cập nhật chi phí BHYT trả";
            this.gridView_BHYTPay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_BHYTPay.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_BHYTPay.OptionsView.ShowFooter = true;
            this.gridView_BHYTPay.OptionsView.ShowGroupPanel = false;
            this.gridView_BHYTPay.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_BHYTPay_InvalidRowException);
            this.gridView_BHYTPay.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_BHYTPay_ValidateRow);
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "ID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.Width = 212;
            // 
            // col_BHYTUnderPrice
            // 
            this.col_BHYTUnderPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_BHYTUnderPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTUnderPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_BHYTUnderPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTUnderPrice.Caption = "Mức bắt đầu chi trả";
            this.col_BHYTUnderPrice.DisplayFormat.FormatString = "#,#";
            this.col_BHYTUnderPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_BHYTUnderPrice.FieldName = "BHYTUnderPrice";
            this.col_BHYTUnderPrice.Name = "col_BHYTUnderPrice";
            this.col_BHYTUnderPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_BHYTUnderPrice.Visible = true;
            this.col_BHYTUnderPrice.VisibleIndex = 0;
            this.col_BHYTUnderPrice.Width = 418;
            // 
            // col_BHYTOnPrice
            // 
            this.col_BHYTOnPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_BHYTOnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTOnPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_BHYTOnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_BHYTOnPrice.Caption = "Mức cao nhất";
            this.col_BHYTOnPrice.DisplayFormat.FormatString = "#,#";
            this.col_BHYTOnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_BHYTOnPrice.FieldName = "BHYTOnPrice";
            this.col_BHYTOnPrice.Name = "col_BHYTOnPrice";
            this.col_BHYTOnPrice.Visible = true;
            this.col_BHYTOnPrice.VisibleIndex = 1;
            this.col_BHYTOnPrice.Width = 483;
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
            // frmChiPhiBHYTTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 355);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChiPhiBHYTTra";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tỉ lệ hưởng BHYT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiPhiBHYTTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BHYTPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BHYTPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refObjectCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_BHYTPay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_BHYTPay;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refObjectCard;
        private DevExpress.XtraGrid.Columns.GridColumn col_BHYTUnderPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_BHYTOnPrice;
    }
}