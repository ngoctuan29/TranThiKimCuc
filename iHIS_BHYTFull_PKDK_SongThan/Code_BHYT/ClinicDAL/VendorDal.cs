using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;


namespace ClinicDAL
{
    public class VendorDal
    {
        public static List<VendorInf> ListVendor(string sVerCode)
        {
            ConnectDB cn = new ConnectDB();
            List<VendorInf> list = new List<VendorInf>();
            try
            {
                string sql = "";
                if (sVerCode != "")
                {
                    sql = " select RowID,VendorCode,VendorName,Salesman,Address,Phone,Email,Status,VendorTaxNo,VendorFax,VendorBankName from Vendor where VendorCode in('{0}') order by Rowid asc ";
                }
                else
                {
                    sql = " select RowID,VendorCode,VendorName,Salesman,Address,Phone,Email,Status,VendorTaxNo,VendorFax,VendorBankName from Vendor order by Rowid asc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sVerCode), null);
                while (ireader.Read())
                {
                    VendorInf inf = new VendorInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.VendorCode = ireader.GetString(1);
                    inf.VendorName = ireader.GetValue(2).ToString();
                    inf.Salesman = ireader.GetValue(3).ToString();
                    inf.Address = ireader.GetValue(4).ToString();
                    inf.Phone = ireader.GetValue(5).ToString();
                    inf.Email = ireader.GetValue(6).ToString();
                    inf.Status = ireader.GetInt32(7);
                    inf.VendorTaxNo = ireader.GetValue(8).ToString();
                    inf.VendorFax = ireader.GetValue(9).ToString();
                    inf.VendorBankName = ireader.GetValue(10).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { list = null; }
            return list;
        }

        public static Int32 InsVendor(VendorInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@VendorCode", SqlDbType.VarChar,50);
                param[0].Value = info.VendorCode;
                param[1] = new SqlParameter("@VendorName", SqlDbType.NVarChar, 50);
                param[1].Value = info.VendorName;
                param[2] = new SqlParameter("@Salesman", SqlDbType.NVarChar);
                param[2].Value = info.Salesman;
                param[3] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[3].Value = info.Address;
                param[4] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[4].Value = info.Phone;
                param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[5].Value = info.Email;
                param[6] = new SqlParameter("@Status", SqlDbType.Int);
                param[6].Value = info.Status;
                param[7] = new SqlParameter("@VendorTaxNo", SqlDbType.NVarChar);
                param[7].Value = info.VendorTaxNo;
                param[8] = new SqlParameter("@VendorFax", SqlDbType.NVarChar);
                param[8].Value = info.VendorFax;
                param[9] = new SqlParameter("@VendorBankName", SqlDbType.NVarChar);
                param[9].Value = info.VendorBankName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Vendor", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelVendor(string sVerCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@VendorCode", SqlDbType.VarChar, 50);
                param[1].Value = sVerCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Vendor", param);
            }
            catch { return -1; }
        }

    }
}
