﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class rpt_BM79a : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime dtimeServer = new DateTime();

        public rpt_BM79a(DateTime _dtimeServer)
        {
            InitializeComponent();
        }

        private void rpt_Test_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtpri.Text = "Ngày " + this.dtimeServer.Date.Day + " tháng " + this.dtimeServer.Date.Month + " năm " + this.dtimeServer.Date.Year;
         //lbThanhtien.Text = "Số tiền đề nghị thanh toán (viết bằng chữ): " + ChangeCurrency.ReadNumberToLetters(Convert.ToDouble(lbtong.Text));
        }
    }
}