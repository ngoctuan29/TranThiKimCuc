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
    public class KCBBDDal
    {
        public static List<KCBBDInf> ListKCBBD(string provincialIDBHYT)
        {
            ConnectDB cn = new ConnectDB();
            List<KCBBDInf> list = new List<KCBBDInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(provincialIDBHYT))
                {
                    sql = "select Rowid,KCBBDCode,KCBBDName,ProvincialIDBHYT,TT from kcbbd where ProvincialIDBHYT ='{0}' ";
                }
                else
                {
                    sql = "select Rowid,KCBBDCode,KCBBDName,ProvincialIDBHYT,TT from kcbbd order by rowid asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, provincialIDBHYT), null);
                while (ireader.Read())
                {
                    KCBBDInf inf = new KCBBDInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.KCBBDCode = ireader.GetString(1);
                    inf.KCBBDName = ireader.GetString(2);
                    inf.ProvincialIDBHYT = ireader.GetValue(3).ToString();
                    inf.TT = ireader.GetInt32(4);
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
        public static DataTable TableKCBBDALL()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select Rowid,KCBBDCode,KCBBDName,ProvincialIDBHYT,TT from kcbbd order by rowid asc";
                tableResult = cn.ExecuteQuery(query);
                
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable TableKCBBDForBHYT(string provincialIDBHYT, string kcbbdCode)
        {
            ConnectDB cn = new ConnectDB();
            List<KCBBDInf> list = new List<KCBBDInf>();
            try
            {
                string sql = "select Rowid,KCBBDCode,KCBBDName,ProvincialIDBHYT,TT from kcbbd where ProvincialIDBHYT in( REPLACE('{0}',' ','') ) and KCBBDCode in(REPLACE('{1}',' ',''))";
                return cn.ExecuteQuery(string.Format(sql, provincialIDBHYT, kcbbdCode));
            }
            catch { return null; }
        }
        public static DataTable TableKCBBDForBHYT(string kcbbdCode)
        {
            ConnectDB cn = new ConnectDB();
            List<KCBBDInf> list = new List<KCBBDInf>();
            try
            {
                string sql = " select Rowid,KCBBDCode,KCBBDName,ProvincialIDBHYT,TT from kcbbd where ProvincialIDBHYT + KCBBDCode in('{0}') ";
                return cn.ExecuteQuery(string.Format(sql, kcbbdCode.Trim()));
            }
            catch { return null; }
        }
        public static Int32 InsKCBBD(KCBBDInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@KCBBDCode", SqlDbType.VarChar, 50);
                param[1].Value = info.KCBBDCode;
                param[2] = new SqlParameter("@KCBBDName", SqlDbType.NVarChar, 500);
                param[2].Value = info.KCBBDName;
                param[3] = new SqlParameter("@ProvincialIDBHYT", SqlDbType.VarChar, 3);
                param[3].Value = info.ProvincialIDBHYT;
                param[4] = new SqlParameter("@TT", SqlDbType.Int);
                param[4].Value = info.TT;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_KCBBD", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 DelKCBBD(Decimal dRowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_CBBD", param);
            }
            catch { return -1; }
        }
        public static List<TinhKCBBDInf> ListTinhKCBBD()
        {
            ConnectDB cn = new ConnectDB();
            List<TinhKCBBDInf> list = new List<TinhKCBBDInf>();
            try
            {
                string sql = "";
                sql = "  select ProvincialIDBHYT,ProvincialName from Catalog_Provincial order by STT asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql), null);
                while (ireader.Read())
                {
                    TinhKCBBDInf inf = new TinhKCBBDInf();
                    inf.ProvincialIDBHYT = ireader.GetValue(0).ToString();
                    inf.ProvincialName = ireader.GetString(1);
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
    }
}
