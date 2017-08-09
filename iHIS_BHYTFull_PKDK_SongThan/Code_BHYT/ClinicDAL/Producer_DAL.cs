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
    public class Producer_DAL
    {
        public static List<Producer_INF> ListProducer(string sProducCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Producer_INF> list = new List<Producer_INF>();
            try
            {
                string sql = "";
                if (sProducCode != "")
                {
                    sql = "select ProducerCode,ProducerName,Hide from Producer where ProducerCode='{0}' order by rowid desc";
                }
                else
                {
                    sql = "select ProducerCode,ProducerName,Hide from Producer order by rowid desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sProducCode), null);
                while (ireader.Read())
                {
                    Producer_INF inf = new Producer_INF();
                    inf.ProducerCode = ireader.GetString(0);
                    inf.ProducerName = ireader.GetString(1);
                    inf.Hide = ireader.GetInt32(2);
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

        public static Int32 Ins(Producer_INF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ProducerCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ProducerCode;
                param[1] = new SqlParameter("@ProducerName", SqlDbType.NVarChar, 250);
                param[1].Value = info.ProducerName;
                param[2] = new SqlParameter("@Hide", SqlDbType.Int);
                param[2].Value = info.Hide;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Producer", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sProducCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ProducerCode", SqlDbType.VarChar, 50);
                param[1].Value = sProducCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Producer", param);
            }
            catch { return -1; }
        }

    }
}
