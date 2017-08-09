using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;
using ClinicLibrary;
using ClinicDAL;

namespace ClinicBLL
{
    public class ServiceSalesBLL
    {
        public static List<ServiceSalesInf> ListServiceSales(int rowID)
        {
            return ServiceSalesDAL.ListServiceSales(rowID);
        }
        public static DataTable TableServiceSales(int rowID)
        {
            return ServiceSalesDAL.TableServiceSales(rowID);
        }
        public static Int32 InsServiceSales(ServiceSalesInf info)
        {
            return ServiceSalesDAL.InsServiceSales(info);
        }
        public static Int32 DelServiceSales(int rowid)
        {
            return ServiceSalesDAL.DelServiceSales(rowid);
        }
        public static DataTable TableServiceSalesDetail(int rowID)
        {
            return ServiceSalesDAL.TableServiceSalesDetail(rowID);
        }
        public static Int32 InsServiceSalesDetail(ServiceSalesDetailInf info)
        {
            return ServiceSalesDAL.InsServiceSalesDetail(info);
        }
        public static Int32 DelServiceSalesDetail(int rowid, string serviceCode)
        {
            return ServiceSalesDAL.DelServiceSalesDetail(rowid, serviceCode);
        }
    }
}
