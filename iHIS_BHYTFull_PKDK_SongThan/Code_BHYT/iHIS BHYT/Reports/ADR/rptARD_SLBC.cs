using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraCharts;

namespace Ps.Clinic.Reports
{
    public partial class rptARD_SLBC : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime from, to;
        private DataTable dtReport;
        public rptARD_SLBC(DateTime _from, DateTime _to, DataTable _dtReport)
        {
            this.from = _from;
            this.to = _to;
            this.dtReport = _dtReport;
            InitializeComponent();
        }

        private void rptARD_SLBC_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDate.Text = "Từ ngày " + this.from.ToString("dd/MM/yyyy") + " đến ngày " + this.to.ToString("dd/MM/yyyy");
            // chart
            chart_Report.DataSource = this.dtReport;
            Series series1 = new Series("Số lượng", ViewType.Bar);
            chart_Report.Series.Add(series1);
            series1.ArgumentDataMember = "Thang";
            series1.ValueDataMembers.AddRange(new string[] { "SoLuong" });
            //ket luan
            DataRow[] drMax = dtReport.Select("[SoLuong] = MAX([SoLuong])");
            DataRow[] drMin = dtReport.Select("[SoLuong] = Min([SoLuong])");
            txtNhanXet.Text = "Số lượng báo cáo ARD ghi nhận ít nhất vào tháng " + drMin[0][1].ToString() + " ." +
            "Số lượng báo cáo ARD nhiều nhất vào tháng " + drMax[0][1].ToString();
        }
    }
}
