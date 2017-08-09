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

namespace Ps.Clinic.Statistics
{
    public partial class frmPopupCancelServiceDetail : DevExpress.XtraEditors.XtraForm
    {
        private string banksAccountCode = string.Empty, patientCode = string.Empty;
        private decimal patientReceiveID = 0;
        private Int32 objectCode = 0;
        private int iTraituyen = 0, iTile = 0;
        private string objectName = string.Empty, sTheBHYT = string.Empty;
        public frmPopupCancelServiceDetail(string _banksAccountCode, string _patientCode, decimal _patientReceiveID, Int32 _objectCode, string _objectName)
        {
            this.banksAccountCode = _banksAccountCode;
            this.patientCode = _patientCode;
            this.patientReceiveID = _patientReceiveID;
            this.objectCode = _objectCode;
            this.objectName = _objectName;
            InitializeComponent();
        }

        private void frmPopupCancelServiceDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.GetNumberReceive();
                this.GetInfoPatient();
                this.GetInfoOutHospital();
                this.ListService();
                this.SumAmountTotal();
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void GetNumberReceive()
        {
            try
            {
                this.lkNgayVaoVien.Properties.DataSource = PatientReceiveBLL.ListPatientView(this.patientCode, this.patientReceiveID);
                this.lkNgayVaoVien.Properties.DisplayMember = "DateIn";
                this.lkNgayVaoVien.Properties.ValueMember = "PatientReceiveID";
                this.lkNgayVaoVien.ItemIndex = 0;
                this.lkNgayVaoVien.Focus();
            }
            catch { }
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
                if (objPatient != null && !string.IsNullOrEmpty(objPatient.PatientCode))
                {
                    this.lbHoten01.Text = objPatient.PatientName;
                    this.lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    lbNamsinh01.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
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
                if (this.objectCode == 1)
                {
                    List<BHYTInf> lstBHYT = new List<BHYTInf>();
                    lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                    if (lstBHYT.Count > 0)
                    {
                        sTheBHYT = lstBHYT[0].Serial;
                        this.lbSothe.Text = lstBHYT[0].Serial;
                        this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                        if (lstBHYT[0].TraiTuyen.Equals(1) && lstBHYT[0].ReferralPaper.Equals(1))
                        {
                            iTraituyen = 0;
                            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = true;
                        }
                        else if (lstBHYT[0].TraiTuyen.Equals(1) && !lstBHYT[0].ReferralPaper.Equals(1))
                        {
                            iTraituyen = 1;
                            this.chkTraiTuyen.Checked = true;
                            this.chkGiayChuyenVien.Checked = false;
                        }
                        else
                        {
                            iTraituyen = 0;
                            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = false;
                        }
                        this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                        this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                        this.GetCardInfo(lstBHYT[0].Serial);
                    }
                }
                else
                {
                    this.iTraituyen = 0;
                    this.lbSothe.Text = this.lbTungay.Text = this.lbNoiDKKCB.Text = this.lbDenngay.Text = string.Empty;
                    this.lbTileBHYT.Text = this.objectName;
                }
            }
            catch { }
        }

        private void GetInfoOutHospital()
        {
            try
            {
                List<PatientReceive_ViewInf> lst = PatientReceiveBLL.ListPatientView(this.patientCode, this.patientReceiveID);
                lbNgayvao.Text = lst[0].DateIn.ToString("dd/MM/yyyy HH:mm:ss");
                if (lst[0].DateOut.ToString() != "01/01/0001 12:00:00 AM")
                    this.lbNgayra.Text = lst[0].DateOut.ToString("dd/MM/yyyy HH:mm:ss");
                else
                    this.lbNgayra.Text = "";
            }
            catch { }
        }
                
        public void ListService()
        {
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult = BanksAccountBLL.GetDataBanksAccountDetailHis(this.banksAccountCode, 1);
                if (dtbResult.Rows.Count > 0)
                {
                    this.gridControl_ListBanksAccount.DataSource = BanksAccountBLL.GetDataBanksAccountDetailHis(this.banksAccountCode, 1);
                    this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
                    this.gridView_ListBanksAccount.ExpandAllGroups();
                }
                else
                {
                    this.gridControl_ListBanksAccount.DataSource = BanksAccountBLL.GetDataBanksAccountDetailHis(Convert.ToString(this.patientReceiveID), 2);
                    this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
                    this.gridView_ListBanksAccount.ExpandAllGroups();
                }
            }
            catch (Exception)
            {
                this.gridControl_ListBanksAccount.DataSource = null;
                return;
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
                    if (this.chkTraiTuyen.Checked)
                    {
                        if (this.chkGiayChuyenVien.Checked)
                        {
                            this.iTile = model.RateTrue;
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                        }
                        else
                        {
                            this.iTile = model.RateFalse;
                            this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                        }
                    }
                    else
                    {
                        this.iTile = model.RateTrue;
                        this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                    }
                }
            }
            catch { }
        }

        public void SumAmountTotal()
        {
            try
            {
                BanksAccountInf inf = BanksAccountBLL.ListBankAccountForCode(this.banksAccountCode);
                if (inf != null && !string.IsNullOrEmpty(inf.BanksAccountCode))
                {
                    this.txtAmount.Text = inf.TotalAmount.ToString("N0");
                    this.txtAmountThuphi.Text = inf.PatientPay.ToString("N0");
                    this.txtAmountBHYT.Text = inf.BHYTPay.ToString("N0");
                    this.txtAmountReal.Text = inf.TotalReal.ToString("N0");
                    this.txtAmountPhuthu.Text = inf.TotalSurcharge.ToString("N0");
                    this.txtDiscount.EditValue = inf.RateExemptions.ToString();
                    this.txtAmountDiscount.EditValue = inf.Exemptions.ToString("N0");
                }
                else
                {
                    this.txtAmount.Text = this.txtAmountThuphi.Text = this.txtAmountBHYT.Text = this.txtAmountReal.Text = this.txtAmountPhuthu.Text = "0";
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}