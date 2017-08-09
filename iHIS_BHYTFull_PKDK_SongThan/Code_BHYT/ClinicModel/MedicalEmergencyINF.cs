using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicalEmergencyINF
    {
        public string MedicalEmergencyCode { get; set; }
        public string PatientCode { get; set; }
        public string DepartmentCode { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateOn { get; set; }
        public string TimeOn { get; set; }
        public string ReceivePatientFrom { get; set; }
        public string DiagnosisCode { get; set; }
        public string ICD10 { get; set; }
        public string Family { get; set; }
        public string FamilyFullname { get; set; }
        public string FamilyAddress { get; set; }
        public string FamilyMobile { get; set; }
        public string PatientReceivingNursing { get; set; }
        public string IDate { get; set; }
        public decimal PatientReceiveID { get; set; }
        public Int32 PatientType { get; set; }
        public Int32 ObjectCode { get; set; }
        public string Symptoms { get; set; }
        public string Treatments { get; set; }
    }
    public class MedicalEmergencyOutINF
    {
        public string MedicalEmergencyOutCode { get; set; }
        public DateTime DateOut { get; set; }
        public string TimeOut { get; set; }
        public Int32 TreatmentTime { get; set; }
        public Int32 TreatmentResults { get; set; }
        public string ICD10Out { get; set; }
        public string MedicalEmergencyCode { get; set; }
        public Int32 Paid { get; set; }
        public string BanksAccountCode { get; set; }
        public string TreatingDoctor { get; set; }
        public string NumberStorage { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 TackleCode { get; set; }
        public string Advices { get; set; }
        public string PatientCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public Int32 Status { get; set; }
    }
}
