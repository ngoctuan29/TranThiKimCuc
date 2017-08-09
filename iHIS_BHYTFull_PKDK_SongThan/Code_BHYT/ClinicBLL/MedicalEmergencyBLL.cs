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
    public class MedicalEmergencyBLL
    {
        public static Int32 InsMedicalEmergency(MedicalEmergencyINF info, ref string sMedicalCode, decimal dSuggestedID)
        {
            return MedicalEmergencyDAL.InsMedicalEmergency(info, ref sMedicalCode, dSuggestedID);
        }
        public static Int32 InsMedicalEmergencyOut(MedicalEmergencyOutINF info, ref string sMedicalCodeOut)
        {
            return MedicalEmergencyDAL.InsMedicalEmergencyOut(info, ref sMedicalCodeOut);
        }
        public static List<TreatmentResultsINF> lstResults()
        {
            return MedicalEmergencyDAL.lstResults();
        }
        public static MedicalEmergencyINF ObjEmergency(string sMedicalCode)
        {
            return MedicalEmergencyDAL.ObjEmergency(sMedicalCode);
        }
        public static MedicalEmergencyINF ObjEmergency(string refPatientCode, decimal refReceiveID)
        {
            return MedicalEmergencyDAL.ObjEmergency(refPatientCode, refReceiveID);
        }
        public static MedicalEmergencyOutINF ObjEmergencyOut(string sMedicalCode)
        {
            return MedicalEmergencyDAL.ObjEmergencyOut(sMedicalCode);
        }
        public static DataTable DataViewMedicinesPatientEmergency(string startDate, string endDate, string patientCode, string itemCode)
        {
            return MedicalEmergencyDAL.DataViewMedicinesPatientEmergency(startDate, endDate, patientCode, itemCode);
        }
        
        public static DataTable hsba_MedicalEmergency(decimal dReceiveID, string sPatientCode)
        {
            return MedicalEmergencyDAL.hsba_MedicalEmergency(dReceiveID, sPatientCode);
        }
        public static DataTable hsba_MedicalEmergencyout(decimal dReceiveID, string sPatientCode)
        {
            return MedicalEmergencyDAL.hsba_MedicalEmergencyout(dReceiveID, sPatientCode);
        }
    }
}
