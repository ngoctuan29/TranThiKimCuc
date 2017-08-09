using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.IO;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmViewImage_Edit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Image img;
        public bool isSave = false;
        private Rectangle rectCropArea;
        private bool isSelected;
        public frmViewImage_Edit(Bitmap bmp)
        {
            InitializeComponent();
            this.img = bmp;
        }
        private void frmViewImage_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                this.fLoadImage();
                this.trackContrast.Value = 0;
                this.trackBrightness.Value = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void fLoadImage()
        {
            this.pictureOld.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureOld.Image = img;
            this.pictureNew.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureNew.Image = img;
        }
        public Bitmap SetBrightness(int brightness, Bitmap img)
        {
            Bitmap temp = img;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j,
                        Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            return (Bitmap)bmap.Clone();
        }
        private void spinContrast_ValueChanged(object sender, EventArgs e)
        {
            if (this.pictureOld.Image != null)
            {
                SpinEdit spin = sender as SpinEdit;
                int value = int.Parse(spin.EditValue.ToString());
                this.trackContrast.EditValue = value;

                if (value != 0)
                {
                    if (int.Parse(this.spinBrightness.EditValue.ToString()) != 0)
                    {
                        this.pictureNew.Image = this.SetContrast(value, this.SetBrightness(int.Parse(this.spinBrightness.EditValue.ToString()), (Bitmap)this.pictureOld.Image));
                    }
                    else
                    { this.pictureNew.Image = this.SetContrast(value, (Bitmap)this.pictureOld.Image); }
                }
                GC.Collect();
            }
            else
                this.spinContrast.EditValue = 0;
        }
        public Bitmap SetContrast(double contrast, Bitmap img)
        {
            Bitmap temp = img;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            return (Bitmap)bmap.Clone();
        }

        private void spinBrightness_ValueChanged(object sender, EventArgs e)
        {
            if (this.pictureOld.Image != null)
            {
                SpinEdit spin = sender as SpinEdit;
                int value = int.Parse(spin.EditValue.ToString());
                this.trackBrightness.EditValue = value;

                if (value != 0)
                {
                    if (int.Parse(this.spinContrast.EditValue.ToString()) != 0)
                    {
                        this.pictureNew.Image = this.SetBrightness(value, this.SetContrast(int.Parse(this.spinContrast.EditValue.ToString()), (Bitmap)this.pictureOld.Image));
                    }
                    else
                    { this.pictureNew.Image = this.SetBrightness(value, (Bitmap)this.pictureOld.Image); }
                }
                GC.Collect();
            }
            else this.spinBrightness.EditValue = 0;
        }

        private void trackContrast_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.pictureOld.Image != null)
            {
                TrackBarControl track = sender as TrackBarControl;
                int value = int.Parse(track.EditValue.ToString());
                this.spinContrast.EditValue = value;
            }
            else
                this.trackContrast.EditValue = 0;
        }

        private void trackBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.pictureOld.Image != null)
            {
                TrackBarControl track = sender as TrackBarControl;
                int value = int.Parse(track.EditValue.ToString());
                this.spinBrightness.EditValue = value;
            }
            else
                this.trackBrightness.EditValue = 0;
        }

        private void picMainRotate_Left_Click(object sender, EventArgs e)
        {
            this.mnuMainRotateCounterclockwise();
        }
        private void mnuMainRotateCounterclockwise()
        {
            try
            {
                if (this.pictureNew.Image == null)
                {
                    return;
                }

                Bitmap renatedBmp = new Bitmap(this.pictureNew.Image);
                renatedBmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                this.pictureNew.Image = renatedBmp;
                GC.Collect();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.ToString(), "iHIS - Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picMainRotate_Right_Click(object sender, EventArgs e)
        {
            this.mnuMainRotateClockwise();
        }
        private void mnuMainRotateClockwise()
        {
            try
            {
                if (this.pictureNew.Image == null)
                {
                    return;
                }
                Bitmap renatedBmp = new Bitmap(this.pictureNew.Image);
                renatedBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.pictureNew.Image = renatedBmp;
                GC.Collect();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.ToString(), "iHIS - Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            this.pictureNew.Image = (Bitmap)this.pictureOld.Image.Clone();
            this.spinContrast.EditValue = 0;
            this.spinBrightness.EditValue = 0;
            this.trackBrightness.EditValue = 0;
            this.trackContrast.EditValue = 0;
            GC.Collect();
        }

        private void picSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.img = pictureNew.Image;
                this.isSave = true;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void picSave_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}