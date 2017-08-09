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
    public class UsageDal
    {
        public static List<UsageInf> ListUsage(string sUsageCode)
        {
            ConnectDB cn = new ConnectDB();
            List<UsageInf> list = new List<UsageInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(sUsageCode))
                {
                    sql = " select UsageCode,UsageName,STT,BHYT_MaDuongDung from Usage where UsageCode in('{0}') order by STT asc ";
                }
                else
                {
                    sql = " select UsageCode,UsageName,STT,BHYT_MaDuongDung from Usage order by STT asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sUsageCode), null);
                while (ireader.Read())
                {
                    UsageInf inf = new UsageInf();
                    inf.UsageCode = ireader.GetString(0);
                    inf.UsageName = ireader.GetValue(1).ToString();
                    inf.STT = (int)ireader.GetValue(2);
                    inf.BHYT_MaDuongDung = ireader.GetValue(3).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }

        public static Int32 InsUsage(UsageInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@UsageCode", SqlDbType.VarChar);
                param[0].Value = info.UsageCode;
                param[1] = new SqlParameter("@UsageName", SqlDbType.NVarChar);
                param[1].Value = info.UsageName;
                param[2] = new SqlParameter("@STT", SqlDbType.Int);
                param[2].Value = info.STT;
                param[3] = new SqlParameter("@BHYT_MaDuongDung", SqlDbType.VarChar);
                param[3].Value = info.BHYT_MaDuongDung;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Usage", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelUsage(string sUsageCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@UsageCode", SqlDbType.VarChar, 50);
                param[1].Value = sUsageCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Usage", param);
            }
            catch { return -1; }
        }

        public static DataTable DataUsageBHYT()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "select UsageCode,UsageName,STT from Usage_BHYT order by STT asc";
                tableResult = cn.ExecuteQuery(sql);
            }
            catch { tableResult = null; }
            return tableResult;
        }
    }
}
