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
    public partial class frmDiUngThuoc : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Image img;
        public string sImagePath = string.Empty;
        private string spatientCode = string.Empty;
        private decimal dPatientReceiveID = 0, dRowID = 0, dRadiologyEntryID = 0;
        public frmDiUngThuoc(Image _img, string _patientCode, decimal _PatientReceiveID, decimal _RowID, decimal _RadiologyEntryID)
        {
            InitializeComponent();
            this.img = _img;
            this.spatientCode = _patientCode;
            this.dPatientReceiveID = _PatientReceiveID;
            this.dRowID = _RowID;
            this.dRadiologyEntryID = _RadiologyEntryID;
        }

        private void frmDiUngThuoc_Load(object sender, EventArgs e)
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