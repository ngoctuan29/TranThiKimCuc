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
    public class HSBA_SynchronizeBLL
    {
        public static HSBA_ObjMedicalrecordsInf ObjMedicalrecords(decimal patientReceiveID, string patientCode)
        {
            return HSBA_SynchronizeDal.ObjMedicalrecords(patientReceiveID, patientCode);
        }
        public static bool isUpdComfirmHSBA(decimal patientReceiveID, string patientCode)
        {
            return HSBA_SynchronizeDal.isUpdComfirmHSBA(patientReceiveID, patientCode);
        }
        public static DataTable TableGet_KetQuaDieuTri(string dtFrom, string dtTo, string department, int iType, int comfirmHSBA)
        {
            return HSBA_SynchronizeDal.TableGet_KetQuaDieuTri(dtFrom, dtTo, department, iType, comfirmHSBA);
        }
    }
}
