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
    public partial class frmPhanTichVENbyChungLoai : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay1;
        DateTime DenNgay1;
        DateTime TuNgay2;
        DateTime DenNgay2;
        public frmPhanTichVENbyChungLoai(DataTable _tbDanhSach, DateTime _TuNgay1, DateTime _DenNgay1, DateTime _TuNgay2, DateTime _DenNgay2)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay1 = _TuNgay1;
            this.DenNgay1 = _DenNgay1;
            this.TuNgay2 = _TuNgay2;
            this.DenNgay2 = _DenNgay2;
            InitializeComponent();
        }

        private void frmPhanTichVENbyChungLoai_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(so sánh T1:(" + this.TuNgay1.ToShortDateString() + " - " + this.DenNgay1.ToShortDateString() + ") và T2:(" + this.TuNgay2.ToShortDateString() + " - " + this.DenNgay2.ToShortDateString() + "))";

                double SlV1 = this.tbDanhSach.Select("[VEN] = 'V' and [iTime] = 1").Count();
                double SlE1 = this.tbDanhSach.Select("[VEN] = 'E' and [iTime] = 1").Count();
                double SlN1 = this.tbDanhSach.Select("[VEN] = 'N' and [iTime] = 1").Count();
                double TongThuoc1 = SlV1 + SlE1 + SlN1;

                double SlV2 = this.tbDanhSach.Select("[VEN] = 'V' and [iTime] = 2").Count();
                double SlE2 = this.tbDanhSach.Select("[VEN] = 'E' and [iTime] = 2").Count();
                double SlN2 = this.tbDanhSach.Select("[VEN] = 'N' and [iTime] = 2").Count();
                double TongThuoc2 = SlV2 + SlE2 + SlN2;

                double phantramV1 = (SlV1 * 100) / TongThuoc1;
                phantramV1 = Math.Round(phantramV1, 2);
                double phantramE1 = (SlE1 * 100) / TongThuoc1;
                phantramE1 = Math.Round(phantramE1, 2);
                double phantramN1 = (SlN1 * 100) / TongThuoc1;
                phantramN1 = Math.Round(phantramN1, 2);

                double phantramV2 = (SlV2 * 100) / TongThuoc2;
                phantramV2 = Math.Round(phantramV2, 2);
                double phantramE2 = (SlE2 * 100) / TongThuoc2;
                phantramE2 = Math.Round(phantramE2, 2);
                double phantramN2 = (SlN2 * 100) / TongThuoc2;
                phantramN2 = Math.Round(phantramN2, 2);

                //pass data into gridNhom
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("chungloai1", typeof(double));
                tbNhom.Columns.Add("tylecl1", typeof(double));
                tbNhom.Columns.Add("chungloai2", typeof(double));
                tbNhom.Columns.Add("tylecl2", typeof(double));
                tbNhom.Rows.Add("V", SlV1, phantramV1, SlV2, phantramV2);
                tbNhom.Rows.Add("E", SlE1, phantramE1, SlE2, phantramE2);
                tbNhom.Rows.Add("N", SlN1, phantramN1, SlN2, phantramN2);
                tbNhom.Rows.Add("Tổng", TongThuoc1, 100, TongThuoc2, 100);
                this.grdNhom.DataSource = tbNhom;

                //Load chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'V' or [nhom] = 'E' or [nhom] = 'N'").CopyToDataTable();
                Series series1 = new Series("% Chủng loại T1", ViewType.Bar);
                Series series2 = new Series("% Chủng loại T2", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylecl1" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylecl2" });

                //Phân tích
                if (phantramV2 >= phantramV1)
                {
                    lblNhomV.Text = "tăng " + Math.Round((phantramV2 - phantramV1), 2) + "%";
                }
                else
                {
                    lblNhomV.Text = "giảm " + Math.Round((phantramV1 - phantramV2), 2) + "%";
                }

                if (phantramE2 >= phantramE1)
                {
                    lblNhomE.Text = "tăng " + Math.Round((phantramE2 - phantramE1), 2) + "%";
                }
                else
                {
                    lblNhomE.Text = "giảm " + Math.Round((phantramE1 - phantramE2), 2) + "%";
                }

                if (phantramN2 >= phantramN1)
                {
                    lblNhomN.Text = "tăng " + Math.Round((phantramN2 - phantramN1), 2) + "%";
                }
                else
                {
                    lblNhomN.Text = "giảm " + Math.Round((phantramN1 - phantramN2),2) + "%";
                }

                double VE1 = Math.Round((phantramE1 + phantramV1), 2);
                double VE2 = Math.Round((phantramE2 + phantramV2), 2);
                lblVE2.Text = VE2 + "%";
                if (VE2 >= VE1)
                {
                    lblSoSanh.Text = "tăng";
                    lblTru.Text = Math.Round((VE2 - VE1), 2) + "%";
                }
                else
                {
                    lblSoSanh.Text = "giảm";
                    lblTru.Text = Math.Round((VE1 - VE2), 2) + "%";
                }
            }
            catch { }
        }
    }
}