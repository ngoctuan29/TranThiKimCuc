using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PictureInf
    {
        public string id { get; set; }
        public string pathPicture { get; set; }
        public byte[] imagebyte { get; set; }
        public bool check { get; set; }
    }
}
