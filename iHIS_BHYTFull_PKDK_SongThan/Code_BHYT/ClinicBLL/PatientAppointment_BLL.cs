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
    public class PatientAppointment_BLL
    {
        public static PatientAppointment_INF ObjAppointment(decimal dReceiveID)
        {
            return PatientAppointment_DAL.ObjAppointment(dReceiveID);
        }
        public static Int32 Ins(PatientAppointment_INF info)
        {
            return PatientAppointment_DAL.Ins(info);
        }

        public static Int32 InsRegister(PatientAppointmentFullInf info, ref DateTime dtimeOld, ref string sHour)
        {
            return PatientAppointment_DAL.InsRegister(info, ref dtimeOld, ref sHour);
        }

        public static Int32 Del(string sPatientCode, decimal dReceiveID)
        {
            return PatientAppointment_DAL.Del(sPatientCode, dReceiveID);
        }
        public static Int32 Del(string sPatientCode, DateTime dtAppoint)
        {
            return PatientAppointment_DAL.Del(sPatientCode, dtAppoint);
        }
        public static DataTable DTListAppointmentSearch(string sPatientCode, string sFullname, string sAge, string sMobile, string sFrom, string sTo)
        {
            return PatientAppointment_DAL.DTListAppointmentSearch(sPatientCode, sFullname, sAge, sMobile, sFrom, sTo);
        }

        public static PatientAppointment_INF ObjAppointment(string sPatientCode, string sDate)
        {
            return PatientAppointment_DAL.ObjAppointment(sPatientCode, sDate);
        }

        public static Int32 UpdStatus(string sPatientCode, string sDate)
        {
            return PatientAppointment_DAL.UpdStatus(sPatientCode, sDate);
        }
        public static DataTable hsba_Appointment(string sPatientCode, decimal dReceiveID)
        {
            return PatientAppointment_DAL.hsba_Appointment(sPatientCode, dReceiveID);
        }
        
    }
}
