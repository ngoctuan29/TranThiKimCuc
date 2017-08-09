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
    public class CareerDAL
    {
        public static DataTable DTCareer(string sCareerCode)
        {
            DataTable dt = new DataTable();
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                dt.Columns.Add(new DataColumn("CareerCode", typeof(string)));
                dt.Columns.Add(new DataColumn("CareerName", typeof(string)));
                if (sCareerCode != string.Empty)
                {
                    sql = "select CareerCode,CareerName from Career where CareerCode in('{0}') order by CareerCode asc";
                }
                else
                {
                    sql = "select CareerCode,CareerName from Career order by CareerCode asc";
                }
                dt = cn.ExecuteQuery(string.Format(sql, sCareerCode));
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCareerCode), null);
                //while (ireader.Read())
                //{
                //    CareerInf inf = new CareerInf();
                //    inf.CareerCode = ireader.GetString(0);
                //    inf.CareerName = ireader.GetString(1);
                //    dt.Rows.Add(inf.CareerCode, inf.CareerName);
                //}
            }
            catch {  }
            return dt;
        }

        public static Int32 Ins(CareerInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CareerCode", SqlDbType.VarChar);
                param[0].Value = info.CareerCode;
                param[1] = new SqlParameter("@CareerName", SqlDbType.NVarChar, 250);
                param[1].Value = info.CareerName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Career", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sCareerCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@CareerCode", SqlDbType.VarChar);
                param[1].Value = sCareerCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Career", param);
            }
            catch { return -1; }
        }

    }
}
