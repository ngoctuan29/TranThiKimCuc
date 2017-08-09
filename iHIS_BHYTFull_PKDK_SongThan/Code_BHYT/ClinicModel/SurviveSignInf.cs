using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class SurviveSignInf
    {
        public decimal RowID { get; set; }
        public string PatientCode { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string BloodPressure1 { get; set; }
        public string Weight { get; set; }
        public string Hight { get; set; }
        public string Breath { get; set; }
        public DateTime CreateDate { get; set; }
        public string EmployeeCode { get; set; }
        public decimal RefID { get; set; }
        public string ReferenceCode { get; set; }
    }
}
