using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PatientAppointment_INF
    {
        public string PatientCode { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string EmloyeeCode { get; set; }
        public string AppointmentNote { get; set; }
        public Int32 STT { get; set; }
    }

    public class PatientAppointmentFullInf
    {
        public decimal RowID { get; set; }
        public string PatientCode { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string EmloyeeCode { get; set; }
        public string AppointmentNote { get; set; }
        public Int32 STT { get; set; }

        public string AppointmentHour { get; set; }
        public Int32 Done { get; set; }
        public Int32 StatusID { get; set; }
        public Int32 LableID { get; set; }
    }

    public class PatientAppointmentView
    {
        public decimal RowID { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public int PatientGender { get; set; }
        public DateTime PatientBirthday { get; set; }
        public int PatientBirthyear { get; set; }
        public int PatientAge { get; set; }
        public string PatientAddress { get; set; }
        public string PatientMobile { get; set; }
        public string PatientEmail { get; set; }
        public string CodeArise { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergy { get; set; }
        public byte[] PatientImage { get; set; }

        public DateTime ExaminationDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string EmloyeeCode { get; set; }
        public string AppointmentNote { get; set; }
        public Int32 STT { get; set; }
    }

}
