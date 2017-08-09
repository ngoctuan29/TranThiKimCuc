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
    public class UnitOfRawDAL
    {
        public static DataTable DT_UnitOfRaw(Int32 iID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("UnitOfRawID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("UnitOfRawName", typeof(string)));
                string sql = "";
                if (iID != 0)
                {
                    sql = " select UnitOfRawID,UnitOfRawName from UnitOfRaw where UnitOfRawID in({0}) order by UnitOfRawID asc ";
                }
                else
                {
                    sql = " select UnitOfRawID,UnitOfRawName from UnitOfRaw order by UnitOfRawID asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iID), null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetInt32(0), ireader.GetValue(1).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<UnitOfRawINF> ListUnitOfRaw(Int32 iID)
        {
            ConnectDB cn = new ConnectDB();
            List<UnitOfRawINF> list = new List<UnitOfRawINF>();
            try
            {
                string sql = "";
                if (iID != 0)
                {
                    sql = " select UnitOfRawID,UnitOfRawName from UnitOfRaw where UnitOfRawID in({0}) order by UnitOfRawID asc ";
                }
                else
                {
                    sql = " select UnitOfRawID,UnitOfRawName from UnitOfRaw order by UnitOfRawID asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iID), null);
                while (ireader.Read())
                {
                    UnitOfRawINF inf = new UnitOfRawINF();
                    inf.UnitOfRawID = ireader.GetInt32(0);
                    inf.UnitOfRawName = ireader.GetValue(1).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { list = null; }
            return list;
        }

        public static Int32 Ins(UnitOfRawINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UnitOfRawID", SqlDbType.Int);
                param[0].Value = info.UnitOfRawID;
                param[1] = new SqlParameter("@UnitOfRawName", SqlDbType.NVarChar, 250);
                param[1].Value = info.UnitOfRawName;
                param[2] = new SqlParameter("@iresult", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_UnitOfRaw", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(Int32 iID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@UnitOfRawID", SqlDbType.Int);
                param[1].Value = iID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_UnitOfRaw", param);
            }
            catch { return -1; }
        }
    }
}
