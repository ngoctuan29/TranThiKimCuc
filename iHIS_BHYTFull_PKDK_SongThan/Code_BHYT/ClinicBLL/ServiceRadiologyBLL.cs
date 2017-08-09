using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicLibrary;
using ClinicModel;
using System.Data;
using ClinicDAL;
namespace ClinicBLL
{
    public class ServiceRadiologyBLL
    {
        public static Int32 InsRadiologyEntry(ServiceRadiologyEntryInf info, ref decimal refID, string serviceGroupCode)
        {
            return ServiceRadiologyDal.InsRadiologyEntry(info, ref refID, serviceGroupCode);
        }
        public static Int32 InsRadiologyDetailEntry(ServiceRadiologyDetailEntryInf info, Int32 iStatus)
        {
            return ServiceRadiologyDal.InsRadiologyDetailEntry(info, iStatus);
        }
        public static Int32 UpdRadiologyDetailEntry(ServiceRadiologyDetailEntryInf info)
        {
            return ServiceRadiologyDal.UpdRadiologyDetailEntry(info);
        }
        public static Int32 DelRadiologyDetailEntry(decimal dRadiologyRowID)
        {
            return ServiceRadiologyDal.DelRadiologyDetailEntry(dRadiologyRowID);
        }
        public static Int32 DelRadiologyDetailEntry(decimal dRadiologyRowID, decimal dRowID)
        {
            return ServiceRadiologyDal.DelRadiologyDetailEntry(dRadiologyRowID, dRowID);
        }
        public static Int32 DelRadiologyEntry(decimal dSuggestedID, ref Int32 refID)
        {
            return ServiceRadiologyDal.DelRadiologyEntry(dSuggestedID, ref refID);
        }
        public static List<ViewPreviousInf> ListPrevious(string sPatientCode, int iMenu)
        {
            return ServiceRadiologyDal.ListPrevious(sPatientCode, iMenu);
        }
        public static List<ViewPreviousInf> ListPreviousPTT(string sPatientCode, int iMenu)
        {
            return ServiceRadiologyDal.ListPreviousPTT(sPatientCode, iMenu);
        }
        public static ServiceRadiologyEntryInf ObjRadiologyEntry(decimal dRowID)
        {
            return ServiceRadiologyDal.ObjRadiologyEntry(dRowID);
        }
        public static List<ServiceRadiologyDetailEntryInf> ListRadiologyDetail(decimal dRadiology)
        {
            return ServiceRadiologyDal.ListRadiologyDetail(dRadiology);
        }
        public static ServiceRadiologyEntryInf ObjRadiologyEntryForSuggestedID(decimal suggestedID)
        {
            return ServiceRadiologyDal.ObjRadiologyEntryForSuggestedID(suggestedID);
        }
        public static DataTable DT_ResultRadiology(decimal dSuggestedID, decimal patientReceiveID)
        {
            return ServiceRadiologyDal.DT_ResultRadiology(dSuggestedID, patientReceiveID);
        }
        public static List<ServiceRadiologyDetailEntryInf> ListRadiologyDetailForReceiptID(decimal dReceipt)
        {
            return ServiceRadiologyDal.ListRadiologyDetailForReceiptID(dReceipt);
        }

        public static DataTable hsba_RadiologyEntry(decimal dReceiveID, string sPatientCode)
        {
            return ServiceRadiologyDal.hsba_RadiologyEntry(dReceiveID, sPatientCode);
        }
        public static DataTable hsba_RadiologyEntrydetail(decimal dReceiveID, string sPatientCode)
        {
            return ServiceRadiologyDal.hsba_RadiologyEntrydetail(dReceiveID, sPatientCode);
        }
    }
}
