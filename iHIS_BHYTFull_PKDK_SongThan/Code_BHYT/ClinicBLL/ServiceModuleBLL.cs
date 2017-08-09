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
    public class ServiceModuleBLL
    {
        public static DataTable DTListServiceModule(string sCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ServiceModuleCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ServiceModuleName", typeof(string)));
                //dt.Columns.Add(new DataColumn("GroupID_BHYT", typeof(Int32)));
                var vlist = ServiceModuleDAL.ListServiceModule(sCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.ServiceModuleCode;
                    dr[2] = lt1.ServiceModuleName;
                    //dr[3] = lt1.GroupID_BHYT;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<ServiceModuleInf> ListServiceModule(string sCode)
        {
            List<ServiceModuleInf> list = new List<ServiceModuleInf>();
            try
            {
                list = ServiceModuleDAL.ListServiceModule(sCode);
            }
            catch { list = null; }
            return list;
        }
    }
}
