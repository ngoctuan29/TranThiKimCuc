using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class view_MedicinesPatientEmergencyInf
    {
        public DateTime DateOn { get; set; }
        public string TimeOn { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public int PatientBirthyear { get; set; }
        public string PatientAddress { get; set; }
        public string PatientGenderName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
    }
}
