using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;
namespace Ps.Clinic.Reports
{
    public partial class view_BacSiChiDinh : DevExpress.XtraReports.UI.XtraReport
    {
        public view_BacSiChiDinh()
        {
            InitializeComponent();
        }

        private void view_BacSiChiDinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            lbNames.Text = names;
            lbAddress.Text = saddress;
            lbPhone.Text = sphone;
            pbImage.ImageUrl = simage;
            lbngay.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

    }
}
