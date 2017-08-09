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
    public class Catalog_SurgicalCrewBLL
    {
        public static DataTable DT_List()
        {
            return Catalog_SurgicalCrewDAL.DT_List();
        }

        public static Int32 Ins(Catalog_SurgicalCrewINF info)
        {
            return Catalog_SurgicalCrewDAL.Ins(info);
        }
        public static Int32 Del(Int32 iRowID)
        {
            return Catalog_SurgicalCrewDAL.Del(iRowID);
        }
    }
}
