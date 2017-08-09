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
    public class Warehousing_DAL
    {
        public static List<Warehousing_INF> List(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Warehousing_INF> list = new List<Warehousing_INF>();
            try
            {
                string sql = string.Empty;
                sql = @"select a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,a.InvoiceDate,a.ReportNumber,a.ReportDate,a.VendorCode,a.Discount,a.Shipper,a.Supplies,a.RepositoryCode,a.Reason,a.Note,a.EmployeeCode, a.Status,a.InventoryStaff,isnull(sum(Amount),0) AmountTotal,isnull(sum(Scot),0) ScotTotal,a.FormNo,a.VAT,a.Depreciated
                            from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode where a.WarehousingCode in('{0}') group by a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,a.InvoiceDate,a.ReportNumber,a.ReportDate,a.VendorCode,a.Discount,a.Shipper,a.Supplies,a.RepositoryCode,a.Reason,a.Note,a.EmployeeCode, a.Status,a.InventoryStaff,a.FormNo,a.VAT,a.Depreciated";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    Warehousing_INF inf = new Warehousing_INF();
                    inf.WarehousingCode = ireader.GetString(0);
                    if (ireader.GetValue(1) != null)
                        inf.ImportDate = ireader.GetDateTime(1);
                    inf.Seri = ireader.GetValue(2).ToString();
                    inf.InvoiceNnumber = ireader.GetValue(3).ToString();
                    if (ireader.GetValue(4) != null && ireader.GetValue(4).ToString() != "")
                        inf.InvoiceDate = ireader.GetString(4);
                    inf.ReportNumber = ireader.GetString(5);
                    if (ireader.GetValue(6) != null && ireader.GetValue(6).ToString() != "")
                        inf.ReportDate = ireader.GetValue(6).ToString();
                    inf.VendorCode = ireader.GetValue(7).ToString();
                    inf.Discount = ireader.GetInt32(8);
                    inf.Shipper = ireader.GetValue(9).ToString();
                    inf.Supplies = ireader.GetInt32(10);
                    inf.RepositoryCode = ireader.GetValue(11).ToString();
                    inf.Reason = ireader.GetInt32(12);
                    inf.Note = ireader.GetValue(13).ToString();
                    inf.EmployeeCode = ireader.GetString(14);
                    inf.Status = ireader.GetInt32(15);
                    inf.InventoryStaff = ireader.GetValue(16).ToString();
                    inf.AmountTotal = ireader.GetDecimal(17);
                    inf.ScotTotal = ireader.GetDecimal(18);
                    inf.FormNo = ireader.GetValue(19).ToString();
                    inf.VAT = ireader.GetInt32(20);
                    inf.Depreciated = ireader.GetDecimal(21);
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

        public static List<WarehousingSearch_INF> ListSearch(string sfrom, string sto, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<WarehousingSearch_INF> list = new List<WarehousingSearch_INF>();
            try
            {
                string sql = string.Empty;
                sql = @"  select a.WarehousingCode, a.ImportDate,a.Seri,a.InvoiceNnumber,c.VendorName,b.RepositoryName,a.Status,a.RepositoryCode,a.FormNo,a.VAT,SUM(a1.Amount) AmountNoVAT, SUM(a1.TotalTax) AmountVAT,a.Depreciated,e.EmployeeName
                            from Warehousing a inner join RepositoryCatalog b on a.RepositoryCode=b.RepositoryCode
                            inner join Vendor c on a.VendorCode=c.VendorCode inner join WarehousingDetail a1 on a.WarehousingCode=a1.WarehousingCode
							inner join Employee e on a.EmployeeCode = e.EmployeeCode
                            where convert(date,a.ImportDate,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and b.RepositoryCode in(select * from [dbo].fnSplitString((select PermissionRepository from Employee where EmployeeCode='{2}'),',')) group by a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,c.VendorName,b.RepositoryName,a.Status,a.RepositoryCode,a.FormNo,a.VAT,a.Depreciated,e.EmployeeName
                            order by a.WarehousingCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sfrom, sto, employeeCode), null);
                while (ireader.Read())
                {
                    WarehousingSearch_INF inf = new WarehousingSearch_INF();
                    inf.WarehousingCode = ireader.GetString(0);
                    if (ireader.GetValue(1) != null)
                        inf.ImportDate = ireader.GetDateTime(1);
                    inf.Seri = ireader.GetValue(2).ToString();
                    inf.InvoiceNnumber = ireader.GetValue(3).ToString();
                    inf.VendorName = ireader.GetValue(4).ToString();
                    inf.RepositoryName = ireader.GetValue(5).ToString();
                    inf.Status = ireader.GetInt32(6);
                    inf.RepositoryCode = ireader.GetValue(7).ToString();
                    inf.FormNo = ireader.GetValue(8).ToString();
                    inf.VAT = ireader.GetInt32(9);
                    inf.AmountNoVAT = Convert.ToDecimal(ireader.GetValue(10));
                    inf.AmountVAT = Convert.ToDecimal(ireader.GetValue(11));
                    inf.Depreciated = Convert.ToDecimal(ireader.GetValue(12));
                    inf.EmployeeName= ireader.GetValue(13).ToString();
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

        public static List<WarehousingSearch_INF> ListExportToRep(Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            List<WarehousingSearch_INF> list = new List<WarehousingSearch_INF>();
            try
            {
                string sql = "";
                sql = @" select a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,c.VendorName,b.RepositoryName,a.Status,a.RepositoryCode
                            from Warehousing a inner join RepositoryCatalog b on a.RepositoryCode=b.RepositoryCode
                            inner join Vendor c on a.VendorCode=c.VendorCode 
                            where a.Status in({0})
                            order by a.WarehousingCode asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus), null);
                while (ireader.Read())
                {
                    WarehousingSearch_INF inf = new WarehousingSearch_INF();
                    inf.WarehousingCode = ireader.GetString(0);
                    if (ireader.GetValue(1) != null)
                        inf.ImportDate = ireader.GetDateTime(1);
                    inf.Seri = ireader.GetValue(2).ToString();
                    inf.InvoiceNnumber = ireader.GetValue(3).ToString();
                    inf.VendorName = ireader.GetValue(4).ToString();
                    inf.RepositoryName = ireader.GetValue(5).ToString();
                    inf.Status = ireader.GetInt32(6);
                    inf.RepositoryCode = ireader.GetValue(7).ToString();
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
                dt.Columns.Add(new DataColumn("ExpWarehousingCode", typeof(string)));
                dt.Columns.Add(new DataColumn("AmountExist", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("GroupName", typeof(string)));
                string sql = string.Empty;
                if (sExpCode != string.Empty)
                {
                    sql = @"
                            select b.RowIDGumshoe RowID,b.ItemCode,c.ItemName,c.Active,d.UnitOfMeasureName,
                            b.DateEnd,b.Shipment,b.UnitPrice,b.SalesPrice,b.BHYTPrice,
                            b.AmountImport,b.AmountExport,b.WarehousingCode,
                            b.RepositoryExportCode,b.AmountRealExport as RealQuantity, 0 as chon,a.ExpWarehousingCode,(b.AmountImport-b.AmountExport) AmountExist,c1.ItemCategoryName,c2.GroupName
                            from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
                            inner join Items c on b.ItemCode=c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode inner join ItemCategory c1 on c.ItemCategoryCode=c1.ItemCategoryCode inner join ItemGroup c2 on c1.GroupCode=c2.GroupCode
                        where a.ExpWarehousingCode='" + sExpCode + "' and b.RepositoryExportCode='{0}'";
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

        public static DataTable DT_ListDetail(string warehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                dtResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("WarehousingCode", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Active", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Quantity", typeof(Decimal)));
                dtResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dtResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("Tax", typeof(int)));
                dtResult.Columns.Add(new DataColumn("Scot", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("TotalTax", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("Shipment", typeof(string)));
                dtResult.Columns.Add(new DataColumn("DateEnd", typeof(DateTime)));
                dtResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Check", typeof(Int32)));
                dtResult.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("UnitPriceNoVAT", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("PerSalesPrice", typeof(Int32)));
                dtResult.Columns.Add(new DataColumn("QtyOfMeasure", typeof(int)));
                dtResult.Columns.Add(new DataColumn("ItemContent", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Packed", typeof(string)));
                dtResult.Columns.Add(new DataColumn("QuantityInput", typeof(Decimal)));
                string sql = string.Empty;
                sql = @"select a.RowID,a.WarehousingCode,a.Active, a.Quantity,a.UnitOfMeasureCode,a.UnitPrice, a.Amount, a.Tax, a.Scot,a.TotalTax,a.SalesPrice,a.Shipment,a.DateEnd,a.ItemCode, 0 as [Check],a.BHYTPrice,a.UnitPriceNoVAT,a.PerSalesPrice,a.QtyOfMeasure,b.ItemContent,b.Packed,a.QuantityInput
                            from WarehousingDetail a inner join Items b on a.ItemCode=b.ItemCode where a.WarehousingCode in('{0}') order by a.RowID asc";
                dtResult = cn.ExecuteQuery(string.Format(sql, warehousingCode));
            }
            catch { }
            return dtResult;
        }

        public static List<WarehousingDetail_INF> ListDetail(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<WarehousingDetail_INF> list = new List<WarehousingDetail_INF>();
            try
            {
                string sql = "";
                sql = @"select RowID,WarehousingCode,ItemCode,Active,UnitOfMeasureCode, Quantity, UnitPrice, Amount, Tax, Scot,TotalTax,SalesPrice,Shipment,DateEnd
                            from WarehousingDetail where WarehousingCode in('{0}') order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    WarehousingDetail_INF inf = new WarehousingDetail_INF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.WarehousingCode = ireader.GetString(1);
                    inf.ItemCode = ireader.GetString(2);
                    inf.Active = ireader.GetValue(3).ToString();
                    inf.UnitOfMeasureCode = ireader.GetValue(4).ToString();
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(5));
                    inf.UnitPrice = ireader.GetDecimal(6);
                    inf.Amount = ireader.GetDecimal(7);
                    inf.Tax = ireader.GetInt32(8);
                    inf.Scot = ireader.GetDecimal(9);
                    inf.TotalTax = ireader.GetDecimal(10);
                    inf.SalesPrice = ireader.GetDecimal(11);
                    inf.Shipment = ireader.GetValue(12).ToString();
                    inf.DateEnd = ireader.GetDateTime(13);
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

        public static List<ViewWarehousingDetailInf> ListViewDetail(string warehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ViewWarehousingDetailInf> list = new List<ViewWarehousingDetailInf>();
            try
            {
                string sql = @"select a.RowID,a.WarehousingCode,a.ItemCode,a.Active,a.UnitOfMeasureCode, a.Quantity, a.UnitPrice, a.Amount, a.Tax, a.Scot,a.TotalTax,a.SalesPrice,a.Shipment,a.DateEnd,a1.ItemName,a2.UnitOfMeasureName,a.QuantityInput,a1.Packed
                            from WarehousingDetail a inner join Items a1 on a.ItemCode=a1.ItemCode inner join UnitOfMeasure a2 on a.UnitOfMeasureCode=a2.UnitOfMeasureCode where a.WarehousingCode in('{0}') order by a.RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, warehousingCode), null);
                while (ireader.Read())
                {
                    ViewWarehousingDetailInf inf = new ViewWarehousingDetailInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.WarehousingCode = ireader.GetString(1);
                    inf.ItemCode = ireader.GetString(2);
                    inf.Active = ireader.GetValue(3).ToString();
                    inf.UnitOfMeasureCode = ireader.GetValue(4).ToString();
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(5));
                    inf.UnitPrice = ireader.GetDecimal(6);
                    inf.Amount = ireader.GetDecimal(7);
                    inf.Tax = ireader.GetInt32(8);
                    inf.Scot = ireader.GetDecimal(9);
                    inf.TotalTax = ireader.GetDecimal(10);
                    inf.SalesPrice = ireader.GetDecimal(11);
                    inf.Shipment = ireader.GetValue(12).ToString();
                    inf.DateEnd = ireader.GetDateTime(13);
                    inf.v_ItemName = ireader.GetValue(14).ToString();
                    inf.v_UnitOfMeasureName = ireader.GetValue(15).ToString();
                    inf.QuantityInput = Convert.ToDecimal(ireader.GetValue(16));
                    inf.Packed = ireader.GetValue(17).ToString();
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

        public static Int32 Ins(Warehousing_INF info, ref string refCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[0].Value = info.WarehousingCode;
                param[1] = new SqlParameter("@ImportDate", SqlDbType.Date);
                param[1].Value = info.ImportDate;
                param[2] = new SqlParameter("@Seri", SqlDbType.VarChar, 50);
                param[2].Value = info.Seri;
                param[3] = new SqlParameter("@InvoiceNnumber", SqlDbType.NVarChar, 50);
                param[3].Value = info.InvoiceNnumber;
                param[4] = new SqlParameter("@InvoiceDate", SqlDbType.VarChar, 50);
                param[4].Value = info.InvoiceDate;
                param[5] = new SqlParameter("@ReportNumber", SqlDbType.VarChar, 50);
                param[5].Value = info.ReportNumber;
                param[6] = new SqlParameter("@ReportDate", SqlDbType.VarChar, 50);
                param[6].Value = info.ReportDate;
                param[7] = new SqlParameter("@VendorCode", SqlDbType.VarChar, 50);
                param[7].Value = info.VendorCode;
                param[8] = new SqlParameter("@Discount", SqlDbType.Int);
                param[8].Value = info.Discount;
                param[9] = new SqlParameter("@Shipper", SqlDbType.NVarChar, 250);
                param[9].Value = info.Shipper;
                param[10] = new SqlParameter("@Supplies", SqlDbType.Int);
                param[10].Value = info.Supplies;
                param[11] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[11].Value = info.RepositoryCode;
                param[12] = new SqlParameter("@Reason", SqlDbType.Int);
                param[12].Value = info.Reason;
                param[13] = new SqlParameter("@Note", SqlDbType.NVarChar, 205);
                param[13].Value = info.Note;
                param[14] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[14].Value = info.EmployeeCode;
                param[15] = new SqlParameter("@Status", SqlDbType.Int);
                param[15].Value = info.Status;
                param[16] = new SqlParameter("@InventoryStaff", SqlDbType.NVarChar, 150);
                param[16].Value = info.InventoryStaff;
                param[17] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[17].Value = info.ShiftWork;
                param[18] = new SqlParameter("@FormNo", SqlDbType.VarChar, 100);
                param[18].Value = info.FormNo;
                param[19] = new SqlParameter("@VAT", SqlDbType.Int);
                param[19].Value = info.VAT;
                param[20] = new SqlParameter("@Depreciated", SqlDbType.Decimal);
                param[20].Value = info.Depreciated;
                param[21] = new SqlParameter("@ResultWarehousingCode", SqlDbType.VarChar, 50);
                param[21].Direction = ParameterDirection.Output;
                refCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_Warehousing", param);
                if (refCode != string.Empty)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Upd_StatusWarehousing(Int32 iStatus, string sHousingCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "update Warehousing set Status=@Status where WarehousingCode=@WarehousingCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[0].Value = sHousingCode;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = iStatus;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 InsDetail(WarehousingDetail_INF info, ref decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@WarehousingCode", SqlDbType.NVarChar, 50);
                param[1].Value = info.WarehousingCode;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ItemCode;
                param[3] = new SqlParameter("@Active", SqlDbType.NVarChar);
                param[3].Value = info.Active;
                param[4] = new SqlParameter("@UnitOfMeasureCode", SqlDbType.VarChar, 50);
                param[4].Value = info.UnitOfMeasureCode;
                param[5] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[5].Value = info.Quantity;
                param[6] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[6].Value = info.UnitPrice;
                param[7] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[7].Value = info.Amount;
                param[8] = new SqlParameter("@Tax", SqlDbType.Int);
                param[8].Value = info.Tax;
                param[9] = new SqlParameter("@Scot", SqlDbType.Decimal);
                param[9].Value = info.Scot;
                param[10] = new SqlParameter("@TotalTax", SqlDbType.Decimal);
                param[10].Value = info.TotalTax;
                param[11] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[11].Value = info.SalesPrice;
                param[12] = new SqlParameter("@Shipment", SqlDbType.NVarChar, 250);
                param[12].Value = info.Shipment;
                param[13] = new SqlParameter("@DateEnd", SqlDbType.Date);
                param[13].Value = info.DateEnd;
                //param[14] = new SqlParameter("@ProducerCode", SqlDbType.VarChar, 50);
                //param[14].Value = info.ProducerCode;
                param[14] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[14].Value = info.BHYTPrice;
                param[15] = new SqlParameter("@UnitPriceNoVAT", SqlDbType.Decimal);
                param[15].Value = info.UnitPriceNoVAT;
                param[16] = new SqlParameter("@PerSalesPrice", SqlDbType.Int);
                param[16].Value = info.PerSalesPrice;
                param[17] = new SqlParameter("@QtyOfMeasure", SqlDbType.Decimal);
                param[17].Value = info.QtyOfMeasure;
                param[18] = new SqlParameter("@QuantityInput", SqlDbType.Decimal);
                param[18].Value = info.QuantityInput;
                param[19] = new SqlParameter("@RowIDOut", SqlDbType.Decimal);
                param[19].Direction = ParameterDirection.Output;
                string sResult = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_WarehousingDetail", param);
                if (Convert.ToDecimal(sResult) > 0)
                {
                    dRowID = Convert.ToDecimal(sResult);
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sHousingCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[1].Value = sHousingCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_WarehousingDetail", param);
            }
            catch { return -1; }
        }

        public static Int32 Del(string sHousingCode, string sItemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[1].Value = sHousingCode;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[2].Value = sItemCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_WarehousingDetailForItem", param);
            }
            catch { return -1; }
        }

        public static List<WarehousingSearch_INF> ListWaitingExport(Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            List<WarehousingSearch_INF> list = new List<WarehousingSearch_INF>();
            try
            {
                string sql = @" select a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,c.VendorName,b.RepositoryName,a.Status
                            from Warehousing a inner join RepositoryCatalog b on a.RepositoryCode=b.RepositoryCode
                            inner join Vendor c on a.VendorCode=c.VendorCode 
                            where a.Status in({0})
                            order by a.WarehousingCode asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus), null);
                while (ireader.Read())
                {
                    WarehousingSearch_INF inf = new WarehousingSearch_INF();
                    inf.WarehousingCode = ireader.GetString(0);
                    if (ireader.GetValue(1) != null)
                        inf.ImportDate = ireader.GetDateTime(1);
                    inf.Seri = ireader.GetValue(2).ToString();
                    inf.InvoiceNnumber = ireader.GetValue(3).ToString();
                    inf.VendorName = ireader.GetValue(4).ToString();
                    inf.RepositoryName = ireader.GetValue(5).ToString();
                    inf.Status = ireader.GetInt32(6);
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

        public static List<ViewWarehousingInf> ListViewWarehousing(string warehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ViewWarehousingInf> list = new List<ViewWarehousingInf>();
            try
            {
                string sql = @"select a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,a.InvoiceDate,a.ReportNumber,a.ReportDate,a.VendorCode,a.Discount,a.Shipper,a.Supplies,a.RepositoryCode,a.Reason,a.Note,a.EmployeeCode, a.Status,a.InventoryStaff,b.VendorName,a2.SuppliesName,a3.RepositoryName,a4.ReasonName,a5.EmployeeName,isnull(sum(a1.Amount),0) AmountTotal,isnull(sum(a1.Scot),0) ScotTotal
                            from Warehousing a inner join WarehousingDetail a1 on a.WarehousingCode=a1.WarehousingCode inner join Vendor b on a.VendorCode=b.VendorCode inner join MedicalSupplies a2 on a.Supplies=a2.RowID inner join RepositoryCatalog a3 on a.RepositoryCode=a3.RepositoryCode inner join MedicalReason a4 on a.Reason=a4.RowID inner join Employee a5 on a.EmployeeCode=a5.EmployeeCode 
                            where a.WarehousingCode in('{0}') group by a.WarehousingCode,a.ImportDate,a.Seri,a.InvoiceNnumber,a.InvoiceDate,a.ReportNumber,a.ReportDate,a.VendorCode,a.Discount,a.Shipper,a.Supplies,a.RepositoryCode,a.Reason,a.Note,a.EmployeeCode, a.Status,a.InventoryStaff,b.VendorName,a2.SuppliesName,a3.RepositoryName,a4.ReasonName,a5.EmployeeName";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, warehousingCode), null);
                while (ireader.Read())
                {
                    ViewWarehousingInf inf = new ViewWarehousingInf();
                    inf.WarehousingCode = ireader.GetString(0);
                    inf.ImportDate = ireader.GetDateTime(1);
                    inf.Seri = ireader.GetValue(2).ToString();
                    inf.InvoiceNnumber = ireader.GetValue(3).ToString();
                    inf.InvoiceDate = ireader.GetValue(4).ToString();
                    inf.ReportNumber = ireader.GetString(5);
                    inf.ReportDate = ireader.GetValue(6).ToString();
                    inf.VendorCode = ireader.GetValue(7).ToString();
                    inf.Discount = ireader.GetInt32(8);
                    inf.Shipper = ireader.GetValue(9).ToString();
                    inf.Supplies = ireader.GetInt32(10);
                    inf.RepositoryCode = ireader.GetValue(11).ToString();
                    inf.Reason = ireader.GetInt32(12);
                    inf.Note = ireader.GetValue(13).ToString();
                    inf.EmployeeCode = ireader.GetString(14);
                    inf.Status = ireader.GetInt32(15);
                    inf.InventoryStaff = ireader.GetValue(16).ToString();
                    inf.v_VendorName = ireader.GetValue(17).ToString();
                    inf.v_SuppliesName = ireader.GetValue(18).ToString();
                    inf.v_RepositoryName = ireader.GetValue(19).ToString();
                    inf.v_ReasonName = ireader.GetValue(20).ToString();
                    inf.v_EmployeeName = ireader.GetValue(21).ToString();
                    inf.AmountTotal = ireader.GetDecimal(22);
                    inf.ScotTotal = ireader.GetDecimal(23);
                    inf.ListWarehousingDetail = ListViewDetail(warehousingCode);
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
