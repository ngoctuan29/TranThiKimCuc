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
    public class Catalog_ExchangeRateDAL
    {
        public static DataTable DT_List()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                sql = " select RowID,RIAL,VND,USD,OTHER from Catalog_ExchangeRate where RowID=1 ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static Int32 Ins(Catalog_ExchangeRateInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@RIAL", SqlDbType.Decimal);
                param[1].Value = info.RIAL;
                param[2] = new SqlParameter("@VND", SqlDbType.Decimal);
                param[2].Value = info.VND;
                param[3] = new SqlParameter("@USD", SqlDbType.Int);
                param[3].Value = info.USD;
                param[4] = new SqlParameter("@OTHER", SqlDbType.Int);
                param[4].Value = info.OTHER;
                param[5] = new SqlParameter("@EMPLOYEECODE", SqlDbType.VarChar, 50);
                param[5].Value = info.EMPLOYEECODE;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Catalog_ExchangeRate", param) >= 1)
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
                string sql = " delete from Catalog_ExchangeRate where RowID=@RowID";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = iRowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

    }
}
