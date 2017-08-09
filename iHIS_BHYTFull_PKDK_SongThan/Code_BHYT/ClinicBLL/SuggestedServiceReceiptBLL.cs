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
    public class SuggestedServiceReceiptBLL
    {
        public static List<SuggestedServiceReceiptInf> List(decimal dRowid)
        {
            return SuggestedServiceReceiptDal.List(dRowid);
        }
        public static List<SuggestedServiceReceiptInf> SuggestedServiceReceipt(string sNote, decimal dRefID, string sPatientCode)
        {
            return SuggestedServiceReceiptDal.SuggestedServiceReceipt(sNote, dRefID, sPatientCode);
        }
        public static DataTable DTListForPatientReceiveHSBA(decimal dRefId, string sPatientCode, string snote)
        {
            return SuggestedServiceReceiptDal.DTListForPatientReceiveHSBA(dRefId, sPatientCode, snote);
        }

        public static DataTable DTListForPatientServiceHSBA(decimal dRefId, string sPatientCode)
        {
            return SuggestedServiceReceiptDal.DTListForPatientServiceHSBA(dRefId, sPatientCode);
        }

        public static DataTable DTListForGroupServiceHSBA(decimal dRefId, string sPatientCode, string sDepartmentCode)
        {
            return SuggestedServiceReceiptDal.DTListForGroupServiceHSBA(dRefId, sPatientCode, sDepartmentCode);
        }

        public static List<SuggestedServiceReceiptInf> ListForPatientCode(string sPatientCode, int iType)
        {
            return SuggestedServiceReceiptDal.ListForPatientCode(sPatientCode, iType);
        }
        public static DataTable DTListForPatientReceiveId(decimal dRefId, string sPatientCode, int iPatientType, string snote, string sDate, string sReferenceCode)
        {
            return SuggestedServiceReceiptDal.DTListForPatientReceiveId(dRefId, sPatientCode, iPatientType, snote, sDate, sReferenceCode);
        }
        public static DataTable DTListReceiveIdGroupDate(decimal dRefId, string sPatientCode, int iPatientType)
        {
            return SuggestedServiceReceiptDal.DTListReceiveIdGroupDate(dRefId, sPatientCode, iPatientType);
        }
        public static DataTable DTListForPatientReceivePre(decimal dRefId, string sPatientCode, int iPatientType, string snote, string sDate)
        {
            return SuggestedServiceReceiptDal.DTListForPatientReceivePre(dRefId, sPatientCode, iPatientType, snote, sDate);
        }

        public static int Ins(SuggestedServiceReceiptInf info)
        {
            return SuggestedServiceReceiptDal.Ins(info);
        }
        public static int Ins(SuggestedServiceReceiptInf info, int statusDepartment)
        {
            return SuggestedServiceReceiptDal.Ins(info, statusDepartment);
        }
        public static Int32 InsReceive(SuggestedServiceReceiptInf info)
        {
            return SuggestedServiceReceiptDal.InsReceive(info);
        }

        public static int Del(decimal dId, ref string refResult)
        {
            try
            {
                if (dId > 0)
                {
                    int iResult = SuggestedServiceReceiptDal.Del(dId);
                    if (iResult == -1)
                        refResult = "Dịch vụ đã thực hiện! Không được phép xóa.";
                    else if (iResult == -2)
                        refResult = "Dịch vụ đã đóng tiền! Không được phép xóa.";
                    else if (iResult == -3)
                        refResult = "Dịch vụ có đính kèm Thuốc - VTTH đã đuyệt, không được phép xóa.";
                    else if (iResult == 0)
                        refResult = string.Empty;
                    else if (iResult == 1)
                        refResult = "Xóa thành công!";
                    return iResult;
                }
                else
                    return 0;
            }
            catch { return -3; }
        }

        public static DataTable DT_Danhsachchidinh(decimal refID, string patientCode, string receiptID, string referenceCode, string date, Int32 patientType, string serviceGroupCode)
        {
            return SuggestedServiceReceiptDal.DT_Danhsachchidinh(refID, patientCode, receiptID, referenceCode, date, patientType, serviceGroupCode);
        }
        public static DataTable DT_ChidinhPK(decimal dRefID, string sPatientCode)
        {
            return SuggestedServiceReceiptDal.DT_ChidinhPK(dRefID, sPatientCode);
        }
        public static decimal dTotalService(decimal dRefID, string sPatientCode, ref decimal dDisparity)
        {
            return SuggestedServiceReceiptDal.dTotalService(dRefID, sPatientCode, ref dDisparity);
        }
        public static DataTable DT_TotalServiceForGroup(decimal dRefID, string sPatientCode)
        {
            return SuggestedServiceReceiptDal.DT_TotalServiceForGroup(dRefID, sPatientCode);
        }
        public static List<SuggestedViewInf> ListView(string sPatientCode, decimal dReceiveID, Int32 iPaid, string sBankCode, decimal amountBHYTtemp, decimal BHYTUnderPrice)
        {
            return SuggestedServiceReceiptDal.ListView(sPatientCode, dReceiveID, iPaid, sBankCode, amountBHYTtemp, BHYTUnderPrice);
        }
        public static List<SuggestedViewInf> ListViewForBV01(string patientCode, string receiveID, int done, string reportID, int iPaid)
        {
            return SuggestedServiceReceiptDal.ListViewForBV01(patientCode, receiveID, done, reportID,iPaid);
        }
        public static List<SuggestedViewMedicinesInf> ListMedicalView(string sPatientCode, decimal dReceiveID, Int32 iPaid, string sBankCode,decimal amountBHYTtemp, decimal BHYTUnderPrice)
        {
            return SuggestedServiceReceiptDal.ListMedicalView(sPatientCode, dReceiveID, iPaid, sBankCode, amountBHYTtemp, BHYTUnderPrice);
        }
        public static List<SuggestedViewMedicinesBV01Inf> ListMedicalViewForBV01(string patientCode, string receiveID, Int32 paid, string reportID)
        {
            return SuggestedServiceReceiptDal.ListMedicalViewForBV01(patientCode, receiveID, paid, reportID);
        }
        public static DataTable DTListServiceGroupDepartmentOrder(decimal dRefId, string sPatientCode, int iPatientType, string sDate, string sDepartmenrCodeOrder)
        {
            return SuggestedServiceReceiptDal.DTListServiceGroupDepartmentOrder(dRefId, sPatientCode, iPatientType, sDate, sDepartmenrCodeOrder);
        }
        public static DataTable DTGetServiceOld(decimal dRefId, string sPatientCode, int iPatientType, string snote, string sDate, string sDepartMentCode)
        {
            return SuggestedServiceReceiptDal.DTGetServiceOld(dRefId, sPatientCode, iPatientType, snote, sDate, sDepartMentCode);
        }

        public static DataTable DTListReceiveIdGroupDepartmentOrder(decimal dRefId, string sPatientCode, int iPatientType, string sDate)
        {
            return SuggestedServiceReceiptDal.DTListReceiveIdGroupDepartmentOrder(dRefId, sPatientCode, iPatientType, sDate);
        }

        public static Int32 UpdChangeDepartment(string departmentCode, string patientCode, decimal patientReceiveID, string serviceCode, string serviceCodeNew)
        {
            return SuggestedServiceReceiptDal.UpdChangeDepartment(departmentCode, patientCode, patientReceiveID, serviceCode, serviceCodeNew);
        }
        public static Int32 UpdStatusAppointment(decimal receiptID, int status)
        {
            return SuggestedServiceReceiptDal.UpdStatusAppointment(receiptID, status);
        }
        public static DataTable TableListServiceFor(decimal refId, string patientCode)
        {
            return SuggestedServiceReceiptDal.TableListServiceFor(refId, patientCode);
        }

        public static DataTable hsba_Suggested(decimal dRefId, string sPatientCode)
        {
            return SuggestedServiceReceiptDal.hsba_Suggested(dRefId, sPatientCode);
        }

        public static Int32 UpdSuggestedForEmployeeDoctor(decimal receiptID, string employeeCodeDoctor)
        {
            return SuggestedServiceReceiptDal.UpdSuggestedForEmployeeDoctor(receiptID, employeeCodeDoctor);
        }
        public static DataTable CheckTotalBHYT(decimal dPatientReceiveID)
        {
            return SuggestedServiceReceiptDal.CheckTotalBHYT(dPatientReceiveID);
        }
        public static DataTable GetThongKeKhamBenhTheoAppointment247(DateTime fromdate, DateTime todate)
        {
            return SuggestedServiceReceiptDal.GetThongKeKhamBenhTheoAppointment247(fromdate, todate);
        }

    }
}
