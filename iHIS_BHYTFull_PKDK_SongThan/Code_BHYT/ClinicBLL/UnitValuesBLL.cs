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
    public class UnitValuesBLL
    {
        public static List<UnitValuesInf> ListUnitValues(int iRowID)
        {
            return UnitValuesDAL.ListUnitValues(iRowID);
        }
        public static DataTable DT_UnitValues(int iRowID)
        {
            return UnitValuesDAL.DT_UnitValues(iRowID); 
        }
        public static Int32 Ins(UnitValuesInf info)
        {
            return UnitValuesDAL.Ins(info);
        }
        public static Int32 Del(Int32 iRowID)
        {
            return UnitValuesDAL.Del(iRowID);
        }
    }
}
