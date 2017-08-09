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
    public class UnitOfMeasureBLL
    {
        public static DataTable DTUnit(string unitOfMeasureCode, string type)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                var vlist = UnitOfMeasureDal.ListUnit(unitOfMeasureCode, type);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.UnitOfMeasureCode;
                    dr[1] = lt1.UnitOfMeasureName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<UnitOfMeasureInf> ListUnit(string unitOfMeasureCode, string type)
        {
            return UnitOfMeasureDal.ListUnit(unitOfMeasureCode, type);
        }

        public static int InsUnit(UnitOfMeasureInf info)
        {
            return UnitOfMeasureDal.InsUnit(info);
        }

        public static int DelUnit(string sCode)
        {
            return UnitOfMeasureDal.DelUnit(sCode);
        }

    }
}
