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
    public class CatalogWardDAL
    {
        public CatalogWardDAL()
        { }
                
        public DataTable DTListWard(string wardCode, string districtCode, string provincialCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("WardCode", typeof(string));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("WardName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("DistrictCode", typeof(string));
                dtbResult.Columns.Add("ShortFor", typeof(string));
                dtbResult.Columns.Add("ProvincialCode", typeof(string));
                string sql = "select a.WardCode,a.STT,a.WardName,a.EmployeeCode,a.DistrictCode,a.ShortFor,b.ProvincialCode from Catalog_Ward a inner join Catalog_District b on a.DistrictCode=b.DistrictCode where 1=1 ";
                if (wardCode != string.Empty)
                    sql += " and a.WardCode in('{0}')";
                if (districtCode != string.Empty)
                    sql += " and a.DistrictCode in('{1}')";
                if (provincialCode != string.Empty)
                    sql += " and b.ProvincialCode in('{2}')";
                sql += " order by b.ProvincialCode,a.DistrictCode,a.STT ";
                dtbResult = cn.ExecuteQuery(string.Format(sql, wardCode, districtCode, provincialCode));
                return dtbResult;
            }
            catch { return null; }
        }

        public bool InsWard(CatalogWardInf obj)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@WardCode", SqlDbType.VarChar, 8);
                param[0].Value = obj.WardCode;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = obj.STT;
                param[2] = new SqlParameter("@WardName", SqlDbType.NVarChar, 500);
                param[2].Value = obj.WardName;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[3].Value = obj.EmployeeCode;
                param[4] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 5);
                param[4].Value = obj.DistrictCode;
                param[5] = new SqlParameter("@ShortFor", SqlDbType.VarChar, 50);
                param[5].Value = obj.ShortFor;
                param[6] = new SqlParameter("@iresult", SqlDbType.Int);
                param[6].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prIns_Catalog_Ward", param));
                if (iresult >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public int DelWard(string wardCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@WardCode", SqlDbType.VarChar, 8);
                param[0].Value = wardCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prDel_Catalog_Ward", param));
                return iresult;
            }
            catch { return -3; }
        }

    }
}
