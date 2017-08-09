using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicinesForPatients
    {
        public string MedicalRecordCode { get; set; }
        public Decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string EmployeeCode { get; set; }
        public decimal MM { get; set; }
        public decimal YYYY { get; set; }
        public DateTime DateApproved { get; set; }
        public Int32 ObjectCode { get; set; }
        public Decimal RowID { get; set; }
        public string shiftWork { get; set; }
    }

    public class MedicinesForPatientsDetail
    {
        public Decimal RowID { get; set; }
        public string MedicalRecordCode { get; set; }
        public string ItemCode { get; set; }
        public Int32 DateOfIssues { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal SalesPrice { get; set; }
        public Decimal BHYTPrice { get; set; }
        public Decimal Amount { get; set; }
        public DateTime IDate { get; set; }
        public Decimal RowIDInventoryGumshoe { get; set; }
        public Decimal RateBHYT { get; set; }
        public Int32 ObjectCode { get; set; }
        public string RepositoryCode { get; set; }
        public Decimal QuantityExport { get; set; }
        public Decimal RowIDMedicines { get; set; }
        public Decimal RowIDMedicalPrescription { get; set; }
    }

}
