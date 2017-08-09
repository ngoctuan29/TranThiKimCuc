using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicLibrary;
using ClinicModel;
using System.Data;
using ClinicDAL;

namespace ClinicBLL
{
    public class Catalog_FoodBLL
    {
        public static DataTable DT_ListCatalog_Food()
        {
            return Catalog_FoodDAL.DT_ListCatalog_Food();
        }
        public static Int32 Ins(Catalog_FoodINF info)
        {
            return Catalog_FoodDAL.Ins(info);
        }
        public static Int32 Del(string sCatalog_FoodCode)
        {
            return Catalog_FoodDAL.Del(sCatalog_FoodCode);
        }
    }
}
