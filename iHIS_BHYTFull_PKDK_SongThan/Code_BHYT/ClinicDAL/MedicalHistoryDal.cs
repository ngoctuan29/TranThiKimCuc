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
    public class MedicalHistoryDal
    {
        public static DataTable TableMedicalHistory(decimal rowID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("MedicalHistoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("MedicalHistoryContent", typeof(string)));
                string sql = "";
                if (rowID != 0)
                {
                    sql = "select RowID,MedicalHistoryName,EmployeeCode,MedicalHistoryContent from MedicalHistory where RowID in({0}) order by RowID asc";
                }
                else
                {
                    sql = "select RowID,MedicalHistoryName,EmployeeCode,MedicalHistoryContent from MedicalHistory order by RowID asc";
                }
                tableResult = cn.ExecuteQuery(string.Format(sql, rowID));
            }
            catch {  }
            return tableResult;
        }

        public static Int32 InsMedicalHistory(MedicalHistoryInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@MedicalHistoryName", SqlDbType.NVarChar, 500);
                param[1].Value = info.MedicalHistoryName;
                param[2] = new SqlParameter("@MedicalHistoryContent", SqlDbType.NVarChar);
                param[2].Value = info.MedicalHistoryContent;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MedicalHistory", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelMedicalHistory(decimal rowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = rowID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_MedicalHistory", param);
            }
            catch { return -1; }
        }

    }
}
