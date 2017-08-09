using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptThongKeAABC : DevExpress.XtraReports.UI.XtraReport
    {
        private int page = 0;
        public rptThongKeAABC()
        {
            InitializeComponent();
        }

        private void PageFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //page += 1;
            //lblpage.Text = page.ToString();
        }

        private void BottomMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           //page += 1;
            //lblpage.Text = page.ToString();
        }

        private void BottomMargin_AfterPrint(object sender, EventArgs e)
        {
            page += 1;
            lblpage.Text = page.ToString();
        }
    }
}
