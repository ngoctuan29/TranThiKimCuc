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
    public class Catalog_FoodDAL
    {
        public static DataTable DT_ListCatalog_Food()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                sql = " select Catalog_FoodCode,FoodCategoryID,Catalog_FoodName,EmployeeCode,UnitOfRawID from Catalog_Food order by FoodCategoryID,Catalog_FoodName ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static Int32 Ins(Catalog_FoodINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Catalog_FoodCode", SqlDbType.VarChar, 6);
                param[0].Value = info.Catalog_FoodCode;
                param[1] = new SqlParameter("@FoodCategoryID", SqlDbType.Int);
                param[1].Value = info.FoodCategoryID;
                param[2] = new SqlParameter("@Catalog_FoodName", SqlDbType.NVarChar,500);
                param[2].Value = info.Catalog_FoodName;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar,50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@UnitOfRawID", SqlDbType.Int);
                param[4].Value = info.UnitOfRawID;
                param[5] = new SqlParameter("@iresult", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Catalog_Food", param);
            }
            catch { return -2; }
        }

        public static Int32 Del(string sCatalog_FoodCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Catalog_FoodCode", SqlDbType.VarChar, 6);
                param[1].Value = sCatalog_FoodCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Catalog_Food", param);
            }
            catch { return -1; }
        }

    }
}
