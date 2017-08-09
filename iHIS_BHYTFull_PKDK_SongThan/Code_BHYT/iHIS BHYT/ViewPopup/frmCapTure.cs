using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ps.Clinic.ViewPopup;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Diagnostics;
using DirectX.Capture;
using DShowNET;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmCapTure : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sPpatientCode = string.Empty;
        private decimal dPatientReceiveID = 0;
        private string imageCode = string.Empty;
        public string path_image_full = string.Empty;
        public string path_video_full = string.Empty;
        public string path_resize = string.Empty;
        public string fname = string.Empty;
        const int WM_GRAPHNOTIFY = 0x8000 + 1;
        private IMediaEventEx mediaEvent = null;
        private int CaptureResult;
        public Capture capture = null;
        private Filters filters = null;
        private TunerInputType tunerInputType = TunerInputType.Cable;
        private AMTunerModeType tunerModeType = AMTunerModeType.TV;

        private int DefaultChannel = 88;
        private int DefaultCountryCode = 31;
        private int DefaultTuningSpace = 0;
        //private bool noChannelChange = false;
        private string apath_thumuc = string.Empty;
        private int iCardNumber = 0;
        private string serviceGroup = string.Empty;
        private int x = 5, y = 0;
        private int imageNumber = 0;
        private DateTime dtimeServer = new DateTime();
        private DateTime dtimeBefore = new DateTime();
        private DataSet dsetImage = new DataSet();
        private int i_Hinh = 1;
        public frmCapTure(decimal refPatientReceiveId, string refPatientCode, string refGroup, DataSet _dsetImage)
        {
            InitializeComponent();
            this.dPatientReceiveID = refPatientReceiveId;
            this.sPpatientCode = refPatientCode;
            this.serviceGroup = refGroup;
            this.dsetImage = _dsetImage;
        }

        private void frmCapTure_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeServer = Utils.DateServer();
                this.dtimeBefore = this.dtimeServer.AddDays(-1);
                capture = null;
                filters = new Filters();
                initMenu();
                updateMenu();
                this.AutoChooseAudio();
                this.txtFilename.Text = ".wmv";
                this.menuAllowSampleGrabber1_Click(sender, e);
                this.mnuVideoDevices_Click(sender, e);
                this.menuSampleGrabber_Click(sender, e);
                this.mnuPreview_Click(sender, e);

                string pathName = Directory.GetCurrentDirectory();
                this.path_image_full = pathName + "\\temp\\Image";
                this.path_video_full = pathName + "\\temp\\Video";
                this.path_resize = pathName + "\\temp\\Resize";
                string yymmdd = string.Empty;
                yymmdd = this.dtimeBefore.Date.Year.ToString().Substring(2) + this.dtimeBefore.Date.Month.ToString().PadLeft(2, '0') + this.dtimeBefore.Date.Day.ToString().PadLeft(2, '0');
                this.apath_thumuc = path_image_full + "\\" + yymmdd;
                if (Directory.Exists(this.apath_thumuc))
                {
                    System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(this.apath_thumuc);
                    directory.Delete(true);
                }
                yymmdd = this.dtimeServer.Date.Year.ToString().Substring(2) + this.dtimeServer.Date.Month.ToString().PadLeft(2, '0') + this.dtimeServer.Date.Day.ToString().PadLeft(2, '0');
                this.apath_thumuc = path_image_full + "\\" + yymmdd + "\\" + this.sPpatientCode;
                if (this.dsetImage != null && this.dsetImage.Tables.Count > 0)
                {
                    if (this.dsetImage.Tables[0].Rows.Count > 0)
                    {
                        //DataTable dtAccept = this.dsetImage.Tables[0].Select("Chon=1", "Chon desc").CopyToDataTable();
                        DataTable dtAccept = this.dsetImage.Tables[0].Select().CopyToDataTable();
                        if (dtAccept != null && dtAccept.Rows.Count > 0)
                            this.i_Hinh = dtAccept.Rows.Count + 1;
                        this.f_UpdatePanelImage(dtAccept);
                    }
                }
                this.DelPathImageALL();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }
        }

        private void f_UpdatePanelImage(DataTable dtImage)
        {
            try
            {
                pnListImage.Controls.Clear();
                //this.x = 0; this.y = 5;
                int i_Hinh = 1;
                string afilename = string.Empty;
                this.pnListImage.AutoScrollPosition = new Point(5, 5);
                foreach (DataRow dr in dtImage.Rows)
                {
                    PictureBox b = new PictureBox();
                    afilename = dr["Tag"].ToString();
                    Bitmap bm = new Bitmap(afilename);
                    b.Image = (Bitmap)bm;
                    b.Width = 120;
                    b.Height = 110;
                    CheckBox chk = new CheckBox();
                    chk.ForeColor = Color.Black;
                    chk.Text = "Hình " + i_Hinh.ToString();
                    chk.AutoSize = true;
                    chk.Checked = false;
                    b.SizeMode = PictureBoxSizeMode.StretchImage;
                    b.Location = new System.Drawing.Point(x, y);
                    chk.Location = new Point(x, y + 110);
                    y += b.Height + 20;
                    b.BorderStyle = BorderStyle.Fixed3D;
                    b.Tag = afilename;
                    chk.Tag = b.Tag.ToString();
                    b.Cursor = Cursors.Hand;
                    b.Click += new System.EventHandler(this.pic1_Click);
                    chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                    pnListImage.Controls.Add(b);
                    pnListImage.Controls.Add(chk);
                    i_Hinh += 1;
                }
            }
            catch
            {
                return;
            }
        }

        #region Capture

        private AMTunerModeType TunerModeType
        {
            get { return this.tunerModeType; }
            set
            {
                this.tunerModeType = value;
                if ((this.capture != null) && (this.capture.Tuner != null))
                {
                    this.capture.Tuner.AudioMode = value;
                    this.capture.Tuner.InputType = this.tunerInputType;
                    this.capture.Tuner.TuningSpace = this.DefaultTuningSpace;
                    this.capture.Tuner.CountryCode = this.DefaultCountryCode;
                }

                if ((this.capture != null) && (this.capture.AllowSampleGrabber))
                {
                    this.menuSampleGrabber.Visible = true;
                    this.menuSampleGrabber.Enabled = true;
                }
                else
                {
                    this.menuSampleGrabber.Visible = false;
                    this.menuSampleGrabber.Enabled = false;
                }

                this.capture.Tuner.Channel = this.DefaultChannel;
            }
        }

        TunerInputType TunerInputType
        {
            get { return this.tunerInputType; }
            set
            {
                this.tunerInputType = value;
                this.capture.Tuner.InputType = value;
            }
        }

        // Option to switch between audio via pci or wired audio connection
        // Default value is false (wired audio connection).
        private bool audioViaPci = false;

        /// <summary>
        /// Audio captured via Capture card in a PCI bus
        /// </summary>
        public bool AudioViaPci
        {
            get { return audioViaPci; }
            set
            {
                audioViaPci = value;
                menuAudioViaPci1.Checked = audioViaPci;
            }
        }

        // Media events are sent to use as windows messages

        // Media events are sent to use as windows messages
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // If this is a windows media message
                case WM_GRAPHNOTIFY:

                    DsEvCode eventCode;


                    int p1, p2, hr;

                    hr = mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);

                    while (hr == 0)
                    {
                        // Handle the event.
                        switch (eventCode)
                        {
                            case DsEvCode.ErrorAbort:

                                // The capture has been aborted
                                CaptureResult = p1;

                                break;
                            case DsEvCode.FullScreenLost:
                                break;
                            default:
                                break;
                        }

#if DEBUG
                        Debug.WriteLine("Media Event " + eventCode.ToString() + " received ...");
#endif
                        // Release parms
                        mediaEvent.FreeEventParams(eventCode, p1, p2);

                        // check for additional events
                        hr = mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);
                    }
                    break;

                // All other messages
                default:
                    try
                    {
                        // unhandled window message
                        base.WndProc(ref m);
                    }
                    catch
                    {
                        Debug.WriteLine("Fatal exception catching a message with WndProc()");
                    }
                    break;
            }
        }

        private void initMenu()
        {
            if (this.capture != null)
            {
                // Show County Dependent settings to user
                //this.ShowCountryDep();

                // Set flag only if capture device is initialized
                this.capture.AllowSampleGrabber = this.menuAllowSampleGrabber1.Checked;
                this.menuSampleGrabber.Enabled = this.menuAllowSampleGrabber1.Checked;
                this.menuSampleGrabber.Visible = this.menuAllowSampleGrabber1.Checked;

                // Set flag only if capture device is initialized
                this.capture.VideoSource = this.capture.VideoSource;
                this.capture.UseVMR9 = this.menuUseVMR9.Checked;
               // this.capture.
                this.menuUseDeInterlace1.Checked = this.FindDeinterlaceFilter(this.menuUseDeInterlace1.Checked);
            }
        }

        private void updateMenu()
        {
            ToolStripMenuItem newChild;
            Source s;
            Source current;
            Filter f;
            PropertyPage p;
            Control oldPreviewWindow = null;

            // Disable preview to avoid additional flashes (optional)
            if (capture != null)
            {
                oldPreviewWindow = capture.PreviewWindow;
                capture.PreviewWindow = null;
            }

            // Load video devices
            Filter videoDevice = null;
            if (capture != null)
                videoDevice = capture.VideoDevice;
            mnuVideoDevices.DropDownItems.Clear();
            newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuVideoDevices_Click));
            newChild.Checked = (videoDevice == null);
            mnuVideoDevices.DropDownItems.Add(newChild);
            for (int c = 0; c < filters.VideoInputDevices.Count; c++)
            {
                f = filters.VideoInputDevices[c];
                newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuVideoDevices_Click));
                newChild.Checked = (videoDevice == f);
                newChild.Tag = c;
                mnuVideoDevices.DropDownItems.Add(newChild);
            }
            mnuVideoDevices.Enabled = (filters.VideoInputDevices.Count > 0);

            // Load audio devices
            try
            {
                Filter audioDevice = null;
                if (capture != null)
                    audioDevice = capture.AudioDevice;
                mnuAudioDevices.DropDownItems.Clear();
                newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuAudioDevices_Click));
                newChild.Checked = (audioDevice == null);
                mnuAudioDevices.DropDownItems.Add(newChild);
                for (int c = 0; c < filters.AudioInputDevices.Count; c++)
                {
                    f = filters.AudioInputDevices[c];
                    newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuAudioDevices_Click));
                    newChild.Checked = (audioDevice == f);
                    mnuAudioDevices.DropDownItems.Add(newChild);
                }
                mnuAudioDevices.Enabled = (filters.AudioInputDevices.Count > 0);
            }
            catch { }

            // Load video compressors
            try
            {
                mnuVideoCompressors.DropDownItems.Clear();
                newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuVideoCompressors_Click));
                newChild.Checked = (capture.VideoCompressor == null);
                mnuVideoCompressors.DropDownItems.Add(newChild);
                for (int c = 0; c < filters.VideoCompressors.Count; c++)
                {
                    f = filters.VideoCompressors[c];
                    newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuVideoCompressors_Click));
                    newChild.Checked = (capture.VideoCompressor == f);
                    mnuVideoCompressors.DropDownItems.Add(newChild);
                }
                mnuVideoCompressors.Enabled = ((capture.VideoDevice != null) && (filters.VideoCompressors.Count > 0));
            }
            catch { mnuVideoCompressors.Enabled = false; }

            // Load audio compressors
            try
            {
                mnuAudioCompressors.DropDownItems.Clear();
                newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuAudioCompressors_Click));
                newChild.Checked = (capture.AudioCompressor == null);
                mnuAudioCompressors.DropDownItems.Add(newChild);
                for (int c = 0; c < filters.AudioCompressors.Count; c++)
                {
                    f = filters.AudioCompressors[c];
                    newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuAudioCompressors_Click));
                    newChild.Checked = (capture.AudioCompressor == f);
                    mnuAudioCompressors.DropDownItems.Add(newChild);
                }
                mnuAudioCompressors.Enabled = ((this.capture.AudioAvailable) &&
                                                (this.filters.AudioCompressors.Count > 0));
            }
            catch { mnuAudioCompressors.Enabled = false; }

            // Load video sources
            try
            {
                mnuVideoSources.DropDownItems.Clear();
                capture.VideoSources = null;
                current = capture.VideoSource;
                for (int c = 0; c < capture.VideoSources.Count; c++)
                {
                    s = capture.VideoSources[c];
                    newChild = new ToolStripMenuItem(s.Name, null, new EventHandler(mnuVideoSources_Click));
                    newChild.Checked = (current == s);
                    mnuVideoSources.DropDownItems.Add(newChild);
                }
                mnuVideoSources.Enabled = (capture.VideoSources.Count > 0);
                if (current != null)
                {
                    capture.VideoSource = current;
                }
            }
            catch { mnuVideoSources.Enabled = false; }

            // Load audio sources
            try
            {
                mnuAudioSources.DropDownItems.Clear();
                this.capture.AudioSources = null;
                current = capture.AudioSource;
                for (int c = 0; c < capture.AudioSources.Count; c++)
                {
                    s = capture.AudioSources[c];
                    newChild = new ToolStripMenuItem(s.Name, null, new EventHandler(mnuAudioSources_Click));
                    newChild.Checked = (current == s);
                    mnuAudioSources.DropDownItems.Add(newChild);
                }
                mnuAudioSources.Enabled = (capture.AudioSources.Count > 0);
            }
            catch { mnuAudioSources.Enabled = false; }

            // Start of new Brian's Low code, with some modifcations to make it more usable,
            // such as listing the available video standards and color spaces only.
            // Load video standards
            menuVideoStandard1.DropDownItems.Clear();
            if ((this.capture != null) &&
                (this.capture.dxUtils != null) && (this.capture.dxUtils.VideoDecoderAvail))
            {
                try
                {
                    menuVideoStandard1.DropDownItems.Clear();
                    AnalogVideoStandard currentStandard = capture.dxUtils.VideoStandard;
                    AnalogVideoStandard availableStandards = capture.dxUtils.AvailableVideoStandards;
                    int mask = 1;
                    while (mask <= (int)AnalogVideoStandard.PAL_N_COMBO)
                    {
                        int avs = mask & (int)availableStandards;
                        if (avs != 0)
                        {
                            newChild = new ToolStripMenuItem(((AnalogVideoStandard)avs).ToString(), null, new EventHandler(menuVideoStandard1_Click));
                            newChild.Checked = (currentStandard == (AnalogVideoStandard)avs);
                            menuVideoStandard1.DropDownItems.Add(newChild);
                        }
                        mask *= 2;
                    }
                    menuVideoStandard1.Enabled = true;
                }
                catch { menuVideoStandard1.Enabled = false; }
            }
            else
            {
                menuVideoStandard1.Enabled = false;
            }

            // Load color spaces
            menuColorSpace1.DropDownItems.Clear();
            if ((this.capture != null) && (this.capture.dxUtils != null))
            {
                try
                {
                    DxUtils.ColorSpaceEnum currentColorSpace = capture.ColorSpace;
                    string[] names = this.capture.dxUtils.SubTypeList;
                    foreach (string name in names)
                    {
                        newChild = new ToolStripMenuItem(name, null, new EventHandler(menuColorSpace1_Click));
                        newChild.Checked = (currentColorSpace == (DxUtils.ColorSpaceEnum)Enum.Parse(typeof(DxUtils.ColorSpaceEnum), name));
                        menuColorSpace1.DropDownItems.Add(newChild);
                    }
                    menuColorSpace1.Enabled = true;
                }
                catch { menuColorSpace1.Enabled = false; }
            }
            else
            {
                menuColorSpace1.Enabled = false;
            }
            // End of new Brian's Low code

            // Load frame rates
            try
            {
                mnuFrameRates.DropDownItems.Clear();
                int frameRate = (int)(capture.FrameRate * 1000);
                newChild = new ToolStripMenuItem("15 fps", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 15000);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("24 fps (Film)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 24000);
                mnuFrameRates.DropDownItems.Add(newChild);

                newChild = new ToolStripMenuItem("25 fps (PAL)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 25000);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("29.997 fps (NTSC)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 29997);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("30 fps (~NTSC)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 30000);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("59.994 fps (2xNTSC)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 59994);
                mnuFrameRates.DropDownItems.Add(newChild);
                mnuFrameRates.Enabled = true;
            }
            catch { mnuFrameRates.Enabled = false; }

            // Load frame sizes
            try
            {
                mnuFrameSizes.DropDownItems.Clear();
                Size frameSize = capture.FrameSize;
                newChild = new ToolStripMenuItem("160 x 120", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(160, 120));

                mnuFrameSizes.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("320 x 240", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(320, 240));

                mnuFrameSizes.DropDownItems.Add(newChild);

                // Added a Pal format ...
                newChild = new ToolStripMenuItem("352 x 288", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(352, 288));

                mnuFrameSizes.DropDownItems.Add(newChild);

                newChild = new ToolStripMenuItem("640 x 480", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(640, 480));

                mnuFrameSizes.DropDownItems.Add(newChild);

                // Added a Ntsc format ...
                newChild = new ToolStripMenuItem("720 x 480", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(720, 480));

                mnuFrameSizes.DropDownItems.Add(newChild);
                mnuFrameSizes.Enabled = true;

                // Added some Pal formats ...
                newChild = new ToolStripMenuItem("720 x 576", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(720, 576));
                mnuFrameSizes.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("768 x 576", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(768, 576));
                mnuFrameSizes.DropDownItems.Add(newChild);
            }
            catch { mnuFrameSizes.Enabled = false; }

            // Load audio channels
            try
            {
                mnuAudioChannels.DropDownItems.Clear();
                short audioChannels = capture.AudioChannels;
                newChild = new ToolStripMenuItem("Mono", null, new EventHandler(mnuAudioChannels_Click));
                newChild.Checked = (audioChannels == 1);
                mnuAudioChannels.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("Stereo", null, new EventHandler(mnuAudioChannels_Click));
                newChild.Checked = (audioChannels == 2);
                mnuAudioChannels.DropDownItems.Add(newChild);
                mnuAudioChannels.Enabled = true;
                capture.AudioSources = null;
            }
            catch { mnuAudioChannels.Enabled = false; }

            // Load audio sampling rate
            try
            {
                mnuAudioSamplingRate.DropDownItems.Clear();
                int samplingRate = capture.AudioSamplingRate;
                newChild = new ToolStripMenuItem("8 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
                newChild.Checked = (samplingRate == 8000);
                mnuAudioSamplingRate.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("11,025 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
                newChild.Checked = (capture.AudioSamplingRate == 11025);
                mnuAudioSamplingRate.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("22,05 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
                newChild.Checked = (capture.AudioSamplingRate == 22050);
                mnuAudioSamplingRate.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("32 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
                newChild.Checked = (capture.AudioSamplingRate == 32000);
                mnuAudioSamplingRate.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("44,1 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
                newChild.Checked = (capture.AudioSamplingRate == 44100);
                mnuAudioSamplingRate.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("48 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
                newChild.Checked = (capture.AudioSamplingRate == 48000);
                mnuAudioSamplingRate.DropDownItems.Add(newChild);
                mnuAudioSamplingRate.Enabled = true;
            }
            catch { mnuAudioSamplingRate.Enabled = false; }

            // Load audio sample sizes
            try
            {
                mnuAudioSampleSizes.DropDownItems.Clear();
                short sampleSize = capture.AudioSampleSize;
                newChild = new ToolStripMenuItem("8 bit", null, new EventHandler(mnuAudioSampleSizes_Click));
                newChild.Checked = (sampleSize == 8);
                mnuAudioSampleSizes.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("16 bit", null, new EventHandler(mnuAudioSampleSizes_Click));
                newChild.Checked = (sampleSize == 16);
                mnuAudioSampleSizes.DropDownItems.Add(newChild);
                mnuAudioSampleSizes.Enabled = true;
            }
            catch { mnuAudioSampleSizes.Enabled = false; }

            // Load property pages
            try
            {
                this.mnuPropertyPages.DropDownItems.Clear();
                for (int c = 0; c < this.capture.PropertyPages.Count; c++)
                {
                    p = this.capture.PropertyPages[c];
                    newChild = new ToolStripMenuItem(p.Name + "...", null, new EventHandler(this.mnuPropertyPages_Click));
                    this.mnuPropertyPages.DropDownItems.Add(newChild);
                }
                this.mnuPropertyPages.Enabled = (this.capture.PropertyPages.Count > 0);
            }
            catch
            {
                this.mnuPropertyPages.Enabled = false;
            }

            // Load TV Tuner channels
            //try
            //{
            //    mnuChannel.DropDownItems.Clear();
            //    if (this.TunerModeType == AMTunerModeType.TV)
            //    {
            //        int current_channel = this.tvSelections.CurrentChannel;

            //        for (int c = 1; c <= this.tvSelections.NbrTunerChannels; c++)
            //        {
            //            this.tvSelections.CurrentChannel = c;
            //            newChild = new ToolStripMenuItem(this.tvSelections.GetChannelName.ToString(),null, new EventHandler(mnuChannel_Click));
            //            newChild.Checked = ((current_channel == c) && (this.capture.Tuner.Channel == this.tvSelections.GetChannelNumber));
            //            mnuChannel.DropDownItems.Add(newChild);
            //        }

            //        this.tvSelections.CurrentChannel = current_channel;
            //        //this.capture.Tuner.Channel = this.tvSelections.GetChannelNumber;

            //        mnuChannel.Enabled = true;
            //    }
            //    else
            //    {
            //        mnuChannel.Enabled = false;
            //    }
            //}
            //catch { mnuChannel.Enabled = false; }

            // Load Tuner Modes (such as TV and FM Radio
            try
            {
                this.menuTunerModes1.DropDownItems.Clear();
                if ((this.capture.Tuner.AvailableAudioModes.TV) &&
                    (this.capture.Tuner.AvailableAudioModes.FMRadio))
                {
                    newChild = new ToolStripMenuItem(AMTunerModeType.TV.ToString(), null, new EventHandler(menuTunerModes1_Click));
                    newChild.Checked = (this.TunerModeType == AMTunerModeType.TV);
                    this.menuTunerModes1.DropDownItems.Add(newChild);
                    newChild = new ToolStripMenuItem(AMTunerModeType.FMRadio.ToString(), null, new EventHandler(menuTunerModes1_Click));
                    newChild.Checked = (this.TunerModeType == AMTunerModeType.FMRadio);
                    newChild.Enabled = false;
                    this.menuTunerModes1.DropDownItems.Add(newChild);

                    this.menuTunerModes1.Enabled = true;
                    this.menuTunerModes1.Visible = true;

                }
                else
                {
                    this.menuTunerModes1.Enabled = false;
                    this.menuTunerModes1.Visible = false;
                }

            }
            catch
            {
                this.menuTunerModes1.Enabled = false;
                this.menuTunerModes1.Visible = false;
            }

            // Load TV Tuner input types
            try
            {
                mnuInputType.DropDownItems.Clear();
                newChild = new ToolStripMenuItem(TunerInputType.Cable.ToString(), null, new EventHandler(mnuInputType_Click));
                newChild.Checked = (capture.Tuner.InputType == TunerInputType.Cable);
                mnuInputType.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem(TunerInputType.Antenna.ToString(), null, new EventHandler(mnuInputType_Click));
                newChild.Checked = (capture.Tuner.InputType == TunerInputType.Antenna);
                mnuInputType.DropDownItems.Add(newChild);
                mnuInputType.Enabled = true;
            }
            catch { mnuInputType.Enabled = false; }

            // Load audio/video recording file modes
            try
            {
                menuAVRecFileModes.DropDownItems.Clear();

                // Fill in all file modes, use enumerations also as string (and file extension)
                for (int i = 0; i < 3; i++)
                {
                    newChild = new ToolStripMenuItem(((DirectX.Capture.Capture.RecFileModeType)i).ToString(), null, new EventHandler(menuAVRecFileModes_Click));
                    newChild.Checked = (i == (int)capture.RecFileMode);
                    menuAVRecFileModes.DropDownItems.Add(newChild);
                }
                menuAVRecFileModes.Enabled = true;
            }
            catch
            {
                menuAVRecFileModes.Enabled = false;
            }

            // Enable/disable caps
            mnuVideoCaps.Enabled = ((capture != null) && (capture.VideoCaps != null));
            menuPreviewCaps.Enabled = ((capture != null) && (capture.PreviewCaps != null));
            mnuAudioCaps.Enabled = ((capture != null) && (capture.AudioCaps != null));

            // Check Preview menu option
            mnuPreview.Checked = (oldPreviewWindow != null);
            mnuPreview.Enabled = (capture != null);

            // Reenable preview if it was enabled before
            if (capture != null)
                capture.PreviewWindow = oldPreviewWindow;

            // Determine if the tuner status should be shown. Status is not
            // stable upon setting the TV broadcast frequency. Therefore it
            // the tuner status is shown at the end of this function.
            //if (mnuChannel.Enabled)
            //{
            //string name = this.tvSelections.GetChannelName;
            //if ((this.capture != null) && (this.capture.Tuner != null))
            //{
            //    if (this.capture.Tuner != null)
            //    {
            //        int[] minmax = new int[2];
            //        this.noChannelChange = true;
            //        minmax = this.capture.Tuner.ChanelMinMax;
            //        this.channelUpDown1.Maximum = minmax[1];
            //        this.channelUpDown1.Minimum = minmax[0];
            //        this.channelUpDown1.Increment = 1;
            //        if (this.DefaultChannel < minmax[0])
            //        {
            //            this.DefaultChannel = minmax[0];
            //        }
            //        if (this.DefaultChannel > minmax[1])
            //        {
            //            this.DefaultChannel = minmax[1];
            //        }
            //        this.channelUpDown1.Value = this.DefaultChannel;
            //        this.noChannelChange = false;
            //    }

            //}
            //if (this.DefaultChannel != this.tvSelections.GetChannelNumber)
            //{
            //name = "Free choice";
            //}
            //this.SetTunerStatus(name);

            //}
        }

        private bool FindDeinterlaceFilter(bool addFilter)
        {
            if (addFilter)
            {
                string filterName = "Alparysoft Deinterlace Filter";

                for (int i = 0; i < this.filters.LegacyFilters.Count; i++)
                {
                    if (filters.LegacyFilters[i].Name.StartsWith(filterName))
                    {
                        this.capture.DeInterlace = filters.LegacyFilters[i];
                        return true;
                    }
                }
            }

            // Either no de-interlace filter needs to be found
            // or no de-interlace filter could be found
            this.capture.DeInterlace = null;
            return false;
        }
        #endregion Capture

        private bool sampleGrabber = false;

        private bool SampleGrabber
        {
            get { return this.sampleGrabber; }
            set
            {
                if ((this.capture != null) && (this.capture.AllowSampleGrabber))
                {
                    this.sampleGrabber = value;
                }
                else
                {
                    this.sampleGrabber = false;
                }
                this.menuSampleGrabber.Checked = this.sampleGrabber;
                if (this.sampleGrabber)
                {
                    //this.imageFileName.Visible = true;
                    //this.button1.Visible = true;
                    //this.button2.Visible = true;
                    //this.pictureBox1.Visible = true;
                    this.txtFilename.Enabled = false;
                    //this.btnCue.Visible = false;
                    if (this.capture != null)
                    {
                        this.capture.FrameEvent2 += new Capture.HeFrame(this.CaptureDone);
                    }
                }
                else
                {
                    if (this.capture != null)
                    {
                        this.capture.DisableEvent();
                        this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone);
                    }
                    //this.imageFileName.Visible = false;
                    //this.button1.Visible = false;
                    //this.button2.Visible = false;
                    //this.pictureBox1.Visible = false;
                    this.txtFilename.Enabled = true;
                    //this.btnCue.Visible = true;
                }
            }
        }

        private void f_LoadDGHinh(string path, string mabn, string file_name)
        {
            try
            {
                //this.pnListImage.Controls.Clear();
                //this.x = 0; this.y = 5;
                //string adk = string.Empty;
                string afilename = string.Empty;
                //adk = mabn + "_" + vcount_ba + "*";
                file_name = file_name.Replace(".jpg", "*");
                this.pnListImage.AutoScrollPosition = new Point(5, 5);
                string[] sf = System.IO.Directory.GetFiles(path, file_name);
                for (int i = 0; i < sf.Length; i++)
                {
                    PictureBox b = new PictureBox();
                    afilename = sf[i].ToString();
                    Bitmap bm = new Bitmap(afilename);
                    b.Image = (Bitmap)bm;
                    b.Width = 120;
                    b.Height = 110;
                    CheckBox chk = new CheckBox();
                    chk.ForeColor = Color.Black;
                    chk.Text = "Hình " + this.i_Hinh.ToString();
                    chk.AutoSize = true;
                    b.SizeMode = PictureBoxSizeMode.StretchImage;
                    b.Location = new System.Drawing.Point(x, y);
                    chk.Location = new Point(x, y + 110);
                    y += b.Height + 20;
                    i_Hinh++;
                    b.BorderStyle = BorderStyle.Fixed3D;
                    b.Tag = afilename;
                    chk.Tag = b.Tag.ToString();
                    chk.Checked = false;
                    b.Cursor = Cursors.Hand;
                    b.Click += new System.EventHandler(this.pic1_Click);
                    chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                    this.pnListImage.Controls.Add(b);
                    this.pnListImage.Controls.Add(chk);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)(sender);
            if (c.Checked) c.ForeColor = Color.Red;
            else c.ForeColor = Color.Blue;
        }

        private int f_Get_STT_Hinh(string athumuc, string amabn, string id_hinh)
        {
            int k = 0;
            string adk = "";
            adk = amabn + "_" + id_hinh;
            adk = adk + "*";
            string[] sf = System.IO.Directory.GetFiles(athumuc, adk);
            string FNAME = "";
            try
            {
                for (int i = 0; i < sf.Length; i++)
                {
                    FNAME = sf[i].Substring(sf[i].LastIndexOf("\\") + 1);
                    if (FNAME.IndexOf(".jpg") != -1 && FNAME.IndexOf(".bmp") != 1)
                    {
                        k++;
                    }
                }
            }
            catch
            {
                k = 1;
            }
            return k + 1;
        }

        private void f_LuuAnh(string vcount_ba)
        {
            try
            {
                this.capture.GrapImg();
                string file_name = string.Empty, path_file_name = string.Empty;
                if (!Directory.Exists(apath_thumuc))
                    Directory.CreateDirectory(apath_thumuc);
                if (!Directory.Exists(path_resize))
                    Directory.CreateDirectory(path_resize);
                if (!Directory.Exists(path_video_full))
                    Directory.CreateDirectory(path_video_full);
                int i_Sohinh = 1;
                i_Sohinh = f_Get_STT_Hinh(this.apath_thumuc, this.sPpatientCode, vcount_ba);
                if (i_Sohinh > 25)
                {
                    XtraMessageBox.Show(this, " Số lượng hình cho phép lưu trữ tối đa 25 hình! ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    file_name = this.sPpatientCode + "_" + vcount_ba + "_" + "Image" + i_Sohinh.ToString().PadLeft(2, '0') + ".jpg";
                    //afile_resize = path_resize + "\\" + afile_name;
                    path_file_name = apath_thumuc + "\\" + file_name;
                    if (capture != null)
                    {
                        int milliseconds = 150;
                        Thread.Sleep(milliseconds);
                        if (System.IO.Directory.Exists(apath_thumuc) && System.IO.Directory.Exists(path_resize))
                        {
                            this.ptb_Capture.Image.Save(path_file_name, ImageFormat.Jpeg);
                            this.f_LoadDGHinh(apath_thumuc, this.sPpatientCode, file_name);
                            //this.pictureBox1.Image.Save(file_name, ImageFormat.Jpeg);
                            //this.f_LoadDGHinh(path_file_name, this.sPpatientCode, vcount_ba);
                            this.ptb_Capture.Dispose();
                        }
                        else
                        {
                            XtraMessageBox.Show(this, "Không tìm thấy đường dẫn để lưu hình\n" + apath_thumuc + "\nChọn đường dẫn khác không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            capture = null;
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(this, "Chưa kết nối với thiết bị. \n\nCác bước để lưu ảnh:\n- Kết nối với thiết bị thành công.\n- Chọn \"Lưu ảnh\" để tiến hành lưu ảnh hiện tại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        capture = null;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CaptureDone(System.Drawing.Bitmap e)
        {
            this.ptb_Capture.Image = e;
            // Show only the selected frame ...
            // If you want to capture all frames, then remove the next line
            //this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone); 
        }

        private void OnCaptureComplete(object sender, EventArgs e)
        {
            // Demonstrate the Capture.CaptureComplete event.
            Debug.WriteLine("Capture complete.");
        }

        private void mnuVideoDevices_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current devices and dispose of capture object
                // because the video and audio device can only be changed
                // by creating a new Capture object.
                Filter videoDevice = null;
                Filter audioDevice = null;

                // Dispose sample grabber data
                this.SampleGrabber = false;

                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }
                //Get Index menuItem
                int index = 0;
                iCardNumber = mnuVideoDevices.DropDownItems.Count;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                    videoDevice = (index > 0 ? filters.VideoInputDevices[index - 1] : null);
                }
                else if (iCardNumber > 0)
                    videoDevice = (iCardNumber > 0 ? filters.VideoInputDevices[0] : null);
                // Create capture object
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new Capture(videoDevice, audioDevice, AudioViaPci);
                    capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    capture.Filename = this.txtFilename.Text;
                    this.initMenu();
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Video device not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }
        private void mnuAudioDevices_Click(object sender, EventArgs e)
        {
            try
            {
                Filter videoDevice = null;
                Filter audioDevice = null;

                this.SampleGrabber = false;

                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                audioDevice = (index > 0 ? filters.AudioInputDevices[index - 1] : null);
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new Capture(videoDevice, audioDevice, AudioViaPci);
                    capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    capture.Filename = this.txtFilename.Text;
                    this.initMenu();
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio device not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }
        
        private void AutoChooseAudio()
        {
            try
            {
                Filter videoDevice = null;
                Filter audioDevice = null;

                this.SampleGrabber = false;

                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }
                int index = 0;
                var item = mnuAudioDevices;
                index = item.DropDown.Items.Count-1;
                
               //if (item != null)
               // {
               //     index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
               // }
                audioDevice = (index > 0 ? filters.AudioInputDevices[index - 1] : null);
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new Capture(videoDevice, audioDevice, AudioViaPci);
                    capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    capture.Filename = this.txtFilename.Text;
                    this.initMenu();
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Audio device not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuVideoCompressors_Click(object sender, EventArgs e)
        {
            try
            {
                // Change the video compressor
                // We subtract 1 from m.Index beacuse the first item is (None)
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.VideoCompressor = (index > 0 ? filters.VideoCompressors[index - 1] : null);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Video compressor not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuAudioCompressors_Click(object sender, EventArgs e)
        {
            try
            {
                // Change the audio compressor
                // We subtract 1 from m.Index beacuse the first item is (None)
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.AudioCompressor = (index > 0 ? filters.AudioCompressors[index - 1] : null);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio compressor not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuVideoSources_Click(object sender, EventArgs e)
        {
            try
            {
                // Choose the video source
                // If the device only has one source, this menu item will be disabled
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                this.capture.VideoSources = null;
                capture.VideoSource = capture.VideoSources[index];
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set video source. Please submit bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuAudioSources_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Choose the audio source
                // If the device only has one source, this menu item will be disabled
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                this.capture.AudioSources = null;
                capture.AudioSource = capture.AudioSources[index];
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set audio source. Please submit bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void menuVideoStandard1_Click(object sender, System.EventArgs e)
        {
            if ((this.capture == null) || (this.capture.dxUtils == null))
            {
                return;
            }
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                AnalogVideoStandard a = (AnalogVideoStandard)Enum.Parse(typeof(AnalogVideoStandard), item.Text);
                capture.dxUtils.VideoStandard = a;
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set video standard.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void menuColorSpace1_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                DxUtils.ColorSpaceEnum c = (DxUtils.ColorSpaceEnum)Enum.Parse(typeof(DxUtils.ColorSpaceEnum), item.Text);
                this.capture.ColorSpace = c;
                this.updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set color space.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuFrameRates_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split(' ');
                capture.FrameRate = double.Parse(s[0]);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Frame rate not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuFrameSizes_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Disable preview to avoid additional flashes (optional)
                bool preview = (capture.PreviewWindow != null);
                capture.PreviewWindow = null;

                // Update the frame size
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split('x');
                Size size = new Size(int.Parse(s[0]), int.Parse(s[1]));
                capture.FrameSize = size;
                //pnCapture.Size = size;
                this.ptb_Capture.Size = size;
                
                //capture.PreviewWindow = (preview ? pnCapture : null);
                capture.PreviewWindow = (preview ? this.ptb_Capture : null);
                
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Frame size not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuAudioChannels_Click(object sender, System.EventArgs e)
        {
            try
            {
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.AudioChannels = (short)Math.Pow(2, index);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Number of audio channels not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuAudioSamplingRate_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split(' ');
                // Parsing is country dependent, in European countries a number
                // with a fraction are separated with a komma, in US this is a dot:
                // 44,1 kHz in Europe versus 44.1 kHz in US
                int samplingRate = (int)(double.Parse(s[0]) * 1000);
                capture.AudioSamplingRate = samplingRate;
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio sampling rate not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuAudioSampleSizes_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split(' ');
                short sampleSize = short.Parse(s[0]);
                capture.AudioSampleSize = sampleSize;
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio sample size not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuPropertyPages_Click(object sender, System.EventArgs e)
        {
            try
            {
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                this.capture.PropertyPages = null;
                capture.PropertyPages[index].Show(this);

                if (this.mnuPropertyPages.DropDownItems[index].Text == "TV Tuner...")
                {
                    this.DefaultChannel = this.capture.Tuner.Channel;
                    this.DefaultCountryCode = this.capture.Tuner.CountryCode;
                    this.DefaultTuningSpace = this.capture.Tuner.TuningSpace;
                    this.tunerInputType = this.capture.Tuner.InputType;
                }

                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display property page. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void menuTunerModes1_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Select selected Tuner Mode
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item.Text.ToString() == AMTunerModeType.TV.ToString())
                {
                    // This is TV
                    this.TunerModeType = AMTunerModeType.TV;
                }
                // Temporary fix ...
                this.updateMenu();
            }
            catch { }
        }

        private void mnuInputType_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                this.TunerInputType = (TunerInputType)(item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable change tuner input type. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void menuAVRecFileModes_Click(object sender, System.EventArgs e)
        {
            try
            {
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.RecFileMode = (DirectX.Capture.Capture.RecFileModeType)index;
                this.txtFilename.Text = this.capture.Filename;
                switch (capture.RecFileMode)
                {
                    case DirectX.Capture.Capture.RecFileModeType.Wmv:
                    case DirectX.Capture.Capture.RecFileModeType.Wma:
                        menuAsfFileFormat.Enabled = true;
                        break;
                    case DirectX.Capture.Capture.RecFileModeType.Avi:
                        menuAsfFileFormat.Enabled = false;
                        break;
                    default:
                        break;
                }
                this.updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio sample size not supported.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
            this.updateMenu();
        }

        private void menuAsfFileFormat_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    switch (capture.RecFileMode)
                    {
                        case DirectX.Capture.Capture.RecFileModeType.Wmv:
                        case DirectX.Capture.Capture.RecFileModeType.Wma:
                            AsfForm asfForm = new AsfForm(capture);
                            asfForm.ShowDialog(this);
                            updateMenu();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch { }
        }

        private void mnuPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.capture.PreviewWindow == null)
                {
                    //capture.PreviewWindow = pnCapture;
                    this.capture.PreviewWindow = this.ptb_Capture;
                    this.mnuPreview.Checked = true;
                }
                else
                {
                    this.capture.PreviewWindow = null;
                    this.mnuPreview.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to enable/disable preview. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void menuAudioViaPci1_Click(object sender, EventArgs e)
        {
            this.AudioViaPci = !this.AudioViaPci;
        }

        private void menuAllowSampleGrabber1_Click(object sender, EventArgs e)
        {
            this.menuAllowSampleGrabber1.Checked = !this.menuAllowSampleGrabber1.Checked;
        }

        private void menuUseVMR9_Click(object sender, EventArgs e)
        {
            this.menuUseVMR9.Checked = !this.menuUseVMR9.Checked;
        }

        private void menuUseDeInterlace1_Click(object sender, EventArgs e)
        {
            this.menuUseDeInterlace1.Checked = !this.menuUseDeInterlace1.Checked;
        }

        private void menuSampleGrabber_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SampleGrabber)
                {
                    this.SampleGrabber = false;
                }
                else
                {
                    this.SampleGrabber = true;
                }
            }
            catch { return; }
        }

        private void menuVidCapSettings1_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                s = String.Format(
                    "Video Device Capabilities\n" +
                    "--------------------------------\n\n" +
                    "Input Size:\t\t{0} x {1}\n" +
                    "\n" +
                    "Min Frame Size:\t\t{2} x {3}\n" +
                    "Max Frame Size:\t\t{4} x {5}\n" +
                    "Frame Size Granularity X:\t{6}\n" +
                    "Frame Size Granularity Y:\t{7}\n" +
                    "\n" +
                    "Min Frame Rate:\t\t{8:0.000} fps\n" +
                    "Max Frame Rate:\t\t{9:0.000} fps\n" +
                    "Video modes: {10}\n",
                    capture.VideoCaps.InputSize.Width, capture.VideoCaps.InputSize.Height,
                    capture.VideoCaps.MinFrameSize.Width, capture.VideoCaps.MinFrameSize.Height,
                    capture.VideoCaps.MaxFrameSize.Width, capture.VideoCaps.MaxFrameSize.Height,
                    capture.VideoCaps.FrameSizeGranularityX,
                    capture.VideoCaps.FrameSizeGranularityY,
                    capture.VideoCaps.MinFrameRate,
                    capture.VideoCaps.MaxFrameRate,
                    capture.VideoCaps.AnalogVideoStandard.ToString());
                MessageBox.Show(s);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display video capabilities. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuVideoCaps_Click(object sender, System.EventArgs e)
        {
            try
            {
                string s;
                s = String.Format(
                    "Video Device Capabilities\n" +
                    "--------------------------------\n\n" +
                    "Input Size:\t\t{0} x {1}\n" +
                    "\n" +
                    "Min Frame Size:\t\t{2} x {3}\n" +
                    "Max Frame Size:\t\t{4} x {5}\n" +
                    "Frame Size Granularity X:\t{6}\n" +
                    "Frame Size Granularity Y:\t{7}\n" +
                    "\n" +
                    "Min Frame Rate:\t\t{8:0.000} fps\n" +
                    "Max Frame Rate:\t\t{9:0.000} fps\n" +
                    "Video modes: {10}\n",
                    capture.VideoCaps.InputSize.Width, capture.VideoCaps.InputSize.Height,
                    capture.VideoCaps.MinFrameSize.Width, capture.VideoCaps.MinFrameSize.Height,
                    capture.VideoCaps.MaxFrameSize.Width, capture.VideoCaps.MaxFrameSize.Height,
                    capture.VideoCaps.FrameSizeGranularityX,
                    capture.VideoCaps.FrameSizeGranularityY,
                    capture.VideoCaps.MinFrameRate,
                    capture.VideoCaps.MaxFrameRate,
                    capture.VideoCaps.AnalogVideoStandard.ToString());
                MessageBox.Show(s);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display video capabilities. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void mnuAudioCaps_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                s = String.Format(
                    "Audio Device Capabilities\n" +
                    "--------------------------------\n\n" +
                    "Min Channels:\t\t{0}\n" +
                    "Max Channels:\t\t{1}\n" +
                    "Channels Granularity:\t{2}\n" +
                    "\n" +
                    "Min Sample Size:\t\t{3}\n" +
                    "Max Sample Size:\t\t{4}\n" +
                    "Sample Size Granularity:\t{5}\n" +
                    "\n" +
                    "Min Sampling Rate:\t\t{6}\n" +
                    "Max Sampling Rate:\t\t{7}\n" +
                    "Sampling Rate Granularity:\t{8}\n",
                    capture.AudioCaps.MinimumChannels,
                    capture.AudioCaps.MaximumChannels,
                    capture.AudioCaps.ChannelsGranularity,
                    capture.AudioCaps.MinimumSampleSize,
                    capture.AudioCaps.MaximumSampleSize,
                    capture.AudioCaps.SampleSizeGranularity,
                    capture.AudioCaps.MinimumSamplingRate,
                    capture.AudioCaps.MaximumSamplingRate,
                    capture.AudioCaps.SamplingRateGranularity);
                MessageBox.Show(s);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display audio capabilities. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.Message);
            }
        }

        private void menuVideoRenderer1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.capture != null)
                {
                    this.capture.ShowPropertyPage(1, this);
                }
            }
            catch { return; }
        }

        private void menuDeInterlaceFilter1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.capture != null)
                {
                    this.capture.ShowPropertyPage(2, this);
                }
            }
            catch { return; }
        }

        private void tool_Photo_Click(object sender, EventArgs e)
        {
            try
            {
                this.f_LuuAnh(imageCode);
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chụp hình !\t\nHãy thử lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void tool_SelectImages_Click(object sender, EventArgs e)
        {
            try
            {
                //picCapturePro.Refresh();
                OpenFileDialog opf = new OpenFileDialog();
                opf.RestoreDirectory = true;
                opf.Multiselect = true;
                opf.Filter = "All (*.*)|*.*|*.gif|*.gif|*.jpg|*.jpg|*.bmp|*.bmp";
                opf.RestoreDirectory = true;
                DialogResult dr = opf.ShowDialog();
                //int i_Hinh = 1;
                this.pnListImage.AutoScrollPosition = new Point(5, 5);
                int countTemp = this.pnListImage.Controls.Count + 1;
                if (countTemp > 0)
                    this.imageNumber = countTemp / 2;
                if (dr == DialogResult.OK && opf.FileNames.Length > 0)
                {
                    //pnListImage.Controls.Clear();
                    //int x = 0, y = 0; // theo chieu ngang
                    //int x = 5, y = 0; // theo chieu doc
                    for (int i = 0; i < opf.FileNames.Length; i++)
                    {
                        this.imageNumber += 1;
                        PictureBox pic = new PictureBox();
                        Bitmap b = new Bitmap(opf.FileNames[i].ToString());
                        CheckBox chk = new CheckBox();
                        chk.ForeColor = Color.Red;
                        //chk.Text = "Hình " + i_Hinh.ToString();
                        chk.Text = "Hình " + this.imageNumber.ToString();
                        pic.Image = (Bitmap)b;
                        pic.Width = 120;
                        pic.Height = 110;
                        pic.Location = new System.Drawing.Point(x, y);
                        pic.BorderStyle = BorderStyle.Fixed3D;
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Cursor = Cursors.Hand;
                        pic.Tag = opf.FileNames[i].ToString();
                        //Hien thi hinh theo chieu ngang
                        //chk.Location = new Point(x, y + 70);
                        //x += pic.Width;
                        //Hien thi hinh theo chieu doc
                        chk.Location = new Point(x, y + 110);
                        y += pic.Height + 20;
                        //i_Hinh += 1;
                        chk.AutoSize = true;
                        chk.Checked = true;
                        chk.Tag = opf.FileNames[i].ToString();
                        pic.Click += new System.EventHandler(this.pic1_Click);
                        chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                        this.pnListImage.Controls.Add(pic);
                        this.pnListImage.Controls.Add(chk);
                    }
                }
            }
            catch
            {
                return;
            }
        }
        
        private void butStartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                if (sPpatientCode != string.Empty)
                {
                    if (!Directory.Exists(path_video_full)) Directory.CreateDirectory(path_video_full);
                    string ddmmyyyy = Convert.ToString(DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString());
                    string filename = path_video_full + "\\" + ddmmyyyy + "_" + sPpatientCode;
                    //fname = filename + ".avi";
                    fname = filename + txtFilename.Text.Trim();
                    if (File.Exists(fname)) fname = filename + "_" + System.DateTime.Now.Millisecond.ToString() + ".wmv";
                    this.Cursor = Cursors.Default;
                }
                if (!capture.Cued)
                    capture.Filename = fname;
                capture.Start();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Audio device not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butStopRecording_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                capture.Stop();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Please select a video and / or audio device. \n\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pic1_Click(object sender, System.EventArgs e)
        {
            try
            {
                PictureBox l = (PictureBox)(sender);
                ViewPopup.frmViewImage frm = new frmViewImage(l.Image, sPpatientCode, dPatientReceiveID, -1, -1);
                frm.ShowDialog();
            }
            catch
            {
                return;
            }
        }

        private void frmCapTure_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (capture != null)
                    capture.Dispose();
                GC.Collect();
                this.Close();
            }
            catch { }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (capture != null)
                capture.Dispose();
            GC.Collect();
            //this.Dispose();
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                    capture.Dispose();
                this.pnListImage.Controls.Clear();
                GC.Collect();
                this.Dispose();
                this.Close();
            }
            catch { }
        }

        private void DelPathImageALL()
        {
            try
            {
                DirectoryInfo dr = new DirectoryInfo(path_image_full);
                string sfolder = Convert.ToString(dr);
                //string[] allFileNames = System.IO.Directory.GetFiles(sfolder, "*.*", System.IO.SearchOption.AllDirectories);
                string[] alldirNames = System.IO.Directory.GetDirectories(sfolder, "*", System.IO.SearchOption.TopDirectoryOnly);
                string apath_thumuc = "", yymmdd = "", subpath_thumuc = string.Empty;
                yymmdd = this.dtimeServer.Date.Year.ToString().Substring(2) + this.dtimeServer.Date.Month.ToString().PadLeft(2, '0') + this.dtimeServer.Date.Day.ToString().PadLeft(2, '0');
                apath_thumuc = path_image_full + "\\" + yymmdd;
                subpath_thumuc = path_image_full + "\\" + yymmdd + "\\" + sPpatientCode;
                foreach (string dirname in alldirNames)
                {
                    FileAttributes attr = File.GetAttributes(dirname);
                    File.SetAttributes(dirname, attr & ~FileAttributes.ReadOnly);
                    if (dirname != apath_thumuc)
                        Directory.Delete(dirname, true);
                }
                //string[] filePaths = Directory.GetFiles(subpath_thumuc);
                //foreach (string file in filePaths)
                //{
                //    try
                //    {
                //        File.Delete(file);
                //    }
                //    catch { }
                //}
            }
            catch { }
        }
        
        private void frmCapTure_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F10: tool_Photo_Click(sender, e); break;
                }
            }
            catch { return; }
        }

    }
}