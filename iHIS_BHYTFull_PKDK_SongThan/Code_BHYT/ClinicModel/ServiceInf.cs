using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServiceInf
    {
        public decimal RowID { get; set; }
        public string ServiceCategoryCode { get; set; }
        public string ServiceGroupCode { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string DepartmentCode { get; set; }
        public Int32 Hide { get; set; }
        public string EmployeeCode { get; set; }
        public string PatientType { get; set; }
        public string ServiceCategoryName { get; set; }
        public Int32 Serial { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public int SampleTransfer { get; set; }
        public string MaTuongDuong_BHYT { get; set; }
        public string MaCK_BHYT { get; set; }
        public string MaDK_BHYT { get; set; }
        public string Note { get; set; }
        public string SOQDPK { get; set; }
        public string Ma_TT37 { get; set; }
        public string Ten_TT37 { get; set; }
        public int IDGroupPrint { get; set; }
        public bool Attach_Items { get; set; }
    }
    public class ServiceFullNameInf
    {
        public string ServiceCategoryCode { get; set; }
        public string ServiceGroupCode { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceGroupName { get; set; }
    }
    public class Service_Item_AttachInf
    {
        public string ServiceCode { get; set; }
        public string ItemCode { get; set; }
        public Int32 ObjectCode { get; set; }
        public decimal Quantity { get; set; }
        public string EmployeeCode { get; set; }
        public int STT { get; set; }
        public string UsageCode { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string Note { get; set; }

    }
}
