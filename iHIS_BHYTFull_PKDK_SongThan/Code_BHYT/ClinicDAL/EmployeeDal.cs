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
    public class EmployeeDal
    {
        public static List<EmployeeInf> ListEmployee(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            List<EmployeeInf> list = new List<EmployeeInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(employeeCode))
                {
                    sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,PermissionDepart,PermissionRepository,EmployeeGroupID from Employee where EmployeeCode in('{0}') order by Rowid desc";
                }
                else
                {
                    sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,PermissionDepart,PermissionRepository,EmployeeGroupID from Employee  order by Rowid desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, employeeCode), null);
                while (ireader.Read())
                {
                    EmployeeInf inf = new EmployeeInf();
                    inf.EmployeeCode = ireader.GetString(0);
                    inf.EmployeeName = ireader.GetString(1);
                    inf.Sex = ireader.GetInt32(2);
                    inf.Mobile = ireader.GetValue(3).ToString();
                    inf.IDCard = ireader.GetValue(4).ToString();
                    inf.Address = ireader.GetValue(5).ToString();
                    inf.Birthday = ireader.GetDateTime(6);
                    inf.PositionCode = ireader.GetInt32(7);
                    inf.Username = ireader.GetString(8);
                    inf.Password = ireader.GetString(9);
                    inf.DepartmentCode = ireader.GetString(10);
                    inf.OffWork = ireader.GetInt32(11);
                    inf.PermissionDepart = ireader.GetValue(12).ToString();
                    inf.PermissionRepository = ireader.GetValue(13).ToString();
                    inf.EmployeeGroupID = ireader.GetInt32(14);
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


        public static DataTable DTEmployeeList(int iEmployCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add(new DataColumn("EmployeeCode", typeof(Int32)));
                table.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
                string sql = string.Empty;
                if (iEmployCode != 0)
                {
                    sql = "select EmployeeCode,EmployeeName from Object where EmployeeCode in({0}) order by EmployeeCode asc";
                }
                else
                {
                    sql = "select EmployeeCode,EmployeeName from Employee order by EmployeeCode asc";
                }
                table = cn.ExecuteQuery(string.Format(sql, iEmployCode));
            }
            catch { }
            return table;
        }

        public static List<EmployeeInf> ListEmployee(string employeeCode, bool offwork)
        {
            ConnectDB cn = new ConnectDB();
            List<EmployeeInf> list = new List<EmployeeInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(employeeCode))
                {
                    sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,PermissionDepart,PermissionRepository,EmployeeGroupID from Employee where EmployeeCode in('{0}') ";
                }
                else
                {
                    sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,PermissionDepart,PermissionRepository,EmployeeGroupID from Employee where 1=1 ";
                }
                if (offwork)
                    sql += " and OffWork=1";
                else
                    sql += " and OffWork=0";
                sql += " order by Rowid desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, employeeCode), null);
                while (ireader.Read())
                {
                    EmployeeInf inf = new EmployeeInf();
                    inf.EmployeeCode = ireader.GetString(0);
                    inf.EmployeeName = ireader.GetString(1);
                    inf.Sex = ireader.GetInt32(2);
                    inf.Mobile = ireader.GetValue(3).ToString();
                    inf.IDCard = ireader.GetValue(4).ToString();
                    inf.Address = ireader.GetValue(5).ToString();
                    inf.Birthday = ireader.GetDateTime(6);
                    inf.PositionCode = ireader.GetInt32(7);
                    inf.Username = ireader.GetString(8);
                    inf.Password = ireader.GetString(9);
                    inf.DepartmentCode = ireader.GetString(10);
                    inf.OffWork = ireader.GetInt32(11);
                    inf.PermissionDepart = ireader.GetValue(12).ToString();
                    inf.PermissionRepository = ireader.GetValue(13).ToString();
                    inf.EmployeeGroupID = ireader.GetInt32(14);
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
        public static List<EmployeeViewInf> ListEmployeeForPosition(string  position)
        {
            ConnectDB cn = new ConnectDB();
            List<EmployeeViewInf> list = new List<EmployeeViewInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(position))
                    sql = " select EmployeeCode,EmployeeName,PositionCode from Employee where PositionCode in({0}) order by Rowid desc ";
                else
                    sql = " select EmployeeCode,EmployeeName,PositionCode from Employee order by Rowid desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, position), null);
                while (ireader.Read())
                {
                    EmployeeViewInf inf = new EmployeeViewInf();
                    inf.EmployeeCode = ireader.GetString(0);
                    inf.EmployeeName = ireader.GetString(1);
                    inf.PositionCode = ireader.GetInt32(2);
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

        public static bool CheckLogin(string sUserName, string sPassword, ref string sEmployeeCode, ref string sFullName)
        {
            ConnectDB cn = new ConnectDB();
            bool bResult = false;
            
            try
            {
                string sql = string.Empty;
                sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork from Employee where Username in('{0}') and [Password]='{1}' and OffWork in(0)";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sUserName, sPassword), null);
                if (ireader.Read())
                {
                    sEmployeeCode = ireader.GetValue(0).ToString();
                    sFullName = ireader.GetValue(1).ToString();
                    bResult = true;
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { bResult = false; }
            return bResult;
        }

        public static List<EmployeeInf> ListEmployeeForDepart(string sDepart)
        {
            ConnectDB cn = new ConnectDB();
            List<EmployeeInf> list = new List<EmployeeInf>();
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(sDepart))
                {
                    sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,PermissionDepart from Employee where DepartmentCode in('{0}') order by Rowid desc";
                }
                else
                {
                    sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,PermissionDepart from Employee  order by Rowid desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sDepart), null);
                while (ireader.Read())
                {
                    EmployeeInf inf = new EmployeeInf();
                    inf.EmployeeCode = ireader.GetString(0);
                    inf.EmployeeName = ireader.GetString(1);
                    inf.Sex = ireader.GetInt32(2);
                    inf.Mobile = ireader.GetValue(3).ToString();
                    inf.IDCard = ireader.GetValue(4).ToString();
                    inf.Address = ireader.GetValue(5).ToString();
                    inf.Birthday = ireader.GetDateTime(6);
                    inf.PositionCode = ireader.GetInt32(7);
                    inf.Username = ireader.GetString(8);
                    inf.Password = ireader.GetString(9);
                    inf.DepartmentCode = ireader.GetString(10);
                    inf.OffWork = ireader.GetInt32(11);
                    inf.PermissionDepart = ireader.GetString(12);
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

        public static Int32 InsEmployee(EmployeeInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[0].Value = info.EmployeeCode;
                param[1] = new SqlParameter("@EmployeeName", SqlDbType.NVarChar);
                param[1].Value = info.EmployeeName;
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
                param[7] = new SqlParameter("@PositionCode", SqlDbType.Int);
                param[7].Value = info.PositionCode;
                param[8] = new SqlParameter("@Username", SqlDbType.VarChar);
                param[8].Value = info.Username;
                param[9] = new SqlParameter("@Password", SqlDbType.VarChar);
                param[9].Value = info.Password;
                param[10] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar);
                param[10].Value = info.DepartmentCode;
                param[11] = new SqlParameter("@offwork", SqlDbType.Int);
                param[11].Value = info.OffWork;
                param[12] = new SqlParameter("@EmployeeGroupID", SqlDbType.Int);
                param[12].Value = info.EmployeeGroupID;
                param[13] = new SqlParameter("@iresult", SqlDbType.Int);
                param[13].Direction = ParameterDirection.Output;
                int iresult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Employee", param);
                if (iresult >= 1)
                    return 1;
                else if (iresult == -1)
                    return -1;
                else
                    return -2;

            }
            catch  { return -2; }
        }

        public static Int32 UpdPermissionDepart(string sEmployeeCode, string sDepart)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[0].Value = sEmployeeCode;
                param[1] = new SqlParameter("@PermissionDepart", SqlDbType.VarChar, 500);
                param[1].Value = sDepart;
                param[2] = new SqlParameter("@iresult", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                int iresult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Upd_EmployeePermiss", param);
                if (iresult >= 1)
                    return 1;
                else if (iresult == -1)
                    return -1;
                else
                    return -2;

            }
            catch { return -2; }
        }

        public static Int32 UpdPass(string sEmployeeCode, string sPassNew)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "update Employee set Password=@Password where EmployeeCode=@EmployeeCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                param[0].Value = sPassNew;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = sEmployeeCode;
                int iresult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
                if (iresult >= 1)
                    return 1;
                else if (iresult == -1)
                    return -1;
                else
                    return -2;

            }
            catch { return -2; }
        }

        public static Int32 UpdPermissionRepository(string sEmployeeCode, string sRep)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[0].Value = sEmployeeCode;
                param[1] = new SqlParameter("@PermissionRepository", SqlDbType.VarChar, 500);
                param[1].Value = sRep;
                param[2] = new SqlParameter("@iresult", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                int iresult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Upd_EmployeeRepository", param);
                if (iresult >= 1)
                    return 1;
                else if (iresult == -1)
                    return -1;
                else
                    return -2;

            }
            catch { return -2; }
        }

        public static Int32 DelEmployee(string sEmployeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = sEmployeeCode;
                int iresult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Employee", param);
                return iresult;
            }
            catch { return -2; }
        }

        public static DataTable TableEmployeeForPosition(string position, string departmentCode)
        {
            ConnectDB access = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "select EmployeeCode,EmployeeName from Employee where PositionCode in({0}) and PermissionDepart like'%{1}%' order by Rowid desc";
                tableResult = access.ExecuteQuery(string.Format(sql, position, departmentCode));
            }
            catch { }
            return tableResult;
        }

        public static DataTable TableEmployeeGroup()
        {
            ConnectDB access = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "select EmployeeGroupID,EmployeeGroupName from EmployeeGroup order by EmployeeGroupID asc";
                tableResult = access.ExecuteQuery(sql);
            }
            catch { }
            return tableResult;
        }

        public static bool CheckUserAdmin(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            bool bResult = false;
            try
            {

                List<EmployeeInf> lst = ListEmployee(employeeCode);
                if (lst != null && lst.Count > 0 && lst[0].EmployeeGroupID == -9999)
                    bResult = true;
            }
            catch { bResult = false; }
            return bResult;
        }

        public static bool CheckUser(string userName, ref string password)
        {
            ConnectDB cn = new ConnectDB();
            bool bResult = false;
            try
            {
                string sql = string.Empty;
                sql = "select EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork from Employee where Username in('{0}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, userName), null);
                if (ireader.Read())
                {
                    password = ireader.GetValue(9).ToString();
                    bResult = true;
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { bResult = false; }
            return bResult;
        }
    }
}
