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
    public class CatalogDistrictDAL
    {
        public CatalogDistrictDAL()
        { }

        public DataTable DTListDistrict(string districtCode, string provincialCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("DistrictCode", typeof(string));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("DistrictName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("ProvincialCode", typeof(string));
                string sql = "select DistrictCode,STT,DistrictName,EmployeeCode,ProvincialCode from Catalog_District where 1=1";
                if (districtCode != string.Empty)
                    sql += " and DistrictCode='{0}'";
                if (provincialCode != string.Empty)
                    sql += " and ProvincialCode='{1}'";
                sql += "order by ProvincialCode,STT";
                dtbResult = cn.ExecuteQuery(string.Format(sql, districtCode, provincialCode));
                return dtbResult;
            }
            catch { return null; }
        }

        public DataTable DTListDistrictForProvincial(string provincialCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("DistrictCode", typeof(string));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("DistrictName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("ProvincialCode", typeof(string));
                string sql = "";
                sql = " select DistrictCode,STT,DistrictName,EmployeeCode,ProvincialCode from Catalog_District where ProvincialCode='{0}' order by STT ";
                dtbResult = cn.ExecuteQuery(string.Format(sql, provincialCode));
                return dtbResult;
            }
            catch { return null; }
        }

        public bool InsDistrict(CatalogDistrictInf obj)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 6);
                param[0].Value = obj.DistrictCode;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = obj.STT;
                param[2] = new SqlParameter("@DistrictName", SqlDbType.NVarChar, 500);
                param[2].Value = obj.DistrictName;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[3].Value = obj.EmployeeCode;
                param[4] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[4].Value = obj.ProvincialCode;
                param[5] = new SqlParameter("@iresult", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prIns_Catalog_District", param));
                if (iresult >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public int DelDistrict(string districtCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 5);
                param[0].Value = districtCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prDel_Catalog_District", param));
                return iresult;
            }
            catch { return -3; }
        }

    }
}
