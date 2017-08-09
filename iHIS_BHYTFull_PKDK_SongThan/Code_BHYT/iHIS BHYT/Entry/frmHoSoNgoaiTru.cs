using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicLibrary;
using ClinicBLL;

namespace Ps.Clinic.Entry
{
    public partial class frmHoSoNgoaiTru : DevExpress.XtraEditors.XtraForm
    {
        private decimal patientReceiveID = 0;
        private string patientCode = string.Empty, employeeCode = string.Empty, employeeCodeDoctor = string.Empty, departmentName = string.Empty, medicalCode = string.Empty;
        private int objectCode = 0, patientType = 0;
        private DateTime dtWorking = new DateTime();
        private DataTable dtICD10KT = new DataTable("ICD10KT");
        private string shiftWork = string.Empty, departmentCode = string.Empty;
        private bool isCancel = false;
        private void lkupTQPXa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tempMaTQPXa = this.lkupTQPXa.EditValue.ToString();
                SearchLookUpEdit editor = sender as SearchLookUpEdit;
                int index = editor.Properties.GetIndexByKeyValue(editor.EditValue);
                DataRow row = (editor.Properties.DataSource as DataTable).Rows[index];
                //string stt = row["STT"].ToString();
                //string WardCode = row["WardCode"].ToString();
                //string ShortFor = row["ShortFor"].ToString();
                //string ProvincialCode = row["ProvincialCode"].ToString();
                //string DistrictCode = row["DistrictCode"].ToString();
                //string WardName = row["WardName"].ToString();

                //LEdit.GetColumnValue("ItemCode").ToString()

                this.lkupTinh.EditValue = row["ProvincialCode"].ToString();
                this.lkupHuyen.EditValue = row["DistrictCode"].ToString();
            }
            catch { throw new Exception(); }
        }

        private void txtNgaySinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkNu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupNgheNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupQuocTich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupTQPXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNoiLamViec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkThuPhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkMien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayHetHanThe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThe01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThe02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThe03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThe04_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThe05_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtThe06_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNguoiThanDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNguoiThanDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtGioVaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayVaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtChanDoanNoiGioiThieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkYte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void chkTuDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtLyDoVaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtQuaTrinhBenhLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTienSuBanThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTienSuGiaDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtKBToanThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtKBBoPhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNhietDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetAp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuyetAp01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNhipTho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtCanNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTomTatKQCLS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtCDBanDau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTomTatThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void lkupBenhChinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayBatDauDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgayKetThucDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtDienBienLamSang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTomTatKQXetNghiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void slkupRaVienBenhChinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void slkupRaVienBenhKT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtPhuongPhapDieuTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtTinhTrangRaVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtHuongDieuTriTiepTheo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtSoToXQuang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtSoToScanner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtSoToSieuAm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtSoToXetNghiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtSoToKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void slkup_NguoiGiaoHS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }

        private void slkup_NguoiNhanHS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }

        private void slkupBacSyDieuTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (MedicalRecordOutputBLL.IsUpdCancelRecordOutput(this.patientReceiveID))
            {
                XtraMessageBox.Show("Huỷ hồ sơ ngoại trú thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearText();
                this.txtLyDoVaoVien.Focus();
            }
            else
            {
                XtraMessageBox.Show("Huỷ hồ sơ ngoại trú không thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            this.ClearText();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                string careerCode = "-1";
                string provincialCode = "-1";
                string districtCode = "-1";
                string wardCode = "-1";
                int ethnicID = -1;
                int nationalityID = -1;
                if (this.lkupNgheNghiep.EditValue != null)
                    careerCode = this.lkupNgheNghiep.EditValue.ToString();
                if (this.lkupTinh.EditValue != null)
                    provincialCode = this.lkupTinh.EditValue.ToString();
                else
                    provincialCode = "000";
                if (this.lkupHuyen.EditValue != null)
                    districtCode = this.lkupHuyen.EditValue.ToString();
                else
                    districtCode = "00000";
                if (this.lkupTQPXa.EditValue != null)
                    wardCode = this.lkupTQPXa.EditValue.ToString();
                else
                    wardCode = "0000000";
                if (this.lkupDanToc.EditValue != null || this.lkupDanToc.EditValue.ToString() != string.Empty)
                    ethnicID = Convert.ToInt32(this.lkupDanToc.EditValue.ToString());
                if (this.lkupQuocTich.EditValue != null || this.lkupQuocTich.EditValue.ToString() != string.Empty)
                    nationalityID = Convert.ToInt32(this.lkupQuocTich.EditValue.ToString());
                if (this.txtNgayHetHanThe.Text.Length > 0)
                {
                    if ((this.txtThe01.Text.Length + this.txtThe02.Text.Length + this.txtThe03.Text.Length + this.txtThe04.Text.Length + this.txtThe05.Text.Length + this.txtThe06.Text.Length) < 15)
                    {
                        XtraMessageBox.Show("Chiều dài thẻ BHYT không hợp lệ. \n\r Vui lòng xem lại.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtThe01.Focus();
                        return;
                    }
                }
                DateTime dtBirthday = new DateTime();
                if (this.txtNgaySinh.Text.Length == 10)
                    dtBirthday = Convert.ToDateTime(this.txtNgaySinh.Text);
                else
                {
                    XtraMessageBox.Show("Ngày sinh bệnh nhân không hợp lệ.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgaySinh.Focus();
                    return;
                }
                if (this.dtNgayLamViec.Text.Length < 10)
                {
                    XtraMessageBox.Show("Nhập ngày làm việc.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtNgayLamViec.Focus();
                    return;
                }
                PatientReceiveBLL.UpdPatientInfo(this.patientReceiveID, this.patientCode, ethnicID, careerCode, nationalityID, provincialCode, districtCode, wardCode, this.txtNoiLamViec.Text.Trim(), this.txtDiaChi.Text.Trim(), dtBirthday, (this.dtWorking.Year - dtBirthday.Year) + 1, dtBirthday.Year);
                MedicalRecordOutputInf record = new MedicalRecordOutputInf();
                record.PatientReceiveID = this.patientReceiveID;
                record.PatientCode = this.patientCode;
                record.DepartmentCode = this.departmentCode;
                record.ShiftWork = this.shiftWork;
                record.EmployeeCode = this.employeeCode;
                record.MedicalRecordCode = this.medicalCode;
                record.ObjectCode = this.objectCode;
                record.FullNameFamily = this.txtNguoiThanDiaChi.Text.Trim();
                record.MobileFamily = this.txtNguoiThanDT.Text.Trim();
                record.HourIn = this.txtGioVaoVien.Text.Trim();
                record.DateIn = this.txtNgayVaoVien.Text.Trim();
                record.DiagnosisIntroduce = this.txtChanDoanNoiGioiThieu.Text.Trim();
                record.isYTe = this.chkYte.Checked ? true : false;
                record.isTuDen = this.chkTuDen.Checked ? true : false;
                record.ReasonIn = this.txtLyDoVaoVien.Text.Trim();
                record.Pathological_Process = this.txtQuaTrinhBenhLy.Text.Trim();
                record.Anamnesis_Personal = this.txtTienSuBanThan.Text.Trim();
                record.Anamnesis_Family = this.txtTienSuGiaDinh.Text.Trim();
                record.KB_Totality = this.txtKBToanThan.Text.Trim();
                record.KB_Parts = this.txtKBBoPhan.Text.Trim();
                record.Pulse = this.txtMach.Text.Trim();
                record.Temperature = this.txtNhietDo.Text.Trim();
                record.BloodPressure = this.txtHuyetAp.Text.Trim();
                record.BloodPressure1 = this.txtHuyetAp01.Text.Trim();
                record.Breath = this.txtNhipTho.Text.Trim();
                record.Weight_ = this.txtCanNang.Text.Trim();
                record.CLS_Brief = this.txtTomTatKQCLS.Text.Trim();
                record.Initial_DiagnosisName = this.txtCDBanDau.Text.Trim();
                record.Drug_Brief = this.txtTomTatThuoc.EditValue.ToString();
                record.ICD10_Out = this.lkupCDRaVien.EditValue == null ? -1 : Convert.ToInt32(this.lkupCDRaVien.EditValue.ToString());
                record.ICD10_OutName = this.lkupCDRaVien.Text.Trim();
                record.Treatment_DateFrom = this.txtNgayBatDauDT.Text;
                record.Treatment_DateTo = this.txtNgayKetThucDT.Text;
                record.BenhAn_DienBienLamSang = this.txtDienBienLamSang.Text;
                record.BenhAn_TomTatXetNghiem = this.txtTomTatKQXetNghiem.Text;
                record.BenhAn_BenhChinh = this.slkupRaVienBenhChinh.EditValue == null ? -1 : Convert.ToInt32(this.slkupRaVienBenhChinh.EditValue.ToString());
                record.BenhAn_BenhChinhTen = this.slkupRaVienBenhChinh.Text.ToString();
                string icd10kt = string.Empty;
                string icd10ktTen = string.Empty;
                foreach (DataRow row in this.dtICD10KT.Rows)
                {
                    icd10kt += row["RowID"].ToString() + ";";
                    icd10ktTen += row["DiagnosisName"].ToString() + ";";
                }
                record.BenhAn_BenhKemTheo = icd10kt;
                record.BenhAn_BenhKemTheoTen = icd10ktTen;
                record.BenhAn_PPDieuTri = this.txtPhuongPhapDieuTri.Text;
                record.BenhAn_TTRaVien = this.lkupTTRaVien.Text;
                record.BenhAn_HuongDieuTri = this.txtHuongDieuTriTiepTheo.Text;
                record.BenhAn_HSXQuang = this.txtSoToXQuang.Text;
                record.BenhAn_HSCTScanner = this.txtSoToScanner.Text;
                record.BenhAn_HSSieuAm = this.txtSoToSieuAm.Text;
                record.BenhAn_HSXetNghiem = this.txtSoToXetNghiem.Text;
                record.BenhAn_HSKhac = this.txtSoToKhac.Text;
                if (this.slkup_NguoiGiaoHS.EditValue != null)
                    record.BenhAn_NguoiGiaoHS = this.slkup_NguoiGiaoHS.EditValue.ToString();
                else
                    record.BenhAn_NguoiGiaoHS = string.Empty;
                if (this.slkup_NguoiNhanHS.EditValue != null)
                    record.BenhAn_NguoiNhanHS = this.slkup_NguoiNhanHS.EditValue.ToString();
                else
                    record.BenhAn_NguoiNhanHS = string.Empty;
                if (this.slkupBacSyDieuTri.EditValue != null)
                    record.EmployeeDoctorCode = this.slkupBacSyDieuTri.EditValue.ToString();
                else
                    record.EmployeeDoctorCode = string.Empty;
                record.DateWorking = Convert.ToDateTime(this.dtNgayLamViec.EditValue.ToString());
                if (this.txtSoLuuTru.Text.Length > 0)
                    record.SoLuuTru = Convert.ToInt32(this.txtSoLuuTru.Text.Trim());
                else
                    record.SoLuuTru = 0;
                record.Cancel = isCancel;
                record.Workplace = this.txtNoiLamViec.Text;
                if (this.txtSoLuuTru.Text.Length > 0)
                    record.SoLuuTru = Convert.ToInt32(this.txtSoLuuTru.Text);
                else
                    record.SoLuuTru = -1;
                int soluutru = 0;
                if (!MedicalRecordOutputBLL.IURecordOutput(record, ref soluutru))
                {
                    XtraMessageBox.Show("Lưu hồ sơ ngoại trú không thành công. Vui lòng xem lại thông tin bệnh án ngoại trú của bệnh nhân!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtLyDoVaoVien.Focus();
                    return;
                }
                else
                {
                    XtraMessageBox.Show("Hồ sơ ngoại trú lưu trữ thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSoLuuTru.Text = soluutru.ToString();
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtThe01_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtThe01.Text.Length < 2)
                this.txtThe01.Focus();
            else
                this.txtThe02.Focus();
        }

        private void txtThe02_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtThe02.Text.Trim().Length < 1)
                this.txtThe02.Focus();
            else
                this.txtThe03.Focus();
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
            if (this.txtThe03.Text.Trim().Length < 2)
                this.txtThe03.Focus();
            else
                this.txtThe04.Focus();
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
            if (this.txtThe04.Text.Trim().Length < 2)
                this.txtThe04.Focus();
            else
                this.txtThe05.Focus();
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
            if (this.txtThe05.Text.Trim().Length < 3)
                this.txtThe05.Focus();
            else
                this.txtThe06.Focus();
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
            if (this.txtThe06.Text.Trim().Length < 5)
                this.txtThe06.Focus();
            else
            {
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

        public frmHoSoNgoaiTru(decimal _patientReceiveID, string _patientCode, string _employeeCode, string _employeeCodeDoctor, string _departmentName, string _medicalCode, int _objectCode, DateTime _dtWorking, DataTable _dtICD10KT, string _shiftWork)
        {
            InitializeComponent();
            this.patientReceiveID = _patientReceiveID;
            this.patientCode = _patientCode;
            this.employeeCode = _employeeCode;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.departmentName = _departmentName;
            this.medicalCode = _medicalCode;
            this.objectCode = _objectCode;
            this.dtWorking = _dtWorking;
            this.dtICD10KT = _dtICD10KT;
            this.shiftWork = _shiftWork;
        }

        private void slkupRaVienBenhKT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit editor = sender as SearchLookUpEdit;
                int index = editor.Properties.GetIndexByKeyValue(editor.EditValue);
                DataRow row = (editor.Properties.DataSource as DataTable).Rows[index];
                string diagnosisCodeTemp = row["RowID"].ToString();

                DataRow r = Utils.GetPriceRowbyCode(this.dtICD10KT, "RowID='" + diagnosisCodeTemp + "'");
                if (r != null)
                {
                    if (XtraMessageBox.Show(" Bệnh kèm theo đã tồn tại! ", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.YesNo) != DialogResult.No)
                        return;
                }
                else
                {
                    this.dtICD10KT.Rows.Add(-1, diagnosisCodeTemp, slkupRaVienBenhKT.Text);
                    this.gridControl_ICD10KT.DataSource = this.dtICD10KT;
                }
            }
            catch { }
        }

        private void butPrintPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsResult = new DataSet();
                DataTable dtMedicalInfo = BanksAccountDetailBLL.DT_View_Treatment_OutPatient(this.patientCode, this.patientReceiveID);
                dsResult.Tables.Add(dtMedicalInfo);
                dsResult.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptHoSoKhamBenh.xml");
                Reports.rptHoSoKhamBenhNgoaiTru rpt1 = new Reports.rptHoSoKhamBenhNgoaiTru();
                rpt1.DataSource = dsResult;
                rpt1.CreateDocument();

                Reports.rptHoSoKhamBenhTongKet rpt2 = new Reports.rptHoSoKhamBenhTongKet();
                rpt2.DataSource = dsResult;
                rpt2.CreateDocument();
                rpt1.Pages.AddRange(rpt2.Pages);
                rpt1.PrintingSystem.ContinuousPageNumbering = true;
                ReportPrintTool printTool = new ReportPrintTool(rpt1);
                printTool.ShowPreviewDialog();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void frmHoSoNgoaiTru_Load(object sender, EventArgs e)
        {
            try
            {
                List<EmployeeInf> listEmployee = EmployeeBLL.ListEmployee(string.Empty);
                this.slkupBacSyDieuTri.Properties.DataSource = listEmployee;
                this.slkupBacSyDieuTri.Properties.ValueMember = "EmployeeCode";
                this.slkupBacSyDieuTri.Properties.DisplayMember = "EmployeeName";
                this.slkup_NguoiGiaoHS.Properties.DataSource = listEmployee;
                this.slkup_NguoiGiaoHS.Properties.ValueMember = "EmployeeCode";
                this.slkup_NguoiGiaoHS.Properties.DisplayMember = "EmployeeName";

                this.slkup_NguoiNhanHS.Properties.DataSource = listEmployee;
                this.slkup_NguoiNhanHS.Properties.ValueMember = "EmployeeCode";
                this.slkup_NguoiNhanHS.Properties.DisplayMember = "EmployeeName";

                this.lbKhoaPhong.Text = this.departmentName;
                this.txtSoNgoaiTru.Text = this.patientCode;

                this.lkupTTRaVien.Properties.DataSource = Tackle_BLL.ListTackle();
                this.lkupTTRaVien.Properties.DisplayMember = "TackleName";
                this.lkupTTRaVien.Properties.ValueMember = "TackleCode";
                #region Load ICD10
                List<DiagnosisInf> listDiagnosis = DiagnosisBLL.ListDiagnosisName();
                this.lkupCDRaVien.Properties.DataSource = listDiagnosis;
                this.lkupCDRaVien.Properties.DisplayMember = "DiagnosisName";
                this.lkupCDRaVien.Properties.ValueMember = "RowID";
                this.slkupRaVienBenhChinh.Properties.DataSource = listDiagnosis;
                this.slkupRaVienBenhChinh.Properties.DisplayMember = "DiagnosisName";
                this.slkupRaVienBenhChinh.Properties.ValueMember = "RowID";
                this.slkupRaVienBenhKT.Properties.DataSource = listDiagnosis;
                this.slkupRaVienBenhKT.Properties.DisplayMember = "DiagnosisName";
                this.slkupRaVienBenhKT.Properties.ValueMember = "RowID";
                this.gridControl_ICD10KT.DataSource = this.dtICD10KT;
                #endregion
                this.LoadPatientInfo();
                MedicalRecordOutputInf objRecord = MedicalRecordOutputBLL.ObjRecordOutputForReceiveID(this.patientReceiveID);
                if (objRecord != null && objRecord.RowID > 0)
                {
                    this.dtICD10KT.Clear();
                    this.GetDataRecordOutput(objRecord);
                }
                else
                {
                    this.GetSurviveSign();
                    this.txtNgayKetThucDT.EditValue = this.dtNgayLamViec.EditValue = this.dtWorking;
                    this.GetMedicalrecord();
                }
                if(this.objectCode.Equals(1))
                    this.ReadOnlyBHYT(false);
                else
                    this.ReadOnlyBHYT(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupTTRaVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtCDBanDau_Validated(object sender, EventArgs e)
        {
            this.txtCDBanDau.Text = Utils.CheckFirtCharForDoc(this.txtCDBanDau.Text);
        }

        private void txtTomTatKQCLS_Validated(object sender, EventArgs e)
        {
            this.txtTomTatKQCLS.Text = Utils.CheckFirtCharForDoc(this.txtTomTatKQCLS.Text);
        }

        private void txtKBToanThan_Validated(object sender, EventArgs e)
        {
            this.txtKBToanThan.Text = Utils.CheckFirtCharForDoc(this.txtKBToanThan.Text);
        }

        private void txtKBBoPhan_Validated(object sender, EventArgs e)
        {
            this.txtKBBoPhan.Text = Utils.CheckFirtCharForDoc(this.txtKBBoPhan.Text);
        }

        private void txtTienSuGiaDinh_Validated(object sender, EventArgs e)
        {
            this.txtTienSuGiaDinh.Text = Utils.CheckFirtCharForDoc(this.txtTienSuGiaDinh.Text);
        }

        private void txtTienSuBanThan_Validated(object sender, EventArgs e)
        {
            this.txtTienSuBanThan.Text = Utils.CheckFirtCharForDoc(this.txtTienSuBanThan.Text);
        }

        private void txtQuaTrinhBenhLy_Validated(object sender, EventArgs e)
        {
            this.txtQuaTrinhBenhLy.Text = Utils.CheckFirtCharForDoc(this.txtQuaTrinhBenhLy.Text);
        }

        private void txtLyDoVaoVien_Validated(object sender, EventArgs e)
        {
            this.txtLyDoVaoVien.Text = Utils.CheckFirtCharForDoc(this.txtLyDoVaoVien.Text);
        }

        private void txtNguoiThanDiaChi_Validated(object sender, EventArgs e)
        {
            this.txtNguoiThanDiaChi.Text = this.txtNguoiThanDiaChi.Text.ToUpper();
        }

        private void txtChanDoanNoiGioiThieu_Validated(object sender, EventArgs e)
        {
            this.txtChanDoanNoiGioiThieu.Text = Utils.CheckFirtCharForDoc(this.txtChanDoanNoiGioiThieu.Text);
        }

        private void txtNoiLamViec_Validated(object sender, EventArgs e)
        {
            this.txtNoiLamViec.Text = Utils.CheckFirtCharForDoc(this.txtNoiLamViec.Text);
        }

        private void txtDienBienLamSang_Validated(object sender, EventArgs e)
        {
            this.txtDienBienLamSang.Text = Utils.CheckFirtCharForDoc(this.txtDienBienLamSang.Text);
        }

        private void txtTomTatKQXetNghiem_Validated(object sender, EventArgs e)
        {
            this.txtTomTatKQXetNghiem.Text = Utils.CheckFirtCharForDoc(this.txtTomTatKQXetNghiem.Text);
        }

        private void txtPhuongPhapDieuTri_Validated(object sender, EventArgs e)
        {
            this.txtPhuongPhapDieuTri.Text = Utils.CheckFirtCharForDoc(this.txtPhuongPhapDieuTri.Text);
        }

        private void txtHuongDieuTriTiepTheo_Validated(object sender, EventArgs e)
        {
            this.txtHuongDieuTriTiepTheo.Text = Utils.CheckFirtCharForDoc(this.txtHuongDieuTriTiepTheo.Text);
        }

        private void ReadOnlyBHYT(bool b)
        {
            this.txtNgayHetHanThe.Properties.ReadOnly = b;
            this.txtThe01.Properties.ReadOnly = b;
            this.txtThe02.Properties.ReadOnly = b;
            this.txtThe03.Properties.ReadOnly = b;
            this.txtThe04.Properties.ReadOnly = b;
            this.txtThe05.Properties.ReadOnly = b;
            this.txtThe06.Properties.ReadOnly = b;
        }

        private void GetSurviveSign()
        {
            List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
            lstSur = SurviveSignBLL.ListSurviveSignForRefCode(this.medicalCode, this.patientReceiveID, this.patientCode);
            if (lstSur != null && lstSur.Count > 0)
            {
                this.txtMach.Text = lstSur[0].Pulse;
                this.txtNhietDo.Text = lstSur[0].Temperature;
                this.txtHuyetAp.Text = lstSur[0].BloodPressure;
                this.txtHuyetAp01.Text = lstSur[0].BloodPressure1;
                this.txtNhipTho.Text = lstSur[0].Breath;
                this.txtCanNang.Text = lstSur[0].Weight;
            }
        }

        private void LoadPatientInfo()
        {
            //CatalogProvincialBLL provincial = new CatalogProvincialBLL();
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

#region patientInfo
            PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
            if (objPatient != null && objPatient.PatientCode != null)
            {
                this.lbHoTen.Text = objPatient.PatientName;
                this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                this.txtTuoi.Text = objPatient.PatientAge.ToString();
                this.chkNam.Checked = objPatient.PatientGender == 1 ? true : false;
                this.chkNu.Checked = objPatient.PatientGender == 0 ? true : false;
            }
#endregion

#region thong tin tiep nhan
            IList<PatientReceiveInf> receive = PatientReceiveBLL.ListPatientReceive(this.patientReceiveID);
            if (receive != null && receive.Count > 0)
            {
                this.lkupNgheNghiep.EditValue = receive[0].CareerCode;
                this.lkupDanToc.EditValue = receive[0].EThnicID;
                this.lkupQuocTich.EditValue = receive[0].NationalityID;
                this.txtDiaChi.Text = receive[0].Address;
                this.lkupTQPXa.EditValue = receive[0].WardCode;
                this.lkupHuyen.EditValue = receive[0].DistrictCode;
                this.lkupTinh.EditValue = receive[0].ProvincialCode;
                this.txtGioVaoVien.Text = receive[0].CreateDate.ToString("HH:mm");
                this.txtNgayVaoVien.Text = receive[0].CreateDate.ToString("dd/MM/yyyy");
                this.txtNgayBatDauDT.EditValue = receive[0].CreateDate;
                this.txtLyDoVaoVien.Text = receive[0].Reason;
                this.txtTienSuBanThan.Text = receive[0].MedicalHistory;
                this.patientType = receive[0].PatientType;
            }
            this.chkBHYT.Checked = this.objectCode == 1 ? true : false;
            this.chkThuPhi.Checked = this.objectCode == 2 ? true : false;
            this.chkMien.Checked = this.objectCode == 5 ? true : false;
            this.chkKhac.Checked = this.objectCode == 6 ? true : false;
            if (this.objectCode == 1)
            {
                List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                if (lstBHYT.Count > 0)
                {
                    this.txtNgayHetHanThe.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                    this.txtThe01.Text = lstBHYT[0].Serial01;
                    this.txtThe02.Text = lstBHYT[0].Serial02;
                    this.txtThe03.Text = lstBHYT[0].Serial03;
                    this.txtThe04.Text = lstBHYT[0].Serial04;
                    this.txtThe05.Text = lstBHYT[0].Serial05;
                    this.txtThe06.Text = lstBHYT[0].Serial06;
                }
            }
#endregion
        }

        private void GetMedicalrecord()
        {
            MedicalRecord_INF mrecord = MedicalRecord_BLL.ObjMedicalRecordForRecordCode(this.medicalCode);
            if (mrecord != null && mrecord.RowID > 0)
            {
                this.txtPhuongPhapDieuTri.Text = mrecord.Treatments;
                this.lkupCDRaVien.EditValue = mrecord.DiagnosisCode;
                this.slkupRaVienBenhChinh.EditValue = mrecord.DiagnosisCode;
                
                this.slkupBacSyDieuTri.EditValue = mrecord.EmployeeCodeDoctor;
                this.slkup_NguoiNhanHS.EditValue = mrecord.EmployeeCode;
                this.slkup_NguoiGiaoHS.EditValue = mrecord.EmployeeCode;
                this.departmentCode = mrecord.DepartmentCode;
                this.txtCDBanDau.Text = mrecord.DiagnosisCustom;
                this.lkupTTRaVien.EditValue = mrecord.TackleCode;

                this.txtTomTatThuoc.Text = MedicalRecord_BLL.GetDrugMedicalrecord(this.patientReceiveID, this.patientCode);
            }
            DataTable dtResulLab = ServiceLaboratoryEntryBLL.GetResultLaboratoryForReceiveID(this.patientReceiveID, this.patientCode);
            if(dtResulLab!= null && dtResulLab.Rows.Count>0)
            {
                foreach(DataRow row in dtResulLab.Rows)
                {
                    this.txtTomTatKQXetNghiem.Text += row["ServiceName"].ToString() + ":" + row["Result"].ToString();
                }
            }
        }

        private void ClearText()
        {
            this.txtNguoiThanDiaChi.Text = string.Empty;
            this.txtNguoiThanDT.Text = string.Empty;
            this.txtGioVaoVien.EditValue = string.Empty;
            this.txtNgayVaoVien.EditValue = this.dtWorking;
            this.txtChanDoanNoiGioiThieu.EditValue = string.Empty;
            this.chkYte.Checked = true;
            this.chkTuDen.Checked = false;
            this.txtLyDoVaoVien.EditValue = string.Empty;
            this.txtQuaTrinhBenhLy.Text = string.Empty;
            this.txtTienSuBanThan.Text = string.Empty;
            this.txtTienSuGiaDinh.Text = string.Empty;
            this.txtKBToanThan.Text = string.Empty;
            this.txtKBBoPhan.Text = string.Empty;
            this.txtMach.Text = string.Empty;
            this.txtNhietDo.Text = string.Empty;
            this.txtHuyetAp.Text = string.Empty;
            this.txtHuyetAp01.Text = string.Empty;
            this.txtNhipTho.Text = string.Empty;
            this.txtCanNang.Text = string.Empty;
            this.txtTomTatKQCLS.Text = string.Empty;
            this.txtCDBanDau.EditValue = null;
            this.txtCDBanDau.Text = string.Empty;
            this.txtTomTatThuoc.EditValue = string.Empty;
            this.lkupCDRaVien.EditValue = null;
            this.lkupCDRaVien.Text = string.Empty;
            this.txtNgayBatDauDT.Text = this.txtNgayKetThucDT.Text = this.dtWorking.ToString("dd/MM/yyyy");
            this.txtDienBienLamSang.EditValue = string.Empty;
            this.txtTomTatKQXetNghiem.EditValue = string.Empty;
            this.slkupRaVienBenhChinh.EditValue = null;
            this.slkupRaVienBenhChinh.EditValue = null;
            this.dtICD10KT.Clear();
            this.slkupRaVienBenhKT.Properties.DataSource = this.dtICD10KT;
            this.txtPhuongPhapDieuTri.EditValue = string.Empty;
            this.lkupTTRaVien.EditValue = string.Empty;
            this.txtHuongDieuTriTiepTheo.EditValue = string.Empty;
            this.txtSoToXQuang.EditValue = string.Empty;
            this.txtSoToScanner.EditValue = string.Empty;
            this.txtSoToSieuAm.EditValue = string.Empty;
            this.txtSoToXetNghiem.EditValue = string.Empty;
            this.txtSoToKhac.EditValue = string.Empty;
            this.slkup_NguoiGiaoHS.EditValue = null;
            this.slkup_NguoiNhanHS.EditValue = null;
            this.slkupBacSyDieuTri.EditValue = null;
            this.slkupBacSyDieuTri.EditValue = null;
            this.isCancel = false;
        }

        private void GetDataRecordOutput(MedicalRecordOutputInf record)
        {
            this.txtNguoiThanDiaChi.Text = record.FullNameFamily;
            this.txtNguoiThanDT.Text = record.MobileFamily;
            this.txtGioVaoVien.Text = record.HourIn;
            this.txtNgayVaoVien.Text = record.DateIn;
            this.txtChanDoanNoiGioiThieu.Text = record.DiagnosisIntroduce;
            this.chkYte.Checked = record.isYTe;
            this.chkTuDen.Checked = record.isTuDen;
            this.txtLyDoVaoVien.Text = record.ReasonIn;
            this.txtQuaTrinhBenhLy.Text = record.Pathological_Process;
            this.txtTienSuBanThan.Text = record.Anamnesis_Personal;
            this.txtTienSuGiaDinh.Text = record.Anamnesis_Family;
            this.txtKBToanThan.Text = record.KB_Totality;
            this.txtKBBoPhan.Text = record.KB_Parts;
            this.txtMach.Text = record.Pulse;
            this.txtNhietDo.Text = record.Temperature;
            this.txtHuyetAp.Text = record.BloodPressure;
            this.txtHuyetAp01.Text = record.BloodPressure1;
            this.txtNhipTho.Text = record.Breath;
            this.txtCanNang.Text = record.Weight_;
            this.txtTomTatKQCLS.Text = record.CLS_Brief;
            this.txtCDBanDau.Text = record.Initial_DiagnosisName;
            this.txtTomTatThuoc.EditValue = record.Drug_Brief;
            this.lkupCDRaVien.EditValue = record.ICD10_Out;
            //this.lkupCDRaVien.Text = record.ICD10_OutName;
            this.txtNgayBatDauDT.Text = record.Treatment_DateFrom;
            this.txtNgayKetThucDT.Text = record.Treatment_DateTo;
            this.txtDienBienLamSang.Text = record.BenhAn_DienBienLamSang;
            this.txtTomTatKQXetNghiem.Text = record.BenhAn_TomTatXetNghiem;
            this.slkupRaVienBenhChinh.EditValue = record.BenhAn_BenhChinh;
            //this.slkupRaVienBenhChinh.Text = record.BenhAn_BenhChinhTen;
            string[] arrICD10 = record.BenhAn_BenhKemTheo.Split(';');
            string[] arrICD10Name = record.BenhAn_BenhKemTheoTen.Split(';');
            for (int i = 0; i < arrICD10.Length-1; i++)
            {
                this.dtICD10KT.Rows.Add(-1, arrICD10[i].ToString(), arrICD10Name[i].ToString());
            }
            this.gridControl_ICD10KT.DataSource = this.dtICD10KT;
            this.txtPhuongPhapDieuTri.Text = record.BenhAn_PPDieuTri;
            this.lkupTTRaVien.Text = record.BenhAn_TTRaVien;
            this.txtHuongDieuTriTiepTheo.Text = record.BenhAn_HuongDieuTri;
            this.txtSoToXQuang.Text = record.BenhAn_HSXQuang;
            this.txtSoToScanner.Text = record.BenhAn_HSCTScanner;
            this.txtSoToSieuAm.Text = record.BenhAn_HSSieuAm;
            this.txtSoToXetNghiem.Text = record.BenhAn_HSXetNghiem;
            this.txtSoToKhac.Text = record.BenhAn_HSKhac;
            this.slkup_NguoiGiaoHS.EditValue = record.BenhAn_NguoiGiaoHS;
            this.slkup_NguoiNhanHS.EditValue = record.BenhAn_NguoiNhanHS;
            this.slkupBacSyDieuTri.EditValue = record.EmployeeDoctorCode;
            this.dtNgayLamViec.EditValue = record.DateWorking;
            this.txtSoLuuTru.Text = record.SoLuuTru.ToString();
            this.isCancel = record.Cancel;
            this.txtNoiLamViec.Text = record.Workplace;
            this.txtNgayHetHanThe.Text = record.EndDate_BHYT;
            this.txtThe01.Text = record.Serial01;
            this.txtThe02.Text = record.Serial02;
            this.txtThe03.Text = record.Serial03;
            this.txtThe04.Text = record.Serial04;
            this.txtThe05.Text = record.Serial05;
            this.txtThe06.Text = record.Serial06;
        }
    }
}