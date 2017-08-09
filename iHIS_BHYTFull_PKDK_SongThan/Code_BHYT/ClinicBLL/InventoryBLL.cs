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
    public class InventoryBLL
    {
        public static Int32 Ins_InventoryGeneral(InventoryGeneralInf info, string sRepositoryCodeExport, string sWarehousingCode)
        {
            return InventoryDal.Ins_InventoryGeneral(info, sRepositoryCodeExport, sWarehousingCode);
        }

        public static Int32 Del_InventoryGeneral(InventoryGeneralInf info, string sRepositoryCodeExport, string sWarehousingCode)
        {
            return InventoryDal.Del_InventoryGeneral(info, sRepositoryCodeExport, sWarehousingCode);
        }

        public static Int32 Upd_InventoryWareHousing(InventoryGeneralInf info, string sRepositoryCodeExport, string sWarehousingCode)
        {
            return InventoryDal.Upd_InventoryWareHousing(info, sRepositoryCodeExport, sWarehousingCode);
        }

        public static Int32 Ins_InventoryGumshoe(InventoryGumshoeInf infInven)
        {
            return InventoryDal.Ins_InventoryGumshoe(infInven);
        }

        public static decimal QuantityInvent(string sItemCode, ref decimal dAmountVirtual, string sRepositoryCode, ref decimal dAmountEnd)
        {
            return InventoryDal.QuantityInvent(sItemCode, ref dAmountVirtual, sRepositoryCode, ref dAmountEnd);
        }

        public static List<InventoryGumshoeInf> ListInventoryGumshoe(string itemCode, string repositoryCode, string sort, bool isGiaThuocDanhMuc)
        {
            return InventoryDal.ListInventoryGumshoe(itemCode, repositoryCode, sort, isGiaThuocDanhMuc);
        }
        public static List<InventoryGumshoeInf> ListInventoryGumshoe(string itemCode, string repositoryCode, string sort, string shipment)
        {
            return InventoryDal.ListInventoryGumshoe(itemCode, repositoryCode, sort, shipment);
        }

        public static DataTable TableTagWarehousing(string repositoryCode)
        {
            return InventoryDal.TableTagWarehousing(repositoryCode);
        }
        public static DataTable TableTagRepositoryGeneral(string repositoryCode, DateTime dateForm, DateTime dateTo, string itemCode)
        {
            return InventoryDal.TableTagRepositoryGeneral(repositoryCode, dateForm, dateTo, itemCode);
        }
        public static Int32 Del_GumshoeForHousingCode(string repositoryCode, string warehousingCode)
        {
            return InventoryDal.Del_GumshoeForHousingCode(repositoryCode, warehousingCode);
        }

        public static DataTable TableViewShipmentDateEnd()
        {
            return InventoryDal.TableViewShipmentDateEnd();
        }
        public static Int32 Upd_InventoryShipmentDateEnd(string itemCode, string shipment, DateTime dtimeEnd, string shipmentNew, DateTime dtimeEndNew)
        {
            return InventoryDal.Upd_InventoryShipmentDateEnd(itemCode, shipment, dtimeEnd, shipmentNew, dtimeEndNew);
        }
        public static Int32 Upd_WarehousingInven(string warehousingCode, decimal rowID, string repositoryCode, string itemCode, string unitOfMeasureCode, decimal quantity, decimal unitPrice, decimal bhytPrice, decimal amount, int tax, decimal scot, decimal totalTax, decimal salesPrice, string shipment, DateTime dtimeEnd)
        {
            return InventoryDal.Upd_WarehousingInven(warehousingCode, rowID, repositoryCode, itemCode, unitOfMeasureCode, quantity, unitPrice, bhytPrice, amount, tax, scot, totalTax, salesPrice, shipment, dtimeEnd);
        }
        public static DataTable TableShipmentForItem(string itemCode, string repositoryCode)
        {
            return InventoryDal.TableShipmentForItem(itemCode, repositoryCode);
        }
        public static Int32 InsInventoryLimited(InventoryLimitedInf limited)
        {
            return InventoryDal.InsInventoryLimited(limited);
        }
    }
}
