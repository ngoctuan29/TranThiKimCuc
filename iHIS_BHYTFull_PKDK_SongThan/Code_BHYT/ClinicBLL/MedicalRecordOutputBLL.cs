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
    public class MedicalRecordOutputBLL
    {
        public static MedicalRecordOutputInf ObjRecordOutput(decimal rowid)
        {
            return MedicalRecordOutputDAL.ObjRecordOutput(rowid);
        }

        public static MedicalRecordOutputInf ObjRecordOutputForReceiveID(decimal patientReceiveID)
        {
            return MedicalRecordOutputDAL.ObjRecordOutputForReceiveID(patientReceiveID);
        }

        public static bool IsUpdCancelRecordOutput(decimal patientReceiveID)
        {
            return MedicalRecordOutputDAL.IsUpdCancelRecordOutput(patientReceiveID);
        }
        public static bool IURecordOutput(MedicalRecordOutputInf info, ref int soluutru)
        {
            return MedicalRecordOutputDAL.IURecordOutput(info, ref soluutru);
        }
    }
}
