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
    public partial class frmPhanTichChiSoKeDon : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tbDanhSach = new DataTable();
        private DateTime TuNgay;
        private DateTime DenNgay;
        public frmPhanTichChiSoKeDon(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichChiSoKeDon_Load(object sender, EventArgs e)
        {
            try
            {
                //Ngày
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                //load grid
                grdDanhSach.DataSource = this.tbDanhSach;

                //Phân tích
                DataRow drDanhSach = this.tbDanhSach.Rows[0];
                double Tongthuoc = Convert.ToDouble(drDanhSach["TongToa"].ToString());
                double TongThuocTB = Convert.ToDouble(drDanhSach["TongThuocTrongToa"].ToString());
                double SoThuocGeneric = Convert.ToDouble(drDanhSach["SLThuocTrongToa_G"].ToString());
                double SoThuocBietDuoc = Convert.ToDouble(drDanhSach["SLThuocTrongToa_B"].ToString());
                double SoThuocKhangSinh = Convert.ToDouble(drDanhSach["TongToa_KS"].ToString());
                double SoThuocTiem = Convert.ToDouble(drDanhSach["TongToa_Tiem"].ToString());
                double SoThuocTVitamin = Convert.ToDouble(drDanhSach["TongToa_Vit"].ToString());
                double SoThuocBYT = Convert.ToDouble(drDanhSach["SLThuocTrongToa_TT45"].ToString());

                lblThuocTB.Text = Math.Round(TongThuocTB / Tongthuoc).ToString();
                lblTyleThuocGeneric.Text = Math.Round(((SoThuocGeneric * 100 )/ TongThuocTB),2)+ "%";
                lblTyleThuocBietDuoc.Text = Math.Round(((SoThuocBietDuoc * 100 )/ TongThuocTB),2) + "%";
                lblTyleKhangSinh.Text = Math.Round(((SoThuocKhangSinh * 100 )/ Tongthuoc),2) + "%";
                lblTyleThuocTiem.Text = Math.Round(((SoThuocTiem * 100 )/ Tongthuoc),2) + "%";
                lblTyleVitamin.Text = Math.Round(((SoThuocTVitamin * 100 )/ Tongthuoc),2) + "%";
                lblTyleThuocBYT.Text = Math.Round(((SoThuocBYT * 100 )/ TongThuocTB),2) + "%";
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