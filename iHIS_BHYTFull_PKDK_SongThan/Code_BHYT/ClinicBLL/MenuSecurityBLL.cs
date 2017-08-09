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
    public class MenuSecurityBLL
    {
        public static DataTable DTMenuSecurity(decimal dIdCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("MenuCode", typeof(string)));
                dt.Columns.Add(new DataColumn("MenuName", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                var vlist = MenuSecurityDal.ListMenu(dIdCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.MenuCode;
                    dr[2] = lt1.MenuName;
                    dr[3] = lt1.EmployeeCode;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static DataTable DTMenuSecurityForUser(string sUser, ref bool bData)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("MenuCode", typeof(string)));
                dt.Columns.Add(new DataColumn("MenuName", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                var vlist = MenuSecurityDal.ListMenuForUser(sUser);
                if (vlist.Count > 0)
                {
                    foreach (var lt1 in vlist)
                    {
                        DataRow dr;
                        dr = dt.NewRow();
                        dr.BeginEdit();
                        dr[0] = lt1.RowID;
                        dr[1] = lt1.MenuCode;
                        dr[2] = lt1.MenuName;
                        dr[3] = lt1.EmployeeCode;
                        dr[4] = 0;
                        dr.EndEdit();
                        dt.Rows.Add(dr);
                    }
                    bData = true;
                }
                else
                {
                    DataTable dtmenu = new DataTable();
                    dtmenu = MenuListDal.DTMenuList();
                    foreach (DataRow dr in dtmenu.Rows)
                    {
                        dt.Rows.Add(-1, dr["MenuCode"].ToString(), dr["MenuName"].ToString(), "", 0);
                    }
                    bData = false;
                }
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable DTMenuSecurityForUser(string sUser)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("menucode", typeof(string)));
                dt.Columns.Add(new DataColumn("menuname", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("chon", typeof(Int32)));
                dt.Columns.Add(new DataColumn("chitiet", typeof(string)));
                var vlist = MenuSecurityDal.ListMenuForUser(sUser);
                if (vlist.Count > 0)
                {
                    foreach (var lt1 in vlist)
                    {
                        DataRow dr;
                        dr = dt.NewRow();
                        dr.BeginEdit();
                        dr[0] = lt1.RowID;
                        dr[1] = lt1.MenuCode;
                        dr[2] = lt1.MenuName;
                        dr[3] = lt1.EmployeeCode;
                        dr[4] = 1;
                        dr[5] = string.Empty;
                        dr.EndEdit();
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch { dt = null; }
            return dt;
        }
        public static List<MenuSecurityInf> ListMenuSecurity(decimal dId)
        {
            return MenuSecurityDal.ListMenu(dId);
        }

        public static int InsMenuSecurity(MenuSecurityInf info)
        {
            return MenuSecurityDal.InsMenuSecurity(info);
        }

        public static int DelMenuSecurity(string sCode)
        {
            return MenuSecurityDal.DelMenuSecurity(sCode);
        }
    }
}
