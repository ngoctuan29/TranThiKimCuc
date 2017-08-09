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
    public partial class frmPTABCbyChungLoai : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay1;
        DateTime DenNgay1;
        DateTime TuNgay2;
        DateTime DenNgay2;
        public frmPTABCbyChungLoai(DataTable _tbDanhSach, DateTime _TuNgay1, DateTime _DenNgay1, DateTime _TuNgay2, DateTime _DenNgay2)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay1 = _TuNgay1;
            this.DenNgay1 = _DenNgay1;
            this.TuNgay2 = _TuNgay2;
            this.DenNgay2 = _DenNgay2;
            InitializeComponent();
        }

        private void frmPTABCbyChungLoai_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(so sánh T1:(" + this.TuNgay1.ToShortDateString() + " - " + this.DenNgay1.ToShortDateString() + ") và T2:(" + this.TuNgay2.ToShortDateString() + " - " + this.DenNgay2.ToShortDateString() + "))";

                double SlA1 = this.tbDanhSach.Select("[ABC] = 'A' and [iTime] = 1").Count();
                double SlB1 = this.tbDanhSach.Select("[ABC] = 'B' and [iTime] = 1").Count();
                double SlC1 = this.tbDanhSach.Select("[ABC] = 'C' and [iTime] = 1").Count();
                double TongThuoc1 = SlA1 + SlB1 + SlC1;

                double SlA2 = this.tbDanhSach.Select("[ABC] = 'A' and [iTime] = 2").Count();
                double SlB2 = this.tbDanhSach.Select("[ABC] = 'B' and [iTime] = 2").Count();
                double SlC2 = this.tbDanhSach.Select("[ABC] = 'C' and [iTime] = 2").Count();
                double TongThuoc2 = SlA2 + SlB2 + SlC2;

                double phantramA1 = (SlA1 * 100) / TongThuoc1;
                phantramA1 = Math.Round(phantramA1, 2);
                double phantramB1 = (SlB1 * 100) / TongThuoc1;
                phantramB1 = Math.Round(phantramB1, 2);
                double phantramC1 = (SlC1 * 100) / TongThuoc1;
                phantramC1 = Math.Round(phantramC1, 2);

                double phantramA2 = (SlA2 * 100) / TongThuoc2;
                phantramA2 = Math.Round(phantramA2, 2);
                double phantramB2 = (SlB2 * 100) / TongThuoc2;
                phantramB2 = Math.Round(phantramB2, 2);
                double phantramC2 = (SlC2 * 100) / TongThuoc2;
                phantramC2 = Math.Round(phantramC2, 2);

                //pass data into gridNhom
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("chungloai1", typeof(double));
                tbNhom.Columns.Add("tylecl1", typeof(double));
                tbNhom.Columns.Add("chungloai2", typeof(double));
                tbNhom.Columns.Add("tylecl2", typeof(double));
                tbNhom.Rows.Add("A", SlA1, phantramA1, SlA2, phantramA2);
                tbNhom.Rows.Add("B", SlB1, phantramB1, SlB2, phantramB2);
                tbNhom.Rows.Add("C", SlC1, phantramC1, SlC2, phantramC2);
                tbNhom.Rows.Add("Tổng", TongThuoc1, 100, TongThuoc2, 100);
                this.grdNhom.DataSource = tbNhom;

                //Load chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'A' or [nhom] = 'B' or [nhom] = 'C'").CopyToDataTable();
                Series series1 = new Series("% Chủng loại T1", ViewType.Bar);
                Series series2 = new Series("% Chủng loại T2", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylecl1" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylecl2" });

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
                    lblNhomC.Text = "giảm " + Math.Round((phantramC1 - phantramC2), 2) + "%";
                }
                if (TongThuoc2 >= TongThuoc1)
                {
                    lblSoSanh.Text = "tăng";
                    lblTru.Text = Math.Round((TongThuoc2 - TongThuoc1), 2).ToString();
                    lblSoThuoc.Text = lblTru.Text;
                    lblPhantich.Text = "được thêm vào";
                }
                else
                {
                    lblSoSanh.Text = "giảm";
                    lblTru.Text = Math.Round((TongThuoc1 - TongThuoc2), 2).ToString();
                    lblSoThuoc.Text = lblTru.Text;
                    lblPhantich.Text = "bị loại khỏi";
                }
            }
            catch { }
        }
    }
}