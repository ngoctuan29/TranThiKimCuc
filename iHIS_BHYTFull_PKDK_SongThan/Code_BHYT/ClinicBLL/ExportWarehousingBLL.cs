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
    public class ExportWarehousingBLL
    {
        public static Int32 Ins(ExportWarehousingInf info, ref string refCode)
        {
            return ExportWarehousingDAL.Ins(info, ref refCode);
        }
        public static Int32 InsDetail(ExportWarehousingDetailInf info)
        {
            return ExportWarehousingDAL.InsDetail(info);
        }
        public static List<ExportWarehousing_View> ListForDate(string sfrom, string sto, Int32 iType, string employeeCode)
        {
            return ExportWarehousingDAL.ListForDate(sfrom, sto, iType, employeeCode);
        }
        public static Int32 Del(string sExpCode)
        {
            return ExportWarehousingDAL.Del(sExpCode);
        }
        public static DataTable rpt_PrintWarehousingExport(string sExpCode)
        {
            return ExportWarehousingDAL.rpt_PrintWarehousingExport(sExpCode);
        }
        public static DataTable rpt_PrintWarehousingExportDetail(string sExpCode)
        {
            return ExportWarehousingDAL.rpt_PrintWarehousingExportDetail(sExpCode);
        }
        public static Int32 CheckEdit(string sExpCode)
        {
            return ExportWarehousingDAL.CheckEdit(sExpCode);
        }
    }
}
