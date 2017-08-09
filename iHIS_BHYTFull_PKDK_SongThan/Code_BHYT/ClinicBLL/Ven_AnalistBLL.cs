using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClinicModel;
using ClinicLibrary;
using ClinicDAL;

namespace ClinicBLL
{
    public class Ven_AnalistBLL
    {
        public static DataTable DataVen()
        {
            return Ven_AnalistDAL.DataVen();
        }
        #region Code Tuan
        public static DataTable GetThongKeABC(string ven, string venCode)
        {
            return Ven_AnalistDAL.GetThongKeABC(ven, venCode);
        }
        public static DataTable GetThongKeABCVEN2Time(string venCode1, string venCode2)
        {
            return Ven_AnalistDAL.GetThongKeABCVEN2Time(venCode1, venCode2);
        }
       public static DataTable GetThongKeABCTheoATC(string venCode)
        {
            return Ven_AnalistDAL.GetThongKeABCTheoATC(venCode);
        }
        public static DataTable GetThongKeABCTheoATC_TyLe(string venCode)
        {
            return Ven_AnalistDAL.GetThongKeABCTheoATC_TyLe(venCode);
        }
        public static DataTable GetThongKeABCVENTheoThuocNoiNgoai(string venCode)
        {
            return Ven_AnalistDAL.GetThongKeABCVENTheoThuocNoiNgoai(venCode);
        }
        #endregion Code Tuan
        #region Code vinh
        public static DataTable GetDMPhieu()
        {
            return Ven_AnalistDAL.GetDMPhieu();
        }
        
        public static DataTable GetDMPhieuForID(int IdVEN)
        {
            return Ven_AnalistDAL.GetDMPhieuForID(IdVEN);
        }
        #endregion

        #region Code vinh Chi So
        public static DataTable GetChiSoHieuQua(string venCode1, string venCode2)
        {
            return Ven_AnalistDAL.GetChiSoHieuQua(venCode1, venCode2);
        }
        #endregion
        public static DataTable ThongKeABCVENTheoThoiGian(string venCode)
        {
            return Ven_AnalistDAL.ThongKeABCVENTheoThoiGian(venCode);
        }

        public static DataTable GetABCVENTheoThoiGian2Time(string venCode1, string venCode2)
        {
            return Ven_AnalistDAL.GetABCVENTheoThoiGian2Time(venCode1, venCode2);
        }

        public static DataTable GetViewInventory(string venCode)
        {
            return Ven_AnalistDAL.GetViewInventory(venCode);
        }

        public static String Ins_VENABC_Analist(string venCode, string fromDate, string toDate, string employeeCode)
        {
            return Ven_AnalistDAL.Ins_VENABC_Analist(venCode, fromDate, toDate, employeeCode);
        }

        public static int Ins_VENABC_AnalistDetail(string venABC_Code, string itemName, string unitOfMeasureName, string active, string bietDuoc, string generic, string venCode, string countryName, string atcCode, decimal quantity, decimal unitPriceVAT)
        {
            return Ven_AnalistDAL.Ins_VENABC_AnalistDetail(venABC_Code, itemName, unitOfMeasureName, active, bietDuoc, generic, venCode, countryName, atcCode, quantity, unitPriceVAT);
        }
        public static int Delete_VENABC_Analist(string venCode)
        {
            return Ven_AnalistDAL.Delete_VENABC_Analist(venCode);
        }

        public static DataTable GetListVENABC_Analist()
        {
            return Ven_AnalistDAL.GetListVENABC_Analist();
        }

        public static DataTable GetVENABC_AnalistByVENcode(string venCode)
        {
            return Ven_AnalistDAL.GetVENABC_AnalistByVENcode(venCode);
        }
        
    }
}
