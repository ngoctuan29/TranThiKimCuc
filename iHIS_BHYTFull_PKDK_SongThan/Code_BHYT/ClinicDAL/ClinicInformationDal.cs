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
    public class ClinicInformationDal
    {
        public static ClinicInformationInf ObjInformation(int iRowID)
        {
            ConnectDB cn = new ConnectDB();
            ClinicInformationInf inf = new ClinicInformationInf();
            try
            {
                string sql = string.Empty;
                sql = "select ClinicCode,ClinicName,ClinicAddress,Province,Phone,Mobile,Doctor,WorkingDateLine01,WorkingDateLine02,WorkingDateLine03,KCBBDCode,WorkingTimeLineFrom01,WorkingTimeLineTo01,WorkingTimeLineFrom02,WorkingTimeLineTo02,WorkingTimeLineFrom03,WorkingTimeLineTo03,PK247Code,UserName_BV,PassWord_BV,UserName_TC,PassWord_TC from ClinicInformation where ClinicCode ={0} ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                if (ireader.Read())
                {
                    inf.ClinicCode = ireader.GetInt32(0);
                    inf.ClinicName = ireader.GetValue(1).ToString();
                    inf.ClinicAddress = ireader.GetValue(2).ToString();
                    inf.Province = ireader.GetValue(3).ToString();
                    inf.Phone = ireader.GetValue(4).ToString();
                    inf.Mobile = ireader.GetValue(5).ToString();
                    inf.Doctor = ireader.GetValue(6).ToString();
                    inf.WorkingDateLine01 = ireader.GetValue(7).ToString();
                    inf.WorkingDateLine02 = ireader.GetValue(8).ToString();
                    inf.WorkingDateLine03 = ireader.GetValue(9).ToString();
                    inf.KCBBDCode = ireader.GetValue(10).ToString();
                    inf.WorkingTimeLineFrom01 = ireader.GetValue(11).ToString();
                    inf.WorkingTimeLineTo01 = ireader.GetValue(12).ToString();
                    inf.WorkingTimeLineFrom02 = ireader.GetValue(13).ToString();
                    inf.WorkingTimeLineTo02 = ireader.GetValue(14).ToString();
                    inf.WorkingTimeLineFrom03 = ireader.GetValue(15).ToString();
                    inf.WorkingTimeLineTo03 = ireader.GetValue(16).ToString();
                    inf.PK247Code = ireader.GetValue(17).ToString() ?? string.Empty;
                    inf.UserName_BV = ireader.GetValue(18).ToString() ?? string.Empty;
                    inf.PassWord_BV = ireader.GetValue(19).ToString() ?? string.Empty;
                    inf.UserName_TC = ireader.GetValue(20).ToString() ?? string.Empty;
                    inf.PassWord_TC = ireader.GetValue(21).ToString() ?? string.Empty;
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch(Exception) { return null; }
        }

        public static DataTable DT_Information(int iRowID)
        {
             ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                sql = "select ClinicCode,ClinicName,ClinicAddress,Province,Phone,Mobile,Doctor,WorkingDateLine01,WorkingDateLine02,WorkingDateLine03,KCBBDCode,PK247Code,UserName_BV,PassWord_BV,UserName_TC,PassWord_TC from ClinicInformation where ClinicCode ={0} ";
                return cn.ExecuteQuery(string.Format(sql, iRowID));
            }
            catch { return null; }
        }

        public static Int32 Ins(ClinicInformationInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@ClinicCode", SqlDbType.Int);
                param[0].Value = info.ClinicCode;
                param[1] = new SqlParameter("@ClinicName", SqlDbType.NVarChar);
                param[1].Value = info.ClinicName;
                param[2] = new SqlParameter("@ClinicAddress", SqlDbType.NVarChar);
                param[2].Value = info.ClinicAddress;
                param[3] = new SqlParameter("@Province", SqlDbType.NVarChar);
                param[3].Value = info.Province;
                param[4] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[4].Value = info.Phone;
                param[5] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[5].Value = info.Mobile;
                param[6] = new SqlParameter("@Doctor", SqlDbType.NVarChar);
                param[6].Value = info.Doctor;
                param[7] = new SqlParameter("@WorkingDateLine01", SqlDbType.NVarChar);
                param[7].Value = info.WorkingDateLine01;
                param[8] = new SqlParameter("@WorkingDateLine02", SqlDbType.NVarChar);
                param[8].Value = info.WorkingDateLine02;
                param[9] = new SqlParameter("@WorkingDateLine03", SqlDbType.NVarChar);
                param[9].Value = info.WorkingDateLine03;
                param[10] = new SqlParameter("@KCBBDCode", SqlDbType.VarChar);
                param[10].Value = info.KCBBDCode;
                param[11] = new SqlParameter("@WorkingTimeLineFrom01", SqlDbType.Char, 5);
                param[11].Value = info.WorkingTimeLineFrom01;
                param[12] = new SqlParameter("@WorkingTimeLineTo01", SqlDbType.Char, 5);
                param[12].Value = info.WorkingTimeLineTo01;
                param[13] = new SqlParameter("@WorkingTimeLineFrom02", SqlDbType.Char, 5);
                param[13].Value = info.WorkingTimeLineFrom02;
                param[14] = new SqlParameter("@WorkingTimeLineTo02", SqlDbType.Char, 5);
                param[14].Value = info.WorkingTimeLineTo02;
                param[15] = new SqlParameter("@WorkingTimeLineFrom03", SqlDbType.Char, 5);
                param[15].Value = info.WorkingTimeLineFrom03;
                param[16] = new SqlParameter("@WorkingTimeLineTo03", SqlDbType.Char, 5);
                param[16].Value = info.WorkingTimeLineTo03;
                param[17] = new SqlParameter("@PK247Code", SqlDbType.VarChar);
                param[17].Value = info.PK247Code;
                param[18] = new SqlParameter("@UserName_BV", SqlDbType.VarChar);
                param[18].Value = info.UserName_BV;
                param[19] = new SqlParameter("@PassWord_BV", SqlDbType.VarChar);
                param[19].Value = info.PassWord_BV;
                param[20] = new SqlParameter("@UserName_TC", SqlDbType.VarChar);
                param[20].Value = info.UserName_TC;
                param[21] = new SqlParameter("@PassWord_TC", SqlDbType.VarChar);
                param[21].Value = info.PassWord_TC;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ClinicInformation", param) >= 1)
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
