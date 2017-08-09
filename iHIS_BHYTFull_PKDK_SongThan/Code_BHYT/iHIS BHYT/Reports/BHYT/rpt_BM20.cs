using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rpt_BM20 : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime dtimeServer = new DateTime();

        public rpt_BM20(DateTime _dtimeServer)
        {
            InitializeComponent();
            this.dtimeServer = _dtimeServer;
        }

        private void rpt_Test_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtpri.Text = "Ngày " + this.dtimeServer.Date.Day + " tháng " + this.dtimeServer.Date.Month + " năm " + this.dtimeServer.Date.Year;
        }
    }
}
