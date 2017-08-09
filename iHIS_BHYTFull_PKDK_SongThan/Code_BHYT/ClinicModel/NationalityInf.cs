using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class NationalityInf
    {
        public Int32 NationalityID { get; set; }
        public Int32 STT { get; set; }
        public String NationalityName { get; set; }
        public String EmployeeCode { get; set; }
        public DateTime IDate { get; set; }
        public Int32 ContinentsID { get; set; }
    }
}
