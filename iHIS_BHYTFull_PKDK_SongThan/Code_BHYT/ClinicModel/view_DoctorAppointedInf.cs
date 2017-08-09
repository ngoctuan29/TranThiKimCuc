using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class view_DoctorAppointedInf
    {
        public string PatientCode { get; set; }
        public DateTime WorkDate { get; set; }
        public string WorkTime { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceGroupName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameOrder { get; set; }
        public string ObjectName { get; set; }
        public string BanksAccountCode { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public Int32 PatientAge { get; set; }
        public Int32 PatientBirthyear { get; set; }
        public string PatientGenderName { get; set; }
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public string EmployeeNameOrder { get; set; }
        public int Quantity { get; set; }
        public decimal AmountDisparity { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountTotal { get; set; }
    }
}
