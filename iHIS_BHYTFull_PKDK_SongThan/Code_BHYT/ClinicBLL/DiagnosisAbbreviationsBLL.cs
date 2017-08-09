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
    public class DiagnosisAbbreviationsBLL
    {
        public static DataTable TableAbbreviations(string employeeCode)
        {
            DiagnosisAbbreviationsDal abb = new DiagnosisAbbreviationsDal();
            return abb.TableAbbreviations(employeeCode);
        }

        public static List<DiagnosisAbbreviationsInf> ListAbbForUser(string employeeCode)
        {
            DiagnosisAbbreviationsDal abb = new DiagnosisAbbreviationsDal();
            return abb.ListAbbForUser(employeeCode);
        }

        public static List<DiagnosisAbbreviationsInf> ListAbb(string employeeCode)
        {
            DiagnosisAbbreviationsDal abb = new DiagnosisAbbreviationsDal();
            return abb.ListAbb(employeeCode);
        }

        public static int Ins(DiagnosisAbbreviationsInf info)
        {
            DiagnosisAbbreviationsDal abb = new DiagnosisAbbreviationsDal();
            return abb.Ins(info);
        }

        public static int Del(Int32 dRowid)
        {
            DiagnosisAbbreviationsDal abb = new DiagnosisAbbreviationsDal();
            return abb.Del(dRowid);
        }
    }
}
