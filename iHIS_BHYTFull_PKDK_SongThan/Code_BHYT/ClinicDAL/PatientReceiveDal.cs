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
    public class PatientReceiveDal
    {
        public static List<PatientReceiveInf> List(decimal rowid)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceiveInf> list = new List<PatientReceiveInf>();
            try
            {
                string sql = string.Empty;
                if (rowid != 0)
                {
                    sql = " select a.PatientReceiveID,a.PatientCode,Reason,a.CreateDate,a.EmployeeCode,a.Status,a.DepartmentCode,a.ObjectCode, a.patientType,a.ReferenceCode,a.EThnicID,a.CareerCode,a.NationalityID,a.ProvincialCode,a.DistrictCode,a.WardCode,a.CompanyInfo,a.[Address],b.MedicalHistory,b.Allergy,IntroName,a.IDTypeReceive,a.PatientReceiveClinic,a.OutDate,a.OrderNumber,a.ConfirmBV01,a.DenominationID,a.IDObjectExempted,a.TNTTID from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode where a.PatientReceiveID ={0} ";
                }
                else
                {
                    sql = " select a.PatientReceiveID,a.PatientCode,Reason,a.CreateDate,a.EmployeeCode,a.Status,a.DepartmentCode,a.ObjectCode, a.patientType,a.ReferenceCode,a.EThnicID,a.CareerCode,a.NationalityID,a.ProvincialCode,a.DistrictCode,a.WardCode,a.CompanyInfo,a.[Address],b.MedicalHistory,b.Allergy,IntroName,a.IDTypeReceive,a.PatientReceiveClinic,a.OutDate,a.OrderNumber,a.ConfirmBV01,a.DenominationID,a.IDObjectExempted,a.TNTTID from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode order by a.PatientReceiveID desc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, rowid), null);
                while (ireader.Read())
                {
                    PatientReceiveInf inf = new PatientReceiveInf();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.Reason = ireader.GetValue(2).ToString();
                    inf.CreateDate = ireader.GetDateTime(3);
                    inf.EmployeeCode = ireader.GetValue(4).ToString();
                    inf.Status = ireader.GetInt32(5);
                    inf.DepartmentCode = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.PatientType = ireader.GetInt32(8);
                    inf.ReferenceCode = ireader.GetValue(9).ToString();
                    inf.EThnicID = ireader.GetInt32(10);
                    inf.CareerCode = ireader.GetValue(11).ToString();
                    inf.NationalityID = ireader.GetInt32(12);
                    inf.ProvincialCode = ireader.GetValue(13).ToString();
                    inf.DistrictCode = ireader.GetValue(14).ToString();
                    inf.WardCode = ireader.GetValue(15).ToString();
                    inf.CompanyInfo = ireader.GetValue(16).ToString();
                    inf.Address = ireader.GetValue(17).ToString();
                    inf.MedicalHistory = ireader.GetValue(18).ToString();
                    inf.Allergy = ireader.GetValue(19).ToString();
                    inf.IntroName = ireader.GetValue(20).ToString();
                    inf.IDTypeReceive = ireader.GetInt32(21);
                    inf.PatientReceiveClinic = ireader.GetValue(22).ToString();
                    if (ireader.GetValue(23) == null || string.IsNullOrEmpty(ireader.GetValue(23).ToString()))
                        inf.OutDate = new DateTime(1990, 01, 01, 01, 01, 01, 01);
                    else
                        inf.OutDate = ireader.GetDateTime(23);
                    inf.OrderNumber = ireader.GetInt32(24);
                    inf.ConfirmBV01 = ireader.GetInt32(25);
                    inf.DenominationID = ireader.GetInt32(26);
                    inf.IDObjectExempted = ireader.GetInt32(27);
                    inf.TNTTID = ireader.GetInt32(28);
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

        public static List<PatientReceive_ViewInf> ListPatientView(string patientCode, decimal receiveID)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceive_ViewInf> list = new List<PatientReceive_ViewInf>();
            try
            {
                string sql = @"
                        select a.PatientReceiveID,a.PatientCode,a.CreateDate DateIn,b.PostingDate DateOut,
                        b.Status,(case when b.Status=1 then N'Kết thúc điều trị' else N'Đang điều trị' end) StatusName,
                        b.Paid,a.ObjectCode,c.ObjectName,a.PatientType,'' as IntroCode,a.IntroName
                        from PatientReceive a left join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID inner join Object c on a.ObjectCode=c.ObjectCode
                        where a.PatientCode in('{0}') ";
                if (receiveID > 0)
                    sql += " and a.PatientReceiveID in({1}) ";
                sql += " order by a.CreateDate desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode, receiveID), null);
                while (ireader.Read())
                {
                    PatientReceive_ViewInf inf = new PatientReceive_ViewInf();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    if (ireader.GetValue(2).ToString() != "")
                        inf.DateIn = ireader.GetDateTime(2);
                    if (ireader.GetValue(3).ToString() != "")
                        inf.DateOut = ireader.GetDateTime(3);
                    inf.Status = ireader.GetValue(4).ToString();
                    inf.StatusName = ireader.GetValue(5).ToString();
                    inf.Paid = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.ObjectName = ireader.GetValue(8).ToString();
                    inf.PatientType = ireader.GetInt32(9);
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

        public static List<PatientReceive_ViewInf> ListPatientView(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceive_ViewInf> list = new List<PatientReceive_ViewInf>();
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[1];
                sqlParameter[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                sqlParameter[0].Value = patientCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, "proPatientReceiveForPayment", sqlParameter);
                while (ireader.Read())
                {
                    PatientReceive_ViewInf inf = new PatientReceive_ViewInf();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    if (ireader.GetValue(2).ToString() != "")
                        inf.DateIn = ireader.GetDateTime(2);
                    if (ireader.GetValue(3).ToString() != "")
                        inf.DateOut = ireader.GetDateTime(3);
                    inf.Status = ireader.GetValue(4).ToString();
                    inf.StatusName = ireader.GetValue(5).ToString();
                    //inf.Paid = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(6);
                    inf.ObjectName = ireader.GetValue(7).ToString();
                    inf.PatientType = ireader.GetInt32(8);
                    inf.DepartmentName = ireader.GetValue(9).ToString();
                    //inf.IntroCode = ireader.GetValue(10).ToString();
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

        public static List<PatientReceiveInf> ListForPatient(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceiveInf> list = new List<PatientReceiveInf>();
            try
            {
                string sql = string.Empty;
                sql = "select PatientReceiveID,PatientCode,Reason,CreateDate,EmployeeCode,Status,DepartmentCode,ObjectCode, PatientType from PatientReceive where PatientCode in('{0}') order by CreateDate desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode), null);
                while (ireader.Read())
                {
                    PatientReceiveInf inf = new PatientReceiveInf();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.Reason = ireader.GetValue(2).ToString();
                    inf.CreateDate = ireader.GetDateTime(3);
                    inf.EmployeeCode = ireader.GetValue(4).ToString();
                    inf.Status = ireader.GetInt32(5);
                    inf.DepartmentCode = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.PatientType = ireader.GetInt32(8);
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

        public static List<PatientReceive_ViewInf> ListForPatient(string patientCode, string dateInto)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceive_ViewInf> list = new List<PatientReceive_ViewInf>();
            try
            {
                string sql = string.Empty;
                sql = "select PatientReceiveID,PatientCode,CreateDate,ObjectCode,PatientType,OutDate,TNTTID from PatientReceive where PatientCode ='{0}' and Convert(date,CreateDate,103)=Convert(date,'{1}',103)  order by CreateDate desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode, dateInto), null);
                while (ireader.Read())
                {
                    PatientReceive_ViewInf inf = new PatientReceive_ViewInf();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.DateIn = ireader.GetDateTime(2);
                    inf.ObjectCode = ireader.GetInt32(3);
                    inf.PatientType = ireader.GetInt32(4);
                    if (ireader.GetValue(5) == null || string.IsNullOrEmpty(ireader.GetValue(5).ToString()))
                        inf.DateOut = new DateTime(1990, 01, 01, 01, 01, 01, 01);
                    else
                        inf.DateOut = ireader.GetDateTime(5);
                    inf.TNTTID = ireader.GetInt32(6);
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

        public static List<PatientReceiveInf> ListCheckPatient(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceiveInf> list = new List<PatientReceiveInf>();
            try
            {
                string sql = string.Empty;
                sql = "select PatientReceiveID,PatientCode,Reason,CreateDate,EmployeeCode,Status,DepartmentCode,ObjectCode, patientType  from PatientReceive where PatientCode in('{0}') and (Status = 0 or Status =1) order by CreateDate desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode), null);
                while (ireader.Read())
                {
                    PatientReceiveInf inf = new PatientReceiveInf();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.Reason = ireader.GetValue(2).ToString();
                    inf.CreateDate = ireader.GetDateTime(3);
                    inf.EmployeeCode = ireader.GetValue(4).ToString();
                    inf.Status = ireader.GetInt32(5);
                    inf.DepartmentCode = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.PatientType = ireader.GetInt32(8);
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

        public static Int32 Ins(PatientReceiveInf info, ref string refCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@vresult", SqlDbType.VarChar, 50);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@Reason", SqlDbType.NVarChar);
                param[3].Value = info.Reason;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar,50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@Status", SqlDbType.Int);
                param[5].Value = info.Status;
                param[6] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 250);
                param[6].Value = info.DepartmentCode;
                param[7] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[7].Value = info.ObjectCode;
                param[8] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[8].Value = info.PatientType;
                param[9] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[9].Value = info.ReferenceCode;
                param[10] = new SqlParameter("@EThnicID", SqlDbType.Int);
                param[10].Value = info.EThnicID;
                param[11] = new SqlParameter("@CareerCode", SqlDbType.VarChar, 10);
                param[11].Value = info.CareerCode;
                param[12] = new SqlParameter("@NationalityID", SqlDbType.Int);
                param[12].Value = info.NationalityID;
                param[13] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[13].Value = info.ProvincialCode;
                param[14] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 5);
                param[14].Value = info.DistrictCode;
                param[15] = new SqlParameter("@WardCode", SqlDbType.VarChar, 8);
                param[15].Value = info.WardCode;
                param[16] = new SqlParameter("@CompanyInfo", SqlDbType.NVarChar, 200);
                param[16].Value = info.CompanyInfo;
                param[17] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[17].Value = info.Address;
                param[18] = new SqlParameter("@IntroName", SqlDbType.NVarChar, 250);
                param[18].Value = info.IntroName;
                param[19] = new SqlParameter("@IDTypeReceive", SqlDbType.Int);
                param[19].Value = info.IDTypeReceive;
                param[20] = new SqlParameter("@PatientReceiveClinic", SqlDbType.VarChar, 30);
                param[20].Value = info.PatientReceiveClinic;
                param[21] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[21].Value = info.ShiftWork;
                param[22] = new SqlParameter("@TNTTID", SqlDbType.Int);
                param[22].Value = info.TNTTID;
                param[23] = new SqlParameter("@IDAppointment247", SqlDbType.NVarChar, 50);
                param[23].Value = info.IDAppointment247;
                param[24] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                param[24].Value = info.CreateDate;
                refCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_PatientReceive", param);
                return 1;
            }
            catch(Exception)  { return -2; }
        }

        public static Int32 InsUpd(PatientReceiveInf info)
        {
            ConnectDB cn = new ConnectDB();
            int iResult = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[4].Value = info.ObjectCode;
                param[5] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[5].Value = info.PatientType;
                param[6] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                param[6].Value = info.CreateDate;
                param[7] = new SqlParameter("@EThnicID", SqlDbType.Int);
                param[7].Value = info.EThnicID;
                param[8] = new SqlParameter("@CareerCode", SqlDbType.VarChar, 10);
                param[8].Value = info.CareerCode;
                param[9] = new SqlParameter("@NationalityID", SqlDbType.Int);
                param[9].Value = info.NationalityID;
                param[10] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[10].Value = info.ProvincialCode;
                param[11] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 5);
                param[11].Value = info.DistrictCode;
                param[12] = new SqlParameter("@WardCode", SqlDbType.VarChar, 8);
                param[12].Value = info.WardCode;
                param[13] = new SqlParameter("@CompanyInfo", SqlDbType.NVarChar, 200);
                param[13].Value = info.CompanyInfo;
                param[14] = new SqlParameter("@IntroName", SqlDbType.VarChar, 250);
                param[14].Value = info.IntroName;
                param[15] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[15].Value = info.Address;
                iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_PatientReceiveUpdate", param));
                return iResult;
            }
            catch { return -2; }
        }

        public static Int32 Del(decimal dPatientReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            int iResult = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = sPatientCode;
                iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_PatientReceive", param));
                return iResult;
            }
            catch { return -2; }
        }

        public static Decimal GetPatientReceive(string patientCode, string referenceCode, DateTime dtWorking)
        {
            ConnectDB cn = new ConnectDB();
            Decimal dId = 0;
            try
            {
                string sql = " select PatientReceiveID from PatientReceive where PatientCode='{0}' and ReferenceCode in('{1}') and convert(char(10),CreateDate,103)=convert(char(10),'{2}',103)";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode, referenceCode, dtWorking.ToString("dd/MM/yyyy")), null);
                if (ireader.Read())
                {
                    dId = ireader.GetDecimal(0);
                }
            }
            catch { dId = 0; }
            return dId;
        }

        public static DataTable DTListPatientsSearch(string patientCode, string fullname, string age, string mobile, string tungay, string denngay)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                string sql = string.Empty;
                string sSearch = string.Empty;
                sql = " select a.PatientCode,a.PatientName, (case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGender,convert(char(10),a.PatientBirthday,103) PatientBirthday,a.PatientBirthyear, a.PatientAge,a.PatientAddress,a.PatientMobile, a.PatientEmail, a.CodeArise,MedicalHistory,a.Allergy,a.IDTypeReceive,a.PatientMonth from Patients a where 1=1 ";
                if (!string.IsNullOrEmpty(tungay) && !string.IsNullOrEmpty(denngay) && tungay.Length == 10 && denngay.Length == 10)
                    sql = " select distinct a.PatientCode,a.PatientName, (case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGender,convert(char(10),a.PatientBirthday,103) PatientBirthday,a.PatientBirthyear, a.PatientAge,a.PatientAddress,a.PatientMobile, a.PatientEmail, a.CodeArise,MedicalHistory,a.Allergy,a.IDTypeReceive,b.PatientReceiveID,a.PatientMonth from Patients a inner join PatientReceive b on a.PatientCode=b.PatientCode where convert(date,b.CreateDate,103) >= convert(date,'" + tungay + "',103) and convert(date,b.CreateDate,103) <= convert(date,'" + denngay + "',103) and b.PatientReceiveID not in(select PatientReceiveID from MedicinesRetail where CONVERT(date,ExportDate,103)>=CONVERT(date,'" + tungay + "',103) and CONVERT(date,ExportDate,103)<=CONVERT(date,'" + denngay + "',103)) ";
                if (!string.IsNullOrEmpty(patientCode))
                {
                    sSearch += " and a.PatientCode like '%{0}'";
                }
                if (!string.IsNullOrEmpty(fullname))
                {
                    sSearch += " and a.PatientName like N'%{1}%'";
                }
                if (!string.IsNullOrEmpty(age) && age.Length < 10)
                {
                    sSearch += " and (a.PatientAge={2} or a.PatientBirthyear ={2} or a.PatientMonth like'%{2}%')";
                }
                if (!string.IsNullOrEmpty(mobile))
                {
                    sSearch += " and a.PatientMobile like'%{3}%'";
                }
                if (!string.IsNullOrEmpty(age) && age.Length == 10)
                {
                    sSearch += " and Convert(date,a.PatientBirthday,103)=Convert(date,'{4}',103)";
                }
                sql += sSearch;
                table = cn.ExecuteQuery(string.Format(sql, patientCode, fullname, age, mobile, age));
            }
            catch { table = null; }
            return table;
        }

        public static DataTable DTCheckExistPatient(string sFullname, string sBirthday, string sGender, string sBirthyear, string sAge, string sAddress)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                string sSearch = "";
                //sql = @" Select a.RowID,a.PatientCode,a.PatientName, (case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGender,
                //        convert(char(10),a.PatientBirthday,103) PatientBirthday,a.PatientBirthyear, 
                //        a.PatientAge,a.PatientAddress,a.PatientMobile, a.PatientEmail, a.CodeArise,MedicalHistory,a.Allergy,b.CreateDate, (case when b.status=0 then N'Chưa khám' else N'Đã khám' end) Status,b.PatientReceiveID 
                //        from Patients a inner join PatientReceive b on a.PatientCode=b.PatientCode where 1=1 ";
                sql = @" Select a.RowID,a.PatientCode,a.PatientName, (case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGender,
                        convert(char(10),a.PatientBirthday,103) PatientBirthday,a.PatientBirthyear, 
                        a.PatientAge,a.PatientAddress,a.PatientMobile, a.PatientEmail, a.CodeArise,MedicalHistory,a.Allergy
                        from Patients a where 1=1 ";
                if (sFullname != "")
                {
                    sSearch = " and a.PatientName like N'%{0}%'";
                }
                else if (sBirthday != "")
                {
                    sSearch = " and convert(char(10),a.PatientBirthday,103) like '%{1}%' ";
                }
                else if (sGender != "")
                {
                    sSearch = " and a.PatientGender like '%{2}%'";
                }
                else if (sBirthyear != "")
                {
                    sSearch += " and a.PatientBirthyear like'%{3}%' ";
                }
                else if (sAge != "")
                    sSearch += " and a.PatientAge like '%{4}%'";
                else if (sAddress != "")
                    sSearch += " and a.PatientAddress like '%{5}%'";
                sql += sSearch;
                dt = cn.ExecuteQuery(string.Format(sql, sFullname, sBirthday, sGender, sBirthyear, sAge, sAddress));

            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable TablePatientWaiting(DateTime dtimeFromDate, DateTime dtimeToDate, Int32 istatus, Int32 iPatientType, string sDepartCode, Int32 iPaid, string employeeCodeDoctor)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dtimeFromDate.ToString("dd/MM/yyyy");
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = istatus;
                param[2] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[2].Value = iPatientType;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = sDepartCode;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = iPaid;
                param[5] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[5].Value = dtimeToDate.ToString("dd/MM/yyyy");
                param[6] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar);
                param[6].Value = employeeCodeDoctor;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_PatientWaiting", param);
            }
            catch { return null; }

        }

        public static DataTable DT_WaitingEmergency(Int32 istatus, Int32 iPatientType, string sDepartCode, DateTime fromDate, DateTime toDate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Status", SqlDbType.Int);
                param[0].Value = istatus;
                param[1] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[1].Value = iPatientType;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[2].Value = sDepartCode;
                param[3] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[3].Value = fromDate;
                param[4] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[4].Value = toDate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_WaitingForEmergency", param);
            }
            catch { return null; }
        }

        public static DataTable DT_WaitingService(DateTime dtime, Int32 istatus, string sDepartCode, Int32 iPaid, Int32 iMenu)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                param[0].Value = dtime;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = istatus;
                //param[2] = new SqlParameter("@PatientType", SqlDbType.Int);
                //param[2].Value = iPatientType;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[2].Value = sDepartCode;
                param[3] = new SqlParameter("@Paid", SqlDbType.Int);
                param[3].Value = iPaid;
                param[4] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[4].Value = iMenu;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_WaitingService", param);
            }
            catch { return null; }
        }

        public static DataTable DT_WaitingService(DateTime dtimeFrom, DateTime dtimeTo, Int32 istatus, string sDepartCode, Int32 iPaid, Int32 iMenu, string employeeCodeDoctor)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                param[0].Value = dtimeFrom;
                param[1] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                param[1].Value = dtimeTo;
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Value = istatus;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = sDepartCode;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = iPaid;
                param[5] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[5].Value = iMenu;
                param[6] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[6].Value = employeeCodeDoctor;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_WaitingServiceForDate", param);
            }
            catch { return null; }
        }

        public static DataTable DT_WaitingServicePTT(DateTime dtimeFrom, DateTime dtimeTo, Int32 istatus, string sDepartCode, Int32 iPaid, Int32 iMenu)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                param[0].Value = dtimeFrom;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = istatus;
                //param[2] = new SqlParameter("@PatientType", SqlDbType.Int);
                //param[2].Value = iPatientType;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[2].Value = sDepartCode;
                param[3] = new SqlParameter("@Paid", SqlDbType.Int);
                param[3].Value = iPaid;
                param[4] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[4].Value = iMenu;
                param[5] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                param[5].Value = dtimeTo;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_WaitingServicePTT", param);
            }
            catch { return null; }
        }

        public static DataTable TableWaitingServiceImmunization(DateTime dtFrom, DateTime dtTo, Int32 status, string departmentCode, Int32 paid, Int32 menu)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[1].Value = dtTo;
                param[2] = new SqlParameter("@ImmunizationStatus", SqlDbType.Int);
                param[2].Value = status;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = departmentCode;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = paid;
                param[5] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[5].Value = menu;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proWaitingServiceImmunization", param);
            }
            catch { return null; }
        }
        
        public static DataTable DT_WaitingGetTemplate(DateTime dtime, Int32 istatus, string sDepartCode, Int32 iPaid, string sCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                param[0].Value = dtime;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = istatus;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[2].Value = sDepartCode;
                param[3] = new SqlParameter("@Paid", SqlDbType.Int);
                param[3].Value = iPaid;
                param[4] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[4].Value = sCategoryCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ForLaboratoryGetTemplate", param);
            }
            catch { return null; }
        }

        public static DataTable DT_PatientWaitingDetail(decimal dReceiveID, string sDepartmentCode, string sServiceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[1].Value = sDepartmentCode;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[2].Value = sServiceCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_PatientWaitingDetail", param);
            }
            catch { return null; }
        }

        public static DataTable DataWaitingLaboratory(DateTime dateStart, DateTime dateEnd, int status, string idmauxn, int paid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@DateStart", SqlDbType.Char, 10);
                param[0].Value = dateStart.ToString("dd/MM/yyyy");
                param[1] = new SqlParameter("@DateEnd", SqlDbType.Char, 10);
                param[1].Value = dateEnd.ToString("dd/MM/yyyy");
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Value = status;
                param[3] = new SqlParameter("@STT", SqlDbType.VarChar);
                param[3].Value = idmauxn;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = paid;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proWaitingLaboratory", param);
            }
            catch { return null; }
        }

        public static DataTable DT_PatientWaitingEmergency(decimal dReceiveID, decimal dSuggestedID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[1].Value = dSuggestedID;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_PatientWaitingEmergency", param);
            }
            catch { return null; }
        }

        public static DataTable DT_StatisticReceive()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("ReportStatistic");
            try
            {
                dt.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DepartmentName", typeof(string)));
                dt.Columns.Add(new DataColumn("Chuakham", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Dakham", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Captoa", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Tong", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                dt.Columns.Add(new DataColumn("ServiceGroupCode", typeof(string)));
                string sql = @" select count(*) Tong,b.DepartmentCode,c.DepartmentName,CONVERT(char(10),b.CreateDate,103) Date,c.ServiceGroupCode
                        from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Department c on b.DepartmentCode=c.DepartmentCode
                        where CONVERT(char(10),b.CreateDate,103)= CONVERT(char(10),getdate(),103) and ServiceCode not in('DV000000') and b.ReceiptID_DisparityPrice=0
                        group by b.DepartmentCode,c.DepartmentName,CONVERT(char(10),b.CreateDate,103),c.ServiceGroupCode ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = ireader.GetString(1);
                    dr[1] = ireader.GetString(2);
                    dr[2] = 0;
                    dr[3] = 0;
                    dr[4] = 0;
                    dr[5] = ireader.GetValue(0);
                    dr[6] = ireader.GetValue(3);
                    dr[7] = ireader.GetValue(4).ToString();
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                foreach (DataRow dr in dt.Rows)
                {
                    string temp = dr["DepartmentCode"].ToString();
                    string query = "select distinct a.RefID from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode where CONVERT(date,a.WorkDate,103)=CONVERT(date,'{0}',103) and a.DepartmentCode='{1}' and a.Status in(0) ";
                    DataTable tableServices = cn.ExecuteQuery(string.Format(query, dr["Date"].ToString(), dr["DepartmentCode"].ToString()));
                    dr["Chuakham"] = tableServices.Rows.Count;
                    query = @" select distinct a.DepartmentCode,a.RefID from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode where CONVERT(date,a.WorkDate,103)=CONVERT(date,'{0}',103) and a.DepartmentCode='{1}' 
                        and a.Status not in(0) and RefID not in(select a.RefID from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode where CONVERT(date,a.WorkDate,103)=CONVERT(date,'{0}',103) and a.DepartmentCode='{1}' and a.Status in(0))";
                    DataTable tableServicesDone = cn.ExecuteQuery(string.Format(query, dr["Date"].ToString(), dr["DepartmentCode"].ToString()));
                    dr["Dakham"] = tableServicesDone.Rows.Count;
                    dr["Tong"] = tableServices.Rows.Count + tableServicesDone.Rows.Count;
                    if (dr["ServiceGroupCode"].Equals("KCB"))
                    {
                        query = @"select distinct PatientReceiveID from MedicalRecord where DepartmentCode in('{0}') and CONVERT(char(10),PostingDate,103)= CONVERT(char(10),'{1}',103) and Status=1";
                        tableServicesDone = cn.ExecuteQuery(string.Format(query, dr["DepartmentCode"].ToString(), dr["Date"].ToString()));
                        dr["Captoa"] = tableServicesDone.Rows.Count;
                    }
                }
            }
            catch { }
            return dt;
        }

        public static DataTable DT_StatisticChart()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("ReportStatistic");
            try
            {
                dt.Columns.Add(new DataColumn("Tong", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                string query = @" select count(*) Tong,CONVERT(date,b.CreateDate,103) Date
                        from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Department c on b.DepartmentCode=c.DepartmentCode
                        where b.Note='TIEPDON' and CONVERT(date,b.CreateDate,103) between CONVERT(date,getdate()-30,103) and CONVERT(date,getdate(),103)
                        group by CONVERT(date,b.CreateDate,103) order by CONVERT(date,b.CreateDate,103) asc ";
                //string query = "select count(*) Tong,CONVERT(date,a.CreateDate,103) Date from PatientReceive a where CONVERT(date,a.CreateDate,103) between CONVERT(date,sysdatetime()-30,103) and CONVERT(date,sysdatetime(),103) group by CONVERT(date,a.CreateDate,103)";
                dt = cn.ExecuteQuery(query);
            }
            catch { }
            return dt;
        }

        public static DataTable DT_ReportReceive(string sfrom, string sto, bool checkReceive, string groupCode, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("Report");
            try
            {
                dt.Columns.Add(new DataColumn("Total", typeof(Int32)));
                dt.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DepartmentName", typeof(string)));
                string sql = @" select count(*) Total,b.DepartmentCode,c.DepartmentName,CONVERT(date,b.CreateDate,103) WorkDate
                        from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID 
                        inner join Department c on b.DepartmentCode=c.DepartmentCode
                        where CONVERT(date,b.CreateDate,103) between CONVERT(date,'{0}',103) and  CONVERT(date,'{1}',103)";
                if (!checkReceive)
                    sql += " and b.ServiceCode not in('DV000000')";
                if (!string.IsNullOrEmpty(groupCode) && groupCode != "0")
                    sql += " and c.ServiceGroupCode in('{2}') ";
                if (!string.IsNullOrEmpty(serviceCode))
                    sql += " and b.ServiceCode in({3})";
                sql += "group by b.DepartmentCode,c.DepartmentName,CONVERT(date,b.CreateDate,103) order by  CONVERT(date,b.CreateDate,103) desc ";
                dt = cn.ExecuteQuery(string.Format(sql, sfrom, sto, groupCode, serviceCode));
            }
            catch { }
            return dt;
        }

        public static DataTable DT_ListReportReceive(string sfrom, string sto, string groupCode, bool checkReceive, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("ReportList");
            try
            {
                string sql = @"select a.PatientCode,b.PatientName,b.PatientBirthyear,(case when b.PatientGender = '1' then N'Nam' else N'Nữ' end) PatientGenderName,d.DepartmentName,a.IntroName,
                a1.ServicePrice,a1.AmountExemption,a1.ServiceCode,a2.ServiceName,(case when a1.Status = 1 then N'Đã thực hiện' when a1.Status=2 then N'Lấy mẫu' else N'Chưa thực hiện' end) StatusName,a.Reason,(case a.IDTypeReceive when 1 then N'Tự đến' when 2 then N'Bác sĩ giới thiệu' when 3 then N'Khám theo lịch hẹn' else '' end) TypeReceive, Convert(date,a.CreateDate,103) CreateDate,b.PatientBirthday,b.PatientAge,b.PatientMobile,
                [dbo].func_PatientOfAddressFull(b.PatientAddress,w.WardName,di.DistrictName,pr.ProvincialName) PatientAddress,a3.ObjectName
                from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join Department d on a.DepartmentCode=d.DepartmentCode 
                inner join SuggestedServiceReceipt a1 on a.PatientReceiveID=a1.RefID inner join Service a2 on a1.ServiceCode=a2.ServiceCode inner join [Object] a3 on a1.ObjectCode = a3.ObjectCode
                left join Catalog_Ward w on b.WardCode=w.WardCode left join Catalog_District di on b.DistrictCode=di.DistrictCode left join Catalog_Provincial pr on b.ProvincialCode=pr.ProvincialCode
                where CONVERT(date,a.CreateDate,103) >= CONVERT(date,'{0}',103) and CONVERT(date,a.CreateDate,103) <= CONVERT(date,'{1}',103)";
                if (!string.IsNullOrEmpty(groupCode) && groupCode != "0")
                    sql += " and a2.ServiceGroupCode in('{2}') ";
                if (!checkReceive)
                    sql += " and a1.ServiceCode not in('DV000000')";
                if (!string.IsNullOrEmpty(serviceCode))
                    sql += " and a1.ServiceCode in({3})";
                sql += " order by a.CreateDate asc ";
                dt = cn.ExecuteQuery(string.Format(sql, sfrom, sto, groupCode, serviceCode));
            }
            catch { }
            return dt;
        }

        public static DataTable DT_ListReportReceive(string sfrom, string sto, Int32 result)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("ReportList");
            try
            {
                string sql = @"  select a.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthyear,c.DiagnosisName,a.PostingDate,(case when b.PatientGender = '1' then N'Nam' else N'Nữ' end) PatientGenderName
                             from MedicalRecord a inner join Patients b on a.PatientCode=b.PatientCode inner join Diagnosis c on a.DiagnosisCode=c.RowID
                            where CONVERT(date,a.PostingDate,103) between CONVERT(date,'{0}',103) and  CONVERT(date,'{1}',103)
                            order by a.PostingDate ";
                dt = cn.ExecuteQuery(string.Format(sql, sfrom, sto));
            }
            catch { }
            return dt;
        }

        public static Int32 CheckPresentPatient(string patientCode, Int32 iCheck, decimal patientReceiveID, ref string sError)
        {
            try
            {
                ConnectDB cn = new ConnectDB();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = patientReceiveID;
                param[3] = new SqlParameter("@Check", SqlDbType.Int);
                param[3].Value = iCheck;
                int iResult = int.Parse(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_PresentPatient", param));
                if (iResult == -1)
                    sError = " Bệnh nhân đã kết thúc điều trị không cho phép sửa!";
                else if (iResult == -2)
                    sError = " Bệnh nhân đang lưu bệnh, đề nghị kết thúc hồ sơ trước khi tiếp nhận mới!";
                else if (iResult == -3)
                    sError = " Bệnh nhân đã đăng ký khám trước đó (hoặc hồ sơ cũ chưa kết thúc), không được phép tiếp đón nữa!";
                else
                    sError = string.Empty;
                return iResult;
            }
            catch { return 0; }
        }

        public static Int32 UpdPatientForStatus(decimal patientReceiveID, string patientCode, int status)
        {
            try
            {
                string sql = " update PatientReceive set status=@Status,OutDate=getdate() where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and PatientType=1 ";
                if (status == 1)
                    sql = " update PatientReceive set status=@Status,OutDate=null where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and PatientType=1 ";
                ConnectDB cn = new ConnectDB();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Value = status;
                int iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
                return iResult;
            }
            catch { return 0; }
        }

        public static Int32 UpdPatientReceiveForReason(decimal patientReceiveID, string patientCode, string reason)
        {
            try
            {
                string sql = " update PatientReceive set Reason=@Reason and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode ";
                ConnectDB cn = new ConnectDB();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@Reason", SqlDbType.NVarChar, 250);
                param[2].Value = reason;
                int iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
                return iResult;
            }
            catch { return 0; }
        }

        public static Int32 UpdPatientForStatus(string patientCode, int status)
        {
            try
            {
                string sql = " update PatientReceive set status=@Status,OutDate=getdate() where PatientCode=@PatientCode and Status in(0)";
                ConnectDB cn = new ConnectDB();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Value = status;
                int iResult = int.Parse(cn.ExecuteReaderProcedure(CommandType.Text, sql, param));
                return iResult;
            }
            catch { return 0; }
        }

        public static Int32 UpdPatientForStatus(string dateFrom, string dateTo, int status)
        {
            try
            {
                string sql = " update PatientReceive set status={0},OutDate=getdate() where CONVERT(date,CreateDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{2}',103) and Status in(0) ";
                ConnectDB cn = new ConnectDB();
                //SqlParameter[] param = new SqlParameter[3];
                //param[0] = new SqlParameter("@Status", SqlDbType.Int);
                //param[0].Value = status;
                //param[1] = new SqlParameter("@DateFrom", SqlDbType.Char);
                //param[1].Value = dateFrom;
                //param[2] = new SqlParameter("@DateTo", SqlDbType.Char);
                //param[2].Value = dateTo;
                int iResult = cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, status, dateFrom, dateTo), null);
                return iResult;
            }
            catch { return 0; }
        }

        public static Int32 UpdPatientReceiveBarcode(decimal patientReceiveID, string patientCode, string barcode)
        {
            try
            {
                string sql = " update PatientReceive set BarcodeBHYT=@BarcodeBHYT where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode ";
                ConnectDB cn = new ConnectDB();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@BarcodeBHYT", SqlDbType.NVarChar);
                param[2].Value = barcode;
                int iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
                return iResult;
            }
            catch { return 0; }
        }

        public static Int32 UpdPatientReceiveConfirmBV01(string patientReceiveID, int confirmBV01)
        {
            try
            {
                string sql = " update PatientReceive set ConfirmBV01={0} where PatientReceiveID in({1})";
                ConnectDB cn = new ConnectDB();
                int iResult = cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, confirmBV01, patientReceiveID));
                return iResult;
            }
            catch { return -1; }
        }

        public static Int32 DelEmergencyOut(string sPatientCode, decimal dPatientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = sPatientCode;
                Int32 iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_CheckMedicalEmergency", param));
                return iResult;
            }
            catch { return 0; }
        }
        
        public static DataTable DT_View_PatientReceive(DateTime dtfrDate, DateTime dttoDate, Int32 iType, string sms)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@frDate", SqlDbType.Date);
                param[0].Value = dtfrDate;
                param[1] = new SqlParameter("@toDate", SqlDbType.Date);
                param[1].Value = dttoDate;
                param[2] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[2].Value = iType;
                param[3] = new SqlParameter("@SMS", SqlDbType.Char);
                param[3].Value = sms;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_PatientReceive", param);
            }
            catch{
                return null; }
        }

        public static DataTable DT_View_ListReportReceive(string startDate, string endDate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@StartDate", SqlDbType.Char, 10);
                param[0].Value = startDate;
                param[1] = new SqlParameter("@EndDate", SqlDbType.Char, 10);
                param[1].Value = endDate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_ListReportReceive", param);
            }
            catch { return null; }
        }

        public static DataTable TableTypeReceive()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string query = "";
                query = "select RowID,ReceiveName from CatalogTypeReceive where RowID not in(0) order by RowID ";
                dt = cn.ExecuteQuery(query);
            }
            catch {  }
            return dt;
        }

        public static DataTable hsba_DTReceive(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("PatientReceiveID", typeof(decimal));
            dtResult.Columns.Add("PatientCode", typeof(string));
            dtResult.Columns.Add("Reason", typeof(string));
            dtResult.Columns.Add("CreateDate", typeof(DateTime));
            dtResult.Columns.Add("EmployeeCode", typeof(string));
            dtResult.Columns.Add("Status", typeof(Int32));
            dtResult.Columns.Add("ObjectCode", typeof(Int32));
            dtResult.Columns.Add("PatientType", typeof(Int32));
            dtResult.Columns.Add("ReferenceCode", typeof(string));
            dtResult.Columns.Add("DepartmentCode", typeof(string));
            dtResult.Columns.Add("OutDate", typeof(DateTime));
            try
            {
                string sql = @" select PatientReceiveID,PatientCode,Reason,CreateDate,EmployeeCode,Status,ObjectCode,PatientType,ReferenceCode,DepartmentCode,OutDate
                        from PatientReceive where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = Convert.ToDecimal(ireader.GetValue(0).ToString());
                    dr[1] = ireader.GetValue(1).ToString();
                    dr[2] = ireader.GetValue(2).ToString();
                    dr[3] = Convert.ToDateTime(ireader.GetValue(3).ToString());
                    dr[4] = ireader.GetValue(4).ToString();
                    dr[5] = Convert.ToInt32(ireader.GetValue(5).ToString());
                    dr[6] = Convert.ToInt32(ireader.GetValue(6).ToString());
                    dr[7] = Convert.ToInt32(ireader.GetValue(7).ToString());
                    dr[8] = ireader.GetValue(8).ToString();
                    dr[9] = ireader.GetValue(9).ToString();
                    if (ireader.GetValue(10).ToString() != "")
                        dr[10] = Convert.ToDateTime(ireader.GetValue(10).ToString());
                    dtResult.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dtResult;
        }

        public static Int32 UpdPatientInfo(decimal patientReceiveID, string patientCode, int eThnicID, string careerCode, int nationalityID, string provincialCode, string districtCode, string wardCode, string companyInfo, string address, DateTime patientBirthday, int patientAge, int patientBirthyear)
        {
            ConnectDB cn = new ConnectDB();
            int iResult = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = patientCode;
                param[3] = new SqlParameter("@EThnicID", SqlDbType.Int);
                param[3].Value = eThnicID;
                param[4] = new SqlParameter("@CareerCode", SqlDbType.VarChar, 10);
                param[4].Value = careerCode;
                param[5] = new SqlParameter("@NationalityID", SqlDbType.Int);
                param[5].Value = nationalityID;
                param[6] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[6].Value = provincialCode;
                param[7] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 5);
                param[7].Value = districtCode;
                param[8] = new SqlParameter("@WardCode", SqlDbType.VarChar, 8);
                param[8].Value = wardCode;
                param[9] = new SqlParameter("@CompanyInfo", SqlDbType.NVarChar, 200);
                param[9].Value = companyInfo;
                param[10] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[10].Value = address;
                param[11] = new SqlParameter("@PatientBirthday", SqlDbType.Date);
                param[11].Value = patientBirthday;
                param[12] = new SqlParameter("@PatientAge", SqlDbType.Int);
                param[12].Value = patientAge;
                param[13] = new SqlParameter("@PatientBirthyear", SqlDbType.Int);
                param[13].Value = patientBirthyear;
                iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proUpd_PatientInfomation", param));
                return iResult;
            }
            catch { return -2; }
        }

        public static DataTable ViewListIDAppointment()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewListIDAppointment247");
            }
            catch { return null; }
        }

        public static DataTable DT_View_PatientReceiveForDate(DateTime dtimeFrom, DateTime dtimeTo, Int32 status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = dtimeFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = dtimeTo;
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Value = status;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewSuggestedForDate", param);
            }
            catch
            {
                return null;
            }
        }

        public static DataTable DataWaitingDV(DateTime dateStart, DateTime dateEnd, int status, int paid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@DateStart", SqlDbType.Char, 10);
                param[0].Value = dateStart.ToString("dd/MM/yyyy");
                param[1] = new SqlParameter("@DateEnd", SqlDbType.Char, 10);
                param[1].Value = dateEnd.ToString("dd/MM/yyyy");
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Value = status;
                //param[3] = new SqlParameter("@STT", SqlDbType.VarChar);
                //param[3].Value = idmauxn;
                param[3] = new SqlParameter("@Paid", SqlDbType.Int);
                param[3].Value = paid;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, "proWaiting_DuyetVTTH_KemDichVu", param);
                return dt;
            }
            catch { return null; }
        }

    }
}
