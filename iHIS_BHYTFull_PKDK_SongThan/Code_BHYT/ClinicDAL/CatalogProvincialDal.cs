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
    public class CatalogProvincialDal
    {
        public static DataTable DTRegionAll()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                string sql = string.Empty;
                sql = " select RegionID,RegionName from Catalog_Region order by STT ";
                dtbResult = cn.ExecuteQuery(sql);
                return dtbResult;
            }
            catch { return null; }
        }

        public static DataTable DTListProvincial(string provincialCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("ProvincialCode", typeof(string));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("ProvincialName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("RegionID", typeof(int));
                dtbResult.Columns.Add("ProvincialIDBHYT", typeof(string));
                string sql = "";
                if (!string.IsNullOrEmpty(provincialCode))
                {
                    sql = " select ProvincialCode,STT,ProvincialName,EmployeeCode,RegionID,ProvincialIDBHYT from Catalog_Provincial where ProvincialCode='{0}' order by STT ";
                }
                else
                {
                    sql = " select ProvincialCode,STT,ProvincialName,EmployeeCode,RegionID,ProvincialIDBHYT from Catalog_Provincial order by STT ";
                }
                dtbResult = cn.ExecuteQuery(string.Format(sql, provincialCode));
                return dtbResult;
            }
            catch { return null; }
        }

        public static DataTable DTListProvincialForBHYT(string provincialCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("ProvincialCode", typeof(string));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("ProvincialName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("RegionID", typeof(int));
                dtbResult.Columns.Add("ProvincialIDBHYT", typeof(string));
                string sql = " select ProvincialCode,STT,ProvincialName,EmployeeCode,RegionID,ProvincialIDBHYT from Catalog_Provincial where ProvincialIDBHYT is not null order by STT ";
                if (!string.IsNullOrEmpty(provincialCode))
                    sql = " select ProvincialCode,STT,ProvincialName,EmployeeCode,RegionID,ProvincialIDBHYT from Catalog_Provincial where ProvincialCode='{0}' and ProvincialIDBHYT is not null order by STT ";
                dtbResult = cn.ExecuteQuery(string.Format(sql, provincialCode));
                return dtbResult;
            }
            catch { return null; }
        }

        public static bool InsProvincial(CatalogProvincialInf obj)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[0].Value = obj.ProvincialCode;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = obj.STT;
                param[2] = new SqlParameter("@ProvincialName", SqlDbType.NVarChar, 500);
                param[2].Value = obj.ProvincialName;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[3].Value = obj.EmployeeCode;
                param[4] = new SqlParameter("@RegionID", SqlDbType.Int);
                param[4].Value = obj.RegionID;
                param[5] = new SqlParameter("@ProvincialIDBHYT", SqlDbType.VarChar, 3);
                param[5].Value = obj.ProvincialIDBHYT;
                param[6] = new SqlParameter("@iresult", SqlDbType.Int);
                param[6].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prIns_Catalog_Provincial", param));
                if (iresult >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public static int DelProvincial(string provincialCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[0].Value = provincialCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prDel_Catalog_Provincial", param));
                return iresult;
            }
            catch { return -3; }
        }

    }
}
