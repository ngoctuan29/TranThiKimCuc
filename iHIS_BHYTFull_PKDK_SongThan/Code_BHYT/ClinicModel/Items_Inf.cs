using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Items_View
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Active { get; set; }
        public string UsageCode { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string ItemCategoryCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public Int32 Status { get; set; }
        public decimal SalesPrice { get; set; }
        public Int32 SafelyQuantity { get; set; }
        public string RepositoryCode { get; set; }
        public string EmployeeCode { get; set; }
        public int ListBHYT { get; set; }
        public int RateBHYT { get; set; }
        public string CountryCode { get; set; }
        public string ProducerCode { get; set; }
        public string Note { get; set; }
        public decimal DisparityPrice { get; set; }
        public int ListService { get; set; }
        public string VendorCode { get; set; }
        public string Packed { get; set; }
        public int QtyOfMeasure { get; set; }
        public string ItemContent { get; set; }
        public string STTBCBHYT { get; set; }
        public string SODKGP { get; set; }
        public string STTQDPK { get; set; }
        public string QUYCACH { get; set; }
        public string Generic_BD { get; set; }
        public string VENCode { get; set; }
        public string Active_TT40 { get; set; }
        public decimal SalesPrice_Retail { get; set; }
        public string UnitOfMeasureCode_Medi { get; set; }
        public Boolean Converted_Medi { get; set; }
    }

    public class Items_Ins
    {
        public decimal RowID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Active { get; set; }
        public string UsageCode { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string ItemCategoryCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BHYTPrice { get; set; }
        public Int32 Status { get; set; }
        public decimal SalesPrice { get; set; }
        public Int32 SafelyQuantity { get; set; }
        public string RepositoryCode { get; set; }
        public DateTime idate { get; set; }
        public DateTime udate { get; set; }
        public string EmployeeCode { get; set; }
        public int ListBHYT { get; set; }
        public int RateBHYT { get; set; }
        public string CountryCode { get; set; }
        public string ProducerCode { get; set; }
        public string Note { get; set; }
        public decimal DisparityPrice { get; set; }
        public int ListService { get; set; }
        public string VendorCode { get; set; }
        public string Packed { get; set; }
        public int QtyOfMeasure { get; set; }
        public string ItemContent { get; set; }
        public string STTBCBHYT { get; set; }
        public string SODKGP { get; set; }
        public string STTQDPK { get; set; }
        public string QUYCACH { get; set; }
        public string Generic_BD { get; set; }
        public string VENCode { get; set; }
        public string Active_TT40 { get; set; }
        public decimal SalesPrice_Retail { get; set; }
        public string UnitOfMeasureCode_Medi { get; set; }
        public Boolean Converted_Medi { get; set; }
    }
    public class Items_Ref
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemContent { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string ItemCategoryName { get; set; }
        public string UsageCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public int SafelyQuantity { get; set; }
        public decimal BHYTPrice { get; set; }
        public string Active { get; set; }
        public decimal AmountVirtual { get; set; }
        public string RepositoryCode { get; set; }
        public string RepositoryName { get; set; }
        public decimal AmountEnd { get; set; }
        public decimal RateBHYT { get; set; }
        public string Note { get; set; }
        public int ListBHYT { get; set; }
        public int RepositoryGroupCode { get; set; }
        public string UsageName { get; set; }
        public decimal DisparityPrice { get; set; }
        public int ListService { get; set; }
        public string Packed { get; set; }
        public int QtyOfMeasure { get; set; }
        public string SODKGP { get; set; }
        public string Active_TT40 { get; set; }
        public decimal SalesPrice_Retail { get; set; }
        public string UnitOfMeasureCode_Medi { get; set; }
        public Boolean Converted_Medi { get; set; }
    }
}
