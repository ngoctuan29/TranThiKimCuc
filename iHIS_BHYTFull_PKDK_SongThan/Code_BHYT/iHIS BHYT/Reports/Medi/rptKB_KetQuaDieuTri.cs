using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptKetQuaDieuTri : DevExpress.XtraReports.UI.XtraReport
    {
        private int iSTT = 0;
        public rptKetQuaDieuTri()
        {
            InitializeComponent();
        }
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iSTT += 1;
            lbSTT.Text = iSTT.ToString();
        }

    }
}
