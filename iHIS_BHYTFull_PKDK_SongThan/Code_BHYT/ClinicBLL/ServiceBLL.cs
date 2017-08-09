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
    public class ServiceBLL
    {

        public static DataTable DTServiceFull()
        {
            return ServiceDal.DTServiceFull();
        }

        public static List<ServiceInf> ListService(string sGroup, string sCate, int hide)
        {
            return ServiceDal.ListService(sGroup, sCate, hide);
        }
        public static List<ServiceInf> rptListService(string sGroup, string sCateCode)
        {
            return ServiceDal.rptListService(sGroup, sCateCode);
        }
        public static DataTable DTServiceRealNotGroup()
        {
            return ServiceDal.DTServiceRealNotGroup();
        }
        public static List<ServiceInf> ListServiceReal(string sGroup, string sCate)
        {
            return ServiceDal.ListServiceReal(sGroup, sCate);
        }

        public static int InsService(ServiceInf info)
        {
            return ServiceDal.InsService(info);
        }

        public static int DelService(string sSvCode)
        {
            return ServiceDal.DelService(sSvCode);
        }
        public static DataTable DTServiceReal()
        {
            return ServiceDal.DTServiceReal();
        }

        public static List<ServiceFullNameInf> ListServiceRealFullName()
        {
            return ServiceDal.ListServiceRealFullName();
        }

        public static List<ServiceLimitInf> ListServiceLimitAll()
        {
            return ServiceDal.ListServiceLimitAll();
        }

        public static DataTable TableServiceLimitForEmployee(string employeeCode)
        {
            return ServiceDal.TableServiceLimitForEmployee(employeeCode);
        }

        public static Int32 InsServiceLimit(ServiceLimitInf info)
        {
            return ServiceDal.InsServiceLimit(info);
        }

        public static Int32 DelServiceLimit(string employeeCode, string serviceCode)
        {
            return ServiceDal.DelServiceLimit(employeeCode, serviceCode);
        }

        public static Int32 DelServiceLimitAll(string employeeCode)
        {
            return ServiceDal.DelServiceLimitAll(employeeCode);
        }
        public static DataTable DTServiceRealNotGroupForBHYT()
        {
            return ServiceDal.DTServiceRealNotGroupForBHYT();
        }
        public static List<Service_Item_AttachInf> ListViewServiceItemAttach(string serviceCode)
        {
            return ServiceDal.ListViewServiceItemAttach(serviceCode);
        }
        public static Int32 InsServiceItemAttach(Service_Item_AttachInf info)
        {
            return ServiceDal.InsServiceItemAttach(info);
        }
        public static Int32 DelServiceItemAttachAll(string servicecode, string itemcode)
        {
            return ServiceDal.DelServiceItemAttachAll(servicecode, itemcode);
        }
        public static Int32 DelServiceItemAttachAll(string servicecode)
        {
            return ServiceDal.DelServiceItemAttachAll(servicecode);
        }
        public static Int32 UpdServiceItemAttach(bool attach_Items, string serviceCode)
        {
            return ServiceDal.UpdServiceItemAttach(attach_Items, serviceCode);
        }
    }
}
