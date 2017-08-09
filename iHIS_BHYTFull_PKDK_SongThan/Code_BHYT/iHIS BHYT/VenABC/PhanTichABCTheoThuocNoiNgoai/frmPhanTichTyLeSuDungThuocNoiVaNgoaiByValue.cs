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
    public partial class frmPhanTichTyLeSuDungThuocNoiVaNgoaiByValue : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay;
        DateTime DenNgay;
        public frmPhanTichTyLeSuDungThuocNoiVaNgoaiByValue(DataTable _tbDanhSach, DateTime _TuNgay, DateTime _DenNgay)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            InitializeComponent();
        }

        private void frmPhanTichTyLeSuDungThuocNoiVaNgoaiByValue_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                //Tổng tiền
                double TongTien = 0;
                foreach (DataRow row in this.tbDanhSach.Rows)
                {
                    TongTien += Convert.ToDouble(row["Amount"].ToString());
                }
                TongTien = Math.Round(TongTien, 2);

                //Thành tiền thuốc nội
                string selectNoiA = "[ABC]= 'A' and [CountryName] = 'Việt Nam'";
                double MoneyNoiA = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNoiA))
                {
                    MoneyNoiA += Convert.ToDouble(row["Amount"].ToString());
                }
                MoneyNoiA = Math.Round(MoneyNoiA, 2);

                string selectNoiB = "[ABC]= 'B' and [CountryName] = 'Việt Nam'";
                double MoneyNoiB = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNoiB))
                {
                    MoneyNoiB += Convert.ToDouble(row["Amount"].ToString());
                }
                MoneyNoiB = Math.Round(MoneyNoiB, 2);

                string selectNoiC = "[ABC]= 'C' and [CountryName] = 'Việt Nam'";
                double MoneyNoiC = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNoiC))
                {
                    MoneyNoiC += Convert.ToDouble(row["Amount"].ToString());
                }
                MoneyNoiC = Math.Round(MoneyNoiC, 2);

                //Tỷ lệ tiền thuốc nội
                double TyleNoiA = (MoneyNoiA * 100) / TongTien;
                TyleNoiA = Math.Round(TyleNoiA, 2);
                double TyleNoiB = (MoneyNoiB * 100) / TongTien;
                TyleNoiB = Math.Round(TyleNoiB, 2);
                double TyleNoiC = (MoneyNoiC * 100) / TongTien;
                TyleNoiC = Math.Round(TyleNoiC, 2);

                //Thành tiền thuốc ngoại
                string selectNgoaiA = "[ABC]= 'A' and [CountryName] <> 'Việt Nam'";
                double MoneyNgoaiA = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNgoaiA))
                {
                    MoneyNgoaiA += Convert.ToDouble(row["Amount"].ToString());
                }
                MoneyNgoaiA = Math.Round(MoneyNgoaiA, 2);

                string selectNgoaiB = "[ABC]= 'B' and [CountryName] <> 'Việt Nam'";
                double MoneyNgoaiB = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNgoaiB))
                {
                    MoneyNgoaiB += Convert.ToDouble(row["Amount"].ToString());
                }
                MoneyNgoaiB = Math.Round(MoneyNgoaiB, 2);

                string selectNgoaiC = "[ABC]= 'C' and [CountryName] <> 'Việt Nam'";
                double MoneyNgoaiC = 0;
                foreach (DataRow row in this.tbDanhSach.Select(selectNgoaiC))
                {
                    MoneyNgoaiC += Convert.ToDouble(row["Amount"].ToString());
                }
                MoneyNgoaiC = Math.Round(MoneyNgoaiC, 2);

                //Tỷ lệ tiền thuốc ngoại
                double TyleNgoaiA = (MoneyNgoaiA * 100) / TongTien;
                TyleNgoaiA = Math.Round(TyleNgoaiA, 2);
                double TyleNgoaiB = (MoneyNgoaiB * 100) / TongTien;
                TyleNgoaiB = Math.Round(TyleNgoaiB, 2);
                double TyleNgoaiC = (MoneyNgoaiC * 100) / TongTien;
                TyleNgoaiC = Math.Round(TyleNgoaiC, 2);

                //Số lương tổng từng loại
                double TongA = MoneyNoiA + MoneyNgoaiA;
                double TongB = MoneyNoiB + MoneyNgoaiB;
                double TongC = MoneyNoiC + MoneyNgoaiC;

                //tỷ lệ tổng 
                double TyleTongA = (TongA * 100) / TongTien;
                TyleTongA = Math.Round(TyleTongA, 2);
                double TyleTongB = (TongB * 100) / TongTien;
                TyleTongB = Math.Round(TyleTongB, 2);
                double TyleTongC = (TongC * 100) / TongTien;
                TyleTongC = Math.Round(TyleTongC, 2);

                double TongTienNoi = MoneyNoiA + MoneyNoiB + MoneyNoiC;
                double TongTienNgoai = MoneyNgoaiA + MoneyNgoaiB + MoneyNgoaiC;
                double TongTyLeNoi = TyleNoiA + TyleNoiB + TyleNoiC;
                double TongTyleNgoai = TyleNgoaiA + TyleNgoaiB + TyleNgoaiC;

                //pass data into grid
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("thanhtiennoi", typeof(double));
                tbNhom.Columns.Add("tylethuocnoi", typeof(double));
                tbNhom.Columns.Add("thanhtienngoai", typeof(double));
                tbNhom.Columns.Add("tylethuocngoai", typeof(double));
                tbNhom.Columns.Add("thanhtientong", typeof(double));
                tbNhom.Columns.Add("tyletong", typeof(double));
                tbNhom.Rows.Add("A", MoneyNoiA, TyleNoiA, MoneyNgoaiA, TyleNgoaiA, TongA, TyleTongA);
                tbNhom.Rows.Add("B", MoneyNoiB, TyleNoiB, MoneyNgoaiB, TyleNgoaiB, TongB, TyleTongB);
                tbNhom.Rows.Add("C", MoneyNoiC, TyleNoiC, MoneyNgoaiC, TyleNgoaiC, TongC, TyleTongC);
                tbNhom.Rows.Add("Tổng", TongTienNoi, TongTyLeNoi, TongTienNgoai, TongTyleNgoai, TongTien, 100);
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
                    lblSoSanhA.Text = "Cao";
                    lblA.Text = (TyleNoiA - TyleNgoaiA).ToString() +" %";
                }
                else
                {
                    lblSoSanhA.Text = "Thấp";
                    lblA.Text = (TyleNgoaiA - TyleNoiA).ToString() + " %";
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
            catch { }
        }
    }
}