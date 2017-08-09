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
    public class ServicePackageBLL
    {
        public static DataTable DTServicePackage(string packageCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("ServicePackageCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ServicePackageName", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode",typeof(string)));
                dt.Columns.Add(new DataColumn("Check", typeof(Int32)));
                var vlist = ServicePackageDal.ListServicePackage(packageCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.ServicePackageCode;
                    dr[1] = lt1.ServicePackageName;
                    dr[2] = lt1.EmployeeCode;
                    dr[3] = 0;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<ServicePackageInf> ListServicePackage(string sgroup)
        {
            return ServicePackageDal.ListServicePackage(sgroup);
        }

        public static int InsServicePackage(ServicePackageInf info)
        {
            return ServicePackageDal.InsServicePackage(info);
        }

        public static int DelServicePackage(string sPackageCode)
        {
            return ServicePackageDal.DelServicePackage(sPackageCode);

        }
    }
}
