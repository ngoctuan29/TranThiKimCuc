using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class BanksAccountInf
    {
        public decimal RowID { get; set; }
        public string BanksAccountCode { get; set; }
        public decimal ReferenceCode { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public decimal Exemptions { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public DateTime PostingDate { get; set; }
        public string EmployeeCode { get; set; }
        public string PatientCode { get; set; }
        public int Cancel { get; set; }
        public int PatientType { get; set; }
        public int ObjectCode { get; set; }
        public decimal TotalReal { get; set; }
        public decimal RateExemptions { get; set; }
        public decimal RateSurcharge { get; set; }
        public decimal TotalSurcharge { get; set; }
        public string IntroCode { get; set; }
        public int Serial { get; set; }
        public string CashierCode { get; set; }
        public string ShiftWork { get; set; }
        public decimal TotalBHYTPay { get; set; }
        public decimal TotalPatientPay { get; set; }
    }
    public class Model_BanksAccountFinish
    {
        public decimal ReferenceCode { get; set; }
        public string BanksAccountCode { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public decimal Exemptions { get; set; }
        public decimal TotalReal { get; set; }
        public string Description { get; set; }
        public DateTime PostingDate { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public int Cancel { get; set; }
        public int ObjectCode { get; set; }
        public string EmployeeName { get; set; }
        public string ObjectName { get; set; }
        public decimal RateExemptions { get; set; }
        public decimal RateSurcharge { get; set; }
        public decimal TotalSurcharge { get; set; }
        public string IntroCode { get; set; }
        public int Serial { get; set; }
        public decimal TotalAmount { get; set; }
        public string CashierCode { get; set; }
        public Int32 StatusReceive { get; set; }
        public Int32 Printer { get; set; }
        public string NoInvoice { get; set; }
        public string EmployeeCode { get; set; }
        public string SerialNumber { get; set; }
        public decimal TotalBHYTPay { get; set; }
        public decimal TotalPatientPay { get; set; }
    }
    public class BanksAccountInvoiceInf
    {
        public string PatientCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string Invoice_MauSo { get; set; }
        public string Invoice_KyHieu { get; set; }
        public string Invoice_HoTenKH { get; set; }
        public string Invoice_DiaChi { get; set; }
        public string Invoice_MaSoThue { get; set; }
        public string Invoice_DienThoai { get; set; }
        public string Invoice_HTThanhToan { get; set; }
        public int Invoice_VAT { get; set; }
        public string Invoice_EmployeeCode { get; set; }
        public string NoInvoice { get; set; }
        public string Invoice_DonVi { get; set; }
    }
}
