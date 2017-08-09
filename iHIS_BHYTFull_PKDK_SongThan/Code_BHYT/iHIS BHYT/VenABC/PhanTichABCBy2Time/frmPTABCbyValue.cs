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

namespace Ps.Clinic.VenABC.PhanTichABCBy2Time
{
    public partial class frmPTABCbyValue : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay1;
        DateTime DenNgay1;
        DateTime TuNgay2;
        DateTime DenNgay2;
        public frmPTABCbyValue(DataTable _tbDanhSach, DateTime _TuNgay1, DateTime _DenNgay1, DateTime _TuNgay2, DateTime _DenNgay2)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay1 = _TuNgay1;
            this.DenNgay1 = _DenNgay1;
            this.TuNgay2 = _TuNgay2;
            this.DenNgay2 = _DenNgay2;
            InitializeComponent();
        }

        private void frmPTABCbyValue_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(so sánh T1:(" + this.TuNgay1.ToShortDateString() + " - " + this.DenNgay1.ToShortDateString() + ") và T2:(" + this.TuNgay2.ToShortDateString() + " - " + this.DenNgay2.ToShortDateString() + "))";

                double GiaTriA1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'A' and [iTime] = 1"))
                {
                    GiaTriA1 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriA1 = Math.Round(GiaTriA1, 2);

                double GiaTriB1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'B' and [iTime] = 1"))
                {
                    GiaTriB1 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriB1 = Math.Round(GiaTriB1, 2);

                double GiaTriC1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'C' and [iTime] = 1"))
                {
                    GiaTriC1 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriC1 = Math.Round(GiaTriC1, 2);

                double TongTien1 = GiaTriA1 + GiaTriB1 + GiaTriC1;
                double phantramA1 = (GiaTriA1 * 100) / TongTien1;
                phantramA1 = Math.Round(phantramA1, 2);
                double phantramB1 = (GiaTriB1 * 100) / TongTien1;
                phantramB1 = Math.Round(phantramB1, 2);
                double phantramC1 = (GiaTriC1 * 100) / TongTien1;
                phantramC1 = Math.Round(phantramC1, 2);

                double GiaTriA2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'A' and [iTime] = 2"))
                {
                    GiaTriA2 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriA2 = Math.Round(GiaTriA2, 2);

                double GiaTriB2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'B' and [iTime] = 2"))
                {
                    GiaTriB2 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriB2 = Math.Round(GiaTriB2, 2);

                double GiaTriC2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[ABC] = 'C' and [iTime] = 2"))
                {
                    GiaTriC2 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriC2 = Math.Round(GiaTriC2, 2);

                double TongTien2 = GiaTriA2 + GiaTriB2 + GiaTriC2;
                double phantramA2 = (GiaTriA2 * 100) / TongTien2;
                phantramA2 = Math.Round(phantramA2, 2);
                double phantramB2 = (GiaTriB2 * 100) / TongTien2;
                phantramB2 = Math.Round(phantramB2, 2);
                double phantramC2 = (GiaTriC2 * 100) / TongTien2;
                phantramC2 = Math.Round(phantramC2, 2);

                //pass data into gridNhom
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("giatri1", typeof(double));
                tbNhom.Columns.Add("tylegt1", typeof(double));
                tbNhom.Columns.Add("giatri2", typeof(double));
                tbNhom.Columns.Add("tylegt2", typeof(double));
                tbNhom.Rows.Add("A", GiaTriA1, phantramA1, GiaTriA2, phantramA2);
                tbNhom.Rows.Add("B", GiaTriB1, phantramB1, GiaTriB2, phantramB2);
                tbNhom.Rows.Add("C", GiaTriC1, phantramC1, GiaTriC2, phantramC2);
                tbNhom.Rows.Add("Tổng", TongTien1, 100, TongTien2, 100);
                this.grdNhom.DataSource = tbNhom;

                //Load chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'A' or [nhom] = 'B' or [nhom] = 'C'").CopyToDataTable();
                Series series1 = new Series("% Giá trị T1", ViewType.Bar);
                Series series2 = new Series("% Giá trị T2", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylegt1" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylegt2" });

                //Phân tích
                if (phantramA2 >= phantramA1)
                {
                    lblNhomA.Text = "tăng " + Math.Round((phantramA2 - phantramA1), 2) + "%";
                }
                else
                {
                    lblNhomA.Text = "giảm " + Math.Round((phantramA1 - phantramA2), 2) + "%";
                }

                if (phantramB2 >= phantramB1)
                {
                    lblNhomB.Text = "tăng " + Math.Round((phantramB2 - phantramB1), 2) + "%";
                }
                else
                {
                    lblNhomB.Text = "giảm " + Math.Round((phantramB1 - phantramB2), 2) + "%";
                }

                if (phantramC2 >= phantramC1)
                {
                    lblNhomC.Text = "tăng " + Math.Round((phantramC2 - phantramC1), 2) + "%";
                }
                else
                {
                    lblNhomC.Text = "giảm " + Math.Round((phantramC1 - phantramC2),2) + "%";
                }
                lblT2.Text = TongTien2.ToString();
                if (TongTien2 >= TongTien1)
                {
                    lblSoSanh.Text = "tăng";
                    lblPhanTich.Text = "tăng lên";
                    lblTru.Text = Math.Round((TongTien2 - TongTien1), 2).ToString();
                }
                else
                {
                    lblSoSanh.Text = "giảm";
                    lblPhanTich.Text = "giảm xuống";
                    lblTru.Text = Math.Round((TongTien1 - TongTien2), 2).ToString();
                }
                lblTien.Text = lblTru.Text;
            }
            catch { }
        }
    }
}