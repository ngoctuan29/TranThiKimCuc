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
    public class LaboratoryBLL
    {
        public static List<LaboratoryInf> ListLaboratory(Int32 iRowID)
        {
            return LaboratoryDAL.ListLaboratory(iRowID);
        }
        public static DataTable DT_Laboratory(int iRowID)
        {
            return LaboratoryDAL.DT_Laboratory(iRowID);
        }
        public static Int32 Ins(LaboratoryInf info)
        {
            return LaboratoryDAL.Ins(info);
        }
        public static Int32 Del(Int32 iRowid)
        {
            return LaboratoryDAL.Del(iRowid);
        }

        public static DataTable DataLaboratoryForPatient(decimal patientReceiveId, string patientCode, int status, string stt, string startDate, string toDate, string departmentCodeOrder)
        {
            return LaboratoryDAL.DataLaboratoryForPatient(patientReceiveId, patientCode, status, stt, startDate, toDate, departmentCodeOrder);
        }
        public static DataTable DataLaboratoryForPatientAppointment(decimal patientReceiveId, string patientCode, int status, int transfer, string serviceModuleCode)
        {
            return LaboratoryDAL.DataLaboratoryForPatientAppointment(patientReceiveId, patientCode, status, transfer, serviceModuleCode);
        }
    }
}
