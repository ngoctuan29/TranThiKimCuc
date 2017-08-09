using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class view_KB_ListPatientReceiveDetailGroup : DevExpress.XtraReports.UI.XtraReport
    {
        private Int32 runNumber = 1;
        public view_KB_ListPatientReceiveDetailGroup()
        {
            InitializeComponent();
        }
        
        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbRecord.Text = this.runNumber.ToString();
            this.runNumber++;
            
        }

    }
}
