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
    public class AdvicesBLL
    {
        public static DataTable DTAdvices(decimal dRowid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("AdvicesName", typeof(string)));
                var vlist = AdvicesDal.ListAdvices(dRowid);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.AdvicesName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<AdvicesInf> ListAdvices(decimal dRowid)
        {
            List<AdvicesInf> list = new List<AdvicesInf>();
            try
            {
                list = AdvicesDal.ListAdvices(dRowid);
            }
            catch  { list = null; }
            return list;
        }

        public static int InsAdvices(AdvicesInf info)
        {
            try
            {
                return AdvicesDal.InsAdvices(info);
            }
            catch { return -2; }
        }

        public static int DelAdvices(decimal dRowid)
        {
            try
            {
                return AdvicesDal.DelAdvices(dRowid);
            }
            catch { return -2; }
        }
    }
}
