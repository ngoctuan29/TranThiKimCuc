using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ImmunizationRecordInf
    {
        public string ImmunizationRecordCode { get; set; }
        public int ObjectCode { get; set; }
        public int PatientType { get; set; }
        public string ServiceCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public decimal ReceiptID { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime WorkDate { get; set; }
        public string EmployeeCode { get; set; }
        public int Status { get; set; }
        public string ShiftWork { get; set; }
    }

    public class ImmunizationRecordDetailInf
    {
        public decimal RowID { get; set; }
        public string ImmunizationRecordCode { get; set; }
        public string ImmunizationRecordDetailCode { get; set; }
        public int RowIDDoseNo { get; set; }
        public string LotNo { get; set; }
        public string Note { get; set; }
        public string Content { get; set; }
        public DateTime DateGiven { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentContent { get; set; }
        public string EmployeeCode { get; set; }
        public string DoseNoName { get; set; }
        public string MedicalRecordCode { get; set; }
        public string ShiftWork { get; set; }
        public string EmployeeCodeDoctor { get; set; }
    }

    public class ImmunizationTimesDetailInf
    {
        public Int32 TimesDetailID { get; set; }
        public string ServiceCode { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 DayTimes { get; set; }
        public Int32 DayTimesCome { get; set; }
        public Int32 DoseNoID { get; set; }
        public int TimesEntryID { get; set; }
        public bool Warning { get; set; }
        public string Note { get; set; }
    }

    public class ImmunizationTimesEntryInf
    {
        public Int32 TimesEntryID { get; set; }
        public string Title { get; set; }
        public string ServiceCode { get; set; }
        public string EmployeeCode { get; set; }
        public string Note { get; set; }
    }

}
