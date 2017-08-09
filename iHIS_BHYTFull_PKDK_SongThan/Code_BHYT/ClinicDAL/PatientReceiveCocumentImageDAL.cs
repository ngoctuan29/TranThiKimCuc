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
    public class PatientReceiveCocumentImageDAL
    {
        public static List<PatientReceiveCocumentImageInf> List(decimal refReceiveID, string refPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientReceiveCocumentImageInf> list = new List<PatientReceiveCocumentImageInf>();
            try
            {
                string sql = @"select RowID,PatientReceiveID,PatientCode,STT,IDtae,Note,Image  from PatientReceiveCocumentImage where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode order by STT desc";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = refReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 20);
                param[1].Value = refPatientCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    PatientReceiveCocumentImageInf inf = new PatientReceiveCocumentImageInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.STT = Convert.ToInt32(ireader.GetValue(3).ToString());
                    inf.IDtae = ireader.GetDateTime(4);
                    inf.Note = ireader.GetValue(5).ToString();
                    inf.Image = (byte[])ireader.GetValue(6);
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

        public static Int32 Ins(PatientReceiveCocumentImageInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = info.PatientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@STT", SqlDbType.Int);
                param[2].Value = info.STT;
                param[3] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[3].Value = info.Note;
                param[4] = new SqlParameter("@Image", SqlDbType.Image);
                param[4].Value = info.Image;
                param[5] = new SqlParameter("@Result", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                int iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_PatientReceiveCocumentImage", param));
                return iResult;
            }
            catch { return -2; }
        }

        public static DataTable hsba_DocumentImage(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("RowID", typeof(decimal));
            dtResult.Columns.Add("PatientReceiveID", typeof(decimal));
            dtResult.Columns.Add("PatientCode", typeof(string));
            dtResult.Columns.Add("STT", typeof(Int32));
            dtResult.Columns.Add("IDtae", typeof(DateTime));
            dtResult.Columns.Add("Note", typeof(string));
            dtResult.Columns.Add("Image", typeof(string));
            try
            {
                string sql = "";
                sql = "select RowID,PatientReceiveID,PatientCode,STT,IDtae,Note,Image from PatientReceiveCocumentImage where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dReceiveID;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = Convert.ToDecimal(ireader.GetValue(0).ToString());
                    dr[1] = Convert.ToDecimal(ireader.GetValue(1).ToString());
                    dr[2] = ireader.GetValue(2).ToString();
                    dr[3] = Convert.ToInt32(ireader.GetValue(3).ToString());
                    dr[4] = Convert.ToDateTime(ireader.GetValue(4).ToString());
                    dr[5] = ireader.GetValue(5).ToString();
                    if (ireader.GetValue(6).ToString() != "")
                    {
                        byte[] bytestemp = (byte[])ireader.GetValue(6);
                        dr[6] = Convert.ToBase64String(bytestemp);
                    }
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
    }
}
