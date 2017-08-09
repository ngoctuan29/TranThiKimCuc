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
    public class SurgeriesDAL
    {
        public static Int32 Ins(SurgeriesINF info, ref string sSurgeriesCode, decimal dSuggestedID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[24];
                param[0] = new SqlParameter("@SurgeriesCode", SqlDbType.VarChar, 15);
                param[0].Value = info.SurgeriesCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[2].Value = info.DepartmentCode;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@DateOn", SqlDbType.Char);
                param[4].Value = info.DateOn;
                param[5] = new SqlParameter("@TimeOn", SqlDbType.Char);
                param[5].Value = info.TimeOn;
                param[6] = new SqlParameter("@DateOut", SqlDbType.Char);
                param[6].Value = info.DateOut;
                param[7] = new SqlParameter("@TimeOut", SqlDbType.Char);
                param[7].Value = info.TimeOut;
                param[8] = new SqlParameter("@ICD10On", SqlDbType.VarChar, 10);
                param[8].Value = info.ICD10On;
                param[9] = new SqlParameter("@ICD10Out", SqlDbType.VarChar, 10);
                param[9].Value = info.ICD10Out;
                param[10] = new SqlParameter("@IDAnesthesia", SqlDbType.Int);
                param[10].Value = info.IDAnesthesia;
                param[11] = new SqlParameter("@IDComplications", SqlDbType.Int);
                param[11].Value = info.IDComplications;
                param[12] = new SqlParameter("@IDTheSituation", SqlDbType.Int);
                param[12].Value = info.IDTheSituation;
                param[13] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[13].Value = info.Content;
                param[14] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[14].Value = info.Note;
                param[15] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[15].Value = info.ObjectCode;
                param[16] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[16].Value = info.PatientReceiveID;
                param[17] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[17].Value = info.PatientType;
                param[18] = new SqlParameter("@EmployeeCodeUpd", SqlDbType.VarChar,50);
                param[18].Value = info.EmployeeCodeUpd;
                param[19] = new SqlParameter("@IDSuggested", SqlDbType.Decimal);
                param[19].Value = info.IDSuggested;
                param[20] = new SqlParameter("@DiagnosisCustomOn", SqlDbType.NVarChar, 250);
                param[20].Value = info.DiagnosisCustomOn;
                param[21] = new SqlParameter("@DiagnosisCustomOut", SqlDbType.NVarChar, 250);
                param[21].Value = info.DiagnosisCustomOut;
                param[22] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[22].Value = info.ShiftWork;
                param[23] = new SqlParameter("@vresult", SqlDbType.VarChar, 15);
                param[23].Direction = ParameterDirection.Output;
                sSurgeriesCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_Surgeries", param);
                return 1;
            }
            catch { return -2; }
        }

        public static Int32 InsSurgicalCrew(string sSurgeriesCode, string sEmployeeCode, Int32 iPositionCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@SurgeriesCode", SqlDbType.VarChar, 15);
                param[0].Value = sSurgeriesCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = sEmployeeCode;
                param[2] = new SqlParameter("@PositionCode", SqlDbType.Int);
                param[2].Value = iPositionCode;
                sSurgeriesCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_SurgicalCrew", param);
                return 1;
            }
            catch { return -2; }
        }

        public static Int32 DelSurgicalCrew(string sSurgeriesCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                sql = "delete from SurgicalCrew where  SurgeriesCode='{0}' ";
                Int32 iresult = cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, sSurgeriesCode));
                return iresult;
            }
            catch
            {
                return -1;
            }
        }

        public static Int32 DelSurgeries(string sSurgeriesCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SurgeriesCode", SqlDbType.VarChar, 15);
                param[0].Value = sSurgeriesCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                Int32 iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_Surgeries", param));
                return iresult;
            }
            catch
            {
                return -1;
            }
        }

        public static Int32 DucTin_DelSurgeries(string sSurgeriesCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SurgeriesCode", SqlDbType.VarChar, 15);
                param[0].Value = sSurgeriesCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                Int32 iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "DucTinDel_Surgeries", param));
                return iresult;
            }
            catch
            {
                return -1;
            }

        }

        public static SurgeriesINF ObjSurgeries(decimal dSuggested)
        {
            ConnectDB cn = new ConnectDB();
            SurgeriesINF inf = new SurgeriesINF();
            try
            {
                string sql = "";
                sql = "select RowID,SurgeriesCode,DateOn,TimeOn,DateOut,TimeOut,ICD10On,ICD10Out,IDAnesthesia,IDComplications,IDTheSituation,Content,Note,EmployeeCode,ObjectCode,PatientCode,PatientType,EmployeeCodeUpd,IDate,UDate,Paid,BanksAccountCode,PatientReceiveID,DiagnosisCustomOn,DiagnosisCustomOut from Surgeries where  IDSuggested={0} ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dSuggested), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.SurgeriesCode = ireader.GetString(1);
                    inf.DateOn = ireader.GetValue(2).ToString();
                    inf.TimeOn = ireader.GetValue(3).ToString();
                    inf.DateOut = ireader.GetValue(4).ToString();
                    inf.TimeOut = ireader.GetValue(5).ToString();
                    inf.ICD10On = ireader.GetString(6);
                    inf.ICD10Out = ireader.GetValue(7).ToString();
                    inf.IDAnesthesia = ireader.GetInt32(8);
                    inf.IDComplications = ireader.GetInt32(9);
                    inf.IDTheSituation = ireader.GetInt32(10);
                    inf.Content = ireader.GetValue(11).ToString();
                    inf.Note = ireader.GetValue(12).ToString();
                    inf.EmployeeCode = ireader.GetValue(13).ToString();
                    inf.ObjectCode = ireader.GetInt32(14);
                    inf.PatientCode = ireader.GetValue(15).ToString();
                    inf.PatientType = ireader.GetInt32(16);
                    inf.EmployeeCodeUpd = ireader.GetValue(17).ToString();
                    inf.IDate = ireader.GetDateTime(18);
                    inf.UDate = ireader.GetDateTime(19);
                    inf.Paid = ireader.GetInt32(20);
                    inf.BanksAccountCode = ireader.GetValue(21).ToString();
                    inf.PatientReceiveID = ireader.GetDecimal(22);
                    inf.DiagnosisCustomOn = ireader.GetValue(23).ToString();
                    inf.DiagnosisCustomOut = ireader.GetValue(24).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                inf = null;
            }
            return inf;
        }

        public static SurgeriesINF ObjSurgeriesForID(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            SurgeriesINF inf = new SurgeriesINF();
            try
            {
                string sql = "";
                sql = "select RowID,SurgeriesCode,DateOn,TimeOn,DateOut,TimeOut,ICD10On,ICD10Out,IDAnesthesia,IDComplications,IDTheSituation,Content,Note,EmployeeCode,ObjectCode,PatientCode,PatientType,EmployeeCodeUpd,IDate,UDate,Paid,BanksAccountCode,PatientReceiveID,DiagnosisCustomOn,DiagnosisCustomOut from Surgeries where  RowID={0} ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.SurgeriesCode = ireader.GetString(1);
                    inf.DateOn = ireader.GetValue(2).ToString();
                    inf.TimeOn = ireader.GetValue(3).ToString();
                    inf.DateOut = ireader.GetValue(4).ToString();
                    inf.TimeOut = ireader.GetValue(5).ToString();
                    inf.ICD10On = ireader.GetString(6);
                    inf.ICD10Out = ireader.GetValue(7).ToString();
                    inf.IDAnesthesia = ireader.GetInt32(8);
                    inf.IDComplications = ireader.GetInt32(9);
                    inf.IDTheSituation = ireader.GetInt32(10);
                    inf.Content = ireader.GetValue(11).ToString();
                    inf.Note = ireader.GetValue(12).ToString();
                    inf.EmployeeCode = ireader.GetValue(13).ToString();
                    inf.ObjectCode = ireader.GetInt32(14);
                    inf.PatientCode = ireader.GetValue(15).ToString();
                    inf.PatientType = ireader.GetInt32(16);
                    inf.EmployeeCodeUpd = ireader.GetValue(17).ToString();
                    inf.IDate = ireader.GetDateTime(18);
                    inf.UDate = ireader.GetDateTime(19);
                    inf.Paid = ireader.GetInt32(20);
                    inf.BanksAccountCode = ireader.GetValue(21).ToString();
                    inf.PatientReceiveID = ireader.GetDecimal(22);
                    inf.DiagnosisCustomOn = ireader.GetValue(23).ToString();
                    inf.DiagnosisCustomOut = ireader.GetValue(24).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                inf = null;
            }
            return inf;
        }

        public static List<SurgicalCrewINF> ListSurgicalCrew(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<SurgicalCrewINF> list = new List<SurgicalCrewINF>();
            try
            {
                string sql = "select RowID,SurgeriesCode,IDate,EmployeeName,Role from SurgicalCrew where  SurgeriesCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    SurgicalCrewINF inf = new SurgicalCrewINF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.SurgeriesCode = ireader.GetString(1);
                    inf.IDate = ireader.GetDateTime(2);
                    inf.EmployeeName = ireader.GetValue(3).ToString();
                    inf.Role = ireader.GetValue(4).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }

        public static DataTable DT_Catalog_SurgicalCrew()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                //dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("PositionCode", typeof(Int32)));
                string sql = "Select RowID,EmployeeCode,PositionCode from Catalog_SurgicalCrew order by stt ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetValue(1).ToString(), ireader.GetValue(2).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dt;
        }

        public static DataTable DT_SurgicalCrew(string sSurgeriesCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                //dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("PositionCode", typeof(Int32)));
                string sql = "select EmployeeCode,PositionCode from SurgicalCrew where SurgeriesCode='{0}' order by rowid ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sSurgeriesCode), null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetValue(0).ToString(), ireader.GetValue(1).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dt;
        }

        public static DataTable DT_Anesthesia()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Names", typeof(string)));
                string sql = "select RowID,Names from Catalog_Anesthesia order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetInt32(0), ireader.GetValue(1).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch {  }
            return dt;
        }

        public static DataTable DT_Complications()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Names", typeof(string)));
                string sql = "select RowID,Names from Catalog_Complications order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetInt32(0), ireader.GetValue(1).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dt;
        }

        public static DataTable DT_TheSituation()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Names", typeof(string)));
                string sql = "select RowID,Names from Catalog_TheSituation order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetInt32(0), ireader.GetValue(1).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dt;
        }

        public static DataTable DT_RptViewSurgeries(string surgeriesCode, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SurgeriesCode", SqlDbType.VarChar, 15);
                param[0].Value = surgeriesCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_RptViewSurgeries", param);
            }
            catch { }
            return dt;
        }

        public static string GetMedicalRecordCode(string sSurgeriesCode)
        {
            ConnectDB cn = new ConnectDB();
            string result = string.Empty;
            string sql = "";
            sql = "select MedicalRecordCode from MedicalRecord where ReferenceCode='{0}'";
            IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sSurgeriesCode), null);
            if (ireader.Read())
            {
                result = ireader.GetValue(0).ToString();
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return result;
        }
        public static DataTable hsba_Surgeries(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = " select RowID,SurgeriesCode,DateOn,TimeOn,DateOut,TimeOut,ICD10On,ICD10Out,IDAnesthesia,IDComplications,IDTheSituation,Content,Note,EmployeeCode,ObjectCode,PatientCode,PatientReceiveID,PatientType,EmployeeCodeUpd,IDate,UDate,IDSuggested,DepartmentCode,Paid,BanksAccountCode from Surgeries where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                dt = cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { }
            return dt;
        }
        public static DataTable hsba_SurgicalCrew(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = " select a.RowID,a.SurgeriesCode,a.IDate,a.EmployeeName,a.Role,a.EmployeeCode,a.PositionCode from SurgicalCrew a inner join Surgeries b on a.SurgeriesCode=b.SurgeriesCode where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                dt = cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { }
            return dt;
        }
    }
}
