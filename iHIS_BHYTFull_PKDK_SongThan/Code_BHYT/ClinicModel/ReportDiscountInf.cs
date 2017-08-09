using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ReportDiscountInf
    {
        public decimal ReceiptID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string ServiceCode { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal ServicePriceOverTime { get; set; }
        public decimal DiscountAmount { get; set; }
        public int DiscountPer { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string IntroName { get; set; }
        public DateTime WorkDate { get; set; }
        public string ShiftWork { get; set; }
        public string EmployeeCode { get; set; }
    }
}
