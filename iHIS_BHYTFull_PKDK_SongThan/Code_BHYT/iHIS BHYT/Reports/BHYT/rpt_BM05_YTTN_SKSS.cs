using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rpt_BM05_YTTN_SKSS : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BM05_YTTN_SKSS()
        {
            InitializeComponent();
        }

        private void rpt_BM05_YTTN_TNTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.lbNames.Text = names;
                string printDate = Utils.DateServer().ToString("dd/MM/yyyy");
                this.lbngay.Text = " Ngày " + printDate.Substring(0, 2) + " tháng " + printDate.Substring(3, 2) + " năm " + printDate.Substring(6, 4);
            }
            catch { }
        }

    }
}
