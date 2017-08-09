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
    public class ServiceLaboratoryEntryBLL
    {
        public static Int32 InsLaboratoryEntry(ServiceLaboratoryEntryINF info, ref decimal refID)
        {
            return ServiceLaboratoryEntryDAL.InsLaboratoryEntry(info, ref refID);
        }
        public static Int32 UpdLaboratoryEntry(decimal dRowID, Int32 iStatus)
        {
            return ServiceLaboratoryEntryDAL.UpdLaboratoryEntry(dRowID, iStatus);
        }
        public static Int32 InsLaboratoryDetail(ServiceLaboratoryDetailINF info, Int32 iStatus)
        {
            return ServiceLaboratoryEntryDAL.InsLaboratoryDetail(info, iStatus);
        }
        public static Int32 UpdSuggestedServiceReceipt(decimal dIDLaboratoryEnTry, Int32 iStatus)
        {
            return ServiceLaboratoryEntryDAL.UpdSuggestedServiceReceipt(dIDLaboratoryEnTry, iStatus);
        }
        public static Int32 ClearResultLaboratoryDetail(decimal dIDLaboratoryEnTry)
        {
            return ServiceLaboratoryEntryDAL.ClearResultLaboratoryDetail(dIDLaboratoryEnTry);
        }
        public static Int32 DelLaboratoryDetail(decimal dRowIDLaboratoryEnTry)
        {
            return ServiceLaboratoryEntryDAL.DelLaboratoryDetail(dRowIDLaboratoryEnTry);
        }
        public static Int32 DelLaboratory(decimal rowIDLaboratoryEnTry)
        {
            return ServiceLaboratoryEntryDAL.DelLaboratory(rowIDLaboratoryEnTry);
        }
        public static Int32 DelLaboratoryTemplate(decimal dRowID)
        {
            return ServiceLaboratoryEntryDAL.DelLaboratoryTemplate(dRowID);
        }

        public static DataTable DTListPrevious(string sPatientCode, string sServiceCategoryCode)
        {
            return ServiceLaboratoryEntryDAL.DTListPrevious(sPatientCode, sServiceCategoryCode);
        }

        public static DataTable DT_Get_LaboratoryPackageDetail(decimal dPatientReceive, string sPatientCode, string sReferenceCode, Int32 iStatus, string sServiceCategoryCode, decimal dRowIDLaboratory, string departmentCodeOrder)
        {
            return ServiceLaboratoryEntryDAL.DT_Get_LaboratoryPackageDetail(dPatientReceive, sPatientCode, sReferenceCode, iStatus, sServiceCategoryCode, dRowIDLaboratory, departmentCodeOrder);
        }

        public static DataTable TableLabServiceTemplate(decimal patientReceive, string patientCode, string referenceCode, string serviceGroupCode, string serviceCategoryCode, Int32 status)
        {
            return ServiceLaboratoryEntryDAL.TableLabServiceTemplate(patientReceive, patientCode, referenceCode, serviceGroupCode, serviceCategoryCode, status);
        }

        public static DataTable DT_Get_LaboratoryPackageDetailForSTTDate(string stt, DateTime postingDate)
        {
            return ServiceLaboratoryEntryDAL.DT_Get_LaboratoryPackageDetailForSTTDate(stt, postingDate);
        }

        public static DataTable DTResultLaboratoryForSuggested(decimal refSuggestedID)
        {
            return ServiceLaboratoryEntryDAL.DTResultLaboratoryForSuggested(refSuggestedID);
        }
        public static ServiceLaboratoryEntryINF ObjLaboratoryEntry(decimal dRowID)
        {
            return ServiceLaboratoryEntryDAL.ObjLaboratoryEntry(dRowID);
        }
        public static DataTable TableResultLaboratory(string dRowID, string referenceCode, string categoryCode, decimal patientReceiveID)
        {
            return ServiceLaboratoryEntryDAL.TableResultLaboratory(dRowID, referenceCode, categoryCode, patientReceiveID);
        }
        public static DataTable DTResultLaboratoryDetail(string rowIDLaboratoryEnTry)
        {
            return ServiceLaboratoryEntryDAL.TableResultLaboratoryDetail(rowIDLaboratoryEnTry);
        }

        public static DataTable TableResultLaboratoryDetailForPrinter(string rowIDLaboratoryEnTry, decimal patientReceiveID)
        {
            return ServiceLaboratoryEntryDAL.TableResultLaboratoryDetailForPrinter(rowIDLaboratoryEnTry, patientReceiveID);
        }
        public static decimal GetRowIDLaboratoryEnTry(decimal receiptID)
        {
            return ServiceLaboratoryEntryDAL.GetRowIDLaboratoryEnTry(receiptID);
        }

        public static Int32 GetSTT(string serviceCategoryCode)
        {
            return ServiceLaboratoryEntryDAL.GetSTT(serviceCategoryCode);
        }

        public static Int32 GetIDPatternForReceive(string serviceCategoryCode, string patientCode, decimal patientReceiveID, int labPathologicalID)
        {
            return ServiceLaboratoryEntryDAL.GetIDPatternForReceive(serviceCategoryCode, patientCode, patientReceiveID, labPathologicalID);
        }

        public static bool ExistsSTTForLaboratory(string serviceCategoryCode, Int32 stt)
        {
            return ServiceLaboratoryEntryDAL.ExistsSTTForLaboratory(serviceCategoryCode, stt);
        }

        public static DataTable DT_ListResultLabEntry(string sPatientCode, decimal dReceive)
        {
            return ServiceLaboratoryEntryDAL.DT_ListResultLabEntry(sPatientCode, dReceive);
        }
        public static DataTable hsba_LaboratoryEntry(string sPatientCode, decimal dReceive)
        {
            return ServiceLaboratoryEntryDAL.hsba_LaboratoryEntry(sPatientCode, dReceive);
        }
        public static DataTable hsba_LaboratoryEntrydetail(string sPatientCode, decimal dReceive)
        {
            return ServiceLaboratoryEntryDAL.hsba_LaboratoryEntrydetail(sPatientCode, dReceive);
        }
        public static LabAppointmentForResultsInf ObjLabAppointmentForResults(decimal patientReceiveID, string serviceCategoryCode)
        {
            return ServiceLaboratoryEntryDAL.ObjLabAppointmentForResults(patientReceiveID, serviceCategoryCode);
        }
        public static DataTable DT_ListResultLabSend(string frdate, string todate)
        {
            return ServiceLaboratoryEntryDAL.DT_ListResultLabSend(frdate, todate);
        }
        public static DataTable TableListServiceLaboratory(string dtFrom, string dtTo)
        {
            return ServiceLaboratoryEntryDAL.TableListServiceLaboratory(dtFrom, dtTo);
        }
        public static DataTable TableListServiceLaboratoryAppointment(decimal patientReceiveID, int status, int sampleTransfer, string serviceCategoryCode)
        {
            return ServiceLaboratoryEntryDAL.TableListServiceLaboratoryAppointment(patientReceiveID, status, sampleTransfer, serviceCategoryCode);
        }
        public static Int32 InsLabAppointment(LabAppointmentForResultsInf info)
        {
            return ServiceLaboratoryEntryDAL.InsLabAppointment(info);
        }
        public static Int32 DelLabAppointment(decimal patientReceiveID, string serviceCategoryCode)
        {
            return ServiceLaboratoryEntryDAL.DelLabAppointment(patientReceiveID, serviceCategoryCode);
        }
        public static DataTable TableReport_ServiceLabAppointment(decimal patientReceiveID, string serviceCategoryCode)
        {
            return ServiceLaboratoryEntryDAL.TableReport_ServiceLabAppointment(patientReceiveID, serviceCategoryCode);
        }
        
        public static DataTable GetResultLaboratoryForReceiveID(decimal patientReceiveID, string patientCode)
        {
            return ServiceLaboratoryEntryDAL.GetResultLaboratoryForReceiveID(patientReceiveID, patientCode);
        }
    }
}
