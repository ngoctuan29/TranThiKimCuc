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
    public class Catalog_ExchangeRateBLL
    {
        
        public static DataTable DT_List()
        {
            return Catalog_ExchangeRateDAL.DT_List();
        }
        public static Int32 Ins(Catalog_ExchangeRateInf info)
        {
            return Catalog_ExchangeRateDAL.Ins(info);
        }
        public static Int32 Del(Int32 iRowID)
        {
            return Catalog_ExchangeRateDAL.Del(iRowID);
        }
        
    }
}
