using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptDMNgheNghiep : DevExpress.XtraReports.UI.XtraReport
    {
        private Int32 iSTT = 0;
        public rptDMNgheNghiep()
        {
            InitializeComponent();
        }

        private void rptDMNgheNghiep_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtNgayIn.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iSTT++;
            lbSTT.Text = iSTT.ToString();
        }

    }
}
