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
    public class ServiceCategoryBLL
    {
        public static DataTable DTServiceCategory(string sgroup, string sCateCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID"));
                dt.Columns.Add(new DataColumn("ServiceGroupCode"));
                dt.Columns.Add(new DataColumn("ServiceCategoryCode"));
                dt.Columns.Add(new DataColumn("ServiceCategoryName"));
                dt.Columns.Add(new DataColumn("STT"));
                var vlist = ServiceCategoryDal.ListServiceCategory(sgroup, sCateCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.ServiceGroupCode;
                    dr[2] = lt1.ServiceCategoryCode;
                    dr[3] = lt1.ServiceCategoryName;
                    dr[4] = lt1.STT;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<ServiceCategoryInf> ListServiceCategory(string sgroup, string sCateCode)
        {
            return ServiceCategoryDal.ListServiceCategory(sgroup, sCateCode);
        }

        public static List<ServiceCategoryInf> ListServiceCategoryRefService(string groupCode, string cateCode)
        {
            return ServiceCategoryDal.ListServiceCategoryRefService(groupCode, cateCode);
        }

        public static List<ServiceCategoryInf> rptListServiceCategory(string sGroup, string sCateCode)
        {
            return ServiceCategoryDal.rptListServiceCategory(sGroup, sCateCode);
        }

        public static int InsServiceCategory(ServiceCategoryInf info)
        {
            try
            {
                return ServiceCategoryDal.InsServiceCategory(info);
            }
            catch { return -2; }
        }

        public static int DelServiceCategory(string sCateCode)
        {
            try
            {
                return ServiceCategoryDal.DelServiceCategory(sCateCode);
            }
            catch { return -2; }
        }

        public static string ServiceGroupCode(string sGroupCode, string sCateCode)
        {
            string sCode = "";
            try
            {
                var vlist = ServiceCategoryDal.ListServiceCategory(sGroupCode, sCateCode);
                if (vlist.Count > 0)
                    sCode = vlist[0].ServiceGroupCode;
            }
            catch { }
            return sCode;
        }
    
    }
}
