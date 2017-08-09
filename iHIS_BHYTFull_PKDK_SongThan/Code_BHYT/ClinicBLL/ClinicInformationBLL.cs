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
    public class ClinicInformationBLL
    {
        public static ClinicInformationInf ObjInformation(int iRowID)
        {
            return ClinicInformationDal.ObjInformation(iRowID);
        }
        public static Int32 Ins(ClinicInformationInf info)
        {
            return ClinicInformationDal.Ins(info);
        }
        public static DataTable DT_Information(int iRowID)
        {
            return ClinicInformationDal.DT_Information(iRowID);
        }
    }
}
