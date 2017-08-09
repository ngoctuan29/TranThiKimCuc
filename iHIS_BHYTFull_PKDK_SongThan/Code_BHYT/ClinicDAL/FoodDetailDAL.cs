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
    public class FoodDetailDAL
    {
        
        public static DataTable DT_ListFoodDetail(decimal dEntryID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FoodDetailID", typeof(decimal)));
            dt.Columns.Add(new DataColumn("FoodEntryID", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Catalog_FoodCode", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
            dt.Columns.Add(new DataColumn("Note", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitOfRawID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("FoodCategoryName", typeof(string)));
            try
            {
                string sql = "";
                sql = @" select a.FoodDetailID, a.FoodEntryID,a.Catalog_FoodCode,a.Price,a.Quantity,a.Amount,a.EmployeeCode,a.Note,b.UnitOfRawID,c.FoodCategoryName from FoodDetail a inner join Catalog_Food b on a.Catalog_FoodCode=b.Catalog_FoodCode inner join FoodCategory c on b.FoodCategoryID=c.FoodCategoryID where a.FoodEntryID=@FoodEntryID order by a.FoodEntryID,a.FoodDetailID asc ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FoodEntryID", SqlDbType.Decimal);
                param[0].Value = dEntryID;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                //while (ireader.Read())
                //{
                //    FoodDetailINF inf = new FoodDetailINF();
                //    inf.FoodDetailID = ireader.GetDecimal(0);
                //    inf.FoodEntryID = ireader.GetDecimal(1);
                //    inf.Catalog_FoodCode = ireader.GetValue(2).ToString();
                //    inf.Price = ireader.GetDecimal(3);
                //    inf.Quantity = ireader.GetDecimal(4);
                //    inf.Amount = ireader.GetDecimal(5);
                //    inf.EmployeeCode = ireader.GetValue(6).ToString();
                //    inf.Note = ireader.GetValue(7).ToString();
                //    dt.Rows.Add(inf.FoodDetailID, inf.FoodEntryID, inf.Catalog_FoodCode, inf.Price, inf.Quantity, inf.Amount, inf.EmployeeCode, inf.Note, ireader.GetInt32(8), ireader.GetValue(9).ToString());
                //}
                //if (!ireader.IsClosed)
                //{
                //    ireader.Close();
                //    ireader.Dispose();
                //}
            }
            catch {  }
            return dt;
        }

        public static Int32 Ins(FoodDetailINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@FoodDetailID", SqlDbType.Decimal);
                param[0].Value = info.FoodDetailID;
                param[1] = new SqlParameter("@FoodEntryID", SqlDbType.Decimal);
                param[1].Value = info.FoodEntryID;
                param[2] = new SqlParameter("@Catalog_FoodCode", SqlDbType.VarChar, 6);
                param[2].Value = info.Catalog_FoodCode;
                param[3] = new SqlParameter("@Price", SqlDbType.Decimal);
                param[3].Value = info.Price;
                param[4] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[4].Value = info.Quantity;
                param[5] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[5].Value = info.Amount;
                param[6] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[6].Value = info.EmployeeCode;
                param[7] = new SqlParameter("@Note", SqlDbType.NVarChar, 250);
                param[7].Value = info.Note;
                param[8] = new SqlParameter("@iresult", SqlDbType.Int);
                param[8].Direction = ParameterDirection.Output;
                return Convert.ToInt32(cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_FoodDetail", param));
            }
            catch { return -1; }
        }

        public static Int32 Del(decimal dEntryID, decimal dDetailID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@FoodDetailID", SqlDbType.Decimal);
                param[1].Value = dDetailID;
                param[2] = new SqlParameter("@FoodEntryID", SqlDbType.Decimal);
                param[2].Value = dEntryID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_FoodDetail", param));
            }
            catch { return -1; }
        }

        public static List<FoodDetailPrintINF> ListFoodDetail(decimal dEntryID)
        {
            ConnectDB cn = new ConnectDB();
            List<FoodDetailPrintINF> list = new List<FoodDetailPrintINF>();
            try
            {
                string sql = "";
                sql = @" select a.Price,a.Quantity,a.Amount,a.Note,b.Content,b.WorkDate,a1.Catalog_FoodName,a2.FoodCategoryName,a3.UnitOfRawName,b.Price PriceEntry,b.Quantity QuantityEntry,b.Amount AmountEntry
                    from FoodDetail a inner join FoodEntry b on a.FoodEntryID=b.FoodEntryID 
                    inner join Catalog_Food a1 on a.Catalog_FoodCode=a1.Catalog_FoodCode
                    inner join FoodCategory a2 on a1.FoodCategoryID=a2.FoodCategoryID inner join UnitOfRaw a3 on a1.UnitOfRawID=a3.UnitOfRawID
                    where a.FoodEntryID={0}                    
                    order by b.WorkDate,a2.STT,a1.Catalog_FoodName
                     ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dEntryID), null);
                while (ireader.Read())
                {
                    FoodDetailPrintINF inf = new FoodDetailPrintINF();
                    inf.Price = ireader.GetDecimal(0);
                    inf.Quantity = ireader.GetDecimal(1);
                    inf.Amount = ireader.GetDecimal(2);
                    inf.Note = ireader.GetValue(3).ToString();
                    inf.Content = ireader.GetValue(4).ToString();
                    inf.WorkDate = ireader.GetDateTime(5);
                    inf.Catalog_FoodName = ireader.GetValue(6).ToString();
                    inf.FoodCategoryName = ireader.GetValue(7).ToString();
                    inf.UnitOfRawName = ireader.GetValue(8).ToString();
                    inf.PriceEntry = ireader.GetDecimal(9);
                    inf.QuantityEntry = ireader.GetInt32(10);
                    inf.AmountEntry = ireader.GetDecimal(11);
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

    }
}
