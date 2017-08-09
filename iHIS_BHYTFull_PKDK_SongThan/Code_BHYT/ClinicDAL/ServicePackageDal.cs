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
    public class ServicePackageDal
    {
        public static List<ServicePackageInf> ListServicePackage(string sPackageCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePackageInf> list = new List<ServicePackageInf>();
            try
            {
                string sql = "";
                if (sPackageCode != "")
                {
                    sql = " Select ServicePackageCode,ServicePackageName,EmployeeCode from ServicePackage where ServicePackageCode in('{0}') order by ServicePackageCode asc ";
                }
                else
                {
                    sql = " Select ServicePackageCode,ServicePackageName,EmployeeCode from ServicePackage order by ServicePackageCode asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPackageCode), null);
                while (ireader.Read())
                {
                    ServicePackageInf inf = new ServicePackageInf();
                    inf.ServicePackageCode = ireader.GetString(0);
                    inf.ServicePackageName = ireader.GetString(1);
                    inf.EmployeeCode = ireader.GetString(2);
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

        public static Int32 InsServicePackage(ServicePackageInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ServicePackageCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServicePackageCode;
                param[1] = new SqlParameter("@ServicePackageName", SqlDbType.NVarChar, 1000);
                param[1].Value = info.ServicePackageName;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.EmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ServicePackage", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelServicePackage(string sPackageCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ServicePackageCode", SqlDbType.VarChar, 50);
                param[1].Value = sPackageCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ServicePackage", param);
            }
            catch { return -1; }
        }
    }
}
