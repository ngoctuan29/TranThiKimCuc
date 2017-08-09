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
    public class FoodEntryDAL
    {
        public static List<FoodEntryINF> ListFoodEntry(decimal dEntryID)
        {
            ConnectDB cn = new ConnectDB();
            List<FoodEntryINF> list = new List<FoodEntryINF>();
            try
            {
                string sql = "";
                sql = @" select FoodEntryID, Content,EmployeeCode,Amount,WorkDate,Quantity,Price from  FoodEntry where FoodEntryID={0} order by WorkDate desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dEntryID), null);
                while (ireader.Read())
                {
                    FoodEntryINF inf = new FoodEntryINF();
                    inf.FoodEntryID = ireader.GetDecimal(0);
                    inf.Content = ireader.GetValue(1).ToString();
                    inf.EmployeeCode = ireader.GetValue(2).ToString();
                    inf.Amount = ireader.GetDecimal(3);
                    inf.WorkDate = ireader.GetDateTime(4);
                    inf.Quantity = ireader.GetInt32(5);
                    inf.Price = ireader.GetDecimal(6);
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

        public static List<FoodEntryINF> ListFoodEntry(DateTime dtfrm, DateTime dtto)
        {
            ConnectDB cn = new ConnectDB();
            List<FoodEntryINF> list = new List<FoodEntryINF>();
            try
            {
                string sql = "";
                sql = @" select FoodEntryID, Content,EmployeeCode,Amount,WorkDate,Quantity,Price
                    from  FoodEntry
                    where CONVERT(date,WorkDate,103) between CONVERT(date,@frmdate,103) and CONVERT(date,@todate,103) 
                    order by WorkDate desc ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frmdate", SqlDbType.Date);
                param[0].Value = dtfrm;
                param[1] = new SqlParameter("@todate", SqlDbType.Date);
                param[1].Value = dtto;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    FoodEntryINF inf = new FoodEntryINF();
                    inf.FoodEntryID = ireader.GetDecimal(0);
                    inf.Content = ireader.GetValue(1).ToString();
                    inf.EmployeeCode = ireader.GetValue(2).ToString();
                    inf.Amount = ireader.GetDecimal(3);
                    inf.WorkDate = ireader.GetDateTime(4);
                    inf.Quantity = ireader.GetInt32(5);
                    inf.Price = ireader.GetDecimal(6);
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

        public static Decimal Ins(FoodEntryINF info)
        {
            ConnectDB cn = new ConnectDB();
            decimal dResult = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@FoodEntryID", SqlDbType.Decimal);
                param[0].Value = info.FoodEntryID;
                param[1] = new SqlParameter("@Content", SqlDbType.NVarChar, 500);
                param[1].Value = info.Content;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.EmployeeCode;
                param[3] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[3].Value = info.Amount;
                param[4] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[4].Value = info.Quantity;
                param[5] = new SqlParameter("@Price", SqlDbType.Decimal);
                param[5].Value = info.Price;
                param[6] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[6].Value = info.WorkDate;
                param[7] = new SqlParameter("@iresult", SqlDbType.Decimal);
                param[7].Direction = ParameterDirection.Output;
                dResult = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_FoodEntry", param));
                return dResult;
            }
            catch { return -1; }
        }

    }
}
