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
    public class SystemParameterDal
    {
        public static List<SystemParameterInf> ListParameter(string sModule)
        {
            ConnectDB cn = new ConnectDB();
            List<SystemParameterInf> list = new List<SystemParameterInf>();
            try
            {
                string sql = "select RowID,Module,[Values],Description,IDate,UDate,Name from SystemParameter where Module in('{0}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sModule), null);
                while (ireader.Read())
                {
                    SystemParameterInf inf = new SystemParameterInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.Module = ireader.GetString(1);
                    inf.Values = ireader.GetInt32(2);
                    inf.Description = ireader.GetValue(3).ToString();
                    inf.IDate = ireader.GetDateTime(4);
                    inf.UDate = ireader.GetDateTime(5);
                    inf.Name = ireader.GetValue(6).ToString();
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

        public static SystemParameterInf ObjParameter(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            SystemParameterInf inf = new SystemParameterInf();
            try
            {
                string sql = "select RowID,Module,[Values],Description,IDate,UDate,Name,VersionNo from SystemParameter where RowID in({0})";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                if(ireader.Read())
                {
                    inf.RowID = ireader.GetInt32(0);
                    inf.Module = ireader.GetString(1);
                    inf.Values = ireader.GetInt32(2);
                    inf.Description = ireader.GetValue(3).ToString();
                    inf.IDate = ireader.GetDateTime(4);
                    inf.UDate = ireader.GetDateTime(5);
                    inf.Name = ireader.GetValue(6).ToString();
                    inf.VersionNo = ireader.GetValue(7).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { return null; }
            return inf;
        }

        public static Int32 Ins(Int32 iRowID, string sModule, string sName, Int32 iValues, string sDescription, string sEmployeeCode, string versionNo)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = iRowID;
                param[1] = new SqlParameter("@Module", SqlDbType.VarChar, 50);
                param[1].Value = sModule;
                param[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 250);
                param[2].Value = sName;
                param[3] = new SqlParameter("@Values", SqlDbType.Int);
                param[3].Value = iValues;
                param[4] = new SqlParameter("@Description", SqlDbType.NVarChar, 250);
                param[4].Value = sDescription;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[5].Value = sEmployeeCode;
                param[6] = new SqlParameter("@VersionNo", SqlDbType.VarChar, 20);
                param[6].Value = versionNo;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_SystemParameter", param) >= 1)
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
