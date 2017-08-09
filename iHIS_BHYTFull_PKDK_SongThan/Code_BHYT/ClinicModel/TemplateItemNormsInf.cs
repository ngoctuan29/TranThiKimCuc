using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class TemplateItemNormsInf
    {
        public string NormsCode { get; set; }
        public DateTime IDate { get; set; }
        public DateTime UDate { get; set; }
        public string ServiceCode { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeCodeUpd { get; set; }
    }

    public class TemplateItemNormsDetailInf
    {
        public decimal RowID { get; set; }
        public string NormsCode { get; set; }
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public string Instruction { get; set; }
    }

}
