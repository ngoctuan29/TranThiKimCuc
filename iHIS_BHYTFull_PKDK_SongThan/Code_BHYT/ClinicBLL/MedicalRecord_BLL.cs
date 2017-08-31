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
    public class MedicalRecord_BLL
    {
        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, string repositoryGroup, DateTime dtNow)
        {
            return MedicalRecord_DAL.DTMedicalRecord(sMedicalCode, iObjectCode, sDepartCode, repositoryGroup, dtNow);
        }

        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, string repositoryGroup, int status)
        {
            return MedicalRecord_DAL.DTMedicalRecord(sMedicalCode, iObjectCode, sDepartCode, repositoryGroup, status);
        }
        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, string repositoryGroup)
        {
            return MedicalRecord_DAL.DTMedicalRecord(sMedicalCode, iObjectCode, sDepartCode, repositoryGroup);
        }
        public static DataTable DTMedicalRecordForSuggestedID(decimal receiptID, string repositoryGroup)
        {
            return MedicalRecord_DAL.DTMedicalRecordForSuggestedID(receiptID, repositoryGroup);
        }
        public static MedicalRecord_INF ObjMedicalRecordForSuggestedID(decimal suggestedID, decimal receiveID)
        {
            return MedicalRecord_DAL.ObjMedicalRecordForSuggestedID(suggestedID, receiveID);
        }
        public static DataTable DTMedicalAttachItem(string serviceCode)
        {
            return MedicalRecord_DAL.DTMedicalAttachItem(serviceCode);
        }
        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, bool bCheck, Int32 typeMedical)
        {
            return MedicalRecord_DAL.DTMedicalRecord(sMedicalCode, iObjectCode, sDepartCode, iGroup, bCheck, typeMedical);
        }
        public static List<MedicalRecord_INF> ListMedicalRecordForPatientCode(string patientCode, DateTime postingDate)
        {
            return MedicalRecord_DAL.ListMedicalRecordForPatientCode(patientCode, postingDate);
        }
        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, bool bCheck, string sDate)
        {
            return MedicalRecord_DAL.DTMedicalRecord(sMedicalCode, iObjectCode, sDepartCode, iGroup, bCheck, sDate);
        }

        public static DataTable DTMedicalRecordSurgeries(string sSurgeriesCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, bool bCheck, string sDate)
        {
            return MedicalRecord_DAL.DTMedicalRecordSurgeries(sSurgeriesCode, iObjectCode, sDepartCode, iGroup, bCheck, sDate);
        }

        public static DataTable DTMedicalRecordOld(string sMedicalCode)
        {
            return MedicalRecord_DAL.DTMedicalRecordOld(sMedicalCode);
        }
        public static DataTable DTMedicalRecordApprove(string sMedicalCode, Int32 objectCode, string sRepCode, Int32 iStatus, decimal dRowIDMedicines)
        {
            return MedicalRecord_DAL.DTMedicalRecordApprove(sMedicalCode, objectCode, sRepCode, iStatus, dRowIDMedicines);
        }
        public static DataTable DTMedicalRecordApprove(string sMedicalCode, Int32 objectCode, string sRepCode, Int32 iStatus, decimal dRowIDMedicines, int objectCode_Medical)
        {
            return MedicalRecord_DAL.DTMedicalRecordApprove(sMedicalCode, objectCode, sRepCode, iStatus, dRowIDMedicines, objectCode_Medical);
        }

        public static DataTable DTMedicalRecordApproveDV(string sMedicalCode, Int32 objectCode, string sRepCode, Int32 iStatus, decimal dRowIDMedicines, int objectCode_Medical)
        {
            return MedicalRecord_DAL.DTMedicalRecordApproveDV(sMedicalCode, objectCode, sRepCode, iStatus, dRowIDMedicines, objectCode_Medical);
        }
        public static DataTable TableMedicalPrescriptionForImmuni(string medicalRecordCode, string patientCode, decimal patientReceiveID)
        {
            return MedicalRecord_DAL.TableMedicalPrescriptionForImmuni(medicalRecordCode, patientCode, patientReceiveID);
        }

        public static List<MedicalRecordHistoryModel> ListHistoryMedical(string sPatientCode, Int32 iPatientType)
        {
            return MedicalRecord_DAL.ListHistoryMedical(sPatientCode, iPatientType);
        }

        public static List<MedicalEmergencyHistoryModel> ListHistoryMedicalEmergency(string sPatientCode)
        {
            return MedicalRecord_DAL.ListHistoryMedicalEmergency(sPatientCode);
        }

        public static MedicalRecord_INF ObjMedicalRecordForReceiveID(decimal dReceiveID, string sDepartmentCode)
        {
            return MedicalRecord_DAL.ObjMedicalRecordForReceiveID(dReceiveID, sDepartmentCode);
        }

        public static List<MedicalRecord_INF> ListMedicalRecordForReceiveID(string receiveID)
        {
            return MedicalRecord_DAL.ListMedicalRecordForReceiveID(receiveID);
        }

        public static MedicalRecord_INF ObjMedicalRecordForRecordCode(string medicalRecordCode)
        {
            return MedicalRecord_DAL.ObjMedicalRecordForRecordCode(medicalRecordCode);
        }
        public static MedicalRecord_ANCINF ObjMedicalRecord_ANC(string medicalRecordCode)
        {
            return MedicalRecord_DAL.ObjMedicalRecord_ANC(medicalRecordCode);
        }
        public static MedicalRecord_AbortionsINF ObjMedicalRecord_Abortions(string medicalRecordCode)
        {
            return MedicalRecord_DAL.ObjMedicalRecord_Abortions(medicalRecordCode);
        }
        public static int InsMedicalRecord(MedicalRecord_INF model, ref string sMedicalCode, ref string sServiceCode, ref string msg)
        {
            return MedicalRecord_DAL.InsMedicalRecord(model, ref sMedicalCode, ref sServiceCode, ref msg);
        }
        public static bool InsMedicalRecord_ANC(MedicalRecord_ANCINF info, ref string msgError)
        {
            return MedicalRecord_DAL.InsMedicalRecord_ANC(info, ref msgError);
        }
        public static bool InsMedicalRecord_Abortions(MedicalRecord_AbortionsINF info, ref string msgError)
        {
            return MedicalRecord_DAL.InsMedicalRecord_Abortions(info, ref msgError);
        }
        public static Int32 InsMedicalRecord_Emergency(MedicalRecord_INF info, ref string sMedicalCode)
        {
            return MedicalRecord_DAL.InsMedicalRecord_Emergency(info, ref sMedicalCode);
        }
        public static Int32 InsMedicalRecord_Surgeries(MedicalRecord_INF info, ref string sMedicalCode)
        {
            return MedicalRecord_DAL.InsMedicalRecord_Surgeries(info, ref sMedicalCode);
        }
        public static Int32 UpdMedicalRecordDetailForNew(string sMedicalRecordCode)
        {
            return MedicalRecord_DAL.UpdMedicalRecordDetailForNew(sMedicalRecordCode);
        }

        public static int InsMedicalRecordDetail(MedicalPrescriptionDetail_INF model, Int32 objectCode_Patient)
        {
            return MedicalRecord_DAL.InsMedicalRecordDetail(model, objectCode_Patient);
        }

        public static Int32 DelMedicalRecordDetail(string sMedicalRecordCode, decimal dRowID, int bhyt)
        {
            return MedicalRecord_DAL.DelMedicalRecordDetail(sMedicalRecordCode, dRowID, bhyt);
        }

        public static Int32 DelMedicalRecord(string medicalRecordCode, decimal patientReceiveID, string patientCode)
        {
            return MedicalRecord_DAL.DelMedicalRecord(medicalRecordCode, patientReceiveID, patientCode);
        }

        public static DataTable DT_GetResultMedical(string sMedicalRecordCode, decimal dPatientReceiveID, int blank)
        {
            return MedicalRecord_DAL.DT_GetResultMedical(sMedicalRecordCode, dPatientReceiveID, blank);
        }

        public static DataTable DT_GetResultMedicalDetail(string sMedicalCode, string iGroup, Int32 iObject, Int32 active, int status)
        {
            return MedicalRecord_DAL.DT_GetResultMedicalDetail(sMedicalCode, iGroup, iObject, active, status);
        }
        
        public static Int32 InsDiagnosisEnclosed(decimal dRowIDDiagnosis, string sMedicalRecordCode)
        {
            return MedicalRecord_DAL.InsDiagnosisEnclosed(dRowIDDiagnosis, sMedicalRecordCode);
        }

        public static Int32 DelDiagnosisEnclosed(string sMedicalRecordCode)
        {
            return MedicalRecord_DAL.DelDiagnosisEnclosed(sMedicalRecordCode);
        }

        public static DataTable DT_MedicalRecordDiagnosisEnclosed(string sMedicalCode)
        {
            return MedicalRecord_DAL.TableMedicalRecordDiagnosisEnclosed(sMedicalCode);
        }

        public static string DiagnosisEnclosed(string sMedicalCode)
        {
            string icd10 = string.Empty;
            try
            {
                DataTable dtTemp = MedicalRecord_DAL.TableMedicalRecordDiagnosisEnclosed(sMedicalCode);
                foreach (DataRow dr in dtTemp.Rows)
                {
                    icd10 += dr["DiagnosisName"].ToString().Trim() + dr["DiagnosisName_EN"].ToString().Trim() + ";";
                }
            }
            catch { }
            return icd10;

        }

        public static string DiagnosisEnclosed(string medicalCode, decimal patientReceiveID, int patientType)
        {
            string icd10 = string.Empty;
            try
            {
                DataTable dtTemp = MedicalRecord_DAL.TableMedicalRecordDiagnosisEnclosed(medicalCode, patientReceiveID, patientType);
                foreach (DataRow dr in dtTemp.Rows)
                {
                    icd10 += dr["DiagnosisName"].ToString().Trim() + dr["DiagnosisName_EN"].ToString().Trim() + ";";
                }
            }
            catch { }
            return icd10;
        }

        public static string sDiagnosis(string sMedicalCode)
        {
            string sTemp = string.Empty;
            try
            {
                DataTable dtTemp = MedicalRecord_DAL.DT_MedicalRecordDiagnosis(sMedicalCode);
                foreach (DataRow dr in dtTemp.Rows)
                {
                    sTemp += dr["DiagnosisName"].ToString().Trim() + dr["DiagnosisName_EN"].ToString().Trim() + ";";
                }
            }
            catch { }
            return sTemp;
        }

        public static decimal dTotalMedicalRecord(decimal dRefID, string sPatientCode, string sMedicalCode, Int32 iObject, string sTheBHYT, Int32 iTraituyen, ref decimal dTotalThuPhi)
        {
            try
            {
                DataTable dtTemp = MedicalRecord_DAL.DT_TotalMedicalRecord(dRefID, sPatientCode, sMedicalCode);
                decimal dAmount = 0, dThuphi = 0, dTotalPrice = 0, dTotalPriceBHYT = 0;
                if (dtTemp.Rows.Count > 0)
                {
                    if (iObject == 1)
                    {
                        BHYTParametersInf Modelpara = BHYTParametersBLL.ObjParameters(1);
                        //RateBHYTInf ModelRate = RateBHYTDal.objectRateBHYT(sTheBHYT.Substring(0, 2));
                        //if (iTraituyen == 1)
                        //{
                        //    dTile = ModelRate.RateFalse;
                        //}
                        //else
                        //{
                        //    dTile = ModelRate.RateTrue;
                        //}
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            //if (dr["ListBHYT"].ToString() == "1")
                            dTotalPrice = (Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr["UnitPrice"].ToString()));
                            dTotalPriceBHYT = dTotalPrice / Convert.ToDecimal(dr["RateBHYT"].ToString());
                            dAmount += dTotalPriceBHYT;
                            dThuphi += dTotalPrice - dTotalPriceBHYT;
                        }
                        //dBHYTTra = (dAmount * dTile) / 100;
                        //dBnTra = dAmount - dBHYTTra + dThuphi;
                    }
                    else
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            dTotalPrice = (Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr["UnitPrice"].ToString()));
                            dAmount += dTotalPrice;
                            dThuphi += dTotalPrice;
                        }
                    }
                }
                dTotalThuPhi = dThuphi;
                return dAmount;
            }
            catch { return 0; }
        }

        public static decimal dTotalMedicalRecord(decimal dRefID, string sPatientCode, Int32 iObject, string sTheBHYT, Int32 iTraituyen, ref decimal dTotalThuPhi)
        {
            try
            {
                DataTable dtTemp = MedicalRecord_DAL.DT_TotalMedicalRecord(dRefID, sPatientCode);
                decimal dAmount = 0, dThuphi = 0, dTotalPrice = 0, dTotalPriceBHYT = 0;
                if (dtTemp.Rows.Count > 0)
                {
                    if (iObject == 1)
                    {
                        BHYTParametersInf Modelpara = BHYTParametersBLL.ObjParameters(1);
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            dTotalPrice = (Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr["UnitPrice"].ToString()));
                            dTotalPriceBHYT = dTotalPrice / Convert.ToDecimal(dr["RateBHYT"].ToString());
                            dAmount += dTotalPriceBHYT;
                            dThuphi += dTotalPrice - dTotalPriceBHYT;
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            dTotalPrice = (Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr["UnitPrice"].ToString()));
                            dAmount += dTotalPrice;
                            dThuphi += dTotalPrice;
                        }
                    }
                }
                dTotalThuPhi = dThuphi;
                return dAmount;
            }
            catch { return 0; }
        }

        public static DataTable DT_Get_PrescriptionsOld(string sPatientCode)
        {
            return MedicalRecord_DAL.DT_Get_PrescriptionsOld(sPatientCode);
        }

        public static DataTable DT_Get_PrescriptionsOld(string sPatientCode, decimal dReceiveID, string sMedicalCode)
        {
            return MedicalRecord_DAL.DT_Get_PrescriptionsOld(sPatientCode, dReceiveID, sMedicalCode);
        }

        public static DataTable DT_Get_PrescriptionsOldFor(string sPatientCode, decimal dReceiveID, string sReferenceCode)
        {
            return MedicalRecord_DAL.DT_Get_PrescriptionsOldFor(sPatientCode, dReceiveID, sReferenceCode);
        }

        public static DataTable DT_MedicalDetailRecordOut(string sMedicalCode, string sDate)
        {
            return MedicalRecord_DAL.DT_MedicalDetailRecordOut(sMedicalCode, sDate);
        }

        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowse(Int32 iStatus, string sRepCode, Int32 typeMedical, Int32 done, DateTime dateFrom, DateTime dateTo)
        {
            //SystemParameterInf objSys = SystemParameterBLL.ObjParameter(204);
            //if (objSys != null && objSys.RowID > 0)
            //    return MedicalRecord_DAL.ListPatient_WaitingBrowse(iStatus, Convert.ToInt32(objSys.Description), sRepCode, typeMedical, done);
            //else
            //    return MedicalRecord_DAL.ListPatient_WaitingBrowse(iStatus, 0, sRepCode, typeMedical, done);
            return MedicalRecord_DAL.ListPatient_WaitingBrowse(iStatus, sRepCode, typeMedical, done, dateFrom, dateTo);
        }
        public static Int32 Done(Decimal MedicalRecordCode)
        {
            return MedicalRecord_DAL.Done(MedicalRecordCode);
        }
        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseForBHYT(Int32 iStatus, string sRepCode, Int32 typeMedical, Int32 done, DateTime dateFrom, DateTime dateTo, string objectCode)
        {
            return MedicalRecord_DAL.ListPatient_WaitingBrowseForBHYT(iStatus, sRepCode, typeMedical, done, dateFrom, dateTo, objectCode);
        }
        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseForBHYTCAPPHAT(Int32 iStatus, string sRepCode, Int32 typeMedical, Int32 done, DateTime dateFrom, DateTime dateTo, string objectCode)
        {
            return MedicalRecord_DAL.ListPatient_WaitingBrowseForBHYTCAPPHAT(iStatus, sRepCode, typeMedical, done, dateFrom, dateTo, objectCode);
        }

        public static List<MedicalRecordHistoryModel> ListHistoryMedicalReceive(string sPatientCode)
        {
            return MedicalRecord_DAL.ListHistoryMedicalReceive(sPatientCode);
        }

        public static string refMedicalCode(decimal dPatientReceiveID, string sPatientCode, string sDepartmentCode, string sReferenceCode, ref Int32 refStatus, ref Int32 refPaid, ref string refBanksAccountCode)
        {
            return MedicalRecord_DAL.refMedicalCode(dPatientReceiveID, sPatientCode, sDepartmentCode, sReferenceCode, ref refStatus, ref refPaid, ref refBanksAccountCode);
        }

        public static DataTable DT_GetResultMedicalDetailForSurgeries(string surgeriesCode)
        {
            return MedicalRecord_DAL.DT_GetResultMedicalDetailForSurgeries(surgeriesCode);
        }

        public static Int32 DelMedicalRecordDetailForItemCode(string sMedicalRecordCode, string sItemCode)
        {
            return MedicalRecord_DAL.DelMedicalRecordDetailForItemCode(sMedicalRecordCode, sItemCode);
        }
        public static Int32 DelMedicalRecordDetailForRowID(string sMedicalRecordCode, decimal RowID)
        {
            return MedicalRecord_DAL.DelMedicalRecordDetailForRowID(sMedicalRecordCode, RowID);
        }
        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseForDate(Int32 iStatus, string dtFrom, string dtTo, bool done)
        {
            return MedicalRecord_DAL.ListPatient_WaitingBrowseForDate(iStatus, dtFrom, dtTo, done);
        }
        public static DataTable DTMedicalRecordApprove(string sMedicalCode, Int32 iObjectCode, Int32 iStatus, decimal dRowIDMedicines)
        {
            return MedicalRecord_DAL.DTMedicalRecordApprove(sMedicalCode, iObjectCode, iStatus, dRowIDMedicines);
        }
        public static DataTable hsba_MedicalRecord(decimal dPatientReceiveID, string sPatientCode)
        {
            return MedicalRecord_DAL.hsba_MedicalRecord(dPatientReceiveID, sPatientCode);
        }
        public static DataTable hsba_MedicalDetail(string sMedicalCode)
        {
            return MedicalRecord_DAL.hsba_MedicalDetail(sMedicalCode);
        }
        public static DataTable hsba_DiagnosisEnclosed(decimal dReceiveID, string sPatientCode)
        {
            return MedicalRecord_DAL.hsba_DiagnosisEnclosed(dReceiveID, sPatientCode);
        }

        public static DataTable TableResultPrescription(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            return MedicalRecord_DAL.TableResultPrescription(sPatientCode, sFromdate, sTodate, sItemCode, employeeCode);
        }

        public static DataTable TableResultPrescriptionGroupForDoctor(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            return MedicalRecord_DAL.TableResultPrescriptionGroupForDoctor(sPatientCode, sFromdate, sTodate, sItemCode, employeeCode);
        }

        public static Int32 UpdMedicalRecordForHide(string medicalRecordCode)
        {
            return MedicalRecord_DAL.UpdMedicalRecordForHide(medicalRecordCode);
        }

        public static bool InsMedicalRecord_Childbirth(MedicalRecord_ChildbirthINF info, ref string msgError)
        {
            return MedicalRecord_DAL.InsMedicalRecord_Childbirth(info, ref msgError);
        }
        public static MedicalRecord_ChildbirthINF ObjMedicalRecord_Childbirth(string medicalRecordCode)
        {
            return MedicalRecord_DAL.ObjMedicalRecord_Childbirth(medicalRecordCode);
        }
        public static Int32 DelMedicalRecord_ANC(string medicalRecordCode)
        {
            return MedicalRecord_DAL.DelMedicalRecord_ANC(medicalRecordCode);
        }
        public static Int32 DelMedicalRecord_Abortions(string medicalRecordCode)
        {
            return MedicalRecord_DAL.DelMedicalRecord_Abortions(medicalRecordCode);
        }

        public static Int32 DelMedicalRecord_Childbirth(string medicalRecordCode)
        {
            return MedicalRecord_DAL.DelMedicalRecord_Childbirth(medicalRecordCode);
        }
        public static string GetDrugMedicalrecord(decimal patientReceiveID, string patientCode)
        {
            return MedicalRecord_DAL.GetDrugMedicalrecord(patientReceiveID, patientCode);
        }
		public static Int32 UpdMedicalRecordForDone(decimal receiptID, decimal discountAmount, string employeeCodeDoing, int per, int status)
        {
            return MedicalRecord_DAL.UpdMedicalRecordForDone(receiptID, discountAmount, employeeCodeDoing, per, status);
        }
        public static Int32 UpdMedicalRecordForDoctorPointed(decimal receiptID, decimal discountAmount, string employeeCodeDoing, int per, int status)
        {
            return MedicalRecord_DAL.UpdMedicalRecordForDoctorPointed(receiptID, discountAmount, employeeCodeDoing, per, status);
        }

        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseFor(Int32 iStatus, Int32 done, DateTime dateFrom, DateTime dateTo)
        {
            return MedicalRecord_DAL.ListPatient_WaitingBrowseFor(iStatus, done, dateFrom, dateTo);
        }
        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowses(Int32 istatus, Int32 done, DateTime dateFrom, DateTime dateTo)
        {
            return MedicalRecord_DAL.ListPatient_WaitingBrowses(istatus, done, dateFrom, dateTo);
        }
    }
}
