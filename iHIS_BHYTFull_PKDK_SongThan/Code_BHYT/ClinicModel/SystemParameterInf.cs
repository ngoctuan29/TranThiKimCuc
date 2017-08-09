using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class SystemParameterInf
    {
        public Int32 RowID { get; set; }
        public string Module { get; set; }
        public string Name { get; set; }
        public Int32 Values { get; set; }
        public string Description { get; set; }
        public DateTime IDate { get; set; }
        public DateTime UDate { get; set; }
        public string VersionNo { get; set; }
    }
}
