using ClinicDAL;
using ClinicModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClinicBLL
{
    public class VP_ServiceGroupPrintBLL
    {
        public static DataTable GetListNhomIn()
        {
            return VP_ServiceGroupPrintDal.GetListNhomIn();
        }

        public static DataTable GetListNhomInByCode(int code)
        {
            return VP_ServiceGroupPrintDal.GetListNhomInByCode(code);
        }

        public static bool InsUpdNhomIn(VP_ServiceGroupPrintInf inf)
        {
            return VP_ServiceGroupPrintDal.InsUpdNhomIn(inf);
        }

        public static bool DelNhomIn(int code)
        {
            return VP_ServiceGroupPrintDal.DelNhomIn(code);
        }
    }
}
