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
    public class BHYTDal
    {
        public static List<BHYTInf> ListBHYT(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<BHYTInf> list = new List<BHYTInf>();
            try
            {
                string sql = string.Empty;
                if (dRowID != 0)
                {
                    sql = "select RowID,Serial,PatientCode,KCBBDCode,StartDate,EndDate,Hide,EmployeeCode,PatientReceiveID,Traituyen,Serial02,Serial03,Serial04,Serial05,Serial06,Serial01 from BHYT where RowID in({0}) order by RowID asc";
                }
                else
                {
                    sql = "select RowID,Serial,PatientCode,KCBBDCode,StartDate,EndDate,Hide,EmployeeCode,PatientReceiveID,Traituyen,Serial02,Serial03,Serial04,Serial05,Serial06,Serial01 from BHYT order by RowID asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                while (ireader.Read())
                {
                    BHYTInf inf = new BHYTInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.Serial = ireader.GetString(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.KCBBDCode = ireader.GetString(3);
                    inf.StartDate = ireader.GetDateTime(4);
                    inf.EndDate = ireader.GetDateTime(5);
                    inf.Hide = ireader.GetInt32(6);
                    inf.EmployeeCode = ireader.GetString(7);
                    inf.PatientReceiveID = ireader.GetDecimal(8);
                    inf.TraiTuyen = ireader.GetInt32(9);
                    inf.Serial02 = ireader.GetString(10);
                    inf.Serial03 = ireader.GetString(11);
                    inf.Serial04 = ireader.GetString(12);
                    inf.Serial05 = ireader.GetString(13);
                    inf.Serial06 = ireader.GetString(14);
                    inf.Serial01 = ireader.GetString(15);
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

        public static List<BHYTInf> ListBHYTForPatientReceiveId(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<BHYTInf> list = new List<BHYTInf>();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.Serial,a.PatientCode,a.KCBBDCode,a.StartDate,a.EndDate,a.Hide,a.EmployeeCode,a.PatientReceiveID,a.TraiTuyen,a.Serial02,a.Serial03,a.Serial04,a.Serial05,a.Serial06,a.Serial01,a.ReferralPaper,b.ProvincialIDBHYT,a.KCBBDCodeFull,a.CapCuu from BHYT a inner join KCBBD b on a.KCBBDCode=b.KCBBDCode where a.PatientReceiveID in({0}) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                if (ireader.Read())
                {
                    BHYTInf inf = new BHYTInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.Serial = ireader.GetString(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.KCBBDCode = ireader.GetString(3);
                    inf.StartDate = ireader.GetDateTime(4);
                    inf.EndDate = ireader.GetDateTime(5);
                    inf.Hide = ireader.GetInt32(6);
                    inf.EmployeeCode = ireader.GetString(7);
                    inf.PatientReceiveID = ireader.GetDecimal(8);
                    inf.TraiTuyen = ireader.GetInt32(9);
                    inf.Serial02 = ireader.GetString(10);
                    inf.Serial03 = ireader.GetString(11);
                    inf.Serial04 = ireader.GetString(12);
                    inf.Serial05 = ireader.GetString(13);
                    inf.Serial06 = ireader.GetString(14);
                    inf.Serial01 = ireader.GetString(15);
                    inf.ReferralPaper = ireader.GetInt32(16);
                    inf.ProvincialIDBHYT = ireader.GetValue(17).ToString();
                    inf.KCBBDCodeFull = ireader.GetValue(18).ToString();
                    inf.Capcuu = ireader.GetInt32(19);
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

        public static string PatientCodeForSerial(string serial)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = string.Empty;
                query = "select distinct PatientCode from BHYT where Serial='{0}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, serial), null);
                if(ireader.Read())
                {
                    return ireader.GetValue(0).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return string.Empty;
            }
            catch { return string.Empty; }
        }

        public static DataTable TableBHYTForPatientReceiveId(decimal dPatientReceiveId)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select a.RowID,a.Serial,a.PatientCode,(b.ProvincialIDBHYT+'-'+a.KCBBDCode) KCBBDCode,a.StartDate,a.EndDate,a.Hide,a.EmployeeCode,a.PatientReceiveID,a.TraiTuyen,a.Serial01,a.Serial02,a.Serial03,a.Serial04,a.Serial05,a.Serial06,b.KCBBDName,(case when a.TraiTuyen=1 and a.ReferralPaper=0 then c.RateFalse when a.TraiTuyen=1 and a.ReferralPaper=1 then c.RateTrue else c.RateTrue end) Rate,a.ReferralPaper from BHYT a left join KCBBD b on a.KCBBDCodeFull=(b.ProvincialIDBHYT+'-'+b.KCBBDCode) left join RateBHYT c on (a.Serial01+a.Serial02)=c.RateCard where a.PatientReceiveID in({0}) and a.hide=0 ";
                return cn.ExecuteQuery(string.Format(sql, dPatientReceiveId));
            }
            catch { return null; }
        }

        public static Int32 InsBHYT(BHYTInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[19];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@Serial", SqlDbType.VarChar, 50);
                param[1].Value = info.Serial;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@KCBBDCode", SqlDbType.VarChar, 50);
                param[3].Value = info.KCBBDCode;
                param[4] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param[4].Value = info.StartDate;
                param[5] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param[5].Value = info.EndDate;
                param[6] = new SqlParameter("@Hide", SqlDbType.Int);
                param[6].Value = info.Hide;
                param[7] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[7].Value = info.EmployeeCode;
                param[8] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[8].Value = info.PatientReceiveID;
                param[9] = new SqlParameter("@TraiTuyen", SqlDbType.Int);
                param[9].Value = info.TraiTuyen;
                param[10] = new SqlParameter("@Serial02", SqlDbType.VarChar, 5);
                param[10].Value = info.Serial02;
                param[11] = new SqlParameter("@Serial03", SqlDbType.VarChar, 5);
                param[11].Value = info.Serial03;
                param[12] = new SqlParameter("@Serial04", SqlDbType.VarChar, 5);
                param[12].Value = info.Serial04;
                param[13] = new SqlParameter("@Serial05", SqlDbType.VarChar, 5);
                param[13].Value = info.Serial05;
                param[14] = new SqlParameter("@Serial06", SqlDbType.VarChar, 5);
                param[14].Value = info.Serial06;
                param[15] = new SqlParameter("@Serial01", SqlDbType.VarChar, 5);
                param[15].Value = info.Serial01;
                param[16] = new SqlParameter("@ReferralPaper", SqlDbType.Int);
                param[16].Value = info.ReferralPaper;
                param[17] = new SqlParameter("@KCBBDCodeFull", SqlDbType.VarChar, 10);
                param[17].Value = info.KCBBDCodeFull;
                param[18] = new SqlParameter("@Capcuu", SqlDbType.Int);
                param[18].Value = info.Capcuu;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_BHYT", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

    }
}
