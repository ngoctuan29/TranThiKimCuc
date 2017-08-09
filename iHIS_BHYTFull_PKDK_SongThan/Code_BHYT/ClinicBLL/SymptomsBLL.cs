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
    public class SymptomsBLL
    {
        public static DataTable DTSymptoms(decimal dRowid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("SymptomsName", typeof(string)));
                var vlist = SymptomsDal.ListSymptoms(dRowid);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.SymptomsName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<SymptomsInf> ListSymptoms(decimal dRowid)
        {
            return SymptomsDal.ListSymptoms(dRowid);
        }

        public static int InsSymptoms(SymptomsInf info)
        {
            try
            {
                return SymptomsDal.InsSymptoms(info);
            }
            catch { return -2; }
        }

        public static int DelSymptoms(decimal dRowid)
        {
            try
            {
                return SymptomsDal.DelSymptoms(dRowid);
            }
            catch { return -2; }
        }
    }
}
