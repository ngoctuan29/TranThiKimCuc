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
    public class TNTTBLL
    {
        public static DataTable TableTaiNanTT()
        {
            return TNTTDal.TableTaiNanTT();
        }

    }
}
