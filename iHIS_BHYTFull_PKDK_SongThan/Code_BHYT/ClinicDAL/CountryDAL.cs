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
    public class CountryDAL
    {
        public static List<CountryInf> ListCountry(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<CountryInf> list = new List<CountryInf>();
            try
            {
                string sql = "";
                if (sCode != "")
                {
                    sql = "select CountryCode,CountryName from Country where CountryCode='{0}' order by CountryCode asc ";
                }
                else
                {
                    sql = "select CountryCode,CountryName from Country order by CountryCode asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    CountryInf inf = new CountryInf();
                    inf.CountryCode = ireader.GetString(0);
                    inf.CountryName = ireader.GetString(1);
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

        public static Int32 Ins(CountryInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@CountryCode", SqlDbType.VarChar, 6);
                param[0].Value = info.CountryCode;
                param[1] = new SqlParameter("@CountryName", SqlDbType.NVarChar, 250);
                param[1].Value = info.CountryName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Country", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@CountryName", SqlDbType.VarChar, 6);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Country", param);
            }
            catch { return -1; }
        }

    }
}
