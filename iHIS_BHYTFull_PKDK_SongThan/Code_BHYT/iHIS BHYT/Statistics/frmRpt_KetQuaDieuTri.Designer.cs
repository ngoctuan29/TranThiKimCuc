namespace Ps.Clinic.Statistics
{
    partial class frmRpt_KetQuaDieuTri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_KetQuaDieuTri));
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dllNgay = new UserControlDate.dllNgay();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.slkupPatientType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Type_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Type_TypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkupDepartment = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Part_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_ServiceGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkupPatientType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.groupControl2.Text = "Thông Tin Vào Viện";
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
            this.col_List_AdvicesOut});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsBehavior.Editable = false;
            this.gridView_result.OptionsView.ColumnAutoWidth = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            // 
            // col_List_CreateDate
            // 
            this.col_List_CreateDate.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_CreateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.col_List_CreateDate.VisibleIndex = 5;
            this.col_List_CreateDate.Width = 112;
            // 
            // col_List_PatientName
            // 
            this.col_List_PatientName.Caption = "Họ tên bệnh nhân";
            this.col_List_PatientName.FieldName = "PatientName";
            this.col_List_PatientName.Name = "col_List_PatientName";
            this.col_List_PatientName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientName.Visible = true;
            this.col_List_PatientName.VisibleIndex = 1;
            this.col_List_PatientName.Width = 151;
            // 
            // col_List_PatientCode
            // 
            this.col_List_PatientCode.Caption = "Mã BN";
            this.col_List_PatientCode.FieldName = "PatientCode";
            this.col_List_PatientCode.Name = "col_List_PatientCode";
            this.col_List_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_List_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_List_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_List_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PatientCode", "{0:#,#.##}")});
            this.col_List_PatientCode.Visible = true;
            this.col_List_PatientCode.VisibleIndex = 0;
            this.col_List_PatientCode.Width = 81;
            // 
            // col_List_PatientBirthyear
            // 
            this.col_List_PatientBirthyear.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientBirthyear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthyear.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientBirthyear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthyear.Caption = "Năm Sinh";
            this.col_List_PatientBirthyear.FieldName = "PatientBirthyear";
            this.col_List_PatientBirthyear.Name = "col_List_PatientBirthyear";
            this.col_List_PatientBirthyear.OptionsColumn.AllowEdit = false;
            this.col_List_PatientBirthyear.OptionsColumn.AllowFocus = false;
            this.col_List_PatientBirthyear.OptionsColumn.ReadOnly = true;
            this.col_List_PatientBirthyear.Visible = true;
            this.col_List_PatientBirthyear.VisibleIndex = 2;
            this.col_List_PatientBirthyear.Width = 95;
            // 
            // col_List_PatientAge
            // 
            this.col_List_PatientAge.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientAge.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientAge.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientAge.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientAge.Caption = "Tuổi";
            this.col_List_PatientAge.FieldName = "PatientAge";
            this.col_List_PatientAge.Name = "col_List_PatientAge";
            this.col_List_PatientAge.OptionsColumn.AllowEdit = false;
            this.col_List_PatientAge.OptionsColumn.AllowFocus = false;
            this.col_List_PatientAge.OptionsColumn.ReadOnly = true;
            this.col_List_PatientAge.Visible = true;
            this.col_List_PatientAge.VisibleIndex = 3;
            this.col_List_PatientAge.Width = 97;
            // 
            // col_List_PatientGenderName
            // 
            this.col_List_PatientGenderName.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientGenderName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientGenderName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientGenderName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientGenderName.Caption = "Giới tính";
            this.col_List_PatientGenderName.FieldName = "PatientGenderName";
            this.col_List_PatientGenderName.Name = "col_List_PatientGenderName";
            this.col_List_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientGenderName.Visible = true;
            this.col_List_PatientGenderName.VisibleIndex = 4;
            this.col_List_PatientGenderName.Width = 86;
            // 
            // col_List_DiagnosisCode
            // 
            this.col_List_DiagnosisCode.Caption = "C. Đoán Vào";
            this.col_List_DiagnosisCode.FieldName = "DiagnosisCode";
            this.col_List_DiagnosisCode.Name = "col_List_DiagnosisCode";
            this.col_List_DiagnosisCode.OptionsColumn.AllowEdit = false;
            this.col_List_DiagnosisCode.OptionsColumn.AllowFocus = false;
            this.col_List_DiagnosisCode.OptionsColumn.ReadOnly = true;
            this.col_List_DiagnosisCode.Visible = true;
            this.col_List_DiagnosisCode.VisibleIndex = 8;
            this.col_List_DiagnosisCode.Width = 105;
            // 
            // col_List_DiagnosisNameIn
            // 
            this.col_List_DiagnosisNameIn.Caption = "ICD10 Vào";
            this.col_List_DiagnosisNameIn.FieldName = "DiagnosisNameIn";
            this.col_List_DiagnosisNameIn.Name = "col_List_DiagnosisNameIn";
            this.col_List_DiagnosisNameIn.OptionsColumn.AllowEdit = false;
            this.col_List_DiagnosisNameIn.OptionsColumn.AllowFocus = false;
            this.col_List_DiagnosisNameIn.OptionsColumn.ReadOnly = true;
            this.col_List_DiagnosisNameIn.Visible = true;
            this.col_List_DiagnosisNameIn.VisibleIndex = 9;
            this.col_List_DiagnosisNameIn.Width = 115;
            // 
            // col_List_ObjectName
            // 
            this.col_List_ObjectName.Caption = "Đối Tượng";
            this.col_List_ObjectName.FieldName = "ObjectName";
            this.col_List_ObjectName.Name = "col_List_ObjectName";
            this.col_List_ObjectName.OptionsColumn.AllowEdit = false;
            this.col_List_ObjectName.OptionsColumn.AllowFocus = false;
            this.col_List_ObjectName.OptionsColumn.ReadOnly = true;
            this.col_List_ObjectName.Visible = true;
            this.col_List_ObjectName.VisibleIndex = 7;
            this.col_List_ObjectName.Width = 113;
            // 
            // col_List_DiagnosisNameOut
            // 
            this.col_List_DiagnosisNameOut.Caption = "ICD10 Ra";
            this.col_List_DiagnosisNameOut.FieldName = "DiagnosisNameOut";
            this.col_List_DiagnosisNameOut.Name = "col_List_DiagnosisNameOut";
            this.col_List_DiagnosisNameOut.OptionsColumn.AllowEdit = false;
            this.col_List_DiagnosisNameOut.OptionsColumn.AllowFocus = false;
            this.col_List_DiagnosisNameOut.OptionsColumn.ReadOnly = true;
            this.col_List_DiagnosisNameOut.Visible = true;
            this.col_List_DiagnosisNameOut.VisibleIndex = 10;
            this.col_List_DiagnosisNameOut.Width = 107;
            // 
            // col_List_ResultName
            // 
            this.col_List_ResultName.Caption = "Xử Trí";
            this.col_List_ResultName.FieldName = "ResultsName";
            this.col_List_ResultName.Name = "col_List_ResultName";
            this.col_List_ResultName.OptionsColumn.AllowEdit = false;
            this.col_List_ResultName.OptionsColumn.AllowFocus = false;
            this.col_List_ResultName.OptionsColumn.ReadOnly = true;
            this.col_List_ResultName.Visible = true;
            this.col_List_ResultName.VisibleIndex = 11;
            this.col_List_ResultName.Width = 131;
            // 
            // col_List_PatientAddress
            // 
            this.col_List_PatientAddress.Caption = "Đơn Vị";
            this.col_List_PatientAddress.FieldName = "PatientAddress";
            this.col_List_PatientAddress.Name = "col_List_PatientAddress";
            this.col_List_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_List_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_List_PatientAddress.OptionsColumn.ReadOnly = true;
            this.col_List_PatientAddress.Visible = true;
            this.col_List_PatientAddress.VisibleIndex = 6;
            this.col_List_PatientAddress.Width = 131;
            // 
            // col_List_AdvicesOut
            // 
            this.col_List_AdvicesOut.Caption = "T.Trạng Ra Về";
            this.col_List_AdvicesOut.FieldName = "AdvicesOut";
            this.col_List_AdvicesOut.Name = "col_List_AdvicesOut";
            this.col_List_AdvicesOut.OptionsColumn.AllowEdit = false;
            this.col_List_AdvicesOut.OptionsColumn.AllowFocus = false;
            this.col_List_AdvicesOut.OptionsColumn.ReadOnly = true;
            this.col_List_AdvicesOut.Visible = true;
            this.col_List_AdvicesOut.VisibleIndex = 12;
            this.col_List_AdvicesOut.Width = 112;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Controls.Add(this.labelControl19);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.butPrint);
            this.panelControl2.Controls.Add(this.slkupPatientType);
            this.panelControl2.Controls.Add(this.slkupDepartment);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(314, 464);
            this.panelControl2.TabIndex = 1039;
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
            this.labelControl19.Location = new System.Drawing.Point(5, 81);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(80, 13);
            this.labelControl19.TabIndex = 1035;
            this.labelControl19.Text = "Loại bệnh nhân :";
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(143, 126);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(89, 23);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 102);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 1035;
            this.labelControl1.Text = "Khoa phòng :";
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(233, 126);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(73, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // slkupPatientType
            // 
            this.slkupPatientType.EditValue = "-1";
            this.slkupPatientType.Location = new System.Drawing.Point(91, 78);
            this.slkupPatientType.Name = "slkupPatientType";
            this.slkupPatientType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.slkupPatientType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupPatientType.Properties.NullText = "";
            this.slkupPatientType.Properties.View = this.searchLookUpEdit1View;
            this.slkupPatientType.Size = new System.Drawing.Size(215, 20);
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
            // slkupDepartment
            // 
            this.slkupDepartment.EditValue = "";
            this.slkupDepartment.Location = new System.Drawing.Point(91, 99);
            this.slkupDepartment.Name = "slkupDepartment";
            this.slkupDepartment.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.slkupDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupDepartment.Properties.NullText = "";
            this.slkupDepartment.Properties.View = this.gridView1;
            this.slkupDepartment.Size = new System.Drawing.Size(215, 20);
            this.slkupDepartment.TabIndex = 1034;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Part_RowID,
            this.col_Part_DepartmentCode,
            this.col_Part_DepartmentName,
            this.col_Part_ServiceGroupCode,
            this.col_Part_Hide});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_Part_RowID
            // 
            this.col_Part_RowID.Caption = "Mã";
            this.col_Part_RowID.FieldName = "RowID";
            this.col_Part_RowID.Name = "col_Part_RowID";
            this.col_Part_RowID.Width = 100;
            // 
            // col_Part_DepartmentCode
            // 
            this.col_Part_DepartmentCode.Caption = "Mã Khoa Phòng";
            this.col_Part_DepartmentCode.FieldName = "DepartmentCode";
            this.col_Part_DepartmentCode.Name = "col_Part_DepartmentCode";
            this.col_Part_DepartmentCode.Visible = true;
            this.col_Part_DepartmentCode.VisibleIndex = 0;
            this.col_Part_DepartmentCode.Width = 183;
            // 
            // col_Part_DepartmentName
            // 
            this.col_Part_DepartmentName.Caption = "Khoa phòng";
            this.col_Part_DepartmentName.FieldName = "DepartmentName";
            this.col_Part_DepartmentName.Name = "col_Part_DepartmentName";
            this.col_Part_DepartmentName.Visible = true;
            this.col_Part_DepartmentName.VisibleIndex = 1;
            // 
            // col_Part_ServiceGroupCode
            // 
            this.col_Part_ServiceGroupCode.Caption = "ServiceGroupCode";
            this.col_Part_ServiceGroupCode.FieldName = "ServiceGroupCode";
            this.col_Part_ServiceGroupCode.Name = "col_Part_ServiceGroupCode";
            // 
            // col_Part_Hide
            // 
            this.col_Part_Hide.Caption = "Hide";
            this.col_Part_Hide.FieldName = "Hide";
            this.col_Part_Hide.Name = "col_Part_Hide";
            // 
            // frmRpt_KetQuaDieuTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 487);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRpt_KetQuaDieuTri";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRpt_KetQuaDieuTri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkupPatientType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butPrint;
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_DepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_ServiceGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_Hide;
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
    }
}