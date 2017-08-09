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
    public class CatalogNationalityDAL
    {
        public DataTable DTListNationality(int nationalityID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("NationalityID", typeof(int));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("NationalityName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("ContinentsID", typeof(int));
                string sql = "";
                if (nationalityID != 0)
                {
                    sql = " select NationalityID,STT,NationalityName,EmployeeCode,ContinentsID from Catalog_Nationality where NationalityID in({0}) order by STT ";
                }
                else
                {
                    sql = " select NationalityID,STT,NationalityName,EmployeeCode,ContinentsID from Catalog_Nationality order by STT ";
                }
                dtbResult = cn.ExecuteQuery(string.Format(sql, nationalityID));
                return dtbResult;
            }
            catch { return null; }
        }
    }
}
