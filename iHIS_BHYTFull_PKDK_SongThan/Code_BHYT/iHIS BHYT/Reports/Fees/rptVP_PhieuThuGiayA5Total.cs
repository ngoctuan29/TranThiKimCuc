using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rptVP_PhieuThuGiayA5Total : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rptVP_PhieuThuGiayA5Total()
        {
            InitializeComponent();
        }

        private void rptPhieuThu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.lbNames.Text = names;
                this.lbAddress.Text = saddress;
                this.lbPhone.Text = sphone;
                this.pbImage.ImageUrl = simage;
                DateTime dtWorking = Utils.DateTimeServer();
                this.txtDate.Text = dtWorking.Date.Hour + ":" + dtWorking.Date.Minute + " ,ngày " + dtWorking.Date.Day.ToString() + " tháng " + dtWorking.Date.Month.ToString() + " năm " + dtWorking.Date.Year.ToString();
                //lbChutien.Text = "Bằng chữ: " + ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prTotalReal.Value));
            }
            catch { }
        }
        private void Detail2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt += 1;
            txtNo.Text = stt.ToString(); 
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt = 0;
        }

    }
}
