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
    public class SamplePrescriptionLine_BLL
    {
        public static DataTable DT_SampleLine(string ref_HCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("SamplePrescriptionCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitOfMeasure", typeof(string)));
                dt.Columns.Add(new DataColumn("Morning", typeof(float)));
                dt.Columns.Add(new DataColumn("Noon", typeof(float)));
                dt.Columns.Add(new DataColumn("Afternoon", typeof(float)));
                dt.Columns.Add(new DataColumn("Evening", typeof(float)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(float)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
                dt.Columns.Add(new DataColumn("Converted_Medi", typeof(Boolean)));
                var vlist = SamplePrescriptionLine_DAL.ListForHederCode(ref_HCode);
                foreach (var v in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = v.RowID;
                    dr[1] = v.SamplePrescriptionCode;
                    dr[2] = v.ItemCode;
                    dr[3] = v.UnitOfMeasure;
                    dr[4] = v.Morning;
                    dr[5] = v.Noon;
                    dr[6] = v.Afternoon;
                    dr[7] = v.Evening;
                    dr[8] = v.Quantity;
                    dr[9] = v.Instruction;
                    dr[10] = v.DateOfIssues;
                    dr[11] = v.UnitOfMeasureCode_Medi;
                    dr[12] = v.Converted_Medi;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<SamplePrescriptionLine_INF> ListForHederCode(string ref_HCode)
        {
            return SamplePrescriptionLine_DAL.ListForHederCode(ref_HCode);
        }
        public static List<SamplePrescriptionLine_INF> ListForHederCode_Price(string ref_HCode)
        {
            return SamplePrescriptionLine_DAL.ListForHederCode_Price(ref_HCode);
        }
        public static Int32 Ins(SamplePrescriptionLine_INF model)
        {
            return SamplePrescriptionLine_DAL.Ins(model);
        }

        public static Int32 Del(decimal dRowid)
        {
            return SamplePrescriptionLine_DAL.Del(dRowid);
        }
        public static Int32 Del(string samplePrescriptionCode, string itemCode)
        {
            return SamplePrescriptionLine_DAL.Del(samplePrescriptionCode, itemCode);
        }
    }
}
