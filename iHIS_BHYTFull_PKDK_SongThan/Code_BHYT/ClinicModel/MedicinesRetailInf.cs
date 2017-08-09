using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicinesRetailInf
    {
        public string RetailCode { get; set; }
        public string FullName { get; set; }
        public string Birthyear { get; set; }
        public string Address { get; set; }
        public string Diagnosis { get; set; }
        public string NumberOfDrugCoal { get; set; }
        public string SerialNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime ExportDate { get; set; }
        public Int32 Paid { get; set; }
        public Int32 STT { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountReal { get; set; }
        public decimal RateOther { get; set; }
        public decimal RateUSD { get; set; }
        public decimal RateSurcharge { get; set; }
        public decimal TotalSurcharge { get; set; }
        public string IntroCode { get; set; }
        public decimal Cash { get; set; }
        public decimal ExcessCash { get; set; }
        public string VoucherCard { get; set; }
        public string OtherCard { get; set; }
        public decimal ExcessCashOther { get; set; }
        public string MedicalRecordCode { get; set; }
        public string PatientCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string ShiftWork { get; set; }
        public DateTime PatientBirthday { get; set; }
        public Int32 PatientGender { get; set; }
        public Int32 PatientAge { get; set; }
        public string PatientMonth { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public int VAT { get; set; }
    }

    public class MedicinesRetailDetailInf
    {
        public decimal RowID { get; set; }
        public string RetailCode { get; set; }
        public string ItemCode { get; set; }
        public Int32 DateOfIssues { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal SalesPrice { get; set; }
        public Decimal BHYTPrice { get; set; }
        public Decimal Amount { get; set; }
        public DateTime IDate { get; set; }
        public Decimal RowIDInventoryGumshoe { get; set; }
        public Decimal RateBHYT { get; set; }
        public string RepositoryCode { get; set; }
        public string Instruction { get; set; }
        public decimal QuantityExport { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
    }

}
