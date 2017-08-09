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
    public class DiagnosisBLL
    {
        public static DataTable DTDiagnosis(decimal dRowid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("DiagnosisName", typeof(string)));
                dt.Columns.Add(new DataColumn("DiagnosisCode", typeof(string)));
                var vlist = DiagnosisDal.ListDiagnosis(dRowid);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.DiagnosisName;
                    dr[2] = lt1.DiagnosisCode;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<DiagnosisInf> ListDiagnosis(decimal dRowid)
        {
            return DiagnosisDal.ListDiagnosis(dRowid);
        }

        public static List<DiagnosisInf> ListDiagnosis(string rowID)
        {
            return DiagnosisDal.ListDiagnosis(rowID);
        }

        public static List<DiagnosisInf> ListDiagnosisName()
        {
            return DiagnosisDal.ListDiagnosisName();
        }

        public static int InsDiagnosis(DiagnosisInf info)
        {
            try
            {
                return DiagnosisDal.InsDiagnosis(info);
            }
            catch { return -2; }
        }

        public static int DelDiagnosis(decimal dRowid)
        {
            try
            {
                return DiagnosisDal.DelDiagnosis(dRowid);
            }
            catch { return -2; }
        }

    }
}
