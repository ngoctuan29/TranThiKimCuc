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
    public class ServiceGroupDal
    {

        public static DataTable DTListServiceGroup(string sgroup)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                if (sgroup != "")
                {
                    sql = "select rowid,servicegroupcode,servicegroupname,ServiceModuleCode from ServiceGroup where servicegroupcode='{0}' order by rowid desc";
                }
                else
                {
                    sql = "select rowid,servicegroupcode,servicegroupname,ServiceModuleCode from ServiceGroup order by rowid desc";
                }
                dt = cn.ExecuteQuery(string.Format(sql, sgroup));
                
            }
            catch 
            {
                //sError = cn.sconnection;
                dt = null;
            }
            return dt;
        }

        public static List<ServiceGroupInf> ListServiceGroup(string groupCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceGroupInf> list = new List<ServiceGroupInf>();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(groupCode))
                {
                    sql = "select rowid,servicegroupcode,servicegroupname,ServiceModuleCode,STT,GroupID_BHYT from ServiceGroup where servicegroupcode='{0}' order by stt asc";
                }
                else
                {
                    sql = "select rowid,servicegroupcode,servicegroupname,ServiceModuleCode,STT,GroupID_BHYT from ServiceGroup order by stt asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, groupCode), null);
                while (ireader.Read())
                {
                    ServiceGroupInf inf = new ServiceGroupInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceGroupCode = ireader.GetString(1);
                    inf.ServiceGroupName = ireader.GetString(2);
                    inf.ServiceModuleCode = ireader.GetValue(3).ToString();
                    inf.STT = ireader.GetInt32(4);
                    inf.GroupID_BHYT = ireader.GetInt32(5);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch {
                //sError = cn.sconnection;
                list = null; }
            return list;
        }

        public static int InsServiceGroup(ServiceGroupInf info, Boolean bIns)
        {
            ConnectDB cn = new ConnectDB();
            string sqlinsert = " insert into ServiceGroup(servicegroupcode,servicegroupname,ServiceModuleCode,STT,GroupID_BHYT) values(@servicegroupcode,@servicegroupname,@ServiceModuleCode,@STT,@GroupID_BHYT) ";
            string sqlupd = " update ServiceGroup set servicegroupname=@servicegroupname,ServiceModuleCode=@ServiceModuleCode,STT=@STT,GroupID_BHYT=@GroupID_BHYT where servicegroupcode=@servicegroupcode";
            try
            {
                if (bIns)
                {
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@servicegroupcode", SqlDbType.VarChar);
                    param[0].Value = info.ServiceGroupCode;
                    param[1] = new SqlParameter("@servicegroupname", SqlDbType.NVarChar);
                    param[1].Value = info.ServiceGroupName;
                    param[2] = new SqlParameter("@ServiceModuleCode", SqlDbType.NVarChar);
                    param[2].Value = info.ServiceModuleCode;
                    param[3] = new SqlParameter("@STT", SqlDbType.Int);
                    param[3].Value = info.STT;
                    param[4] = new SqlParameter("@GroupID_BHYT", SqlDbType.Int);
                    param[4].Value = info.GroupID_BHYT;
                    if (cn.ExecuteNonQuery(CommandType.Text, sqlinsert, param) == 1)
                    {
                        return 1;
                    }
                    else
                        return 0;
                }
                else
                {
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@servicegroupcode", SqlDbType.VarChar);
                    param[0].Value = info.ServiceGroupCode;
                    param[1] = new SqlParameter("@servicegroupname", SqlDbType.NVarChar);
                    param[1].Value = info.ServiceGroupName;
                    param[2] = new SqlParameter("@ServiceModuleCode", SqlDbType.NVarChar);
                    param[2].Value = info.ServiceModuleCode;
                    param[3] = new SqlParameter("@STT", SqlDbType.Int);
                    param[3].Value = info.STT;
                    param[4] = new SqlParameter("@GroupID_BHYT", SqlDbType.Int);
                    param[4].Value = info.GroupID_BHYT;
                    if (cn.ExecuteNonQuery(CommandType.Text, sqlupd, param) == 1)
                    {
                        return 1;
                    }
                    else
                        return 0;
                }
            }
            catch { return -1; }
        }

        public static int DelServiceGroup(string sServiceGroupCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 50);
                param[1].Value = sServiceGroupCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_ServiceGroup", param);
            }
            catch { return -1; }
        }

    }
}
