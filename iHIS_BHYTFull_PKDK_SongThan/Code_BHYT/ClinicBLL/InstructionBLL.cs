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
    public class InstructionBLL
    {
        public static DataTable DTInstruction(int iObjCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("InstructionName", typeof(string)));
                var vlist = InstructionDal.ListInstruction(iObjCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.InstructionName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<InstructionInf> ListInstruction(decimal dId)
        {
            return InstructionDal.ListInstruction(dId);
        }

        public static DataTable DataTableInstruction(decimal dId)
        {
            return InstructionDal.DataTableInstruction(dId);
        }

        public static int InsInstruction(InstructionInf info)
        {
            try
            {
                return InstructionDal.InsInstruction(info);
            }
            catch { return -2; }
        }

        public static int DelInstruction(decimal dId)
        {
            try
            {
                return InstructionDal.DelInstruction(dId);
            }
            catch { return -2; }
        }
    }
}
