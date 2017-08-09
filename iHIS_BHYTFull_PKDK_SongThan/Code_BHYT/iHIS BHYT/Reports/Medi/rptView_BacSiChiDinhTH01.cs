using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class view_BacSiChiDinhTH01 : DevExpress.XtraReports.UI.XtraReport
    {
        private int orderNumber = 1;
        public view_BacSiChiDinhTH01()
        {
            InitializeComponent();
        }

        private void view_BacSiChiDinhTH01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            this.lbNames.Text = names;
            this.lbAddress.Text = saddress;
            this.lbPhone.Text = sphone;
            this.pbImage.ImageUrl = simage;
            this.lbngay.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrlbSTT.Text = this.orderNumber.ToString();
            this.orderNumber++;
        }
    }
}
