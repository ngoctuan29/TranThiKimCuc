using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Ps.Clinic.ViewPopup;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Entry
{
    public partial class frmTiepDonBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUserID = string.Empty;
        private string sYear = string.Empty;
        private bool bBHYT = false;
        private int iTraituyen = 0, iPatientType = 0, iCapcuu = 0;
        private decimal patientReceiveId = 0;
        private string sMatheBHYT = string.Empty;
        private decimal dIDSurvive = 0;
        private decimal dIdBHYT = 0;
        private string sReferenceCode = string.Empty;
        private Int32 iStatus = 0, iUpdate = 0;
        private DateTime dtWorking = new DateTime();
        private DateTime dtWorkingOld = new DateTime();
        private string sNgayhen = string.Empty;
        private DataTable dtService = new DataTable();
        private DataTable dtServiceDetail = new DataTable();
        private string sImagePath = string.Empty;
        private ChartTitle chartTitle1 = new ChartTitle();
        private Int32 iNew = 0;
        private bool reloadTreeview = false;
        private bool suggestedClick = false, isCheckCardBHYT = false;
        private string patientReceiveClinic = string.Empty;
        private string shiftWork = string.Empty;
        private string barcode = string.Empty;
        private DateTime dtServer = new DateTime();
        private string username_TC = string.Empty, password_TC = string.Empty;
        private string username_BV = string.Empty, password_BV = string.Empty;

        public frmTiepDonBHYT(string _UserID, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.sUserID = _UserID;
            this.shiftWork = _shiftWork;
            this.dtWorking = this.dtWorkingOld = _dtWorking;
            this.dtServiceDetail.Columns.Add(new DataColumn("ServiceCode", typeof(string)));
            this.dtServiceDetail.Columns.Add(new DataColumn("ServiceName", typeof(string)));
            this.dtServiceDetail.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
            this.dtServiceDetail.Columns.Add(new DataColumn("DepartmentName", typeof(string)));
            this.dtServiceDetail.Columns.Add(new DataColumn("ReceiptID", typeof(decimal)));
            this.dtServiceDetail.Columns.Add(new DataColumn("Status", typeof(Int32)));
            this.dtServiceDetail.Columns.Add(new DataColumn("Paid", typeof(Int32)));
        }

        public void InitField()
        {
            this.txtLoaiTuoi.Properties.Items.AddRange(new string[] { "Tuổi", "Tháng" });
            this.cbGioiTinh.Properties.Items.AddRange(new string[] { "Nữ", "Nam" });
            this.lkPatientType.Properties.DataSource = PatientsBLL.DT_PatientType();
            this.lkPatientType.Properties.DisplayMember = "TypeName";
            this.lkPatientType.Properties.ValueMember = "RowID";
        }
        
        private void fLoad_Luottiepdon(decimal receiveID)
        {
            try
            {
                this.xtabInfo.SelectedTabPageIndex = 0;
                List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(receiveID);
                if (lstReceive.Count > 0)
                {
                    sReferenceCode = lstReceive[0].ReferenceCode;
                    this.patientReceiveClinic = lstReceive[0].PatientReceiveClinic;
                    this.Enable(false);
                    this.butEdit.Enabled = true;
                    this.lkDoituong.EditValue = lstReceive[0].ObjectCode;
                    this.txtLydo.Text = lstReceive[0].Reason;
                    this.iPatientType = lstReceive[0].PatientType;
                    this.lkPatientType.EditValue = iPatientType;
                    this.dtServiceDetail = SuggestedServiceReceiptBLL.DT_ChidinhPK(receiveID, this.txtMabn.Text.Trim());
                    this.gridControl_Detail.DataSource = dtServiceDetail;
                    this.iStatus = lstReceive[0].Status;
                    this.dtWorkingOld = lstReceive[0].CreateDate;
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
                    this.memoNote.EditValue = lstReceive[0].CompanyInfo;
                    this.cbIntroducer.Text = lstReceive[0].IntroName;
                    if (lstReceive[0].IDTypeReceive != 0)
                        this.lkupTypeReceive.EditValue = lstReceive[0].IDTypeReceive;
                    else
                        this.lkupTypeReceive.EditValue = 1;
                    this.lkupTaiNanTT.EditValue = lstReceive[0].TNTTID;
                }
                else
                {
                    this.lkDoituong.EditValue = null;
                    this.lkPatientType.EditValue = null;
                    this.txtLydo.Text = string.Empty;
                    XtraMessageBox.Show("Bệnh nhân không tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                /// get info BHYT
                List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(receiveID);
                if (lstBHYT.Count > 0)
                {
                    this.sMatheBHYT = lstBHYT[0].Serial;
                    this.dIdBHYT = lstBHYT[0].RowID;
                    if (lstBHYT[0].EndDate >= Utils.DateServer())
                    {
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
                        this.chkTraiTuyen.Checked = lstBHYT[0].TraiTuyen == 1 ? true : false;
                        this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                        this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                        this.GetCardInfo();
                        this.LoadDKKCBBD();
                    }
                    else
                        this.ClearBHYTInfo();
                }
                else
                {
                    this.ClearBHYTInfo();
                    this.dIdBHYT = 0;
                    this.lbTileBHYT.Text = this.lkDoituong.Text;
                }
                /// get info SurviveSign
                List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefID(receiveID);
                if (lstSur.Count > 0)
                {
                    dIDSurvive = lstSur[0].RowID;
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
                if (this.iStatus == 0)
                    this.butEdit.Enabled = true;
                else
                    this.butEdit.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void frmTiepDonBHYT_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtServer = Utils.DateServer();
                this.txtHoTen.Focus();
                this.LoadPatientInfo();
                this.Enable(false);
                this.EnableBHYT(false);
                this.lbTileBHYT.Visible = false;

                DataTable dtbProvincial = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.repProvincial.DataSource = dtbProvincial;
                this.repProvincial.DisplayMember = "ProvincialName";
                this.repProvincial.ValueMember = "ProvincialCode";

                this.lkupTinh.Properties.DataSource = dtbProvincial;
                this.lkupTinh.Properties.DisplayMember = "ProvincialName";
                this.lkupTinh.Properties.ValueMember = "ProvincialCode";

                CatalogDistrictBLL district = new CatalogDistrictBLL();
                DataTable dtbDistrict = district.DTListDistrict(string.Empty, string.Empty);
                this.repDistrict.DataSource = dtbDistrict;
                this.repDistrict.DisplayMember = "DistrictName";
                this.repDistrict.ValueMember = "DistrictCode";

                CatalogWardBLL ward = new CatalogWardBLL();
                DataTable dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                if (dtbWard.Rows.Count <= 0 || dtbWard == null)
                    dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                this.lkupTQPXa.Properties.DataSource = dtbWard;
                this.lkupTQPXa.Properties.DisplayMember = "WardName";
                this.lkupTQPXa.Properties.ValueMember = "WardCode";

                this.lkupTypeReceive.Properties.DataSource = PatientReceiveBLL.TableTypeReceive();
                this.lkupTypeReceive.Properties.ValueMember = "RowID";
                this.lkupTypeReceive.Properties.DisplayMember = "ReceiveName";

                this.lkupTaiNanTT.Properties.DataSource = TNTTBLL.TableTaiNanTT();
                this.lkupTaiNanTT.Properties.DisplayMember = "Ten";
                this.lkupTaiNanTT.Properties.ValueMember = "Ma";

                this.GetStatistic();
                this.chartTitle1.Text = "Số lượng bệnh theo ngày";
                this.chartTitle1.Font = new Font("Tahoma", 10, FontStyle.Regular);
                this.chartControl1.Titles.Add(chartTitle1);

                DataTable tableIntro = IntroducerBLL.DTIntroducer(string.Empty);
                foreach (DataRow row in tableIntro.Rows)
                    this.cbIntroducer.Properties.Items.Add(row["IntroName"].ToString());
                this.InitField();
                //this.tabControlTke.Visible = true;
                //if (EmployeeBLL.CheckUserAdmin(this.sUserID))
                //{
                //    this.tabControlTke.Visible = true;
                //}
                SystemParameterInf sys = SystemParameterBLL.ObjParameter(13);
                if (sys != null & sys.RowID > 0 & sys.Values == 1)
                    this.isCheckCardBHYT = true;
                this.GetUserPass_GD_BHYT();
                this.startDate.EditValue = this.endDate.EditValue = this.dtWorking;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadPatientInfo()
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

                CatalogNationalityBLL national = new CatalogNationalityBLL();
                this.lkupQuocTich.Properties.DataSource = national.DTListNationality(0);
                this.lkupQuocTich.Properties.DisplayMember = "NationalityName";
                this.lkupQuocTich.Properties.ValueMember = "NationalityID";

                this.lkDoituong.Properties.DataSource = ObjectBLL.DTObjectListNotIn(5);
                this.lkDoituong.Properties.DisplayMember = "ObjectName";
                this.lkDoituong.Properties.ValueMember = "ObjectCode";

            }
            catch { return; }
        }
                
        public bool bNgay(string ngay)
        {
            try
            {
                if (ngay.IndexOf("_") != -1 || (ngay.IndexOf(" ") != -1 && ngay.Trim().Length == 10)) return false;
                int len = ngay.Length;
                if (len == 0) return false;
                string dd = ngay.Substring(0, 2), mm = ngay.Substring(3, 2), yyyy = ngay.Substring(6, 4);
                string s31 = "01+03+05+07+08+10+12+", s30 = "04+06+09+11+", s2829 = (int.Parse(yyyy) % 4 == 0) ? "29" : "28";
                if (int.Parse(yyyy.Substring(0, 1)) < 1) return false;
                if (int.Parse(mm) < 1 || int.Parse(mm) > 12) return false;
                if (s31.IndexOf(mm + "+") > -1)
                {
                    if (int.Parse(dd) < 1 || int.Parse(dd) > 31) return false;
                }
                else if (s30.IndexOf(mm + "+") > -1)
                {
                    if (int.Parse(dd) < 1 || int.Parse(dd) > 30) return false;
                }
                else if (int.Parse(dd) < 1 || int.Parse(dd) > int.Parse(s2829)) return false;
                if (len > 10)
                {
                    string hh = ngay.Substring(11, 2), MM = ngay.Substring(14, 2);
                    if (int.Parse(hh) > 23) return false;
                    if (int.Parse(MM) > 59) return false;
                }
                return true;
            }
            catch { return false; };
        }

        public bool bNgay(string ngayvao, string ngaysinh)
        {
            try
            {
                int d1 = DateTime.Now.Day;
                int m1 = DateTime.Now.Month;
                int y1 = DateTime.Now.Year;
                if (!string.IsNullOrEmpty(ngayvao))
                {
                    y1 = int.Parse(ngayvao.Substring(6, 4));
                    m1 = int.Parse(ngayvao.Substring(3, 2));
                    d1 = int.Parse(ngayvao.Substring(0, 2));
                }
                int d2 = int.Parse(ngaysinh.Substring(0, 2));
                int m2 = int.Parse(ngaysinh.Substring(3, 2));
                int y2 = int.Parse(ngaysinh.Substring(6, 4));
                if (y2 > y1) return false;
                else if (y2 < y1) return true;
                if (m2 > m1) return false;
                else if (m2 < m1) return true;
                if (d2 > d1) return false;
                return true;
            }
            catch { return true; }
        }
                
        public int Namsinh(string ngaysinh)
        {
            return int.Parse(ngaysinh.Substring(6, 4));
        }

        public int Namsinh(string ngayvao, int ituoi, int iloai)
        {
            int namht = this.dtWorking.Year;
            int iNamsinh = 0;
            if (iloai == 1 && ituoi <= 12)
            {
                if (bNgay(this.dtWorking.Day.ToString().PadLeft(2, '0') + "/" + ituoi.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0'), this.dtWorking.Day.ToString().PadLeft(2, '0') + "/" + this.dtWorking.Month.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0')))
                    iNamsinh = namht - 1;
                else iNamsinh = namht;
            }
            else if (iloai == 1 && ituoi <= 72)
            {
                int tmp_tuoi = ituoi / 12;
                int tmp_thang = ituoi - (tmp_tuoi * 12);
                if (bNgay(this.dtWorking.Day.ToString().PadLeft(2, '0') + "/" + tmp_thang.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0'), this.dtWorking.Day.ToString().PadLeft(2, '0') + "/" + this.dtWorking.Month.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0')))
                    iNamsinh = namht - tmp_tuoi - 1;
                else
                    iNamsinh = namht - tmp_tuoi;
                if (this.txtNgaySinh.Text.Length < 10)
                    this.txtNgaySinh.Text = "01" + "/" + this.dtWorking.Date.AddMonths(-tmp_thang).Month.ToString().PadLeft(2, '0') + "/" + iNamsinh.ToString();
                else
                    this.txtNgaySinh.Text = this.txtNgaySinh.Text.Substring(0, 2) + "/" + this.dtWorking.Date.AddMonths(-tmp_thang).Month.ToString().PadLeft(2, '0') + "/" + iNamsinh.ToString();
            }
            else
            {
                switch (iloai)
                {
                    case 0:
                        iNamsinh = namht - ituoi;
                        this.txtNgaySinh.Text = string.IsNullOrEmpty(this.txtNgaySinh.Text) ? "01" + "/" + "01" + "/" + iNamsinh.ToString() : this.txtNgaySinh.Text.Substring(0, 5) + "/" + iNamsinh.ToString();
                        break;
                    case 1:
                        iNamsinh = namht - ituoi / 12;
                        this.txtNgaySinh.Text = "01" + "/" + (ituoi % 12).ToString().PadLeft(2, '0') + "/" + iNamsinh.ToString();
                        break;
                    case 2: iNamsinh = namht - ituoi / 365;
                        break;
                    default: iNamsinh = namht;
                        break;
                }
            }
            return iNamsinh;
        }
        
        private void txtSearchCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butSearch.Focus();
            else if (e.KeyCode == Keys.Tab)
                this.txtSearchName.Focus();
        }

        private void txtSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butSearch_Click(sender, e);
            else if (e.KeyCode == Keys.Tab)
                this.txtSearchAge.Focus();
        }

        private void txtSearchAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butSearch_Click(sender, e);
            else if (e.KeyCode == Keys.Tab)
                this.txtSearchMobile.Focus();
        }

        private void txtSearchMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                this.butSearch_Click(sender, e);   
        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtNgaySinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupNgheNghiep.Focus();
                this.lkupNgheNghiep.Show();
            }
        }

        private void txtNgaySinh_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( this.txtNgaySinh.Text) || this.txtNgaySinh.Text == "__/__/____") return;
            this.txtNgaySinh.Text = this.txtNgaySinh.Text.Trim();
            if (!Utils.isDate(this.txtNgaySinh.Text))
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNgaySinh.Focus();
                return;
            }
            if (Utils.StringToDate(this.txtNgaySinh.Text).Year > this.dtWorking.Year)
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNgaySinh.Focus();
                return;
            }
            try
            {
                this.TuoiBenhNhan(string.Empty, this.txtNgaySinh.Text);
                if (int.Parse(this.txtTuoi.Text) > 130)
                {
                    XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaySinh.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtTuoi.Text.Trim()) || Convert.ToInt32(this.txtTuoi.Text.Trim()).Equals(0))
                {
                    XtraMessageBox.Show("Vui lòng nhập năm sinh của bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNamSinh.Focus();
                    return;
                }
                this.lkupNgheNghiep.Focus();
                this.lkupNgheNghiep.Show();
            }
            catch { }
        }

        private void txtNamSinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtNamSinh_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtNamSinh.Text))
            {
                if (int.Parse(this.txtNamSinh.Text) > this.dtWorking.Year)
                {
                    XtraMessageBox.Show("Năm sinh không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNamSinh.Focus();
                    return;
                }
                if (this.txtNamSinh.Text.Length < 4)
                    this.txtNamSinh.Text = Convert.ToString(this.dtWorking.Year - int.Parse(this.txtNamSinh.Text));
                this.txtTuoi.Text = Convert.ToString(this.dtWorking.Year - int.Parse(this.txtNamSinh.Text)).PadLeft(2, '0');
                this.txtNgaySinh.Text = string.IsNullOrEmpty(this.txtNgaySinh.Text) ? "01" + "/" + "01" + "/" + this.txtNamSinh.Text : this.txtNgaySinh.Text.Substring(0, 5) + "/" + this.txtNamSinh.Text;
                this.TuoiBenhNhan(string.Empty, this.txtNgaySinh.Text);
                if (int.Parse(this.txtTuoi.Text) > 150)
                {
                    XtraMessageBox.Show("Năm sinh không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNamSinh.Focus();
                    return;
                }
                if (this.txtTuoi.Text.Equals("00") || this.txtTuoi.Text.Equals("000") || Convert.ToInt32(this.txtTuoi.Text.Trim()).Equals(0))
                {
                    XtraMessageBox.Show("Kiểm tra lại ngày sinh bệnh nhân.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaySinh.Focus();
                    return;
                }
                this.lkupNgheNghiep.Focus();
                this.lkupNgheNghiep.Show();
            }
        }
        private void TuoiBenhNhan(string ngayvao, string ngaysinh)
        {
            int namht = this.dtWorking.Year;
            int thanght = this.dtWorking.Month;
            int ngayht = this.dtWorking.Day;
            int gioht = this.dtWorking.Hour;

            int nam = int.Parse(ngaysinh.Substring(6, 4));
            int thang = int.Parse(ngaysinh.Substring(3, 2));
            int ngay = int.Parse(ngaysinh.Substring(0, 2));
            int gio = (ngaysinh.Length > 10) ? int.Parse(ngaysinh.Substring(11, 2)) : 0;
            if (!string.IsNullOrEmpty(ngayvao))
            {
                namht = int.Parse(ngayvao.Substring(6, 4));
                thanght = int.Parse(ngayvao.Substring(3, 2));
                ngayht = int.Parse(ngayvao.Substring(0, 2));
                gioht = int.Parse(ngayvao.Substring(11, 2));
            }
            int yyyy = namht - nam;
            DateTime dtNgaySinh = Convert.ToDateTime(this.txtNgaySinh.Text.Trim());
            int sothang = this.dtWorking.Month - dtNgaySinh.Month + 12 * (this.dtWorking.Year - dtNgaySinh.Year);
            if (sothang <= 72)
            {
                int yy = sothang / 12;
                int mm = sothang % 12;
                this.lbNamSinh.Text = yy + " tuổi " + mm + " tháng.";
                this.txtTuoi.Text = sothang.ToString().PadLeft(2, '0');
                this.txtLoaiTuoi.SelectedIndex = 1;
            }
            else
            {
                //int mm = sothang % 12;
                //if (mm > 0)
                //    yyyy++;
                this.txtLoaiTuoi.SelectedIndex = 0;
                this.lbNamSinh.Text = yyyy + " tuổi ";
                this.txtTuoi.Text = yyyy.ToString().PadLeft(2, '0');
            }
            this.txtNamSinh.Text = this.Namsinh(this.txtNgaySinh.Text).ToString();
        }
        private void tuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.txtTuoi.Text != string.Empty)
                {
                    this.lkupNgheNghiep.Focus();
                    this.lkupNgheNghiep.Show();
                }
                else
                {
                    XtraMessageBox.Show("Yêu cầu nhập tuổi vào !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTuoi.Focus();
                    return;
                }
            }
        }

        private void tuoi_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtTuoi.Text))
                {
                    this.txtNamSinh.Text = this.Namsinh(string.Empty, int.Parse(this.txtTuoi.Text), this.txtLoaiTuoi.SelectedIndex).ToString();
                }
                this.txtLoaiTuoi.Focus();
            }
            catch { this.txtNgaySinh.Focus(); }
        }
        
        private void dienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}"); 
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}"); 
        }

        private void tiensu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.txtDiUng.Focus();
        }
        
        private void txtLydo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}");
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}{F4}");
        }

        private void ten_Validated(object sender, EventArgs e)
        {
            this.txtHoTen.Text = this.txtHoTen.Text.Trim().Trim('-').Trim('+');
            this.txtHoTen.Text = Utils.ToUpperCharacterFisrt(this.txtHoTen.Text);
        }
        
        private void butSearch_Click(object sender, EventArgs e)
        {
            this.gridControl_Patient_List.DataSource = PatientReceiveBLL.DTListPatientsSearch(this.txtSearchCode.Text.Trim(), this.txtSearchName.Text.Trim(), this.txtSearchAge.Text.Trim(), this.txtSearchMobile.Text.Trim(), string.Empty, string.Empty);
        }
        
        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                iNew = 0;
                this.Enable(false);
                this.EnableBHYT(false);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi xảy ra: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            string sTemp = string.Empty;
            //if(this.iNew.Equals(1))
            //    this.txtMabn.Text = PatientsBLL.GetPatientCode();
            this.suggestedClick = true;
            if (PatientReceiveBLL.CheckPresentPatient(this.txtMabn.Text.Trim(), iNew, this.patientReceiveId, ref sTemp) == 1)
            {
                if (this.SaveInfoReceive(ref sTemp))
                {
                    if (!string.IsNullOrEmpty(this.barcode))
                        PatientReceiveBLL.UpdPatientReceiveBarcode(this.patientReceiveId, this.txtMabn.Text.Trim(), this.barcode);
                    this.dtServiceDetail = SuggestedServiceReceiptBLL.DT_ChidinhPK(this.patientReceiveId, txtMabn.Text.Trim());
                    this.gridControl_Detail.DataSource = this.dtServiceDetail;
                    XtraMessageBox.Show(" Cập nhật thông tin bệnh nhân thành công! ", "Bệnh viện điện tử .NET - OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Enable(false);
                    this.EnableBHYT(false);
                    this.btnCaptureDocument.Enabled = true;
                    //this.butNew_Click(sender, e);
                }
                else
                    XtraMessageBox.Show(sTemp, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show(sTemp + "\n\t Chọn Yes để kết thúc đợt khám cũ.", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    PatientReceiveBLL.UpdPatientForStatus(this.txtMabn.Text.Trim(), 2);
                    this.butSave.Focus();
                }
                else
                {
                    this.txtMabn.Focus();
                    return;
                }
            }
        }

        private bool SaveInfoReceive(ref string message)
        {
            try
            {
                string skhoaphong = string.Empty;
                foreach (DataRow dr in dtServiceDetail.Rows)
                {
                    skhoaphong += dr["DepartmentCode"].ToString() + ",";
                }

                if (this.txtMabn.Text.Trim().Length != 8)
                {
                    //XtraMessageBox.Show(" Mã bệnh nhân không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Mã bệnh nhân không hợp lệ !";
                    this.txtMabn.Focus();
                    return false;
                }
                else if (this.txtHoTen.Text.Trim() == string.Empty)
                {
                    //XtraMessageBox.Show("Nhập họ tên bệnh nhân !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Nhập họ tên bệnh nhân !";
                    this.txtHoTen.Focus();
                    return false;
                }
                else if (this.cbGioiTinh.SelectedIndex == -1)
                {
                    //XtraMessageBox.Show("Chọn giới tính!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Chọn giới tính!";
                    this.cbGioiTinh.Focus();
                    return false;
                }
                else if (txtNamSinh.Text.Trim() == string.Empty)
                {
                    //XtraMessageBox.Show("Nhập năm sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Nhập năm sinh!";
                    this.txtNamSinh.Focus();
                    return false;
                }
                else if (this.lkupNgheNghiep.EditValue == null)
                {
                    //XtraMessageBox.Show("Chọn nghề nghiệp!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Chọn nghề nghiệp!";
                    this.lkupNgheNghiep.Focus();
                    return false;
                }
                else if (this.lkupDanToc.EditValue == null)
                {
                    //XtraMessageBox.Show("Chọn dân tộc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Chọn dân tộc!";
                    this.lkupDanToc.Focus();
                    return false;
                }
                else if (this.lkupQuocTich.EditValue == null)
                {
                    //XtraMessageBox.Show("Chọn quốc tịch!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Chọn quốc tịch!";
                    this.lkupQuocTich.Focus();
                    return false;
                }
                else if (this.lkupTinh.EditValue == null)
                {
                    message = "Chọn tỉnh/thành phô!";
                    this.lkupTinh.Focus();
                    return false;
                }
                else if (this.lkupHuyen.EditValue == null)
                {
                    message = "Chọn quận/huyện!";
                    this.lkupHuyen.Focus();
                    return false;
                }
                else if (this.lkupPhuongXa.EditValue == null)
                {
                    message = "Chọn phường/xã!";
                    this.lkupPhuongXa.Focus();
                    return false;
                }
                //else if (this.txtDienThoai.Text.Trim() == string.Empty)
                //{
                //    message = "Nhập số điện thoại!";
                //    this.txtDienThoai.Focus();
                //    return false;
                //}
                else if (lkPatientType.EditValue.ToString() == "0")
                {
                    //XtraMessageBox.Show(" chọn loại bệnh nhân khi tiếp nhận!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Chọn loại bệnh nhân khi tiếp nhận!";
                    this.lkPatientType.Focus();
                    return false;
                }
                if (bBHYT)
                {
                    if (this.txtThe01.Text.Trim() == string.Empty)
                    {
                        //XtraMessageBox.Show("Nhập mã số thẻ BHYT!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        message = "Nhập đầy đủ mã số thẻ BHYT!";
                        this.txtThe01.Focus();
                        return false;
                    }
                    if (this.txtThe02.Text.Trim() == string.Empty)
                    {
                        message = "Nhập đầy đủ mã số thẻ BHYT!";
                        this.txtThe02.Focus();
                        return false;
                    }
                    if (this.txtThe03.Text.Trim() == string.Empty)
                    {
                        message = "Nhập đầy đủ mã số thẻ BHYT!";
                        this.txtThe03.Focus();
                        return false;
                    }
                    if (this.txtThe04.Text.Trim() == string.Empty)
                    {
                        message = "Nhập đầy đủ mã số thẻ BHYT!";
                        this.txtThe04.Focus();
                        return false;
                    }
                    if (this.txtThe05.Text.Trim() == string.Empty)
                    {
                        message = "Nhập đầy đủ mã số thẻ BHYT!";
                        this.txtThe05.Focus();
                        return false;
                    }
                    if (this.txtThe06.Text.Trim() == string.Empty)
                    {
                        message = "Nhập đầy đủ mã số thẻ BHYT!";
                        this.txtThe06.Focus();
                        return false;
                    }
                    if (this.lkKCB.EditValue.ToString() == string.Empty)
                    {
                        //XtraMessageBox.Show("Chưa chọn nơi đăng lý KCB ban đầu!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        message = "Chưa chọn nơi đăng lý KCB ban đầu!";
                        this.lkKCB.Focus();
                        return false;
                    }
                    if (txtTheStart.Text.ToString() == string.Empty)
                    {
                        //XtraMessageBox.Show("Chưa nhập ngày bắt đầu hưởng BHYT!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        message = "Chưa nhập ngày bắt đầu hưởng BHYT!";
                        this.txtTheStart.Focus();
                        return false;
                    }
                    if (txtTheEnd.Text.ToString() == string.Empty)
                    {
                        //XtraMessageBox.Show("Chưa nhập ngày hết hạn thẻ BHYT!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        message = "Chưa nhập ngày hết hạn thẻ BHYT!";
                        this.txtTheEnd.Focus();
                        return false;
                    }
                    if (Convert.ToDateTime(this.txtTheStart.EditValue).Date > this.dtWorking.Date)
                    {
                        message = "Thẻ chưa đến ngày hưởng BHYT!";
                        this.txtTheStart.Focus();
                        return false;
                    }
                    if (Convert.ToDateTime(this.txtTheEnd.EditValue).Date < this.dtWorking.Date)
                    {
                        message = "Thẻ đã hết hạn sử dụng!";
                        this.txtTheEnd.Focus();
                        return false;
                    }
                }

                if (this.lkDoituong.EditValue == null)
                {
                    //XtraMessageBox.Show(" Xin vui lòng chọn đối tượng bệnh nhân khi tiếp đón! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Xin vui lòng chọn đối tượng bệnh nhân khi tiếp đón!";
                    this.lkDoituong.Focus();
                    return false;
                }
                if (this.suggestedClick && this.dtServiceDetail.Rows.Count <= 0)
                {
                    message = "Chưa chọn phòng khám!";
                    this.lkupCongKham.Focus();
                    return false;
                }
                else
                {
                    //luu thong tin hanh chinh benh nhan
                    string careerCode = "-1";
                    string provincialCode = "-1";
                    string districtCode = "-1";
                    string wardCode = "-1";
                    int ethnicID = -1;
                    int nationalityID = -1;
                    if (this.lkupNgheNghiep.EditValue != null || this.lkupNgheNghiep.EditValue.ToString() != string.Empty)
                        careerCode = this.lkupNgheNghiep.EditValue.ToString();
                    if (this.lkupTinh.EditValue != null || this.lkupTinh.EditValue.ToString() != string.Empty)
                        provincialCode = this.lkupTinh.EditValue.ToString();
                    if (this.lkupHuyen.EditValue != null || this.lkupHuyen.EditValue.ToString() != string.Empty)
                        districtCode = this.lkupHuyen.EditValue.ToString();
                    if (this.lkupPhuongXa.EditValue != null || this.lkupPhuongXa.EditValue.ToString() != string.Empty)
                        wardCode = this.lkupPhuongXa.EditValue.ToString();
                    if (this.lkupDanToc.EditValue != null || this.lkupDanToc.EditValue.ToString() != string.Empty)
                        ethnicID = Convert.ToInt32(this.lkupDanToc.EditValue.ToString());
                    if (this.lkupQuocTich.EditValue != null || this.lkupQuocTich.EditValue.ToString() != string.Empty)
                        nationalityID = Convert.ToInt32(this.lkupQuocTich.EditValue.ToString());
                    FileStream fstr;
                    byte[] imagedata;
                    PatientsInf infPatient = new PatientsInf();
                    infPatient.PatientCode = txtMabn.Text.Trim();
                    infPatient.PatientName = txtHoTen.Text.Trim();
                    infPatient.PatientGender = cbGioiTinh.EditValue.ToString() == "Nam" ? 1 : 0;
                    if (this.txtNgaySinh.Text.Trim() != string.Empty)
                        infPatient.PatientBirthday = Utils.StringToDate(this.txtNgaySinh.Text.Trim());
                    else
                        infPatient.PatientBirthday = Utils.StringToDate("01/01/" + this.txtNamSinh.Text);
                    infPatient.PatientBirthyear = int.Parse(this.txtNamSinh.Text.Trim());
                    infPatient.PatientAge = (this.dtWorking.Year - int.Parse(this.txtNamSinh.Text.Trim()));// int.Parse(txtTuoi.Text.Trim());
                    infPatient.PatientAddress = txtDiaChi.Text.Trim();
                    infPatient.PatientMobile = txtDienThoai.Text.Trim();
                    infPatient.PatientEmail = txtEmail.Text.Trim();
                    infPatient.MedicalHistory = txtTienSu.Text.Trim();
                    infPatient.Allergy = txtDiUng.Text.Trim();
                    infPatient.CareerCode = careerCode;
                    infPatient.EThnicID = ethnicID; 
                    infPatient.NationalityID = nationalityID;
                    infPatient.ProvincialCode = provincialCode;
                    infPatient.DistrictCode = districtCode;
                    infPatient.WardCode = wardCode;
                    if (sImagePath != string.Empty)
                    {
                        fstr = new FileStream(sImagePath, FileMode.Open, FileAccess.Read);
                        imagedata = new byte[fstr.Length];
                        fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        infPatient.PatientImage = imagedata;
                    }

                    infPatient.PatientMonth = this.txtLoaiTuoi.SelectedIndex == 0 ? string.Empty : this.txtTuoi.Text.Trim();
                    infPatient.IDTypeReceive = string.IsNullOrEmpty(this.lkupTypeReceive.EditValue.ToString())?0:Convert.ToInt32(this.lkupTypeReceive.EditValue);
                    infPatient.TenCha = txtHoTenCha.Text.Trim();
                    if (txtNamSinhCha.Text.Trim() != "")
                        infPatient.NSCha = Convert.ToInt32(txtNamSinhCha.Text.Trim());
                    else
                        infPatient.NSCha = 0;
                    infPatient.TenMe = txtHoTenMe.Text.Trim();
                    if (txtNamSinhMe.Text.Trim() != "")
                        infPatient.NSMe = Convert.ToInt32(txtNamSinhMe.Text.Trim());
                    else
                        infPatient.NSMe = 0;
                    if (PatientsBLL.InsPatients(infPatient) == 1)
                    {
                        //Luu thong tin kham
                        if (sNgayhen != string.Empty)
                            PatientAppointment_BLL.UpdStatus(txtMabn.Text.Trim(), sNgayhen);
                        PatientReceiveInf infReceive = new PatientReceiveInf();
                        infReceive.PatientReceiveID = patientReceiveId;
                        infReceive.PatientCode = this.txtMabn.Text.Trim();
                        infReceive.Reason = this.txtLydo.Text.Trim();
                        infReceive.EmployeeCode = this.sUserID;
                        infReceive.Status = 0;
                        infReceive.DepartmentCode = skhoaphong.TrimEnd(',');
                        infReceive.ObjectCode = int.Parse(this.lkDoituong.EditValue.ToString());
                        iPatientType = Convert.ToInt32(this.lkPatientType.EditValue);
                        infReceive.PatientType = iPatientType;
                        infReceive.ReferenceCode = sReferenceCode;
                        infReceive.CareerCode = careerCode;
                        infReceive.EThnicID = ethnicID;
                        infReceive.NationalityID = nationalityID;
                        infReceive.ProvincialCode = provincialCode;
                        infReceive.DistrictCode = districtCode;
                        infReceive.WardCode = wardCode;
                        infReceive.CompanyInfo = string.Empty;
                        infReceive.Address = this.txtDiaChi.Text.Trim();
                        infReceive.IntroName = this.cbIntroducer.Text.ToUpper();
                        infReceive.IDTypeReceive = string.IsNullOrEmpty(this.lkupTypeReceive.EditValue.ToString()) ? 0 : Convert.ToInt32(this.lkupTypeReceive.EditValue);
                        infReceive.PatientReceiveClinic = this.patientReceiveClinic;
                        infReceive.ShiftWork = this.shiftWork;
                        infReceive.CreateDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                        infReceive.TNTTID = (this.lkupTaiNanTT.EditValue == null || this.lkupTaiNanTT.EditValue.ToString() == string.Empty) ? 0 : Convert.ToInt32(this.lkupTaiNanTT.EditValue);
                        if (PatientReceiveBLL.InsPatientReceive(infReceive, ref sReferenceCode) == -2)
                        { return false; }
                        //Luu thong tin bao hiem yte
                        this.patientReceiveId = PatientReceiveBLL.GetPatientReceive(this.txtMabn.Text.Trim(), sReferenceCode, this.dtWorking);
                        if (this.patientReceiveId <= 0) return false;
                        if (bBHYT)
                        {
                            sMatheBHYT = this.txtThe01.Text.Trim() + this.txtThe02.Text.Trim() + this.txtThe03.Text.Trim() + this.txtThe04.Text.Trim() + this.txtThe05.Text.Trim() + this.txtThe06.Text.Trim();
                            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(6);
                            iTraituyen = this.chkTraiTuyen.Checked ? 1 : 0;
                            iCapcuu = this.chkCapCuu.Checked ? 1 : 0;
                            if (objSys.Values.Equals(1) && this.lkPatientType.EditValue.Equals(2))
                                iTraituyen = 0;
                            BHYTInf infBHYT = new BHYTInf();
                            infBHYT.RowID = dIdBHYT;
                            infBHYT.Serial01 = this.txtThe01.Text.Trim();
                            infBHYT.Serial02 = this.txtThe02.Text.Trim();
                            infBHYT.Serial03 = this.txtThe03.Text.Trim();
                            infBHYT.Serial04 = this.txtThe04.Text.Trim();
                            infBHYT.Serial05 = this.txtThe05.Text.Trim();
                            infBHYT.Serial06 = this.txtThe06.Text.Trim();
                            infBHYT.PatientCode = this.txtMabn.Text.Trim();
                            infBHYT.KCBBDCode = this.lkKCB.EditValue.ToString();
                            infBHYT.StartDate = Utils.StringToDate(this.txtTheStart.Text.Trim());
                            infBHYT.EndDate = Utils.StringToDate(this.txtTheEnd.Text.Trim());
                            infBHYT.Hide = 0;
                            infBHYT.EmployeeCode = this.sUserID;
                            infBHYT.PatientReceiveID = this.patientReceiveId;
                            infBHYT.TraiTuyen = iTraituyen;
                            infBHYT.Capcuu = iCapcuu;
                            infBHYT.Serial = this.sMatheBHYT;
                            infBHYT.ReferralPaper = this.chkGiayChuyenVien.Checked ? 1 : 0;
                            string str = this.txtKCBBD.Text.Trim().Replace(" ", "");
                            string[] strArrayCode = str.Split(new char[] { '-' });
                            if (strArrayCode.Length > 1)
                                infBHYT.KCBBDCodeFull = str;
                            else
                                infBHYT.KCBBDCodeFull = str.Substring(0, 2) + "-" + this.lkKCB.EditValue.ToString();
                            BHYTBLL.InsBHYT(infBHYT);
                        }
                        //Luu mach nhiet do huyet ap
                        List<SurviveSignInf> lst = SurviveSignBLL.ListSurviveSignForRefCode(sReferenceCode, patientReceiveId, txtMabn.Text.Trim());
                        if (this.txtMach.Text.Trim() != string.Empty || this.txtNhietdo.Text.Trim() != string.Empty || this.txtHuyetap.Text.Trim() != string.Empty || this.txtHuyetap1.Text.Trim() != string.Empty || this.txtCao.Text.Trim() != string.Empty || this.txtNang.Text.Trim() != string.Empty)
                        {
                            if (lst != null && lst.Count > 0)
                            {
                                SurviveSignInf infsur = new SurviveSignInf();
                                infsur.RowID = lst[0].RowID;
                                infsur.PatientCode = this.txtMabn.Text.Trim();
                                infsur.Pulse = this.txtMach.Text.Trim();
                                infsur.Temperature = this.txtNhietdo.Text.Trim();
                                infsur.BloodPressure = this.txtHuyetap.Text.Trim();
                                infsur.BloodPressure1 = this.txtHuyetap1.Text.Trim();
                                infsur.Weight = this.txtNang.Text.Trim();
                                infsur.Hight = this.txtCao.Text.Trim();
                                infsur.EmployeeCode = this.sUserID;
                                infsur.RefID = this.patientReceiveId;
                                infsur.ReferenceCode = this.sReferenceCode;
                                SurviveSignBLL.InsSurviveSign(infsur);
                            }
                            else
                            {
                                SurviveSignInf infsur = new SurviveSignInf();
                                infsur.RowID = 0;
                                infsur.PatientCode = this.txtMabn.Text.Trim();
                                infsur.Pulse = this.txtMach.Text.Trim();
                                infsur.Temperature = this.txtNhietdo.Text.Trim();
                                infsur.BloodPressure = this.txtHuyetap.Text.Trim();
                                infsur.BloodPressure1 = this.txtHuyetap1.Text.Trim();
                                infsur.Weight = this.txtNang.Text.Trim();
                                infsur.Hight = this.txtCao.Text.Trim();
                                infsur.EmployeeCode = this.sUserID;
                                infsur.RefID = this.patientReceiveId;
                                infsur.ReferenceCode = this.sReferenceCode;
                                infsur.CreateDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                                SurviveSignBLL.InsSurviveSign(infsur);
                            }
                        }
                        //Luu thong tin vao table chidinh
                        if (this.dtServiceDetail.Rows.Count > 0)
                        {
                            foreach (DataRow dr in this.dtServiceDetail.Rows)
                            {
                                SuggestedServiceReceiptInf infSugges = new SuggestedServiceReceiptInf();
                                infSugges.ReceiptID = Convert.ToDecimal(dr["ReceiptID"].ToString());
                                infSugges.DepartmentCode = dr["DepartmentCode"].ToString();
                                infSugges.ServiceCode = dr["ServiceCode"].ToString();
                                infSugges.ServicePrice = 0;
                                infSugges.DisparityPrice = 0;
                                infSugges.PatientCode = this.txtMabn.Text.Trim();
                                infSugges.Status = Convert.ToInt32(dr["Status"].ToString());
                                infSugges.Paid = Convert.ToInt32(dr["Paid"].ToString());
                                infSugges.ServicePackageCode = string.Empty;
                                infSugges.EmployeeCode = this.sUserID;
                                infSugges.Note = "TIEPDON";
                                infSugges.RefID = this.patientReceiveId;
                                infSugges.ObjectCode = int.Parse(lkDoituong.EditValue.ToString());
                                infSugges.PatientType = this.iPatientType;
                                infSugges.WorkDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                                infSugges.ReferenceCode = this.sReferenceCode;
                                infSugges.DepartmentCodeOder = "KP0000";
                                infSugges.ShiftWork = this.shiftWork;
                                infSugges.EmployeeCodeDoctor = this.sUserID;
                                infSugges.Quantity = 1;
                                infSugges.Check_ = 0;
                                SuggestedServiceReceiptBLL.Ins(infSugges);
                            }
                        }
                        else
                        {
                            SuggestedServiceReceiptInf infSugges = new SuggestedServiceReceiptInf();
                            infSugges.ReceiptID = 0;
                            infSugges.DepartmentCode = "KP0000";
                            infSugges.ServiceCode = "DV000000";
                            infSugges.ServicePrice = 0;
                            infSugges.DisparityPrice = 0;
                            infSugges.PatientCode = this.txtMabn.Text.Trim();
                            infSugges.Status = 1;
                            infSugges.Paid = 1;
                            infSugges.ServicePackageCode = string.Empty;
                            infSugges.EmployeeCode = sUserID;
                            infSugges.Note = "TIEPDON";
                            infSugges.RefID = this.patientReceiveId;
                            infSugges.ObjectCode = int.Parse(lkDoituong.EditValue.ToString());
                            infSugges.PatientType = this.iPatientType;
                            infSugges.WorkDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                            infSugges.ReferenceCode = this.sReferenceCode;
                            infSugges.DepartmentCodeOder = "KP0000";
                            infSugges.ShiftWork = this.shiftWork;
                            infSugges.EmployeeCodeDoctor = this.sUserID;
                            infSugges.Quantity = 1;
                            SuggestedServiceReceiptBLL.InsReceive(infSugges);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch
            {
                message = " Save fail";
                return false;
            }
        }

        private void ClearData()
        {
            this.reloadTreeview = false;
            this.patientReceiveId = 0;
            this.patientReceiveClinic = string.Empty;
            this.txtBarcodeBHYT.Text = this.txtHoTen.Text = this.txtNgaySinh.Text = this.txtNamSinh.Text = this.txtTuoi.Text = this.txtDiaChi.Text = this.txtDienThoai.Text = this.txtEmail.Text = this.txtTienSu.Text = this.txtDiUng.Text = string.Empty;
            this.cbGioiTinh.SelectedIndex = -1;
            this.lkKCB.EditValue = string.Empty;
            this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = this.txtKCBBD.Text = string.Empty;
            this.txtTheStart.EditValue = this.txtTheEnd.EditValue = string.Empty;
            this.sImagePath = this.txtLydo.Text = this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNang.Text = this.txtCao.Text = string.Empty;
            this.dtService.Clear();
            this.dtServiceDetail.Clear();
            this.txtMaTQPXa.Text = this.txtMaTinh.Text = this.txtMaTinh01.Text = this.txtMaHuyen.Text = this.txtMaTinhHuyen.Text = this.txtMaPXa.Text = string.Empty;
            this.lkupTQPXa.EditValue = "";
            this.lkupTinh.EditValue = string.Empty;
            this.lkupHuyen.EditValue = string.Empty;
            this.lkupPhuongXa.EditValue = string.Empty;
            this.gridControl_History.DataSource = null;
            this.lkPatientType.EditValue = 1;
            this.lkupNgheNghiep.EditValue = "NN00000001";
            this.lkupDanToc.EditValue = 1;
            this.lkupQuocTich.EditValue = 1;
            this.lkupCongKham.EditValue = null;
            this.lkupPhongKham.EditValue = string.Empty;
            this.lkDoituong.EditValue = -1;
            this.cbIntroducer.Text = string.Empty;
            this.lkupTypeReceive.EditValue = 1;
            this.txtLoaiTuoi.SelectedIndex = -1;
            this.lbstt.Text = this.lbTileBHYT.Text = this.sNgayhen = string.Empty;
            this.txtHoTenCha.Text = this.txtHoTenMe.Text = this.txtNamSinhCha.Text = this.txtNamSinhMe.Text = string.Empty;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = false;
            this.txtBarcodeBHYT.Focus();
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.iNew = 1;
                this.reloadTreeview = false;
                this.patientReceiveId = 0;
                this.patientReceiveClinic = string.Empty;
                this.iStatus = this.iUpdate = this.iPatientType = 0;
                this.txtMabn.Text = PatientsBLL.GetPatientCode();
                this.txtBarcodeBHYT.Text = this.txtHoTen.Text = this.txtNgaySinh.Text = this.txtNamSinh.Text = this.txtTuoi.Text = this.txtDiaChi.Text = this.txtDienThoai.Text = this.txtEmail.Text = this.txtTienSu.Text = this.txtDiUng.Text = string.Empty;
                this.cbGioiTinh.SelectedIndex = -1;
                this.lkKCB.EditValue = string.Empty;
                this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = this.txtKCBBD.Text = string.Empty;
                this.txtTheStart.EditValue = this.txtTheEnd.EditValue = string.Empty;
                this.sImagePath = this.txtLydo.Text = this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNang.Text = this.txtCao.Text = string.Empty;
                this.Enable(true);
                this.dtService.Clear();
                this.dtServiceDetail.Clear();
                this.txtMaTQPXa.Text = this.txtMaTinh.Text = this.txtMaTinh01.Text = this.txtMaHuyen.Text = this.txtMaTinhHuyen.Text = this.txtMaPXa.Text = string.Empty;
                this.lkupTQPXa.EditValue = string.Empty;
                this.lkupTinh.EditValue = string.Empty;
                this.lkupHuyen.EditValue = string.Empty;
                this.lkupPhuongXa.EditValue = string.Empty;
                this.gridControl_History.DataSource = null;
                this.GetStatistic();
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
                this.lkPatientType.EditValue = 1;
                this.lkupNgheNghiep.EditValue = "NN00000001";
                this.lkupDanToc.EditValue = 1;
                this.lkupQuocTich.EditValue = 1;
                this.lkupCongKham.EditValue = null;
                this.lkupPhongKham.EditValue = string.Empty;
                this.lkDoituong.EditValue = -1;
                this.cbIntroducer.Text = string.Empty;
                this.lkupTypeReceive.EditValue = 1;
                this.lbstt.Text = this.lbTileBHYT.Text = this.sNgayhen = this.barcode = string.Empty;
                this.txtLoaiTuoi.SelectedIndex = -1;
                this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = false;
                this.txtHoTenCha.Text = this.txtHoTenMe.Text = this.txtNamSinhCha.Text = this.txtNamSinhMe.Text =string.Empty;
                this.txtHoTen.Focus();
                this.lkDoituong.EditValue = 2;
                this.lkupTaiNanTT.EditValue = 0;
                ///this.EnableBHYT(false);
                //if (this.CheckReceiveOverRows1000())
                //    XtraMessageBox.Show("PHIÊN BẢN HIỆN TẠI ĐANG DÙNG THỬ! \r\n VÙI LÒNG LIÊN HỆ CÔNG TY ĐỂ ĐƯỢC HỖ TRỢ - Hotline: 098 737 10 79 - 0973 23 0919 ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error click new: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void GetStatistic()
        {
            try
            {
                this.chartControl1.Series.Clear();
                this.gridControl_SuggestedReceipt.DataSource = PatientReceiveBLL.DT_StatisticReceive();
                DataTable dtChart = PatientReceiveBLL.DT_StatisticChart();
                Series series2 = new Series("Biểu đồ", ViewType.Line);
                string sDate = string.Empty;
                if (dtChart.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtChart.Rows)
                    {
                        //string sTemp = "Ngày: " + dr["Date"].ToString().Substring(0, 5);
                        string sTemp = dr["Date"].ToString().Substring(0, 5);
                        int quantityTemp = Int32.Parse(dr["Tong"].ToString());
                        series2.Points.Add(new SeriesPoint(sTemp, new double[] { quantityTemp }));
                    }
                }
                this.chartControl1.Series.AddRange(new Series[] { series2 });
                this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            }
            catch { }
        }

        private void diung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //this.lkPatientType.Focus();
                this.txtHoTenCha.Focus();
            }
        }

        private void frmTiepDonBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1: butNew_Click(sender, e); break;
                    case Keys.F2: butSave_Click(sender, e); break;
                    case Keys.F3: butUndo_Click(sender, e); break;
                    case Keys.F8: butEdit_Click(sender, e); break;
                    case Keys.F5: butLoadInfo_Click(sender, e); break;
                    case Keys.F6: butPrintBarcode_Click(sender, e); break;
                    case Keys.F7: butListService_Click(sender, e); break;
                    case Keys.F10: butSearch_Click(sender, e); break;
                    case Keys.F11: this.ShowBangDien(); break;
                }
            }
            catch { return; }
        }

        private void txtNangcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) butSave.Focus(); 
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

        private void butListService_Click(object sender, EventArgs e)
        {
            try
            {
                this.suggestedClick = false;
                if (!string.IsNullOrEmpty(txtMabn.Text.ToString()))
                {
                    string message = string.Empty;
                    if (iUpdate == 0)
                    {
                        if (this.SaveInfoReceive(ref message))
                        {
                            this.dtServiceDetail = SuggestedServiceReceiptBLL.DT_ChidinhPK(patientReceiveId, txtMabn.Text.Trim());
                            this.gridControl_Detail.DataSource = dtServiceDetail;
                            this.butSave.Enabled = false;
                            this.butNew.Enabled = true;
                            frmChiDinhDichVu frm = new frmChiDinhDichVu(patientReceiveId, txtMabn.Text.ToString(), sUserID, Int32.Parse(lkDoituong.EditValue.ToString()), this.sMatheBHYT, iTraituyen, sReferenceCode, iPatientType, "KP0000", null, string.Empty, this.shiftWork, this.dtWorking);
                            frm.ShowDialog();
                        }
                        else
                        {
                            XtraMessageBox.Show(message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        frmChiDinhDichVu frm = new frmChiDinhDichVu(patientReceiveId, txtMabn.Text.ToString(), sUserID, Int32.Parse(lkDoituong.EditValue.ToString()), this.sMatheBHYT, iTraituyen, sReferenceCode, iPatientType, "KP0000", null, string.Empty, this.shiftWork, this.dtWorking);
                        frm.ShowDialog();
                    }
                }
            }
            catch { }
        }

        private void butPrintBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtMabn.Text.ToString()))
                {
                    DataTable dtPatient = PatientsBLL.DTPatients(this.txtMabn.Text.Trim(), this.patientReceiveId);
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtPatient);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBarCode.xml");
                    //Reports.rptBarCode barcode = new Reports.rptBarCode();
                    //barcode.DataSource = dsTemp;
                    //barcode.Print();
                    Reports.rptBarCode rptShow = new Reports.rptBarCode();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "MaVach","Barcode");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn bệnh nhân để in thẻ mã vạch (Barcode).", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Enable(bool b)
        {
            this.butNew.Enabled = !b;
            this.butEdit.Enabled = false;
            this.butSave.Enabled = b;
            this.butUndo.Enabled = b;
            this.butListService.Enabled = b;
            this.txtMabn.Properties.ReadOnly = true;
            this.txtBarcodeBHYT.ReadOnly = !b;
            this.txtHoTen.Properties.ReadOnly = !b;
            this.cbGioiTinh.Enabled = b;
            this.txtNgaySinh.Properties.ReadOnly = !b;
            this.txtNamSinh.Properties.ReadOnly = !b;
            this.txtLoaiTuoi.Properties.ReadOnly = !b;
            this.txtTuoi.Properties.ReadOnly = !b;
            //this.txtThang.Properties.ReadOnly = true;
            this.txtDiaChi.Properties.ReadOnly = !b;
            this.txtDienThoai.Properties.ReadOnly = !b;
            this.txtEmail.Properties.ReadOnly = !b;
            this.lkDoituong.Properties.ReadOnly = !b;
            this.txtTienSu.Properties.ReadOnly = !b;
            this.txtDiUng.Properties.ReadOnly = !b;
            this.txtLydo.Properties.ReadOnly = !b;
            this.txtMach.Properties.ReadOnly = !b;
            this.txtHuyetap.Properties.ReadOnly = !b;
            this.txtHuyetap1.Properties.ReadOnly = !b;
            this.txtNhietdo.Properties.ReadOnly = !b;
            this.txtNang.Properties.ReadOnly = !b;
            this.txtCao.Properties.ReadOnly = !b;
            this.txtHoTenCha.Properties.ReadOnly = !b;
            this.txtNamSinhCha.Properties.ReadOnly = !b;
            this.txtHoTenMe.Properties.ReadOnly = !b;
            this.txtNamSinhMe.Properties.ReadOnly = !b;

            this.butListService.Enabled = b;
            this.butChonhinhanh.Enabled = b;
            this.butLoadInfo.Enabled = false;
            this.btnCaptureDocument.Enabled = false;
            this.lkPatientType.Properties.ReadOnly = !b;
            this.gridControl_Detail.Enabled = b;
            this.lkupNgheNghiep.Properties.ReadOnly = !b;
            this.lkupDanToc.Properties.ReadOnly = !b;
            this.lkupQuocTich.Properties.ReadOnly = !b;
            //this.txtMaTQPXa.Properties.ReadOnly = !b;
            this.lkupTQPXa.Properties.ReadOnly = !b;
            //this.txtMaTinh.Properties.ReadOnly = !b;
            this.lkupTinh.Properties.ReadOnly = !b;
            //this.txtMaHuyen.Properties.ReadOnly = !b;
            this.lkupHuyen.Properties.ReadOnly = !b;
            //this.txtMaPXa.Properties.ReadOnly = !b;
            this.lkupPhuongXa.Properties.ReadOnly = !b;
            this.lkupCongKham.Properties.ReadOnly = !b;
            this.lkupPhongKham.Properties.ReadOnly = !b;
            this.memoNote.Properties.ReadOnly = !b;
            this.btnRelation.Enabled = b;
            this.cbIntroducer.Properties.ReadOnly = !b;
            this.lkupTypeReceive.Properties.ReadOnly = !b;
            this.lkupTaiNanTT.Properties.ReadOnly = !b;
        }

        private void EnableBHYT(bool b)
        {
            this.txtThe01.Properties.ReadOnly = this.txtThe02.Properties.ReadOnly = this.txtThe03.Properties.ReadOnly = this.txtThe04.Properties.ReadOnly = this.txtThe05.Properties.ReadOnly = this.txtThe06.Properties.ReadOnly = this.txtKCBBD.Properties.ReadOnly = !b;
            this.lkKCB.Properties.ReadOnly = !b;
            this.txtTheStart.Properties.ReadOnly = !b;
            this.txtTheEnd.Properties.ReadOnly = !b;
            this.chkTraiTuyen.Properties.ReadOnly = this.chkGiayChuyenVien.Properties.ReadOnly = !b;
        }

        private void lkDoituong_EditValueChanged(object sender, EventArgs e)
        {
            string objectTemp = "0";
            string patientTypeTemp = string.Empty;
            try
            {
                if (this.lkDoituong.EditValue != null)
                    objectTemp = lkDoituong.EditValue.ToString();
                if (this.lkPatientType.EditValue != null)
                    patientTypeTemp = lkPatientType.EditValue.ToString();
                if (string.IsNullOrEmpty(objectTemp))
                    objectTemp = "0";
                if (string.IsNullOrEmpty(patientTypeTemp))
                    patientTypeTemp = "1";
                
                List<ObjectInf> lstObject = ObjectBLL.ListObject(int.Parse(objectTemp));
                if (lstObject.Count > 0 && lstObject[0].ObjectCard == 1)
                {
                    bBHYT = true;
                    this.EnableBHYT(true);
                    this.lbstt.Enabled = true;
                    this.dtService = ServicePriceBLL.DTListPrice_MapService(0, int.Parse(objectTemp), Convert.ToInt32(patientTypeTemp), "'KCB'", string.Empty);
                    if (this.dtService != null && this.dtService.Rows.Count > 0)
                    {
                        this.lkupCongKham.Properties.DataSource = this.dtService;
                        this.lkupCongKham.Properties.DisplayMember = "ServiceName";
                        this.lkupCongKham.Properties.ValueMember = "ServiceCode";
                    }
                    if (this.txtThe06.Text.Trim().Length == 5)
                        this.GetCardInfo();
                    this.txtThe01.Focus();
                }
                else
                {
                    this.dtService = ServicePriceBLL.DTListPrice_MapService(0, int.Parse(objectTemp), Convert.ToInt32(patientTypeTemp), "'KCB'", string.Empty);
                    this.lkupCongKham.Properties.DataSource = this.dtService;
                    this.lkupCongKham.Properties.DisplayMember = "ServiceName";
                    this.lkupCongKham.Properties.ValueMember = "ServiceCode";

                    bBHYT = false;
                    this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = false;
                    this.EnableBHYT(false);
                    this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = string.Empty;
                    this.txtTheStart.Text = this.txtTheEnd.Text = this.txtKCBBD.Text = string.Empty;
                    this.lkKCB.EditValue = null;
                    this.lbTileBHYT.Text = this.lkDoituong.Text;
                    this.lkupCongKham.Focus();
                }
                this.dtServiceDetail.Clear();
                this.lkupPhongKham.Properties.DataSource = null;
                this.lkupCongKham.EditValue = string.Empty;
                this.gridControl_Detail.DataSource = this.dtServiceDetail;
                this.lbTileBHYT.Visible = true;
                if (objectTemp.Equals(1))
                    this.butListService.Enabled = false;
                else
                    this.butListService.Enabled = true;
            }
            catch {
                return;
            }
        }

        private void txtTheStart_Validated(object sender, EventArgs e)
        {
            if (txtTheStart.Text == "" || txtTheStart.Text == "__/__/____") return;
            txtTheStart.Text = txtTheStart.Text.Trim();
            if (!bNgay(txtTheStart.Text))
            {
                XtraMessageBox.Show("Nhập ngày không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTheStart.Focus();
                return;
            }
        }

        private void txtTheEnd_Validated(object sender, EventArgs e)
        {
            if (txtTheEnd.Text == "" || txtTheEnd.Text == "__/__/____") return;
            txtTheEnd.Text = txtTheEnd.Text.Trim();
            if (!bNgay(txtTheEnd.Text))
            {
                XtraMessageBox.Show("Nhập ngày không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTheEnd.Focus();
                return;
            }
        }
                
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                iNew = 0;
                if (!this.CheckPatientReceive(this.txtMabn.Text.TrimEnd()))
                {
                    if (this.dtWorking.ToString("dd/MM/yyyy") != this.dtWorkingOld.ToString("dd/MM/yyyy"))
                    {
                        XtraMessageBox.Show(" Khác ngày khám bệnh không cho phép sửa ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.butNew.Focus();
                    }
                    else
                    {
                        if (iStatus == 2)
                        {
                            XtraMessageBox.Show(" Bệnh nhân kết thúc điều trị, không được phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.butNew.Focus();
                        }
                        else
                        {
                            this.gridControl_History.DataSource = null;
                            this.GetStatistic();
                            this.lkupPhongKham.Properties.DataSource = null;
                            this.txtHoTen.Focus();
                            this.Enable(true);
                            if (this.lkDoituong.EditValue.ToString() == "1")
                                this.EnableBHYT(true);
                        }
                    }
                }
            }
            catch { }
        }

        private void txtTheStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}{F4}");
        }

        private void txtTheEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupCongKham.Focus();
                SendKeys.Send("{F4}");
            }
        }

        private void txtThe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //lkKCB.Focus();
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void butListService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void dtSearchFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void dtSearchTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }
        
        private void gridView_Patient_List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.iNew = 0;
                this.ClearData();
                if (this.gridView_Patient_List.GetFocusedRow() != null)
                {
                    if (this.gridView_Patient_List.RowCount > 0)
                    {
                        string refPatientCode = this.gridView_Patient_List.GetRowCellValue(this.gridView_Patient_List.FocusedRowHandle, this.col_PatientCode).ToString();
                        this.txtMabn.Text = refPatientCode;
                        if (string.IsNullOrEmpty(refPatientCode))
                        {
                            XtraMessageBox.Show(" Thông tin bệnh nhân không tồn tại trong hệ thống!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            this.iUpdate = 1;
                            this.GetHistoryPatient(refPatientCode);
                            this.GetInfoPatient(refPatientCode);
                            this.EnableBHYT(false);
                            this.gridView_History_DoubleClick(sender, e);
                        }
                        this.xtabInfo.SelectedTabPageIndex = 0;
                        this.Enable(false);
                        this.btnCaptureDocument.Enabled = true;
                        this.butLoadInfo.Enabled = true;
                        this.ProcessBMI();
                    }
                    this.butLoadInfo.Focus();
                }
                else
                {
                    return;
                }
            }
            catch { return; }
        }

        private void GetInfoPatient(string sPatient)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(sPatient, this.patientReceiveId);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    this.txtMabn.Text = objPatient.PatientCode;
                    this.txtHoTen.Text = objPatient.PatientName;
                    if (objPatient.PatientAge > 6)
                    {
                        this.txtTuoi.Text = objPatient.PatientAge.ToString();
                        this.txtLoaiTuoi.SelectedIndex = 0;
                    }
                    else
                    {

                        this.txtTuoi.Text = objPatient.PatientMonth;
                        this.txtLoaiTuoi.SelectedIndex = 1;
                    }
                    this.txtDiaChi.Text = objPatient.PatientAddress;
                    this.txtDienThoai.Text = objPatient.PatientMobile;
                    this.txtEmail.Text = objPatient.PatientEmail;
                    this.txtTienSu.Text = objPatient.MedicalHistory;
                    this.txtDiUng.Text = objPatient.Allergy;
                    this.txtHoTenCha.Text = objPatient.TenCha;
                    if (objPatient.NSCha != 0)
                        this.txtNamSinhCha.Text = objPatient.NSCha.ToString();
                    else
                        this.txtNamSinhCha.Text = string.Empty;
                    this.txtHoTenMe.Text = objPatient.TenMe;
                    if (objPatient.NSMe != 0)
                        this.txtNamSinhMe.Text = objPatient.NSMe.ToString();
                    else
                        this.txtNamSinhMe.Text = string.Empty;
                    this.cbGioiTinh.SelectedIndex = objPatient.PatientGender;
                    this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.txtNamSinh.Text = objPatient.PatientBirthyear.ToString();
                    //this.txtLoaiTuoi.SelectedIndex = string.IsNullOrEmpty(objPatient.PatientMonth) ? 1 : 0;
                    if (objPatient.IDTypeReceive != 0)
                        this.lkupTypeReceive.EditValue = objPatient.IDTypeReceive;
                    else
                        this.lkupTypeReceive.EditValue = 1;
                    this.lkupNgheNghiep.EditValue = objPatient.CareerCode;
                    this.lkupDanToc.EditValue = objPatient.EThnicID;
                    this.lkupQuocTich.EditValue = objPatient.NationalityID;
                    
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
                {
                    objPatient = PatientsBLL.ObjPatients(sPatient, 0);
                    this.txtMabn.Text = objPatient.PatientCode;
                    this.txtHoTen.Text = objPatient.PatientName;
                    if (objPatient.PatientAge > 6)
                    {
                        this.txtTuoi.Text = objPatient.PatientAge.ToString();
                        this.txtLoaiTuoi.SelectedIndex = 0;
                    }
                    else
                    {

                        this.txtTuoi.Text = objPatient.PatientMonth;
                        this.txtLoaiTuoi.SelectedIndex = 1;
                    }
                    this.txtDiaChi.Text = objPatient.PatientAddress;
                    this.txtDienThoai.Text = objPatient.PatientMobile;
                    this.txtEmail.Text = objPatient.PatientEmail;
                    this.txtTienSu.Text = objPatient.MedicalHistory;
                    this.txtDiUng.Text = objPatient.Allergy;
                    this.txtHoTenCha.Text = objPatient.TenCha;
                    if (objPatient.NSCha != 0)
                        this.txtNamSinhCha.Text = objPatient.NSCha.ToString();
                    else
                        this.txtNamSinhCha.Text = "";
                    this.txtHoTenMe.Text = objPatient.TenMe;
                    if (objPatient.NSMe != 0)
                        this.txtNamSinhMe.Text = objPatient.NSMe.ToString();
                    else
                        this.txtNamSinhMe.Text = "";
                    this.cbGioiTinh.SelectedIndex = objPatient.PatientGender;
                    this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.txtNamSinh.Text = objPatient.PatientBirthyear.ToString();
                    //this.txtLoaiTuoi.SelectedIndex = string.IsNullOrEmpty(objPatient.PatientMonth) ? 1 : 0;
                    if (objPatient.IDTypeReceive != 0)
                        this.lkupTypeReceive.EditValue = objPatient.IDTypeReceive;
                    else
                        this.lkupTypeReceive.EditValue = 1;
                    this.lkupNgheNghiep.EditValue = objPatient.CareerCode;
                    this.lkupDanToc.EditValue = objPatient.EThnicID;
                    this.lkupQuocTich.EditValue = objPatient.NationalityID;
                    //this.txtThang.Text = objPatient.PatientMonth;
                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        this.picPatient.Image = (Bitmap)b;
                    }
                    else
                    {
                        Bitmap b1 = new Bitmap("NoImgPatient.jpeg");
                        this.picPatient.Image = (Bitmap)b1;
                    }
                }
            }
            catch { }
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtHoTen.Focus();
        }

        private void butChonhinhanh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.RestoreDirectory = true;
                opf.Multiselect = false;
                opf.Filter = "All (*.*)|*.*|*.gif|*.gif|*.jpg|*.jpg|*.bmp|*.bmp";
                opf.RestoreDirectory = true;
                MemoryStream stream = new MemoryStream();
                DialogResult dr = opf.ShowDialog();
                if (dr == DialogResult.OK && opf.FileNames.Length > 0)
                {
                    for (int i = 0; i < opf.FileNames.Length; i++)
                    {
                        Bitmap b = new Bitmap(opf.FileNames[i].ToString());
                        sImagePath = opf.FileNames[i].ToString();
                        picPatient.Image = (Bitmap)b;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void GetHistoryPatient(string sPatient)
        {
            try
            {
                if (!this.reloadTreeview)
                {
                    this.reloadTreeview = true;
                    //this.dbTree_History.Nodes.Clear();
                    //this.dbTree_History.RemoveGroup("Detail");
                    this.gridControl_History.DataSource = null;
                    List<PatientViewInf> lstHistory = PatientsBLL.ListHistoryForPatient(sPatient);
                    //this.dbTree_History.SetLeafData("History", "Info", "RefID", 0, 0);
                    //this.dbTree_History.DataSource = lstHistory;
                    //this.dbTree_History.AddGroup("Detail", "RefID", "Title", "RefID", 0, 0);
                    //this.dbTree_History.BuildTree();
                    this.gridControl_History.DataSource = lstHistory;
                    this.gridView_History.Columns["CreateDate"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    this.gridView_History.Columns["CreateDate"].Group();
                    this.gridView_History.FocusedRowHandle = 0;
                }
            }
            catch { }
        }

        private void txtNamSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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

        private void txtHuyetap1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void lkPatientType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //this.lkDoituong.Focus();
                //this.lkDoituong.Show();
                SendKeys.Send("{Tab}{F4}");

            }
        }

        private void lkKCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}{F4}"); 
        }

        private void txtHuyetap1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}"); 
        }

        private void txtNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}"); 
        }

        private void txtCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}"); 
        }

        private void gridControl_Detail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa công khám này hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        string sResult = string.Empty;
                        Int32 iResult = SuggestedServiceReceiptBLL.Del(decimal.Parse(gridView_Detail.GetRowCellValue(gridView_Detail.FocusedRowHandle, col_Detail_ReceiptID).ToString()), ref sResult);
                        if (iResult == 1)
                        {
                            XtraMessageBox.Show(sResult.ToString(), "Bệnh viện điện tử .NET");
                            dtServiceDetail = SuggestedServiceReceiptBLL.DT_ChidinhPK(this.patientReceiveId, txtMabn.Text.Trim());
                            gridControl_Detail.DataSource = dtServiceDetail;
                        }
                        else if (iResult == 0)
                        {
                            dtServiceDetail.Rows.RemoveAt(gridView_Detail.FocusedRowHandle);
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show(sResult, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch { return; }
                }
            }
        }
        
        private void butLoadInfo_Click(object sender, EventArgs e)
        {
            try {
                //this.iNew = 1;
                this.patientReceiveId = 0;
                this.patientReceiveClinic = string.Empty;
                this.iStatus = this.iUpdate = this.iPatientType = 0;
                this.lkDoituong.EditValue = null;
                //this.lkKCB.EditValue = string.Empty;
                this.lkPatientType.EditValue = 1;
                this.lkupCongKham.EditValue = string.Empty;
                this.Enable(true);
                this.dtService.Clear();
                this.dtServiceDetail.Clear();
                this.lbstt.Text = this.lbTileBHYT.Text = string.Empty;
                this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNang.Text = this.txtCao.Text = string.Empty;
                this.gridControl_History.DataSource = null;
                if (!string.IsNullOrEmpty(this.txtTheEnd.Text) && Utils.isDate(this.txtTheEnd.Text) && Convert.ToDateTime(this.txtTheEnd.Text) <= this.dtWorking.Date)
                {
                    this.lkDoituong.EditValue = 2;
                    //this.ClearBHYTInfo();
                }
                else
                    this.lkDoituong.EditValue = 1;
            }
            catch ( Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBHYTInfo()
        {
            this.sMatheBHYT = this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = string.Empty;
            this.txtKCBBD.Text = this.txtTheStart.Text = this.txtTheEnd.Text = string.Empty;
            this.lkKCB.EditValue = null;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = this.chkCapCuu.Checked = false;
        }

        private void chkTraiTuyen_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
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
                                this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                            else
                                this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "%";
                        }
                        else
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                    }
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckPatientReceive(string sPatientCode)
        {
            try
            {
                List<PatientReceiveInf> lst = PatientReceiveBLL.ListCheckPatient(sPatientCode);
                if (lst.Count > 0 && lst[0].CreateDate.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    XtraMessageBox.Show("Đề nghị kết thúc điều trị bệnh nhân trước khi tiếp đón mới! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        private void SearchCheckPatient()
        {
            try
            {
                DataTable dttemp = PatientReceiveBLL.DTCheckExistPatient(txtHoTen.Text.TrimEnd(), txtNgaySinh.Text.TrimEnd(), cbGioiTinh.SelectedIndex.ToString(), txtNamSinh.Text.TrimEnd(), txtTuoi.Text.TrimEnd(), txtDiaChi.Text.TrimEnd());
                if (dttemp != null && dttemp.Rows.Count > 0)
                {
                    gridControl_Patient_List.DataSource = dttemp;
                    xtabInfo.SelectedTabPageIndex = 1;
                }
            }
            catch { }
        }

        private void txtNang_Validated(object sender, EventArgs e)
        {
            if (txtNang.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(txtNang.Text.Trim()))
                {
                    XtraMessageBox.Show(" Cân nặng phải nhập số!", "Bệnh viện điện tử .NET");
                    txtNang.Focus();
                    return;
                }
                else
                    ProcessBMI();
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
            catch {  }
        }
                
        private void txtNhietdo_Validated(object sender, EventArgs e)
        {
            if (txtNhietdo.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(txtNhietdo.Text.Trim()))
                {
                    XtraMessageBox.Show(" Nhiệt độ phải nhập số!", "Bệnh viện điện tử .NET");
                    txtNhietdo.Focus();
                    return;
                }
            }
        }

        private void btnCaptureDocument_Click(object sender, EventArgs e)
        {
            ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(patientReceiveId, txtMabn.Text.Trim());
            frm.ShowDialog();
        }

        private void butSearchHen_Click(object sender, EventArgs e)
        {
            this.gridControl_Appointment.DataSource = PatientAppointment_BLL.DTListAppointmentSearch(txtHen_MaBN.Text.Trim(), txtHen_HoTen.Text.Trim(), txtHen_Tuoi.Text.Trim(), txtHen_DienThoai.Text.Trim(), dtfrom.Text.Trim(), dtTo.Text.Trim());
        }

        private void gridView_Appointment_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_Appointment.RowCount > 0)
                {
                    string refPatientCode = gridView_Appointment.GetRowCellValue(gridView_Appointment.FocusedRowHandle, col_hen_PatientCode).ToString();
                    sNgayhen = gridView_Appointment.GetRowCellValue(gridView_Appointment.FocusedRowHandle, col_hen_AppointmentDate).ToString();
                    if (refPatientCode == string.Empty)
                    {
                        XtraMessageBox.Show(" Bệnh nhân chưa đăng ký hẹn..! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        this.GetInfoPatient(refPatientCode);
                        this.GetHistoryPatient(refPatientCode);
                        this.xtabInfo.SelectedTabPageIndex = 0;
                        this.Enable(false);
                        this.btnCaptureDocument.Enabled = true;
                        this.butLoadInfo.Enabled = true;
                    }
                }
                else
                {
                    return;
                }
            }
            catch { return; }
        }

        private void cbGioiTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }
        
        private void txtCao_Validated(object sender, EventArgs e)
        {
            if (txtCao.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(txtCao.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chiều cao phải nhập số!", "Bệnh viện điện tử .NET");
                    txtCao.Focus();
                    return;
                }
            }
        }

        private void lkPatientType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.dtService = ServicePriceBLL.DTListPrice_MapService(0, int.Parse(lkDoituong.EditValue.ToString()), Convert.ToInt32(this.lkPatientType.EditValue.ToString()), "'KCB'", string.Empty);
                List<ObjectInf> lstObject = new List<ObjectInf>();
                lstObject = ObjectBLL.ListObject(int.Parse(lkDoituong.EditValue.ToString()));
                if (lstObject[0].ObjectCard == 1)
                {
                    this.bBHYT = true;
                    this.EnableBHYT(true);
                    this.lbstt.Enabled = true;
                    if (dtService != null && dtService.Rows.Count > 0)
                    { 
                        this.lkupCongKham.Properties.DataSource = dtService;
                        this.lkupCongKham.Properties.ValueMember = "ServiceCode";
                        this.lkupCongKham.Properties.DisplayMember = "ServiceName";
                    }
                    if (this.txtThe06.Text.Trim().Length == 5)
                        this.GetCardInfo();
                    if (this.lkPatientType.EditValue.Equals(2))
                    {
                        SystemParameterInf objSys = SystemParameterBLL.ObjParameter(6);
                        if (objSys.Values.Equals(1) && this.lkPatientType.EditValue.Equals(2))
                        {
                            this.iTraituyen = 0;
                            this.chkTraiTuyen.Checked = false;
                        }
                    }
                    this.txtThe01.Focus();
                }
                else
                {
                    this.dtService = ServicePriceBLL.DTListPrice_MapService(0, int.Parse(lkDoituong.EditValue.ToString()), Convert.ToInt32(this.lkPatientType.EditValue.ToString()), "'KCB'", string.Empty);
                    this.lkupCongKham.Properties.DataSource = this.dtService;
                    this.lkupCongKham.Properties.ValueMember = "ServiceCode";
                    this.lkupCongKham.Properties.DisplayMember = "ServiceName";
                    this.bBHYT = false;
                    this.EnableBHYT(false);
                    this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = string.Empty;
                    this.txtTheStart.Text = this.txtTheEnd.Text = this.txtKCBBD.Text = string.Empty;
                    this.lkKCB.EditValue = null;
                    this.chkGiayChuyenVien.Checked = this.chkTraiTuyen.Checked = false;
                    this.lbTileBHYT.Text = this.lkDoituong.Text.ToString();
                    this.lkupCongKham.Focus();
                }
                this.dtServiceDetail.Clear();
                this.lkupPhongKham.Properties.DataSource = null;
                this.gridControl_Detail.DataSource = dtServiceDetail;
                this.lbTileBHYT.Visible = true;
            }
            catch { }
        }

        private void xtabInfo_Click(object sender, EventArgs e)
        {
            if (this.xtabInfo.SelectedTabPageIndex == 1)
                this.txtSearchCode.Focus();
        }

        private void txtSearchCode_Validated(object sender, EventArgs e)
        {
            butSearch_Click(sender, e);
        }

        private void tabControlTke_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    startDate.EditValue = endDate.EditValue = DateTime.Now.Date;
            //    if (tabControlTke.SelectedTabPageIndex == 1)
            //    {
            //        this.butGetPatient_Click(sender, e);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new ApplicationException(ex.Message);
            //}
        }

        private void butGetPatient_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbReceice = PatientReceiveBLL.DT_View_ListReportReceive(this.startDate.EditValue.ToString(), this.endDate.EditValue.ToString());
                this.gridControl_ListPatient.DataSource = dtbReceice;
                this.gridView_ListPatient.Columns["DepartmentName"].Group();
                //this.gridView_ListPatient.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl_ListPatient.ShowRibbonPrintPreview();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private void gridView_ListPatient_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 status = 0, paid = 0;
                if (e.RowHandle >= 0)
                {
                    status = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status"]));
                    paid = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Paid"]));
                    if (paid == 1 || status == 1)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                        View.ActiveEditor.Enabled = false;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                        View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
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

        private void lkupNgheNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupQuocTich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtMaTQPXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtMaTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupHuyen.Focus();
                this.lkupHuyen.ShowPopup();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtMaPXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupPhuongXa.Focus();
                this.lkupPhuongXa.ShowPopup();
            }
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupTQPXa.Focus();
                this.lkupTQPXa.ShowPopup();
            }
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            try
            {
                this.txtDiaChi.Text = Utils.ToUpperCharacterFisrt(this.txtDiaChi.Text.TrimEnd());
                this.SearchCheckPatient();
            }
            catch { return; }
        }

        private void lkupTQPXa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
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

        private void lkupHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupPhuongXa.Focus();
                this.lkupPhuongXa.ShowPopup();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtMaTinh01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtMaHuyen.Focus();
                //SendKeys.Send("{Tab}");
            }
        }

        private void txtMaHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupHuyen.Focus();
                this.lkupHuyen.ShowPopup();
            }
        }

        private void txtMaTinhHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtMaPXa.Focus();
            }
        }

        private void lkupPhuongXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void lkupCongKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                //this.lkupPhongKham.Focus();
                //this.lkupPhongKham.ShowPopup();
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupPhongKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                this.lkupTaiNanTT.Focus();
        }

        private void lkupPhongKham_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string serviceCodeTemp = this.lkupCongKham.EditValue.ToString();
                string departmentCode = this.lkupPhongKham.EditValue.ToString();
                DataRow r = Utils.GetPriceRowbyCode(dtServiceDetail, "ServiceCode='" + serviceCodeTemp + "' and DepartmentCode='" + departmentCode + "'");
                if (r != null)
                {
                    if (XtraMessageBox.Show(" Công khám đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        this.lkupCongKham.Focus();
                        return;
                    }
                    else
                        dtServiceDetail.Rows.Add(serviceCodeTemp, this.lkupCongKham.Text, departmentCode, this.lkupPhongKham.Text, 0, 0, 0);
                }
                else
                {
                    dtServiceDetail.Rows.Add(serviceCodeTemp, this.lkupCongKham.Text, departmentCode, this.lkupPhongKham.Text, 0, 0, 0);
                }
                this.gridControl_Detail.DataSource = dtServiceDetail;
                this.cbIntroducer.Focus();
            }
            catch { }
        }

        private void lkupCongKham_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.lkupPhongKham.EditValue = null;
                string[] sPart = this.lkupCongKham.GetColumnValue("DepartmentCode").ToString().Split(',');
                string sTemp = "";
                for (int i = 0; i < sPart.Length; i++)
                {
                    sTemp += "'" + sPart[i].ToString().TrimStart(' ') + "',";
                }
                this.lkupPhongKham.Properties.DataSource = DepartmentBLL.ListDepartmentForCode(sTemp.TrimEnd(','));
                this.lkupPhongKham.Properties.DisplayMember = "DepartmentName";
                this.lkupPhongKham.Properties.ValueMember = "DepartmentCode";
                SendKeys.Send("{Tab}{F4}");
            }
            catch { }
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            if (txtMabn.Text.Trim().Length > 0)
            {
                frmRelationPatient frm = new frmRelationPatient(patientReceiveId, sUserID, txtMabn.Text.Trim());
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để khai báo thông tin gia đình!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkDoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.lkupCongKham.Focus();
                this.lkupCongKham.ShowPopup();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupPhuongXa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtMaPXa.Text = this.lkupPhuongXa.EditValue.ToString();
            }
            catch { return; }
        }

        private void lkupNguoiGT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                this.txtLydo.Focus();
        }

        private void butHSBA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMabn.Text))
            {
                frmKB_HSBA frm = new frmKB_HSBA(this.txtMabn.Text);
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show(" Chưa có thông tin mã bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupTypeReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}{F4}");
        }

        private void cbIntroducer_TextChanged(object sender, EventArgs e)
        {
            string temp = string.Empty;
        }

        private void butPrintPatientList_Click(object sender, EventArgs e)
        {
            this.gridControl_Patient_List.ShowRibbonPrintPreview();
        }

        private void butPrintPatientAppoiment_Click(object sender, EventArgs e)
        {
            this.gridControl_Appointment.ShowRibbonPrintPreview();
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

        private void txtThe01_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (this.txtThe01.Text.Trim().Length < 2)
            //    this.txtThe01.Focus();
            //else
            //    this.txtThe02.Focus();
        }

        private void txtThe01_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe01.Text.Length < 2)
                this.txtThe01.Focus();
            else
                this.txtThe02.Focus();
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
            //else
            //{
            //    if (this.txtThe02.Text.Trim().Length < 1)
            //        this.txtThe02.Focus();
            //    else
            //        this.txtThe03.Focus();
            //}
        }

        private void txtThe02_EditValueChanged(object sender, EventArgs e)
        {
            this.lbstt.Text = (this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length).ToString();
            if (this.txtThe02.Text.Trim().Length < 1)
                this.txtThe02.Focus();
            else
                this.txtThe03.Focus();
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
            //else
            //{
            //    if (this.txtThe03.Text.Trim().Length < 2)
            //        this.txtThe03.Focus();
            //    else
            //        this.txtThe04.Focus();
            //}
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
            //else
            //{
            //    if (this.txtThe04.Text.Trim().Length < 2)
            //        this.txtThe04.Focus();
            //    else
            //        this.txtThe05.Focus();
            //}
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

        private void txtThe05_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (this.txtThe05.Text.Trim().Length < 1)
                    this.txtThe04.Focus();
            }
            //else
            //{
            //    if (this.txtThe05.Text.Trim().Length < 3)
            //        this.txtThe05.Focus();
            //    else
            //        this.txtThe06.Focus();
            //}
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
            //else
            //{
            //    if (this.txtThe06.Text.Trim().Length < 5)
            //        this.txtThe06.Focus();
            //    else
            //        SendKeys.Send("{Tab}{F4}");
            //}
        }

        private void txtThe06_Validated(object sender, EventArgs e)
        {
            this.GetCardInfo();
        }

        private void txtKCBBD_Validated(object sender, EventArgs e)
        {
            this.LoadDKKCBBD();
        }

        private void LoadDKKCBBD()
        {
            try
            {
                string[] strArrayCode = this.txtKCBBD.Text.Trim().Split(new char[] { '-' });
                DataTable tableKCBBD = new DataTable();
                if (strArrayCode.Length > 1)
                    tableKCBBD = KCBBDBLL.TableKCBBDForBHYT(strArrayCode[0].ToString().Trim(), strArrayCode[1].ToString().Trim());
                else
                    tableKCBBD = KCBBDBLL.TableKCBBDForBHYT(strArrayCode[0].ToString().Trim());
                if (tableKCBBD != null && tableKCBBD.Rows.Count > 0)
                {
                    this.lkKCB.Properties.DataSource = tableKCBBD;
                    this.lkKCB.Properties.DisplayMember = "KCBBDName";
                    this.lkKCB.Properties.ValueMember = "KCBBDCode";
                    //this.lkKCB.EditValue = strArrayCode[1].ToString().Trim();
                    this.lkKCB.EditValue = tableKCBBD.Rows[0][1].ToString();
                    if (Convert.ToInt32(tableKCBBD.Rows[0][4].ToString()) == 0)
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
            catch (Exception exception)
            {
                XtraMessageBox.Show("Error: Load barcode BHYT " + exception.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtKCBBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkKCB.Focus();
            }
        }

        private void txtBarcodeBHYT_TextChanged(object sender, EventArgs e)
        {
            string textBarcode = this.txtBarcodeBHYT.Text;
            this.barcode = textBarcode;
            int lengthBarcode = textBarcode.Length;
            if (lengthBarcode > 0)
            {
                char ch = textBarcode.ToCharArray()[lengthBarcode - 1];
                byte num2 = (byte)ch;
                if ((num2 == 36) && (textBarcode.ToCharArray()[lengthBarcode - 2] == '|'))
                {
                    bool check = false;
                    this.GenerateDataFromBarcode(textBarcode, ref check);
                    if (check)
                    {
                        this.txtNgaySinh_Validated(sender, e);
                        this.txtNamSinh_Validated(sender, e);
                        this.LoadDKKCBBD();
                        string paientCodeTemp = BHYTBLL.PatientCodeForSerial(this.sMatheBHYT);
                        if (!string.IsNullOrEmpty(paientCodeTemp))
                        {
                            this.iNew = 0;
                            this.txtMabn.Text = paientCodeTemp;
                            this.GetHistoryPatient(paientCodeTemp);
                            this.butLoadInfo.Enabled = true;
                        }
                    }
                    this.CheckBHYTCard();
                    this.lkupCongKham.Focus();
                }
            }
        }
        
        private void GenerateDataFromBarcode(string barcode,ref bool check)
        {
            try
            {
                string[] strArray = barcode.Split(new char[] { '|' });
                if (strArray.Length < 15 || strArray.Length > 15 || strArray[0].Length < 15)
                {
                    XtraMessageBox.Show("Mã thẻ không hợp lệ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtBarcodeBHYT.Text = string.Empty;
                    this.txtBarcodeBHYT.Focus();
                    check = false;
                    return;
                }
                else
                {
                    this.sMatheBHYT = strArray[0];
                    this.txtHoTen.Text = this.ConvertHexaToUnicode(strArray[1]);
                    if (strArray[2].Length == 4)
                        this.txtNgaySinh.Text = "01/01/" + strArray[2];
                    else
                        this.txtNgaySinh.Text = strArray[2];
                    if (Convert.ToInt32(strArray[3]) == 1)
                        this.cbGioiTinh.SelectedIndex = 1;
                    else if (Convert.ToInt32(strArray[3]) == 2)
                        this.cbGioiTinh.SelectedIndex = 0;
                    this.txtDiaChi.Text = this.ConvertHexaToUnicode(strArray[4]);
                    this.lkDoituong.EditValue = 1;
                    this.txtThe01.Text = strArray[0].Substring(0, 2);
                    this.txtThe02.Text = strArray[0].Substring(2, 1);
                    this.txtThe03.Text = strArray[0].Substring(3, 2);
                    this.txtThe04.Text = strArray[0].Substring(5, 2);
                    this.txtThe05.Text = strArray[0].Substring(7, 3);
                    this.txtThe06.Text = strArray[0].Substring(10, 5);
                    this.lbstt.Text = strArray[0].Length.ToString();
                    string[] strArrayCode = strArray[5].Split(new char[] { '-' });
                    this.txtTheStart.Text = Convert.ToDateTime(strArray[6].ToString()).ToString("dd/MM/yyyy");
                    this.txtTheEnd.Text = Convert.ToDateTime(strArray[7].ToString()).ToString("dd/MM/yyyy");
                    this.txtKCBBD.Text = strArray[5].Trim();
                    DataTable tableKCBBD = new DataTable();
                    if (strArrayCode.Length > 1)
                        tableKCBBD = KCBBDBLL.TableKCBBDForBHYT(strArrayCode[0].ToString().Trim(), strArrayCode[1].ToString().Trim());
                    else
                        tableKCBBD = KCBBDBLL.TableKCBBDForBHYT(strArrayCode[0].ToString().Trim());
                    if (Convert.ToDateTime(strArray[6].ToString()) > this.dtServer.Date)
                    {
                        if (XtraMessageBox.Show("Mã thẻ chưa đến ngày được hưởng BHYT theo tỷ lệ. \r\n Chọn Yes: Chuyển bệnh nhân sang đối tượng thu phí. \r\n Chọn No: Để chỉnh sửa lại ngày tham gia bao hiểm.", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            this.txtBarcodeBHYT.Text = string.Empty;
                            this.txtBarcodeBHYT.Focus();
                            this.lkDoituong.EditValue = 2;
                            check = false;
                            return;
                        }
                    }
                    if (Convert.ToDateTime(strArray[7].ToString()) < this.dtServer.Date)
                    {
                        if (XtraMessageBox.Show("Mã thẻ đã hết hạn được hưởng BHYT theo tỷ lệ. \r\n Chọn Yes: Chuyển bệnh nhân sang đối tượng thu phí. \r\n Chọn No: Để chỉnh sửa lại ngày tham gia bao hiểm.", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            this.txtBarcodeBHYT.Text = string.Empty;
                            this.txtBarcodeBHYT.Focus();
                            this.lkDoituong.EditValue = 2;
                            check = false;
                            return;
                        }
                    }
                    if (tableKCBBD != null && tableKCBBD.Rows.Count > 0)
                    {
                        this.lkKCB.Properties.DataSource = tableKCBBD;
                        this.lkKCB.Properties.DisplayMember = "KCBBDName";
                        this.lkKCB.Properties.ValueMember = "KCBBDCode";
                        this.lkKCB.EditValue = tableKCBBD.Rows[0][1].ToString();
                        if (Convert.ToInt32(tableKCBBD.Rows[0][4].ToString()) == 0)
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
                    check = true;
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Error: Load barcode BHYT " + exception.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ConvertHexaToUnicode(string hexString)
        {
            try
            {
                int length = hexString.Length;
                byte[] bytes = new byte[length / 2];
                for (int i = 0; i < length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
                }
                return Encoding.UTF8.GetString(bytes);
            }
            catch { return string.Empty; }
        }

        private void chkGiayChuyenVien_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
        }

        private void txtBarcodeBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtHoTen.Focus();
            }
        }

        private void txtTenCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNamSinhCha.Focus();
        }

        private void txtNamSinhCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtHoTenMe.Focus();
        }

        private void txtTenMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNamSinhMe.Focus();
        }

        private void txtNamSinhMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.lkupTypeReceive.Focus();
        }

        private void txtNamSinhCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNamSinhMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkCapCuu_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
        }

        private void txtLoaiTuoi_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtTuoi.Text))
                this.txtNamSinh.Text = this.Namsinh(this.txtNgaySinh.Text, int.Parse(this.txtTuoi.Text), this.txtLoaiTuoi.SelectedIndex).ToString();
        }

        private void gridView_History_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_History.GetFocusedRow() != null)
                {
                    if (this.gridView_History.RowCount > 0)
                    {
                        this.patientReceiveId = Convert.ToDecimal(this.gridView_History.GetRowCellValue(this.gridView_History.FocusedRowHandle, colHistory_RefID).ToString());
                        this.xtabInfo.SelectedTabPageIndex = 0;
                        this.Enable(false);
                        this.EnableBHYT(false);
                        this.fLoad_Luottiepdon(this.patientReceiveId);
                        //this.butLoadInfo.Enabled = true;
                        //this.butListService.Enabled = false;
                    }
                }
            }
            catch { return; }
        }
        
        private void txtLoaiTuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupNgheNghiep.Focus();
                this.lkupNgheNghiep.Show();
            }
        }

        private void lkupTaiNanTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.cbIntroducer.Focus();
        }

        private void butEditPatient_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinBN frm = new frmCapNhatThongTinBN(this.sUserID, this.txtMabn.Text.Trim(), this.dtWorking);
            frm.ShowDialog();
        }

        private void ShowBangDien()
        {
            try
            {
                frmBangDienInfo frm = new frmBangDienInfo();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckReceiveOverRows1000()
        {
            List<PatientReceiveInf> listReceive = PatientReceiveBLL.ListPatientReceive(0);
            if (listReceive != null && listReceive.Count >= 1000)
                return true;
            else
                return false;
        }

        private void CheckBHYTCard()
        {
            if (this.isCheckCardBHYT)
            {
                iHISPortalBHYT.ModelGDBHYT.DataHistoryExaminationPatient data = new iHISPortalBHYT.ModelGDBHYT.DataHistoryExaminationPatient();
                data.gioiTinh = this.cbGioiTinh.SelectedIndex;
                data.hoTen = this.txtHoTen.Text;
                data.maCSKCB = this.txtKCBBD.Text.Remove('-').Trim();// "79024";
                data.maThe = this.txtThe01.Text + this.txtThe02.Text + this.txtThe03.Text + this.txtThe04.Text + this.txtThe05.Text + this.txtThe06.Text;
                data.ngayBD = this.txtTheStart.Text;//"01/10/2016";
                data.ngayKT = this.txtTheEnd.Text;//"31/12/2016";
                data.ngaySinh = this.txtNgaySinh.Text;//"29/03/1990";
                iHISPortalBHYT.FuncPortalBHYT portal = new iHISPortalBHYT.FuncPortalBHYT();
                iHISPortalBHYT.ModelGDBHYT.ResultCheckTheBHYT result = portal.CheckTheBHYT(this.username_TC, this.password_TC, data);
                if (!result.maKetQua.Equals("00"))
                    XtraMessageBox.Show(result.ketQua, "iHIS Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetUserPass_GD_BHYT()
        {
            ClinicInformationInf hospital = ClinicInformationBLL.ObjInformation(1);
            this.username_TC = hospital.UserName_TC;
            this.password_TC = hospital.PassWord_TC;
            this.username_BV = hospital.UserName_BV;
            this.password_BV = hospital.PassWord_BV;
        }

        private void btnViewHistoryBHYT_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableKCBBD = KCBBDBLL.TableKCBBDALL();
                iHISPortalBHYT.ModelGDBHYT.DataHistoryExaminationPatient dataCard = new iHISPortalBHYT.ModelGDBHYT.DataHistoryExaminationPatient();
                dataCard.gioiTinh = this.cbGioiTinh.SelectedIndex;
                dataCard.hoTen = this.txtHoTen.Text;
                string kcbbd = this.txtKCBBD.Text;
                dataCard.maCSKCB = kcbbd.Replace('-',' ').Trim();// "79024";
                dataCard.maThe = this.txtThe01.Text + this.txtThe02.Text + this.txtThe03.Text + this.txtThe04.Text + this.txtThe05.Text + this.txtThe06.Text;
                dataCard.ngayBD = this.txtTheStart.Text;//"01/10/2016";
                dataCard.ngayKT = this.txtTheEnd.Text;//"31/12/2016";
                dataCard.ngaySinh = this.txtNgaySinh.Text;//"29/03/1990";
                iHISPortalBHYT.FuncPortalBHYT portal = new iHISPortalBHYT.FuncPortalBHYT();
                iHISPortalBHYT.frmGetHistoryPatients frmHistory = new iHISPortalBHYT.frmGetHistoryPatients(tableKCBBD, this.username_BV, this.password_BV, dataCard);
                frmHistory.ShowDialog();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}