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
    public class ServiceModuleDAL
    {
        public static DataTable DTListServiceModule(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                if (sCode != "")
                {
                    sql = "select rowid,servicemodulecode,servicemodulename from ServiceModule where servicemodulecode='{0}' order by rowid desc";
                }
                else
                {
                    sql = "select rowid,servicemodulecode,servicemodulename from ServiceModule order by rowid desc";
                }
                dt = cn.ExecuteQuery(string.Format(sql, sCode));

            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static List<ServiceModuleInf> ListServiceModule(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceModuleInf> list = new List<ServiceModuleInf>();
            try
            {
                string sql = "";
                if (sCode != "")
                {
                    sql = "select rowid,servicemodulecode,servicemodulename from ServiceModule where servicemodulecode='{0}' order by rowid desc";
                }
                else
                {
                    sql = "select rowid,servicemodulecode,servicemodulename from ServiceModule order by rowid desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    ServiceModuleInf inf = new ServiceModuleInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceModuleCode = ireader.GetString(1);
                    inf.ServiceModuleName = ireader.GetString(2);
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

    }
}
