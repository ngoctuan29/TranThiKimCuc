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
    public class BanksAccountDetailBLL
    {
        public static Int32 Ins(BanksAccountDetailInf info)
        {
            return BanksAccountDetailDal.Ins(info);
        }
        public static Int32 InsForMedical(BanksAccountDetailInf info)
        {
            return BanksAccountDetailDal.InsForMedical(info);
        }
        public static Int32 Upd_Paid_MedicalRecord(string sMedicalCode, Int32 iPaid, string sBankCode)
        {
            return BanksAccountDetailDal.Upd_Paid_MedicalRecord(sMedicalCode, iPaid, sBankCode);
        }

        public static DataTable TableBanksTotal(string banksAccountCode, Int32 cancel, decimal patientReceiveID)
        {
            return BanksAccountDetailDal.TableBanksTotal(banksAccountCode, cancel, patientReceiveID);
        }

        public static DataTable TableBanksTotalForInvoice(string banksAccountCode, Int32 cancel, decimal patientReceiveID)
        {
            return BanksAccountDetailDal.TableBanksTotalForInvoice(banksAccountCode, cancel, patientReceiveID);
        }
        public static DataTable TableBanksTotalForInvoice(decimal patientReceiveID, int objectCode)
        {
            return BanksAccountDetailDal.TableBanksTotalForInvoice(patientReceiveID, objectCode);
        }
        public static DataTable DT_BanksTotalBV01(string sPatientCode, decimal dPatientReceive, Int32 iCancel)
        {
            return BanksAccountDetailDal.DT_BanksTotalBV01(sPatientCode, dPatientReceive, iCancel);
        }
        public static DataTable DT_View_Treatment_Info(string sPatientCode, decimal dPatientReceive)
        {
            return BanksAccountDetailDal.DT_View_Treatment_Info(sPatientCode, dPatientReceive);
        }
        public static DataTable DT_View_Treatment_Emergency(string sPatientCode, decimal dPatientReceive, string sMedicalEmergencyCode)
        {
            return BanksAccountDetailDal.DT_View_Treatment_Emergency(sPatientCode, dPatientReceive, sMedicalEmergencyCode);
        }
        public static DataTable DT_GetBank_Service_Done(decimal dRefID, string sPatientCode, string sBanksCode)
        {
            return BanksAccountDetailDal.DT_GetBank_Service_Done(dRefID, sPatientCode, sBanksCode);
        }

        public static DataTable TableBanksTotal_TotalGroupDate(Int32 cancel, string patientCode, DateTime dtPosting)
        {
            return BanksAccountDetailDal.TableBanksTotal_TotalGroupDate(cancel, patientCode, dtPosting);
        }

        public static DataTable Table_GetBankServiceDoneForInvoice(decimal patientReceiveID, string patientCode)
        {
            return BanksAccountDetailDal.Table_GetBankServiceDoneForInvoice(patientReceiveID, patientCode);
        }

        public static DataTable TableBanksTotalForInvoiceTop(string sPatientCode, Int32 cancel, decimal patientReceiveID)
        {
            return BanksAccountDetailDal.TableBanksTotalForInvoiceTop(sPatientCode, cancel, patientReceiveID);
        }

        public static DataTable Table_GetBank_Service_DoneGeneral(decimal patientReceiveID, string patientCode, string banksAccountCode)
        {
            return BanksAccountDetailDal.Table_GetBank_Service_DoneGeneral(patientReceiveID, patientCode, banksAccountCode);
        }
        
        public static DataTable DT_GetBank_Service_BV01(decimal dRefID, string sPatientCode, Int32 iCancel)
        {
            return BanksAccountDetailDal.DT_GetBank_Service_BV01(dRefID, sPatientCode, iCancel);
        }
        public static DataTable DT_View_Treatment_Costs(decimal dRefID, string sPatientCode)
        {
            return BanksAccountDetailDal.DT_View_Treatment_Costs(dRefID, sPatientCode);
        }
        public static DataTable DT_View_Treatment_OutPatient(string patientCode, decimal patientReceive)
        {
            return BanksAccountDetailDal.DT_View_Treatment_OutPatient(patientCode, patientReceive);
        }
    }
}
