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
    public partial class rptKB_ChidinhGroup : DevExpress.XtraReports.UI.XtraReport
    {
        private int iSTT = 0;
        private DateTime dtimeWorking = new DateTime();
        public rptKB_ChidinhGroup(DateTime _dtimeWorking)
        {
            InitializeComponent();
            this.dtimeWorking = _dtimeWorking;
        }

        private void rptKB_ChidinhGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.lbNames.Text = names;
                this.lbAddress.Text = saddress;
                this.lbPhone.Text = sphone;
                this.pbImage.ImageUrl = simage;
                string dateTile = "Ngày " + this.dtimeWorking.Date.Day + " tháng " + this.dtimeWorking.Date.Month + " năm " + this.dtimeWorking.Date.Year;
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(7);
                if (objSys != null && objSys.Values == 1)
                    this.txtNgayKham.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + " , " + dateTile;
                else
                    this.txtNgayKham.Text = dateTile;
                //this.txtPrint.Text = "Bệnh Viện Điện Tử .Net - Ngày in: " + DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToShortTimeString();
            }
            catch { }
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.iSTT += 1;
            this.txtNo.Text = iSTT.ToString() + ".";
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.iSTT = 0;
        }
    }
}
