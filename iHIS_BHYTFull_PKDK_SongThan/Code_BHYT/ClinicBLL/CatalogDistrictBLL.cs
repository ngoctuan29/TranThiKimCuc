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
    public class CatalogDistrictBLL
    {
        public CatalogDistrictBLL() { }
        public DataTable DTListDistrict(string districtCode, string provincialCode)
        {
            CatalogDistrictDAL district = new CatalogDistrictDAL();
            return district.DTListDistrict(districtCode, provincialCode);
        }

        public DataTable DTListDistrictForProvincial(string provincialCode)
        {
            CatalogDistrictDAL district = new CatalogDistrictDAL();
            return district.DTListDistrictForProvincial(provincialCode);
        }

        public bool InsDistrict(CatalogDistrictInf obj)
        {
            CatalogDistrictDAL district = new CatalogDistrictDAL();
            return district.InsDistrict(obj);
        }
        public int DelDistrict(string districtCode)
        {
            CatalogDistrictDAL district = new CatalogDistrictDAL();
            return district.DelDistrict(districtCode);
        }
    }
}
