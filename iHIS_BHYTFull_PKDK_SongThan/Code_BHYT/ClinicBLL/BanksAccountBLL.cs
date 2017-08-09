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
    public class BanksAccountBLL
    {
        public static List<Model_BanksAccountFinish> ListWaitingFinsh(string sMaBN, string sHoTen, string sTuoi, string sfrom, string sto)
        {
            return BanksAccountDal.ListWaitingFinsh(sMaBN, sHoTen, sTuoi, sfrom, sto);
        }
        
        public static bool InsBanksAccount(BanksAccountInf info, ref string refMsgError)
        {
            return BanksAccountDal.InsBanksAccount(info, ref refMsgError);
        }

        public static Int32 DelBanksAccount(string banksCode, string patientCode, decimal receiveID, string shiftWork, string employeeCode, string reason)
        {
            return BanksAccountDal.DelBanksAccount(banksCode, patientCode, receiveID, shiftWork, employeeCode, reason);
        }

        public static DataTable DT_StatisticBankTotal(string fromDate, string toDate, string serviceGroupCode, string serviceCategoryCode, string serviceCode)
        {
            DataTable tableResult = new DataTable();
            tableResult.Columns.Add("PostingDate", typeof(DateTime));
            tableResult.Columns.Add("PostingTime",typeof(TimeSpan));
            tableResult.Columns.Add("PatientCode", typeof(string));
            tableResult.Columns.Add("PatientName", typeof(string));
            tableResult.Columns.Add("PatientBirthyear", typeof(Int32)).DefaultValue = 0;
            tableResult.Columns.Add("TotalMedical", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalDrug", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalRad", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalLab", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalPTTT", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalTC", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalAll", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalVC", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalGIUONG", typeof(decimal)).DefaultValue = 0;
            tableResult.Columns.Add("TotalNHAKHOA", typeof(decimal)).DefaultValue = 0;
            try
            {
                DataTable tableTemp = BanksAccountDal.TableStatisticBankTotal(fromDate, toDate, serviceGroupCode, serviceCategoryCode, serviceCode);
                if (tableTemp != null && tableTemp.Rows.Count > 0)
                {
                    foreach (DataRow row in tableTemp.Rows)
                    {
                        DataRow r = Utils.GetPriceRowbyCode(tableResult, "PatientCode='" + row["PatientCode"].ToString() + "'");
                        if (r == null)
                        {
                            DataRow addRow = tableResult.NewRow();
                            addRow["PostingDate"] = row["PostingDate"];
                            addRow["PostingTime"] = row["PostingTime"];
                            addRow["PatientCode"] = row["PatientCode"];
                            addRow["PatientName"] = row["PatientName"];
                            addRow["PatientBirthyear"] = row["PatientBirthyear"];
                            if (row["ServiceModuleCode"].ToString() == "KCB")
                                addRow["TotalAll"] = addRow["TotalMedical"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "THUOC")
                                addRow["TotalAll"] = addRow["TotalDrug"] = Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "CDHA")
                                addRow["TotalAll"] = addRow["TotalRad"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "XN")
                                addRow["TotalAll"] = addRow["TotalLab"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "PTTT")
                                addRow["TotalAll"] = addRow["TotalPTTT"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "TC")
                                addRow["TotalAll"] = addRow["TotalTC"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "VC")
                                addRow["TotalAll"] = addRow["TotalVC"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "GIUONG")
                                addRow["TotalAll"] = addRow["TotalGIUONG"] = row["Amount"];
                            if (row["ServiceModuleCode"].ToString() == "NHAKHOA")
                                addRow["TotalAll"] = addRow["TotalNHAKHOA"] = row["Amount"];
                            tableResult.Rows.Add(addRow);
                        }
                        else
                        {
                            if (row["ServiceModuleCode"].ToString() == "KCB")
                                r["TotalMedical"] = Convert.ToDecimal(r["TotalMedical"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "THUOC")
                                r["TotalDrug"] = Convert.ToDecimal(r["TotalDrug"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "CDHA")
                                r["TotalRad"] = Convert.ToDecimal(r["TotalRad"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "XN")
                                r["TotalLab"] = Convert.ToDecimal(r["TotalLab"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "PTTT")
                                r["TotalPTTT"] = Convert.ToDecimal(r["TotalPTTT"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "TC")
                                r["TotalTC"] = Convert.ToDecimal(r["TotalTC"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "VC")
                                r["TotalVC"] = Convert.ToDecimal(r["TotalVC"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "GIUONG")
                                r["TotalGIUONG"] = Convert.ToDecimal(r["TotalGIUONG"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            if (row["ServiceModuleCode"].ToString() == "NHAKHOA")
                                r["TotalNHAKHOA"] = Convert.ToDecimal(r["TotalNHAKHOA"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                            r["TotalAll"] = Convert.ToDecimal(r["TotalAll"].ToString()) + Convert.ToDecimal(row["Amount"].ToString());
                        }
                    }
                }
                //thuốc bán lẻ
                //DataTable tableRetailTemp = MedicinesRetailDAL.TableReportListRetail(fromDate, toDate);
                //if (tableRetailTemp != null && tableRetailTemp.Rows.Count > 0)
                //{
                //    foreach (DataRow row in tableRetailTemp.Rows)
                //    {
                //        DataRow addRow = tableResult.NewRow();
                //        addRow["PostingDate"] = row["ExportDate"];
                //        addRow["PatientCode"] = row["RetailCode"];
                //        addRow["PatientName"] = row["FullName"];
                //        addRow["PatientBirthyear"] = row["Birthyear"];
                //        addRow["TotalAll"] = addRow["TotalDrug"] = Convert.ToDecimal(row["Amount"].ToString());
                //        tableResult.Rows.Add(addRow);
                //    }
                //}
            }
            catch { }
            return tableResult;
        }
       
        public static DataTable TableStatisticBankDetail(string dtfrom, string dtto, string group, string category, string employeeCode, string introName)
        {
            return BanksAccountDal.TableStatisticBankDetail(dtfrom, dtto, group, category, employeeCode, introName);
        }
        public static DataTable TableWaitingForDate(string sfrom, string sto)
        {
            return BanksAccountDal.TableWaitingForDate(sfrom, sto);
        }
        public static DataTable TableWaitingForDateBV01(string fromDate, string toDate, int confirmBV01, int objectCode)
        {
            return BanksAccountDal.TableWaitingForDateBV01(fromDate, toDate, confirmBV01, objectCode);
        }
        
        public static bool IsUpdateBanksAccountHideReport(string banksAccountCode)
        {
            return BanksAccountDal.IsUpdateBanksAccountHideReport(banksAccountCode);
        }
        public static bool IsUpdateBanksAccountUnhideReport(string banksAccountCode)
        {
            return BanksAccountDal.IsUpdateBanksAccountUnhideReport(banksAccountCode);
        }
        public static DataTable GetDataBanksAccountDetailHis(string banksAccountCode, int loai)
        {
            return BanksAccountDal.GetDataBanksAccountDetailHis(banksAccountCode, loai);
        }
        public static BanksAccountInf ListBankAccountForCode(string banksAccountCode)
        {
            return BanksAccountDal.ListBankAccountForCode(banksAccountCode);
        } 
        
        public static Int32 UpdBanksAccountInvoice(BanksAccountInvoiceInf inf)
        {
            return BanksAccountDal.UpdBanksAccountInvoice(inf);
        }
        
        public static DataTable TableWaitingForDateBN(string sfrom, string sto)
        {
            return BanksAccountDal.TableWaitingForDateBN(sfrom, sto);
        }
        public static Int32 UpdBanksAccountPrinter(string banksAccountCode)
        {
            return BanksAccountDal.UpdBanksAccountPrinter(banksAccountCode);
        }
        public static BanksAccountInvoiceInf ObjBanksAccountInvoice(decimal patientReceiveID, string patientCode, string noinvoice)
        {
            return BanksAccountDal.ObjBanksAccountInvoice(patientReceiveID, patientCode, noinvoice);
        }
    }
}
