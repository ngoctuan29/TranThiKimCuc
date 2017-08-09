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
    public class RateBHYTDal
    {
        public static List<RateBHYTInf> ListRateBHYT()
        {
            ConnectDB cn = new ConnectDB();
            List<RateBHYTInf> list = new List<RateBHYTInf>();
            try
            {
                string sql = "";
                sql = "select RateCard,RateTrue,RateFalse from RateBHYT order by RateCard asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    RateBHYTInf inf = new RateBHYTInf();
                    inf.RateCard = ireader.GetString(0);
                    inf.RateTrue = ireader.GetInt32(1);
                    inf.RateFalse = ireader.GetInt32(2);
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

        public static RateBHYTInf objectRateBHYT(string sRateCard)
        {
            ConnectDB cn = new ConnectDB();
            RateBHYTInf inf = new RateBHYTInf();
            try
            {
                string sql = "";
                sql = "select RateCard,RateTrue,RateFalse from RateBHYT where RateCard='{0}' order by RateCard asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRateCard), null);
                if (ireader.Read())
                {
                    inf.RateCard = ireader.GetString(0);
                    inf.RateTrue = ireader.GetInt32(1);
                    inf.RateFalse = ireader.GetInt32(2);
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

        public static Int32 InsRate(RateBHYTInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RateCard", SqlDbType.VarChar, 20);
                param[0].Value = info.RateCard;
                param[1] = new SqlParameter("@RateTrue", SqlDbType.Int);
                param[1].Value = info.RateTrue;
                param[2] = new SqlParameter("@RateFalse", SqlDbType.Int);
                param[2].Value = info.RateFalse;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_RateBHYT", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelRate(string rateCard)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from RateBHYT where RateCard=@RateCard";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RateCard", SqlDbType.VarChar, 20);
                param[0].Value = rateCard;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }
    }
}
