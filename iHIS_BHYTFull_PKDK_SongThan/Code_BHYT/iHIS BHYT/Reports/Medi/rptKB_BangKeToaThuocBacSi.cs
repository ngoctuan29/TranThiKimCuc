using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rpt_KB_BangKeToaThuocBacSi : DevExpress.XtraReports.UI.XtraReport
    {
        //private Int32 runNumber = 0;
        public rpt_KB_BangKeToaThuocBacSi()
        {
            InitializeComponent();
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.runNumber += 1;
            //this.lbSTT.Text = this.runNumber.ToString();
        }

        private void rpt_KB_BangKeToaThuocBacSi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty, note = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                lbNames.Text = names;
                lbAddress.Text = saddress;
                lbPhone.Text = sphone;
                lbEmail.Text = semail;
                pbImage.ImageUrl = simage;
                lbngay.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            }
            catch { }
        }

    }
}
