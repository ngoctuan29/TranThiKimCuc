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
    public class rpt_Banking_DAL
    {
        public static DataTable DT_Chart_DoanhThuNgay(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.Char);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.Char);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ChartVP_DoanhThuNgay", param);
                return dtResult;
            }
            catch { return null; }
        }
        
        public static DataTable DT_Chart_DoanhThuThang()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ChartVP_DoanhThuThang", null);
                return dtResult;
            }
            catch { return null; }
        }

        public static List<ServiceCategoryInf> rptListCategoryGeneral(string sGroup)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceCategoryInf> list = new List<ServiceCategoryInf>();
            try
            {
                string sql = "";
                sql = @" select RowID,ServiceGroupCode GroupCode,ServiceCategoryCode CategoryCode,ServiceCategoryName CategoryName from ServiceCategory ";
                if (sGroup != "")
                    sql += " where servicegroupcode in({0})";
                sql+=" union all";
                sql += " select a.RowID,a.GroupCode,a.ItemCategoryCode CategoryCode,a.ItemCategoryName CategoryName  from ItemCategory a inner join ItemGroup a1 on a.GroupCode=a1.GroupCode ";
                if (sGroup != "")
                    sql += " where a1.ServiceModuleCode in({0}) ";
                sql += "  order by GroupCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sGroup), null);
                while (ireader.Read())
                {
                    ServiceCategoryInf inf = new ServiceCategoryInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceGroupCode = ireader.GetString(1);
                    inf.ServiceCategoryCode = ireader.GetString(2);
                    inf.ServiceCategoryName = ireader.GetString(3);
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

        public static DataTable DataReportDailyRevenue(DateTime startDate, DateTime endDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param[0].Value = startDate;
                param[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param[1].Value = endDate;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ReportDailyRevenue", param);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable DataViewDailyRevenueDetail(DateTime startDate, DateTime endDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[2];
                sqlParameter[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                sqlParameter[0].Value = startDate;
                sqlParameter[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                sqlParameter[1].Value = endDate;
                dtbResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ReportDailyRevenueDetail", sqlParameter);
            }
            catch { }
            return dtbResult;
        }

        public static DataTable DataViewDailyInvoice(DateTime startDate, DateTime endDate, Int32 cancel)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[3];
                sqlParameter[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                sqlParameter[0].Value = startDate;
                sqlParameter[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                sqlParameter[1].Value = endDate;
                sqlParameter[2] = new SqlParameter("@Cancel", SqlDbType.Int);
                sqlParameter[2].Value = cancel;
                dtbResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ReportDailyInvoice", sqlParameter);
            }
            catch { }
            return dtbResult;
        }
        public static DataTable DataViewDailyInvoiceDetail(DateTime startDate, DateTime endDate, Int32 cancel)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[3];
                sqlParameter[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                sqlParameter[0].Value = startDate;
                sqlParameter[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                sqlParameter[1].Value = endDate;
                sqlParameter[2] = new SqlParameter("@Cancel", SqlDbType.Int);
                sqlParameter[2].Value = cancel;
                dtbResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_DailyInvoiceDetail", sqlParameter);
            }
            catch(Exception ex) { }
            return dtbResult;
        }
        public static DataTable ReportDailyInvoice_xempk(DateTime startDate, DateTime endDate, Int32 cancel, Int32 loai)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                sqlParameter[0].Value = startDate;
                sqlParameter[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                sqlParameter[1].Value = endDate;
                sqlParameter[2] = new SqlParameter("@Cancel", SqlDbType.Int);
                sqlParameter[2].Value = cancel;
                sqlParameter[3] = new SqlParameter("@Loai", SqlDbType.Int);
                sqlParameter[3].Value = loai;
                dtbResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ReportDailyInvoice_xempk", sqlParameter);
            }
            catch { }
            return dtbResult;
        }
    }
}
