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
    public partial class frmKBSoDe : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCode = string.Empty, medicalRecordCode = string.Empty;
        public MedicalRecord_ChildbirthINF sode;
        private DateTime dtimeWorking = new DateTime();
        public frmKBSoDe(string _employeeCode, string _medicalRecordCode, DateTime _dtimeWorking, MedicalRecord_ChildbirthINF _sode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.medicalRecordCode = _medicalRecordCode;
            this.dtimeWorking = _dtimeWorking;
            this.sode = _sode;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.sode = new MedicalRecord_ChildbirthINF();
                this.sode.MedicalRecordCode = this.medicalRecordCode;
                this.sode.EmployeeCode = this.employeeCode;
                this.sode.QLThai = this.txtQLThai.Text.Trim();
                this.sode.TiemUV = this.txtUV.Text.Trim();
                this.sode.KT3Lan = this.chk3lan.Checked;
                this.sode.KT4Lan = this.chk4lan.Checked;
                this.sode.XNHIVMangThai = this.txtXNHIVMangThai.Text.Trim();
                this.sode.XNHIVChuyenDa = this.txtXNHIVChuyenDa.Text.Trim();
                this.sode.SLDeDuThang = Convert.ToInt32(this.spSLDeDuThang.EditValue);
                this.sode.SLDeNon = Convert.ToInt32(this.spSLDeNon.EditValue);
                this.sode.SLPhaThai = Convert.ToInt32(this.spSLXayThai.EditValue);
                this.sode.SLConHienTai = Convert.ToInt32(this.spSoCon.EditValue);
                this.sode.CachThucDe = this.txtCachThucDe.Text.Trim();
                this.sode.TaiBienMac = this.chkTaiBienMac.Checked ? 1 : 0;
                this.sode.TaiBienTV = this.chkTaiBienTV.Checked ? 1 : 0;
                this.sode.CanNang = this.txtCanNang.Text.Trim();
                this.sode.GioiTinh = this.rdNu.Checked ? 0 : 1;
                this.sode.TinhTrangCon = this.txtTinhTrangCon.Text.Trim();
                this.sode.TVThaiNhi = this.txtTVThaiNhi.Text.Trim();
                this.sode.NguoiDoDe = this.txtNguoiDoDe.Text.Trim();
                this.sode.BuGioDau = this.txtBuGioDau.Text.Trim();
                this.sode.TiemViataminK1 = this.chkVitaminK1.Checked;
                this.sode.TiemVXViemGanB = this.chkViemGanB.Checked;
                this.sode.KhamTuanDau = this.txtKhamTuanDau.Text.Trim();
                this.sode.KhamSauDe = this.txtKhamSauDe.Text.Trim();
                this.sode.GhiChu = this.txtGhiChu.Text.Trim();
                this.sode.WorkDate = Convert.ToDateTime(this.dtimeWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
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
        
        private void butClear_Click(object sender, EventArgs e)
        {
            this.ClearText();
            this.txtQLThai.Focus();
        }
        
        private void frmKBSoDe_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.sode != null)
                {
                    this.txtQLThai.Text = this.sode.QLThai;
                    this.txtUV.Text = this.sode.TiemUV;
                    this.chk3lan.Checked = this.sode.KT3Lan;
                    this.chk4lan.Checked = this.sode.KT4Lan;
                    this.txtXNHIVMangThai.Text = this.sode.XNHIVMangThai;
                    this.txtXNHIVChuyenDa.Text = this.sode.XNHIVChuyenDa;
                    this.spSLDeDuThang.EditValue = this.sode.SLDeDuThang;
                    this.spSLDeNon.EditValue = this.sode.SLDeNon;
                    this.spSLXayThai.EditValue = this.sode.SLPhaThai;
                    this.spSoCon.EditValue = this.sode.SLConHienTai;
                    this.txtCachThucDe.Text = this.sode.CachThucDe;
                    this.chkTaiBienMac.Checked = this.sode.TaiBienMac == 1 ? true : false;
                    this.chkTaiBienTV.Checked = this.sode.TaiBienTV == 1 ? true : false;
                    this.txtCanNang.Text = this.sode.CanNang;
                    this.rdNu.Checked = this.sode.GioiTinh == 0 ? true : false;
                    this.rdNam.Checked = this.sode.GioiTinh == 1 ? true : false;
                    this.txtTinhTrangCon.Text = this.sode.TinhTrangCon;
                    this.txtTVThaiNhi.Text = this.sode.TVThaiNhi;
                    this.txtNguoiDoDe.Text = this.sode.NguoiDoDe;
                    this.txtBuGioDau.Text = this.sode.BuGioDau;
                    this.chkVitaminK1.Checked = this.sode.TiemViataminK1;
                    this.chkViemGanB.Checked = this.sode.TiemVXViemGanB;
                    this.txtKhamTuanDau.Text = this.sode.KhamTuanDau;
                    this.txtKhamSauDe.Text = this.sode.KhamSauDe;
                    this.txtGhiChu.Text = this.sode.GhiChu;
                }
                else
                {   
                    if (!string.IsNullOrEmpty(this.medicalRecordCode))
                    {
                        MedicalRecord_ChildbirthINF obj = MedicalRecord_BLL.ObjMedicalRecord_Childbirth(this.medicalRecordCode);
                        this.txtQLThai.Text = obj.QLThai;
                        this.txtUV.Text = obj.TiemUV;
                        this.chk3lan.Checked = obj.KT3Lan;
                        this.chk4lan.Checked = obj.KT4Lan;
                        this.txtXNHIVMangThai.Text = obj.XNHIVMangThai;
                        this.txtXNHIVChuyenDa.Text = obj.XNHIVChuyenDa;
                        this.spSLDeDuThang.EditValue = obj.SLDeDuThang;
                        this.spSLDeNon.EditValue = obj.SLDeNon;
                        this.spSLXayThai.EditValue = obj.SLPhaThai;
                        this.spSoCon.EditValue = obj.SLConHienTai;
                        this.txtCachThucDe.Text = obj.CachThucDe;
                        this.chkTaiBienMac.Checked = obj.TaiBienMac == 1 ? true : false;
                        this.chkTaiBienTV.Checked = obj.TaiBienTV == 1 ? true : false;
                        this.txtCanNang.Text = obj.CanNang;
                        this.rdNu.Checked = obj.GioiTinh == 0 ? true : false;
                        this.rdNam.Checked = obj.GioiTinh == 1 ? true : false;
                        this.txtTinhTrangCon.Text = obj.TinhTrangCon;
                        this.txtTVThaiNhi.Text = obj.TVThaiNhi;
                        this.txtNguoiDoDe.Text = obj.NguoiDoDe;
                        this.txtBuGioDau.Text = obj.BuGioDau;
                        this.chkVitaminK1.Checked = obj.TiemViataminK1;
                        this.chkViemGanB.Checked = obj.TiemVXViemGanB;
                        this.txtKhamTuanDau.Text = obj.KhamTuanDau;
                        this.txtKhamSauDe.Text = obj.KhamSauDe;
                        this.txtGhiChu.Text = obj.GhiChu;
                    }
                    else
                    {
                        this.ClearText();
                    }
                }
                this.txtQLThai.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtQLThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtUV.Focus();
        }

        private void txtUV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.chk3lan.Focus();
        }

        private void chk3lan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.chk4lan.Focus();
        }

        private void chk4lan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtXNHIVMangThai.Focus();
        }

        private void txtXNHIVChuyenDa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.spSLDeDuThang.Focus();
        }

        private void txtXNHIVMangThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtXNHIVChuyenDa.Focus();
        }

        private void spSLDeDuThang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.spSLDeNon.Focus();
        }

        private void spSLDeNon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.spSLXayThai.Focus();
        }

        private void spSLXayThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.spSoCon.Focus();
        }

        private void spSoCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtCachThucDe.Focus();
        }

        private void txtCachThucDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.chkTaiBienMac.Focus();
        }

        private void chkTaiBienMac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtCanNang.Focus();
        }

        private void chkTaiBienTV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtCanNang.Focus();
        }

        private void txtCanNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.rdNu.Focus();
        }

        private void rdNu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTinhTrangCon.Focus();
        }

        private void rdNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTinhTrangCon.Focus();
        }

        private void txtTinhTrangCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTVThaiNhi.Focus();
        }

        private void txtTVThaiNhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNguoiDoDe.Focus();
        }

        private void txtNguoiDoDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtBuGioDau.Focus();
        }

        private void txtBuGioDau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.chkVitaminK1.Focus();
        }

        private void chkVitaminK1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtKhamTuanDau.Focus();
        }

        private void chkViemGanB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtKhamTuanDau.Focus();
        }

        private void txtKhamTuanDau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtKhamSauDe.Focus();
        }

        private void txtKhamSauDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtGhiChu.Focus();
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(" Bạn thật sự muốn hủy hồ sơ này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                if (MedicalRecord_BLL.DelMedicalRecord_Childbirth(this.medicalRecordCode) >= 1)
                {
                    XtraMessageBox.Show(" Hủy hồ sơ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearText();
                    this.sode = null;
                    this.txtQLThai.Focus();
                }
            }
        }

        private void ClearText()
        {
            this.txtQLThai.Text = string.Empty;
            this.txtUV.Text = string.Empty;
            this.chk3lan.Checked = false;
            this.chk4lan.Checked = false;
            this.txtXNHIVMangThai.Text = string.Empty;
            this.txtXNHIVChuyenDa.Text = string.Empty;
            this.spSLDeDuThang.EditValue = 0;
            this.spSLDeNon.EditValue = 0;
            this.spSLXayThai.EditValue = 0;
            this.spSoCon.EditValue = 0;
            this.txtCachThucDe.Text = string.Empty;
            this.chkTaiBienMac.Checked = false;
            this.chkTaiBienTV.Checked = false;
            this.txtCanNang.Text = string.Empty;
            this.rdNu.Checked = false;
            this.rdNam.Checked = true;
            this.txtTinhTrangCon.Text = string.Empty;
            this.txtTVThaiNhi.Text = string.Empty;
            this.txtNguoiDoDe.Text = string.Empty;
            this.txtBuGioDau.Text = string.Empty;
            this.chkVitaminK1.Checked = false;
            this.chkViemGanB.Checked = false;
            this.txtKhamTuanDau.Text = string.Empty;
            this.txtKhamSauDe.Text = string.Empty;
            this.txtGhiChu.Text = string.Empty;
        }

    }
}