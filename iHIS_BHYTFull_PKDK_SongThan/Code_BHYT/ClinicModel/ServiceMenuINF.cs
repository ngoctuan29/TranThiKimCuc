using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ServiceMenuINF
    {
        public int ServiceMenuID { get; set; }
        public string ServiceMenuName { get; set; }
    }
    public class ServiceMenuForDepartmentINF
    {
        public string DepartmentCode { get; set; }
        public int ServiceMenuID { get; set; }
        
    }

    public class ServiceMenuForServiceINF
    {
        public string ServiceCode { get; set; }
        public int ServiceMenuID { get; set; }

    }
}
