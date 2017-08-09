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
    public class ServiceLaboratoryEntryDAL
    {
        public static ServiceLaboratoryEntryINF ObjLaboratoryEntry(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            ServiceLaboratoryEntryINF inf = new ServiceLaboratoryEntryINF();
            try
            {
                string sql = @" select RowID,PatientCode,ReferenceCode,AppointmentDate,AppointmentNote,Conclusion,Proposal,PostingDate,PatientReceiveID,ServiceCategoryCode,
                                STT,Status,EmployeeCode,ObjectCode
                                from ServiceLaboratoryEntry where RowID=@RowID
                                ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = dRowID;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetValue(1).ToString();
                    inf.ReferenceCode = ireader.GetValue(2).ToString();
                    if (ireader.GetValue(3).ToString() != "" && ireader.GetValue(3) != null)
                        inf.AppointmentDate = ireader.GetDateTime(3);
                    inf.AppointmentNote = ireader.GetValue(4).ToString();
                    inf.Conclusion = ireader.GetValue(5).ToString();
                    inf.Proposal = ireader.GetValue(6).ToString();
                    inf.PostingDate = ireader.GetDateTime(7);
                    inf.PatientReceiveID = ireader.GetDecimal(8);
                    inf.ServiceCategoryCode = ireader.GetValue(9).ToString();
                    inf.STT = ireader.GetValue(10).ToString();
                    inf.Status = ireader.GetInt32(11);
                    inf.EmployeeCode = ireader.GetValue(12).ToString();
                    inf.ObjectCode = ireader.GetInt32(13);
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
        public static Int32 InsLaboratoryEntry(ServiceLaboratoryEntryINF info, ref decimal refID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@ReferenceCode", SqlDbType.NVarChar, 50);
                param[2].Value = info.ReferenceCode;
                //param[3] = new SqlParameter("@AppointmentDate", SqlDbType.Date);
                //param[3].Value = info.AppointmentDate;
                //param[4] = new SqlParameter("@AppointmentNote", SqlDbType.NVarChar);
                //param[4].Value = info.AppointmentNote;
                param[3] = new SqlParameter("@Conclusion", SqlDbType.NVarChar);
                param[3].Value = info.Conclusion;
                param[4] = new SqlParameter("@Proposal", SqlDbType.NVarChar);
                param[4].Value = info.Proposal;
                param[5] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[5].Value = info.PostingDate;
                param[6] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[6].Value = info.PatientReceiveID;
                param[7] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[7].Value = info.ServiceCategoryCode;
                param[8] = new SqlParameter("@Status", SqlDbType.Int);
                param[8].Value = info.Status;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[10].Value = info.ObjectCode;
                param[11] = new SqlParameter("@STT", SqlDbType.VarChar, 10);
                param[11].Value = info.STT;
                param[12] = new SqlParameter("@ResultRowID", SqlDbType.Decimal);
                param[12].Direction = ParameterDirection.Output;
                param[13] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar, 10);
                param[13].Value = info.DepartmentCodeOrder;
                param[14] = new SqlParameter("@LabPathologicalID", SqlDbType.Int);
                param[14].Value = info.LabPathologicalID;
                param[15] = new SqlParameter("@OrderDate", SqlDbType.VarChar, 20);
                param[15].Value = info.OrderDate;
                param[16] = new SqlParameter("@EmployeeCodeOrder", SqlDbType.VarChar, 20);
                param[16].Value = info.EmployeeCodeOrder;
                param[17] = new SqlParameter("@EmployeeDoctorCodeOrder", SqlDbType.VarChar, 20);
                param[17].Value = info.EmployeeDoctorCodeOrder;
                param[18] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[18].Value = info.ShiftWork;
                param[19] = new SqlParameter("@IDMachine", SqlDbType.Int);
                param[19].Value = info.IDMachine;
                param[20] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar);
                param[20].Value = info.DepartmentCode;
                param[21] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar);
                param[21].Value = info.EmployeeCodeDoctor;
                refID = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_ServiceLaboratoryEntry", param));
                if (refID > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 UpdLaboratoryEntry(decimal dRowID, Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "update ServiceLaboratoryEntry set status={1} where RowID in({0})";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, dRowID, iStatus), null);
            }
            catch { return -1; }
        }
        public static Int32 InsLaboratoryDetail(ServiceLaboratoryDetailINF info, Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[15];
                param[0] = new SqlParameter("@RowIDLaboratoryEnTry", SqlDbType.Decimal);
                param[0].Value = info.RowIDLaboratoryEnTry;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@UnitValues", SqlDbType.NVarChar, 50);
                param[2].Value = info.UnitValues;
                param[3] = new SqlParameter("@ValuesEntry", SqlDbType.NVarChar,50);
                param[3].Value = info.ValuesEntry;
                param[4] = new SqlParameter("@ValuedFemale", SqlDbType.NVarChar,50);
                param[4].Value = info.ValuedFemale;
                param[5] = new SqlParameter("@ValuedMale", SqlDbType.NVarChar,50);
                param[5].Value = info.ValuedMale;
                param[6] = new SqlParameter("@MinValuedFemale", SqlDbType.Decimal);
                param[6].Value = info.MinValuedFemale;
                param[7] = new SqlParameter("@MaxValuedFemale", SqlDbType.Decimal);
                param[7].Value = info.MaxValuedFemale;
                param[8] = new SqlParameter("@MinValuedMale", SqlDbType.Decimal);
                param[8].Value = info.MinValuedMale;
                param[9] = new SqlParameter("@MaxValuedMale", SqlDbType.Decimal);
                param[9].Value = info.MaxValuedMale;
                param[10] = new SqlParameter("@Normal", SqlDbType.Decimal);
                param[10].Value = info.Normal;
                param[11] = new SqlParameter("@LaboratoryName", SqlDbType.NVarChar, 100);
                param[11].Value = info.LaboratoryName;
                param[12] = new SqlParameter("@STT", SqlDbType.Int);
                param[12].Value = info.STT;
                param[13] = new SqlParameter("@Status", SqlDbType.Int);
                param[13].Value = iStatus;
                param[14] = new SqlParameter("@ParameterMachine", SqlDbType.NVarChar);
                param[14].Value = info.ParameterMachine;
                int iResult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ServiceLaboratoryDetail", param);
                return iResult;
            }
            catch { return -2; }
        }
        public static Int32 UpdSuggestedServiceReceipt(decimal dIDLaboratoryEnTry, Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowIDLaboratoryEnTry", SqlDbType.Decimal);
                param[0].Value = dIDLaboratoryEnTry;
                param[1] = new SqlParameter("@Status", SqlDbType.VarChar, 50);
                param[1].Value = iStatus;
                param[2] = new SqlParameter("@Result", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                int iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Upd_SuggestedServiceReceipt", param));
                return iResult;
            }
            catch { return -2; }
        }
        public static Int32 ClearResultLaboratoryDetail(decimal dIDLaboratoryEnTry)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "update ServiceLaboratoryDetail set ValuesEntry='',Normal=0 where RowIDLaboratoryEnTry in({0})";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, dIDLaboratoryEnTry), null);
            }
            catch { return -1; }
        }
        public static Int32 DelLaboratoryDetail(decimal dRowIDLaboratoryEnTry)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from ServiceLaboratoryDetail where RowIDLaboratoryEnTry=@RowIDLaboratoryEnTry ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowIDLaboratoryEnTry", SqlDbType.Decimal);
                param[0].Value = dRowIDLaboratoryEnTry;
                int iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
                return iResult;
            }
            catch { return -2; }
        }
        public static Int32 DelLaboratory(decimal rowIDLaboratoryEnTry)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from ServiceLaboratoryEntry where RowID=@RowIDLaboratoryEnTry ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowIDLaboratoryEnTry", SqlDbType.Decimal);
                param[0].Value = rowIDLaboratoryEnTry;
                int iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
                return iResult;
            }
            catch { return -2; }
        }
        public static Int32 DelLaboratoryTemplate(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = dRowID;
                param[1] = new SqlParameter("@Result", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                int iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_LaboratoryGetTemplate", param));
                return iResult;
            }
            catch { return -2; }
        }
        public static DataTable DTListPrevious(string sPatientCode, string sServiceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.PatientCode,a.ReferenceCode,a.PatientReceiveID,a.PostingDate,b.ServiceCategoryName,a.ObjectCode,a.Status,
                        (case when c.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ServiceCategoryCode,a.EmployeeCode
                        from ServiceLaboratoryEntry a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode 
                        inner join Patients c on a.PatientCode=c.PatientCode
                        where a.PatientCode ='{0}' and a.ServiceCategoryCode='{1}'
                        order by a.PostingDate";
                dt = cn.ExecuteQuery(string.Format(sql, sPatientCode, sServiceCategoryCode));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable TableResultLaboratory(string dRowID, string referenceCode, string categoryCode, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.PatientCode,a.ReferenceCode,a.AppointmentDate,a.AppointmentNote,a.Conclusion,a.Proposal,a.PostingDate,a.PatientReceiveID,a.ServiceCategoryCode,a.STT,a.Status,a.EmployeeCode,a.ObjectCode,
                        b.PatientName,upper((case when b.PatientGender=0 then N'Nữ' else N'Nam' end)) PatientGenderName,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,[dbo].func_PatientOfAddress({2}) PatientAddress,
                        b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,upper(c.ServiceCategoryName) ServiceCategoryName,d.EmployeeName,e.ObjectName,a1.EmployeeNameOrder,upper(f.IntroName) as IntroName,a1.DateOrder,a1.EmployeeNameDoctor,a2.LabPathologicalName
                        from ServiceLaboratoryEntry a inner join Patients b on a.PatientCode=b.PatientCode inner join ServiceCategory c on a.ServiceCategoryCode=c.ServiceCategoryCode inner join Employee d on a.EmployeeCode=d.EmployeeCode inner join Object e on a.ObjectCode=e.ObjectCode inner join PatientReceive f on a.PatientReceiveID=f.PatientReceiveID
                        inner join ( select top(1) a.RefID,a.PatientCode,a.EmployeeCodeDoctor,a1.EmployeeName EmployeeNameOrder,CONVERT(date,a.CreateDate,103) DateOrder,a2.EmployeeName EmployeeNameDoctor from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.EmployeeCodeDoctor=a2.EmployeeCode where b.ServiceCategoryCode='{1}' and RefID={2} and ReferenceCode='{3}') a1 on a.PatientCode=a1.PatientCode and a.PatientReceiveID=a1.RefID left join LabPathological a2 on a.LabPathologicalID =a2.LabPathologicalID
                        where a.RowID in({0})
                        ";
                tableResult = cn.ExecuteQuery(string.Format(sql, dRowID, categoryCode, patientReceiveID, referenceCode));
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable DTResultLaboratoryForSuggested(decimal refSuggestedID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.PatientCode,a.ReferenceCode,a.AppointmentDate,a.AppointmentNote,a.Conclusion,a.Proposal,a.PostingDate,a.PatientReceiveID,a.ServiceCategoryCode,a.STT,a.Status,a.EmployeeCode,a.ObjectCode,
                        b.PatientName,(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientAddress,
                        b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.ServiceCategoryName,d.EmployeeName,e.ObjectName
                        from ServiceLaboratoryEntry a inner join Patients b on a.PatientCode=b.PatientCode inner join ServiceCategory c on a.ServiceCategoryCode=c.ServiceCategoryCode inner join Employee d on a.EmployeeCode=d.EmployeeCode inner join Object e on a.ObjectCode=e.ObjectCode
                        where a.RowID in( select RowIDLaboratoryEnTry from ServiceLaboratoryDetail where SuggestedID={0} group by RowIDLaboratoryEnTry)
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, refSuggestedID));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable TableResultLaboratoryDetail(string rowIDLaboratoryEnTry)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ServiceCode,a.UnitValues,a.ValuesEntry,a.ValuedFemale,a.ValuedMale,(case when c.PatientGender=0 then a.ValuedFemale else a.ValuedMale end) ValuedNormal,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,(case when a.Normal=1 then 'x' else '' end) Normal,a.Normal NormalID,a.LaboratoryName,b.ServiceName,a2.LabPathologicalName,a3.ServiceCategoryName
                        from ServiceLaboratoryDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceLaboratoryEntry a1 on a.RowIDLaboratoryEnTry=a1.RowID inner join Patients c on a1.PatientCode=c.PatientCode left join LabPathological a2 on a1.LabPathologicalID =a2.LabPathologicalID inner join ServiceCategory a3 on a1.ServiceCategoryCode=a3.ServiceCategoryCode
                        where a.RowIDLaboratoryEnTry in({0}) order by a.[RowID]
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, rowIDLaboratoryEnTry));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable TableResultLaboratoryDetailForPrinter(string rowIDLaboratoryEnTry, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @"select c.PatientCode,c.PatientName,upper((case when c.PatientGender=0 then N'Nữ' else N'Nam' end)) PatientGenderName,CONVERT(date,c.PatientBirthday,103) PatientBirthday,c.PatientBirthyear,c.PatientAge,[dbo].func_PatientOfAddress(165562) PatientAddress,c.PatientMobile,c.PatientEmail,a1.STT,a.UnitValues,a.ValuesEntry,a.ValuedFemale,a.ValuedMale,(case when c.PatientGender=0 then a.ValuedFemale else a.ValuedMale end) ValuedNormal,
                        a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,(case when a.Normal=1 then 'x' else '' end) Normal,a.Normal NormalID,a.LaboratoryName,b.ServiceName,a2.LabPathologicalName,UPPER(a3.ServiceCategoryName) as ServiceCategoryName,d.EmployeeName,oj.ObjectCode,a1.OrderDate,a4.EmployeeName as EmployeeNameOrder,a5.EmployeeName as EmployeeDoctorNameOrder,a6.IntroName,CONVERT(date,a1.PostingDate,103) PostingDate,a1.Conclusion,a7.DiagnosisCustom,oj.ObjectName ObjectNameService
                        from ServiceLaboratoryDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceLaboratoryEntry a1 on a.RowIDLaboratoryEnTry=a1.RowID inner join Patients c on a1.PatientCode=c.PatientCode 
                        left join LabPathological a2 on a1.LabPathologicalID =a2.LabPathologicalID inner join ServiceCategory a3 on a1.ServiceCategoryCode=a3.ServiceCategoryCode inner join Employee d on a1.EmployeeCode=d.EmployeeCode 
                        left join Employee a4 on a1.EmployeeCodeOrder=a4.EmployeeCode left join Employee a5 on a1.EmployeeDoctorCodeOrder=a5.EmployeeCode inner join PatientReceive a6 on a1.PatientReceiveID=a6.PatientReceiveID left join MedicalRecord a7 on a1.ReferenceCode=a7.MedicalRecordCode
                        inner join SuggestedServiceReceipt a8 on a.SuggestedID=a8.ReceiptID inner join Object oj on oj.ObjectCode=a8.ObjectCode
                        where a.RowIDLaboratoryEnTry in({0}) order by a.[RowID]";
                //sql = @" select c.PatientCode,c.PatientName,upper((case when c.PatientGender=0 then N'Nữ' else N'Nam' end)) PatientGenderName,CONVERT(date,c.PatientBirthday,103) PatientBirthday,c.PatientBirthyear,c.PatientAge,[dbo].func_PatientOfAddress({1}) PatientAddress,c.PatientMobile,c.PatientEmail,a1.STT,a.UnitValues,a.ValuesEntry,a.ValuedFemale,a.ValuedMale,(case when c.PatientGender=0 then a.ValuedFemale else a.ValuedMale end) ValuedNormal,
                //        a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,(case when a.Normal=1 then 'x' else '' end) Normal,a.Normal NormalID,a.LaboratoryName,b.ServiceName,a2.LabPathologicalName,UPPER(a3.ServiceCategoryName) as ServiceCategoryName,d.EmployeeName,e.ObjectName,a1.OrderDate,a4.EmployeeName as EmployeeNameOrder,a5.EmployeeName as EmployeeDoctorNameOrder,a6.IntroName,CONVERT(date,a1.PostingDate,103) PostingDate,a1.Conclusion,a7.DiagnosisCustom,a8.EmployeeName as EmployeeNameDoctor
                //        from ServiceLaboratoryDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceLaboratoryEntry a1 on a.RowIDLaboratoryEnTry=a1.RowID inner join Patients c on a1.PatientCode=c.PatientCode 
                //        left join LabPathological a2 on a1.LabPathologicalID =a2.LabPathologicalID inner join ServiceCategory a3 on a1.ServiceCategoryCode=a3.ServiceCategoryCode inner join Employee d on a1.EmployeeCode=d.EmployeeCode inner join Object e on a1.ObjectCode=e.ObjectCode 
                //        left join Employee a4 on a1.EmployeeCodeOrder=a4.EmployeeCode left join Employee a5 on a1.EmployeeDoctorCodeOrder=a5.EmployeeCode inner join PatientReceive a6 on a1.PatientReceiveID=a6.PatientReceiveID left join MedicalRecord a7 on a1.ReferenceCode=a7.MedicalRecordCode left join Employee a8 on a1.EmployeeCodeDoctor=a8.EmployeeCode
                //        where a.RowIDLaboratoryEnTry in({0}) order by a.[RowID]";
                dt = cn.ExecuteQuery(string.Format(sql, rowIDLaboratoryEnTry, patientReceiveID));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable DT_Get_LaboratoryPackageDetail(decimal patientReceive, string patientCode, string referenceCode, Int32 status, string serviceCategoryCode, decimal rowIDLaboratory, string departmentCodeOrder)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceive;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[2].Value = referenceCode;
                param[3] = new SqlParameter("@Status", SqlDbType.Int);
                param[3].Value = status;
                param[4] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[4].Value = serviceCategoryCode;
                param[5] = new SqlParameter("@RowIDLaboratoryEnTry", SqlDbType.Decimal);
                param[5].Value = rowIDLaboratory;
                param[6] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar, 10);
                param[6].Value = departmentCodeOrder;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "Get_LaboratoryPackageDetail", param);
            }
            catch { return null; }
        }
        public static DataTable TableLabServiceTemplate(decimal patientReceive, string patientCode, string referenceCode, string serviceGroupCode, string serviceCategoryCode, Int32 status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceive;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[2].Value = referenceCode;
                param[3] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 50);
                param[3].Value = serviceGroupCode;
                param[4] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[4].Value = serviceCategoryCode;
                param[5] = new SqlParameter("@Status", SqlDbType.Int);
                param[5].Value = status;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "Get_LabServiceTemplate", param);
            }
            catch { return null; }
        }
        public static DataTable DT_Get_LaboratoryPackageDetailForSTTDate(string stt, DateTime postingDate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@STT", SqlDbType.VarChar, 10);
                param[0].Value = stt;
                param[1] = new SqlParameter("@PostingDate", SqlDbType.Date);
                param[1].Value = postingDate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "Get_LaboratoryDetailForSTTDATE", param);
            }
            catch { return null; }
        }
        public static Int32 GetSTT(string sLoaiXN)
        {
            Int32 istt = 1;
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select ISNULL( MAX(CONVERT(int, STT)+1),1) STT from ServiceLaboratoryEntry where ServiceCategoryCode=@ServiceCategoryCode and CONVERT(date,PostingDate,103)=CONVERT(date,GETDATE(),103)";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[0].Value = sLoaiXN;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                {
                    if (ireader.GetValue(0).ToString() != "" && ireader.GetValue(0) != null)
                        istt = ireader.GetInt32(0);
                    else
                        istt = 1;
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return istt;
        }
        public static decimal GetRowIDLaboratoryEnTry(decimal receiptID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select distinct a.RowID from ServiceLaboratoryEntry a inner join ServiceLaboratoryDetail b on a.RowID=b.RowIDLaboratoryEnTry where b.SuggestedID=@SuggestedID";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SuggestedID", SqlDbType.Decimal);
                param[0].Value = receiptID;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                {
                    return ireader.GetDecimal(0);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return 0;
            }
            catch { return -1; }
        }
        public static Int32 GetIDPatternForReceive(string serviceCategoryCode, string patientCode, decimal patientReceiveID, int labPathologicalID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "proGetSerialNumberLabEntry";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCategoryCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = patientReceiveID;
                param[3] = new SqlParameter("@LabPathologicalID", SqlDbType.Int);
                param[3].Value = patientReceiveID;
                param[4] = new SqlParameter("@Result", SqlDbType.Int);
                param[4].Direction = ParameterDirection.Output;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, query, param));
            }
            catch { return -1; }
        }
        public static bool ExistsSTTForLaboratory(string serviceCategoryCode, Int32 stt)
        {
            try
            {
                bool exists = false;
                ConnectDB cn = new ConnectDB();
                string sql = " select STT from ServiceLaboratoryEntry where CONVERT(date,PostingDate,103)=CONVERT(date,GETDATE(),103) and ServiceCategoryCode=@ServiceCategoryCode and STT=@STT";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCategoryCode;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = stt;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                    exists = true;
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return exists;
            }
            catch { return false; }
        }
        public static DataTable DT_ListResultLabEntry(string sPatientCode, decimal dReceive)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.PatientCode,a.PostingDate,a.PatientReceiveID,a.ServiceCategoryCode,a.STT,b.ServiceCategoryName
                        from ServiceLaboratoryEntry a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode  
                        where a.PatientCode in('{0}') and a.PatientReceiveID in({1}) order by RowID ";
                return cn.ExecuteQuery(string.Format(sql, sPatientCode, dReceive));
            }
            catch { return null; }
        }
        public static DataTable DT_ListResultLabSend(string frdate, string todate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@datefr", SqlDbType.VarChar, 15);
                param[0].Value = frdate;
                param[1] = new SqlParameter("@dateto", SqlDbType.VarChar, 15);
                param[1].Value = todate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_DTListResultLabSend", param);
            }
            catch { return null; }
        }
        public static DataTable TableListServiceLaboratory(string dateFrom, string dateTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = dateTo;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ListServiceLaboratory", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable TableReport_ServiceLabAppointment(decimal patientReceiveID, string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 15);
                param[1].Value = serviceCategoryCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proReport_ListServiceLabAppointment", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable TableListServiceLaboratoryAppointment(decimal patientReceiveID,int status, int sampleTransfer, string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = status;
                param[2] = new SqlParameter("@SampleTransfer", SqlDbType.Int);
                param[2].Value = sampleTransfer;
                param[3] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 15);
                param[3].Value = serviceCategoryCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ListServiceLabAppointment", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static Int32 InsLabAppointment(LabAppointmentForResultsInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = info.PatientReceiveID;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@SampleDate", SqlDbType.Date);
                param[2].Value = info.SampleDate;
                param[3] = new SqlParameter("@AppointmentDate", SqlDbType.Date);
                param[3].Value = info.AppointmentDate;
                param[4] = new SqlParameter("@AppointmentContent", SqlDbType.NVarChar);
                param[4].Value = info.AppointmentContent;
                param[5] = new SqlParameter("@AppointmentCode", SqlDbType.VarChar, 5);
                param[5].Value = info.AppointmentCode;
                param[6] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 15);
                param[6].Value = info.ServiceCategoryCode;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_LabAppointmentForResults", param);
                return result;
            }
            catch { return -2; }
        }
        public static Int32 DelLabAppointment(decimal patientReceiveID, string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 15);
                param[1].Value = serviceCategoryCode;
                int iResult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_LabAppointmentForResults", param);
                return iResult;
            }
            catch { return -2; }
        }
        public static LabAppointmentForResultsInf ObjLabAppointmentForResults(decimal patientReceiveID, string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            LabAppointmentForResultsInf inf = new LabAppointmentForResultsInf();
            try
            {
                string sql = @" select PatientReceiveID,EmployeeCode,SampleDate,AppointmentDate,AppointmentContent,AppointmentCode,ServiceCategoryCode from LabAppointmentForResults where PatientReceiveID=@PatientReceiveID and ServiceCategoryCode=@ServiceCategoryCode ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 15);
                param[1].Value = serviceCategoryCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                {
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.EmployeeCode = ireader.GetValue(1).ToString();
                    inf.SampleDate = ireader.GetDateTime(2);
                    inf.AppointmentDate = ireader.GetDateTime(3);
                    inf.AppointmentContent = ireader.GetValue(4).ToString();
                    inf.AppointmentCode = ireader.GetValue(5).ToString();
                    inf.ServiceCategoryCode = ireader.GetValue(6).ToString();
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
        public static DataTable hsba_LaboratoryEntry(string sPatientCode, decimal dReceive)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.PatientCode,a.ReferenceCode,a.AppointmentDate,a.AppointmentNote,a.Conclusion,a.Proposal,a.PostingDate,a.PatientReceiveID,a.ServiceCategoryCode,a.STT,a.Status,a.EmployeeCode,a.ObjectCode
                        from ServiceLaboratoryEntry a  
                        where a.PatientCode=@PatientCode and a.PatientReceiveID=@PatientReceiveID order by RowID ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dReceive;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable hsba_LaboratoryEntrydetail(string sPatientCode, decimal dReceive)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.RowIDLaboratoryEnTry,a.ServiceCode,a.UnitValues,a.ValuesEntry,a.ValuedFemale,a.ValuedMale,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,a.Normal,a.SuggestedID,a.LaboratoryName
                        from ServiceLaboratoryDetail a inner join ServiceLaboratoryEntry b on a.RowIDLaboratoryEnTry=b.RowID  
                        where b.PatientCode=@PatientCode and b.PatientReceiveID=@PatientReceiveID order by a.RowID ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dReceive;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }
        
        public static DataTable GetResultLaboratoryForReceiveID(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "proView_ResultLaboratoryForReceiveID";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
                param[1].Value = patientCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { return null; }
            return tableResult;
        }
    }
}
