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
    public class MedicalPatternBLL
    {
        public DataTable TablePattern(int rowid)
        {
            MedicalPatternDAL pattern = new MedicalPatternDAL();
            return pattern.TablePattern(rowid);
        }
        public List<MedicalPatternInf> ListPattern(string serviceCode)
        {
            MedicalPatternDAL pattern = new MedicalPatternDAL();
            return pattern.ListPattern(serviceCode);
        }
        public MedicalPatternInf ObjPattern(int rowid)
        {
            MedicalPatternDAL pattern = new MedicalPatternDAL();
            return pattern.ObjPattern(rowid);
        }
        public Int32 InsPattern(MedicalPatternInf info)
        {
            MedicalPatternDAL pattern = new MedicalPatternDAL();
            return pattern.InsPattern(info);
        }
        public Int32 DelPattern(int rowid, string employeeCode)
        {
            MedicalPatternDAL pattern = new MedicalPatternDAL();
            return pattern.DelPattern(rowid, employeeCode);
        }
    }
}
