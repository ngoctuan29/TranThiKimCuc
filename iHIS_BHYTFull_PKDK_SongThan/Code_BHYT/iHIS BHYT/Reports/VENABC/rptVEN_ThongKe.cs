﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptThongKeVEN : DevExpress.XtraReports.UI.XtraReport
    {
        private int page = 0;
        public rptThongKeVEN()
        {
            InitializeComponent();
        }

        private void BottomMargin_AfterPrint(object sender, EventArgs e)
        {
            page += 1;
            lblpage.Text = page.ToString();
        }
    }
}
