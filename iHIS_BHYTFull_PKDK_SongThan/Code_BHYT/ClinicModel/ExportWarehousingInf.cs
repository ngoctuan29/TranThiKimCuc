using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ExportWarehousingInf
    {
        public decimal RowID { get; set; }
        public string ExpWarehousingCode { get; set; }
        public DateTime ExportDate { get; set; }
        public string ExpRepositoryCode { get; set; }
        public string ImpRepositoryCode { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 Type { get; set; }
        public string EmployeeNameReceive { get; set; }
    }

    public class ExportWarehousing_View
    {
        public string ExpWarehousingCode { get; set; }
        public DateTime ExportDate { get; set; }
        public string ExpRepositoryCode { get; set; }
        public string ImpRepositoryCode { get; set; }
        public string EmployeeName { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public string ExpRepositoryName { get; set; }
        public string ImpRepositoryName { get; set; }
        public Int32 Type { get; set; }
        public string EmployeeNameReceive { get; set; }
    }
}
