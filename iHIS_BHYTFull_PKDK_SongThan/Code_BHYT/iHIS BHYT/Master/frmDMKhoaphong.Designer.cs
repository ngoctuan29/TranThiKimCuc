namespace Ps.Clinic.Master
{
    partial class frmDMKhoaphong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMKhoaphong));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_Depart = new DevExpress.XtraGrid.GridControl();
            this.gridView_Depart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_List_Depart_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ServiceGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_List_Depart = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_List_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckEdit_List_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_List_IdBv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_List_LoaiKhoa = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_List_KBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_List_departBHYT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repLoaiKhoa = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkRepository = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkKhoa = new System.Windows.Forms.CheckBox();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Depart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Depart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_List_Depart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_List_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_List_LoaiKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_List_departBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRepository)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.btnRefesh);
            this.grMain.Controls.Add(this.chkKhoa);
            this.grMain.Controls.Add(this.splitContainerControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(719, 452);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục khoa - Phòng khám";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 23);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl_Depart);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(715, 427);
            this.splitContainerControl1.SplitterPosition = 266;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_Depart
            // 
            this.gridControl_Depart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Depart.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Depart.MainView = this.gridView_Depart;
            this.gridControl_Depart.Name = "gridControl_Depart";
            this.gridControl_Depart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckEdit_List_Hide,
            this.rep_List_Depart,
            this.repLoaiKhoa,
            this.rep_List_departBHYT,
            this.rep_List_LoaiKhoa});
            this.gridControl_Depart.Size = new System.Drawing.Size(715, 266);
            this.gridControl_Depart.TabIndex = 3;
            this.gridControl_Depart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Depart});
            this.gridControl_Depart.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Depart_ProcessGridKey);
            // 
            // gridView_Depart
            // 
            this.gridView_Depart.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Depart.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Depart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Depart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_List_Depart_RowID,
            this.col_List_DepartmentCode,
            this.col_List_DepartmentName,
            this.col_List_ServiceGroupCode,
            this.col_List_Hide,
            this.col_List_IdBv,
            this.col_List_KBHYT});
            this.gridView_Depart.GridControl = this.gridControl_Depart;
            this.gridView_Depart.Name = "gridView_Depart";
            this.gridView_Depart.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục khoa - phòng khám.";
            this.gridView_Depart.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Depart.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Depart.OptionsFind.FindFilterColumns = "Item_Name";
            this.gridView_Depart.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Depart.OptionsView.ShowFooter = true;
            this.gridView_Depart.OptionsView.ShowGroupPanel = false;
            this.gridView_Depart.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_Depart_RowClick);
            // 
            // col_List_Depart_RowID
            // 
            this.col_List_Depart_RowID.Caption = "RowID";
            this.col_List_Depart_RowID.Name = "col_List_Depart_RowID";
            // 
            // col_List_DepartmentCode
            // 
            this.col_List_DepartmentCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_DepartmentCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_DepartmentCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_DepartmentCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_DepartmentCode.Caption = "Mã KP";
            this.col_List_DepartmentCode.FieldName = "DepartmentCode";
            this.col_List_DepartmentCode.Name = "col_List_DepartmentCode";
            this.col_List_DepartmentCode.OptionsColumn.AllowEdit = false;
            this.col_List_DepartmentCode.OptionsColumn.AllowFocus = false;
            this.col_List_DepartmentCode.OptionsColumn.ReadOnly = true;
            this.col_List_DepartmentCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DepartmentCode", "Count: {0:#,#}")});
            this.col_List_DepartmentCode.Visible = true;
            this.col_List_DepartmentCode.VisibleIndex = 0;
            this.col_List_DepartmentCode.Width = 68;
            // 
            // col_List_DepartmentName
            // 
            this.col_List_DepartmentName.Caption = "Tên khoa phòng";
            this.col_List_DepartmentName.FieldName = "DepartmentName";
            this.col_List_DepartmentName.Name = "col_List_DepartmentName";
            this.col_List_DepartmentName.Visible = true;
            this.col_List_DepartmentName.VisibleIndex = 1;
            this.col_List_DepartmentName.Width = 353;
            // 
            // col_List_ServiceGroupCode
            // 
            this.col_List_ServiceGroupCode.Caption = "Nhóm dịch vụ";
            this.col_List_ServiceGroupCode.ColumnEdit = this.rep_List_Depart;
            this.col_List_ServiceGroupCode.FieldName = "ServiceGroupCode";
            this.col_List_ServiceGroupCode.Name = "col_List_ServiceGroupCode";
            this.col_List_ServiceGroupCode.Visible = true;
            this.col_List_ServiceGroupCode.VisibleIndex = 2;
            this.col_List_ServiceGroupCode.Width = 222;
            // 
            // rep_List_Depart
            // 
            this.rep_List_Depart.AutoHeight = false;
            this.rep_List_Depart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_List_Depart.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupName", "Tên nhóm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupCode", "Mã nhóm")});
            this.rep_List_Depart.Name = "rep_List_Depart";
            this.rep_List_Depart.NullText = "...";
            // 
            // col_List_Hide
            // 
            this.col_List_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_Hide.Caption = "Khóa";
            this.col_List_Hide.ColumnEdit = this.CheckEdit_List_Hide;
            this.col_List_Hide.FieldName = "Hide";
            this.col_List_Hide.Name = "col_List_Hide";
            this.col_List_Hide.Visible = true;
            this.col_List_Hide.VisibleIndex = 5;
            this.col_List_Hide.Width = 66;
            // 
            // CheckEdit_List_Hide
            // 
            this.CheckEdit_List_Hide.AutoHeight = false;
            this.CheckEdit_List_Hide.DisplayValueChecked = "1";
            this.CheckEdit_List_Hide.DisplayValueGrayed = "0";
            this.CheckEdit_List_Hide.DisplayValueUnchecked = "0";
            this.CheckEdit_List_Hide.Name = "CheckEdit_List_Hide";
            this.CheckEdit_List_Hide.ValueChecked = 1;
            this.CheckEdit_List_Hide.ValueGrayed = 0;
            this.CheckEdit_List_Hide.ValueUnchecked = 0;
            // 
            // col_List_IdBv
            // 
            this.col_List_IdBv.Caption = "Loại khoa";
            this.col_List_IdBv.ColumnEdit = this.rep_List_LoaiKhoa;
            this.col_List_IdBv.FieldName = "IdBv";
            this.col_List_IdBv.Name = "col_List_IdBv";
            this.col_List_IdBv.Visible = true;
            this.col_List_IdBv.VisibleIndex = 4;
            // 
            // rep_List_LoaiKhoa
            // 
            this.rep_List_LoaiKhoa.AutoHeight = false;
            this.rep_List_LoaiKhoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_List_LoaiKhoa.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoai", "Loại khoa")});
            this.rep_List_LoaiKhoa.Name = "rep_List_LoaiKhoa";
            this.rep_List_LoaiKhoa.NullText = "";
            // 
            // col_List_KBHYT
            // 
            this.col_List_KBHYT.Caption = "Mã khoa BHYT";
            this.col_List_KBHYT.ColumnEdit = this.rep_List_departBHYT;
            this.col_List_KBHYT.FieldName = "KBHYT";
            this.col_List_KBHYT.Name = "col_List_KBHYT";
            this.col_List_KBHYT.Visible = true;
            this.col_List_KBHYT.VisibleIndex = 3;
            this.col_List_KBHYT.Width = 91;
            // 
            // rep_List_departBHYT
            // 
            this.rep_List_departBHYT.AutoHeight = false;
            this.rep_List_departBHYT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_List_departBHYT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoa", "Tên khoa")});
            this.rep_List_departBHYT.Name = "rep_List_departBHYT";
            this.rep_List_departBHYT.NullText = "";
            // 
            // repLoaiKhoa
            // 
            this.repLoaiKhoa.AutoHeight = false;
            this.repLoaiKhoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLoaiKhoa.Name = "repLoaiKhoa";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.chkRepository);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(715, 156);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Kho dược";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Controls.Add(this.butSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(609, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(104, 131);
            this.panelControl1.TabIndex = 2;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(4, 36);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(97, 28);
            this.butPrint.TabIndex = 8;
            this.butPrint.Text = "In Khoa Phòng";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butSave
            // 
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = global::Ps.Clinic.Properties.Resources.Ribbon_Save_16x16;
            this.butSave.Location = new System.Drawing.Point(4, 8);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(97, 27);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // chkRepository
            // 
            this.chkRepository.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRepository.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkRepository.Location = new System.Drawing.Point(0, 21);
            this.chkRepository.Name = "chkRepository";
            this.chkRepository.Size = new System.Drawing.Size(607, 135);
            this.chkRepository.TabIndex = 0;
            // 
            // chkKhoa
            // 
            this.chkKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKhoa.AutoSize = true;
            this.chkKhoa.Location = new System.Drawing.Point(621, 2);
            this.chkKhoa.Name = "chkKhoa";
            this.chkKhoa.Size = new System.Drawing.Size(66, 17);
            this.chkKhoa.TabIndex = 3;
            this.chkKhoa.Text = "DS Khoá";
            this.chkKhoa.UseVisualStyleBackColor = true;
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefesh.Location = new System.Drawing.Point(690, 2);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(21, 17);
            this.btnRefesh.TabIndex = 4;
            this.btnRefesh.Text = "btnRefesh";
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // frmDMKhoaphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 452);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMKhoaphong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMKhoaphong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Depart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Depart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_List_Depart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_List_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_List_LoaiKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_List_departBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkRepository)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkRepository;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Depart;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Depart;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CheckEdit_List_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_Depart_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ServiceGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_List_Depart;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_IdBv;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_KBHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repLoaiKhoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_List_departBHYT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_List_LoaiKhoa;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private System.Windows.Forms.CheckBox chkKhoa;
    }
}