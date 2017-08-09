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

namespace Ps.Clinic.VenABC.PhanTichABCTheoThuocNoiNgoai
{
    public partial class frmPhanTichTyLeSuDungThuocNoiVaNgoai : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichTyLeSuDungThuocNoiVaNgoai(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichTyLeSuDungThuocNoiVaNgoai_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                //Tổng thuốc
                double TongThuoc = this.tbDanhSach.Rows.Count;

                //Sô lượng thuốc nội
                string selectNoiA = "[ABC]= 'A' and [CountryName] = 'Việt Nam'";
                double SlNoiA = this.tbDanhSach.Select(selectNoiA).Count();

                string selectNoiB = "[ABC]= 'B' and [CountryName] = 'Việt Nam'";
                double SlNoiB = this.tbDanhSach.Select(selectNoiB).Count();

                string selectNoiC = "[ABC]= 'C' and [CountryName] = 'Việt Nam'";
                double SlNoiC = this.tbDanhSach.Select(selectNoiC).Count();

                //tỷ lệ thuốc nội
                double TyleNoiA = (SlNoiA * 100) / TongThuoc;
                TyleNoiA = Math.Round(TyleNoiA, 2);
                double TyleNoiB = (SlNoiB * 100) / TongThuoc;
                TyleNoiB = Math.Round(TyleNoiB, 2);
                double TyleNoiC = (SlNoiC * 100) / TongThuoc;
                TyleNoiC = Math.Round(TyleNoiC, 2);

                //Số lượng thuốc ngoại
                string selectNgoaiA = "[ABC]= 'A' and [CountryName] <> 'Việt Nam'";
                double SlNgoaiA = this.tbDanhSach.Select(selectNgoaiA).Count();

                string selectNgoaiB = "[ABC]= 'B' and [CountryName] <> 'Việt Nam'";
                double SlNgoaiB = this.tbDanhSach.Select(selectNgoaiB).Count();

                string selectNgoaiC = "[ABC]= 'C' and [CountryName] <> 'Việt Nam'";
                double SlNgoaiC = this.tbDanhSach.Select(selectNgoaiC).Count();

                //tỷ lệ thuốc Ngoại
                double TyleNgoaiA = (SlNgoaiA * 100) / TongThuoc;
                TyleNgoaiA = Math.Round(TyleNgoaiA, 2);
                double TyleNgoaiB = (SlNgoaiB * 100) / TongThuoc;
                TyleNgoaiB = Math.Round(TyleNgoaiB, 2);
                double TyleNgoaiC = (SlNgoaiC * 100) / TongThuoc;
                TyleNgoaiC = Math.Round(TyleNgoaiC, 2);

                //Số lương tổng từng loại
                double TongA = SlNoiA + SlNgoaiA;
                double TongB = SlNoiB + SlNgoaiB;
                double TongC = SlNoiC + SlNgoaiC;

                //tỷ lệ tổng 
                double TyleTongA = (TongA * 100) / TongThuoc;
                TyleTongA = Math.Round(TyleTongA, 2);
                double TyleTongB = (TongB * 100) / TongThuoc;
                TyleTongB = Math.Round(TyleTongB, 2);
                double TyleTongC = (TongC * 100) / TongThuoc;
                TyleTongC = Math.Round(TyleTongC, 2);

                double TongSlNoi = SlNoiA + SlNoiB + SlNoiC;
                double TongSlNgoai = SlNgoaiA + SlNgoaiB + SlNgoaiC;
                double TongTyLeNoi = TyleNoiA + TyleNoiB + TyleNoiC;
                double TongTyleNgoai = TyleNgoaiA + TyleNgoaiB + TyleNgoaiC;

                //pass data into grid
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("slthuocnoi", typeof(double));
                tbNhom.Columns.Add("tylethuocnoi", typeof(double));
                tbNhom.Columns.Add("slthuocngoai", typeof(double));
                tbNhom.Columns.Add("tylethuocngoai", typeof(double));
                tbNhom.Columns.Add("sltong", typeof(double));
                tbNhom.Columns.Add("tyletong", typeof(double));
                tbNhom.Rows.Add("A", SlNoiA, TyleNoiA, SlNgoaiA, TyleNgoaiA, TongA, TyleTongA);
                tbNhom.Rows.Add("B", SlNoiB, TyleNoiB, SlNgoaiB, TyleNgoaiB, TongB, TyleTongB);
                tbNhom.Rows.Add("C", SlNoiC, TyleNoiC, SlNgoaiC, TyleNgoaiC, TongC, TyleTongC);
                tbNhom.Rows.Add("Tổng", TongSlNoi, TongTyLeNoi, TongSlNgoai, TongTyleNgoai, TongThuoc, 100);
                grdNhom.DataSource = tbNhom;

                //so sánh
                if (TongTyLeNoi > TongTyleNgoai)
                {
                    lblSoSanhNoiNgoai.Text = "Cao";
                    lblNoiNgoai.Text = (TongTyLeNoi - TongTyleNgoai).ToString() + " %";
                }
                else
                {
                    lblSoSanhNoiNgoai.Text = "Thấp";
                    lblNoiNgoai.Text = (TongTyleNgoai - TongTyLeNoi).ToString() + " %";
                }
                if (TyleNoiA > TyleNgoaiA)
                {
                    lblSoSanhNoiNgoaiA.Text = "Cao";
                    lblNoiNgoaiA.Text = (TyleNoiA - TyleNgoaiA).ToString() + " %";
                }
                else
                {
                    lblSoSanhNoiNgoaiA.Text = "Thấp";
                    lblNoiNgoaiA.Text = (TyleNgoaiA - TyleNoiA).ToString() + " %";
                }
                // chart
                chrNhom.DataSource = tbNhom.Select("[nhom] = 'A' or [nhom] = 'B' or [nhom] = 'C'").CopyToDataTable();
                Series series1 = new Series("% Thuốc nội", ViewType.Bar);
                Series series2 = new Series("% Thuốc ngoại", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylethuocnoi" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylethuocngoai" });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}