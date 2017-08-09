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
    public partial class frmPhanTichVenbyValue : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay1;
        DateTime DenNgay1;
        DateTime TuNgay2;
        DateTime DenNgay2;
        public frmPhanTichVenbyValue(DataTable _tbDanhSach, DateTime _TuNgay1, DateTime _DenNgay1, DateTime _TuNgay2, DateTime _DenNgay2)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay1 = _TuNgay1;
            this.DenNgay1 = _DenNgay1;
            this.TuNgay2 = _TuNgay2;
            this.DenNgay2 = _DenNgay2;
            InitializeComponent();
        }

        private void frmPhanTichVenbyValue_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(so sánh T1:(" + this.TuNgay1.ToShortDateString() + " - " + this.DenNgay1.ToShortDateString() + ") và T2:(" + this.TuNgay2.ToShortDateString() + " - " + this.DenNgay2.ToShortDateString() + "))";

                double GiaTriV1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'V' and [iTime] = 1"))
                {
                    GiaTriV1 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriV1 = Math.Round(GiaTriV1, 2);

                double GiaTriE1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'E' and [iTime] = 1"))
                {
                    GiaTriE1 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriE1 = Math.Round(GiaTriE1, 2);

                double GiaTriN1 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'N' and [iTime] = 1"))
                {
                    GiaTriN1 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriN1 = Math.Round(GiaTriN1, 2);

                double TongTien1 = GiaTriV1 + GiaTriE1 + GiaTriN1;
                double phantramV1 = (GiaTriV1 * 100) / TongTien1;
                phantramV1 = Math.Round(phantramV1, 2);
                double phantramE1 = (GiaTriE1 * 100) / TongTien1;
                phantramE1 = Math.Round(phantramE1, 2);
                double phantramC1 = (GiaTriN1 * 100) / TongTien1;
                phantramC1 = Math.Round(phantramC1, 2);

                double GiaTriV2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'V' and [iTime] = 2"))
                {
                    GiaTriV2 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriV2 = Math.Round(GiaTriV2, 2);

                double GiaTriE2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'E' and [iTime] = 2"))
                {
                    GiaTriE2 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriE2 = Math.Round(GiaTriE2, 2);

                double GiaTriN2 = 0;
                foreach (DataRow row in this.tbDanhSach.Select("[VEN] = 'N' and [iTime] = 2"))
                {
                    GiaTriN2 += Convert.ToDouble(row["ThanhTien"].ToString());
                }
                GiaTriN2 = Math.Round(GiaTriN2, 2);

                double TongTien2 = GiaTriV2 + GiaTriE2 + GiaTriN2;
                double phantramV2 = (GiaTriV2 * 100) / TongTien2;
                phantramV2 = Math.Round(phantramV2, 2);
                double phantramE2 = (GiaTriE2 * 100) / TongTien2;
                phantramE2 = Math.Round(phantramE2, 2);
                double phantramN2 = (GiaTriN2 * 100) / TongTien2;
                phantramN2 = Math.Round(phantramN2, 2);

                //pass data into gridNhom
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("giatri1", typeof(double));
                tbNhom.Columns.Add("tylegt1", typeof(double));
                tbNhom.Columns.Add("giatri2", typeof(double));
                tbNhom.Columns.Add("tylegt2", typeof(double));
                tbNhom.Rows.Add("V", GiaTriV1, phantramV1, GiaTriV2, phantramV2);
                tbNhom.Rows.Add("E", GiaTriE1, phantramE1, GiaTriE2, phantramE2);
                tbNhom.Rows.Add("N", GiaTriN1, phantramC1, GiaTriN2, phantramN2);
                tbNhom.Rows.Add("Tổng", TongTien1, 100, TongTien2, 100);
                this.grdNhom.DataSource = tbNhom;

                //Load chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'V' or [nhom] = 'E' or [nhom] = 'N'").CopyToDataTable();
                Series series1 = new Series("% Giá trị T1", ViewType.Bar);
                Series series2 = new Series("% Giá trị T2", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylegt1" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylegt2" });

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

                if (phantramN2 >= phantramC1)
                {
                    lblNhomN.Text = "tăng " + Math.Round((phantramN2 - phantramC1), 2) + "%";
                }
                else
                {
                    lblNhomN.Text = "giảm " + Math.Round((phantramC1 - phantramN2),2) + "%";
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