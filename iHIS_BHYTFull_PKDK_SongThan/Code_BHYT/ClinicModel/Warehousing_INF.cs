using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Warehousing_INF
    {
        public Warehousing_INF() { }
        public string WarehousingCode { get; set; }
        public DateTime ImportDate { get; set; }
        public string Seri { get; set; }
        public string InvoiceNnumber { get; set; }
        public string InvoiceDate { get; set; }
        public string ReportNumber { get; set; }
        public string ReportDate { get; set; }
        public string VendorCode { get; set; }
        public Int32 Discount { get; set; }
        public string Shipper { get; set; }
        public Int32 Supplies { get; set; }
        public string RepositoryCode { get; set; }
        public Int32 Reason { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public Int32 Status { get; set; }
        public string InventoryStaff { get; set; }
        public Decimal AmountTotal { get; set; }
        public Decimal ScotTotal { get; set; }
        public string ShiftWork { get; set; }
        public string FormNo { get; set; }
        public Int32 VAT { get; set; }
        public decimal Depreciated { get; set; }
    }

    public class ViewWarehousingInf : Warehousing_INF
    {
        public string v_VendorName { get; set; }
        public string v_SuppliesName { get; set; }
        public string v_RepositoryName { get; set; }
        public string v_ReasonName { get; set; }
        public string v_EmployeeName { get; set; }
        public List<ViewWarehousingDetailInf> ListWarehousingDetail { get; set; }
    }

    public class WarehousingSearch_INF
    {
        public string WarehousingCode { get; set; }
        public DateTime ImportDate { get; set; }
        public string Seri { get; set; }
        public string InvoiceNnumber { get; set; }
        public string VendorName { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryCode { get; set; }
        public Int32 Status { get; set; }
        public string FormNo { get; set; }
        public Int32 VAT { get; set; }
        public decimal AmountNoVAT { get; set; }
        public decimal AmountVAT { get; set; }
        public decimal Depreciated { get; set; }
        public string EmployeeName { get; set; }
    }

    public class WarehousingDetail_INF
    {
        public WarehousingDetail_INF() { }
        public decimal RowID { get; set; }
        public string WarehousingCode { get; set; }
        public string ItemCode { get; set; }
        public string Active { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public Int32 Tax { get; set; }
        public Decimal Scot { get; set; }
        public Decimal TotalTax { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public string Shipment { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal UnitPriceNoVAT { get; set; }
        public Int32 PerSalesPrice { get; set; }
        public decimal QtyOfMeasure { get; set; }
        public decimal QuantityInput { get; set; }
    }

    public class ViewWarehousingDetailInf : WarehousingDetail_INF
    {
        public string v_ItemName { get; set; }
        public string v_UnitOfMeasureName { get; set; }
        public string Packed { get; set; }
    }
}
