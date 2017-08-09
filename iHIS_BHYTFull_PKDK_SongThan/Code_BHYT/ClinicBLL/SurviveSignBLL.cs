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
    public class SurviveSignBLL
    {
        public static List<SurviveSignInf> ListPatients(decimal dRow)
        {
            return SurviveSignDal.ListSurviveSign(dRow);
        }
        public static List<SurviveSignInf> ListSurviveSignForRefID(decimal dRefID)
        {
            return SurviveSignDal.ListSurviveSignForRefID(dRefID);
        }
        public static List<SurviveSignInf> ListSurviveSignForRefCode(string sReferCode, decimal dRefID, string sPatientCode)
        {
            return SurviveSignDal.ListSurviveSignForRefCode(sReferCode, dRefID, sPatientCode);
        }
        public static int InsSurviveSign(SurviveSignInf info)
        {
            return SurviveSignDal.InsSurviveSign(info);
        }

        public static DataTable DT_SurviveSignForRefCode(string referCode, string patientcode, decimal refID)
        {
            return SurviveSignDal.DT_SurviveSignForRefCode(referCode, patientcode, refID);
        }
        public static DataTable DT_SurviveSignForRefCode(string referCode)
        {
            return SurviveSignDal.DT_SurviveSignForRefCode(referCode);
        }
        public static DataTable DT_SurviveSignForRefID(decimal dRefID)
        {
            return SurviveSignDal.DT_SurviveSignForRefID(dRefID);
        }

    }
}
