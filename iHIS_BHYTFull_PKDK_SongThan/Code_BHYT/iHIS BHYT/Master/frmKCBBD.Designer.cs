namespace Ps.Clinic.Master
{
    partial class frmKCBBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKCBBD));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Main = new DevExpress.XtraGrid.GridControl();
            this.gridView_Main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KCBBDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KCBBDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProvincialIDBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchProvincialIDBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchView_ProvincialIDBHYT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.seachView_ProvincialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seachView_ProvincialIDBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ThongTuyenBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refHide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProvincialIDBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_ProvincialIDBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Main);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(673, 365);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh sách nơi đăng ký KCB BĐ";
            // 
            // gridControl_Main
            // 
            this.gridControl_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Main.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Main.MainView = this.gridView_Main;
            this.gridControl_Main.Name = "gridControl_Main";
            this.gridControl_Main.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refHide,
            this.repSearchProvincialIDBHYT,
            this.repositoryItemCheckEdit1});
            this.gridControl_Main.Size = new System.Drawing.Size(669, 340);
            this.gridControl_Main.TabIndex = 0;
            this.gridControl_Main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Main});
            this.gridControl_Main.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Main_ProcessGridKey);
            // 
            // gridView_Main
            // 
            this.gridView_Main.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Main.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Main.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Main.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_KCBBDCode,
            this.col_KCBBDName,
            this.col_ProvincialIDBHYT,
            this.col_ThongTuyenBHYT});
            this.gridView_Main.GridControl = this.gridControl_Main;
            this.gridView_Main.Name = "gridView_Main";
            this.gridView_Main.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục nơi đăng ký KCB ban đầu.";
            this.gridView_Main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Main.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Main.OptionsView.ShowFooter = true;
            this.gridView_Main.OptionsView.ShowGroupPanel = false;
            this.gridView_Main.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Main_InvalidRowException);
            this.gridView_Main.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Main_ValidateRow);
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_RowID.Caption = "Row";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowEdit = false;
            this.col_RowID.OptionsColumn.AllowFocus = false;
            this.col_RowID.OptionsColumn.ReadOnly = true;
            this.col_RowID.Width = 76;
            // 
            // col_KCBBDCode
            // 
            this.col_KCBBDCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_KCBBDCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_KCBBDCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_KCBBDCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_KCBBDCode.Caption = "Mã KCB";
            this.col_KCBBDCode.FieldName = "KCBBDCode";
            this.col_KCBBDCode.Name = "col_KCBBDCode";
            this.col_KCBBDCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "KCBBDCode", "Count: {0:#,#}")});
            this.col_KCBBDCode.Visible = true;
            this.col_KCBBDCode.VisibleIndex = 0;
            this.col_KCBBDCode.Width = 125;
            // 
            // col_KCBBDName
            // 
            this.col_KCBBDName.Caption = "Tên KCB";
            this.col_KCBBDName.FieldName = "KCBBDName";
            this.col_KCBBDName.Name = "col_KCBBDName";
            this.col_KCBBDName.Visible = true;
            this.col_KCBBDName.VisibleIndex = 1;
            this.col_KCBBDName.Width = 625;
            // 
            // col_ProvincialIDBHYT
            // 
            this.col_ProvincialIDBHYT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ProvincialIDBHYT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ProvincialIDBHYT.Caption = "Mã Tỉnh";
            this.col_ProvincialIDBHYT.ColumnEdit = this.repSearchProvincialIDBHYT;
            this.col_ProvincialIDBHYT.FieldName = "ProvincialIDBHYT";
            this.col_ProvincialIDBHYT.Name = "col_ProvincialIDBHYT";
            this.col_ProvincialIDBHYT.Visible = true;
            this.col_ProvincialIDBHYT.VisibleIndex = 2;
            this.col_ProvincialIDBHYT.Width = 242;
            // 
            // repSearchProvincialIDBHYT
            // 
            this.repSearchProvincialIDBHYT.AutoHeight = false;
            this.repSearchProvincialIDBHYT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchProvincialIDBHYT.Name = "repSearchProvincialIDBHYT";
            this.repSearchProvincialIDBHYT.NullText = "";
            this.repSearchProvincialIDBHYT.View = this.repSearchView_ProvincialIDBHYT;
            // 
            // repSearchView_ProvincialIDBHYT
            // 
            this.repSearchView_ProvincialIDBHYT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.seachView_ProvincialName,
            this.seachView_ProvincialIDBHYT});
            this.repSearchView_ProvincialIDBHYT.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchView_ProvincialIDBHYT.Name = "repSearchView_ProvincialIDBHYT";
            this.repSearchView_ProvincialIDBHYT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchView_ProvincialIDBHYT.OptionsView.ShowGroupPanel = false;
            // 
            // seachView_ProvincialName
            // 
            this.seachView_ProvincialName.Caption = "Tỉnh, Thành phố";
            this.seachView_ProvincialName.FieldName = "ProvincialName";
            this.seachView_ProvincialName.Name = "seachView_ProvincialName";
            this.seachView_ProvincialName.Visible = true;
            this.seachView_ProvincialName.VisibleIndex = 0;
            // 
            // seachView_ProvincialIDBHYT
            // 
            this.seachView_ProvincialIDBHYT.Caption = "Mã tỉnh, thành phố";
            this.seachView_ProvincialIDBHYT.FieldName = "ProvincialIDBHYT";
            this.seachView_ProvincialIDBHYT.Name = "seachView_ProvincialIDBHYT";
            this.seachView_ProvincialIDBHYT.Visible = true;
            this.seachView_ProvincialIDBHYT.VisibleIndex = 1;
            // 
            // col_ThongTuyenBHYT
            // 
            this.col_ThongTuyenBHYT.Caption = "Đúng tuyến";
            this.col_ThongTuyenBHYT.ColumnEdit = this.refHide;
            this.col_ThongTuyenBHYT.FieldName = "TT";
            this.col_ThongTuyenBHYT.Name = "col_ThongTuyenBHYT";
            this.col_ThongTuyenBHYT.Visible = true;
            this.col_ThongTuyenBHYT.VisibleIndex = 3;
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
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueGrayed = "0";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueGrayed = false;
            // 
            // frmKCBBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 365);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKCBBD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKCBBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProvincialIDBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_ProvincialIDBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Main;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Main;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_KCBBDCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refHide;
        private DevExpress.XtraGrid.Columns.GridColumn col_KCBBDName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProvincialIDBHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchProvincialIDBHYT;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchView_ProvincialIDBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn seachView_ProvincialName;
        private DevExpress.XtraGrid.Columns.GridColumn seachView_ProvincialIDBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn col_ThongTuyenBHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}