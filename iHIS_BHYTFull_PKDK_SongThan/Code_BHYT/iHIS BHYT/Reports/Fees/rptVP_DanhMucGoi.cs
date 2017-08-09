using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rptVP_DanhMucGoi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptVP_DanhMucGoi()
        {
            InitializeComponent();
        }

        private void rptVP_DanhMucGoi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                lbngay.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            }
            catch { }
        }

    }
}
