using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rptDMThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDMThuoc()
        {
            InitializeComponent();
        }

        private void rptDMThuoc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbngay.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

    }
}
