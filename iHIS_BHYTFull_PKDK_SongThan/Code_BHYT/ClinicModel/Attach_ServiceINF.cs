using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Attach_ServiceINF
    {
        public int RowID { get; set; }
        public string AttachServiceCode { get; set; }
        public string ItemCode { get; set; }
        public int ObjectCode { get; set; }
        public DateTime IDate { get; set; }
        public int Quantity { get; set; }
        public string EmployeeCode { get; set; }
        public int STT { get; set; }
        public string Note { get; set; }
        public string AttachServiceCodeOld { get; set; }
        public int Is_Service_Auto { get; set; }

    }
}
