using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class SurgeriesINF
    {
        public decimal RowID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string SurgeriesCode { get; set; }
        public string DateOn { get; set; }
        public string TimeOn { get; set; }
        public string DateOut { get; set; }
        public string TimeOut { get; set; }
        public string ICD10On { get; set; }
        public string ICD10Out { get; set; }
        public Int32 IDAnesthesia { get; set; }
        public Int32 IDComplications { get; set; }
        public Int32 IDTheSituation { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 ObjectCode { get; set; }
        public string PatientCode { get; set; }
        public Int32 PatientType { get; set; }
        public string EmployeeCodeUpd { get; set; }
        public DateTime IDate { get; set; }
        public DateTime UDate { get; set; }
        public decimal IDSuggested { get; set; }
        public string DepartmentCode { get; set; }
        public Int32 Paid { get; set; }
        public string BanksAccountCode { get; set; }
        public string DiagnosisCustomOn { get; set; }
        public string DiagnosisCustomOut { get; set; }
        public string ShiftWork { get; set; }
    }

    public class SurgicalCrewINF
    {
        public decimal RowID { get; set; }
        public string SurgeriesCode { get; set; }
        public DateTime IDate { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
    }

}
