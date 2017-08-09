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
    public partial class rptXN_General_A4 : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime dtWorking = new DateTime();
        public rptXN_General_A4(DateTime _dtWorking)
        {
            InitializeComponent();
            this.dtWorking = _dtWorking;
        }

        private void rptXN_General_A4_TTBVSKMTr_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            this.lbNames.Text = names;
            this.lbAddress.Text = saddress;
            this.lbPhone.Text = sphone;
            this.lbEmail.Text = semail;
            this.pbImage.ImageUrl = simage;
            //DateTime dtWorking = Utils.DateTimeServer();
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(7);
            if (objSys != null && objSys.Values == 1)
                this.txtNgayKham.Text = DateTime.Now.Date.Hour + ":" + DateTime.Now.Date.Minute + " ,ngày " + this.dtWorking.Date.Day.ToString() + " tháng " + this.dtWorking.Date.Month.ToString() + " năm " + this.dtWorking.Date.Year.ToString();
            else
                this.txtNgayKham.Text = "Ngày " + this.dtWorking.Date.Day.ToString() + " tháng " + this.dtWorking.Date.Month.ToString() + " năm " + this.dtWorking.Date.Year.ToString();
        }
        
        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string temp = this.lbNormal.Text;
            if (temp == "1")
            {
                this.cellValuesEntry.Font = new Font("Times New Roman", 13, FontStyle.Bold);
                this.cellValuesEntry.ForeColor = Color.Red;
            }
            else
            {
                this.cellValuesEntry.Font = new Font("Times New Roman", 11, FontStyle.Regular);
                this.cellValuesEntry.ForeColor = Color.Black;
            }
        }
    }
}
