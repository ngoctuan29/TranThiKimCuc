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
    public partial class frmTiepDon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUserID = string.Empty;
        private string sYear = string.Empty;
        private bool bBHYT = false;
        private int iPatientType = 0;
        private decimal patientReceiveId = 0;
        private decimal dIDSurvive = 0;
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
        private bool suggestedClick = false;
        private string patientReceiveClinic = string.Empty;
        private string shiftWork = string.Empty;
        private string barcode = string.Empty;

        public frmTiepDon(string _UserID, string _shiftWork, DateTime _dtWorking)
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
                this.lbTileBHYT.Text = this.lkDoituong.Text;
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
            catch { }
        }
        
        private void frmTiepDon_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtHoTen.Focus();
                this.LoadPatientInfo();
                this.Enable(false);                
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
                this.startDate.EditValue = this.endDate.EditValue = this.dtWorking;
            }
            catch { }
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

                if (ObjectBLL.DTObjectListNotIn(5).Select("ObjectCode<>1").Length > 0)
                {
                    this.lkDoituong.Properties.DataSource = ObjectBLL.DTObjectListNotIn(5).Select("ObjectCode<>1").CopyToDataTable();
                    this.lkDoituong.Properties.DisplayMember = "ObjectName";
                    this.lkDoituong.Properties.ValueMember = "ObjectCode";
                }
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
            string patientCodeTemp = this.txtMabn.Text.Trim();
            this.suggestedClick = true;
            int resultReceive = PatientReceiveBLL.CheckPresentPatient(patientCodeTemp, iNew, this.patientReceiveId, ref sTemp);
            List<PatientViewInf> lstpatient = PatientsBLL.ListHistoryForPatient(patientCodeTemp).Where(p => p.CreateDate == this.dtWorking).ToList();
            if (lstpatient.Count >= 1)
            {
                frmKB_ShowHistoryReceive frm = new frmKB_ShowHistoryReceive(lstpatient);
                frm.ShowDialog();
                this.patientReceiveId = frm.patientReceiveID;
            }
            if ((resultReceive == 1) || this.patientReceiveId > 0)
            {
                if (this.SaveInfoReceive(ref sTemp))
                {
                    if (!string.IsNullOrEmpty(this.barcode))
                        PatientReceiveBLL.UpdPatientReceiveBarcode(this.patientReceiveId, this.txtMabn.Text.Trim(), this.barcode);
                    this.dtServiceDetail = SuggestedServiceReceiptBLL.DT_ChidinhPK(this.patientReceiveId, txtMabn.Text.Trim());
                    this.gridControl_Detail.DataSource = this.dtServiceDetail;
                    XtraMessageBox.Show(" Cập nhật thông tin bệnh nhân thành công! ", "Bệnh viện điện tử .NET - OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Enable(false);
                    this.btnCaptureDocument.Enabled = true;
                }
                else
                    XtraMessageBox.Show(sTemp, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show(sTemp + "\n\t Chọn [Yes] để kết thúc đợt khám cũ (trước đó!).", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                else if (lkPatientType.EditValue.ToString() == "0")
                {
                    //XtraMessageBox.Show(" chọn loại bệnh nhân khi tiếp nhận!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    message = "Chọn loại bệnh nhân khi tiếp nhận!";
                    this.lkPatientType.Focus();
                    return false;
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
                        infReceive.IDTypeReceive = string.IsNullOrEmpty(this.lkupTypeReceive.EditValue.ToString())?0: Convert.ToInt32(this.lkupTypeReceive.EditValue);
                        infReceive.PatientReceiveClinic = this.patientReceiveClinic;
                        infReceive.ShiftWork = this.shiftWork;
                        infReceive.CreateDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                        if (this.lkupTaiNanTT.EditValue == null || string.IsNullOrEmpty(this.lkupTaiNanTT.EditValue.ToString()))
                            infReceive.TNTTID = 0;
                        else
                            infReceive.TNTTID = Convert.ToInt32(this.lkupTaiNanTT.EditValue);
                        if (PatientReceiveBLL.InsPatientReceive(infReceive, ref sReferenceCode) == -2)
                        { return false; }
                        //Luu thong tin bao hiem yte
                        this.patientReceiveId = PatientReceiveBLL.GetPatientReceive(this.txtMabn.Text.Trim(), sReferenceCode, this.dtWorking);
                        if (this.patientReceiveId <= 0) return false;
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
                            infSugges.Check_ = 0;
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
            this.txtHoTen.Text = this.txtNgaySinh.Text = this.txtNamSinh.Text = this.txtTuoi.Text = this.txtDiaChi.Text = this.txtDienThoai.Text = this.txtEmail.Text = this.txtTienSu.Text = this.txtDiUng.Text = string.Empty;
            this.cbGioiTinh.SelectedIndex = -1;
            this.sImagePath = this.txtLydo.Text = this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNang.Text = this.txtCao.Text = string.Empty;
            this.dtService.Clear();
            this.dtServiceDetail.Clear();
            this.txtMaTQPXa.Text = this.txtMaTinh.Text = this.txtMaTinh01.Text = this.txtMaHuyen.Text = this.txtMaTinhHuyen.Text = this.txtMaPXa.Text = string.Empty;
            this.lkupTQPXa.EditValue = string.Empty;
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
            this.lbTileBHYT.Text = this.sNgayhen = string.Empty;
            this.txtHoTenCha.Text = this.txtHoTenMe.Text = this.txtNamSinhCha.Text = this.txtNamSinhMe.Text = string.Empty;
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
                this.txtHoTen.Text = this.txtNgaySinh.Text = this.txtNamSinh.Text = this.txtTuoi.Text = this.txtDiaChi.Text = this.txtDienThoai.Text = this.txtEmail.Text = this.txtTienSu.Text = this.txtDiUng.Text = string.Empty;
                this.cbGioiTinh.SelectedIndex = -1;
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
                this.lbTileBHYT.Text = this.sNgayhen = this.barcode = string.Empty;
                this.txtLoaiTuoi.SelectedIndex = -1;
                this.txtHoTenCha.Text = this.txtHoTenMe.Text = this.txtNamSinhCha.Text = this.txtNamSinhMe.Text =string.Empty;
                this.txtHoTen.Focus();
                this.lkDoituong.EditValue = 2;
                this.lkupTaiNanTT.EditValue = 0;
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
                this.chartControl1.Legend.Visible = false;
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

        private void frmTiepDon_KeyDown(object sender, KeyEventArgs e)
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
                            dtServiceDetail = SuggestedServiceReceiptBLL.DT_ChidinhPK(patientReceiveId, txtMabn.Text.Trim());
                            gridControl_Detail.DataSource = dtServiceDetail;
                            butSave.Enabled = false;
                            this.butNew.Enabled = true;
                            frmChiDinhDichVu frm = new frmChiDinhDichVu(patientReceiveId, txtMabn.Text.ToString(), sUserID, Int32.Parse(lkDoituong.EditValue.ToString()), string.Empty, 0, sReferenceCode, iPatientType, "KP0000", null, string.Empty, this.shiftWork, this.dtWorking);
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
                        frmChiDinhDichVu frm = new frmChiDinhDichVu(patientReceiveId, txtMabn.Text.ToString(), sUserID, Int32.Parse(lkDoituong.EditValue.ToString()), string.Empty, 0, sReferenceCode, iPatientType, "KP0000", null, string.Empty, this.shiftWork, this.dtWorking);
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
                    rptShow.Print();
                    //Reports rpt = new Reports.frmReportEditGeneral(rptShow, "MaVach", "Barcode");
                    //rpt.ShowDialog();
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

                this.dtService = ServicePriceBLL.DTListPrice_MapService(0, int.Parse(objectTemp), Convert.ToInt32(patientTypeTemp), "'KCB'", string.Empty);
                this.lkupCongKham.Properties.DataSource = this.dtService;
                this.lkupCongKham.Properties.DisplayMember = "ServiceName";
                this.lkupCongKham.Properties.ValueMember = "ServiceCode";
                this.bBHYT = false;
                this.lbTileBHYT.Text = this.lkDoituong.Text;
                this.lkupCongKham.Focus();

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
                        }
                    }
                }
            }
            catch { }
        }
        
        private void butListService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }
        
        private void ma_Validated(object sender, EventArgs e)
        {
            try
            {
                //if (iNew==1)
                //{
                //    CheckPatient();
                //}
            }
            catch { }
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

        private void GetHistoryPatient(string patientCodeTemp)
        {
            if (!this.reloadTreeview)
            {
                this.reloadTreeview = true;
                //this.dbTree_History.Nodes.Clear();
                //this.dbTree_History.RemoveGroup("Detail");
                this.gridControl_History.DataSource = null;
                List<PatientViewInf> lstHistory = PatientsBLL.ListHistoryForPatient(patientCodeTemp);
                //this.dbTree_History.SetLeafData("History", "Info", "RefID", 0, 0);
                //this.dbTree_History.DataSource = lstHistory;
                //this.dbTree_History.AddGroup("Detail", "RefID", "Title", "RefID", 0, 0);
                //this.dbTree_History.BuildTree();
                this.gridControl_History.DataSource = lstHistory;
                //this.gridView_History.Columns["CreateDate"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                this.gridView_History.Columns["Title"].Group();
                this.gridView_History.FocusedRowHandle = 0;
            }
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
                            XtraMessageBox.Show(sResult.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            try
            {
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
                this.lbTileBHYT.Text = string.Empty;
                this.txtMach.Text = this.txtNhietdo.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNang.Text = this.txtCao.Text = string.Empty;
                this.gridControl_History.DataSource = null;
                ///this.ClearBHYTInfo();
                this.lkDoituong.EditValue = 2;
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool CheckPatientReceive(string sPatientCode)
        {
            try
            {
                List<PatientReceiveInf> lst = PatientReceiveBLL.ListCheckPatient(sPatientCode);
                if (lst.Count > 0 && lst[0].CreateDate.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    XtraMessageBox.Show("Đề nghị kết thúc điều trị bệnh nhân trước khi tiếp đón mới! ", "Bệnh viện điện tử .NET");
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
                DataTable dttemp = PatientReceiveBLL.DTCheckExistPatient(this.txtHoTen.Text.TrimEnd(), this.txtNgaySinh.Text.TrimEnd(), this.cbGioiTinh.SelectedIndex.ToString(), txtNamSinh.Text.TrimEnd(), txtTuoi.Text.TrimEnd(), txtDiaChi.Text.TrimEnd());
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
                    XtraMessageBox.Show(" Cân nặng phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            try
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(patientReceiveId, txtMabn.Text.Trim());
                frm.ShowDialog();
            }
            catch { }
        }

        private void butSearchHen_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl_Appointment.DataSource = PatientAppointment_BLL.DTListAppointmentSearch(txtHen_MaBN.Text.Trim(), txtHen_HoTen.Text.Trim(), txtHen_Tuoi.Text.Trim(), txtHen_DienThoai.Text.Trim(), dtfrom.Text.Trim(), dtTo.Text.Trim());
            }
            catch { }
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
                List<ObjectInf> lstObject = ObjectBLL.ListObject(int.Parse(lkDoituong.EditValue.ToString()));
                this.lkupCongKham.Properties.DataSource = this.dtService;
                this.lkupCongKham.Properties.ValueMember = "ServiceCode";
                this.lkupCongKham.Properties.DisplayMember = "ServiceName";
                this.bBHYT = false;

                this.lbTileBHYT.Text = this.lkDoituong.Text.ToString();
                this.lkupCongKham.Focus();
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
        private void lkupTaiNanTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.cbIntroducer.Focus();
        }
        private void butPrintBarcode_Click_1(object sender, EventArgs e)
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
                    rptShow.Print();
                    //Reports rpt = new Reports.frmReportEditGeneral(rptShow, "MaVach", "Barcode");
                    //rpt.ShowDialog();
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

        private bool CheckReceiveOverRows1000()
        {
            List<PatientReceiveInf> listReceive = PatientReceiveBLL.ListPatientReceive(0);
            if (listReceive != null && listReceive.Count >= 1000)
                return true;
            else
                return false;
        }
        
    }
}