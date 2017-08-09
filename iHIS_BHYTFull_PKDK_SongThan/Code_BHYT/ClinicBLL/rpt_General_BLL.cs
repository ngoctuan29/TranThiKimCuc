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
    public class rpt_General_BLL
    {
        public static DataTable DT_Get_KetQuaDieuTri(string dtFrom, string dtTo, string sDepartment, int iType)
        {
            return rpt_General_DAL.DT_Get_KetQuaDieuTri(dtFrom, dtTo, sDepartment, iType);
        }

        public static List<view_SurviveSignInf> List_DauHieuSinhTon(DateTime dtFrom, DateTime dtTo, string sDepartment)
        {
            DataTable dtTemp = new DataTable();
            List<view_SurviveSignInf> lst = new List<view_SurviveSignInf>();
            try
            {
                string sResultS = string.Empty;
                string sResultC = string.Empty;
                dtTemp = rpt_General_DAL.DT_DauHieuSinhTon(dtFrom, dtTo, sDepartment);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        DataTable dtResult = new DataTable();
                        dtResult = rpt_General_DAL.DT_DauHieuSinhTonForPatient(Utils.StringToDate(dr["CreateDate"].ToString()), dr["PatientCode"].ToString());
                        sResultS = string.Empty;
                        sResultC = string.Empty;
                        foreach (DataRow r in dtResult.Rows)
                        {
                            if (r["Time"].ToString() == "S")
                                sResultS += "M: " + r["Pulse"].ToString() + " - N.Đ: " + r["Temperature"].ToString() + " - H.A: " + r["BloodPressure"].ToString() + "/" + r["BloodPressure1"].ToString() + " - Th: " + r["Breath"].ToString() + "\n";
                            else if (r["Time"].ToString() == "C")
                                sResultC += "M: " + r["Pulse"].ToString() + " - N.Đ: " + r["Temperature"].ToString() + " - H.A: " + r["BloodPressure"].ToString() + "/" + r["BloodPressure1"].ToString() + " - Th: " + r["Breath"].ToString() + "\n";
                        }
                        view_SurviveSignInf inf = new view_SurviveSignInf();
                        inf.PatientCode = dr["PatientCode"].ToString();
                        inf.PatientName = dr["PatientName"].ToString();
                        inf.CreateDate = Utils.StringToDate(dr["CreateDate"].ToString());
                        inf.ResultS = sResultS;
                        inf.ResultC = sResultC;
                        lst.Add(inf);
                    }
                }
            }
            catch { }
            return lst;
        }

        public static DataTable TableViewListMedical(string dtFrom, string dtTo, Int32 type)
        {
            return rpt_General_DAL.TableViewListMedical(dtFrom, dtTo, type);
        }

        public static DataTable TableTotalSuggested(string serviceGroupCode, string tungay, string denngay, int receive)
        {
            return rpt_General_DAL.TableTotalSuggested(serviceGroupCode, tungay, denngay, receive);
        }

        public static DataTable TableTotalSuggestedForDoctor(DateTime fromDate, DateTime toDate, string serviceCategoryCode, string employeeCodeDoctor, Int32 paid, string serviceGroupCode, Int32 done)
        {
            return rpt_General_DAL.TableTotalSuggestedForDoctor(fromDate, toDate, serviceCategoryCode, employeeCodeDoctor, paid, serviceGroupCode, done);
        }
        public static DataTable TableCountReceive()
        {
            return rpt_General_DAL.TableCountReceive();
        }
        public static DataTable TableTotalSuggestedForDoctorForDoing(string fromDate, string toDate, string serviceCategoryCode, string employeeCodeDoctor, Int32 paid, string serviceGroupCode, Int32 done, string Service)
        {
            return rpt_General_DAL.TableTotalSuggestedForDoctorDoing(fromDate, toDate, serviceCategoryCode, employeeCodeDoctor, paid, serviceGroupCode, done, Service);
        }
        public static DataTable TableChiTietBenhNhanDV(string fromDate, string toDate, string PatientCode, int PatientReceiveID)
        {
            return rpt_General_DAL.TableChiTietBenhNhanDV(fromDate, toDate, PatientCode, PatientReceiveID);
        }
        public static DataTable TableChiTietBenhNhanTH(string fromDate, string toDate, string PatientCode, int PatientReceiveID)
        {
            return rpt_General_DAL.TableChiTietBenhNhanTH(fromDate, toDate, PatientCode, PatientReceiveID);
        }
        public static DataTable XuatBM79a(string dtFrom, string dtTo)
        {
            return rpt_General_DAL.XuatBM79a(dtFrom, dtTo);
        }
        public static DataTable XuatBM80a(string dtFrom, string dtTo)
        {
            return rpt_General_DAL.XuatBM80a(dtFrom, dtTo);
        }
        public static DataTable XuatBCTE(string dtFrom, string dtTo)
        {
            return rpt_General_DAL.XuatBCTE(dtFrom, dtTo);
        }
        public static DataTable Xuat21(string dtFrom, string dtTo)
        {
            return rpt_General_DAL.Xuat21(dtFrom, dtTo);
        }
        public static DataTable Xuat20(string dtFrom, string dtTo)
        {
            return rpt_General_DAL.Xuat20(dtFrom, dtTo);
        }
        public static DataTable Xuat19(string dtFrom, string dtTo)
        {
            return rpt_General_DAL.Xuat19(dtFrom, dtTo);
        }
        public static DataTable WriteXML1_9324(string dtFrom, string dtTo, string reportID)
        {
            return rpt_General_DAL.WriteXML1_9324(dtFrom, dtTo,reportID);
        }
        public static DataTable WriteXML2_9324(string dtFrom, string dtTo, string reportID)
        {
            return rpt_General_DAL.WriteXML2_9324(dtFrom, dtTo,reportID);
        }
        public static DataTable WriteXML3_9324(string dtFrom, string dtTo, string reportID)
        {
            return rpt_General_DAL.WriteXML3_9324(dtFrom, dtTo,reportID);
        }
        public static DataTable TableTHTC(DateTime tungay, DateTime denngay)
        {
            return rpt_General_DAL.TableTHTC(tungay, denngay);
        }
        public static DataTable TableTiemVaccin(DateTime tungay, DateTime denngay)
        {
            return rpt_General_DAL.TableTiemVaccin(tungay, denngay);
        }
        public static DataTable TableHDKCB(DateTime tungay, DateTime denngay)
        {
            return rpt_General_DAL.TableHDKCB(tungay, denngay);
        }
        public static DataTable TableTNTT(DateTime tungay, DateTime denngay)
        {
            return rpt_General_DAL.TableTNTT(tungay, denngay);
        }
        public static DataTable TableBM_6_YTTN(DateTime tungay, DateTime denngay)
        {
            return rpt_General_DAL.TableBM_6_YTTN(tungay, denngay);
        }
        public static DataTable TableDiscountForIntroName(DateTime fromDate, DateTime toDate, string serviceCategoryCode, string employeeCode, string serviceGroupCode, string introName, string typeReport)
        {
            return rpt_General_DAL.TableDiscountForIntroName(fromDate, toDate, serviceCategoryCode, employeeCode, serviceGroupCode, introName, typeReport);
        }
        public static DataTable TableDiscountForDoctor(DateTime fromDate, DateTime toDate, string serviceCategoryCode, string employeeCode, string serviceGroupCode, string employeeCodeDoctor, string typeReport)
        {
            return rpt_General_DAL.TableDiscountForDoctor(fromDate, toDate, serviceCategoryCode, employeeCode, serviceGroupCode, employeeCodeDoctor, typeReport);
        }
    }
}
