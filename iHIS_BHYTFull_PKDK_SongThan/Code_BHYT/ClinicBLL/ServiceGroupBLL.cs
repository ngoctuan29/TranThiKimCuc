using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicLibrary;
using ClinicModel;
using System.Data;
using ClinicDAL;
namespace ClinicBLL
{
    public class ServiceGroupBLL
    {
        public static DataTable DTServiceGroup(string sgroup)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID"));
                dt.Columns.Add(new DataColumn("ServiceGroupCode"));
                dt.Columns.Add(new DataColumn("ServiceGroupName"));
                dt.Columns.Add(new DataColumn("ServiceModuleCode"));
                dt.Columns.Add(new DataColumn("STT"));
                dt.Columns.Add(new DataColumn("GroupID_BHYT"));
                var vlist = ServiceGroupDal.ListServiceGroup(sgroup);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.ServiceGroupCode;
                    dr[2] = lt1.ServiceGroupName;
                    dr[3] = lt1.ServiceModuleCode;
                    dr[4] = lt1.STT;
                    dr[5] = lt1.GroupID_BHYT;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch{ dt = null; }
            return dt;
        }

        public static List<ServiceGroupInf> ListServiceGroup(string sgroup)
        {
            return ServiceGroupDal.ListServiceGroup(sgroup);
        }

        public static int InsServiceGroup(ServiceGroupInf info, Boolean bIns)
        {
            try
            {
                return  ServiceGroupDal.InsServiceGroup(info, bIns);
            }
            catch { return -2; }
        }

        public static int DelServiceGroup(string sGroupCode)
        {
            try
            {
                return ServiceGroupDal.DelServiceGroup(sGroupCode);
            }
            catch { return -2; }
        }

    }
}
