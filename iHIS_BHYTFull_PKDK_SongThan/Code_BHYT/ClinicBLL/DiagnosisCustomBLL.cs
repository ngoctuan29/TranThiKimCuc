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
    public class DiagnosisCustomBLL
    {
        public static DataTable TableDiagnosisCustom(Int32 rowid)
        {
            return DiagnosisCustomDAL.TableDiagnosisCustom(rowid);
        }

        public static Int32 Ins(Int32 rowid, string diagnosisName, string employeeCode)
        {
            return DiagnosisCustomDAL.Ins(rowid, diagnosisName, employeeCode);
        }

        public static Int32 Del(Int32 rowid)
        {
            return DiagnosisCustomDAL.Del(rowid);
        }
    }
}
