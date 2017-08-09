using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class RepositoryCatalog_Inf
    {
        public decimal RowID { get; set; }
        public String RepositoryCode { get; set; }
        public String RepositoryName { get; set; }
        public Int32 Hide { get; set; }
        public String EmployeeCode { get; set; }
        public decimal RepositoryGroupCode { get; set; }
        public DateTime DateReport { get; set; }
    }
}
