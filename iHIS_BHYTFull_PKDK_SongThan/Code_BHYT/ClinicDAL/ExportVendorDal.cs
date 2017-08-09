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
    public class ExportVendorDal
    {
        public static Int32 Ins(ExportVendorInf info, ref string refCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@ExportVendorCode", SqlDbType.VarChar, 15);
                param[0].Value = info.ExportVendorCode;
                param[1] = new SqlParameter("@ExportDate", SqlDbType.Date);
                param[1].Value = info.ExportDate;
                param[2] = new SqlParameter("@ExpRepositoryCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ExpRepositoryCode;
                param[3] = new SqlParameter("@VendorCode", SqlDbType.VarChar, 50);
                param[3].Value = info.VendorCode;
                param[4] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[4].Value = info.Note;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[5].Value = info.EmployeeCode;
                param[6] = new SqlParameter("@Cancel", SqlDbType.Int);
                param[6].Value = info.Cancel;
                param[7] = new SqlParameter("@ResultCode", SqlDbType.VarChar, 50);
                param[7].Direction = ParameterDirection.Output;
                refCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_ExportVendor", param);
                if (refCode != string.Empty)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 InsDetail(ExportVendorDetailInf info, string sRepositoryExportCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[1] = new SqlParameter("@ExportVendorCode", SqlDbType.VarChar, 15);
                param[1].Value = info.ExportVendorCode;
                param[2] = new SqlParameter("@RowIDGumshoe", SqlDbType.Decimal);
                param[2].Value = info.RowIDGumshoe;
                param[3] = new SqlParameter("@AmountRealExport", SqlDbType.Decimal);
                param[3].Value = info.AmountRealExport;
                param[4] = new SqlParameter("@RepositoryExportCode", SqlDbType.VarChar, 50);
                param[4].Value = sRepositoryExportCode;
                param[5] = new SqlParameter("@iresult", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                Int32 iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_ExportVendorDetail", param));
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
            Int32 iresult = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ExportVendorCode", SqlDbType.VarChar, 15);
                param[1].Value = sExpCode;
                iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_ExportVendor", param));
                return iresult;
            }
            catch { return -1; }
        }

        public static Int32 Deltail(string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            Int32 iresult = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ExportVendorCode", SqlDbType.VarChar, 15);
                param[1].Value = sExpCode;
                iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_ExportVendorDetail", param));
                return iresult;
            }
            catch { return -1; }
        }

        public static List<ExportVendor_View> ListForDate(string sfrom, string sto)
        {
            ConnectDB cn = new ConnectDB();
            List<ExportVendor_View> list = new List<ExportVendor_View>();
            try
            {
                string sql = "";
                sql = @"	select a.ExportVendorCode,a.ExportDate,a.ExpRepositoryCode,b.RepositoryName ExpRepositoryName,a.VendorCode,c.VendorName,a.Note,a.EmployeeCode,a.Cancel,e.EmployeeName
                        from ExportVendor a inner join RepositoryCatalog b on a.ExpRepositoryCode=b.RepositoryCode inner join Vendor c on a.VendorCode=c.VendorCode
						inner join Employee e on a.EmployeeCode =e.EmployeeCode
                        where CONVERT(date,a.ExportDate,103) between CONVERT(date,'" + sfrom + "',103) and CONVERT(date,'" + sto + "',103) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ExportVendor_View inf = new ExportVendor_View();
                    inf.ExportVendorCode = ireader.GetString(0);
                    if (ireader.GetValue(1) != null)
                        inf.ExportDate = ireader.GetDateTime(1);
                    inf.ExpRepositoryCode = ireader.GetValue(2).ToString();
                    inf.ExpRepositoryName = ireader.GetValue(3).ToString();
                    inf.VendorCode = ireader.GetValue(4).ToString();
                    inf.VendorName = ireader.GetValue(5).ToString();
                    inf.Note = ireader.GetValue(6).ToString();
                    inf.EmployeeCode = ireader.GetString(7);
                    inf.Cancel = ireader.GetInt32(8);
                    inf.EmployeeName = ireader.GetValue(9).ToString();
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

        public static DataTable DT_ListDetailExport(string sRepositoryCode, string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("Active", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                dt.Columns.Add(new DataColumn("DateEnd", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Shipment", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("AmountImport", typeof(decimal)));
                dt.Columns.Add(new DataColumn("AmountExport", typeof(decimal)));
                dt.Columns.Add(new DataColumn("WarehousingCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RealQuantity", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ExportVendorCode", typeof(string)));
                dt.Columns.Add(new DataColumn("AmountExist", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("GroupName", typeof(string)));
                string sql = "";
                if (sExpCode != string.Empty)
                {
                    sql = @"
                    select b.RowIDGumshoe RowID,b.ItemCode,c.ItemName,c.Active,d.UnitOfMeasureName,
                    b.DateEnd,b.Shipment,b.UnitPrice,b.SalesPrice,b.BHYTPrice,
                    b.AmountImport,b.AmountExport,b1.WarehousingCode,
                    a.ExpRepositoryCode RepositoryExportCode,b.AmountRealExport as RealQuantity, 0 as chon,a.ExportVendorCode,(b.AmountImport-b.AmountRealExport) AmountExist,c1.ItemCategoryName,c2.GroupName
                    from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode 
                    inner join Items c on b.ItemCode=c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode 
                    inner join ItemCategory c1 on c.ItemCategoryCode=c1.ItemCategoryCode inner join ItemGroup c2 on c1.GroupCode=c2.GroupCode
                    inner join InventoryGumshoe b1 on b.RowIDGumshoe=b1.RowID
                where a.ExportVendorCode='" + sExpCode + "' and a.ExpRepositoryCode='{0}'";
                }
                else
                {
                    sql = @"select a.RowID,b.ItemCode,b.ItemName,b.Active,c.UnitOfMeasureName,a.DateEnd,a.Shipment,a.UnitPrice,a.SalesPrice,a.BHYTPrice,a.AmountImport,a.AmountExport,a.WarehousingCode,
                        a.RepositoryCode,0 as RealQuantity, 0 as chon,a.ExpWarehousingCode,(a.AmountImport-a.AmountExport) AmountExist,b1.ItemCategoryName,b2.GroupName
                        from InventoryGumshoe a inner join Items b on a.ItemCode=b.ItemCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode inner join ItemGroup b2 on b1.GroupCode=b2.GroupCode inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join Warehousing d on a.WarehousingCode=d.WarehousingCode
                        where a.RepositoryCode='{0}' and a.AmountImport>a.AmountExport and d.Status=1 ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRepositoryCode), null);
                while (ireader.Read())
                {
                    DataRow r = dt.NewRow();
                    r[0] = ireader.GetDecimal(0);
                    r[1] = ireader.GetString(1);
                    r[2] = ireader.GetValue(2).ToString();
                    r[3] = ireader.GetValue(3).ToString();
                    r[4] = ireader.GetValue(4).ToString();
                    r[5] = ireader.GetDateTime(5);
                    r[6] = ireader.GetValue(6).ToString();
                    r[7] = ireader.GetDecimal(7);
                    r[8] = ireader.GetDecimal(8);
                    r[9] = ireader.GetDecimal(9);
                    r[10] = ireader.GetDecimal(10);
                    r[11] = ireader.GetDecimal(11);
                    r[12] = ireader.GetValue(12).ToString();
                    r[13] = ireader.GetValue(13).ToString();
                    r[14] = Convert.ToDecimal(ireader.GetValue(14).ToString());
                    r[15] = ireader.GetInt32(15);
                    r[16] = ireader.GetValue(16).ToString();
                    r[17] = ireader.GetDecimal(17);
                    r[18] = ireader.GetValue(18).ToString();
                    r[19] = ireader.GetValue(19).ToString();
                    dt.Rows.Add(r);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable rpt_PrintExportVendor(string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                sql = @" select a.ExportVendorCode,convert(char(10),a.ExportDate,103) ExportDate,a1.RepositoryName RepositoryNameOut,a2.VendorName,a.Note,b.EmployeeName
                        from ExportVendor a inner join RepositoryCatalog a1 on a.ExpRepositoryCode=a1.RepositoryCode
                        inner join Vendor a2 on a.VendorCode=a2.VendorCode inner join Employee b on a.EmployeeCode=b.EmployeeCode  
                        where a.ExportVendorCode='{0}'";
                dt = cn.ExecuteQuery(string.Format(sql, sExpCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable rpt_PrintExportVendorDetail(string sExpCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                sql = @"  select a.ExportVendorCode,a.ItemCode,a1.ItemName,a.AmountImport,SUBSTRING(CONVERT(varchar(10),a.DateEnd,103),4,7) DateEnd,a.SalesPrice,a.UnitPrice,a.Shipment,a.BHYTPrice,a.IDate WorkDate,a.AmountRealExport,
                            a2.UnitOfMeasureName,(a.UnitPrice*a.AmountRealExport) TotalAmount 
                        from ExportVendorDetail a inner join Items a1 on a.ItemCode=a1.ItemCode 
                        inner join UnitOfMeasure a2 on a1.UnitOfMeasureCode=a2.UnitOfMeasureCode
                        where a.ExportVendorCode='{0}'";
                dt = cn.ExecuteQuery(string.Format(sql, sExpCode));
            }
            catch { dt = null; }
            return dt;
        }

    }
}
