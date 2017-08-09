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
    public class ReportBHYTBLL
    {
        public static int InsReportBHYT(ReportBHYTInf info, ref string reportID, DateTime dateEdit)
        {
            return ReportBHYTDal.InsReportBHYT(info, ref reportID, dateEdit);
        }

        public static int InsReportBHYTDetail(ReportBHYTDetailInf info)
        {
            return ReportBHYTDal.InsReportBHYTDetail(info);
        }

        public static Int32 DelReportBHYT(string reportID)
        {
            return ReportBHYTDal.DelReportBHYT(reportID);
        }

        public static Int32 DelReportBHYTDetail(string reportID)
        {
            return ReportBHYTDal.DelReportBHYTDetail(reportID);
        }

        public static Int32 UpdCancelReportBHYT(string reportID, string employeeCode)
        {
            return ReportBHYTDal.UpdCancelReportBHYT(reportID, employeeCode);
        }

        public static DataTable TableListReportBHYTFinish(string dateFrom, string dateTo, Int32 cancel)
        {
            return ReportBHYTDal.TableListReportBHYTFinish(dateFrom, dateTo, cancel);
        }
        public static DataTable TableListReportBHYTFinish(string dateFrom, string dateTo, Int32 cancel, string patientcode)
        {
            return ReportBHYTDal.TableListReportBHYTFinish(dateFrom, dateTo, cancel, patientcode);
        }
        public static DataTable TableReportBHYTFinish(string reportID)
        {
            return ReportBHYTDal.TableReportBHYTFinish(reportID);
        }
        public static DataTable TableReportBHYTFinishThuPhi(string reportID)
        {
            return ReportBHYTDal.TableReportBHYTFinishThuPhi(reportID);
        }
        public static DataTable TableReportBHYTFinishDetail(string reportID, int type)
        {
            return ReportBHYTDal.TableReportBHYTFinishDetail(reportID, type);
        }
        public static ReportBHYTInf ObjReportBHYTFinish(string reportID)
        {
            return ReportBHYTDal.ObjReportBHYTFinish(reportID); 
        }
        public static Int32 UpdSendFileReportBHYT(string reportID)
        {
            return ReportBHYTDal.UpdSendFileReportBHYT(reportID);
        }
        public static DataTable TableDMTTRV()
        {
            return ReportBHYTDal.TableDMTTRV();
        }

        public static DataTable TableKQDT()
        {
            return ReportBHYTDal.TableKQDT();
        }
    }
}
