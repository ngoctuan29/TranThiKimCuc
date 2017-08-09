using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptHoSoKhamBenh : DevExpress.XtraReports.UI.XtraReport
    {

        public rptHoSoKhamBenh()
        {
            InitializeComponent();
        }

        private void rptHoSoKhamBenh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtDateEnd.Text = DateTime.Now.ToString();
            txtDateprint.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            lbNames.Text = names;
            lbAddress.Text = saddress;
            lbPhone.Text = sphone;
            pbImage.ImageUrl = simage;
        }
                
    }
}
