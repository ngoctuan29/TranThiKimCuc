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
    public class FoodEntryBLL
    {
        public static List<FoodEntryINF> ListFoodEntry(decimal dEntryID)
        {
            return FoodEntryDAL.ListFoodEntry(dEntryID);
        }

        public static Decimal Ins(FoodEntryINF info)
        {
            return FoodEntryDAL.Ins(info);
        }

        public static List<FoodEntryINF> ListFoodEntry(DateTime dtfrm, DateTime dtto)
        {
            return FoodEntryDAL.ListFoodEntry(dtfrm, dtto);
        }

    }
}
