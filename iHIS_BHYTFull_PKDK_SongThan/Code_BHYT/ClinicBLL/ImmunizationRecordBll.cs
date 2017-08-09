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
    public class ImmunizationRecordBll
    {
        public static List<ImmunizationRecordInf> ListImmunizationAll()
        {
            return ImmunizationRecordDal.ListImmunizationAll();
        }

        public static ImmunizationRecordInf ObjImmunization(string recordCode)
        {
            return ImmunizationRecordDal.ObjImmunization(recordCode);
        }

        public static bool InsImmunization(ImmunizationRecordInf info, ref string recordCode)
        {
            return ImmunizationRecordDal.InsImmunization(info, ref recordCode);
        }

        public static bool InsImmunizationDetail(ImmunizationRecordDetailInf info, ref string recordCode)
        {
            return ImmunizationRecordDal.InsImmunizationDetail(info, ref recordCode);
        }

        public static List<ImmunizationRecordDetailInf> ListImmunizationDetail(string recordCode)
        {
            return ImmunizationRecordDal.ListImmunizationDetail(recordCode);
        }

        public static DataTable TableImmunizationHistoryTimes(string serviceCode, string immunizationRecordCode, decimal patientReceiveID, string patientCode)
        {
            return ImmunizationRecordDal.TableImmunizationHistoryTimes(serviceCode, immunizationRecordCode, patientReceiveID, patientCode);
        }

        public static ImmunizationRecordDetailInf ObjImmunizationDetail(string recordDetailCode)
        {
            return ImmunizationRecordDal.ObjImmunizationDetail(recordDetailCode);
        }

        public static DataTable TableDoseNo()
        {
            return ImmunizationRecordDal.TableDoseNo();
        }

        public static DataTable TableRptViewImmunization(string recordCode, decimal patientReceiveID)
        {
            return ImmunizationRecordDal.TableRptViewImmunization(recordCode, patientReceiveID);
        }

        public static DataTable TableRptViewImmunizationDetail(string recordCode)
        {
            return ImmunizationRecordDal.TableRptViewImmunizationDetail(recordCode);
        }

        public static Int32 DelImmunization(string recordCode, string employeeCode, string recordDetailCode, decimal patientReceiveID)
        {
            return ImmunizationRecordDal.DelImmunization(recordCode, employeeCode, recordDetailCode, patientReceiveID);
        }

        public static Int32 DelImmunizationForMedical(string recordCode, string employeeCode, string recordDetailCode, decimal patientReceiveID, string medicalRecordCode)
        {
            return ImmunizationRecordDal.DelImmunizationForMedical(recordCode, employeeCode, recordDetailCode, patientReceiveID, medicalRecordCode);
        }

        public static Int32 UpdStatusImmunizationRecord(string employeeCode, decimal patientReceiveID, string immunizationCode)
        {
            return ImmunizationRecordDal.UpdStatusImmunizationRecord(employeeCode, patientReceiveID, immunizationCode);
        }
    }

    public class ImmunizationTimesDetailBLL
    {
        public static Int32 IUTimesDetail(ImmunizationTimesDetailInf info)
        {
            return ImmunizationTimesDetailDAL.IUTimesDetail(info);
        }

        public static DataTable TableTimesDetail(int timesEntryID)
        {
            return ImmunizationTimesDetailDAL.TableTimesDetail(timesEntryID);
        }

        public static Int32 DelTimesDetail(string serviceCode, int doseNoID, string employeeCode)
        {
            return ImmunizationTimesDetailDAL.DelTimesDetail(serviceCode, doseNoID, employeeCode);
        }
    }

    public class ImmunizationTimesEntryBLL
    {
        public static ImmunizationTimesEntryInf ObjTimesEntry(string serviceCode)
        {
            return ImmunizationTimesEntryDAL.ObjTimesEntry(serviceCode);
        }
        public static ImmunizationTimesEntryInf ObjTimesEntryID(int timesEntryID)
        {
            return ImmunizationTimesEntryDAL.ObjTimesEntryID(timesEntryID);
        }
        public static List<ImmunizationTimesEntryInf> ListTimesEntryAll()
        {
            return ImmunizationTimesEntryDAL.ListTimesEntryAll();
        }

        public static bool IUTimesEntry(ImmunizationTimesEntryInf info, ref int timesEntryIDTemp)
        {
            return ImmunizationTimesEntryDAL.IUTimesEntry(info, ref timesEntryIDTemp);
        }

        public static Int32 DelTimesEntry(string serviceCode, string employeeCode)
        {
            return ImmunizationTimesEntryDAL.DelTimesEntry(serviceCode, employeeCode);
        }

    }

}
