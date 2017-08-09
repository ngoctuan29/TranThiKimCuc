using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using ClinicModel;

namespace ClinicDAL
{
    public class PatientTypeDAL
    {
        public static List<PatientTypeINF> ListPatientType()
        {
            ConnectDB cn = new ConnectDB();
            List<PatientTypeINF> list = new List<PatientTypeINF>();
            try
            {
                string sql = "";
                sql = "select RowID,TypeName from PatientType order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    PatientTypeINF inf = new PatientTypeINF();
                    inf.RowID = ireader.GetInt32(0);
                    inf.TypeName = ireader.GetString(1);
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
