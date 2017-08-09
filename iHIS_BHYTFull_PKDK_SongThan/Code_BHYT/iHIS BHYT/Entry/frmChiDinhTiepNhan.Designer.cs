namespace Ps.Clinic.Entry
{
    partial class frmChiDinhTiepNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiDinhTiepNhan));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_List_CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientBirthYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_WardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DistrictName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ProvincialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientReceiveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtimeTo = new DevExpress.XtraEditors.DateEdit();
            this.dtimeFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.col_List_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkStatus = new DevExpress.XtraEditors.CheckEdit();
            this.col_List_ObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ReferenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_OrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(880, 487);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông Tin Tìm Kiếm";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 51);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(876, 434);
            this.panelControl1.TabIndex = 1040;
            // 
            // gridControl_result
            // 
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.Size = new System.Drawing.Size(876, 434);
            this.gridControl_result.TabIndex = 6;
            this.gridControl_result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_result});
            // 
            // gridView_result
            // 
            this.gridView_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_List_CreateDate,
            this.col_List_PatientName,
            this.col_List_PatientCode,
            this.col_List_PatientBirthYear,
            this.col_List_PatientAge,
            this.col_List_PatientGenderName,
            this.col_List_WardName,
            this.col_List_DistrictName,
            this.col_List_ObjectName,
            this.col_List_ProvincialName,
            this.col_List_Address,
            this.col_List_PatientReceiveID,
            this.col_List_PatientMobile,
            this.col_List_EmployeeName,
            this.col_List_ObjectCode,
            this.col_List_ReferenceCode,
            this.col_List_PatientType,
            this.col_List_OrderNumber});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsBehavior.Editable = false;
            this.gridView_result.OptionsView.ColumnAutoWidth = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            this.gridView_result.OptionsView.ShowIndicator = false;
            this.gridView_result.DoubleClick += new System.EventHandler(this.gridView_result_DoubleClick);
            // 
            // col_List_CreateDate
            // 
            this.col_List_CreateDate.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_CreateDate.AppearanceCell.Options.UseFont = true;
            this.col_List_CreateDate.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_CreateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_List_CreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_CreateDate.AppearanceHeader.Options.UseFont = true;
            this.col_List_CreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_CreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_List_CreateDate.Caption = "Ngày Vào";
            this.col_List_CreateDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_List_CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_List_CreateDate.FieldName = "CreateDate";
            this.col_List_CreateDate.Name = "col_List_CreateDate";
            this.col_List_CreateDate.OptionsColumn.AllowEdit = false;
            this.col_List_CreateDate.OptionsColumn.AllowFocus = false;
            this.col_List_CreateDate.OptionsColumn.ReadOnly = true;
            this.col_List_CreateDate.Visible = true;
            this.col_List_CreateDate.VisibleIndex = 11;
            this.col_List_CreateDate.Width = 113;
            // 
            // col_List_PatientName
            // 
            this.col_List_PatientName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientName.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientName.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientName.Caption = "Họ & tên";
            this.col_List_PatientName.FieldName = "PatientName";
            this.col_List_PatientName.Name = "col_List_PatientName";
            this.col_List_PatientName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientName.Visible = true;
            this.col_List_PatientName.VisibleIndex = 2;
            this.col_List_PatientName.Width = 147;
            // 
            // col_List_PatientCode
            // 
            this.col_List_PatientCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientCode.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientCode.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientCode.Caption = "Mã BN";
            this.col_List_PatientCode.FieldName = "PatientCode";
            this.col_List_PatientCode.Name = "col_List_PatientCode";
            this.col_List_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_List_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_List_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_List_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PatientCode", "{0:#,#.##}")});
            this.col_List_PatientCode.Visible = true;
            this.col_List_PatientCode.VisibleIndex = 1;
            this.col_List_PatientCode.Width = 87;
            // 
            // col_List_PatientBirthYear
            // 
            this.col_List_PatientBirthYear.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientBirthYear.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientBirthYear.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientBirthYear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientBirthYear.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientBirthYear.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientBirthYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthYear.Caption = "Năm Sinh";
            this.col_List_PatientBirthYear.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_List_PatientBirthYear.FieldName = "PatientBirthYear";
            this.col_List_PatientBirthYear.Name = "col_List_PatientBirthYear";
            this.col_List_PatientBirthYear.OptionsColumn.AllowEdit = false;
            this.col_List_PatientBirthYear.OptionsColumn.AllowFocus = false;
            this.col_List_PatientBirthYear.OptionsColumn.ReadOnly = true;
            this.col_List_PatientBirthYear.Visible = true;
            this.col_List_PatientBirthYear.VisibleIndex = 3;
            this.col_List_PatientBirthYear.Width = 80;
            // 
            // col_List_PatientAge
            // 
            this.col_List_PatientAge.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientAge.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientAge.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientAge.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientAge.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientAge.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientAge.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientAge.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientAge.Caption = "Tuổi";
            this.col_List_PatientAge.FieldName = "PatientAge";
            this.col_List_PatientAge.Name = "col_List_PatientAge";
            this.col_List_PatientAge.OptionsColumn.AllowEdit = false;
            this.col_List_PatientAge.OptionsColumn.AllowFocus = false;
            this.col_List_PatientAge.OptionsColumn.ReadOnly = true;
            this.col_List_PatientAge.Visible = true;
            this.col_List_PatientAge.VisibleIndex = 4;
            this.col_List_PatientAge.Width = 72;
            // 
            // col_List_PatientGenderName
            // 
            this.col_List_PatientGenderName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientGenderName.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientGenderName.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientGenderName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientGenderName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientGenderName.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientGenderName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientGenderName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientGenderName.Caption = "Giới tính";
            this.col_List_PatientGenderName.FieldName = "PatientGenderName";
            this.col_List_PatientGenderName.Name = "col_List_PatientGenderName";
            this.col_List_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientGenderName.Visible = true;
            this.col_List_PatientGenderName.VisibleIndex = 5;
            this.col_List_PatientGenderName.Width = 69;
            // 
            // col_List_WardName
            // 
            this.col_List_WardName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_WardName.AppearanceCell.Options.UseFont = true;
            this.col_List_WardName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_WardName.AppearanceHeader.Options.UseFont = true;
            this.col_List_WardName.Caption = "Xã/Phường";
            this.col_List_WardName.FieldName = "WardName";
            this.col_List_WardName.Name = "col_List_WardName";
            this.col_List_WardName.OptionsColumn.AllowEdit = false;
            this.col_List_WardName.OptionsColumn.AllowFocus = false;
            this.col_List_WardName.OptionsColumn.ReadOnly = true;
            this.col_List_WardName.Visible = true;
            this.col_List_WardName.VisibleIndex = 7;
            this.col_List_WardName.Width = 165;
            // 
            // col_List_DistrictName
            // 
            this.col_List_DistrictName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_DistrictName.AppearanceCell.Options.UseFont = true;
            this.col_List_DistrictName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_DistrictName.AppearanceHeader.Options.UseFont = true;
            this.col_List_DistrictName.Caption = "Huyện/Quận";
            this.col_List_DistrictName.FieldName = "DistrictName";
            this.col_List_DistrictName.Name = "col_List_DistrictName";
            this.col_List_DistrictName.OptionsColumn.AllowEdit = false;
            this.col_List_DistrictName.OptionsColumn.AllowFocus = false;
            this.col_List_DistrictName.OptionsColumn.ReadOnly = true;
            this.col_List_DistrictName.Visible = true;
            this.col_List_DistrictName.VisibleIndex = 8;
            this.col_List_DistrictName.Width = 131;
            // 
            // col_List_ObjectName
            // 
            this.col_List_ObjectName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_ObjectName.AppearanceCell.Options.UseFont = true;
            this.col_List_ObjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_ObjectName.AppearanceHeader.Options.UseFont = true;
            this.col_List_ObjectName.Caption = "Đối Tượng";
            this.col_List_ObjectName.FieldName = "ObjectName";
            this.col_List_ObjectName.Name = "col_List_ObjectName";
            this.col_List_ObjectName.OptionsColumn.AllowEdit = false;
            this.col_List_ObjectName.OptionsColumn.AllowFocus = false;
            this.col_List_ObjectName.OptionsColumn.ReadOnly = true;
            this.col_List_ObjectName.Visible = true;
            this.col_List_ObjectName.VisibleIndex = 12;
            this.col_List_ObjectName.Width = 113;
            // 
            // col_List_ProvincialName
            // 
            this.col_List_ProvincialName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_ProvincialName.AppearanceCell.Options.UseFont = true;
            this.col_List_ProvincialName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_ProvincialName.AppearanceHeader.Options.UseFont = true;
            this.col_List_ProvincialName.Caption = "Tỉnh/ Tp";
            this.col_List_ProvincialName.FieldName = "ProvincialName";
            this.col_List_ProvincialName.Name = "col_List_ProvincialName";
            this.col_List_ProvincialName.OptionsColumn.AllowEdit = false;
            this.col_List_ProvincialName.OptionsColumn.AllowFocus = false;
            this.col_List_ProvincialName.OptionsColumn.ReadOnly = true;
            this.col_List_ProvincialName.Visible = true;
            this.col_List_ProvincialName.VisibleIndex = 9;
            this.col_List_ProvincialName.Width = 121;
            // 
            // col_List_Address
            // 
            this.col_List_Address.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_Address.AppearanceCell.Options.UseFont = true;
            this.col_List_Address.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_Address.AppearanceHeader.Options.UseFont = true;
            this.col_List_Address.Caption = "Số nhà (thôn, xóm)";
            this.col_List_Address.FieldName = "Address";
            this.col_List_Address.Name = "col_List_Address";
            this.col_List_Address.OptionsColumn.AllowEdit = false;
            this.col_List_Address.OptionsColumn.AllowFocus = false;
            this.col_List_Address.OptionsColumn.ReadOnly = true;
            this.col_List_Address.Visible = true;
            this.col_List_Address.VisibleIndex = 6;
            this.col_List_Address.Width = 174;
            // 
            // col_List_PatientReceiveID
            // 
            this.col_List_PatientReceiveID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientReceiveID.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientReceiveID.Caption = "PatientReceiveID";
            this.col_List_PatientReceiveID.FieldName = "PatientReceiveID";
            this.col_List_PatientReceiveID.Name = "col_List_PatientReceiveID";
            this.col_List_PatientReceiveID.OptionsColumn.AllowEdit = false;
            this.col_List_PatientReceiveID.OptionsColumn.AllowFocus = false;
            this.col_List_PatientReceiveID.OptionsColumn.ReadOnly = true;
            // 
            // col_List_PatientMobile
            // 
            this.col_List_PatientMobile.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_List_PatientMobile.AppearanceCell.Options.UseFont = true;
            this.col_List_PatientMobile.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientMobile.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientMobile.Caption = "Điện thoại";
            this.col_List_PatientMobile.FieldName = "PatientMobile";
            this.col_List_PatientMobile.Name = "col_List_PatientMobile";
            this.col_List_PatientMobile.OptionsColumn.ReadOnly = true;
            this.col_List_PatientMobile.Visible = true;
            this.col_List_PatientMobile.VisibleIndex = 10;
            this.col_List_PatientMobile.Width = 130;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.chkStatus);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.dtimeTo);
            this.panelControl2.Controls.Add(this.dtimeFrom);
            this.panelControl2.Controls.Add(this.labelControl23);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 20);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(876, 31);
            this.panelControl2.TabIndex = 1039;
            // 
            // butOK
            // 
            this.butOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butOK.Appearance.Options.UseFont = true;
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(432, 3);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(68, 23);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Tìm";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(179, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 1012;
            this.labelControl5.Text = "đến ngày :";
            // 
            // dtimeTo
            // 
            this.dtimeTo.EditValue = null;
            this.dtimeTo.Location = new System.Drawing.Point(237, 5);
            this.dtimeTo.Name = "dtimeTo";
            this.dtimeTo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.dtimeTo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtimeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtimeTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtimeTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtimeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtimeTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtimeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtimeTo.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dtimeTo.Size = new System.Drawing.Size(106, 20);
            this.dtimeTo.TabIndex = 1011;
            // 
            // dtimeFrom
            // 
            this.dtimeFrom.EditValue = null;
            this.dtimeFrom.Location = new System.Drawing.Point(73, 5);
            this.dtimeFrom.Name = "dtimeFrom";
            this.dtimeFrom.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.dtimeFrom.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtimeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtimeFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtimeFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtimeFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtimeFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtimeFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtimeFrom.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dtimeFrom.Size = new System.Drawing.Size(100, 20);
            this.dtimeFrom.TabIndex = 1010;
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(18, 8);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(47, 13);
            this.labelControl23.TabIndex = 1009;
            this.labelControl23.Text = "Từ ngày :";
            // 
            // col_List_EmployeeName
            // 
            this.col_List_EmployeeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_EmployeeName.AppearanceHeader.Options.UseFont = true;
            this.col_List_EmployeeName.Caption = "Người tiếp nhận";
            this.col_List_EmployeeName.FieldName = "EmployeeName";
            this.col_List_EmployeeName.Name = "col_List_EmployeeName";
            this.col_List_EmployeeName.OptionsColumn.ReadOnly = true;
            this.col_List_EmployeeName.Visible = true;
            this.col_List_EmployeeName.VisibleIndex = 13;
            this.col_List_EmployeeName.Width = 112;
            // 
            // chkStatus
            // 
            this.chkStatus.Location = new System.Drawing.Point(349, 5);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Properties.Caption = "Đã chỉ định";
            this.chkStatus.Size = new System.Drawing.Size(75, 19);
            this.chkStatus.TabIndex = 1013;
            // 
            // col_List_ObjectCode
            // 
            this.col_List_ObjectCode.Caption = "Mã đối tượng";
            this.col_List_ObjectCode.FieldName = "ObjectCode";
            this.col_List_ObjectCode.Name = "col_List_ObjectCode";
            this.col_List_ObjectCode.OptionsColumn.ReadOnly = true;
            // 
            // col_List_ReferenceCode
            // 
            this.col_List_ReferenceCode.Caption = "ReferenceCode";
            this.col_List_ReferenceCode.FieldName = "ReferenceCode";
            this.col_List_ReferenceCode.Name = "col_List_ReferenceCode";
            // 
            // col_List_PatientType
            // 
            this.col_List_PatientType.Caption = "PatientType";
            this.col_List_PatientType.FieldName = "PatientType";
            this.col_List_PatientType.Name = "col_List_PatientType";
            // 
            // col_List_OrderNumber
            // 
            this.col_List_OrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_OrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_OrderNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_OrderNumber.AppearanceHeader.Options.UseFont = true;
            this.col_List_OrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_OrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_OrderNumber.Caption = "STT";
            this.col_List_OrderNumber.FieldName = "OrderNumber";
            this.col_List_OrderNumber.Name = "col_List_OrderNumber";
            this.col_List_OrderNumber.OptionsColumn.ReadOnly = true;
            this.col_List_OrderNumber.Visible = true;
            this.col_List_OrderNumber.VisibleIndex = 0;
            this.col_List_OrderNumber.Width = 55;
            // 
            // frmChiDinhTiepNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 487);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChiDinhTiepNhan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiDinhTiepNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtimeFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_CreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientBirthYear;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientAge;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_WardName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DistrictName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ProvincialName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_Address;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientReceiveID;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientMobile;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dtimeTo;
        private DevExpress.XtraEditors.DateEdit dtimeFrom;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_EmployeeName;
        private DevExpress.XtraEditors.CheckEdit chkStatus;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ReferenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientType;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_OrderNumber;
    }
}