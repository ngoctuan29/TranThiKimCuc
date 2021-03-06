﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ExportVendorDetailInf
    {
        public decimal RowID { get; set; }
        public DateTime DateImport { get; set; }
        public string ItemCode { get; set; }
        public decimal AmountImport { get; set; }
        public string ExportVendorCode { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AmountExport { get; set; }
        public string Shipment { get; set; }
        public DateTime IDate { get; set; }
        public decimal BHYTPrice { get; set; }
        public decimal AmountRealExport { get; set; }
        public decimal RowIDGumshoe { get; set; }
    }


}
