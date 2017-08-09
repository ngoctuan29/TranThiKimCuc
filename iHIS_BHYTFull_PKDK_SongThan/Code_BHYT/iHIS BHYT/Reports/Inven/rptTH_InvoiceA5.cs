using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rptTH_InvoiceA5 : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rptTH_InvoiceA5()
        {
            InitializeComponent();
        }

        private void rpt_VP_Invoice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                //this.txtDay.Text = DateTime.Now.Day.ToString();
                //this.txtMonth.Text = DateTime.Now.Month.ToString();
                //this.txtYear.Text = DateTime.Now.Year.ToString();
                this.lbChutien.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prTotalReal.Value));
            }
            catch { }
        }
        

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt += 1;
            lbNo.Text = stt.ToString(); 
        }

    }
}
