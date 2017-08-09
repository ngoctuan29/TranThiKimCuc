using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptDMDichVuGia : DevExpress.XtraReports.UI.XtraReport
    {
        private Int32 iSTT = 0;
        public rptDMDichVuGia()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iSTT++;
            lbstt.Text = iSTT.ToString();
        }

    }
}
