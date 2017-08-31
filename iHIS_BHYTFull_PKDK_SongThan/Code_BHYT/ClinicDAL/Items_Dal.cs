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
    public class Items_Dal
    {
        public static List<Items_Ref> ListItemsRef(int iStatus, string repositoryCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_Ref> list = new List<Items_Ref>();
            try
            {
                string sql = string.Empty;
                sql = @" Select a.ItemCode,a.ItemName,a.ItemContent,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,d.UsageName,a.DisparityPrice,a.ListService,a.ListBHYT,a.Packed,a.QtyOfMeasure
                        from Items a inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode inner join Usage d on a.UsageCode=d.UsageCode
                        where a.Status in({0}) and a.RepositoryCode like'%{1}%' order by a.ItemName asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, repositoryCode), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.ItemContent = ireader.GetValue(2).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(3).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(4).ToString());
                    inf.ItemCategoryName = ireader.GetString(5);
                    inf.SafelyQuantity = ireader.GetInt32(6);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(7).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(8).ToString();
                    inf.Active = ireader.GetValue(9).ToString();
                    inf.UsageCode = ireader.GetValue(10).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(11).ToString());
                    inf.AmountVirtual = 0;
                    inf.UsageName = ireader.GetValue(12).ToString();
                    inf.DisparityPrice = ireader.GetDecimal(13);
                    inf.ListService = ireader.GetInt32(14);
                    inf.ListBHYT = ireader.GetInt32(15);
                    inf.Packed = ireader.GetValue(16).ToString();
                    inf.QtyOfMeasure = ireader.GetInt32(17);
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


        public static DataTable ListItemslist(string sitemcode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            dt.Columns.Add("ServiceCode", typeof(string));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("Check", typeof(int));
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("ObjectCode", typeof(int));
            dt.Columns.Add("Soluong",typeof(int));

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[0].Value = sitemcode;
                var irender = cn.ExecuteReader(CommandType.StoredProcedure, "proList_Items", param);
                while(irender.Read())
                {
                    DataRow r = dt.NewRow();
                    r.BeginEdit();
                    r[0] = irender.GetValue(0).ToString();
                    r[1]= irender.GetValue(1).ToString();
                    r[2] = 0;
                    r[3]= irender.GetValue(2).ToString();
                    r[4] = Convert.ToInt32(irender.GetValue(3).ToString());
                    r[5] = Convert.ToInt32(irender.GetValue(4).ToString());
                    r.EndEdit();
                    dt.Rows.Add(r);
                }
                return dt;
            }
            catch { return null; }

        }


        public static DataTable ListItemslistAuto(string sitemcode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dc = new DataTable();
            dc.Columns.Add("ServiceCode", typeof(string));
            dc.Columns.Add("ServiceName", typeof(string));
            dc.Columns.Add("Check", typeof(int));
            dc.Columns.Add("ItemCode", typeof(string));
            dc.Columns.Add("ObjectCode", typeof(int));
            dc.Columns.Add("Soluong", typeof(int));
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[0].Value = sitemcode;
                var irender = cn.ExecuteReader(CommandType.StoredProcedure, "proList_Items_Auto", param);
                while (irender.Read())
                {
                    DataRow r = dc.NewRow();
                    r.BeginEdit();
                    r[0] = irender.GetValue(0).ToString();
                    r[1] = irender.GetValue(1).ToString();
                    r[2] = 0;
                    r[3] = irender.GetValue(2).ToString();
                    r[4] = Convert.ToInt32(irender.GetValue(3).ToString());
                    r[5] = Convert.ToInt32(irender.GetValue(4).ToString());
                    r.EndEdit();
                    dc.Rows.Add(r);
                }
                return dc;
            }
            catch  { return null; }

        }


        public static List<Items_Ref> ListItemsRef(int iStatus, string sDepartCode, Int32 iGroup)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_Ref> list = new List<Items_Ref>();
            try
            {
                string sql = string.Empty;
                sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0})  
                        and d.RepositoryCode in(select RepositoryCode from DepartmentForRepository where DepartmentCode in('{1}'))
                        and f.RepositoryGroupCode in({2})
                        order by a.ItemName asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, sDepartCode, iGroup), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = ireader.GetDecimal(11);
                    inf.RepositoryCode = ireader.GetValue(12).ToString();
                    inf.RepositoryName = ireader.GetValue(13).ToString();
                    inf.AmountEnd = ireader.GetDecimal(14);
                    inf.RateBHYT = ireader.GetDecimal(15);
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
        public static DataTable Table_ListItemsRef(int iStatus, string sDepartCode, string group, Int32 objectCode, bool isUnitPrice_Menu)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("SafelyQuantity", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("Active", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AmountVirtual", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AmountEnd", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("Note", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ListBHYT", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("SODKGP", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
            dtResult.Columns.Add(new DataColumn("Converted_Medi", typeof(bool)));
            dtResult.Columns.Add(new DataColumn("ListService", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("Is_Acttach_Service", typeof(int)));
            dtResult.Columns.Add(new DataColumn("Is_Service_Auto", typeof(int)));
            try
            {
                string sql = string.Empty;
                if (isUnitPrice_Menu)
                {
                    sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT,a.Note,a.ListBHYT,e.RepositoryGroupCode,a.SODKGP,a.UnitOfMeasureCode_Medi,a.Converted_Medi,a.ListService,a.Is_Acttach_Service,a.Is_Service_Auto
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0}) and d.RepositoryCode in(select RepositoryCode from DepartmentForRepository where DepartmentCode in('{1}')) and f.RepositoryGroupCode in({2})";
                } 
                else
                {
                    sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,d1.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,d1.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, d1.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT,a.Note,a.ListBHYT,e.RepositoryGroupCode,a.SODKGP,a.UnitOfMeasureCode_Medi,a.Converted_Medi,a.ListService,a.Is_Acttach_Service,a.Is_Service_Auto
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode inner join InventoryGumshoe d1 on d.ItemCode=d1.ItemCode and d.RepositoryCode=d1.RepositoryCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0}) and d.RepositoryCode in(select RepositoryCode from DepartmentForRepository where DepartmentCode in('{1}')) and f.RepositoryGroupCode in({2})";
                }
                sql += " order by d.RepositoryCode,d.ItemCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, sDepartCode, group), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = ireader.GetDecimal(11);
                    inf.RepositoryCode = ireader.GetValue(12).ToString();
                    inf.RepositoryName = ireader.GetValue(13).ToString();
                    inf.AmountEnd = ireader.GetDecimal(14);
                    inf.RateBHYT = ireader.GetDecimal(15);
                    inf.Note = ireader.GetValue(16).ToString();
                    inf.ListBHYT = ireader.GetInt32(17);
                    //if ((Convert.ToInt32(ireader.GetValue(18).ToString()) == 2 || Convert.ToInt32(ireader.GetValue(18).ToString()) == 3) && ireader.GetInt32(17) == 1)
                    //    inf.ListBHYT = 1;
                    //else
                    //    inf.ListBHYT = 0;
                    inf.RepositoryGroupCode = Convert.ToInt32(ireader.GetValue(18).ToString());
                    inf.SODKGP = ireader.GetValue(19).ToString();
                    inf.UnitOfMeasureCode_Medi = ireader.GetValue(20).ToString();
                    inf.Converted_Medi = ireader.GetBoolean(21);
                    inf.ListService = ireader.GetInt32(22);
                    if (ireader.GetValue(23).ToString() != null && ireader.GetValue(23).ToString() != "")
                    {
                        inf.Is_Acttach_Service = ireader.GetInt32(23);
                    }
                    else
                    {
                        inf.Is_Acttach_Service = 0;
                    }
                    if (ireader.GetValue(24).ToString() != null && ireader.GetValue(24).ToString() != "")
                    {
                        inf.Is_Service_Auto = ireader.GetInt32(24);
                    }
                    else
                    {
                        inf.Is_Service_Auto = 0;
                    }
                    
                    
                    dtResult.Rows.Add(inf.ItemCode, inf.ItemName, inf.UnitOfMeasureName, inf.UnitOfMeasureCode, inf.ItemCategoryName, inf.UsageCode, inf.UnitPrice, inf.SalesPrice, inf.SafelyQuantity, inf.BHYTPrice, inf.Active, inf.AmountVirtual, inf.RepositoryCode, inf.RepositoryName, inf.AmountEnd, inf.RateBHYT, inf.Note, inf.ListBHYT, inf.RepositoryGroupCode, inf.SODKGP, inf.UnitOfMeasureCode_Medi, inf.Converted_Medi, inf.ListService,inf.Is_Acttach_Service,inf.Is_Service_Auto);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch(Exception) {  }
            return dtResult;
        }
        public static DataTable Table_ListItemsRef(int iStatus, string group, Int32 objectCode, bool isUnitPrice_Menu)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("SafelyQuantity", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("Active", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AmountVirtual", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
            dtResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
            dtResult.Columns.Add(new DataColumn("AmountEnd", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
            dtResult.Columns.Add(new DataColumn("Note", typeof(string)));
            dtResult.Columns.Add(new DataColumn("ListBHYT", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
            dtResult.Columns.Add(new DataColumn("SODKGP", typeof(string)));
            dtResult.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
            dtResult.Columns.Add(new DataColumn("Converted_Medi", typeof(bool)));
            dtResult.Columns.Add(new DataColumn("ListService", typeof(Int32)));
            try
            {
                string sql = string.Empty;
                if (isUnitPrice_Menu)
                {
                    sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT,a.Note,a.ListBHYT,e.RepositoryGroupCode,a.SODKGP,a.UnitOfMeasureCode_Medi,a.Converted_Medi,a.ListService
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0}) and f.RepositoryGroupCode in({1})";
                }
                else
                {
                    sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,d1.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,d1.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, d1.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT,a.Note,a.ListBHYT,e.RepositoryGroupCode,a.SODKGP,a.UnitOfMeasureCode_Medi,a.Converted_Medi,a.ListService
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode inner join InventoryGumshoe d1 on d.ItemCode=d1.ItemCode and d.RepositoryCode=d1.RepositoryCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0}) and f.RepositoryGroupCode in({1})";
                }
                sql += " order by d.RepositoryCode,d.ItemCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, group), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = ireader.GetDecimal(11);
                    inf.RepositoryCode = ireader.GetValue(12).ToString();
                    inf.RepositoryName = ireader.GetValue(13).ToString();
                    inf.AmountEnd = ireader.GetDecimal(14);
                    inf.RateBHYT = ireader.GetDecimal(15);
                    inf.Note = ireader.GetValue(16).ToString();
                    inf.ListBHYT = ireader.GetInt32(17);
                    //if ((Convert.ToInt32(ireader.GetValue(18).ToString()) == 2 || Convert.ToInt32(ireader.GetValue(18).ToString()) == 3) && ireader.GetInt32(17) == 1)
                    //    inf.ListBHYT = 1;
                    //else
                    //    inf.ListBHYT = 0;
                    inf.RepositoryGroupCode = Convert.ToInt32(ireader.GetValue(18).ToString());
                    inf.SODKGP = ireader.GetValue(19).ToString();
                    inf.UnitOfMeasureCode_Medi = ireader.GetValue(20).ToString();
                    inf.Converted_Medi = ireader.GetBoolean(21);
                    inf.ListService = ireader.GetInt32(22);
                    dtResult.Rows.Add(inf.ItemCode, inf.ItemName, inf.UnitOfMeasureName, inf.UnitOfMeasureCode, inf.ItemCategoryName, inf.UsageCode, inf.UnitPrice, inf.SalesPrice, inf.SafelyQuantity, inf.BHYTPrice, inf.Active, inf.AmountVirtual, inf.RepositoryCode, inf.RepositoryName, inf.AmountEnd, inf.RateBHYT, inf.Note, inf.ListBHYT, inf.RepositoryGroupCode, inf.SODKGP, inf.UnitOfMeasureCode_Medi, inf.Converted_Medi, inf.ListService);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch (Exception) { }
            return dtResult;
        }
        public static DataTable DT_ListItemsRef(int iStatus, string sDepartCode, string group)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            table.Columns.Add(new DataColumn("ItemName", typeof(string)));
            table.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
            table.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
            table.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
            table.Columns.Add(new DataColumn("UsageCode", typeof(string)));
            table.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            table.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
            table.Columns.Add(new DataColumn("SafelyQuantity", typeof(Int32)));
            table.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
            table.Columns.Add(new DataColumn("Active", typeof(string)));
            table.Columns.Add(new DataColumn("AmountVirtual", typeof(decimal)));
            table.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
            table.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
            table.Columns.Add(new DataColumn("AmountEnd", typeof(decimal)));
            table.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
            table.Columns.Add(new DataColumn("Note", typeof(string)));
            table.Columns.Add(new DataColumn("ListBHYT", typeof(Int32)));
            try
            {
                string sql = string.Empty;
                sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitOfMeasureCode,b.ItemCategoryName,a.UsageCode,a.UnitPrice,a.SalesPrice,a.SafelyQuantity,a.BHYTPrice,a.Active,d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT,a.Note,a.ListBHYT
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0}) and d.RepositoryCode in(select RepositoryCode from DepartmentForRepository where DepartmentCode in('{1}')) and f.RepositoryGroupCode in({2})";
                sql += " order by d.RepositoryCode,d.ItemCode asc ";
                table = cn.ExecuteQuery(string.Format(sql, iStatus, sDepartCode, group));
            }
            catch { }
            return table;
        }
        public static DataTable TablePrintItem(int status)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                string query = string.Empty;
                query = @" select a.ItemCode,a.ItemName,a.Active,a1.UnitOfMeasureName,a2.ItemCategoryName,a3.GroupName,a4.UsageName,a.ListBHYT,a.ListService,SalesPrice
                    from Items a inner join UnitOfMeasure a1 on a.UnitOfMeasureCode=a1.UnitOfMeasureCode 
                    inner join ItemCategory a2 on a.ItemCategoryCode=a2.ItemCategoryCode inner join ItemGroup a3 on a2.GroupCode=a3.GroupCode
                    inner join Usage a4 on a.UsageCode=a4.UsageCode where Status ={0} ";
                table = cn.ExecuteQuery(string.Format(query, status));
            }
            catch { }
            return table;
        }
        public static List<Items_Ref> ListItemsRefForRepCode(int iStatus, string sRepCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_Ref> list = new List<Items_Ref>();
            try
            {
                string sql = string.Empty;
                sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status in({0})  and d.RepositoryCode='{1}' and d.AmountEnd > 0
                        order by a.ItemName asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, sRepCode), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = ireader.GetDecimal(11);
                    inf.RepositoryCode = ireader.GetValue(12).ToString();
                    inf.RepositoryName = ireader.GetValue(13).ToString();
                    inf.AmountEnd = ireader.GetDecimal(14);
                    inf.RateBHYT = ireader.GetDecimal(15);
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
        public static List<Items_Ref> ListItemsRef(int iStatus)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_Ref> list = new List<Items_Ref>();
            try
            {
                string sql = string.Empty;
                sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,d.UsageName,a.DisparityPrice,a.ListService,a.ListBHYT
                        from Items a inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode inner join Usage d on a.UsageCode=d.UsageCode
                        where 1=1";
                if (!iStatus.Equals(-1))
                    sql += " and a.Status in({0})";
                sql += " order by a.ItemName asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = 0;
                    inf.UsageName = ireader.GetValue(11).ToString();
                    inf.DisparityPrice = ireader.GetDecimal(12);
                    inf.ListService = ireader.GetInt32(13);
                    inf.ListBHYT = ireader.GetInt32(14);
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
        public static List<Items_View> ListItemsAll(int status)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_View> list = new List<Items_View>();
            try
            {
                string sql = string.Empty;
                if (status == -1)
                    sql = "select ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity, RepositoryCode,EmployeeCode,BHYTPrice,ListBHYT,RateBHYT,CountryCode,ProducerCode,Note,DisparityPrice,ListService,VendorCode,Packed,QtyOfMeasure,ItemContent,STTBCBHYT,SODKGP,STTQDPK,QUYCACH,Generic_BD,VENCode,Active_TT40,SalesPrice_Retail,UnitOfMeasureCode_Medi,Converted_Medi,Is_Acttach_Service,Is_Service_Auto from Items order by ItemName asc ";
                else
                    sql = "select ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity, RepositoryCode,EmployeeCode,BHYTPrice,ListBHYT,RateBHYT,CountryCode,ProducerCode,Note,DisparityPrice,ListService,VendorCode,Packed,QtyOfMeasure,ItemContent,STTBCBHYT,SODKGP,STTQDPK,QUYCACH,Generic_BD,VENCode,Active_TT40,SalesPrice_Retail,UnitOfMeasureCode_Medi,Converted_Medi,Is_Acttach_Service,Is_Service_Auto from Items where Status={0} order by ItemName asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, status), null);
                while (ireader.Read())
                {
                    Items_View inf = new Items_View();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.Active = ireader.GetValue(2).ToString();
                    inf.UsageCode = ireader.GetValue(3).ToString();
                    inf.UnitOfMeasureCode = ireader.GetValue(4).ToString();
                    inf.ItemCategoryCode = ireader.GetValue(5).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.Status = ireader.GetInt32(7);
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(8).ToString());
                    inf.SafelyQuantity = ireader.GetInt32(9);
                    inf.RepositoryCode = ireader.GetValue(10).ToString();
                    inf.EmployeeCode = ireader.GetValue(11).ToString();
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(12).ToString());
                    inf.ListBHYT = ireader.GetInt32(13);
                    inf.RateBHYT = Convert.ToInt32(ireader.GetValue(14).ToString());
                    inf.CountryCode = ireader.GetValue(15).ToString();
                    inf.ProducerCode = ireader.GetValue(16).ToString();
                    inf.Note = ireader.GetValue(17).ToString();
                    inf.DisparityPrice = ireader.GetDecimal(18);
                    inf.ListService = ireader.GetInt32(19);
                    inf.VendorCode = ireader.GetValue(20).ToString();
                    inf.Packed = ireader.GetValue(21).ToString();
                    inf.QtyOfMeasure = ireader.GetInt32(22);
                    inf.ItemContent = ireader.GetValue(23).ToString();
                    inf.STTBCBHYT = ireader.GetValue(24).ToString();
                    inf.SODKGP = ireader.GetValue(25).ToString();
                    inf.STTQDPK = ireader.GetValue(26).ToString();
                    inf.QUYCACH = ireader.GetValue(27).ToString();
                    inf.Generic_BD = ireader.GetValue(28).ToString();
                    inf.VENCode = ireader.GetValue(29).ToString();
                    inf.Active_TT40 = ireader.GetValue(30).ToString();
                    inf.SalesPrice_Retail = ireader.GetDecimal(31);
                    inf.UnitOfMeasureCode_Medi = ireader.GetValue(32).ToString();
                    inf.Converted_Medi = ireader.GetBoolean(33);
                    inf.Converted_Medi = ireader.GetBoolean(33);
                    string s = ireader.GetValue(34).ToString();
                    if (ireader.GetValue(34).ToString()!=null && ireader.GetValue(34).ToString()!="")
                    {
                        inf.Is_Acttach_Service = Convert.ToInt32(ireader.GetValue(34).ToString());
                    }
                    else
                    {
                        inf.Is_Acttach_Service = 0;
                    }
                    if (ireader.GetValue(35) != null && ireader.GetValue(35).ToString() != "")
                    {
                        inf.Is_Service_Auto = Convert.ToInt32(ireader.GetValue(35).ToString());
                    }
                    else
                    {
                        inf.Is_Service_Auto = 0;
                    }
                    
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
        public static List<Items_View> ListItemsForActive(string sActive, string sItemCode, DataTable dtItems)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_View> list = new List<Items_View>();
            try
            {
                string sql = string.Empty;
                string[] ArrActive = sActive.Split('+');
                string sTemp = "";
                string sActiveTemp = "";
                sql = @" select ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity, RepositoryCode,EmployeeCode,BHYTPrice,ListBHYT,RateBHYT 
                        from Items
                        where [ItemCode] not in('{0}')";
                int j = ArrActive.Length - 1;
                for (int i = 0; i < ArrActive.Length; i++)
                {
                    sActiveTemp += " Active like '%" + ArrActive[i].ToString() + "%'";
                    if (i < j)
                        sActiveTemp += " or ";
                }
                foreach (DataRow r in dtItems.Rows)
                {
                    if (r["ItemCode"].ToString() != sItemCode)
                        sTemp += "'" + r["ItemCode"].ToString() + "',";
                }
                if (sTemp != "")
                    sql += " and ItemCode in(" + sTemp.TrimEnd(',') + ")";
                else
                    sql += " and ItemCode in('')";
                if (sActiveTemp != "")
                    sql += " and (" + sActiveTemp + ")";
                sql += "  order by ItemName asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sItemCode), null);
                while (ireader.Read())
                {
                    Items_View inf = new Items_View();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.Active = ireader.GetString(2);
                    inf.UsageCode = ireader.GetValue(3).ToString();
                    inf.UnitOfMeasureCode = ireader.GetValue(4).ToString();
                    inf.ItemCategoryCode = ireader.GetString(5);
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.Status = ireader.GetInt32(7);
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(8).ToString());
                    inf.SafelyQuantity = ireader.GetInt32(9);
                    inf.RepositoryCode = ireader.GetString(10);
                    inf.EmployeeCode = ireader.GetValue(11).ToString();
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(12).ToString());
                    inf.ListBHYT = ireader.GetInt32(13);
                    inf.RateBHYT = Convert.ToInt32(ireader.GetValue(14).ToString());
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
        public static Items_View ListItemsForItemCode(string sItemCode, int iStatus)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                Items_View inf = new Items_View();
                string sql = string.Empty;
                sql = @"select ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity,RepositoryCode,EmployeeCode,BHYTPrice from Items
               where ItemCode ='{0}' and Status in({1}) order by ItemName asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sItemCode, iStatus), null);
                if(ireader.Read())
                {
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.Active = ireader.GetString(2);
                    inf.UsageCode = ireader.GetValue(3).ToString();
                    inf.UnitOfMeasureCode = ireader.GetValue(4).ToString();
                    inf.ItemCategoryCode = ireader.GetString(5);
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.Status = ireader.GetInt32(7);
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(8).ToString());
                    inf.SafelyQuantity = ireader.GetInt32(9);
                    inf.RepositoryCode = ireader.GetString(10);
                    inf.EmployeeCode = ireader.GetValue(11).ToString();
                    inf.BHYTPrice = ireader.GetDecimal(12);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch  { return null; }
        }
        public static Int32 Ins(Items_Ins info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[37];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ItemCode;
                param[1] = new SqlParameter("@ItemName", SqlDbType.NVarChar, 500);
                param[1].Value = info.ItemName;
                param[2] = new SqlParameter("@Active", SqlDbType.NVarChar);
                param[2].Value = info.Active;
                param[3] = new SqlParameter("@UsageCode", SqlDbType.VarChar, 50);
                param[3].Value = info.UsageCode;
                param[4] = new SqlParameter("@UnitOfMeasureCode", SqlDbType.VarChar, 50);
                param[4].Value = info.UnitOfMeasureCode;
                param[5] = new SqlParameter("@ItemCategoryCode", SqlDbType.VarChar, 50);
                param[5].Value = info.ItemCategoryCode;
                param[6] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[6].Value = info.UnitPrice;
                param[7] = new SqlParameter("@Status", SqlDbType.Int);
                param[7].Value = info.Status;
                param[8] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[8].Value = info.SalesPrice;
                param[9] = new SqlParameter("@SafelyQuantity", SqlDbType.Int);
                param[9].Value = info.SafelyQuantity;
                param[10] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[10].Value = info.RepositoryCode;
                param[11] = new SqlParameter("@udate", SqlDbType.DateTime);
                param[11].Value = info.udate;
                param[12] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[12].Value = info.EmployeeCode;
                param[13] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[13].Value = info.BHYTPrice;
                param[14] = new SqlParameter("@ListBHYT", SqlDbType.Int);
                param[14].Value = info.ListBHYT;
                param[15] = new SqlParameter("@RateBHYT", SqlDbType.Int);
                param[15].Value = info.RateBHYT;
                param[16] = new SqlParameter("@CountryCode", SqlDbType.VarChar, 6);
                param[16].Value = info.CountryCode;
                param[17] = new SqlParameter("@ProducerCode", SqlDbType.VarChar, 50);
                param[17].Value = info.ProducerCode;
                param[18] = new SqlParameter("@Note", SqlDbType.NVarChar, 100);
                param[18].Value = info.Note;
                param[19] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[19].Value = info.DisparityPrice;
                param[20] = new SqlParameter("@ListService", SqlDbType.Int);
                param[20].Value = info.ListService;
                param[21] = new SqlParameter("@VendorCode", SqlDbType.VarChar, 200);
                param[21].Value = info.VendorCode;
                param[22] = new SqlParameter("@Packed", SqlDbType.NVarChar, 50);
                param[22].Value = info.Packed;
                param[23] = new SqlParameter("@QtyOfMeasure", SqlDbType.Int);
                param[23].Value = info.QtyOfMeasure;
                param[24] = new SqlParameter("@ItemContent", SqlDbType.NVarChar, 50);
                param[24].Value = info.ItemContent;
                param[25] = new SqlParameter("@STTBCBHYT", SqlDbType.VarChar, 50);
                param[25].Value = info.STTBCBHYT;
                param[26] = new SqlParameter("@SODKGP", SqlDbType.VarChar, 50);
                param[26].Value = info.SODKGP;
                param[27] = new SqlParameter("@STTQDPK", SqlDbType.VarChar, 50);
                param[27].Value = info.STTQDPK;
                param[28] = new SqlParameter("@QUYCACH", SqlDbType.NVarChar);
                param[28].Value = info.QUYCACH;
                param[29] = new SqlParameter("@Generic_BD", SqlDbType.Char, 1);
                param[29].Value = info.Generic_BD;
                param[30] = new SqlParameter("@VENCode", SqlDbType.Char, 1);
                param[30].Value = info.VENCode;
                param[31] = new SqlParameter("@Active_TT40", SqlDbType.VarChar);
                param[31].Value = info.Active_TT40;
                param[32] = new SqlParameter("@SalesPrice_Retail", SqlDbType.Decimal);
                param[32].Value = info.SalesPrice_Retail;
                param[33] = new SqlParameter("@UnitOfMeasureCode_Medi", SqlDbType.VarChar);
                param[33].Value = info.UnitOfMeasureCode_Medi;
                param[34] = new SqlParameter("@Converted_Medi", SqlDbType.Bit);
                param[34].Value = info.Converted_Medi == true ? 1 : 0;
                param[35] = new SqlParameter("@Is_Acttach_Service", SqlDbType.Int);
                param[35].Value = info.Is_Acttach_Service;
                param[36] = new SqlParameter("@Is_Service_Auto", SqlDbType.Int);
                param[36].Value = info.Is_Service_Auto;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Items", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch (Exception ex) { return -2; }
        }
        public static Int32 Del(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Items", param);
            }
            catch { return -1; }
        }
        public static DataTable DT_ListItemsRefForRepCode(int iStatus, string sRepCode, bool isUnitPrice_Menu)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
            dt.Columns.Add(new DataColumn("UsageCode", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SafelyQuantity", typeof(Int32)));
            dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Active", typeof(string)));
            dt.Columns.Add(new DataColumn("AmountVirtual", typeof(decimal)));
            dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
            dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
            dt.Columns.Add(new DataColumn("AmountEnd", typeof(decimal)));
            dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SalesPrice_Retail", typeof(decimal)));
            try
            {
                string sql = string.Empty;
                if (isUnitPrice_Menu)
                {
                    sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        d.AmountVirtual,e.RepositoryCode,e.RepositoryName,d.AmountEnd,a.RateBHYT,a.SalesPrice_Retail
                        from InventoryGeneral d inner join Items a on d.ItemCode=a.ItemCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status ={0}  and d.RepositoryCode='{1}' and d.AmountEnd>=0
                        order by a.ItemName asc ";
                }
                else
                {
                    sql += @" select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        0 as AmountVirtual,e.RepositoryCode,e.RepositoryName,(sum(d.AmountImport)-sum(d.AmountExport)) AmountEnd,a.RateBHYT,a.SalesPrice_Retail
                        from InventoryGumshoe d inner join Items a on d.ItemCode=a.ItemCode
                        inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode  
                        inner join RepositoryCatalog e on d.RepositoryCode = e.RepositoryCode inner join RepositoryGroup f on e.RepositoryGroupCode=f.RepositoryGroupCode
                        where a.Status={0}  and d.RepositoryCode='{1}'
	                    group by d.DateEnd,d.Shipment,a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode
	                    , a.SalesPrice,e.RepositoryCode,e.RepositoryName,a.RateBHYT,a.SalesPrice_Retail
	                    having (sum(d.AmountImport)-sum(d.AmountExport))>0
                        order by a.ItemName asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, sRepCode), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = Convert.ToDecimal(ireader.GetValue(11));
                    inf.RepositoryCode = ireader.GetValue(12).ToString();
                    inf.RepositoryName = ireader.GetValue(13).ToString();
                    inf.AmountEnd = ireader.GetDecimal(14);
                    inf.RateBHYT = ireader.GetDecimal(15);
                    inf.SalesPrice_Retail = ireader.GetDecimal(16);
                    dt.Rows.Add(inf.ItemCode, inf.ItemName, inf.UnitOfMeasureName, inf.UnitOfMeasureCode, inf.ItemCategoryName, inf.UsageCode, inf.UnitPrice, inf.SalesPrice, inf.SafelyQuantity, inf.BHYTPrice, inf.Active, inf.AmountVirtual, inf.RepositoryCode, inf.RepositoryName, inf.AmountEnd, inf.RateBHYT, inf.SalesPrice_Retail);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dt;
        }
        public static List<Items_Ref> ListItemsRefBHYT(int iStatus)
        {
            ConnectDB cn = new ConnectDB();
            List<Items_Ref> list = new List<Items_Ref>();
            try
            {
                string sql = string.Empty;
                sql = @" Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,d.UsageName,a.DisparityPrice,a.ListService,a.ListBHYT,a.SODKGP,a.Active_TT40
                        from Items a inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode inner join Usage d on a.UsageCode=d.UsageCode
                        where 1=1 and a.ListBHYT=1 and a.BHYTPrice > 0 ";
                if (!iStatus.Equals(-1))
                    sql += " and a.Status in({0})";
                sql += " order by a.ItemName asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = 0;
                    inf.UsageName = ireader.GetValue(11).ToString();
                    inf.DisparityPrice = ireader.GetDecimal(12);
                    inf.ListService = ireader.GetInt32(13);
                    inf.ListBHYT = ireader.GetInt32(14);
                    inf.SODKGP = ireader.GetValue(15).ToString();
                    inf.Active_TT40 = ireader.GetValue(16).ToString();
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
        public static List<Items_BHYTInf> ListItemsBHYT()
        {
            ConnectDB cn = new ConnectDB();
            List<Items_BHYTInf> list = new List<Items_BHYTInf>();
            try
            {
                string query = " select STT,SO_DANG_KY,TEN_THUOC,MA_HOAT_CHAT_TT40,HOAT_CHAT_TT40,HOAT_CHAT_SODK,MA_DUONG_DUNG,DUONG_DUNG,HAM_LUONG,DONG_GOI,HANG_SX,NUOC_SX from  Items_BHYT order by STT ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, query, null);
                while (ireader.Read())
                {
                    Items_BHYTInf inf = new Items_BHYTInf();
                    inf.STT = ireader.GetDecimal(0);
                    inf.SO_DANG_KY = ireader.GetValue(1).ToString();
                    inf.TEN_THUOC = ireader.GetValue(2).ToString();
                    inf.MA_HOAT_CHAT_TT40 = ireader.GetValue(3).ToString();
                    inf.HOAT_CHAT_TT40 = ireader.GetValue(4).ToString();
                    inf.HOAT_CHAT_SODK = ireader.GetValue(5).ToString();
                    inf.MA_DUONG_DUNG = ireader.GetValue(6).ToString();
                    inf.DUONG_DUNG = ireader.GetValue(7).ToString();
                    inf.HAM_LUONG = ireader.GetValue(8).ToString();
                    inf.DONG_GOI = ireader.GetValue(9).ToString();
                    inf.HANG_SX = ireader.GetValue(10).ToString();
                    inf.NUOC_SX = ireader.GetValue(11).ToString();
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
        public static DataTable TableActive_BHYT()
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                string query = @" select Active_Code,Active_Name,Note,STT from Items_BHYT_Active order by STT";
                table = cn.ExecuteQuery(query);
            }
            catch { }
            return table;
        }
    }
}
