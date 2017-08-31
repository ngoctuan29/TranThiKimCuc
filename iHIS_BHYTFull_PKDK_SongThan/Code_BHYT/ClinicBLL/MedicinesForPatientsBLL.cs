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
    public class MedicinesForPatientsBLL
    {
        public static List<MedicinesForPatients> MedicinesForPatients(string sMedicinesCode)
        {
            return MedicinesForPatientsDal.MedicinesForPatients(sMedicinesCode);
        }
        public static Int32 Ins(MedicinesForPatients info, ref decimal dRowIDMedicines)
        {
            return MedicinesForPatientsDal.Ins(info, ref dRowIDMedicines);
        }
        public static Int32 Del(string sMedicalCode, decimal dRowIDMedicines, string employeeCode)
        {
            return MedicinesForPatientsDal.Del(sMedicalCode, dRowIDMedicines, employeeCode);
        }
        public static Int32 InsDetail(MedicinesForPatientsDetail info)
        {
            return MedicinesForPatientsDal.InsDetail(info);
        }
        public static DataTable DT_StatisticMedicinesForPatients(DateTime dtfrom, DateTime dtto)
        {
            return MedicinesForPatientsDal.DT_StatisticMedicinesForPatients(dtfrom, dtto);
        }
        public static DataTable hsba_MedicinesForPatients(decimal dReceiveID, string sPatientCode)
        {
            return MedicinesForPatientsDal.hsba_MedicinesForPatients(dReceiveID, sPatientCode);
        }
        public static DataTable hsba_MedicinesForPatientsdetail(decimal dReceiveID, string sPatientCode)
        {
            return MedicinesForPatientsDal.hsba_MedicinesForPatientsdetail(dReceiveID, sPatientCode);
        }
        public static Int32 UpdForDone(string medicalCode, decimal rowIDMedicines, string employeeCodeDone, int done, decimal patientReceiveID)
        {
            return MedicinesForPatientsDal.UpdForDone(medicalCode, rowIDMedicines, employeeCodeDone, done, patientReceiveID);
        }
        public static DataTable TablePrintMedicinesForPatients(string rowid)
        {
            return MedicinesForPatientsDal.TablePrintMedicinesForPatients(rowid);
        }

        public static Int32 MedicinesForPatients_ReceiveIns(MedicinesForPatients_ReceiveINF info)
        {
            return MedicinesForPatientsDal.MedicinesForPatients_ReceiveIns(info);
        }

        public static bool UpdateDone(decimal patientRe, int done)
        {
            return MedicinesForPatientsDal.UpdateDone(patientRe,done);
        }
    }
}
