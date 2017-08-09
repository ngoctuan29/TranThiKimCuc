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
    public class MenuListDal
    {
        public static DataTable DTMenuList()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                //dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                //dt.Columns.Add(new DataColumn("MenuCode", typeof(string)));
                //dt.Columns.Add(new DataColumn("MenuName", typeof(string)));
                dt = cn.ExecuteQuery("select menucode,menuname from MenuList order by rowid ");
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DTMenuListSystem()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt = cn.ExecuteQuery(" select RowID,menucode,menuname,'' EmployeeCode,0 as chon,'' as chitiet from MenuList order by RowID ");
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 InsMenuList(MenuListInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MenuCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MenuCode;
                param[1] = new SqlParameter("@MenuName", SqlDbType.NVarChar, 500);
                param[1].Value = info.MenuName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MenuList", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch{ return -2; }
        }

        public static Int32 DelAll_MenuList()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from MenuList; update SystemParameter set [Values]=0 where RowID=3 ";
                if (cn.ExecuteNonQuery(CommandType.Text, sql, null) >= 1)
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
