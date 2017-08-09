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
    public partial class frmCapToaVe : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userCode = string.Empty;
        private string patientCode = string.Empty;
        private Int32 iPaid = 0, iPatientType = 0, iStatus = 0;
        private string medicalCode = string.Empty;
        private string bankCode = string.Empty;
        private string exportCode = string.Empty;
        private string strUsed, firstRowUsageGuide = string.Empty;
        private string firstRowUOM = string.Empty;
        private string s, tr, c, t = string.Empty;
        private decimal ReceiveID = 0;
        private string s_makp = string.Empty, emergencyCode = string.Empty;
        private int iObjectCode = 0;
        private DataTable dtMedicalRecord = new DataTable();
        private DataTable tableItemOut = new DataTable();
        private DateTime dtServer;
        private DataView dataViewItem = null;
        private string shiftWork = string.Empty;
        private string diagnosisCustom = string.Empty;
        private string symptoms = string.Empty;
        private string treatments = string.Empty;
        private DataTable tableICD10kemtheo = new DataTable();
        private DateTime dtWorking = new DateTime();
        private string employeeCodeDoctorRpository = string.Empty;
        public frmCapToaVe(string smakp, string suserCode, string _emergencyCode, string _patitentCode, Int32 _patientType, Int32 _paid, decimal _patientReceiveID, Int32 _objectCode, string _shiftWork, DataTable _tableICD10kemtheo, string _diagnosisCustom, string _symptoms, string _treatments, DateTime _dtWorking)
        {
            InitializeComponent();
            this.s_makp = smakp;
            this.s_userCode = suserCode;
            this.patientCode = _patitentCode;
            this.iPatientType = _patientType;
            this.iPaid = _paid;
            this.ReceiveID = _patientReceiveID;
            this.iObjectCode = _objectCode;
            this.emergencyCode = _emergencyCode;
            this.shiftWork = _shiftWork;
            this.tableICD10kemtheo = _tableICD10kemtheo;
            this.diagnosisCustom = _diagnosisCustom;
            this.symptoms = _symptoms;
            this.treatments = _treatments;
            this.dtWorking = _dtWorking;
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
        
        private void frmCapToaVe_Load(object sender, EventArgs e)
        {
            try
            {
                this.medicalCode = MedicalRecord_BLL.refMedicalCode(this.ReceiveID, this.patientCode, this.s_makp, this.emergencyCode, ref iStatus, ref iPaid, ref bankCode);
                List<UnitOfMeasureInf> lstUnitOf = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.refUoM.DataSource = lstUnitOf;
                this.refUoM.DisplayMember = "UnitOfMeasureName";
                this.refUoM.ValueMember = "UnitOfMeasureCode";

                this.replkup_ObjectCode.DataSource = ObjectBLL.DTObjectListNotIn(5);
                this.replkup_ObjectCode.DisplayMember = "ObjectName";
                this.replkup_ObjectCode.ValueMember = "ObjectCode";

                this.repSlkup_UnitOfMeasureCode_Medi.DataSource = lstUnitOf;
                this.repSlkup_UnitOfMeasureCode_Medi.DisplayMember = "UnitOfMeasureName";
                this.repSlkup_UnitOfMeasureCode_Medi.ValueMember = "UnitOfMeasureCode";

                this.repUsage.DataSource = UsageBLL.ListUsage(string.Empty);
                this.repUsage.DisplayMember = "UsageName";
                this.repUsage.ValueMember = "UsageCode";
                this.txtToamau.Properties.DataSource = SamplePrescriptionHeader_BLL.ListAll();
                this.txtToamau.Properties.DisplayMember = "SamplePrescriptionName";
                this.txtToamau.Properties.ValueMember = "SamplePrescriptionCode";
                List<InstructionInf> lstInstruc = InstructionBLL.ListInstruction(0);
                foreach (var v in lstInstruc)
                {
                    this.refInstruction.Items.Add(v.InstructionName);
                }
                List<AdvicesInf> lstAdvices = AdvicesBLL.ListAdvices(0);
                foreach (var v in lstAdvices)
                {
                    this.txtLoidan.Properties.Items.Add(v.AdvicesName);
                }
                this.LoadRepository();
                if (this.dtMedicalRecord.Rows.Count > 0)
                {
                    this.butSave.Enabled = this.butNew.Enabled = this.txtNgayTaiKham.Enabled = false;
                    this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                }
                else
                {
                    this.EnableText(false);
                    this.butNew.Enabled = true;
                    this.butSave.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = this.txtNgayTaiKham.Enabled = false;
                }
                MedicalRecord_INF objMedical = MedicalRecord_BLL.ObjMedicalRecordForReceiveID(ReceiveID, s_makp);
                if (objMedical != null && objMedical.PatientReceiveID > 0)
                    this.txtLoidan.EditValue = objMedical.Advices;
                if (objMedical != null && objMedical.PatientReceiveID > 0 && objMedical.AppointmentDate.ToString().Substring(0, 10) != "01/01/0001" && objMedical.AppointmentDate.ToString().Substring(0, 10) != "01/01/1900")
                    this.txtNgayTaiKham.EditValue = objMedical.AppointmentDate;
                this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                this.gridView_Prescription.OptionsBehavior.Editable = false;
                this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.GetInfoPatient(patientCode);
                this.Load_TreeView();
                if (!this.iObjectCode.Equals(1))
                    this.butPrintBlank.Enabled = false;
                this.dtServer = Utils.DateTimeServer();
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Lỗi phát sinh khi cấp toa\t\n-Liên hệ admin để kiểm tra lỗi: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Restart();
            }
        }

        public void EnableText(bool ena)
        {
            this.txtNgayCap.Properties.ReadOnly = this.txtToamau.Properties.ReadOnly = this.txtLoidan.Properties.ReadOnly = !ena;
        }

        public void EnableButton(bool b)
        {
            this.butEdit.Enabled = this.butPrintPrescription.Enabled = b;
            this.butSave.Enabled = this.butUndo.Enabled = this.txtNgayTaiKham.Enabled = !b;
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
                
        private void frmCapToaVe_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2: this.butNew_Click(sender, e); break;                   //F2 - Thêm mới
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
                    modelRecord.MedicalRecordCode = this.medicalCode;
                    modelRecord.PatientReceiveID = this.ReceiveID;
                    modelRecord.PatientCode = this.patientCode;
                    modelRecord.DepartmentCode = this.s_makp;
                    modelRecord.EmployeeCode = this.s_userCode;
                    modelRecord.PostingDate = Utils.DateTimeServer();
                    modelRecord.ReferenceCode = this.emergencyCode;
                    modelRecord.Status = this.iStatus;
                    modelRecord.ObjectCode = this.iObjectCode;
                    modelRecord.DiagnosisEnclosed = -1;
                    if (!string.IsNullOrEmpty(this.txtNgayTaiKham.Text))
                        modelRecord.AppointmentDate = Convert.ToDateTime(this.txtNgayTaiKham.Text);
                    else
                        modelRecord.AppointmentDate = Convert.ToDateTime("01/01/1900");
                    modelRecord.EmployeeCodeDoctor = this.s_userCode;
                    modelRecord.Advices = this.txtLoidan.Text;
                    modelRecord.Symptoms = this.symptoms;
                    modelRecord.ContentMedicalPattern = string.Empty;
                    modelRecord.ShiftWork = this.shiftWork;
                    modelRecord.Treatments = this.treatments;
                    modelRecord.DiagnosisCustom = this.diagnosisCustom;
                    int iResult = MedicalRecord_BLL.InsMedicalRecord_Emergency(modelRecord, ref medicalCode);
                    if (iResult == 1)
                    {
                        if (this.txtNgayTaiKham.EditValue != null && this.txtNgayTaiKham.Text != "01/01/1990")
                        {
                            PatientAppointment_INF mApp = new PatientAppointment_INF();
                            mApp.PatientCode = this.patientCode;
                            mApp.ExaminationDate = this.dtServer;
                            mApp.AppointmentDate = Convert.ToDateTime(this.txtNgayTaiKham.EditValue);
                            mApp.EmloyeeCode = this.s_userCode;
                            mApp.PatientReceiveID = this.ReceiveID;
                            mApp.AppointmentNote = string.Empty;
                            mApp.STT = 0;
                            PatientAppointment_BLL.Ins(mApp);
                        }
                        //else
                        //{
                        //    PatientAppointment_INF mApp = new PatientAppointment_INF();
                        //    mApp.PatientCode = this.patientCode;
                        //    mApp.ExaminationDate = this.dtServer;
                        //    mApp.AppointmentDate = Convert.ToDateTime("01/01/1990");
                        //    mApp.EmloyeeCode = this.s_userCode;
                        //    mApp.PatientReceiveID = this.ReceiveID;
                        //    mApp.AppointmentNote = string.Empty;
                        //    mApp.STT = 0;
                        //    PatientAppointment_BLL.Ins(mApp);
                        //}
                        decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                        bool bcheckInventory = true;
                        bool bcheckQuantity = true;
                        string msgError = string.Empty, sMsgErrorQuantity = string.Empty;
                        foreach (DataRow r in this.dtMedicalRecord.Rows)
                        {
                            dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                            dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, r["RepositoryCode"].ToString(), ref dAmountEnd);
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
                        if (!bcheckQuantity)
                        {
                            message = " Những thuốc sau chưa nhập số lượng \n\t" + sMsgErrorQuantity;
                            resultSave = false;
                        }
                        else if (bcheckInventory)
                        {
                            MedicalRecord_BLL.DelMedicalRecordDetail(medicalCode, -1, this.iObjectCode == 1 ? 1 : 0);
                            foreach (DataRow r in this.dtMedicalRecord.Rows)
                            {
                                if (r["Status"].ToString() == "0")
                                {
                                    MedicalPrescriptionDetail_INF mDetail = new MedicalPrescriptionDetail_INF();
                                    mDetail.MedicalRecordCode = medicalCode;
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
                                    mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                    mDetail.DoseOf = 0;
                                    mDetail.DoseOfPills = string.Empty;
                                    if (this.iObjectCode.Equals(1))
                                        mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                    else
                                        mDetail.ObjectCode = this.iObjectCode;
                                    //if (r["RepositoryGroupCode"].ToString() == "4")
                                    //    mDetail.BHYT = 0;
                                    //else
                                    //    mDetail.BHYT = 1;
                                    if (!mDetail.ObjectCode.Equals(1))
                                        mDetail.BHYT = 0;
                                    else
                                        mDetail.BHYT = 1;
                                    mDetail.UnitOfMeasureCode_Medi = r["UnitOfMeasureCode_Medi"].ToString();
                                    MedicalRecord_BLL.InsMedicalRecordDetail(mDetail, this.iObjectCode);
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

        private void PrintPrescription()
        {
            try
            {
                //DataTable dtClinic = new DataTable("ClinicInfo");
                //dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtMedicalRecordPrint = new DataTable("ResultMedicalRecord");
                dtMedicalRecordPrint = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.ReceiveID, 0);
                DataTable dtMedicalDetail = new DataTable("ResultMedicalDetail");
                dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalCode, "2", iObjectCode, 0, -1); //-1 in tat ca cac thuoc trong toa
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.ReceiveID);
                    DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.ReceiveID);
                    DataSet dsTemp = new DataSet("Result");
                    DataTable dtICD10kt = new DataTable();
                    dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    if (this.tableICD10kemtheo != null && this.tableICD10kemtheo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in this.tableICD10kemtheo.Rows)
                        {
                            sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                        }
                    }
                    dtICD10kt.Rows.Add(sICD10kt);
                    dsTemp.Tables.Add(dtMedicalRecordPrint);
                    dsTemp.Tables.Add(dtMedicalDetail);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtBHYT);
                    dsTemp.Tables.Add(dtICD10kt);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToathuoc.xml");
                    Reports.rpt_KB_Toathuoc rptShow = new Reports.rpt_KB_Toathuoc(this.dtServer, this.dtWorking);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Toathuoc", "Toa thuốc");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = 3;
        }

        private void PrintPrescription_Out()
        {
            try
            {
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Clear();
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtMedicalRecord = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.ReceiveID, 0);
                DataTable dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalCode, "4", iObjectCode, 1, -1); //-1 in tat ca thuoc co trong kho
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.emergencyCode, this.patientCode, this.ReceiveID);

                    DataTable dtICD10kt = new DataTable();
                    dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    if (this.tableICD10kemtheo != null && this.tableICD10kemtheo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in this.tableICD10kemtheo.Rows)
                        {
                            sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                        }
                    }
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
                    this.txtToamau.Properties.ReadOnly = false;
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
                this.txtToamau.Properties.ReadOnly = true;
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
                this.butUndo.Enabled = this.butSave.Enabled = this.txtNgayTaiKham.Enabled = false;
                this.butEdit.Enabled = this.butPrintPrescription.Enabled = true;
                this.butNew.Enabled = true;
                this.txtToamau.Properties.ReadOnly = true;
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
                if (this.SaveMedical(ref error, true))
                {
                    XtraMessageBox.Show(" Lưu toa thuốc thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.EnableText(false);
                    this.EnableButton(true);
                    this.butNew.Enabled = false;
                    this.LoadRepository();
                    if (this.tableItemOut.Rows.Count > 0)
                    {
                        this.butSave.Enabled = this.butNew.Enabled = this.txtNgayTaiKham.Enabled = false;
                        this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                    }
                    else
                    {
                        this.EnableText(false);
                        this.butNew.Enabled = true;
                        this.butSave.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = this.txtNgayTaiKham.Enabled = false;
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

        private void butNew_Click(object sender, EventArgs e)
        {
            this.gridView_Prescription.OptionsBehavior.ReadOnly = false;
            this.gridView_Prescription.OptionsBehavior.Editable = true;
            this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.LoadRepository();
            this.txtToamau.EditValue = null;
            this.txtToamau.Properties.ReadOnly = false;
            this.EnableText(true);
            this.EnableButton(false);
            this.butNew.Enabled = false;
        }

        private void LoadRepository()
        {
            
            this.tableItemOut.Clear();
            string repositoryGroup = "2,4";
            if (!this.iObjectCode.Equals(1))
                repositoryGroup = "4";
            //this.tableItemOut = ItemsBLL.Table_ListItemsRef(0, this.s_makp, repositoryGroup, this.iObjectCode);
            DataTable tableRepTemp = ItemsBLL.Table_ListItemsRef(0, this.s_makp, repositoryGroup, this.iObjectCode);
            if (tableRepTemp.Select(this.employeeCodeDoctorRpository).Length > 0)
                this.tableItemOut = tableRepTemp.Select(this.employeeCodeDoctorRpository).CopyToDataTable();
            else
                this.tableItemOut = tableRepTemp.Clone();

            this.repSearchBHYT_ItemCode.DataSource = this.tableItemOut;
            this.repSearchBHYT_ItemCode.DisplayMember = "ItemName";
            this.repSearchBHYT_ItemCode.ValueMember = "ItemCode";
            int status = 0;
            this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalRecord(this.medicalCode, this.iObjectCode, this.s_makp, repositoryGroup, status);
            this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
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

        private void txtNgayCap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtNgayTaiKham.EditValue = DateTime.Now.AddDays(Convert.ToDouble(this.txtNgayCap.EditValue));
                if (this.gridView_Prescription.RowCount > 0)
                {
                    this.gridView_Prescription.SetRowCellValue(this.gridView_Prescription.FocusedRowHandle, col_Date_Of_Issues, Convert.ToDecimal(this.txtNgayCap.Value));
                    this.gridView_Prescription.SetRowCellValue(this.gridView_Prescription.FocusedRowHandle, col_Quantity, Convert.ToDecimal(this.txtNgayCap.Value) * (Convert.ToDecimal(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, "Morning")) + Convert.ToDecimal(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, "Noon")) + Convert.ToDecimal(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, "Afternoon")) + Convert.ToDecimal(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, "Evening"))));
                    decimal amount = Convert.ToDecimal(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, col_Quantity)) * Convert.ToDecimal(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, this.col_Unit_Price));
                    this.gridView_Prescription.SetRowCellValue(this.gridView_Prescription.FocusedRowHandle, col_Amount, amount);
                }
            }
            catch
            {
                return;
            }
        }
                
        private void txtNgayCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.gridView_Prescription.Focus();
            }
        }

        private void txtToamau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void Load_TreeView()
        {
            try
            {
                treeHistory.Nodes.Clear();
                TreeNode node, node1;
                DataTable dtHis = MedicalRecord_BLL.DT_Get_PrescriptionsOldFor(patientCode, ReceiveID, emergencyCode);
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

        private void txtToamau_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.txtToamau.EditValue != null)
                //{
                //    int j = 0;
                //    while (gridView_Prescription.RowCount != 0)
                //    {
                //        this.gridView_Prescription.FocusedRowHandle = j;
                //        this.gridView_Prescription.DeleteSelectedRows();
                //    }
                //    var line = SamplePrescriptionLine_BLL.ListForHederCode_Price(this.txtToamau.EditValue.ToString());
                //    foreach (var v in line)
                //    {
                //        foreach (DataRow dr in tableItemOut.Rows)
                //        {
                //            this.dtMedicalRecord.Rows.Add(this.medicalCode, v.ItemCode, v.DateOfIssues, v.Morning, v.Noon, v.Afternoon, v.Evening, v.Quantity, v.Instruction, v.UnitPrice, (v.Quantity * v.UnitPrice), 0, dr["UnitOfMeasureCode"].ToString(), dr["RepositoryCode"].ToString(), dr["RepositoryName"].ToString(), v.ItemName, v.SalesPrice, v.BHYTPrice, v.RateBHYT, string.Empty, Utils.DateServer(), 0, this.iObjectCode, string.Empty);
                //        }
                //    }
                //    this.gridControl_Prescription.DataSource = dtMedicalRecord;
                //}

                if (this.txtToamau.EditValue != null)
                {
                    decimal unitPriceTemp = 0, amountEndTemp = 0, safelyQuantityTemp = 0;
                    string repositoryNameTemp = string.Empty, repositoryCodeTemp = string.Empty;
                    Int32 repositoryGroupCodeTemp = 0;
                    this.dtMedicalRecord.Clear();
                    int objectCodeTemp = this.iObjectCode;
                    var line = SamplePrescriptionLine_BLL.ListForHederCode_Price(this.txtToamau.EditValue.ToString());
                    string messageDrugError = string.Empty;
                    foreach (var v in line)
                    {
                        this.txtNgayCap.EditValue = v.DateOfIssues;
                        DataRow row = null;
                        if (this.iObjectCode.Equals(1))
                            row = Utils.GetPriceRowbyCode(this.tableItemOut, "ItemCode='" + v.ItemCode + "' and ListBHYT=1");
                        if (row == null)
                        {
                            row = Utils.GetPriceRowbyCode(this.tableItemOut, "ItemCode='" + v.ItemCode + "' and AmountEnd >0 and ListService=1");
                            objectCodeTemp = 2;
                        }
                        if (row != null)
                        {
                            safelyQuantityTemp = Convert.ToDecimal(row[8].ToString());
                            amountEndTemp = Convert.ToDecimal(row[14].ToString());
                            repositoryNameTemp = row[13].ToString();
                            repositoryCodeTemp = row[12].ToString();
                            repositoryGroupCodeTemp = Convert.ToInt32(row[18].ToString());
                            string morningtemp = v.Morning == 0 ? string.Empty : v.Morning.ToString();
                            string noontemp = v.Noon == 0 ? string.Empty : v.Noon.ToString();
                            string afternoontemp = v.Afternoon == 0 ? string.Empty : v.Afternoon.ToString();
                            string evening = v.Evening == 0 ? string.Empty : v.Evening.ToString();

                            if (this.iObjectCode.Equals(1))
                                unitPriceTemp = v.BHYTPrice;
                            else
                                unitPriceTemp = v.SalesPrice;
                            this.dtMedicalRecord.Rows.Add(medicalCode, v.ItemCode, v.DateOfIssues, morningtemp, noontemp, afternoontemp, evening, v.Quantity, v.Instruction, unitPriceTemp, (v.Quantity * unitPriceTemp), 0, v.UnitOfMeasure, repositoryCodeTemp, repositoryNameTemp, v.ItemName, 0, v.DateOfIssues, string.Empty, objectCodeTemp, v.RateBHYT, repositoryGroupCodeTemp, v.UsageCode, string.Empty, v.UnitOfMeasureCode_Medi, v.Converted_Medi);
                        }
                        else
                        {
                            messageDrugError += v.ItemName + "; ";
                        }
                    }
                    if (!string.IsNullOrEmpty(messageDrugError))
                        XtraMessageBox.Show("Những thuốc sau tồn kho đã hết: " + messageDrugError.TrimEnd(';'), "Bệnh Viện Điện Tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
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
                            if (MedicalRecord_BLL.DelMedicalRecordDetail(medicalCode, dRowID, this.iObjectCode == 1 ? 1 : 0) != 1)
                            {
                                bResult = false;
                                itemNameTemp += dr["ItemName"].ToString() + ";";
                            }
                        }
                    }
                    if (bResult)
                    {
                        XtraMessageBox.Show(" Đã hủy phiếu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadRepository();
                        if (this.dtMedicalRecord.Rows.Count > 0)
                        {
                            this.butSave.Enabled = this.butNew.Enabled = false;
                            this.butEdit.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                        }
                        else
                        {
                            this.EnableText(false);
                            this.butNew.Enabled = true;
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
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, col_Date_Of_Issues, this.txtNgayCap.EditValue);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, col_Quantity, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, col_Unit_Price, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, col_Amount, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, col_Stutus, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, col_MedicalRecordCode, this.medicalCode);
                }
                else
                {
                    return;
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
                            MedicalRecord_BLL.DelMedicalRecordDetailForItemCode(this.medicalCode, itemCodeTemp);
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

        private void gridViewBHYT_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 listBHYT = 0;
                if (e.RowHandle >= 0)
                {
                    listBHYT = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ListBHYT"]));
                    if (listBHYT.Equals(0))
                        e.Appearance.ForeColor = Color.Blue;
                }
            }
            catch { }
        }

        private void butPrintBlank_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMedicalRecordPrint = MedicalRecord_BLL.DT_GetResultMedical(this.emergencyCode, this.ReceiveID, 1);
                DataTable dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.emergencyCode, "2", this.iObjectCode, 0, -1);//-1 in tat ca thuoc trong toa

                DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.emergencyCode, this.patientCode, this.ReceiveID);
                DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.ReceiveID);
                DataSet dsTemp = new DataSet("Result");
                DataTable dtICD10kt = new DataTable();
                dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                string sICD10kt = string.Empty;
                foreach (DataRow dr in this.tableICD10kemtheo.Rows)
                {
                    sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                }
                dtICD10kt.Rows.Add(sICD10kt);
                dsTemp.Tables.Add(dtMedicalRecordPrint);
                dsTemp.Tables.Add(dtMedicalDetail);
                dsTemp.Tables.Add(dtSurviveSign);
                dsTemp.Tables.Add(dtBHYT);
                dsTemp.Tables.Add(dtICD10kt);
                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToathuoc.xml");
                Reports.rptToathuocBlank rptShow = new Reports.rptToathuocBlank(this.dtServer, this.dtWorking);
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Toathuoc", "Toa thuốc");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
    }
}