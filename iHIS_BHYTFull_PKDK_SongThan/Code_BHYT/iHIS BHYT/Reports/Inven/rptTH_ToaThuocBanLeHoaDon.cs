using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rptToaThuocBanLeHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public rptToaThuocBanLeHoaDon()
        {
            InitializeComponent();
        }

        private void rptToaThuocBanLeHoaDon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                txtDay.Text = DateTime.Now.Day.ToString();
                txtMonth.Text = DateTime.Now.Month.ToString();
                txtYear.Text = DateTime.Now.Year.ToString();
                lbChutien.Text = ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(prTotalRealVAT.Value));
            }
            catch { }
        }
        
    }
}
