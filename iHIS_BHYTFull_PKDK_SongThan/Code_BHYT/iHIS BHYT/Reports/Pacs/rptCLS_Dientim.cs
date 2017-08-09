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
    public partial class rptDientim : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDientim()
        {
            InitializeComponent();
        }

        private void PhieuKQCLS_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                lbNames.Text = names;
                lbAddress.Text = saddress;
                lbPhone.Text = sphone;
                lbEmail.Text = semail;
                pbImage.ImageUrl = simage;

                txtNgayKham.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
                var imageList = ServiceRadiologyBLL.ListRadiologyDetailForReceiptID(Convert.ToDecimal(RadiologyRowID.Value));
                int i = 0;
                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                {
                    PictureBox l = new PictureBox();
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(image.Image.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    if (i == 0)
                        PicImage.Image = (Bitmap)b;
                    i++;
                }
            }
            catch { }
        }

    }
}
