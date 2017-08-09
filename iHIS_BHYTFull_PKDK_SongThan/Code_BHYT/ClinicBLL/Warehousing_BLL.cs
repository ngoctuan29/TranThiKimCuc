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
    public class Warehousing_BLL
    {
        public static List<Warehousing_INF> List(string sCode)
        {
            return Warehousing_DAL.List(sCode);
        }

        public static List<ViewWarehousingInf> ListViewWarehousing(string warehousingCode)
        {
            return Warehousing_DAL.ListViewWarehousing(warehousingCode);
        }

        public static List<WarehousingSearch_INF> ListSearch(string sfrom, string sto, string employeeCode)
        {
            return Warehousing_DAL.ListSearch(sfrom, sto, employeeCode);
        }
        public static List<WarehousingSearch_INF> ListExportToRep(Int32 iStatus)
        {
            return Warehousing_DAL.ListExportToRep(iStatus);
        }
        public static List<WarehousingDetail_INF> ListDetail(string sCode)
        {
            return Warehousing_DAL.ListDetail(sCode);
        }

        public static DataTable DT_ListDetail(string sCode)
        {
            return Warehousing_DAL.DT_ListDetail(sCode);
        }

        public static DataTable DT_ListDetailExport(string sRepositoryCode, string sExpCode)
        {
            return Warehousing_DAL.DT_ListDetailExport(sRepositoryCode, sExpCode);
        }

        public static Int32 Ins(Warehousing_INF info, ref string refCode)
        {
            return Warehousing_DAL.Ins(info, ref refCode);
        }

        public static Int32 InsDetail(WarehousingDetail_INF info, ref decimal dRowID)
        {
            return Warehousing_DAL.InsDetail(info, ref dRowID);
        }
        public static Int32 Upd_StatusWarehousing(Int32 iStatus, string sHousingCode)
        {
            return Warehousing_DAL.Upd_StatusWarehousing(iStatus, sHousingCode);
        }
        public static Int32 Del(string sHousingCode)
        {
            return Warehousing_DAL.Del(sHousingCode);
        }
        public static Int32 Del(string sHousingCode, string sItemCode)
        {
            return Warehousing_DAL.Del(sHousingCode, sItemCode);
        }
        public static List<WarehousingSearch_INF> ListWaitingExport(Int32 iStatus)
        {
            return Warehousing_DAL.ListWaitingExport(iStatus);
        }
        
    }
}
