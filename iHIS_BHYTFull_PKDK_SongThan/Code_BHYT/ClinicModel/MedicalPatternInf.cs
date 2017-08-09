using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicalPatternInf
    {
        public int RowID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ServiceCode { get; set; }
        public string EmployeeCode { get; set; }
    }
}
