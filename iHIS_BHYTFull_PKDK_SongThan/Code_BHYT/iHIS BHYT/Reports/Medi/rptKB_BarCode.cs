using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptBarCode : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBarCode()
        {
            InitializeComponent();
        }

        private void rptBarCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //txtPrintDate.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

    }
}
