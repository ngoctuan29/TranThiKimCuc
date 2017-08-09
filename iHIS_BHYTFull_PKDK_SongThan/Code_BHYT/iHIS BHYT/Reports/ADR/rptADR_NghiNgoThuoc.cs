using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Linq;

namespace Ps.Clinic.Reports
{
    public partial class rptADR_NghiNgoThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime from, to;
        private DataTable dtDuongDung = new DataTable();
        private DataTable dtATC = new DataTable();
        private DataTable dtNghiNgo = new DataTable();

        public rptADR_NghiNgoThuoc(DateTime _from, DateTime _to,DataTable _dtDuongDung, DataTable _dtATC, DataTable _dtNghiNgo)
        {
            this.from = _from;
            this.to = _to;
            this.dtDuongDung = _dtDuongDung;
            this.dtATC = _dtATC;
            this.dtNghiNgo = _dtNghiNgo;
            InitializeComponent();
        }

        private void rptADR_NghiNgoThuoc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDate.Text = "Từ ngày " + this.from.ToString("dd/MM/yyyy") + " đến ngày " + this.to.ToString("dd/MM/yyyy");

            DataRow[] drMaxDuongDung = dtDuongDung.Select("[SoLuong] = MAX([SoLuong])");
            string klDuongDung = "Nhận thấy, phản ứng có hại xảy ra nhiều nhất khi dùng thuốc ";
            for (int i = 0; i < drMaxDuongDung.Count(); i++)
            {
                klDuongDung += drMaxDuongDung[i][1].ToString() + " ,";
            }
            klDuongDung = klDuongDung.TrimEnd(',');
            klDuongDung += "chiếm " + drMaxDuongDung[0][3].ToString() + "%";
            txtNhanXetDuongDung.Text = klDuongDung;

            DataRow[] drMaxATC = dtATC.Select("[SoLuong] = MAX([SoLuong])");
            string klATC = "Nhận thấy, nhóm ";
            for (int i = 0; i < drMaxATC.Count(); i++)
            {
                klATC += drMaxATC[i][2].ToString() + " ,";
            }
            klATC = klATC.TrimEnd(',');
            klATC += "ghi nhận nhiều nhất, chiếm tỷ lệ " + drMaxATC[0][4].ToString() + "%";
            txtNhanXetATC.Text = klATC;
        }
    }
}
