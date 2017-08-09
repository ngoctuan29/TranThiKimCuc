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
    public class iLABGetResultDAL
    {
        public static DataTable TableResult_iLab(string dateWorking, string resultCode, string machineCode)
        {
            ConnectDBiLAB cn = new ConnectDBiLAB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "proLayKetQuaXN";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PostingDate", SqlDbType.Date);
                param[0].Value = Convert.ToDateTime(dateWorking);
                param[1] = new SqlParameter("@ResultCode", SqlDbType.VarChar, 50);
                param[1].Value = resultCode;
                param[2] = new SqlParameter("@MachineCode", SqlDbType.VarChar, 50);
                param[2].Value = machineCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
    }
}
