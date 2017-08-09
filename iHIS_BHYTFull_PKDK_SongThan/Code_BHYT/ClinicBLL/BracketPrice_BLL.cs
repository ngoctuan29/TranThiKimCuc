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
    public class BracketPrice_BLL
    {
        public static BracketPrice_INF List(int iRowID)
        {
            return BracketPrice_DAL.List(iRowID);
        }
        public static DataTable DT_List()
        {
            return BracketPrice_DAL.DT_List();
        }
        public static Int32 Ins(BracketPrice_INF info)
        {
            return BracketPrice_DAL.Ins(info);
        }
        public static Int32 Del(Int32 iRowID)
        {
            return BracketPrice_DAL.Del(iRowID);
        }
        public static Int32 SearchRateOf(decimal dUnitPrice)
        {
            return BracketPrice_DAL.SearchRateOf(dUnitPrice);
        }
    }
}
