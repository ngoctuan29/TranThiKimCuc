using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;
using ClinicLibrary;
using ClinicDAL;

namespace ClinicBLL
{
    public class rpt_Banking_BLL
    {
        public static DataTable DT_Chart_DoanhThuNgay(string dtFrom, string dtTo)
        {
            return rpt_Banking_DAL.DT_Chart_DoanhThuNgay(dtFrom, dtTo);
        }
        public static DataTable DT_Chart_DoanhThuThang()
        {
            return rpt_Banking_DAL.DT_Chart_DoanhThuThang();
        }
        public static List<ServiceCategoryInf> rptListCategoryGeneral(string sGroup)
        {
            return rpt_Banking_DAL.rptListCategoryGeneral(sGroup);
        }
        public static DataTable DataReportDailyRevenue(DateTime startDate, DateTime endDate)
        {
            return rpt_Banking_DAL.DataReportDailyRevenue(startDate, endDate);
        }
        public static DataTable DataViewDailyRevenueDetail(DateTime startDate, DateTime endDate)
        {
            return rpt_Banking_DAL.DataViewDailyRevenueDetail(startDate, endDate);
        }

        public static DataTable DataViewDailyInvoice(DateTime startDate, DateTime endDate, Int32 cancel)
        {
            return rpt_Banking_DAL.DataViewDailyInvoice(startDate, endDate, cancel);
        }
        public static DataTable DataViewDailyInvoiceDetail(DateTime startDate, DateTime endDate, Int32 cancel)
        {
            return rpt_Banking_DAL.DataViewDailyInvoiceDetail(startDate, endDate, cancel);
        }
        public static DataTable ReportDailyInvoice_xempk(DateTime startDate, DateTime endDate, Int32 cancel, Int32 loai)
        {
            return rpt_Banking_DAL.ReportDailyInvoice_xempk(startDate, endDate, cancel, loai);
        }
    }
}
