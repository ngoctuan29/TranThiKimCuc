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
    public class Fee_NoteBookDAL
    {
        public static DataTable TableListNoteBookALL()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select RowID,Symbol,NoteBookName,FromNumber,ToNumber,WriteNumber,NoteType,Hide,ShiftWork,EmployeeCode,EmployeeCodeUpd,UDate from Fee_NoteBook order by RowID";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static List<Fee_NoteBookInf> ListNoteBook(int rowid)
        {
            ConnectDB cn = new ConnectDB();
            List<Fee_NoteBookInf> list = new List<Fee_NoteBookInf>();
            try
            {
                string sql = "select RowID,Symbol,NoteBookName,FromNumber,ToNumber,WriteNumber,NoteType,Hide,ShiftWork,EmployeeCode,EmployeeCodeUpd,UDate from Fee_NoteBook order by RowID";
                if (rowid > 0)
                    sql = " select RowID,Symbol,NoteBookName,FromNumber,ToNumber,WriteNumber,NoteType,Hide,ShiftWork,EmployeeCode,EmployeeCodeUpd,UDate from Fee_NoteBook where RowID={0} order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, rowid), null);
                while (ireader.Read())
                {
                    Fee_NoteBookInf inf = new Fee_NoteBookInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.Symbol = ireader.GetString(1);
                    inf.NoteBookName = ireader.GetString(2);
                    inf.FromNumber = ireader.GetInt32(3);
                    inf.ToNumber = ireader.GetInt32(4);
                    inf.WriteNumber = ireader.GetInt32(5);
                    inf.NoteType = ireader.GetInt32(6);
                    inf.Hide = ireader.GetInt32(7);
                    inf.ShiftWork = ireader.GetValue(8).ToString();
                    inf.EmployeeCode = ireader.GetValue(9).ToString();
                    inf.EmployeeCodeUpd = ireader.GetValue(10).ToString();
                    inf.UDate = ireader.GetValue(10).ToString();
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

        public static bool InsFee_NoteBook(Fee_NoteBookInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@Symbol", SqlDbType.NVarChar);
                param[1].Value = info.Symbol;
                param[2] = new SqlParameter("@NoteBookName", SqlDbType.NVarChar);
                param[2].Value = info.NoteBookName;
                param[3] = new SqlParameter("@FromNumber", SqlDbType.Int);
                param[3].Value = info.FromNumber;
                param[4] = new SqlParameter("@ToNumber", SqlDbType.Int);
                param[4].Value = info.ToNumber;
                param[5] = new SqlParameter("@WriteNumber", SqlDbType.Int);
                param[5].Value = info.WriteNumber;
                param[6] = new SqlParameter("@NoteType", SqlDbType.Int);
                param[6].Value = info.NoteType;
                param[7] = new SqlParameter("@Hide", SqlDbType.Int);
                param[7].Value = info.Hide;
                param[8] = new SqlParameter("@ShiftWork", SqlDbType.Char);
                param[8].Value = info.ShiftWork;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@EmployeeCodeUpd", SqlDbType.VarChar);
                param[10].Value = info.EmployeeCodeUpd;
                param[11] = new SqlParameter("@UDate", SqlDbType.VarChar);
                param[11].Value = info.UDate;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIUFee_NoteBook", param) > 0 ? true : false;
            }
            catch { return false; }
        }

        public static bool DelFee_NoteBook(int rowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = rowid;
                param[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
                param[1].Direction = ParameterDirection.Output;
                return Convert.ToInt32( cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDelFee_NoteBook", param)) > 0 ? true : false;
            }
            catch { return false; }
        }

    }
}
