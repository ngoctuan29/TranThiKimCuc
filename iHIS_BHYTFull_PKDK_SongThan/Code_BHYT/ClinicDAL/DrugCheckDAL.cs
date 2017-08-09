using System;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using ClinicModel;

namespace ClinicDAL
{
   public class DrugCheckDAL
    {
        public static string Get_ICD10(int RowID)
        {
            ConnectDB cn = new ConnectDB();
            string ICDcode = string.Empty;
            try
            {
                string sql = string.Empty;
                sql = "select DiagnosisCode from Diagnosis where RowID={0}";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, RowID), null);
                while (ireader.Read())
                {
                    ICDcode = ireader.ToString();
                }
            }
            catch (Exception){ }
            return ICDcode;
        }
        public static DataTable Get_ICD10_Base_Disease_Local(string PatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "pro_ICD_Base_Disease_Local";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.Decimal,18);
                param[0].Value = PatientCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static string Get_DoctorName(string EmployeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "pro_Get_NameDoctor";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.NVarChar);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@employeeCodeDoctor", SqlDbType.VarChar,50);
                param[1].Value = EmployeeCode;
                return cn.ExecuteReaderProcedure(CommandType.StoredProcedure, query, param);
            }
            catch { return string.Empty; }

        }
    }
}
