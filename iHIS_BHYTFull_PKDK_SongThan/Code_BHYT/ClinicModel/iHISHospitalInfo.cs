using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class iHISHospitalInfo
    {
        public String id { get; set; }

        public string code { get; set; }

        public String name { get; set; }

        public String address { get; set; }

        public IList<string> location { get; set; }

        public string phone { get; set; }

        public string email { get; set; }
        public string cityId { get; set; }

        public string districtId { get; set; }
    }
}
