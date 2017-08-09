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
    public class ServicePriceDal
    {
        public static List<ServicePriceInf> ListServicePrice(string sServiceCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePriceInf> list = new List<ServicePriceInf>();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.ServiceCode,a.UnitPrice,a.DateOfApplication,a.hide,a.EmployeeCode,a.ObjectCode,a.DisparityPrice,b1.ServiceCategoryName,a.SampleTransferPrice,a.DateOfApplicationEnd,a.PerDiscountIntro,a.DiscountIntro,a.PerDiscountDoctorDone,a.DiscountDoctorDone,a.PerDiscountDoctor,a.DiscountDoctor
                        from [ServicePrice] a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
                        where  b.Hide=0  ";
                if (!string.IsNullOrEmpty(sServiceCode))
                    sql += " and a.ServiceCode='{0}' ";
                sql += " order by a.ServiceCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sServiceCode), null);
                while (ireader.Read())
                {
                    ServicePriceInf inf = new ServicePriceInf();
                    inf.Rowid = ireader.GetDecimal(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.UnitPrice = ireader.GetDecimal(2);
                    inf.DateOfApplication = ireader.GetDateTime(3);
                    inf.Hide = ireader.GetInt32(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.ObjectCode = ireader.GetInt32(6);
                    inf.DisparityPrice = ireader.GetDecimal(7);
                    inf.ServiceCategoryName = ireader.GetValue(8).ToString();
                    inf.SampleTransferPrice = ireader.GetDecimal(9);
                    inf.DateOfApplicationEnd = ireader.GetDateTime(10);
                    inf.PerDiscountIntro = ireader.GetInt32(11);
                    inf.DiscountIntro = ireader.GetDecimal(12);
                    inf.PerDiscountDoctorDone = ireader.GetInt32(13);
                    inf.DiscountDoctorDone = ireader.GetDecimal(14);
                    inf.PerDiscountDoctor = ireader.GetInt32(15);
                    inf.DiscountDoctor = ireader.GetDecimal(16);
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

        public static List<ServicePriceInf> ListServicePriceReal(string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePriceInf> list = new List<ServicePriceInf>();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.ServiceCode,a.UnitPrice,a.DateOfApplication,a.hide,a.EmployeeCode,a.ObjectCode,a.DisparityPrice,b.DepartmentCode,b.UnitOfMeasureCode from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode where a.Hide=0 and CONVERT(date,a.DateOfApplication,103)<=CONVERT(date,getdate(),103)";
                if (!string.IsNullOrEmpty(serviceCode))
                    sql += " and a.ServiceCode='{0}' ";
                sql += " order by CONVERT(date,a.DateOfApplication,103) desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, serviceCode), null);
                while (ireader.Read())
                {
                    ServicePriceInf inf = new ServicePriceInf();
                    inf.Rowid = ireader.GetDecimal(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.UnitPrice = ireader.GetDecimal(2);
                    inf.DateOfApplication = ireader.GetDateTime(3);
                    inf.Hide = ireader.GetInt32(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.ObjectCode = ireader.GetInt32(6);
                    inf.DisparityPrice = ireader.GetDecimal(7);
                    inf.DepartmentCode = ireader.GetString(8);
                    inf.UnitOfMeasureCode = ireader.GetValue(9).ToString();
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

        public static ServicePriceInf ObjServicePriceReal(string sServiceCode, Int32 iObjectCode)
        {
            ConnectDB cn = new ConnectDB();
            ServicePriceInf inf = new ServicePriceInf();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.ServiceCode,a.UnitPrice,a.DateOfApplication,a.hide,a.EmployeeCode,a.ObjectCode,a.DisparityPrice,b.DepartmentCode,b.UnitOfMeasureCode from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode where  a.Hide=0 and a.ServiceCode='{0}' and a.ObjectCode in({1})";
                sql += " order by a.ObjectCode asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sServiceCode, iObjectCode), null);
                if (ireader.Read())
                {
                    inf.Rowid = ireader.GetDecimal(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.UnitPrice = ireader.GetDecimal(2);
                    inf.DateOfApplication = ireader.GetDateTime(3);
                    inf.Hide = ireader.GetInt32(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.ObjectCode = ireader.GetInt32(6);
                    inf.DisparityPrice = ireader.GetDecimal(7);
                    inf.DepartmentCode = ireader.GetString(8);
                    inf.UnitOfMeasureCode = ireader.GetValue(9).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch {  }
            return null;
        }

        public static List<ServicePriceInf> ListServicePriceReal(string sServiceCode, Int32 iObject)
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePriceInf> list = new List<ServicePriceInf>();
            try
            {
                string sql = string.Empty;
                sql = @" select a.RowID,a.ServiceCode,a.UnitPrice,a.DateOfApplication,a.hide,a.EmployeeCode,a.ObjectCode,a.DisparityPrice,b.DepartmentCode from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode 
                        where  a.Hide=0  and a.ServiceCode='{0}' and a.ObjectCode in({1}) and CONVERT(date,getdate(),103) between CONVERT(date,DateOfApplication,103) and CONVERT(date,DateOfApplicationEnd,103) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sServiceCode, iObject), null);
                while (ireader.Read())
                {
                    ServicePriceInf inf = new ServicePriceInf();
                    inf.Rowid = ireader.GetDecimal(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.UnitPrice = ireader.GetDecimal(2);
                    inf.DateOfApplication = ireader.GetDateTime(3);
                    inf.Hide = ireader.GetInt32(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.ObjectCode = ireader.GetInt32(6);
                    inf.DisparityPrice = ireader.GetDecimal(7);
                    inf.DepartmentCode = ireader.GetString(8);
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
        
        public static DataTable DTListPrice_MapService(decimal dRowid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dttemp = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.ServiceCode,a.UnitPrice,a.DateOfApplication,a.hide,a.EmployeeCode,a.ObjectCode,a.DisparityPrice,b.ServiceName,b.DepartmentCode,c.ServiceGroupName,d.DepartmentName,e.ObjectName,a.ObjectCode ";
                sql += " from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode inner join Department d on b.DepartmentCode=d.DepartmentCode inner join Object e on a.ObjectCode=e.ObjectCode ";
                sql += " where a.Hide=0 and b.Hide =0 and c.ServiceGroupCode='KCB'";
                if (dRowid != 0)
                    sql += " and RowID in({0})";
                sql += " order by ServiceGroupName asc ";
                dttemp = cn.ExecuteQuery(string.Format(sql, dRowid));
            }
            catch  { dttemp = null; }
            return dttemp;
        }

        public static DataTable DTListPrice_MapService(decimal dRowid, Int32 iObject, Int32 iPatientType, string serviceGroupCode, string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dttemp = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = " select a.RowID,a.ServiceCode,a.UnitPrice,a.EmployeeCode,a.ObjectCode,a.DisparityPrice,b.ServiceName,b.DepartmentCode,c.ServiceGroupName,e.ObjectName, 0 as Chon ";
                sql += " from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode inner join Object e on a.ObjectCode=e.ObjectCode inner join ServiceMenuForService b1 on b.ServiceCode=b1.ServiceCode ";
                sql += " where a.Hide=0 and b.Hide =0 and a.ObjectCode in({0})";
                if (!string.IsNullOrEmpty(serviceGroupCode))
                    sql += " and c.ServiceGroupCode in(" + serviceGroupCode + ")";
                if (!string.IsNullOrEmpty(serviceCategoryCode))
                    sql += " and b.ServiceCategoryCode in(" + serviceCategoryCode + ")";
                if (dRowid != 0)
                    sql += " and RowID in({1})";
                sql += " and b.PatientType like'%" + iPatientType + "%'";
                sql += " order by ServiceGroupName asc ";
                dttemp = cn.ExecuteQuery(string.Format(sql, iObject, dRowid));
            }
            catch { dttemp = null; }
            return dttemp;
        }
        
        public static Int32 InsServicePrice(ServicePriceInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.Rowid;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[2].Value = info.UnitPrice;
                param[3] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[3].Value = info.ObjectCode;
                param[4] = new SqlParameter("@DateOfApplication", SqlDbType.DateTime);
                param[4].Value = info.DateOfApplication;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar,50);
                param[5].Value = info.EmployeeCode;
                param[6] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[6].Value = info.DisparityPrice;
                param[7] = new SqlParameter("@Hide", SqlDbType.Int);
                param[7].Value = info.Hide;
                param[8] = new SqlParameter("@SampleTransferPrice", SqlDbType.Decimal);
                param[8].Value = info.SampleTransferPrice;
                param[9] = new SqlParameter("@DateOfApplicationEnd", SqlDbType.Date);
                param[9].Value = info.DateOfApplicationEnd;
                param[10] = new SqlParameter("@PerDiscountIntro", SqlDbType.Int);
                param[10].Value = info.PerDiscountIntro;
                param[11] = new SqlParameter("@DiscountIntro", SqlDbType.Decimal);
                param[11].Value = info.DiscountIntro;
                param[12] = new SqlParameter("@PerDiscountDoctorDone", SqlDbType.Int);
                param[12].Value = info.PerDiscountDoctorDone;
                param[13] = new SqlParameter("@DiscountDoctorDone", SqlDbType.Decimal);
                param[13].Value = info.DiscountDoctorDone;
                param[14] = new SqlParameter("@PerDiscountDoctor", SqlDbType.Int);
                param[14].Value = info.PerDiscountDoctor;
                param[15] = new SqlParameter("@DiscountDoctor", SqlDbType.Decimal);
                param[15].Value = info.DiscountDoctor;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ServicePrice", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelServicePrice(Decimal dRowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ServicePrice", param);
            }
            catch { return -1; }
        }

        public static List<ServicePricePrintInf> ListPrintMapService()
        {
            ConnectDB cn = new ConnectDB();
            List<ServicePricePrintInf> lst = new List<ServicePricePrintInf>();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ServiceCode,b.ServiceName,b1.ServiceCategoryName,b2.ServiceGroupName,c.ObjectName,a.UnitPrice,a.DisparityPrice,a.DateOfApplication,a.DateOfApplicationEnd,d.UnitOfMeasureName
                from ServicePrice a inner join Service b on a.ServiceCode=b.ServiceCode 
                inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
                inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode 
                inner join Object c on a.ObjectCode=c.ObjectCode inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode
                where a.Hide=0 order by b2.STT,b.ServiceName ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ServicePricePrintInf inf = new ServicePricePrintInf();
                    inf.ServiceCode = ireader.GetValue(0).ToString();
                    inf.ServiceName = ireader.GetValue(1).ToString();
                    inf.ServiceCategoryName = ireader.GetValue(2).ToString();
                    inf.ServiceGroupName = ireader.GetValue(3).ToString();
                    inf.ObjectName = ireader.GetValue(4).ToString();
                    inf.UnitPrice = ireader.GetDecimal(5);
                    inf.DisparityPrice = ireader.GetDecimal(6);
                    inf.DateOfApplication = ireader.GetDateTime(7);
                    inf.DateOfApplicationEnd = ireader.GetDateTime(8);
                    inf.UnitOfMeasureName = ireader.GetValue(9).ToString();
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch { return null; }
        }

        public static DataTable TableObjectForService(string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("ObjectName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ObjectCard", typeof(Int32)));
                string query = " select distinct a.ObjectCode,b.ObjectName,b.ObjectCard from ServicePrice a inner join [Object] b on a.ObjectCode=b.ObjectCode where ServiceCode='{0}' and a.Hide=0 order by a.ObjectCode ";
                tableResult = cn.ExecuteQuery(string.Format(query, serviceCode));
            }
            catch { return null; }
            return tableResult;
        }
        
        public static DataTable TableListServicePrice()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = string.Empty;
                query = @" select a.ServiceCode,a.ServiceName,a3.UnitOfMeasureName,b1.ObjectName,b1.ObjectCode,b.UnitPrice,b.DisparityPrice,a1.ServiceCategoryName,a2.ServiceGroupName,a3.UnitOfMeasureCode
                 from Service a inner join ServiceCategory a1 on a.ServiceCategoryCode=a1.ServiceCategoryCode inner join ServiceGroup a2 on a1.ServiceGroupCode=a2.ServiceGroupCode
                 inner join UnitOfMeasure a3 on a.UnitOfMeasureCode=a3.UnitOfMeasureCode inner join ServicePrice b on a.ServiceCode=b.ServiceCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode
                 where CONVERT(date,b.DateOfApplication,103)<=CONVERT(date,GETDATE(),103) and b.Hide=0
                 order by a2.ServiceGroupName,a1.ServiceCategoryName ";
                tableResult = cn.ExecuteQuery(query);
            }
            catch { return null; }
            return tableResult;
        }

    }
}
