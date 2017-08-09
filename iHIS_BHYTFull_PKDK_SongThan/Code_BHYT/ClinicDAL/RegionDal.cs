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
    public class RegionDal
    {
        public static List<RegionInf> ListRegion(Int32 iRegionID)
        {
            ConnectDB cn = new ConnectDB();
            List<RegionInf> list = new List<RegionInf>();
            try
            {
                string sql = "";
                if (iRegionID != 0)
                {
                    sql = "select RegionID,STT,RegionName,EmployeeCode,NationalityID from Catalog_Region where RegionID in({0}) order by STT asc ";
                }
                else
                {
                    sql = "select RegionID,STT,RegionName,EmployeeCode,NationalityID from Catalog_Region order by STT asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRegionID), null);
                while (ireader.Read())
                {
                    RegionInf inf = new RegionInf();
                    inf.RegionID = ireader.GetInt32(0);
                    inf.STT = ireader.GetInt32(1);
                    inf.RegionName = ireader.GetValue(2).ToString();
                    inf.EmployeeCode = ireader.GetValue(3).ToString();
                    inf.NationalityID = ireader.GetInt32(4);
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

        public static DataTable DTListRegion(Int32 iRegionID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("Result");
            dt.Columns.Add("RegionID", typeof(Int32));
            dt.Columns.Add("STT", typeof(Int32));
            dt.Columns.Add("RegionName", typeof(string));
            dt.Columns.Add("NationalityID", typeof(Int32));
            try
            {
                string sql = "";
                if (iRegionID != 0)
                {
                    sql = "select RegionID,STT,RegionName,NationalityID from Catalog_Region where RegionID in({0}) order by STT asc ";
                }
                else
                {
                    sql = "select RegionID,STT,RegionName,NationalityID from Catalog_Region order by STT asc ";
                }
                dt = cn.ExecuteQuery(string.Format(sql, iRegionID));
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRegionID), null);
                //while (ireader.Read())
                //{
                    
                //    RegionInf inf = new RegionInf();
                //    inf.RegionID = ireader.GetInt32(0);
                //    inf.STT = ireader.GetInt32(1);
                //    inf.RegionName = ireader.GetValue(2).ToString();
                //    inf.NationalityID = ireader.GetInt32(3);
                //    dt.Rows.Add(inf.RegionID, inf.STT, inf.RegionName, inf.NationalityID);
                //}
                //if (!ireader.IsClosed)
                //{
                //    ireader.Close();
                //    ireader.Dispose();
                //}
            }
            catch {  }
            return dt;

        }

        public static Int32 InsRegion(RegionInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RegionID", SqlDbType.Int);
                param[0].Value = info.RegionID;
                param[1] = new SqlParameter("@STT", SqlDbType.Int);
                param[1].Value = info.STT;
                param[2] = new SqlParameter("@RegionName", SqlDbType.NVarChar, 500);
                param[2].Value = info.RegionName;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@NationalityID", SqlDbType.Int);
                param[4].Value = info.NationalityID;
                param[5] = new SqlParameter("@iresult", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prIns_Catalog_Region", param));
            }
            catch { return -2; }
        }
        
        public static Int32 DelRegion(Int32 iRegionID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RegionID", SqlDbType.Int);
                param[1].Value = iRegionID;
                Int32 iresult = 0;
                iresult = Convert.ToInt32(cn.ExecuteNonQuery(CommandType.StoredProcedure, "prDel_Catalog_Region", param));
                return iresult;
            }
            catch { return -1; }
        }
    }
}
