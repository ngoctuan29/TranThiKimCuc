namespace Ps.Clinic.Master
{
    partial class frmTiLeBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiLeBHYT));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Object = new DevExpress.XtraGrid.GridControl();
            this.gridView_Object = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RateCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RateTrue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RateFalse = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.grMain.Size = new System.Drawing.Size(733, 337);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Tỉ lệ hưởng thẻ BHYT";
            // 
            // gridControl_Object
            // 
            this.gridControl_Object.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Object.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Object.MainView = this.gridView_Object;
            this.gridControl_Object.Name = "gridControl_Object";
            this.gridControl_Object.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refObjectCard});
            this.gridControl_Object.Size = new System.Drawing.Size(729, 312);
            this.gridControl_Object.TabIndex = 0;
            this.gridControl_Object.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Object});
            this.gridControl_Object.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Object_ProcessGridKey);
            // 
            // gridView_Object
            // 
            this.gridView_Object.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Object.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Object.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Object.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Object.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Object.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RateCard,
            this.col_RateTrue,
            this.col_RateFalse});
            this.gridView_Object.GridControl = this.gridControl_Object;
            this.gridView_Object.Name = "gridView_Object";
            this.gridView_Object.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Tỷ lệ thẻ BHYT).";
            this.gridView_Object.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Object.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Object.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Object.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Object.OptionsView.ShowFooter = true;
            this.gridView_Object.OptionsView.ShowGroupPanel = false;
            this.gridView_Object.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Object_InvalidRowException);
            this.gridView_Object.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Object_ValidateRow);
            // 
            // col_RateCard
            // 
            this.col_RateCard.Caption = "Mã thẻ";
            this.col_RateCard.FieldName = "RateCard";
            this.col_RateCard.Name = "col_RateCard";
            this.col_RateCard.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_RateCard.Visible = true;
            this.col_RateCard.VisibleIndex = 0;
            this.col_RateCard.Width = 608;
            // 
            // col_RateTrue
            // 
            this.col_RateTrue.AppearanceCell.Options.UseTextOptions = true;
            this.col_RateTrue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_RateTrue.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RateTrue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_RateTrue.Caption = "Đúng tuyến (% BHYT chi trả)";
            this.col_RateTrue.DisplayFormat.FormatString = "#,#";
            this.col_RateTrue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_RateTrue.FieldName = "RateTrue";
            this.col_RateTrue.Name = "col_RateTrue";
            this.col_RateTrue.Visible = true;
            this.col_RateTrue.VisibleIndex = 1;
            this.col_RateTrue.Width = 211;
            // 
            // col_RateFalse
            // 
            this.col_RateFalse.AppearanceCell.Options.UseTextOptions = true;
            this.col_RateFalse.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_RateFalse.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RateFalse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_RateFalse.Caption = "Trái tuyến (% BHYT chi trả)";
            this.col_RateFalse.DisplayFormat.FormatString = "#,#";
            this.col_RateFalse.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_RateFalse.FieldName = "RateFalse";
            this.col_RateFalse.Name = "col_RateFalse";
            this.col_RateFalse.Visible = true;
            this.col_RateFalse.VisibleIndex = 2;
            this.col_RateFalse.Width = 185;
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
            // frmTiLeBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 337);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTiLeBHYT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tỉ lệ hưởng BHYT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTiLeBHYT_Load);
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
        private DevExpress.XtraGrid.Columns.GridColumn col_RateCard;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refObjectCard;
        private DevExpress.XtraGrid.Columns.GridColumn col_RateTrue;
        private DevExpress.XtraGrid.Columns.GridColumn col_RateFalse;
    }
}