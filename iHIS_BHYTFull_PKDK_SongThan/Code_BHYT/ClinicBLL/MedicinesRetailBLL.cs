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
    public class MedicinesRetailBLL
    {
        public static DataTable DT_MedicinesRetailDetail(string sRetailCode)
        {
            return MedicinesRetailDAL.DT_MedicinesRetailDetail(sRetailCode);
        }

        public static Int32 Ins(MedicinesRetailInf info, ref string refRetailCode)
        {
            return MedicinesRetailDAL.Ins(info, ref refRetailCode);
        }
        public static Int32 UpdMedicinesRetailInfo(MedicinesRetailInf info)
        {
            return MedicinesRetailDAL.UpdMedicinesRetailInfo(info);
        }
        public static Int32 UpdStatus(Int32 iPaid, string sRetailCode)
        {
            return MedicinesRetailDAL.UpdStatus(iPaid, sRetailCode);
        }

        public static Int32 InsDetail(MedicinesRetailDetailInf info)
        {
            return MedicinesRetailDAL.InsDetail(info);
        }

        public static Int32 DelDetail(string sRetailCode, string sItemCode)
        {
            return MedicinesRetailDAL.DelDetail(sRetailCode, sItemCode);
        }

        public static Int32 DelDetail(string sRetailCode)
        {
            return MedicinesRetailDAL.DelDetail(sRetailCode);
        }

        public static Int32 DelAll(string sRetailCode)
        {
            return MedicinesRetailDAL.DelAll(sRetailCode);
        }

        public static Int32 InsDetailSub(MedicinesRetailDetailInf info)
        {
            return MedicinesRetailDAL.InsDetailSub(info);
        }

        public static DataTable DT_ListRetail(string sfr, string sto, bool isCancel, bool isDone)
        {
            return MedicinesRetailDAL.DT_ListRetail(sfr, sto, isCancel, isDone);
        }

        public static Int32 UpdAmountRealRetail(string retailCode)
        {
            return MedicinesRetailDAL.UpdAmountRealRetail(retailCode);
        }

        public static MedicinesRetailInf ObjRetail(string sRetailCode)
        {
            return MedicinesRetailDAL.ObjRetail(sRetailCode);
        }

        public static List<MedicinesRetailDetailInf> ListRetailDetail(string sRetailCode)
        {
            return MedicinesRetailDAL.ListRetailDetail(sRetailCode);
        }

        public static DataTable rpt_MedicinesRetail(string retailCode, int paid)
        {
            return MedicinesRetailDAL.rpt_MedicinesRetail(retailCode, paid);
        }

        public static DataTable rpt_MedicinesRetailDetail(string sRetailCode)
        {
            return MedicinesRetailDAL.rpt_MedicinesRetailDetail(sRetailCode);
        }

        public static Int32 Del_AfterInvoiceNumber(string sRetailCode, string sEmployee, string reason)
        {
            return MedicinesRetailDAL.Del_AfterInvoiceNumber(sRetailCode, sEmployee, reason);
        }
        public static DataTable DT_Exp_RetailForPatients(string sRepositoryCode, string sfrom, string sto, string sItemCode, int cancel)
        {
            return MedicinesRetailDAL.DT_Exp_RetailForPatients(sRepositoryCode, sfrom, sto, sItemCode, cancel);
        }
        public static DataTable DT_MedicinesRetail(string sPatientCode, decimal dPatientReceiveID, Int32 iPaid, string sBanksAccountCode)
        {
            return MedicinesRetailDAL.DT_MedicinesRetail(sPatientCode, dPatientReceiveID, iPaid, sBanksAccountCode);
        }
        public static Int32 UpdPaidMedicines(Int32 iPaid, string sPatientCode, decimal dPatientReceiveID, string sBanksAccountCode)
        {
            return MedicinesRetailDAL.UpdPaidMedicines(iPaid, sPatientCode, dPatientReceiveID, sBanksAccountCode);
        }
        public static DataTable TableResultMedicinesRetailGroupForDoctor(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            return MedicinesRetailDAL.TableResultMedicinesRetailGroupForDoctor(sPatientCode, sFromdate, sTodate, sItemCode, employeeCode);
        }
        public static DataTable TableResultMedicinesRetail(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            return MedicinesRetailDAL.TableResultMedicinesRetail(sPatientCode, sFromdate, sTodate, sItemCode, employeeCode);
        }
        public static Int32 UpdVAT_InvoiceNumber(string retailCode, string invoiceNumber, int vat)
        {
            return MedicinesRetailDAL.UpdVAT_InvoiceNumber(retailCode, invoiceNumber, vat);
        }
    }
}
