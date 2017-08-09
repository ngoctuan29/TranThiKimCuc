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
    public class RealMedicinesForPatientsBLL
    {
        public static List<RealMedicinesForPatientsINF> ListForPatients(string sRefCode, decimal dPatientReceiveID, string sPatientCode)
        {
            return RealMedicinesForPatientsDAL.ListForPatients(sRefCode, dPatientReceiveID, sPatientCode);
        }

        public static List<RealMedicinesForPatientsINF> ListForPatientsHistory(string sRefCode, decimal dPatientReceiveID, string sPatientCode)
        {
            return RealMedicinesForPatientsDAL.ListForPatientsHistory(sRefCode, dPatientReceiveID, sPatientCode);
        }

        public static Int32 InsReal(RealMedicinesForPatientsINF info, ref decimal dRowID)
        {
            return RealMedicinesForPatientsDAL.InsReal(info, ref dRowID);
        }
        public static Int32 InsRealDetail(RealMedicinesForPatientsDetailINF info)
        {
            return RealMedicinesForPatientsDAL.InsRealDetail(info);
        }
        public static Int32 DelRealDetailAll(decimal dRealID)
        {
            return RealMedicinesForPatientsDAL.DelRealDetailAll(dRealID);
        }
        public static Int32 DelRealDetailOnly(decimal dRealID)
        {
            return RealMedicinesForPatientsDAL.DelRealDetailOnly(dRealID);
        }
        public static Int32 DelRealDetailForItems(decimal dRealID, string sItemCode, decimal dRowID)
        {
            return RealMedicinesForPatientsDAL.DelRealDetailForItems(dRealID, sItemCode, dRowID);
        }
        public static DataTable DTRealMedicines(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, DateTime dtNow)
        {
            return RealMedicinesForPatientsDAL.DTRealMedicines(sRefCode, iObjectCode, sDepartCode, iGroup, dtNow);
        }
                
        public static DataTable DTRealMedicines(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup)
        {
            return RealMedicinesForPatientsDAL.DTRealMedicines(sRefCode, iObjectCode, sDepartCode, iGroup);
        }

        public static DataTable DTRealMedicinesForEmergency(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, DateTime dtNow, ref decimal dRealID)
        {
            return RealMedicinesForPatientsDAL.DTRealMedicinesForEmergency(sRefCode, iObjectCode, sDepartCode, iGroup, dtNow,ref dRealID);
        }

        public static DataTable DTRealMedicinesCoppy(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, string dtNow)
        {
            return RealMedicinesForPatientsDAL.DTRealMedicinesCoppy(sRefCode, iObjectCode, sDepartCode, iGroup, dtNow);
        }
        public static Int32 UpdReal_Bank(string sBankCode, string sRefCode, decimal dPatientReceive, string sPatientCode)
        {
            return RealMedicinesForPatientsDAL.UpdReal_Bank(sBankCode, sRefCode, dPatientReceive, sPatientCode);
        }
        public static DataTable DT_RealMedicinesEmergency(string sMedicalEmergencyCode, string sPatientCode, decimal dPatientReceiveID, Int32 patientType)
        {
            return RealMedicinesForPatientsDAL.DT_RealMedicinesEmergency(sMedicalEmergencyCode, sPatientCode, dPatientReceiveID, patientType);
        }
        public static DataTable DTRealMedicinesForEmergency(decimal dRealRowID)
        {
            return RealMedicinesForPatientsDAL.DTRealMedicinesForEmergency(dRealRowID);
        }
        public static DataTable DTRealMedicinesForEmergencyCoppy(decimal dRealRowID)
        {
            return RealMedicinesForPatientsDAL.DTRealMedicinesForEmergencyCoppy(dRealRowID);
        }
        public static DataTable DT_RealMedicinesEmergencyDetail(string sMedicalEmergencyCode, string sPatientCode, decimal dPatientReceiveID, DateTime refDate)
        {
            return RealMedicinesForPatientsDAL.DT_RealMedicinesEmergencyDetail(sMedicalEmergencyCode, sPatientCode, dPatientReceiveID, refDate);
        }
        public static DataTable DT_RealMedicinesEmergencyDetail(decimal realID, int objectCode, bool groupby)
        {
            return RealMedicinesForPatientsDAL.DT_RealMedicinesEmergencyDetail(realID, objectCode, groupby);
        }
        public static DataTable DTTemplateNorms(string sDepartCode, Int32 iGroup, decimal RowIDLab)
        {
            return RealMedicinesForPatientsDAL.DTTemplateNorms(sDepartCode, iGroup, RowIDLab);
        }
        public static DataTable hsba_RealMedicines(decimal dReceiveID, string sPatientCode)
        {
            return RealMedicinesForPatientsDAL.hsba_RealMedicines(dReceiveID, sPatientCode);
        }
        public static DataTable hsba_RealMedicinesdetail(decimal dReceiveID, string sPatientCode)
        {
            return RealMedicinesForPatientsDAL.hsba_RealMedicinesdetail(dReceiveID, sPatientCode);
        }
    }
}
