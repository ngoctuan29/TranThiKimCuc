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
    public class Rpt_VuDieuTriBLL
    {
        public static DataTable TableBM05Template()
        {
            return Rpt_VuDieuTriDAL.TableBM05Template();
        }
        public static DataTable TableBM05Default()
        {
            return Rpt_VuDieuTriDAL.TableBM05Default();
        }
        public static DataTable TableBM05Default(decimal rowID_BM05)
        {
            return Rpt_VuDieuTriDAL.TableBM05Default(rowID_BM05);
        }
        public static Int32 InsBM05(BM05_YTTN_TemplateInf info)
        {
            return Rpt_VuDieuTriDAL.InsBM05(info);
        }
        public static Int32 InsBC_BM05(BM05_YTTNInf info, ref decimal result)
        {
            return Rpt_VuDieuTriDAL.InsBC_BM05(info, ref result);
        }
        public static DataTable TableBM05()
        {
            return Rpt_VuDieuTriDAL.TableBM05();
        }
        public static Int32 InsBC_BM05Detail(BM05_YTTNDetailInf info)
        {
            return Rpt_VuDieuTriDAL.InsBC_BM05Detail(info);
        }
        public static Int32 DelBM05(int rowIDTemplate)
        {
            return Rpt_VuDieuTriDAL.DelBM05(rowIDTemplate);
        }
        public static DataTable TableViewBM05(decimal rowID_BM05)
        {
            return Rpt_VuDieuTriDAL.TableViewBM05(rowID_BM05);
        }
        public static DataTable TableViewTotalSuggested(DateTime dtfrom, DateTime dtto, string serviceCode)
        {
            return Rpt_VuDieuTriDAL.TableViewTotalSuggested(dtfrom, dtto, serviceCode);
        }
        public static DataTable TableBM_6_YTTN(DateTime tungay, DateTime denngay)
        {
            return Rpt_VuDieuTriDAL.TableBM_6_YTTN(tungay, denngay);
        }
        public static DataTable SoKhamThai(string dateFrom, string dateTo)
        {
            return Rpt_VuDieuTriDAL.SoKhamThai(dateFrom, dateTo);
        }
        public static DataTable SoDe(string dtFrom, string dtTo)
        {
            return Rpt_VuDieuTriDAL.SoDe(dtFrom, dtTo);
        }
        public static DataTable SoPhaThai(string dtFrom, string dtTo)
        {
            return Rpt_VuDieuTriDAL.SoPhaThai(dtFrom, dtTo);
        }
    }
}
