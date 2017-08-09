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
    public class SamplePrescriptionHeader_BLL
    {
        public static DataTable DT_SampleHeader()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("SamplePrescriptionCode", typeof(string)));
                dt.Columns.Add(new DataColumn("SamplePrescriptionName", typeof(string)));
                dt.Columns.Add(new DataColumn("SamplePrescriptionDescription", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                var vlist = SamplePrescriptionHeader_DAL.ListAll();
                foreach (var v in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = v.SamplePrescriptionCode;
                    dr[1] = v.SamplePrescriptionName;
                    dr[2] = v.SamplePrescriptionDescription;
                    dr[3] = v.EmployeeCode;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
        
        public static List<SamplePrescriptionHeader_INF> ListAll()
        {
            return SamplePrescriptionHeader_DAL.ListAll();
        }
        public static Int32 Ins(SamplePrescriptionHeader_INF model)
        {
            return SamplePrescriptionHeader_DAL.Ins(model);
        }
        public static Int32 Del(string sSampleCode)
        {
            return SamplePrescriptionHeader_DAL.Del(sSampleCode);
        }

    }
}
