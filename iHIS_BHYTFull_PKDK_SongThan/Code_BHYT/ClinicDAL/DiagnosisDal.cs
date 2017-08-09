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
    public class DiagnosisDal
    {
        public static List<DiagnosisInf> ListDiagnosis(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<DiagnosisInf> list = new List<DiagnosisInf>();
            try
            {
                string sql = string.Empty;
                if (dRowID != 0)
                {
                    sql = "select RowID,DiagnosisName,DiagnosisCode from Diagnosis where RowID in({0}) order by DiagnosisCode asc";
                }
                else
                {
                    sql = "select RowID,DiagnosisName,DiagnosisCode from Diagnosis order by DiagnosisCode asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                while (ireader.Read())
                {
                    DiagnosisInf inf = new DiagnosisInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.DiagnosisName = ireader.GetString(1);
                    inf.DiagnosisCode = ireader.GetValue(2).ToString();
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

        public static List<DiagnosisInf> ListDiagnosis(string rowID)
        {
            ConnectDB cn = new ConnectDB();
            List<DiagnosisInf> list = new List<DiagnosisInf>();
            try
            {
                string sql = " select RowID,DiagnosisName,DiagnosisCode from Diagnosis where RowID in({0}) order by DiagnosisCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, rowID), null);
                while (ireader.Read())
                {
                    DiagnosisInf inf = new DiagnosisInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.DiagnosisName = ireader.GetString(1);
                    inf.DiagnosisCode = ireader.GetValue(2).ToString();
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

        public static List<DiagnosisInf> ListDiagnosisName()
        {
            ConnectDB cn = new ConnectDB();
            List<DiagnosisInf> list = new List<DiagnosisInf>();
            try
            {
                string sql = string.Empty;
                sql = " select RowID,(DiagnosisCode +' - ' +DiagnosisName)DiagnosisName,DiagnosisCode from Diagnosis order by DiagnosisCode asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    DiagnosisInf inf = new DiagnosisInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.DiagnosisName = ireader.GetString(1);
                    inf.DiagnosisCode = ireader.GetValue(2).ToString();
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

        public static Int32 InsDiagnosis(DiagnosisInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@DiagnosisName", SqlDbType.NVarChar, 500);
                param[1].Value = info.DiagnosisName;
                param[2] = new SqlParameter("@DiagnosisCode", SqlDbType.NVarChar, 50);
                param[2].Value = info.DiagnosisCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Diagnosis", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelDiagnosis(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Diagnosis", param);
            }
            catch { return -1; }
        }

    }
}
