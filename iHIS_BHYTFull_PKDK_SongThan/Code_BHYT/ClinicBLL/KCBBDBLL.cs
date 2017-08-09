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
    public class KCBBDBLL
    {
        public static DataTable DTKCBBD_List(string provincialIDBHYT)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("KCBBDCode", typeof(string)));
                dt.Columns.Add(new DataColumn("KCBBDName", typeof(string)));
                dt.Columns.Add(new DataColumn("ProvincialIDBHYT", typeof(string)));
                dt.Columns.Add(new DataColumn("TT", typeof(int)));
                dt.Columns.Add(new DataColumn("KCBBDCodeFull", typeof(string)));
                var vlist = KCBBDDal.ListKCBBD(provincialIDBHYT);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.KCBBDCode;
                    dr[2] = lt1.KCBBDName;
                    dr[3] = lt1.ProvincialIDBHYT;
                    dr[4] = lt1.TT;
                    dr[5] = lt1.ProvincialIDBHYT + "-" + lt1.KCBBDCode;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable TableKCBBDForBHYT(string provincialIDBHYT, string kcbbdCode)
        {
            return KCBBDDal.TableKCBBDForBHYT(provincialIDBHYT, kcbbdCode);
        }
        public static DataTable TableKCBBDALL()
        {
            return KCBBDDal.TableKCBBDALL();
        }
        public static DataTable TableKCBBDForBHYT(string kcbbdCode)
        {
            return KCBBDDal.TableKCBBDForBHYT(kcbbdCode);
        }

        public static int InsKCBBD(KCBBDInf info)
        {
            return KCBBDDal.InsKCBBD(info);
        }

        public static int DelKCBBD(decimal dRowid)
        {
            return KCBBDDal.DelKCBBD(dRowid);
        }
        public static DataTable TinhKCBBD_List()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("ProvincialIDBHYT", typeof(string)));
                dt.Columns.Add(new DataColumn("ProvincialName", typeof(string)));
                var vlist = KCBBDDal.ListTinhKCBBD();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.ProvincialIDBHYT;
                    dr[1] = lt1.ProvincialName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
    }
}
