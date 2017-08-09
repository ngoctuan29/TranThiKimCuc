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
    public partial class frmCapNhatThongTinBN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty, sUserid = string.Empty;
        private string sReferenceCode = string.Empty;
        private Int32 iStatus = 0, iTraituyen = 0, iPatientType = 0, iCapcuu = 0;
        private decimal patientReceiveId = 0, dIdBHYT = 0;
        private string sImagePath = string.Empty;
        private string sMatheBHYT = string.Empty;
        private DateTime dtNgayKham;
        private bool bBHYT = false;
        private DateTime dtWorking = new DateTime();
        private DataTable tableService = new DataTable();
        public frmCapNhatThongTinBN(string _User, string _patientCode, DateTime _dtWorking)
        {
            InitializeComponent();
            this.sUserid = _User;
            this.txtSearchMabn.Text = _patientCode;
            this.patientCode = _patientCode;
            this.dtWorking = _dtWorking;
        }
        
        private void frmCapNhatThongTinBN_Load(object sender, EventArgs e)
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

                DataTable dtbProvincial = new DataTable();
                dtbProvincial = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.repProvincial.DataSource = dtbProvincial;
                this.repProvincial.DisplayMember = "ProvincialName";
                this.repProvincial.ValueMember = "ProvincialCode";

                this.lkupTinh.Properties.DataSource = dtbProvincial;
                this.lkupTinh.Properties.DisplayMember = "ProvincialName";
                this.lkupTinh.Properties.ValueMember = "ProvincialCode";

                CatalogDistrictBLL district = new CatalogDistrictBLL();
                DataTable dtbDistrict = new DataTable();
                dtbDistrict = district.DTListDistrict(string.Empty, string.Empty);
                this.repDistrict.DataSource = dtbDistrict;
                this.repDistrict.DisplayMember = "DistrictName";
                this.repDistrict.ValueMember = "DistrictCode";

                CatalogWardBLL ward = new CatalogWardBLL();
                DataTable dtbWard = new DataTable();
                dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                if (dtbWard.Rows.Count <= 0 || dtbWard == null)
                    dtbWard = ward.DTListWard(string.Empty, string.Empty, string.Empty);
                this.lkupTQPXa.Properties.DataSource = dtbWard;
                this.lkupTQPXa.Properties.DisplayMember = "WardName";
                this.lkupTQPXa.Properties.ValueMember = "WardCode";

                DataTable tableIntro = IntroducerBLL.DTIntroducer(string.Empty);
                foreach (DataRow row in tableIntro.Rows)
                    this.cboxIntroducer.Properties.Items.Add(row["IntroName"].ToString());
                this.repGridLKupEmployeeCodeDoctor.DataSource = EmployeeBLL.ListEmployee(string.Empty);
                this.repGridLKupEmployeeCodeDoctor.DisplayMember = "EmployeeName";
                this.repGridLKupEmployeeCodeDoctor.ValueMember = "EmployeeCode";
                this.txtSearchMabn.Focus();
                this.Enable(false);
                this.EnableBHYT(false);
                this.lbTileBHYT.Visible = false;
            }
            catch { }
        }

        public void LoadDataInfo()
        {
            this.txtLoaiTuoi.Properties.Items.Clear();
            this.txtLoaiTuoi.Properties.Items.AddRange(new string[] { "Năm", "Tháng", "Ngày", "Giờ" });

            this.cbgioitinh.Text = "";
            this.cbgioitinh.Properties.Items.Clear();
            this.cbgioitinh.Properties.Items.AddRange(new string[] { "Nữ", "Nam" });

            this.lkupNgheNghiep.Properties.DataSource = CareerBLL.DTCareer("");
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

            this.picPatient.ImageLocation = sImagePath;

        }

        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.patientReceiveId = decimal.Parse(this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, "RefID").ToString());
                this.patientCode = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, "PatientCode").ToString();
                this.GetInfoPatient(this.patientCode);
                this.fLoad_Luottiepdon();
                this.Enable(false);
                this.EnableBHYT(false);
                this.butEdit.Enabled = true;
                this.LoadServiceFor();
                if (this.iStatus == 2)
                    this.butUpdateReceive.Enabled = true;
                else
                    this.butUpdateReceive.Enabled = false;
            }
            catch { }
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

        public int Namsinh(string ngayvao, int ituoi, int iloai)
        {
            //int namht = (!string.IsNullOrEmpty(ngayvao)) ? int.Parse(ngayvao.Substring(6, 4)) : this.dtWorking.Year;
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
                this.txtNgaySinh.Text = "01" + "/" + this.dtWorking.Date.AddMonths(-tmp_thang).Month.ToString().PadLeft(2, '0') + "/" + iNamsinh.ToString();
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
                    case 2:
                        iNamsinh = namht - ituoi / 365;
                        break;
                    default:
                        iNamsinh = namht;
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

        private void Enable(bool b)
        {
            this.butNew.Enabled = !b;
            this.butEdit.Enabled = b;
            this.butSave.Enabled = b;
            this.butUndo.Enabled = b;
            this.butCancel.Enabled = b;
            this.butUpdateReceive.Enabled = b;

            this.butPrintBarcode.Enabled = b;
            this.ma.Properties.ReadOnly = true;
            this.ten.Properties.ReadOnly = !b;
            this.cbgioitinh.Properties.ReadOnly = !b;
            this.txtNgaySinh.Properties.ReadOnly = !b;
            this.txtNamSinh.Properties.ReadOnly = !b;
            this.txtTuoi.Properties.ReadOnly = !b;
            this.txtLoaiTuoi.Properties.ReadOnly = !b;
            this.diachi.Properties.ReadOnly = !b;
            this.dienthoai.Properties.ReadOnly = !b;
            this.email.Properties.ReadOnly = !b;
            this.lkDoituong.Properties.ReadOnly = !b;
            this.tiensu.Properties.ReadOnly = !b;
            this.diung.Properties.ReadOnly = !b;
            this.butChonhinhanh.Enabled = b;
            this.butCapture.Enabled = b;
            this.dtNgayVaoVien.Properties.ReadOnly = !b;
            this.lkPatientType.Properties.ReadOnly = true;
            this.txtTenCha.Properties.ReadOnly = !b;
            this.txtNamSinhCha.Properties.ReadOnly = !b;
            this.txtTenMe.Properties.ReadOnly = !b;
            this.txtNamSinhMe.Properties.ReadOnly = !b;

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
            this.memoNote.Properties.ReadOnly = !b;
            this.btnRelation.Enabled = b;
            this.cboxIntroducer.Properties.ReadOnly = !b;
            this.gridView_SuggestedReceipt.OptionsBehavior.Editable = !b;
        }

        private void EnableBHYT(bool b)
        {
            this.txtThe01.Properties.ReadOnly = this.txtThe02.Properties.ReadOnly = this.txtThe03.Properties.ReadOnly = this.txtThe04.Properties.ReadOnly = this.txtThe05.Properties.ReadOnly = this.txtThe06.Properties.ReadOnly = this.txtKCBBD.Properties.ReadOnly = !b;
            this.lkKCB.Properties.ReadOnly = !b;
            this.txtTheStart.Properties.ReadOnly = !b;
            this.txtNamSinhCha.Properties.ReadOnly = this.txtNamSinhMe.Properties.ReadOnly = this.txtTenCha.Properties.ReadOnly = this.txtTenMe.Properties.ReadOnly = !b;
            this.txtTheEnd.Properties.ReadOnly = !b;
            this.chkTraiTuyen.Properties.ReadOnly = this.chkGiayChuyenVien.Properties.ReadOnly = this.chkCapcuu.Properties.ReadOnly = !b;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.patientReceiveId = 0;
                this.iStatus = iPatientType = 0;
                this.lbstt.Text = string.Empty;
                this.lbTileBHYT.Text = string.Empty;
                this.ma.Text = this.txtSearchMabn.Text = string.Empty;
                this.ten.Text = this.txtNgaySinh.Text = this.txtNamSinh.Text = this.txtTuoi.Text = this.diachi.Text = this.dienthoai.Text = this.email.Text = this.tiensu.Text = this.diung.Text = string.Empty;
                this.cbgioitinh.SelectedIndex = txtLoaiTuoi.SelectedIndex = -1;
                this.lkDoituong.EditValue = null;
                this.lkKCB.EditValue = null;
                this.lkPatientType.EditValue = 0;
                this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = this.txtKCBBD.Text = string.Empty;
                this.txtTheStart.EditValue = this.txtTheEnd.EditValue = string.Empty;
                this.sImagePath = string.Empty;
                this.Enable(true);
                this.dtNgayKham = Utils.DateServer();
                this.txtMaTQPXa.Text = this.txtMaTinh.Text = this.txtMaTinh01.Text = this.txtMaHuyen.Text = this.txtMaTinhHuyen.Text = this.txtMaPXa.Text = string.Empty;
                this.memoNote.Text = string.Empty;
                this.lkupNgheNghiep.EditValue = null;
                this.LoadWard(string.Empty, string.Empty, string.Empty);
                this.lkupTinh.EditValue = null;
                this.lkupHuyen.EditValue = null;
                this.lkupPhuongXa.EditValue = null;
                this.txtSearchMabn.Focus();
                this.cboxIntroducer.Text = string.Empty;
                this.txtTenCha.Text = this.txtTenMe.Text = this.txtNamSinhCha.Text = this.txtNamSinhMe.Text = string.Empty;
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                picPatient.Image = (Bitmap)b;
                this.tableService = new DataTable();
                this.gridControl_SuggestedReceipt.DataSource = null;
            }
            catch
            {
                XtraMessageBox.Show("Lỗi tìm bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (this.SaveInfoReceive(ref message))
            {
                XtraMessageBox.Show(" Cập nhật thông tin bệnh nhân thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enable(false);
                this.EnableBHYT(false);
                this.butCapture.Enabled = true;
            }
            else
                XtraMessageBox.Show(message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (iStatus == 2)
                {
                    XtraMessageBox.Show(" Bệnh nhân kết thúc điều trị, không được phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    butNew.Focus();
                }
                else
                {
                    this.Enable(true);
                    if (lkDoituong.EditValue.ToString() == "1")
                        this.EnableBHYT(true);
                    this.butEdit.Enabled = false;
                    this.ten.Focus();
                }
            }
            catch { }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                Enable(false);
                EnableBHYT(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi xảy ra: " + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void fLoad_Luottiepdon()
        {
            try
            {
                List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(this.patientReceiveId);
                if (lstReceive.Count > 0)
                {
                    this.sReferenceCode = lstReceive[0].ReferenceCode;
                    this.Enable(false);
                    this.butEdit.Enabled = true;
                    this.lkDoituong.EditValue = lstReceive[0].ObjectCode;
                    this.iPatientType = lstReceive[0].PatientType;
                    this.lkPatientType.EditValue = iPatientType;
                    this.iStatus = lstReceive[0].Status;
                    this.dtNgayKham = lstReceive[0].CreateDate;
                    this.dtNgayVaoVien.Text = dtNgayKham.ToString("dd/MM/yyyy");
                    this.lkupNgheNghiep.EditValue = lstReceive[0].CareerCode;
                    this.lkupDanToc.EditValue = lstReceive[0].EThnicID;
                    this.lkupQuocTich.EditValue = lstReceive[0].NationalityID;
                    this.diachi.Text = lstReceive[0].Address;
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
                    this.cboxIntroducer.Text = lstReceive[0].IntroName;
                }
                else
                {
                    this.lkDoituong.EditValue = null;
                    this.lkPatientType.EditValue = null;
                    XtraMessageBox.Show("Bệnh nhân không tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveId);
                if (lstBHYT.Count > 0)
                {
                    dIdBHYT = lstBHYT[0].RowID;
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
                    this.chkCapcuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                    this.GetCardInfo();
                    this.LoadDKKCBBD(); //--23/07/2016
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
                        if (this.chkGiayChuyenVien.Checked || this.chkCapcuu.Checked)
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

        private void GetInfoPatient(string sPatient)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(sPatient, this.patientReceiveId);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    this.ma.Text = objPatient.PatientCode;
                    this.ten.Text = objPatient.PatientName;
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
                    this.diachi.Text = objPatient.PatientAddress;
                    this.dienthoai.Text = objPatient.PatientMobile;
                    this.email.Text = objPatient.PatientEmail;
                    this.tiensu.Text = objPatient.MedicalHistory;
                    this.diung.Text = objPatient.Allergy;

                    this.cbgioitinh.SelectedIndex = objPatient.PatientGender;
                    this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.txtNamSinh.Text = objPatient.PatientBirthyear.ToString();
                    //this.txtLoaiTuoi.SelectedIndex = string.IsNullOrEmpty(objPatient.PatientMonth) ? 1 : 0;
                    this.txtTenCha.Text = objPatient.TenCha;
                    if (objPatient.NSCha != 0)
                        this.txtNamSinhCha.Text = objPatient.NSCha.ToString();
                    else
                        this.txtNamSinhCha.Text = "";
                    this.txtTenMe.Text = objPatient.TenMe;
                    if (objPatient.NSMe != 0)
                        this.txtNamSinhMe.Text = objPatient.NSMe.ToString();
                    else
                        this.txtNamSinhMe.Text = "";

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

        private void butReload_Click(object sender, EventArgs e)
        {
            this.GetHistoryPatient(txtSearchMabn.Text.Trim());
        }

        private void GetHistoryPatient(string sPatient)
        {
            this.gridControl_Search.DataSource = PatientsBLL.ListHistoryForPatient(sPatient);
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
                if (string.IsNullOrEmpty(this.txtNamSinh.Text.Trim()))
                {
                    message = "Nhập năm sinh!";
                    this.txtNamSinh.Focus();
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
                if (Utils.DateServer() < Utils.StringToDate(this.dtNgayVaoVien.Text))
                {
                    message = "Ngày vào viện không được lớn hơn ngày hiện tại!";
                    this.dtNgayVaoVien.Focus();
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
                    if (txtNgaySinh.Text.Trim() != string.Empty)
                        infPatient.PatientBirthday = Utils.StringToDate(txtNgaySinh.Text.Trim());
                    else
                        infPatient.PatientBirthday = Utils.StringToDate("01/01/" + txtNamSinh.Text);
                    infPatient.PatientBirthyear = int.Parse(this.txtNamSinh.Text.Trim());
                    infPatient.PatientAge = (this.dtWorking.Year - int.Parse(this.txtNamSinh.Text.Trim()));// int.Parse(txtTuoi.Text.Trim());
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
                    infPatient.PatientMonth = this.txtLoaiTuoi.SelectedIndex == 0 ? string.Empty : this.txtTuoi.Text.Trim();
                    infPatient.TenCha = txtTenCha.Text;
                    if (txtNamSinhCha.Text.Trim() != "")
                        infPatient.NSCha = Convert.ToInt32(txtNamSinhCha.Text.Trim());
                    else
                        infPatient.NSCha = 0;
                    infPatient.TenMe = txtTenMe.Text;
                    if (txtNamSinhMe.Text.Trim() != "")
                        infPatient.NSMe = Convert.ToInt32(txtNamSinhMe.Text.Trim());
                    else
                        infPatient.NSMe = 0;

                    if (sImagePath != string.Empty)
                    {
                        fstr = new FileStream(sImagePath, FileMode.Open, FileAccess.Read);
                        imagedata = new byte[fstr.Length];
                        fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        infPatient.PatientImage = imagedata;
                    }
                    if (PatientsBLL.InsPatients(infPatient) == 1)
                    {
                        //Luu thong tin kham
                        PatientReceiveInf infReceive = new PatientReceiveInf();
                        infReceive.PatientReceiveID = this.patientReceiveId;
                        infReceive.PatientCode = ma.Text.Trim();
                        infReceive.EmployeeCode = sUserid;
                        infReceive.ObjectCode = int.Parse(this.lkDoituong.EditValue.ToString());
                        iPatientType = Convert.ToInt32(lkPatientType.EditValue);
                        infReceive.PatientType = iPatientType;
                        if (this.dtNgayVaoVien.Text.Trim() != string.Empty)
                            infReceive.CreateDate = Utils.StringToDateTime(this.dtNgayVaoVien.Text + " " + Utils.TimeServer());
                        else
                            infReceive.CreateDate = dtNgayKham;
                        infReceive.CareerCode = careerCode;
                        infReceive.EThnicID = ethnicID;
                        infReceive.NationalityID = nationalityID;
                        infReceive.ProvincialCode = provincialCode;
                        infReceive.DistrictCode = districtCode;
                        infReceive.WardCode = wardCode;
                        infReceive.CompanyInfo = memoNote.EditValue.ToString();
                        infReceive.IntroName = this.cboxIntroducer.Text;
                        infReceive.Address = this.diachi.Text.Trim();
                        PatientReceiveBLL.UpdPatientReceive(infReceive);
                        if (this.bBHYT)
                        {
                            sMatheBHYT = this.txtThe01.Text.Trim() + this.txtThe02.Text.Trim() + this.txtThe03.Text.Trim() + this.txtThe04.Text.Trim() + this.txtThe05.Text.Trim() + this.txtThe06.Text.Trim();
                            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(6);
                            iTraituyen = this.chkTraiTuyen.Checked ? 1 : 0;
                            iCapcuu = this.chkCapcuu.Checked ? 1 : 0;
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
                            infBHYT.PatientReceiveID = this.patientReceiveId;
                            infBHYT.TraiTuyen = iTraituyen;
                            infBHYT.Capcuu = iCapcuu;
                            infBHYT.Serial = this.sMatheBHYT;
                            infBHYT.ReferralPaper = this.chkGiayChuyenVien.Checked ? 1 : 0;
                            string str = this.txtKCBBD.Text.Trim();
                            str = str.Replace(" ", "");
                            infBHYT.KCBBDCodeFull = str;
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
                this.lkupNgheNghiep.Focus();
                this.lkupNgheNghiep.Show();
            }
        }

        private void ngaysinh_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNgaySinh.Text) || this.txtNgaySinh.Text == "__/__/____") return;
            this.txtNgaySinh.Text = this.txtNgaySinh.Text.Trim();
            if (!Utils.isDate(this.txtNgaySinh.Text))
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNgaySinh.Focus();
                return;
            }
            this.txtNgaySinh.Text = Utils.KiemTrangaygio(this.txtNgaySinh.Text, 10);
            if (!Utils.isDate(string.Empty, this.txtNgaySinh.Text))
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
                //this.txtLoaiTuoi.Focus();
            }
            catch { }
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

        private void namsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
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
        
        private void loaituoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtLoaiTuoi.SelectedIndex == -1) txtLoaiTuoi.SelectedIndex = 0;
                txtNamSinh.Text = Namsinh(string.Empty, int.Parse(txtTuoi.Text), txtLoaiTuoi.SelectedIndex).ToString();
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void diachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupTQPXa.Focus();
                this.lkupTQPXa.ShowPopup();
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
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.patientReceiveId, ma.Text.Trim());
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
                int iResut = PatientReceiveBLL.DelPatientReceive(this.patientReceiveId, this.patientCode);
                string sMsg = string.Empty;
                if (iResut == -1)
                    sMsg = "Bênh nhân đã làm xét nghiệm không được phép xóa.";
                else if (iResut == -2)
                    sMsg = "Bênh nhân đã làm cận lâm sàn không được phép xóa.";
                else if (iResut == -3)
                    sMsg = "Bênh nhân đã thực hiện khám bệnh không được phép xóa.";
                else if (iResut == -4)
                    sMsg = "Bênh nhân phát sinh chi phí hóa đơn không được phép xóa.";
                else if (iResut == -5)
                    sMsg = "Bênh nhân đã thực hiện thủ thuật không được phép xóa.";
                else
                    sMsg = "Xóa thành công tiếp nhận khám bệnh.";
                XtraMessageBox.Show(sMsg, "Bệnh viện điện tử .NET");
                if (iResut == 1)
                {
                    this.ClearText();
                    this.GetHistoryPatient(string.Empty);
                }
                //if()
            }
            catch { }
        }

        private void ClearText()
        {
            try
            {
                this.patientReceiveId = 0;
                iStatus  = iPatientType = 0;
                this.lbstt.Text = string.Empty;
                this.lbTileBHYT.Text = string.Empty;
                this.ma.Text = ten.Text = txtNgaySinh.Text = txtNamSinh.Text = txtTuoi.Text = diachi.Text = dienthoai.Text = email.Text = tiensu.Text = diung.Text = string.Empty;
                cbgioitinh.SelectedIndex = txtLoaiTuoi.SelectedIndex = -1;
                lkDoituong.EditValue = null;
                lkKCB.EditValue = null;
                this.ClearBHYTInfo();
                this.txtTheStart.EditValue = this.txtTheEnd.EditValue = this.txtNamSinhCha.EditValue = this.txtNamSinhMe.EditValue = this.txtTenCha.EditValue = this.txtTenMe.EditValue = string.Empty;
                sImagePath = string.Empty;
                Enable(false);
                ten.Focus();
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                picPatient.Image = (Bitmap)b;
            }
            catch
            {
                XtraMessageBox.Show("Lỗi tạo mới bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                this.txtMaHuyen.Text = tempDistrict;
                this.LoadWard(string.Empty, tempDistrict, this.txtMaTinh.Text);
                this.txtMaTinhHuyen.Text = tempDistrict;
            }
            catch { return; }
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
                this.lkupTQPXa.Focus();
                this.lkupTQPXa.ShowPopup();
            }
        }

        private void txtMaTQPXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.lkupTinh.Focus();
                this.lkupTinh.ShowPopup();
            }
        }

        private void lkupTQPXa_KeyDown(object sender, KeyEventArgs e)
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

        private void memoNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}"); 
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
                    this.dtNgayVaoVien.Focus();
            }
        }

        private void dtNgayVaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}"); 
        }

        private void LoadServiceFor()
        {
            this.tableService = SuggestedServiceReceiptBLL.TableListServiceFor(this.patientReceiveId, this.patientCode);
            this.gridControl_SuggestedReceipt.DataSource = this.tableService;
            //this.gridView_SuggestedReceipt.Columns["ServiceGroupName"].Group();
        }

        private void gridView_SuggestedReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show(" Bạn thật sự muốn xóa dịch vụ này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        decimal ReceiptID = Convert.ToDecimal(this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, this.colSugg_ReceiptID).ToString());
                        Int32 status = Convert.ToInt32(this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, this.colSugg_Status).ToString());
                        Int32 paid = Convert.ToInt32(this.gridView_SuggestedReceipt.GetRowCellValue(this.gridView_SuggestedReceipt.FocusedRowHandle, this.colSugg_Paid).ToString());
                        if (status == 0 && paid == 0)
                        {
                            string message = string.Empty;
                            int resuul = SuggestedServiceReceiptBLL.Del(ReceiptID, ref message);
                            XtraMessageBox.Show(message, "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadServiceFor();
                        }
                        else if (status == 1)
                        {
                            XtraMessageBox.Show("Dịch vụ đã thực hiện! Không được phép xóa.", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (paid == 1)
                        {
                            XtraMessageBox.Show("Dịch vụ đã thu phí! Không được phép xóa.", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch
            {
                return;
            }

        }

        private void butUpdateReceive_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(" Bạn thật sự muốn hủy kết thúc khám bệnh?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                int result = PatientReceiveBLL.UpdPatientForStatus(this.patientReceiveId, this.patientCode, 1);
                if (result > 0)
                {
                    XtraMessageBox.Show("Đã cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadServiceFor();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật không thành công! Vui lòng xem lại thông tin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void ClearBHYTInfo()
        {
            this.sMatheBHYT = this.txtThe01.Text = this.txtThe02.Text = this.txtThe03.Text = this.txtThe04.Text = this.txtThe05.Text = this.txtThe06.Text = string.Empty;
            this.txtKCBBD.Text = this.txtTheStart.Text = this.txtTheEnd.Text = this.txtNamSinhCha.Text = this.txtNamSinhMe.Text = this.txtTenCha.Text = this.txtTenMe.Text = string.Empty;
            this.lkKCB.EditValue = null;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = this.chkCapcuu.Checked = false;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtNamSinhMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNamSinhCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTenCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTenMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNamSinh_Validated(object sender, EventArgs e)
        {
            try
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
                }
            }
            catch { return; }
        }

        private void txtTuoi_Validated(object sender, EventArgs e)
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

        private void txtLoaiTuoi_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtTuoi.Text))
                this.txtNamSinh.Text = this.Namsinh(this.txtNgaySinh.Text, int.Parse(this.txtTuoi.Text), this.txtLoaiTuoi.SelectedIndex).ToString();
        }

        private void toolbutPrintService_Click(object sender, EventArgs e)
        {
            this.PrintServices();
            this.PrintServicesXN();
        }

        private void PrintServices()
        {
            try
            {
                DataTable dtClinic = new DataTable("ClinicInfo");
                dtClinic = ClinicInformationBLL.DT_Information(1);
                string sRowID = string.Empty;
                foreach (DataRow dr in this.tableService.Rows)
                {
                    if (dr["Check"].ToString() == "1")
                        sRowID += dr[0].ToString() + ",";
                }
                DataTable dtICD10kt = new DataTable();
                dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                string sICD10kt = MedicalRecord_BLL.DiagnosisEnclosed(string.Empty, this.patientReceiveId, this.iPatientType);
                if (sICD10kt != string.Empty)
                    dtICD10kt.Rows.Add(sICD10kt);
                DataTable tableHandPoint = new DataTable("SuggestedInfo");
                if (!string.IsNullOrEmpty(sRowID))
                    tableHandPoint = SuggestedServiceReceiptBLL.DT_Danhsachchidinh(this.patientReceiveId, this.patientCode, sRowID.TrimEnd(','), "", this.dtNgayVaoVien.Text, this.iPatientType, "CDHA,KCB,TC,TT,TD,NK");
                else
                    tableHandPoint = SuggestedServiceReceiptBLL.DT_Danhsachchidinh(this.patientReceiveId, this.patientCode, sRowID.TrimEnd(','), "", this.dtNgayVaoVien.Text, this.iPatientType, "CDHA,KCB,TC,TT,TD,NK");
                if (tableHandPoint != null && tableHandPoint.Rows.Count > 0)
                {
                    DataTable dtBHYT = new DataTable("BHYT");
                    dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveId);
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(tableHandPoint);
                    dsTemp.Tables.Add(dtICD10kt);
                    dsTemp.Tables.Add(dtBHYT);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptChidinh.xml");
                    if (this.lkDoituong.EditValue.Equals(1))
                    {
                        Reports.rptKB_Chidinh rpt = new Reports.rptKB_Chidinh();
                        rpt.DataSource = dsTemp;
                        rpt.ShowPreviewDialog();
                    }
                    else
                    {
                        Reports.rptKB_ChidinhDichVu rpt = new Reports.rptKB_ChidinhDichVu();
                        rpt.DataSource = dsTemp;
                        rpt.ShowPreviewDialog();
                    }
                }
            }
            catch { }
        }

        private void PrintServicesXN()
        {
            try
            {
                DataTable dtClinic = new DataTable("ClinicInfo");
                dtClinic = ClinicInformationBLL.DT_Information(1);
                string sRowID = string.Empty;
                foreach (DataRow dr in this.tableService.Rows)
                {
                    if (dr["Check"].ToString() == "1")
                        sRowID += dr[0].ToString() + ",";
                }
                DataTable dtICD10kt = new DataTable();
                dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                string sICD10kt = MedicalRecord_BLL.DiagnosisEnclosed(string.Empty, this.patientReceiveId, this.iPatientType);
                if (sICD10kt != string.Empty)
                    dtICD10kt.Rows.Add(sICD10kt);
                DataTable tableHandPoint = new DataTable("SuggestedInfo");
                if (!string.IsNullOrEmpty(sRowID))
                    tableHandPoint = SuggestedServiceReceiptBLL.DT_Danhsachchidinh(this.patientReceiveId, this.patientCode, sRowID.TrimEnd(','), "", this.dtNgayVaoVien.Text, this.iPatientType, "XN");
                else
                    tableHandPoint = SuggestedServiceReceiptBLL.DT_Danhsachchidinh(this.patientReceiveId, this.patientCode, sRowID.TrimEnd(','), "", this.dtNgayVaoVien.Text, this.iPatientType, "XN");
                if (tableHandPoint != null && tableHandPoint.Rows.Count > 0)
                {
                    DataTable dtBHYT = new DataTable("BHYT");
                    dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveId);
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(tableHandPoint);
                    dsTemp.Tables.Add(dtICD10kt);
                    dsTemp.Tables.Add(dtBHYT);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptChidinh.xml");
                    if (this.lkDoituong.EditValue.Equals(1))
                    {
                        Reports.rptKB_Chidinh rpt = new Reports.rptKB_Chidinh();
                        rpt.DataSource = dsTemp;
                        rpt.ShowPreviewDialog();
                    }
                    else
                    {
                        Reports.rptKB_ChidinhDichVu rpt = new Reports.rptKB_ChidinhDichVu();
                        rpt.DataSource = dsTemp;
                        rpt.ShowPreviewDialog();
                    }
                }
            }
            catch { }
        }

        private void toolbutSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in this.tableService.Rows)
                {
                    if (row["Check"].Equals(1))
                    {
                        SuggestedServiceReceiptBLL.UpdSuggestedForEmployeeDoctor(Convert.ToDecimal(row["ReceiptID"]), row["EmployeeCodeDoctor"].ToString());
                    }
                }
            }
            catch {
                XtraMessageBox.Show("Error: " + e.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public int Namsinh(string ngaysinh)
        {
            return int.Parse(ngaysinh.Substring(6, 4));
        }

    }
}