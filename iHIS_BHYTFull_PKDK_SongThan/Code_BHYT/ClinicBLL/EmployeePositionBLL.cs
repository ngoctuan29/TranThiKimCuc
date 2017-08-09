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
    public class EmployeePositionBLL
    {
        public static DataTable DTEmployeePosition(Int32 iPositionCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("PositionCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("PositionName", typeof(string)));
                var vlist = EmployeePositionDal.ListEmployeePosition(iPositionCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.PositionCode;
                    dr[1] = lt1.PositionName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }               
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<EmployeePositionInf> ListEmployeePosition(Int32 iPositionCode)
        {
            List<EmployeePositionInf> list = new List<EmployeePositionInf>();
            try
            {
                list = EmployeePositionDal.ListEmployeePosition(iPositionCode);
            }
            catch { list = null; }
            return list;
        }

        public static int InsEmployeePosition(EmployeePositionInf info, bool bCheck)
        {
            try
            {
                return EmployeePositionDal.InsEmployeePosition(info, bCheck);
            }
            catch { return -2; }
        }

        public static int DelEmployeePosition(string sPositionCode)
        {
            try
            {
                return EmployeePositionDal.DelEmployeePosition(sPositionCode);
            }
            catch { return -2; }
        }

    }
}
