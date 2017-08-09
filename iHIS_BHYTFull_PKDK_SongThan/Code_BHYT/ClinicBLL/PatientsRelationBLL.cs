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
    public class PatientsRelationBLL
    {
        public DataTable TableRelation(string patientCode)
        {
            PatientsRelationDal relation = new PatientsRelationDal();
            return relation.TableRelation(patientCode);
        }

        public bool DelPatientsRelation(decimal rowid)
        {
            PatientsRelationDal relation = new PatientsRelationDal();
            return relation.DelPatientsRelation(rowid);
        }

        public int InsPatientsRelation(PatientsRelationInf info)
        {
            PatientsRelationDal relation = new PatientsRelationDal();
            return relation.InsPatientsRelation(info);
        }

    }
}
