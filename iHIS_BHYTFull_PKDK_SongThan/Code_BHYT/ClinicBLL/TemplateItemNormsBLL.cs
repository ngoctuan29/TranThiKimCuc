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
    public class TemplateItemNormsBLL
    {
        public static List<TemplateItemNormsInf> ListItemNorms(string sCode)
        {
            return TemplateItemNormsDal.ListItemNorms(sCode);
        }
        //public static Int32 Ins(TemplateItemNormsInf info, ref string refsCode)
        //{
        //    return TemplateItemNormsDal.Ins(info, ref refsCode);
        //}
        public static Int32 Ins(TemplateItemNormsInf info)
        {
            return TemplateItemNormsDal.Ins(info);
        }
        public static Int32 Del(string sCode)
        {
            return TemplateItemNormsDal.Del(sCode);
        }
        public static DataTable dtItemNormsDetail(string sCode)
        {
            return TemplateItemNormsDal.dtItemNormsDetail(sCode);
        }
        public static Int32 InsDetail(TemplateItemNormsDetailInf info)
        {
            return TemplateItemNormsDal.InsDetail(info);
        }
        public static Int32 DelDetail(string sCode, decimal dRowID)
        {
            return TemplateItemNormsDal.DelDetail(sCode, dRowID);
        }
        public static TemplateItemNormsInf ObjItemNormsForService(string serviceCode)
        {
            return TemplateItemNormsDal.ObjItemNormsForService(serviceCode);
        }
    }
}
