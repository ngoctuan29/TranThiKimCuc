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
    public class RepositoryCatalog_Dal
    {
        public static List<RepositoryCatalog_Inf> ListRepositoryForImport(Int32 iHide, string groupCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = "proRepositoryForUser";
                //sql = "select RowID,RepositoryCode,RepositoryName,Hide,RepositoryGroupCode from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode in({1}) order by RowID asc";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Hide", SqlDbType.Int);
                param[0].Value = iHide;
                param[1] = new SqlParameter("@RepositoryGroupCode", SqlDbType.VarChar, 50);
                param[1].Value = groupCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 10);
                param[2].Value = employeeCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, sql, param);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
                    inf.RepositoryGroupCode = ireader.GetDecimal(4);
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

        public static List<RepositoryCatalog_Inf> ListRepositoryForExport(Int32 iHide, string groupCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide,RepositoryGroupCode from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode not in({1}) and RepositoryCode in(select * from [dbo].fnSplitString((select PermissionRepository from Employee where EmployeeCode='{2}'),',')) order by RowID asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iHide, groupCode, employeeCode), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
                    inf.RepositoryGroupCode = ireader.GetDecimal(4);
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

        public static List<RepositoryCatalog_Inf> ListRepositoryForBHYT(Int32 iHide, Int32 iGroupCode)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode in({1}) order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iHide, iGroupCode), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
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

        public static List<RepositoryCatalog_Inf> ListRepositoryForDuyetCap(Int32 iHide)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode in(2,4) order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iHide), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
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

        public static List<RepositoryCatalog_Inf> ListRepositoryForBHYT(Int32 iHide, Int32 iGroupCode, string sRepCode)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode in({1}) and RepositoryCode in({2}) order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iHide, iGroupCode, sRepCode), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
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

        public static List<RepositoryCatalog_Inf> ListRepository(Int32 iHide)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide from RepositoryCatalog where Hide in({0})  order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iHide), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
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

        public static List<RepositoryCatalog_Inf> ListRepositoryForDepartment(Int32 iHide)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode in(2,3,4) order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iHide), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
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

        public static RepositoryCatalog_Inf ListRepository(string sRepCode, int iHide)
        {
            ConnectDB cn = new ConnectDB();
            RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide from RepositoryCatalog where RepositoryCode in('{0}') and Hide in({1}) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRepCode, iHide), null);
                if(ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch  { return null; }
        }

        public static List<RepositoryCatalog_Inf> ListRepositoryAll(int hide)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                if (hide == -1)
                    sql = "select RowID,RepositoryCode,RepositoryName,Hide,RepositoryGroupCode,DateReport from RepositoryCatalog order by RowID asc";
                else
                    sql = "select RowID,RepositoryCode,RepositoryName,Hide,RepositoryGroupCode,DateReport from RepositoryCatalog where hide in({0}) order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, hide), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
                    inf.RepositoryGroupCode = ireader.GetDecimal(4);
                    inf.DateReport = ireader.GetDateTime(5);
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

        public static Int32 Ins(RepositoryCatalog_Inf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = info.RepositoryCode;
                param[1] = new SqlParameter("@RepositoryName", SqlDbType.NVarChar, 1000);
                param[1].Value = info.RepositoryName;
                param[2] = new SqlParameter("@Hide", SqlDbType.Int);
                param[2].Value = info.Hide;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@RepositoryGroupCode", SqlDbType.Decimal);
                param[4].Value = info.RepositoryGroupCode;
                param[5] = new SqlParameter("@DateReport", SqlDbType.DateTime);
                param[5].Value = info.DateReport;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_RepositoryCatalog", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_RepositoryCatalog", param);
            }
            catch { return -1; }
        }

        public static DataTable DT_ListRepositoryGroup()
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = " select RepositoryGroupCode,RepositoryGroupName from RepositoryGroup order by RepositoryGroupCode asc";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static DataTable DT_ViewInventory(string repositoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar);
                param[0].Value = repositoryCode;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewInventory", param);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable TableViewInventoryLimited(string repositoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar);
                param[0].Value = repositoryCode;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewInventoryLimited", param);
                return dtResult;
            }
            catch { return null; }
        }

        public static List<RepositoryCatalog_Inf> ListRepositoryNotGroup(Int32 hide, Int32 group)
        {
            ConnectDB cn = new ConnectDB();
            List<RepositoryCatalog_Inf> list = new List<RepositoryCatalog_Inf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,RepositoryCode,RepositoryName,Hide,RepositoryGroupCode from RepositoryCatalog where Hide in({0}) and RepositoryGroupCode not in({1}) order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, hide, group), null);
                while (ireader.Read())
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RepositoryCode = ireader.GetString(1);
                    inf.RepositoryName = ireader.GetString(2);
                    inf.Hide = ireader.GetInt32(3);
                    inf.RepositoryGroupCode = ireader.GetDecimal(4);
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
