using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Reports
{
    public partial class rptPhanLoaiSST : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime from, to;

        private void rptPhanLoaiSST_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDate.Text = "Từ ngày " + this.from.ToString("dd/MM/yyyy") + " đến ngày " + this.to.ToString("dd/MM/yyyy");
        }

        public rptPhanLoaiSST(DateTime _from, DateTime _to)
        {
            this.from = _from;
            this.to = _to;
            InitializeComponent();
        }

    }
}
