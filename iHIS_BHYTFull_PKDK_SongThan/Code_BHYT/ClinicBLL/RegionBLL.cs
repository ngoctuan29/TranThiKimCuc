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
    public class RegionBLL
    {
        public static List<RegionInf> ListRegion(Int32 iRegionID)
        {
            return RegionDal.ListRegion(iRegionID);
        }
        public static Int32 InsRegion(RegionInf info)
        {
            return RegionDal.InsRegion(info);
        }
        
        public static Int32 DelRegion(Int32 iRegionID)
        {
            return RegionDal.DelRegion(iRegionID);
        }
        public static DataTable DTListRegion(Int32 iRegionID)
        {
            return RegionDal.DTListRegion(iRegionID);
        }
    }
}
