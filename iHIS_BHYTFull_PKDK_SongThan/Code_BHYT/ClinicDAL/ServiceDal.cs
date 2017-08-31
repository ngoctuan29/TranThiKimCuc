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
    public class ServiceDal
    {


        public static DataTable DTServiceList(int iServiceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add(new DataColumn("ServiceCode", typeof(Int32)));
                table.Columns.Add(new DataColumn("ServiceName", typeof(string)));
                string sql = string.Empty;
                if (iServiceCode != 0)
                {
                    sql = "select ServiceCode,ServiceName from Service where ServiceCode in({0}) order by ServiceCode asc";
                }
                else
                {
                    sql = "select ServiceCode,ServiceName from Service order by ServiceCode asc";
                }
                table = cn.ExecuteQuery(string.Format(sql, iServiceCode));
            }
            catch { }
            return table;
        }

        public static List<ServiceInf> ListService(string sGroup, string sCateCode, int hide)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceInf> list = new List<ServiceInf>();
            try
            {
                string sql = string.Empty;
                sql = " select a.RowID,a.ServiceCategoryCode,a.ServiceCode,a.ServiceName,a.DepartmentCode,a.Hide,a.servicegroupcode,a.PatientType,b.ServiceCategoryName,a.Serial,a.UnitOfMeasureCode,a.SampleTransfer,a.MaTuongDuong_BHYT,a.MaCK_BHYT,a.MaDK_BHYT,a.Note,a.SOQDPK,a.Ma_TT37,a.Ten_TT37,a.IDGroupPrint,a.Attach_Items from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode where  ServiceCode <>'DV000000' ";
                if (!string.IsNullOrEmpty(sGroup))
                    sql += " and a.servicegroupcode in('{0}')";
                if (!string.IsNullOrEmpty(sCateCode))
                    sql += " and a.ServiceCategoryCode in('{1}') ";
                if (hide != -1)
                    sql += " and a.Hide=" + hide;
                sql += " order by a.ServiceName desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sGroup, sCateCode), null);
                while (ireader.Read())
                {
                    ServiceInf inf = new ServiceInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceCategoryCode = ireader.GetString(1);
                    inf.ServiceCode = ireader.GetString(2);
                    inf.ServiceName = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.Hide = ireader.GetInt32(5);
                    inf.ServiceGroupCode = ireader.GetString(6);
                    inf.PatientType = ireader.GetValue(7).ToString();
                    inf.ServiceCategoryName = ireader.GetValue(8).ToString();
                    inf.Serial = ireader.GetInt32(9);
                    inf.UnitOfMeasureCode = ireader.GetValue(10).ToString();
                    inf.SampleTransfer = ireader.GetInt32(11);
                    inf.MaTuongDuong_BHYT = ireader.GetValue(12).ToString();
                    inf.MaCK_BHYT = ireader.GetValue(13).ToString();
                    inf.MaDK_BHYT = ireader.GetValue(14).ToString();
                    inf.Note = ireader.GetValue(15).ToString();
                    inf.SOQDPK = ireader.GetValue(16).ToString();
                    inf.Ma_TT37 = ireader.GetValue(17).ToString();
                    inf.Ten_TT37 = ireader.GetValue(18).ToString();
                    inf.IDGroupPrint = ireader.GetInt32(19);
                    inf.Attach_Items = ireader.GetBoolean(20);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }

        public static List<ServiceInf> rptListService(string sGroup, string sCateCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceInf> list = new List<ServiceInf>();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.ServiceCategoryCode,a.ServiceCode,a.ServiceName,a.DepartmentCode,a.Hide,a.servicegroupcode,a.PatientType from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode where  1=1 ";
                if (!string.IsNullOrEmpty(sGroup))
                    sql += " and a.servicegroupcode in({0})";
                if (!string.IsNullOrEmpty(sCateCode))
                    sql += " and a.ServiceCategoryCode in({1})";
                sql += " order by a.rowid desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sGroup, sCateCode), null);
                while (ireader.Read())
                {
                    ServiceInf inf = new ServiceInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceCategoryCode = ireader.GetString(1);
                    inf.ServiceCode = ireader.GetString(2);
                    inf.ServiceName = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.Hide = ireader.GetInt32(5);
                    inf.ServiceGroupCode = ireader.GetString(6);
                    inf.PatientType = ireader.GetValue(7).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }

        public static List<ServiceInf> ListServiceReal(string sGroup, string sCateCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceInf> list = new List<ServiceInf>();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.ServiceCategoryCode,a.ServiceCode,a.ServiceName,a.DepartmentCode,a.Hide,a.ServiceGroupCode,b.ServiceCategoryName from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode where  a.Hide=0 ";
                if (!string.IsNullOrEmpty(sGroup))
                    sql += " and a.servicegroupcode in('{0}') ";
                if (!string.IsNullOrEmpty(sCateCode))
                    sql += " and a.ServiceCategoryCode in('{1}') ";
                if (sGroup.Equals("XN"))
                    sql += " order by a.serial asc ";
                else
                    sql += " order by a.serial,a.ServiceName asc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sGroup, sCateCode), null);
                while (ireader.Read())
                {
                    ServiceInf inf = new ServiceInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceCategoryCode = ireader.GetString(1);
                    inf.ServiceCode = ireader.GetString(2);
                    inf.ServiceName = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.Hide = ireader.GetInt32(5);
                    inf.ServiceGroupCode = ireader.GetString(6);
                    inf.ServiceCategoryName = ireader.GetString(7);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch 
            {
                list = null;
            }
            return list;
        }

        public static DataTable DTServiceFull()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ServiceCategoryCode,a.ServiceCode,a.ServiceName,a.DepartmentCode,a.Hide,a.servicegroupcode,b.ServiceCategoryName,c.ServiceGroupName
                    from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode 
                    where  Hide=0 order by a.ServiceCode
                    ";
                dtResult = cn.ExecuteQuery(sql);
                return dtResult;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable DTServiceReal()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = " Select a.ServiceCode,a.ServiceName,b.ServiceCategoryName, 0 as Chon,c.ServiceGroupName from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode where a.Hide=0 ";
                sql += " order by b.ServiceGroupCode ";
                dtResult = cn.ExecuteQuery(sql);
                return dtResult;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable DTServiceRealNotGroup()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = @" select a.RowID,a.ServiceCode,b.ServiceName,a.UnitPrice,a.DisparityPrice,a.ObjectCode,e.ObjectName,b.DepartmentCode,d.DepartmentName,c.ServiceGroupName,c.ServiceGroupCode,f.UnitOfMeasureName,c.ServiceModuleCode,b.MaDK_BHYT
                    from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode
                    left join Department d on b.DepartmentCode=d.DepartmentCode inner join Object e on a.ObjectCode=e.ObjectCode  inner join UnitOfMeasure f on b.UnitOfMeasureCode=f.UnitOfMeasureCode
                     where a.Hide=0 and b.Hide =0 and c.ServiceModuleCode not in('THUOC') order by b.serial asc";
                dtResult = cn.ExecuteQuery(sql);
                return dtResult;
            }
            catch
            {
                return null;
            }
        }

        public static Int32 InsService(ServiceInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[19];
                param[0] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServiceCategoryCode;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@ServiceName", SqlDbType.NVarChar);
                param[2].Value = info.ServiceName;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 250);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@Hide", SqlDbType.Int);
                param[4].Value = info.Hide;
                param[5] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar);
                param[5].Value = info.ServiceGroupCode;
                param[6] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[6].Value = info.EmployeeCode;
                param[7] = new SqlParameter("@PatientType", SqlDbType.VarChar);
                param[7].Value = info.PatientType;
                param[8] = new SqlParameter("@Serial", SqlDbType.Int);
                param[8].Value = info.Serial;
                param[9] = new SqlParameter("@UnitOfMeasureCode", SqlDbType.VarChar, 50);
                param[9].Value = info.UnitOfMeasureCode;
                param[10] = new SqlParameter("@SampleTransfer", SqlDbType.Int);
                param[10].Value = info.SampleTransfer;
                param[11] = new SqlParameter("@MaTuongDuong_BHYT", SqlDbType.VarChar, 50);
                param[11].Value = info.MaTuongDuong_BHYT;
                param[12] = new SqlParameter("@MaCK_BHYT", SqlDbType.VarChar, 50);
                param[12].Value = info.MaCK_BHYT;
                param[13] = new SqlParameter("@MaDK_BHYT", SqlDbType.VarChar, 50);
                param[13].Value = info.MaDK_BHYT;
                param[14] = new SqlParameter("@Note", SqlDbType.VarChar);
                param[14].Value = info.Note;
                param[15] = new SqlParameter("@SOQDPK", SqlDbType.NVarChar);
                param[15].Value = info.SOQDPK;
                param[16] = new SqlParameter("@Ma_TT37", SqlDbType.VarChar);
                param[16].Value = info.Ma_TT37;
                param[17] = new SqlParameter("@Ten_TT37", SqlDbType.NVarChar);
                param[17].Value = info.Ten_TT37;
                param[18] = new SqlParameter("@IDGroupPrint", SqlDbType.Int);
                param[18].Value = info.IDGroupPrint;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Service", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelService(string sServiceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = sServiceCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Service", param);
            }
            catch { return -1; }
        }

        public static List<ServiceFullNameInf> ListServiceRealFullName()
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceFullNameInf> lst = new List<ServiceFullNameInf>();
            try
            {
                string sql = @" select a.ServiceCode,a.ServiceName,a.ServiceCategoryCode,a.ServiceGroupCode,b.ServiceCategoryName,c.ServiceGroupName
                    from Service a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode inner join ServiceGroup c on a.ServiceGroupCode=c.ServiceGroupCode
                    where a.Hide=0 order by c.STT,b.STT,a.ServiceName ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ServiceFullNameInf inf = new ServiceFullNameInf();
                    inf.ServiceCode = ireader.GetValue(0).ToString();
                    inf.ServiceName = ireader.GetValue(1).ToString();
                    inf.ServiceCategoryCode = ireader.GetValue(2).ToString();
                    inf.ServiceGroupCode = ireader.GetValue(3).ToString();
                    inf.ServiceCategoryName = ireader.GetValue(4).ToString();
                    inf.ServiceGroupName = ireader.GetValue(5).ToString();
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }

        public static List<ServiceLimitInf> ListServiceLimitAll()
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceLimitInf> lst = new List<ServiceLimitInf>();
            try
            {
                string sql = @" select EmployeeCode,ServiceCode,IEmployeeCode,0 as Checked from ServiceLimitForEmployee ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ServiceLimitInf inf = new ServiceLimitInf();
                    inf.EmployeeCode = ireader.GetValue(0).ToString();
                    inf.ServiceCode = ireader.GetValue(1).ToString();
                    inf.IEmployeeCode = ireader.GetValue(2).ToString();
                    inf.Checked = ireader.GetInt32(3);
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable TableServiceLimitForEmployee(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" Select a.ServiceCode,a.ServiceName,b.ServiceCategoryName,c.ServiceGroupName, (case when d.ServiceCode is null then 0 else 1 end) Chon
                             from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode 
                             left join ServiceLimitForEmployee d on a.ServiceCode=d.ServiceCode and d.EmployeeCode='{0}'
                             where a.Hide=0 
                             order by b.ServiceGroupCode ";
                return cn.ExecuteQuery(string.Format(sql, employeeCode));
            }
            catch
            {
                return null;
            }
        }

        public static Int32 InsServiceLimit(ServiceLimitInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServiceCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@IEmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.IEmployeeCode;
                param[3] = new SqlParameter("@Result", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                Int32 result = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proInsUpd_ServiceLimit", param));
                if (cn.sqlConnection != null)
                    cn.sqlConnection.Close();
                return result;
            }
            catch { return -2; }
        }

        public static Int32 DelServiceLimit(string employeeCode, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from ServiceLimitForEmployee where ServiceCode=@ServiceCode and EmployeeCode=@EmployeeCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = employeeCode;
                return cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch { return -1; }
        }

        public static Int32 DelServiceLimitAll(string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from ServiceLimitForEmployee where EmployeeCode=@EmployeeCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[0].Value = employeeCode;
                Int32 result = cn.ExecuteNonQuery(CommandType.Text, query, param);
                if (cn.sqlConnection != null)
                    cn.sqlConnection.Close();
                return result;
            }
            catch { return -1; }
        }
        public static DataTable DTServiceRealNotGroupForBHYT()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = @" select a.RowID,a.ServiceCode,b.ServiceName,a.UnitPrice,a.DisparityPrice,a.ObjectCode,e.ObjectName,b.DepartmentCode,d.DepartmentName,c.ServiceGroupName,c.ServiceGroupCode,f.UnitOfMeasureName,c.ServiceModuleCode
                    from [ServicePrice] a inner join [Service] b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode
                    left join Department d on b.DepartmentCode=d.DepartmentCode inner join Object e on a.ObjectCode=e.ObjectCode  inner join UnitOfMeasure f on b.UnitOfMeasureCode=f.UnitOfMeasureCode
                     where a.Hide=0 and b.Hide =0 and a.ObjectCode=1 and c.ServiceModuleCode not in('THUOC') order by b.serial asc";
                dtResult = cn.ExecuteQuery(sql);
                return dtResult;
            }
            catch
            {
                return null;
            }
        }
        public static List<Service_Item_AttachInf2> ListViewServiceItemAttach(string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Service_Item_AttachInf2> lst = new List<Service_Item_AttachInf2>();
            try
            {
                string sql = @" select s.ServiceCode,s.ItemCode,s.ObjectCode,s.Quantity,s.EmployeeCode,s.STT,it.UsageCode,it.UnitOfMeasureCode,s.Note,it.ItemName
                    from Service_Item_Attach s inner join Items it on s.ItemCode=it.ItemCode
                    where s.ServiceCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, serviceCode), null);
                while (ireader.Read())
                {
                    Service_Item_AttachInf2 inf = new Service_Item_AttachInf2();
                    inf.ServiceCode = ireader.GetValue(0).ToString();
                    inf.ItemCode = ireader.GetValue(1).ToString();
                    inf.ObjectCode = ireader.GetInt32(2);
                    inf.Quantity = ireader.GetDecimal(3);
                    inf.EmployeeCode = ireader.GetValue(4).ToString();
                    inf.STT = ireader.GetInt32(5);
                    inf.UsageCode = ireader.GetValue(6).ToString();
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Note = ireader.GetValue(8).ToString();
                    inf.Note = ireader.GetValue(9).ToString();
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch(Exception ex)
            {
                return null;
            }
        }



        public static List<Attach_ServiceINF> ListViewAttach_Service(string ItemCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Attach_ServiceINF> lst = new List<Attach_ServiceINF>();
            try
            {
                string sql = @" select RowID,AttachServiceCode,ItemCode,ObjectCode,IDate,Quantity,EmployeeCode,STT,Note,Is_Service_Auto,AttachServiceCode as AttachServiceCodeOld 
                    from Attach_Service where ItemCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, ItemCode), null);
                while (ireader.Read())
                {
                    Attach_ServiceINF inf = new Attach_ServiceINF();
                    inf.RowID = Convert.ToInt32(ireader.GetValue(0).ToString());
                    inf.AttachServiceCode = ireader.GetValue(1).ToString();
                    inf.ItemCode = ireader.GetValue(2).ToString();
                    inf.ObjectCode = ireader.GetInt32(3);
                    inf.IDate = ireader.GetDateTime(4);
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(5).ToString());
                    inf.EmployeeCode = ireader.GetValue(6).ToString();
                    inf.STT = Convert.ToInt32(ireader.GetValue(7).ToString());
                    inf.Note = ireader.GetValue(8).ToString();
                    inf.Is_Service_Auto = Convert.ToInt32(ireader.GetValue(9).ToString());
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }


        public static Int32 InsAttach_Service(Attach_ServiceINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@AttachServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.AttachServiceCode;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ItemCode;
                param[3] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[3].Value = info.ObjectCode;
                param[4] = new SqlParameter("@IDate", SqlDbType.DateTime);
                param[4].Value = info.IDate;
                param[5] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[5].Value = info.Quantity;
                param[6] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[6].Value = info.EmployeeCode;
                param[7] = new SqlParameter("@STT", SqlDbType.Int);
                param[7].Value = info.STT;
                param[8] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[8].Value = info.Note;
                param[9] = new SqlParameter("@Is_Service_Auto", SqlDbType.Int);
                param[9].Value = info.Is_Service_Auto;
                //param[9] = new SqlParameter("@AttachServiceCodeOld", SqlDbType.NVarChar);
                //param[9].Value = info.Note;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIU_Attach_Service", param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch(Exception ex) { return -2; }
        }





        public static Int32 InsServiceItemAttach(Service_Item_AttachInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServiceCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ItemCode;
                param[2] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[2].Value = info.ObjectCode;
                param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[3].Value = info.Quantity;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@STT", SqlDbType.Int);
                param[5].Value = info.STT;
                param[6] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[6].Value = info.Note;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIU_Service_Item_Attach", param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }



        public static Int32 DelServiceItemAttachAll(string servicecode, string itemcode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from Service_Item_Attach where ServiceCode=@ServiceCode and ItemCode=@ItemCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = servicecode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = itemcode;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }




        public static Int32 DelAttach_ServiceAll(string attachServiceCode, string itemcode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from Attach_Service where AttachServiceCode=@AttachServiceCode and ItemCode=@ItemCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@AttachServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = attachServiceCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = itemcode;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelServiceItemAttachAll(string servicecode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "delete from Service_Item_Attach where ServiceCode=@ServiceCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = servicecode;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 UpdServiceItemAttach(bool attach_Items, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update Service set Attach_Items=@Attach_Items where ServiceCode=@ServiceCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Attach_Items", SqlDbType.Bit);
                param[0].Value = attach_Items ? 1 : 0;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = serviceCode;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                    return 1;
                else
                    return -1;
            }
            catch(Exception ex) { return -2; }
        }
    }
}
