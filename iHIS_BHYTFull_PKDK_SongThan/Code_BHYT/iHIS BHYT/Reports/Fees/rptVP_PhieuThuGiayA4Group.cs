using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rptVP_PhieuThuGiayA4Group : DevExpress.XtraReports.UI.XtraReport
    {
        private int stt = 0;
        public rptVP_PhieuThuGiayA4Group()
        {
            InitializeComponent();
        }

        private void rptVP_PhieuThuGiayA4Group_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                txtDate.Text = dtWorking.Hour + ":" + dtWorking.Minute + " ,ngày " + dtWorking.Date.Day.ToString() + " tháng " + dtWorking.Date.Month.ToString() + " năm " + dtWorking.Date.Year.ToString();
                //lbChutien.Text = "Bằng chữ: " + ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prTotalReal.Value));
                if (Convert.ToDecimal(this.prTotalReal.Value) < 0)
                    this.lbHoanTra.Text = "Hoàn trả :";
                this.lbTotalReal.Text = Math.Abs(Convert.ToDecimal(this.prTotalReal.Value)).ToString("N0");
            }
            catch { }
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //stt = 0;
            this.stt += 1;
            this.txtNo.Text = this.stt.ToString();
        }

    }
}
