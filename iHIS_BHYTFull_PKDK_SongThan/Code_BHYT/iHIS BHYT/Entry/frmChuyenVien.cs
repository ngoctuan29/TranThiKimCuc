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

namespace Ps.Clinic.Entry
{
    public partial class frmChuyenVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty, sUserid = string.Empty;
        private string sReferenceCode = string.Empty;
        private Int32 iStatus = 0, iTraituyen = 0, iPatientType = 0;
        private decimal patientReceiveID = 0, dIdBHYT = 0;
        private string sImagePath = string.Empty;
        private string sMatheBHYT = string.Empty;
        private string symptoms = string.Empty;
        private DateTime dtNgayKham;
        private bool bBHYT = false;
        private string departmentCode = string.Empty, referenceCode = string.Empty, diagnosisCustom = string.Empty;
        private DateTime dtimeServer = new DateTime();
        private DateTime dtimePostingDatetime = new DateTime();
        private bool bEdit = false;
        private string employeeCodeDoctor = string.Empty;
        public frmChuyenVien(string _userCode, string _patientCode, decimal _patientReceiveID, string _departmentCode, DateTime _dtimePostingDatetime, string _symptoms, string _referenceCode, string _diagnosisCustom, string _employeeCodeDoctor)
        {
            InitializeComponent();
            this.sUserid = _userCode;
            this.patientCode = _patientCode;
            this.patientReceiveID = _patientReceiveID;
            this.departmentCode = _departmentCode;
            this.dtimePostingDatetime = _dtimePostingDatetime;
            this.symptoms = _symptoms;
            this.referenceCode = _referenceCode;
            this.diagnosisCustom = _diagnosisCustom;
            this.employeeCodeDoctor = _employeeCodeDoctor;
        }
        private void butExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        private void frmChuyenVien_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataInfo();
                this.lkDoituong.Properties.DataSource = ObjectBLL.DTObjectList(0);
                this.lkDoituong.Properties.DisplayMember = "ObjectName";
                this.lkDoituong.Properties.ValueMember = "ObjectCode";
                this.lkKCB.Properties.DataSource = KCBBDBLL.DTKCBBD_List(string.Empty);
                this.lkKCB.Properties.DisplayMember = "KCBBDName";
                this.lkKCB.Properties.ValueMember = "KCBBDCode";
                DataTable dtbProvincial = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.lkupTinh.Properties.DataSource = dtbProvincial;
                this.lkupTinh.Properties.DisplayMember = "ProvincialName";
                this.lkupTinh.Properties.ValueMember = "ProvincialCode";
                CatalogDistrictBLL district = new CatalogDistrictBLL();
                DataTable dtbDistrict = district.DTListDistrict(string.Empty, string.Empty);
                CatalogWardBLL ward = new CatalogWardBLL();
                DataTable dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                if (dtbWard.Rows.Count <= 0 || dtbWard == null)
                    dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                this.EnableInfoPatient(false);
                this.EnableBHYT(false);
                this.dtimeServer = Utils.DateTimeServer();
                this.GetTransferPatietnDetail();
                if (this.iStatus == 2)
                    this.butEdit.Enabled = false;
                else
                    this.butEdit.Enabled = true;
                this.dtFromDate.EditValue = this.dtToDate.EditValue = this.dtimeServer;
                this.ListSearchTransfer();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadDataInfo()
        {
            this.cbgioitinh.Text = string.Empty;
            this.cbgioitinh.Properties.Items.Clear();
            this.cbgioitinh.Properties.Items.AddRange(new string[] { "Nữ", "Nam" });

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

            this.lkPatientType.Properties.DataSource = PatientsBLL.DT_PatientType();
            this.lkPatientType.Properties.DisplayMember = "TypeName";
            this.lkPatientType.Properties.ValueMember = "RowID";
            this.picPatient.ImageLocation = this.sImagePath;

        }
        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.patientReceiveID = Convert.ToDecimal(this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.colsearch_PatientReceiveID).ToString());
                this.patientCode = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.colsearch_PatientCode).ToString();
                this.GetTransferPatietnDetail();
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                int d1 = this.dtimeServer.Day;
                int m1 = this.dtimeServer.Month;
                int y1 = this.dtimeServer.Year;
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
        private string onlyso(string s)
        {
            string ret = "", s1 = " 0123456789";
            for (int i = 0; i < s.Length; i++)
                if (s1.IndexOf(s.Substring(i, 1)) != -1) ret += s.Substring(i, 1);
            return ret;
        }
        public string Ktngaygio(string s, int len)
        {
            try
            {
                string s1 = onlyso(s);
                if (len == 10)
                    return s1.Substring(0, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(2, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(4).Trim().PadLeft(4, '0');
                else
                    return s1.Substring(0, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(2, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(4, 4).Trim().PadLeft(4, '0') + " " + s1.Substring(9, 2).Trim().PadLeft(2, '0') + ":" + s1.Substring(11, 2).Trim().PadLeft(2, '0');
            }
            catch { return s; }
        }
        public string Tuoivao(string ngayvao, string ngaysinh)
        {
            string tuoi = "";
            int namht = this.dtimeServer.Year;
            int thanght = this.dtimeServer.Month;
            int ngayht = this.dtimeServer.Day;
            int gioht = this.dtimeServer.Hour;

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
            if (nam == namht)
            {
                if (thang == thanght)
                {
                    if (ngay == ngayht) tuoi = "3/" + (gioht - gio);
                    else tuoi = "2/" + (ngayht - ngay);
                }
                else tuoi = "1/" + (thanght - thang);
            }
            else tuoi = "0/" + (namht - nam);
            return tuoi;
        }
        public string Tuoivao_thang(string ngayvao, string ngaysinh, string namsinh)
        {
            string tuoi = "";
            int namht = this.dtimeServer.Year;
            int thanght = this.dtimeServer.Month;
            int ngayht = this.dtimeServer.Day;
            int gioht = this.dtimeServer.Hour;

            if (!string.IsNullOrEmpty(ngayvao))
            {
                namht = int.Parse(ngayvao.Substring(6, 4));
                thanght = int.Parse(ngayvao.Substring(3, 2));
                ngayht = int.Parse(ngayvao.Substring(0, 2));
                gioht = (ngayvao.Length > 10) ? int.Parse(ngayvao.Substring(11, 2)) : this.dtimeServer.Hour;
            }
            if (ngaysinh.Trim() == "")
            {
                int inam = int.Parse(namsinh);
                if (namht - inam <= 6) tuoi = "1/" + ((namht - inam) * 12);
                else tuoi = "0/" + (namht - inam);
                return tuoi;
            }
            int nam = int.Parse(ngaysinh.Substring(6, 4));
            int thang = int.Parse(ngaysinh.Substring(3, 2));
            int ngay = int.Parse(ngaysinh.Substring(0, 2));
            int gio = (ngaysinh.Length > 10) ? int.Parse(ngaysinh.Substring(11, 2)) : 0;

            int sothang = 0;
            if (nam >= namht - 6)
            {
                sothang = (namht - nam) * 12;
                if (thang == thanght && sothang == 0)
                {
                    if (ngay == ngayht) tuoi = "3/" + (gioht - gio);
                    else tuoi = "2/" + (ngayht - ngay);
                }
                else if (thang <= thanght && sothang > 0)
                {
                    tuoi = "1/" + (sothang + thanght - thang);
                }
                else if (thang < thanght && sothang > 0)
                {
                    tuoi = "1/" + (sothang - 12 + thang);
                }
            }
            else tuoi = "0/" + (namht - nam);
            return tuoi;
        }
        public int Namsinh(string ngaysinh)
        {
            return int.Parse(ngaysinh.Substring(6, 4));
        }
        public int Namsinh(string ngayvao, int ituoi, int iloai)
        {
            int namht = (!string.IsNullOrEmpty(ngayvao)) ? int.Parse(ngayvao.Substring(6, 4)) : this.dtimeServer.Year;
            int iNamsinh = 0;
            if (iloai == 1 && ituoi <= 12)
            {
                if (bNgay(this.dtimeServer.Day.ToString().PadLeft(2, '0') + "/" + ituoi.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0'), this.dtimeServer.Day.ToString().PadLeft(2, '0') + "/" + this.dtimeServer.Month.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0')))
                    iNamsinh = namht - 1;
                else iNamsinh = namht;
            }
            else if (iloai == 1 && ituoi <= 72)
            {
                int tmp_tuoi = ituoi / 12;
                int tmp_thang = ituoi - (tmp_tuoi * 12);
                if (bNgay(this.dtimeServer.Day.ToString().PadLeft(2, '0') + "/" + tmp_thang.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0'), this.dtimeServer.Day.ToString().PadLeft(2, '0') + "/" + this.dtimeServer.Month.ToString().PadLeft(2, '0') + "/" + namht.ToString().PadLeft(4, '0')))
                    iNamsinh = namht - tmp_tuoi - 1;
                else iNamsinh = namht - tmp_tuoi;
            }
            else
            {
                switch (iloai)
                {
                    case 0: iNamsinh = namht - ituoi;
                        break;
                    case 1: iNamsinh = namht - ituoi / 12;
                        break;
                    case 2: iNamsinh = namht - ituoi / 365;
                        break;
                    default: iNamsinh = namht;
                        break;
                }
            }
            return iNamsinh;
        }
        public string Caps(string s)
        {
            if (s.Length == 0) return null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(s);//.ToLower());
            sb[0] = Char.ToUpper(sb[0]);
            string ret = null;
            int num = 0; int ispace = 0;
            while (num < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[num])) ispace++;
                if (!Char.IsWhiteSpace(sb[num]))
                {
                    if (ispace > 0 && num > 0)
                    {
                        sb[num] = Char.ToUpper(sb[num]);
                        ispace = 0;
                    }
                }
                num++;
            }
            num = 0;
            ispace = 0;
            while (num < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[num]))
                {
                    if (ispace < 1 && num > 0) ret += sb[num];
                    ispace++;
                }
                else
                {
                    ret += sb[num];
                    ispace = 0;
                }
                num++;
            }
            return ret;
        }
        private void EnableInfoPatient(bool b)
        {
            this.ma.Properties.ReadOnly = true;
            this.ten.Properties.ReadOnly = !b;
            this.cbgioitinh.Properties.ReadOnly = !b;
            this.ngaysinh.Properties.ReadOnly = !b;
            this.namsinh.Properties.ReadOnly = !b;
            this.tuoi.Properties.ReadOnly = !b;
            this.txtThang.Properties.ReadOnly = !b;
            this.diachi.Properties.ReadOnly = !b;
            this.dienthoai.Properties.ReadOnly = !b;
            this.email.Properties.ReadOnly = !b;
            this.lkDoituong.Properties.ReadOnly = !b;
            this.tiensu.Properties.ReadOnly = !b;
            this.diung.Properties.ReadOnly = !b;
            this.butCapture.Enabled = !b;
            this.txtNgayVao.ReadOnly = !b;
            this.txtGioVao.ReadOnly = !b;
            this.txtNgayKham.ReadOnly = !b;
            this.txtGioKham.ReadOnly = !b;
            this.lkPatientType.Properties.ReadOnly = true;

            this.lkupNgheNghiep.Properties.ReadOnly = !b;
            this.lkupDanToc.Properties.ReadOnly = !b;
            this.lkupQuocTich.Properties.ReadOnly = !b;
            this.txtMaTinh.Properties.ReadOnly = !b;
            this.lkupTinh.Properties.ReadOnly = !b;
            this.txtMaHuyen.Properties.ReadOnly = !b;
            this.lkupHuyen.Properties.ReadOnly = !b;
            this.txtMaPXa.Properties.ReadOnly = !b;
            this.lkupPhuongXa.Properties.ReadOnly = !b;
            this.btnRelation.Enabled = !b;
        }
        private void EnableBHYT(bool b)
        {
            this.txtThe01.Properties.ReadOnly = this.txtThe02.Properties.ReadOnly = this.txtThe03.Properties.ReadOnly = this.txtThe04.Properties.ReadOnly = this.txtThe05.Properties.ReadOnly = this.txtThe06.Properties.ReadOnly = this.txtKCBBD.Properties.ReadOnly = !b;
            this.lkKCB.Properties.ReadOnly = !b;
            this.txtTheStart.Properties.ReadOnly = !b;
            this.txtTheEnd.Properties.ReadOnly = !b;
            this.chkTraiTuyen.Properties.ReadOnly = this.chkGiayChuyenVien.Properties.ReadOnly = !b;
        }
        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.patientReceiveID = 0;
                this.iStatus = iPatientType = 0;
                this.lbstt.Text = string.Empty;
                this.lbTileBHYT.Text = string.Empty;
                this.ma.Text = string.Empty;
                this.ten.Text = this.ngaysinh.Text = this.namsinh.Text = this.tuoi.Text = this.diachi.Text = this.dienthoai.Text = this.email.Text = this.tiensu.Text = this.diung.Text = string.Empty;
                this.cbgioitinh.SelectedIndex = -1;
                this.lkDoituong.EditValue = null;
                this.lkKCB.EditValue = null;
                this.lkPatientType.EditValue = 0;
                this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = this.txtKCBBD.Text = this.txtNgayKham.Text = this.txtNgayVao.Text = this.txtGioVao.Text = this.txtGioKham.Text = string.Empty;
                this.txtTheStart.EditValue = this.txtTheEnd.EditValue = string.Empty;
                this.sImagePath = string.Empty;
                this.EnableInfoPatient(true);
                this.dtNgayKham = Utils.DateServer();
                this.lkupNgheNghiep.EditValue = null;
                this.LoadWard(string.Empty, string.Empty, string.Empty);
                this.lkupTinh.EditValue = null;
                this.lkupHuyen.EditValue = null;
                this.lkupPhuongXa.EditValue = null;
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
                this.patientReceiveID = -1;
                this.patientCode = this.departmentCode = this.symptoms = this.referenceCode = this.diagnosisCustom = this.employeeCodeDoctor = string.Empty;
                this.txtTenBenhVien.Text = this.txtDHLamSang.Text = this.txtCLSThucHien.Text = this.txtChanDoan.Text = this.txtThuocDaDung.Text = this.txtTinhTrangLucCV.Text = this.txtLyDoChuyen.Text = this.txtSoChuyenVien.Text = this.txtSoLuuTru.Text = this.txtPhuongTienCV.Text = this.txtHoTenNguoiCV.Text = string.Empty;
                this.chkDirector.Checked = this.chkPatient.Checked = false;
                this.dtimeServer = Utils.DateTimeServer();
                this.txtNgayChuyen.Text = this.dtimeServer.ToString("dd/MM/yyyy");
                this.txtGioChuyen.Text = this.dtimeServer.ToString("HH:mm");
            }
            catch
            {
                XtraMessageBox.Show("Lỗi tìm bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;
                if (this.bEdit)
                    this.SaveInfoReceive(ref message);
                if (this.SaveTransfer())
                {
                    XtraMessageBox.Show("Lưu trữ hồ sơ chuyển viện thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ListSearchTransfer();
                    this.butSave.Enabled = this.butUndo.Enabled = false;
                    this.butPrint.Enabled = this.butCancel.Enabled = this.butEdit.Enabled = this.butNew.Enabled = true;
                }
                else
                    XtraMessageBox.Show("Hồ sơ chuyển viện lưu không thành công! \r\n Vui lòng xem lại thông tin chuyển viện.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.iStatus == 2)
                {
                    XtraMessageBox.Show(" Bệnh nhân kết thúc điều trị, không được phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.butNew.Focus();
                }
                else
                {
                    this.bEdit = true;
                    this.EnableInfoPatient(true);
                    if (this.lkDoituong.EditValue.ToString() == "1")
                        this.EnableBHYT(true);
                    this.butEdit.Enabled = false;
                    this.butUndo.Enabled = true;
                    this.ten.Focus();
                }
            }
            catch { }
        }
        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.EnableInfoPatient(false);
                this.EnableBHYT(false);
                this.butUndo.Enabled = this.butSave.Enabled = this.butCancel.Enabled = false;
                this.butNew.Enabled = this.butEdit.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void GetLuottiepdon()
        {
            try
            {
                List<PatientReceiveInf> lstReceive = new List<PatientReceiveInf>();
                lstReceive = PatientReceiveBLL.ListPatientReceive(this.patientReceiveID);
                if (lstReceive.Count > 0)
                {
                    this.sReferenceCode = lstReceive[0].ReferenceCode;
                    this.EnableInfoPatient(false);
                    this.butEdit.Enabled = true;
                    this.lkDoituong.EditValue = lstReceive[0].ObjectCode;
                    this.iPatientType = lstReceive[0].PatientType;
                    this.lkPatientType.EditValue = iPatientType;
                    this.iStatus = lstReceive[0].Status;
                    this.dtNgayKham = lstReceive[0].CreateDate;
                    this.txtNgayVao.Text = this.dtNgayKham.ToString("dd/MM/yyyy");
                    this.txtGioVao.Text = this.dtNgayKham.ToString("HH:mm");
                    this.lkupNgheNghiep.EditValue = lstReceive[0].CareerCode;
                    this.lkupDanToc.EditValue = lstReceive[0].EThnicID;
                    this.lkupQuocTich.EditValue = lstReceive[0].NationalityID;
                    this.diachi.Text = lstReceive[0].Address;
                    this.txtMaTinh.Text = this.txtMaTinh01.Text = lstReceive[0].ProvincialCode;
                    this.lkupTinh.EditValue = lstReceive[0].ProvincialCode;
                    if (!string.IsNullOrEmpty(lstReceive[0].DistrictCode))
                        this.txtMaHuyen.Text = lstReceive[0].DistrictCode.Substring(3, 2);
                    else
                        this.txtMaHuyen.Text = string.Empty;
                    this.txtMaTinhHuyen.Text = lstReceive[0].DistrictCode;
                    this.lkupHuyen.EditValue = lstReceive[0].DistrictCode;
                    if (!string.IsNullOrEmpty(lstReceive[0].WardCode))
                        this.txtMaPXa.Text = lstReceive[0].WardCode.Substring(5, 2);
                    else
                        this.txtMaPXa.Text = string.Empty;
                    this.lkupPhuongXa.EditValue = lstReceive[0].WardCode;
                }
                else
                {
                    this.lkDoituong.EditValue = null;
                    this.lkPatientType.EditValue = null;
                    XtraMessageBox.Show("Bệnh nhân không tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<BHYTInf> lstBHYT = new List<BHYTInf>();
                lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                if (lstBHYT.Count > 0)
                {
                    dIdBHYT = lstBHYT[0].RowID;
                    this.txtThe01.Text = lstBHYT[0].Serial01;
                    this.txtThe02.Text = lstBHYT[0].Serial02;
                    this.txtThe03.Text = lstBHYT[0].Serial03;
                    this.txtThe04.Text = lstBHYT[0].Serial04;
                    this.txtThe05.Text = lstBHYT[0].Serial05;
                    this.txtThe06.Text = lstBHYT[0].Serial06;
                    this.txtKCBBD.Text = lstBHYT[0].KCBBDCodeFull;
                    this.lkKCB.EditValue = lstBHYT[0].KCBBDCode;
                    this.txtTheStart.EditValue = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                    this.txtTheEnd.EditValue = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                    this.lbstt.Text = lstBHYT[0].Serial.Length.ToString();
                    this.iTraituyen = lstBHYT[0].TraiTuyen;
                    this.chkTraiTuyen.Checked = lstBHYT[0].TraiTuyen == 1 ? true : false;
                    this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                    this.GetCardInfo();
                }
                else
                {
                    this.dIdBHYT = 0;
                    this.ClearBHYTInfo();
                    this.lkKCB.EditValue = null;
                    this.txtTheStart.EditValue = null;
                    this.txtTheEnd.EditValue = null;
                    this.lbTileBHYT.Text = this.lkDoituong.Text;
                }
            }
            catch { }
        }
        private void GetCardInfo()
        {
            try
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
        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    this.ma.Text = objPatient.PatientCode;
                    this.ten.Text = objPatient.PatientName;
                    this.tuoi.Text = objPatient.PatientAge.ToString();
                    this.diachi.Text = objPatient.PatientAddress;
                    this.dienthoai.Text = objPatient.PatientMobile;
                    this.email.Text = objPatient.PatientEmail;
                    this.tiensu.Text = objPatient.MedicalHistory;
                    this.diung.Text = objPatient.Allergy;

                    this.cbgioitinh.SelectedIndex = objPatient.PatientGender;
                    this.ngaysinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.namsinh.Text = objPatient.PatientBirthyear.ToString();
                    //this.txtLoaiTuoi.SelectedIndex = 0;
                    if (objPatient.IDTypeReceive != 0)
                        this.lkPatientType.EditValue = objPatient.IDTypeReceive;
                    else
                        this.lkPatientType.EditValue = 1;
                    this.lkupNgheNghiep.EditValue = objPatient.CareerCode;
                    this.lkupDanToc.EditValue = objPatient.EThnicID;
                    this.lkupQuocTich.EditValue = objPatient.NationalityID;
                    this.txtThang.Text = objPatient.PatientMonth;
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
                    objPatient = PatientsBLL.ObjPatients(this.patientCode, 0);
                    this.ma.Text = objPatient.PatientCode;
                    this.ten.Text = objPatient.PatientName;
                    this.tuoi.Text = objPatient.PatientAge.ToString();
                    this.diachi.Text = objPatient.PatientAddress;
                    this.dienthoai.Text = objPatient.PatientMobile;
                    this.email.Text = objPatient.PatientEmail;
                    this.tiensu.Text = objPatient.MedicalHistory;
                    this.diung.Text = objPatient.Allergy;

                    this.cbgioitinh.SelectedIndex = objPatient.PatientGender;
                    this.ngaysinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.namsinh.Text = objPatient.PatientBirthyear.ToString();
                    //this.txtLoaiTuoi.SelectedIndex = 0;
                    if (objPatient.IDTypeReceive != 0)
                        this.lkPatientType.EditValue = objPatient.IDTypeReceive;
                    else
                        this.lkPatientType.EditValue = 1;
                    this.lkupNgheNghiep.EditValue = objPatient.CareerCode;
                    this.lkupDanToc.EditValue = objPatient.EThnicID;
                    this.lkupQuocTich.EditValue = objPatient.NationalityID;
                    this.txtThang.Text = objPatient.PatientMonth;
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
        private bool SaveInfoReceive(ref string message)
        {
            try
            {               
                if (this.ma.Text.Trim().Length != 8)
                {                    
                    message = "Mã bệnh nhân không hợp lệ !";
                    this.ma.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(this.ten.Text.Trim()))
                {
                    message = "Nhập họ tên bệnh nhân !";
                    this.ten.Focus();
                    return false;
                }
                if (this.cbgioitinh.SelectedIndex == -1)
                {
                    message = "Chọn giới tính!";
                    this.cbgioitinh.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(this.namsinh.Text.Trim()))
                {
                    message = "Nhập năm sinh!";
                    this.namsinh.Focus();
                    return false;
                }
                if (this.lkupNgheNghiep.EditValue == null)
                {
                    message = "Chọn nghề nghiệp!";
                    this.lkupNgheNghiep.Focus();
                    return false;
                }
                if (this.lkupDanToc.EditValue == null)
                {
                    message = "Chọn dân tộc!";
                    this.lkupDanToc.Focus();
                    return false;
                }
                if (this.lkupQuocTich.EditValue == null)
                {
                    message = "Chọn quốc tịch!";
                    this.lkupQuocTich.Focus();
                    return false;
                }
                if (lkPatientType.EditValue.ToString() == "0")
                {
                    message = "Chọn loại bệnh nhân khi tiếp nhận!";
                    this.lkPatientType.Focus();
                    return false;
                }
                if (bBHYT)
                {
                    if (this.txtThe01.Text.Trim() == string.Empty)
                    {
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
                    Int32 lengthBHYT = (this.txtThe01.Text.Trim().Length + this.txtThe02.Text.Trim().Length + this.txtThe03.Text.Trim().Length + this.txtThe04.Text.Trim().Length + this.txtThe05.Text.Trim().Length + this.txtThe06.Text.Trim().Length);
                    this.lbstt.Text = lengthBHYT.ToString();
                    if (!lengthBHYT.Equals(15))
                    {
                        message = "Kiểm tra lại mã thẻ, chiều dài thẻ không hợp lệ!";
                        this.txtThe01.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.lkKCB.EditValue.ToString()))
                    {
                        message = "Chưa chọn nơi đăng lý KCB ban đầu!";
                        this.lkKCB.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtTheStart.Text.ToString()))
                    {
                        message = "Chưa nhập ngày bắt đầu hưởng BHYT!";
                        this.txtTheStart.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.txtTheEnd.Text.ToString()))
                    {
                        message = "Chưa nhập ngày hết hạn thẻ BHYT!";
                        this.txtTheEnd.Focus();
                        return false;
                    }
                }
                if (this.lkDoituong.EditValue == null)
                {
                    message = "Xin vui lòng chọn đối tượng bệnh nhân khi tiếp đón!";
                    this.lkDoituong.Focus();
                    return false;
                }
                if (Utils.DateServer() < Utils.StringToDate(this.txtNgayKham.Text))
                {
                    message = "Ngày vào viện không được lớn hơn ngày hiện tại!";
                    this.txtNgayKham.Focus();
                    return false;
                }
                else
                {
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
                    infPatient.PatientCode = ma.Text.Trim();
                    infPatient.PatientName = ten.Text.Trim();
                    infPatient.PatientGender = cbgioitinh.EditValue.ToString() == "Nam" ? 1 : 0;
                    if (ngaysinh.Text.Trim() != string.Empty)
                        infPatient.PatientBirthday = Utils.StringToDate(ngaysinh.Text.Trim());
                    else
                        infPatient.PatientBirthday = Utils.StringToDate("01/01/" + namsinh.Text);
                    infPatient.PatientBirthyear = int.Parse(namsinh.Text.Trim());
                    infPatient.PatientAge = int.Parse(tuoi.Text.Trim());
                    infPatient.PatientAddress = diachi.Text.Trim();
                    infPatient.PatientMobile = dienthoai.Text.Trim();
                    infPatient.PatientEmail = email.Text.Trim();
                    infPatient.MedicalHistory = tiensu.Text.Trim();
                    infPatient.Allergy = diung.Text.Trim();
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
                    infPatient.PatientMonth = this.txtThang.Text.Trim();
                    infPatient.IDTypeReceive = Convert.ToInt32(this.lkPatientType.EditValue);
                    if (PatientsBLL.InsPatients(infPatient) == 1)
                    {
                        //Luu thong tin kham
                        PatientReceiveInf infReceive = new PatientReceiveInf();
                        infReceive.PatientReceiveID = this.patientReceiveID;
                        infReceive.PatientCode = ma.Text.Trim();
                        infReceive.EmployeeCode = sUserid;
                        infReceive.ObjectCode = int.Parse(this.lkDoituong.EditValue.ToString());
                        iPatientType = Convert.ToInt32(lkPatientType.EditValue);
                        infReceive.PatientType = iPatientType;
                        //if (this.dtNgayVaoVien.Text.Trim() != string.Empty)
                            //infReceive.CreateDate = Utils.StringToDateTime(this.dtNgayVaoVien.Text + " " + Utils.TimeServer());
                        //else
                            //infReceive.CreateDate = dtNgayKham;
                        infReceive.CareerCode = careerCode;
                        infReceive.EThnicID = ethnicID;
                        infReceive.NationalityID = nationalityID;
                        infReceive.ProvincialCode = provincialCode;
                        infReceive.DistrictCode = districtCode;
                        infReceive.WardCode = wardCode;
                        //infReceive.CompanyInfo = memoNote.EditValue.ToString();
                        //infReceive.IntroName = this.cboxIntroducer.Text;
                        infReceive.Address = this.diachi.Text.Trim();
                        PatientReceiveBLL.UpdPatientReceive(infReceive);
                        if (this.bBHYT)
                        {
                            sMatheBHYT = this.txtThe01.Text.Trim() + this.txtThe02.Text.Trim() + this.txtThe03.Text.Trim() + this.txtThe04.Text.Trim() + this.txtThe05.Text.Trim() + this.txtThe06.Text.Trim();
                            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(6);
                            iTraituyen = this.chkTraiTuyen.Checked ? 1 : 0;
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
                            infBHYT.PatientCode = this.ma.Text.Trim();
                            infBHYT.KCBBDCode = this.lkKCB.EditValue.ToString();
                            infBHYT.StartDate = Utils.StringToDate(this.txtTheStart.Text.Trim());
                            infBHYT.EndDate = Utils.StringToDate(this.txtTheEnd.Text.Trim());
                            infBHYT.Hide = 0;
                            infBHYT.EmployeeCode = this.sUserid;
                            infBHYT.PatientReceiveID = this.patientReceiveID;
                            infBHYT.TraiTuyen = iTraituyen;
                            infBHYT.Serial = this.sMatheBHYT;
                            infBHYT.ReferralPaper = this.chkGiayChuyenVien.Checked ? 1 : 0;
                            infBHYT.KCBBDCodeFull = this.txtKCBBD.Text.Trim();
                            BHYTBLL.InsBHYT(infBHYT);
                        }
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception ex)
            {
                message = " Save fail: " + ex.Message;
                return false;
            }
        }
        private void ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }
        private void cbgioitinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void ngaysinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void ngaysinh_Validated(object sender, EventArgs e)
        {
            if (this.ngaysinh.Text == "" || this.ngaysinh.Text == "__/__/____") return;
            this.ngaysinh.Text = this.ngaysinh.Text.Trim();
            if (!Utils.isDate(this.ngaysinh.Text))
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ngaysinh.Focus();
                return;
            }
            this.ngaysinh.Text = Utils.KiemTrangaygio(this.ngaysinh.Text, 10);
            if (!Utils.isDate("", this.ngaysinh.Text))
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ngaysinh.Focus();
                return;
            }
            try
            {
                this.TuoiBenhNhan(string.Empty, this.ngaysinh.Text);
                if (int.Parse(this.ngaysinh.Text) > 130)
                {
                    XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ngaysinh.Focus();
                    return;
                }
                if ((string.IsNullOrEmpty(this.tuoi.Text) && string.IsNullOrEmpty(this.txtThang.Text)) || (this.tuoi.Text.Equals(0) && this.txtThang.Text.Equals(0)))
                {
                    XtraMessageBox.Show("Vui lòng nhập năm sinh của bệnh nhân!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ngaysinh.Focus();
                    return;
                }
                this.lkupNgheNghiep.Focus();
                this.lkupNgheNghiep.Show();
            }
            catch { }
        }
        private void TuoiBenhNhan(string ngayvao, string ngaysinh)
        {
            int namht = DateTime.Now.Year;
            int thanght = DateTime.Now.Month;
            int ngayht = DateTime.Now.Day;
            int gioht = DateTime.Now.Hour;

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
            if (yyyy <= 5)
            {
                DateTime dtNgaySinh = Convert.ToDateTime(this.ngaysinh.Text.Trim());
                var sothang = this.dtNgayKham.Month - dtNgaySinh.Month + 12 * (this.dtNgayKham.Year - dtNgaySinh.Year);
                int yy = sothang / 12;
                int mm = sothang % 12;
                //this.lbNamSinh.Text = yy + " tuổi " + mm + " tháng.";
                this.txtThang.Text = mm.ToString().PadLeft(2, '0');
                this.tuoi.Text = yy.ToString().PadLeft(2, '0');
            }
            else
            {
                //this.lbNamSinh.Text = yyyy + " tuổi ";
                this.tuoi.Text = yyyy.ToString().PadLeft(2, '0');
                this.txtThang.Text = "00";
            }
            this.namsinh.Text = this.Namsinh(this.ngaysinh.Text).ToString();
        }
        private void namsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (!string.IsNullOrEmpty(this.namsinh.Text))
                {
                    if (int.Parse(this.namsinh.Text) > this.dtimeServer.Year)
                    {
                        XtraMessageBox.Show("Năm sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.namsinh.Focus();
                        return;
                    }
                    if (this.namsinh.Text.Length < 4)
                        this.namsinh.Text = Convert.ToString(this.dtimeServer.Year - int.Parse(this.namsinh.Text));
                    this.tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(this.namsinh.Text)).PadLeft(2, '0');
                    if (int.Parse(this.tuoi.Text) > 130)
                    {
                        XtraMessageBox.Show("Năm sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.namsinh.Focus();
                        return;
                    }
                    if (this.tuoi.Text == "00" && this.txtThang.Text == "00")
                    {
                        XtraMessageBox.Show("Kiểm tra lại ngày sinh bệnh nhân.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ngaysinh.Focus();
                        return;
                    }
                }
                //SendKeys.Send("{Tab}{F4}");
                this.lkupNgheNghiep.Focus();
            }
        }

        private void namsinh_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.namsinh.Text))
                {
                    if (int.Parse(namsinh.Text) > this.dtNgayKham.Year)
                    {
                        XtraMessageBox.Show("Năm sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net");
                        namsinh.Focus();
                        return;
                    }
                    if (namsinh.Text.Length < 4)
                        namsinh.Text = Convert.ToString(this.dtNgayKham.Year - int.Parse(namsinh.Text));
                    this.tuoi.Text = Convert.ToString(this.dtNgayKham.Year - int.Parse(namsinh.Text)).PadLeft(2, '0');
                    this.txtThang.Text = "00";
                    this.ngaysinh.Text = "01/01/" + namsinh.Text;
                    this.TuoiBenhNhan(string.Empty, this.ngaysinh.Text);
                    if (int.Parse(this.tuoi.Text) > 150)
                    {
                        XtraMessageBox.Show("Năm sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net");
                        this.namsinh.Focus();
                        return;
                    }
                    if (this.tuoi.Text == "00" && this.txtThang.Text == "00")
                    {
                        XtraMessageBox.Show("Kiểm tra lại ngày sinh bệnh nhân.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.namsinh.Focus();
                        return;
                    }
                }
            }
            catch { return; }
        }

        private void tuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.tuoi.Text != string.Empty)
                {
                    this.namsinh.Text = this.Namsinh(this.dtNgayKham.ToString("dd/MM/yyyy"), int.Parse(this.tuoi.Text), 0).ToString();
                    this.ngaysinh.Text = "01/01/" + this.namsinh.Text;
                    this.lkupNgheNghiep.Focus();
                    this.lkupNgheNghiep.Show();
                }
                else
                {
                    XtraMessageBox.Show("Yêu cầu nhập tuổi vào !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tuoi.Focus();
                    return;
                }
            }
        }

        private void tuoi_Validated(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(tuoi.Text) == 0 && this.tuoi.Text.Trim() == "")
                {
                    this.namsinh.Text = (this.dtNgayKham.Year - int.Parse(this.tuoi.Text)).ToString();
                    //this.txtNgaySinh.Text = "01/01/" + (this.dtNgayKham.Year - int.Parse(txtTuoi.Text)).ToString();
                    this.ngaysinh.Focus();
                }
                else this.diachi.Focus();
            }
            catch { this.ngaysinh.Focus(); }
        }
        
        private void diachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //this.lkupTQPXa.Focus();
                //this.lkupTQPXa.ShowPopup();
            }
        }

        private void dienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}"); 
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}");
        }

        private void tiensu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}");
        }

        private void ten_Validated(object sender, EventArgs e)
        {
            this.ten.Text = ten.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+');
            this.ten.Text = Caps(this.ten.Text);
        }

        private void diachi_Validated(object sender, EventArgs e)
        {
            diachi.Text = diachi.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+');
            diachi.Text = Caps(diachi.Text);
        }

        private void diung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void lkPatientType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkDoituong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                List<ObjectInf> lstObject = new List<ObjectInf>();
                lstObject = ObjectBLL.ListObject(int.Parse(lkDoituong.EditValue.ToString()));
                if (lstObject[0].ObjectCard == 1)
                {
                    bBHYT = true;
                    EnableBHYT(true);
                    lbstt.Enabled = true;
                    if (this.txtThe06.Text.Trim().Length == 5)
                        this.GetCardInfo();
                }
                else
                {
                    bBHYT = false;
                    EnableBHYT(false);
                    lbTileBHYT.Text = lkDoituong.Text.ToString();
                }
                lbTileBHYT.Visible = true;
            }
            catch { }
        }

        private void txtThe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }
                
        private void lkKCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}"); 
        }

        private void chkTraiTuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void chkTraiTuyen_CheckedChanged(object sender, EventArgs e)
        {
            this.GetCardInfo();
        }

        private void txtTheStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void txtTheEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void butCapture_Click(object sender, EventArgs e)
        {
            try
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.patientReceiveID, ma.Text.Trim());
                frm.ShowDialog();
            }
            catch { }
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

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(" Bạn thật sự muốn hủy hồ sơ chuyển viện? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    if (HospitalTransferBLL.DelTransfer(this.patientReceiveID) >= 1)
                    {
                        this.ListSearchTransfer();
                        this.butNew_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ClearText()
        {
            try
            {
                this.patientReceiveID = 0;
                iStatus  = iPatientType = 0;
                this.lbstt.Text = string.Empty;
                this.lbTileBHYT.Text = string.Empty;
                this.ma.Text = ten.Text = ngaysinh.Text = namsinh.Text = tuoi.Text = diachi.Text = dienthoai.Text = email.Text = tiensu.Text = diung.Text = this.txtThang.Text = string.Empty;
                cbgioitinh.SelectedIndex = -1;// loaituoi.SelectedIndex = -1;
                lkDoituong.EditValue = null;
                lkKCB.EditValue = null;
                this.ClearBHYTInfo();
                txtTheStart.EditValue = txtTheEnd.EditValue = string.Empty;
                sImagePath = string.Empty;
                this.EnableInfoPatient(false);
                ten.Focus();
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                picPatient.Image = (Bitmap)b;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupTQPXa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //string tempMaTQPXa = this.lkupTQPXa.EditValue.ToString();
                //this.txtMaTQPXa.Text = tempMaTQPXa;
                //this.txtMaTinh.Text = this.txtMaTinh01.Text = tempMaTQPXa.Substring(0, 3);
                //this.txtMaHuyen.Text = tempMaTQPXa.Substring(3, 2);
                //this.lkupTinh.EditValue = tempMaTQPXa.Substring(0, 3);
                //this.lkupHuyen.EditValue = tempMaTQPXa.Substring(0, 5);
                //this.txtMaTinhHuyen.Text = tempMaTQPXa.Substring(0, 5);
                //this.lkupPhuongXa.EditValue = tempMaTQPXa;
                //this.txtMaPXa.Text = tempMaTQPXa.Substring(5, 2);
                this.dienthoai.Focus();
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message); }
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
                this.lkupTinh.EditValue = provincialCode;
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

        private void txtMaTQPXa_Validated(object sender, EventArgs e)
        {
            try
            {
                //if (this.txtMaTQPXa.Text.Trim().Length > 0)
                //{
                //    string tempMaTQPXa = this.txtMaTQPXa.Text;
                //    this.txtMaTQPXa.Text = tempMaTQPXa;
                //    this.txtMaTinh.Text = this.txtMaTinh01.Text = tempMaTQPXa.Substring(0, 3);
                //    this.txtMaHuyen.Text = tempMaTQPXa.Substring(3, 2);
                //    this.lkupTQPXa.EditValue = tempMaTQPXa;
                //    this.LoadProvincial(txtMaTQPXa.Text);
                //    this.LoadDistrict(this.txtMaTinh.Text, string.Empty);
                //    this.LoadWard(string.Empty, string.Empty, this.txtMaTinh.Text);
                //}
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

        private void lkupTinh_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtMaTinh.Text = this.txtMaTinh01.Text = this.lkupTinh.EditValue.ToString();
                this.LoadDistrict(string.Empty, this.txtMaTinh.Text);
                this.LoadWard(string.Empty, string.Empty, this.txtMaTinh.Text);
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

        private void lkupHuyen_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tempDistrict = this.lkupHuyen.EditValue.ToString();
                this.txtMaHuyen.Text = tempDistrict.Substring(3, 2);
                this.LoadWard(string.Empty, tempDistrict, this.txtMaTinh.Text);
                this.txtMaTinhHuyen.Text = tempDistrict;
            }
            catch { return; }
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            if (ma.Text.Trim().Length > 0)
            {
                frmRelationPatient frm = new frmRelationPatient(this.patientReceiveID, sUserid, ma.Text.Trim());
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để khai báo thông tin gia đình!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void namsinh_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lkupNgheNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupDanToc.Focus();
                this.lkupDanToc.ShowPopup();
            }
        }

        private void lkupDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupQuocTich.Focus();
                this.lkupQuocTich.ShowPopup();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupQuocTich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //this.lkupTQPXa.Focus();
                //this.lkupTQPXa.ShowPopup();
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

        private void lkupHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupPhuongXa.Focus();
                this.lkupPhuongXa.ShowPopup();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtMaTinhHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtMaPXa.Focus();
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

        private void lkupPhuongXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }
        
        private void lkDoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.lkDoituong.EditValue.ToString() == "1")
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    SendKeys.Send("{Tab}");
            }
            else
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    this.txtNgayVao.Focus();
            }
        }
        
        private void LoadServiceTransfer()
        {
            DataTable tableService = SuggestedServiceReceiptBLL.TableListServiceFor(this.patientReceiveID, this.patientCode);
            DataTable tbServiceLab = new DataTable();
            DataTable tbServiceRad = new DataTable();
            int countLab = tableService.Select("ServiceModuleCode='XN'").Count();
            int countRad = tableService.Select("ServiceModuleCode='CDHA'").Count();
            if (countLab > 0)
                tbServiceLab = tableService.Select("ServiceModuleCode='XN'").CopyToDataTable();
            if (countRad > 0)
                tbServiceRad = tableService.Select("ServiceModuleCode='CDHA'").CopyToDataTable();
            string resultRad = string.Empty, resultLab = string.Empty;
            if (tbServiceLab != null && tbServiceLab.Rows.Count>0)
            {
                foreach (DataRow row in tbServiceLab.Rows)
                {
                    resultLab += row["ServiceName"].ToString() + ",";
                }
            }
            if (tbServiceRad != null && tbServiceRad.Rows.Count > 0)
            {
                foreach (DataRow row in tbServiceRad.Rows)
                {
                    resultRad += row["ServiceName"].ToString() + ",";
                }
            }
            this.txtCLSThucHien.Text = resultLab.TrimEnd(',') + "\r\n" + resultRad.TrimEnd(',');
        }

        private void LoadDrugTransfer()
        {
            DataTable tableMedicalRecord = MedicalRecord_BLL.DTMedicalRecordOld(this.referenceCode);
            string content = string.Empty;
            if (tableMedicalRecord != null && tableMedicalRecord.Rows.Count > 0)
            {
                foreach (DataRow row in tableMedicalRecord.Rows)
                {
                    content += row["ItemName"].ToString() + "(" + row["Quantity"].ToString() + " " + row["UnitOfMeasureName"].ToString() + " ), ";
                }
            }
            this.txtThuocDaDung.Text = content.TrimEnd(',');
        }

        private void ClearBHYTInfo()
        {
            this.sMatheBHYT = this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = string.Empty;
            this.txtKCBBD.Text = this.txtTheStart.Text = this.txtTheEnd.Text = string.Empty;
            this.lkKCB.EditValue = null;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = false;
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

        private void txtKCBBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.lkKCB.Focus();
        }

        private void txtTenBenhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtDHLamSang.Focus();
        }

        private void txtDHLamSang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtCLSThucHien.Focus();
        }

        private void txtCLSThucHien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtChanDoan.Focus();
        }

        private void txtChanDoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtThuocDaDung.Focus();
        }

        private void txtThuocDaDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTinhTrangLucCV.Focus();
        }

        private void txtTinhTrangLucCV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTinhTrangLucCV.Focus();
        }

        private void txtLyDoChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNgayChuyen.Focus();
        }

        private void txtNgayChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtGioChuyen.Focus();
        }

        private void txtSoLuuTru_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtSoLuuTru.Focus();
        }

        private void txtSoChuyenVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtPhuongTienCV.Focus();
        }

        private void txtPhuongTienCV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtHoTenNguoiCV.Focus();
        }
        
        private void butPrintBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.patientCode))
                {
                    DataTable dtPatient = new DataTable("InfoPatient");
                    dtPatient = PatientsBLL.DTPatients(this.patientCode);
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtPatient);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBarCode.xml");
                    //Reports.rptBarCode barcode = new Reports.rptBarCode();
                    //barcode.DataSource = dsTemp;
                    //barcode.Print();
                    Reports.rptBarCode rptShow = new Reports.rptBarCode();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "MaVach","Mã vạch");
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

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void GetTransferPatient()
        {
            try
            {
                this.gridControl_Search.DataSource = null;
                //this.gridControl_Search.DataSource = PatientsBLL.ListHistoryForPatient(sPatient);
            }
            catch { }
        }
        private void butSearch_Click(object sender, EventArgs e)
        {
            this.ListSearchTransfer();
        }
        private void ListSearchTransfer()
        {
            this.gridControl_Search.DataSource = HospitalTransferBLL.TableTransfer(this.dtFromDate.Text, this.dtToDate.Text);
        }
        private void GetTransferPatietnDetail()
        {
            this.GetInfoPatient();
            this.GetLuottiepdon();
            HospitalTransferINF inf = HospitalTransferBLL.ObjTransfer(this.patientReceiveID);
            if (inf == null || inf.PatientReceiveID <= 0)
            {
                this.LoadServiceTransfer();
                this.LoadDrugTransfer();
                this.txtDHLamSang.Text = this.symptoms;
                this.txtChanDoan.Text = this.diagnosisCustom;
                this.txtNgayChuyen.Text = this.dtimeServer.ToString("dd/MM/yyyy");
                this.txtGioChuyen.Text = this.dtimeServer.ToString("HH:mm");
                this.txtSoLuuTru.Text = this.patientCode;
                this.butNew.Enabled = this.butSave.Enabled = true;
                this.butPrint.Enabled = this.butCancel.Enabled = false;
            }
            else
            {
                this.txtTenBenhVien.Text = inf.HospitalTransfer;
                this.txtDHLamSang.Text = inf.Symptoms;
                this.txtCLSThucHien.Text = inf.LabResult;
                this.txtChanDoan.Text = inf.DiagnosisCustom;
                this.txtThuocDaDung.Text = inf.DrugUsed;
                this.txtTinhTrangLucCV.Text = inf.Result;
                this.txtLyDoChuyen.Text = inf.Reason;
                this.txtNgayChuyen.Text = inf.DateTransfer;
                this.txtGioChuyen.Text = inf.HourTransfer;
                this.txtSoLuuTru.Text = inf.NumberSave;
                this.txtSoChuyenVien.Text = inf.NumberTransfer;
                this.txtPhuongTienCV.Text = inf.TransferExpediency;
                this.txtHoTenNguoiCV.Text = inf.TransferFullName;
                this.chkDirector.Checked = inf.DirectorApproval == 1 ? true : false;
                this.chkPatient.Checked = inf.PatientApproval == 1 ? true : false;
                this.butNew.Enabled = this.butSave.Enabled = this.butPrint.Enabled = this.butCancel.Enabled = true;
            }
            this.txtNgayKham.Text = this.dtimePostingDatetime.ToString("dd/MM/yyyy");
            this.txtGioKham.Text = this.dtimePostingDatetime.ToString("HH:mm");
        }
        private bool SaveTransfer()
        {
            HospitalTransferINF inf = new HospitalTransferINF();
            inf.HospitalTransfer = this.txtTenBenhVien.Text.Trim().ToUpper();
            inf.PatientReceiveID = this.patientReceiveID;
            inf.ObjectCode = Convert.ToInt32(this.lkDoituong.EditValue);
            inf.DepartmentCode = this.departmentCode;
            inf.DateIn = this.txtNgayVao.Text.Trim();
            inf.HourIn = this.txtGioVao.Text.Trim();
            inf.DateMedical = this.txtNgayKham.Text.Trim();
            inf.HourMedical = this.txtGioKham.Text.Trim();
            inf.Symptoms = this.txtDHLamSang.Text.Trim();
            inf.LabResult = this.txtCLSThucHien.Text.Trim();
            inf.DiagnosisCustom = this.txtChanDoan.Text.Trim();
            inf.DrugUsed = this.txtThuocDaDung.Text.Trim();
            inf.ReferenceCode = this.referenceCode;
            inf.Result = Utils.ToUpperCharacterFisrtString(this.txtTinhTrangLucCV.Text);
            inf.Reason = Utils.ToUpperCharacterFisrtString(this.txtLyDoChuyen.Text);
            inf.DateTransfer = this.txtNgayChuyen.EditValue.ToString();
            inf.HourTransfer = this.txtGioChuyen.Text;
            inf.NumberSave = this.txtSoLuuTru.Text;
            inf.NumberTransfer = this.txtSoChuyenVien.Text;
            inf.EmployeeCode = this.sUserid;
            inf.TransferExpediency = Utils.ToUpperCharacterFisrtString(this.txtPhuongTienCV.Text);
            inf.TransferFullName = Utils.ToUpperCharacterFisrt(this.txtHoTenNguoiCV.Text.Trim());
            inf.DirectorApproval = this.chkDirector.Checked ? 1 : 0;
            inf.PatientApproval = this.chkPatient.Checked ? 1 : 0;
            inf.EmployeeCodeDoctor = this.employeeCodeDoctor;
            inf.WorkDate = this.dtimeServer;
            inf.PatientAddress = this.diachi.Text + ", " + this.lkupPhuongXa.Text + ", " + this.lkupHuyen.Text + ", " + this.lkupTinh.Text;
            inf.Serial01 = this.txtThe01.Text;
            inf.Serial02 = this.txtThe02.Text;
            inf.Serial03 = this.txtThe03.Text;
            inf.Serial04 = this.txtThe04.Text;
            inf.Serial05 = this.txtThe05.Text;
            inf.Serial06 = this.txtThe06.Text;
            inf.FromDate = this.txtTheStart.Text;
            inf.ToDate = this.txtTheEnd.Text;
            bool bResult = HospitalTransferBLL.InsTransfer(inf);
            if (bResult)
                PatientReceiveBLL.UpdPatientForStatus(this.patientReceiveID, this.patientCode, 2);
            return bResult;
        }
        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableHandPoint = HospitalTransferBLL.DTPrintTrransfer(this.patientReceiveID);
                if (tableHandPoint != null && tableHandPoint.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(tableHandPoint);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptGiayCV.xml");
                    Reports.rpt_KB_GiayCV_A4 rptShow = new Reports.rpt_KB_GiayCV_A4();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "GiayChuyenTuyen","Giấy chuyển viện");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}