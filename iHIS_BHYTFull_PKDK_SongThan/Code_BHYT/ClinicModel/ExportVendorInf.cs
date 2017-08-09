using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ExportVendorInf
    {
        public decimal RowID { get; set; }
        public string ExportVendorCode { get; set; }
        public DateTime ExportDate { get; set; }
        public string ExpRepositoryCode { get; set; }
        public string VendorCode { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 Cancel { get; set; }
    }
    public class ExportVendor_View
    {
        public string ExportVendorCode { get; set; }
        public DateTime ExportDate { get; set; }
        public string ExpRepositoryCode { get; set; }
        public string VendorCode { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 Cancel { get; set; }
        public string ExpRepositoryName { get; set; }
        public string VendorName { get; set; }
        public string EmployeeName { get; set; }
    }
}
