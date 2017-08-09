using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PatientsRelationInf
    {
        public decimal RowID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string RelationContent { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime WorkDate { get; set; }
        public int RowIDMenu { get; set; }
        public string Age { get; set; }
        public string CareerName { get; set; }
        public string MedicalHistory { get; set; }
    }
}
