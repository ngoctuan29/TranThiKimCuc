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
    public class BHYTParametersBLL
    {
        public static BHYTParametersInf ObjParameters(int iRowid)
        {
            return BHYTParametersDal.ObjParameters(iRowid);
        }

        public static DataTable DT_ListParameters(int iRowid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(int)));
                dt.Columns.Add(new DataColumn("BHYTUnderPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTOnPrice", typeof(decimal)));
                var vlist = BHYTParametersDal.ObjParameters(iRowid);
                DataRow dr;
                dr = dt.NewRow();
                dr.BeginEdit();
                dr[0] = vlist.RowID;
                dr[1] = vlist.BHYTUnderPrice;
                dr[2] = vlist.BHYTOnPrice;
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            catch  { dt = null; }
            return dt;
        }

        public static int Ins(BHYTParametersInf info)
        {
            return BHYTParametersDal.Ins(info);
        }
    }
}
