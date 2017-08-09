using System;
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
using DevExpress.XtraReports.UI;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ps.Clinic.ViewPopup;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;

namespace Ps.Clinic.Entry
{
    public partial class frmThuThuat : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private string patientCode, patientName = string.Empty;
        private string serviceCode = string.Empty;
        private string serviceName = string.Empty;
        private string sReferenceCode = string.Empty, sBanksAccountCode = string.Empty;
        private decimal dPatientReceiveID = 0, dReceiptCode = 0, dRealID = 0;
        private Int32 iStatus = 0, iObjectCode = 0, iPatientType = 0, iPaid = 0;
        private string imageCode = string.Empty, sSurgeriesCode = string.Empty;
        private string sTheBHYT = string.Empty;
        private int iTraituyen = 0;
        private string sMakp = string.Empty, sNamekp = string.Empty;
        private string s_uSerid = string.Empty;
        private List<Items_Ref> lstItem = new List<Items_Ref>();
        private DataTable dtEkip = new DataTable();
        private DataTable dtMedicalRecord_Material = new DataTable();
        private DataTable dtPPVocam = new DataTable();
        private DataTable dtPPTinhhinh = new DataTable();
        private DataTable dtPPTaibien = new DataTable();
        private List<EmployeeViewInf> lstEmployee = new List<EmployeeViewInf>();
        private List<EmployeePositionInf> lstPosition = new List<EmployeePositionInf>();
        private int iMenu = 0;
        private DataTable tableItem = new DataTable();
        private DataView cloneout = null;
        private string shiftWork = string.Empty;
        private DateTime dtWorking = new DateTime();
        //private DateTime dtimePosting;

        public frmThuThuat(string _spk, string _uSerid, int _Menu, string _namekp, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            grWaitingList.Visible = true;
            grWaitingList.Dock = DockStyle.Fill;
            grPrevious.Visible = false;
            grPrevious.Dock = DockStyle.None;
            sMakp = _spk;
            s_uSerid = _uSerid;
            iMenu = _Menu;
            sNamekp = _namekp;
            this.shiftWork = _shiftWork;
            this.dtWorking = _dtWorking;
        }
        private void frmThuThuat_Load(object sender, EventArgs e)
        {
            try
            {
                this.EnableField(true);
                this.ref_ObjectCode.DataSource = ObjectBLL.ListObject(0);
                this.ref_ObjectCode.DisplayMember = "ObjectName";
                this.ref_ObjectCode.ValueMember = "ObjectCode";
                this.repMaterial_Usage.DataSource = UsageBLL.ListUsage(string.Empty);
                this.repMaterial_Usage.DisplayMember = "UsageName";
                this.repMaterial_Usage.ValueMember = "UsageCode";

                //List<DiagnosisInf> lstDia = DiagnosisBLL.ListDiagnosisName();
                //Search_CDtruocPTT.Properties.DataSource = lstDia;
                //Search_CDtruocPTT.Properties.DisplayMember = "DiagnosisName";
                //Search_CDtruocPTT.Properties.ValueMember = "DiagnosisCode";

                //Search_CDsauPTT.Properties.DataSource = lstDia;
                //Search_CDsauPTT.Properties.DisplayMember = "DiagnosisName";
                //Search_CDsauPTT.Properties.ValueMember = "DiagnosisCode";

                this.dtPPVocam = SurgeriesBLL.DT_Anesthesia();
                this.Search_PP_Vocam.Properties.DataSource = dtPPVocam;
                this.Search_PP_Vocam.Properties.DisplayMember = "Names";
                this.Search_PP_Vocam.Properties.ValueMember = "RowID";
                this.dtPPTinhhinh = SurgeriesBLL.DT_TheSituation();
                this.Search_Tinhhinh.Properties.DataSource = dtPPTinhhinh;
                this.Search_Tinhhinh.Properties.DisplayMember = "Names";
                this.Search_Tinhhinh.Properties.ValueMember = "RowID";
                this.dtPPTaibien = SurgeriesBLL.DT_Complications();
                this.Search_Taibien.Properties.DataSource = dtPPTaibien;
                this.Search_Taibien.Properties.DisplayMember = "Names";
                this.Search_Taibien.Properties.ValueMember = "RowID";
                this.ref_Material_UoM.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.ref_Material_UoM.DisplayMember = "UnitOfMeasureName";
                this.ref_Material_UoM.ValueMember = "UnitOfMeasureCode";
                this.LoadRepository();
                List<InstructionInf> lstInstruc = InstructionBLL.ListInstruction(0);
                foreach (var v in lstInstruc)
                {
                    this.rep_Out_Instruction.Items.Add(v.InstructionName);
                }
                this.lstEmployee = EmployeeBLL.ListEmployeeForPosition("2,3");
                this.lstPosition = EmployeePositionBLL.ListEmployeePosition(0);
                this.rep_Ekip_EmployeeCode.DataSource = lstEmployee;
                this.rep_Ekip_EmployeeCode.DisplayMember = "EmployeeName";
                this.rep_Ekip_EmployeeCode.ValueMember = "EmployeeCode";
                this.rep_Ekip_EmployeePosition.DataSource = lstPosition;
                this.rep_Ekip_EmployeePosition.DisplayMember = "PositionName";
                this.rep_Ekip_EmployeePosition.ValueMember = "PositionCode";
                this.dtEkip = SurgeriesBLL.DT_Catalog_SurgicalCrew();
                this.gridControl_Ekip.DataSource = this.dtEkip;

                DataTable tableDiagnosis = DiagnosisCustomBLL.TableDiagnosisCustom(0);
                foreach (DataRow row in tableDiagnosis.Rows)
                {
                    this.cboxDiagnosisOn.Properties.Items.Add(row["DiagnosisName"].ToString());
                    this.cboxDiagnosisOut.Properties.Items.Add(row["DiagnosisName"].ToString());
                }
                //SystemParameterInf objSys = SystemParameterBLL.ObjParameter(500);
                //this.dtimePosting = Utils.DateServer();
                //if (objSys != null && objSys.RowID > 0)
                //{
                //    this.dtimeFrom.EditValue = this.dtimePosting.AddDays(-Convert.ToInt32(objSys.Description));
                //    this.dtimeTo.EditValue = this.dtimePosting;
                //}
                //else
                //{
                //    this.dtimeFrom.EditValue = this.dtimeTo.EditValue = this.dtimePosting;
                //}
                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = this.dtWorking;
                this.EnableButton(true);
                this.butNew.Enabled = false;
                this.loadListPatientWaitingCompleted(0);
            }
            catch { }
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
        private Int32 ISDBNULL2INT32(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToInt32(b);
            }
            else
                return Convert.ToInt32(a);
        }
        
        public void EnableField(bool ena)
        {
            txtNgaybd.ReadOnly = ena; txtGiobd.ReadOnly = ena;
            txtNgaykt.ReadOnly = ena; txtGiokt.ReadOnly = ena;
            txtGhichu.Properties.ReadOnly = ena;
            txtTemplateCode.Properties.ReadOnly = ena;
            txtMach.Properties.ReadOnly = txtNhietdo.Properties.ReadOnly = txtHuyetap.Properties.ReadOnly = txtHuyetap1.Properties.ReadOnly = txtCao.Properties.ReadOnly = txtNang.Properties.ReadOnly = ena;
            txtContent.ReadOnly = ena;
            this.cboxDiagnosisOn.Properties.ReadOnly = ena;
            this.cboxDiagnosisOut.Properties.ReadOnly = ena;
            Search_CDtruocPTT.Properties.ReadOnly = ena;
            Search_CDsauPTT.Properties.ReadOnly = ena;
            Search_PP_Vocam.Properties.ReadOnly = ena;
            Search_Tinhhinh.Properties.ReadOnly = ena;
            Search_Taibien.Properties.ReadOnly = ena;
            
            gridView_Ekip.OptionsBehavior.ReadOnly = ena;
            gridView_Ekip.OptionsBehavior.Editable = !ena;
            gridView_Material.OptionsBehavior.ReadOnly = ena;
            gridView_Material.OptionsBehavior.Editable = !ena;
        }

        public void EnableButton(bool b)
        {
            butNew.Enabled = b;
            butSave.Enabled = !b;
            butUndo.Enabled = !b;
            butEdit.Enabled = false;
            butPrint.Enabled = false;
            butPrintVTTH.Enabled = false;
            butCancel.Enabled = false;
            this.butHandPoint.Enabled = !b;
        }

        public void CleanerField()
        {
            txtNgaybd.Text = txtNgaykt.Text = "__/__/____";
            txtGiobd.Text = txtGiokt.Text = "__:__";
            txtGhichu.Text = txtMach.Text = txtHuyetap.Text = txtHuyetap1.Text = txtNhietdo.Text = txtCao.Text = txtNang.Text = string.Empty;
            lbBMI.Text = string.Empty;
            txtContent.Text = string.Empty;
            this.cboxDiagnosisOn.Text = this.cboxDiagnosisOut.Text = string.Empty;
            Search_CDtruocPTT.EditValue = null;
            Search_CDsauPTT.EditValue = null;
            Search_PP_Vocam.EditValue = null;
            Search_Tinhhinh.EditValue = null;
            Search_Taibien.EditValue = null;
            txtTemplateCode.EditValue = null;
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            picPatient.Image = (Bitmap)b;
        }
  
        private void butReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
                
        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadRepository();
                if (this.dReceiptCode != 0)
                {
                    if (this.iStatus == 0)
                    {
                        this.EnableField(false);
                        this.EnableButton(false);
                        this.gridControl_PreviousList.Visible = false;
                        this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                        this.gridView_Ekip.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Thủ thuật đã thực hiện!\t\n Chỉ được xem và sửa nội dung.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký thủ thuật!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void LoadRepository()
        {
            try
            {
                this.tableItem = ItemsBLL.DT_ListItemsRef(0, sMakp, "3");
                this.repSearch_Out_ItemCode.DataSource = this.tableItem;
                this.repSearch_Out_ItemCode.DisplayMember = "ItemName";
                this.repSearch_Out_ItemCode.ValueMember = "ItemCode";
            }
            catch { }
        }
        
        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utils.isDate(this.txtNgaybd.Text))
                {
                    XtraMessageBox.Show(" Ngày bắt đầu thực hiện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaybd.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtGiobd.Text))
                {
                    XtraMessageBox.Show(" Giờ bắt đầu thực hiện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiobd.Focus();
                    return;
                }
                if (!Utils.isDate(this.txtNgaykt.Text))
                {
                    XtraMessageBox.Show(" Ngày ra không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaykt.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtGiokt.Text))
                {
                    XtraMessageBox.Show(" Giờ ra không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiokt.Focus();
                    return;
                }
                //if (Search_CDtruocPTT.EditValue == null || Search_CDtruocPTT.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Nhập chẩn đoán trước phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Search_CDtruocPTT.Focus();
                //    return;
                //}
                //if (Search_CDsauPTT.EditValue == null || Search_CDsauPTT.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Nhập chẩn đoán sau phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Search_CDsauPTT.Focus();
                //    return;
                //}
                if (this.cboxDiagnosisOn.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Nhập chẩn đoán trước phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboxDiagnosisOn.Focus();
                    return;
                }
                if (this.cboxDiagnosisOut.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Nhập chẩn đoán sau phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboxDiagnosisOut.Focus();
                    return;
                }
                if (Search_PP_Vocam.EditValue == null || Search_PP_Vocam.Text.Trim().ToString() == "")
                {
                    XtraMessageBox.Show(" Nhập phương pháp vô cảm! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Search_PP_Vocam.Focus();
                    return;
                }
                //if (Search_Tinhhinh.EditValue == null || Search_Tinhhinh.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Nhập tình hình thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Search_Tinhhinh.Focus();
                //    return;
                //}
                if (Search_Taibien.EditValue == null || Search_Taibien.Text.Trim().ToString() == "")
                {
                    XtraMessageBox.Show(" Nhập tai biến thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Search_Taibien.Focus();
                    return;
                }
                
                if (txtContent.Text != string.Empty && dReceiptCode != 0)
                {
                    var infSur = new SurgeriesINF();
                    {
                        infSur.SurgeriesCode =sSurgeriesCode;
                        infSur.PatientCode = patientCode;
                        infSur.DepartmentCode = sMakp;
                        infSur.EmployeeCode = s_uSerid;
                        infSur.DateOn = txtNgaybd.Text;
                        infSur.TimeOn = txtGiobd.Text;
                        infSur.DateOut = txtNgaykt.Text;
                        infSur.TimeOut = txtGiokt.Text;
                        infSur.ICD10On = "-1";// Search_CDtruocPTT.EditValue.ToString();
                        infSur.ICD10Out = "-1";// Search_CDsauPTT.EditValue.ToString();
                        infSur.IDAnesthesia = Convert.ToInt32(Search_PP_Vocam.EditValue);
                        infSur.IDComplications = Convert.ToInt32(Search_Taibien.EditValue);
                        infSur.IDTheSituation = Convert.ToInt32(Search_Tinhhinh.EditValue);
                        infSur.Note = txtGhichu.Text;
                        infSur.Content = txtContent.RtfText.ToString();
                        infSur.ObjectCode = iObjectCode;
                        infSur.PatientReceiveID = dPatientReceiveID;
                        infSur.PatientType = iPatientType;
                        infSur.EmployeeCodeUpd = s_uSerid;
                        infSur.IDSuggested = dReceiptCode;
                        infSur.DiagnosisCustomOn = this.cboxDiagnosisOn.Text.Trim();
                        infSur.DiagnosisCustomOut = this.cboxDiagnosisOut.Text.Trim();
                        infSur.ShiftWork = this.shiftWork;
                    };
                    int iresult = SurgeriesBLL.Ins(infSur, ref sSurgeriesCode, dReceiptCode);
                    if (iresult > 0 && sSurgeriesCode !=string.Empty)
                    {
                        if (this.txtMach.Text.Trim() != string.Empty || this.txtNhietdo.Text.Trim() != string.Empty || this.txtHuyetap.Text.Trim() != string.Empty || this.txtHuyetap1.Text.Trim() != string.Empty || this.txtCao.Text.Trim() != string.Empty || this.txtNang.Text.Trim() != string.Empty)
                        {
                            List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
                            lstSur = SurviveSignBLL.ListSurviveSignForRefCode(sSurgeriesCode, dPatientReceiveID, patientCode);
                            if (lstSur.Count > 0)
                            {
                                SurviveSignInf infsur = new SurviveSignInf();
                                infsur.RowID = lstSur[0].RowID;
                                infsur.PatientCode = patientCode;
                                infsur.Pulse = txtMach.Text.Trim();
                                infsur.Temperature = txtNhietdo.Text.Trim();
                                infsur.BloodPressure = txtHuyetap.Text.Trim();
                                infsur.BloodPressure1 = txtHuyetap1.Text.Trim();
                                infsur.Weight = txtNang.Text.Trim();
                                infsur.Hight = txtCao.Text;
                                infsur.EmployeeCode = s_uSerid;
                                infsur.RefID = dPatientReceiveID;
                                infsur.ReferenceCode = sSurgeriesCode;
                                SurviveSignBLL.InsSurviveSign(infsur);
                            }
                            else
                            {
                                SurviveSignInf infsur = new SurviveSignInf();
                                infsur.RowID = 0;
                                infsur.PatientCode = patientCode;
                                infsur.Pulse = txtMach.Text.Trim();
                                infsur.Temperature = txtNhietdo.Text.Trim();
                                infsur.BloodPressure = txtHuyetap.Text.Trim();
                                infsur.BloodPressure1 = txtHuyetap1.Text.Trim();
                                infsur.Weight = txtNang.Text.Trim();
                                infsur.Hight = txtCao.Text.Trim();
                                infsur.EmployeeCode = s_uSerid;
                                infsur.RefID = dPatientReceiveID;
                                infsur.ReferenceCode = sSurgeriesCode;
                                infsur.CreateDate = Utils.DateTimeServer();
                                SurviveSignBLL.InsSurviveSign(infsur);
                            }
                        }
                        SurgeriesBLL.DelSurgicalCrew(sSurgeriesCode);
                        foreach (DataRow dr in dtEkip.Rows)
                        {
                            SurgeriesBLL.InsSurgicalCrew(sSurgeriesCode, dr["EmployeeCode"].ToString(), Convert.ToInt32(dr["PositionCode"].ToString()));
                        }

                        #region Xuat thuoc tu truc

                        if (gridView_Material.RowCount != 0 && iPaid == 0)//&& iStatus == 0)
                        {
                            decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                            bool bcheckInventory = true, bImportDate = false, bShipment = false, bDateEnd = false, bCheckQuantity = true;
                            string sMsgError = string.Empty, sError = string.Empty;
                            foreach (DataRow r in dtMedicalRecord_Material.Rows)
                            {
                                dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                                dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, r["RepositoryCode"].ToString(), ref dAmountEnd);
                                if (dAmountEnd < dQuantityReq)
                                {
                                    sMsgError += r["ItemName"].ToString() + " tồn: " + dAmountEnd.ToString("N0");
                                    bcheckInventory = false;
                                }
                                if (dQuantityReq <= 0)
                                {
                                    sError += r["ItemName"].ToString() + "(" + dQuantityReq + ");";
                                    bCheckQuantity = false;
                                }
                            }
                            if (!bCheckQuantity)
                            {
                                XtraMessageBox.Show(" Những thuốc sau không có số lượng! \n" + sError, "Bệnh viện điện tử .NET");
                                return;
                            }
                            if (bcheckInventory)
                            {
                                SystemParameterInf para = new SystemParameterInf();
                                para = SystemParameterBLL.ObjParameter(200);
                                string sSort = string.Empty;
                                if (para != null && para.Values == 1)
                                {
                                    bImportDate = true;
                                    sSort += "DateImport,";
                                }
                                para = SystemParameterBLL.ObjParameter(201);
                                if (para != null && para.Values == 1)
                                {
                                    bShipment = true;
                                    sSort += "Shipment,";
                                }
                                para = SystemParameterBLL.ObjParameter(202);
                                if (para != null && para.Values == 1)
                                {
                                    bDateEnd = true;
                                    sSort += "DateEnd,";
                                }
                                string sItemCode = string.Empty;
                                RealMedicinesForPatientsINF infReal = new RealMedicinesForPatientsINF();
                                {
                                    infReal.RowID = dRealID;
                                    infReal.RefCode = sSurgeriesCode;
                                    infReal.PatientReceiveID = dPatientReceiveID;
                                    infReal.PatientCode = patientCode;
                                    infReal.EmployeeCode = s_uSerid;
                                    infReal.ObjectCode = iObjectCode;
                                    infReal.PatientType = iPatientType;
                                    infReal.VoteRowID = 1;
                                    infReal.Status = 1;
                                    infReal.DepartmentCode = sMakp;
                                    infReal.DateApproved = Utils.StringToDate(txtNgaybd.Text.Trim());
                                    infReal.ShiftWork = this.shiftWork;
                                };
                                if (RealMedicinesForPatientsBLL.InsReal(infReal, ref dRealID) > 0)
                                {
                                    bool isGiaThuocDanhMuc = false;
                                    SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
                                    if (objSys != null && objSys.RowID > 0)
                                    {
                                        isGiaThuocDanhMuc = objSys.Values.Equals(1) ? true : false;
                                    }
                                    bool bResult = true;
                                    RealMedicinesForPatientsBLL.DelRealDetailOnly(dRealID);
                                    if (dtMedicalRecord_Material != null && dtMedicalRecord_Material.Rows.Count > 0)
                                    {
                                        foreach (DataRow r in dtMedicalRecord_Material.Rows)
                                        {
                                            decimal dQuantityRequest = Convert.ToDecimal(r["Quantity"].ToString());
                                            decimal dQuantityReal = 0;
                                            sItemCode = r["ItemCode"].ToString();
                                            List<InventoryGumshoeInf> lst = InventoryBLL.ListInventoryGumshoe(sItemCode, r["RepositoryCode"].ToString(), sSort.TrimEnd(','), isGiaThuocDanhMuc);
                                            if (lst != null && lst.Count > 0)
                                            {
                                                RealMedicinesForPatientsDetailINF mDetail = new RealMedicinesForPatientsDetailINF();
                                                foreach (var v in lst)
                                                {
                                                    dQuantityReal = v.AmountImport - v.AmountExport;
                                                    if (dQuantityReal >= dQuantityRequest)
                                                    {
                                                        mDetail.RealRowID = dRealID;
                                                        mDetail.ItemCode = r["ItemCode"].ToString();
                                                        mDetail.Quantity = dQuantityRequest;
                                                        mDetail.SalesPrice = v.SalesPrice;
                                                        mDetail.BHYTPrice = v.BHYTPrice;
                                                        mDetail.RowIDInventoryGumshoe = v.RowID;
                                                        mDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                                        mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                                        if (mDetail.ObjectCode.Equals(1) || mDetail.ObjectCode.Equals(5))
                                                            mDetail.UnitPrice = v.UnitPrice;
                                                        else
                                                            mDetail.UnitPrice = v.SalesPrice;
                                                        mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                                        mDetail.Instruction = r["Instruction"].ToString();
                                                        if (r["RowID"].ToString() != string.Empty)
                                                            mDetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                                                        else
                                                            mDetail.RowID = 0;
                                                        mDetail.Amount = mDetail.Quantity * mDetail.UnitPrice;
                                                        RealMedicinesForPatientsBLL.InsRealDetail(mDetail);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        mDetail.RealRowID = dRealID;
                                                        mDetail.ItemCode = v.ItemCode;
                                                        mDetail.Quantity = dQuantityReal;
                                                        mDetail.SalesPrice = v.SalesPrice;
                                                        mDetail.BHYTPrice = v.BHYTPrice;
                                                        mDetail.RowIDInventoryGumshoe = v.RowID;
                                                        mDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                                        mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                                        if (mDetail.ObjectCode.Equals(1) || mDetail.ObjectCode.Equals(5))
                                                            mDetail.UnitPrice = v.UnitPrice;
                                                        else
                                                            mDetail.UnitPrice = v.SalesPrice;
                                                        mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                                        mDetail.Instruction = r["Instruction"].ToString();
                                                        if (r["RowID"].ToString() != string.Empty)
                                                            mDetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                                                        else
                                                            mDetail.RowID = 0;
                                                        mDetail.Amount = mDetail.Quantity * mDetail.UnitPrice;
                                                        RealMedicinesForPatientsBLL.InsRealDetail(mDetail);
                                                        dQuantityRequest = dQuantityRequest - dQuantityReal;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                bResult = false;
                                                RealMedicinesForPatientsBLL.DelRealDetailAll(dRealID);
                                                XtraMessageBox.Show(" Tồn kho không đủ để cấp thuốc, liên hệ quản trị ! \n\t", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    XtraMessageBox.Show(" Lưu đơn thuốc không thành công ! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(" Thuốc không đủ tồn : \n\t" + sMsgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        #endregion

                        XtraMessageBox.Show(" Lưu kết quả thủ thuật thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gridControl_PreviousList.Visible = true;
                        this.EnableField(false);
                        this.EnableButton(true);
                        this.butSave.Enabled = this.butNew.Enabled = this.butUndo.Enabled = false;
                        this.butEdit.Enabled = true;
                        this.butPrint.Enabled = true;
                        this.butPrintVTTH.Enabled = true;
                        this.gridView_Material.OptionsBehavior.ReadOnly = true;
                        this.gridView_Material.OptionsBehavior.Editable = false;
                        this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        this.GetHistoryPatient();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Lưu kết quả thủ thuật không thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Đề nghị nhập nội dung thủ thuật trước khi lưu !\t ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi lưu kết quả thủ thuật !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grPrevious.Visible = false;
                this.dPatientReceiveID = 0;
                this.dReceiptCode = 0;
                this.sReferenceCode = string.Empty;
                this.patientCode = string.Empty;
                this.serviceName = string.Empty;
                this.iStatus = 0;
                this.grMain.Text = string.Empty;
                this.EnableField(false);
                this.CleanerField();
                this.EnableButton(true);
                this.butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceCode != string.Empty && patientCode != string.Empty)
                {
                    DataTable dtResult = SurgeriesBLL.DT_RptViewSurgeries(sSurgeriesCode, this.dPatientReceiveID);
                    DataTable dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(sSurgeriesCode, patientCode, dPatientReceiveID, this.dtWorking);
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(sSurgeriesCode, this.patientCode, this.dPatientReceiveID);
                    //DataTable dtSurgicalCrew = SurgeriesBLL.DT_SurgicalCrew(sSurgeriesCode);
                    DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(dPatientReceiveID);

                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.Tables.Add(dtEmergencyDetail);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtBHYT);
                    //dsTemp.Tables.Add(dtSurgicalCrew);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptPhauThuThuat.xml");
                    Reports.rptPhauThuThuat rptShow = new Reports.rptPhauThuThuat();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PTTT","PTTT");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt thực hiện từ danh sách để in phiếu Phẫu Thủ Thuật!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void loadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(507);
            if (objSys != null && objSys.RowID > 0)
            {
                this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingServicePTT(Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), iStatus, this.sMakp, objSys.Values, iMenu);
            }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grWaitingList.Dock = DockStyle.Fill;
                this.grPrevious.Visible = false;
                this.grPrevious.Dock = DockStyle.None;
                this.grMain.Text = "Quản lý thủ thuật!";
                this.butReload_Click(sender, e);
                this.EnableField(true);
                this.CleanerField();
                this.patientCode = this.patientName = this.serviceCode = this.serviceName = this.sSurgeriesCode = this.sReferenceCode = string.Empty;
                this.dPatientReceiveID = this.dReceiptCode = this.dRealID = 0;
                this.iStatus = this.iPatientType = this.iObjectCode = this.iTraituyen = 0;
                this.imageCode = this.sTheBHYT = this.sBanksAccountCode = string.Empty;
                this.iPaid = 0;
                this.dtMedicalRecord_Material.Clear();
                this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
                this.dtEkip = SurgeriesBLL.DT_Catalog_SurgicalCrew();
                this.gridControl_Ekip.DataSource = dtEkip;
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
            }
            catch { }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadListPatientWaitingCompleted(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CheckCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadListPatientWaitingCompleted(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }    
        
        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_WaitingList.RowCount > 0)
                {
                    if (gridView_WaitingList.GetFocusedRow() != null)
                    {
                        gridControl_PreviousList.Visible = true;
                        this.CleanerField();
                        dtMedicalRecord_Material.Clear();
                        gridControl_Material.DataSource = dtMedicalRecord_Material;
                        dtEkip = SurgeriesBLL.DT_Catalog_SurgicalCrew();
                        gridControl_Ekip.DataSource = dtEkip;

                        grWaitingList.Visible = false;
                        grWaitingList.Dock = DockStyle.None;
                        grPrevious.Visible = true;
                        grPrevious.Dock = DockStyle.Fill;
                        
                        dPatientReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RefID).ToString());
                        dReceiptCode = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReceiptID).ToString());
                        sReferenceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString();
                        patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        serviceCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString(), string.Empty);
                        serviceName = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceName).ToString(), string.Empty);
                        iStatus = ISDBNULL2INT32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Status), 404);
                        iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                        
                        string name = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString(), string.Empty);
                        string gender = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString(), string.Empty);
                        string year = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString(), string.Empty);
                        string address = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientAddress).ToString(), string.Empty);
                        grMain.Text = sNamekp + " | " + Convert.ToString(serviceName + " - Họ tên: " + name + " | Giới tính: " + gender + " | Năm sinh: " + year + " | Địa chỉ: " + address);
                        loadTemplate();
                        List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(dPatientReceiveID);
                        iPatientType = lstReceive[0].PatientType;
                        if (iStatus == 1)
                        {
                            this.ObjectSurgeries();
                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            this.gridView_Ekip.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        }
                        if (iStatus == 0)
                        {
                            butNew.Enabled = true;
                            List<SurviveSignInf> lstSign = SurviveSignBLL.ListSurviveSignForRefCode(sReferenceCode, dPatientReceiveID, patientCode);
                            if (lstSign != null && lstSign.Count > 0)
                            {
                                txtMach.Text = lstSign[0].Pulse;
                                txtNhietdo.Text = lstSign[0].Temperature;
                                txtHuyetap.Text = lstSign[0].BloodPressure;
                                txtHuyetap1.Text = lstSign[0].BloodPressure1;
                                txtNang.Text = lstSign[0].Weight;
                                txtCao.Text = lstSign[0].Hight;
                            }
                            txtNgaybd.Text = txtNgaykt.Text = this.dtWorking.ToString("dd/MM/yyyy");
                            txtGiobd.Text = txtGiokt.Text = Utils.TimeServer();
                        }
                        else
                        {
                            List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
                            lstSur = SurviveSignBLL.ListSurviveSignForRefCode(sSurgeriesCode, dPatientReceiveID, patientCode);
                            if (lstSur != null && lstSur.Count > 0)
                            {
                                txtMach.Text = lstSur[0].Pulse;
                                txtNhietdo.Text = lstSur[0].Temperature;
                                txtHuyetap.Text = lstSur[0].BloodPressure;
                                txtHuyetap1.Text = lstSur[0].BloodPressure1;
                                txtNang.Text = lstSur[0].Weight;
                                txtCao.Text = lstSur[0].Hight;
                            }
                            butEdit.Enabled = butUndo.Enabled = butPrint.Enabled = butPrintVTTH.Enabled = true;
                            butNew.Enabled = false;
                        }

                        if (iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = new List<BHYTInf>();
                            lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dPatientReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                sTheBHYT = lstBHYT[0].Serial;
                                lbSothe.Text = lstBHYT[0].Serial;
                                lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                iTraituyen = lstBHYT[0].TraiTuyen;
                                if (iTraituyen == 1)
                                    chkTraiTuyen.Checked = true;
                                else
                                    chkTraiTuyen.Checked = false;
                                lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                GetCardInfo(lstBHYT[0].Serial);
                                VisableBHYT(true);
                            }
                        }
                        else
                        {
                            lbTileBHYT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                            VisableBHYT(false);
                        }

                        this.dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicinesForEmergency(sSurgeriesCode, iObjectCode, sMakp, 3, Utils.StringToDate(txtNgaybd.Text.Trim()), ref dRealID);
                        this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
                        if (dtMedicalRecord_Material.Rows.Count > 0)
                        {
                            dRealID = Convert.ToDecimal(dtMedicalRecord_Material.Rows[0][0].ToString());
                        }
                        if (dtEkip.Rows.Count <= 0)
                        {
                            dtEkip = SurgeriesBLL.DT_Catalog_SurgicalCrew();
                            gridControl_Ekip.DataSource = dtEkip;
                        }
                        if (iStatus == 0)
                        {
                            this.Search_PP_Vocam.EditValue = 1;
                            this.Search_Taibien.EditValue = 1;
                            this.Search_Tinhhinh.EditValue = 1;
                        }
                        this.GetInfoPatient();
                        this.GetHistoryPatient();
                        this.ProcessBMI();
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }

        private void loadTemplate()
        {
            this.txtTemplateCode.Properties.DataSource = TemplateDescriptionBLL.TableListTemplateForService(this.serviceCode, string.Empty);
            this.txtTemplateCode.Properties.ValueMember = "TemplateHeaderCode";
            this.txtTemplateCode.Properties.DisplayMember = "TemplateHeaderName";
        }

        private void ObjectSurgeries()
        {
            try
            {
                SurgeriesINF obj = SurgeriesBLL.ObjSurgeries(dReceiptCode);
                sSurgeriesCode = obj.SurgeriesCode;
                txtNgaybd.Text = obj.DateOn; txtGiobd.Text = obj.TimeOn;
                txtNgaykt.Text = obj.DateOut; txtGiokt.Text = obj.TimeOut;
                //Search_CDtruocPTT.EditValue = obj.ICD10On;
                //Search_CDsauPTT.EditValue = obj.ICD10Out;
                Search_PP_Vocam.EditValue = obj.IDAnesthesia;
                Search_Tinhhinh.EditValue = obj.IDTheSituation;
                Search_Taibien.EditValue = obj.IDComplications;
                txtGhichu.Text = obj.Note;
                txtContent.RtfText = obj.Content;
                iPaid = obj.Paid;
                sBanksAccountCode = obj.BanksAccountCode;
                dPatientReceiveID = obj.PatientReceiveID;
                patientCode = obj.PatientCode;
                iObjectCode = obj.ObjectCode;
                this.cboxDiagnosisOn.Text = obj.DiagnosisCustomOn;
                this.cboxDiagnosisOut.Text = obj.DiagnosisCustomOut;
                dtEkip = SurgeriesBLL.DT_SurgicalCrew(sSurgeriesCode);
                gridControl_Ekip.DataSource = dtEkip;
            }
            catch { }
        }

        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 2);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (chkTraiTuyen.Checked == true)
                        lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                    else
                        lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                }
            }
            catch { }
        }

        private void VisableBHYT(bool b)
        {
            this.lbSothe.Visible = b;
            this.lbTungay.Visible = b;
            this.chkTraiTuyen.Visible = b;
            this.lbNoiDKKCB.Visible = b;
            this.lbDenngay.Visible = b;
        }

        private void GetHistoryPatient()
        {
            this.gridControl_PreviousList.DataSource = ServiceRadiologyBLL.ListPreviousPTT(this.patientCode, this.iMenu);
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.dPatientReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    lbMabn01.Text = objPatient.PatientCode;
                    lbHoten01.Text = objPatient.PatientName;
                    lbNamsinh01.Text = objPatient.PatientBirthday.ToString().Substring(0, 10); //objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
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
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_PreviousList.RowCount > 0)
                {
                    if (gridView_PreviousList.GetFocusedRow() != null)
                    {
                        serviceCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                        String sEmployeeCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_EmployeeCode).ToString(), string.Empty);
                        if (sBanksAccountCode != string.Empty && iPaid == 1)
                        {
                            XtraMessageBox.Show(" Bệnh nhân thanh toán ra viện không cho phép xóa hoặc sửa! ", "Bệnh viện điện tử .NET");
                            return;
                        }
                        else if (sEmployeeCode == s_uSerid)
                        {
                            if (serviceCode != string.Empty)
                            {
                                if (iPaid == 0 && sBanksAccountCode.Trim() == string.Empty)
                                {
                                    this.gridControl_PreviousList.Visible = true;
                                    this.EnableField(false);
                                    this.butSave.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butHandPoint.Enabled = true;
                                    this.butEdit.Enabled = this.butPrint.Enabled = this.butPrintVTTH.Enabled = false;
                                    this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                                    this.gridView_Ekip.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                                }
                                else
                                {
                                    XtraMessageBox.Show(" Bệnh nhân đã thanh toán ra viện không cho phép xóa, sữa! ", "Bệnh viện điện tử .NET");
                                    return;
                                }
                            }
                            else
                            {

                                XtraMessageBox.Show(" Chọn đợt phẫu thủ thuật cần sửa lại thông tin! ", "Bệnh viện điện tử .NET");
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khác bác sĩ thực hiện phẫu thủ thuật, không cho phép sửa! ", "Bệnh viện điện tử .NET");
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chọn đợt thực hiện cần sửa lại thông tin! ", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa có thực hiện phẫu thủ thuật!", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkWaiting.Checked == true)
                {
                    this.loadListPatientWaitingCompleted(0);
                }
                if (CheckCompleted.Checked == true)
                {
                    this.loadListPatientWaitingCompleted(1);
                }
                this.EnableButton(true);
                butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void frmThuThuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: butReload_Click(sender, e); break;                    //F5 - Refresh
                    case Keys.F1: butContinues_Click(sender, e); break;                 //F1 - Bệnh nhân tiếp
                    case Keys.F2: butNew_Click(sender, e); break;                     //F2 - Thực hiện
                    case Keys.F3: butSave_Click(sender, e); break;                    //F3 - Lưu
                    case Keys.F6: butPrint_Click(sender, e); break;                   //F6 - In toa
                }
            }
            catch
            {
                return;
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
            if (!Utils.IsNumber(txtNang.Text.Trim()))
            {
                XtraMessageBox.Show(" Cân nặng phải nhập số!", "Bệnh viện điện tử .NET");
                txtNang.Focus();
                return;
            }
            else
            {
                ProcessBMI();
            }
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHuyetap.Focus();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{Tab}{F4}");
                txtCao.Focus();
            }
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHuyetap1.Focus();
                //SendKeys.Send("{Tab}{F4}");
            }
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

        private void txtHuyetap1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtNhietdo.Focus();
        }

        private void txtHuyetap1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNhietdo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{Tab}{F4}");
                txtCao.Focus();
            }
        }

        private void txtNhietdo_Validated(object sender, EventArgs e)
        {
            if (!Utils.IsNumber(txtNhietdo.Text.Trim()))
            {
                XtraMessageBox.Show(" Nhiệt độ phải nhập số!", "Bệnh viện điện tử .NET");
                txtNhietdo.Focus();
                return;
            }
        }

        private void txtCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNang.Focus();
            }
        }

        private void txtCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtContent.Focus();
            }
        }

        private void txtNgaybd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtGiobd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtNgaykt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtGiokt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void Search_CDtruocPTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void Search_CDsauPTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void Search_PP_Vocam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void Search_Tinhhinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void Search_Taibien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtGhichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void gridControl_Ekip_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Ekip.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                gridView_Ekip.DeleteSelectedRows();
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                String sEmployeeCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_EmployeeCode).ToString(), string.Empty);
                if (sBanksAccountCode != string.Empty && iPaid == 1)
                {
                    XtraMessageBox.Show(" Bệnh nhân thanh toán ra viện không cho phép xóa hoặc sửa! ", "Bệnh viện điện tử .NET");
                    return;
                }
                else if (sEmployeeCode != s_uSerid)
                {
                    XtraMessageBox.Show(" Khác bác sĩ thực hiện phẫu thủ thuật, không cho phép sửa! ", "Bệnh viện điện tử .NET");
                    return;
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn thật sự muốn hủy phiếu phẫu thủ thuật này không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        if (SurgeriesBLL.DelSurgeries(sSurgeriesCode) == 1)
                        {
                            XtraMessageBox.Show(" Hủy phiếu phẫu thủ thuật thành công! ", "Bệnh viện điện tử .NET");
                            gridControl_PreviousList.Visible = true;
                            EnableField(true);
                            EnableButton(true);
                            butNew.Enabled = false;
                            GetHistoryPatient();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Hủy phiếu phẫu thủ thuật không thành công! ", "Bệnh viện điện tử .NET");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch { }
        }

        private void gridView_Material_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            int rowfocus = e.RowHandle;
            try
            {
                string stempItemcode = view.GetRowCellValue(rowfocus, col_Material_ItemCode).ToString();
                if (stempItemcode == null || stempItemcode == "")
                {
                    e.Valid = false;
                    view.SetColumnError(col_Material_ItemCode, " Chọn thuốc cần kê toa!");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Material_Quantity, " Số lượng yêu cầu lớn hơn 0!");
                }
                //if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_UnitPrice)), 1) <= 0)
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_Material_UnitPrice, "Chưa khai đơn giá cho vật tư tiêu hao!");
                //}
                if (e.Valid)
                {
                    decimal unitPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_UnitPrice));
                    decimal salesPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_SalesPrice));
                    decimal bhytPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_BHYTPrice));
                    decimal quantityTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_Quantity));
                    Int32 listBHYTTemp = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Material_ListBHYT));
                    if (this.iObjectCode.Equals(1) || this.iObjectCode.Equals(5))
                    {
                        if (listBHYTTemp.Equals(1))
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * bhytPriceTemp);
                        else
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * salesPriceTemp);
                    }
                    else
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * salesPriceTemp);
                }
            }
            catch { return; }
        }

        private void gridView_Material_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Quantity")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }
        }

        private void gridView_Material_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa thuốc - VTTH đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        decimal tempRealID = Convert.ToDecimal(gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_RealRowID).ToString());
                        string tempItemCode = gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_ItemCode).ToString();
                        decimal tempRowID = Convert.ToDecimal(gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_RowID).ToString());
                        Int32 iResult = RealMedicinesForPatientsBLL.DelRealDetailForItems(tempRealID, tempItemCode, tempRowID);
                        if (iResult >= 1)
                        {
                            this.LoadRepository();
                            if (this.dtMedicalRecord_Material.Rows.Count <= 0)
                                this.EnableButton(true);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thuốc đang chọn đã thanh toán, hoặc đã được duyệt! Không cho phép xóa!", "Bệnh viện điện tử .NET");
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi xóa thuốc: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Material_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Phiếu xuất thuốc thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private void gridView_PreviousList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_PreviousList.RowCount > 0)
                {
                    if (gridView_PreviousList.GetFocusedRow() != null)
                    {
                        serviceCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                        serviceName = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceName).ToString(), string.Empty);
                        decimal dRowID = ISDBNULL2DECIMAL(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_RowID).ToString(), string.Empty);
                        iStatus = 1;
                        if (serviceCode != string.Empty && dReceiptCode > 0)
                        {

                            this.CleanerField();
                            this.butEdit.Enabled = true;
                            this.butPrint.Enabled = this.butPrintVTTH.Enabled = true;

                            SurgeriesINF obj = SurgeriesBLL.ObjSurgeriesForID(dRowID);
                            sSurgeriesCode = obj.SurgeriesCode;
                            txtNgaybd.Text = obj.DateOn; txtGiobd.Text = obj.TimeOn;
                            txtNgaykt.Text = obj.DateOut; txtGiokt.Text = obj.TimeOut;
                            //Search_CDtruocPTT.EditValue = obj.ICD10On;
                            //Search_CDsauPTT.EditValue = obj.ICD10Out;
                            Search_PP_Vocam.EditValue = obj.IDAnesthesia;
                            Search_Tinhhinh.EditValue = obj.IDTheSituation;
                            Search_Taibien.EditValue = obj.IDComplications;
                            txtGhichu.Text = obj.Note;
                            txtContent.RtfText = obj.Content;
                            iPaid = obj.Paid;
                            sBanksAccountCode = obj.BanksAccountCode;
                            dPatientReceiveID = obj.PatientReceiveID;
                            patientCode = obj.PatientCode;
                            iObjectCode = obj.ObjectCode;
                            this.cboxDiagnosisOn.Text = obj.DiagnosisCustomOn;
                            this.cboxDiagnosisOut.Text = obj.DiagnosisCustomOut;
                            dtEkip = SurgeriesBLL.DT_SurgicalCrew(sSurgeriesCode);
                            gridControl_Ekip.DataSource = dtEkip;
                            grMain.Text = sNamekp + " | " + Convert.ToString(serviceName);
                            List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(dPatientReceiveID);
                            iPatientType = lstReceive[0].PatientType;
                            List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
                            lstSur = SurviveSignBLL.ListSurviveSignForRefCode(sSurgeriesCode, dPatientReceiveID, patientCode);
                            if (lstSur != null && lstSur.Count > 0)
                            {
                                txtMach.Text = lstSur[0].Pulse;
                                txtNhietdo.Text = lstSur[0].Temperature;
                                txtHuyetap.Text = lstSur[0].BloodPressure;
                                txtHuyetap1.Text = lstSur[0].BloodPressure1;
                                txtNang.Text = lstSur[0].Weight;
                                txtCao.Text = lstSur[0].Hight;
                            }

                            if (iObjectCode == 1)
                            {
                                List<BHYTInf> lstBHYT = new List<BHYTInf>();
                                lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dPatientReceiveID);
                                if (lstBHYT.Count > 0)
                                {
                                    sTheBHYT = lstBHYT[0].Serial;
                                    lbSothe.Text = lstBHYT[0].Serial;
                                    lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                    iTraituyen = lstBHYT[0].TraiTuyen;
                                    if (iTraituyen == 1)
                                        chkTraiTuyen.Checked = true;
                                    else
                                        chkTraiTuyen.Checked = false;
                                    lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                    lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                    GetCardInfo(lstBHYT[0].Serial);
                                    VisableBHYT(true);
                                }
                            }
                            else
                            {
                                lbTileBHYT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                                VisableBHYT(false);
                            }
                            butEdit.Enabled = butUndo.Enabled = true;
                            butNew.Enabled = false;
                            gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            gridView_Ekip.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicines(sSurgeriesCode, iObjectCode, sMakp, 3, this.dtWorking);
                            gridControl_Material.DataSource = dtMedicalRecord_Material;
                            GetInfoPatient();
                            ProcessBMI();
                        }
                        else
                        {
                            serviceCode = string.Empty;
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch { }
        }
        
        private void picRelation_Click(object sender, EventArgs e)
        {
            if (this.patientCode.Trim().Length > 0)
            {
                frmRelationPatient frm = new frmRelationPatient(this.dPatientReceiveID, this.s_uSerid, this.patientCode);
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
            if (this.patientCode == string.Empty || this.dPatientReceiveID == 0)
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để đính kèm file văn bản hình ảnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.dPatientReceiveID, this.patientCode);
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
        
        private void butPrintVTTH_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceCode != string.Empty && patientCode != string.Empty)
                {
                    DataTable dtResult = new DataTable("KetquaThuThuat");
                    dtResult = SurgeriesBLL.DT_RptViewSurgeries(sSurgeriesCode, this.dPatientReceiveID);

                    DataTable dtEmergencyDetail = new DataTable("ResultEmergencyDetail");
                    dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(sSurgeriesCode, patientCode, dPatientReceiveID, this.dtWorking);
                    DataTable dtSurviveSign = new DataTable("SurviveSign");
                    dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(sSurgeriesCode, this.patientCode, this.dPatientReceiveID);

                    //DataTable dtSurgicalCrew = SurgeriesBLL.DT_SurgicalCrew(sSurgeriesCode);
                    DataTable dtBHYT = new DataTable("Medical");
                    dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(dPatientReceiveID);

                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.Tables.Add(dtEmergencyDetail);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtBHYT);
                    //dsTemp.Tables.Add(dtSurgicalCrew);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptPhauThuThuatVTTH.xml");
                    Reports.rptPhauThuThuatVTTH rptShow = new Reports.rptPhauThuThuatVTTH();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PTTT_VTTH", "PTTT-VTTH");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt thực hiện từ danh sách để in phiếu Phẫu Thủ Thuật!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Material_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                //if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is LookUpEdit)
                //{
                //    Text = view.ActiveEditor.Parent.Name;
                //    DevExpress.XtraEditors.LookUpEdit edit;
                //    edit = (LookUpEdit)view.ActiveEditor;
                //    DataTable table = edit.Properties.LookUpData.DataSource as DataTable;
                //    cloneout = new DataView(table);
                //    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                //    cloneout.RowFilter = "AmountEnd >0 ";
                //    edit.Properties.LookUpData.DataSource = cloneout;
                //}

                if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is SearchLookUpEdit)
                {
                    Text = view.ActiveEditor.Parent.Name;
                    DevExpress.XtraEditors.SearchLookUpEdit searchEdit;
                    searchEdit = (SearchLookUpEdit)view.ActiveEditor;
                    DataTable table = this.repSearch_Out_ItemCode.DataSource as DataTable;
                    cloneout = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    cloneout.RowFilter = "AmountEnd >0 ";
                    searchEdit.Properties.DataSource = cloneout;
                }
                else if (view.FocusedColumn.FieldName == "ObjectCode" && view.ActiveEditor is LookUpEdit)
                {
                    DevExpress.XtraEditors.LookUpEdit objectEdit;
                    objectEdit = (LookUpEdit)view.ActiveEditor;
                    DataTable table = this.ref_ObjectCode.DataSource as DataTable;
                    DataView viewOject = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    if (!this.iObjectCode.Equals(1))
                        viewOject.RowFilter = "ObjectCode <>1";
                    objectEdit.Properties.DataSource = viewOject;
                }
            }
            catch { }
        }

        private void gridView_Material_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneout != null)
            {
                cloneout.Dispose();
                cloneout = null;
            }
        }

        private void txtTemplateCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string templateCode = ISDBNULL2STRING(txtTemplateCode.EditValue, string.Empty);
                if (string.IsNullOrEmpty(templateCode))
                {
                    return;
                }
                else
                {
                    var queryTemplate = TemplateDescriptionBLL.ObjTemplate(templateCode);///.FirstOrDefault();
                    if (queryTemplate != null)
                    {
                        this.txtContent.RtfText = queryTemplate.Contents;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void repSearch_Out_ItemCode_EditValueChanged(object sender, EventArgs e)
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
                decimal bhytPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("BHYTPrice").ToString());
                decimal salesPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice").ToString());
                Int32 rateBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("RateBHYT").ToString());
                Int32 listBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("ListBHYT").ToString());
                string itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
                string noteTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Note").ToString();
                string usageCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UsageCode").ToString();
                decimal unitPriceTemp = 0;
                DataRow r = Utils.GetPriceRowbyCode(this.dtMedicalRecord_Material, "ItemCode='" + itemCodeTemp + "' and RepositoryCode='" + repositoryCodeTemp + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê trong toa thuốc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, null);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 0);
                }
                else
                {
                    if (amountEndTemp <= safelyQuantityTemp)
                    {
                        if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục kê thuốc không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_SalesPrice, salesPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_BHYTPrice, bhytPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_RateBHYT, rateBHYTTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryCode, repositoryCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryName, repositoryNameTemp);
                            if (this.iObjectCode == 1)
                            {
                                if (listBHYTTemp == 1)
                                {
                                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, this.iObjectCode);
                                    unitPriceTemp = bhytPriceTemp;
                                }
                                else
                                {
                                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, 2);
                                    unitPriceTemp = salesPriceTemp;
                                }
                            }
                            else
                            {
                                this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, iObjectCode);
                                unitPriceTemp = salesPriceTemp;
                            }
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitPrice, unitPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, unitPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemName, itemNameTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_ListBHYT, listBHYTTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Usage, usageCodeTemp);
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
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_SalesPrice, salesPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_BHYTPrice, bhytPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_RateBHYT, rateBHYTTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryCode, repositoryCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryName, repositoryNameTemp);
                        if (this.iObjectCode == 1)
                        {
                            if (listBHYTTemp == 1)
                            {
                                this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, this.iObjectCode);
                                unitPriceTemp = bhytPriceTemp;
                            }
                            else
                            {
                                this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, 2);
                                unitPriceTemp = salesPriceTemp;
                            }
                        }
                        else
                        {
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, iObjectCode);
                            unitPriceTemp = salesPriceTemp;
                        }
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitPrice, unitPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, unitPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemName, itemNameTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_ListBHYT, listBHYTTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Usage, usageCodeTemp);
                    }
                }
                this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
            }
            catch { }
        }

        private void butHSBA_Click(object sender, EventArgs e)
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

        private void butHandPoint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utils.isDate(this.txtNgaybd.Text))
                {
                    XtraMessageBox.Show(" Ngày bắt đầu thực hiện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaybd.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtGiobd.Text))
                {
                    XtraMessageBox.Show(" Giờ bắt đầu thực hiện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiobd.Focus();
                    return;
                }
                if (!Utils.isDate(this.txtNgaykt.Text))
                {
                    XtraMessageBox.Show(" Ngày ra không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaykt.Focus();
                    return;
                }
                if (!Utils.isHour(txtGiokt.Text))
                {
                    XtraMessageBox.Show(" Giờ ra không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiokt.Focus();
                    return;
                }
                //if (Search_CDtruocPTT.EditValue == null || Search_CDtruocPTT.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Nhập chẩn đoán trước phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Search_CDtruocPTT.Focus();
                //    return;
                //}
                //if (Search_CDsauPTT.EditValue == null || Search_CDsauPTT.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Nhập chẩn đoán sau phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Search_CDsauPTT.Focus();
                //    return;
                //}
                if (this.cboxDiagnosisOn.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Nhập chẩn đoán trước phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboxDiagnosisOn.Focus();
                    return;
                }
                if (this.cboxDiagnosisOut.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Nhập chẩn đoán sau phẫu thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboxDiagnosisOut.Focus();
                    return;
                }
                if (this.Search_PP_Vocam.EditValue == null || this.Search_PP_Vocam.Text.Trim().ToString() == "")
                {
                    XtraMessageBox.Show(" Nhập phương pháp vô cảm! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Search_PP_Vocam.Focus();
                    return;
                }
                if (this.Search_Tinhhinh.EditValue == null || this.Search_Tinhhinh.Text.Trim().ToString() == "")
                {
                    XtraMessageBox.Show(" Nhập tình hình thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Search_Tinhhinh.Focus();
                    return;
                }
                if (this.Search_Taibien.EditValue == null || this.Search_Taibien.Text.Trim().ToString() == "")
                {
                    XtraMessageBox.Show(" Nhập tai biến thủ thuật! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Search_Taibien.Focus();
                    return;
                }
                if (this.dReceiptCode != 0)
                {
                    var infSur = new SurgeriesINF();
                    {
                        infSur.SurgeriesCode = sSurgeriesCode;
                        infSur.PatientCode = patientCode;
                        infSur.DepartmentCode = sMakp;
                        infSur.EmployeeCode = s_uSerid;
                        infSur.DateOn = txtNgaybd.Text;
                        infSur.TimeOn = txtGiobd.Text;
                        infSur.DateOut = txtNgaykt.Text;
                        infSur.TimeOut = txtGiokt.Text;
                        infSur.ICD10On = "-1";// Search_CDtruocPTT.EditValue.ToString();
                        infSur.ICD10Out = "-1";// Search_CDsauPTT.EditValue.ToString();
                        infSur.IDAnesthesia = Convert.ToInt32(Search_PP_Vocam.EditValue);
                        infSur.IDComplications = Convert.ToInt32(Search_Taibien.EditValue);
                        infSur.IDTheSituation = Convert.ToInt32(Search_Tinhhinh.EditValue);
                        infSur.Note = txtGhichu.Text;
                        infSur.Content = txtContent.RtfText.ToString();
                        infSur.ObjectCode = iObjectCode;
                        infSur.PatientReceiveID = dPatientReceiveID;
                        infSur.PatientType = iPatientType;
                        infSur.EmployeeCodeUpd = s_uSerid;
                        infSur.IDSuggested = dReceiptCode;
                        infSur.DiagnosisCustomOn = this.cboxDiagnosisOn.Text.Trim();
                        infSur.DiagnosisCustomOut = this.cboxDiagnosisOut.Text.Trim();
                        infSur.ShiftWork = this.shiftWork;
                    };
                    int iresult = SurgeriesBLL.Ins(infSur, ref sSurgeriesCode, dReceiptCode);
                    if (iresult > 0 && sSurgeriesCode != string.Empty)
                    {
                        frmChiDinhDichVu frm = new frmChiDinhDichVu(this.dPatientReceiveID, this.patientCode, this.s_uSerid, iObjectCode, this.sTheBHYT, this.iTraituyen, sReferenceCode, this.iPatientType, this.sMakp, this.s_uSerid, this.serviceCode, this.shiftWork, this.dtWorking);
                        frm.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Lưu kết quả thủ thuật " + serviceName.ToUpper() + " không thành công! \t\n Hãy kiểm tra lại thông tin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show(" Lỗi phát sinh khi lưu kết quả thủ thuật !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void repSearchViewItem_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 listBHYT = 0;
                if (e.RowHandle >= 0)
                {
                    listBHYT = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ListBHYT"]));
                    if (listBHYT.Equals(1))
                        e.Appearance.ForeColor = Color.Blue;
                }
            }
            catch { }
        }

        private void rep_Ekip_EmployeeCode_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lkupEdit = sender as LookUpEdit;
            this.gridView_Ekip.SetFocusedRowCellValue(col_Ekip_Role, lkupEdit.GetColumnValue("PositionCode").ToString());
        }

    }
}