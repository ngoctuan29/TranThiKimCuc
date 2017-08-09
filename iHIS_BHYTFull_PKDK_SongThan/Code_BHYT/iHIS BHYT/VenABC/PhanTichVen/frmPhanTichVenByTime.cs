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

namespace Ps.Clinic.VenABC.PhanTichVen
{
    public partial class frmPhanTichVenByTime : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichVenByTime(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichVenByTime_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                double SlV = this.tbDanhSach.Select("[VEN] = 'V'").Count();
                double SlE = this.tbDanhSach.Select("[VEN] = 'E'").Count();
                double SlN = this.tbDanhSach.Select("[VEN] = 'N'").Count();

                double TongThuoc = SlV + SlE + SlN;
                double phantramV = (SlV * 100) / TongThuoc;
                phantramV = Math.Round(phantramV, 2);
                double phantramE = (SlE * 100) / TongThuoc;
                phantramE = Math.Round(phantramE, 2);
                double phantramN = (SlN * 100) / TongThuoc;
                phantramN = Math.Round(phantramN, 2);

                double sumTienV = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'V'"))
                {
                    sumTienV += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                sumTienV = Math.Round(sumTienV, 2);

                double sumTienE = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'E'"))
                {
                    sumTienE += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                sumTienE = Math.Round(sumTienE, 2);

                double sumTienN = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'N'"))
                {
                    sumTienN += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                sumTienN = Math.Round(sumTienN, 2);

                double TongTien = sumTienV + sumTienE + sumTienN;
                double phantramTienV = (sumTienV * 100) / TongTien;
                phantramTienV = Math.Round(phantramTienV, 2);
                double phantramTienE = (sumTienE * 100) / TongTien;
                phantramTienE = Math.Round(phantramTienE, 2);
                double phantramTienN = (sumTienN * 100) / TongTien;
                phantramTienN = Math.Round(phantramTienN, 2);

                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("chungloai", typeof(double));
                tbNhom.Columns.Add("tylecl", typeof(double));
                tbNhom.Columns.Add("giatri", typeof(double));
                tbNhom.Columns.Add("tylegt", typeof(double));

                tbNhom.Rows.Add("V", SlV, phantramV, sumTienV, phantramTienV);
                tbNhom.Rows.Add("E", SlE, phantramE, sumTienE, phantramTienE);
                tbNhom.Rows.Add("N", SlN, phantramN, sumTienN, phantramTienN);
                tbNhom.Rows.Add("Tổng", TongThuoc, 100, TongTien, 100);
                //pass into gridNhom
                this.grdNhom.DataSource = tbNhom;

                //load chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'V' or [nhom] = 'E' or [nhom] = 'N'").CopyToDataTable();
                Series series1 = new Series("% Chủng loại", ViewType.Bar);
                Series series2 = new Series("% Giá trị", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylecl" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylegt" });

                //Phân tích
                DataTable tbPhantich = new DataTable();
                tbPhantich = (DataTable)chrNhom.DataSource;
                lblThuocMax.Text = tbPhantich.Select("[tylegt] = MAX(tylegt)")[0]["nhom"].ToString();
                lblSlMax.Text = tbPhantich.Select("[tylegt] = MAX(tylegt)")[0]["tylegt"].ToString() + " %";

                lblThuocMin.Text = tbNhom.Select("[tylegt] = MIN(tylegt)")[0]["nhom"].ToString();
                lblSlMin.Text = tbNhom.Select("[tylegt] = MIN(tylegt)")[0]["tylegt"].ToString() + " %";
            }
            catch { }
        }
    }
}