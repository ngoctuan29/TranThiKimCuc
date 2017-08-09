using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
using ClinicModel;
using ClinicBLL;

namespace Ps.Clinic.Reports
{
    public partial class rptToathuocBlank : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime dtimeServer = new DateTime();
        private DateTime dtimeWorking = new DateTime();
        public rptToathuocBlank(DateTime _dtimeServer, DateTime _dtimeWorking)
        {
            InitializeComponent();
            this.dtimeServer = _dtimeServer;
            this.dtimeWorking = _dtimeWorking;
        }

        private void rptToathuocBlank_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                pbImage.ImageUrl = simage;
                this.lbNames.Text = names;
                this.lbAddress.Text = saddress;
                this.lbPhone.Text = sphone;
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(8);
                if (objSys != null && objSys.Values == 1)
                    this.txtNgayKham.Text = this.dtimeServer.Date.Hour + ":" + this.dtimeServer.Date.Minute + ", ngày " + this.dtimeServer.Date.Day + " tháng " + this.dtimeServer.Date.Month + " năm " + this.dtimeServer.Date.Year;
                else
                    this.txtNgayKham.Text = " Ngày " + this.dtimeServer.Date.Day + " tháng " + this.dtimeServer.Date.Month + " năm " + this.dtimeServer.Date.Year;

            }
            catch { }
        }

    }
}
