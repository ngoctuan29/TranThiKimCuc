using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PatientsSendSMSInf
    {
        public string IDTarget { get; set; }
        public string PatientCode { get; set; }
        public string AppointmentDate { get; set; }
        public string Mobile { get; set; }
        public string Result { get; set; }
        public string Content { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime WorkDate { get; set; }
        public decimal PatientReceiveID { get; set; }
    }
}
