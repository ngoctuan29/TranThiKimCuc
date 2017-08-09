using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServiceSalesInf
    {
        public int RowID { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Hide { get; set; }
        public string EmployeeCode { get; set; }
    }
    public class ServiceSalesDetailInf
    {
        public int IDSales { get; set; }
        public string ServiceCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int RateSales { get; set; }
        public decimal UnitPriceSales { get; set; }
        public string EmployeeCode { get; set; }
    }
}
