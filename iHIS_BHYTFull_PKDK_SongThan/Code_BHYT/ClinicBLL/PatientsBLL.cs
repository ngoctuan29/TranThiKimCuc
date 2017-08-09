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
    public class PatientsBLL
    {
        public static List<PatientsInf> ListPatients(string sPatientCode)
        {
            return PatientsDal.ListPatients(sPatientCode);
        }
        public static PatientsInf ObjPatients(string sPatientCode, decimal patientReceiveID)
        {
            return PatientsDal.ObjPatients(sPatientCode, patientReceiveID);
        }
        public static int InsPatients(PatientsInf info)
        {
            return PatientsDal.InsPatients(info);
        }

        public static Int32 UpdPatientsForMedicalHistoryChildren(string patientCode, string medicalHistoryChildren)
        {
            return PatientsDal.UpdPatientsForMedicalHistoryChildren(patientCode, medicalHistoryChildren);
        }

        public static string GetPatientCode()
        {
            return PatientsDal.GetPatientCode();
        }

        public static DataTable DTPatients(string patientCode)
        {
            return PatientsDal.DTPatients(patientCode);
        }
        public static DataTable DTPatients(string patientCode, decimal patientReceiveId)
        {
            return PatientsDal.DTPatients(patientCode, patientReceiveId);
        }
        public static List<PatientViewInf> ListHistoryForPatient(string patientCode)
        {
            return PatientsDal.ListHistoryForPatient(patientCode);
        }
        public static DataTable DT_PatientType()
        {
            return PatientsDal.DT_PatientType();
        }

        public static DataTable DT_PatientTypeNotin(Int32 iType)
        {
            return PatientsDal.DT_PatientTypeNotin(iType);
        }

        public static DataTable DT_PatientTypeMain()
        {
            return PatientsDal.DT_PatientTypeMain();
        }

        public static DataTable hsba_Patients(string patientCode)
        {
            return PatientsDal.hsba_Patients(patientCode);
        }

        public static Int32 UpdPatients(string medicalHistory, string sAllergy, string patientCode)
        {
            return PatientsDal.UpdPatients(medicalHistory, sAllergy, patientCode);
        }
    }
}
