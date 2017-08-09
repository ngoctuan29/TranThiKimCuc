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
    public class rpt_Medicines_BLL
    {
        public static DataTable DT_View_XNT_General(string refRepositoryCode, string dtFrom, string dtTo, string itemCode)
        {
            return rpt_Medicines_DAL.DT_View_XNT_General(refRepositoryCode, dtFrom, dtTo, itemCode);
        }
        public static DataTable DT_View_XNT_GeneralDetail(string refRepositoryCode, string dtFrom, string dtTo, string itemCode)
        {
            return rpt_Medicines_DAL.DT_View_XNT_GeneralDetail(refRepositoryCode, dtFrom, dtTo, itemCode);
        }
        public static DataTable DT_View_DateEnd(string refRepositoryCode)
        {
            return rpt_Medicines_DAL.DT_View_DateEnd(refRepositoryCode);
        }
        
        public static DataTable DT_View_TKeBanThuoc(string sFrom, string sTo, Int32 iPaid)
        {
            return rpt_Medicines_DAL.DT_View_TKeBanThuoc(sFrom, sTo, iPaid);
        }
        public static DataTable DT_View_TKeBanThuocTH(string sFrom, string sTo, Int32 iPaid)
        {
            return rpt_Medicines_DAL.DT_View_TKeBanThuocTH(sFrom, sTo, iPaid);
        }
        public static DataTable DT_View_TKeBanThuocTHMonth(string sFrom, string sTo, Int32 iPaid)
        {
            return rpt_Medicines_DAL.DT_View_TKeBanThuocTHMonth(sFrom, sTo, iPaid);
        }
        
        public static DataTable DT_Exp_MedicinesForPatients(string sRepositoryCode, string sfrom, string sto, string sItemCode)
        {
            return rpt_Medicines_DAL.DT_Exp_MedicinesForPatients(sRepositoryCode, sfrom, sto, sItemCode);
        }

        public static DataTable DT_View_RealMedicinesTH(string sRepositoryCode, DateTime dtfrDate, DateTime dttoDate)
        {
            DataTable dtResult = new DataTable();
            DataTable dtTemp01 = new DataTable();
            DataTable dtTemp02 = new DataTable();

            dtResult.Columns.Add("Mã Thuốc", typeof(string));
            dtResult.Columns.Add("Tên Thuốc", typeof(string));
            dtResult.Columns.Add("Tổng", typeof(decimal));
            Int32 iCount = 2;
            try
            {
                dtTemp01 = PatientReceiveBLL.DT_View_PatientReceive(dtfrDate, dttoDate, 2, "F");
                dtTemp02 = rpt_Medicines_DAL.DT_View_RealMedicinesTH(sRepositoryCode, dtfrDate, dttoDate);
                if (dtTemp01.Rows.Count > 0 && dtTemp02.Rows.Count > 0)
                {
                    string sColName = string.Empty;
                    bool bCheckExist = false;
                    foreach (DataRow r2 in dtTemp02.Rows)
                    {
                        dtResult.Rows.Add(r2["ItemCode"].ToString(), r2["ItemName"].ToString(), r2["TotalQuantity"].ToString());
                    }
                    foreach (DataRow r1 in dtTemp01.Rows)
                    {
                        bCheckExist = false;
                        sColName = string.Empty;
                        iCount++;
                        foreach (DataColumn column in dtResult.Columns)
                        {
                            sColName = column.ColumnName.ToString();
                            if (column.ColumnName.ToString() == r1["PatientName"].ToString())
                            {
                                sColName = r1["PatientName"].ToString() + "_01";
                                bCheckExist = true;
                                break;
                            }
                        }
                        if (bCheckExist)
                            dtResult.Columns.Add(sColName, typeof(string));
                        else
                            dtResult.Columns.Add(r1["PatientName"].ToString(), typeof(string));
                        foreach (DataRow r in dtResult.Rows)
                        {
                            r[iCount] = rpt_Medicines_DAL.View_RealMedicinesDetail(r1["PatientCode"].ToString(), Convert.ToDecimal(r1["PatientReceiveID"].ToString()), r["Mã Thuốc"].ToString());
                        }
                    }
                }
            }
            catch { }
            return dtResult;
        }

        public static DataTable DT_View_RealMedicinesDetail(string sRepositoryCode, DateTime dtfrDate, DateTime dttoDate)
        {
            return rpt_Medicines_DAL.DT_View_RealMedicinesDetail(sRepositoryCode, dtfrDate, dttoDate);
        }

        public static List<view_DoctorAppointedInf> View_BSChiDinh(string sEmployeeCode, string sFrom, string sTo, string sDepartmentCode, string sDepartmentCodeOrder, string sServiceCategoryCode, string sServiceGroupCode, Int32 iPatientType, string sServiceCode, int iStatus, Int32 iPaid, string employeeCodeReport)
        {
            return rpt_Medicines_DAL.View_BSChiDinh(sEmployeeCode, sFrom, sTo, sDepartmentCode, sDepartmentCodeOrder, sServiceCategoryCode, sServiceGroupCode, iPatientType, sServiceCode, iStatus, iPaid, employeeCodeReport);
        }
        public static DataTable TableViewInputWarehousing(string repositoryCode, DateTime dateFrom, DateTime dateTo, Int32 import)
        {
            return rpt_Medicines_DAL.TableViewInputWarehousing(repositoryCode, dateFrom, dateTo, import);
        }

        public static List<view_DoctorAppointedInf> View_ChiDinhKCB(string sFrom, string sTo, string sServiceGroupCode, Int32 iStatus)
        {
            return rpt_Medicines_DAL.View_ChiDinhKCB(sFrom, sTo, sServiceGroupCode, iStatus);
        }
    }
}
