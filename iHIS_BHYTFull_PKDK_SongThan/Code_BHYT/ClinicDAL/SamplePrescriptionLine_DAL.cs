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
    public class SamplePrescriptionLine_DAL
    {
        public static List<SamplePrescriptionLine_INF> ListForHederCode(string ref_HCode)
        {
            ConnectDB cn = new ConnectDB();
            List<SamplePrescriptionLine_INF> list = new List<SamplePrescriptionLine_INF>();
            try
            {
                string sql = " select a.RowID,a.SamplePrescriptionCode,a.ItemCode,a.UnitOfMeasure,a.DateOfIssues, a.Morning,a.Noon,a.Afternoon,a.Evening,a.Quantity,a.Instruction, a.UnitOfMeasureCode_Medi,b.Converted_Medi from SamplePrescriptionLine a inner join Items b on a.ItemCode=b.ItemCode where a.SamplePrescriptionCode='{0}' order by a.SamplePrescriptionCode desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, ref_HCode), null);
                while (ireader.Read())
                {
                    SamplePrescriptionLine_INF inf = new SamplePrescriptionLine_INF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.SamplePrescriptionCode = ireader.GetValue(1).ToString();
                    inf.ItemCode = ireader.GetValue(2).ToString();
                    inf.UnitOfMeasure = ireader.GetValue(3).ToString();
                    inf.DateOfIssues = ireader.GetInt32(4);
                    inf.Morning = float.Parse(ireader.GetValue(5).ToString());
                    inf.Noon = float.Parse(ireader.GetValue(6).ToString());
                    inf.Afternoon = float.Parse(ireader.GetValue(7).ToString());
                    inf.Evening = float.Parse(ireader.GetValue(8).ToString());
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(9).ToString());
                    inf.Instruction = ireader.GetValue(10).ToString();
                    inf.UnitOfMeasureCode_Medi = ireader.GetValue(11).ToString();
                    inf.Converted_Medi = ireader.GetBoolean(12);
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
        public static List<SamplePrescriptionLine_INF> ListForHederCode_Price(string ref_HCode)
        {
            ConnectDB cn = new ConnectDB();
            List<SamplePrescriptionLine_INF> list = new List<SamplePrescriptionLine_INF>();
            try
            {
                string sql = string.Empty;
                sql = " select a.RowID,a.SamplePrescriptionCode,a.ItemCode,a.UnitOfMeasure,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a.Quantity,a.Instruction,b.UnitPrice,b.BHYTPrice,b.SalesPrice,b.UsageCode,b.RateBHYT,b.ListBHYT,b.ListService,a.UnitOfMeasureCode_Medi,b.Converted_Medi from SamplePrescriptionLine a inner join Items b on a.ItemCode=b.ItemCode where a.SamplePrescriptionCode='{0}' order by a.SamplePrescriptionCode desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, ref_HCode), null);
                while (ireader.Read())
                {
                    SamplePrescriptionLine_INF inf = new SamplePrescriptionLine_INF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.SamplePrescriptionCode = ireader.GetValue(1).ToString();
                    inf.ItemCode = ireader.GetValue(2).ToString();
                    inf.UnitOfMeasure = ireader.GetValue(3).ToString();
                    inf.DateOfIssues = ireader.GetInt32(4);
                    inf.Morning = float.Parse(ireader.GetValue(5).ToString());
                    inf.Noon = float.Parse(ireader.GetValue(6).ToString());
                    inf.Afternoon = float.Parse(ireader.GetValue(7).ToString());
                    inf.Evening = float.Parse(ireader.GetValue(8).ToString());
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(9).ToString());
                    inf.Instruction = ireader.GetValue(10).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(11).ToString());
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(12).ToString());
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(13).ToString());
                    inf.UsageCode = ireader.GetValue(14).ToString();
                    inf.RateBHYT = Convert.ToInt32(ireader.GetValue(15).ToString());
                    inf.ListBHYT = Convert.ToInt32(ireader.GetValue(16).ToString());
                    inf.ListService = Convert.ToInt32(ireader.GetValue(17).ToString());
                    inf.UnitOfMeasureCode_Medi = ireader.GetValue(18).ToString();
                    inf.Converted_Medi = ireader.GetBoolean(19);
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
        public static Int32 Ins(SamplePrescriptionLine_INF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@SamplePrescriptionCode", SqlDbType.VarChar, 50);
                param[0].Value = info.SamplePrescriptionCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ItemCode;
                param[2] = new SqlParameter("@UnitOfMeasure", SqlDbType.VarChar, 50);
                param[2].Value = info.UnitOfMeasure;
                param[3] = new SqlParameter("@DateOfIssues", SqlDbType.Int);
                param[3].Value = info.DateOfIssues;
                param[4] = new SqlParameter("@Morning", SqlDbType.Float);
                param[4].Value = info.Morning;
                param[5] = new SqlParameter("@Noon", SqlDbType.Float);
                param[5].Value = info.Noon;
                param[6] = new SqlParameter("@Afternoon", SqlDbType.Float);
                param[6].Value = info.Afternoon;
                param[7] = new SqlParameter("@Evening", SqlDbType.Float);
                param[7].Value = info.Evening;
                param[8] = new SqlParameter("@Quantity", SqlDbType.Float);
                param[8].Value = info.Quantity;
                param[9] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 500);
                param[9].Value = info.Instruction;
                param[10] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[10].Value = info.RowID;
                param[11] = new SqlParameter("@UnitOfMeasureCode_Medi", SqlDbType.VarChar);
                param[11].Value = info.UnitOfMeasureCode_Medi;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_SampleLine", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch{ return -2; }
        }

        public static Int32 Del(decimal dRowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_SampleLine", param);
            }
            catch { return -1; }
        }
        public static Int32 Del(string samplePrescriptionCode, string itemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from SamplePrescriptionLine where SamplePrescriptionCode=@SamplePrescriptionCode and ItemCode=@ItemCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SamplePrescriptionCode", SqlDbType.VarChar);
                param[0].Value = samplePrescriptionCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[1].Value = itemCode;
                return cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch { return -1; }
        }
    }
}
