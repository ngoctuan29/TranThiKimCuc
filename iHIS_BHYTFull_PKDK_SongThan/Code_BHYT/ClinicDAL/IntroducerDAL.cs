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
    public class IntroducerDAL
    {
        public static DataTable DTIntroducer(string sIntroCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                dt.Columns.Add(new DataColumn("IntroCode", typeof(string)));
                dt.Columns.Add(new DataColumn("IntroName", typeof(string)));
                dt.Columns.Add(new DataColumn("Sex", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
                dt.Columns.Add(new DataColumn("IDCard", typeof(string)));
                dt.Columns.Add(new DataColumn("Address", typeof(string)));
                dt.Columns.Add(new DataColumn("Birthday", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("CareerCode", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Note", typeof(string)));
                if (sIntroCode == string.Empty)
                    sql = " select IntroCode, IntroName,Sex, Mobile,IDCard,Address,Birthday,CareerCode,EmployeeCode,Note from Introducer order by IntroCode ";
                else
                    sql = " select IntroCode, IntroName,Sex, Mobile,IDCard,Address,Birthday,CareerCode,EmployeeCode,Note from Introducer where IntroCode='{0}' ";
                dt = cn.ExecuteQuery(string.Format(sql, sIntroCode));
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sIntroCode), null);
                //while (ireader.Read())
                //{
                //    IntroducerInf inf = new IntroducerInf();
                //    inf.IntroCode = ireader.GetString(0);
                //    inf.IntroName = ireader.GetString(1);
                //    inf.Sex = ireader.GetInt32(2);
                //    inf.Mobile = ireader.GetValue(3).ToString();
                //    inf.IDCard = ireader.GetValue(4).ToString();
                //    inf.Address = ireader.GetValue(5).ToString();
                //    inf.Birthday = ireader.GetDateTime(6);
                //    inf.CareerCode = ireader.GetString(7);
                //    inf.EmployeeCode = ireader.GetString(8);
                //    inf.Note = ireader.GetValue(9).ToString();
                //    dt.Rows.Add(inf.IntroCode, inf.IntroName, inf.Sex, inf.Mobile, inf.IDCard, inf.Address, inf.Birthday, inf.CareerCode, inf.EmployeeCode, inf.Note);
                //}
                //if (!ireader.IsClosed)
                //{
                //    ireader.Close();
                //    ireader.Dispose();
                //}
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 Ins(IntroducerInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@IntroCode", SqlDbType.VarChar);
                param[0].Value = info.IntroCode;
                param[1] = new SqlParameter("@IntroName", SqlDbType.NVarChar);
                param[1].Value = info.IntroName;
                param[2] = new SqlParameter("@Sex", SqlDbType.Int);
                param[2].Value = info.Sex;
                param[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[3].Value = info.Mobile;
                param[4] = new SqlParameter("@IDCard", SqlDbType.NVarChar);
                param[4].Value = info.IDCard;
                param[5] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[5].Value = info.Address;
                param[6] = new SqlParameter("@Birthday", SqlDbType.DateTime);
                param[6].Value = info.Birthday;
                param[7] = new SqlParameter("@CareerCode", SqlDbType.VarChar);
                param[7].Value = info.CareerCode;
                param[8] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[8].Value = info.EmployeeCode;
                param[9] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[9].Value = info.Note;
                param[10] = new SqlParameter("@iresult", SqlDbType.Int);
                param[10].Direction = ParameterDirection.Output;
                int iresult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Introducer", param);
                if (iresult >= 1)
                    return 1;
                else if (iresult == -1)
                    return -1;
                else
                    return -2;

            }
            catch { return -2; }
        }

        public static Int32 Del(string sIntroCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@IntroCode", SqlDbType.VarChar, 10);
                param[1].Value = sIntroCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Introducer", param);
            }
            catch { return -1; }
        }


    }
}
