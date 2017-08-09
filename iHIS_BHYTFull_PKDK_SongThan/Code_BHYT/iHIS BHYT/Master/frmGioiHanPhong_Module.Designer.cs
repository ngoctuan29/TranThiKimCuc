namespace Ps.Clinic.Master
{
    partial class frmGioiHanPhong_Module
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGioiHanPhong_Module));
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Service = new DevExpress.XtraGrid.GridControl();
            this.gridView_Service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Ser_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ser_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ser_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Ser_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_Ser_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Menu = new DevExpress.XtraGrid.GridControl();
            this.gridView_Menu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceMenuID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceMenuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkDepartment = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Ser_Chon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grList)).BeginInit();
            this.grList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).BeginInit();
            this.pnTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.butSave);
            this.grDetails.Controls.Add(this.gridControl_Service);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(573, 595);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "Dịch vụ";
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = global::Ps.Clinic.Properties.Resources.Ribbon_Save_16x16;
            this.butSave.Location = new System.Drawing.Point(491, 37);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(77, 22);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Cập nhật";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // gridControl_Service
            // 
            this.gridControl_Service.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Service.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Service.MainView = this.gridView_Service;
            this.gridControl_Service.Name = "gridControl_Service";
            this.gridControl_Service.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_Ser_Chon});
            this.gridControl_Service.Size = new System.Drawing.Size(569, 570);
            this.gridControl_Service.TabIndex = 13;
            this.gridControl_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Service});
            // 
            // gridView_Service
            // 
            this.gridView_Service.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Service.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Ser_ServiceCode,
            this.col_Ser_ServiceName,
            this.col_Ser_ServiceCategoryName,
            this.col_Chon,
            this.col_Ser_ServiceGroupName});
            this.gridView_Service.GridControl = this.gridControl_Service;
            this.gridView_Service.Name = "gridView_Service";
            this.gridView_Service.NewItemRowText = "Khai báo chi tiết gói";
            this.gridView_Service.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Service.OptionsFind.AlwaysVisible = true;
            this.gridView_Service.OptionsFind.FindFilterColumns = "ServiceName";
            this.gridView_Service.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView_Service.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView_Service.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView_Service.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Service.OptionsView.ShowFooter = true;
            this.gridView_Service.OptionsView.ShowIndicator = false;
            // 
            // col_Ser_ServiceCode
            // 
            this.col_Ser_ServiceCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ser_ServiceCode.AppearanceHeader.Options.UseFont = true;
            this.col_Ser_ServiceCode.Caption = "Mã";
            this.col_Ser_ServiceCode.FieldName = "ServiceCode";
            this.col_Ser_ServiceCode.Name = "col_Ser_ServiceCode";
            this.col_Ser_ServiceCode.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceCode.Visible = true;
            this.col_Ser_ServiceCode.VisibleIndex = 0;
            this.col_Ser_ServiceCode.Width = 68;
            // 
            // col_Ser_ServiceName
            // 
            this.col_Ser_ServiceName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ser_ServiceName.AppearanceHeader.Options.UseFont = true;
            this.col_Ser_ServiceName.Caption = "Tên dịch vụ";
            this.col_Ser_ServiceName.FieldName = "ServiceName";
            this.col_Ser_ServiceName.Name = "col_Ser_ServiceName";
            this.col_Ser_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceName.Visible = true;
            this.col_Ser_ServiceName.VisibleIndex = 1;
            this.col_Ser_ServiceName.Width = 224;
            // 
            // col_Ser_ServiceCategoryName
            // 
            this.col_Ser_ServiceCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ser_ServiceCategoryName.AppearanceHeader.Options.UseFont = true;
            this.col_Ser_ServiceCategoryName.Caption = "Loại dịch vụ";
            this.col_Ser_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_Ser_ServiceCategoryName.Name = "col_Ser_ServiceCategoryName";
            this.col_Ser_ServiceCategoryName.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceCategoryName.Visible = true;
            this.col_Ser_ServiceCategoryName.VisibleIndex = 2;
            this.col_Ser_ServiceCategoryName.Width = 107;
            // 
            // col_Chon
            // 
            this.col_Chon.AppearanceCell.Options.UseTextOptions = true;
            this.col_Chon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Chon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Chon.AppearanceHeader.Options.UseFont = true;
            this.col_Chon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Chon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Chon.Caption = "Chọn";
            this.col_Chon.ColumnEdit = this.rep_Ser_Chon;
            this.col_Chon.FieldName = "Chon";
            this.col_Chon.Name = "col_Chon";
            this.col_Chon.OptionsColumn.AllowMove = false;
            this.col_Chon.Visible = true;
            this.col_Chon.VisibleIndex = 4;
            this.col_Chon.Width = 53;
            // 
            // rep_Ser_Chon
            // 
            this.rep_Ser_Chon.AutoHeight = false;
            this.rep_Ser_Chon.DisplayValueChecked = "1";
            this.rep_Ser_Chon.DisplayValueGrayed = "0";
            this.rep_Ser_Chon.DisplayValueUnchecked = "0";
            this.rep_Ser_Chon.Name = "rep_Ser_Chon";
            this.rep_Ser_Chon.ValueChecked = 1;
            this.rep_Ser_Chon.ValueGrayed = 0;
            this.rep_Ser_Chon.ValueUnchecked = 0;
            // 
            // col_Ser_ServiceGroupName
            // 
            this.col_Ser_ServiceGroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ser_ServiceGroupName.AppearanceHeader.Options.UseFont = true;
            this.col_Ser_ServiceGroupName.Caption = "Nhóm";
            this.col_Ser_ServiceGroupName.FieldName = "ServiceGroupName";
            this.col_Ser_ServiceGroupName.Name = "col_Ser_ServiceGroupName";
            this.col_Ser_ServiceGroupName.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceGroupName.Visible = true;
            this.col_Ser_ServiceGroupName.VisibleIndex = 3;
            // 
            // grList
            // 
            this.grList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grList.AppearanceCaption.Options.UseFont = true;
            this.grList.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grList.CaptionImage")));
            this.grList.Controls.Add(this.gridControl_Menu);
            this.grList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grList.Location = new System.Drawing.Point(0, 0);
            this.grList.Name = "grList";
            this.grList.Size = new System.Drawing.Size(362, 378);
            this.grList.TabIndex = 0;
            this.grList.Text = "Danh mục menu";
            // 
            // gridControl_Menu
            // 
            this.gridControl_Menu.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Menu.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Menu.MainView = this.gridView_Menu;
            this.gridControl_Menu.Name = "gridControl_Menu";
            this.gridControl_Menu.Size = new System.Drawing.Size(358, 353);
            this.gridControl_Menu.TabIndex = 0;
            this.gridControl_Menu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Menu});
            // 
            // gridView_Menu
            // 
            this.gridView_Menu.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Menu.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Menu.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Menu.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Menu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServiceMenuID,
            this.col_ServiceMenuName});
            this.gridView_Menu.GridControl = this.gridControl_Menu;
            this.gridView_Menu.Name = "gridView_Menu";
            this.gridView_Menu.NewItemRowText = "...";
            this.gridView_Menu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Menu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Menu.OptionsFind.FindFilterColumns = "ServicePackageName";
            this.gridView_Menu.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Menu.OptionsView.ShowFooter = true;
            this.gridView_Menu.OptionsView.ShowGroupPanel = false;
            this.gridView_Menu.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Menu.Click += new System.EventHandler(this.gridView_Menu_Click);
            // 
            // col_ServiceMenuID
            // 
            this.col_ServiceMenuID.Caption = "ID";
            this.col_ServiceMenuID.FieldName = "ServiceMenuID";
            this.col_ServiceMenuID.Name = "col_ServiceMenuID";
            this.col_ServiceMenuID.OptionsColumn.AllowEdit = false;
            this.col_ServiceMenuID.OptionsColumn.AllowFocus = false;
            this.col_ServiceMenuID.OptionsColumn.ReadOnly = true;
            this.col_ServiceMenuID.Visible = true;
            this.col_ServiceMenuID.VisibleIndex = 0;
            this.col_ServiceMenuID.Width = 60;
            // 
            // col_ServiceMenuName
            // 
            this.col_ServiceMenuName.Caption = "Menu";
            this.col_ServiceMenuName.FieldName = "ServiceMenuName";
            this.col_ServiceMenuName.Name = "col_ServiceMenuName";
            this.col_ServiceMenuName.OptionsColumn.AllowEdit = false;
            this.col_ServiceMenuName.OptionsColumn.AllowFocus = false;
            this.col_ServiceMenuName.OptionsColumn.ReadOnly = true;
            this.col_ServiceMenuName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_ServiceMenuName.Visible = true;
            this.col_ServiceMenuName.VisibleIndex = 1;
            this.col_ServiceMenuName.Width = 282;
            // 
            // chkDepartment
            // 
            this.chkDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDepartment.Location = new System.Drawing.Point(2, 2);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(358, 213);
            this.chkDepartment.TabIndex = 1;
            // 
            // pnTemplate
            // 
            this.pnTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnTemplate.Name = "pnTemplate";
            this.pnTemplate.Panel1.Controls.Add(this.panelControl1);
            this.pnTemplate.Panel1.Controls.Add(this.grList);
            this.pnTemplate.Panel1.Text = "Panel1";
            this.pnTemplate.Panel2.Controls.Add(this.grDetails);
            this.pnTemplate.Panel2.Text = "Panel2";
            this.pnTemplate.Size = new System.Drawing.Size(940, 595);
            this.pnTemplate.SplitterPosition = 362;
            this.pnTemplate.TabIndex = 5;
            this.pnTemplate.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkDepartment);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 378);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(362, 217);
            this.panelControl1.TabIndex = 1;
            // 
            // frmGioiHanPhong_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 595);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGioiHanPhong_Module";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGioiHanPhong_Module_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Ser_Chon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grList)).EndInit();
            this.grList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraEditors.GroupControl grList;
        private DevExpress.XtraGrid.GridControl gridControl_Menu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Menu;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceMenuID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceMenuName;
        private DevExpress.XtraEditors.SplitContainerControl pnTemplate;
        private DevExpress.XtraGrid.GridControl gridControl_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Service;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_Ser_Chon;
        private DevExpress.XtraEditors.CheckedListBoxControl chkDepartment;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceGroupName;

    }
}