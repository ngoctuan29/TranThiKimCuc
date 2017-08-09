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
    public partial class frmKBSoPhaThai : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCode = string.Empty, medicalRecordCode = string.Empty;
        public MedicalRecord_AbortionsINF sophathai = new MedicalRecord_AbortionsINF();
        private DateTime dtimeWorking = new DateTime();
        public frmKBSoPhaThai(string _employeeCode, string _medicalRecordCode, DateTime _dtimeWorking, MedicalRecord_AbortionsINF _sophathai)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.medicalRecordCode = _medicalRecordCode;
            this.dtimeWorking = _dtimeWorking;
            this.sophathai = _sophathai;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.sophathai = new MedicalRecord_AbortionsINF();
                this.sophathai.MedicalRecordCode = this.medicalRecordCode;
                this.sophathai.EmployeeCode = this.employeeCode;
                this.sophathai.TTHonNhan = this.rdDocThan.Checked ? 0 : 1;
                this.sophathai.ChuanDoanThai = this.txtChanDoanThai.Text.Trim();
                this.sophathai.SoConHienCo = Convert.ToInt32(this.spSoCon.EditValue);
                this.sophathai.NgayKinhCuoiCung = this.txtNgayKinhCuoiCung.Text.Trim();
                this.sophathai.PPPhaThai = this.txtPPPhaThai.Text.Trim();
                this.sophathai.KetQuaSoiMo = this.txtKQSoiMo.Text.Trim();
                this.sophathai.TaiBienChet = this.chkTaiBienChet.Checked ? 1 : 0;
                this.sophathai.TaiBienMac = this.chkTaiBienMac.Checked ? 1 : 0;
                this.sophathai.KhamLai = this.txtKhamLai.Text.Trim();
                this.sophathai.GhiChu = this.txtGhiChu.Text.Trim();
                this.sophathai.WorkDate = Convert.ToDateTime(this.dtimeWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
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
            this.sophathai = null;
            this.spSoCon.Focus();
        }

        private void spSoCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayKinhCuoiCung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtChanDoanThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtPPPhaThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtKQSoiMo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkTaiBienMac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkTaiBienChet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtKhamLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(" Bạn thật sự muốn hủy hồ sơ này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                if (MedicalRecord_BLL.DelMedicalRecord_Abortions(this.medicalRecordCode) >= 1)
                {
                    XtraMessageBox.Show(" Hủy hồ sơ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearText();
                    this.sophathai = null;
                    this.spSoCon.Focus();
                }
            }
        }
        private void ClearText()
        {
            this.rdDocThan.Checked = true;
            this.rdGiaDinh.Checked = false;
            this.spSoCon.EditValue = 0;
            this.txtNgayKinhCuoiCung.Text = string.Empty;
            this.txtChanDoanThai.Text = string.Empty;
            this.txtPPPhaThai.Text = string.Empty;
            this.txtKQSoiMo.Text = string.Empty;
            this.chkTaiBienMac.Checked = false;
            this.chkTaiBienChet.Checked = false;
            this.txtKhamLai.Text = string.Empty;
            this.txtGhiChu.Text = string.Empty;
        }
        private void frmKBSoPhaThai_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.sophathai != null)
                {
                    this.rdDocThan.Checked = this.sophathai.TTHonNhan == 0 ? true : false;
                    this.rdGiaDinh.Checked = this.sophathai.TTHonNhan == 1 ? true : false;
                    this.spSoCon.EditValue = this.sophathai.SoConHienCo;
                    this.txtNgayKinhCuoiCung.Text = this.sophathai.NgayKinhCuoiCung;
                    this.txtChanDoanThai.Text = this.sophathai.ChuanDoanThai;
                    this.txtPPPhaThai.Text = this.sophathai.PPPhaThai;
                    this.txtKQSoiMo.Text = this.sophathai.KetQuaSoiMo;
                    this.chkTaiBienMac.Checked = this.sophathai.TaiBienMac == 1 ? true : false;
                    this.chkTaiBienChet.Checked = this.sophathai.TaiBienChet == 1 ? true : false;
                    this.txtKhamLai.Text = this.sophathai.KhamLai;
                    this.txtGhiChu.Text = this.sophathai.GhiChu;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.medicalRecordCode))
                    {
                        MedicalRecord_AbortionsINF obj = MedicalRecord_BLL.ObjMedicalRecord_Abortions(this.medicalRecordCode);
                        this.rdDocThan.Checked = obj.TTHonNhan == 0 ? true : false;
                        this.rdGiaDinh.Checked = obj.TTHonNhan == 1 ? true : false;
                        this.spSoCon.EditValue = obj.SoConHienCo;
                        this.txtNgayKinhCuoiCung.Text = obj.NgayKinhCuoiCung;
                        this.txtChanDoanThai.Text = obj.ChuanDoanThai;
                        this.txtPPPhaThai.Text = obj.PPPhaThai;
                        this.txtKQSoiMo.Text = obj.KetQuaSoiMo;
                        this.chkTaiBienMac.Checked = obj.TaiBienMac == 1 ? true : false;
                        this.chkTaiBienChet.Checked = obj.TaiBienChet == 1 ? true : false;
                        this.txtKhamLai.Text = obj.KhamLai;
                        this.txtGhiChu.Text = obj.GhiChu;
                    }
                    else
                        this.ClearText();
                }
                this.spSoCon.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
    }
}