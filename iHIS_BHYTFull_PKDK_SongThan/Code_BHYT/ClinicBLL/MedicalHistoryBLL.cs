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
    public class MedicalHistoryBLL
    {
        public static DataTable TableMedicalHistory(decimal rowID)
        {
            return MedicalHistoryDal.TableMedicalHistory(rowID);
        }
                
        public static int InsMedicalHistory(MedicalHistoryInf info)
        {
            return MedicalHistoryDal.InsMedicalHistory(info);
        }

        public static int DelMedicalHistory(decimal rowID)
        {
            return MedicalHistoryDal.DelMedicalHistory(rowID);
        }

    }
}
