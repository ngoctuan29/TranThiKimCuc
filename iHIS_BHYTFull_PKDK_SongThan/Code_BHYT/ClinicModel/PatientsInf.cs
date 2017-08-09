using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PatientsInf
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
        public int EThnicID { get; set; }
        public string CareerCode { get; set; }
        public int NationalityID { get; set; }
        public string ProvincialCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string PatientAddressFull { get; set; }
        public string WardName { get; set; }
        public string DistrictName { get; set; }
        public string ProvincialName { get; set; }
        public string MedicalHistoryChildren { get; set; }
        public int IDTypeReceive { get; set; }
        public string PatientMonth { get; set; }
        public string TenCha { get; set; }
        public Int32 NSCha { get; set; }
        public string TenMe { get; set; }
        public Int32 NSMe { get; set; }
    }

    public class PatientViewInf
    {
        public string PatientCode { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public decimal RefID { get; set; }
        public DateTime CreateDate { get; set; }
        public Int32 Status { get; set; }
        public string EmployeeName { get; set; }
        public Int32 PatientType { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public string OutDate { get; set; }
    }
        
}
