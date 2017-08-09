using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class FoodDetailINF
    {
        public decimal FoodDetailID { get; set; }
        public decimal FoodEntryID { get; set; }
        public string Catalog_FoodCode { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string EmployeeCode { get; set; }
        public string Note { get; set; }
        public DateTime IDate { get; set; }
    }

    public class FoodDetailPrintINF
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string Content { get; set; }
        public DateTime WorkDate { get; set; }
        public string Catalog_FoodName { get; set; }
        public string FoodCategoryName { get; set; }
        public string UnitOfRawName { get; set; }

        public decimal AmountEntry { get; set; }
        public decimal PriceEntry { get; set; }
        public decimal QuantityEntry { get; set; }

    }

}
