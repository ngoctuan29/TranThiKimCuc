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
    public partial class frmPhanTichChiSoSuDungTrongBenhVien : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichChiSoSuDungTrongBenhVien(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichChiSoSuDungTrongBenhVien_Load(object sender, EventArgs e)
        {
            try
            {
                //Ngày
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

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

                lblNamVienTB.Text = Math.Round((SoNgayTB / TongSoLuot), 2).ToString();
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