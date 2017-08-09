using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class LaboratoryResultDescriptionInf
    {
        public Int32 RowID { get; set; }
        public string DescriptionResult { get; set; }
    }

    public class LabPatternAttachInf
    {
        public Int32 LabPatternID { get; set; }
        public string LabPatternTitle { get; set; }
        public string LabPatternContent { get; set; }
        public string EmployeeCode { get; set; }
        public string ServiceCategoryCode { get; set; }
        public DateTime WorkDate { get; set; }
        public Int32 LabPathologicalID { get; set; }
    }

}
