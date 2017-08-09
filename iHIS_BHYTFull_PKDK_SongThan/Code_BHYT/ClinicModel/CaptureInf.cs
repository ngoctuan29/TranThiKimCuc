using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class AudioVideoDevicesInf
    {
        public string AudioDevicesID { get; set; }
        public string AudioDevicesName { get; set; }
    }

    public class VideoDevicesInf
    {
        public string DevicesID { get; set; }
        public string DevicesName { get; set; }
    }
    public class VideoCompressorsInf
    {
        public string CompressoID { get; set; }
        public string CompressoName { get; set; }
    }
    public class VideoFrameRateInf
    {
        public string FrameRateID { get; set; }
        public string FrameRateName { get; set; }
    }

}
