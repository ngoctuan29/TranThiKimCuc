using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptHoSoKhamBenhTongKet : DevExpress.XtraReports.UI.XtraReport
    {

        public rptHoSoKhamBenhTongKet()
        {
            InitializeComponent();
        }

        private void rptHoSoKhamBenhTongKet_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtDateprint.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }
        
        private void lbBenhChinhRaVienKT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.lbBenhChinhRaVienKT.Text.Length > 0)
            {
                string[] arrICD10KT = this.lbBenhChinhRaVienKT.Text.Split(';');
                this.lbBenhChinhRaVienKT.Text = arrICD10KT[0].ToString();
            }
            else
                this.lbBenhChinhRaVienKT.Text = string.Empty;
        }
    }
}
