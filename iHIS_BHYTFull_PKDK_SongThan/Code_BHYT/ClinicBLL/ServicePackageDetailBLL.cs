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
    public class ServicePackageDetailBLL
    {
        public static DataTable DTServicePackage(string sPackageCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ServicePackageCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ServiceCode", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Serial", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ServicePrice", typeof(decimal)));
                var vlist = ServicePackageDetailDal.ListServicePackageDetail(sPackageCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.ServicePackageCode;
                    dr[2] = lt1.ServiceCode;
                    dr[3] = lt1.EmployeeCode;
                    dr[4] = lt1.Serial;
                    dr[5] = lt1.ServicePrice;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<ServicePackageDetailInf> ListServicePackageDetail(string sPackageCode)
        {
            return ServicePackageDetailDal.ListServicePackageDetail(sPackageCode);
        }
        public static List<Model_Chidinh> ListChidinh(string sPackageCode)
        {
            return ServicePackageDetailDal.ListChidinh(sPackageCode);
        }
        public static DataTable TablePackageDetail(string sPackageCode)
        {
            return ServicePackageDetailDal.TablePackageDetail(sPackageCode);
        }
        public static int InsServicePackageDetail(ServicePackageDetailInf info)
        {
            return ServicePackageDetailDal.InsServicePackageDetail(info);
        }

        public static int DelServicePackageDetail(decimal dRowid)
        {
            return ServicePackageDetailDal.DelServicePackageDetail(dRowid);
        }
    }
}
