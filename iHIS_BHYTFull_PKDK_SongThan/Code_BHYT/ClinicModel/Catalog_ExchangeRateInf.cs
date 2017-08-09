using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Catalog_ExchangeRateInf
    {
        public Int32 RowID { get; set; }
        public decimal RIAL { get; set; }
        public decimal VND { get; set; }
        public decimal USD { get; set; }
        public decimal OTHER { get; set; }
        public DateTime IDATE { get; set; }
        public string EMPLOYEECODE { get; set; }
    }
}
