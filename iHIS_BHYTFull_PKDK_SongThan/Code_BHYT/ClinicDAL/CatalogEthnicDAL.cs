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
    public class CatalogEthnicDAL
    {
        public DataTable DTListEthnic(int ethnicID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dtbResult = new DataTable();
                dtbResult.Columns.Add("EThnicID", typeof(int));
                dtbResult.Columns.Add("STT", typeof(int));
                dtbResult.Columns.Add("EThnicName", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("NationalityID", typeof(int));
                string sql = "";
                if (ethnicID != 0)
                {
                    sql = " select EThnicID,STT,EThnicName,EmployeeCode,NationalityID from Catalog_EThnic where EThnicID in({0}) order by STT ";
                }
                else
                {
                    sql = " select EThnicID,STT,EThnicName,EmployeeCode,NationalityID from Catalog_EThnic order by STT ";
                }
                dtbResult = cn.ExecuteQuery(string.Format(sql, ethnicID));
                return dtbResult;
            }
            catch { return null; }
        }
    }
}
