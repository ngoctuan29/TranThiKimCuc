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
    public class SystemParameterBLL
    {
        public static List<SystemParameterInf> ListParameter(string sModule)
        {
            return SystemParameterDal.ListParameter(sModule);
        }
        public static Int32 Ins(Int32 iRowID, string sModule, string sName, Int32 iValues, string sDescription, string sEmployeeCode, string versionNo)
        {
            return SystemParameterDal.Ins(iRowID, sModule, sName, iValues, sDescription, sEmployeeCode, versionNo);
        }
        public static SystemParameterInf ObjParameter(decimal dRowID)
        {
            return SystemParameterDal.ObjParameter(dRowID);
        }
    }
}
