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
    public partial class frmPhanTichChiSoToanDien : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichChiSoToanDien(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichChiSoToanDien_Load(object sender, EventArgs e)
        {
            try
            {
                //Ngày
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                //load grid
                grdDanhSach.DataSource = this.tbDanhSach;

                //Phân tích
                DataRow drDanhSach = this.tbDanhSach.Rows[0];
                double TongLuot = Convert.ToDouble(drDanhSach["TongLuot"].ToString());
                double TongLuotKhongThuoc = Convert.ToDouble(drDanhSach["TongLuotKhongThuoc"].ToString());
                double TongDonThuoc = Convert.ToDouble(drDanhSach["TongToa"].ToString());
                double TongGiaTri = Convert.ToDouble(drDanhSach["TongGiaTriThuoc"].ToString());
                double TongGiaTriKhangSinh = Convert.ToDouble(drDanhSach["TongGiaTri_KS"].ToString());
                double TongGiaTriTiem = Convert.ToDouble(drDanhSach["TongGiaTri_Tiem"].ToString());
                double TongGiaTriVitamin = Convert.ToDouble(drDanhSach["TongGiaTri_Vit"].ToString());

                lblChiem.Text = TongLuotKhongThuoc + "/" + TongLuot;
                lblTyLeChiem.Text = Math.Round((TongLuotKhongThuoc * 100) / TongLuot, 2) + "%";
                lblGiaTB.Text = Math.Round(TongGiaTri / TongDonThuoc, 2).ToString();
                lblTyleKhangSinh.Text = Math.Round((TongGiaTriKhangSinh * 100) / TongGiaTri, 2) + "%";
                lblTyleThuocTiem.Text = Math.Round((TongGiaTriTiem * 100) / TongGiaTri, 2) + "%";
                lblTyleVitamin.Text = Math.Round((TongGiaTriVitamin * 100) / TongGiaTri, 2) + "%";
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