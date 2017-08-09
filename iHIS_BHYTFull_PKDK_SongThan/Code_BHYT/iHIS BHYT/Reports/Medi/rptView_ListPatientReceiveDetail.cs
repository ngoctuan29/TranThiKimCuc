using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class view_KB_ListPatientReceiveDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public view_KB_ListPatientReceiveDetail()
        {
            InitializeComponent();
        }

        private void view_KB_ListPatientReceiveDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbngay.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

    }
}
