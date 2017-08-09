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
    public class FoodCategoryDAL
    {
        public static List<FoodCategoryINF> ListFoodCategory()
        {
            ConnectDB cn = new ConnectDB();
            List<FoodCategoryINF> list = new List<FoodCategoryINF>();
            try
            {
                string sql = "";
                sql = @" select FoodCategoryID, FoodCategoryName,STT from  FoodCategory order by STT ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    FoodCategoryINF inf = new FoodCategoryINF();
                    inf.FoodCategoryID = ireader.GetInt32(0);
                    inf.FoodCategoryName = ireader.GetValue(1).ToString();
                    inf.STT = ireader.GetInt32(2);
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

        public static DataTable DTListFoodCategory()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                sql = @" select FoodCategoryID, FoodCategoryName,STT from  FoodCategory order by STT ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static Int32 Ins(FoodCategoryINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "insert into FoodCategory(FoodCategoryID,FoodCategoryName,IDate,STT) values((select ISNULL(MAX(FoodCategoryID),1)+1 from FoodCategory),@FoodCategoryName,GETDATE(),@STT)";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FoodCategoryName", SqlDbType.NVarChar, 250);
                param[0].Value = info.FoodCategoryName;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = info.STT;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 Upd(FoodCategoryINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update FoodCategory set FoodCategoryName=@FoodCategoryName,IDate=GETDATE(),STT=@STT where FoodCategoryID=@FoodCategoryID ";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FoodCategoryName", SqlDbType.NVarChar, 250);
                param[0].Value = info.FoodCategoryName;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = info.STT;
                param[2] = new SqlParameter("@FoodCategoryID", SqlDbType.Int);
                param[2].Value = info.FoodCategoryID;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 Del(Int32 iFoodCategoryID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@FoodCategoryID", SqlDbType.Int);
                param[1].Value = iFoodCategoryID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_FoodCategory", param);
            }
            catch { return -1; }
        }

    }
}
