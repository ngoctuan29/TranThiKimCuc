using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rpt_VP_Invoice : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rpt_VP_Invoice()
        {
            InitializeComponent();
        }

        private void rpt_VP_Invoice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                //txtDay.Text = DateTime.Now.Day.ToString();
                //txtMonth.Text = DateTime.Now.Month.ToString();
                //txtYear.Text = DateTime.Now.Year.ToString();

                this.lbChutien.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prTotalReal.Value));
            }
            catch { }
        }
        
        private void Detail2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.stt += 1;
            this.lbNo.Text = stt.ToString(); 
        }

    }
}
