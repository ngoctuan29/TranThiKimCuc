using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptChiphidieutri : DevExpress.XtraReports.UI.XtraReport
    {
        private int s_stt = 0;
        private string sLaMA = string.Empty;
        public rptChiphidieutri()
        {
            InitializeComponent();
        }

        private void rptChiphidieutri_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            lbNames.Text = names;
            lbAddress.Text = saddress;
            lbPhone.Text = sphone;
            pbImage.ImageUrl = simage;
            txtDateEnd.Text = DateTime.Now.ToString();
            txtDateprint.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            s_stt += 1;
            sLaMA = IntToLaMa(s_stt);
            lbGroupSTT.Text = sLaMA;
        }
                
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbGroupTotalSTT.Text = "Cộng " + sLaMA;
        }

        private string IntToLaMa(Int32 iSTT)
        {
            string sTemp = string.Empty;
            try
            {
                if (iSTT == 1)
                    sTemp = "I";
                else if (iSTT == 2)
                    sTemp = "II";
                else if (iSTT == 3)
                    sTemp = "III";
                else if (iSTT == 4)
                    sTemp = "IV";
                else if (iSTT == 5)
                    sTemp = "V";
                else if (iSTT == 6)
                    sTemp = "VI";
                else if (iSTT == 7)
                    sTemp = "VII";
                else if (iSTT == 8)
                    sTemp = "VIII";
                else if (iSTT == 9)
                    sTemp = "IX";
                else if (iSTT == 10)
                    sTemp = "X";
            }
            catch { }
            return sTemp;
        }
    }
}
