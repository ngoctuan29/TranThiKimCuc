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
    public class IntroducerBLL
    {
        public static DataTable DTIntroducer(string sIntroCode)
        {
            return IntroducerDAL.DTIntroducer(sIntroCode);
        }
        public static Int32 Ins(IntroducerInf info)
        {
            return IntroducerDAL.Ins(info);
        }
        public static Int32 Del(string sIntroCode)
        {
            return IntroducerDAL.Del(sIntroCode);
        }

    }
}
