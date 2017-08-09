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
    public class PatientsSendSMSBLL
    {
        public static Int32 InsSendSMS(PatientsSendSMSInf info)
        {
            return PatientsSendSMSDAL.InsSendSMS(info);
        }
        public static DataTable TableGetPatientSendSMS(string fromDate, string toDate)
        {
            return PatientsSendSMSDAL.TableGetPatientSendSMS(fromDate, toDate);
        }
    }
}
