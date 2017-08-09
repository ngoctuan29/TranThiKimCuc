using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptNhapKho : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rptNhapKho()
        {
            InitializeComponent();
        }
                
        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt += 1;
            txtNo.Text = stt.ToString() + "."; 
        }

        private void rptNhapKho_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            this.lbSoyte.Text = ssoyte;
            this.lbNames.Text = names;
            this.lbAddress.Text = saddress;
            this.lbPhone.Text = sphone + " " + semail;
            this.pbImage.ImageUrl = simage;
            this.lbChutien.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prAmountTotal.Value));
        }

        
    }
}
