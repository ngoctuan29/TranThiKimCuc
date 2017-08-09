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
    public class SymptomsDal
    {
        public static List<SymptomsInf> ListSymptoms(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<SymptomsInf> list = new List<SymptomsInf>();
            try
            {
                string sql = "";
                if (dRowID != 0)
                {
                    sql = "select RowID,SymptomsName from Symptoms where RowID in({0}) order by RowID asc";
                }
                else
                {
                    sql = "select RowID,SymptomsName from Symptoms order by RowID asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                while (ireader.Read())
                {
                    SymptomsInf inf = new SymptomsInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.SymptomsName = ireader.GetString(1);
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

        public static Int32 InsSymptoms(SymptomsInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@SymptomsName", SqlDbType.NVarChar, 500);
                param[1].Value = info.SymptomsName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Symptoms", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelSymptoms(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Symptoms", param);
            }
            catch { return -1; }
        }

    }
}
