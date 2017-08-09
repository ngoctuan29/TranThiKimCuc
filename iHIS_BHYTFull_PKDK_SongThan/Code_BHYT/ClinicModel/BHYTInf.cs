using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class BHYTInf
    {
        public decimal RowID { get; set; }
        public string Serial { get; set; }
        public string Serial01 { get; set; }
        public string Serial02 { get; set; }
        public string Serial03 { get; set; }
        public string Serial04 { get; set; }
        public string Serial05 { get; set; }
        public string Serial06 { get; set; }
        public string PatientCode { get; set; }
        public string KCBBDCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Hide { get; set; }
        public string EmployeeCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public int TraiTuyen { get; set; }
        public int Capcuu { get; set; }
        public int ReferralPaper { get; set; }
        public string ProvincialIDBHYT { get; set; }
        public string KCBBDCodeFull { get; set; }
    }
}
