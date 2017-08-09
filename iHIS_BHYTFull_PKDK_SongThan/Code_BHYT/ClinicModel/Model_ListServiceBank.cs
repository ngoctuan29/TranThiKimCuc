using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Model_ListServiceBank
    {
        public decimal ReceiptID { get; set; }
        public string PatientCode { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string DepartmentCode { get; set; }
        public int Quantity { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public Int32 ObjectCode { get; set; }
        public decimal Amount { get; set; }
        public decimal RowIDPrice { get; set; }
        public decimal RefID { get; set; }
        public Int32 Check { get; set; }
        public Decimal PatientPay { get; set; }
    }
}
