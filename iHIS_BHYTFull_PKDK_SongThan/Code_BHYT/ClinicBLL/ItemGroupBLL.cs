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
    public class ItemGroupBLL
    {
        public static DataTable DTListItemGroup(string sCode)
        {
            return ItemGroupDAL.DTListItemGroup(sCode);
        }
        public static List<ItemGroupInf> ListItemGroup(string sCode)
        {
            return ItemGroupDAL.ListItemGroup(sCode);
        }
        public static Int32 InsItemGroup(ItemGroupInf info)
        {
            return ItemGroupDAL.InsItemGroup(info);
        }
        public static Int32 DelItemGroup(string sCode)
        {
            return ItemGroupDAL.DelItemGroup(sCode);
        }
    }
}
