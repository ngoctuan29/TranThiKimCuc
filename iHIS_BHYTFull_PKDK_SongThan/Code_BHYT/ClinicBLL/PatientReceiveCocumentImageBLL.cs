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
    public class PatientReceiveCocumentImageBLL
    {
        public static List<PatientReceiveCocumentImageInf> List(decimal refReceiveID, string refPatientCode)
        {
            return PatientReceiveCocumentImageDAL.List(refReceiveID, refPatientCode);
        }
        public static Int32 Ins(PatientReceiveCocumentImageInf info)
        {
            return PatientReceiveCocumentImageDAL.Ins(info);
        }
        public static DataTable hsba_DocumentImage(decimal dReceiveID, string sPatientCode)
        {
            return PatientReceiveCocumentImageDAL.hsba_DocumentImage(dReceiveID, sPatientCode);
        }
    }
}
