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
using System.Globalization;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace Ps.Clinic.Entry
{
    public partial class frmConfirmReportBV01 : DevExpress.XtraEditors.XtraForm
    {
        private string userid = string.Empty, shiftWork = string.Empty, serialBHYT = string.Empty;
        private Int32 patientType = 0, iTraituyen = 0, done = 0, iCapcuu = 0 , iChuyenvien = 0;
        private Int32 ratioBHYT = 0;
        private List<SuggestedViewInf> lstViewServies = new List<SuggestedViewInf>();
        private List<SuggestedViewMedicinesBV01Inf> lstViewItems = new List<SuggestedViewMedicinesBV01Inf>();
        private List<PatientReceive_ViewInf> lstReceiveID = new List<PatientReceive_ViewInf>();
        private string spatientReceiveID = string.Empty;
        private DataTable tableIDC10More = new DataTable();
        private string reportID = string.Empty, receiptID = string.Empty;
        private string itemNameTemp = string.Empty, itemUnitOfMeasureNameTemp = string.Empty;
        private decimal itemSalesPriceTemp = 0, itemBHYTPriceTemp = 0, itemDisparityPriceTemp = 0;
        private Int32 itemListBHYTTemp = 0, itemRateBHYT = 0;
        private decimal servicePriceTemp = 0, disparityPriceTemp = 0;
        private string serviceCodeTemp =string.Empty, serviceNameTemp = string.Empty, serviceGroupNameTemp = string.Empty, serviceGroupCodeTemp = string.Empty, unitOfMeasureNameTemp = string.Empty, serviceModuleCodeTemp = string.Empty;
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        private DateTime dateInto = new DateTime();
        private int iPaid = 1;
        private List<DiagnosisInf> lstDiagnosis = new List<DiagnosisInf>();
        private string itemSODKGP_Temp = string.Empty, itemCode_PKTemp = string.Empty, serviceCode_PKTemp = string.Empty;
        public frmConfirmReportBV01(string _userid, string _shiftWork)
        {
            InitializeComponent();
            this.userid = _userid;
            this.shiftWork = _shiftWork;
        }

        private void butSearchReciept_Click(object sender, EventArgs e)
        {
            this.GetPatientWaiting();
        }

        private void frmConformReportBV01_Load(object sender, EventArgs e)
        {
            try
            {
                this.tableIDC10More.Columns.Add("RowID", typeof(Int32));
                this.tableIDC10More.Columns.Add("DiagnosisName", typeof(string));
                this.dtSearchFrom.EditValue = this.dtSearchTo.EditValue = this.dtimeFrom.EditValue = dtimeTo.EditValue = Utils.DateServer();
                this.InitField();
                this.GetPatientWaiting();
                this.LoadData();
                this.txtLoaiTuoi.SelectedIndex = 0;
                this.butAddItem.Enabled = true;
                this.butPrintItems.Enabled = this.butPrintServices.Enabled = this.butPrintBV.Enabled = this.butCancel.Enabled = this.butReceipt.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetPatientWaiting()
        {
            this.gridControl_WaitingList.DataSource = BanksAccountBLL.TableWaitingForDateBV01(this.dtimeFrom.Text.Trim(), this.dtimeTo.Text.Trim(), 0, 1);
        }

        private void LoadData()
        {
            try
            {
                this.lkupNgheNghiep.Properties.DataSource = CareerBLL.DTCareer(string.Empty);
                this.lkupNgheNghiep.Properties.DisplayMember = "CareerName";
                this.lkupNgheNghiep.Properties.ValueMember = "CareerCode";

                CatalogEthnicBLL ethnic = new CatalogEthnicBLL();
                this.lkupDanToc.Properties.DataSource = ethnic.DTListEthnic(0);
                this.lkupDanToc.Properties.DisplayMember = "EThnicName";
                this.lkupDanToc.Properties.ValueMember = "EThnicID";

                this.lkupTaiNanTT.Properties.DataSource = TNTTBLL.TableTaiNanTT();
                this.lkupTaiNanTT.Properties.DisplayMember = "Ten";
                this.lkupTaiNanTT.Properties.ValueMember = "Ma";

                this.lkupTTRV.Properties.DataSource = ReportBHYTBLL.TableDMTTRV();
                this.lkupTTRV.Properties.DisplayMember = "Ten";
                this.lkupTTRV.Properties.ValueMember = "Ma";
                this.lkupTTRV.EditValue = 1;

                this.lkupKQDT.Properties.DataSource = ReportBHYTBLL.TableKQDT();
                this.lkupKQDT.Properties.DisplayMember = "ResultsName";
                this.lkupKQDT.Properties.ValueMember = "RowID";
                this.lkupKQDT.EditValue = 2;

                CatalogNationalityBLL national = new CatalogNationalityBLL();
                this.lkupQuocTich.Properties.DataSource = national.DTListNationality(0);
                this.lkupQuocTich.Properties.DisplayMember = "NationalityName";
                this.lkupQuocTich.Properties.ValueMember = "NationalityID";

                DataTable dtbProvincial = new DataTable();
                dtbProvincial = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.lkupTinh.Properties.DataSource = dtbProvincial;
                this.lkupTinh.Properties.DisplayMember = "ProvincialName";
                this.lkupTinh.Properties.ValueMember = "ProvincialCode";

                CatalogDistrictBLL district = new CatalogDistrictBLL();
                DataTable dtbDistrict = new DataTable();
                dtbDistrict = district.DTListDistrict(string.Empty, string.Empty);
                this.lkupHuyen.Properties.DataSource = dtbDistrict;
                this.lkupHuyen.Properties.DisplayMember = "DistrictName";
                this.lkupHuyen.Properties.ValueMember = "DistrictCode";

                CatalogWardBLL ward = new CatalogWardBLL();
                DataTable dtbWard = new DataTable();
                dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                if (dtbWard.Rows.Count <= 0 || dtbWard == null)
                    dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                this.lkupTQPXa.Properties.DataSource = dtbWard;
                this.lkupTQPXa.Properties.DisplayMember = "WardName";
                this.lkupTQPXa.Properties.ValueMember = "WardCode";

                this.lkupPhuongXa.Properties.DataSource = dtbWard;
                this.lkupPhuongXa.Properties.DisplayMember = "WardName";
                this.lkupPhuongXa.Properties.ValueMember = "WardCode";

                this.lkupDepartment.Properties.DataSource = DepartmentBLL.DTDepartment("KCB");
                this.lkupDepartment.Properties.DisplayMember = "DepartmentName";
                this.lkupDepartment.Properties.ValueMember = "DepartmentCode";

                this.lstDiagnosis = DiagnosisBLL.ListDiagnosis(0);
                
                this.txtChandoankemtheo.Properties.DataSource = DiagnosisBLL.ListDiagnosisName();
                this.txtChandoankemtheo.Properties.DisplayMember = "DiagnosisName";
                this.txtChandoankemtheo.Properties.ValueMember = "RowID";

                this.txtXutri.Properties.DataSource = Tackle_BLL.ListTackle();
                this.txtXutri.Properties.DisplayMember = "TackleName";
                this.txtXutri.Properties.ValueMember = "TackleCode";

                this.searchLkup_Service.Properties.DataSource = ServiceBLL.DTServiceRealNotGroup();
                this.searchLkup_Service.Properties.DisplayMember = "ServiceName";
                this.searchLkup_Service.Properties.ValueMember = "RowID";

                this.searchLkup_Items.Properties.DataSource = ItemsBLL.ListItemsRefBHYT(0);
                this.searchLkup_Items.Properties.DisplayMember = "ItemName";
                this.searchLkup_Items.Properties.ValueMember = "ItemCode";

                DataTable tableObject = ObjectBLL.DTObjectListNotIn(5);
                this.ref_ObjectCode.DataSource = tableObject;
                this.ref_ObjectCode.DisplayMember = "ObjectName";
                this.ref_ObjectCode.ValueMember = "ObjectCode";

                this.lkupDoituong.Properties.DataSource = tableObject;
                this.lkupDoituong.Properties.DisplayMember = "ObjectName";
                this.lkupDoituong.Properties.ValueMember = "ObjectCode";

                this.searchLKupEmployeeDoctor.Properties.DataSource = EmployeeBLL.DTEmployee(string.Empty, false);
                this.searchLKupEmployeeDoctor.Properties.DisplayMember = "EmployeeName";
                this.searchLKupEmployeeDoctor.Properties.ValueMember = "EmployeeCode";

            }
            catch { return; }
        }
        
        public void InitField()
        {
            this.txtLoaiTuoi.Properties.Items.AddRange(new string[] { "Năm", "Tháng", "Ngày", "Giờ" });
            this.cbGioiTinh.Properties.Items.AddRange(new string[] { "Nữ", "Nam" });
        }

        private void GetInfoPatient(string patientCode, string dateInto)
        {
            try
            {
                this.lstReceiveID = PatientReceiveBLL.ListForPatient(patientCode, dateInto);
                if (this.lstReceiveID != null && this.lstReceiveID.Count > 0)
                {
                    bool updateInfo = false;
                    foreach (var patient in this.lstReceiveID)
                    {
                        this.spatientReceiveID += patient.PatientReceiveID + ",";
                        if (!updateInfo)
                        {
                            PatientsInf objPatient = PatientsBLL.ObjPatients(patient.PatientCode, patient.PatientReceiveID);
                            if (objPatient != null && objPatient.PatientCode != null)
                            {
                                this.txtMabn.Text = objPatient.PatientCode;
                                this.txtHoTen.Text = objPatient.PatientName;
                                this.txtTuoi.Text = objPatient.PatientAge.ToString();
                                this.txtDiaChi.Text = objPatient.PatientAddress;
                                this.txtDienThoai.Text = objPatient.PatientMobile;
                                this.txtEmail.Text = objPatient.PatientEmail;
                                this.txtTienSu.Text = objPatient.MedicalHistory;
                                this.txtDiUng.Text = objPatient.Allergy;
                                this.cbGioiTinh.SelectedIndex = objPatient.PatientGender;
                                this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                                this.txtNamSinh.Text = objPatient.PatientBirthyear.ToString();
                                //this.txtLoaiTuoi.SelectedIndex = 0;
                                //this.lkupNgheNghiep.EditValue = objPatient.CareerCode;
                                //this.lkupDanToc.EditValue = objPatient.EThnicID;
                                //this.lkupQuocTich.EditValue = objPatient.NationalityID;
                                PatientAppointment_INF mApp = PatientAppointment_BLL.ObjAppointment(patient.PatientReceiveID);
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
                                this.LoadPatientReceiveAddressCard(patient.PatientReceiveID);
                                updateInfo = true;
                            }
                        }
                        this.lkupTaiNanTT.EditValue = patient.TNTTID;
                    }
                    this.GetHistoryPatientMedical();
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadPatientReceiveAddressCard(decimal receiveID)
        {
            try
            {
                List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(receiveID);
                if (lstReceive.Count > 0)
                {
                    this.patientType = lstReceive[0].PatientType;
                    this.dateTimeIntoEdit.EditValue = lstReceive[0].CreateDate;
                    DateTime dateTemp = new DateTime(1990, 01, 01, 01, 01, 01, 01);
                    if (!DateTime.Equals(dateTemp, lstReceive[0].OutDate))
                        this.dateTimeOut.EditValue = lstReceive[0].OutDate;
                    else
                        this.dateTimeOut.EditValue = Utils.DateTimeServer();
                    this.lkupNgheNghiep.EditValue = lstReceive[0].CareerCode;
                    this.lkupDanToc.EditValue = lstReceive[0].EThnicID;
                    this.lkupQuocTich.EditValue = lstReceive[0].NationalityID;
                    this.txtDiaChi.Text = lstReceive[0].Address;
                    this.txtMaTQPXa.Text = lstReceive[0].WardCode;
                    this.lkupTQPXa.EditValue = lstReceive[0].WardCode;
                    this.txtMaTinh.Text = this.txtMaTinh01.Text = lstReceive[0].ProvincialCode;
                    this.lkupTinh.EditValue = lstReceive[0].ProvincialCode;
                    if (!string.IsNullOrEmpty(lstReceive[0].DistrictCode))
                        this.txtMaHuyen.Text = lstReceive[0].DistrictCode;
                    else
                        this.txtMaHuyen.Text = string.Empty;
                    this.txtMaTinhHuyen.Text = lstReceive[0].DistrictCode;
                    this.lkupHuyen.EditValue = lstReceive[0].DistrictCode;
                    if (!string.IsNullOrEmpty(lstReceive[0].WardCode))
                        this.txtMaPXa.Text = lstReceive[0].WardCode;
                    else
                        this.txtMaPXa.Text = string.Empty;
                    this.lkupPhuongXa.EditValue = lstReceive[0].WardCode;
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân không tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(receiveID);
                if (lstBHYT.Count > 0)
                {
                    this.serialBHYT = lstBHYT[0].Serial;
                    this.txtThe01.Text = lstBHYT[0].Serial01;
                    this.txtThe02.Text = lstBHYT[0].Serial02;
                    this.txtThe03.Text = lstBHYT[0].Serial03;
                    this.txtThe04.Text = lstBHYT[0].Serial04;
                    this.txtThe05.Text = lstBHYT[0].Serial05;
                    this.txtThe06.Text = lstBHYT[0].Serial06;
                    //this.txtKCBBD.Text = lstBHYT[0].ProvincialIDBHYT + '-' + lstBHYT[0].KCBBDCode;
                    this.txtKCBBD.Text = lstBHYT[0].KCBBDCodeFull;
                    this.lkKCB.EditValue = lstBHYT[0].KCBBDCode;
                    this.txtTheStart.EditValue = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                    this.txtTheEnd.EditValue = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                    this.lbstt.Text = lstBHYT[0].Serial.Length.ToString();
                    this.iTraituyen = lstBHYT[0].TraiTuyen;
                    this.iCapcuu = lstBHYT[0].Capcuu;
                    this.iChuyenvien = lstBHYT[0].ReferralPaper;
                    this.chkTraiTuyen.Checked = lstBHYT[0].TraiTuyen == 1 ? true : false;
                    this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                    this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                    this.GetCardInfo();
                    this.LoadDKKCBBD();
                }
                else
                {
                    this.ClearBHYTInfo();
                    this.ratioBHYT = 0;
                    this.lbTileBHYT.Text = string.Empty;
                }
                List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefID(receiveID);
                if (lstSur.Count > 0)
                {
                    this.txtMach.Text = lstSur[0].Pulse;
                    this.txtHuyetap.Text = lstSur[0].BloodPressure;
                    this.txtHuyetap1.Text = lstSur[0].BloodPressure1;
                    this.txtNhietdo.Text = lstSur[0].Temperature;
                    this.txtNang.Text = lstSur[0].Weight;
                    this.txtCao.Text = lstSur[0].Hight;
                }
                else
                {
                    this.txtMach.Text = string.Empty;
                    this.txtHuyetap.Text = string.Empty;
                    this.txtHuyetap1.Text = string.Empty;
                    this.txtNhietdo.Text = string.Empty;
                    this.txtNang.Text = string.Empty;
                    this.txtCao.Text = string.Empty;
                }
            }
            catch { }
        }

        private void GetCardInfo()
        {
            try
            {
                if (this.txtThe01.Text.Trim().Length == 2 && this.txtThe02.Text.Trim().Length == 1)
                {
                    string cardTemp = this.txtThe01.Text.Trim() + this.txtThe02.Text.Trim();
                    RateBHYTInf model = RateBHYTBLL.objectRateBHYT(cardTemp);
                    if (model == null || model.RateCard == string.Empty)
                    {
                        XtraMessageBox.Show(" Mã thẻ không hợp lệ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtThe01.Focus();
                        return;
                    }
                    else
                    {
                        if (this.chkTraiTuyen.Checked)
                        {
                            if (this.chkGiayChuyenVien.Checked || this.chkCapCuu.Checked)
                            {
                                this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                                this.ratioBHYT = model.RateTrue;
                            }
                            else
                            {
                                this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "%";
                                this.ratioBHYT = model.RateFalse;
                            }    
                        }
                        else
                        {
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                            this.ratioBHYT = model.RateTrue;
                        }
                    }
                }
            }
            catch { }
        }

        private void LoadDKKCBBD()
        {
            try
            {
                string[] strArrayCode = this.txtKCBBD.Text.Trim().Split(new char[] { '-' });
                DataTable tableKCBBD = KCBBDBLL.TableKCBBDForBHYT(strArrayCode[0].ToString().Trim(), strArrayCode[1].ToString().Trim());
                if (tableKCBBD != null && tableKCBBD.Rows.Count > 0)
                {
                    this.lkKCB.Properties.DataSource = tableKCBBD;
                    this.lkKCB.Properties.DisplayMember = "KCBBDName";
                    this.lkKCB.Properties.ValueMember = "KCBBDCode";
                    this.lkKCB.EditValue = strArrayCode[1].ToString().Trim();

                    DataTable tbKCBBD = KCBBDBLL.TableKCBBDForBHYT(strArrayCode[0].ToString(), strArrayCode[1].ToString());
                    if (Convert.ToInt32(tbKCBBD.Rows[0][4].ToString()) == 0)
                        this.chkTraiTuyen.Checked = true;
                        else
                            this.chkTraiTuyen.Checked = false;
                    this.txtTheStart.Focus();
                }
                else
                {
                    this.lkKCB.Properties.DataSource = null;
                    this.txtKCBBD.Text = string.Empty;
                }
            }
            catch { }
        }

        private void ClearBHYTInfo()
        {
            this.serialBHYT = this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = string.Empty;
            this.txtKCBBD.Text = this.txtTheStart.Text = this.txtTheEnd.Text = string.Empty;
            this.lkKCB.EditValue = null;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = this.chkCapCuu.Checked = false;
        }

        private void GetHistoryPatientMedical()
        {
            string departmentCodeTemp = string.Empty;
            List<MedicalRecord_INF> lstMedical = MedicalRecord_BLL.ListMedicalRecordForReceiveID(this.spatientReceiveID.TrimEnd(','));
            if (lstMedical != null && lstMedical.Count > 0)
            {
                bool updateInfo = false;
                foreach (var medical in lstMedical)
                {
                    departmentCodeTemp += medical.DepartmentCode + ",";
                    if (!updateInfo)
                    {
                        this.txtTrieuChung.Text = medical.Symptoms;
                        this.txtMaICD10.Text = medical.ICD10_Custom;
                        this.txtNameICD10.Text = medical.ICD10Name_Custom;
                        this.txtChandoankemtheo.EditValue = medical.DiagnosisEnclosed;
                        this.cboxDiagnosis.Text = medical.DiagnosisCustom;
                        this.txtXutri.EditValue = medical.TackleCode;
                        this.txtLoidan.Text = medical.Advices;
                        this.memoTreatments.Text = medical.Treatments;
                        this.tableIDC10More = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(medical.MedicalRecordCode);
                        updateInfo = true;
                    }
                    DataTable tableTemp = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(medical.MedicalRecordCode);
                    if (tableTemp != null && tableTemp.Rows.Count > 0)
                    {
                        foreach (DataRow row in tableTemp.Rows)
                        {
                            DataRow dr = this.tableIDC10More.NewRow();
                            dr["RowID"] = row["RowID"];
                            dr["DiagnosisName"] = row["DiagnosisName"];
                            DataRow r = Utils.GetPriceRowbyCode(this.tableIDC10More, "RowID=" + row["RowID"]);
                            if (r == null)
                                this.tableIDC10More.Rows.Add(dr);
                        }
                    }
                }
                this.searchLKupEmployeeDoctor.EditValue = lstMedical[0].EmployeeCodeDoctor;
            }
            this.lkupDepartment.EditValue = departmentCodeTemp.TrimEnd(',');
            this.gridControl_ICD10.DataSource = this.tableIDC10More;
        }

        private void ClearData()
        {
            this.spatientReceiveID = this.reportID = string.Empty;
            this.done = 0;
            this.lstReceiveID.Clear();
            this.txtMabn.Text = string.Empty;
            this.txtHoTen.Text = this.txtNgaySinh.Text = this.txtNamSinh.Text = this.txtTuoi.Text = this.txtDiaChi.Text = this.txtDienThoai.Text = this.txtEmail.Text = this.txtTienSu.Text = this.txtDiUng.Text = string.Empty;
            this.cbGioiTinh.SelectedIndex = -1;
            this.txtMaTQPXa.Text = this.txtMaTinh.Text = this.txtMaTinh01.Text = this.txtMaHuyen.Text = this.txtMaTinhHuyen.Text = this.txtMaPXa.Text = string.Empty;
            this.lkupNgheNghiep.EditValue = "NN00000001";
            this.lkupDanToc.EditValue = 1;
            this.lkupQuocTich.EditValue = 1;
            this.lkupKQDT.EditValue = string.Empty;
            this.lkupTaiNanTT.EditValue = string.Empty;
            this.lkupTTRV.EditValue = string.Empty;
            this.lkupTQPXa.EditValue = string.Empty;
            this.lkupTinh.EditValue = string.Empty;
            this.lkupHuyen.EditValue = string.Empty;
            this.lkupPhuongXa.EditValue = string.Empty;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = this.chkCapCuu.Checked = false;
            this.lbTileBHYT.Text = this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNang.Text = this.txtCao.Text = string.Empty;
            this.lbKCB.Text = this.lbCDHA_TDCN.Text = this.lbXN.Text = this.lbPT_TT.Text = this.lbTHUOC_VTYT.Text = this.lbKhac.Text = this.lbGiuong.Text = this.lbMau.Text = this.lbVC.Text = "0";
            this.memoTreatments.Text = string.Empty;
            this.txtTrieuChung.EditValue = this.txtChandoankemtheo.EditValue = this.txtXutri.EditValue = this.txtLoidan.EditValue = null;
            this.cboxDiagnosis.Text = string.Empty;
            this.txtNgayTaiKham.EditValue = null;
            this.txtAppointmentNote.Text = string.Empty;
            this.tableIDC10More.Clear();
            this.dateTimeIntoEdit.EditValue = this.dateTimeOut.EditValue = null;
            this.lkupDepartment.EditValue = string.Empty;
            this.lstViewServies.Clear();
            this.lstViewItems.Clear();
            this.lstReceiveID.Clear();
            this.gridControl_ICD10.DataSource = null;
            this.gridControl_Items.DataSource = null;
            this.gridControl_Services.DataSource = null;
            this.txtAmount.EditValue = this.txtAmountBHYT.EditValue = this.txtAmountThuphi.EditValue = this.txtAmountPhuthu.EditValue = this.txtAmountReal.EditValue = this.txtDiscount.Value = this.txtAmountDiscount.Value = 0;
            this.txtNgayCap.EditValue = this.spinQuantity.Text = spinQuantity.Text;
            this.txtMorning.Text = this.txtAfternoon.Text = this.txtEvening.Text = this.txtAfternoon.Text = string.Empty;
            this.txtItemUnitPrice.EditValue = this.txtItemAmount.EditValue = 0;
            this.lkupKQDT.EditValue = 2;
            this.lkupTaiNanTT.EditValue = 0;
            this.lkupTTRV.EditValue = 1;
            this.lkupDepartment.EditValue = null;
            this.txtBNTra.EditValue = this.txtTTBHYT.EditValue = 0;
            this.txtMaICD10.EditValue = this.txtNameICD10.EditValue = string.Empty;
            this.itemCode_PKTemp = this.itemSODKGP_Temp = string.Empty;
        }

        private void txtChandoankemtheo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow r = Utils.GetPriceRowbyCode(this.tableIDC10More, "RowID='" + this.txtChandoankemtheo.EditValue.ToString() + "'");
                if (r != null)
                {
                    if (XtraMessageBox.Show(" Bệnh kèm theo đã tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    this.tableIDC10More.Rows.Add(this.txtChandoankemtheo.EditValue.ToString(), this.txtChandoankemtheo.Text);
                    this.gridControl_ICD10.DataSource = this.tableIDC10More;
                }
            }
            catch { }
        }

        private void GetTotalServiceMedical(bool breset)
        {
            decimal amountBHYTTotal = 0;
            this.ListService(ref amountBHYTTotal, breset);
            this.ListMedical(ref amountBHYTTotal, breset);

            #region tinh lai BHYT cho dich vu va thuoc
            BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
            if (amountBHYTTotal <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotal <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotal <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
            {
                foreach (var v in this.lstViewServies)
                {
                    if (v.ObjectCode == 1)
                    {
                        v.BHYTPay = v.Quantity * v.ServicePrice;
                        v.PatientPay = 0;
                    }
                }
            }
            this.gridControl_Services.DataSource = this.lstViewServies;
            this.gridView_Services.Columns["ServiceGroupName"].Group();
            this.gridView_Services.ExpandAllGroups();
            if (amountBHYTTotal <= bhytpara.BHYTUnderPrice && this.iTraituyen==0 || amountBHYTTotal <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotal <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
            {
                foreach (var items in this.lstViewItems)
                {
                    if (items.ObjectCode == 1)
                    {
                        items.BHYTPay = items.Quantity * items.UnitPrice;
                        items.PatientPay = 0;
                    }
                }
            }
            this.gridControl_Items.DataSource = this.lstViewItems;
            #endregion

            this.SumAmountTotal(string.Empty);
        }

        public void ListService(ref decimal amountTotalService, bool isReset)
        {
            try
            {
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(502);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.iPaid = 0;
                    else
                        this.iPaid = 1;
                }
                if (this.lstViewServies.Count <= 0)
                    this.lstViewServies = SuggestedServiceReceiptBLL.ListViewForBV01(this.txtMabn.Text.Trim().ToUpper(), this.spatientReceiveID.TrimEnd(','), this.done, this.reportID,this.iPaid).Where(v => v.ObjectCode == 1 && v.DisparityPrice == 0).ToList();
                decimal dBHYT = 0;
                foreach (var v in this.lstViewServies)
                {
                    if (v.Check.Equals(1))
                    {
                        if (v.ObjectCode == 1)
                        {
                            if (isReset)
                            {
                                dBHYT = (((v.Quantity * v.ServicePrice) * this.ratioBHYT) / 100);
                                v.BHYTPay = dBHYT;
                                v.PatientPay = (v.Quantity * v.ServicePrice) - dBHYT;// +v.DisparityPrice;
                                v.Amount = (v.Quantity * v.ServicePrice);// +v.DisparityPrice;
                                amountTotalService += (v.Quantity * v.ServicePrice);
                            }
                            else
                            {
                                amountTotalService += (v.Quantity * v.ServicePrice);
                            }
                        }
                        else
                        {
                            v.PatientPay = (v.Quantity * v.ServicePrice);// +v.DisparityPrice;
                            v.BHYTPay = 0;
                            v.Amount = (v.Quantity * v.ServicePrice);// + v.DisparityPrice;
                        }
                    }
                }
            }
            catch { }
        }

        private void ListMedical(ref decimal amountTotalMedical, bool isReset)
        {
            try
            {
                if (this.lstViewItems.Count <= 0)
                    this.lstViewItems = SuggestedServiceReceiptBLL.ListMedicalViewForBV01(this.txtMabn.Text.Trim().ToUpper(), this.spatientReceiveID.TrimEnd(','), this.done, this.reportID);
                List<SuggestedViewMedicinesBV01Inf> lstViewThuocReal = this.lstViewItems.Where(p => p.Check == 1).ToList();
                decimal dBHYTReal = 0, dPatientReal = 0;
                foreach (var v in lstViewThuocReal)
                {
                    if (v.ObjectCode == 1)
                    {
                        if (isReset)
                        {
                            dBHYTReal = (((v.Quantity * v.BHYTPrice) * this.ratioBHYT) / 100); //((v.BHYTPay * this.ratioBHYT) / 100);
                            dPatientReal = ((v.Quantity * v.BHYTPrice) - dBHYTReal);//(v.PatientPay + v.BHYTPay - dBHYTReal);
                            v.BHYTPay = dBHYTReal;
                            v.PatientPay = dPatientReal;


                            amountTotalMedical += v.Quantity * v.UnitPrice;
                        }
                        else
                        {
                            amountTotalMedical += v.Quantity * v.UnitPrice;
                        }
                    }
                    else
                    {
                        dBHYTReal = v.Amount;
                        dPatientReal = v.Amount;
                        v.PatientPay = dPatientReal;
                        v.BHYTPay = 0;
                    }
                }

            }
            catch { }
        }

        public void SumAmountTotal(string rowIDSuggested)
        {
            decimal dCDHA = 0, dKCB = 0, dPTTT = 0, dXN = 0, dKhac = 0, dMau = 0, dVC = 0, dGiuong = 0;
            decimal dDVDisparity = 0, dDVTotal = 0, dDVBHYTTotal = 0;
            decimal dThuocBHYTChiTra = 0, dThuocThuPhi = 0, dThuocBHYTTotal = 0;
            decimal totalPayBHYT = 0, totalDVThuPhi = 0, totalPaientPay = 0;
            decimal tongbhyt = 0, tongbntra = 0;
            try
            {
                //DataTable dtAmountService = new DataTable();
                //dtAmountService = BanksAccountBLL.TableSumAmountServiceDetailForBV01(this.spatientReceiveID.TrimEnd(','), this.txtMabn.Text.Trim().ToUpper(), rowIDSuggested, this.done, this.reportID);
                List<SuggestedViewInf> lstServicesReal = this.lstViewServies.Where(p => p.Check.Equals(1)).ToList();
                List<SuggestedViewMedicinesBV01Inf> lstMedicinesReal = this.lstViewItems.Where(p => p.Check.Equals(1)).ToList();
                //foreach (DataRow dr in dtAmountService.Rows)
                //{
                //    dDVDisparity += Convert.ToDecimal(dr["TotalDisparity"].ToString());
                //    if (dr["ServiceModuleCode"].ToString() == "CDHA")
                //        dCDHA += Convert.ToDecimal(dr["Total"].ToString());
                //    else if (dr["ServiceModuleCode"].ToString() == "KCB")
                //        dKCB += Convert.ToDecimal(dr["Total"].ToString());
                //    else if (dr["ServiceModuleCode"].ToString() == "PTTT")
                //        dPTTT += Convert.ToDecimal(dr["Total"].ToString());
                //    else if (dr["ServiceModuleCode"].ToString() == "XN")
                //        dXN += Convert.ToDecimal(dr["Total"].ToString());
                //    else
                //        dKhac += Convert.ToDecimal(dr["Total"].ToString());
                //}
                foreach (var v in lstServicesReal)
                {
                    dDVDisparity += v.DisparityPrice;
                    if (v.ServiceModuleCode == "CDHA")
                        dCDHA += v.Amount;
                    else if (v.ServiceModuleCode == "KCB")
                        dKCB += v.Amount;
                    else if (v.ServiceModuleCode == "PTTT")
                        dPTTT += v.Amount;
                    else if (v.ServiceModuleCode == "XN")
                        dXN += v.Amount;
                    else if (v.ServiceModuleCode == "MAU")
                        dMau += v.Amount;
                    else if (v.ServiceModuleCode == "VC")
                        dVC += v.Amount;
                    else if (v.ServiceModuleCode == "GIUONG")
                        dGiuong += v.Amount;
                    else
                        dKhac += v.Amount;
                }
                this.lbCDHA_TDCN.Text = dCDHA.ToString("N0");
                this.lbKCB.Text = dKCB.ToString("N0");
                this.lbPT_TT.Text = dPTTT.ToString("N0");
                this.lbXN.Text = dXN.ToString("N0");
                this.lbKhac.Text = dKhac.ToString("N0");
                this.lbTHUOC_VTYT.Text = "0";
                this.lbMau.Text = dMau.ToString("N0");
                this.lbVC.Text = dVC.ToString("N0");
                this.lbGiuong.Text = dGiuong.ToString("N0");
                foreach (var vservice in lstServicesReal)
                {
                    if (vservice.ObjectCode == 1)
                    {
                        dDVBHYTTotal += (vservice.Quantity * vservice.ServicePrice);
                        totalPayBHYT += vservice.BHYTPay;
                        totalPaientPay += vservice.Amount - vservice.BHYTPay;// -vservice.DisparityPrice;
                        //dDVDisparity += vservice.DisparityPrice;
                        tongbhyt += (vservice.Quantity * vservice.ServicePrice);
                        tongbntra += vservice.PatientPay;
                    }
                    else
                    {
                        totalPayBHYT += vservice.BHYTPay;
                        totalDVThuPhi += vservice.Amount - vservice.BHYTPay;// -vservice.DisparityPrice;
                    }
                }
                if (lstMedicinesReal.Count > 0)
                {
                    foreach (var items in lstMedicinesReal)
                    {
                        if (items.ObjectCode != 5)
                        {
                            dThuocBHYTChiTra += items.BHYTPay;
                            dThuocThuPhi += items.PatientPay;
                            tongbhyt += items.BHYTPay + items.PatientPay;
                            tongbntra += items.PatientPay;
                        }
                        if (items.ObjectCode == 1 && items.BHYTPay > 0)
                            dThuocBHYTTotal += items.BHYTPay + items.PatientPay;
                        dDVDisparity += items.DisparityPrice;
                    }
                    this.lbTHUOC_VTYT.Text = (dThuocBHYTChiTra + dThuocThuPhi).ToString("N0");
                }
                dDVTotal = (dCDHA + dKCB + dPTTT + dXN + dKhac + dMau + dVC + dGiuong);
                this.txtAmount.Text = (dDVTotal + dThuocBHYTChiTra + dThuocThuPhi + dDVDisparity).ToString("N0");
                this.txtAmountThuphi.Text = (totalDVThuPhi).ToString("N0");// (totalDVThuPhi + dThuocThuPhi + totalPaientPay).ToString("N0");
                this.txtAmountBHYT.Text = (totalPayBHYT + dThuocBHYTChiTra).ToString("N0");
                this.txtAmountReal.Text = (totalDVThuPhi + dThuocThuPhi + dDVDisparity).ToString("N0");
                this.txtAmountPhuthu.Text = dDVDisparity.ToString("N0");
                this.txtBNTra.Text = tongbntra.ToString("N0");
                this.txtTTBHYT.Text = (dDVBHYTTotal + dThuocBHYTTotal).ToString("N0");
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (((dDVBHYTTotal + dThuocBHYTTotal) <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0) || ((dDVBHYTTotal + dThuocBHYTTotal) <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1) || ((dDVBHYTTotal + dThuocBHYTTotal) <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1))
                {
                    this.txtAmountReal.Text = dDVDisparity.ToString("N0");
                    this.txtAmountBHYT.Text = (dDVBHYTTotal + dThuocBHYTTotal).ToString("N0");
                    this.txtAmountThuphi.Text = totalDVThuPhi.ToString("N0");
                    this.txtBNTra.Text = "0";
                }
                else if ((dDVBHYTTotal + dThuocBHYTTotal) > bhytpara.BHYTUnderPrice && (dDVBHYTTotal + dThuocBHYTTotal) <= bhytpara.BHYTOnPrice)
                {
                    this.txtAmountReal.Text = (totalDVThuPhi + totalPaientPay + dThuocThuPhi + dDVDisparity).ToString("N0");
                }
                else if ((dDVBHYTTotal + dThuocBHYTTotal) >= bhytpara.BHYTOnPrice)
                {
                    this.txtAmountReal.Text = ((totalDVThuPhi + totalPaientPay + dThuocThuPhi + dDVDisparity) - bhytpara.BHYTOnPrice).ToString("N0");
                }
                this.txtAmountReal.EditValue = Convert.ToDecimal(this.txtAmount.EditValue.ToString()) - Convert.ToDecimal(this.txtAmountBHYT.EditValue.ToString()) - Convert.ToDecimal(this.txtAmountDiscount.EditValue.ToString());
            }
            catch { }
        }

        private void butReceipt_Click(object sender, EventArgs e)
        {
            
            try
            {
                //if (this.lkupDoituong.EditValue == null || string.IsNullOrEmpty(this.lkupDoituong.Text.Trim()))
                //{
                //    XtraMessageBox.Show(" Chọn đối tượng cho dịch vụ(thuốc - vtth).", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (this.lkupDepartment.EditValue == null || string.IsNullOrEmpty(this.lkupDepartment.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chọn khoa phòng điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupDepartment.Focus();
                    return;
                }
                //if (this.TxtChandoan.EditValue == null || string.IsNullOrEmpty(this.TxtChandoan.Text.Trim()))
                //{
                //    XtraMessageBox.Show(" Chọn đối tượng cho ICD-10.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.TxtChandoan.Focus();
                //    return;
                //}
                if (this.txtXutri.EditValue == null || string.IsNullOrEmpty(this.txtXutri.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chọn xử trí khám bệnh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtXutri.Focus();
                    return;
                }
                this.GetTotalServiceMedical(false); 
                ReportBHYTInf report = new ReportBHYTInf();
                report.ReportID = this.reportID;
                report.BHYTPay = Convert.ToDecimal(this.txtAmountBHYT.EditValue);
                report.PatientPay = Convert.ToDecimal(this.txtAmountThuphi.EditValue);
                report.Exemptions = Convert.ToDecimal(this.txtAmountDiscount.EditValue);
                report.RateExemptions = Convert.ToDecimal(this.txtDiscount.EditValue);
                report.TotalSurcharge = Convert.ToDecimal(this.txtAmountPhuthu.EditValue);
                report.TotalAmount = Convert.ToDecimal(this.txtAmount.EditValue);
                report.TotalReal = Convert.ToDecimal(this.txtAmountReal.EditValue);
                report.AmountBHYT = Convert.ToDecimal(this.txtTTBHYT.EditValue);
                report.AmountBNTraBHYT = Convert.ToDecimal(this.txtBNTra.EditValue);
                report.RateSurcharge = 0;
                report.PatientCode = this.txtMabn.Text.Trim();
                report.EmployeeCode = this.userid;
                report.ShiftWork = this.shiftWork;
                report.DateInto = this.dateInto; //Convert.ToDateTime(this.dateTimeIntoEdit.EditValue);
                report.DateOut = Convert.ToDateTime(this.dateTimeOut.EditValue);
                report.DepartmentCode = this.lkupDepartment.EditValue.ToString();
                report.Symptoms = this.txtTrieuChung.Text.ToString();
                report.Advices = this.txtLoidan.Text;
                report.Treatments = this.txtLoidan.Text;
                if (this.txtXutri.EditValue != null)
                    report.TackleCode = Convert.ToInt32(this.txtXutri.EditValue.ToString());
                else
                    this.txtXutri.EditValue = 0;
                report.Advices = this.txtLoidan.Text;
                report.Symptoms = this.txtTrieuChung.Text.ToString();
                report.DiagnosisCustom = this.cboxDiagnosis.Text;
                report.Treatments = this.memoTreatments.Text.Trim();
                report.AppointmentDate = this.txtNgayTaiKham.Text;
                report.AppointmentContent = this.txtAppointmentNote.Text;
                //report.ICD10 = this.TxtChandoan.EditValue.ToString();
                report.ICD10 = "-1";
                report.ICD10_Custom = this.txtMaICD10.EditValue.ToString();
                report.ICD10Name_Custom = this.txtNameICD10.Text;
                string icd10More = string.Empty;
                foreach (DataRow row in this.tableIDC10More.Rows)
                {
                    icd10More += row["RowID"].ToString() + ",";
                }
                report.ICD10More = icd10More.TrimEnd(',');
                report.Pulse = this.txtMach.Text.Trim();
                report.Temperature = this.txtNhietdo.Text.Trim();
                report.BloodPressure = this.txtHuyetap.Text.Trim();
                report.BloodPressure1 = this.txtHuyetap1.Text.Trim();
                report.Weight = this.txtNang.Text.Trim();
                report.Hight = this.txtCao.Text;
                report.Breath = string.Empty;
                report.Serial = this.txtThe01.Text.Trim() + this.txtThe02.Text.Trim() + this.txtThe03.Text.Trim() + this.txtThe04.Text.Trim() + this.txtThe05.Text.Trim() + this.txtThe06.Text.Trim();
                report.Serial01 = this.txtThe01.Text.Trim();
                report.Serial02 = this.txtThe02.Text.Trim();
                report.Serial03 = this.txtThe03.Text.Trim();
                report.Serial04 = this.txtThe04.Text.Trim();
                report.Serial05 = this.txtThe05.Text.Trim();
                report.Serial06 = this.txtThe06.Text.Trim();
                report.KCBBDCode = this.txtKCBBD.Text.Trim();
                report.StartDate = Utils.StringToDate(this.txtTheStart.Text.Trim());
                report.EndDate = Utils.StringToDate(this.txtTheEnd.Text.Trim());
                //report.StartDate = Convert.ToDateTime(this.dateTimeInto.EditValue);
                //report.EndDate = Convert.ToDateTime(this.dateTimeOut.EditValue);
                report.TraiTuyen = iTraituyen;
                report.Capcuu = iCapcuu;
                report.ReferralPaper = iChuyenvien;
                //report.Capcuu = this.chkCapCuu.Checked ? 1 : 0;
                report.RateBHYT = this.ratioBHYT;
                report.ObjectCode = 1;
                if (this.lkupTaiNanTT.EditValue != null)
                    report.MATNTT = Convert.ToInt32(this.lkupTaiNanTT.EditValue);
                else
                    report.MATNTT = 0;
                if (this.lkupTTRV.EditValue != null)
                    report.MATTRV = Convert.ToInt32(this.lkupTTRV.EditValue);
                else
                    report.MATTRV = 1;
                if (this.lkupKQDT.EditValue != null)
                    report.IDTreatmentResults = Convert.ToInt32(this.lkupKQDT.EditValue);
                else
                    report.IDTreatmentResults = 1;
                ReportBHYTBLL.InsReportBHYT(report, ref this.reportID, Convert.ToDateTime(this.dateTimeIntoEdit.EditValue));
                if (!string.IsNullOrEmpty(this.reportID))
                {
                    ReportBHYTBLL.DelReportBHYTDetail(this.reportID);
                    List<SuggestedViewInf> lstViewReal = this.lstViewServies.Where(p => p.Check == 1).ToList();
                    List<SuggestedViewMedicinesBV01Inf> lstViewMedicinesReal = this.lstViewItems.Where(p => p.Check == 1).ToList();
                    int istt = 1;
                    bool result = true;
                    foreach (var v in lstViewReal)
                    {
                        if (v.Check == 1)
                        {
                            ReportBHYTDetailInf modelAccdetail = new ReportBHYTDetailInf();
                            modelAccdetail.ReportID = this.reportID;
                            modelAccdetail.PatientReceiveID = v.ReceiveID;
                            modelAccdetail.PatientCode = this.txtMabn.Text.Trim();
                            modelAccdetail.ServiceCode = v.ServiceCode;
                            modelAccdetail.ServicePrice = v.ServicePrice;
                            modelAccdetail.DisparityPrice = v.DisparityPrice;
                            modelAccdetail.ObjectCode = v.ObjectCode;
                            modelAccdetail.Quantity = v.Quantity;
                            modelAccdetail.Amount = v.Amount;
                            modelAccdetail.BHYTPay = v.BHYTPay;
                            modelAccdetail.PatientPay = v.PatientPay;
                            modelAccdetail.Ordinal = istt;
                            modelAccdetail.SalesPrice = v.ServicePrice;
                            modelAccdetail.BHYTPrice = v.ServicePrice;
                            modelAccdetail.DateOfIssues = string.Empty;
                            modelAccdetail.Morning = string.Empty;
                            modelAccdetail.Noon = string.Empty;
                            modelAccdetail.Afternoon = string.Empty;
                            modelAccdetail.Evening = string.Empty;
                            modelAccdetail.Instruction = string.Empty;
                            modelAccdetail.DoseOf = string.Empty;
                            modelAccdetail.DoseOfPills = string.Empty;
                            modelAccdetail.RowIDPrice = v.RowIDPrice;
                            modelAccdetail.ServiceCode_PK = v.ServiceCode_PK;
                            modelAccdetail.SODKGP = string.Empty;
                            istt++;
                            if (ReportBHYTBLL.InsReportBHYTDetail(modelAccdetail) < 1) {
                                result = false;
                                break;
                            }
                        }
                    }
                    foreach (var v in lstViewMedicinesReal)
                    {
                        ReportBHYTDetailInf modelAccdetail = new ReportBHYTDetailInf();
                        modelAccdetail.ReportID = this.reportID;
                        modelAccdetail.PatientReceiveID = v.PatientReceiveID;
                        modelAccdetail.PatientCode = this.txtMabn.Text.Trim();
                        modelAccdetail.ServiceCode = v.ItemCode;
                        modelAccdetail.ServicePrice = v.UnitPrice;
                        modelAccdetail.DisparityPrice = v.DisparityPrice;
                        modelAccdetail.ObjectCode = v.ObjectCode;
                        modelAccdetail.Quantity = v.Quantity;
                        modelAccdetail.Amount = v.Amount;
                        modelAccdetail.BHYTPay = v.BHYTPay;
                        modelAccdetail.PatientPay = v.PatientPay;
                        modelAccdetail.Ordinal = istt;
                        modelAccdetail.SalesPrice = v.SalesPrice;
                        modelAccdetail.BHYTPrice = v.BHYTPrice;
                        modelAccdetail.RateBHYT = Convert.ToInt32(v.RateBHYT.ToString());
                        modelAccdetail.DateOfIssues = v.DateOfIssues.ToString();
                        modelAccdetail.Morning = v.Morning;
                        modelAccdetail.Noon = v.Noon;
                        modelAccdetail.Afternoon = v.Afternoon;
                        modelAccdetail.Evening = v.Evening;
                        modelAccdetail.Instruction = v.Instruction;
                        modelAccdetail.DoseOf = string.Empty;
                        modelAccdetail.DoseOfPills = string.Empty;
                        modelAccdetail.RowIDPrice = v.RowIDPrice;
                        modelAccdetail.ServiceCode_PK = v.ItemCode_PK;
                        modelAccdetail.SODKGP = v.SODKGP;
                        istt++;
                        if (ReportBHYTBLL.InsReportBHYTDetail(modelAccdetail) < 1)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result)
                    {
                        PatientReceiveBLL.UpdPatientReceiveConfirmBV01(this.spatientReceiveID.TrimEnd(','), 1);
                        XtraMessageBox.Show("Lưu thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.butReceipt.Enabled = false;
                        this.butPrintItems.Enabled = this.butPrintServices.Enabled = this.butPrintBV.Enabled = this.butCancel.Enabled = true;
                        //this.ClearData();
                        //this.ClearBHYTInfo();
                        this.GetPatientWaiting();
                    }
                    else
                    {
                        ReportBHYTBLL.DelReportBHYT(this.reportID);
                        this.reportID = "-1";
                        XtraMessageBox.Show("Lưu không thành công. \r\n Xem lại thông tin lưu trữ.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật không thành công, vui lòng xem lại thông tin đợt điều trị của bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
            }
            catch (Exception ex){
                ReportBHYTBLL.DelReportBHYT(this.reportID);
                this.reportID = "-1";
                XtraMessageBox.Show("Error: butReceipt_Click " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.butReceipt.Enabled = true;
                this.butPrintItems.Enabled = this.butPrintServices.Enabled = this.butPrintBV.Enabled = this.butCancel.Enabled = false;
                this.gridView_Items.OptionsBehavior.Editable = true;
                this.gridView_Services.OptionsBehavior.Editable = true;
                this.ClearData();
                this.ClearBHYTInfo();
                this.searchLkup_Service.EditValue = this.searchLkup_Items.EditValue = null;
            }
            catch (Exception ex) {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabMainDetail_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (this.tabMainDetail.SelectedTabPageIndex == 0)
            {
                this.searchLkup_Service.Visible = true;
                this.searchLkup_Items.Visible = false;
                this.txtNgayCap.Properties.ReadOnly = this.txtMorning.Properties.ReadOnly = this.txtNoon.Properties.ReadOnly = this.txtAfternoon.Properties.ReadOnly = this.txtEvening.Properties.ReadOnly = this.txtInstruction.Properties.ReadOnly = true;
                this.butAddItem.Enabled = false;
            }
            else
            {
                this.searchLkup_Service.Visible = false;
                this.searchLkup_Items.Visible = true;
                this.txtNgayCap.Properties.ReadOnly = this.txtMorning.Properties.ReadOnly = this.txtNoon.Properties.ReadOnly = this.txtAfternoon.Properties.ReadOnly = this.txtEvening.Properties.ReadOnly = this.spinQuantity.Properties.ReadOnly = this.txtInstruction.Properties.ReadOnly = false;
                this.butAddItem.Enabled = true;
            }
        }

        private void gridView_Services_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                this.serviceCodeTemp = this.gridView_Services.GetRowCellValue(this.gridView_Services.FocusedRowHandle, col_ServiceCode).ToString();
                decimal rowidPrice = Convert.ToDecimal(this.gridView_Services.GetRowCellValue(this.gridView_Services.FocusedRowHandle, col_RowIDPrice).ToString());
                decimal quantityTemp = Convert.ToDecimal(this.gridView_Services.GetRowCellValue(this.gridView_Services.FocusedRowHandle, col_Quantity).ToString());
                decimal unitPriceTemp = Convert.ToDecimal(this.gridView_Services.GetRowCellValue(this.gridView_Services.FocusedRowHandle, col_ServicePrice).ToString());
                decimal amountTemp = Convert.ToDecimal(this.gridView_Services.GetRowCellValue(this.gridView_Services.FocusedRowHandle, col_Amount).ToString());
                Int32 objectCodeTemp = Convert.ToInt32(this.gridView_Services.GetRowCellValue(this.gridView_Services.FocusedRowHandle, col_ObjectCode).ToString());
                if (!string.IsNullOrEmpty(serviceCodeTemp))
                {
                    this.spinQuantity.Text = quantityTemp.ToString();
                    this.txtItemUnitPrice.EditValue = unitPriceTemp;
                    this.txtItemAmount.EditValue = amountTemp;
                    this.lkupDoituong.EditValue = objectCodeTemp;
                    this.searchLkup_Service.EditValue = rowidPrice.ToString();
                    this.butAddItem.Enabled = true;
                    this.spinQuantity.Enabled = true;
                }
            }
            catch { }
        }

        private void gridView_Items_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                string itemCodeTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_ItemCode).ToString();
                decimal quantityTemp = Convert.ToDecimal(this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Quantity).ToString());
                decimal unitPriceTemp = Convert.ToDecimal(this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_UnitPrice).ToString());
                decimal amountTemp = Convert.ToDecimal(this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Amount).ToString());
                string dateOfIssuesTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_DateOfIssues).ToString();
                string morningTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Morning).ToString();
                string noonTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Noon).ToString();
                string afternoonTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Afternoon).ToString();
                string eveningTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Evening).ToString();
                string instructionTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_Instruction).ToString();
                this.unitOfMeasureNameTemp = this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_UnitOfMeasureName).ToString();
                Int32 objectCodeTemp = Convert.ToInt32(this.gridView_Items.GetRowCellValue(this.gridView_Items.FocusedRowHandle, col_Medical_ObjectCode).ToString());
                if (!string.IsNullOrEmpty(itemCodeTemp))
                {
                    this.lkupDoituong.EditValue = objectCodeTemp;
                    this.txtNgayCap.EditValue = dateOfIssuesTemp;
                    this.spinQuantity.Text = quantityTemp.ToString();
                    this.txtMorning.EditValue = morningTemp;
                    this.txtNoon.EditValue = noonTemp;
                    this.txtAfternoon.EditValue = afternoonTemp;
                    this.txtEvening.EditValue = eveningTemp;
                    this.txtItemUnitPrice.Text = unitPriceTemp.ToString("N0");
                    this.txtItemAmount.Text = amountTemp.ToString("N0");
                    this.txtInstruction.Text = instructionTemp;
                    this.searchLkup_Items.EditValue = itemCodeTemp;
                    this.spinQuantity.Enabled = true;
                }
            }
            catch { }
        }

        private void butAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lkupDoituong.EditValue == null || string.IsNullOrEmpty(this.lkupDoituong.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chọn đối tượng cho dịch vụ(thuốc - vtth).", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (this.TxtChandoan.EditValue == null || string.IsNullOrEmpty(this.TxtChandoan.Text.Trim()))
                //{
                //    XtraMessageBox.Show(" Chọn đối tượng cho ICD-10.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if ( Convert.ToInt32(this.spinQuantity.Text) == 0 )
                {
                    XtraMessageBox.Show(" Số lượng phải lớn hơn 0.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.tabMainDetail.SelectedTabPageIndex == 0)
                {
                    decimal rowidPriceTemp = Convert.ToDecimal(this.searchLkup_Service.EditValue.ToString());
                    int objectCodeTemp = Convert.ToInt32(this.lkupDoituong.EditValue);
                    List<SuggestedViewInf> lstViewServiesTemp = this.lstViewServies.Where(p => p.RowIDPrice == rowidPriceTemp).ToList();
                    if (lstViewServiesTemp.Count > 0)
                    {
                        XtraMessageBox.Show(" Dịch vụ đã tồn tại! Vui lòng chọn dịch vụ khác.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.gridControl_Services.DataSource = null;
                    SuggestedViewInf sugges = new SuggestedViewInf();
                    sugges.Check = 1;
                    sugges.RowID = 0;
                    sugges.ReceiveID = 0;//khac cong kham bang = 0
                    sugges.PatientCode = this.txtMabn.Text.Trim();
                    sugges.ServiceCode = serviceCodeTemp;
                    sugges.ServiceName = this.serviceNameTemp;
                    sugges.Quantity = Convert.ToDecimal(this.spinQuantity.Text);
                    sugges.ServicePrice = Convert.ToDecimal(this.txtItemUnitPrice.EditValue);
                    sugges.DisparityPrice = disparityPriceTemp;
                    sugges.PatientPay = 0;
                    sugges.BHYTPay = 0;
                    sugges.Amount = Convert.ToDecimal(this.txtItemAmount.EditValue);
                    sugges.Status = 0;
                    sugges.Paid = 0;
                    sugges.ObjectCode = objectCodeTemp;
                    sugges.BanksAccountCode = string.Empty;
                    sugges.Cancel = 0;
                    sugges.ServiceGroupCode = this.serviceGroupCodeTemp;
                    sugges.ServiceGroupName = this.serviceGroupNameTemp;
                    sugges.UnitOfMeasureName = this.unitOfMeasureNameTemp;
                    sugges.ServiceModuleCode = this.serviceModuleCodeTemp;
                    sugges.RowIDPrice = rowidPriceTemp;
                    sugges.ServiceCode_PK = this.serviceCode_PKTemp;
                    sugges.SODKGP = string.Empty;
                    this.lstViewServies.Add(sugges);
                    this.GetTotalServiceMedical(true);
                }
                else if (this.tabMainDetail.SelectedTabPageIndex == 1)
                {
                    string itemCodeTemp = this.searchLkup_Items.EditValue.ToString();
                    int objectCodeTemp = Convert.ToInt32(this.lkupDoituong.EditValue);
                    List<SuggestedViewMedicinesBV01Inf> lstViewItemsTemp = this.lstViewItems.Where(p => p.ItemCode == itemCodeTemp && p.ObjectCode == objectCodeTemp).ToList();
                    if (!string.IsNullOrEmpty(itemCodeTemp))
                    {
                        if (lstViewItemsTemp.Count <= 0)
                        {
                            SuggestedViewMedicinesBV01Inf items = new SuggestedViewMedicinesBV01Inf();
                            items.ItemCode = itemCodeTemp;
                            items.Quantity = Convert.ToDecimal(this.spinQuantity.Text);
                            items.UnitPrice = Convert.ToDecimal(this.txtItemUnitPrice.EditValue);
                            items.Amount = items.Quantity * items.UnitPrice;
                            items.ItemName = this.itemNameTemp;
                            items.SalesPrice = this.itemSalesPriceTemp;
                            items.BHYTPrice = this.itemBHYTPriceTemp;
                            items.RateBHYT = this.itemRateBHYT;
                            items.BHYTPay = items.Amount;
                            items.Check = 1;
                            items.ObjectCode = Convert.ToInt32(this.lkupDoituong.EditValue);
                            items.ObjectName = this.lkupDoituong.Text;
                            items.DisparityPrice = this.itemDisparityPriceTemp;
                            items.DateOfIssues = this.txtNgayCap.EditValue.ToString();
                            items.Morning = this.txtMorning.Text.Trim();
                            items.Noon = this.txtNoon.Text.Trim();
                            items.Afternoon = this.txtAfternoon.Text.Trim();
                            items.Evening = this.txtEvening.Text.Trim();
                            items.Instruction = this.txtInstruction.Text.Trim();
                            items.UnitOfMeasureName = this.unitOfMeasureNameTemp;
                            items.ItemCode_PK = this.itemCode_PKTemp;
                            items.SODKGP = this.itemSODKGP_Temp;
                            this.lstViewItems.Add(items);
                        }
                        else
                        {
                            ///lstViewItemsTemp[0].ItemCode = itemCodeTemp;
                            lstViewItemsTemp[0].Quantity = Convert.ToDecimal(this.spinQuantity.Text);
                            lstViewItemsTemp[0].UnitPrice = Convert.ToDecimal(this.txtItemUnitPrice.EditValue);
                            lstViewItemsTemp[0].Amount = lstViewItemsTemp[0].Quantity * lstViewItemsTemp[0].UnitPrice;
                            ///lstViewItemsTemp[0].ItemName = this.itemNameTemp;
                            lstViewItemsTemp[0].SalesPrice = this.itemSalesPriceTemp;
                            lstViewItemsTemp[0].BHYTPrice = this.itemBHYTPriceTemp;
                            lstViewItemsTemp[0].RateBHYT = this.itemRateBHYT;
                            lstViewItemsTemp[0].BHYTPay = lstViewItemsTemp[0].Amount;
                            lstViewItemsTemp[0].PatientPay = 0;
                            lstViewItemsTemp[0].Check = 1;
                            ///lstViewItemsTemp[0].ObjectCode = Convert.ToInt32(this.lkupDoituong.EditValue);
                            ///lstViewItemsTemp[0].ObjectName = this.lkupDoituong.Text;
                            ///lstViewItemsTemp[0].DisparityPrice = this.itemDisparityPriceTemp;
                            lstViewItemsTemp[0].Morning = this.txtMorning.Text.Trim();
                            lstViewItemsTemp[0].Noon = this.txtNoon.Text.Trim();
                            lstViewItemsTemp[0].Afternoon = this.txtAfternoon.Text.Trim();
                            lstViewItemsTemp[0].Evening = this.txtEvening.Text.Trim();
                            lstViewItemsTemp[0].Instruction = this.txtInstruction.Text.Trim();
                            ///lstViewItemsTemp[0].UnitOfMeasureName = this.unitOfMeasureNameTemp;
                        }
                        this.gridControl_Items.DataSource = null;
                        this.GetTotalServiceMedical(true);
                    }
                }
            }
            catch { return; }
        }

        private void searchLkup_Items_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.itemListBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("ListBHYT").ToString());
            this.itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
            this.itemSalesPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice").ToString());
            this.itemBHYTPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("BHYTPrice").ToString());
            this.itemRateBHYT = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("RateBHYT").ToString());
            this.itemDisparityPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("DisparityPrice").ToString());
            this.unitOfMeasureNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureName").ToString();
            this.itemSODKGP_Temp = searchEdit.Properties.View.GetFocusedRowCellValue("SODKGP").ToString();
            this.itemCode_PKTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active_TT40").ToString();
            //if (this.itemListBHYTTemp.Equals(1))
            //{
            //    this.txtItemAmount.EditValue = this.txtItemUnitPrice.EditValue = itemBHYTPriceTemp;
            //}
            //else
            //{
            //    this.txtItemAmount.EditValue = this.txtItemUnitPrice.EditValue = itemSalesPriceTemp;
            //}
            this.txtItemAmount.Text = this.txtItemUnitPrice.Text = itemBHYTPriceTemp.ToString("N0");
            this.lkupDoituong.Properties.ReadOnly = false;
            this.lkupDoituong.EditValue = 1;
            this.butAddItem.Enabled = true;
            this.spinQuantity.Enabled = true;
           
        }

        private void searchLkup_Service_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            Int32 objectCodeTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("ObjectCode").ToString());
            this.lkupDoituong.EditValue = objectCodeTemp;
            this.serviceNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceName").ToString();
            this.serviceCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceCode").ToString();
            this.servicePriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("UnitPrice").ToString());
            this.disparityPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("DisparityPrice").ToString());
            this.serviceGroupNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceGroupName").ToString();
            this.serviceGroupCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceGroupCode").ToString();
            this.unitOfMeasureNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureName").ToString();
            this.serviceModuleCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceModuleCode").ToString();
            this.serviceModuleCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceModuleCode").ToString();
            this.serviceCode_PKTemp = searchEdit.Properties.View.GetFocusedRowCellValue("MaDK_BHYT").ToString();
            this.spinQuantity.Text = "1";
            this.txtItemUnitPrice.Text = this.servicePriceTemp.ToString("N0");
            this.txtItemAmount.Text = this.servicePriceTemp.ToString("N0");
            this.lkupDoituong.Properties.ReadOnly = true;
            this.butAddItem.Enabled = true;
            this.spinQuantity.Enabled = true;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            this.gridControl_BankList.DataSource = ReportBHYTBLL.TableListReportBHYTFinish(this.dtSearchFrom.Text, this.dtSearchTo.Text, 0);
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetap1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayTaiKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtAppointmentNote.Focus();
        }

        private void txtAppointmentNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butReceipt.Focus();
        }

        private void butPrintItems_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableInfo = ReportBHYTBLL.TableReportBHYTFinish(this.reportID);
                DataTable tableDetail = ReportBHYTBLL.TableReportBHYTFinishDetail(this.reportID, 1);
                if (tableDetail != null && tableDetail.Rows.Count > 0)
                {
                    DataSet dsResult = new DataSet("Result");
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in this.tableIDC10More.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                    }
                    tableInfo.Rows[0]["DepartmentName"] = "Phòng Khám";
                    //tableInfo.Rows[0]["ICD10"] = this.TxtChandoan.Text;
                    tableInfo.Rows[0]["ICD10More"] = sICD10kt;
                    dsResult.Tables.Add(tableInfo);
                    dsResult.Tables.Add(tableDetail);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToathuocBV01.xml");
                    Reports.rptToathuocBV01 rptShow = new Reports.rptToathuocBV01();
                    rptShow.Parameters["prTitle"].Value = "TOA THUỐC";
                    rptShow.Parameters["prNgayIn"].Value = "Ngày " + tableInfo.Rows[0]["DateOut"].ToString().Substring(0, 2) + " tháng " + tableInfo.Rows[0]["DateOut"].ToString().Substring(3, 2) + " năm " + tableInfo.Rows[0]["DateOut"].ToString().Substring(6, 4);
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuoc", "Toa thuốc bác sỹ");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Thuốc chưa phát sinh! Hãy kiểm tra lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_BankList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_BankList.RowCount > 0)
                {
                    this.ClearData();
                    this.ClearBHYTInfo();
                    //this.gridView_Items.OptionsBehavior.Editable = false;
                    //this.gridView_Services.OptionsBehavior.Editable = false;
                    this.done = 1;
                    this.tabMainContent.SelectedTabPageIndex = 0;
                    this.reportID = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "ReportID").ToString();
                    ReportBHYTInf bhyt = ReportBHYTBLL.ObjReportBHYTFinish(this.reportID);
                    if (bhyt != null && bhyt.ReportID != string.Empty)
                    {
                        PatientsInf objPatient = PatientsBLL.ObjPatients(bhyt.PatientCode, 0);
                        if (objPatient != null && objPatient.PatientCode != null)
                        {
                            this.txtMabn.Text = objPatient.PatientCode;
                            this.txtHoTen.Text = objPatient.PatientName;
                            this.txtTuoi.Text = objPatient.PatientAge.ToString();
                            this.txtDiaChi.Text = objPatient.PatientAddress;
                            this.txtDienThoai.Text = objPatient.PatientMobile;
                            this.txtEmail.Text = objPatient.PatientEmail;
                            this.txtTienSu.Text = objPatient.MedicalHistory;
                            this.txtDiUng.Text = objPatient.Allergy;
                            this.cbGioiTinh.SelectedIndex = objPatient.PatientGender;
                            this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                            this.txtNamSinh.Text = objPatient.PatientBirthyear.ToString();
                            this.txtLoaiTuoi.SelectedIndex = 0;
                            this.lkupNgheNghiep.EditValue = objPatient.CareerCode;
                            this.lkupDanToc.EditValue = objPatient.EThnicID;
                            this.lkupQuocTich.EditValue = objPatient.NationalityID;
                            this.txtDiaChi.Text = objPatient.PatientAddress;
                            this.txtMaTQPXa.Text = objPatient.WardCode;
                            this.lkupTQPXa.EditValue = objPatient.WardCode;
                            this.txtMaTinh.Text = this.txtMaTinh01.Text = objPatient.ProvincialCode;
                            this.lkupTinh.EditValue = objPatient.ProvincialCode;
                            if (!string.IsNullOrEmpty(objPatient.DistrictCode))
                                this.txtMaHuyen.Text = objPatient.DistrictCode;
                            else
                                this.txtMaHuyen.Text = string.Empty;
                            this.txtMaTinhHuyen.Text = objPatient.DistrictCode;
                            this.lkupHuyen.EditValue = objPatient.DistrictCode;
                            if (!string.IsNullOrEmpty(objPatient.WardCode))
                                this.txtMaPXa.Text = objPatient.WardCode;
                            else
                                this.txtMaPXa.Text = string.Empty;
                            this.lkupPhuongXa.EditValue = objPatient.WardCode;
                        }
                        this.serialBHYT = bhyt.Serial;
                        this.txtThe01.Text = bhyt.Serial01;
                        this.txtThe02.Text = bhyt.Serial02;
                        this.txtThe03.Text = bhyt.Serial03;
                        this.txtThe04.Text = bhyt.Serial04;
                        this.txtThe05.Text = bhyt.Serial05;
                        this.txtThe06.Text = bhyt.Serial06;
                        this.txtKCBBD.Text = bhyt.KCBBDCode;
                        this.lkKCB.EditValue = bhyt.KCBBDCode;
                        this.txtTheStart.EditValue = bhyt.StartDate.ToString("dd/MM/yyyy");
                        this.txtTheEnd.EditValue = bhyt.EndDate.ToString("dd/MM/yyyy");
                        this.lbstt.Text = bhyt.Serial.Length.ToString();
                        this.iTraituyen = bhyt.TraiTuyen;
                        this.iCapcuu = bhyt.Capcuu;
                        this.iChuyenvien = bhyt.ReferralPaper;
                        this.chkTraiTuyen.Checked = bhyt.TraiTuyen == 1 ? true : false;
                        this.chkGiayChuyenVien.Checked = bhyt.ReferralPaper == 1 ? true : false;
                        this.chkCapCuu.Checked = bhyt.Capcuu == 1 ? true : false;
                        this.lkupTTRV.EditValue = bhyt.MATTRV;
                        this.lkupTaiNanTT.EditValue = bhyt.MATNTT;
                        this.lkupKQDT.EditValue = bhyt.IDTreatmentResults;
                        this.GetCardInfo();
                        this.LoadDKKCBBD();

                        this.dateTimeIntoEdit.EditValue = bhyt.DateInto;
                        this.dateInto = bhyt.DateInto;
                        this.dateTimeOut.EditValue = bhyt.DateOut;
                        this.lkupDepartment.EditValue = bhyt.DepartmentCode;
                        this.txtTrieuChung.Text = bhyt.Symptoms;
                        this.txtMaICD10.EditValue = bhyt.ICD10_Custom;
                        this.txtNameICD10.EditValue = bhyt.ICD10Name_Custom;
                        this.txtChandoankemtheo.EditValue = bhyt.ICD10More;
                        List<DiagnosisInf> lstDiagnosis = DiagnosisBLL.ListDiagnosis(string.IsNullOrEmpty(bhyt.ICD10More.TrimEnd(',')) ? "-1" : bhyt.ICD10More.TrimEnd(','));
                        this.tableIDC10More.Clear();
                        foreach (var v in lstDiagnosis)
                        {
                            this.tableIDC10More.Rows.Add(v.RowID, v.DiagnosisCode + " - " + v.DiagnosisName);
                        }
                        this.gridControl_ICD10.DataSource = this.tableIDC10More;
                        this.cboxDiagnosis.Text = bhyt.DiagnosisCustom;
                        this.txtXutri.EditValue = bhyt.TackleCode;
                        this.txtLoidan.Text = bhyt.Advices;
                        this.memoTreatments.Text = bhyt.Treatments;

                        this.txtMach.Text = bhyt.Pulse;
                        this.txtHuyetap.Text = bhyt.BloodPressure;
                        this.txtHuyetap1.Text = bhyt.BloodPressure1;
                        this.txtNhietdo.Text = bhyt.Temperature;
                        this.txtNang.Text = bhyt.Weight;
                        this.txtCao.Text = bhyt.Hight;
                        this.txtNgayTaiKham.EditValue = bhyt.AppointmentDate;
                        this.txtAppointmentNote.Text = bhyt.AppointmentContent;
                        this.GetTotalServiceMedical(true);
                        this.butCancel.Enabled = this.butPrintBV.Enabled = this.butPrintItems.Enabled = this.butPrintServices.Enabled = this.butReceipt.Enabled = true;
                        this.butAddItem.Enabled = false;
                        this.spinQuantity.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrintServices_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableInfo = ReportBHYTBLL.TableReportBHYTFinish(this.reportID);
                DataTable tableDetail = ReportBHYTBLL.TableReportBHYTFinishDetail(this.reportID, 0);
                if (tableDetail != null && tableDetail.Rows.Count > 0)
                {
                    DataSet dsResult = new DataSet("Result");
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in this.tableIDC10More.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                    }
                    string departmentCode = this.lkupDepartment.EditValue.ToString();
                    string[] arrDepartment;
                    if (departmentCode.Length > 0)
                        arrDepartment = departmentCode.Split(',');
                    else
                        arrDepartment = null;
                    if (arrDepartment != null)
                    {
                        departmentCode = string.Empty;
                        for (Int32 i = 0; i < arrDepartment.Length; i++)
                        {
                            departmentCode += "'" + arrDepartment[i].ToString().Trim() + "',";
                        }
                    }
                    List<DepartmentInf> ListDepartmentForCode = DepartmentBLL.ListDepartmentForCode(departmentCode.TrimEnd(','));
                    departmentCode = string.Empty;
                    foreach (var depart in ListDepartmentForCode)
                    {
                        departmentCode += depart.DepartmentName + ";";
                    }
                    tableInfo.Rows[0]["DepartmentName"] = departmentCode.TrimEnd(';');
                    //tableInfo.Rows[0]["ICD10"] = this.TxtChandoan.Text;
                    tableInfo.Rows[0]["ICD10More"] = sICD10kt;
                    dsResult.Tables.Add(tableInfo);
                    dsResult.Tables.Add(tableDetail);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptChidinhBV01.xml");
                    Reports.rptChidinhBV01 rptShow = new Reports.rptChidinhBV01();
                    rptShow.Parameters["prNgayIn"].Value = "Ngày " + tableInfo.Rows[0]["DateOut"].ToString().Substring(0, 2) + " tháng " + tableInfo.Rows[0]["DateOut"].ToString().Substring(3, 2) + " năm " + tableInfo.Rows[0]["DateOut"].ToString().Substring(6, 4);
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Chỉ định dịch vụ");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Dịch vụ cận lâm sàn chưa phát sinh! Hãy kiểm tra lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butInBangKeHD_Click(object sender, EventArgs e)
        {
            ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
            frmPath.ShowInTaskbar = false;
            frmPath.ShowDialog();
            if (frmPath.reloaded)
            {
                this.gridControl_BankList.ExportToXls(frmPath.pathName);
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = false;
                oxl.ActiveWindow.DisplayZeros = false;
                oxl.Visible = true;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.done == 1 && !string.IsNullOrEmpty(this.reportID))
                {
                    if (XtraMessageBox.Show(" Bạn thật sự muốn hủy thông tin duyệt mẫu BV01?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (ReportBHYTBLL.UpdCancelReportBHYT(this.reportID, this.userid) >= 1)
                        {
                            XtraMessageBox.Show(" Hủy thành công mẫu BV01!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ClearData();
                            this.ClearBHYTInfo();
                            this.GetPatientWaiting();
                            this.butPrintBV.Enabled = this.butPrintItems.Enabled = this.butPrintServices.Enabled = false;
                        }
                        else
                        {
                            XtraMessageBox.Show(" Hủy không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Phiếu đã được hủy!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void tabMainContent_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (this.tabMainContent.SelectedTabPageIndex == 1)
                this.butSearch_Click(sender, e);
        }

        private void butPrintBV01_Click(object sender, EventArgs e)
        {
            try
            {
                //this.GetTotalServiceMedical();
                DataTable tableInfo = ReportBHYTBLL.TableReportBHYTFinish(this.reportID);
                DataTable tableDetail = ReportBHYTBLL.TableReportBHYTFinishDetail(this.reportID, 3);
                if (tableDetail != null && tableDetail.Rows.Count > 0)
                {
                    DataSet dsResult = new DataSet("Result");
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in this.tableIDC10More.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                    }
                    string departmentCode = this.lkupDepartment.EditValue.ToString();
                    string[] arrDepartment;
                    if (departmentCode.Length > 0)
                        arrDepartment = departmentCode.Split(',');
                    else
                        arrDepartment = null;
                    if (arrDepartment != null)
                    {
                        departmentCode = string.Empty;
                        for (Int32 i = 0; i < arrDepartment.Length; i++)
                        {
                            departmentCode += "'" + arrDepartment[i].ToString().Trim() + "',";
                        }
                    }
                    List<DepartmentInf> ListDepartmentForCode = DepartmentBLL.ListDepartmentForCode(departmentCode.TrimEnd(','));
                    departmentCode = string.Empty;
                    if (ListDepartmentForCode != null)
                    {
                        foreach (var depart in ListDepartmentForCode)
                        {
                            departmentCode += depart.DepartmentName + ";";
                        }
                    } 
                    tableInfo.Rows[0]["DepartmentName"] = departmentCode.TrimEnd(';');
                    //tableInfo.Rows[0]["ICD10"] = this.TxtChandoan.Text;
                    tableInfo.Rows[0]["ICD10More"] = sICD10kt;
                    dsResult.Tables.Add(tableInfo);
                    dsResult.Tables.Add(tableDetail);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptMauBV01Confirm.xml");
                    Reports.rptMauBV01Confirm rptShow = new Reports.rptMauBV01Confirm();
                    rptShow.Parameters["prTotalAmount"].Value = Convert.ToDecimal(tableInfo.Rows[0]["TotalAmount"].ToString());
                    rptShow.Parameters["prBHYTPayTotal"].Value = Convert.ToDecimal(tableInfo.Rows[0]["BHYTPay"].ToString());
                    rptShow.Parameters["prPatientPayTotal"].Value = Convert.ToDecimal(tableInfo.Rows[0]["PatientPay"].ToString());
                    rptShow.Parameters["prPatientReal"].Value = Convert.ToDecimal(tableInfo.Rows[0]["TotalReal"].ToString());
                    rptShow.Parameters["prDisparityPrice"].Value = Convert.ToDecimal(tableInfo.Rows[0]["TotalSurcharge"].ToString());
                    rptShow.Parameters["loai"].Value = "NGOẠI TRÚ";
                    rptShow.Parameters["MauBV"].Value = "01";
                    rptShow.Parameters["prNgayIn"].Value = "Ngày " + tableInfo.Rows[0]["DateOut"].ToString().Substring(0, 2) + " tháng " + tableInfo.Rows[0]["DateOut"].ToString().Substring(3, 2) + " năm " + tableInfo.Rows[0]["DateOut"].ToString().Substring(6, 4);
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BV01","Mẫu BV01");
                    rpt.ShowDialog();
                    //this.printfBVThuPhi();
                }
                else
                {
                    XtraMessageBox.Show(" Thông tin chi phí đợt điều trị không phát sinh!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_Services_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                this.receiptID = string.Empty;
                if (this.gridView_Services.GetRowCellValue(e.RowHandle, "Check").ToString() == "1")
                {
                    this.gridView_Services.SetRowCellValue(e.RowHandle, "Check", 0);
                }
                else
                {
                    this.gridView_Services.SetRowCellValue(e.RowHandle, "Check", 1);
                }
                decimal amountBHYTTotal = 0;
                this.ListService(ref amountBHYTTotal, false);
                this.ListMedical(ref amountBHYTTotal, false);
                this.gridControl_Services.DataSource = this.lstViewServies;
                this.gridView_Services.Columns["ServiceGroupName"].Group();
                this.gridView_Services.ExpandAllGroups();
                //this.gridControl_Items.DataSource = this.lstViewItems;
                this.SumAmountTotal(this.receiptID.TrimEnd(','));
            }
            catch { }
        }

        private void gridView_Items_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (this.gridView_Items.GetRowCellValue(e.RowHandle, "Check").ToString() == "1")
                    this.gridView_Items.SetRowCellValue(e.RowHandle, "Check", 0);
                else
                    this.gridView_Items.SetRowCellValue(e.RowHandle, "Check", 1);
                this.gridControl_Items.DataSource = this.lstViewItems;
                this.SumAmountTotal(this.receiptID.TrimEnd(','));
            }
            catch { }
        }

        private void txtNgayCap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.PreTotalQuantity();
            }
            catch { }
        }

        private void PreTotalQuantity()
        {
            decimal issue = Convert.ToDecimal(this.txtNgayCap.EditValue);
            decimal morning = this.ParseQuantity(this.txtMorning.EditValue.ToString());
            decimal noon = this.ParseQuantity(this.txtNoon.EditValue.ToString());
            decimal afternoon = this.ParseQuantity(this.txtAfternoon.EditValue.ToString());
            decimal evening = this.ParseQuantity(this.txtEvening.EditValue.ToString());
            decimal quantityTemp = issue * (morning + noon + afternoon + evening);
            this.spinQuantity.Text = quantityTemp.ToString();
            this.txtItemAmount.EditValue = quantityTemp * Convert.ToDecimal(this.txtItemUnitPrice.EditValue);
        }

        private void LoadProvincial(string provincialCode)
        {
            try
            {
                DataTable dtbProvincial = new DataTable();
                dtbProvincial = CatalogProvincialBLL.DTListProvincial(provincialCode);
                if (dtbProvincial.Rows.Count <= 0 || dtbProvincial == null)
                    dtbProvincial = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.lkupTinh.Properties.DataSource = dtbProvincial;
                this.lkupTinh.Properties.DisplayMember = "ProvincialName";
                this.lkupTinh.Properties.ValueMember = "ProvincialCode";
                this.lkupTinh.SelectedText = provincialCode;
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message); }
        }

        private void LoadDistrict(string districtCode, string provincialCode)
        {
            try
            {
                CatalogDistrictBLL district = new CatalogDistrictBLL();
                DataTable dtbDistrict = new DataTable();
                dtbDistrict = district.DTListDistrict(districtCode, provincialCode);
                if (dtbDistrict.Rows.Count <= 0 || dtbDistrict == null)
                    dtbDistrict = district.DTListDistrict(string.Empty, string.Empty);
                this.lkupHuyen.Properties.DataSource = dtbDistrict;
                this.lkupHuyen.Properties.DisplayMember = "DistrictName";
                this.lkupHuyen.Properties.ValueMember = "DistrictCode";
            }
            catch { return; }
        }

        private void LoadWard(string wardCode, string districtCode, string provincialCode)
        {
            try
            {
                CatalogWardBLL ward = new CatalogWardBLL();
                DataTable dtbWard = new DataTable();
                dtbWard = ward.DTListWard(wardCode, districtCode, provincialCode);
                if (dtbWard.Rows.Count <= 0 || dtbWard == null)
                    dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                this.lkupPhuongXa.Properties.DataSource = dtbWard;
                this.lkupPhuongXa.Properties.DisplayMember = "WardName";
                this.lkupPhuongXa.Properties.ValueMember = "WardCode";
            }
            catch { return; }
        }

        private void lkupTQPXa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tempMaTQPXa = this.lkupTQPXa.EditValue.ToString();
                this.txtMaTQPXa.Text = tempMaTQPXa;
                CatalogWardBLL ward = new CatalogWardBLL();
                DataTable dtbWard = new DataTable();
                dtbWard = ward.DTListWard(tempMaTQPXa, string.Empty, string.Empty);
                string tempTinh = string.Empty;
                string tempHuyen = string.Empty;
                foreach (DataRow dr in dtbWard.Rows)
                {
                    tempTinh = dr["ProvincialCode"].ToString().Trim();
                    tempHuyen = dr["DistrictCode"].ToString().Trim();

                }
                this.txtMaTinh.Text = this.txtMaTinh01.Text = tempTinh;
                this.txtMaHuyen.Text = tempHuyen;
                this.lkupTinh.EditValue = tempTinh;
                this.lkupHuyen.EditValue = tempHuyen;
                this.txtMaTinhHuyen.Text = tempHuyen;
                this.lkupPhuongXa.EditValue = tempMaTQPXa;
                this.txtMaPXa.Text = tempMaTQPXa;
                this.txtDienThoai.Focus();
            }
            catch { return; }
        }

        private void lkupTinh_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtMaTinh.Text = this.txtMaTinh01.Text = this.lkupTinh.EditValue.ToString();
                this.LoadDistrict(string.Empty, this.txtMaTinh.Text);
                this.LoadWard(string.Empty, string.Empty, this.txtMaTinh.Text);
                this.txtMaHuyen.Text = string.Empty;
                this.txtMaTinhHuyen.Text = string.Empty;
                this.txtMaPXa.Text = string.Empty;
            }
            catch { return; }
        }

        private void lkupHuyen_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tempDistrict = this.lkupHuyen.EditValue.ToString();
                this.txtMaHuyen.Text = tempDistrict;
                this.LoadWard(string.Empty, tempDistrict, this.txtMaTinh.Text);
                this.txtMaTinhHuyen.Text = tempDistrict;
                this.txtMaPXa.Text = string.Empty;
            }
            catch { return; }
        }

        private void lkupPhuongXa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtMaPXa.Text = this.lkupPhuongXa.EditValue.ToString();
            }
            catch { return; }
        }

        private void txtMaTQPXa_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMaTQPXa.Text.Trim().Length > 0)
                {
                    DataTable dtbWard = new DataTable();
                    CatalogWardBLL ward = new CatalogWardBLL();
                    dtbWard = ward.DTListWard(this.txtMaTQPXa.Text, string.Empty, string.Empty);
                    string tempTinh = string.Empty;
                    string tempHuyen = string.Empty;
                    foreach (DataRow dr in dtbWard.Rows)
                    {
                        tempTinh = dr["ProvincialCode"].ToString().Trim();
                        tempHuyen = dr["DistrictCode"].ToString().Trim();

                    }
                    string tempMaTQPXa = this.txtMaTQPXa.Text;
                    this.txtMaTQPXa.Text = tempMaTQPXa;
                    this.txtMaTinh.Text = this.txtMaTinh01.Text = tempTinh;
                    this.txtMaHuyen.Text = tempHuyen;
                    this.lkupTQPXa.EditValue = tempMaTQPXa;
                    this.LoadProvincial(txtMaTQPXa.Text);
                    this.LoadDistrict(this.txtMaTinh.Text, string.Empty);
                    this.LoadWard(string.Empty, string.Empty, this.txtMaTinh.Text);
                }
            }
            catch { return; }
        }

        private void txtMaTinh_Validated(object sender, EventArgs e)
        {
            try
            {
                this.LoadProvincial(txtMaTinh.Text.Trim());
                this.txtMaTinh01.Text = txtMaTinh.Text.Trim();
                this.LoadDistrict("", txtMaTinh.Text.Trim());
            }
            catch { return; }
        }

        private void txtMaHuyen_Validated(object sender, EventArgs e)
        {
            try
            {
                string tempDistrict = this.txtMaTinh01.Text + txtMaHuyen.Text;
                this.lkupHuyen.EditValue = tempDistrict;
                this.LoadWard(string.Empty, tempDistrict, this.txtMaTinh.Text);
            }
            catch { return; }
        }

        private void txtThe01_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe01.Text.Length < 2)
                this.txtThe01.Focus();
            else
                this.txtThe02.Focus();
        }

        private void txtThe01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtThe01.Text.Trim().Length == 2)
                    this.txtThe02.Focus();
                else
                    this.txtThe01.Focus();
            }
        }

        private void txtThe02_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe02.Text.Trim().Length < 1)
                this.txtThe02.Focus();
            else
                this.txtThe03.Focus();
        }

        private void txtThe02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtThe02.Text.Trim().Length == 1)
                    this.txtThe03.Focus();
                else
                    this.txtThe02.Focus();
            }
        }

        private void txtThe02_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (this.txtThe02.Text.Trim().Length < 1)
                    this.txtThe01.Focus();
            }
        }

        private void txtThe03_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe03.Text.Trim().Length < 2)
                this.txtThe03.Focus();
            else
                this.txtThe04.Focus();
        }

        private void txtThe03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtThe03.Text.Trim().Length == 2)
                    this.txtThe04.Focus();
                else
                    this.txtThe03.Focus();
            }
        }

        private void txtThe03_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (this.txtThe03.Text.Trim().Length < 1)
                    this.txtThe02.Focus();
            }
        }

        private void txtThe04_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe04.Text.Trim().Length < 2)
                this.txtThe04.Focus();
            else
                this.txtThe05.Focus();
        }

        private void txtThe04_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtThe04.Text.Trim().Length == 2)
                    this.txtThe05.Focus();
                else
                    this.txtThe04.Focus();
            }
        }

        private void txtThe04_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (this.txtThe04.Text.Trim().Length < 1)
                    this.txtThe03.Focus();
            }
        }

        private void txtThe05_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe05.Text.Trim().Length < 3)
                this.txtThe05.Focus();
            else
                this.txtThe06.Focus();
        }

        private void txtThe05_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtThe05.Text.Trim().Length == 3)
                    this.txtThe06.Focus();
                else
                    this.txtThe05.Focus();
            }
        }

        private void spinQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                this.butAddItem.Focus();
                e.Handled = true;
            }
        }

        private void spinQuantity_EditValueChanged(object sender, EventArgs e)
        {
            if(spinQuantity.Text == "")
            {
                this.txtItemAmount.EditValue = 0 * Convert.ToDecimal(this.txtItemUnitPrice.EditValue);
            }
            else
            {
                this.txtItemAmount.EditValue = Convert.ToDecimal(spinQuantity.Text) * Convert.ToDecimal(this.txtItemUnitPrice.EditValue);
            }
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    this.ClearData();
                    this.ClearBHYTInfo();
                    string patientCodeTemp = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, "PatientCode").ToString();
                    string dateInto = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, "CreateDate").ToString();
                    this.GetInfoPatient(patientCodeTemp, dateInto);
                    this.GetTotalServiceMedical(true);
                    if (!string.IsNullOrEmpty(dateInto))
                        this.dateInto = Convert.ToDateTime(dateInto);
                    this.butReceipt.Enabled = true;
                    this.gridView_Items.OptionsBehavior.Editable = true;
                    this.gridView_Services.OptionsBehavior.Editable = true;
                    this.tabMainContent.SelectedTabPageIndex = 0;
                    this.spinQuantity.Enabled = true;
                    this.butPrintBV.Enabled = this.butPrintItems.Enabled = this.butPrintServices.Enabled = this.butCancel.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: gridView_WaitingList_DoubleClick_ " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
        }

        private void txtThe05_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (this.txtThe05.Text.Trim().Length < 1)
                    this.txtThe04.Focus();
            }
        }
        
        private void txtThe06_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe06.Text.Trim().Length < 5)
                this.txtThe06.Focus();
            else
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }
        
        private void txtThe06_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtThe06.Text.Length == 5)
                    this.txtKCBBD.Focus(); ///SendKeys.Send("{Tab}{F4}");
                else
                    SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtThe06_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (this.txtThe06.Text.Trim().Length < 1)
                    this.txtThe05.Focus();
            }
        }

        private void txtKCBBD_Validated(object sender, EventArgs e)
        {
            this.LoadDKKCBBD();
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

        private void txtKCBBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkKCB.Focus();
            }
        }

        private void chkTraiTuyen_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
        }

        private void chkGiayChuyenVien_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
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

        private void txtMorning_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.PreTotalQuantity();
            }
            catch { }
        }

        private void txtNoon_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.PreTotalQuantity();
            }
            catch { }
        }

        private void txtAfternoon_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.PreTotalQuantity();
            }
            catch { }
        }

        private void txtEvening_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.PreTotalQuantity();
            }
            catch { }
        }

        private void frmConfirmReportBV01_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: this.butNew_Click(sender, e); break;
                case Keys.F2: this.butAddItem_Click(sender, e); break;
                case Keys.F3: this.butReceipt_Click(sender, e); break; 
                case Keys.F6: this.butPrintItems_Click(sender, e); break;
                case Keys.F7: this.butPrintServices_Click(sender, e); break;
            }
        }

        private void gridControl_ICD10_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && this.gridView_ICD10.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn bỏ chẩn đoán bệnh kèm theo này?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        this.tableIDC10More.Rows.RemoveAt(this.gridView_ICD10.FocusedRowHandle);
                    }
                }
            }
            catch { }
        }

        private void printfBVThuPhi()
        {
            try
            {
                //this.GetTotalServiceMedical();
                DataTable tableInfo = ReportBHYTBLL.TableReportBHYTFinishThuPhi(this.reportID);
                DataTable tableDetail = ReportBHYTBLL.TableReportBHYTFinishDetail(this.reportID, 4);
                if (tableDetail != null && tableDetail.Rows.Count > 0)
                {
                    DataSet dsResult = new DataSet("Result");
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in this.tableIDC10More.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
                    }
                    string departmentCode = this.lkupDepartment.EditValue.ToString();
                    string[] arrDepartment;
                    if (departmentCode.Length > 0)
                        arrDepartment = departmentCode.Split(',');
                    else
                        arrDepartment = null;
                    if (arrDepartment != null)
                    {
                        departmentCode = string.Empty;
                        for (Int32 i = 0; i < arrDepartment.Length; i++)
                        {
                            departmentCode += "'" + arrDepartment[i].ToString().Trim() + "',";
                        }
                    }
                    List<DepartmentInf> ListDepartmentForCode = DepartmentBLL.ListDepartmentForCode(departmentCode.TrimEnd(','));
                    departmentCode = string.Empty;
                    if (ListDepartmentForCode != null)
                    {
                        foreach (var depart in ListDepartmentForCode)
                        {
                            departmentCode += depart.DepartmentName + ";";
                        }
                    }
                    tableInfo.Rows[0]["DepartmentName"] = departmentCode.TrimEnd(';');
                    //tableInfo.Rows[0]["ICD10"] = this.TxtChandoan.Text;
                    tableInfo.Rows[0]["ICD10More"] = sICD10kt;
                    dsResult.Tables.Add(tableInfo);
                    dsResult.Tables.Add(tableDetail);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptMauBV01Confirm.xml");
                    
                    Reports.rptMauBV01Confirm_ThuPhi rptShow = new Reports.rptMauBV01Confirm_ThuPhi();
                    rptShow.Parameters["prTotalAmount"].Value = Convert.ToDecimal(tableInfo.Rows[0]["TotalAmount"].ToString());
                    rptShow.Parameters["prBHYTPayTotal"].Value = Convert.ToDecimal(tableInfo.Rows[0]["BHYTPay"].ToString());
                    rptShow.Parameters["prPatientPayTotal"].Value = Convert.ToDecimal(tableInfo.Rows[0]["PatientPay"].ToString());
                    rptShow.Parameters["prPatientReal"].Value = Convert.ToDecimal(tableInfo.Rows[0]["TotalReal"].ToString());
                    rptShow.Parameters["prDisparityPrice"].Value = Convert.ToDecimal(tableInfo.Rows[0]["TotalSurcharge"].ToString());
                    rptShow.Parameters["loai"].Value = "NGOẠI TRÚ";
                    rptShow.Parameters["MauBV"].Value = "01";
                    rptShow.Parameters["prNgayIn"].Value = "Ngày " + tableInfo.Rows[0]["DateOut"].ToString().Substring(0, 2) + " tháng " + tableInfo.Rows[0]["DateOut"].ToString().Substring(3, 2) + " năm " + tableInfo.Rows[0]["DateOut"].ToString().Substring(6, 4);
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BV01", "Mẫu BV01");
                    rpt.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtNameICD10_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtNameICD10.EditValue != null && !string.IsNullOrEmpty(this.txtNameICD10.EditValue.ToString()) && this.txtNameICD10.EditValue.ToString().EndsWith(" "))
                this.BrowseToICD10Name(this.txtMaICD10.Location.X, this.txtMaICD10.Location.Y, this.lkupICD10.Height, this.txtMaICD10.Width + this.txtNameICD10.Width);
        }

        private void txtMaICD10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.ResetLocationBrowseICD10();
                this.txtNameICD10.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                //this.lkupICD10.ShowPopup();
                this.lkupICD10.Focus();
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
            {
                //this.lkupICD10.ShowPopup();
                this.lkupICD10.Focus();
            }
        }

        private void lkupICD10_EditValueChanged(object sender, EventArgs e)
        {
            this.txtMaICD10.EditValue = this.lkupICD10.EditValue.ToString();
            this.txtNameICD10.EditValue = this.lkupICD10.Text;
            this.lkupICD10.Visible = false;
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

        private void ResetLocationBrowseICD10()
        {
            this.lkupICD10.Visible = false;
            this.lkupICD10.Location = new Point(9, 102);
            this.lkupICD10.Size = new Size(18, 20);
        }
    }
}