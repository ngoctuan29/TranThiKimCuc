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
    public class CatalogWardBLL
    {
        public DataTable DTListWard(string wardCode, string districtCode, string provincialCode)
        {
            CatalogWardDAL ward = new CatalogWardDAL();
            return ward.DTListWard(wardCode, districtCode, provincialCode);
        }
        public bool InsWard(CatalogWardInf obj)
        {
            CatalogWardDAL ward = new CatalogWardDAL();
            return ward.InsWard(obj);
        }
        public int DelWard(string wardCode)
        {
            CatalogWardDAL ward = new CatalogWardDAL();
            return ward.DelWard(wardCode);
        }
    }
}
