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
    public class NationalityBLL
    {
        public static List<NationalityInf> ListNationality(Int32 iNationalityID)
        {
            return NationalityDal.ListNationality(iNationalityID);
        }
    }
}
