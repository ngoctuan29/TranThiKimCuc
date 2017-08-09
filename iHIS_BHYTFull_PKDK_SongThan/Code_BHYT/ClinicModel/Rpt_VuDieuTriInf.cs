using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class BM05_YTTNInf
    {
        public Decimal RowID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime WorkDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class BM05_YTTNDetailInf
    {
        public Decimal RowID_BM05 { get; set; }
        public int RowIDTemplate { get; set; }
        public string TargetName { get; set; }
        public string Result { get; set; }
    }
    public class BM05_YTTN_TemplateInf
    {
        public int RowIDTemplate { get; set; }
        public int OrderNumber { get; set; }
        public string LaMa { get; set; }
        public string LaMa_Detail { get; set; }
        public string TargetName { get; set; }
        public string Result { get; set; }
        public string ServiceCode { get; set; }
    }
}
