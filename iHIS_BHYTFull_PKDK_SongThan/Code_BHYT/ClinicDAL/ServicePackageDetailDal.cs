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
    public class ServicePackageDetailDal
    {
        public static List<ServicePackageDetailInf> ListServicePackageDetail(string sPackageCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePackageDetailInf> list = new List<ServicePackageDetailInf>();
            try
            {
                string sql = string.Empty;
                if (sPackageCode != "")
                {
                    sql = " Select ServicePackageCode,ServiceCode,EmployeeCode,RowID,Serial,ServicePrice from ServicePackageDetail where ServicePackageCode in('{0}') order by Serial asc ";
                }
                else
                {
                    sql = " Select ServicePackageCode,ServiceCode,EmployeeCode,RowID,Serial,ServicePrice from ServicePackageDetail order by Serial asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPackageCode), null);
                while (ireader.Read())
                {
                    ServicePackageDetailInf inf = new ServicePackageDetailInf();
                    inf.ServicePackageCode = ireader.GetString(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.EmployeeCode = ireader.GetString(2);
                    inf.RowID = ireader.GetDecimal(3);
                    inf.Serial = ireader.GetInt32(4);
                    inf.ServicePrice = ireader.GetDecimal(5);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }

        public static DataTable TablePackageDetail(string packageCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePackageDetailInf> list = new List<ServicePackageDetailInf>();
            try
            {
                string sql = string.Empty;
                sql = @" select b.ServiceName,a.servicecode,c.ServiceCategoryName,a.ServicePackageCode,a1.ServicePackageName,a.ServicePrice,b1.UnitOfMeasureName
                        from ServicePackageDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode
                        inner join ServiceCategory c on b.ServiceCategoryCode=c.ServiceCategoryCode inner join ServicePackage a1 on a.ServicePackageCode=a1.ServicePackageCode";
                if (!string.IsNullOrEmpty(packageCode))
                    sql += " where a.ServicePackageCode in('{0}') ";
                return cn.ExecuteQuery(string.Format(sql, packageCode));
            }
            catch { return null; }
        }

        public static List<Model_Chidinh> ListChidinh(string sPackageCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Model_Chidinh> list = new List<Model_Chidinh>();
            try
            {
                string sql = "  Select a.ServiceCode,b.ServiceName,c.ObjectCode,c.UnitPrice,c.DisparityPrice,b.DepartmentCode,c.RowID,a.ServicePackageCode,a.EmployeeCode,a.RowID,b.UnitOfMeasureCode,a.ServicePrice from ServicePackageDetail a inner join [Service] b on a.ServiceCode = b.ServiceCode inner join ServicePrice c on b.ServiceCode = c.ServiceCode where a.ServicePackageCode in('{0}') and b.Hide = 0 and c.ObjectCode = 2 order by b.ServiceCode asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPackageCode), null);
                while (ireader.Read())
                {
                    Model_Chidinh model = new Model_Chidinh();
                    model.ReceiptID = 0;
                    model.ServiceCode = ireader.GetString(0);
                    model.ServiceName = ireader.GetString(1);
                    model.Quantity = 1;
                    model.ObjectCode = ireader.GetInt32(2);
                    model.Price = ireader.GetDecimal(3);
                    model.DisparityPrice = ireader.GetDecimal(4);
                    model.DepartmentCode = ireader.GetString(5);
                    model.Status = 0;
                    model.Paid = 0;
                    model.Del = 0;
                    model.RowIDPrice = ireader.GetDecimal(6);
                    model.ServicePackageCode = ireader.GetString(7);
                    model.UnitOfMeasureCode = ireader.GetValue(10).ToString();
                    model.ServicePrice = Convert.ToDecimal(ireader.GetValue(11).ToString());
                    list.Add(model);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }

        public static Int32 InsServicePackageDetail(ServicePackageDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ServicePackageCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServicePackageCode;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.EmployeeCode;
                param[3] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[3].Value = info.RowID;
                param[4] = new SqlParameter("@Serial", SqlDbType.Int);
                param[4].Value = info.Serial;
                param[5] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[5].Value = info.ServicePrice;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ServicePackageDetail", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelServicePackageDetail(Decimal dRowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ServicePackageDetail", param);
            }
            catch { return -1; }
        }

    }
}
