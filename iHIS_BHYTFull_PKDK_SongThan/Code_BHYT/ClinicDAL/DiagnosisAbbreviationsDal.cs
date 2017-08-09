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
    public class DiagnosisAbbreviationsDal
    {
        public DataTable TableAbbreviations(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("CharacterCode", typeof(string)));
                dt.Columns.Add(new DataColumn("CharacterName", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                string sql = "select RowID,CharacterCode,CharacterName,EmployeeCode from DiagnosisAbbreviations where EmployeeCode='{0}' order by rowid desc";
                dt = cn.ExecuteQuery(string.Format(sql, employeeCode));
            }
            catch {  }
            return dt;
        }

        public List<DiagnosisAbbreviationsInf> ListAbb(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<DiagnosisAbbreviationsInf> list = new List<DiagnosisAbbreviationsInf>();
            try
            {
                string sql = " Select RowID,CharacterCode,CharacterName,EmployeeCode from DiagnosisAbbreviations where EmployeeCode='{0}' order by rowid desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, employeeCode), null);
                while (ireader.Read())
                {
                    DiagnosisAbbreviationsInf inf = new DiagnosisAbbreviationsInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.CharacterCode = ireader.GetString(1);
                    inf.CharacterName = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
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

        public List<DiagnosisAbbreviationsInf> ListAbbForUser(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<DiagnosisAbbreviationsInf> list = new List<DiagnosisAbbreviationsInf>();
            try
            {
                string sql = "select RowID,CharacterCode,CharacterName,EmployeeCode from DiagnosisAbbreviations where EmployeeCode={'0'} order by rowid desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, employeeCode), null);
                while (ireader.Read())
                {
                    DiagnosisAbbreviationsInf inf = new DiagnosisAbbreviationsInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.CharacterCode = ireader.GetString(1);
                    inf.CharacterName = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
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

        public Int32 Ins(DiagnosisAbbreviationsInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@CharacterCode", SqlDbType.VarChar, 50);
                param[1].Value = info.CharacterCode;
                param[2] = new SqlParameter("@CharacterName", SqlDbType.NVarChar, 4000);
                param[2].Value = info.CharacterName;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 10);
                param[3].Value = info.EmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_DiagnosisAbbreviations", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public Int32 Del(Int32 iRowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = iRowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_DiagnosisAbbreviations", param);
            }
            catch { return -1; }
        }

    }
}
