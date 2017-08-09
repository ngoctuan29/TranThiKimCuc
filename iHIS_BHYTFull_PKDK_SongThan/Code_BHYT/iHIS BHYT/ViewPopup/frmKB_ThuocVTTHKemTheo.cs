using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Ps.Clinic.ViewPopup;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmKB_ThuocVTTHKemTheo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userCode = string.Empty;
        private string patientCode = string.Empty;
        private Int32 iPaid = 0, iPatientType = 0, iStatus = 0;
        private string bankCode = string.Empty, medicalRecordCode = string.Empty;
        private string exportCode = string.Empty, serviceCode = string.Empty;
        private string strUsed, firstRowUsageGuide = string.Empty;
        private string firstRowUOM = string.Empty;
        private string s, tr, c, t = string.Empty;
        private decimal ReceiveID = 0;
        private string departmentCode = string.Empty, referenceCode = string.Empty;
        private int iObjectCode = 0;
        private DataTable dtMedicalRecord = new DataTable();
        private DataTable tableItemOut = new DataTable();
        private DateTime dtServer = new DateTime();
        private DataView dataViewItem = null;
        private string shiftWork = string.Empty;
        private DateTime dtWorking = new DateTime();
        private string employeeCodeDoctorRpository = string.Empty;
        private decimal suggestedID = -1;
        private string repositoryGroup = "2,4";
        public frmKB_ThuocVTTHKemTheo(decimal _suggestedID, string _serviceCode, string _departmentCode, string suserCode, string _referenceCode, string _patitentCode, Int32 _patientType, decimal _patientReceiveID, Int32 _objectCode, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.departmentCode = _departmentCode;
            this.s_userCode = suserCode;
            this.patientCode = _patitentCode;
            this.iPatientType = _patientType;
            this.ReceiveID = _patientReceiveID;
            this.iObjectCode = _objectCode;
            this.referenceCode = _referenceCode;
            this.shiftWork = _shiftWork;
            this.dtWorking = _dtWorking;
            this.serviceCode = _serviceCode;
            this.suggestedID = _suggestedID;
        }

        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }
        
        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }
        
        private void frmKB_ThuocVTTHKemTheo_Load(object sender, EventArgs e)
        {
            try
            {
                //this.medicalCode = MedicalRecord_BLL.refMedicalCode(this.ReceiveID, this.patientCode, this.departmentCode, this.referenceCode, ref iStatus, ref iPaid, ref bankCode);
                List<UnitOfMeasureInf> lstUnitOf = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.refUoM.DataSource = lstUnitOf;
                this.refUoM.DisplayMember = "UnitOfMeasureName";
                this.refUoM.ValueMember = "UnitOfMeasureCode";

                this.replkup_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.replkup_ObjectCode.DisplayMember = "ObjectName";
                this.replkup_ObjectCode.ValueMember = "ObjectCode";

                this.repSlkup_UnitOfMeasureCode_Medi.DataSource = lstUnitOf;
                this.repSlkup_UnitOfMeasureCode_Medi.DisplayMember = "UnitOfMeasureName";
                this.repSlkup_UnitOfMeasureCode_Medi.ValueMember = "UnitOfMeasureCode";

                this.repUsage.DataSource = UsageBLL.ListUsage(string.Empty);
                this.repUsage.DisplayMember = "UsageName";
                this.repUsage.ValueMember = "UsageCode";
                List<InstructionInf> lstInstruc = InstructionBLL.ListInstruction(0);
                foreach (var v in lstInstruc)
                {
                    this.refInstruction.Items.Add(v.InstructionName);
                }
                if (this.dtMedicalRecord.Rows.Count > 0)
                {
                    this.butSave.Enabled = false;
                    this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                }
                else
                {
                    this.EnableText(false);
                    this.butSave.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = false;
                }

                MedicalRecord_INF objMedical = MedicalRecord_BLL.ObjMedicalRecordForSuggestedID(this.suggestedID, this.ReceiveID);
                if (objMedical != null && !string.IsNullOrEmpty(objMedical.MedicalRecordCode))
                {
                    this.medicalRecordCode = objMedical.MedicalRecordCode;
                    this.iStatus = objMedical.Status;
                    if (!this.iStatus.Equals(1))
                    {
                        this.butSave.Enabled = false;
                        this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                    }
                    else
                        this.butPrintPrescription.Enabled = true;
                }

                this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                this.gridView_Prescription.OptionsBehavior.Editable = false;
                this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.GetInfoPatient(this.patientCode);
                
                List<EmployeeInf> objEmployee = EmployeeBLL.ListEmployee(this.s_userCode);
                if (objEmployee != null && !string.IsNullOrEmpty(objEmployee[0].EmployeeCode))
                {
                    string[] arrRepository = objEmployee[0].PermissionRepository.Split(',');
                    if (arrRepository.Length > 0)
                    {
                        for (int i = 0; i < arrRepository.Length; i++)
                        {
                            this.employeeCodeDoctorRpository += "RepositoryCode='" + arrRepository[i].ToString() + "'";
                            if (i < arrRepository.Length - 1)
                                this.employeeCodeDoctorRpository += " or ";
                        }
                    }
                }
                this.repositoryGroup = "2,4";
                this.lkupRepositoryCode.Properties.DataSource = RepositoryCatalog_BLL.ListRepositoryForImport(0, this.repositoryGroup, this.s_userCode);
                this.lkupRepositoryCode.Properties.ValueMember = "RepositoryCode";
                this.lkupRepositoryCode.Properties.DisplayMember = "RepositoryName";
                this.LoadRepository();
                this.Load_TreeView();
                this.dtServer = Utils.DateTimeServer();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Lỗi phát sinh khi cấp toa\t\n-Liên hệ admin để kiểm tra lỗi: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Restart();
            }
        }

        private void LoadRepository()
        {
            try
            {
                this.tableItemOut = new DataTable();
                
                if (!this.iObjectCode.Equals(1))
                    this.repositoryGroup = "4";
                DataTable tableRepTemp = ItemsBLL.Table_ListItemsRef(0, this.repositoryGroup, this.iObjectCode);
                if (tableRepTemp.Select(this.employeeCodeDoctorRpository).Length > 0)
                    this.tableItemOut = tableRepTemp.Select(this.employeeCodeDoctorRpository).CopyToDataTable();
                else
                    this.tableItemOut = tableRepTemp.Clone();
                this.repSearchBHYT_ItemCode.DataSource = this.tableItemOut;
                this.repSearchBHYT_ItemCode.DisplayMember = "ItemName";
                this.repSearchBHYT_ItemCode.ValueMember = "ItemCode";
                this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalRecordForSuggestedID(this.suggestedID, this.repositoryGroup);
                this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
                if (this.dtMedicalRecord == null || this.dtMedicalRecord.Rows.Count <= 0)
                {
                    this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalAttachItem(this.serviceCode);
                    this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = false;
                    this.gridView_Prescription.OptionsBehavior.Editable = true;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    this.EnableText(true);
                    this.EnableButton(false);
                }
            }
            catch (Exception) { return; }
        }

        public void EnableText(bool ena)
        {
            this.lkupRepositoryCode.ReadOnly = !ena;
        }

        public void EnableButton(bool b)
        {
            this.butEdit.Enabled = this.butPrintPrescription.Enabled = b;
            this.butSave.Enabled = this.butUndo.Enabled = !b;
        }

        private decimal ParseQuantity(string qty)
        {
            decimal sl1 = 0;
            try
            {
                string[] arr;
                if (qty.Trim() != "")
                {
                    arr = qty.Trim().Split('/');
                    if (arr.Length == 2)
                    {
                        try
                        {
                            int tu = int.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                            int mau = int.Parse(arr[1].Trim() == "" ? "1" : arr[1].Trim());
                            sl1 = (decimal)(tu * (1M) / mau);
                        }
                        catch { }
                    }
                    else
                        if (arr.Length > 0)
                        {
                            try
                            {
                                sl1 = decimal.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                            }
                            catch { }
                        }
                }
            }
            catch { }
            return sl1;
        }
                
        private void frmKB_ThuocVTTHKemTheo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //case Keys.F2: this.butNew_Click(sender, e); break;                   //F2 - Thêm mới
                case Keys.F3: this.butSave_Click(sender, e); break;                  //F3 - Lưu
                case Keys.F6: this.butPrintPrescription_Click(sender, e); break;     //F6 - In toa
            }
        }

        private bool SaveMedical(ref string message, bool saveItem)
        {
            bool resultSave = false;
            try
            {
                if (this.dtMedicalRecord != null && this.dtMedicalRecord.Rows.Count > 0)
                {
                    MedicalRecord_INF modelRecord = new MedicalRecord_INF();
                    modelRecord.MedicalRecordCode = this.medicalRecordCode;
                    modelRecord.PatientReceiveID = this.ReceiveID;
                    modelRecord.PatientCode = this.patientCode;
                    modelRecord.DepartmentCode = this.departmentCode;
                    modelRecord.EmployeeCode = this.s_userCode;
                    modelRecord.PostingDate = Utils.DateTimeServer();
                    modelRecord.ReferenceCode = this.referenceCode;
                    modelRecord.Status = this.iStatus;
                    modelRecord.ObjectCode = this.iObjectCode;
                    modelRecord.DiagnosisEnclosed = -1;
                    modelRecord.AppointmentDate = Convert.ToDateTime("01/01/1900");
                    modelRecord.EmployeeCodeDoctor = this.s_userCode;
                    modelRecord.Advices = string.Empty;
                    modelRecord.Symptoms = string.Empty;
                    modelRecord.ContentMedicalPattern = string.Empty;
                    modelRecord.ShiftWork = this.shiftWork;
                    modelRecord.Treatments = string.Empty;
                    modelRecord.DiagnosisCustom = string.Empty;
                    modelRecord.ReceiptID = this.suggestedID;
                    int iResult = MedicalRecord_BLL.InsMedicalRecord_Emergency(modelRecord, ref this.medicalRecordCode);
                    if (iResult == 1)
                    {
                        decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                        bool bcheckInventory = true;
                        bool bcheckQuantity = true;
                        string msgError = string.Empty, sMsgErrorQuantity = string.Empty;
                        foreach (DataRow r in this.dtMedicalRecord.Rows)
                        {
                            if (r["isChecked"].ToString() == "1")
                            {
                                dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                                dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, this.lkupRepositoryCode.EditValue.ToString(), ref dAmountEnd);
                                if (dQuantityReq <= 0)
                                {
                                    sMsgErrorQuantity += r["ItemName"].ToString() + " số lượng: " + dQuantityReq.ToString("N0") + "\n\t";
                                    bcheckQuantity = false;
                                }
                                if (dAmountEnd < dQuantityReq)
                                {
                                    msgError += r["ItemName"].ToString() + " tồn hiện tại: " + dAmountEnd.ToString("N0") + "\n\t";
                                    bcheckInventory = false;
                                }
                            }
                        }
                        if (!bcheckQuantity)
                        {
                            message = " Những thuốc sau chưa nhập số lượng \n\t" + sMsgErrorQuantity;
                            resultSave = false;
                        }
                        else if (bcheckInventory)
                        {
                            MedicalRecord_BLL.DelMedicalRecordDetail(this.medicalRecordCode, -1, this.iObjectCode == 1 ? 1 : 0);
                            foreach (DataRow r in this.dtMedicalRecord.Rows)
                            {
                                if (r["isChecked"].ToString() == "1")
                                {
                                    DataRow row = Utils.GetPriceRowbyCode(this.tableItemOut, "ItemCode='" + r["ItemCode"].ToString() + "'");
                                if (r["Status"].ToString() == "0" && row != null)
                                {
                                    MedicalPrescriptionDetail_INF mDetail = new MedicalPrescriptionDetail_INF();
                                    mDetail.MedicalRecordCode = this.medicalRecordCode;
                                    mDetail.EmployeeCode = s_userCode;
                                    mDetail.ItemCode = r["ItemCode"].ToString();
                                    mDetail.DateOfIssues = Convert.ToInt32(r["DateOfIssues"].ToString());
                                    mDetail.Morning = r["Morning"].ToString();
                                    mDetail.Noon = r["Noon"].ToString();
                                    mDetail.Afternoon = r["Afternoon"].ToString();
                                    mDetail.Evening = r["Evening"].ToString();
                                    mDetail.Quantity = Convert.ToDecimal(r["Quantity"].ToString());
                                    mDetail.Instruction = r["Instruction"].ToString();
                                    mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                    mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                    mDetail.PostingDate = Utils.DateTimeServer();
                                    mDetail.Status = 0;
                                    mDetail.RepositoryCode = this.lkupRepositoryCode.EditValue.ToString();
                                    mDetail.DoseOf = 0;
                                    mDetail.DoseOfPills = string.Empty;
                                        //if (this.iObjectCode.Equals(1))
                                        //    mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                        //else
                                        //    mDetail.ObjectCode = this.iObjectCode;
                                        if (Convert.ToInt32(r["ObjectCode"].ToString()) > 2)
                                            mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                        else
                                            mDetail.ObjectCode = this.iObjectCode;
                                    //if (!mDetail.ObjectCode.Equals(1))
                                    //    mDetail.BHYT = 0;
                                    //else
                                    //    mDetail.BHYT = 1;
                                    mDetail.BHYT = 0;
                                    mDetail.UnitOfMeasureCode_Medi = r["UnitOfMeasureCode_Medi"].ToString();
                                    MedicalRecord_BLL.InsMedicalRecordDetail(mDetail, this.iObjectCode);
                                }
                            }
                        }
                            resultSave = true;
                        }
                        else
                        {
                            message = " Thuốc không đủ tồn : \n\t" + msgError;
                            resultSave = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message+" \n Lưu không thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resultSave = false;
            }
            return resultSave;
        }

        private void butPrintPrescription_Click(object sender, EventArgs e)
        {
            if (this.dtMedicalRecord.Rows.Count > 0)
            {
                //if (this.iObjectCode.Equals(1))
                //    this.PrintPrescription();
                this.PrintPrescription_Out();
            }
        }
        
        private void PrintPrescription_Out()
        {
            try
            {
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Clear();
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtMedicalRecord = MedicalRecord_BLL.DT_GetResultMedical(this.medicalRecordCode, this.ReceiveID, 0);
                DataTable dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalRecordCode, "4", -1, 1, -1); //-1 in tat ca thuoc co trong kho
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.referenceCode, this.patientCode, this.ReceiveID);

                    DataTable dtICD10kt = new DataTable();
                    dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    dtICD10kt.Rows.Add(sICD10kt);
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtMedicalRecord);
                    dsTemp.Tables.Add(dtMedicalDetail);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtICD10kt);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToaThuocMuaNgoai.xml");
                    Reports.rptToaThuocMuaNgoai rptShow = new Reports.rptToaThuocMuaNgoai();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuocMuaNgoai", "Toa mua ngoài");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ReceiveID > 0 && this.iPaid == 0 && this.bankCode == string.Empty)
                {
                    this.EnableText(true);
                    this.EnableButton(false);
                    this.lkupRepositoryCode.ReadOnly = false;
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = false;
                    this.gridView_Prescription.OptionsBehavior.Editable = true;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    this.butPrintPrescription.Enabled = true;
                }
                else
                {
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                    this.gridView_Prescription.OptionsBehavior.Editable = false;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    XtraMessageBox.Show(" Đợt điều trị đã thanh toán, không được phép xóa hay sửa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký tiếp nhận!\t\n Hãy xem lại thông tin bệnh nhân.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lkupRepositoryCode.Properties.ReadOnly = true;
                this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                this.gridView_Prescription.OptionsBehavior.Editable = false;
                this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                return;
            } 
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.butUndo.Enabled = this.butSave.Enabled = false;
                this.butEdit.Enabled = this.butPrintPrescription.Enabled = true;
                this.lkupRepositoryCode.Properties.ReadOnly = true;
                this.EnableText(false);
            }
            catch
            {
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                string error = string.Empty;
                if (this.lkupRepositoryCode.EditValue == null || string.IsNullOrEmpty(this.lkupRepositoryCode.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Chọn kho xuất Thuốc - VTTH cho bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupRepositoryCode.Focus();
                    return;
                }
                if (this.SaveMedical(ref error, true))
                {
                    XtraMessageBox.Show(" Lưu toa thuốc thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.EnableText(false);
                    this.EnableButton(true);
                    this.LoadRepository();
                    if (this.tableItemOut.Rows.Count > 0)
                    {
                        this.butSave.Enabled = false;
                        this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                    }
                    else
                    {
                        this.EnableText(false);
                        this.butSave.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = false;
                    }
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                    this.gridView_Prescription.OptionsBehavior.Editable = false;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    this.Load_TreeView();
                }
                else
                {
                    XtraMessageBox.Show(" Lưu toa thuốc không thành công, phát sinh lỗi: " + error, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void GetInfoPatient(string sPatient)
        {

            PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.ReceiveID);
            if (objPatient != null && objPatient.PatientCode != null)
            {
                string sGenderName = string.Empty;
                if (objPatient.PatientGender == 0)
                    sGenderName = "Nữ";
                else
                    sGenderName = "Nam";
                this.grInfoMedial.Text = "Mã BN: " + objPatient.PatientCode + " | Họ tên: " + objPatient.PatientName + " - " + objPatient.PatientBirthyear.ToString() + " - " + objPatient.PatientAge.ToString() + " - Giới tính: " + sGenderName + " | Địa chỉ: " + objPatient.PatientAddress;
            }
            else
                return;

        }
        
        private void Load_TreeView()
        {
            try
            {
                treeHistory.Nodes.Clear();
                TreeNode node, node1;
                DataTable dtHis = MedicalRecord_BLL.DT_Get_PrescriptionsOldFor(patientCode, ReceiveID, this.referenceCode);
                foreach (DataRow dr in dtHis.Rows)
                {
                    node = new TreeNode("Toa ngày: " + dr["PostingDate"].ToString());
                    node.Tag = dr["MedicalRecordCode"].ToString() + ":?";
                    treeHistory.Nodes.Add(node);
                    DataTable dtTemp = MedicalRecord_BLL.DT_MedicalDetailRecordOut(dr["MedicalRecordCode"].ToString(), dr["PostingDate"].ToString());
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        node1 = new TreeNode(r["ItemName"].ToString() + "(" + r["Quantity"].ToString() + ")");
                        node1.Tag = r["ItemCode"].ToString() + ":?";
                        node.Nodes.Add(node1);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(" Bạn thật sự muốn hủy toa thuốc này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    Int32 statusTemp = 0;
                    decimal dRowID = 0;
                    bool bResult = true;
                    string itemNameTemp = string.Empty;
                    foreach (DataRow dr in this.dtMedicalRecord.Rows)
                    {
                        statusTemp = Convert.ToInt32(dr["Status"].ToString());
                        dRowID = Convert.ToDecimal(dr["RowID"].ToString());
                        itemNameTemp = dr["ItemName"].ToString();
                        if (statusTemp == 0)
                        {
                            if (MedicalRecord_BLL.DelMedicalRecordDetail(this.medicalRecordCode, dRowID, this.iObjectCode == 1 ? 1 : 0) != 1)
                            {
                                bResult = false;
                                itemNameTemp += dr["ItemName"].ToString() + ";";
                            }
                        }
                    }
                    if (bResult)
                    {
                        XtraMessageBox.Show(" Đã hủy phiếu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.LoadRepository();
                        this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalRecordForSuggestedID(this.suggestedID, this.repositoryGroup);
                        this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
                        if (this.dtMedicalRecord.Rows.Count > 0)
                        {
                            this.butSave.Enabled = false;
                            this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                        }
                        else
                        {
                            this.EnableText(false);
                            this.butSave.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = false;
                        }
                        this.Load_TreeView();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Những thuốc sau không hủy được: " + itemNameTemp.TrimEnd(','), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show(" Lỗi: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridControl_Prescription_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            GridControl grid = sender as GridControl;
            this.gridView_Prescription_KeyPress(grid.FocusedView, e);
        }

        private void gridView_Prescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "DateOfIssues")
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (view.FocusedColumn.FieldName == "Morning")
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
                if (view.FocusedColumn.FieldName == "Noon")
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
                if (view.FocusedColumn.FieldName == "Afternoon")
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
                if (view.FocusedColumn.FieldName == "Evening")
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
            }
            catch { }
        }
        private void Fresh_value_checked_in_Table_dtMedicalRecord()
        {
            try
            {
                foreach(DataRow row in this.dtMedicalRecord.Rows)
                {
                    row["isChecked"] = 0;
                }
            }
            catch { }
        }
        private void gridView_Prescription_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Action == CollectionChangeAction.Refresh)  //IF CHECK ALL IN GRIDVIEW
                {
                    this.Fresh_value_checked_in_Table_dtMedicalRecord();
                    int[] lstchecked = view.GetSelectedRows();
                    if(lstchecked.Count()>0)
                    foreach (var index in lstchecked)
                    {
                        if (index >= 0)
                        {
                            string itemcode = string.Empty;

                                try
                                {
                                    itemcode = view.GetRowCellValue(index, this.col_ItemCode).ToString();
                                    DataRow row = this.dtMedicalRecord.Select("Itemcode = '" + itemcode + "'").FirstOrDefault();
                                    row["isChecked"] = 1;
                                }
                                catch { }
                        }
                    }
                   
                }
                else
                {
                    string itemcode = string.Empty;
                    itemcode = view.GetFocusedRowCellValue(col_ItemCode).ToString();
                    DataRow row = this.dtMedicalRecord.Select("Itemcode = '" + itemcode + "'").FirstOrDefault();
                    if (row != null)
                    {
                        if (e.Action == CollectionChangeAction.Add)
                        {

                            row["isChecked"] = 1;
                        }

                        else if (e.Action == CollectionChangeAction.Remove)
                        {
                            row["isChecked"] = 0;
                        }
                    }
                }

            }
            catch { }
        }

        private void gridView_Prescription_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView_Prescription_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (this.gridView_Prescription.GetFocusedRow() != null)
                {
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Date_Of_Issues, 1);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Quantity, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Unit_Price, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Amount, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Stutus, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_MedicalRecordCode, this.medicalRecordCode);
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi khởi tạo toa thuốc!\t\n- Liên hệ quản trị để được kiểm tra lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Prescription_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Toa thuốc bác sĩ kê thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private void gridView_Prescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show(" Bạn có muốn xóa thuốc này hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        string status = ISDBNULL2STRING(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, col_Stutus).ToString(), string.Empty);
                        string itemCodeTemp = this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, col_ItemCode).ToString();
                        if (status != "1")
                        {
                            MedicalRecord_BLL.DelMedicalRecordDetailForItemCode(this.medicalRecordCode, itemCodeTemp);
                            this.gridView_Prescription.DeleteSelectedRows();
                            this.dtMedicalRecord.AcceptChanges();
                        }
                        else
                        {
                            XtraMessageBox.Show("Thuốc đang chọn đã xuất cho bệnh nhân, không được xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi xóa thuốc", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridView_Prescription_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 statusTemp = 0;
                if (e.RowHandle >= 0)
                {
                    statusTemp = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status"]));
                    if (statusTemp == 1)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                        View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void gridView_Prescription_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is SearchLookUpEdit)
                {
                    DevExpress.XtraEditors.SearchLookUpEdit searchEdit;
                    searchEdit = (SearchLookUpEdit)view.ActiveEditor;
                    DataTable table = this.repSearchBHYT_ItemCode.DataSource as DataTable;
                    this.dataViewItem = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    this.dataViewItem.RowFilter = "AmountEnd >0 ";
                    searchEdit.Properties.DataSource = this.dataViewItem;
                }
            }
            catch { }
        }

        private void gridView_Prescription_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (ISDBNULL2STRING(Convert.ToString(view.GetRowCellValue(rowfocus, col_ItemCode)).ToString(), string.Empty) == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ItemCode, "Nhập tên thuốc! ");
                }

                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Quantity, "Số lượng yêu cầu lớn hơn 0 !");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Unit_Price)), 1) < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Unit_Price, "Chưa khai đơn giá cho thuốc!");
                }
            }
            catch { }
        }

        private void gridView_Prescription_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                decimal unitprice = Convert.ToDecimal(view.GetFocusedRowCellValue(this.col_Unit_Price));
                decimal amount = Convert.ToDecimal(view.GetFocusedRowCellValue(this.col_Amount));
                bool converted_Medi = Convert.ToBoolean(view.GetFocusedRowCellValue(this.col_Converted_Medi));
                s = Convert.ToString(view.GetFocusedRowCellValue("Morning"));
                tr = Convert.ToString(view.GetFocusedRowCellValue("Noon"));
                c = Convert.ToString(view.GetFocusedRowCellValue("Afternoon"));
                t = Convert.ToString(view.GetFocusedRowCellValue("Evening"));
                
                if (view.FocusedColumn.FieldName == "Morning")
                {
                    if (view.GetFocusedRowCellValue(col_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(e.Value.ToString());
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(col_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(col_Quantity, 1);
                            decimal s1 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Amount, s1);
                            s = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Noon")
                {
                    if (view.GetFocusedRowCellValue(col_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(e.Value.ToString());
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(col_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(col_Quantity, 1);
                            decimal s2 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Amount, s2);

                            tr = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Afternoon")
                {
                    if (view.GetFocusedRowCellValue(col_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(e.Value.ToString());
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(col_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(col_Quantity, 1);
                            decimal s3 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Amount, s3);
                            c = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Evening")
                {
                    if (view.GetFocusedRowCellValue(col_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(e.Value.ToString());
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(col_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(col_Quantity, 1);
                            decimal s4 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Amount, s4);
                            t = e.Value.ToString();
                        }
                    }
                }

                if (s.ToString() != string.Empty && s.ToString() != "0")
                    strUsed = "Sáng " + s.ToString();
                if (tr.ToString() != string.Empty && tr.ToString() != "0")
                    strUsed += ",Trưa " + tr.ToString();
                if (c.ToString() != string.Empty && c.ToString() != "0")
                    strUsed += ",Chiều " + c.ToString();
                if (t.ToString() != string.Empty && t.ToString() != "0")
                    strUsed += ",Tối " + t.ToString();
                ///strUsed = "Sáng " + s.ToString() + ", Trưa " + tr.ToString() + ", Chiều " + c.ToString() + ", Tối " + t.ToString();
                ///view.SetFocusedRowCellValue(col_Instruction, strUsed);
                if (view.FocusedColumn.FieldName == "Quantity")
                {
                    if (view.GetFocusedRowCellValue(col_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal totalQuantity = ParseQuantity(e.Value.ToString());
                            decimal s5 = Convert.ToDecimal(totalQuantity * unitprice);
                            view.SetFocusedRowCellValue(col_Amount, s5);
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "DateOfIssues")
                {
                    if (view.GetFocusedRowCellValue(col_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(e.Value);
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));

                            if (converted_Medi)
                                view.SetFocusedRowCellValue(col_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(col_Quantity, 1);
                            decimal s0 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Amount, s0);
                        }
                    }
                }
            }
            catch { }
        }

        private void repSearchBHYT_ItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string itemCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemCode").ToString();
                string activeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active").ToString();
                decimal amountEndTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("AmountEnd").ToString());
                decimal safelyQuantityTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SafelyQuantity").ToString());
                string unitOfMeasureCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode").ToString();
                string repositoryNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryName").ToString();
                string repositoryCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryCode").ToString();
                string repositoryGroupCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryGroupCode").ToString();
                decimal bhytPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("BHYTPrice").ToString());
                decimal salesPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice").ToString());
                Int32 rateBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("RateBHYT").ToString());
                Int32 listBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("ListBHYT").ToString());
                string itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
                string noteTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Note").ToString();
                string usageCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UsageCode").ToString();
                string unitOfMeasureCode_MediTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode_Medi").ToString();
                bool converted_MediTemp = Convert.ToBoolean(searchEdit.Properties.View.GetFocusedRowCellValue("Converted_Medi"));
                bool bCheckActice = true;
                DataRow r = Utils.GetPriceRowbyCode(dtMedicalRecord, "ItemCode='" + itemCodeTemp + "' and RepositoryCode='" + repositoryCodeTemp + "'");
                if (bCheckActice)
                {
                    string sErrorActive = string.Empty;
                    List<Items_View> lstActive = new List<Items_View>();
                    if (activeTemp != string.Empty)
                    {
                        lstActive = ItemsBLL.ListItemsForActive(activeTemp, itemCodeTemp, dtMedicalRecord);
                        foreach (var v in lstActive)
                        {
                            sErrorActive += v.ItemName + ":" + v.Active + "\n";
                        }
                        if (sErrorActive != string.Empty)
                        {
                            XtraMessageBox.Show(" Thuốc có hoạt chất trùng với thuốc : \n" + sErrorActive, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return;
                        }
                    }
                }
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê trong toa thuốc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Prescription.SetFocusedRowCellValue(this.col_ItemCode, null);
                    this.gridView_Prescription.SetFocusedRowCellValue(this.col_Quantity, 0);
                }
                else
                {
                    if (amountEndTemp <= safelyQuantityTemp)
                    {
                        if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục cho thuốc ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            this.gridView_Prescription.SetFocusedRowCellValue(col_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_RepositoryCode, repositoryCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_RepositoryName, repositoryNameTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_ItemName, itemNameTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_Instruction, noteTemp);
                            decimal s1 = 0;
                            if (listBHYTTemp.Equals(1) && this.iObjectCode.Equals(1))
                            {
                                this.gridView_Prescription.SetFocusedRowCellValue(col_Unit_Price, bhytPriceTemp);
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 1);
                                s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * bhytPriceTemp;
                            }
                            else
                            {
                                if (!this.iObjectCode.Equals(1))
                                    this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, this.iObjectCode);
                                else
                                    this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 2);
                                this.gridView_Prescription.SetFocusedRowCellValue(col_Unit_Price, salesPriceTemp);
                                s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * salesPriceTemp;
                            }
                            this.gridView_Prescription.SetFocusedRowCellValue(col_Amount, s1);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_RepositoryGroupCode, repositoryGroupCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_Usage, usageCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_UnitOfMeasureCode_Medi, unitOfMeasureCode_MediTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Converted_Medi, converted_MediTemp);
                        }
                        return;
                    }
                    else if (amountEndTemp == 0)
                    {
                        XtraMessageBox.Show(" Thuốc trong kho đã hết!\t\n Xin vui lòng kê thuôc khác ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        this.gridView_Prescription.SetFocusedRowCellValue(col_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_Unit_Price, bhytPriceTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_RepositoryCode, repositoryCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_RepositoryName, repositoryNameTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_ItemName, itemNameTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_Instruction, noteTemp);
                        decimal s1 = 0;
                        if (listBHYTTemp.Equals(1) && this.iObjectCode.Equals(1))
                        {
                            this.gridView_Prescription.SetFocusedRowCellValue(col_Unit_Price, bhytPriceTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 1);
                            s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * bhytPriceTemp;
                        }
                        else
                        {
                            if (!this.iObjectCode.Equals(1))
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, this.iObjectCode);
                            else
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 2);
                            this.gridView_Prescription.SetFocusedRowCellValue(col_Unit_Price, salesPriceTemp);
                            s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * salesPriceTemp;
                        }
                        this.gridView_Prescription.SetFocusedRowCellValue(col_Amount, s1);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_RepositoryGroupCode, repositoryGroupCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(col_Usage, usageCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_UnitOfMeasureCode_Medi, unitOfMeasureCode_MediTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_Converted_Medi, converted_MediTemp);
                    }
                }
                this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
            }
            catch { }
        }
                
    }
}