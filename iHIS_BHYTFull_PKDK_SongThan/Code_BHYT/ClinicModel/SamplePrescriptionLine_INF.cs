using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class SamplePrescriptionLine_INF
    {
        public decimal RowID { get; set; }
        public string SamplePrescriptionCode { get; set; }
        public string ItemCode { get; set; }
        public string UnitOfMeasure { get; set; }
        public Int32 DateOfIssues { get; set; }
        public float Morning { get; set; }
        public float Noon { get; set; }
        public float Afternoon { get; set; }
        public float Evening { get; set; }
        public Int32 Quantity { get; set; }
        public string Instruction { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string UsageCode { get; set; }
        public string ItemName { get; set; }
        public Int32 RateBHYT { get; set; }
        public Int32 ListBHYT { get; set; }
        public Int32 ListService { get; set; }
        public string UnitOfMeasureCode_Medi { get; set; }
        public bool Converted_Medi { get; set; }
    }

    public class Model_SamplePrescription
    {
        public decimal RowID { get; set; }
        public string SamplePrescriptionCode { get; set; }
        public string ItemCode { get; set; }
        public string UnitOfMeasure { get; set; }
        public Int32 DateOfIssues { get; set; }
        public float Morning { get; set; }
        public float Noon { get; set; }
        public float Afternoon { get; set; }
        public float Evening { get; set; }
        public float Quantity { get; set; }
        public string Instruction { get; set; }
        public float UnitPrice { get; set; }
    }

}
