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
    public class MedicalReasonDAL
    {
        public static List<MedicalReasonINF> ListReason()
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalReasonINF> list = new List<MedicalReasonINF>();
            try
            {
                string sql = "";
                sql = "select RowID,ReasonName from MedicalReason order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    MedicalReasonINF inf = new MedicalReasonINF();
                    inf.RowID = ireader.GetInt32(0);
                    inf.ReasonName = ireader.GetString(1);
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
    }
}
