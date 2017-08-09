using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PatientReceiveInf
    {
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string Reason { get; set; }
        public DateTime CreateDate { get; set; }
        public string EmployeeCode { get; set; }
        public int Status { get; set; }
        public string DepartmentCode { get; set; }
        public int ObjectCode { get; set; }
        public Int32 PatientType { get; set; }
        public string ReferenceCode { get; set; }
        public int EThnicID { get; set; }
        public string CareerCode { get; set; }
        public int NationalityID { get; set; }
        public string ProvincialCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string CompanyInfo { get; set; }
        public string Address { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergy { get; set; }
        //public string IntroCode { get; set; }
        public string IntroName { get; set; }
        public int IDTypeReceive { get; set; }
        public string PatientReceiveClinic { get; set; }
        public string ShiftWork { get; set; }
        public string BarcodeBHYT { get; set; }
        public DateTime OutDate { get; set; }
        public int TNTTID { get; set; }
        public string IDAppointment247 { get; set; }
        public int OrderNumber { get; set; }
        public int ConfirmBV01 { get; set; }
        public int DenominationID { get; set; }
        public int IDObjectExempted { get; set; }
    }

    public class PatientReceive_ViewInf
    {
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string StatusName { get; set; }
        public string Status { get; set; }
        public string Paid { get; set; }
        public Int32 ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public Int32 PatientType { get; set; }
        public string DepartmentName { get; set; }
        public string IntroName { get; set; }
        public int TNTTID { get; set; }
    }
}
