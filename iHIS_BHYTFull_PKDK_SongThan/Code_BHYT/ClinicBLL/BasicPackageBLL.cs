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
    public class BasicPackageBLL
    {
        public static DataTable TableItemsRef()
        {
            return BasicPackageDAL.TableItemsRef();
        }
        public static DataTable TableMedicalRecord(string medicalCode)
        {
            return BasicPackageDAL.TableMedicalRecord(medicalCode);
        }
        public static DataTable TableGetResultMedicalDetail(string medicalCode)
        {
            return BasicPackageDAL.TableGetResultMedicalDetail(medicalCode);
        }
    }
}
