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
    public partial class rptNoisoi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNoisoi()
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
                pbImage.ImageUrl = simage;
                txtNgayKham.Text = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
                var imageList = ServiceRadiologyBLL.ListRadiologyDetailForReceiptID(Convert.ToDecimal(RadiologyRowID.Value));
                Int32 countImage = imageList.Count;
                Int32 height = 180;
                Int32 width = 200;
                Int32 x = 50;
                Int32 y = 10;
                Int32 top = 10;

                if (countImage >= 2)
                {
                    x = 10;
                    height = 200;
                    width = 250;
                }
                //if (countImage <= 2)
                //{
                //    x = 15;
                //    height = 230;
                //    width = 300;
                //}
                //else if (countImage == 4)
                //{
                //    x = 10;
                //    height = 200;
                //    width = 250;
                //}
                //else
                //{
                //    x = 10;
                //    height = 160;
                //    width = 160;
                //}
                Int32 countTemp = 1;
                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                {
                    XRPictureBox pictureBox = new XRPictureBox();
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(image.Image.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    pictureBox.Image = (Bitmap)b;

                    if (countTemp % 2 == 0)
                    {
                        x = width + 20;
                        y = top;
                        top += height + 10;
                    }
                    else
                    {
                        x = 10;
                    }
                    pictureBox.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
                    pictureBox.Sizing = ImageSizeMode.StretchImage;
                    pictureBox.SizeF = new System.Drawing.SizeF(width, height);
                    y = top;

                    //if (countImage >= 4)
                    //{
                    //    if (countTemp % 2 == 0)
                    //    {
                    //        x = width + 20;
                    //        y = top;
                    //        top += height + 10;
                    //    }
                    //    else
                    //    {
                    //        x = 10;
                    //    }
                    //    pictureBox.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
                    //    pictureBox.Sizing = ImageSizeMode.StretchImage;
                    //    pictureBox.SizeF = new System.Drawing.SizeF(width, height);
                    //    y = top;
                    //}
                    //else
                    //{
                    //    pictureBox.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
                    //    pictureBox.Sizing = ImageSizeMode.StretchImage;
                    //    pictureBox.SizeF = new System.Drawing.SizeF(width, height);
                    //    y += height + 10;
                    //}
                    this.pnPictureBox.Controls.Add(pictureBox);
                    countTemp++;
                }
            }
            catch { }
        }

    }
}
