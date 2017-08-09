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
using DevExpress.XtraCharts;

namespace Ps.Clinic.VenABC
{
    public partial class frmPhanTichABC : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichABC(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichABC_Load(object sender, EventArgs e)
        {
            try
            {
                //Ngày
                this.lbldate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                double SlA = this.tbDanhSach.Select("[ABC] = 'A'").Count();
                double SlB = this.tbDanhSach.Select("[ABC] = 'B'").Count();
                double SlC = this.tbDanhSach.Select("[ABC] = 'C'").Count();

                double TongThuoc = SlA + SlB + SlC;
                double phantramA = (SlA * 100) / TongThuoc;
                phantramA = Math.Round(phantramA, 2);
                double phantramB = (SlB * 100) / TongThuoc;
                phantramB = Math.Round(phantramB, 2);
                double phantramC = (SlC * 100) / TongThuoc;
                phantramC = Math.Round(phantramC, 2);

                double sumTienA = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'A'"))
                {
                    sumTienA += Convert.ToDouble(row["Amount"].ToString());
                }
                sumTienA = Math.Round(sumTienA, 2);

                double sumTienB = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'B'"))
                {
                    sumTienB += Convert.ToDouble(row["Amount"].ToString());
                }
                sumTienB = Math.Round(sumTienB, 2);

                double sumTienC = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'C'"))
                {
                    sumTienC += Convert.ToDouble(row["Amount"].ToString());
                }
                sumTienC = Math.Round(sumTienC, 2);

                double TongTien = sumTienA + sumTienB + sumTienC;
                double phantramTienA = (sumTienA * 100) / TongTien;
                phantramTienA = Math.Round(phantramTienA, 2);
                double phantramTienB = (sumTienB * 100) / TongTien;
                phantramTienB = Math.Round(phantramTienB, 2);
                double phantramTienC = (sumTienC * 100) / TongTien;
                phantramTienC = Math.Round(phantramTienC, 2);

                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("chungloai", typeof(double));
                tbNhom.Columns.Add("tylecl", typeof(double));
                tbNhom.Columns.Add("giatri", typeof(double));
                tbNhom.Columns.Add("tylegt", typeof(double));

                tbNhom.Rows.Add("A", SlA, phantramA, sumTienA, phantramTienA);
                tbNhom.Rows.Add("B", SlB, phantramB, sumTienB, phantramTienB);
                tbNhom.Rows.Add("C", SlC, phantramC, sumTienC, phantramTienC);
                tbNhom.Rows.Add("Tổng", TongThuoc, 100, TongTien, 100);
                //pass into gridNhom
                this.grdNhom.DataSource = tbNhom;
                //Nhóm A
                this.lblNhomA.Text = SlA.ToString();
                //Thuốc AN
                int soThuocAN = this.tbDanhSach.Select("[ABC] = 'A' and [VEN] = 'N'").Count();
                if (soThuocAN > 0)
                {
                    this.lblAN.Text = soThuocAN.ToString();
                    this.grdAN.DataSource = this.tbDanhSach.Select("[ABC] = 'A' and [VEN] = 'N'").CopyToDataTable();
                }
                else
                {
                    this.lblAN.Text = "0";
                }
                //Thuốc AV
                int soThuocAV = this.tbDanhSach.Select("[ABC] = 'A' and [VEN] = 'V'").Count();
                if (soThuocAV > 0)
                {
                    this.lblAV.Text = soThuocAV.ToString();
                    this.grdAV.DataSource = this.tbDanhSach.Select("[ABC] = 'A' and [VEN] = 'V'").CopyToDataTable();
                }
                else
                {
                    this.lblAV.Text = "0";
                }
                //Thuốc biệt dược
                DataTable tbAVE = new DataTable();
                int soThuocBietduoc = this.tbDanhSach.Select("[ABC] = 'A' and [BietDuoc1] = 'B'").Count();
                if (soThuocBietduoc > 0)
                {
                    this.lblBietduoc.Text = soThuocBietduoc.ToString();
                    this.grdBietduoc.DataSource = this.tbDanhSach.Select("[ABC] = 'A' and [BietDuoc1] = 'B'").CopyToDataTable();
                }
                else
                {
                    this.lblBietduoc.Text = "0";
                }
                // chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'A' or [nhom] = 'B' or [nhom] = 'C'").CopyToDataTable();
                Series series1 = new Series("% Chủng loại", ViewType.Bar);
                Series series2 = new Series("% Giá trị", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylecl" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylegt" });
            }
            catch { }
        }
    }
}