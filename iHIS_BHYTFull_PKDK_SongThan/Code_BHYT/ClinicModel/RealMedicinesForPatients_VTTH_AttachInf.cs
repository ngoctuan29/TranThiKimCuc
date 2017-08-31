using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class RealMedicinesForPatients_VTTH_AttachInf
    {
        public decimal RowID { get; set; }
        public string RefCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateApproved { get; set; }
        public Int32 ObjectCode { get; set; }
        public Int32 PatientType { get; set; }
        public Int32 Status { get; set; }
        public string BanksAccountCode { get; set; }
        public string DepartmentCode { get; set; }
        public string ShiftWork { get; set; }
        public string ServiceCode { get; set; }
        public decimal SuggestedID { get; set; }
    }
    public class RealMedicinesForPatients_VTTH_Attach_DetailInf
    {
        public decimal RowID { get; set; }
        public decimal RealRowID { get; set; }
        public string ItemCode { get; set; }
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
        public string Instruction { get; set; }
        public int Paid { get; set; }
        public string BanksAccountCode { get; set; }
    }
}
