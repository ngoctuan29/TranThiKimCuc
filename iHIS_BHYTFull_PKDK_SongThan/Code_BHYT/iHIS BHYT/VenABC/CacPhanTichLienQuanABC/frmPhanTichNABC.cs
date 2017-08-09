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
    public partial class frmPhanTichNABC : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichNABC(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichAABC_Load(object sender, EventArgs e)
        {
            try
            {
                //Ngày
                lbldate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";
                string selectNhom1 = "([ABC] = 'A' and [VEN] = 'V') or ([ABC] = 'A' and [VEN] = 'E') or ([ABC] = 'A' and [VEN] = 'N') or ([ABC] = 'B' and [VEN] = 'V') or ([ABC] = 'C' and [VEN] = 'V')";
                double SlNhom1 = this.tbDanhSach.Select(selectNhom1).Count();

                string selectNhom2 = "([ABC] = 'B' and [VEN] = 'E') or ([ABC] = 'B' and [VEN] = 'N') or ([ABC] = 'C' and [VEN] = 'E')";
                double SlNhom2 = this.tbDanhSach.Select(selectNhom2).Count();

                string selectNhom3 = "[ABC] = 'C' and [VEN] = 'N' ";
                double SlNhom3 = this.tbDanhSach.Select(selectNhom3).Count();

                double TongNhom = SlNhom1 + SlNhom2 + SlNhom3;
                double phantramNhom1 = (SlNhom1 * 100) / TongNhom;
                phantramNhom1 = Math.Round(phantramNhom1, 2);
                double phantramNhom2 = (SlNhom2 * 100) / TongNhom;
                phantramNhom2 = Math.Round(phantramNhom2, 2);
                double phantramNhom3 = (SlNhom3 * 100) / TongNhom;
                phantramNhom3 = Math.Round(phantramNhom3, 2);

                double sumTienNhom1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNhom1))
                {
                    sumTienNhom1 += Convert.ToDouble(row["Amount"].ToString());
                }
                sumTienNhom1 = Math.Round(sumTienNhom1, 2);

                double sumTienNhom2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNhom2))
                {
                    sumTienNhom2 += Convert.ToDouble(row["Amount"].ToString());
                }
                sumTienNhom2 = Math.Round(sumTienNhom2, 2);

                double sumTienNhom3 = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNhom3))
                {
                    sumTienNhom3 += Convert.ToDouble(row["Amount"].ToString());
                }
                sumTienNhom3 = Math.Round(sumTienNhom3, 2);

                double TongTien = sumTienNhom1 + sumTienNhom2 + sumTienNhom3;
                double phantramTien1 = (sumTienNhom1 * 100) / TongTien;
                phantramTien1 = Math.Round(phantramTien1, 2);
                double phantramTien2 = (sumTienNhom2 * 100) / TongTien;
                phantramTien2 = Math.Round(phantramTien2, 2);
                double phantramTien3 = (sumTienNhom3 * 100) / TongTien;
                phantramTien3 = Math.Round(phantramTien3, 2);

                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("chungloai", typeof(double));
                tbNhom.Columns.Add("tylecl", typeof(double));
                tbNhom.Columns.Add("giatri", typeof(double));
                tbNhom.Columns.Add("tylegt", typeof(double));

                tbNhom.Rows.Add("I", SlNhom1, phantramNhom1, sumTienNhom1, phantramTien1);
                tbNhom.Rows.Add("II", SlNhom2, phantramNhom2, sumTienNhom2, phantramTien2);
                tbNhom.Rows.Add("III", SlNhom3, phantramNhom3, sumTienNhom3, phantramTien3);
                tbNhom.Rows.Add("Tổng", TongNhom, 100, TongTien, 100);
                //pass into gridNhom
                this.grdNhom.DataSource = tbNhom;
                //Thuốc BN
                int soThuocBN = this.tbDanhSach.Select("[ABC] = 'B' and [VEN] = 'N'").Count();
                if (soThuocBN > 0)
                {
                    lblBN.Text = soThuocBN.ToString();
                    grdBN.DataSource = this.tbDanhSach.Select("[ABC] = 'B' and [VEN] = 'N'").CopyToDataTable();
                }
                else
                {
                    lblBN.Text = "0";
                }
                //Thuốc CN
                int soThuocCN = this.tbDanhSach.Select("[ABC] = 'C' and [VEN] = 'N'").Count();
                if (soThuocCN > 0)
                {
                    lblCN.Text = soThuocCN.ToString();
                    grdCN.DataSource = this.tbDanhSach.Select("[ABC] = 'C' and [VEN] = 'N'").CopyToDataTable();
                }
                else
                {
                    lblCN.Text = "0";
                }

                // chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'I' or [nhom] = 'II' or [nhom] = 'III'").CopyToDataTable();
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