using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicinesForPatients_ReceiveINF
    {
        public decimal RowID { get; set; }
        public string PatientCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string ReferenceCode { get; set; }
        public DateTime IDate { get; set; }
        public string EmployeeCode { get; set; }
        public string ItemCode { get; set; }
        public string RepositoryCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Quantity_Receive { get; set; }
        public DateTime WorkDate_Receive { get; set; }
        public string Note { get; set; }
        public decimal RowIDMedicine { get; set; }
    }
}
