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
    public class ItemGroupDAL
    {
        public static DataTable DTListItemGroup(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                if (sCode != "")
                {
                    sql = "select GroupCode,GroupName,ServiceModuleCode,GroupID_BHYT from ItemGroup where GroupCode in('{0}') order by GroupCode asc";
                }
                else
                {
                    sql = "select GroupCode,GroupName,ServiceModuleCode,GroupID_BHYT from ItemGroup order by GroupCode asc";
                }
                dt = cn.ExecuteQuery(string.Format(sql, sCode));
            }
            catch
            {
                //sError = cn.sconnection;
                dt = null;
            }
            return dt;
        }
        public static List<ItemGroupInf> ListItemGroup(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ItemGroupInf> list = new List<ItemGroupInf>();
            try
            {
                string sql = "";
                if (sCode != "")
                {
                    sql = "select GroupCode,GroupName,ServiceModuleCode from ItemGroup where GroupCode in('{0}') order by GroupCode asc";
                }
                else
                {
                    sql = "select GroupCode,GroupName,ServiceModuleCode from ItemGroup order by GroupCode asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    ItemGroupInf inf = new ItemGroupInf();
                    inf.GroupCode = ireader.GetString(0);
                    inf.GroupName = ireader.GetString(1);
                    inf.ServiceModuleCode = ireader.GetValue(2).ToString();
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

        public static Int32 InsItemGroup(ItemGroupInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@GroupCode", SqlDbType.VarChar, 50);
                param[0].Value = info.GroupCode;
                param[1] = new SqlParameter("@GroupName", SqlDbType.NVarChar, 500);
                param[1].Value = info.GroupName;
                param[2] = new SqlParameter("@ServiceModuleCode", SqlDbType.VarChar, 20);
                param[2].Value = info.ServiceModuleCode;
                param[3] = new SqlParameter("@GroupID_BHYT", SqlDbType.Int);
                param[3].Value = info.GroupID_BHYT;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ItemGroup", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelItemGroup(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@GroupCode", SqlDbType.VarChar, 50);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ItemGroup", param);
            }
            catch { return -1; }
        }
    }
}
