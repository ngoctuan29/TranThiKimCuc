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

namespace Ps.Clinic.VenABC
{
    public partial class frmPhanTichChiSoSuDungTrongBenhVienTungNgay : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime Ngay;
        public frmPhanTichChiSoSuDungTrongBenhVienTungNgay(DataTable _tbDanhSach, DateTime _Ngay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.Ngay = _Ngay;
            InitializeComponent();
        }

        private void frmPhanTichChiSoSuDungTrongBenhVienTungNgay_Load(object sender, EventArgs e)
        {
            try
            {
                //Ngày
                lblDate.Text = "(" + this.Ngay.ToShortDateString() + ")";

                //load grid
                grdDanhSach.DataSource = this.tbDanhSach;

                //Phân tích
                DataRow drDanhSach = this.tbDanhSach.Rows[0];
                double TongSoLuot = Convert.ToDouble(drDanhSach["TongSoLuot"].ToString());
                double SoNgayTB = Convert.ToDouble(drDanhSach["TongSoNgayNamVien"].ToString());
                double SoThuocTB = Convert.ToDouble(drDanhSach["TongSoThuoc"].ToString());
                double SoThuoCKSTB = Convert.ToDouble(drDanhSach["TongSoThuoc_KS"].ToString());
                double SoThuocTiemTB = Convert.ToDouble(drDanhSach["TongSoThuoc_Tiem"].ToString());
                double GiaTB = Convert.ToDouble(drDanhSach["TongGiaTriThuoc"].ToString());

                lblThuocTB.Text = Math.Round((SoThuocTB / TongSoLuot)).ToString();
                lblThuocKSTB.Text = Math.Round((SoThuoCKSTB / TongSoLuot)).ToString();
                lblThuocTiemTB.Text = Math.Round((SoThuocTiemTB / TongSoLuot)).ToString();
                lblGiaTB.Text = Math.Round((GiaTB / TongSoLuot), 2).ToString();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}