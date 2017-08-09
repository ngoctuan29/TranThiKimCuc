using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class FoodEntryINF
    {
        public decimal FoodEntryID { get; set; }
        public string Content { get; set; }
        public string EmployeeCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime WorkDate { get; set; }
        public Int32 Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
