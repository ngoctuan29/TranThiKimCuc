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
    public class ObjectDal
    {
        public static DataTable DTObjectList(int iObjCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                table.Columns.Add(new DataColumn("ObjectName", typeof(string)));
                table.Columns.Add(new DataColumn("ObjectCard", typeof(Int32)));
                string sql = string.Empty;
                if (iObjCode != 0)
                {
                    sql = "select ObjectCode,ObjectName,ObjectCard from Object where ObjectCode in({0}) order by ObjectCode asc";
                }
                else
                {
                    sql = "select ObjectCode,ObjectName,ObjectCard from Object order by ObjectCode asc";
                }
                table = cn.ExecuteQuery(string.Format(sql, iObjCode));
            }
            catch {}
            return table;
        }

        public static DataTable DTObjectListNotIn(int iObjCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectName", typeof(string)));
                dt.Columns.Add(new DataColumn("ObjectCard", typeof(Int32)));
                string sql = string.Empty;
                sql = "select ObjectCode,ObjectName,ObjectCard from Object where ObjectCode not in({0}) order by ObjectCode asc";
                dt = cn.ExecuteQuery(string.Format(sql, iObjCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static List<ObjectInf> ListObject(int iObjCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ObjectInf> list = new List<ObjectInf>();
            try
            {
                string sql = string.Empty;
                if (iObjCode != 0)
                {
                    sql = "select ObjectCode,ObjectName,ObjectCard from Object where ObjectCode in({0}) order by ObjectCode asc";
                }
                else
                {
                    sql = "select ObjectCode,ObjectName,ObjectCard from Object order by ObjectCode asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iObjCode), null);
                while (ireader.Read())
                {
                    ObjectInf inf = new ObjectInf();
                    inf.ObjectCode = ireader.GetInt32(0);
                    inf.ObjectName = ireader.GetString(1);
                    inf.ObjectCard = ireader.GetInt32(2);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }

        public static Int32 InsObject(ObjectInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[0].Value = info.ObjectCode;
                param[1] = new SqlParameter("@ObjectName", SqlDbType.NVarChar, 250);
                param[1].Value = info.ObjectName;
                param[2] = new SqlParameter("@ObjectCard", SqlDbType.Int);
                param[2].Value = info.ObjectCard;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Object", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelObject(Int32 iObjCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[1].Value = iObjCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Object", param);
            }
            catch { return -1; }
        }


        public static Int32 Del(int sRowID, int sReceiveID, string sPatientCode, string sServiceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = sRowID;
                param[2] = new SqlParameter("@ReceiveID", SqlDbType.Int);
                param[2].Value = sReceiveID;
                param[3] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[3].Value = sPatientCode;
                param[4] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[4].Value = sServiceCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "prDel_PhieuThuTien", param);
            }
            catch { return -1; }
        }

        public static Int32 DelThuoc(int sRowID2, string sMedicalRecordCode, string sItemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = sRowID2;
                param[2] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar);
                param[2].Value = sMedicalRecordCode;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[3].Value = sItemCode;
                int status = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "prDel_Thuoc", param));
                return status;
            }
            catch (Exception ex) { return -1; }
        }

        public static List<ObjectInf> GetObject()
        {
            ConnectDB cn = new ConnectDB();
            List<ObjectInf> list = new List<ObjectInf>();
            try
            {
                string sql = string.Empty;
                sql = "select objectCode, objectName from object where ObjectCode=5";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql), null);
                while (ireader.Read())
                {
                    ObjectInf obj = new ObjectInf();
                    obj.ObjectCode = ireader.GetInt32(0);
                    obj.ObjectName = ireader.GetValue(1).ToString();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            { return null; }
            return list;
        }
    }
}
