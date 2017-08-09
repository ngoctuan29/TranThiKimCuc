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
    public class PatientsRelationMenuBLL
    {
        public DataTable TableRelationMenu()
        {
            PatientsRelationMenuDAL relation = new PatientsRelationMenuDAL();
            return relation.TableRelationMenu();
        }

        public bool DelPatientsRelationMenu(int rowid)
        {
            PatientsRelationMenuDAL relation = new PatientsRelationMenuDAL();
            return relation.DelPatientsRelationMenu(rowid);
        }

        public int InsPatientsRelationMenu(PatientsRelationMenuInf info)
        {
            PatientsRelationMenuDAL relation = new PatientsRelationMenuDAL();
            return relation.InsPatientsRelationMenu(info);
        }
    }
}
