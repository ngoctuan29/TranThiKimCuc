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
    public class UnitValuesDAL
    {
        public static List<UnitValuesInf> ListUnitValues(int iRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<UnitValuesInf> list = new List<UnitValuesInf>();
            try
            {
                string sql = "";
                if (iRowID != 0)
                {
                    sql = " select RowID,UnitValuesName from UnitValues where RowID in({0}) order by RowID asc ";
                }
                else
                {
                    sql = " select RowID,UnitValuesName from UnitValues order by RowID asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                while (ireader.Read())
                {
                    UnitValuesInf inf = new UnitValuesInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.UnitValuesName = ireader.GetString(1);
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
        
        public static DataTable DT_UnitValues(int iRowID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("UnitValuesName", typeof(string)));
                string sql = "";
                if (iRowID != 0)
                {
                    sql = " select RowID,UnitValuesName from UnitValues where RowID in({0}) order by RowID asc ";
                }
                else
                {
                    sql = " select RowID,UnitValuesName from UnitValues order by RowID asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                while (ireader.Read())
                {
                    dt.Rows.Add(ireader.GetInt32(0), ireader.GetValue(1).ToString());
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 Ins(UnitValuesInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@UnitValuesName", SqlDbType.NVarChar, 250);
                param[1].Value = info.UnitValuesName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_UnitValues", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(Int32 iRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = iRowID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_UnitValues", param);
            }
            catch { return -1; }
        }

    }
}
