using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;


namespace ClinicDAL
{
    public class MedicalEmergencyDAL
    {
        public static Int32 InsMedicalEmergency(MedicalEmergencyINF info, ref string sMedicalCode, decimal dSuggestedID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[21];
                param[0] = new SqlParameter("@MedicalEmergencyCode", SqlDbType.VarChar, 20);
                param[0].Value = info.MedicalEmergencyCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[2].Value = info.DepartmentCode;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@DateOn", SqlDbType.Date);
                param[4].Value = info.DateOn;
                param[5] = new SqlParameter("@TimeOn", SqlDbType.VarChar);
                param[5].Value = info.TimeOn;
                param[6] = new SqlParameter("@ReceivePatientFrom", SqlDbType.NVarChar, 100);
                param[6].Value = info.ReceivePatientFrom;
                param[7] = new SqlParameter("@DiagnosisCode", SqlDbType.NVarChar, 250);
                param[7].Value = info.DiagnosisCode;
                param[8] = new SqlParameter("@ICD10", SqlDbType.VarChar, 10);
                param[8].Value = info.ICD10;
                param[9] = new SqlParameter("@Family", SqlDbType.NVarChar, 250);
                param[9].Value = info.Family;
                param[10] = new SqlParameter("@FamilyFullname", SqlDbType.NVarChar, 250);
                param[10].Value = info.FamilyFullname;
                param[11] = new SqlParameter("@FamilyAddress", SqlDbType.NVarChar, 250);
                param[11].Value = info.FamilyAddress;
                param[12] = new SqlParameter("@FamilyMobile", SqlDbType.NVarChar, 250);
                param[12].Value = info.FamilyMobile;
                param[13] = new SqlParameter("@PatientReceivingNursing", SqlDbType.VarChar, 50);
                param[13].Value = info.PatientReceivingNursing;
                param[14] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[14].Value = info.PatientReceiveID;
                param[15] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[15].Value = info.PatientType;
                param[16] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[16].Value = info.ObjectCode;
                param[17] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[17].Value = dSuggestedID;
                param[18] = new SqlParameter("@Symptoms", SqlDbType.NVarChar, 250);
                param[18].Value = info.Symptoms;
                param[19] = new SqlParameter("@Treatments", SqlDbType.NVarChar, 200);
                param[19].Value = info.Treatments;
                param[20] = new SqlParameter("@vresult", SqlDbType.VarChar, 50);
                param[20].Direction = ParameterDirection.Output;
                sMedicalCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicalEmergency", param);
                return 1;
            }
            catch { return -2; }
        }

        public static Int32 InsMedicalEmergencyOut(MedicalEmergencyOutINF info, ref string sMedicalCodeOut)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@MedicalEmergencyOutCode", SqlDbType.VarChar, 20);
                param[0].Value = info.MedicalEmergencyOutCode;
                param[1] = new SqlParameter("@DateOut", SqlDbType.Date);
                param[1].Value = info.DateOut;
                param[2] = new SqlParameter("@TimeOut", SqlDbType.VarChar);
                param[2].Value = info.TimeOut;
                param[3] = new SqlParameter("@TreatmentTime", SqlDbType.Int);
                param[3].Value = info.TreatmentTime;
                param[4] = new SqlParameter("@TreatmentResults", SqlDbType.Int);
                param[4].Value = info.TreatmentResults;
                param[5] = new SqlParameter("@ICD10Out", SqlDbType.VarChar, 10);
                param[5].Value = info.ICD10Out;
                param[6] = new SqlParameter("@MedicalEmergencyCode", SqlDbType.VarChar, 20);
                param[6].Value = info.MedicalEmergencyCode;
                param[7] = new SqlParameter("@TreatingDoctor", SqlDbType.VarChar, 50);
                param[7].Value = info.TreatingDoctor;
                param[8] = new SqlParameter("@NumberStorage", SqlDbType.VarChar, 50);
                param[8].Value = info.NumberStorage;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@TackleCode", SqlDbType.Int);
                param[10].Value = info.TackleCode;
                param[11] = new SqlParameter("@Advices", SqlDbType.NVarChar, 250);
                param[11].Value = info.Advices;
                param[12] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[12].Value = info.PatientReceiveID;
                param[13] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[13].Value = info.PatientCode;
                param[14] = new SqlParameter("@Status", SqlDbType.Int);
                param[14].Value = info.Status;
                param[15] = new SqlParameter("@vresult", SqlDbType.VarChar, 50);
                param[15].Direction = ParameterDirection.Output;
                sMedicalCodeOut = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicalEmergencyOut", param);
                return 1;
            }
            catch { return -2; }
        }

        public static List<TreatmentResultsINF> lstResults()
        {
            ConnectDB cn = new ConnectDB();
            List<TreatmentResultsINF> list = new List<TreatmentResultsINF>();
            try
            {
                string sql = "SELECT [RowID],[ResultsName]  FROM TreatmentResults ";

                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    TreatmentResultsINF inf = new TreatmentResultsINF();
                    inf.RowID = ireader.GetInt32(0);
                    inf.ResultsName = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { list = null; }
            return list;
        }

        public static MedicalEmergencyINF ObjEmergency(string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalEmergencyINF inf = new MedicalEmergencyINF();
            try
            {
                string sql = "SELECT [MedicalEmergencyCode],[PatientCode],[DepartmentCode],[EmployeeCode],[DateOn],[TimeOn],[ReceivePatientFrom],[DiagnosisCode],[ICD10],[Family],[FamilyFullname],[FamilyAddress],[FamilyMobile],[PatientReceivingNursing],[PatientReceiveID],[PatientType],[ObjectCode],[Symptoms],[Treatments] FROM MedicalEmergency where MedicalEmergencyCode in('{0}') ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicalCode), null);
                if(ireader.Read())
                {
                    inf.MedicalEmergencyCode = ireader.GetValue(0).ToString();
                    inf.PatientCode = ireader.GetString(1);
                    inf.DepartmentCode = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
                    inf.DateOn = ireader.GetDateTime(4);
                    inf.TimeOn = ireader.GetValue(5).ToString();
                    inf.ReceivePatientFrom = ireader.GetValue(6).ToString();
                    inf.DiagnosisCode = ireader.GetValue(7).ToString();
                    inf.ICD10 = ireader.GetValue(8).ToString();
                    inf.Family = ireader.GetValue(9).ToString();
                    inf.FamilyFullname = ireader.GetValue(10).ToString();
                    inf.FamilyAddress = ireader.GetValue(11).ToString();
                    inf.FamilyMobile = ireader.GetValue(12).ToString();
                    inf.PatientReceivingNursing = ireader.GetValue(13).ToString();
                    inf.PatientReceiveID = ireader.GetDecimal(14);
                    inf.PatientType = ireader.GetInt32(15);
                    inf.ObjectCode = ireader.GetInt32(16);
                    inf.Symptoms = ireader.GetValue(17).ToString();
                    inf.Treatments = ireader.GetValue(18).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }
        public static MedicalEmergencyINF ObjEmergency(string refPatientCode, decimal refReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            MedicalEmergencyINF inf = new MedicalEmergencyINF();
            try
            {
                string sql = "SELECT [MedicalEmergencyCode],[PatientCode],[DepartmentCode],[EmployeeCode],[DateOn],[TimeOn],[ReceivePatientFrom],[DiagnosisCode],[ICD10],[Family],[FamilyFullname],[FamilyAddress],[FamilyMobile],[PatientReceivingNursing],[PatientReceiveID],[PatientType],[ObjectCode] FROM MedicalEmergency where PatientCode in('{0}') and PatientReceiveID in({1})";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, refPatientCode, refReceiveID), null);
                if (ireader.Read())
                {
                    inf.MedicalEmergencyCode = ireader.GetValue(0).ToString();
                    inf.PatientCode = ireader.GetString(1);
                    inf.DepartmentCode = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
                    inf.DateOn = ireader.GetDateTime(4);
                    inf.TimeOn = ireader.GetValue(5).ToString();
                    inf.ReceivePatientFrom = ireader.GetValue(6).ToString();
                    inf.DiagnosisCode = ireader.GetValue(7).ToString();
                    inf.ICD10 = ireader.GetValue(8).ToString();
                    inf.Family = ireader.GetValue(9).ToString();
                    inf.FamilyFullname = ireader.GetValue(10).ToString();
                    inf.FamilyAddress = ireader.GetValue(11).ToString();
                    inf.FamilyMobile = ireader.GetValue(12).ToString();
                    inf.PatientReceivingNursing = ireader.GetValue(13).ToString();
                    inf.PatientReceiveID = ireader.GetDecimal(14);
                    inf.PatientType = ireader.GetInt32(15);
                    inf.ObjectCode = ireader.GetInt32(16);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }
        public static MedicalEmergencyOutINF ObjEmergencyOut(string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalEmergencyOutINF inf = new MedicalEmergencyOutINF();
            try
            {
                string sql = @"SELECT [MedicalEmergencyOutCode],[DateOut],[TimeOut],[TreatmentTime],[TreatmentResults],[ICD10Out],[MedicalEmergencyCode]
                                  ,[Paid],[BanksAccountCode],[TreatingDoctor],[NumberStorage],[EmployeeCode],[TackleCode],[Advices]
                                  ,[PatientReceiveID],[PatientCode]
                              FROM MedicalEmergencyOut where MedicalEmergencyCode in('{0}') ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicalCode), null);
                if (ireader.Read())
                {
                    inf.MedicalEmergencyOutCode = ireader.GetValue(0).ToString();
                    inf.DateOut = ireader.GetDateTime(1);
                    inf.TimeOut = ireader.GetValue(2).ToString();
                    inf.TreatmentTime = ireader.GetInt32(3);
                    inf.TreatmentResults = ireader.GetInt32(4);
                    inf.ICD10Out = ireader.GetValue(5).ToString();
                    inf.MedicalEmergencyCode = ireader.GetValue(6).ToString();
                    inf.Paid = ireader.GetInt32(7);
                    inf.BanksAccountCode = ireader.GetValue(8).ToString();
                    inf.TreatingDoctor = ireader.GetString(9);
                    inf.NumberStorage = ireader.GetValue(10).ToString();
                    inf.EmployeeCode = ireader.GetString(11);
                    inf.TackleCode = ireader.GetInt32(12);
                    inf.Advices = ireader.GetString(13);
                    inf.PatientReceiveID = ireader.GetDecimal(14);
                    inf.PatientCode = ireader.GetString(15);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }

        public static DataTable DataViewMedicinesPatientEmergency(string startDate, string endDate, string patientCode, string itemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@StartDate", SqlDbType.VarChar, 10);
                param[0].Value = startDate;
                param[1] = new SqlParameter("@EndDate", SqlDbType.VarChar, 10);
                param[1].Value = endDate;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = patientCode;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[3].Value = itemCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewMedicinesPatientEmergency", param);
            }
            catch { return null; }
        }
        
        public static DataTable hsba_MedicalEmergency(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select MedicalEmergencyCode,PatientCode,DepartmentCode,EmployeeCode,DateOn,TimeOn,ReceivePatientFrom,DiagnosisCode,ICD10,Family,FamilyFullname,FamilyAddress,FamilyMobile,PatientReceivingNursing,IDate,PatientReceiveID,PatientType,ObjectCode from MedicalEmergency where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable hsba_MedicalEmergencyout(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select a.MedicalEmergencyOutCode,a.DateOut,a.TimeOut,a.TreatmentTime,TreatmentResults,a.ICD10Out,a.MedicalEmergencyCode,a.Paid,a.BanksAccountCode,a.TreatingDoctor,a.NumberStorage,a.EmployeeCode,a.TackleCode,a.Advices,a.IDate,a.PatientReceiveID,a.PatientCode from MedicalEmergencyOut a where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

    }
}
