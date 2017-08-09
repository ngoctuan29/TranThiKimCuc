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
    public class CatalogProvincialBLL
    {
        public static DataTable DTListProvincial(string provincialCode)
        {
            return CatalogProvincialDal.DTListProvincial(provincialCode);
        }
        public static DataTable DTListProvincialForBHYT(string provincialCode)
        {
            CatalogProvincialDal provincial = new CatalogProvincialDal();
            return CatalogProvincialDal.DTListProvincialForBHYT(provincialCode);
        }
        public static DataTable DTRegionAll()
        {
            return CatalogProvincialDal.DTRegionAll();
        }
        public static bool InsProvincial(CatalogProvincialInf obj)
        {
            return CatalogProvincialDal.InsProvincial(obj);
        }
        public static int DelProvincial(string provincialCode)
        {
            return CatalogProvincialDal.DelProvincial(provincialCode);
        }
    }
}
