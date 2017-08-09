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
    public partial class rptToaThuocMuaNgoai_A4 : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = 0;
        public rptToaThuocMuaNgoai_A4()
        {
            InitializeComponent();
        }

        private void rptToaThuocMuaNgoai_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                lbNames.Text = names;
                lbAddress.Text = saddress;
                lbPhone.Text = sphone;
                pbImage.ImageUrl = simage;
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(8);
                if (objSys != null && objSys.Values == 1)
                    this.txtNgayKham.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ", ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
                else
                    this.txtNgayKham.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            }
            catch { }
            
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt += 1;
            txtNo.Text = stt.ToString() + "."; 
        }

        private void txtNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
