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
    public class SurviveSignDal
    {
        public static List<SurviveSignInf> ListSurviveSign(decimal dRow)
        {
            ConnectDB cn = new ConnectDB();
            List<SurviveSignInf> list = new List<SurviveSignInf>();
            try
            {
                string sql = string.Empty;
                if (dRow != 0)
                {
                    sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,Weight,CreateDate,EmployeeCode,RefID,BloodPressure1,Hight  from SurviveSign where RowID in({0}) ";
                }
                else
                {
                    sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,WeightHight,CreateDate,EmployeeCode,RefID,BloodPressure1,Hight  from SurviveSign order by RowID desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRow), null);
                while (ireader.Read())
                {
                    SurviveSignInf inf = new SurviveSignInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.Pulse = ireader.GetValue(2).ToString();
                    inf.Temperature = ireader.GetValue(3).ToString();
                    inf.BloodPressure = ireader.GetValue(4).ToString();
                    inf.Weight = ireader.GetValue(5).ToString();
                    inf.CreateDate = ireader.GetDateTime(6);
                    inf.EmployeeCode = ireader.GetValue(7).ToString();
                    inf.RefID = ireader.GetDecimal(8);
                    inf.BloodPressure1 = ireader.GetValue(9).ToString();
                    inf.Hight = ireader.GetValue(10).ToString();
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
        
        public static List<SurviveSignInf> ListSurviveSignForRefID(decimal dRefID)
        {
            ConnectDB cn = new ConnectDB();
            List<SurviveSignInf> list = new List<SurviveSignInf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,Weight,CreateDate,EmployeeCode,RefID,BloodPressure1,Hight,Breath  from SurviveSign where RefID in({0}) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRefID), null);
                while (ireader.Read())
                {
                    SurviveSignInf inf = new SurviveSignInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.Pulse = ireader.GetValue(2).ToString();
                    inf.Temperature = ireader.GetValue(3).ToString();
                    inf.BloodPressure = ireader.GetValue(4).ToString();
                    inf.Weight = ireader.GetValue(5).ToString();
                    inf.CreateDate = ireader.GetDateTime(6);
                    inf.EmployeeCode = ireader.GetValue(7).ToString();
                    inf.RefID = ireader.GetDecimal(8);
                    inf.BloodPressure1 = ireader.GetValue(9).ToString();
                    inf.Hight = ireader.GetValue(10).ToString();
                    inf.Breath = ireader.GetValue(11).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }
        
        public static List<SurviveSignInf> ListSurviveSignForRefCode(string sReferCode, decimal dRefID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<SurviveSignInf> list = new List<SurviveSignInf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,Weight,CreateDate,EmployeeCode,RefID,ReferenceCode,BloodPressure1,Hight,Breath  from SurviveSign where ReferenceCode in('{0}') and RefID in({1}) and PatientCode in('{2}') order by RowID desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sReferCode, dRefID, sPatientCode), null);
                while (ireader.Read())
                {
                    SurviveSignInf inf = new SurviveSignInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.Pulse = ireader.GetValue(2).ToString();
                    inf.Temperature = ireader.GetValue(3).ToString();
                    inf.BloodPressure = ireader.GetValue(4).ToString();
                    inf.Weight = ireader.GetValue(5).ToString();
                    inf.CreateDate = ireader.GetDateTime(6);
                    inf.EmployeeCode = ireader.GetValue(7).ToString();
                    inf.RefID = ireader.GetDecimal(8);
                    inf.ReferenceCode = ireader.GetValue(9).ToString();
                    inf.BloodPressure1 = ireader.GetValue(10).ToString();
                    inf.Hight = ireader.GetValue(11).ToString();
                    inf.Breath = ireader.GetValue(12).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }

        public static DataTable DT_SurviveSignForRefCode(string referCode, string patientcode, decimal refID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,Weight,CreateDate,EmployeeCode,RefID,ReferenceCode,BloodPressure1,Hight,Breath  from SurviveSign where ReferenceCode ='{0}' and PatientCode='{1}' and RefID={2} ";
                return cn.ExecuteQuery(string.Format(sql, referCode, patientcode, refID));
            }
            catch { return null; }
        }
        public static DataTable DT_SurviveSignForRefCode(string referCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,Weight,CreateDate,EmployeeCode,RefID,ReferenceCode,BloodPressure1,Hight,Breath  from SurviveSign where ReferenceCode ='{0}' ";
                return cn.ExecuteQuery(string.Format(sql, referCode));
            }
            catch { return null; }
        }
        public static DataTable DT_SurviveSignForRefID(decimal dRefID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,PatientCode,Pulse,Temperature,BloodPressure,Weight,CreateDate,EmployeeCode,RefID,ReferenceCode,BloodPressure1,Hight,Breath  from SurviveSign where RefID in({0})  ";
                return cn.ExecuteQuery(string.Format(sql, dRefID));
            }
            catch { return null; }
        }

        public static Int32 InsSurviveSign(SurviveSignInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@Pulse", SqlDbType.VarChar);
                param[2].Value = info.Pulse;
                param[3] = new SqlParameter("@Temperature", SqlDbType.VarChar);
                param[3].Value = info.Temperature;
                param[4] = new SqlParameter("@BloodPressure", SqlDbType.VarChar);
                param[4].Value = info.BloodPressure;
                param[5] = new SqlParameter("@BloodPressure1", SqlDbType.VarChar);
                param[5].Value = info.BloodPressure1;
                param[6] = new SqlParameter("@Weight", SqlDbType.VarChar);
                param[6].Value = info.Weight;
                param[7] = new SqlParameter("@Hight", SqlDbType.VarChar);
                param[7].Value = info.Hight;
                param[8] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[8].Value = info.EmployeeCode;
                param[9] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[9].Value = info.RefID;
                param[10] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar);
                param[10].Value = info.ReferenceCode;
                param[11] = new SqlParameter("@Breath", SqlDbType.VarChar);
                param[11].Value = info.Breath;
                param[12] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                param[12].Value = info.CreateDate;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_SurviveSign", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

    }
}
