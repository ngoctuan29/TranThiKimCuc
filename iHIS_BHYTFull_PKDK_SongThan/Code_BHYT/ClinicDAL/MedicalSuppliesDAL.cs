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
    public class MedicalSuppliesDAL
    {
        public static List<MedicalSuppliesINF> ListSupplies()
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalSuppliesINF> list = new List<MedicalSuppliesINF>();
            try
            {
                string sql = "";
                sql = "select RowID,SuppliesName from MedicalSupplies order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    MedicalSuppliesINF inf = new MedicalSuppliesINF();
                    inf.RowID = ireader.GetInt32(0);
                    inf.SuppliesName = ireader.GetString(1);
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
