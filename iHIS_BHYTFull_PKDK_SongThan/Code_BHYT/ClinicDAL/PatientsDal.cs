using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using ClinicModel;

namespace ClinicDAL
{
    public class PatientsDal
    {
        public static List<PatientsInf> ListPatients(string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<PatientsInf> list = new List<PatientsInf>();
            try
            {
                string sql = string.Empty;
                if (sPatientCode != "")
                {
                    sql = "select RowID,PatientCode,PatientName,PatientGender,PatientBirthday,PatientBirthyear,PatientAge,PatientAddress,PatientMobile,PatientEmail,CodeArise,MedicalHistory,Allergy,PatientImage from Patients where PatientCode in('{0}') ";
                }
                else
                {
                    sql = "select RowID,PatientCode,PatientName,PatientGender,PatientBirthday,PatientBirthyear,PatientAge,PatientAddress,PatientMobile,PatientEmail,CodeArise,MedicalHistory,Allergy,PatientImage from Patients order by RowID asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode), null);
                while (ireader.Read())
                {
                    PatientsInf inf = new PatientsInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.PatientName = ireader.GetString(2);
                    inf.PatientGender = ireader.GetInt32(3);
                    inf.PatientBirthday = ireader.GetDateTime(4);
                    inf.PatientBirthyear = ireader.GetInt32(5);
                    inf.PatientAge = ireader.GetInt32(6);
                    inf.PatientAddress = ireader.GetValue(7).ToString();
                    inf.PatientMobile = ireader.GetValue(8).ToString();
                    inf.PatientEmail = ireader.GetValue(9).ToString();
                    inf.CodeArise = ireader.GetValue(10).ToString();
                    inf.MedicalHistory = ireader.GetValue(11).ToString();
                    inf.Allergy = ireader.GetValue(12).ToString();
                    if (ireader.GetValue(13).ToString() != "")
                        inf.PatientImage = (byte[])ireader.GetValue(13);
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

        public static PatientsInf ObjPatients(string sPatientCode, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                PatientsInf inf = new PatientsInf();
                string sql = string.Empty;
                if (patientReceiveID > 0)
                {
                    sql = @" select a.RowID,a.PatientCode,a.PatientName,a.PatientGender,a.PatientBirthday,a.PatientBirthyear,a.PatientAge,b.Address PatientAddress,a.PatientMobile,a.PatientEmail,a.CodeArise,a.MedicalHistory,a.Allergy,a.PatientImage,a.EThnicID,a.CareerCode,a.NationalityID,a.ProvincialCode,a.DistrictCode,a.WardCode,(case b1.WardName when LOWER(N'Không xác định') then '' else b1.WardName end) WardName,(case b2.DistrictName when LOWER(N'Không xác định') then '' else b2.DistrictName end) DistrictName,(case b3.ProvincialName when LOWER(N'Không xác định') then '' else b3.ProvincialName end) ProvincialName,a.MedicalHistoryChildren,a.IDTypeReceive,a.PatientMonth,a.TenCha,a.NSCha,a.TenMe,a.NSMe
                        from Patients a inner join PatientReceive b on a.PatientCode=b.PatientCode left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode
                         where a.PatientCode in('{0}') and b.PatientReceiveID in({1})";
                }
                else
                {
                    sql = @" select a.RowID,a.PatientCode,a.PatientName,a.PatientGender,a.PatientBirthday,a.PatientBirthyear,a.PatientAge,a.PatientAddress,a.PatientMobile,a.PatientEmail,a.CodeArise,a.MedicalHistory,a.Allergy,a.PatientImage,a.EThnicID,a.CareerCode,a.NationalityID,a.ProvincialCode,a.DistrictCode,a.WardCode,(case b1.WardName when LOWER(N'Không xác định') then '' else b1.WardName end) WardName,(case b2.DistrictName when LOWER(N'Không xác định') then '' else b2.DistrictName end) DistrictName,(case b3.ProvincialName when LOWER(N'Không xác định') then '' else b3.ProvincialName end) ProvincialName,a.MedicalHistoryChildren,a.IDTypeReceive,a.PatientMonth,a.TenCha,a.NSCha,a.TenMe,a.NSMe
                    from Patients a left join Catalog_Ward b1 on a.WardCode=b1.WardCode left join Catalog_District b2 on a.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a.ProvincialCode=b3.ProvincialCode
                     where a.PatientCode in('{0}')";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, patientReceiveID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.PatientName = ireader.GetString(2);
                    inf.PatientGender = ireader.GetInt32(3);
                    inf.PatientBirthday = ireader.GetDateTime(4);
                    inf.PatientBirthyear = ireader.GetInt32(5);
                    inf.PatientAge = ireader.GetInt32(6);
                    inf.PatientAddress = ireader.GetValue(7).ToString();
                    inf.PatientMobile = ireader.GetValue(8).ToString();
                    inf.PatientEmail = ireader.GetValue(9).ToString();
                    inf.CodeArise = ireader.GetValue(10).ToString();
                    inf.MedicalHistory = ireader.GetValue(11).ToString();
                    inf.Allergy = ireader.GetValue(12).ToString();
                    if (ireader.GetValue(13).ToString() != "")
                        inf.PatientImage = (byte[])ireader.GetValue(13);
                    inf.EThnicID = ireader.GetInt32(14);
                    inf.CareerCode = ireader.GetValue(15).ToString();
                    inf.NationalityID = ireader.GetInt32(16);
                    inf.ProvincialCode = ireader.GetValue(17).ToString();
                    inf.DistrictCode = ireader.GetValue(18).ToString();
                    inf.WardCode = ireader.GetValue(19).ToString();
                    inf.WardName = ireader.GetValue(20).ToString();
                    inf.DistrictName = ireader.GetValue(21).ToString();
                    inf.ProvincialName = ireader.GetValue(22).ToString();
                    inf.MedicalHistoryChildren = ireader.GetValue(23).ToString();
                    inf.IDTypeReceive = ireader.GetInt32(24);
                    inf.PatientMonth = ireader.GetValue(25).ToString();
                    inf.TenCha = ireader.GetValue(26).ToString();
                    inf.NSCha = Convert.ToInt32(ireader.GetValue(27).ToString());
                    inf.TenMe = ireader.GetValue(28).ToString();
                    inf.NSMe = Convert.ToInt32(ireader.GetValue(29).ToString()); 
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }
                
        public static DataTable DTPatients(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select RowID,PatientCode,PatientName,PatientGender,PatientBirthday,PatientBirthyear,PatientAge,PatientAddress,PatientMobile,PatientEmail,CodeArise,MedicalHistory,Allergy,PatientImage,(case when PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,EThnicID,CareerCode,NationalityID,ProvincialCode,DistrictCode,WardCode from Patients where PatientCode in('{0}') ";
                return cn.ExecuteQuery(string.Format(sql, patientCode));
            }
            catch { return null; }
        }
        public static DataTable DTPatients(string patientCode, decimal patientReceiveId)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select a.PatientCode,a.PatientName,a.PatientGender,a.PatientBirthday,a.PatientBirthyear,a.PatientAge,a.PatientAddress,a.PatientMobile,a.PatientEmail,
                a.CodeArise,a.MedicalHistory,a.Allergy,a.PatientImage,(case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,a1.EthnicName,c.DepartmentName,b.STT
                from Patients a inner join SuggestedServiceReceipt b on a.PatientCode=b.PatientCode inner join Department c on b.DepartmentCode=c.DepartmentCode
                inner join Catalog_EThnic a1 on a.EThnicID=a1.EThnicID inner join Service b1 on b.ServiceCode=b1.ServiceCode inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode
                 where a.PatientCode='{0}' and RefID={1} and b2.ServiceGroupCode='KCB'";
                return cn.ExecuteQuery(string.Format(sql, patientCode, patientReceiveId));
            }
            catch { return null; }
        }
        public static Int32 InsPatients(PatientsInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = info.PatientCode;
                param[1] = new SqlParameter("@PatientName", SqlDbType.NVarChar, 500);
                param[1].Value = info.PatientName;
                param[2] = new SqlParameter("@PatientGender", SqlDbType.Int);
                param[2].Value = info.PatientGender;
                param[3] = new SqlParameter("@PatientBirthday", SqlDbType.DateTime);
                param[3].Value = info.PatientBirthday;
                param[4] = new SqlParameter("@PatientBirthyear", SqlDbType.Int);
                param[4].Value = info.PatientBirthyear;
                param[5] = new SqlParameter("@PatientAge", SqlDbType.Int);
                param[5].Value = info.PatientAge;
                param[6] = new SqlParameter("@PatientAddress", SqlDbType.NVarChar, 500);
                param[6].Value = info.PatientAddress;
                param[7] = new SqlParameter("@PatientMobile", SqlDbType.VarChar, 50);
                param[7].Value = info.PatientMobile;
                param[8] = new SqlParameter("@PatientEmail", SqlDbType.VarChar, 50);
                param[8].Value = info.PatientEmail;
                param[9] = new SqlParameter("@CodeArise", SqlDbType.VarChar, 50);
                param[9].Value = info.CodeArise;
                param[10] = new SqlParameter("@MedicalHistory", SqlDbType.NVarChar);
                param[10].Value = info.MedicalHistory;
                param[11] = new SqlParameter("@Allergy", SqlDbType.NVarChar);
                param[11].Value = info.Allergy;
                param[12] = new SqlParameter("@PatientImage", SqlDbType.Image);
                param[12].Value = info.PatientImage;
                param[13] = new SqlParameter("@EThnicID", SqlDbType.Int);
                param[13].Value = info.EThnicID;
                param[14] = new SqlParameter("@CareerCode", SqlDbType.VarChar, 10);
                param[14].Value = info.CareerCode;
                param[15] = new SqlParameter("@NationalityID", SqlDbType.Int);
                param[15].Value = info.NationalityID;
                param[16] = new SqlParameter("@ProvincialCode", SqlDbType.VarChar, 3);
                param[16].Value = info.ProvincialCode;
                param[17] = new SqlParameter("@DistrictCode", SqlDbType.VarChar, 5);
                param[17].Value = info.DistrictCode;
                param[18] = new SqlParameter("@WardCode", SqlDbType.VarChar, 8);
                param[18].Value = info.WardCode;
                param[19] = new SqlParameter("@IDTypeReceive", SqlDbType.Int);
                param[19].Value = info.IDTypeReceive;
                param[20] = new SqlParameter("@PatientMonth", SqlDbType.VarChar, 5);
                param[20].Value = info.PatientMonth;
                //BHYT 27/07/2016
                param[21] = new SqlParameter("@TenCha", SqlDbType.NVarChar, 250);
                param[21].Value = info.TenCha;
                param[22] = new SqlParameter("@NSCha", SqlDbType.Decimal);
                param[22].Value = info.NSCha;
                param[23] = new SqlParameter("@TenMe", SqlDbType.NVarChar, 250);
                param[23].Value = info.TenMe;
                param[24] = new SqlParameter("@NSMe", SqlDbType.Decimal);
                param[24].Value = info.NSMe;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Patients", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 UpdPatients(string sMedicalHistory, string sAllergy, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@MedicalHistory", SqlDbType.NVarChar);
                param[1].Value = sMedicalHistory;
                param[2] = new SqlParameter("@Allergy", SqlDbType.NVarChar);
                param[2].Value = sAllergy;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_UpdPatients", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 UpdPatientsForMedicalHistoryChildren(string patientCode, string medicalHistoryChildren)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@MedicalHistoryChildren", SqlDbType.NVarChar);
                param[1].Value = medicalHistoryChildren;
                param[2] = new SqlParameter("@Result", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                if (Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_UpdPatientsAbout", param)) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static string GetPatientCode()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@vresult", SqlDbType.VarChar, 50);
                param[0].Direction = ParameterDirection.Output;
                return cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_GetPatientCode", param);;
            }
            catch { return string.Empty; }
        }

        public static List<PatientViewInf> ListHistoryForPatient(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select a.PatientCode,(N'Vào viện ngày : ' + convert(char(10),b.CreateDate,103) + ' ' +convert(char(5),sysdatetime(),108)) Title,((N'Khám : ' +c.DepartmentName) + ' ('+(case when a.Status=0 and a.ServiceCode<>'DV000000' then N'Chưa khám' when a.Status=1 and a.ServiceCode<>'DV000000' then 'Đã khám' else '...' end ) + ') ') as Info,a.RefID,convert(date,b.CreateDate,103) CreateDate,d.EmployeeName,b.PatientType,a2.EmployeeName EmployeeNameDoctor,b.Status,b.OutDate 
                from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Employee d on a.EmployeeCode=d.EmployeeCode left join MedicalRecord a1 on a.ReceiptID=a1.ReceiptID left join Employee a2 on a1.EmployeeCodeDoctor=a2.EmployeeCode
                where a.PatientCode='{0}' and a.Note='TIEPDON' and a.ReceiptID_DisparityPrice=0
                order by b.CreateDate desc ";
                List<PatientViewInf> list = new List<PatientViewInf>();
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode), null);
                while (ireader.Read())
                {
                    PatientViewInf inf = new PatientViewInf();
                    inf.PatientCode = ireader.GetValue(0).ToString();
                    inf.Title = ireader.GetValue(1).ToString();
                    inf.Info = ireader.GetValue(2).ToString();
                    inf.RefID = ireader.GetDecimal(3);
                    inf.CreateDate = ireader.GetDateTime(4);
                    inf.EmployeeName = ireader.GetValue(5).ToString();
                    inf.PatientType = Convert.ToInt32(ireader.GetValue(6).ToString());
                    inf.EmployeeNameDoctor = ireader.GetValue(7).ToString();
                    inf.Status = ireader.GetInt32(8);
                    inf.OutDate = ireader.GetValue(9).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return list;
            }
            catch { return null; }
        }

        public static DataTable DT_PatientType()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @"select RowID,TypeName from PatientType order by RowID ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static DataTable DT_PatientTypeNotin(Int32 iType)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select top(1) 0 RowID,N'Chọn loại bệnh nhân' TypeName from PatientType where 1=1
                                union all select RowID,TypeName from PatientType where RowID not in({0}) order by RowID ";
                return cn.ExecuteQuery(string.Format(sql, iType));
            }
            catch { return null; }
        }

        public static DataTable DT_PatientTypeMain()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select RowID,TypeName from PatientType order by RowID ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }

        public static DataTable hsba_Patients(string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("RowID", typeof(decimal));
            dtResult.Columns.Add("PatientCode", typeof(string));
            dtResult.Columns.Add("PatientName", typeof(string));
            dtResult.Columns.Add("PatientGender", typeof(Int32));
            dtResult.Columns.Add("PatientBirthday", typeof(DateTime));
            dtResult.Columns.Add("PatientBirthyear", typeof(Int32));
            dtResult.Columns.Add("PatientAge", typeof(Int32));
            dtResult.Columns.Add("PatientAddress", typeof(string));
            dtResult.Columns.Add("PatientMobile", typeof(string));
            dtResult.Columns.Add("PatientEmail", typeof(string));
            dtResult.Columns.Add("CodeArise", typeof(string));
            dtResult.Columns.Add("MedicalHistory", typeof(string));
            dtResult.Columns.Add("Allergy", typeof(string));
            dtResult.Columns.Add("PatientImage", typeof(string));
            try
            {
                string sql = "select RowID,PatientCode,PatientName,PatientGender,PatientBirthday,PatientBirthyear,PatientAge,PatientAddress,PatientMobile,PatientEmail,CodeArise,MedicalHistory,Allergy,PatientImage from Patients where PatientCode=@PatientCode ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = Convert.ToDecimal(ireader.GetValue(0).ToString());
                    dr[1] = ireader.GetValue(1).ToString();
                    dr[2] = ireader.GetValue(2).ToString();
                    dr[3] = Convert.ToInt32(ireader.GetValue(3).ToString());
                    dr[4] = Convert.ToDateTime(ireader.GetValue(4).ToString());
                    dr[5] = Convert.ToInt32(ireader.GetValue(5).ToString());
                    dr[6] = Convert.ToInt32(ireader.GetValue(6).ToString());
                    dr[7] = ireader.GetValue(7).ToString();
                    dr[8] = ireader.GetValue(8).ToString();
                    dr[9] = ireader.GetValue(9).ToString();
                    dr[10] = ireader.GetValue(10).ToString();
                    dr[11] = ireader.GetValue(11).ToString();
                    dr[12] = ireader.GetValue(12).ToString();
                    if (ireader.GetValue(13).ToString() != "")
                    {
                        byte[] bytestemp = (byte[])ireader.GetValue(13);
                        dr[13] = Convert.ToBase64String(bytestemp);
                    }
                    dtResult.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch {  }
            return dtResult;
        }

    }
}
