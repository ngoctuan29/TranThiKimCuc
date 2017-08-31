using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class SuggestedServiceReceiptInf
    {
        public decimal ReceiptID { get; set; }
        public string DepartmentCode { get; set; }
        public string ServiceCode { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public string PatientCode { get; set; }
        public int Status { get; set; }
        public int Paid { get; set; }
        public DateTime CreateDate { get; set; }
        public string ServicePackageCode { get; set; }
        public string EmployeeCode { get; set; }
        public string Note { get; set; }
        public decimal RefID { get; set; }
        public int ObjectCode { get; set; }
        public decimal RowIDPrice { get; set; }
        public Int32 PatientType { get; set; }
        public DateTime WorkDate { get; set; }
        public string ReferenceCode { get; set; }
        public string DepartmentCodeOder { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public string ShiftWork { get; set; }
        public int Quantity { get; set; }
        public string IDAppointment247 { get; set; }
        public string IDDoctorAppointment247 { get; set; }
        public string NameDoctorAppointment247 { get; set; }
        public string Content { get; set; }
        public int Check_ { get; set; }
    }

    public class SuggestedViewInf
    {
        public string BanksAccountCode { get; set; }
        public Int32 Check { get; set; }
        public decimal RowID { get; set; }
        public decimal ReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public decimal Quantity { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public decimal PatientPay { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public int Paid { get; set; }
        public int ObjectCode { get; set; }
        public Int32 Cancel { get; set; }
        public string ServiceGroupCode { get; set; }
        public string ServiceGroupName { get; set; }
        public string ServiceModuleCode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal RowIDPrice { get; set; }
        public decimal ServicePriceSalesOff { get; set; }
        public string ServiceCode_PK { get; set; }
        public string SODKGP { get; set; }
        public decimal PatientPayReal { get; set; }
        public decimal ReceiptID_DisparityPrice { get; set; }
    }

    public class SuggestedViewMedicinesInf
    {
        public string MedicalRecordCode { get; set; }
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public decimal RateBHYT { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal PatientReceiveID { get; set; }
        public decimal RowIDPrice { get; set; }
        public int ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public decimal DisparityPrice { get; set; }
        public decimal RowID { get; set; }
        public Int32 Check { get; set; }
        public Int32 MedicinesType { get; set; } //1-Thuoc duyet kho,2-Thuoc xuat tu truc
        public decimal RowIDDetail { get; set; }
        public decimal ServicePriceSalesOff { get; set; }
        public decimal PatientPayReal { get; set; }
    }

    public class SuggestedViewMedicinesBV01Inf
    {
        public string MedicalRecordCode { get; set; }
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public decimal RateBHYT { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal PatientReceiveID { get; set; }
        public decimal RowIDPrice { get; set; }
        public int ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public decimal DisparityPrice { get; set; }
        public decimal RowID { get; set; }
        public Int32 Check { get; set; }
        public Int32 MedicinesType { get; set; } //1-Thuoc duyet kho,2-Thuoc xuat tu truc
        public decimal RowIDDetail { get; set; }
        public string DateOfIssues { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public string Instruction { get; set; }
        public string ItemCode_PK { get; set; }
        public string SODKGP { get; set; }
    }
    public class SuggestedServiceReceiptIns
    {

    }
}
