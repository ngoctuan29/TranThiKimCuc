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
    public class AdvicesDal
    {
        public static List<AdvicesInf> ListAdvices(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<AdvicesInf> list = new List<AdvicesInf>();
            try
            {
                string sql = "";
                if (dRowID != 0)
                {
                    sql = "select RowID,AdvicesName from Advices where RowID in({0}) order by RowID asc";
                }
                else
                {
                    sql = "select RowID,AdvicesName from Advices order by RowID asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                while (ireader.Read())
                {
                    AdvicesInf inf = new AdvicesInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.AdvicesName = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch{ list = null; }
            return list;
        }

        public static Int32 InsAdvices(AdvicesInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@AdvicesName", SqlDbType.NVarChar, 500);
                param[1].Value = info.AdvicesName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Advices", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelAdvices(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Advices", param);
            }
            catch { return -1; }
        }

    }
}
