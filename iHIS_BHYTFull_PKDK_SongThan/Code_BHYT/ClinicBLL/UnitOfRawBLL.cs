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
    public class UnitOfRawBLL
    {
        public static List<UnitOfRawINF> ListUnitOfRaw(Int32 iID)
        {
            return UnitOfRawDAL.ListUnitOfRaw(iID);
        }

        public static DataTable DT_UnitOfRaw(Int32 iID)
        {
            return UnitOfRawDAL.DT_UnitOfRaw(iID);
        }

        public static Int32 Ins(UnitOfRawINF info)
        {
            return UnitOfRawDAL.Ins(info);
        }
        public static Int32 Del(Int32 iID)
        {
            return UnitOfRawDAL.Del(iID);
        }

    }
}
