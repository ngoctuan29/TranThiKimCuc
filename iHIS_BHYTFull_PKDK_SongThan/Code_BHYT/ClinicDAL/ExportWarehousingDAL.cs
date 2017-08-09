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
    public class ExportWarehousingDAL
    {
        public static List<ExportWarehousing_View> ListForDate(string sfrom, string sto, Int32 iType, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ExportWarehousing_View> list = new List<ExportWarehousing_View>();
            try
            {
                string sql = string.Empty;
                sql = @"select a.ExpWarehousingCode,a.ExportDate,a.ExpRepositoryCode,b.RepositoryName ExpRepositoryName,a.ImpRepositoryCode,c.RepositoryName ImpRepositoryName,a.Note,a.EmployeeCode,e.EmployeeName, a.EmployeeNameReceive
                        from ExportWarehousing a inner join RepositoryCatalog b on a.ExpRepositoryCode=b.RepositoryCode 
						inner join Employee e on a.EmployeeCode = e.EmployeeCode
                        inner join RepositoryCatalog c on a.ImpRepositoryCode=c.RepositoryCode and b.RepositoryCode in(select * from [dbo].fnSplitString((select PermissionRepository from Employee where EmployeeCode='{1}'),','))
                        where CONVERT(date,a.ExportDate,103) between CONVERT(date,'" + sfrom + "',103) and CONVERT(date,'" + sto + "',103) and a.Type in({0})";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iType, employeeCode), null);
                while (ireader.Read())
                {
                    ExportWarehousing_View inf = new ExportWarehousing_View();
                    inf.ExpWarehousingCode = ireader.GetString(0);
                    if (ireader.GetValue(1) != null)
                        inf.ExportDate = ireader.GetDateTime(1);
                    inf.ExpRepositoryCode = ireader.GetValue(2).ToString();
                    inf.ExpRepositoryName = ireader.GetValue(3).ToString();
                    inf.ImpRepositoryCode = ireader.GetValue(4).ToString();
                    inf.ImpRepositoryName = ireader.GetValue(5).ToString();
                    inf.Note = ireader.GetValue(6).ToString();
                    inf.EmployeeCode = ireader.GetString(7);
                    inf.EmployeeName = ireader.GetString(8);
                    inf.EmployeeNameReceive = ireader.GetValue(9).ToString();
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

        public static Int32 Ins(ExportWarehousingInf info, ref string refCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@ExpWarehousingCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ExpWarehousingCode;
                param[1] = new SqlParameter("@ExportDate", SqlDbType.Date);
                param[1].Value = info.ExportDate;
                param[2] = new SqlParameter("@ExpRepositoryCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ExpRepositoryCode;
                param[3] = new SqlParameter("@ImpRepositoryCode", SqlDbType.VarChar, 50);
                param[3].Value = info.ImpRepositoryCode;
                param[4] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[4].Value = info.Note;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[5].Value = info.EmployeeCode;
                param[6] = new SqlParameter("@Type", SqlDbType.Int);
                param[6].Value = info.Type;
                param[7] = new SqlParameter("@EmployeeNameReceive", SqlDbType.NVarChar);
                param[7].Value = info.EmployeeNameReceive;
                param[8] = new SqlParameter("@ResultCode", SqlDbType.VarChar, 50);
                param[8].Direction = ParameterDirection.Output;
                refCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_ExportWarehousing", param);
                if (refCode != string.Empty)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch(Exception) { return -2; }
        }

        public static Int32 InsDetail(ExportWarehousingDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RowIDGumshoe", SqlDbType.Decimal);
                param[0].Value = info.RowIDGumshoe;
                param[1] = new SqlParameter("@RepositoryReceiveCode", SqlDbType.VarChar, 50);
                param[1].Value = info.RepositoryReceiveCode;
                param[2] = new SqlParameter("@RepositoryExportCode", SqlDbType.VarChar, 50);
                param[2].Value = info.RepositoryExportCode;
                param[3] = new SqlParameter("@AmountRealExport", SqlDbType.Decimal);
                param[3].Value = info.AmountRealExport;
                param[4] = new SqlParameter("@ExpWarehousingCode", SqlDbType.VarChar,50);
                param[4].Value = info.ExpWarehousingCode;
                Int32 iResult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ExportWarehousingDetail", param);
                if (iResult > 0)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            Int32 iresult = -1;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ExpWarehousingCode", SqlDbType.VarChar, 50);
                param[1].Value = sExpCode;
                iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_ExportWarehousing", param));
                return iresult;
            }
            catch { return -1; }
        }

        public static DataTable rpt_PrintWarehousingExport(string expCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select a.ExpWarehousingCode,convert(char(10),a.ExportDate,103) ExportDate,a1.RepositoryName RepositoryNameOut,a2.RepositoryName RepositoryNameIn,a.Note,b.EmployeeName, ISNULL(SUM(a3.AmountRealExport*a3.UnitPrice),0) AmountTotal,a.EmployeeNameReceive 
                        from ExportWarehousing a inner join RepositoryCatalog a1 on a.ExpRepositoryCode=a1.RepositoryCode inner join RepositoryCatalog a2 on a.ImpRepositoryCode=a2.RepositoryCode inner join Employee b on a.EmployeeCode=b.EmployeeCode inner join ExportWarehousingDetail a3 on a.ExpWarehousingCode=a3.ExpWarehousingCode
                        where a.ExpWarehousingCode='{0}' group by a.ExpWarehousingCode,convert(char(10),a.ExportDate,103),a1.RepositoryName,a2.RepositoryName,a.Note,b.EmployeeName,a.EmployeeNameReceive ";
                dt = cn.ExecuteQuery(string.Format(sql, expCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable rpt_PrintWarehousingExportDetail(string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                sql = @"  select a.ExpWarehousingCode,a.ItemCode,a1.ItemName,a.AmountImport,SUBSTRING(CONVERT(varchar(10),a.DateEnd,103),4,7) DateEnd,a.SalesPrice,a.UnitPrice,a.Shipment,a.BHYTPrice,a.IDate WorkDate,a.AmountRealExport,
                            a2.UnitOfMeasureName,(a.UnitPrice*a.AmountRealExport) TotalAmount 
                        from ExportWarehousingDetail a inner join Items a1 on a.ItemCode=a1.ItemCode inner join UnitOfMeasure a2 on a1.UnitOfMeasureCode=a2.UnitOfMeasureCode
                        where a.ExpWarehousingCode='{0}'";
                dt = cn.ExecuteQuery(string.Format(sql, sExpCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 CheckEdit(string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            Int32 iresult = -1;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ExpWarehousingCode", SqlDbType.VarChar, 50);
                param[1].Value = sExpCode;
                iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_check_ExportWarehousing", param));
                return iresult;
            }
            catch { return -1; }
        }

    }
}
