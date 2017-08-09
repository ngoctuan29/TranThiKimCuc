using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptToaThuocBanLeA5 : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rptToaThuocBanLeA5()
        {
            InitializeComponent();
        }

        private void rptToaThuocBanLeA5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.pbImage.ImageUrl = simage;
                this.lbNames.Text = names;
                this.lbAddress.Text = saddress;
                this.lbPhone.Text = sphone;
                this.txtPrintDate.Text = "(Hóa đơn: Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString() + ")";
                this.lbChutien.Text = "Bằng chữ: " + ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prTotalReal.Value));
            }
            catch { }
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt += 1;
            txtNo.Text = stt.ToString();
            //lbCountItem.Text = stt.ToString() + " Khoản";
        }

    }
}
