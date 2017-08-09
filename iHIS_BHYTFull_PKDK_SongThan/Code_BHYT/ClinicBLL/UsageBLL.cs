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
    public class UsageBLL
    {
        public static DataTable DTUsageList(string sCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                dt.Columns.Add(new DataColumn("UsageName", typeof(string)));
                dt.Columns.Add(new DataColumn("STT", typeof(int)));
                dt.Columns.Add(new DataColumn("BHYT_MaDuongDung", typeof(string)));
                var vlist = UsageDal.ListUsage(sCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.UsageCode;
                    dr[1] = lt1.UsageName;
                    dr[2] = lt1.STT;
                    dr[3] = lt1.BHYT_MaDuongDung;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<UsageInf> ListUsage(string sUsageCode)
        {
            return UsageDal.ListUsage(sUsageCode);
        }

        public static int InsUsage(UsageInf info)
        {
            return UsageDal.InsUsage(info);
        }

        public static int DelUsage(string sCode)
        {
            return UsageDal.DelUsage(sCode);
        }
        public static DataTable DataUsageBHYT()
        {
            return UsageDal.DataUsageBHYT();
        }
    }
}
