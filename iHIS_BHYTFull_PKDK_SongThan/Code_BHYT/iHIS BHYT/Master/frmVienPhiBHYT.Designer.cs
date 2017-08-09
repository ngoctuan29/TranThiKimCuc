namespace Ps.Clinic.Master
{
    partial class frmVienPhiBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVienPhiBHYT));
            this.gridControl_Service = new DevExpress.XtraGrid.GridControl();
            this.gridView_Service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_MaTuongDuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ma_TT50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ten_TT50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaPT_TT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ma_TT37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ten_TT37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaCKTT50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PhanTuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoQD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NgayKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaTT03_04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaQD5084 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemGridLookUpEdit_Service_Group = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ItemGridLookUpEditView_Service_Group = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_Service_Group_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_Service_Group_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Service_CategoryCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_groupSerive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_categoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_categoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rep_DepartmentCode = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.rep_PatientType = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.ref_UnitOf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.refChk_SampleTransfer = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.col_DonGia_010316 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DonGia_010716 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Service_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_Service_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_CategoryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_DepartmentCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_PatientType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_UnitOf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refChk_SampleTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Service
            // 
            this.gridControl_Service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Service.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Service.MainView = this.gridView_Service;
            this.gridControl_Service.Name = "gridControl_Service";
            this.gridControl_Service.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemGridLookUpEdit_Service_Group,
            this.ItemCheckEdit_Hide,
            this.ref_Service_CategoryCode,
            this.repositoryItemGridLookUpEdit1,
            this.rep_DepartmentCode,
            this.rep_PatientType,
            this.ref_UnitOf,
            this.refChk_SampleTransfer});
            this.gridControl_Service.Size = new System.Drawing.Size(1020, 575);
            this.gridControl_Service.TabIndex = 2;
            this.gridControl_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Service});
            this.gridControl_Service.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Service_ProcessGridKey);
            // 
            // gridView_Service
            // 
            this.gridView_Service.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Service.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Service.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Service.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Service.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Service.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Hide,
            this.col_MaTuongDuong,
            this.col_Ma_TT50,
            this.col_Ten_TT50,
            this.col_MaPT_TT,
            this.col_Ma_TT37,
            this.col_Ten_TT37,
            this.col_STT,
            this.col_MaCKTT50,
            this.col_Note,
            this.col_PhanTuyen,
            this.col_SoQD,
            this.col_NgayKy,
            this.col_MaTT03_04,
            this.col_MaQD5084,
            this.col_DonGia_010316,
            this.col_DonGia_010716});
            this.gridView_Service.GridControl = this.gridControl_Service;
            this.gridView_Service.Name = "gridView_Service";
            this.gridView_Service.NewItemRowText = "Nhập thêm mới dịch vụ BHYT ...";
            this.gridView_Service.OptionsBehavior.ReadOnly = true;
            this.gridView_Service.OptionsFind.AlwaysVisible = true;
            this.gridView_Service.OptionsView.ShowFooter = true;
            this.gridView_Service.OptionsView.ShowGroupPanel = false;
            this.gridView_Service.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_Service_RowStyle);
            this.gridView_Service.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Service_InvalidRowException);
            this.gridView_Service.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Service_ValidateRow);
            this.gridView_Service.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_Service_ValidatingEditor);
            // 
            // col_Hide
            // 
            this.col_Hide.AppearanceCell.Options.UseTextOptions = true;
            this.col_Hide.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Hide.AppearanceHeader.Options.UseFont = true;
            this.col_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.Caption = "Khóa";
            this.col_Hide.ColumnEdit = this.ItemCheckEdit_Hide;
            this.col_Hide.FieldName = "Hide";
            this.col_Hide.Name = "col_Hide";
            this.col_Hide.OptionsColumn.AllowMove = false;
            this.col_Hide.Visible = true;
            this.col_Hide.VisibleIndex = 9;
            this.col_Hide.Width = 37;
            // 
            // ItemCheckEdit_Hide
            // 
            this.ItemCheckEdit_Hide.AutoHeight = false;
            this.ItemCheckEdit_Hide.DisplayValueChecked = "1";
            this.ItemCheckEdit_Hide.DisplayValueGrayed = "0";
            this.ItemCheckEdit_Hide.DisplayValueUnchecked = "0";
            this.ItemCheckEdit_Hide.Name = "ItemCheckEdit_Hide";
            this.ItemCheckEdit_Hide.ValueChecked = 1;
            this.ItemCheckEdit_Hide.ValueGrayed = 0;
            this.ItemCheckEdit_Hide.ValueUnchecked = 0;
            // 
            // col_MaTuongDuong
            // 
            this.col_MaTuongDuong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaTuongDuong.AppearanceHeader.Options.UseFont = true;
            this.col_MaTuongDuong.Caption = "Mã tương đương";
            this.col_MaTuongDuong.FieldName = "MaTuongDuong";
            this.col_MaTuongDuong.Name = "col_MaTuongDuong";
            this.col_MaTuongDuong.OptionsColumn.AllowEdit = false;
            this.col_MaTuongDuong.OptionsColumn.AllowFocus = false;
            this.col_MaTuongDuong.OptionsColumn.ReadOnly = true;
            this.col_MaTuongDuong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaTuongDuong", "{0}")});
            this.col_MaTuongDuong.Visible = true;
            this.col_MaTuongDuong.VisibleIndex = 0;
            this.col_MaTuongDuong.Width = 112;
            // 
            // col_Ma_TT50
            // 
            this.col_Ma_TT50.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ma_TT50.AppearanceHeader.Options.UseFont = true;
            this.col_Ma_TT50.Caption = "Mã TT-50";
            this.col_Ma_TT50.FieldName = "Ma_TT50";
            this.col_Ma_TT50.Name = "col_Ma_TT50";
            this.col_Ma_TT50.OptionsColumn.AllowEdit = false;
            this.col_Ma_TT50.OptionsColumn.AllowFocus = false;
            this.col_Ma_TT50.OptionsColumn.ReadOnly = true;
            this.col_Ma_TT50.Visible = true;
            this.col_Ma_TT50.VisibleIndex = 1;
            this.col_Ma_TT50.Width = 67;
            // 
            // col_Ten_TT50
            // 
            this.col_Ten_TT50.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ten_TT50.AppearanceHeader.Options.UseFont = true;
            this.col_Ten_TT50.Caption = "Tên TT-50";
            this.col_Ten_TT50.FieldName = "Ten_TT50";
            this.col_Ten_TT50.Name = "col_Ten_TT50";
            this.col_Ten_TT50.OptionsColumn.AllowEdit = false;
            this.col_Ten_TT50.OptionsColumn.AllowFocus = false;
            this.col_Ten_TT50.OptionsColumn.ReadOnly = true;
            this.col_Ten_TT50.Visible = true;
            this.col_Ten_TT50.VisibleIndex = 2;
            this.col_Ten_TT50.Width = 162;
            // 
            // col_MaPT_TT
            // 
            this.col_MaPT_TT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaPT_TT.AppearanceHeader.Options.UseFont = true;
            this.col_MaPT_TT.Caption = "Mã PT - TT";
            this.col_MaPT_TT.FieldName = "MaPT_TT";
            this.col_MaPT_TT.Name = "col_MaPT_TT";
            this.col_MaPT_TT.OptionsColumn.AllowEdit = false;
            this.col_MaPT_TT.OptionsColumn.AllowFocus = false;
            this.col_MaPT_TT.OptionsColumn.ReadOnly = true;
            this.col_MaPT_TT.Visible = true;
            this.col_MaPT_TT.VisibleIndex = 3;
            this.col_MaPT_TT.Width = 69;
            // 
            // col_Ma_TT37
            // 
            this.col_Ma_TT37.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ma_TT37.AppearanceHeader.Options.UseFont = true;
            this.col_Ma_TT37.Caption = "Mã TT-37";
            this.col_Ma_TT37.FieldName = "Ma_TT37";
            this.col_Ma_TT37.Name = "col_Ma_TT37";
            this.col_Ma_TT37.OptionsColumn.AllowEdit = false;
            this.col_Ma_TT37.OptionsColumn.AllowFocus = false;
            this.col_Ma_TT37.OptionsColumn.ReadOnly = true;
            this.col_Ma_TT37.Visible = true;
            this.col_Ma_TT37.VisibleIndex = 4;
            this.col_Ma_TT37.Width = 57;
            // 
            // col_Ten_TT37
            // 
            this.col_Ten_TT37.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ten_TT37.AppearanceHeader.Options.UseFont = true;
            this.col_Ten_TT37.Caption = "Tên TT-37";
            this.col_Ten_TT37.FieldName = "Ten_TT37";
            this.col_Ten_TT37.Name = "col_Ten_TT37";
            this.col_Ten_TT37.OptionsColumn.AllowEdit = false;
            this.col_Ten_TT37.OptionsColumn.AllowFocus = false;
            this.col_Ten_TT37.OptionsColumn.ReadOnly = true;
            this.col_Ten_TT37.Visible = true;
            this.col_Ten_TT37.VisibleIndex = 5;
            this.col_Ten_TT37.Width = 126;
            // 
            // col_STT
            // 
            this.col_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_STT.AppearanceHeader.Options.UseFont = true;
            this.col_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.Caption = "STT";
            this.col_STT.FieldName = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.OptionsColumn.AllowEdit = false;
            this.col_STT.OptionsColumn.AllowFocus = false;
            this.col_STT.OptionsColumn.ReadOnly = true;
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 6;
            this.col_STT.Width = 30;
            // 
            // col_MaCKTT50
            // 
            this.col_MaCKTT50.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaCKTT50.AppearanceHeader.Options.UseFont = true;
            this.col_MaCKTT50.Caption = "Mã CK TT 50";
            this.col_MaCKTT50.FieldName = "MaCKTT50";
            this.col_MaCKTT50.Name = "col_MaCKTT50";
            this.col_MaCKTT50.OptionsColumn.AllowEdit = false;
            this.col_MaCKTT50.OptionsColumn.AllowFocus = false;
            this.col_MaCKTT50.OptionsColumn.ReadOnly = true;
            this.col_MaCKTT50.Visible = true;
            this.col_MaCKTT50.VisibleIndex = 7;
            this.col_MaCKTT50.Width = 76;
            // 
            // col_Note
            // 
            this.col_Note.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Note.AppearanceHeader.Options.UseFont = true;
            this.col_Note.Caption = "Ghi chú";
            this.col_Note.FieldName = "Note";
            this.col_Note.Name = "col_Note";
            this.col_Note.OptionsColumn.AllowEdit = false;
            this.col_Note.OptionsColumn.AllowFocus = false;
            this.col_Note.OptionsColumn.ReadOnly = true;
            this.col_Note.Visible = true;
            this.col_Note.VisibleIndex = 8;
            this.col_Note.Width = 40;
            // 
            // col_PhanTuyen
            // 
            this.col_PhanTuyen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PhanTuyen.AppearanceHeader.Options.UseFont = true;
            this.col_PhanTuyen.Caption = "Phân Tuyến";
            this.col_PhanTuyen.FieldName = "PhanTuyen";
            this.col_PhanTuyen.Name = "col_PhanTuyen";
            this.col_PhanTuyen.OptionsColumn.AllowEdit = false;
            this.col_PhanTuyen.OptionsColumn.AllowFocus = false;
            this.col_PhanTuyen.OptionsColumn.ReadOnly = true;
            this.col_PhanTuyen.Visible = true;
            this.col_PhanTuyen.VisibleIndex = 10;
            this.col_PhanTuyen.Width = 53;
            // 
            // col_SoQD
            // 
            this.col_SoQD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SoQD.AppearanceHeader.Options.UseFont = true;
            this.col_SoQD.Caption = "Quyết Định";
            this.col_SoQD.FieldName = "SoQD";
            this.col_SoQD.Name = "col_SoQD";
            this.col_SoQD.OptionsColumn.AllowEdit = false;
            this.col_SoQD.OptionsColumn.AllowFocus = false;
            this.col_SoQD.OptionsColumn.ReadOnly = true;
            this.col_SoQD.Visible = true;
            this.col_SoQD.VisibleIndex = 11;
            this.col_SoQD.Width = 48;
            // 
            // col_NgayKy
            // 
            this.col_NgayKy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_NgayKy.AppearanceHeader.Options.UseFont = true;
            this.col_NgayKy.Caption = "Ngày Ký";
            this.col_NgayKy.FieldName = "NgayKy";
            this.col_NgayKy.Name = "col_NgayKy";
            this.col_NgayKy.OptionsColumn.AllowEdit = false;
            this.col_NgayKy.OptionsColumn.AllowFocus = false;
            this.col_NgayKy.OptionsColumn.ReadOnly = true;
            this.col_NgayKy.Visible = true;
            this.col_NgayKy.VisibleIndex = 12;
            this.col_NgayKy.Width = 50;
            // 
            // col_MaTT03_04
            // 
            this.col_MaTT03_04.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaTT03_04.AppearanceHeader.Options.UseFont = true;
            this.col_MaTT03_04.Caption = "Mã TT 03, 04";
            this.col_MaTT03_04.FieldName = "MaTT03_04";
            this.col_MaTT03_04.Name = "col_MaTT03_04";
            this.col_MaTT03_04.OptionsColumn.AllowEdit = false;
            this.col_MaTT03_04.OptionsColumn.AllowFocus = false;
            this.col_MaTT03_04.OptionsColumn.ReadOnly = true;
            this.col_MaTT03_04.Visible = true;
            this.col_MaTT03_04.VisibleIndex = 13;
            this.col_MaTT03_04.Width = 57;
            // 
            // col_MaQD5084
            // 
            this.col_MaQD5084.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaQD5084.AppearanceHeader.Options.UseFont = true;
            this.col_MaQD5084.Caption = "Mã QĐ 5084";
            this.col_MaQD5084.FieldName = "MaQD5084";
            this.col_MaQD5084.Name = "col_MaQD5084";
            this.col_MaQD5084.OptionsColumn.AllowEdit = false;
            this.col_MaQD5084.OptionsColumn.AllowFocus = false;
            this.col_MaQD5084.OptionsColumn.ReadOnly = true;
            this.col_MaQD5084.Visible = true;
            this.col_MaQD5084.VisibleIndex = 14;
            this.col_MaQD5084.Width = 94;
            // 
            // ItemGridLookUpEdit_Service_Group
            // 
            this.ItemGridLookUpEdit_Service_Group.AutoHeight = false;
            this.ItemGridLookUpEdit_Service_Group.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ItemGridLookUpEdit_Service_Group.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemGridLookUpEdit_Service_Group.Name = "ItemGridLookUpEdit_Service_Group";
            this.ItemGridLookUpEdit_Service_Group.NullText = "...";
            this.ItemGridLookUpEdit_Service_Group.View = this.ItemGridLookUpEditView_Service_Group;
            // 
            // ItemGridLookUpEditView_Service_Group
            // 
            this.ItemGridLookUpEditView_Service_Group.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_Service_Group_Code,
            this.view_Service_Group_Name});
            this.ItemGridLookUpEditView_Service_Group.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ItemGridLookUpEditView_Service_Group.Name = "ItemGridLookUpEditView_Service_Group";
            this.ItemGridLookUpEditView_Service_Group.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ItemGridLookUpEditView_Service_Group.OptionsView.ShowColumnHeaders = false;
            this.ItemGridLookUpEditView_Service_Group.OptionsView.ShowGroupPanel = false;
            // 
            // view_Service_Group_Code
            // 
            this.view_Service_Group_Code.Caption = "Mã nhóm viện phí";
            this.view_Service_Group_Code.FieldName = "ServiceGroupCode";
            this.view_Service_Group_Code.Name = "view_Service_Group_Code";
            // 
            // view_Service_Group_Name
            // 
            this.view_Service_Group_Name.Caption = "Tên nhóm dịch vụ";
            this.view_Service_Group_Name.FieldName = "ServiceGroupName";
            this.view_Service_Group_Name.Name = "view_Service_Group_Name";
            this.view_Service_Group_Name.Visible = true;
            this.view_Service_Group_Name.VisibleIndex = 0;
            // 
            // ref_Service_CategoryCode
            // 
            this.ref_Service_CategoryCode.AutoHeight = false;
            this.ref_Service_CategoryCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Service_CategoryCode.Name = "ref_Service_CategoryCode";
            this.ref_Service_CategoryCode.NullText = "...";
            this.ref_Service_CategoryCode.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_groupSerive,
            this.col_categoryCode,
            this.col_categoryName});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // view_groupSerive
            // 
            this.view_groupSerive.Caption = "Nhóm";
            this.view_groupSerive.FieldName = "ServiceGroupCode";
            this.view_groupSerive.Name = "view_groupSerive";
            this.view_groupSerive.Visible = true;
            this.view_groupSerive.VisibleIndex = 0;
            // 
            // col_categoryCode
            // 
            this.col_categoryCode.Caption = "Mã loại";
            this.col_categoryCode.FieldName = "ServiceCategoryCode";
            this.col_categoryCode.Name = "col_categoryCode";
            // 
            // col_categoryName
            // 
            this.col_categoryName.Caption = "Nội dung";
            this.col_categoryName.FieldName = "ServiceCategoryName";
            this.col_categoryName.Name = "col_categoryName";
            this.col_categoryName.Visible = true;
            this.col_categoryName.VisibleIndex = 1;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // rep_DepartmentCode
            // 
            this.rep_DepartmentCode.AutoHeight = false;
            this.rep_DepartmentCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_DepartmentCode.Name = "rep_DepartmentCode";
            // 
            // rep_PatientType
            // 
            this.rep_PatientType.AutoHeight = false;
            this.rep_PatientType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_PatientType.Name = "rep_PatientType";
            // 
            // ref_UnitOf
            // 
            this.ref_UnitOf.AutoHeight = false;
            this.ref_UnitOf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_UnitOf.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureName", "Đơn vị tính")});
            this.ref_UnitOf.Name = "ref_UnitOf";
            this.ref_UnitOf.NullText = "";
            // 
            // refChk_SampleTransfer
            // 
            this.refChk_SampleTransfer.AutoHeight = false;
            this.refChk_SampleTransfer.DisplayValueChecked = "1";
            this.refChk_SampleTransfer.DisplayValueGrayed = "0";
            this.refChk_SampleTransfer.DisplayValueUnchecked = "0";
            this.refChk_SampleTransfer.Name = "refChk_SampleTransfer";
            this.refChk_SampleTransfer.ValueChecked = 1;
            this.refChk_SampleTransfer.ValueGrayed = 0;
            this.refChk_SampleTransfer.ValueUnchecked = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Service);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1024, 600);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục - Dịch vụ BHYT";
            // 
            // col_DonGia_010316
            // 
            this.col_DonGia_010316.AppearanceCell.Options.UseTextOptions = true;
            this.col_DonGia_010316.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DonGia_010316.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DonGia_010316.AppearanceHeader.Options.UseFont = true;
            this.col_DonGia_010316.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonGia_010316.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DonGia_010316.Caption = "Giá T03";
            this.col_DonGia_010316.DisplayFormat.FormatString = "#,#";
            this.col_DonGia_010316.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_DonGia_010316.FieldName = "DonGia_010716";
            this.col_DonGia_010316.Name = "col_DonGia_010316";
            this.col_DonGia_010316.Visible = true;
            this.col_DonGia_010316.VisibleIndex = 15;
            // 
            // col_DonGia_010716
            // 
            this.col_DonGia_010716.AppearanceCell.Options.UseTextOptions = true;
            this.col_DonGia_010716.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DonGia_010716.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DonGia_010716.AppearanceHeader.Options.UseFont = true;
            this.col_DonGia_010716.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonGia_010716.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DonGia_010716.Caption = "Giá T07";
            this.col_DonGia_010716.DisplayFormat.FormatString = "#,#";
            this.col_DonGia_010716.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_DonGia_010716.FieldName = "DonGia_010716";
            this.col_DonGia_010716.Name = "col_DonGia_010716";
            this.col_DonGia_010716.Visible = true;
            this.col_DonGia_010716.VisibleIndex = 16;
            // 
            // frmVienPhiBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVienPhiBHYT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo công khám - giá viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVienPhiBHYT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEdit_Service_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridLookUpEditView_Service_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_CategoryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_DepartmentCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_PatientType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_UnitOf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refChk_SampleTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Service;
        private DevExpress.XtraGrid.Columns.GridColumn col_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ItemGridLookUpEdit_Service_Group;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemGridLookUpEditView_Service_Group;
        private DevExpress.XtraGrid.Columns.GridColumn view_Service_Group_Code;
        private DevExpress.XtraGrid.Columns.GridColumn view_Service_Group_Name;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ref_Service_CategoryCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn view_groupSerive;
        private DevExpress.XtraGrid.Columns.GridColumn col_categoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_categoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rep_DepartmentCode;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rep_PatientType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_UnitOf;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refChk_SampleTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaTuongDuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ma_TT50;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ten_TT50;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaPT_TT;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ma_TT37;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ten_TT37;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaCKTT50;
        private DevExpress.XtraGrid.Columns.GridColumn col_Note;
        private DevExpress.XtraGrid.Columns.GridColumn col_PhanTuyen;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoQD;
        private DevExpress.XtraGrid.Columns.GridColumn col_NgayKy;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaTT03_04;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaQD5084;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonGia_010316;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonGia_010716;
    }
}