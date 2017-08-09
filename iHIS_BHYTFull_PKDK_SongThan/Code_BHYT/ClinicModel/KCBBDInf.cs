using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class KCBBDInf
    {
        public decimal RowID { get; set; }
        public string KCBBDCode { get; set; }
        public string KCBBDName { get; set; }
        public string ProvincialIDBHYT { get; set; }
        public Int32 TT { get; set; }
    }
    public class TinhKCBBDInf
    {
        public decimal RowID { get; set; }
        public string ProvincialIDBHYT { get; set; }
        public string ProvincialName { get; set; }
    }
}
