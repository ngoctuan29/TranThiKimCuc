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
    public class PatientReceiveBLL
    {
        public static List<PatientReceiveInf> ListPatientReceive(decimal rowid)
        {
            return PatientReceiveDal.List(rowid);
        }
        public static List<PatientReceive_ViewInf> ListPatientView(string sPatienCode, decimal dReceiveID)
        {
            return PatientReceiveDal.ListPatientView(sPatienCode, dReceiveID);
        }
        public static List<PatientReceive_ViewInf> ListPatientView(string patientCode)
        {
            return PatientReceiveDal.ListPatientView(patientCode);
        }
        public static List<PatientReceiveInf> ListForPatient(string patientCode)
        {
            return PatientReceiveDal.ListForPatient(patientCode);
        }
        public static List<PatientReceiveInf> ListCheckPatient(string patientCode)
        {
            return PatientReceiveDal.ListCheckPatient(patientCode);
        }
        public static int InsPatientReceive(PatientReceiveInf info, ref string refCode)
        {
            return PatientReceiveDal.Ins(info, ref refCode);
        }
        public static Int32 UpdPatientReceiveBarcode(decimal patientReceiveID, string patientCode, string barcode)
        {
            return PatientReceiveDal.UpdPatientReceiveBarcode(patientReceiveID, patientCode, barcode);
        }
        public static Int32 UpdPatientReceive(PatientReceiveInf info)
        {
            return PatientReceiveDal.InsUpd(info);
        }
        public static Int32 DelPatientReceive(decimal dPatientReceiveID, string sPatientCode)
        {
            return PatientReceiveDal.Del(dPatientReceiveID, sPatientCode);
        }
        public static Decimal GetPatientReceive(string patientCode, string referenceCode, DateTime dtWorking)
        {
            return PatientReceiveDal.GetPatientReceive(patientCode, referenceCode, dtWorking);
        }
        public static DataTable DTListPatientsSearch(string patientCode, string fullname, string age, string mobile, string tungay, string denngay)
        {
            return PatientReceiveDal.DTListPatientsSearch(patientCode, fullname, age, mobile, tungay, denngay);
        }
        public static DataTable TablePatientWaiting(DateTime dtimeFromDate, DateTime dtimeToDate, int istatus, int iPatientType, string sDepartCode, Int32 iPaid, string employeeCodeDoctor)
        {
            return PatientReceiveDal.TablePatientWaiting(dtimeFromDate, dtimeToDate, istatus, iPatientType, sDepartCode, iPaid, employeeCodeDoctor);
        }
        public static DataTable DT_WaitingEmergency(Int32 istatus, Int32 iPatientType, string sDepartCode, DateTime fromDate, DateTime toDate)
        {
            return PatientReceiveDal.DT_WaitingEmergency(istatus, iPatientType, sDepartCode, fromDate, toDate);
        }
        public static DataTable DT_WaitingService(DateTime dtime, int istatus, string sDepartCode, Int32 iPaid, Int32 iMenu)
        {
            return PatientReceiveDal.DT_WaitingService(dtime, istatus, sDepartCode, iPaid, iMenu);
        }
        public static DataTable DT_WaitingService(DateTime dtimeFrom, DateTime dtimeTo, Int32 istatus, string sDepartCode, Int32 iPaid, Int32 iMenu, string employeeCodeDoctor)
        {
            return PatientReceiveDal.DT_WaitingService(dtimeFrom, dtimeTo, istatus, sDepartCode, iPaid, iMenu, employeeCodeDoctor);
        }
        public static DataTable DT_WaitingServicePTT(DateTime dtimeFrom, DateTime dtimeTo, int istatus, string sDepartCode, Int32 iPaid, Int32 iMenu)
        {
            return PatientReceiveDal.DT_WaitingServicePTT(dtimeFrom, dtimeTo, istatus, sDepartCode, iPaid, iMenu);
        }

        public static DataTable DT_WaitingGetTemplate(DateTime dtime, Int32 istatus, string sDepartCode, Int32 iPaid, string sCategoryCode)
        {
            return PatientReceiveDal.DT_WaitingGetTemplate(dtime, istatus, sDepartCode, iPaid, sCategoryCode);
        }
        public static DataTable DataWaitingLaboratory(DateTime dateStart, DateTime dateEnd, int status, string idmau, int ipaid)
        {
            return PatientReceiveDal.DataWaitingLaboratory(dateStart, dateEnd, status, idmau, ipaid);
        }
        public static DataTable DT_PatientWaitingDetail(decimal dReceiveID, string sDepartmentCode, string sServiceCode)
        {
            return PatientReceiveDal.DT_PatientWaitingDetail(dReceiveID, sDepartmentCode, sServiceCode);
        }
        public static DataTable DT_PatientWaitingEmergency(decimal dReceiveID, decimal dSuggestedID)
        {
            return PatientReceiveDal.DT_PatientWaitingEmergency(dReceiveID, dSuggestedID);
        }
        public static DataTable DTCheckExistPatient(string sFullname, string sBirthday, string sGender, string sBirthyear, string sAge, string sAddress)
        {
            return PatientReceiveDal.DTCheckExistPatient(sFullname, sBirthday, sGender, sBirthyear, sAge, sAddress);
        }
        public static DataTable DT_StatisticReceive()
        {
            return PatientReceiveDal.DT_StatisticReceive();
        }
        public static DataTable DT_StatisticChart()
        {
            return PatientReceiveDal.DT_StatisticChart();
        }
        public static DataTable DT_ReportReceive(string sfrom, string sto, bool checkReceive, string groupCode, string serviceCode)
        {
            return PatientReceiveDal.DT_ReportReceive(sfrom, sto, checkReceive, groupCode, serviceCode);
        }
        public static DataTable DT_ListReportReceive(string sfrom, string sto, string groupCode, bool checkReceive, string serviceCode)
        {
            return PatientReceiveDal.DT_ListReportReceive(sfrom, sto, groupCode, checkReceive, serviceCode);
        }
        public static Int32 CheckPresentPatient(string patientCode, Int32 iCheck, decimal patientReceiveID, ref string sError)
        {
            return PatientReceiveDal.CheckPresentPatient(patientCode, iCheck, patientReceiveID, ref sError);
        }
        public static Int32 UpdPatientForStatus(decimal patientReceiveID, string patientCode, int status)
        {
            return PatientReceiveDal.UpdPatientForStatus(patientReceiveID, patientCode, status);
        }
        public static Int32 UpdPatientForStatus(string dateFrom, string dateTo, int status)
        {
            return PatientReceiveDal.UpdPatientForStatus(dateFrom, dateTo, status);
        }
        public static Int32 UpdPatientForStatus(string patientCode, int status)
        {
            return PatientReceiveDal.UpdPatientForStatus(patientCode, status);
        }
        public static Int32 DelEmergencyOut(string sPatientCode, decimal dPatientReceiveID)
        {
            return PatientReceiveDal.DelEmergencyOut(sPatientCode, dPatientReceiveID);
        }
        public static DataTable DT_View_PatientReceive(DateTime dtfrDate, DateTime dttoDate, Int32 iType, string sms)
        {
            return PatientReceiveDal.DT_View_PatientReceive(dtfrDate, dttoDate, iType, sms);
        }
        public static DataTable DT_View_ListReportReceive(string startDate, string endDate)
        {
            return PatientReceiveDal.DT_View_ListReportReceive(startDate, endDate);
        }
        public static DataTable TableWaitingServiceImmunization(DateTime dtFrom, DateTime dtTo, Int32 status, string departmentCode, Int32 paid, Int32 menu)
        {
            return PatientReceiveDal.TableWaitingServiceImmunization(dtFrom, dtTo, status, departmentCode, paid, menu);
        }
        public static DataTable TableTypeReceive()
        {
            return PatientReceiveDal.TableTypeReceive();
        }
        public static DataTable hsba_DTReceive(decimal dReceiveID, string sPatientCode)
        {
            return PatientReceiveDal.hsba_DTReceive(dReceiveID, sPatientCode);
        }
        public static Int32 UpdPatientReceiveForReason(decimal patientReceiveID, string patientCode, string reason)
        {
            return PatientReceiveDal.UpdPatientReceiveForReason(patientReceiveID, patientCode, reason);
        }
        public static List<PatientReceive_ViewInf> ListForPatient(string patientCode, string dateInto)
        {
            return PatientReceiveDal.ListForPatient(patientCode, dateInto);
        }
        public static Int32 UpdPatientReceiveConfirmBV01(string patientReceiveID, int confirmBV01)
        {
            return PatientReceiveDal.UpdPatientReceiveConfirmBV01(patientReceiveID, confirmBV01);
        }
        public static Int32 UpdPatientInfo(decimal patientReceiveID, string patientCode, int eThnicID, string careerCode, int nationalityID, string provincialCode, string districtCode, string wardCode, string companyInfo, string address, DateTime patientBirthday, int patientAge, int patientBirthyear)
        {
            return PatientReceiveDal.UpdPatientInfo(patientReceiveID, patientCode, eThnicID, careerCode, nationalityID, provincialCode, districtCode, wardCode, companyInfo, address, patientBirthday, patientAge, patientBirthyear);
        }
        public static DataTable ViewListIDAppointment()
        {
            return PatientReceiveDal.ViewListIDAppointment();
        }
        public static DataTable DT_View_PatientReceiveForDate(DateTime dtimeFrom, DateTime dtimeTo, Int32 status)
        {
            return PatientReceiveDal.DT_View_PatientReceiveForDate(dtimeFrom, dtimeTo, status);
        }
    }
}
