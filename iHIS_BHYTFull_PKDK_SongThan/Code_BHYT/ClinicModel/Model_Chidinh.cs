using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Model_Chidinh
    {
        public Decimal ReceiptID { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public int ObjectCode { get; set; }
        public Decimal Price { get; set; }
        public Decimal DisparityPrice { get; set; }
        public string DepartmentCode { get; set; }
        public int Status { get; set; }
        public int Paid { get; set; }
        public int Del { get; set; }
        public Decimal RowIDPrice { get; set; }
        public string ServicePackageCode { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
