using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class PatientReceiveCocumentImageInf
    {
        public decimal RowID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public Int32 STT { get; set; }
        public DateTime IDtae { get; set; }
        public string Note { get; set; }
        public byte[] Image { get; set; }
    }
}
