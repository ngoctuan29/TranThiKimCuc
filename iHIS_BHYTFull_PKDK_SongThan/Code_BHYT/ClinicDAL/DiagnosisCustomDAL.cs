using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;

namespace ClinicDAL
{
    public class DiagnosisCustomDAL
    {
        public static DataTable TableDiagnosisCustom(Int32 rowid)
        {
            DataTable tableResult = new DataTable();
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                tableResult.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("DiagnosisName", typeof(string)));
                if (rowid != 0)
                    sql = "select RowID,DiagnosisName from DiagnosisCustom where RowID in({0}) ";
                else
                    sql = "select RowID,DiagnosisName from DiagnosisCustom order by RowID ";
                tableResult = cn.ExecuteQuery(string.Format(sql, rowid));
            }
            catch { }
            return tableResult;
        }

        public static Int32 Ins(Int32 rowid, string diagnosisName, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = rowid;
                param[1] = new SqlParameter("@DiagnosisName", SqlDbType.NVarChar, 250);
                param[1].Value = diagnosisName;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_DiagnosisCustom", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(Int32 rowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = rowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_DiagnosisCustom", param);
            }
            catch { return -1; }
        }

    }
}

