using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicModel;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmCapTureSetting : DevExpress.XtraEditors.XtraForm
    {
        public frmCapTureSetting()
        {
            InitializeComponent();
        }

        private void frmCapTureSetting_Load(object sender, EventArgs e)
        {
            try
            {
                this.GetDevicesCapture();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error:  " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetDevicesCapture()
        {
            List<VideoDevicesInf> lstDevices = new List<VideoDevicesInf>();
            this.cbxDevices.DataSource = lstDevices;
            this.cbxDevices.DisplayMember = "DevicesName";
            this.cbxDevices.ValueMember = "DevicesID";
        }
        private void GetAudioDevicesCapture()
        {

        }
        private List<VideoFrameSize> GetListVideoFrameSize()
        {
            List<VideoFrameSize> lstFramesize = new List<VideoFrameSize>();
            VideoFrameSize fs = new VideoFrameSize { FramesizeID = 1, FramesizeName = "320x240" };
            lstFramesize.Add(fs);
            fs = new VideoFrameSize { FramesizeID = 2, FramesizeName = "640x480" };
            lstFramesize.Add(fs);
            fs = new VideoFrameSize { FramesizeID = 3, FramesizeName = "720x480" };
            lstFramesize.Add(fs);
            fs = new VideoFrameSize { FramesizeID = 4, FramesizeName = "720x576" };
            lstFramesize.Add(fs);
            fs = new VideoFrameSize { FramesizeID = 5, FramesizeName = "768x576" };
            lstFramesize.Add(fs);
            return lstFramesize;
        }
        private List<VideoFrameRateInf> GetListVideoFrameRate()
        {
            List<VideoFrameRateInf> lstFrame = new List<VideoFrameRateInf>();
            VideoFrameRateInf fs = new VideoFrameRateInf { FrameRateID = "15000", FrameRateName = "15 fps" };
            lstFrame.Add(fs);
            fs = new VideoFrameRateInf { FrameRateID = "24000", FrameRateName = "24 fps(Film)" };
            lstFrame.Add(fs);
            fs = new VideoFrameRateInf { FrameRateID = "25000", FrameRateName = "25 fps(PAL)" };
            lstFrame.Add(fs);
            fs = new VideoFrameRateInf { FrameRateID = "29997", FrameRateName = "29.997 fps(NTSC)" };
            lstFrame.Add(fs);
            fs = new VideoFrameRateInf { FrameRateID = "30000", FrameRateName = "30 fps(~NTSC)" };
            lstFrame.Add(fs);
            fs = new VideoFrameRateInf { FrameRateID = "59994", FrameRateName = "59.994 fps(2xNTSC)" };
            lstFrame.Add(fs);
            return lstFrame;
        }
        private List<VideoColorSpace> GetListVideoColorSpace()
        {
            List<VideoColorSpace> lst = new List<VideoColorSpace>();
            VideoColorSpace fs = new VideoColorSpace { ColorID = "RGB24", ColorName = "RGB24" };
            lst.Add(fs);
            fs = new VideoColorSpace { ColorID = "YUY2", ColorName = "YUY2" };
            lst.Add(fs);
            return lst;
        }
        private class VideoFrameSize
        {
            public int FramesizeID { get; set; }
            public string FramesizeName { get; set; }
        }
        
        private class VideoColorSpace
        {
            public string ColorID { get; set; }
            public string ColorName { get; set; }
        }
    }
    
}