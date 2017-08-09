using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
using ClinicModel;
using ClinicBLL;
namespace Ps.Clinic.Reports
{
    public partial class rpt_KB_GiayCV_A4 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_KB_GiayCV_A4()
        {
            InitializeComponent();
        }

        private void rptChidinhBV01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.lbSoYTe.Text = ssoyte;
                this.lbNames.Text = names;
                this.txtDateprint.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
                //this.txtPrint.Text = "Bệnh Viện Điện Tử .Net - Ngày in: " + DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToShortTimeString();
            }
            catch { }
        }
        
    }
}
