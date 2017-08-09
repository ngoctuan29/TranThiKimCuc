namespace Ps.Clinic.Statistics
{
    partial class frmRpt_DSChuyenVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_DSChuyenVien));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_HospitalTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientReceiveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateMedical = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Symptoms = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LabResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DiagnosisCustom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DrugUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ReferenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NumberSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NumberTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TransferExpediency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TransferFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaTheBH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EThnicName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CareerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeNameDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dllNgay = new UserControlDate.dllNgay();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
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
            this.col_HospitalTransfer,
            this.col_PatientReceiveID,
            this.col_ObjectName,
            this.col_DateIn,
            this.col_DateMedical,
            this.col_Symptoms,
            this.col_LabResult,
            this.col_DiagnosisCustom,
            this.col_DrugUsed,
            this.col_ReferenceCode,
            this.col_Result,
            this.col_Reason,
            this.col_DateTransfer,
            this.col_NumberSave,
            this.col_NumberTransfer,
            this.col_TransferExpediency,
            this.col_TransferFullName,
            this.col_EmployeeName,
            this.col_PatientAddress,
            this.col_MaTheBH,
            this.col_FromDate,
            this.col_ToDate,
            this.col_PatientName,
            this.col_PatientBirthday,
            this.col_EThnicName,
            this.col_CareerName,
            this.col_EmployeeNameDoctor,
            this.col_PatientGender,
            this.col_DepartmentName,
            this.col_PatientCode});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsView.ColumnAutoWidth = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            // 
            // col_HospitalTransfer
            // 
            this.col_HospitalTransfer.Caption = "Nơi chuyển đến";
            this.col_HospitalTransfer.FieldName = "HospitalTransfer";
            this.col_HospitalTransfer.Name = "col_HospitalTransfer";
            this.col_HospitalTransfer.OptionsColumn.AllowEdit = false;
            this.col_HospitalTransfer.OptionsColumn.AllowFocus = false;
            this.col_HospitalTransfer.Visible = true;
            this.col_HospitalTransfer.VisibleIndex = 0;
            this.col_HospitalTransfer.Width = 101;
            // 
            // col_PatientReceiveID
            // 
            this.col_PatientReceiveID.Caption = "PatientReceiveID";
            this.col_PatientReceiveID.FieldName = "PatientReceiveID";
            this.col_PatientReceiveID.Name = "col_PatientReceiveID";
            this.col_PatientReceiveID.OptionsColumn.AllowEdit = false;
            this.col_PatientReceiveID.OptionsColumn.AllowFocus = false;
            // 
            // col_ObjectName
            // 
            this.col_ObjectName.Caption = "Đối tượng";
            this.col_ObjectName.FieldName = "ObjectName";
            this.col_ObjectName.Name = "col_ObjectName";
            this.col_ObjectName.OptionsColumn.AllowEdit = false;
            this.col_ObjectName.OptionsColumn.AllowFocus = false;
            this.col_ObjectName.Visible = true;
            this.col_ObjectName.VisibleIndex = 1;
            // 
            // col_DateIn
            // 
            this.col_DateIn.Caption = "Ngày vào";
            this.col_DateIn.FieldName = "DateIn";
            this.col_DateIn.Name = "col_DateIn";
            this.col_DateIn.OptionsColumn.AllowEdit = false;
            this.col_DateIn.OptionsColumn.AllowFocus = false;
            this.col_DateIn.Visible = true;
            this.col_DateIn.VisibleIndex = 9;
            this.col_DateIn.Width = 90;
            // 
            // col_DateMedical
            // 
            this.col_DateMedical.Caption = "Ngày khám";
            this.col_DateMedical.FieldName = "DateMedical";
            this.col_DateMedical.Name = "col_DateMedical";
            this.col_DateMedical.OptionsColumn.AllowEdit = false;
            this.col_DateMedical.OptionsColumn.AllowFocus = false;
            this.col_DateMedical.Visible = true;
            this.col_DateMedical.VisibleIndex = 10;
            this.col_DateMedical.Width = 91;
            // 
            // col_Symptoms
            // 
            this.col_Symptoms.Caption = "Chuẩn đoán";
            this.col_Symptoms.FieldName = "Symptoms";
            this.col_Symptoms.Name = "col_Symptoms";
            this.col_Symptoms.OptionsColumn.AllowEdit = false;
            this.col_Symptoms.OptionsColumn.AllowFocus = false;
            this.col_Symptoms.Visible = true;
            this.col_Symptoms.VisibleIndex = 11;
            this.col_Symptoms.Width = 108;
            // 
            // col_LabResult
            // 
            this.col_LabResult.Caption = "Các chỉ định";
            this.col_LabResult.FieldName = "LabResult";
            this.col_LabResult.Name = "col_LabResult";
            this.col_LabResult.OptionsColumn.AllowEdit = false;
            this.col_LabResult.OptionsColumn.AllowFocus = false;
            this.col_LabResult.Visible = true;
            this.col_LabResult.VisibleIndex = 13;
            this.col_LabResult.Width = 148;
            // 
            // col_DiagnosisCustom
            // 
            this.col_DiagnosisCustom.Caption = "Triệu chứng";
            this.col_DiagnosisCustom.FieldName = "DiagnosisCustom";
            this.col_DiagnosisCustom.Name = "col_DiagnosisCustom";
            this.col_DiagnosisCustom.OptionsColumn.AllowEdit = false;
            this.col_DiagnosisCustom.OptionsColumn.AllowFocus = false;
            this.col_DiagnosisCustom.Visible = true;
            this.col_DiagnosisCustom.VisibleIndex = 12;
            this.col_DiagnosisCustom.Width = 89;
            // 
            // col_DrugUsed
            // 
            this.col_DrugUsed.Caption = "Thuốc đã cấp";
            this.col_DrugUsed.FieldName = "DrugUsed";
            this.col_DrugUsed.Name = "col_DrugUsed";
            this.col_DrugUsed.OptionsColumn.AllowEdit = false;
            this.col_DrugUsed.OptionsColumn.AllowFocus = false;
            this.col_DrugUsed.Visible = true;
            this.col_DrugUsed.VisibleIndex = 14;
            this.col_DrugUsed.Width = 124;
            // 
            // col_ReferenceCode
            // 
            this.col_ReferenceCode.Caption = "ReferenceCode";
            this.col_ReferenceCode.FieldName = "ReferenceCode";
            this.col_ReferenceCode.Name = "col_ReferenceCode";
            this.col_ReferenceCode.OptionsColumn.AllowEdit = false;
            this.col_ReferenceCode.OptionsColumn.AllowFocus = false;
            // 
            // col_Result
            // 
            this.col_Result.Caption = "Tính trạng CV";
            this.col_Result.FieldName = "Result";
            this.col_Result.Name = "col_Result";
            this.col_Result.OptionsColumn.AllowEdit = false;
            this.col_Result.OptionsColumn.AllowFocus = false;
            this.col_Result.Visible = true;
            this.col_Result.VisibleIndex = 15;
            this.col_Result.Width = 103;
            // 
            // col_Reason
            // 
            this.col_Reason.Caption = "Lí do CV";
            this.col_Reason.FieldName = "Reason";
            this.col_Reason.Name = "col_Reason";
            this.col_Reason.OptionsColumn.AllowEdit = false;
            this.col_Reason.OptionsColumn.AllowFocus = false;
            this.col_Reason.Visible = true;
            this.col_Reason.VisibleIndex = 16;
            this.col_Reason.Width = 107;
            // 
            // col_DateTransfer
            // 
            this.col_DateTransfer.Caption = "Ngày chuyển viện";
            this.col_DateTransfer.FieldName = "DateTransfer";
            this.col_DateTransfer.Name = "col_DateTransfer";
            this.col_DateTransfer.OptionsColumn.AllowEdit = false;
            this.col_DateTransfer.OptionsColumn.AllowFocus = false;
            this.col_DateTransfer.Visible = true;
            this.col_DateTransfer.VisibleIndex = 19;
            this.col_DateTransfer.Width = 105;
            // 
            // col_NumberSave
            // 
            this.col_NumberSave.Caption = "Số lưu trữ";
            this.col_NumberSave.FieldName = "NumberSave";
            this.col_NumberSave.Name = "col_NumberSave";
            this.col_NumberSave.OptionsColumn.AllowEdit = false;
            this.col_NumberSave.OptionsColumn.AllowFocus = false;
            this.col_NumberSave.Visible = true;
            this.col_NumberSave.VisibleIndex = 18;
            // 
            // col_NumberTransfer
            // 
            this.col_NumberTransfer.Caption = "Số chuyển viện";
            this.col_NumberTransfer.FieldName = "NumberTransfer";
            this.col_NumberTransfer.Name = "col_NumberTransfer";
            this.col_NumberTransfer.OptionsColumn.AllowEdit = false;
            this.col_NumberTransfer.OptionsColumn.AllowFocus = false;
            this.col_NumberTransfer.Visible = true;
            this.col_NumberTransfer.VisibleIndex = 17;
            this.col_NumberTransfer.Width = 93;
            // 
            // col_TransferExpediency
            // 
            this.col_TransferExpediency.Caption = "Phương tiện ";
            this.col_TransferExpediency.FieldName = "TransferExpediency";
            this.col_TransferExpediency.Name = "col_TransferExpediency";
            this.col_TransferExpediency.OptionsColumn.AllowEdit = false;
            this.col_TransferExpediency.OptionsColumn.AllowFocus = false;
            this.col_TransferExpediency.Visible = true;
            this.col_TransferExpediency.VisibleIndex = 20;
            this.col_TransferExpediency.Width = 89;
            // 
            // col_TransferFullName
            // 
            this.col_TransferFullName.Caption = "Người đi cùng";
            this.col_TransferFullName.FieldName = "TransferFullName";
            this.col_TransferFullName.Name = "col_TransferFullName";
            this.col_TransferFullName.OptionsColumn.AllowEdit = false;
            this.col_TransferFullName.OptionsColumn.AllowFocus = false;
            this.col_TransferFullName.Visible = true;
            this.col_TransferFullName.VisibleIndex = 21;
            this.col_TransferFullName.Width = 109;
            // 
            // col_EmployeeName
            // 
            this.col_EmployeeName.Caption = "Nhân viên nhập";
            this.col_EmployeeName.FieldName = "EmployeeName";
            this.col_EmployeeName.Name = "col_EmployeeName";
            this.col_EmployeeName.OptionsColumn.AllowEdit = false;
            this.col_EmployeeName.OptionsColumn.AllowFocus = false;
            this.col_EmployeeName.Visible = true;
            this.col_EmployeeName.VisibleIndex = 27;
            this.col_EmployeeName.Width = 101;
            // 
            // col_PatientAddress
            // 
            this.col_PatientAddress.Caption = "Địa chỉ";
            this.col_PatientAddress.FieldName = "PatientAddress";
            this.col_PatientAddress.Name = "col_PatientAddress";
            this.col_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_PatientAddress.Visible = true;
            this.col_PatientAddress.VisibleIndex = 6;
            this.col_PatientAddress.Width = 106;
            // 
            // col_MaTheBH
            // 
            this.col_MaTheBH.Caption = "Mã thẻ BHYT";
            this.col_MaTheBH.FieldName = "MaTheBH";
            this.col_MaTheBH.Name = "col_MaTheBH";
            this.col_MaTheBH.OptionsColumn.AllowEdit = false;
            this.col_MaTheBH.OptionsColumn.AllowFocus = false;
            this.col_MaTheBH.Visible = true;
            this.col_MaTheBH.VisibleIndex = 24;
            this.col_MaTheBH.Width = 106;
            // 
            // col_FromDate
            // 
            this.col_FromDate.Caption = "Từ ngày";
            this.col_FromDate.FieldName = "FromDate";
            this.col_FromDate.Name = "col_FromDate";
            this.col_FromDate.OptionsColumn.AllowEdit = false;
            this.col_FromDate.OptionsColumn.AllowFocus = false;
            this.col_FromDate.Visible = true;
            this.col_FromDate.VisibleIndex = 25;
            // 
            // col_ToDate
            // 
            this.col_ToDate.Caption = "Đến ngày";
            this.col_ToDate.FieldName = "ToDate";
            this.col_ToDate.Name = "col_ToDate";
            this.col_ToDate.OptionsColumn.AllowEdit = false;
            this.col_ToDate.OptionsColumn.AllowFocus = false;
            this.col_ToDate.Visible = true;
            this.col_ToDate.VisibleIndex = 26;
            // 
            // col_PatientName
            // 
            this.col_PatientName.Caption = "Tên bệnh nhân";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.OptionsColumn.AllowEdit = false;
            this.col_PatientName.OptionsColumn.AllowFocus = false;
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 3;
            this.col_PatientName.Width = 135;
            // 
            // col_PatientBirthday
            // 
            this.col_PatientBirthday.Caption = "Ngày sinh";
            this.col_PatientBirthday.FieldName = "PatientBirthday";
            this.col_PatientBirthday.Name = "col_PatientBirthday";
            this.col_PatientBirthday.OptionsColumn.AllowEdit = false;
            this.col_PatientBirthday.OptionsColumn.AllowFocus = false;
            this.col_PatientBirthday.Visible = true;
            this.col_PatientBirthday.VisibleIndex = 4;
            // 
            // col_EThnicName
            // 
            this.col_EThnicName.Caption = "Dân tộc";
            this.col_EThnicName.FieldName = "EThnicName";
            this.col_EThnicName.Name = "col_EThnicName";
            this.col_EThnicName.OptionsColumn.AllowEdit = false;
            this.col_EThnicName.OptionsColumn.AllowFocus = false;
            this.col_EThnicName.Visible = true;
            this.col_EThnicName.VisibleIndex = 8;
            // 
            // col_CareerName
            // 
            this.col_CareerName.Caption = "Nghề nghiệp";
            this.col_CareerName.FieldName = "CareerName";
            this.col_CareerName.Name = "col_CareerName";
            this.col_CareerName.OptionsColumn.AllowEdit = false;
            this.col_CareerName.OptionsColumn.AllowFocus = false;
            this.col_CareerName.Visible = true;
            this.col_CareerName.VisibleIndex = 7;
            // 
            // col_EmployeeNameDoctor
            // 
            this.col_EmployeeNameDoctor.Caption = "Bác sỹ điều trị";
            this.col_EmployeeNameDoctor.FieldName = "EmployeeNameDoctor";
            this.col_EmployeeNameDoctor.Name = "col_EmployeeNameDoctor";
            this.col_EmployeeNameDoctor.OptionsColumn.AllowEdit = false;
            this.col_EmployeeNameDoctor.OptionsColumn.AllowFocus = false;
            this.col_EmployeeNameDoctor.Visible = true;
            this.col_EmployeeNameDoctor.VisibleIndex = 23;
            this.col_EmployeeNameDoctor.Width = 121;
            // 
            // col_PatientGender
            // 
            this.col_PatientGender.Caption = "Giới tính";
            this.col_PatientGender.FieldName = "PatientGender";
            this.col_PatientGender.Name = "col_PatientGender";
            this.col_PatientGender.OptionsColumn.AllowEdit = false;
            this.col_PatientGender.OptionsColumn.AllowFocus = false;
            this.col_PatientGender.Visible = true;
            this.col_PatientGender.VisibleIndex = 5;
            this.col_PatientGender.Width = 49;
            // 
            // col_DepartmentName
            // 
            this.col_DepartmentName.Caption = "Phòng điều trị";
            this.col_DepartmentName.FieldName = "DepartmentName";
            this.col_DepartmentName.Name = "col_DepartmentName";
            this.col_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_DepartmentName.Visible = true;
            this.col_DepartmentName.VisibleIndex = 22;
            this.col_DepartmentName.Width = 110;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.Caption = "Mã bệnh nhân";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 2;
            this.col_PatientCode.Width = 82;
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
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Controls.Add(this.butPrint);
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
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(67, 82);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(97, 23);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(170, 82);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(97, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In danh sách";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // frmRpt_DSChuyenVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 487);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRpt_DSChuyenVien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChon;
        private DevExpress.XtraGrid.Columns.GridColumn col_HospitalTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientReceiveID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateIn;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateMedical;
        private DevExpress.XtraGrid.Columns.GridColumn col_Symptoms;
        private DevExpress.XtraGrid.Columns.GridColumn col_LabResult;
        private DevExpress.XtraGrid.Columns.GridColumn col_DiagnosisCustom;
        private DevExpress.XtraGrid.Columns.GridColumn col_DrugUsed;
        private DevExpress.XtraGrid.Columns.GridColumn col_ReferenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_Reason;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn col_NumberSave;
        private DevExpress.XtraGrid.Columns.GridColumn col_NumberTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn col_TransferExpediency;
        private DevExpress.XtraGrid.Columns.GridColumn col_TransferFullName;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaTheBH;
        private DevExpress.XtraGrid.Columns.GridColumn col_FromDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ToDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_EThnicName;
        private DevExpress.XtraGrid.Columns.GridColumn col_CareerName;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeNameDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientGender;
        private DevExpress.XtraGrid.Columns.GridColumn col_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
    }
}