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
    public class ServiceSalesDAL
    {
        public static List<ServiceSalesInf> ListServiceSales(int rowID)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceSalesInf> list = new List<ServiceSalesInf>();
            try
            {
                string query = " select RowID,Name,DateFrom,DateTo,Hide,EmployeeCode from ServiceSales ";
                if (rowID > 0)
                    query += " where RowID={0} ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, rowID), null);
                while (ireader.Read())
                {
                    ServiceSalesInf inf = new ServiceSalesInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.Name = ireader.GetValue(1).ToString();
                    inf.DateFrom = ireader.GetDateTime(2);
                    inf.DateTo = ireader.GetDateTime(3);
                    inf.Hide = ireader.GetInt32(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }
        public static DataTable TableServiceSales(int rowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " select RowID,Name,DateFrom,DateTo,Hide,EmployeeCode from ServiceSales ";
                if (rowID > 0)
                    query += " where RowID={0} ";
                return cn.ExecuteQuery(string.Format(query, rowID));
            }
            catch
            {
                return null;
            }
        }
        public static Int32 InsServiceSales(ServiceSalesInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 250);
                param[1].Value = info.Name;
                param[2] = new SqlParameter("@DateFrom", SqlDbType.Date);
                param[2].Value = info.DateFrom;
                param[3] = new SqlParameter("@DateTo", SqlDbType.Date);
                param[3].Value = info.DateTo;
                param[4] = new SqlParameter("@Hide", SqlDbType.Int);
                param[4].Value = info.Hide;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar,15);
                param[5].Value = info.EmployeeCode;
                param[6] = new SqlParameter("@IDOutPut", SqlDbType.Int);
                param[6].Direction = ParameterDirection.Output;
                int rowid = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIns_ServiceSales", param));
                if (rowid >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 DelServiceSales(int rowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = rowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_ServiceSales", param);
            }
            catch { return 404; }
        }
        public static DataTable TableServiceSalesDetail(int rowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " select IDSales,ServiceCode,UnitPrice,RateSales,UnitPriceSales,EmployeeCode from ServiceSalesDetail where IDSales={0} ";
                return cn.ExecuteQuery(string.Format(query, rowID));
            }
            catch
            {
                return null;
            }
        }
        public static Int32 InsServiceSalesDetail(ServiceSalesDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@IDSales", SqlDbType.Int);
                param[0].Value = info.IDSales;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[2].Value = info.UnitPrice;
                param[3] = new SqlParameter("@RateSales", SqlDbType.Int);
                param[3].Value = info.RateSales;
                param[4] = new SqlParameter("@UnitPriceSales", SqlDbType.Decimal);
                param[4].Value = info.UnitPriceSales;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[5].Value = info.EmployeeCode;
                int rowid = Convert.ToInt32(cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_ServiceSalesDetail", param));
                if (rowid >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 DelServiceSalesDetail(int rowid, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = rowid;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[2].Value = serviceCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_ServiceSalesDetail", param);
            }
            catch { return 404; }
        }
    }
}
