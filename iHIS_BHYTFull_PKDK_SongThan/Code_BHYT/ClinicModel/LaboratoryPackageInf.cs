using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class LaboratoryPackageInf
    {
        public string LaboratoryPackageCode { get; set; }
        public string EmployeeCode { get; set; }
        public string ServiceCode { get; set; }
        public string LaboratoryPackageName { get; set; }
        public Int32 TypeResult { get; set; }
        public string TemplateHeaderCode { get; set; }
    }

    public class LaboratoryPackageDetailInf
    {
        public Int32 RowID { get; set; }
        public string LaboratoryPackageCode { get; set; }
        public string LaboratoryName { get; set; }
        public string UnitValues { get; set; }
        public string ValuedFemale { get; set; }
        public string ValuedMale { get; set; }
        public decimal MinValuedFemale { get; set; }
        public decimal MaxValuedFemale { get; set; }
        public decimal MinValuedMale { get; set; }
        public decimal MaxValuedMale { get; set; }
        public Int32 STT { get; set; }
        public string ParameterMachine { get; set; }
        public string ValuesEntry { get; set; }
    }
}
