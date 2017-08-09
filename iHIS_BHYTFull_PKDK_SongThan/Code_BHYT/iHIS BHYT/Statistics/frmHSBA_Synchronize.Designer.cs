namespace Ps.Clinic.Statistics
{
    partial class frmHSBA_Synchronize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHSBA_Synchronize));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_List_CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientBirthyear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DiagnosisCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DiagnosisNameIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DiagnosisNameOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ResultName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_AdvicesOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_List_PatientReceiveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkConfirm = new DevExpress.XtraEditors.CheckEdit();
            this.butUpload = new DevExpress.XtraEditors.SimpleButton();
            this.dllNgay = new UserControlDate.dllNgay();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.butReload = new DevExpress.XtraEditors.SimpleButton();
            this.slkupPatientType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Type_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Type_TypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupPatientType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
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
            this.groupControl2.Text = "Thông Tin Lọc Dữ Liệu";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(316, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(562, 464);
            this.panelControl1.TabIndex = 1040;
            // 
            // gridControl_result
            // 
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChon});
            this.gridControl_result.Size = new System.Drawing.Size(562, 464);
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
            this.col_List_PatientBirthyear,
            this.col_List_PatientAge,
            this.col_List_PatientGenderName,
            this.col_List_DiagnosisCode,
            this.col_List_DiagnosisNameIn,
            this.col_List_ObjectName,
            this.col_List_DiagnosisNameOut,
            this.col_List_ResultName,
            this.col_List_PatientAddress,
            this.col_List_AdvicesOut,
            this.col_List_Chon,
            this.col_List_PatientReceiveID});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu ...";
            this.gridView_result.IndicatorWidth = 10;
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsView.ColumnAutoWidth = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            // 
            // col_List_CreateDate
            // 
            this.col_List_CreateDate.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_CreateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_CreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_CreateDate.AppearanceHeader.Options.UseFont = true;
            this.col_List_CreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_CreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_CreateDate.Caption = "Ngày Vào";
            this.col_List_CreateDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_List_CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_List_CreateDate.FieldName = "CreateDate";
            this.col_List_CreateDate.Name = "col_List_CreateDate";
            this.col_List_CreateDate.OptionsColumn.AllowEdit = false;
            this.col_List_CreateDate.OptionsColumn.AllowFocus = false;
            this.col_List_CreateDate.OptionsColumn.ReadOnly = true;
            this.col_List_CreateDate.Visible = true;
            this.col_List_CreateDate.VisibleIndex = 6;
            this.col_List_CreateDate.Width = 98;
            // 
            // col_List_PatientName
            // 
            this.col_List_PatientName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientName.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientName.Caption = "Họ tên bệnh nhân";
            this.col_List_PatientName.FieldName = "PatientName";
            this.col_List_PatientName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_List_PatientName.Name = "col_List_PatientName";
            this.col_List_PatientName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientName.Visible = true;
            this.col_List_PatientName.VisibleIndex = 2;
            this.col_List_PatientName.Width = 151;
            // 
            // col_List_PatientCode
            // 
            this.col_List_PatientCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientCode.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientCode.Caption = "Mã BN";
            this.col_List_PatientCode.FieldName = "PatientCode";
            this.col_List_PatientCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_List_PatientCode.Name = "col_List_PatientCode";
            this.col_List_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_List_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_List_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_List_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PatientCode", "{0:#,#.##}")});
            this.col_List_PatientCode.Visible = true;
            this.col_List_PatientCode.VisibleIndex = 1;
            this.col_List_PatientCode.Width = 81;
            // 
            // col_List_PatientBirthyear
            // 
            this.col_List_PatientBirthyear.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientBirthyear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthyear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientBirthyear.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientBirthyear.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientBirthyear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthyear.Caption = "Năm Sinh";
            this.col_List_PatientBirthyear.FieldName = "PatientBirthyear";
            this.col_List_PatientBirthyear.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_List_PatientBirthyear.Name = "col_List_PatientBirthyear";
            this.col_List_PatientBirthyear.OptionsColumn.AllowEdit = false;
            this.col_List_PatientBirthyear.OptionsColumn.AllowFocus = false;
            this.col_List_PatientBirthyear.OptionsColumn.ReadOnly = true;
            this.col_List_PatientBirthyear.Visible = true;
            this.col_List_PatientBirthyear.VisibleIndex = 3;
            this.col_List_PatientBirthyear.Width = 71;
            // 
            // col_List_PatientAge
            // 
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
            this.col_List_PatientAge.Width = 58;
            // 
            // col_List_PatientGenderName
            // 
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
            this.col_List_PatientGenderName.Width = 63;
            // 
            // col_List_DiagnosisCode
            // 
            this.col_List_DiagnosisCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_DiagnosisCode.AppearanceHeader.Options.UseFont = true;
            this.col_List_DiagnosisCode.Caption = "C. Đoán Vào";
            this.col_List_DiagnosisCode.FieldName = "DiagnosisCode";
            this.col_List_DiagnosisCode.Name = "col_List_DiagnosisCode";
            this.col_List_DiagnosisCode.OptionsColumn.AllowEdit = false;
            this.col_List_DiagnosisCode.OptionsColumn.AllowFocus = false;
            this.col_List_DiagnosisCode.OptionsColumn.ReadOnly = true;
            this.col_List_DiagnosisCode.Visible = true;
            this.col_List_DiagnosisCode.VisibleIndex = 9;
            this.col_List_DiagnosisCode.Width = 105;
            // 
            // col_List_DiagnosisNameIn
            // 
            this.col_List_DiagnosisNameIn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_DiagnosisNameIn.AppearanceHeader.Options.UseFont = true;
            this.col_List_DiagnosisNameIn.Caption = "ICD10 Vào";
            this.col_List_DiagnosisNameIn.FieldName = "DiagnosisNameIn";
            this.col_List_DiagnosisNameIn.Name = "col_List_DiagnosisNameIn";
            this.col_List_DiagnosisNameIn.OptionsColumn.AllowEdit = false;
            this.col_List_DiagnosisNameIn.OptionsColumn.AllowFocus = false;
            this.col_List_DiagnosisNameIn.OptionsColumn.ReadOnly = true;
            this.col_List_DiagnosisNameIn.Visible = true;
            this.col_List_DiagnosisNameIn.VisibleIndex = 10;
            this.col_List_DiagnosisNameIn.Width = 115;
            // 
            // col_List_ObjectName
            // 
            this.col_List_ObjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_ObjectName.AppearanceHeader.Options.UseFont = true;
            this.col_List_ObjectName.Caption = "Đối Tượng";
            this.col_List_ObjectName.FieldName = "ObjectName";
            this.col_List_ObjectName.Name = "col_List_ObjectName";
            this.col_List_ObjectName.OptionsColumn.AllowEdit = false;
            this.col_List_ObjectName.OptionsColumn.AllowFocus = false;
            this.col_List_ObjectName.OptionsColumn.ReadOnly = true;
            this.col_List_ObjectName.Visible = true;
            this.col_List_ObjectName.VisibleIndex = 8;
            this.col_List_ObjectName.Width = 113;
            // 
            // col_List_DiagnosisNameOut
            // 
            this.col_List_DiagnosisNameOut.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_DiagnosisNameOut.AppearanceHeader.Options.UseFont = true;
            this.col_List_DiagnosisNameOut.Caption = "ICD10 Ra";
            this.col_List_DiagnosisNameOut.FieldName = "DiagnosisNameOut";
            this.col_List_DiagnosisNameOut.Name = "col_List_DiagnosisNameOut";
            this.col_List_DiagnosisNameOut.OptionsColumn.AllowEdit = false;
            this.col_List_DiagnosisNameOut.OptionsColumn.AllowFocus = false;
            this.col_List_DiagnosisNameOut.OptionsColumn.ReadOnly = true;
            this.col_List_DiagnosisNameOut.Visible = true;
            this.col_List_DiagnosisNameOut.VisibleIndex = 11;
            this.col_List_DiagnosisNameOut.Width = 107;
            // 
            // col_List_ResultName
            // 
            this.col_List_ResultName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_ResultName.AppearanceHeader.Options.UseFont = true;
            this.col_List_ResultName.Caption = "Xử Trí";
            this.col_List_ResultName.FieldName = "ResultsName";
            this.col_List_ResultName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.col_List_ResultName.Name = "col_List_ResultName";
            this.col_List_ResultName.OptionsColumn.AllowEdit = false;
            this.col_List_ResultName.OptionsColumn.AllowFocus = false;
            this.col_List_ResultName.OptionsColumn.ReadOnly = true;
            this.col_List_ResultName.Visible = true;
            this.col_List_ResultName.VisibleIndex = 12;
            this.col_List_ResultName.Width = 130;
            // 
            // col_List_PatientAddress
            // 
            this.col_List_PatientAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_PatientAddress.AppearanceHeader.Options.UseFont = true;
            this.col_List_PatientAddress.Caption = "Đơn Vị";
            this.col_List_PatientAddress.FieldName = "PatientAddress";
            this.col_List_PatientAddress.Name = "col_List_PatientAddress";
            this.col_List_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_List_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_List_PatientAddress.OptionsColumn.ReadOnly = true;
            this.col_List_PatientAddress.Visible = true;
            this.col_List_PatientAddress.VisibleIndex = 7;
            this.col_List_PatientAddress.Width = 131;
            // 
            // col_List_AdvicesOut
            // 
            this.col_List_AdvicesOut.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_AdvicesOut.AppearanceHeader.Options.UseFont = true;
            this.col_List_AdvicesOut.Caption = "T.Trạng Ra Về";
            this.col_List_AdvicesOut.FieldName = "AdvicesOut";
            this.col_List_AdvicesOut.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.col_List_AdvicesOut.Name = "col_List_AdvicesOut";
            this.col_List_AdvicesOut.OptionsColumn.AllowEdit = false;
            this.col_List_AdvicesOut.OptionsColumn.AllowFocus = false;
            this.col_List_AdvicesOut.OptionsColumn.ReadOnly = true;
            this.col_List_AdvicesOut.Visible = true;
            this.col_List_AdvicesOut.VisibleIndex = 13;
            this.col_List_AdvicesOut.Width = 112;
            // 
            // col_List_Chon
            // 
            this.col_List_Chon.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_Chon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_Chon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_List_Chon.AppearanceHeader.Options.UseFont = true;
            this.col_List_Chon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_Chon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_Chon.Caption = "Chọn";
            this.col_List_Chon.ColumnEdit = this.repChon;
            this.col_List_Chon.FieldName = "Chon";
            this.col_List_Chon.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_List_Chon.Name = "col_List_Chon";
            this.col_List_Chon.Visible = true;
            this.col_List_Chon.VisibleIndex = 0;
            this.col_List_Chon.Width = 36;
            // 
            // repChon
            // 
            this.repChon.AutoHeight = false;
            this.repChon.DisplayValueChecked = "1";
            this.repChon.DisplayValueGrayed = "0";
            this.repChon.DisplayValueUnchecked = "0";
            this.repChon.Name = "repChon";
            this.repChon.ValueChecked = 1;
            this.repChon.ValueGrayed = 0;
            this.repChon.ValueUnchecked = 0;
            // 
            // col_List_PatientReceiveID
            // 
            this.col_List_PatientReceiveID.Caption = "PatientReceiveID";
            this.col_List_PatientReceiveID.FieldName = "PatientReceiveID";
            this.col_List_PatientReceiveID.Name = "col_List_PatientReceiveID";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.chkConfirm);
            this.panelControl2.Controls.Add(this.butUpload);
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Controls.Add(this.labelControl19);
            this.panelControl2.Controls.Add(this.butReload);
            this.panelControl2.Controls.Add(this.slkupPatientType);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(314, 464);
            this.panelControl2.TabIndex = 1039;
            // 
            // chkConfirm
            // 
            this.chkConfirm.Location = new System.Drawing.Point(56, 108);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Properties.Caption = "Đã upload";
            this.chkConfirm.Size = new System.Drawing.Size(75, 19);
            this.chkConfirm.TabIndex = 1038;
            // 
            // butUpload
            // 
            this.butUpload.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.butUpload.Appearance.Options.UseForeColor = true;
            this.butUpload.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butUpload.Image = ((System.Drawing.Image)(resources.GetObject("butUpload.Image")));
            this.butUpload.Location = new System.Drawing.Point(219, 107);
            this.butUpload.Name = "butUpload";
            this.butUpload.Size = new System.Drawing.Size(86, 23);
            this.butUpload.TabIndex = 1037;
            this.butUpload.Text = "Upload Web";
            this.butUpload.Click += new System.EventHandler(this.butUpload_Click);
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(10, 3);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(296, 73);
            this.dllNgay.TabIndex = 1036;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(20, 81);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(42, 13);
            this.labelControl19.TabIndex = 1035;
            this.labelControl19.Text = "Loại BN :";
            // 
            // butReload
            // 
            this.butReload.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butReload.Image = ((System.Drawing.Image)(resources.GetObject("butReload.Image")));
            this.butReload.Location = new System.Drawing.Point(133, 107);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(85, 23);
            this.butReload.TabIndex = 4;
            this.butReload.Text = "Lấy số liệu";
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // slkupPatientType
            // 
            this.slkupPatientType.EditValue = "-1";
            this.slkupPatientType.Location = new System.Drawing.Point(65, 78);
            this.slkupPatientType.Name = "slkupPatientType";
            this.slkupPatientType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.slkupPatientType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupPatientType.Properties.NullText = "";
            this.slkupPatientType.Properties.View = this.searchLookUpEdit1View;
            this.slkupPatientType.Size = new System.Drawing.Size(240, 20);
            this.slkupPatientType.TabIndex = 1034;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Type_RowID,
            this.col_Type_TypeName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // col_Type_RowID
            // 
            this.col_Type_RowID.Caption = "Mã";
            this.col_Type_RowID.FieldName = "RowID";
            this.col_Type_RowID.Name = "col_Type_RowID";
            this.col_Type_RowID.Visible = true;
            this.col_Type_RowID.VisibleIndex = 0;
            this.col_Type_RowID.Width = 100;
            // 
            // col_Type_TypeName
            // 
            this.col_Type_TypeName.Caption = "Loại bệnh nhân";
            this.col_Type_TypeName.FieldName = "TypeName";
            this.col_Type_TypeName.Name = "col_Type_TypeName";
            this.col_Type_TypeName.Visible = true;
            this.col_Type_TypeName.VisibleIndex = 1;
            this.col_Type_TypeName.Width = 183;
            // 
            // frmHSBA_Synchronize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 487);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHSBA_Synchronize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHSBA_Synchronize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupPatientType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butReload;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupPatientType;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn col_Type_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Type_TypeName;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_CreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientBirthyear;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientAge;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DiagnosisCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DiagnosisNameIn;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DiagnosisNameOut;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ResultName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_AdvicesOut;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChon;
        private DevExpress.XtraEditors.SimpleButton butUpload;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientReceiveID;
        private DevExpress.XtraEditors.CheckEdit chkConfirm;
    }
}