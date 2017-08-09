using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Xml.Serialization;
using System.Xml;
using iHISOpenImageDicom;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmKB_HSBA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private decimal patientReceiveID = decimal.Zero;
        private Int32 iPatientType = 0, iObjectCode = 0, iTraituyen = 0;
        private string medicalCode = string.Empty, sServiceCode = string.Empty, sDepartmentCode = string.Empty, refCode = string.Empty, patientCode = string.Empty;
        private string sTheBHYT = string.Empty;
        private DateTime dtReceive;
        private List<ListFileDicom> listFileDCMData = new List<ListFileDicom>();
        private DataTable dtICD10 = new DataTable("ICD10");
        private DataTable dtICD10rv = new DataTable("ICD10rv");

        private List<SurviveSignInf> lstSign = new List<SurviveSignInf>();
        private DateTime dtServer = new DateTime();
        public frmKB_HSBA(string refPatientCode)
        {
            InitializeComponent();
            patientCode = refPatientCode;
            List<SymptomsInf> lstSym = new List<SymptomsInf>();
            lstSym = SymptomsBLL.ListSymptoms(0);
            foreach (var v in lstSym)
            {
                this.txtTrieuChung.Properties.Items.Add(v.SymptomsName);
            }
            this.TxtChandoan.Properties.DataSource = DiagnosisBLL.ListDiagnosisName();
            this.TxtChandoan.Properties.DisplayMember = "DiagnosisName";
            this.TxtChandoan.Properties.ValueMember = "RowID";

            this.txtChandoankemtheo.Properties.DataSource = DiagnosisBLL.ListDiagnosisName();
            this.txtChandoankemtheo.Properties.DisplayMember = "DiagnosisName";
            this.txtChandoankemtheo.Properties.ValueMember = "RowID";

            this.txtXutri.Properties.DataSource = Tackle_BLL.ListTackle();
            this.txtXutri.Properties.DisplayMember = "TackleName";
            this.txtXutri.Properties.ValueMember = "TackleCode";

            List<AdvicesInf> lstAdvices = new List<AdvicesInf>();
            lstAdvices = AdvicesBLL.ListAdvices(0);
            foreach (var v in lstAdvices)
            {
                txtLoidan.Properties.Items.Add(v.AdvicesName);
            }
            this.dtICD10.Columns.Add("RowID", typeof(Int32));
            this.dtICD10.Columns.Add("DiagnosisName", typeof(string));
        }

        private void frmHSBA_Load(object sender, EventArgs e)
        {
            this.GetInfoPatient();
            this.GetHistoryPatient();
            this.enableText(true);
            this.dtServer = Utils.DateTimeServer();
        }

        private void GetHistoryPatient()
        {
            try
            {
                this.dbTree_History.Nodes.Clear();
                TreeNode node, node1;
                List<PatientReceiveInf> lstPatien = PatientReceiveBLL.ListForPatient(patientCode);
                foreach (var v in lstPatien)
                {
                    node = new TreeNode("Ngày vào viện: " + v.CreateDate.ToString("dd/MM/yyyy"));
                    node.Tag = v.PatientReceiveID + ":" + v.ObjectCode + ":" + v.PatientType + ":?:?:" + v.DepartmentCode + ":?";
                    this.dbTree_History.Nodes.Add(node);
                    DataTable dtTemp = SuggestedServiceReceiptBLL.DTListForPatientReceiveHSBA(v.PatientReceiveID, v.PatientCode, "TIEPDON");
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        node1 = new TreeNode("Khám: " + r["DepartmentName"].ToString());
                        node1.Tag = v.PatientReceiveID + ":" + r["ObjectCode"].ToString() + ":" + r["PatientType"].ToString() + ":" + r["MedicalRecordCode"].ToString() + ":" + r["ServiceCode"].ToString() + ":" + r["DepartmentCode"].ToString() + ":" + r["RowID"].ToString();
                        node.Nodes.Add(node1);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    lbNamsinh01.Text = objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    lbDiachi01.Text = objPatient.PatientAddress;

                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        picPatient.Image = (Bitmap)b;
                    }
                }
                else
                    return;
            }
            catch { }
        }

        private void GetCardInfo(Int32 iObjectCode, decimal dPatientReceiveID)
        {
            try
            {
                if (iObjectCode == 1)
                {
                    List<BHYTInf> lstBHYT = new List<BHYTInf>();
                    lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dPatientReceiveID);
                    if (lstBHYT.Count > 0)
                    {
                        //sTheBHYT = lstBHYT[0].Serial;
                        lbSothe.Text = lstBHYT[0].Serial;
                        lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                        //iTraituyen = lstBHYT[0].TraiTuyen;
                        //if (iTraituyen == 1)
                        //    chkTraiTuyen.Checked = true;
                        //else
                        //    chkTraiTuyen.Checked = false;
                        lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                        lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                        //GetCardInfo(lstBHYT[0].Serial);
                        //VisableBHYT(true);
                    }
                }
                else
                {
                    //lbTileBHYT.Text = ;
                    //VisableBHYT(false);
                }

                //string sMaBHYT = sCard.Substring(0, 2);
                //RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                //if (model != null || model.RateCard != string.Empty)
                //{
                //    if (chkTraiTuyen.Checked == true)
                //        lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                //    else
                //        lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                //}
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
        
        private void LoadInfo()
        {
            try
            {
                if (sDepartmentCode != "?" && sServiceCode != "?")
                {
                    DataTable dt = PatientReceiveBLL.DT_PatientWaitingDetail(patientReceiveID, sDepartmentCode, sServiceCode);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        refCode = dt.Rows[0]["ReferenceCode"].ToString();
                        txtTiensubenh.Text = dt.Rows[0]["MedicalHistory"].ToString();
                        txtDiungthuoc.Text = dt.Rows[0]["Allergy"].ToString();
                        txtLydokham.Text = dt.Rows[0]["Reason"].ToString();
                    }
                    else
                    {
                        txtTiensubenh.Text = "";
                        txtDiungthuoc.Text = "";
                        txtLydokham.Text = "";
                    }
                    MedicalRecord_INF mRecord = new MedicalRecord_INF();
                    mRecord = MedicalRecord_BLL.ObjMedicalRecordForReceiveID(patientReceiveID, sDepartmentCode);
                    if (mRecord != null && mRecord.RowID > 0)
                    {
                        this.medicalCode = mRecord.MedicalRecordCode;
                        txtTrieuChung.Text = mRecord.Symptoms;
                        TxtChandoan.EditValue = mRecord.DiagnosisCode;
                        txtChandoankemtheo.EditValue = mRecord.DiagnosisEnclosed;
                        txtXutri.EditValue = mRecord.TackleCode;
                        txtLoidan.Text = mRecord.Advices;
                        txtGhichu.Text = mRecord.DescriptionNode;
                        PatientAppointment_INF mApp = new PatientAppointment_INF();
                        mApp = PatientAppointment_BLL.ObjAppointment(patientReceiveID);
                        if (mApp != null && mApp.PatientReceiveID != 0)
                        {
                            txtNgayTaiKham.EditValue = mApp.AppointmentDate;
                            txtAppointmentNote.Text = mApp.AppointmentNote;
                        }
                        else
                        {
                            txtNgayTaiKham.EditValue = null;
                            txtAppointmentNote.Text = "";
                        }
                    }
                    else
                    {
                        txtTrieuChung.Text = "";
                        TxtChandoan.EditValue = null;
                        txtChandoankemtheo.EditValue = null;
                        txtXutri.EditValue = null;
                        txtLoidan.Text = "";
                        txtGhichu.Text = "";
                        txtNgayTaiKham.EditValue = null;
                        txtAppointmentNote.Text = "";
                    }
                    List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
                    lstSur = SurviveSignBLL.ListSurviveSignForRefCode(mRecord.MedicalRecordCode, patientReceiveID, patientCode);
                    if (lstSur != null && lstSur.Count > 0)
                    {
                        txtMach.Text = lstSur[0].Pulse;
                        txtNhietdo.Text = lstSur[0].Temperature;
                        txtHuyetap.Text = lstSur[0].BloodPressure;
                        txtHuyetap1.Text = lstSur[0].BloodPressure1;
                        txtNang.Text = lstSur[0].Weight;
                        txtCao.Text = lstSur[0].Hight;
                    }
                    else
                    {
                        txtMach.Text = "";
                        txtNhietdo.Text = "";
                        txtHuyetap.Text = "";
                        txtHuyetap1.Text = "";
                        txtNang.Text = "";
                        txtCao.Text = "";
                    }
                    dtICD10 = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(this.medicalCode);
                    gridControl_ICD10.DataSource = dtICD10;
                    if (iObjectCode == 1)
                    {
                        List<BHYTInf> lstBHYT = new List<BHYTInf>();
                        lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(patientReceiveID);
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
                        lbTileBHYT.Text = Utils.ObjectName(iObjectCode);
                        VisableBHYT(false);
                    }
                    ProcessBMI();
                }
            }
            catch { }
        }

        private void LoadMedicines()
        {
            try
            {
                treeB.Nodes.Clear();
                TreeNode node;
                if (this.medicalCode != "?")
                {
                    DataTable dtMedicalRecord = MedicalRecord_BLL.DT_Get_PrescriptionsOld(patientCode, patientReceiveID, this.medicalCode);
                    foreach (DataRow dr in dtMedicalRecord.Rows)
                    {
                        node = new TreeNode(dr["PostingDateName"].ToString());
                        node.Tag = dr["MedicalRecordCode"].ToString() + ":" + dr["PatientReceiveID"].ToString();
                        treeB.Nodes.Add(node);
                    }
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

        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (this.chkTraiTuyen.Checked)
                    {
                        if (this.chkGiayChuyenVien.Checked)
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

        private void ProcessBMI()
        {
            try
            {
                double do_BMI = 0;
                double do_W = 0;
                double do_H = 0;
                string strThumuc = Directory.GetCurrentDirectory();
                if (txtNang.Text.Trim() != "" && txtCao.Text.Trim() != "")
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

        public void enableText(bool ena)
        {
            try
            {
                txtTrieuChung.Properties.ReadOnly = TxtChandoan.Properties.ReadOnly = txtChandoankemtheo.Properties.ReadOnly = txtXutri.Properties.ReadOnly = txtLoidan.Properties.ReadOnly = ena;
                txtMach.Properties.ReadOnly = txtHuyetap.Properties.ReadOnly = txtHuyetap1.Properties.ReadOnly = txtNhietdo.Properties.ReadOnly = txtNang.Properties.ReadOnly = txtCao.Properties.ReadOnly = ena;
                txtGhichu.Properties.ReadOnly = txtNgayTaiKham.Properties.ReadOnly = txtAppointmentNote.Properties.ReadOnly = ena;
                txtTiensubenh.Properties.ReadOnly = txtDiungthuoc.Properties.ReadOnly = txtLydokham.Properties.ReadOnly = ena;

            }
            catch { }
        }

        private void PrintPrescription()
        {
            try
            {
                DataTable dtMedicalRecordPrint = new DataTable("ResultMedicalRecord");
                dtMedicalRecordPrint = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.patientReceiveID, 0);
                DataTable dtMedicalDetail = new DataTable("ResultMedicalDetail");
                dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalCode, "2", iObjectCode, 0,-1);
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = new DataTable("SurviveSign");
                    dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.patientReceiveID);
                    DataTable dtBHYT = new DataTable("BHYT");
                    dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveID);
                    DataSet dsTemp = new DataSet("Result");

                    DataTable dtICD10kt = new DataTable();
                    dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in dtICD10.Rows)
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
                    Reports.rpt_KB_Toathuoc rptShow = new Reports.rpt_KB_Toathuoc(this.dtServer, this.dtServer);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Toathuoc", "Toa thuốc");
                    rpt.ShowDialog();
                }
                else
                {
                    DataTable dtSurviveSign = new DataTable("SurviveSign");
                    dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.patientReceiveID);
                    DataTable dtBHYT = new DataTable("BHYT");
                    dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveID);
                    DataSet dsTemp = new DataSet("Result");
                    DataTable dtICD10kt = new DataTable();
                    dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in dtICD10.Rows)
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
                    Reports.rptToathuocBlank rptShow = new Reports.rptToathuocBlank(this.dtServer, this.dtServer);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow,"Toathuoc", "Toa thuốc");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PrintPrescription_Out()
        {
            try
            {
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Clear();
                DataTable dtClinic = new DataTable("ClinicInfo");
                dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtMedicalRecord = new DataTable("ResultMedicalRecord");
                dtMedicalRecord = MedicalRecord_BLL.DT_GetResultMedical(this.medicalCode, this.patientReceiveID, 0);
                DataTable dtMedicalDetail = new DataTable("ResultMedicalDetail");
                dtMedicalDetail = MedicalRecord_BLL.DT_GetResultMedicalDetail(this.medicalCode, "4", iObjectCode, 1,-1);
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    DataTable dtSurviveSign = new DataTable("SurviveSign");
                    dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(this.medicalCode, this.patientCode, this.patientReceiveID);
                    DataTable dtICD10kt = new DataTable();
                    dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                    string sICD10kt = string.Empty;
                    foreach (DataRow dr in dtICD10.Rows)
                    {
                        sICD10kt += dr["DiagnosisName"].ToString().Trim() + ";";
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

        private void LoadService()
        {
            try
            {
                //DataTable dtGroup = SuggestedServiceReceiptBLL.DTListForGroupServiceHSBA(patientReceiveID, patientCode, sDepartmentCode);
                this.gridControl_SuggestedReceipt.DataSource = SuggestedServiceReceiptBLL.DTListForPatientServiceHSBA(patientReceiveID, patientCode);
                this.gridView_SuggestedReceipt.Columns["ServiceGroupName"].Group();
                this.gridView_SuggestedReceipt.Columns["ServiceCategoryName"].Group();
                this.gridView_SuggestedReceipt.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResultSieuAm(decimal dReceiptID)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptID, this.patientReceiveID);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaSieuam.xml");
                    Reports.rptCLS_SieuamA4Rotate rptShow = new Reports.rptCLS_SieuamA4Rotate();
                    rptShow.Parameters["RadiologyRowID"].Value = dReceiptID.ToString();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "SieuAm", "Kết quả siêu âm");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả siêu âm chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResultNoiSoi(decimal dReceiptID)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptID, this.patientReceiveID);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaNoisoi.xml");
                    Reports.rptCLS_NoisoiA4Rotate rptShow = new Reports.rptCLS_NoisoiA4Rotate();
                    rptShow.Parameters["RadiologyRowID"].Value = dReceiptID;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "NoiSoi","Kết quả nọi soi");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả nội soi chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResultXQuang(decimal dReceiptID)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptID, this.patientReceiveID);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaXQuang.xml");
                    Reports.rptCLS_XQuangA5 rptShow = new Reports.rptCLS_XQuangA5(this.dtServer);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "X-Quang","Kết quả X-Quang");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả X-Quang chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResultDienTim(decimal dReceiptID)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptID, this.patientReceiveID);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaDientim.xml");
                    Reports.rptDientim rptShow = new Reports.rptDientim();
                    rptShow.Parameters["RadiologyRowID"].Value = dReceiptID.ToString();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DienTim","Kết quả điện tim");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả điện tim chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void ResultMRI(decimal dReceiptID)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptID, patientReceiveID);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaMRI.xml");
                    //repPhieuKQ.Parameters["RadiologyRowID"].Value = dReceiptCode.ToString();
                    Reports.rptMRI rptShow = new Reports.rptMRI();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "MRI", "Kết quả MRI");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả MRI chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResultCTScanner(decimal dReceiptID)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptID, this.patientReceiveID);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaCTScanner.xml");
                    Reports.rptCTScanner rptShow = new Reports.rptCTScanner();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "CTSCanner","Kết quả CT");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả CTScanner chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResultSurgeries(decimal dReceiptID, string surgeriesCode)
        {
            try
            {
                DataTable dtResult = SurgeriesBLL.DT_RptViewSurgeries(surgeriesCode, this.patientReceiveID);
                DataTable dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(surgeriesCode, patientCode, this.patientReceiveID, Utils.DateServer());
                DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(surgeriesCode,this.patientCode, this.patientReceiveID);
                DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveID);
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtResult);
                dsTemp.Tables.Add(dtEmergencyDetail);
                dsTemp.Tables.Add(dtSurviveSign);
                dsTemp.Tables.Add(dtBHYT);

                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptPhauThuThuat.xml");
                Reports.rptPhauThuThuat rptShow = new Reports.rptPhauThuThuat();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ThuThuat", "Kết quả PT-TT");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void treeB_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.iObjectCode.Equals(1))
            {
                this.PrintPrescription();
                this.PrintPrescription_Out();
            }
            else
            {
                this.PrintPrescription_Out();
            }
        }
        
        private void dbTree_History_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.patientReceiveID = Convert.ToDecimal(dbTree_History.SelectedNode.Tag.ToString().Split(':')[0]);
                this.iObjectCode = Convert.ToInt32(dbTree_History.SelectedNode.Tag.ToString().Split(':')[1]);
                this.iPatientType = Convert.ToInt32(dbTree_History.SelectedNode.Tag.ToString().Split(':')[2]);
                this.medicalCode = ISDBNULL2STRING(dbTree_History.SelectedNode.Tag.ToString().Split(':')[3], string.Empty);
                this.sServiceCode = ISDBNULL2STRING(dbTree_History.SelectedNode.Tag.ToString().Split(':')[4], string.Empty);
                this.sDepartmentCode = ISDBNULL2STRING(dbTree_History.SelectedNode.Tag.ToString().Split(':')[5], string.Empty);
                if (this.iPatientType == 1)
                {
                    this.LoadInfo();
                    this.LoadMedicines();
                    this.LoadService();
                }
                else
                {
                    this.xTabMain.SelectedTabPageIndex = 1;
                    this.LoadInfoEmergency();
                    this.LoadMedicinesEmergency();
                    this.LoadServiceEmergency();
                }
                this.GetDataImage(patientReceiveID);
                this.GetSurviveSign();
                this.GetStatistic();
            }
            catch
            {
                this.patientReceiveID = 0;
            }
        }
        
        private void ResultLabGeneral(decimal receiptID)
        {
            try
            {
                decimal rowIDLaboratory = ServiceLaboratoryEntryBLL.GetRowIDLaboratoryEnTry(receiptID);
                if (this.patientCode != string.Empty && rowIDLaboratory > 0)
                {
                    DataTable dtClinic = new DataTable("ClinicInfo");
                    dtClinic = ClinicInformationBLL.DT_Information(1);
                    DataTable dtResultDetail = new DataTable("LabResultDetail");
                    dtResultDetail = ServiceLaboratoryEntryBLL.TableResultLaboratoryDetailForPrinter(rowIDLaboratory.ToString(), this.patientReceiveID);
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResultDetail);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_XN_General.xml");
                    Reports.rptXN_General_A4 rptShow = new Reports.rptXN_General_A4(this.dtServer);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "KQXetNghiem","Kết quả xét nghiệm");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Kết quả xét nghiệm chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInfoEmergency()
        {
            try
            {
                List<SymptomsInf> lstSym = new List<SymptomsInf>();
                lstSym = SymptomsBLL.ListSymptoms(0);
                foreach (var v in lstSym)
                {
                    cbChandoan.Properties.Items.Add(v.SymptomsName);
                }
                List<DiagnosisInf> lstDia = DiagnosisBLL.ListDiagnosisName();
                lkupICD10.Properties.DataSource = lstDia;
                lkupICD10.Properties.DisplayMember = "DiagnosisName";
                lkupICD10.Properties.ValueMember = "DiagnosisCode";

                lkupICD10ktheo.Properties.DataSource = lstDia;
                lkupICD10ktheo.Properties.DisplayMember = "DiagnosisName";
                lkupICD10ktheo.Properties.ValueMember = "RowID";

                lkupBenhchinh.Properties.DataSource = lstDia;
                lkupBenhchinh.Properties.DisplayMember = "DiagnosisName";
                lkupBenhchinh.Properties.ValueMember = "DiagnosisCode";

                lkupBenhkemtheo.Properties.DataSource = lstDia;
                lkupBenhkemtheo.Properties.DisplayMember = "DiagnosisName";
                lkupBenhkemtheo.Properties.ValueMember = "RowID";

                lkXutri.Properties.DataSource = Tackle_BLL.ListTackle();
                lkXutri.Properties.DisplayMember = "TackleName";
                lkXutri.Properties.ValueMember = "TackleCode";

                lkKetquadieutri.Properties.DataSource = MedicalEmergencyBLL.lstResults();
                lkKetquadieutri.Properties.DisplayMember = "ResultsName";
                lkKetquadieutri.Properties.ValueMember = "RowID";

                List<AdvicesInf> lstAdvices = new List<AdvicesInf>();
                lstAdvices = AdvicesBLL.ListAdvices(0);
                foreach (var v in lstAdvices)
                {
                    cbLoidan.Properties.Items.Add(v.AdvicesName);
                }
                lkBacsi.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
                lkBacsi.Properties.DisplayMember = "EmployeeName";
                lkBacsi.Properties.ValueMember = "EmployeeCode";

                lkNhanbenh.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
                lkNhanbenh.Properties.DisplayMember = "EmployeeName";
                lkNhanbenh.Properties.ValueMember = "EmployeeCode";

                dtICD10rv.Columns.Add("RowID", typeof(Int32));
                dtICD10rv.Columns.Add("DiagnosisName", typeof(string));

                MedicalEmergencyINF ObjEmergency = MedicalEmergencyBLL.ObjEmergency(patientCode, patientReceiveID);
                if (ObjEmergency != null && ObjEmergency.MedicalEmergencyCode != string.Empty)
                {
                    List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(patientReceiveID);
                    if (lstReceive.Count > 0 && lstReceive != null)
                        dtReceive = lstReceive[0].CreateDate;
                    if (lstReceive.Count > 0 && lstReceive != null)
                        dtReceive = lstReceive[0].CreateDate;
                    DataTable dt = PatientReceiveBLL.DT_PatientWaitingEmergency(patientReceiveID, 0);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        refCode = dt.Rows[0]["ReferenceCode"].ToString();
                        txtTiensubenh.Text = dt.Rows[0]["MedicalHistory"].ToString();
                        txtDiungthuoc.Text = dt.Rows[0]["Allergy"].ToString();
                        txtLydokham.Text = dt.Rows[0]["Reason"].ToString();
                        txtTiensubenhCC.Text = dt.Rows[0]["MedicalHistory"].ToString();
                        txtDiungthuocCC.Text = dt.Rows[0]["Allergy"].ToString();
                        txtLydokhamCC.Text = dt.Rows[0]["Reason"].ToString();
                    }
                    if (iObjectCode == 1)
                    {
                        List<BHYTInf> lstBHYT = new List<BHYTInf>();
                        lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(patientReceiveID);
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
                        List<ObjectInf> ListObject = ObjectBLL.ListObject(iObjectCode);
                        lbTileBHYT.Text = ListObject[0].ObjectName;
                        VisableBHYT(false);
                    }

                    List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefCode(ObjEmergency.MedicalEmergencyCode, patientReceiveID, patientCode);
                    if (lstSur.Count > 0)
                    {
                        txtMach.Text = lstSur[0].Pulse;
                        txtNhietdo.Text = lstSur[0].Temperature;
                        txtHuyetap.Text = lstSur[0].BloodPressure;
                        txtHuyetap1.Text = lstSur[0].BloodPressure1;
                        txtNang.Text = lstSur[0].Weight;
                        txtCao.Text = lstSur[0].Hight;

                        txtMachCC.Text = lstSur[0].Pulse;
                        txtNhietdoCC.Text = lstSur[0].Temperature;
                        txtHuyetapCC.Text = lstSur[0].BloodPressure;
                        txtHuyetapCC1.Text = lstSur[0].BloodPressure1;
                        txtNangCC.Text = lstSur[0].Weight;
                        txtCaoCC.Text = lstSur[0].Hight;
                    }
                    else
                    {
                        txtMach.Text = string.Empty;
                        txtNhietdo.Text = string.Empty;
                        txtHuyetap.Text = string.Empty;
                        txtHuyetap1.Text = string.Empty;
                        txtNang.Text = string.Empty;
                        txtCao.Text = string.Empty;

                        txtMachCC.Text = string.Empty;
                        txtNhietdo.Text = string.Empty;
                        txtHuyetapCC.Text = string.Empty;
                        txtHuyetapCC1.Text = string.Empty;
                        txtNangCC.Text = string.Empty;
                        txtCaoCC.Text = string.Empty;
                    }
                    MedicalEmergencyINF objEmergency = MedicalEmergencyBLL.ObjEmergency(ObjEmergency.MedicalEmergencyCode);
                    if (objEmergency != null && objEmergency.MedicalEmergencyCode != "")
                    {
                        txtNgayvv.Text = objEmergency.DateOn.ToString("dd/MM/yyyy");
                        txtGiovv.Text = objEmergency.TimeOn;
                        txtNhantu.Text = objEmergency.ReceivePatientFrom;
                        cbChandoan.Text = objEmergency.DiagnosisCode;
                        lkupICD10.EditValue = objEmergency.ICD10;
                        txtNguoithan.Text = objEmergency.Family;
                        txtHoten.Text = objEmergency.FamilyFullname;
                        txtdiachi.Text = objEmergency.FamilyAddress;
                        txtDienthoai.Text = objEmergency.FamilyMobile;
                        lkNhanbenh.EditValue = objEmergency.PatientReceivingNursing;
                    }
                    dtICD10 = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(ObjEmergency.MedicalEmergencyCode);
                    gridControl_ICD10.DataSource = dtICD10;
                    MedicalEmergencyOutINF objEmergencyOut = MedicalEmergencyBLL.ObjEmergencyOut(ObjEmergency.MedicalEmergencyCode);
                    if (objEmergencyOut != null && objEmergencyOut.PatientReceiveID > 0)
                    {
                        txtNgayrv.Text = objEmergencyOut.DateOut.ToString("dd/MM/yyyy");
                        txtGiorv.Text = objEmergencyOut.TimeOut;
                        txtNgaydieutri.Text = objEmergencyOut.TreatmentTime.ToString();
                        lkKetquadieutri.EditValue = objEmergencyOut.TreatmentResults;
                        lkupBenhchinh.EditValue = objEmergencyOut.ICD10Out;

                        lkBacsi.EditValue = objEmergencyOut.TreatingDoctor;
                        txtSoluutru.Text = objEmergencyOut.NumberStorage.ToString();
                        lkXutri.EditValue = objEmergencyOut.TackleCode;
                        cbLoidan.Text = objEmergencyOut.Advices;
                    }
                    dtICD10rv = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(objEmergencyOut.MedicalEmergencyOutCode);
                    gridControl_Benhkemtheo.DataSource = dtICD10rv;
                }
            }
            catch { }
        }

        private void LoadMedicinesEmergency()
        {
            try
            {
                treeCCThuoc.Nodes.Clear();
                TreeNode node;
                DataTable dtMedicalRecord = MedicalRecord_BLL.DT_Get_PrescriptionsOld(patientCode, patientReceiveID, this.medicalCode);
                foreach (DataRow dr in dtMedicalRecord.Rows)
                {
                    node = new TreeNode(dr["PostingDateName"].ToString());
                    node.Tag = dr["MedicalRecordCode"].ToString() + ":" + dr["PatientReceiveID"].ToString();
                    treeCCThuoc.Nodes.Add(node);
                }
            }
            catch { }
        }

        private void LoadServiceEmergency()
        {
            try
            {
                treeCCDichvu.Nodes.Clear();
                TreeNode node;
                DataTable dtGroup = SuggestedServiceReceiptBLL.DTListForGroupServiceHSBA(patientReceiveID, patientCode, sDepartmentCode);
                DataTable dtService;
                foreach (DataRow row in dtGroup.Rows)
                {
                    node = new TreeNode(row["ServiceGroupName"].ToString());
                    node.Tag = "0:" + row["ServiceGroupCode"].ToString();
                    treeCCDichvu.Nodes.Add(node);
                    //dtService = SuggestedServiceReceiptBLL.DTListForPatientServiceHSBA(patientReceiveID, patientCode, row["ServiceGroupCode"].ToString());
                    //foreach (DataRow r in dtService.Rows)
                    //{
                    //    if (r["Status"].ToString() == "0")
                    //        node1 = new TreeNode(r["ServiceName"].ToString());
                    //    else
                    //        node1 = new TreeNode(r["ServiceName"].ToString() + " (" + r["StatusName"].ToString() + ") ");
                    //    node1.Tag = r["RowID"].ToString() + ":" + r["ServiceMenuID"].ToString();
                    //    node.Nodes.Add(node1);
                    //}
                }
            }
            catch { }
        }

        private void treeCCThuoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.PrintPrescription_Out();
        }
        public Bitmap BytesToBitmap(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Bitmap img = (Bitmap)Image.FromStream(ms);
                return img;
            }
        }
        
        private void gridView_SuggestedReceipt_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Preview")
            {
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                int status = Convert.ToInt32(this.gridView_SuggestedReceipt.GetRowCellValue(e.RowHandle, "Status"));
                if (status == 0)
                {
                    btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                    btn.Buttons[0].Enabled = false;
                    e.RepositoryItem = btn;
                }
            }
            else if(e.Column.FieldName == "ServiceMenuID")
            {
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                int dicom = Convert.ToInt32(this.gridView_SuggestedReceipt.GetRowCellValue(e.RowHandle, "ServiceMenuID"));
                if (dicom != 3)
                {
                    btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                    btn.Buttons[0].Enabled = false;
                    e.RepositoryItem = btn;
                }
            }
        }
        
        private void repbutPreview_Click(object sender, EventArgs e)
        {
            try
            {
                decimal receiptID = Convert.ToDecimal(this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, "ReceiptID").ToString());
                string resultCode = this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, "ResultCode").ToString();
                int serviceMenuID = Convert.ToInt32(this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, "ServiceMenuID").ToString());
                if (serviceMenuID == 5)
                    this.ResultSieuAm(receiptID);
                else if (serviceMenuID == 6)
                    this.ResultNoiSoi(receiptID);
                else if (serviceMenuID == 3)
                    this.ResultXQuang(receiptID);
                else if (serviceMenuID == 4)
                    this.ResultDienTim(receiptID);
                else if (serviceMenuID == 10)
                    this.ResultMRI(receiptID);
                else if (serviceMenuID == 11)
                    this.ResultCTScanner(receiptID);
                else if (serviceMenuID == 16 || serviceMenuID == 7 || serviceMenuID == 8 || serviceMenuID == 9 || serviceMenuID == 13 || serviceMenuID == 14)
                    this.ResultLabGeneral(receiptID);
                else if (serviceMenuID == 2)
                    this.ResultSurgeries(receiptID, resultCode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void repbutVieDicom_Click(object sender, EventArgs e)
        {
            try
            {
                //string serviceModuleCode = this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, "ServiceModuleCode").ToString();
                decimal receiptID = Convert.ToDecimal(this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, "ReceiptID").ToString());
                var temp = ServiceRadiologyBLL.ObjRadiologyEntryForSuggestedID(receiptID);
                var imageList = ServiceRadiologyBLL.ListRadiologyDetail(temp.RowID);
                this.listFileDCMData = new List<ListFileDicom>();
                foreach (var detail in imageList)
                {
                    ListFileDicom dicom = new ListFileDicom();
                    dicom.ID = detail.RowID.ToString();
                    dicom.Img = this.BytesToBitmap(detail.Image);
                    dicom.PatientName = this.lbHoten01.Text;
                    dicom.Technique = string.Empty;
                    this.listFileDCMData.Add(dicom);
                }
                iHISOpenImageDicom.frmOpenFileDicom frmDicom = new frmOpenFileDicom(this.listFileDCMData);
                frmDicom.ShowDialog();
                if (frmDicom.listFileDCM != null)
                    this.listFileDCMData = frmDicom.listFileDCM;
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void treeCCDichvu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                decimal receiptID = Convert.ToDecimal(treeCCDichvu.SelectedNode.Tag.ToString().Split(':')[0]);
                Int32 serviceMenuID = Convert.ToInt32(treeCCDichvu.SelectedNode.Tag.ToString().Split(':')[1]);
                if (serviceMenuID == 5)
                    ResultSieuAm(receiptID);
                else if (serviceMenuID == 6)
                    ResultNoiSoi(receiptID);
                else if (serviceMenuID == 3)
                    ResultXQuang(receiptID);
                else if (serviceMenuID == 4)
                    ResultDienTim(receiptID);
                else if (serviceMenuID == 10)
                    ResultMRI(receiptID);
                else if (serviceMenuID == 11)
                    ResultCTScanner(receiptID);
                else if (serviceMenuID == 16 || serviceMenuID == 7 || serviceMenuID == 8 || serviceMenuID == 9 || serviceMenuID == 13 || serviceMenuID == 14)
                    this.ResultLabGeneral(receiptID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetDataImage(decimal dPatientReceiveID)
        {
            try
            {
                pnListImage.Controls.Clear();
                int x = 5, y = 0;
                var imageList = PatientReceiveCocumentImageBLL.List(dPatientReceiveID, patientCode);
                foreach (PatientReceiveCocumentImageInf image in imageList)
                {
                    PictureBox l = new PictureBox();
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(image.Image.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    l.Image = (Bitmap)b;
                    l.Width = 130;
                    l.Height = 130;
                    l.Location = new System.Drawing.Point(x, y);
                    l.BorderStyle = BorderStyle.Fixed3D;
                    l.SizeMode = PictureBoxSizeMode.StretchImage;
                    l.Cursor = Cursors.Hand;
                    l.Tag = "db";
                    l.DoubleClick += new System.EventHandler(this.pic1_Click);

                    CheckBox chk = new CheckBox();
                    chk.ForeColor = Color.Red;
                    chk.Text = "Hình " + image.STT;
                    chk.AutoSize = true;
                    TextBox txt = new TextBox();
                    txt.ForeColor = Color.Red;
                    txt.Text = image.Note;
                    txt.Width = 160;
                    txt.Height = 30;
                    //chk.Location = new Point(x, y + 100);
                    chk.Location = new Point(x, y + 130);
                    txt.Location = new Point(x, y + 150);
                    //chk.Location = new Point(x + 130, y);
                    //txt.Location = new Point(x + 150, y);
                    x += l.Height + 45;

                    //chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                    pnListImage.Controls.Add(l);
                    pnListImage.Controls.Add(chk);
                    pnListImage.Controls.Add(txt);
                }
            }
            catch { }
        }

        private void pic1_Click(object sender, System.EventArgs e)
        {
            try
            {
                PictureBox l = (PictureBox)(sender);
                ViewPopup.frmViewImage frm = new frmViewImage(l.Image, patientCode, patientReceiveID, -1, -1);
                frm.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void GetSurviveSign()
        {
            try
            {
                lstSign = SurviveSignBLL.ListSurviveSignForRefID(patientReceiveID);
                gridControl_Sign.DataSource = lstSign;
            }
            catch { }
        }

        private void GetStatistic()
        {
            try
            {
                chartControl1.Series.Clear();
                
                Series series1 = new Series("Mạch", ViewType.SwiftPlot);
                Series series2 = new Series("Nhiệt độ", ViewType.SwiftPlot);
                Series series3 = new Series("Huyết áp", ViewType.SwiftPlot);
                Series series4 = new Series("Nặng", ViewType.SwiftPlot);
                Series series5 = new Series("Cao", ViewType.SwiftPlot);
                Series series6 = new Series("Nhịp thở", ViewType.SwiftPlot);
                string sDate = string.Empty;
                foreach (var v in lstSign)
                {
                    sDate = v.CreateDate.ToString("dd/MM HH:mm");
                    if (v.Pulse.Trim() != string.Empty)
                        series1.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Pulse) }));
                    else
                        series1.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Temperature.Trim() != string.Empty)
                        series2.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Temperature) }));
                    else
                        series2.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.BloodPressure.Trim() != string.Empty)
                        series3.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.BloodPressure) }));
                    else
                        series3.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Weight.Trim() != string.Empty)
                        series4.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Weight) }));
                    else
                        series4.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Hight.Trim() != string.Empty)
                        series5.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Hight) }));
                    else
                        series5.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Breath.Trim() != string.Empty)
                        series6.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Breath) }));
                    else
                        series6.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                }
                chartControl1.Series.Add(series1);
                chartControl1.Series.Add(series2);
                chartControl1.Series.Add(series3);
                chartControl1.Series.Add(series4);
                chartControl1.Series.Add(series5);
                chartControl1.Series.Add(series6);
                chartControl1.Legend.Visible = true;
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                /*string sPath = @"..\..\xml\rptDauSinhTon.xml";
                XmlSerializer serialiser = new XmlSerializer(typeof(List<SurviveSignInf>));
                TextWriter FileStream = new StreamWriter(sPath);
                serialiser.Serialize(FileStream, lstSign);
                FileStream.Close();
                */
                /*
                DataTable dtClinic = new DataTable("ClinicInfo");
                dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = new DataTable("Result");
                dtResult = BanksAccountDetailBLL.DT_View_Treatment_Info(patientCode, patientReceiveID);
                DataTable dtSign = new DataTable("Sign");
                dtSign = SurviveSignBLL.DT_SurviveSignForRefID(patientReceiveID);
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtClinic);
                dsTemp.Tables.Add(dtResult);
                dsTemp.Tables.Add(dtSign);
                dsTemp.WriteXml(@"..\..\xml\rptDauSinhTon.xml");

                Reports.view_DauSinhTon rpt = new Reports.view_DauSinhTon();
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
                 */
            }
            catch { }
        }

    }
}