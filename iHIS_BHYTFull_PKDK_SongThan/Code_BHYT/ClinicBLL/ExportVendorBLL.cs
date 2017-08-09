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
    public class ExportVendorBLL
    {
        public static Int32 Ins(ExportVendorInf info, ref string refCode)
        {
            return ExportVendorDal.Ins(info, ref refCode);
        }

        public static Int32 InsDetail(ExportVendorDetailInf info, string sRepositoryExportCode)
        {
            return ExportVendorDal.InsDetail(info, sRepositoryExportCode);
        }

        public static Int32 Del(string sExpCode)
        {
            return ExportVendorDal.Del(sExpCode);
        }

        public static Int32 Deltail(string sExpCode)
        {
            return ExportVendorDal.Deltail(sExpCode);
        }

        public static List<ExportVendor_View> ListForDate(string sfrom, string sto)
        {
            return ExportVendorDal. ListForDate(sfrom, sto);
        }

        public static DataTable DT_ListDetailExport(string sRepositoryCode, string sExpCode)
        {
            return ExportVendorDal.DT_ListDetailExport(sRepositoryCode, sExpCode);
        }

        public static DataTable rpt_PrintExportVendor(string sExpCode)
        {
            return ExportVendorDal.rpt_PrintExportVendor(sExpCode);
        }

        public static DataTable rpt_PrintExportVendorDetail(string sExpCode)
        {
            return ExportVendorDal.rpt_PrintExportVendorDetail(sExpCode);
        }

    }
}
