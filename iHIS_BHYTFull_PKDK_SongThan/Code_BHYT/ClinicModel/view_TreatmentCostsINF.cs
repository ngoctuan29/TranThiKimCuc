using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class view_TreatmentCostsINF
    {
        public string PatientCode { get; set; }
        public decimal BHYTPayTotal { get; set; }
        public decimal PatientPayTotal { get; set; }
        public decimal Exemptions { get; set; }
        public decimal TotalAmount { get; set; }
        public string ObjectName { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public decimal Quantity { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCategoryName { get; set; }
        public decimal RateBHYT { get; set; }
        public string DVT { get; set; }
        public decimal Amount { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public string GroupName { get; set; }
        public DateTime WorkDate { get; set; }
    }
}
