using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using ClinicModel;


namespace ClinicDAL
{
    public class PatientAppointment_DAL
    {
        public static PatientAppointment_INF ObjAppointment(decimal dReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            PatientAppointment_INF inf = new PatientAppointment_INF();
            try
            {
                string sql = "";
                sql = "select PatientCode,ExaminationDate,AppointmentDate,PatientReceiveID,EmloyeeCode,AppointmentNote,STT from PatientAppointment where PatientReceiveID in({0}) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dReceiveID), null);
                if(ireader.Read())
                {
                    inf.PatientCode = ireader.GetString(0);
                    inf.ExaminationDate = ireader.GetDateTime(1);
                    inf.AppointmentDate = ireader.GetDateTime(2);
                    inf.PatientReceiveID = ireader.GetDecimal(3);
                    inf.EmloyeeCode = ireader.GetString(4);
                    inf.AppointmentNote = ireader.GetValue(5).ToString();
                    inf.STT = ireader.GetInt32(6);
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

        public static PatientAppointment_INF ObjAppointment(string sPatientCode, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            PatientAppointment_INF inf = new PatientAppointment_INF();
            try
            {
                string sql = "";
                sql = "select PatientCode,ExaminationDate,AppointmentDate,PatientReceiveID,EmloyeeCode,AppointmentNote,STT from PatientAppointment where PatientCode in('{0}') and convert(date,AppointmentDate,103)=convert(date,'{1}',103)";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, sDate), null);
                if (ireader.Read())
                {
                    inf.PatientCode = ireader.GetString(0);
                    inf.ExaminationDate = ireader.GetDateTime(1);
                    inf.AppointmentDate = ireader.GetDateTime(2);
                    inf.PatientReceiveID = ireader.GetDecimal(3);
                    inf.EmloyeeCode = ireader.GetString(4);
                    inf.AppointmentNote = ireader.GetValue(5).ToString();
                    inf.STT = ireader.GetInt32(6);
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

        public static Int32 UpdStatus(string sPatientCode, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            PatientAppointment_INF inf = new PatientAppointment_INF();
            try
            {
                string sql = "";
                sql = "update PatientAppointment set status=1 where PatientCode in('{0}') and convert(date,AppointmentDate,103)=convert(date,'{1}',103)";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, sPatientCode, sDate));
                
            }
            catch { return -1; }
        }

        public static DataTable DTListAppointmentSearch(string sPatientCode, string sFullname, string sAge, string sMobile, string sFrom, string sTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                string sSearch = string.Empty;
                sql = @" select convert(char(10),b.AppointmentDate,103) AppointmentDate,b.STT,b.AppointmentNote,a.PatientCode,a.PatientName, 
                    (case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGender,a.PatientBirthyear, a.PatientAge,
                    a.PatientAddress,a.PatientMobile, a.PatientEmail, a.CodeArise,MedicalHistory,a.Allergy
                     from Patients a inner join PatientAppointment b on a.PatientCode=b.PatientCode 
                     where 1=1 and b.Done = 0 ";
                if (sPatientCode != "")
                {
                    sSearch = " and a.PatientCode like '%{0}%'";
                }
                else if (sFullname != "")
                {
                    sSearch = " and a.PatientName like N'%{1}%' ";
                }
                else if (sAge != "")
                {
                    sSearch = " and a.PatientBirthyear like '%{2}%'";
                }
                else if (sMobile != "")
                {
                    sSearch += " and a.PatientMobile like'%{3}%' ";
                }
                else if (sFrom != "" && sTo != "")
                    sSearch += " and convert(date,b.AppointmentDate,103) between convert(date,'{4}',103) and convert(date,'{5}',103)";
                sql += sSearch;
                dt = cn.ExecuteQuery(string.Format(sql, sPatientCode, sFullname, sAge, sMobile, sFrom, sTo));

            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 Ins(PatientAppointment_INF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = info.PatientCode;
                param[1] = new SqlParameter("@ExaminationDate", SqlDbType.DateTime);
                param[1].Value = info.ExaminationDate;
                param[2] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[2].Value = info.AppointmentDate;
                param[3] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[3].Value = info.PatientReceiveID;
                param[4] = new SqlParameter("@EmloyeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmloyeeCode;
                param[5] = new SqlParameter("@AppointmentNote", SqlDbType.NVarChar, 250);
                param[5].Value = info.AppointmentNote;
                param[6] = new SqlParameter("@STT", SqlDbType.Int);
                param[6].Value = info.STT;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_PatientAppointment", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 InsRegister(PatientAppointmentFullInf info, ref DateTime dtimeOld, ref string sHour)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = info.PatientCode;
                param[1] = new SqlParameter("@ExaminationDate", SqlDbType.DateTime);
                param[1].Value = info.ExaminationDate;
                param[2] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[2].Value = info.AppointmentDate;
                param[3] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[3].Value = info.PatientReceiveID;
                param[4] = new SqlParameter("@EmloyeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmloyeeCode;
                param[5] = new SqlParameter("@AppointmentNote", SqlDbType.NVarChar, 250);
                param[5].Value = info.AppointmentNote;
                param[6] = new SqlParameter("@STT", SqlDbType.Int);
                param[6].Value = info.STT;
                param[7] = new SqlParameter("@AppointmentHour", SqlDbType.VarChar, 10);
                param[7].Value = info.AppointmentHour;
                param[8] = new SqlParameter("@Done", SqlDbType.Int);
                param[8].Value = info.Done;
                param[9] = new SqlParameter("@StatusID", SqlDbType.Int);
                param[9].Value = info.StatusID;
                param[10] = new SqlParameter("@LableID", SqlDbType.Int);
                param[10].Value = info.LableID;
                param[11] = new SqlParameter("@AppointmentDateOld", SqlDbType.DateTime);
                param[11].Value = dtimeOld;
                param[12] = new SqlParameter("@AppointmentHourOld", SqlDbType.VarChar, 10);
                param[12].Value = sHour;
                param[13] = new SqlParameter("@iresult", SqlDbType.Int);
                param[13].Direction = ParameterDirection.Output;
                int iresul = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_AppointmentRegister", param));
                return iresul;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sPatientCode, DateTime dtAppoint)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from PatientAppointment where PatientCode=@PatientCode and CONVERT(date,AppointmentDate,103)=CONVERT(date,@AppointmentDate,103) and status=0";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[2] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[2].Value = dtAppoint;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sPatientCode, decimal dReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from PatientAppointment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and status=0";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = dReceiveID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static DataTable hsba_Appointment(string sPatientCode, decimal dReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                sql = @" select RowID,PatientCode,ExaminationDate,AppointmentDate,PatientReceiveID,EmloyeeCode,AppointmentNote,STT,AppointmentHour,Done,StatusID,LableID from PatientAppointment where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 10);
                param[1].Value = sPatientCode;
                dt = cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { dt = null; }
            return dt;
        }
    }
}
