using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rpt_BMTE : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime dtimeServer = new DateTime();
        public rpt_BMTE(DateTime _dtimeServer)
        {
            InitializeComponent();
            this.dtimeServer = _dtimeServer;
        }

        private void rpt_Test_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txt1.Text = "Ngày " + this.dtimeServer.Date.Day.ToString() + " tháng " + this.dtimeServer.Date.Month.ToString() + " năm " + this.dtimeServer.Date.Year.ToString();
            this.txt2.Text = "Ngày " + this.dtimeServer.Date.Day.ToString() + " tháng " + this.dtimeServer.Date.Month.ToString() + " năm " + this.dtimeServer.Date.Year.ToString();
            this.txtPrint.Text = string.Empty;
        }

    }
}
