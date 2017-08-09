using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptMauBV01 : DevExpress.XtraReports.UI.XtraReport
    {
        private int s_stt = 0;
        private string sLaMA = string.Empty;
        public rptMauBV01()
        {
            InitializeComponent();
        }

        private void rptMauBV01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtDateEnd.Text = DateTime.Now.ToString();
            this.txtDateprint.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            this.lbNames.Text = names;
            //this.lbAddress.Text = saddress;
            //lbPhone.Text = sphone;
            //pbImage.ImageUrl = simage;
            ///this.lbPatientPayTotal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(this.prPatientPayTotal.Value));
            //this.lbBHYTPayTotal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(this.prBHYTPayTotal.Value));
            //this.lbPatientPayReal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(this.prPatientReal.Value));
            //this.lbOtherPayTotal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(this.prDisparityPrice.Value));
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            s_stt += 1;
            //sLaMA = IntToLaMa(s_stt);
            //lbGroupSTT.Text = s_stt.ToString();
        }
                
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbGroupTotalSTT.Text = "Cộng " + s_stt.ToString() + " :";
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

        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string objectName = this.lbObjectName.Text;
                string amountTotal = this.cellAmountTotal.Summary.GetResult().ToString();
                string amountBHYT = this.cellAmountBHYT.Summary.GetResult().ToString();
                string amountPatient = this.cellAmountPatient.Summary.GetResult().ToString();
                this.lbPatientPayTotal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(amountTotal));
                if (objectName.Equals("BHYT"))
                    this.lbBHYTPayTotal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(this.prBHYTPayTotal.Value));
                else
                    this.lbBHYTPayTotal.Text = "Không đồng.";
                this.lbPatientPayReal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(amountPatient));
                this.lbOtherPayTotal.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(this.prDisparityPrice.Value));
            }
            catch { }
        }
    }
}
