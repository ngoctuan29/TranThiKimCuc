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
    public class Tackle_DAL
    {
        public static List<TackleInf> ListTackle()
        {
            ConnectDB cn = new ConnectDB();
            List<TackleInf> list = new List<TackleInf>();
            try
            {
                string sql = " select TackleCode, TackleName from Tackle order by TackleCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    TackleInf inf = new TackleInf();
                    inf.TackleCode = ireader.GetInt32(0);
                    inf.TackleName = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return list;
            }
            catch  { return null; }
        }
    }
}
