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
    public class BracketPrice_DAL
    {
        public static BracketPrice_INF List(int iRowID)
        {
            ConnectDB cn = new ConnectDB();
            BracketPrice_INF inf = new BracketPrice_INF();
            try
            {
                string sql = string.Empty;
                if (iRowID != 0)
                {
                    sql = "select RowID,Range1,Range2,InterestRateOf,STT from BracketPrice where RowID in({0}) order by RowID asc";
                }
                else
                {
                    sql = "select RowID,Range1,Range2,InterestRateOf,STT from BracketPrice order by RowID asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetInt32(0);
                    inf.Range1 = ireader.GetDecimal(1);
                    inf.Range2 = ireader.GetDecimal(2);
                    inf.InterestRateOf = ireader.GetInt32(3);
                    inf.STT = ireader.GetInt32(4);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }

        public static DataTable DT_List()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = " select RowID,Range1,Range2,InterestRateOf,STT from BracketPrice order by STT asc ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static Int32 Ins(BracketPrice_INF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@Range1", SqlDbType.Decimal);
                param[1].Value = info.Range1;
                param[2] = new SqlParameter("@Range2", SqlDbType.Decimal);
                param[2].Value = info.Range2;
                param[3] = new SqlParameter("@InterestRateOf", SqlDbType.Int);
                param[3].Value = info.InterestRateOf;
                param[4] = new SqlParameter("@STT", SqlDbType.Int);
                param[4].Value = info.STT;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[5].Value = info.EmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_BracketPrice", param) >= 1)
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
                string sql = " delete from BracketPrice where RowID=@RowID";
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

        public static Int32 SearchRateOf(decimal dUnitPrice)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                Int32 iResult = 0;
                string sql = string.Empty;
                sql = " select Range1,Range2,InterestRateOf from BracketPrice order by STT ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    if (dUnitPrice >= ireader.GetDecimal(0) && dUnitPrice <= ireader.GetDecimal(1))
                    {
                        iResult = ireader.GetInt32(2);
                        break;
                    }
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return iResult;
            }
            catch { return 0; }
        }
    }
}
