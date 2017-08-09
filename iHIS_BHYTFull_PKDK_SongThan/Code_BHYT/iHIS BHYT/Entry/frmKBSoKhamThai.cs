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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraRichEdit.API.Native;

namespace Ps.Clinic.Entry
{
    public partial class frmKBSoKhamThai : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCodeDoctor = string.Empty, medicalRecordCode = string.Empty;
        public MedicalRecord_ANCINF sokhamthai;
        private DateTime dtimeWorking = new DateTime();
        public frmKBSoKhamThai(string _employeeCodeDoctor, string _medicalRecordCode, DateTime _dtimeWorking, MedicalRecord_ANCINF _sokhamthai)
        {
            InitializeComponent();
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.medicalRecordCode = _medicalRecordCode;
            this.dtimeWorking = _dtimeWorking;
            this.sokhamthai = _sokhamthai;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtNgayKinhCuoiCung.Text.Trim()) && !string.IsNullOrEmpty(this.txtNgaySinhDuKien.Text.Trim()))
                {
                    if (Convert.ToDateTime(this.txtNgayKinhCuoiCung.Text.Trim()) > Convert.ToDateTime(this.txtNgaySinhDuKien.Text.Trim()))
                    {
                        XtraMessageBox.Show("Ngày dự kiến sinh không được nhỏ hơn ngày kinh cuối cùng.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.sokhamthai = new MedicalRecord_ANCINF();
                this.sokhamthai.MedicalRecordCode = this.medicalRecordCode;
                this.sokhamthai.TienSuSinhDe = this.txtTienSuSinhDe.Text.Trim();
                this.sokhamthai.NgayKinhCuoiCung = this.txtNgayKinhCuoiCung.Text.Trim();
                this.sokhamthai.TuanThai = this.txtTuanThai.Text.Trim();
                this.sokhamthai.NgaySinhDuKien = this.txtNgaySinhDuKien.Text.Trim();
                this.sokhamthai.LanCoThai = Convert.ToInt32(this.spLanCoThai.EditValue);
                this.sokhamthai.TrongLuongMe = this.txtTrongLuongMe.Text.Trim();
                this.sokhamthai.ChieuCaoMe = this.txtChieuCaoMe.Text.Trim();
                this.sokhamthai.HuyetAp = this.txtHuyetap.Text.Trim();
                this.sokhamthai.HuyetAp1 = this.txtHuyetap01.Text.Trim();
                this.sokhamthai.ChieuCaoTC = this.txtChieuCaoTC.Text.Trim();
                this.sokhamthai.VongBung = this.txtVongBung.Text.Trim();
                this.sokhamthai.KhungChau = this.txtKhungChau.Text.Trim();
                this.sokhamthai.ThieuMau = this.txtThieuMau.Text.Trim();
                this.sokhamthai.Protein = this.txtProtein.Text.Trim();
                this.sokhamthai.XNHIV = this.txtXetNghiemHIV.Text.Trim();
                this.sokhamthai.XNKhac = this.txtXNKhac.Text.Trim();
                this.sokhamthai.TienLuongDe = this.txtTienLuongDe.Text.Trim();
                this.sokhamthai.SoMuiTiem = Convert.ToInt32(this.spSoMuiTiem.EditValue);
                this.sokhamthai.UongVien = this.chkUongVien.Checked;
                this.sokhamthai.WorkDate = Convert.ToDateTime(this.dtimeWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                this.sokhamthai.EmployeeCode = this.employeeCodeDoctor;
                this.sokhamthai.TimThai = this.txtTimThai.Text.Trim();
                this.sokhamthai.NgoiThai = this.txtNgoiThai.Text.Trim();
                this.sokhamthai.GhiChu = this.txtGhiChu.Text.Trim();
                this.Close();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void txtTienSuSinhDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayKinhCuoiCung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTuanThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgaySinhDuKien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void spLanCoThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTrongLuongMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtChieuCaoMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetap01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtChieuCaoTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtVongBung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtKhungChau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThieuMau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtProtein_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtXetNghiemHIV.Focus();
        }

        private void txtXetNghiemHIV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtXNKhac.Focus();
        }

        private void txtXNKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTienLuongDe.Focus();
        }

        private void txtTienLuongDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void spSoMuiTiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkUongVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTimThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgoiThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtGhiChu.Focus();
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            this.ClearText();
            this.txtTienSuSinhDe.Focus();
        }
        private void ClearText()
        {
            this.txtTienSuSinhDe.Text = string.Empty;
            this.txtNgayKinhCuoiCung.Text = string.Empty;
            this.txtTuanThai.Text = string.Empty;
            this.txtNgaySinhDuKien.Text = string.Empty;
            this.spLanCoThai.EditValue = 1;
            this.txtTrongLuongMe.Text = string.Empty;
            this.txtChieuCaoMe.Text = string.Empty;
            this.txtHuyetap.Text = string.Empty;
            this.txtHuyetap01.Text = string.Empty;
            this.txtChieuCaoTC.Text = string.Empty;
            this.txtVongBung.Text = string.Empty;
            this.txtKhungChau.Text = string.Empty;
            this.txtThieuMau.Text = string.Empty;
            this.txtProtein.Text = string.Empty;
            this.txtXetNghiemHIV.Text = string.Empty;
            this.txtXNKhac.Text = string.Empty;
            this.txtTienLuongDe.Text = string.Empty;
            this.spSoMuiTiem.EditValue = 0;
            this.chkUongVien.Checked = false;
            this.txtTimThai.Text = string.Empty;
            this.txtNgoiThai.Text = string.Empty;
            this.txtGhiChu.Text = string.Empty;

        }
        private void butDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(" Bạn thật sự muốn hủy hồ sơ này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                if (MedicalRecord_BLL.DelMedicalRecord_ANC(this.medicalRecordCode) >= 1)
                {
                    XtraMessageBox.Show(" Hủy hồ sơ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearText();
                    this.sokhamthai = null;
                    this.txtTienSuSinhDe.Focus();
                }
            }
        }

        private void frmKBSoKhamThai_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.sokhamthai != null)
                {
                    this.txtTienSuSinhDe.Text = this.sokhamthai.TienSuSinhDe;
                    this.txtNgayKinhCuoiCung.Text = this.sokhamthai.NgayKinhCuoiCung;
                    this.txtTuanThai.Text = this.sokhamthai.TuanThai;
                    this.txtNgaySinhDuKien.Text = this.sokhamthai.NgaySinhDuKien;
                    this.spLanCoThai.EditValue = this.sokhamthai.LanCoThai;
                    this.txtTrongLuongMe.Text = this.sokhamthai.TrongLuongMe;
                    this.txtChieuCaoMe.Text = this.sokhamthai.ChieuCaoMe;
                    this.txtHuyetap.Text = this.sokhamthai.HuyetAp;
                    this.txtHuyetap01.Text = this.sokhamthai.HuyetAp1;
                    this.txtChieuCaoTC.Text = this.sokhamthai.ChieuCaoTC;
                    this.txtVongBung.Text = this.sokhamthai.VongBung;
                    this.txtKhungChau.Text = this.sokhamthai.KhungChau;
                    this.txtThieuMau.Text = this.sokhamthai.ThieuMau;
                    this.txtProtein.Text = this.sokhamthai.Protein;
                    this.txtXetNghiemHIV.Text = this.sokhamthai.XNHIV;
                    this.txtXNKhac.Text = this.sokhamthai.XNKhac;
                    this.txtTienLuongDe.Text = this.sokhamthai.TienLuongDe;
                    this.spSoMuiTiem.EditValue = this.sokhamthai.SoMuiTiem;
                    this.chkUongVien.Checked = this.sokhamthai.UongVien;
                    this.txtTimThai.Text = this.sokhamthai.TimThai;
                    this.txtNgoiThai.Text = this.sokhamthai.NgoiThai;
                    this.txtGhiChu.Text = this.sokhamthai.GhiChu;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.medicalRecordCode))
                    {
                        MedicalRecord_ANCINF obj = MedicalRecord_BLL.ObjMedicalRecord_ANC(this.medicalRecordCode);
                        this.txtTienSuSinhDe.Text = obj.TienSuSinhDe;
                        this.txtNgayKinhCuoiCung.Text = obj.NgayKinhCuoiCung;
                        this.txtTuanThai.Text = obj.TuanThai;
                        this.txtNgaySinhDuKien.Text = obj.NgaySinhDuKien;
                        this.spLanCoThai.EditValue = obj.LanCoThai;
                        this.txtTrongLuongMe.Text = obj.TrongLuongMe;
                        this.txtChieuCaoMe.Text = obj.ChieuCaoMe;
                        this.txtHuyetap.Text = obj.HuyetAp;
                        this.txtHuyetap01.Text = obj.HuyetAp1;
                        this.txtChieuCaoTC.Text = obj.ChieuCaoTC;
                        this.txtVongBung.Text = obj.VongBung;
                        this.txtKhungChau.Text = obj.KhungChau;
                        this.txtThieuMau.Text = obj.ThieuMau;
                        this.txtProtein.Text = obj.Protein;
                        this.txtXetNghiemHIV.Text = obj.XNHIV;
                        this.txtXNKhac.Text = obj.XNKhac;
                        this.txtTienLuongDe.Text = obj.TienLuongDe;
                        this.spSoMuiTiem.EditValue = obj.SoMuiTiem;
                        this.chkUongVien.Checked = obj.UongVien;
                        this.txtTimThai.Text = obj.TimThai;
                        this.txtNgoiThai.Text = obj.NgoiThai;
                        this.txtGhiChu.Text = obj.GhiChu;
                    }
                    else
                        this.ClearText();
                }
                this.txtTienSuSinhDe.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
    }
}