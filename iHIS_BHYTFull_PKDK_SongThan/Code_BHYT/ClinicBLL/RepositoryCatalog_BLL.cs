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
    public class RepositoryCatalog_BLL
    {
        public static DataTable DTListRepositoryAll(int hide)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("Hide", typeof(Int32)));
                dt.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(decimal)));
                dt.Columns.Add(new DataColumn("DateReport", typeof(DateTime)));
                var vlist = RepositoryCatalog_Dal.ListRepositoryAll(hide);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.RepositoryCode;
                    dr[2] = lt1.RepositoryName;
                    dr[3] = lt1.Hide;
                    dr[4] = lt1.RepositoryGroupCode;
                    dr[5] = lt1.DateReport;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
        
        public static List<RepositoryCatalog_Inf> ListRepositoryForImport(Int32 iHide, string groupCode, string employeeCode)
        {
            return RepositoryCatalog_Dal.ListRepositoryForImport(iHide, groupCode, employeeCode);
        }
        public static List<RepositoryCatalog_Inf> ListRepositoryForExport(Int32 iHide, string groupCode, string employeeCode)
        {
            return RepositoryCatalog_Dal.ListRepositoryForExport(iHide, groupCode, employeeCode);
        }
        public static List<RepositoryCatalog_Inf> ListRepository(Int32 iHide)
        {
            return RepositoryCatalog_Dal.ListRepository(iHide);
        }
        public static List<RepositoryCatalog_Inf> ListRepositoryForBHYT(Int32 iHide, Int32 iGroupCode)
        {
            return RepositoryCatalog_Dal.ListRepositoryForBHYT(iHide, iGroupCode);
        }
        public static List<RepositoryCatalog_Inf> ListRepositoryForDuyetCap(Int32 iHide)
        {
            return RepositoryCatalog_Dal.ListRepositoryForDuyetCap(iHide);
        }
        public static List<RepositoryCatalog_Inf> ListRepositoryForBHYT(Int32 iHide, Int32 iGroupCode, string sRepCode)
        {
            return RepositoryCatalog_Dal.ListRepositoryForBHYT(iHide, iGroupCode, sRepCode);
        }
        public static List<RepositoryCatalog_Inf> ListRepositoryForDepartment(Int32 iHide)
        {
            return RepositoryCatalog_Dal.ListRepositoryForDepartment(iHide);
        }
        public static RepositoryCatalog_Inf ListRepository(string sRepCode, int iHide)
        {
            return RepositoryCatalog_Dal.ListRepository(sRepCode, iHide);
        }
        public static int Ins(RepositoryCatalog_Inf info)
        {
            try
            {
                return RepositoryCatalog_Dal.Ins(info);
            }
            catch { return -2; }
        }

        public static Int32 Del(string sCode)
        {
            return RepositoryCatalog_Dal.Del(sCode);
        }
        public static DataTable DT_ListRepositoryGroup()
        {
            return RepositoryCatalog_Dal.DT_ListRepositoryGroup();
        }
        public static DataTable DT_ViewInventory(string repositoryCode)
        {
            return RepositoryCatalog_Dal.DT_ViewInventory(repositoryCode);
        }
        public static DataTable TableViewInventoryLimited(string repositoryCode)
        {
            return RepositoryCatalog_Dal.TableViewInventoryLimited(repositoryCode);
        }
        public static List<RepositoryCatalog_Inf> ListRepositoryNotGroup(Int32 hide, Int32 group)
        {
            return RepositoryCatalog_Dal.ListRepositoryNotGroup(hide, group);
        }
       
    }
}
