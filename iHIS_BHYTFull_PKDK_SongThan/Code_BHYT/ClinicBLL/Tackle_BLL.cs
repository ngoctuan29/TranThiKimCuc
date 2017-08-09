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
    public class Tackle_BLL
    {
        public static List<TackleInf> ListTackle()
        {
            return Tackle_DAL.ListTackle();
        }
    }
}
