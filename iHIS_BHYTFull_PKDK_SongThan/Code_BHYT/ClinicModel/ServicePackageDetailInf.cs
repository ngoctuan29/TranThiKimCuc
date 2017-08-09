using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServicePackageDetailInf
    {
        public decimal RowID { get; set; }
        public string ServicePackageCode { get; set; }
        public string ServiceCode { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 Serial { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
