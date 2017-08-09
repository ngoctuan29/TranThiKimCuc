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
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraRichEdit.API.Native;
using iHISDrugInformation;
using DevExpress.Utils.Win;

namespace Ps.Clinic.Entry
{
    public partial class frmKhamBenh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userCode = string.Empty;
        private string patientCode = string.Empty;
        private string sServiceName = string.Empty, sServiceCode = string.Empty;
        private int iStatusrv = 0, iTypePatient = 1;
        private string medicalCode = string.Empty;
        private string bankCode = string.Empty;
        private string exportCode = string.Empty;
        private string strUsed, firstRowUsageGuide = string.Empty;
        private string firstRowUOM = string.Empty;
        private string bs = string.Empty, s = string.Empty, btr = string.Empty, tr = string.Empty, bc = string.Empty, c = string.Empty, bt = string.Empty, t = string.Empty;
        private decimal patientReceiveID = 0, suggestedID = 0;
        private string s_makp = string.Empty;
        private int iObjectCode = 0, iCheckCard = 0;
        private DataTable dtMedicalRecord = new DataTable();
        private string cardBHYT = string.Empty;
        private int iTraituyen = 0;
        private string refCode = string.Empty;
        private DataTable dtICD10KT = new DataTable("ICD10");
        private DataTable lstItem = new DataTable();
        private DataView clonebhyt = null;
        private string sDepartmentName = string.Empty;
        private bool bCheckActice = true;
        private DateTime dtWorking = new DateTime();
        private DateTime dtServer = new DateTime();
        private List<DiagnosisAbbreviationsInf> listAbbre;
        public string employeeCodeDoctor = string.Empty;
        private string shiftWork = string.Empty;
        private bool bEditEmployeeDoctor = false;
        private MedicalRecord_ANCINF sokhamthai = new MedicalRecord_ANCINF();
        private MedicalRecord_AbortionsINF sophathai = new MedicalRecord_AbortionsINF();
        private MedicalRecord_ChildbirthINF sode = new MedicalRecord_ChildbirthINF();
        private string employeeCodeDoing = string.Empty;
        private bool isTuongTacThuoc = false;
        private List<DiagnosisInf> lstDiagnosis = new List<DiagnosisInf>();
        private string employeeCodeDoctorRpository = string.Empty;
        public frmKhamBenh(string smakp, string suserCode, string _DepartmentName, string _employeeCodeDoctor, string _shiftWork, string _employeeCodeDoing, DateTime _dtimePosting)
        {
            InitializeComponent();
            this.s_makp = smakp;
            this.s_userCode = suserCode;
            this.sDepartmentName = _DepartmentName;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.shiftWork = _shiftWork;
            this.employeeCodeDoing = _employeeCodeDoing;
            this.dtWorking = _dtimePosting;
            this.grWaitingList.Visible = true;
            this.grWaitingList.Dock = DockStyle.Fill;
            this.panelControl3.Visible = false;
            this.panelControl3.Dock = DockStyle.None;
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
        public void LoadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(500);
            if (objSys != null && objSys.RowID > 0)
            {
                this.gridControl_WaitingList.DataSource = PatientReceiveBLL.TablePatientWaiting(Convert.ToDateTime(this.dtimeFromDate.EditValue), Convert.ToDateTime(this.dtimeToDate.EditValue), iStatus, 1, s_makp, objSys.Values, this.employeeCodeDoctor);
            }
            else
                this.gridControl_WaitingList.DataSource = null;
        }
        private void frmKhamBenh_Load(object sender, EventArgs e)
        {
            try
            {
                this.butNew.Enabled = this.butSave.Enabled = this.butSoKB.Enabled = this.butEdit.Enabled = this.butEdit.Enabled = this.picTotal.Enabled = false;
                this.ref_Department.DataSource = DepartmentBLL.ListDepartment(string.Empty);
                this.ref_Department.ValueMember = "DepartmentCode";
                this.ref_Department.DisplayMember = "DepartmentName";
                List<SymptomsInf> lstSym = SymptomsBLL.ListSymptoms(0);
                foreach (var v in lstSym)
                {
                    this.txtTrieuChung.Properties.Items.Add(v.SymptomsName);
                }
                this.lstDiagnosis = DiagnosisBLL.ListDiagnosis(0);

                this.txtChandoankemtheo.Properties.DataSource = DiagnosisBLL.ListDiagnosisName();
                this.txtChandoankemtheo.Properties.DisplayMember = "DiagnosisName";
                this.txtChandoankemtheo.Properties.ValueMember = "RowID";

                this.replkup_ObjectCode.DataSource = ObjectBLL.DTObjectListNotIn(5);
                this.replkup_ObjectCode.DisplayMember = "ObjectName";
                this.replkup_ObjectCode.ValueMember = "ObjectCode";
                //DataTable tableDiagnosis = DiagnosisCustomBLL.TableDiagnosisCustom(0);
                //foreach (DataRow row in tableDiagnosis.Rows)
                //    this.cboxDiagnosis.Properties.Items.Add(row["DiagnosisName"].ToString());

                this.txtXutri.Properties.DataSource = Tackle_BLL.ListTackle();
                this.txtXutri.Properties.DisplayMember = "TackleName";
                this.txtXutri.Properties.ValueMember = "TackleCode";
                List<AdvicesInf> lstAdvices = AdvicesBLL.ListAdvices(0);
                foreach (var v in lstAdvices)
                {
                    this.txtLoidan.Properties.Items.Add(v.AdvicesName);
                }
                List<UnitOfMeasureInf> lstUOM = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.refUoM.DataSource = lstUOM;
                this.refUoM.DisplayMember = "UnitOfMeasureName";
                this.refUoM.ValueMember = "UnitOfMeasureCode";

                this.repSlkup_UnitOfMeasureCode_Medi.DataSource = lstUOM;
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
                this.txtToamau.Properties.DataSource = SamplePrescriptionHeader_BLL.ListAll();
                this.txtToamau.Properties.DisplayMember = "SamplePrescriptionName";
                this.txtToamau.Properties.ValueMember = "SamplePrescriptionCode";
                this.dtICD10KT.Columns.Add("RowID", typeof(Int32));
                this.dtICD10KT.Columns.Add("DiagnosisName", typeof(string));
                this.EnableText(false);
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(207);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.bCheckActice = true;
                }
                objSys = SystemParameterBLL.ObjParameter(9);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.bEditEmployeeDoctor = true;
                }
                objSys = SystemParameterBLL.ObjParameter(12);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                    {
                        this.isTuongTacThuoc = true;
                        this.chkTT_ChatCoCon.Visible = this.chkTT_HutThuoc.Visible = this.chkTT_PNChoConBu.Visible = this.chkTT_PNMangThai.Visible = true;
                    }
                    else
                    {
                        this.isTuongTacThuoc = false;
                        this.chkTT_ChatCoCon.Visible = this.chkTT_HutThuoc.Visible = this.chkTT_PNChoConBu.Visible = this.chkTT_PNMangThai.Visible = false;
                    }
                }
                this.LoadPattern(0);
                this.dtimeFromDate.EditValue = this.dtimeToDate.EditValue = this.dtWorking;
                this.dtServer = Utils.DateTimeServer();
                this.LoadAbbre();
                this.LoadListPatientWaitingCompleted(0);
                this.picRelation.Enabled = false;
                this.picCaptureDocument.Enabled = false;
                this.btChangeDepart.Enabled = false;
                this.tabMedical.SelectedTabPageIndex = 1;
                this.chkBV01.Properties.ReadOnly = true;
                List<EmployeeInf> objEmployee = EmployeeBLL.ListEmployee(this.employeeCodeDoctor);
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
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void EnableText(bool ena)
        {
            this.txtLydokham.Properties.ReadOnly = this.txtTrieuChung.Properties.ReadOnly = this.lkupICD10.Properties.ReadOnly = this.txtChandoankemtheo.Properties.ReadOnly = this.txtXutri.Properties.ReadOnly = this.txtLoidan.Properties.ReadOnly = this.cboxDiagnosis.Properties.ReadOnly = !ena;
            this.txtMach.Properties.ReadOnly = this.txtHuyetap.Properties.ReadOnly = this.txtHuyetap1.Properties.ReadOnly = this.txtNhietdo.Properties.ReadOnly = this.txtNang.Properties.ReadOnly = this.txtCao.Properties.ReadOnly = !ena;
            this.txtGhichu.Properties.ReadOnly = this.txtNgayCap.Properties.ReadOnly = this.txtNgayCap.Properties.ReadOnly = this.txtNgayTaiKham.Properties.ReadOnly = this.txtAppointmentNote.Properties.ReadOnly = this.txtToacu.Properties.ReadOnly = this.txtToamau.Properties.ReadOnly = !ena;
            this.txtTiensubenh.Properties.ReadOnly = this.txtDiung.Properties.ReadOnly = this.memoTreatments.Properties.ReadOnly = !ena;
            this.lkupMedicalPattern.Properties.ReadOnly = !ena;
            if (this.isTuongTacThuoc)
                this.chkTT_ChatCoCon.ReadOnly = this.chkTT_HutThuoc.ReadOnly = this.chkTT_PNChoConBu.ReadOnly = this.chkTT_PNMangThai.ReadOnly = !ena;
            this.cbxHoSoKB.Properties.ReadOnly = !ena;
            this.txtMaICD10.Properties.ReadOnly = !ena;
            this.txtNameICD10.Properties.ReadOnly = !ena;
        }

        public void EnableButton(bool b)
        {
            this.butNew.Enabled = this.butEdit.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = this.butCancel.Enabled = this.butPrintBHYT.Enabled = this.chkBV01.Properties.ReadOnly = b;
            this.butSave.Enabled = this.butUndo.Enabled = this.picHSBA.Enabled = this.butHandPoint.Enabled = this.picXuatTuTruc.Enabled = this.butSoKB.Enabled = !b;
        }
        
        private decimal ParseQuantity(string qty)
        {
            decimal sl1 = 0;
            try
            {
                string[] arr;
                if (!string.IsNullOrEmpty(qty.Trim()))
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

        private void gridView_Prescription_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (ISDBNULL2STRING(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_ItemCode)).ToString(), string.Empty) == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ItemCode, "Nhập tên thuốc! ");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Quantity, "Số lượng yêu cầu lớn hơn 0 !");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Unit_Price)), 1) < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Unit_Price, "Chưa khai đơn giá cho thuốc!");
                }
                if (e.Valid && this.isTuongTacThuoc)
                {
                    DataTable tableTemp = new DataTable();
                    tableTemp = this.dtMedicalRecord.Copy();
                    DataRow rowNew = tableTemp.NewRow();
                    rowNew["MedicalRecordCode"] = this.medicalCode;
                    rowNew["ItemCode"] = view.GetRowCellValue(rowfocus, this.col_ItemCode);
                    rowNew["DateOfIssues"] = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Date_Of_Issues));
                    rowNew["Morning"] = view.GetRowCellValue(rowfocus, this.col_Morning).ToString();
                    rowNew["Noon"] = view.GetRowCellValue(rowfocus, this.col_Noon).ToString();
                    rowNew["Afternoon"] = view.GetRowCellValue(rowfocus, this.col_Afternoon).ToString();
                    rowNew["Evening"] = view.GetRowCellValue(rowfocus, this.col_Evening).ToString();
                    rowNew["Quantity"] = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Quantity).ToString());
                    rowNew["Instruction"] = view.GetRowCellValue(rowfocus, this.col_Instruction).ToString();
                    rowNew["UnitPrice"] = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Unit_Price).ToString());
                    rowNew["Amount"] = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Amount).ToString());
                    rowNew["Status"] = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Stutus).ToString());
                    rowNew["UnitOfMeasureCode"] = view.GetRowCellValue(rowfocus, this.col_UnitOfMeasureCode).ToString();
                    rowNew["RepositoryCode"] = view.GetRowCellValue(rowfocus, this.col_RepositoryCode).ToString();
                    rowNew["RepositoryName"] = view.GetRowCellValue(rowfocus, this.col_RepositoryName).ToString();
                    rowNew["ItemName"] = view.GetRowCellValue(rowfocus, this.col_ItemName).ToString();
                    if (!string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_RowID).ToString()))
                        rowNew["RowID"] = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_RowID));
                    else
                        rowNew["RowID"] = 0;
                    rowNew["DoseOf"] = 0;
                    rowNew["DoseOfPills"] = view.GetRowCellValue(rowfocus, this.col_DoseOfPills).ToString();
                    rowNew["ObjectCode"] = this.iObjectCode;
                    rowNew["RateBHYT"] = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_RateBHYT));
                    rowNew["RepositoryGroupCode"] = view.GetRowCellValue(rowfocus, this.col_RepositoryGroupCode).ToString();
                    rowNew["UsageCode"] = view.GetRowCellValue(rowfocus, this.col_UsageCode).ToString();
                    rowNew["SODKGP"] = view.GetRowCellValue(rowfocus, this.col_SODKGP).ToString();
                    tableTemp.Rows.Add(rowNew);
                    if (tableTemp.Rows.Count > 1)
                        this.CheckTuongTacThuoc(tableTemp);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

                            //if (s != string.Empty)
                            //{
                            //    bs = "Sáng " + firstRowUsageGuide + " " + s + " " + firstRowUOM + ", ";
                            //}
                            //else
                            //{
                            //    bs = "";
                            //}
                            //strUsed = Convert.ToString(bs.ToString());
                            //view.SetFocusedRowCellValue(col_Instruction, strUsed);
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
                            //if (tr != string.Empty)
                            //{
                            //    btr = "Trưa " + firstRowUsageGuide + " " + tr + " " + firstRowUOM + ", ";
                            //}
                            //else
                            //{
                            //    btr = "";
                            //}
                            //strUsed = Convert.ToString(bs.ToString() + btr.ToString());
                            //view.SetFocusedRowCellValue(col_Instruction, strUsed);
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
                            //if (c != string.Empty)
                            //{
                            //    bc = "Chiều " + firstRowUsageGuide + " " + c + " " + firstRowUOM + ", ";
                            //}
                            //else
                            //{
                            //    bc = "";
                            //}
                            //strUsed = Convert.ToString(bs.ToString() + btr.ToString() + bc.ToString());
                            //view.SetFocusedRowCellValue(col_Instruction, strUsed);
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
                            //if (t != string.Empty)
                            //{
                            //    bt = "Tối " + firstRowUsageGuide + " " + t + " " + firstRowUOM + ".";
                            //}
                            //else
                            //{
                            //    bt = "";
                            //}
                            //strUsed = Convert.ToString(bs.ToString() + btr.ToString() + bc.ToString() + bt.ToString());
                            //view.SetFocusedRowCellValue(col_Instruction, strUsed);
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
        
        private void gridView_Prescription_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (this.gridView_Prescription.GetFocusedRow() != null)
                {
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Date_Of_Issues, this.txtNgayCap.EditValue);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Quantity, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Unit_Price, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Amount, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_Stutus, 0);
                    this.gridView_Prescription.SetRowCellValue(e.RowHandle, this.col_MedicalRecordCode, this.medicalCode);
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error_gridView_Prescription_InitNewRow : " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void txtToacu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tableMedicalTemp = MedicalRecord_BLL.DTMedicalRecordOld(this.txtToacu.EditValue.ToString());
                decimal unitPriceTemp = 0, amountEndTemp = 0, safelyQuantityTemp = 0;
                string repositoryNameTemp = string.Empty, repositoryCodeTemp = string.Empty;
                Int32 repositoryGroupCodeTemp = 0;
                this.dtMedicalRecord.Clear();
                int objectCodeTemp = this.iObjectCode;
                if (tableMedicalTemp != null && tableMedicalTemp.Rows.Count > 0)
                {
                    foreach (DataRow r in tableMedicalTemp.Rows)
                    {
                        DataRow row = null;
                        if (this.iObjectCode.Equals(1))
                            row = Utils.GetPriceRowbyCode(this.lstItem, "ItemCode='" + r["ItemCode"].ToString() + "' and ListBHYT=1 and ListService=0");
                        if (row == null)
                        {
                            //row = Utils.GetPriceRowbyCode(this.lstItem, "ItemCode='" + r["ItemCode"].ToString() + "' and ListBHYT=0");
                            row = Utils.GetPriceRowbyCode(this.lstItem, "ItemCode='" + r["ItemCode"].ToString() + "'");
                            objectCodeTemp = 2;
                        }
                        if (row != null)
                        {
                            safelyQuantityTemp = Convert.ToDecimal(row[8].ToString());
                            amountEndTemp = Convert.ToDecimal(row[14].ToString());
                            repositoryNameTemp = row[13].ToString();
                            repositoryCodeTemp = row[12].ToString();
                            repositoryGroupCodeTemp = Convert.ToInt32(row[18].ToString());
                            if (this.iObjectCode.Equals(1))
                                unitPriceTemp = Convert.ToDecimal(r["BHYTPrice"].ToString());
                            else
                                unitPriceTemp = Convert.ToDecimal(r["SalesPrice"].ToString());
                            if (amountEndTemp <= safelyQuantityTemp)
                            {
                                if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục cho thuốc ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                                    this.dtMedicalRecord.Rows.Add(medicalCode, r["ItemCode"].ToString(), r["DateOfIssues"], r["Morning"].ToString(), r["Noon"].ToString(), r["Afternoon"].ToString(), r["Evening"].ToString(), r["Quantity"], r["Instruction"].ToString(), unitPriceTemp, (Convert.ToDecimal(r["Quantity"]) * unitPriceTemp), 0, r["UnitOfMeasureCode"].ToString(), repositoryCodeTemp, repositoryNameTemp, r["ItemName"].ToString(), 0, r["DateOfIssues"], string.Empty, objectCodeTemp, r["RateBHYT"], repositoryGroupCodeTemp, r["UsageCode"]);
                            }
                            else
                                this.dtMedicalRecord.Rows.Add(medicalCode, r["ItemCode"].ToString(), r["DateOfIssues"], r["Morning"].ToString(), r["Noon"].ToString(), r["Afternoon"].ToString(), r["Evening"].ToString(), r["Quantity"], r["Instruction"].ToString(), unitPriceTemp, (Convert.ToDecimal(r["Quantity"]) * unitPriceTemp), 0, r["UnitOfMeasureCode"].ToString(), repositoryCodeTemp, repositoryNameTemp, r["ItemName"].ToString(), 0, r["DateOfIssues"], string.Empty, objectCodeTemp, r["RateBHYT"], repositoryGroupCodeTemp, r["UsageCode"]);
                        }
                    }
                }
                this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
            }
            catch { }
        }

        private void frmKhamBenh_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: this.butReload_Click(sender, e); break;                //F5 - Refresh
                case Keys.F1: this.butContinues_Click(sender, e); break;             //F1 - Bệnh nhân tiếp
                case Keys.F2: this.butNew_Click(sender, e); break;                   //F2 - Doing
                case Keys.F3: this.butSave_Click(sender, e); break;                  //F3 - Lưu
                case Keys.F4: this.butEdit_Click(sender, e); break;                  //F4 - Edit
                case Keys.F6: this.butPrintBHYT_Click(sender, e); break;             //F6 - In toa
                case Keys.F7: this.butHandPoint_Click(sender, e); break;             //F7 - Chỉ định CLS
                case Keys.F12: this.picHSBA_Click(sender, e); break;                 //F12 - Xem HSBA
            }
        }

        private void txtTrieuchung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.memoTreatments.Focus();
        }
        
        private void txtLoidan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            } 
        }

        private void txtNgayTaiKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtAppointmentNote.Focus();
            }
        }

        private void txtGhichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTrieuChung.Focus();
        }

        private void txtNgayCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.repSearchBHYT_ItemCode.AllowFocused = true;
            }
        }

        private void txtLydokham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtGhichu.Focus();
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtHuyetap.Focus();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{Tab}{F4}");
                this.txtCao.Focus();
            }
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtHuyetap1.Focus();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtNangcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{Tab}{F4}");
                this.cboxDiagnosis.Focus();
            }
        }

        private void gridView_Prescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show(" Bạn có muốn xóa thuốc này hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        string status = ISDBNULL2STRING(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, this.col_Stutus).ToString(), string.Empty);
                        // string itemCodeTemp = this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, this.col_ItemCode).ToString();
                        int rowID = 0;
                        rowID = Convert.ToInt32(this.gridView_Prescription.GetRowCellValue(this.gridView_Prescription.FocusedRowHandle, this.col_RowID) ?? "0");
                        if (status != "1")
                        {
                            Int32 rowIndex = this.gridView_Prescription.GetVisibleIndex(this.gridView_Prescription.FocusedRowHandle);
                            //   MedicalRecord_BLL.DelMedicalRecordDetailForItemCode(this.medicalCode, itemCodeTemp);
                            MedicalRecord_BLL.DelMedicalRecordDetailForRowID(this.medicalCode, rowID);
                            this.gridView_Prescription.DeleteSelectedRows();
                          // this.dtMedicalRecord.DefaultView.Delete(rowIndex);
                            this.dtMedicalRecord.AcceptChanges();
                        }
                        else
                        {
                            XtraMessageBox.Show("Thuốc đang chọn đã duyệt cho bệnh nhân, không được xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void gridView_Prescription_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Toa thuốc bác sĩ kê thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private void rdWaiting_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdWaiting.Checked)
            {
                this.butNew.Enabled = true;
                this.LoadListPatientWaitingCompleted(0);
                this.btChangeDepart.Enabled = true;
            }
        }

        private void rdCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdCompleted.Checked)
            {
                this.butNew.Enabled = false;
                this.txtToacu.Properties.ReadOnly = true;
                this.txtToamau.Properties.ReadOnly = true;
                this.LoadListPatientWaitingCompleted(1);
                this.btChangeDepart.Enabled = true;
            }
        }

        private void butHandPoint_Click(object sender, EventArgs e)
        {
            string sError = string.Empty;
            if (this.SaveMedical(ref sError, false))
            {
                frmChiDinhDichVu form = new frmChiDinhDichVu(this.patientReceiveID, patientCode, s_userCode, iObjectCode, this.cardBHYT, iTraituyen, medicalCode, iTypePatient, s_makp, this.employeeCodeDoctor, this.sServiceCode, this.shiftWork, this.dtWorking);
                form.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(sError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool SaveMedical(ref string sMsg, bool saveItem)
        {
            try
            {
                //if (this.txtTrieuChung.EditValue == null || this.txtTrieuChung.Text.Trim().ToString() == "")
                //{
                //    //XtraMessageBox.Show(" Nhập triệu chứng bệnh! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    sMsg = "Nhập triệu chứng bệnh! ";
                //    this.txtTrieuChung.Focus();
                //    return false;
                //}
                //if (this.cboxDiagnosis.Text == null || string.IsNullOrEmpty(this.cboxDiagnosis.Text.Trim().ToString()))
                //{
                //    ///XtraMessageBox.Show(" Nhập chẩn đoán bệnh theo danh mục ICD-10 ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    sMsg = " Nhập chẩn đoán bệnh! ";
                //    this.cboxDiagnosis.Focus();
                //    return false;
                //}
                if (this.txtXutri.EditValue == null || this.txtXutri.Text.Trim().ToString() == "")
                {
                    sMsg = "Chọn xử trí khám bệnh !";
                    //XtraMessageBox.Show(" Chọn xử trí khám bệnh ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtXutri.Focus();
                    return false;
                }
                else
                {
                    bool resultSave = false;
                    MedicalRecord_INF modelRecord = new MedicalRecord_INF();
                    modelRecord.MedicalRecordCode = this.medicalCode;
                    modelRecord.PatientReceiveID = this.patientReceiveID;
                    modelRecord.PatientCode = this.patientCode;
                    modelRecord.DepartmentCode = this.s_makp;
                    modelRecord.EmployeeCode = this.s_userCode;
                    //if (this.lkupICD10.EditValue != null)
                    //    modelRecord.DiagnosisCode = Convert.ToDecimal(this.lkupICD10.EditValue.ToString());
                    //else
                        modelRecord.DiagnosisCode = 0;
                    modelRecord.DescriptionNode = this.txtGhichu.Text;
                    modelRecord.PostingDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                    if (!string.IsNullOrEmpty(txtNgayTaiKham.Text))
                        modelRecord.AppointmentDate = Convert.ToDateTime(this.txtNgayTaiKham.Text);
                    else
                        modelRecord.AppointmentDate = Convert.ToDateTime("01/01/1900");
                    modelRecord.ReferenceCode = refCode;
                    modelRecord.Symptoms = this.txtTrieuChung.Text.ToString();
                    modelRecord.Status = 0;
                    modelRecord.ObjectCode = this.iObjectCode;
                    modelRecord.Advices = this.txtLoidan.Text;
                    modelRecord.DiagnosisEnclosed = -1;
                    modelRecord.EmployeeCodeDoctor = this.employeeCodeDoctor;
                    if (this.txtXutri.EditValue != null)
                        modelRecord.TackleCode = Convert.ToInt32(this.txtXutri.EditValue.ToString());
                    else
                        this.txtXutri.EditValue = 0;
                    if (this.lkupMedicalPattern.EditValue != null && !string.IsNullOrEmpty(this.lkupMedicalPattern.EditValue.ToString()))
                        modelRecord.RowIDMedicalPattern = Convert.ToInt32(this.lkupMedicalPattern.EditValue);
                    else
                        modelRecord.RowIDMedicalPattern = -1;
                    modelRecord.ContentMedicalPattern = this.txtContentPattern.RtfText;
                    modelRecord.DiagnosisCustom = this.cboxDiagnosis.Text;
                    modelRecord.ShiftWork = this.shiftWork;
                    modelRecord.Treatments = this.memoTreatments.Text.Trim();
                    modelRecord.Pregnant = this.chkTT_PNMangThai.Checked ? 1 : 0;
                    modelRecord.Breastfeeding = this.chkTT_PNChoConBu.Checked ? 1 : 0;
                    modelRecord.Use_Smoking = this.chkTT_HutThuoc.Checked ? 1 : 0;
                    modelRecord.Use_Alcohol = this.chkTT_ChatCoCon.Checked ? 1 : 0;
                    modelRecord.EmployeeCodeDoing = this.employeeCodeDoing;
                    modelRecord.ICD10_Custom = this.txtMaICD10.Text.Trim();
                    modelRecord.ICD10Name_Custom = this.txtNameICD10.Text.Trim();
                    modelRecord.ReceiptID = this.suggestedID;
                    string msgError = string.Empty;
                    int iResult = MedicalRecord_BLL.InsMedicalRecord(modelRecord, ref this.medicalCode, ref sServiceCode, ref msgError);
                    if (iResult == 1)
                    {
                        PatientsBLL.UpdPatients(this.txtTiensubenh.Text, this.txtDiung.Text, patientCode);
                        MedicalRecord_BLL.DelDiagnosisEnclosed(this.medicalCode);
                        if (this.dtICD10KT.Rows.Count > 0)
                        {
                            foreach (DataRow dr in this.dtICD10KT.Rows)
                            {
                                MedicalRecord_BLL.InsDiagnosisEnclosed(Convert.ToDecimal(dr["RowID"].ToString()), this.medicalCode);
                            }
                        }

                        if (this.txtMach.Text.Trim() != string.Empty || this.txtNhietdo.Text.Trim() != string.Empty || this.txtHuyetap.Text.Trim() != string.Empty || this.txtHuyetap1.Text.Trim() != string.Empty || this.txtCao.Text.Trim() != string.Empty || this.txtNang.Text.Trim() != string.Empty)
                        {
                            List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefCode(medicalCode, this.patientReceiveID, patientCode);
                            if (lstSur.Count > 0)
                            {
                                SurviveSignInf infsur = new SurviveSignInf();
                                infsur.RowID = lstSur[0].RowID;
                                infsur.PatientCode = patientCode;
                                infsur.Pulse = this.txtMach.Text.Trim();
                                infsur.Temperature = this.txtNhietdo.Text.Trim();
                                infsur.BloodPressure = this.txtHuyetap.Text.Trim();
                                infsur.BloodPressure1 = this.txtHuyetap1.Text.Trim();
                                infsur.Weight = this.txtNang.Text.Trim();
                                infsur.Hight = this.txtCao.Text;
                                infsur.EmployeeCode = this.s_userCode;
                                infsur.RefID = this.patientReceiveID;
                                infsur.ReferenceCode = this.medicalCode;
                                infsur.CreateDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                                SurviveSignBLL.InsSurviveSign(infsur);
                            }
                            else
                            {
                                SurviveSignInf infsur = new SurviveSignInf();
                                infsur.RowID = 0;
                                infsur.PatientCode = patientCode;
                                infsur.Pulse = this.txtMach.Text.Trim();
                                infsur.Temperature = this.txtNhietdo.Text.Trim();
                                infsur.BloodPressure = this.txtHuyetap.Text.Trim();
                                infsur.BloodPressure1 = this.txtHuyetap1.Text.Trim();
                                infsur.Weight = this.txtNang.Text.Trim();
                                infsur.Hight = this.txtCao.Text.Trim();
                                infsur.EmployeeCode = this.s_userCode;
                                infsur.RefID = this.patientReceiveID;
                                infsur.ReferenceCode = this.medicalCode;
                                infsur.CreateDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                                SurviveSignBLL.InsSurviveSign(infsur);
                            }
                        }
                        if (this.txtNgayTaiKham.EditValue != null)
                        {
                            PatientAppointment_INF mApp = new PatientAppointment_INF();
                            mApp.PatientCode = this.patientCode;
                            mApp.ExaminationDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                            mApp.AppointmentDate = Convert.ToDateTime(this.txtNgayTaiKham.EditValue);
                            mApp.EmloyeeCode = this.s_userCode;
                            mApp.PatientReceiveID = this.patientReceiveID;
                            mApp.AppointmentNote = this.txtAppointmentNote.Text;
                            mApp.STT = 0;
                            PatientAppointment_BLL.Ins(mApp);
                        }
                        else
                        {
                            PatientAppointment_INF mApp = new PatientAppointment_INF();
                            mApp.PatientCode = this.patientCode;
                            mApp.ExaminationDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                            mApp.AppointmentDate = Convert.ToDateTime("01/01/1990");
                            mApp.EmloyeeCode = this.s_userCode;
                            mApp.PatientReceiveID = this.patientReceiveID;
                            mApp.AppointmentNote = this.txtAppointmentNote.Text.TrimEnd();
                            mApp.STT = 0;
                            PatientAppointment_BLL.Ins(mApp);
                        }
                        if (saveItem)
                        {
                            #region Toa thuoc cho benh nhan
                            //if (this.dtMedicalRecord != null && this.dtMedicalRecord.Rows.Count > 0 && iDuyetThuoc == 0)
                            if (this.dtMedicalRecord != null && this.dtMedicalRecord.Rows.Count > 0)
                            {
                                decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                                bool bcheckInventory = true;
                                bool bcheckQuantity = true;
                                int status = 0;
                                string sMsgError = string.Empty, sMsgErrorQuantity = string.Empty;
                                foreach (DataRow r in this.dtMedicalRecord.Rows)
                                {
                                    status = Convert.ToInt32(r["Status"].ToString());
                                    if (status == 0)
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
                                            sMsgError += r["ItemName"].ToString() + " tồn hiện tại: " + dAmountEnd.ToString("N0") + "\n\t";
                                            bcheckInventory = false;
                                        }
                                    }
                                }
                                if (!bcheckQuantity)
                                {
                                    sMsg = " Những thuốc sau chưa nhập số lượng \n\t" + sMsgErrorQuantity;
                                    return false;
                                }
                                else if (bcheckInventory)
                                {
                                    MedicalRecord_BLL.DelMedicalRecordDetail(medicalCode, -1, this.iObjectCode == 1 ? 1 : 0);
                                    foreach (DataRow r in this.dtMedicalRecord.Rows)
                                    {
                                        if (Convert.ToInt32(r["Status"]).Equals(0))
                                        {
                                            MedicalPrescriptionDetail_INF mDetail = new MedicalPrescriptionDetail_INF();
                                            mDetail.MedicalRecordCode = medicalCode;
                                            mDetail.EmployeeCode = this.s_userCode;
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
                                            mDetail.PostingDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
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
                                            mDetail.BHYT = mDetail.ObjectCode == 1 ? 1 : 0;
                                            mDetail.UnitOfMeasureCode_Medi = r["UnitOfMeasureCode_Medi"].ToString();
                                            MedicalRecord_BLL.InsMedicalRecordDetail(mDetail, this.iObjectCode);
                                        }
                                    }
                                    resultSave = true;
                                }
                                else
                                {
                                    sMsg = " Thuốc không đủ tồn : \n\t" + sMsgError;
                                    return false;
                                }
                            }
                            else
                                resultSave = true;
                            #endregion
                        }
                        else
                            return true;
                        #region Luu thong tin so kham thai, so pha thai, so de
                        if (this.sokhamthai != null)
                        {
                            string msgErrorKhamThai = string.Empty;
                            this.sokhamthai.MedicalRecordCode = medicalCode;
                            MedicalRecord_BLL.InsMedicalRecord_ANC(this.sokhamthai, ref msgErrorKhamThai);
                        }
                        if (this.sophathai != null)
                        {
                            string msgErrorPhaThai = string.Empty;
                            this.sophathai.MedicalRecordCode = medicalCode;
                            MedicalRecord_BLL.InsMedicalRecord_Abortions(this.sophathai, ref msgErrorPhaThai);
                        }
                        if (this.sode != null)
                        {
                            string msgErrorSoDe = string.Empty;
                            this.sode.MedicalRecordCode = medicalCode;
                            MedicalRecord_BLL.InsMedicalRecord_Childbirth(this.sode, ref msgErrorSoDe);
                        }
                        #endregion
                    }
                    else
                    {
                        sMsg = " Lưu không thành công: " + msgError;
                        return false;
                    }
                    return resultSave;
                }
                
            }
            catch(Exception ex)
            {
                sMsg = ex.Message + "! \t\n Đề nghị xem lại thông tin khám bệnh.";
                return false;
            }
        }
        
        private void PrintPrescription(int objectCode, string repositoryGroup)
        {
            try
            {
                DataTable dtMedicalRecordPrint = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.patientReceiveID, 0);
                DataTable dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalCode, repositoryGroup, objectCode, 0, this.chkStatus.Checked ? 1 : 0);
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.patientReceiveID);
                    DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveID);
                    DataSet dsTemp = new DataSet("Result");

                    DataTable dtICD10KTTemp = new DataTable();
                    dtICD10KTTemp.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in this.dtICD10KT.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                    }
                    dtICD10KTTemp.Rows.Add(sICD10kt);
                    dsTemp.Tables.Add(dtMedicalRecordPrint);
                    dsTemp.Tables.Add(dtMedicalDetail);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtBHYT);
                    dsTemp.Tables.Add(dtICD10KTTemp);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToathuoc.xml");
                    Reports.rpt_KB_Toathuoc rptShow = new Reports.rpt_KB_Toathuoc(this.dtServer, this.dtWorking);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuoc", "Toa thuốc bác sỹ");
                    rpt.ShowDialog();
                }
                else
                {
                    if (this.chkBlank.Checked)
                    {
                        DataTable dtSurviveSign = new DataTable("SurviveSign");
                        dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.patientReceiveID);
                        DataTable dtBHYT = new DataTable("BHYT");
                        dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveID);
                        DataSet dsTemp = new DataSet("Result");
                        DataTable dtICD10KTTemp = new DataTable();
                        dtICD10KTTemp.Columns.Add("DiagnosisName", typeof(string));
                        string sICD10kt = string.Empty;
                        foreach (DataRow dr in dtICD10KTTemp.Rows)
                        {
                            sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                        }
                        dtICD10KTTemp.Rows.Add(sICD10kt);
                        dsTemp.Tables.Add(dtMedicalRecordPrint);
                        dsTemp.Tables.Add(dtMedicalDetail);
                        dsTemp.Tables.Add(dtSurviveSign);
                        dsTemp.Tables.Add(dtBHYT);
                        dsTemp.Tables.Add(dtICD10KTTemp);
                        dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToathuoc.xml");
                        Reports.rptToathuocBlank rptShow = new Reports.rptToathuocBlank(this.dtServer, this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuoc", "Toa thuốc bác sỹ");
                        rpt.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.patientReceiveID > 0)
                {
                    MedicalRecord_INF mRecord = MedicalRecord_BLL.ObjMedicalRecordForRecordCode(this.medicalCode);
                    if (this.medicalCode == string.Empty || mRecord.MedicalRecordCode == null)
                    {
                        XtraMessageBox.Show(" Hồ sơ bệnh án chưa phát sinh, vui lòng xem lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.butEdit.Enabled = false;
                        this.butNew.Focus();
                        return;
                    }
                    else if (!this.bEditEmployeeDoctor)
                    {
                        if (mRecord.EmployeeCodeDoctor != this.employeeCodeDoctor)
                        {
                            XtraMessageBox.Show(" Khác bác sĩ khám bệnh không cho phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.butNew.Focus();
                        }
                    }
                    else if (iStatusrv == 2)
                    {
                        XtraMessageBox.Show(" Bệnh nhân đã in mẫu thanh toán không được phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.butNew.Focus();
                        return;
                    }
                    this.LoadRepository();
                    this.EnableText(true);
                    this.EnableButton(false);
                    //if (iDuyetThuoc == 0)
                    //{
                    this.txtNgayCap.Properties.ReadOnly = false;
                    this.txtToacu.Properties.ReadOnly = false;
                    this.txtToamau.Properties.ReadOnly = false;
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = false;
                    this.gridView_Prescription.OptionsBehavior.Editable = true;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    this.gridView_ICD10.OptionsBehavior.ReadOnly = false;
                    this.gridView_ICD10.OptionsBehavior.Editable = true;
                    //}
                    //else
                    //{
                    //this.txtNgayCap.Properties.ReadOnly = true;
                    //this.txtToacu.Properties.ReadOnly = true;
                    //this.txtToamau.Properties.ReadOnly = true;
                    //this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                    //this.gridView_Prescription.OptionsBehavior.Editable = false;
                    //this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    //this.gridView_ICD10.OptionsBehavior.ReadOnly = true;
                    //this.gridView_ICD10.OptionsBehavior.Editable = false;
                    //}
                }
            }
            catch
            {
                XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký khám!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký.", "Bệnh viện điện tử .NET");
                this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                this.gridView_Prescription.OptionsBehavior.Editable = false;
                this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.gridView_ICD10.OptionsBehavior.ReadOnly = true;
                this.gridView_ICD10.OptionsBehavior.Editable = false;
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_PreviousList.Visible = true;
                this.gridControl_PreviousList.Dock = DockStyle.Fill;
                this.butUndo.Enabled = this.butSave.Enabled = this.butSoKB.Enabled = false;
                if (this.iStatusrv != 2)//if (iDuyetThuoc == 0 && iStatusrv != 2)
                    this.butEdit.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = true;
                else
                    this.butEdit.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = false;
                this.butNew.Enabled = true;
                this.butHandPoint.Enabled = this.picXuatTuTruc.Enabled = false;
                this.txtToacu.Properties.ReadOnly = true;
                this.txtToacu.EditValue = txtToamau.EditValue = null;
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
                string sError = string.Empty;
                //if (this.txtTrieuChung.EditValue == null || this.txtTrieuChung.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Nhập triệu chứng bệnh! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtTrieuChung.Focus();
                //    return;
                //}
                if ((this.cboxDiagnosis.EditValue == null || string.IsNullOrEmpty(this.cboxDiagnosis.Text.Trim().ToString())) && string.IsNullOrEmpty(this.txtMaICD10.Text.Trim().ToString()))
                {
                    XtraMessageBox.Show(" Nhập chẩn đoán bệnh bệnh hoặc nhập ICD chẩn đoán bệnh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboxDiagnosis.Focus();
                    return;
                }
                if (this.txtXutri.EditValue == null || this.txtXutri.Text.ToString() == "")
                {
                    XtraMessageBox.Show(" Chọn xử trí khám bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtXutri.Focus();
                    return;
                }
                if (this.SaveMedical(ref sError, true))
                {
                    if (this.chkBV01.Checked)
                        PatientReceiveBLL.UpdPatientForStatus(this.patientReceiveID, this.patientCode, 2);
                    XtraMessageBox.Show(" Hồ sơ bệnh án lưu trữ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetHistoryPatient();
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                    this.gridView_Prescription.OptionsBehavior.Editable = false;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    this.gridView_ICD10.OptionsBehavior.ReadOnly = true;
                    this.gridView_ICD10.OptionsBehavior.Editable = false;
                    this.EnableText(false);
                    this.EnableButton(true);
                    if (this.txtXutri.EditValue.Equals(4))
                        this.picChuyenVien.Enabled = true;
                    else
                        this.picChuyenVien.Enabled = false;
                    this.butNew.Enabled = this.butEdit.Enabled = this.butCancel.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(sError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string repositoryGroup = "2,4";
                if (!this.iObjectCode.Equals(1))
                    repositoryGroup = "4";
                this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalRecord(this.medicalCode, this.iObjectCode, this.s_makp, repositoryGroup);
                this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.patientReceiveID > 0)
                {
                    this.LoadRepository();
                    if (this.iStatusrv != 2)//if (iDuyetThuoc == 0 && iStatusrv != 2)
                    {
                        this.txtTrieuChung.EditValue = this.lkupICD10.EditValue = this.txtLoidan.EditValue = this.txtGhichu.EditValue = this.txtToamau.EditValue = null;
                        this.txtToacu.Properties.ReadOnly = false;
                        this.txtToamau.Properties.ReadOnly = false;
                        this.EnableButton(false);
                        this.EnableText(true);
                        this.gridView_Prescription.OptionsBehavior.ReadOnly = false;
                        this.gridView_Prescription.OptionsBehavior.Editable = true;
                        this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                        this.gridView_ICD10.OptionsBehavior.ReadOnly = false;
                        this.gridView_ICD10.OptionsBehavior.Editable = true;
                        this.dtICD10KT.Clear();
                        this.btChangeDepart.Enabled = false;
                        this.txtXutri.EditValue = 1;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Bệnh nhân đã khám xong!\t\n Đề nghị bệnh nhân khám lại vào đợt sau. ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.txtTrieuChung.Focus();
                }
                this.tabMedical.SelectedTabPageIndex = 1;
            }
            catch
            {
                XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký khám!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                this.gridView_Prescription.OptionsBehavior.Editable = false;
                this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                this.gridView_ICD10.OptionsBehavior.ReadOnly = true;
                this.gridView_ICD10.OptionsBehavior.Editable = false;
                return;
            }
        }

        private void LoadRepository()
        {
            try
            {
                this.lstItem.Clear();
                string repositoryGroup = "2,4";
                if (!this.iObjectCode.Equals(1))
                    repositoryGroup = "4";
                DataTable tableRepTemp = ItemsBLL.Table_ListItemsRef(0, this.s_makp, repositoryGroup, this.iObjectCode);
                if (tableRepTemp.Select(this.employeeCodeDoctorRpository).Length > 0)
                    this.lstItem = tableRepTemp.Select(this.employeeCodeDoctorRpository).CopyToDataTable();
                else
                    this.lstItem = tableRepTemp.Clone();
                this.repSearchBHYT_ItemCode.DataSource = this.lstItem;
                this.repSearchBHYT_ItemCode.DisplayMember = "ItemName";
                this.repSearchBHYT_ItemCode.ValueMember = "ItemCode";
                this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalRecord(this.medicalCode, this.iObjectCode, this.s_makp, repositoryGroup);
                this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
            }
            catch (Exception){ return; }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            this.grWaitingList.Visible = true;
            this.grWaitingList.Dock = DockStyle.Fill;
            this.panelControl3.Visible = false;
            this.panelControl3.Dock = DockStyle.None;
            this.grMain.Text = "Quản lý HSBA - khám bệnh!";
            this.CleanerInfo();
            this.dtICD10KT.Clear();
            if (this.rdWaiting.Checked)
                this.LoadListPatientWaitingCompleted(0);
            else if(this.rdCompleted.Checked)
                this.LoadListPatientWaitingCompleted(1);
            else if(this.rdClose.Checked)
                this.LoadListPatientWaitingCompleted(2);
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            this.picPatient.Image = (Bitmap)b;
            this.btChangeDepart.Enabled = false;
            this.picRelation.Enabled = false;
            this.picCaptureDocument.Enabled = false;
            this.tabMedical.SelectedTabPageIndex = 1;
            this.lbThang.Visible = true;
            this.lbThang01.Visible = true;
        }

        public void CleanerInfo()
        {
            this.txtLydokham.Text = this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap1.Text = this.txtHuyetap.Text = this.txtCao.Text = this.txtNang.Text = string.Empty;
            this.txtGhichu.Text = this.txtTiensubenh.Text = this.memoTreatments.Text = string.Empty;
            this.txtTrieuChung.EditValue = null;
            this.txtDiung.EditValue = string.Empty;
            this.lkupICD10.EditValue = null;
            this.txtChandoankemtheo.EditValue = -1;
            this.txtXutri.EditValue = null;
            this.txtLoidan.EditValue = null;

            this.cboxDiagnosis.Text = string.Empty;
            this.patientReceiveID = 0;
            this.patientCode = string.Empty;
            this.txtToacu.EditValue = this.txtToamau.EditValue = string.Empty;
            this.txtNgayCap.EditValue = 1;
            this.txtContentPattern.RtfText = string.Empty;
            this.lkupMedicalPattern.EditValue = null;
            this.gridControl_Prescription.DataSource = null;
            this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            this.txtNgayTaiKham.EditValue = null;
            this.txtAppointmentNote.Text = this.lbSTT.Text = string.Empty;
            this.butNew.Enabled = this.butSave.Enabled = this.butSoKB.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = this.butCancel.Enabled = false;
            this.butHandPoint.Enabled = this.picHSBA.Enabled = this.picXuatTuTruc.Enabled = false;
            this.chkBV01.Checked = false;
            this.sode = null;
            this.sokhamthai = null;
            this.sophathai = null;
            this.chkTT_ChatCoCon.Checked = this.chkTT_HutThuoc.Checked = this.chkTT_PNChoConBu.Checked = this.chkTT_PNMangThai.Checked = false;
            this.cbxHoSoKB.SelectedIndex = 0;
            this.txtMaICD10.Text = this.txtNameICD10.Text = string.Empty;
            this.suggestedID = 0;
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
        
        private void butReload_Click(object sender, EventArgs e)
        {
            if (this.rdWaiting.Checked == true)
            {
                this.LoadListPatientWaitingCompleted(0);
            }
            else if (this.rdCompleted.Checked == true)
            {
                this.LoadListPatientWaitingCompleted(1);
            }
            else if (this.rdClose.Checked == true)
            {
                this.LoadListPatientWaitingCompleted(2);
            }
        }

        private void txtToamau_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtToamau.EditValue != null)
                {
                    if (this.tabMedical.SelectedTabPage.Name == "pageMedical01")
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
                                row = Utils.GetPriceRowbyCode(this.lstItem, "ItemCode='" + v.ItemCode + "' and ListBHYT=1 and ListService=0");
                            if (row == null)
                            {
                                //row = Utils.GetPriceRowbyCode(this.lstItem, "ItemCode='" + v.ItemCode + "' and AmountEnd >0 and ListService=1");
                                row = Utils.GetPriceRowbyCode(this.lstItem, "ItemCode='" + v.ItemCode + "' and AmountEnd >0");
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                    this.gridView_Prescription.OptionsBehavior.Editable = false;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    this.gridView_ICD10.OptionsBehavior.ReadOnly = true;
                    this.gridView_ICD10.OptionsBehavior.Editable = false;
                    string employeeCodeDoctorTemp = string.Empty;
                    this.chkBV01.Checked = false;
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        if (this.rdWaiting.Checked == true)
                        {
                            this.butNew.Enabled = true;
                        }
                        this.butHandPoint.Enabled = false; this.picHSBA.Enabled = true;
                        this.grWaitingList.Visible = false;
                        this.grWaitingList.Dock = DockStyle.None;
                        this.panelControl3.Visible = true;
                        this.panelControl3.Dock = DockStyle.Fill;
                        DataTable tableReceive = new DataTable();
                        this.patientReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientReceiveID).ToString());
                        iTypePatient = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientType).ToString());
                        medicalCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_MedicalRecordCode).ToString(), string.Empty);
                        patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        iObjectCode = Int32.Parse(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode).ToString());
                        sServiceCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString(), string.Empty);
                        DateTime dtWorkingold = Convert.ToDateTime(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_CreateDate).ToString());
                        iCheckCard = Int32.Parse(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCard).ToString());
                        //this.iDuyetThuoc = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Status).ToString());
                        iStatusrv = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Statusrv).ToString());
                        this.lbSTT.Text = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_IdentityNo).ToString();
                        this.GetInfoPatient();
                        MedicalPatternBLL pattern = new MedicalPatternBLL();
                        List<MedicalPatternInf> listPattern = pattern.ListPattern(sServiceCode);
                        if (listPattern.Count > 0)
                            this.lkupMedicalPattern.EditValue = listPattern[0].RowID;
                        tableReceive = PatientReceiveBLL.DT_PatientWaitingDetail(this.patientReceiveID, s_makp, sServiceCode);
                        if (tableReceive != null && tableReceive.Rows.Count > 0)
                        {
                            refCode = tableReceive.Rows[0]["ReferenceCode"].ToString();
                            this.txtTiensubenh.Text = tableReceive.Rows[0]["MedicalHistory"].ToString();
                            this.txtDiung.Text = tableReceive.Rows[0]["Allergy"].ToString();
                            this.txtLydokham.Text = tableReceive.Rows[0]["Reason"].ToString();
                            this.sServiceName = tableReceive.Rows[0]["ServiceName"].ToString();
                            if (string.IsNullOrEmpty(medicalCode))
                            {
                                this.txtMach.Text = tableReceive.Rows[0]["Pulse"].ToString();
                                this.txtNhietdo.Text = tableReceive.Rows[0]["Temperature"].ToString();
                                this.txtHuyetap.Text = tableReceive.Rows[0]["BloodPressure"].ToString();
                                this.txtHuyetap1.Text = tableReceive.Rows[0]["BloodPressure1"].ToString();
                                this.txtNang.Text = tableReceive.Rows[0]["Weight"].ToString();
                                this.txtCao.Text = tableReceive.Rows[0]["Hight"].ToString();
                            }
                        }
                        if (iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                this.cardBHYT = lstBHYT[0].Serial;
                                this.lbSothe.Text = lstBHYT[0].Serial;
                                this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                this.iTraituyen = lstBHYT[0].TraiTuyen;
                                this.chkTraiTuyen.Checked = this.iTraituyen == 1 ? true : false;
                                this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                                this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                                this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCodeFull.ToString();
                                this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                this.GetCardInfo(lstBHYT[0].Serial);
                                this.VisableBHYT(true);
                            }
                        }
                        else
                        {
                            this.lbTileBHYT.Text = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                            this.VisableBHYT(false);
                        }
                        this.grMain.Text = "Khám: " + sServiceName + " | " + sDepartmentName;
                        MedicalRecord_INF mRecord = MedicalRecord_BLL.ObjMedicalRecordForReceiveID(this.patientReceiveID, s_makp);
                        if (mRecord != null && mRecord.RowID > 0)
                        {
                            medicalCode = mRecord.MedicalRecordCode;
                            this.txtTrieuChung.Text = mRecord.Symptoms;
                            //this.lkupICD10.EditValue = mRecord.DiagnosisCode;
                            this.txtMaICD10.Text = mRecord.ICD10_Custom;
                            this.txtNameICD10.Text = mRecord.ICD10Name_Custom;
                            this.txtChandoankemtheo.EditValue = mRecord.DiagnosisEnclosed;
                            this.cboxDiagnosis.Text = mRecord.DiagnosisCustom;
                            this.txtXutri.EditValue = mRecord.TackleCode;
                            this.txtLoidan.Text = mRecord.Advices;
                            this.txtGhichu.Text = mRecord.DescriptionNode;
                            this.txtContentPattern.RtfText = mRecord.ContentMedicalPattern;
                            this.lkupMedicalPattern.EditValue = mRecord.RowIDMedicalPattern;
                            this.memoTreatments.Text = mRecord.Treatments;
                            employeeCodeDoctorTemp = mRecord.EmployeeCodeDoctor;
                            PatientAppointment_INF mApp = PatientAppointment_BLL.ObjAppointment(this.patientReceiveID);
                            if (mApp != null && mApp.PatientReceiveID != 0 && mApp.AppointmentDate > Convert.ToDateTime("01-01-1990"))
                            {
                                this.txtNgayTaiKham.EditValue = mApp.AppointmentDate;
                                this.txtAppointmentNote.Text = mApp.AppointmentNote;
                            }
                            else
                            {
                                this.txtNgayTaiKham.EditValue = null;
                                this.txtAppointmentNote.Text = string.Empty;
                            }
                            if (mRecord.TackleCode == 4)
                                this.picChuyenVien.Enabled = true;
                            else
                                this.picChuyenVien.Enabled = false;
                            this.chkTT_PNMangThai.Checked = mRecord.Pregnant == 1 ? true : false;
                            this.chkTT_PNChoConBu.Checked = mRecord.Breastfeeding == 1 ? true : false;
                            this.chkTT_HutThuoc.Checked = mRecord.Use_Smoking == 1 ? true : false;
                            this.chkTT_ChatCoCon.Checked = mRecord.Use_Alcohol == 1 ? true : false;
                            this.LoadRepository();
                        }
                        List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefCode(this.medicalCode, this.patientReceiveID, patientCode);
                        if (lstSur != null && lstSur.Count > 0)
                        {
                            this.txtMach.Text = lstSur[0].Pulse;
                            this.txtNhietdo.Text = lstSur[0].Temperature;
                            this.txtHuyetap.Text = lstSur[0].BloodPressure;
                            this.txtHuyetap1.Text = lstSur[0].BloodPressure1;
                            this.txtNang.Text = lstSur[0].Weight;
                            this.txtCao.Text = lstSur[0].Hight;
                        }
                        this.dtICD10KT = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(medicalCode);
                        this.gridControl_ICD10.DataSource = this.dtICD10KT;
                        if (this.dtWorking.ToString("dd/MM/yyyy").Equals(dtWorkingold.ToString("dd/MM/yyyy")) && (employeeCodeDoctor.Equals(employeeCodeDoctorTemp) || this.bEditEmployeeDoctor))
                        {
                            if (this.iStatusrv != 2)//if (iDuyetThuoc == 1 || iStatusrv != 2)
                            {
                                this.butPrintBHYT.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = true;
                                if (this.rdCompleted.Checked)
                                {
                                    this.butEdit.Enabled = true;
                                    this.butNew.Enabled = false;
                                }
                                if (!this.rdWaiting.Checked)
                                    this.butEdit.Enabled = true;
                            }
                            if (this.iStatusrv == 1)//if (iDuyetThuoc == 0 && iStatusrv == 1)
                                this.butCancel.Enabled = true;
                        }
                        else
                        {
                            this.butEdit.Enabled = this.butPrintBHYT.Enabled = this.picTotal.Enabled = this.butCancel.Enabled = false;
                            this.butPrintBHYT.Enabled = true;
                        }
                        if (this.iStatusrv.Equals(2))
                            this.chkBV01.Checked = true;
                        this.txtToacu.Properties.DataSource = MedicalRecord_BLL.DT_Get_PrescriptionsOld(this.patientCode);
                        this.txtToacu.Properties.DisplayMember = "PostingDateName";
                        this.txtToacu.Properties.ValueMember = "MedicalRecordCode";
                        this.EnableText(false);
                        this.ProcessBMI();
                        this.GetHistoryPatient();
                        this.picRelation.Enabled = true;
                        this.picCaptureDocument.Enabled = this.butPrintResult.Enabled = true;
                        if (this.rdWaiting.Checked)
                            this.butNew_Click(sender, e);
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi : " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (this.chkTraiTuyen.Checked )
                    {
                        if (this.chkGiayChuyenVien.Checked || this.chkCapCuu.Checked)
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                        else
                            this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "%";
                    }
                    else
                        this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                }
            }
            catch { }
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    lbMabn01.Text = objPatient.PatientCode;
                    lbHoten01.Text = objPatient.PatientName;
                    lbNamsinh01.Text = objPatient.PatientBirthday.ToString().Substring(0, 10); //objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if(objPatient.PatientAge <= 3)
                        lbThang01.Text = objPatient.PatientMonth;
                    else
                    {
                        lbThang.Visible = false;
                        lbThang01.Visible = false;
                    }
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    this.lbDiachi01.Text = objPatient.PatientAddress.TrimEnd(',');
                    if (!string.IsNullOrEmpty(objPatient.WardName))
                        this.lbDiachi01.Text += ", " + objPatient.WardName;
                    if (!string.IsNullOrEmpty(objPatient.DistrictName))
                        this.lbDiachi01.Text += ", " + objPatient.DistrictName;
                    if (!string.IsNullOrEmpty(objPatient.ProvincialName))
                        this.lbDiachi01.Text += ", " + objPatient.ProvincialName;
                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        picPatient.Image = (Bitmap)b;
                    }
                    else
                    {
                        Bitmap b1 = new Bitmap("NoImgPatient.jpeg");
                        this.picPatient.Image = (Bitmap)b1;
                    }
                }
                else
                    return;
            }
            catch { }
        }

        private void GetHistoryPatient()
        {
            this.gridControl_PreviousList.DataSource = MedicalRecord_BLL.ListHistoryMedical(this.patientCode, this.iTypePatient);
        }

        private void txtChandoankemtheo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow r = Utils.GetPriceRowbyCode(this.dtICD10KT, "DiagnosisCode='" + txtChandoankemtheo.EditValue.ToString() + "'");
                if (r != null)
                {
                    if (XtraMessageBox.Show(" Bệnh kèm theo đã tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    this.dtICD10KT.Rows.Add(txtChandoankemtheo.EditValue.ToString(), txtChandoankemtheo.Text);
                    gridControl_ICD10.DataSource = this.dtICD10KT;
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show(" Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl_ICD10_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && this.gridView_ICD10.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn bỏ chẩn đoán bệnh kèm theo này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        this.dtICD10KT.Rows.RemoveAt(this.gridView_ICD10.FocusedRowHandle);
                    }
                }
            }
            catch { }
        }

        private void txtMach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHuyetap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHuyetap1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       
        private void ProcessBMI()
        {
            try
            {
                double do_BMI = 0;
                double do_W = 0;
                double do_H = 0;
                string strThumuc = Directory.GetCurrentDirectory();
                if (!string.IsNullOrEmpty(txtNang.Text.Trim()) && !string.IsNullOrEmpty(txtCao.Text.Trim()))
                {
                    do_W = Convert.ToDouble(txtNang.Text.Trim());
                    do_H = Convert.ToDouble(txtCao.Text.Trim()) / 100;
                    do_BMI = do_W / (do_H * do_H);
                    if (do_BMI < 18)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + "\n : Người gầy.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H1.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 18 && do_BMI <= 24.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + " : Người bình thường.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H2.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 25 && do_BMI <= 29.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + " : Người béo phì độ I.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H3.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 30 && do_BMI <= 34.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + " : Người béo phì độ II.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H4.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI > 35 && do_BMI <= 39.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + "\n : Người béo phì độ III.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H5.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 40)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + "\n : Người béo phì độ III.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H6.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                }
            }
            catch { }
        }

        private void txtNang_Validated(object sender, EventArgs e)
        {
            if (this.txtNang.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(this.txtNang.Text.Trim()))
                {
                    XtraMessageBox.Show(" Cân nặng phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNang.Focus();
                    return;
                }
                else
                    this.ProcessBMI();
            }
        }

        private void VisableBHYT(bool b)
        {
            lbSothe.Visible = b;
            lbTungay.Visible = b;
            chkTraiTuyen.Visible = b;
            chkCapCuu.Visible = b;
            chkGiayChuyenVien.Visible = b;
            lbNoiDKKCB.Visible = b;
            lbDenngay.Visible = b;
            
        }

        private void txtCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNang.Focus();
        }
                        
        private void txtChandoankemtheo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtXutri.Focus();
                this.txtXutri.Show();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtXutri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtLoidan.Focus();
                this.txtLoidan.Show();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtToamau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtToacu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtAppointmentNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtMach.Focus();
        }

        private void txtHuyetap1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNhietdo.Focus();
            //SendKeys.Send("{Tab}{F4}");
        }
        
        private void txtNhietdo_Validated(object sender, EventArgs e)
        {
            if (this.txtNhietdo.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(this.txtNhietdo.Text.Trim()))
                {
                    XtraMessageBox.Show(" Nhiệt độ phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNhietdo.Focus();
                    return;
                }
            }
        }
        
        private void Total_Treatment_Costs()
        {
            try
            {
                Int32 iTile = 0;
                if (this.iObjectCode == 1)
                {
                    BHYTParametersInf Modelpara = BHYTParametersBLL.ObjParameters(1);
                    RateBHYTInf ModelRate = RateBHYTBLL.objectRateBHYT(this.cardBHYT.Substring(0, 3));
                    if (iTraituyen == 1)
                    {
                        iTile = ModelRate.RateFalse;
                    }
                    else
                    {
                        iTile = ModelRate.RateTrue;
                    }
                }
                //DataTable dtClinic = new DataTable("ClinicInfo");
                //dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtBanksInfo = new DataTable("BanksInfo");
                dtBanksInfo = BanksAccountDetailBLL.DT_View_Treatment_Info(patientCode, this.patientReceiveID);
                DataTable dtBV01 = new DataTable("ResultBV01");
                dtBV01 = BanksAccountDetailBLL.DT_View_Treatment_Costs(this.patientReceiveID, patientCode);
                decimal disparityPrice = 0;
                foreach (DataRow dr in dtBV01.Rows)
                {
                    decimal bhytPay = 0, servicePrice = 0, patientPay = 0, quantity = 0;
                    Int32 rate = 0;
                    if (Convert.ToInt32(dr["ObjectCode"].ToString()) == 1)
                    {
                        if (dr["ServiceModuleCode"].Equals("THUOC"))
                        {
                            if (Convert.ToInt32(dr["ListBHYT"].ToString()) == 1)
                            {
                                rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                                servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                                quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                                bhytPay = ((((servicePrice * quantity) * rate) / 100) * iTile / 100);
                                patientPay = (servicePrice * quantity) - bhytPay;
                                dr["PatientPay"] = patientPay;
                                dr["BHYTPay"] = bhytPay;
                            }
                            else
                            {
                                rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                                servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                                quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                                bhytPay = 0;
                                patientPay = (servicePrice * quantity) - bhytPay;
                                dr["PatientPay"] = patientPay;
                                dr["BHYTPay"] = bhytPay;
                            }
                        }
                        else
                        {
                            rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                            servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                            quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                            bhytPay = ((servicePrice * quantity) * iTile / 100);
                            patientPay = servicePrice - bhytPay;
                            dr["PatientPay"] = patientPay;
                            dr["BHYTPay"] = bhytPay;
                        }
                        disparityPrice += Convert.ToDecimal(dr["DisparityPrice"].ToString());
                    }
                    else
                    {
                        servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                        quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                        dr["PatientPay"] = servicePrice* quantity;
                        dr["BHYTPay"] = 0;
                    }
                }
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Tables.Add(dtBanksInfo);
                dsTemp.Tables.Add(dtBV01);
                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptChiphidieutri.xml");
                Reports.rptChiphidieutri rptShow = new Reports.rptChiphidieutri();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ChiPhiDieuTri", "Chi phí điều trị");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_PreviousList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    this.gridView_Prescription.OptionsBehavior.ReadOnly = true;
                    this.gridView_Prescription.OptionsBehavior.Editable = false;
                    this.gridView_Prescription.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    this.gridView_ICD10.OptionsBehavior.ReadOnly = true;
                    this.gridView_ICD10.OptionsBehavior.Editable = false;
                    DateTime medicalCodeDateTemp = new DateTime();
                    string employeeCodeDoctorTemp = string.Empty;
                    if (this.gridView_PreviousList.GetFocusedRow() != null)
                    {
                        this.grWaitingList.Visible = false;
                        this.grWaitingList.Dock = DockStyle.None;
                        this.panelControl3.Visible = true;
                        this.panelControl3.Dock = DockStyle.Fill;
                        this.patientReceiveID = Convert.ToDecimal(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_PatientReceiveID).ToString());
                        this.iTypePatient = Convert.ToInt32(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_PatientType).ToString());
                        this.medicalCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_MedicalRecordCode).ToString(), string.Empty);
                        this.patientCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_PatientCode).ToString(), string.Empty);
                        this.iObjectCode = Int32.Parse(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_ObjectCode).ToString());
                        this.sServiceCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_ServiceCode).ToString(), string.Empty);
                        medicalCodeDateTemp = Convert.ToDateTime(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_Previous_PostingDate).ToString());
                        this.iCheckCard = Int32.Parse(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_ObjectCard).ToString());
                        //this.iDuyetThuoc = Convert.ToInt32(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_Status).ToString());
                        this.iStatusrv = Convert.ToInt32(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_Statusrv).ToString());
                        this.lbSTT.Text = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_Previous_STT).ToString();
                        this.GetInfoPatient();
                        if (this.iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                            if (lstBHYT != null && lstBHYT.Count > 0)
                            {
                                this.cardBHYT = lstBHYT[0].Serial;
                                this.lbSothe.Text = lstBHYT[0].Serial;
                                this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                iTraituyen = lstBHYT[0].TraiTuyen;
                                if (iTraituyen == 1)
                                    this.chkTraiTuyen.Checked = true;
                                else
                                    this.chkTraiTuyen.Checked = false;
                                this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                                this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                                this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                this.GetCardInfo(lstBHYT[0].Serial);
                            }
                        }
                        else
                            this.lbTileBHYT.Text = this.gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_Previous_ObjectName).ToString();
                        if (this.iStatusrv != 2)//if (iDuyetThuoc == 1 || iStatusrv != 2)
                        {
                            MedicalRecord_INF mRecord = MedicalRecord_BLL.ObjMedicalRecordForRecordCode(this.medicalCode);
                            if (mRecord != null && mRecord.RowID > 0)
                            {
                                medicalCode = mRecord.MedicalRecordCode;
                                txtTrieuChung.Text = mRecord.Symptoms;
                                lkupICD10.EditValue = mRecord.DiagnosisCode;
                                txtChandoankemtheo.EditValue = mRecord.DiagnosisEnclosed;
                                this.cboxDiagnosis.Text = mRecord.DiagnosisCustom;
                                txtXutri.EditValue = mRecord.TackleCode;
                                txtLoidan.Text = mRecord.Advices;
                                txtGhichu.Text = mRecord.DescriptionNode;
                                this.txtContentPattern.RtfText = mRecord.ContentMedicalPattern;
                                this.lkupMedicalPattern.EditValue = mRecord.RowIDMedicalPattern;
                                this.memoTreatments.Text = mRecord.Treatments;
                                employeeCodeDoctorTemp = mRecord.EmployeeCodeDoctor;
                                PatientAppointment_INF mApp = new PatientAppointment_INF();
                                mApp = PatientAppointment_BLL.ObjAppointment(this.patientReceiveID);
                                if (mApp != null && mApp.PatientReceiveID > 0 && mApp.AppointmentDate > Convert.ToDateTime("01-01-1990"))
                                {
                                    this.txtNgayTaiKham.EditValue = mApp.AppointmentDate;
                                    this.txtAppointmentNote.Text = mApp.AppointmentNote;
                                }
                                else
                                {
                                    this.txtNgayTaiKham.EditValue = null;
                                    this.txtAppointmentNote.Text = string.Empty;
                                }
                                this.chkTT_PNMangThai.Checked = mRecord.Pregnant == 1 ? true : false;
                                this.chkTT_PNChoConBu.Checked = mRecord.Breastfeeding == 1 ? true : false;
                                this.chkTT_HutThuoc.Checked = mRecord.Use_Smoking == 1 ? true : false;
                                this.chkTT_ChatCoCon.Checked = mRecord.Use_Alcohol == 1 ? true : false;
                                this.dtMedicalRecord = MedicalRecord_BLL.DTMedicalRecordOld(this.medicalCode);
                                this.gridControl_Prescription.DataSource = this.dtMedicalRecord;
                            }
                            List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefCode(mRecord.MedicalRecordCode, this.patientReceiveID, patientCode);
                            if (lstSur != null && lstSur.Count > 0)
                            {
                                this.txtMach.Text = lstSur[0].Pulse;
                                this.txtNhietdo.Text = lstSur[0].Temperature;
                                this.txtHuyetap.Text = lstSur[0].BloodPressure;
                                this.txtHuyetap1.Text = lstSur[0].BloodPressure1;
                                this.txtNang.Text = lstSur[0].Weight;
                                this.txtCao.Text = lstSur[0].Hight;
                            }
                            this.dtICD10KT = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(this.medicalCode);
                            this.gridControl_ICD10.DataSource = this.dtICD10KT;
                        }
                        else
                            this.butEdit.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = false;
                        this.txtToacu.Properties.DataSource = MedicalRecord_BLL.DT_Get_PrescriptionsOld(this.patientCode);
                        this.txtToacu.Properties.DisplayMember = "PostingDateName";
                        this.txtToacu.Properties.ValueMember = "MedicalRecordCode";
                        this.EnableText(false);
                        this.ProcessBMI();
                        if (this.dtWorking.Date.Equals(medicalCodeDateTemp.Date) && employeeCodeDoctor.Equals(employeeCodeDoctorTemp))
                        {
                            this.butEdit.Enabled = this.butPrintBHYT.Enabled = this.picTotal.Enabled = this.butPrintResult.Enabled = true;
                        }
                        else
                        {
                            this.butCancel.Enabled = this.butNew.Enabled = this.butSave.Enabled = this.butSoKB.Enabled = this.butUndo.Enabled = this.butEdit.Enabled = this.butPrintBHYT.Enabled = this.picTotal.Enabled = this.picXuatTuTruc.Enabled = this.butPrintResult.Enabled = this.butHandPoint.Enabled = false;
                            this.butPrintBHYT.Enabled = true;
                        }
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi : " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_Prescription_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is SearchLookUpEdit)
            {
                DevExpress.XtraEditors.SearchLookUpEdit searchEdit;
                searchEdit = (SearchLookUpEdit)view.ActiveEditor;
                DataTable table = this.repSearchBHYT_ItemCode.DataSource as DataTable;
                clonebhyt = new DataView(table);
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                clonebhyt.RowFilter = "AmountEnd >0 ";
                searchEdit.Properties.DataSource = clonebhyt;
            }
        }

        private void gridView_Prescription_HiddenEditor(object sender, EventArgs e)
        {
            if (clonebhyt != null)
            {
                clonebhyt.Dispose();
                clonebhyt = null;
            }
        }

        private void gridView_Prescription_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                Int32 statusTemp = 0;
                if (e.RowHandle >= 0)
                {
                    statusTemp = Convert.ToInt32(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Status"]));
                    if (statusTemp == 1)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                        //view.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void txtCao_Validated(object sender, EventArgs e)
        {
            if (txtCao.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(txtCao.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chiều cao phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCao.Focus();
                    return;
                }
            }
        }

        private void LoadPattern(int rowid)
        {
            MedicalPatternBLL pattern = new MedicalPatternBLL();
            this.lkupMedicalPattern.Properties.DataSource = pattern.TablePattern(rowid);
            this.lkupMedicalPattern.Properties.DisplayMember = "Title";
            this.lkupMedicalPattern.Properties.ValueMember = "RowID";
        }

        private void LoadAbbre()
        {
            this.listAbbre = new List<DiagnosisAbbreviationsInf>();
            this.listAbbre = DiagnosisAbbreviationsBLL.ListAbb(s_userCode);
        }

        private void lkupMedicalPattern_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtContentPattern.RtfText = this.lkupMedicalPattern.GetColumnValue("Content").ToString();
                this.tabMedical.SelectedTabPage.Name = "pageMedical03";
            }
            catch { return; }
        }

        private void txtTiensubenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtDiung.Focus();
        }

        private void txtDiung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtGhichu.Focus();
        }

        private void txtContentPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DevExpress.XtraRichEdit.RichEditControl txt = (DevExpress.XtraRichEdit.RichEditControl)(sender);
                string auto = "", s1 = "", s2 = "", strSource = "";
                if (e.KeyChar == ' ')
                {
                    strSource = this.f_Get_AutoRichText(txt);
                    auto = this.SearchCharecter(strSource);
                    if (!string.IsNullOrEmpty(auto))
                    {
                        s1 = auto.Split('©')[0];
                        s2 = auto.Split('©')[1];
                        int start = txt.Document.CaretPosition.ToInt();
                        Document document = txt.Document;
                        document.BeginUpdate();
                        try
                        {
                            DocumentRange range = txt.Document.CreateRange(start - s2.Length, s2.Length);
                            string text = txt.Document.GetText(range);
                            document.Delete(range);
                            document.Replace(range, s1);
                            document.Selection = range;
                        }
                        catch
                        {
                        }
                        finally
                        {
                            document.EndUpdate();
                        }
                    }
                }
            }
            catch { }
        }

        private string f_Get_AutoRichText(DevExpress.XtraRichEdit.RichEditControl txt)
        {
            int iSelect = 0;
            int iStart = 0;
            int chieudai = 0;
            string str = "", strFind = "", strSource = "";
            strSource = txt.Text;
            strSource = strSource.Replace("\n", " ");
            strSource = strSource.Replace("\r", " ");
            strSource = strSource.Replace("\t", " ");
            iSelect = txt.Document.Selection.Start.ToInt();

            for (int i = iSelect - 1; i > 0; i--)
            {
                iStart = i;
                str = strSource.Substring(iStart, 1);
                if (str == " ")
                {
                    chieudai = iSelect - 1 - i;
                    strFind = txt.Text.Substring(iSelect - chieudai, chieudai);
                    break;
                }
            }
            try
            {
                if (strFind == "" && strFind.Length < 10) strFind = txt.Text;
            }
            catch
            {
                strFind = string.Empty;
            }
            return strFind;
        }

        private string SearchCharecter(string strsource)
        {
            string stemp = "";
            try
            {
                var v_Viettat = from p in this.listAbbre where p.CharacterCode == strsource select new { p.CharacterName };
                stemp = v_Viettat.FirstOrDefault().CharacterName;
                strsource = strsource.ToLower().Trim();
                try
                {
                    stemp += "©" + strsource;
                }
                catch
                {
                    stemp = string.Empty;
                }
            }
            catch { }
            return stemp;
        }

        private void butPrintResult_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMedicalInfo = BanksAccountDetailBLL.DT_View_Treatment_Info(this.patientCode, this.patientReceiveID);
                DataTable dtResultMedical = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.patientReceiveID, 0);
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Tables.Add(dtMedicalInfo);
                dsTemp.Tables.Add(dtResultMedical);
                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptHoSoKhamBenh.xml");
                Reports.rptHoSoKhamBenh rptShow = new Reports.rptHoSoKhamBenh();
                rptShow.Parameters["paraTitle"].Value = this.lkupMedicalPattern.Text.ToUpper();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PHIẾU KHÁM BỆNH", "Phiếu khám bệnh");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btChangeDepart_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tempPatientReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientReceiveID).ToString());
                string tempServiceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString();
                string tempPatientCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString();
                Int32 tempObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                this.suggestedID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReceiptID).ToString());
                Int32 tempPaid = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Paid));
                string tempReferenceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString();
                /*if (tempPaid == 1)
                {
                    XtraMessageBox.Show(" Công khám đã thanh toán không cho phép thay đổi!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    frmDepartmentOther frmDepartment = new frmDepartmentOther(this.s_userCode, this.s_makp, tempPatientCode, tempPatientReceiveID, tempServiceCode, tempObjectCode, this.iTypePatient, tempReferenceCode, tempPaid, tempReceiptID, "'KCB'", "'LO0001'", this.employeeCodeDoctor);
                    frmDepartment.ShowDialog();
                    if (frmDepartment.reload)
                        this.butReload_Click(sender, e);
                }*/
                frmDepartmentOther frmDepartment = new frmDepartmentOther(this.s_userCode, this.s_makp, tempPatientCode, tempPatientReceiveID, tempServiceCode, tempObjectCode, this.iTypePatient, tempReferenceCode, tempPaid, this.suggestedID, "'KCB'", "'LO0001'", this.employeeCodeDoctor, this.rdCompleted.Checked ? 1 : 0, this.shiftWork);
                frmDepartment.ShowDialog();
                if (frmDepartment.reload)
                    this.butReload_Click(sender, e);
            }
            catch { }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalRecord_INF mRecord = new MedicalRecord_INF();
                mRecord = MedicalRecord_BLL.ObjMedicalRecordForRecordCode(this.medicalCode);
                if (this.medicalCode == string.Empty || mRecord.MedicalRecordCode == null)
                {
                    XtraMessageBox.Show(" Hồ sơ bệnh án chưa phát sinh, vui lòng xem lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.butCancel.Enabled = false;
                    this.butNew.Focus();
                    return;
                }
                else if (!this.bEditEmployeeDoctor)
                {
                    if (mRecord.EmployeeCodeDoctor != this.employeeCodeDoctor)
                    {
                        XtraMessageBox.Show(" Khác bác sĩ khám bệnh không cho phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.butCancel.Enabled = false;
                        this.butNew.Focus();
                        return;
                    }
                }
                if (XtraMessageBox.Show(" Bạn thật sự muốn hủy hồ sơ bệnh án? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    int result = 0;
                    result = MedicalRecord_BLL.DelMedicalRecord(this.medicalCode, this.patientReceiveID, this.patientCode);
                    if (result == -1)
                    {
                        XtraMessageBox.Show(" Bệnh nhân đã duyệt đơn thuốc, không được phép huỷ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (result == -2)
                    {
                        XtraMessageBox.Show(" Bệnh nhân đã thanh toán ra viện, không được phép huỷ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (result == -3)
                    {
                        XtraMessageBox.Show(" Hồ sơ bệnh án chưa phát sinh, vui lòng xem lại? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (result == -4)
                    {
                        XtraMessageBox.Show(" Dịch vụ đã đóng tiền không được phép hủy? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (result == -5)
                    {
                        XtraMessageBox.Show(" Có dịch vụ đã thực hiện không được phép hủy?", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (result == 1)
                    {
                        XtraMessageBox.Show(" Đã xóa hồ sơ bệnh án!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.butContinues_Click(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Xóa không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.butCancel.Enabled = false;
                        return;
                    }
                }
            }
            catch { this.butCancel.Enabled = false; }
        }

        private void picChuyenVien_Click(object sender, EventArgs e)
        {
            frmChuyenVien frm = new frmChuyenVien(this.s_userCode, this.patientCode, this.patientReceiveID, this.s_makp, this.dtWorking, this.txtTrieuChung.Text.TrimEnd(), this.medicalCode, this.cboxDiagnosis.Text.Trim(), this.employeeCodeDoctor);
            frm.ShowDialog();
        }
        
        private void txtLoidan_Validated(object sender, EventArgs e)
        {
            this.txtLoidan.Text = Utils.ToUpperCharacterFisrtString(this.txtLoidan.Text);
        }

        private void cboxDiagnosis_Validated(object sender, EventArgs e)
        {
            this.cboxDiagnosis.Text = Utils.ToUpperCharacterFisrtString(this.cboxDiagnosis.Text);
        }

        private void memoTreatments_Validated(object sender, EventArgs e)
        {
            this.memoTreatments.Text = Utils.ToUpperCharacterFisrtString(this.memoTreatments.Text);
        }

        private void txtTrieuChung_Validated(object sender, EventArgs e)
        {
            this.txtTrieuChung.Text = Utils.ToUpperCharacterFisrtString(this.txtTrieuChung.Text);
        }

        private void txtGhichu_Validated(object sender, EventArgs e)
        {
            this.txtGhichu.Text = Utils.ToUpperCharacterFisrtString(this.txtGhichu.Text);
        }

        private void txtLydokham_Validated(object sender, EventArgs e)
        {
            this.txtLydokham.Text = Utils.ToUpperCharacterFisrtString(this.txtLydokham.Text);
        }

        private void txtDiung_Validated(object sender, EventArgs e)
        {
            this.txtDiung.Text = Utils.ToUpperCharacterFisrtString(this.txtDiung.Text);
        }

        private void txtTiensubenh_Validated(object sender, EventArgs e)
        {
            this.txtTiensubenh.Text = Utils.ToUpperCharacterFisrtString(this.txtTiensubenh.Text);
        }
        
        private void cboxDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtMaICD10.Focus();
        }
        
        private void gridView_WaitingList_Click(object sender, EventArgs e)
        {
            /*
            if (this.CheckCompleted.Checked)
                this.btChangeDepart.Enabled = false;
            else
                this.btChangeDepart.Enabled = true;
                */
            this.btChangeDepart.Enabled = true;
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
                Int32 listServiceTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("ListService").ToString());
                string itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
                string noteTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Note").ToString();
                string usageCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UsageCode").ToString();
                string SODKGP = searchEdit.Properties.View.GetFocusedRowCellValue("SODKGP").ToString();
                string unitOfMeasureCode_MediTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode_Medi").ToString();
                bool converted_MediTemp = Convert.ToBoolean(searchEdit.Properties.View.GetFocusedRowCellValue("Converted_Medi"));
                DataRow r = Utils.GetPriceRowbyCode(this.dtMedicalRecord, "ItemCode='" + itemCodeTemp + "' and RepositoryCode='" + repositoryCodeTemp + "' and Status=0");
                if (this.bCheckActice)
                {
                    string errorActive = string.Empty;
                    List<Items_View> lstActive = new List<Items_View>();
                    if (activeTemp != string.Empty)
                    {
                        lstActive = ItemsBLL.ListItemsForActive(activeTemp, itemCodeTemp, this.dtMedicalRecord);
                        foreach (var v in lstActive)
                        {
                            errorActive += v.ItemName + ":" + v.Active + "\n";
                        }
                        if (errorActive != string.Empty)
                        {
                            XtraMessageBox.Show(" Thuốc có hoạt chất trùng với thuốc : \n" + errorActive, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_RepositoryCode, repositoryCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_RepositoryName, repositoryNameTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_ItemName, itemNameTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Instruction, noteTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_SODKGP, SODKGP);
                            decimal s1 = 0;
                            if (listBHYTTemp.Equals(1) && this.iObjectCode.Equals(1) && listServiceTemp.Equals(0))
                            {
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_Unit_Price, bhytPriceTemp);
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 1);
                                s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * bhytPriceTemp;
                            }
                            else
                            {
                                if (!this.iObjectCode.Equals(1))
                                    this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, this.iObjectCode);
                                else
                                    this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 2);
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_Unit_Price, salesPriceTemp);
                                s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * salesPriceTemp;
                            }
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Amount, s1);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_RepositoryGroupCode, repositoryGroupCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_UsageCode, usageCodeTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_RateBHYT, rateBHYTTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_UnitOfMeasureCode_Medi, unitOfMeasureCode_MediTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Converted_Medi, converted_MediTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Stutus, 0);
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
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_UnitOfMeasureCode, unitOfMeasureCodeTemp);                        
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_RepositoryCode, repositoryCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_RepositoryName, repositoryNameTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_ItemName, itemNameTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_Instruction, noteTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_SODKGP, SODKGP);
                        decimal s1 = 0;
                        if (listBHYTTemp.Equals(1) && this.iObjectCode.Equals(1) && listServiceTemp.Equals(0))
                        {
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Unit_Price, bhytPriceTemp);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 1);
                            s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * bhytPriceTemp;
                        }
                        else
                        {
                            if (!this.iObjectCode.Equals(1))
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, this.iObjectCode);
                            else
                                this.gridView_Prescription.SetFocusedRowCellValue(this.col_ObjectCode, 2);
                            this.gridView_Prescription.SetFocusedRowCellValue(this.col_Unit_Price, salesPriceTemp);
                            s1 = Convert.ToDecimal(gridView_Prescription.GetFocusedRowCellValue("Quantity")) * salesPriceTemp;
                        }
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_Amount, s1);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_RepositoryGroupCode, repositoryGroupCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_UsageCode, usageCodeTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_RateBHYT, rateBHYTTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_UnitOfMeasureCode_Medi, unitOfMeasureCode_MediTemp);
                        this.gridView_Prescription.SetFocusedRowCellValue(this.col_Converted_Medi, converted_MediTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrintBHYT_Click(object sender, EventArgs e)
        {
            string repositoryGroup = "2,4";
            if (this.iObjectCode.Equals(1))
            {
                this.PrintPrescription(1, repositoryGroup);
                if (this.dtMedicalRecord.Rows.Count > 0)
                    this.PrintPrescription_Out(this.iObjectCode == 1 ? 2 : this.iObjectCode, repositoryGroup);
            }
            else
            {
                if (this.dtMedicalRecord.Rows.Count > 0)
                {
                    this.PrintPrescription_Out(this.iObjectCode == 1 ? 2 : this.iObjectCode, repositoryGroup);
                }
            }
        }

        private void gridView_Prescription_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void PrintPrescription_Out(int objectCode, string repositoryGroup)
        {
            try
            {
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Clear();
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtMedicalRecordOut = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.patientReceiveID, 0);
                DataTable dtMedicalDetailOut = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalCode, repositoryGroup, objectCode, 1, this.chkStatus.Checked ? 1 : 0);
                if (dtMedicalDetailOut != null && dtMedicalDetailOut.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.patientReceiveID);
                    DataTable dtICD10KTTemp = new DataTable();
                    dtICD10KTTemp.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in this.dtICD10KT.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                    }
                    dtICD10KTTemp.Rows.Add(sICD10kt);
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtMedicalRecordOut);
                    dsTemp.Tables.Add(dtMedicalDetailOut);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtICD10KTTemp);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToaThuocMuaNgoai.xml");
                    Reports.rptToaThuocMuaNgoai rptShow = new Reports.rptToaThuocMuaNgoai();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuocMuaNgoai", "Toa thuốc mua ngoài");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_WaitingList_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 prescription = 0;
                if (e.RowHandle >= 0)
                {
                    prescription = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Prescription"]));
                    if (prescription == 1)
                    {
                        e.Appearance.ForeColor = Color.Blue;
                        View.ActiveEditor.Enabled = false;
                    }
                }
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
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                }
            }
            catch { }
        }

        private void memoTreatments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.cboxDiagnosis.Focus();
        }

        private void butSoKB_Click(object sender, EventArgs e)
        {
            if (this.cbxHoSoKB.SelectedIndex == 1)
            {
                frmKBSoKhamThai frm = new frmKBSoKhamThai(this.employeeCodeDoctor, this.medicalCode, this.dtWorking, this.sokhamthai);
                if (this.sokhamthai != null && !string.IsNullOrEmpty(this.sokhamthai.MedicalRecordCode))
                {
                    frm.sokhamthai = this.sokhamthai;
                }
                frm.ShowDialog();
                this.sokhamthai = frm.sokhamthai;
            }
            else if (this.cbxHoSoKB.SelectedIndex == 2)
            {
                frmKBSoPhaThai frm = new frmKBSoPhaThai(this.s_userCode, this.medicalCode, this.dtWorking, this.sophathai);
                if (this.sophathai != null && !string.IsNullOrEmpty(this.sophathai.MedicalRecordCode))
                {
                    frm.sophathai = this.sophathai;
                }
                frm.ShowDialog();
                this.sophathai = frm.sophathai;
            }
            else if (this.cbxHoSoKB.SelectedIndex == 3)
            {
                frmKBSoDe frm = new frmKBSoDe(this.s_userCode, this.medicalCode, this.dtWorking, this.sode);
                if (this.sode != null && !string.IsNullOrEmpty(this.sode.MedicalRecordCode))
                {
                    frm.sode = this.sode;
                }
                frm.ShowDialog();
                this.sode = frm.sode;
            }
            else if (this.cbxHoSoKB.SelectedIndex == 4)
            {
                frmHoSoNgoaiTru frm = new frmHoSoNgoaiTru(this.patientReceiveID, this.patientCode, this.s_userCode, this.employeeCodeDoctor, this.sDepartmentName, this.medicalCode, this.iObjectCode, Utils.DateServer(), this.dtICD10KT, this.shiftWork);
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Vui lòng chọn hồ sơ khám bệnh.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #region Check tuong tac thuoc
        private List<string> Get_AllergicDrugs() //Get list dị ứng thuốc theo mã thuốc SDK
        {
            List<string> lst = new List<string>();
            // Do :  lấy danh sách thuốc dị ứng add vào lst , mã dị ứng thuốc theo SỐ ĐK
            return lst;
        }
        private List<string> Get_AllergicUnii() //Get list dị ứng hoạt chất theo mã Unii của FDA
        {
            List<string> lst = new List<string>();
            // Do :  lấy danh sách mã hoạt chất dị ứng add vào lst
            return lst;
        }
        private List<string> Get_BaseDiseases() // Get list ICD10 tiền sử bệnh
        {
            List<string> lst = new List<string>();
            // Do :  lấy danh sách ICD10 trong danh sách tiền sử bệnh của bệnh nhân rồi add vào lst
            DataTable data = DrugCheckBLL.Get_ICD10_Base_Disease_Local(this.lbMabn01.Text);
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    lst.Add(row["DiagnosisCode"].ToString());
                }
            }
            // lấy ICD10 từ lịch sử khám bệnh trên cổng giám định. 
            //lấy dữ liệu khám bệnh của bệnh nhân tại pk/bv union với list lịch sử khám bệnh trên cổng giám định BHYT
            return lst;
        }
        private List<string> Get_Diseases() // Get list ICD10 theo chuẩn đoán chính và chuẩn kèm theo của Bác sĩ
        {
            List<string> lst = new List<string>();
            if (this.lkupICD10.EditValue != null && !string.IsNullOrEmpty(this.lkupICD10.EditValue.ToString()))
                lst.Add(DrugCheckBLL.GetICD10(Convert.ToInt32(this.lkupICD10.EditValue.ToString())));
            if (this.dtICD10KT.Rows.Count > 0) // lấy mã ICD10 từ chuẩn đoán phụ
            {
                foreach (DataRow row in this.dtICD10KT.Rows)
                {
                    int rowID = int.Parse(row["RowID"].ToString());
                    lst.Add(DrugCheckBLL.GetICD10(rowID));
                }
            }
            return lst;
        }
        private string Get_CodeDataDrugCheck()
        {
            string str = string.Empty;
            //Get ngày giờ của hệ thống - > to string
            try
            {
                str = Utils.DateTimeServer().ToString("yyyyMMddhhmmss");
            }
            catch
            {
                str = DateTime.Now.Date.ToString("yyyyMMddhhmmss");
            }
                return str;
        }
        private ThongTinThuocModel.patient Get_DataPatient() //lấy dữ liệu bệnh nhân
        {
            ThongTinThuocModel.patient data = new ThongTinThuocModel.patient();
            //Lấy thông tin bệnh nhân
            data.height = string.IsNullOrEmpty(this.txtCao.Text)?0:int.Parse(this.txtCao.Text);
            data.name = this.lbHoten01.Text;
            data.sex = this.lbGioitinh01.Text == "Nam" ? "M" : "F";
            data.weight = string.IsNullOrEmpty(this.txtNang.Text) ? 0 : int.Parse(this.txtNang.Text);
            data.age = string.IsNullOrEmpty(this.lbTuoi01.Text)?0:int.Parse(this.lbTuoi01.Text);
            data.code = this.lbMabn01.Text;
            data.dob = this.lbNamsinh01.Text;
            data.base_diseases = this.Get_BaseDiseases();
            data.breast_feeding = this.chkTT_PNChoConBu.Checked ? true : false;
            data.allergic_drugs = this.Get_AllergicDrugs();
            data.allergic_uniis = this.Get_AllergicUnii();
            data.pregnant = this.chkTT_PNMangThai.Checked ? 1 : 0;
            data.pulse = string.IsNullOrEmpty(this.txtHuyetap.Text)?0:int.Parse(this.txtHuyetap.Text);
            data.diastolic = string.IsNullOrEmpty(this.txtHuyetap.Text) ? 0 : int.Parse(this.txtHuyetap.Text);
            data.systolic = string.IsNullOrEmpty(this.txtHuyetap1.Text) ? 0 : int.Parse(this.txtHuyetap1.Text);
            data.smoking = this.chkTT_HutThuoc.Checked ? true : false;
            data.alcohol = this.chkTT_ChatCoCon.Checked ? true : false;
            return data;
        }
        
        private void txtChandoankemtheo_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private void rdClose_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdClose.Checked)
            {
                this.butNew.Enabled = false;
                this.txtToacu.Properties.ReadOnly = true;
                this.txtToamau.Properties.ReadOnly = true;
                this.LoadListPatientWaitingCompleted(2);
                this.btChangeDepart.Enabled = true;
            }
        }

        private void picRelation_Click(object sender, EventArgs e)
        {
            if (this.patientCode.Trim().Length > 0)
            {
                frmRelationPatient frm = new frmRelationPatient(this.patientReceiveID, this.s_userCode, this.patientCode);
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để khai báo thông tin gia đình!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void picCaptureDocument_Click(object sender, EventArgs e)
        {
            if (this.patientCode == string.Empty || this.patientReceiveID == 0)
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để đính kèm file văn bản hình ảnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.patientReceiveID, this.patientCode);
                frm.ShowDialog();
            }
        }

        private void picHSBA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.patientCode))
            {
                frmKB_HSBA frm = new frmKB_HSBA(this.patientCode);
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show(" Chưa có thông tin mã bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void picTotal_Click(object sender, EventArgs e)
        {
            this.Total_Treatment_Costs();
        }

        private void picXuatTuTruc_Click(object sender, EventArgs e)
        {
            string msgError = string.Empty;
            if (this.SaveMedical(ref msgError, false))
            {
                frmXuatTuTruc form = new frmXuatTuTruc(this.s_makp, this.s_userCode, this.patientReceiveID, patientCode, iObjectCode, medicalCode, iTypePatient, this.cardBHYT, iTraituyen, this.shiftWork, this.dtWorking);
                form.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(msgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtMaICD10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.ResetLocationBrowseICD10();
                this.txtNameICD10.Focus();
            }
            if (e.KeyCode == Keys.Down)
                this.lkupICD10.Focus();
        }

        private List<ThongTinThuocModel.drug> Get_DataDrugCheck(DataTable tableDrugs) //Lấy dữ liệu thuốc để check tương tác
        {
            List<ThongTinThuocModel.drug> lst = new List<ThongTinThuocModel.drug>();
            //Lấy dữ liệu thuốc trên gridview khi bác sĩ kê đơn add thông tin thuốc vào lst
            if (tableDrugs != null && tableDrugs.Rows.Count > 0)
            {
                foreach (DataRow row in tableDrugs.Rows)
                {
                    ThongTinThuocModel.drug drug = new ThongTinThuocModel.drug();
                    drug.drug_id = row["SODKGP"].ToString();
                    lst.Add(drug);
                }
            }
            return lst;
        }
        
        private string Get_DoctorName()
        {
            string doctorName = string.Empty;
            try
            {
                DrugCheckBLL.Get_DoctorName(this.employeeCodeDoctor);
            }
            catch
            { }
            return doctorName;
        }
        private string Get_OwnerID() // lấy Owner ID bên Thongtinthuoc.com cung cấp
        {
            string ID = "VNM-BVPK-HCM-00001"; // set cứng để test thôi, lúc chạy thì nhờ bên thongtinthuoc.com cung cấp
                                                // mỗi OwnerID sẽ đi kèm với 1 token -> sửa lại thư viện DrugCheck
            return ID;
        }
        
        private string msg = string.Empty;
        
        private string strAlcohol = @"- Cảnh báo mức độ {0} :Thuốc {1} khi người bệnh sử dụng với chất có cồn. {2} ";
        private string strcontraindications = @"- Thuốc {0} chống chỉ định {1}{2}";
        private string strdrug_interactions = @"- Tương tác thuốc giữa {0} và {1} ở mức độ{2}. {3} ";

        private void repSearchBHYT_ItemCode_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private string strbreast_feeding = @"- Thuốc {0} ảnh hướng tới việc phụ  nữ đang cho con bú ";

        private void gridView_Prescription_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            int statusTemp = (view.GetRowCellValue(view.FocusedRowHandle, "Status") == null || view.GetRowCellValue(view.FocusedRowHandle, "Status").ToString() == string.Empty || view.GetRowCellValue(view.FocusedRowHandle, "Status").ToString() == "0") ? 0 : 1;
            if (statusTemp.Equals(1))
                e.Cancel = true;
        }

        private void txtMaICD10_Validated(object sender, EventArgs e)
        {
            try
            {
                List<DiagnosisInf> lstDiagnosisTemp = this.lstDiagnosis.Where(p => p.DiagnosisCode.Contains(this.txtMaICD10.Text.ToUpper())).ToList();
                if (lstDiagnosisTemp != null && lstDiagnosisTemp.Count > 0)
                    this.txtNameICD10.Text = lstDiagnosisTemp[0].DiagnosisName;
                else
                    this.txtNameICD10.Text = string.Empty;
            }
            catch { this.txtNameICD10.Text = string.Empty; }
        }

        private string strpregnancy = @"- Thuốc {0} ảnh hướng tới việc phụ  nữ đang mang thai ";
        private string strallergy = @"- Bệnh nhân bị dị ứng với thành phần của thuốc {0}";
        private string strindication_by_disease = @"- Thuốc {0} {1} với bệnh {2}";
        private void CheckTuongTacThuoc(DataTable tableDrugs)
        {
            ThongTinThuocModel.DataDrugsCheck dataDrugCheck = new ThongTinThuocModel.DataDrugsCheck();
            dataDrugCheck.code = this.Get_CodeDataDrugCheck();
            dataDrugCheck.date = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer()).ToString("yyyy-MM-dd'T'hh:mm:ss");
            dataDrugCheck.doctor_name = this.Get_DoctorName();
            dataDrugCheck.nurse_name = string.Empty; // có thì lấy, ko có thì thôi.
            dataDrugCheck.owner_id = this.Get_OwnerID();
            dataDrugCheck.drugs = this.Get_DataDrugCheck(tableDrugs);
            dataDrugCheck.diseases = this.Get_Diseases();
            dataDrugCheck.patient = this.Get_DataPatient();
            try
            {
                ThongTinThuocModel.ResultDrugCheck result =ThongTinThuocFunctions.GetDrugCheck(dataDrugCheck);

                if (result != null)
                {
                    if (!(result.result.alcohol_interaction == null && result.result.allergy == null && result.result.contraindications == null && result.result.drug_interactions == null
                 && result.result.indication_by_disease == null && result.result.pregnancy == null && result.result.warnings == null && result.result.tobacco == null))
                    {
                        if (result.result.alcohol_interaction != null)
                        {
                            this.msg += "CẢNH BÁO THUỐC ĐỐI VỚI CHẤT CỒN: \r\n";
                            foreach (var item in result.result.alcohol_interaction)
                            {
                                this.msg += string.Format(this.strAlcohol + "\r\n", item.severity, item.drug_name, ThongTinThuocFunctions.ConvertHTMLtoPlantext(item.summary));
                            }
                        }
                        if (result.result.allergy != null)
                        {
                            this.msg += "CẢNH BÁO THUỐC ĐỐI VỚI CHẤT DỊ ỨNG: \r\n";
                            foreach (var item in result.result.allergy)
                            {
                                this.msg += string.Format(this.strallergy + "\r\n", item.name);
                            }
                        }
                        if (result.result.contraindications != null)
                        {
                            this.msg += "CẢNH BÁO THUỐC CHỐNG CHỈ ĐỊNH: \r\n";
                            foreach (var item in result.result.contraindications)
                            {
                                this.msg += string.Format(this.strcontraindications + "\r\n", item.drug_name, item.reason, item.explanation);
                            }
                        }
                        if (result.result.drug_interactions != null)
                        {
                            this.msg += "CẢNH BÁO TƯƠNG TÁC THUỐC: \r\n";
                            foreach (var item in result.result.drug_interactions)
                            {
                                if (item.severity > 0) // nghiêm trọng thì mới cảnh báo.
                                {
                                    this.msg += string.Format(this.strdrug_interactions + "\r\n", item.a_name, item.b_name, item.severity, ThongTinThuocFunctions.ConvertHTMLtoPlantext(item.summary));
                                }
                            }
                        }
                        if (result.result.indication_by_disease != null)
                        {
                            this.msg += "CẢNH BÁO TƯƠNG TÁC THUỐC VỚI BỆNH: \r\n";
                            foreach (var item in result.result.indication_by_disease)
                            {
                                if (!item.type.Equals("I"))
                                {
                                    string type = string.Empty;
                                    if (item.type.Equals("D"))
                                        type = "gây bệnh";
                                    if (item.type.Equals("C"))
                                        type = "chống chỉ định";
                                    this.msg += string.Format(this.strindication_by_disease + "\r\n", item.drug_name, type, item.reason); //mapping item.reason với danh mục ICD để lấy tên bệnh
                                }
                            }
                        }
                        if (result.result.pregnancy != null)
                        {
                            this.msg += "CẢNH BÁO THUỐC VỚI PHỤ NỮ MANG THAI: \r\n";
                            foreach (var item in result.result.pregnancy)
                            {
                                this.msg += string.Format(this.strpregnancy + "\r\n", item.drug_name);

                            }
                        }
                        if (result.result.warnings != null)
                        {
                            this.msg += "CẢNH BÁO THUỐC PHỤ NỮ ĐANG CHO CON  BÚ: \r\n";
                            foreach (var item in result.result.warnings)
                            {
                                this.msg += string.Format(this.strbreast_feeding + "\r\n", item.drug_name);
                            }
                        }
                        if (!string.IsNullOrEmpty(this.msg))
                        {
                            MessageBox.Show(this.msg, "iHis-Bệnh viện điện tử.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "iHis-Bệnh viện điện tử.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region Process ICD10
        private void lkupICD10_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkupICD10.EditValue != null && !string.IsNullOrEmpty(this.lkupICD10.EditValue.ToString()))
            {
                this.txtMaICD10.EditValue = this.lkupICD10.EditValue.ToString();
                this.txtNameICD10.EditValue = this.lkupICD10.Text;
                this.lkupICD10.Visible = false;
            }
        }
        private void txtMaICD10_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtMaICD10.EditValue != null && !string.IsNullOrEmpty(this.txtMaICD10.EditValue.ToString()))
            {
                List<DiagnosisInf> lstDiagnosisTemp = this.lstDiagnosis.Where(p => p.DiagnosisCode.Contains(this.txtMaICD10.Text.ToUpper())).ToList();
                this.BrowseToICD10(this.txtMaICD10.Location.X, this.txtNameICD10.Location.Y, this.lkupICD10.Height, this.txtMaICD10.Width + this.txtNameICD10.Width, lstDiagnosisTemp);
            }
        }
        private void txtNameICD10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.ResetLocationBrowseICD10();
                this.txtChandoankemtheo.Focus();
            }
            if (e.KeyCode == Keys.Down)
                this.lkupICD10.Focus();
        }
        private void txtNameICD10_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtNameICD10.EditValue != null && !string.IsNullOrEmpty(this.txtNameICD10.EditValue.ToString()) && this.txtNameICD10.EditValue.ToString().EndsWith(" "))
                this.BrowseToICD10Name(this.txtMaICD10.Location.X, this.txtMaICD10.Location.Y, this.lkupICD10.Height, this.txtMaICD10.Width + this.txtNameICD10.Width);
        }
        private void ResetLocationBrowseICD10()
        {
            this.lkupICD10.Visible = false;
            this.lkupICD10.Location = new Point(128, 164);
            this.lkupICD10.Size = new Size(53, 20);
        }
        private void BrowseToICD10Name(int x, int y, int h, int w)
        {
            this.lkupICD10.Location = new Point(x, y);
            this.lkupICD10.Size = new Size(w, h);
            this.lkupICD10.Visible = true;
            this.lkupICD10.Properties.DataSource = this.lstDiagnosis.Where(p => p.DiagnosisName.Contains(this.txtNameICD10.Text)).ToList();
            this.lkupICD10.Properties.DisplayMember = "DiagnosisName";
            this.lkupICD10.Properties.ValueMember = "DiagnosisCode";
            this.lkupICD10.ShowPopup();
        }
        private void BrowseToICD10(int x, int y, int h, int w, List<DiagnosisInf> lstDiagnosisTemp)
        {
            this.lkupICD10.Location = new Point(x, y);
            this.lkupICD10.Size = new Size(w, h);
            this.lkupICD10.Visible = true;
            this.lkupICD10.Properties.DataSource = lstDiagnosisTemp;
            this.lkupICD10.Properties.DisplayMember = "DiagnosisName";
            this.lkupICD10.Properties.ValueMember = "DiagnosisCode";
            this.lkupICD10.ShowPopup();
        }
        #endregion End Process ICD10
    }
}