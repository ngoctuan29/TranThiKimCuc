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
    public class iLABGetResultBLL
    {
        public static DataTable TableResult_iLab(string dateWorking, string resultCode, string machineCode)
        {
            return iLABGetResultDAL.TableResult_iLab(dateWorking, resultCode, machineCode);
        }
    }
}
