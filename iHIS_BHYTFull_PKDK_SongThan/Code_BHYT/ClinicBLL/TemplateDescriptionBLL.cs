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
    public class TemplateDescriptionBLL
    {
        public static TemplateDescriptionInf ObjTemplate(string sCode)
        {
            return TemplateDescriptionDal.ObjTemplate(sCode);
        }
        public static Int32 Ins(TemplateDescriptionInf info, ref string resultCode)
        {
            return TemplateDescriptionDal.Ins(info, ref resultCode);
        }
        public static Int32 Del(string sCode)
        {
            return TemplateDescriptionDal.Del(sCode);
        }
        public static DataTable DT_ListTemplate(string headerCode)
        {
            return TemplateDescriptionDal.DT_ListTemplate(headerCode);
        }
        public static DataTable DT_ListTemplateForMenuID(int serviceMenuID)
        {
            return TemplateDescriptionDal.DT_ListTemplateForMenuID(serviceMenuID);
        }
        public static DataTable TableListTemplateForService(string serviceCode, string employeeDoctorCode)
        {
            return TemplateDescriptionDal.TableListTemplateForService(serviceCode, employeeDoctorCode);
        }
    }
}
