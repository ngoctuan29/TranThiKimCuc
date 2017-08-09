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
    public class MenuListBLL
    {
        public static DataTable DTMenuList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = MenuListDal.DTMenuList();
            }
            catch  { dt = null; }
            return dt;
        }
        public static DataTable DTMenuListSystem()
        {
            return MenuListDal.DTMenuListSystem();
        }
        public static Int32 InsMenuList(MenuListInf info)
        {
            return MenuListDal.InsMenuList(info);
        }

        public static Int32 DelAll_MenuList()
        {
            return MenuListDal.DelAll_MenuList();
        }
    }
}
