using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ReportBHYTInf
    {
        public string ReportID { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public decimal Exemptions { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PostingDate { get; set; }
        public string EmployeeCode { get; set; }
        public string PatientCode { get; set; }
        public int Cancel { get; set; }
        public decimal TotalReal { get; set; }
        public decimal RateExemptions { get; set; }
        public decimal RateSurcharge { get; set; }
        public decimal TotalSurcharge { get; set; }
        public string ShiftWork { get; set; }
        public DateTime DateInto { get; set; }
        public DateTime DateOut { get; set; }
        public string DepartmentCode { get; set; }
        public string Symptoms { get; set; }
        public string Advices { get; set; }
        public string Treatments { get; set; }
        public int TackleCode { get; set; }
        public string ICD10 { get; set; }
        public string ICD10More { get; set; }
        public string DiagnosisCustom { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentContent { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string BloodPressure1 { get; set; }
        public string Weight { get; set; }
        public string Hight { get; set; }
        public string Breath { get; set; }
        public string Serial { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string KCBBDCode { get; set; }
        public Int32 TraiTuyen { get; set; }
        public string Serial01 { get; set; }
        public string Serial02 { get; set; }
        public string Serial03 { get; set; }
        public string Serial04 { get; set; }
        public string Serial05 { get; set; }
        public string Serial06 { get; set; }
        public Int32 ReferralPaper { get; set; }
        public Int32 RateBHYT { get; set; }
        public Int32 ObjectCode { get; set; }
        public Int32 MATNTT { get; set; }
        public Int32 MATTRV { get; set; }
        public Int32 IDTreatmentResults { get; set; }
        public Int32 Capcuu { get; set; }
        public decimal AmountBHYT { get; set; }
        public decimal AmountBNTraBHYT { get; set; }
        public string ICD10_Custom { get; set; }
        public string ICD10Name_Custom { get; set; }
    }

    public class ReportBHYTDetailInf
    {
        public string ReportID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string ServiceCode { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public int ObjectCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public int Ordinal { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public int RateBHYT { get; set; }
        public string DateOfIssues { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public string Instruction { get; set; }
        public string DoseOf { get; set; }
        public string DoseOfPills { get; set; }
        public decimal RowIDPrice { get; set; }
        public string ServiceCode_PK { get; set; }
        public string SODKGP { get; set; }
    }

}
