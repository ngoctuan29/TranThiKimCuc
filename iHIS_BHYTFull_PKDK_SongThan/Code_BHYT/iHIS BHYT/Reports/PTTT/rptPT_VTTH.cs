using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptPhauThuThuatVTTH : DevExpress.XtraReports.UI.XtraReport
    {
        int iSTT = 0;
        public rptPhauThuThuatVTTH()
        {
            InitializeComponent();
        }

        private void rptPhauThuThuatVTTH_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.lbNames.Text = names;
                this.lbAddress.Text = saddress;
                this.lbPhone.Text = sphone;
                this.pbImage.ImageUrl = simage;
                this.txtNgayKham.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            }
            catch { }
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iSTT += 1;
            this.txtNo.Text = iSTT.ToString() + ".";
        }

    }
}
