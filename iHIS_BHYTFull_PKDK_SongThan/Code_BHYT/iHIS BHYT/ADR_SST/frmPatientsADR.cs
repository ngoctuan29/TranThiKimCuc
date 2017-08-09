using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicLibrary;
using ClinicModel;
using ClinicBLL;

namespace Ps.Clinic.ADR_SST
{
    public partial class frmPatientsADR : DevExpress.XtraEditors.XtraForm
    {
        private int idPhieu = 0;
        public frmPatientsADR(int _idPhieu)
        {
            this.idPhieu = _idPhieu;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ADR_BenhNhanInf model = new ADR_BenhNhanInf();
                model.Id = 0;
                model.IdPhieuBaoCao = this.idPhieu;
                model.HoTen = txtHoTen.Text;
                model.NgaySinh = Convert.ToDateTime(dteNgaySinh.EditValue).ToString("yyyy");
                model.GioiTinh = cbxSex.Text;
                model.CanNang = txtCanNang.Value.ToString();
                model.NgayXuatHienPhanUng = Convert.ToDateTime(dteNgayPhanUng.EditValue).ToString("yyyy");
                model.MoTaBieuHien = txtMoTa.Text;
                if(ADRBLL.InsUpd_BenhNhan(model) == 1)
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Cập nhật dữ liệu không thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}