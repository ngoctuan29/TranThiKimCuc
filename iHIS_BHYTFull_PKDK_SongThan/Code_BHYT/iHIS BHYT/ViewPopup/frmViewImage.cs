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
using System.Drawing.Imaging;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmViewImage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Image img;
        public string sImagePath = string.Empty;
        private string spatientCode = string.Empty;
        private decimal dPatientReceiveID = 0, dRowID = 0, dRadiologyEntryID = 0;
        public frmViewImage(Image _img, string _patientCode, decimal _PatientReceiveID, decimal _RowID, decimal _RadiologyEntryID)
        {
            InitializeComponent();
            this.img = _img;
            this.spatientCode = _patientCode;
            this.dPatientReceiveID = _PatientReceiveID;
            this.dRowID = _RowID;
            this.dRadiologyEntryID = _RadiologyEntryID;
        }
        public frmViewImage(Bitmap bmp)
        {
            InitializeComponent();
            this.img = bmp;
            this.toolbtEdit.Enabled = this.toolbtSave.Enabled = this.toolbtDelete.Enabled = false;
        }
        private void frmViewImage_Load(object sender, EventArgs e)
        {
            fLoadImage();
            if (dRowID == -1 || dRadiologyEntryID == -1)
            {
                toolbtEdit.Enabled = false;
                toolbtSave.Enabled = false;
                toolbtDelete.Enabled = false;
            }
        }
        private void fLoadImage()
        {
            try
            {
                int w_s = img.Width;
                int h_s = img.Height;
                int w = 0, h = 0;
                if (w_s <= 400 && h_s <= 400)
                {
                    w = w_s;
                    h = h_s;
                }
                else
                {
                    if (w_s >= h_s)
                    {
                        w = 400;
                        h = 400 * h_s / w_s;
                    }
                    else
                    {
                        h = 400;
                        w = w_s * 400 / h_s;
                    }
                }
                //img.Width = w;
                //img.Height = h;
                picPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                picPreview.Image = img;
                //picPreview.Image.Width = 120;
            }
            catch
            {
                return;
            }
        }

        private void toolbtEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.RestoreDirectory = true;
                opf.Multiselect = false;
                opf.Filter = "All (*.*)|*.*|*.gif|*.gif|*.jpg|*.jpg|*.bmp|*.bmp";
                opf.RestoreDirectory = true;
                MemoryStream stream = new MemoryStream();
                DialogResult dr = opf.ShowDialog();
                if (dr == DialogResult.OK && opf.FileNames.Length > 0)
                {
                    for (int i = 0; i < opf.FileNames.Length; i++)
                    {
                        Bitmap b = new Bitmap(opf.FileNames[i].ToString());
                        sImagePath = opf.FileNames[i].ToString();
                        picPreview.Image = (Bitmap)b;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(this.picPreview.Image !=null)
            {
                string fileName = "Hinh_" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString()+".jpg";
                this.ConvertImage(this.picPreview.Image, fileName);
            }
        }
        public  void ConvertImage(System.Drawing.Image pic, string filename)
        {

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "BMP|*.bmp|EMF|*.emf|EXIF|*.exif|GIF|*.gif|ICO|*.ico|JPG|*.jpg|PNG|*.png|TIFF|*.tiff|WMF|*.wmf|Base64String (*.txt)|*.txt";
            s.FileName = Path.GetFileNameWithoutExtension(filename);
            string ext = Path.GetExtension(filename).Substring(1);

            switch (ext.ToLower())
            {
                case "bmp":
                    s.FilterIndex = 1;
                    break;
                case "emf":
                    s.FilterIndex = 2;
                    break;
                case "exif":
                    s.FilterIndex = 3;
                    break;
                case "gif":
                    s.FilterIndex = 4;
                    break;
                case "ico":
                    s.FilterIndex = 5;
                    break;
                case "jpg":
                    s.FilterIndex = 6;
                    break;
                case "png":
                    s.FilterIndex = 7;
                    break;
                case "tiff":
                    s.FilterIndex = 8;
                    break;
                case "wmf":
                    s.FilterIndex = 9;
                    break;
            }


            if (s.ShowDialog() == DialogResult.OK)
            {
                // used to avoid the following consecutive exceptions:
                // System.ObjectDisposedException
                // System.Runtime.InteropServices.ExternalException
                var clonedPic = new Bitmap(pic);

                switch (s.FilterIndex)
                {
                    case 1:
                        clonedPic.Save(s.FileName, ImageFormat.Bmp);
                        break;
                    case 2:
                        clonedPic.Save(s.FileName, ImageFormat.Emf);
                        break;
                    case 3:
                        clonedPic.Save(s.FileName, ImageFormat.Exif);
                        break;
                    case 4:
                        clonedPic.Save(s.FileName, ImageFormat.Gif);
                        break;
                    case 5:
                        clonedPic.Save(s.FileName, ImageFormat.Icon);
                        break;
                    case 6:
                        clonedPic.Save(s.FileName, ImageFormat.Jpeg);
                        break;
                    case 7:
                        clonedPic.Save(s.FileName, ImageFormat.Png);
                        break;
                    case 8:
                        clonedPic.Save(s.FileName, ImageFormat.Tiff);
                        break;
                    case 9:
                        clonedPic.Save(s.FileName, ImageFormat.Wmf);
                        break;
                    case 10:
                        using (MemoryStream ms = new MemoryStream())
                        {
                            try
                            {
                                clonedPic.Save(ms, pic.RawFormat);
                                string base64string = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());

                                using (StreamWriter fs = new StreamWriter(s.FileName))
                                {
                                    fs.Write(base64string);
                                    fs.Flush();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Xin lỗi, Phần mềm không thể chuyển file Dicom thành file ảnh vì: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        break;
                }

                // free resources
                clonedPic.Dispose();
            }
        }
        private void toolbtSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fstr;
                byte[] imagedata;
                if (sImagePath != string.Empty)
                {
                    fstr = new FileStream(sImagePath, FileMode.Open, FileAccess.Read);
                    imagedata = new byte[fstr.Length];
                    fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Close();
                    var doInsertServiceDetail = new ServiceRadiologyDetailEntryInf();
                    {
                        doInsertServiceDetail.RadiologyRowID = dRadiologyEntryID;
                        doInsertServiceDetail.Image = imagedata;
                        doInsertServiceDetail.RowID = dRowID;
                    };
                    Int32 iResult = 0;
                    iResult = ServiceRadiologyBLL.UpdRadiologyDetailEntry(doInsertServiceDetail);
                    
                    if (iResult > 0)
                    {
                        XtraMessageBox.Show(" Thay đổi hình thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.img = picPreview.Image;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Thay đổi hình không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
            }
            catch { }
        }

        private void toolbtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(" Bạn thật sự muốn xóa  hình ảnh đang chọn? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    Int32 iResult = ServiceRadiologyBLL.DelRadiologyDetailEntry(dRadiologyEntryID, dRowID);
                    if (iResult == 1)
                    {
                        XtraMessageBox.Show(" Xóa hình thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        picPreview.Image = null;
                        this.img = picPreview.Image;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Xóa không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch { }
        }
        
    }
}