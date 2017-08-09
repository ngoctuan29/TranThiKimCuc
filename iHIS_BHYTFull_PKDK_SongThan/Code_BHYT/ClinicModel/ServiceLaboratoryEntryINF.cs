using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServiceLaboratoryEntryINF
    {
        public decimal RowID { get; set; }
        public string PatientCode { get; set; }
        public string ReferenceCode { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentNote { get; set; }
        public string Conclusion { get; set; }
        public string Proposal { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string ServiceCategoryCode { get; set; }
        public string STT { get; set; }
        public Int32 Status { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 ObjectCode { get; set; }
        public string DepartmentCodeOrder { get; set; }
        public Int32 LabPathologicalID { get; set; }
        public string OrderDate { get; set; }
        public string EmployeeCodeOrder { get; set; }
        public string EmployeeDoctorCodeOrder { get; set; }
        public string ShiftWork { get; set; }
        public int IDMachine { get; set; }
        public string DepartmentCode { get; set; }
        public string EmployeeCodeDoctor { get; set; }
    }

    public class ServiceLaboratoryDetailINF
    {
        public decimal RowID { get; set; }
        public decimal RowIDLaboratoryEnTry { get; set; }
        public string ServiceCode { get; set; }
        public string UnitValues { get; set; }
        public string ValuesEntry { get; set; }
        public string ValuedFemale { get; set; }
        public string ValuedMale { get; set; }
        public decimal MinValuedFemale { get; set; }
        public decimal MaxValuedFemale { get; set; }
        public decimal MinValuedMale { get; set; }
        public decimal MaxValuedMale { get; set; }
        public decimal Normal { get; set; }
        public decimal SuggestedID { get; set; }
        public string LaboratoryName { get; set; }
        public int STT { get; set; }
        public string ParameterMachine { get; set; }
    }

    public class LabAppointmentForResultsInf
    {
        public decimal PatientReceiveID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime SampleDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentContent { get; set; }
        public string AppointmentCode { get; set; }
        public string ServiceCategoryCode { get; set; }
    }
}
