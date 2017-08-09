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
    public class NationalityDal
    {
        public static List<NationalityInf> ListNationality(Int32 iNationalityID)
        {
            ConnectDB cn = new ConnectDB();
            List<NationalityInf> list = new List<NationalityInf>();
            try
            {
                string sql = "";
                if (iNationalityID != 0)
                {
                    sql = " select NationalityID,STT,NationalityName,ContinentsID from Catalog_Nationality where NationalityID in({0}) order by STT asc ";
                }
                else
                {
                    sql = " select NationalityID,STT,NationalityName,ContinentsID from Catalog_Nationality order by STT asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iNationalityID), null);
                while (ireader.Read())
                {
                    NationalityInf inf = new NationalityInf();
                    inf.NationalityID = ireader.GetInt32(0);
                    inf.STT = ireader.GetInt32(1);
                    inf.NationalityName = ireader.GetString(2);
                    inf.ContinentsID = ireader.GetInt32(3);
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
