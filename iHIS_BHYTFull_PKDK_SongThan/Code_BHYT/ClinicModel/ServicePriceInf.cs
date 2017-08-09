using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServicePriceInf
    {
        public Decimal Rowid { get; set; }
        public string ServiceCode { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 ObjectCode { get; set; }
        public DateTime DateOfApplication { get; set; }
        public Int32 Hide { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime CreateOfDate { get; set; }
        public decimal DisparityPrice { get; set; }
        public string DepartmentCode { get; set; }
        public string ServiceCategoryName { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public decimal SampleTransferPrice { get; set; }
        public DateTime DateOfApplicationEnd { get; set; }
        public decimal DiscountIntro { get; set; }
        public Int32 PerDiscountIntro { get; set; }
        public decimal DiscountDoctorDone { get; set; }
        public Int32 PerDiscountDoctorDone { get; set; }
        public decimal DiscountDoctor { get; set; }
        public Int32 PerDiscountDoctor { get; set; }
    }
    public class ServicePricePrintInf
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceGroupName { get; set; }
        public string ObjectName { get; set; }
        public Decimal UnitPrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public DateTime DateOfApplication { get; set; }
        public DateTime DateOfApplicationEnd { get; set; }
        public string UnitOfMeasureName { get; set; }
    }
}
