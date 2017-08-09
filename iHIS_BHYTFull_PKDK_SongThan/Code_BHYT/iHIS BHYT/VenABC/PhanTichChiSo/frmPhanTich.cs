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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.VenABC
{
    public partial class frmPhanTich : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay1;
        DateTime DenNgay1;
        DateTime TuNgay2;
        DateTime DenNgay2;
        public frmPhanTich(DataTable _tbDanhSach, DateTime _TuNgay1, DateTime _DenNgay1, DateTime _TuNgay2, DateTime _DenNgay2)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay1 = _TuNgay1;
            this.DenNgay1 = _DenNgay1;
            this.TuNgay2 = _TuNgay2;
            this.DenNgay2 = _DenNgay2;
            InitializeComponent();
        }

        private void frmPhanTich_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(so sánh T1:(" + this.TuNgay1.ToShortDateString() + " - " + this.DenNgay1.ToShortDateString() + ") và T2:(" + this.TuNgay2.ToShortDateString() + " - " + this.DenNgay2.ToShortDateString() + "))";

                // phân tích tăng bậc
                lblSlTangBtoA.Text = this.tbDanhSach.Select("[ABC1] = 'B' and [ABC2] = 'A'").Count().ToString();
                lblSlTangCtoA.Text = this.tbDanhSach.Select("[ABC1] = 'C' and [ABC2] = 'A'").Count().ToString();
                lblSlTangCtoB.Text = this.tbDanhSach.Select("[ABC1] = 'C' and [ABC2] = 'B'").Count().ToString();

                double ValueTangBtoATT1 = 0;
                double ValueTangBtoATT2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC1] = 'B' and [ABC2] = 'A'"))
                {
                    ValueTangBtoATT1 += Convert.ToDouble(row["TT1"].ToString());
                    ValueTangBtoATT2 += Convert.ToDouble(row["TT2"].ToString());
                }
                lblValueTangBtoA.Text = Math.Round((ValueTangBtoATT2 - ValueTangBtoATT1), 2).ToString();

                double ValueTangCtoATT1 = 0;
                double ValueTangCtoATT2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC1] = 'C' and [ABC2] = 'A'"))
                {
                    ValueTangCtoATT1 += Convert.ToDouble(row["TT1"].ToString());
                    ValueTangCtoATT2 += Convert.ToDouble(row["TT2"].ToString());
                }
                lblValueTangCtoA.Text = Math.Round((ValueTangCtoATT2 - ValueTangCtoATT1), 2).ToString();

                double ValueTangCtoBTT1 = 0;
                double ValueTangCtoBTT2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC1] = 'C' and [ABC2] = 'B'"))
                {
                    ValueTangCtoBTT1 += Convert.ToDouble(row["TT1"].ToString());
                    ValueTangCtoBTT2 += Convert.ToDouble(row["TT2"].ToString());
                }
                lblValueTangCtoB.Text = Math.Round((ValueTangCtoBTT2 - ValueTangCtoBTT1), 2).ToString();

                lblTongSlTangBCtoA.Text = (Convert.ToInt32(lblSlTangBtoA.Text) + Convert.ToInt32(lblSlTangCtoA.Text)).ToString();
                lblTongSlTangCtoB.Text = lblSlTangCtoB.Text;
                lblTangNotChange.Text = (this.tbDanhSach.Rows.Count - ((Convert.ToInt32(lblSlTangBtoA.Text) + Convert.ToInt32(lblSlTangCtoA.Text) + Convert.ToInt32(lblSlTangCtoB.Text)))).ToString();

                string selectTongTang = "(([ABC1] = 'B' and [ABC2] = 'A') or ([ABC1] = 'C' and [ABC2] = 'A') or ([ABC1] = 'C' and [ABC2] = 'B'))";
                lblTongSlTang.Text = this.tbDanhSach.Select(selectTongTang).Count().ToString();
                lblTangV.Text = this.tbDanhSach.Select(selectTongTang + " and [VEN] = 'V'").Count().ToString();
                lblTangE.Text = this.tbDanhSach.Select(selectTongTang + " and [VEN] = 'E'").Count().ToString();
                lblTangN.Text = this.tbDanhSach.Select(selectTongTang + " and [VEN] = 'N'").Count().ToString();

                double TongTienTang = (Convert.ToDouble(lblValueTangBtoA.Text) + Convert.ToDouble(lblValueTangCtoA.Text) + Convert.ToDouble(lblValueTangCtoB.Text));
                lblTongTienTang.Text = Math.Round(TongTienTang, 2).ToString();

                //Phân tích giảm bậc
                lblSlGiamAtoB.Text = this.tbDanhSach.Select("[ABC1] = 'A' and [ABC2] = 'B'").Count().ToString();
                lblSlGiamAtoC.Text = this.tbDanhSach.Select("[ABC1] = 'A' and [ABC2] = 'C'").Count().ToString();
                lblSlGiamBtoC.Text = this.tbDanhSach.Select("[ABC1] = 'B' and [ABC2] = 'C'").Count().ToString();

                double ValueGiamAtoBTT1 = 0;
                double ValueGiamAtoBTT2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC1] = 'A' and [ABC2] = 'B'"))
                {
                    ValueGiamAtoBTT1 += Convert.ToDouble(row["TT1"].ToString());
                    ValueGiamAtoBTT2 += Convert.ToDouble(row["TT2"].ToString());
                }
                lblValueGiamAtoB.Text = Math.Round((ValueGiamAtoBTT2 - ValueGiamAtoBTT1), 2).ToString();

                double ValueGiamAtoCTT1 = 0;
                double ValueGiamAtoCTT2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC1] = 'A' and [ABC2] = 'C'"))
                {
                    ValueGiamAtoCTT1 += Convert.ToDouble(row["TT1"].ToString());
                    ValueGiamAtoCTT2 += Convert.ToDouble(row["TT2"].ToString());
                }
                lblValueGiamAtoC.Text = Math.Round((ValueGiamAtoCTT2 - ValueGiamAtoCTT1), 2).ToString();

                double ValueGiamBtoCTT1 = 0;
                double ValueGiamBtoCTT2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC1] = 'B' and [ABC2] = 'C'"))
                {
                    ValueGiamBtoCTT1 += Convert.ToDouble(row["TT1"].ToString());
                    ValueGiamBtoCTT2 += Convert.ToDouble(row["TT2"].ToString());
                }
                lblValueGiamBtoC.Text = Math.Round((ValueGiamBtoCTT2 - ValueGiamBtoCTT1), 2).ToString();

                lblTongSlGiamAtoB.Text = lblSlGiamAtoB.Text;
                lblTongSlGiamABtoC.Text = (Convert.ToInt32(lblSlGiamAtoC.Text) + Convert.ToInt32(lblSlGiamBtoC.Text)).ToString();

                string selectTongGiam = "(([ABC1] = 'A' and [ABC2] = 'B') or ([ABC1] = 'A' and [ABC2] = 'C') or ([ABC1] = 'B' and [ABC2] = 'C'))";
                lblTongSlGiam.Text = this.tbDanhSach.Select(selectTongGiam).Count().ToString();
                lblGiamV.Text = this.tbDanhSach.Select(selectTongGiam + " and [VEN] = 'V'").Count().ToString();
                lblGiamE.Text = this.tbDanhSach.Select(selectTongGiam + " and [VEN] = 'E'").Count().ToString();
                lblGiamN.Text = this.tbDanhSach.Select(selectTongGiam + " and [VEN] = 'N'").Count().ToString();

                double TongTienGiam = (Convert.ToDouble(lblValueGiamAtoB.Text) + Convert.ToDouble(lblValueGiamAtoC.Text) + Convert.ToDouble(lblValueGiamBtoC.Text));
                lblTongTienGiam.Text = Math.Round(TongTienGiam, 2).ToString();

                //Hiệu quả
                double SoTienHieuQua = (Convert.ToDouble(lblTongTienGiam.Text) + Convert.ToDouble(lblTongTienTang.Text));
                if(SoTienHieuQua < 0)
                {
                    lblHieuQua.Text = "tiết kiệm";
                    lblTienHieuQua.Text = (SoTienHieuQua * (-1)).ToString();
                }
                else
                {
                    lblHieuQua.Text = "tăng chi phí";
                    lblTienHieuQua.Text = SoTienHieuQua.ToString();
                }
            }
            catch { }
        }
    }
}