using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class BanksAccountDetailInf
    {
        public decimal RowID { get; set; }
        public string BanksAccountCode { get; set; }
        public string ServiceCode { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public int STT { get; set; }
        public int ObjectCode { get; set; }
        public DateTime PostingDate { get; set; }
        public string EmployeeCode { get; set; }
        public decimal RowIDPrice { get; set; }
        public decimal ReceiptID { get; set; }
        public Int32 Type { get; set; }
        public decimal Quantity { get; set; }
        public string MedicalRecordCode { get; set; }
        public decimal RowIDMedicines { get; set; }
        public decimal RowIDDetail { get; set; }
        public Int32 MedicinesType { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal PatientPay { get; set; }
        public decimal ServicePriceSalesOff { get; set; }
    }
}
