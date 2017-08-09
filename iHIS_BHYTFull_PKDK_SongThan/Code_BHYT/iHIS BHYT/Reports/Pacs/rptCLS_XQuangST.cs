using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports.Pacs
{
    public partial class rptCLS_XQuangST : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCLS_XQuangST()
        {
            InitializeComponent();
        }

        private void rptCLS_XQuangST_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                pbImage.ImageUrl = simage;
            }
            catch { }
        }
    }
}
