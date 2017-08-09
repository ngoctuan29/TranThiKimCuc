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
    public class ServicePriceBLL
    {
        public static DataTable DTServicePriceList(string sSvCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("ServiceCode", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("DateOfApplication", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Hide", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DisparityPrice", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("ServiceCategoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("SampleTransferPrice", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("DateOfApplicationEnd", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("PerDiscountIntro", typeof(Int32)));
                dt.Columns.Add(new DataColumn("DiscountIntro", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("PerDiscountDoctorDone", typeof(Int32)));
                dt.Columns.Add(new DataColumn("DiscountDoctorDone", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("PerDiscountDoctor", typeof(Int32)));
                dt.Columns.Add(new DataColumn("DiscountDoctor", typeof(Decimal)));
                
                var vlist = ServicePriceDal.ListServicePrice(sSvCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.Rowid;
                    dr[1] = lt1.ServiceCode;
                    dr[2] = lt1.UnitPrice;
                    dr[3] = lt1.DateOfApplication;
                    dr[4] = lt1.Hide;
                    dr[5] = lt1.ObjectCode;
                    dr[6] = lt1.EmployeeCode;
                    dr[7] = lt1.DisparityPrice;
                    dr[8] = lt1.ServiceCategoryName;
                    dr[9] = lt1.SampleTransferPrice;
                    dr[10] = lt1.DateOfApplicationEnd;
                    dr[11] = lt1.PerDiscountIntro;
                    dr[12] = lt1.DiscountIntro;
                    dr[13] = lt1.PerDiscountDoctorDone;
                    dr[14] = lt1.DiscountDoctorDone;
                    dr[15] = lt1.PerDiscountDoctor;
                    dr[16] = lt1.DiscountDoctor;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static ServicePriceInf ObjServicePriceReal(string sServiceCode, Int32 iObjectCode)
        {
            return ServicePriceDal.ObjServicePriceReal(sServiceCode, iObjectCode);
        }
        public static List<ServicePriceInf> ListServicePrice(string sSvCode)
        {
            return ServicePriceDal.ListServicePrice(sSvCode);
        }
        public static List<ServicePriceInf> ListServicePriceReal(string sSvCode, Int32 iObject)
        {
            return ServicePriceDal.ListServicePriceReal(sSvCode, iObject);
        }

        public static List<ServicePriceInf> ListServicePriceReal(string serviceCode)
        {
            return ServicePriceDal.ListServicePriceReal(serviceCode);
        }

        public static int InsServicePrice(ServicePriceInf info)
        {
            return ServicePriceDal.InsServicePrice(info);
        }

        public static int DelServicePrice(decimal dRowID)
        {
            return ServicePriceDal.DelServicePrice(dRowID);
        }

        public static DataTable DTListPrice_MapService(decimal dRowid)
        {
            return ServicePriceDal.DTListPrice_MapService(dRowid);
        }

        public static DataTable DTListPrice_MapService(decimal dRowid, Int32 iObject, Int32 iPatientType, string serviceGroupCode, string serviceCategoryCode)
        {
            return ServicePriceDal.DTListPrice_MapService(dRowid, iObject, iPatientType, serviceGroupCode, serviceCategoryCode);
        }

        public static List<ServicePricePrintInf> ListPrintMapService()
        {
            return ServicePriceDal.ListPrintMapService();
        }

        public static DataTable TableObjectForService(string serviceCode)
        {
            return ServicePriceDal.TableObjectForService(serviceCode);
        }
    }
}
