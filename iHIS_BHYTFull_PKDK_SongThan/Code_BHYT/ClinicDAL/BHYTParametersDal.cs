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
    public class BHYTParametersDal
    {
        public static BHYTParametersInf ObjParameters(int iRowID)
        {
            ConnectDB cn = new ConnectDB();
            BHYTParametersInf inf = new BHYTParametersInf();
            try
            {
                string sql = string.Empty;
                if (iRowID != 0)
                {
                    sql = "select RowID,BHYTUnderPrice,BHYTOnPrice from BHYTParameters where RowID in({0}) order by RowID asc";
                }
                else
                {
                    sql = "select RowID,BHYTUnderPrice,BHYTOnPrice from BHYTParameters order by RowID asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetInt32(0);
                    inf.BHYTUnderPrice = ireader.GetDecimal(1);
                    inf.BHYTOnPrice = ireader.GetDecimal(2);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch  { return null; }
        }

        public static Int32 Ins(BHYTParametersInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@BHYTUnderPrice", SqlDbType.Decimal);
                param[1].Value = info.BHYTUnderPrice;
                param[2] = new SqlParameter("@BHYTOnPrice", SqlDbType.Decimal);
                param[2].Value = info.BHYTOnPrice;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_BHYTParameters", param) >= 1)
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
