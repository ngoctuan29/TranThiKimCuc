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
    public class FoodDetailBLL
    {
        public static DataTable DT_ListFoodDetail(decimal dEntryID)
        {
            return FoodDetailDAL.DT_ListFoodDetail(dEntryID);
        }

        public static Int32 Ins(FoodDetailINF info)
        {
            return FoodDetailDAL.Ins(info);
        }
        public static Int32 Del(decimal dEntryID, decimal dDetailID)
        {
            return FoodDetailDAL.Del(dEntryID, dDetailID);
        }
        public static List<FoodDetailPrintINF> ListFoodDetail(decimal dEntryID)
        {
            return FoodDetailDAL.ListFoodDetail(dEntryID);
        }
    }
}
