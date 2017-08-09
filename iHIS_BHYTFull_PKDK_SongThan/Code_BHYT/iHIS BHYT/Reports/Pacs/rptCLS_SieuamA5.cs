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
using DevExpress.XtraPrinting;

namespace Ps.Clinic.Reports
{
    public partial class rptCLS_SieuamA5 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCLS_SieuamA5()
        {
            InitializeComponent();
        }

        private void PhieuKQCLS_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                this.lbNames.Text = names;
                this.lbAddress.Text = saddress;
                this.lbPhone.Text = sphone;
                this.pbImage.ImageUrl = simage;
                this.txtNgay.Text = Convert.ToDateTime(this.prDateResult.Value).Day.ToString();
                this.txtThang.Text = Convert.ToDateTime(this.prDateResult.Value).Month.ToString();
                this.txtNam.Text = Convert.ToDateTime(this.prDateResult.Value).Year.ToString();
                var imageList = ServiceRadiologyBLL.ListRadiologyDetailForReceiptID(Convert.ToDecimal(RadiologyRowID.Value));
                Int32 countImage = imageList.Count;
                #region
                Int32 height = 180;
                Int32 width = 280;
                Int32 x = 50;
                Int32 y = 10;
                if (countImage <= 2)
                {
                    x = 5;
                    height = 220;
                    width = 300;
                }
                //if (countImage > 2)
                //    this.pnPictureBox.HeightF += height;
                int groupImage = 1;
                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                {
                    XRPictureBox pictureBox = new XRPictureBox();
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(image.Image.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    pictureBox.Image = (Bitmap)b;
                    pictureBox.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
                    pictureBox.Sizing = ImageSizeMode.StretchImage;
                    pictureBox.SizeF = new System.Drawing.SizeF(width, height);
                    this.pnPictureBox.Controls.Add(pictureBox);
                    //y += height + 10; //Tang chieu cao control panel Image
                    x += width + 30;
                    if (groupImage % 2 == 0)
                    {
                        y = height + 20;
                        x = 50;
                    }
                    groupImage++;
                }
                #endregion
            }
            catch (Exception) { }
        }
        
    }
}
