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
    public class DepartmentDal
    {
        
        public static List<DepartmentInf> ListDepartment(string sgroup)
        {
            ConnectDB cn = new ConnectDB();
            List<DepartmentInf> list = new List<DepartmentInf>();
            try
            {
                string sql = string.Empty;
                if (sgroup != "")
                {
                    sql = "select RowID,DepartmentCode,DepartmentName,ServiceGroupCode,Hide,IdBv,KBHYT from Department where servicegroupcode='{0}' and DepartmentCode not in('KP0000') order by rowid desc";
                }
                else
                {
                    sql = "select RowID,DepartmentCode,DepartmentName,ServiceGroupCode,Hide,IdBv,KBHYT from Department where DepartmentCode not in('KP0000') order by rowid desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sgroup), null);
                while (ireader.Read())
                {
                    DepartmentInf inf = new DepartmentInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.DepartmentCode = ireader.GetString(1);
                    inf.DepartmentName = ireader.GetString(2);
                    inf.ServiceGroupCode = ireader.GetString(3);
                    inf.Hide = ireader.GetInt32(4);
                    inf.IdBv = ireader.GetInt32(5);
                    inf.KBHYT = ireader.GetValue(6).ToString();
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

        public static List<DepartmentInf> ListDepartmentFull()
        {
            ConnectDB cn = new ConnectDB();
            List<DepartmentInf> list = new List<DepartmentInf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,DepartmentCode,DepartmentName,ServiceGroupCode,Hide from Department where hide=0 and DepartmentCode not in('KP0000') order by rowid desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    DepartmentInf inf = new DepartmentInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.DepartmentCode = ireader.GetString(1);
                    inf.DepartmentName = ireader.GetString(2);
                    inf.ServiceGroupCode = ireader.GetString(3);
                    inf.Hide = ireader.GetInt32(4);
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

        public static List<DepartmentInf> ListDepartmentForCode(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<DepartmentInf> list = new List<DepartmentInf>();
            try
            {
                string sql = string.Empty;
                sql = "select DepartmentCode,DepartmentName from Department where DepartmentCode in({0}) order by DepartmentCode desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    DepartmentInf inf = new DepartmentInf();
                    inf.DepartmentCode = ireader.GetString(0);
                    inf.DepartmentName = ireader.GetString(1);
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

        public static List<DepartmentInf> ListDepartment(string sgroup, string sDepartmentCode)
        {
            ConnectDB cn = new ConnectDB();
            List<DepartmentInf> list = new List<DepartmentInf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,DepartmentCode,DepartmentName,ServiceGroupCode,Hide from Department where servicegroupcode='{0}' and DepartmentCode in({1}) order by rowid desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sgroup, sDepartmentCode), null);
                while (ireader.Read())
                {
                    DepartmentInf inf = new DepartmentInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.DepartmentCode = ireader.GetString(1);
                    inf.DepartmentName = ireader.GetString(2);
                    inf.ServiceGroupCode = ireader.GetString(3);
                    inf.Hide = ireader.GetInt32(4);
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

        public static Int32 InsDepartment(DepartmentInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[0].Value = info.DepartmentCode;
                param[1] = new SqlParameter("@DepartmentName", SqlDbType.NVarChar, 4000);
                param[1].Value = info.DepartmentName;
                param[2] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ServiceGroupCode;
                param[3] = new SqlParameter("@Hide", SqlDbType.Int);
                param[3].Value = info.Hide;
                param[4] = new SqlParameter("@IdBv", SqlDbType.Int);
                param[4].Value = info.IdBv;
                param[5] = new SqlParameter("@KBHYT", SqlDbType.VarChar, 50);
                param[5].Value = info.KBHYT;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Department", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 InsDepartmentForRepository(string sDepartmentCode, string sRepositoryCode, string sEmployeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " insert into DepartmentForRepository(DepartmentCode,RepositoryCode,EmployeeCode) values(@DepartmentCode,@RepositoryCode,@EmployeeCode)";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[0].Value = sDepartmentCode;
                param[1] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[1].Value = sRepositoryCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = sEmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelDepartmentForRepository(string sDepartmentCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete  from DepartmentForRepository where DepartmentCode=@DepartmentCode ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[0].Value = sDepartmentCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static DataTable DT_DepartmentForRepository(string sDepartmentCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select DepartmentCode,RepositoryCode from DepartmentForRepository where DepartmentCode in('{0}')";
                return cn.ExecuteQuery(string.Format(sql, sDepartmentCode));
            }
            catch { return null; }
        }

        public static string sRepositoryCodeForGroup(string sDepartmentCode, Int32 iGroup)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sRepCode = string.Empty;
                string sql = @" select a.RepositoryCode
  from DepartmentForRepository a inner join RepositoryCatalog b on a.RepositoryCode=b.RepositoryCode
  where a.DepartmentCode in('{0}') and b.RepositoryGroupCode in({1})";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sDepartmentCode, iGroup), null);
                if (ireader.Read())
                {
                    sRepCode = ireader.GetValue(0).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return sRepCode;
            }
            catch { return ""; }
        }

        public static Int32 DelDepartment(string sDepartCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[1].Value = sDepartCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Department", param);
            }
            catch { return -1; }
        }
        public static List<DepartmentBHYTInf> ListDepartmentBHYT()
        {
            ConnectDB cn = new ConnectDB();
            List<DepartmentBHYTInf> list = new List<DepartmentBHYTInf>();
            try
            {
                string sql = "select STT,TenKhoa,MaKhoa from DepartmentBHYT ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    DepartmentBHYTInf inf = new DepartmentBHYTInf();
                    inf.STT = ireader.GetInt32(0);
                    inf.TenKhoa = ireader.GetString(1);
                    inf.MaKhoa = ireader.GetString(2);
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
        public static List<LoaiKhoaTInf> ListLoaiKhoa()
        {
            ConnectDB cn = new ConnectDB();
            List<LoaiKhoaTInf> list = new List<LoaiKhoaTInf>();
            try
            {
                string sql = "select ID,TenLoai from LoaiKhoa ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    LoaiKhoaTInf inf = new LoaiKhoaTInf();
                    inf.Id = ireader.GetInt32(0);
                    inf.TenLoai = ireader.GetString(1);
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
