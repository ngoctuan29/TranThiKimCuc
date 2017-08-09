using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class InventoryGeneralInf
    {
        public decimal RowID { get; set; }
        public string ItemCode { get; set; }
        //public decimal MM { get; set; }
        //public decimal YYYY { get; set; }
        public string RepositoryCode { get; set; }
        public DateTime IDate { get; set; }
        public decimal AmountVirtual { get; set; }
        public decimal AmountBegin { get; set; }
        public decimal AmountImpot { get; set; }
        public decimal AmountExpot { get; set; }
        public decimal AmountEnd { get; set; }
    }

    public class InventoryGumshoeInf
    {
        public decimal RowID { get; set; }
        public DateTime DateImport { get; set; }
        public decimal MM { get; set; }
        public decimal YYYY { get; set; }
        public string ItemCode { get; set; }
        public decimal AmountImport { get; set; }
        public string WarehousingCode { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AmountExport { get; set; }
        public string Shipment { get; set; }
        public string RepositoryCode { get; set; }
        public DateTime IDate { get; set; }
        public decimal BHYTPrice { get; set; }
        public decimal IDWarehousingDetail { get; set; }
    }

    public class InventoryView
    {
        public string ItemCode { get; set; }
        public string Active { get; set; }
        public string UsageCode { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string RepositoryCode { get; set; }
        public decimal AmountBegin { get; set; }
        public decimal AmountVirtual { get; set; }
        public decimal AmountImport { get; set; }
        public decimal AmountExport { get; set; }
        public decimal AmountEnd { get; set; }
        public Int32 Chon { get; set; }
        public Int32 MM { get; set; }
        public Int32 YYYY { get; set; }
    }

    public class InventoryLimitedInf
    {
        public string ItemCode { get; set; }
        public string RepositoryCode { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 Quantity { get; set; }
        public string IEmployeeCode { get; set; }
    }
}
