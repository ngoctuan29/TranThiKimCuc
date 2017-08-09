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
    public class ServiceCategoryDal
    {
        public static List<ServiceCategoryInf> ListServiceCategory(string group, string cateCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceCategoryInf> list = new List<ServiceCategoryInf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,ServiceGroupCode,ServiceCategoryCode,ServiceCategoryName,STT from ServiceCategory where 1=1 ";
                if (group != "")
                    sql += " and servicegroupcode in('{0}')";
                if (cateCode != "")
                    sql += " and ServiceCategoryCode in('{1}')";
                sql += "  order by STT asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, group, cateCode), null);
                while (ireader.Read())
                {
                    ServiceCategoryInf inf = new ServiceCategoryInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceGroupCode = ireader.GetString(1);
                    inf.ServiceCategoryCode = ireader.GetString(2);
                    inf.ServiceCategoryName = ireader.GetString(3);
                    inf.STT = ireader.GetInt32(4);
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

        public static List<ServiceCategoryInf> ListServiceCategoryRefService(string groupCode, string cateCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceCategoryInf> list = new List<ServiceCategoryInf>();
            try
            {
                string sql = string.Empty;
                sql = "select distinct a.ServiceGroupCode,a.ServiceCategoryCode,a.ServiceCategoryName,a.STT from ServiceCategory a inner join [Service] b on a.ServiceCategoryCode = b.ServiceCategoryCode where 1=1 ";
                if (!string.IsNullOrEmpty(groupCode))
                    sql += " and a.servicegroupcode in('{0}')";
                if (!string.IsNullOrEmpty(cateCode))
                    sql += " and a.ServiceCategoryCode in('{1}')";
                sql += "  order by STT asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, groupCode, cateCode), null);
                while (ireader.Read())
                {
                    ServiceCategoryInf inf = new ServiceCategoryInf();
                    inf.ServiceGroupCode = ireader.GetString(0);
                    inf.ServiceCategoryCode = ireader.GetString(1);
                    inf.ServiceCategoryName = ireader.GetString(2);
                    inf.STT = ireader.GetInt32(3);
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

        public static List<ServiceCategoryInf> rptListServiceCategory(string sGroup, string sCateCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceCategoryInf> list = new List<ServiceCategoryInf>();
            try
            {
                string sql = "";
                sql = "select RowID,ServiceGroupCode,ServiceCategoryCode,ServiceCategoryName,STT from ServiceCategory where 1=1 ";
                if (sGroup != "")
                    sql += " and servicegroupcode in({0})";
                if (sCateCode != "")
                    sql += " and ServiceCategoryCode in({1})";
                sql += "  order by STT asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sGroup, sCateCode), null);
                while (ireader.Read())
                {
                    ServiceCategoryInf inf = new ServiceCategoryInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceGroupCode = ireader.GetString(1);
                    inf.ServiceCategoryCode = ireader.GetString(2);
                    inf.ServiceCategoryName = ireader.GetString(3);
                    inf.STT = ireader.GetInt32(4);
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

        public static Int32 InsServiceCategory(ServiceCategoryInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServiceGroupCode;
                param[1] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCategoryCode;
                param[2] = new SqlParameter("@ServiceCategoryName", SqlDbType.NVarChar);
                param[2].Value = info.ServiceCategoryName;
                param[3] = new SqlParameter("@STT", SqlDbType.Int);
                param[3].Value = info.STT;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ServiceCategory", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelServiceCategory(string sServiceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[1].Value = sServiceCategoryCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ServiceCategory", param);
            }
            catch { return -1; }
        }

    }
}
