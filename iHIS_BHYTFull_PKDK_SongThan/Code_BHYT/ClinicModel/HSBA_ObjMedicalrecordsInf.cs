using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class HSBA_ObjMedicalrecordsInf
    {
        public hsba_PatientsInf ObjPatient { get; set; }
        public hsba_PatientReceiveInf ObjPatientReceive { get; set; }
        public IList<hsba_SuggestedServiceReceiptInf> ListSuggested { get; set; }
        public IList<hsba_ReceiveDocumentImageInf> ListReceiveDocumentImage { get; set; }
        public IList<hsba_MedicalRecordInf> ListMedicalRecord { get; set; }
        public IList<hsba_MedicalRecordDetailInf> ListMedicalRecordDetail { get; set; }
        public IList<hsba_ServiceRadiologyEntryInf> ListServiceRadiologyEntry { get; set; }
        public IList<hsba_ServiceRadiologyDetailInf> ListServiceRadiologyDetail { get; set; }
        public IList<hsba_SurgeriesInf> ListSurgeries { get; set; }
        public IList<hsba_SurgicalCrewInf> ListSurgicalCrew { get; set; }
        public IList<hsba_LaboratoryEntryInf> ListLaboratoryEntry { get; set; }
        public IList<hsba_LaboratoryDetailInf> ListLaboratoryDetail { get; set; }
    }
    public class hsba_PatientsInf
    {
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string EThnicName { get; set; }
        public string CareerName { get; set; }
        public string NationalityName { get; set; }
        public string ProvincialName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string PatientAddress { get; set; }
        public int PatientGender { get; set; }
        public DateTime PatientBirthDay { get; set; }
        public int PatientAge { get; set; }
        public string PatientMobile { get; set; }
        public string PatientEmail { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergy { get; set; }
        public byte[] PatientImage { get; set; }
        public string PatientMonth { get; set; }
    }

    public class hsba_PatientReceiveInf
    {
        public string PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string Reason { get; set; }
        public DateTime InDate { get; set; }
        public string EmployeeName { get; set; }
        public int ObjectCode { get; set; }
        public int TypeReceiveID { get; set; }
        public DateTime OutDate { get; set; }
        public string EThnicName { get; set; }
        public string CareerName { get; set; }
        public string NationalityName { get; set; }
        public string ProvincialName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string CompanyInfo { get; set; }
        public string PatientAddress { get; set; }
        public string IntroName { get; set; }
        public int OrderNumber { get; set; }
        public string DenominationName { get; set; }
        public string ObjectExemptedName { get; set; }
        public string ContentMedicalPattern { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string BloodPressure1 { get; set; }
        public string Weight_ { get; set; }
        public string Hight { get; set; }
        public string Breath { get; set; }
        public string Serial { get; set; }
        public string KCBBDCode { get; set; }
        public string KCBBDName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int TraiTuyen { get; set; }
        public string HospitalCode { get; set; }
    }

    public class hsba_SuggestedServiceReceiptInf
    {
        public decimal SuggestedReceiptID { get; set; }
        public string PatientReceiveID { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public decimal UnitPriceRoot { get; set; }
        public string PatientCode { get; set; }
        public int Status_ { get; set; }
        public int Paid { get; set; }
        public string EmployeeName { get; set; }
        public string Note { get; set; }
        public int ObjectCode { get; set; }
        public int PatientType { get; set; }
        public DateTime WorkDate { get; set; }
        public decimal OrderNumber { get; set; }
        public string DepartmentNameOrder { get; set; }
        public string DepartmentName { get; set; }
        public decimal AmountExemption { get; set; }
        public decimal Quantity { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public string Content { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceGroupName { get; set; }
        public string ServiceModuleCode { get; set; }
        public string HospitalCode { get; set; }
    }

    public class hsba_ReceiveDocumentImageInf
    {
        public string PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string Note { get; set; }
        public byte[] Image_ { get; set; }
        public int STT { get; set; }
    }

    public class hsba_SurviveSignInf
    {
        public string PatientReceiveID { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string BloodPressure1 { get; set; }
        public string Weight_ { get; set; }
        public string Hight { get; set; }
        public string Breath { get; set; }
    }

    public class hsba_MedicalRecordInf
    {
        public string PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string MedicalRecordCode { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeName { get; set; }
        public string DiagnosisName { get; set; }
        public string DescriptionNode { get; set; }
        public DateTime PostingDate { get; set; }
        public string AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public int ObjectCode { get; set; }
        public string Advices { get; set; }
        public string IDC10KT { get; set; }
        public string TackleName { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public string DiagnosisCustom { get; set; }
        public string Treatments { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string BloodPressure1 { get; set; }
        public string Weight_ { get; set; }
        public string Hight { get; set; }
        public string Breath { get; set; }
        public string AppointmentNote { get; set; }
        public string Allergy { get; set; }
        public string Reason { get; set; }
        public decimal SuggestedReceiptID { get; set; }
    }

    public class hsba_MedicalRecordDetailInf
    {
        public string MedicalRecordCode { get; set; }
        public string PatientReceiveID { get; set; }
        public string ItemName { get; set; }
        public string DateOfIssues { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public decimal Quantity { get; set; }
        public string Instruction { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int ObjectCode { get; set; }
        public int DoseOf { get; set; }
        public string DoseOfPills { get; set; }
        public string ItemCategoryName { get; set; }
        public string GroupName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string Active { get; set; }
        public string ItemContent { get; set; }
    }

    public class hsba_ServiceRadiologyEntryInf
    {
        public decimal RowID { get; set; }
        public string PatientReceiveID { get; set; }
        public string Contents { get; set; }
        public string Conclusion { get; set; }
        public string Proposal { get; set; }
        public DateTime PostingDate { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public string ServiceGroupCode { get; set; }
        public string Note { get; set; }
        public string Diagnosis { get; set; }
        public string ServiceName { get; set; }
        public decimal SuggestedReceiptID { get; set; }
    }

    public class hsba_ServiceRadiologyDetailInf
    {
        public decimal RadiologyRowID { get; set; }
        public string PatientReceiveID { get; set; }
        public byte[] Image_ { get; set; }
    }

    public class hsba_SurgeriesInf
    {
        public string PatientReceiveID { get; set; }
        public string SurgeriesCode { get; set; }
        public string DateOn { get; set; }
        public string TimeOn { get; set; }
        public string DateOut { get; set; }
        public string TimeOut { get; set; }
        public string ICD10On { get; set; }
        public string ICD10Out { get; set; }
        public string AnesthesiaName { get; set; }
        public string ComplicationsName { get; set; }
        public string SituationName { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public string EmployeeName { get; set; }
        public int ObjectCode { get; set; }
        public int PatientType { get; set; }
        public string DepartmentName { get; set; }
        public string DiagnosisCustomOn { get; set; }
        public string DiagnosisCustomOut { get; set; }
        public decimal SuggestedReceiptID { get; set; }
        public string ServiceName { get; set; }
    }

    public class hsba_SurgicalCrewInf
    {
        public string PatientReceiveID { get; set; }
        public string SurgeriesCode { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
    }

    public class hsba_LaboratoryEntryInf
    {
        public string PatientReceiveID { get; set; }
        public decimal IDLaboratoryEntry { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentNote { get; set; }
        public string Conclusion { get; set; }
        public string Proposal { get; set; }
        public DateTime PostingDate { get; set; }
        public string ServiceCategoryName { get; set; }
        public string IDTemplate { get; set; }
        public int ObjectCode { get; set; }
        public string EmployeeName { get; set; }
        public string PostingDateResult { get; set; }
        public string DepartmentNameOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public string EmployeeDoctorNameOrder { get; set; }
        public string Status_ { get; set; }
    }

    public class hsba_LaboratoryDetailInf
    {
        public string PatientReceiveID { get; set; }
        public decimal IDLaboratoryEntry { get; set; }
        public string ServiceName { get; set; }
        public string UnitValues { get; set; }
        public string ValuesEntry { get; set; }
        public string ValuedFemale { get; set; }
        public string ValuedMale { get; set; }
        public int Normal { get; set; }
        public string LaboratoryName { get; set; }
        public int Serial { get; set; }
        public decimal SuggestedReceiptID { get; set; }
    }
}
