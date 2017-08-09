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
    public class ServiceMenuDAL
    {
        public static List<ServiceMenuINF> ListServiceMenu()
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceMenuINF> list = new List<ServiceMenuINF>();
            try
            {
                string sql = "";
                sql = " Select ServiceMenuID,ServiceMenuName from ServiceMenu where Hide = 0 order by ServiceMenuID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ServiceMenuINF inf = new ServiceMenuINF();
                    inf.ServiceMenuID = ireader.GetInt32(0);
                    inf.ServiceMenuName = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }

        public static List<ServiceMenuForDepartmentINF> ListServiceMenuForDepartmentINF(Int32 idMenu)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceMenuForDepartmentINF> list = new List<ServiceMenuForDepartmentINF>();
            try
            {
                string sql = "";
                sql = "select ServiceMenuID,DepartmentCode from ServiceMenuForDepartment where ServiceMenuID in ({0}) order by ServiceMenuID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, idMenu), null);
                while (ireader.Read())
                {
                    ServiceMenuForDepartmentINF inf = new ServiceMenuForDepartmentINF();
                    inf.ServiceMenuID = ireader.GetInt32(0);
                    inf.DepartmentCode = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }

        public static List<ServiceMenuForServiceINF> ListServiceMenuForService(Int32 idMenu)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceMenuForServiceINF> list = new List<ServiceMenuForServiceINF>();
            try
            {
                string sql = "";
                sql = "select ServiceMenuID,ServiceCode from ServiceMenuForService where ServiceMenuID in({0})  order by ServiceMenuID desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, idMenu), null);
                while (ireader.Read())
                {
                    ServiceMenuForServiceINF inf = new ServiceMenuForServiceINF();
                    inf.ServiceMenuID = ireader.GetInt32(0);
                    inf.ServiceCode = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }

        public static Int32 Ins_ServiceMenuForDepartment(ServiceMenuForDepartmentINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " insert into ServiceMenuForDepartment(DepartmentCode,ServiceMenuID) values(@DepartmentCode,@ServiceMenuID)";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceMenuID", SqlDbType.Int);
                param[0].Value = info.ServiceMenuID;
                param[1] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[1].Value = info.DepartmentCode;
                
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Ins_ServiceMenuForService(ServiceMenuForServiceINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " insert into ServiceMenuForService(ServiceCode,ServiceMenuID) values(@ServiceCode,@ServiceMenuID)";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceMenuID", SqlDbType.Int);
                param[0].Value = info.ServiceMenuID;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del_ServiceMenuForService(Int32 iMenu)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from ServiceMenuForService where ServiceMenuID=@ServiceMenuID";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceMenuID", SqlDbType.Int);
                param[0].Value = iMenu;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del_ServiceMenuForDepartment(Int32 iMenu)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from ServiceMenuForDepartment where ServiceMenuID=@ServiceMenuID";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceMenuID", SqlDbType.Int);
                param[0].Value = iMenu;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static DataTable DT_MenuDeparForEmployee(Int32 idMenu, string sDepartCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                sql = @" select a.DepartmentCode,b.DepartmentName
                        from ServiceMenuForDepartment a inner join Department b on a.DepartmentCode=b.DepartmentCode where a.ServiceMenuID in ({0}) and a.DepartmentCode in({1}) order by a.DepartmentCode ";
                return cn.ExecuteQuery(string.Format(sql, idMenu, sDepartCode));
            }
            catch
            {
                return null;
            }
        }
    }
}
