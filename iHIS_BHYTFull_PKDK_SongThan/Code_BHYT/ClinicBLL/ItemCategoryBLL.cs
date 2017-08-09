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
    public class ItemCategoryBLL
    {
        public static DataTable DTItemCategory(string sCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("ItemCategoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("GroupCode", typeof(string)));
                var vlist = ItemCategoryDal.ListItemCategory(sCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.ItemCategoryCode;
                    dr[1] = lt1.ItemCategoryName;
                    dr[2] = lt1.GroupCode;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<ItemCategoryInf> ListItemCategory(string sCode)
        {
            return ItemCategoryDal.ListItemCategory(sCode);
        }

        public static int InsItemCategory(ItemCategoryInf info)
        {
            return ItemCategoryDal.InsItemCategory(info);
        }

        public static int DelItemCategory(string sCode)
        {
            return ItemCategoryDal.DelItemCategory(sCode);
        }

    }
}
