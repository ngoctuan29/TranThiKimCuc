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
    public class ItemsBLL
    {
        public static List<Items_View> ListItems(Int32 iStatus)
        {
            return Items_Dal.ListItemsAll(iStatus);
        }
        public static Items_View ListItemsForItemCode(string sItemCode, int iStatus)
        {
            return Items_Dal.ListItemsForItemCode(sItemCode, iStatus);
        }

        public static DataTable ListItemsCode(string sitemCode)
        {
            return Items_Dal.ListItemslist(sitemCode);
        }

        public static DataTable ListItemslistAuto(string sitemCode)
        {
            return Items_Dal.ListItemslistAuto(sitemCode);
        }
        public static List<Items_Ref> ListItemsRef(Int32 iStatus, string repositoryCode)
        {
            return Items_Dal.ListItemsRef(iStatus, repositoryCode);
        }
        public static List<Items_Ref> ListItemsRef(Int32 iStatus, string sDepartCode, Int32 iGroup)
        {
            return Items_Dal.ListItemsRef(iStatus, sDepartCode, iGroup);
        }
        public static DataTable DT_ListItemsRef(int iStatus, string sDepartCode, string group)
        {
            return Items_Dal.DT_ListItemsRef(iStatus, sDepartCode, group);
        }
        public static DataTable Table_ListItemsRef(int iStatus, string sDepartCode, string group, Int32 objectCode)
        {
            bool isUnitPrice_Menu = false;
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
            if (objSys != null && objSys.RowID > 0)
                isUnitPrice_Menu = objSys.Values.Equals(1) ? true : false;
            return Items_Dal.Table_ListItemsRef(iStatus, sDepartCode, group, objectCode, isUnitPrice_Menu);
        }
        public static DataTable Table_ListItemsRef(int iStatus, string group, Int32 objectCode)
        {
            bool isUnitPrice_Menu = false;
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
            if (objSys != null && objSys.RowID > 0)
                isUnitPrice_Menu = objSys.Values.Equals(1) ? true : false;
            return Items_Dal.Table_ListItemsRef(iStatus, group, objectCode, isUnitPrice_Menu);
        }
        public static List<Items_View> ListItemsForActive(string sActive, string sItemCode, DataTable dtItems)
        {
            return Items_Dal.ListItemsForActive(sActive, sItemCode, dtItems);
        }

        public static List<Items_Ref> ListItemsRef(Int32 iStatus)
        {
            return Items_Dal.ListItemsRef(iStatus);
        }
        public static Int32 Ins(Items_Ins model)
        {
            return Items_Dal.Ins(model);
        }

        public static DataTable TablePrintItem(int status)
        {
            return Items_Dal.TablePrintItem(status);
        }

        public static Int32 Del(string sCode)
        {
            return Items_Dal.Del(sCode);
        }
        public static DataTable DT_ListItemsRefForRepCode(int iStatus, string sRepCode)
        {
            bool isUnitPrice_Menu = false;
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
            if (objSys != null && objSys.RowID > 0)
                isUnitPrice_Menu = objSys.Values.Equals(1) ? true : false;
            return Items_Dal.DT_ListItemsRefForRepCode(iStatus, sRepCode, isUnitPrice_Menu);
        }
        public static List<Items_Ref> ListItemsRefBHYT(Int32 iStatus)
        {
            return Items_Dal.ListItemsRefBHYT(iStatus);
        }
        public static List<Items_BHYTInf> ListItemsBHYT()
        {
            return Items_Dal.ListItemsBHYT();
        }

        public static DataTable TableActive_BHYT()
        {
            return Items_Dal.TableActive_BHYT();
        }
    }
}
