using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;
using System.Configuration;
using System.Net.Sockets;

namespace ClinicDAL
{
    public class CatalogComputerDAL
    {
        public static CatalogComputerInf ObjComputer(string hddSerialNo)
        {
            ConnectDB cn = new ConnectDB();
            CatalogComputerInf computer = new CatalogComputerInf();
            try
            {
                string sql = " select ComputerName,VersionNo,MacAddress,HDDSerialNo,convert(date,IDate,103) IDate from CatalogComputer where HDDSerialNo='{0}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, hddSerialNo), null);
                if (ireader.Read())
                {
                    computer.ComputerName = ireader.GetValue(0).ToString();
                    computer.VersionNo = ireader.GetValue(1).ToString();
                    computer.MacAddress = ireader.GetValue(2).ToString();
                    computer.HDDSerialNo = ireader.GetValue(3).ToString();
                    computer.IDate = ireader.GetDateTime(4);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { computer = null; }
            return computer;
        }

        public static Int32 InsComputer(CatalogComputerInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ComputerName", SqlDbType.NVarChar, 200);
                param[0].Value = info.ComputerName;
                param[1] = new SqlParameter("@VersionNo", SqlDbType.VarChar, 20);
                param[1].Value = info.VersionNo;
                param[2] = new SqlParameter("@MacAddress", SqlDbType.VarChar, 20);
                param[2].Value = info.MacAddress;
                param[3] = new SqlParameter("@HDDSerialNo", SqlDbType.VarChar, 20);
                param[3].Value = info.HDDSerialNo;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proInsCatalogComputer", param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 UpdDateWorking(DateTime dtimeWorking, string hddserialNo)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update CatalogComputer set DateWorking=@DateWorking where HDDSerialNo=@HDDSerialNo";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DateWorking", SqlDbType.DateTime);
                param[0].Value = dtimeWorking;
                param[1] = new SqlParameter("@HDDSerialNo", SqlDbType.VarChar, 50);
                param[1].Value = hddserialNo;
                int iresult = cn.ExecuteNonQuery(CommandType.Text, query, param);
                if (iresult >= 1)
                    return 1;
                else if (iresult == -1)
                    return -1;
                else
                    return -2;

            }
            catch { return -2; }
        }
    }
}
