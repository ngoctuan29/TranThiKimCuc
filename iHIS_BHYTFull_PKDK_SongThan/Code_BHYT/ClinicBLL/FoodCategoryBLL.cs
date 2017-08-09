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
    public class FoodCategoryBLL
    {
        public static List<FoodCategoryINF> ListFoodCategory()
        {
            return FoodCategoryDAL.ListFoodCategory();
        }

        public static Int32 Ins(FoodCategoryINF info)
        {
            return FoodCategoryDAL.Ins(info);
        }

        public static Int32 Upd(FoodCategoryINF info)
        {
            return FoodCategoryDAL.Upd(info);
        }

        public static Int32 Del(Int32 iFoodCategoryID)
        {
            return FoodCategoryDAL.Del(iFoodCategoryID);
        }
        public static DataTable DTListFoodCategory()
        {
            return FoodCategoryDAL.DTListFoodCategory();
        }
    }
}
