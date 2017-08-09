using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class VendorInf
    {
        public decimal RowID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Salesman { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string VendorTaxNo { get; set; }
        public string VendorFax { get; set; }
        public string VendorBankName { get; set; }
    }
}
