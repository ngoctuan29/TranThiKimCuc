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
    public class MenuSecurityDal
    {

        public static List<MenuSecurityInf> ListMenu(decimal dId)
        {
            ConnectDB cn = new ConnectDB();
            List<MenuSecurityInf> list = new List<MenuSecurityInf>();
            try
            {
                string sql = "";
                if (dId != 0)
                {
                    sql = "select Rowid,MenuCode,MenuName,EmployeeCode from MenuSecurity where Rowid in({0}) order by Rowid asc";
                }
                else
                {
                    sql = "select Rowid,MenuCode,MenuName,EmployeeCode from MenuSecurity order by Rowid asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dId), null);
                while (ireader.Read())
                {
                    MenuSecurityInf inf = new MenuSecurityInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MenuCode = ireader.GetString(1);
                    inf.MenuName = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
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

        public static List<MenuSecurityInf> ListMenuForUser(string sUser)
        {
            ConnectDB cn = new ConnectDB();
            List<MenuSecurityInf> list = new List<MenuSecurityInf>();
            try
            {
                string sql = "";
                if (sUser != "")
                {
                    sql = "select Rowid,MenuCode,MenuName,EmployeeCode,1 as Chon,'' as chitiet from MenuSecurity where EmployeeCode in('{0}') order by Rowid asc";
                }
                else
                {
                    sql = "select Rowid,MenuCode,MenuName,EmployeeCode,1 as Chon,'' as chitiet from MenuSecurity order by Rowid asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sUser), null);
                while (ireader.Read())
                {
                    MenuSecurityInf inf = new MenuSecurityInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MenuCode = ireader.GetString(1);
                    inf.MenuName = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
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

        public static Int32 InsMenuSecurity(MenuSecurityInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                //param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                //param[0].Value = info.RowID;
                param[0] = new SqlParameter("@MenuCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MenuCode;
                param[1] = new SqlParameter("@MenuName", SqlDbType.NVarChar, 500);
                param[1].Value = info.MenuName;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.EmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MenuSecurity", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelMenuSecurity(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar,50);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_MenuSecurity", param);
            }
            catch { return -1; }
        }

    }
}
