using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicDAL;
using System.Data;

namespace ClinicBLL
{
    public class DrugCheckBLL
    {
        public static string GetICD10(int RowID)
        {
            return DrugCheckDAL.Get_ICD10(RowID);
        }
        public static DataTable Get_ICD10_Base_Disease_Local(string PatientCode)
        {
            return DrugCheckDAL.Get_ICD10_Base_Disease_Local(PatientCode);
        }
        public static string Get_DoctorName(string EmployeeCode)
        {
            return DrugCheckDAL.Get_DoctorName(EmployeeCode);
        }
    }
}
