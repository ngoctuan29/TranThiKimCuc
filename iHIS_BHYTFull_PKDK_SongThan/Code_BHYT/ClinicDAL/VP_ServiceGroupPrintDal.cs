using ClinicModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ClinicDAL
{
    public class VP_ServiceGroupPrintDal
    {
        public static DataTable GetListNhomIn()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" SELECT ID,GroupName FROM ServiceGroupPrint";
                return cn.ExecuteQuery(string.Format(sql));
            }
            catch { return null; }
        }

        public static DataTable GetListNhomInByCode(int code)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" SELECT ID,GroupName FROM ServiceGroupPrint where ID = {0}";
                return cn.ExecuteQuery(string.Format(sql, code));
            }
            catch { return null; }
        }

        public static bool InsUpdNhomIn(VP_ServiceGroupPrintInf inf)
        {
            try
            {
                ConnectDB cn = new ConnectDB();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = inf.ID;
                param[1] = new SqlParameter("@GroupName", SqlDbType.NVarChar);
                param[1].Value = inf.GroupName;
                cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIU_ServiceGroupPrint", param);
                return true;
            }
            catch { return false; }
        }

        public static bool DelNhomIn(int code)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ID", SqlDbType.Int);
                param[1].Value = code;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_ServiceGroupPrint", param) == 1)
                { return true; }
                else { return false; }
            }
            catch { return false; }
        }
    }
}
