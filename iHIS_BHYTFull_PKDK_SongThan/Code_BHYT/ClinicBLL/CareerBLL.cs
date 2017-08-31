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
    public class CareerBLL
    {
        public static DataTable DTCareer(string sCareerCode)
        {
            return CareerDAL.DTCareer(sCareerCode);
        }

        public static Int32 Ins(CareerInf info)
        {
            return CareerDAL.Ins(info);
        }



        public static Int32 Del(string sCareerCode)
        {
            return CareerDAL.Del(sCareerCode);
        }

    }
}
