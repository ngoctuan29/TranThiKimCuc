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
    public class EmployeePositionDal
    {
        static ConnectDB cn = new ConnectDB();
        public static List<EmployeePositionInf> ListEmployeePosition(int iPositionCode)
        {
            List<EmployeePositionInf> list = new List<EmployeePositionInf>();
            try
            {
                string sql = "";
                if (iPositionCode != 0)
                {
                    sql = "select PositionCode,PositionName from EmployeePosition where PositionCode in({0}) order by PositionCode desc";
                }
                else
                {
                    sql = "select PositionCode,PositionName from EmployeePosition order by PositionCode desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iPositionCode), null);
                while (ireader.Read())
                {
                    EmployeePositionInf inf = new EmployeePositionInf();
                    inf.PositionCode = ireader.GetInt32(0);
                    inf.PositionName = ireader.GetString(1);
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

        public static Int32 InsEmployeePosition(EmployeePositionInf info, bool bCheck)
        {
            try
            {
                string sql = "";
                if (bCheck)
                {
                    sql = " insert into EmployeePosition(PositionName) values(@PositionName) ";
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@PositionName", SqlDbType.NVarChar);
                    param[0].Value = info.PositionName;
                    if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                    {
                        return 1;
                    }
                    else
                        return -1;
                }
                else
                {
                    sql = " update EmployeePosition set PositionName=@PositionName where PositionCode=@PositionCoe ";
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@PositionCode", SqlDbType.Int);
                    param[0].Value = info.PositionCode;
                    param[1] = new SqlParameter("@PositionName", SqlDbType.NVarChar);
                    param[1].Value = info.PositionName;
                    if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                    {
                        return 1;
                    }
                    else
                        return -1;
                }
                
            }
            catch { return -2; }
        }

        public static Int32 DelEmployeePosition(string sPositionCode)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PositionCode", SqlDbType.VarChar, 50);
                param[1].Value = sPositionCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_EmployeePosition", param);
            }
            catch { return -1; }
        }

    }
}
