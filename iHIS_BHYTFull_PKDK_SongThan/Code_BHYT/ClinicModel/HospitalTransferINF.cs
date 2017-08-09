using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class HospitalTransferINF
    {
        public decimal RowID { get; set; }
        public string HospitalTransfer { get; set; }
        public decimal PatientReceiveID { get; set; }
        public int ObjectCode { get; set; }
        public string DepartmentCode { get; set; }
        public string DateIn { get; set; }
        public string HourIn { get; set; }
        public string DateMedical { get; set; }
        public string HourMedical { get; set; }
        public string Symptoms { get; set; }
        public string LabResult { get; set; }
        public string RadResult { get; set; }
        public string DiagnosisCustom { get; set; }
        public string DrugUsed { get; set; }
        public string ReferenceCode { get; set; }
        public string Result { get; set; }
        public string Reason { get; set; }
        public string DateTransfer { get; set; }
        public string HourTransfer { get; set; }
        public string NumberSave { get; set; }
        public string NumberTransfer { get; set; }
        public string TransferExpediency { get; set; }
        public string TransferFullName { get; set; }
        public string EmployeeCode { get; set; }
        public int DirectorApproval { get; set; }
        public int PatientApproval { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public DateTime WorkDate { get; set; }
        public string PatientAddress { get; set; }
        public string Serial01 { get; set; }
        public string Serial02 { get; set; }
        public string Serial03 { get; set; }
        public string Serial04 { get; set; }
        public string Serial05 { get; set; }
        public string Serial06 { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
