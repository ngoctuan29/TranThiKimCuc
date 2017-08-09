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
    public class TNTTDal
    {
        public static DataTable TableTaiNanTT()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select Ma,Ten from DMTaiNanTT order by ma ";
                tableResult = cn.CallProcedureTable(CommandType.Text, query, null);
            }
            catch { tableResult = null; }
            return tableResult;
        }

    }
}
