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
    public class MedicalReasonBLL
    {
        public static List<MedicalReasonINF> ListReason()
        {
            return MedicalReasonDAL.ListReason();
        }
    }
}
