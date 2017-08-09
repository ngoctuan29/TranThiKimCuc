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
    public partial class rptCLS_SieuamA4Rotate : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCLS_SieuamA4Rotate()
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
                //lbAddress.Text = saddress;
                //lbPhone.Text = sphone;
                pbImage.ImageUrl = simage;
                this.txtNgay.Text = Convert.ToDateTime(this.prDateResult.Value).Day.ToString();
                this.txtThang.Text = Convert.ToDateTime(this.prDateResult.Value).Month.ToString();
                this.txtNam.Text = Convert.ToDateTime(this.prDateResult.Value).Year.ToString();
                var imageList = ServiceRadiologyBLL.ListRadiologyDetailForReceiptID(Convert.ToDecimal(RadiologyRowID.Value));
                Int32 countImage = imageList.Count;
                Int32 height = 180;
                Int32 width = 255;
                Int32 x = 50;
                Int32 y = 10;
                Int32 top = 10;

                if (countImage == 2)
                {
                    x = 110;
                    height = 200;
                    width = 320;
                }
                Int32 countTemp = 1;
                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                {
                    XRPictureBox pictureBox = new XRPictureBox();
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(image.Image.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    pictureBox.Image = (Bitmap)b;
                    if (countImage == 2)
                    {
                        if (countTemp == 1)
                            top = 10;
                        else
                        {
                            x = 110;
                            top += height + 10;
                            y = top;
                        }
                    }
                    else if (countImage % 3 == 0 && countTemp == 3)
                    {
                        x = 110;
                        top += height + 10;
                        y = top;
                    }
                    else if (countImage >= 4)
                    {
                        if (countTemp % 2 == 0)
                        {
                            x = width + 20;
                            y = top;
                            top += height + 10;
                        }
                        else
                            x = 10;
                    }
                    else
                    {
                        if (countTemp % 2 == 0)
                            x = width + 20;
                        else
                            x = 10;
                        if (countImage == 1)
                        {
                            x = 100;
                            height = 300;
                            width = 360;
                        }
                        y = top;
                    }
                    pictureBox.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
                    pictureBox.Sizing = ImageSizeMode.StretchImage;
                    pictureBox.Borders = BorderSide.None;
                    pictureBox.SizeF = new System.Drawing.SizeF(width, height);
                    y = top;
                    this.pnPictureBox.Controls.Add(pictureBox);
                    countTemp++;
                }
            }
            catch { }
        }

    }
}
