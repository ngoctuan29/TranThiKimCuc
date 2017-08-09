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
    public partial class rptThuocTuTruc : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rptThuocTuTruc()
        {
            InitializeComponent();
        }

        private void rptThuocTuTruc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            this.lbNames.Text = names;
            this.lbAddress.Text = saddress;
            this.lbPhone.Text = sphone;
            this.pbImage.ImageUrl = simage;
            if (!this.prObjectCode.Value.Equals(1))
                this.lbRate.Visible = this.lbPercent.Visible = false;
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(8);
            if (objSys != null && objSys.Values == 1)
                this.txtNgay.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ", ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            else
                this.txtNgay.Text = "Long An, Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt += 1;
            this.txtNo.Text = stt.ToString() + "."; 
        }

    }
}
