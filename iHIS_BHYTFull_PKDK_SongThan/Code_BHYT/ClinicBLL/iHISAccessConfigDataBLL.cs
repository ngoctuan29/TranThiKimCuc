using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicDAL;
using System.Data;

namespace ClinicBLL
{
    public class iHISAccessConfigDataBLL
    {
        public static string MyServerName()
        {
            return iHISAccessConfigDataDAL.MyServerName();
        }

        public static DataTable TableServerName()
        {
            return iHISAccessConfigDataDAL.TableServerName();
        }
    }
}
