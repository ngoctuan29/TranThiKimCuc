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
    public class SurgeriesBLL
    {
        public static SurgeriesINF ObjSurgeries(decimal dSuggested)
        {
            return SurgeriesDAL.ObjSurgeries(dSuggested);
        }
        public static List<SurgicalCrewINF> ListSurgicalCrew(string sCode)
        {
            return SurgeriesDAL.ListSurgicalCrew(sCode);
        }
        public static DataTable DT_Anesthesia()
        {
            return SurgeriesDAL.DT_Anesthesia(); 
        }
        public static DataTable DT_Complications()
        {
            return SurgeriesDAL.DT_Complications();
        }
        public static DataTable DT_TheSituation()
        {
            return SurgeriesDAL.DT_TheSituation();
        }
        public static DataTable DT_Catalog_SurgicalCrew()
        {
            return SurgeriesDAL.DT_Catalog_SurgicalCrew();
        }

        public static DataTable DT_SurgicalCrew(string sSurgeriesCode)
        {
            return SurgeriesDAL.DT_SurgicalCrew(sSurgeriesCode);
        }

        public static SurgeriesINF ObjSurgeriesForID(decimal dRowID)
        {
            return SurgeriesDAL.ObjSurgeriesForID(dRowID);
        }

        public static Int32 Ins(SurgeriesINF info, ref string sSurgeriesCode, decimal dSuggestedID)
        {
            return SurgeriesDAL.Ins(info, ref sSurgeriesCode, dSuggestedID);
        }

        public static Int32 InsSurgicalCrew(string sSurgeriesCode, string sEmployeeCode, Int32 iPositionCode)
        {
            return SurgeriesDAL.InsSurgicalCrew(sSurgeriesCode, sEmployeeCode, iPositionCode);
        }

        public static Int32 DelSurgicalCrew(string sSurgeriesCode)
        {
            return SurgeriesDAL.DelSurgicalCrew(sSurgeriesCode);
        }

        public static Int32 DelSurgeries(string sSurgeriesCode)
        {
            return SurgeriesDAL.DelSurgeries(sSurgeriesCode);
        }

        public static Int32 DucTin_DelSurgeries(string sSurgeriesCode)
        {
            return SurgeriesDAL.DucTin_DelSurgeries(sSurgeriesCode);
        }

        public static DataTable DT_RptViewSurgeries(string surgeriesCode, decimal patientReceiveID)
        {
            return SurgeriesDAL.DT_RptViewSurgeries(surgeriesCode, patientReceiveID);
        }

        public static string GetMedicalRecordCode(string sSurgeriesCode)
        {
            return SurgeriesDAL.GetMedicalRecordCode(sSurgeriesCode);
        }

        public static DataTable hsba_Surgeries(decimal dReceiveID, string sPatientCode)
        {
            return SurgeriesDAL.hsba_Surgeries(dReceiveID, sPatientCode);
        }

        public static DataTable hsba_SurgicalCrew(decimal dReceiveID, string sPatientCode)
        {
            return SurgeriesDAL.hsba_SurgicalCrew(dReceiveID, sPatientCode);
        }
    }
}
