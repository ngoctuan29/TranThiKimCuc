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
    public class UnitOfMeasureDal
    {
        public static List<UnitOfMeasureInf> ListUnit(string sCode, string type)
        {
            ConnectDB cn = new ConnectDB();
            List<UnitOfMeasureInf> list = new List<UnitOfMeasureInf>();
            try
            {
                string sql = string.Empty;
                if (sCode != "")
                {
                    sql = " select RowID,UnitOfMeasureCode,UnitOfMeasureName from UnitOfMeasure where [Type]='{0}' and UnitOfMeasureCode in('{1}') order by UnitOfMeasureCode asc ";
                }
                else
                {
                    sql = " select RowID,UnitOfMeasureCode,UnitOfMeasureName from UnitOfMeasure where [Type]='{0}' order by UnitOfMeasureCode asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, type, sCode), null);
                while (ireader.Read())
                {
                    UnitOfMeasureInf inf = new UnitOfMeasureInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.UnitOfMeasureCode = ireader.GetString(1);
                    inf.UnitOfMeasureName = ireader.GetString(2);
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

        public static Int32 InsUnit(UnitOfMeasureInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UnitOfMeasureCode", SqlDbType.VarChar, 50);
                param[0].Value = info.UnitOfMeasureCode;
                param[1] = new SqlParameter("@UnitOfMeasureName", SqlDbType.NVarChar, 250);
                param[1].Value = info.UnitOfMeasureName;
                param[2] = new SqlParameter("@Type", SqlDbType.Char, 1);
                param[2].Value = info.Type;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_UnitOfMeasure", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelUnit(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@UnitOfMeasureCode", SqlDbType.VarChar);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_UnitOfMeasure", param);
            }
            catch { return -1; }
        }

    }
}
