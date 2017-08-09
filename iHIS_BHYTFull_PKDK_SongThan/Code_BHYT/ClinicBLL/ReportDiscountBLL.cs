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
    public class ReportDiscountBLL
    {
        public static DataTable GetPatientReceiveForIntroName(string dateFrom, string dateTo, string introName, string serviceGroupCode, bool confirmdiscountIntro)
        {
            return ReportDiscountDal.GetPatientReceiveForIntroName(dateFrom, dateTo, introName, serviceGroupCode, confirmdiscountIntro);
        }

        public static DataTable GetSuggestedServiceForIntroNameDetail(string dateFrom, string dateTo, string introName, string serviceGroup, int statusConfirm)
        {
            return ReportDiscountDal.GetSuggestedServiceForIntroNameDetail(dateFrom, dateTo, introName, serviceGroup, statusConfirm);
        }

        public static DataTable GetPatientReceiveForDoctor(string dateFrom, string dateTo, string employeeCode, string serviceGroupCode, string type)
        {
            return ReportDiscountDal.GetPatientReceiveForDoctor(dateFrom, dateTo, employeeCode, serviceGroupCode, type);
        }

        public static DataTable GetPatientReceiveForDoctorPointed(string dateFrom, string dateTo, string employeeCode, string serviceGroup)
        {
            return ReportDiscountDal.GetPatientReceiveForDoctorPointed(dateFrom, dateTo, employeeCode, serviceGroup);
        }

        public static DataTable GetSuggestedServiceForDoctorDetail(string dateFrom, string dateTo, string employeeCode, string serviceGroupCode, string type)
        {
            return ReportDiscountDal.GetSuggestedServiceForDoctorDetail(dateFrom, dateTo, employeeCode, serviceGroupCode, type);
        }

        public static DataTable GetSuggestedServiceForDoctorPointed(string dateFrom, string dateTo, string employeeCode, string serviceGroup)
        {
            return ReportDiscountDal.GetSuggestedServiceForDoctorPointed(dateFrom, dateTo, employeeCode, serviceGroup);
        }

        public static Int32 IUReportDiscount(ReportDiscountInf info, int status)
        {
            return ReportDiscountDal.IUReportDiscount(info, status);
        }
    }
}
