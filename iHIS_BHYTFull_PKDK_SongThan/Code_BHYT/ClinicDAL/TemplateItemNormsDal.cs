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
    public class TemplateItemNormsDal
    {
        public static List<TemplateItemNormsInf> ListItemNorms(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<TemplateItemNormsInf> list = new List<TemplateItemNormsInf>();
            try
            {
                string sql = "";
                if (sCode != "")
                {
                    sql = " select NormsCode,ServiceCode,EmployeeCode,EmployeeCodeUpd  from TemplateItemNorms where NormsCode in('{0}') order by NormsCode asc ";
                }
                else
                {
                    sql = " select NormsCode,ServiceCode,EmployeeCode,EmployeeCodeUpd from TemplateItemNorms order by NormsCode asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    TemplateItemNormsInf inf = new TemplateItemNormsInf();
                    inf.NormsCode = ireader.GetString(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.EmployeeCode = ireader.GetValue(2).ToString();
                    inf.EmployeeCodeUpd = ireader.GetValue(3).ToString();
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

        public static Int32 Ins(TemplateItemNormsInf info, ref string refsCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@NormsCode", SqlDbType.VarChar, 15);
                param[0].Value = info.NormsCode;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.EmployeeCode;
                param[3] = new SqlParameter("@EmployeeCodeUpd", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCodeUpd;
                param[4] = new SqlParameter("@ResultCode", SqlDbType.VarChar, 15);
                param[4].Direction = ParameterDirection.Output;
                refsCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_TemplateItemNorms", param);
                if (refsCode != string.Empty)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = sCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                Int32 iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prDel_TemplateItemNorms", param));
                return iresult;
            }
            catch
            {
                return -1;
            }
        }

        public static DataTable dtItemNormsDetail(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("RowID", typeof(decimal));
            dtResult.Columns.Add("NormsCode", typeof(string));
            dtResult.Columns.Add("ItemCode", typeof(string));
            dtResult.Columns.Add("Quantity", typeof(decimal));
            dtResult.Columns.Add("UnitPrice", typeof(decimal));
            dtResult.Columns.Add("SalesPrice", typeof(decimal));
            dtResult.Columns.Add("BHYTPrice", typeof(decimal));
            dtResult.Columns.Add("Instruction", typeof(string));
            dtResult.Columns.Add("UnitOfMeasureCode", typeof(string));
            try
            {
                string sql = "";
                sql = " select a.RowID,a.NormsCode,a.ItemCode,a.Quantity,a.UnitPrice,a.SalesPrice,a.BHYTPrice,a.Instruction,b.UnitOfMeasureCode  from TemplateItemNormsDetail a inner join Items b on a.ItemCode=b.ItemCode inner join TemplateItemNorms a1 on a.NormsCode=a1.NormsCode where a1.ServiceCode=@ServiceCode order by a.ItemCode asc ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[0].Value = sCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = ireader.GetDecimal(0);
                    dr[1] = ireader.GetValue(1).ToString();
                    dr[2] = ireader.GetValue(2).ToString();
                    dr[3] = ireader.GetDecimal(3).ToString();
                    dr[4] = ireader.GetDecimal(4).ToString();
                    dr[5] = ireader.GetDecimal(5).ToString();
                    dr[6] = ireader.GetDecimal(6).ToString();
                    dr[7] = ireader.GetValue(7).ToString();
                    dr[8] = ireader.GetValue(8).ToString();
                    dtResult.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch {  }
            return dtResult;
        }

        public static Int32 InsDetail(TemplateItemNormsDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@NormsCode", SqlDbType.VarChar, 15);
                param[1].Value = info.NormsCode;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ItemCode;
                param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[3].Value = info.Quantity;
                param[4] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[4].Value = info.UnitPrice;
                param[5] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[5].Value = info.SalesPrice;
                param[6] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[6].Value = info.BHYTPrice;
                param[7] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 250);
                param[7].Value = info.Instruction;
                Int32 iresult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_TemplateItemNormsDetail", param);
                return iresult;
            }
            catch { return -2; }
        }

        public static Int32 DelDetail(string sCode, decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = dRowID;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = sCode;
                param[2] = new SqlParameter("@iresult", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                Int32 iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prDel_TemplateItemNormsDetail", param));
                return iresult;
            }
            catch
            {
                return -1;
            }
        }

    }
}
