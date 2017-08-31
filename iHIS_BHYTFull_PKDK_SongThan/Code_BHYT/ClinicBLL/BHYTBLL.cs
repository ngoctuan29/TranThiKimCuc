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
    public class BHYTBLL
    {
        public static List<BHYTInf> ListBHYT(decimal dRowid)
        {
            return BHYTDal.ListBHYT(dRowid);
        }

        public static List<BHYTInf> ListBHYTForPatientReceiveId(decimal dRowid)
        {
            return BHYTDal.ListBHYTForPatientReceiveId(dRowid);
        }

        public static List<BHYTInf> ListBHYTForPatientReceiveIdDV(decimal dRowid)
        {
            return BHYTDal.ListBHYTForPatientReceiveIdDV(dRowid);
        }

        public static string PatientCodeForSerial(string serial)
        {
            return BHYTDal.PatientCodeForSerial(serial);
        }

        public static int InsBHYT(BHYTInf info)
        {
            return BHYTDal.InsBHYT(info);
        }

        public static DataTable TableBHYTForPatientReceiveId(decimal patientReceiveId)
        {
            return BHYTDal.TableBHYTForPatientReceiveId(patientReceiveId);
        }

    }
}
