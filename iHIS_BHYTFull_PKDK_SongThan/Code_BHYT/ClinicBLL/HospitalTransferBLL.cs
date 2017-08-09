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
    public class HospitalTransferBLL
    {
        public static bool InsTransfer(HospitalTransferINF info)
        {
            return HospitalTransferDAL.InsTransfer(info);
        }
        public static DataTable DTPrintTrransfer(decimal patientReceiveID)
        {
            return HospitalTransferDAL.DTPrintTrransfer(patientReceiveID);
        }
        public static Int32 DelTransfer(decimal patientReceiveID)
        {
            return HospitalTransferDAL.DelTransfer(patientReceiveID);
        }
        public static HospitalTransferINF ObjTransfer(decimal patientReceiveID)
        {
            return HospitalTransferDAL.ObjTransfer(patientReceiveID);
        }
        public static DataTable TableTransfer(string dtimeFrom, string dtimeTo)
        {
            return HospitalTransferDAL.TableTransfer(dtimeFrom, dtimeTo);
        }
        public static DataTable DSTransfer(string datefr, string dateto)
        {
            return HospitalTransferDAL.DSTransfer(datefr, dateto);
        }
    }
}
