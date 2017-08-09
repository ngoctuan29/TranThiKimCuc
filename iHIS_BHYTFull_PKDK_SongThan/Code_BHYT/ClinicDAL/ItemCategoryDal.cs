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
    public class ItemCategoryDal
    {
        public static List<ItemCategoryInf> ListItemCategory(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ItemCategoryInf> list = new List<ItemCategoryInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(sCode))
                {
                    sql = "select ItemCategoryCode,ItemCategoryName,GroupCode from ItemCategory where ItemCategoryCode in('{0}') order by ItemCategoryCode asc";
                }
                else
                {
                    sql = "select ItemCategoryCode,ItemCategoryName,GroupCode from ItemCategory order by ItemCategoryCode asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    ItemCategoryInf inf = new ItemCategoryInf();
                    inf.ItemCategoryCode = ireader.GetString(0);
                    inf.ItemCategoryName = ireader.GetString(1);
                    inf.GroupCode = ireader.GetValue(2).ToString();
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

        public static Int32 InsItemCategory(ItemCategoryInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemCategoryCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ItemCategoryCode;
                param[1] = new SqlParameter("@ItemCategoryName", SqlDbType.NVarChar, 500);
                param[1].Value = info.ItemCategoryName;
                param[2] = new SqlParameter("@GroupCode", SqlDbType.VarChar, 20);
                param[2].Value = info.GroupCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ItemCategory", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelItemCategory(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ItemCategoryCode", SqlDbType.VarChar, 50);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ItemCategory", param);
            }
            catch { return -1; }
        }

    }
}
