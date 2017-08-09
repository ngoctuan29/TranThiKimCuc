using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServiceRadiologyEntryInf
    {
        public decimal RowID { get; set; }
        public string ServiceCode { get; set; }
        public string PatientCode { get; set; }
        public string ReferenceCode { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentNote { get; set; }
        public string Contents { get; set; }
        public string Conclusion { get; set; }
        public string Proposal { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal PatientReceiveID { get; set; }
        public Int32 Done { get; set; }
        public string EmployeeCode { get; set; }
        public decimal SuggestedID { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public string ShiftWork { get; set; }
        public string Note { get; set; }
    }
    public class ServiceRadiologyDetailEntryInf
    {
        public decimal RowID { get; set; }
        public decimal RadiologyRowID { get; set; }
        public byte[] Image { get; set; }
        public DateTime PostingDate { get; set; }
        public bool Checked { get; set; }
    }

    public class ViewPreviousInf
    {
        public decimal RowID { get; set; }
        public string ServiceCode { get; set; }
        public string PatientCode { get; set; }
        public DateTime PostingDate { get; set; }
        public string ServiceName { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime UDate { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public  int STT { get; set; }
        public decimal SuggestedID { get; set; }
    }

}
