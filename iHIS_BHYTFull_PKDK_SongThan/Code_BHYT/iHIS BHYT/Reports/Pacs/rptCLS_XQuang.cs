using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Data.Linq;
using System.IO;
using System.Windows.Forms;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.Reports
{
    public partial class rptCLS_XQuang : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime dtWorking = new DateTime();
        public rptCLS_XQuang(DateTime _dtWorking)
        {
            InitializeComponent();
            this.dtWorking = _dtWorking;
        }

        private void rptCLS_XQuang_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                lbNames.Text = names;
                lbAddress.Text = saddress;
                lbPhone.Text = sphone;
                pbImage.ImageUrl = simage;
                this.txtNgayKham.Text = "Ngày " + this.dtWorking.Date.Day.ToString() + " tháng " + this.dtWorking.Date.Month.ToString() + " năm " + this.dtWorking.Date.Year.ToString();
            }
            catch { }
            
        }

    }
}
