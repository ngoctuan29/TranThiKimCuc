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
    public class Catalog_SurgicalCrewDAL
    {
        public static DataTable DT_List()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                sql = " select RowID,EmployeeName,Role,STT,EmployeeCode,PositionCode from Catalog_SurgicalCrew ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        
        public static Int32 Ins(Catalog_SurgicalCrewINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@EmployeeName", SqlDbType.NVarChar, 250);
                param[1].Value = info.EmployeeName;
                param[2] = new SqlParameter("@Role", SqlDbType.NVarChar, 50);
                param[2].Value = info.Role;
                param[3] = new SqlParameter("@STT", SqlDbType.Int);
                param[3].Value = info.STT;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@PositionCode", SqlDbType.Int);
                param[5].Value = info.PositionCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Catalog_SurgicalCrew", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(Int32 iRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from Catalog_SurgicalCrew where RowID=@RowID";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = iRowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
    }
}
