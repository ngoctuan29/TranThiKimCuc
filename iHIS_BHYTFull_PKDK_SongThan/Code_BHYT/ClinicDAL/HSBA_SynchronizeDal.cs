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
    public class HSBA_SynchronizeDal
    {
        public static HSBA_ObjMedicalrecordsInf ObjMedicalrecords(decimal patientReceiveID, string patientCode)
        {
            HSBA_ObjMedicalrecordsInf obj = new HSBA_ObjMedicalrecordsInf();
            try
            {
                obj.ObjPatient = objPatient(patientCode);
                obj.ObjPatientReceive = objPatientReceive(patientReceiveID);
                obj.ListSuggested = ListSuggested(patientReceiveID, patientCode);
                obj.ListReceiveDocumentImage = ListReceiveDocumentImage(patientReceiveID);
                obj.ListMedicalRecord = ListMedicalRecord(patientReceiveID, patientCode);
                obj.ListMedicalRecordDetail = ListMedicalRecordDetail(patientReceiveID, patientCode);
                obj.ListServiceRadiologyEntry = ListServiceRadiologyEntry(patientReceiveID, patientCode);
                obj.ListServiceRadiologyDetail = ListServiceRadiologyDetail(patientReceiveID, patientCode);
                obj.ListSurgeries = ListSurgeries(patientReceiveID, patientCode);
                obj.ListSurgicalCrew = ListSurgicalCrew(patientReceiveID, patientCode);
                obj.ListLaboratoryEntry = ListLaboratoryEntry(patientReceiveID, patientCode);
                obj.ListLaboratoryDetail = ListLaboratoryDetail(patientReceiveID, patientCode);
            }
            catch  { obj = null; }
            return obj;
        }
        private static hsba_PatientsInf objPatient(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            hsba_PatientsInf obj = new hsba_PatientsInf();
            string query = "prohsba_GetPatients";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
            param[0].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            if (ireader.Read())
            {
                obj.PatientCode = ireader.GetValue(0).ToString();
                obj.EThnicName = ireader.GetValue(1).ToString();
                obj.CareerName = ireader.GetValue(2).ToString();
                obj.NationalityName = ireader.GetValue(3).ToString();
                obj.ProvincialName = ireader.GetValue(4).ToString();
                obj.DistrictName = ireader.GetValue(5).ToString();
                obj.WardName = ireader.GetValue(6).ToString();
                obj.PatientAddress = ireader.GetValue(7).ToString();
                obj.PatientName = ireader.GetValue(8).ToString();
                obj.PatientGender = Convert.ToInt32(ireader.GetValue(9).ToString());
                obj.PatientBirthDay = Convert.ToDateTime(ireader.GetValue(10).ToString());
                obj.PatientAge = Convert.ToInt32(ireader.GetValue(11).ToString());
                obj.PatientMobile = ireader.GetValue(12).ToString();
                obj.PatientEmail = ireader.GetValue(13).ToString();
                obj.MedicalHistory = ireader.GetValue(14).ToString();
                obj.Allergy = ireader.GetValue(15).ToString();
                if (!string.IsNullOrEmpty(ireader.GetValue(16).ToString()))
                    obj.PatientImage = (byte[])ireader.GetValue(16);
                obj.PatientMonth = ireader.GetValue(17).ToString();
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return obj;
        }
        private static hsba_PatientReceiveInf objPatientReceive(decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            hsba_PatientReceiveInf obj = new hsba_PatientReceiveInf();
            string query = "prohsba_GetPatientReceive";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            if (ireader.Read())
            {
                obj.PatientReceiveID = ireader.GetValue(0).ToString();
                obj.PatientCode = ireader.GetValue(1).ToString();
                obj.Reason = ireader.GetValue(2).ToString();
                obj.InDate = Convert.ToDateTime(ireader.GetValue(3).ToString());
                obj.EmployeeName = ireader.GetValue(4).ToString();
                obj.ObjectCode = Convert.ToInt32(ireader.GetValue(5).ToString());
                if (ireader.GetValue(6) == null || string.IsNullOrEmpty(ireader.GetValue(6).ToString()))
                    obj.OutDate = new DateTime(1990, 01, 01, 01, 01, 01, 01);
                else
                    obj.OutDate = ireader.GetDateTime(6);
                obj.EThnicName = ireader.GetValue(7).ToString();
                obj.CareerName = ireader.GetValue(8).ToString();
                obj.NationalityName = ireader.GetValue(9).ToString();
                obj.ProvincialName = ireader.GetValue(10).ToString();
                obj.DistrictName = ireader.GetValue(11).ToString();
                obj.WardName = ireader.GetValue(12).ToString();
                obj.CompanyInfo = ireader.GetValue(13).ToString();
                obj.PatientAddress = ireader.GetValue(14).ToString();
                obj.IntroName = ireader.GetValue(15).ToString();
                obj.TypeReceiveID = Convert.ToInt32(ireader.GetValue(16).ToString());
                obj.OrderNumber = Convert.ToInt32(ireader.GetValue(17).ToString());
                obj.DenominationName = ireader.GetValue(18).ToString();
                obj.ObjectExemptedName = ireader.GetValue(19).ToString();
                obj.ContentMedicalPattern = ireader.GetValue(20).ToString();
                obj.Pulse = ireader.GetValue(21).ToString();
                obj.Temperature = ireader.GetValue(22).ToString();
                obj.BloodPressure = ireader.GetValue(23).ToString();
                obj.BloodPressure1 = ireader.GetValue(24).ToString();
                obj.Weight_ = ireader.GetValue(25).ToString();
                obj.Hight = ireader.GetValue(26).ToString();
                obj.Breath = ireader.GetValue(27).ToString();
                obj.Serial = ireader.GetValue(28).ToString();
                obj.KCBBDCode = ireader.GetValue(29).ToString();
                obj.KCBBDName = ireader.GetValue(30).ToString();
                obj.StartDate = ireader.GetValue(31).ToString();
                obj.EndDate = ireader.GetValue(32).ToString();
                obj.TraiTuyen = !string.IsNullOrEmpty(ireader.GetValue(33).ToString()) ? 1 : 0;
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return obj;
        }

        private static IList<hsba_SuggestedServiceReceiptInf> ListSuggested(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_SuggestedServiceReceiptInf> list = new List<hsba_SuggestedServiceReceiptInf>();
            string query = "prohsba_GetSuggestedServiceReceipt";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_SuggestedServiceReceiptInf obj = new hsba_SuggestedServiceReceiptInf();
                obj.SuggestedReceiptID = Convert.ToDecimal(ireader.GetValue(0).ToString());
                obj.PatientReceiveID = ireader.GetValue(1).ToString();
                obj.ServiceName = ireader.GetValue(2).ToString();
                obj.ServicePrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                obj.DisparityPrice = Convert.ToDecimal(ireader.GetValue(4).ToString());
                obj.UnitPriceRoot = Convert.ToDecimal(ireader.GetValue(5).ToString());
                obj.PatientCode = ireader.GetValue(6).ToString();
                obj.Status_ = Convert.ToInt32(ireader.GetValue(7).ToString());
                obj.Paid = Convert.ToInt32(ireader.GetValue(8).ToString());
                obj.EmployeeName = ireader.GetValue(9).ToString();
                obj.Note = ireader.GetValue(10).ToString();
                obj.ObjectCode = Convert.ToInt32(ireader.GetValue(11).ToString());
                obj.PatientType = Convert.ToInt32(ireader.GetValue(12).ToString());
                obj.WorkDate = Convert.ToDateTime(ireader.GetValue(13).ToString());
                obj.OrderNumber = Convert.ToDecimal(ireader.GetValue(14).ToString());
                obj.EmployeeNameDoctor = ireader.GetValue(15).ToString();
                obj.DepartmentName = ireader.GetValue(16).ToString();
                obj.DepartmentNameOrder = ireader.GetValue(17).ToString();
                obj.AmountExemption = Convert.ToDecimal(ireader.GetValue(18).ToString());
                obj.Quantity = Convert.ToDecimal(ireader.GetValue(19).ToString());
                obj.Content = ireader.GetValue(20).ToString();
                obj.UnitOfMeasureName = ireader.GetValue(21).ToString();
                obj.ServiceCategoryName = ireader.GetValue(22).ToString();
                obj.ServiceGroupName = ireader.GetValue(23).ToString();
                obj.ServiceModuleCode = ireader.GetValue(24).ToString();
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_ReceiveDocumentImageInf> ListReceiveDocumentImage(decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_ReceiveDocumentImageInf> list = new List<hsba_ReceiveDocumentImageInf>();
            string query = "prohsba_GetReceiveCocumentImage";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_ReceiveDocumentImageInf obj = new hsba_ReceiveDocumentImageInf();
                obj.PatientReceiveID = ireader.GetValue(0).ToString();
                obj.Note = ireader.GetValue(1).ToString();
                if (ireader.GetValue(2).ToString() != "")
                    obj.Image_ = (byte[])ireader.GetValue(2);
                obj.STT = Convert.ToInt32(ireader.GetValue(3).ToString());
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_MedicalRecordInf> ListMedicalRecord(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_MedicalRecordInf> list = new List<hsba_MedicalRecordInf>();
            string query = "prohsba_GetMedicalRecord";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_MedicalRecordInf obj = new hsba_MedicalRecordInf();
                obj.MedicalRecordCode = ireader.GetValue(0).ToString();
                obj.PatientReceiveID = ireader.GetValue(1).ToString();
                obj.PatientCode = ireader.GetValue(2).ToString();
                obj.DepartmentName = ireader.GetValue(3).ToString();
                obj.EmployeeName = ireader.GetValue(4).ToString();
                obj.DiagnosisName = ireader.GetValue(5).ToString();
                obj.DescriptionNode = ireader.GetValue(6).ToString();
                obj.PostingDate = Convert.ToDateTime(ireader.GetValue(7).ToString());
                obj.AppointmentDate = ireader.GetValue(8).ToString();
                obj.Symptoms = ireader.GetValue(9).ToString();
                obj.ObjectCode = Convert.ToInt32(ireader.GetValue(10).ToString());
                obj.Advices = ireader.GetValue(11).ToString();
                obj.IDC10KT = ireader.GetValue(12).ToString();
                obj.TackleName = ireader.GetValue(13).ToString();
                obj.EmployeeNameDoctor = ireader.GetValue(14).ToString();
                obj.DiagnosisCustom = ireader.GetValue(15).ToString();
                obj.Treatments = ireader.GetValue(16).ToString();
                obj.Pulse = ireader.GetValue(17).ToString();
                obj.Temperature = ireader.GetValue(18).ToString();
                obj.BloodPressure = ireader.GetValue(19).ToString();
                obj.BloodPressure1 = ireader.GetValue(20).ToString();
                obj.Weight_ = ireader.GetValue(21).ToString();
                obj.Hight = ireader.GetValue(22).ToString();
                obj.Breath = ireader.GetValue(23).ToString();
                obj.AppointmentNote = string.Empty;
                obj.SuggestedReceiptID = (decimal)ireader.GetValue(24);
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_MedicalRecordDetailInf> ListMedicalRecordDetail(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_MedicalRecordDetailInf> list = new List<hsba_MedicalRecordDetailInf>();
            string query = "prohsba_GetMedicalRecordDetail";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_MedicalRecordDetailInf obj = new hsba_MedicalRecordDetailInf();
                obj.MedicalRecordCode = ireader.GetValue(0).ToString();
                obj.ItemName = ireader.GetValue(1).ToString();
                obj.DateOfIssues = ireader.GetValue(2).ToString();
                obj.Morning = ireader.GetValue(3).ToString();
                obj.Noon = ireader.GetValue(4).ToString();
                obj.Afternoon = ireader.GetValue(5).ToString();
                obj.Evening = ireader.GetValue(6).ToString();
                obj.Quantity = Convert.ToDecimal(ireader.GetValue(7).ToString());
                obj.Instruction = ireader.GetValue(8).ToString();
                obj.UnitPrice = Convert.ToDecimal(ireader.GetValue(9).ToString());
                obj.Amount = Convert.ToDecimal(ireader.GetValue(10).ToString());
                obj.ObjectCode = Convert.ToInt32(ireader.GetValue(11).ToString());
                obj.DoseOf = Convert.ToInt32(ireader.GetValue(12).ToString());
                obj.DoseOfPills = ireader.GetValue(13).ToString();
                obj.ItemCategoryName = ireader.GetValue(14).ToString();
                obj.GroupName = ireader.GetValue(15).ToString();
                obj.UnitOfMeasureName = ireader.GetValue(16).ToString();
                obj.Active = ireader.GetValue(17).ToString();
                obj.ItemContent = ireader.GetValue(18).ToString();
                obj.PatientReceiveID = ireader.GetValue(19).ToString();
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_ServiceRadiologyEntryInf> ListServiceRadiologyEntry(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_ServiceRadiologyEntryInf> list = new List<hsba_ServiceRadiologyEntryInf>();
            string query = "prohsba_GetServiceRadiologyEntry";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_ServiceRadiologyEntryInf obj = new hsba_ServiceRadiologyEntryInf();
                obj.RowID = Convert.ToDecimal(ireader.GetValue(0).ToString());
                obj.PatientReceiveID = ireader.GetValue(1).ToString();
                obj.Contents = ireader.GetValue(2).ToString();
                obj.Conclusion = ireader.GetValue(3).ToString();
                obj.Proposal = ireader.GetValue(4).ToString();
                obj.PostingDate = Convert.ToDateTime(ireader.GetValue(5).ToString());
                obj.EmployeeName = ireader.GetValue(6).ToString();
                obj.EmployeeNameDoctor = ireader.GetValue(7).ToString();
                obj.ServiceGroupCode = ireader.GetValue(8).ToString();
                obj.Note = ireader.GetValue(9).ToString();
                obj.Diagnosis = ireader.GetValue(10).ToString();
                obj.ServiceName = ireader.GetValue(11).ToString();
                obj.SuggestedReceiptID = (decimal)ireader.GetValue(12);
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_ServiceRadiologyDetailInf> ListServiceRadiologyDetail(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_ServiceRadiologyDetailInf> list = new List<hsba_ServiceRadiologyDetailInf>();
            string query = "prohsba_GetServiceRadiologyDetail";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_ServiceRadiologyDetailInf obj = new hsba_ServiceRadiologyDetailInf();
                obj.PatientReceiveID = ireader.GetValue(0).ToString();
                obj.RadiologyRowID = Convert.ToDecimal(ireader.GetValue(1).ToString());
                if (!string.IsNullOrEmpty(ireader.GetValue(2).ToString()))
                    obj.Image_ = (byte[])ireader.GetValue(2);
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_SurgeriesInf> ListSurgeries(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_SurgeriesInf> list = new List<hsba_SurgeriesInf>();
            string query = "prohsba_GetSurgeries";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_SurgeriesInf obj = new hsba_SurgeriesInf();
                obj.PatientReceiveID = ireader.GetValue(0).ToString();
                obj.SurgeriesCode = ireader.GetValue(1).ToString();
                obj.DateOn = ireader.GetValue(2).ToString();
                obj.TimeOn = ireader.GetValue(3).ToString();
                obj.DateOut = ireader.GetValue(4).ToString();
                obj.TimeOut = ireader.GetValue(5).ToString();
                obj.ICD10On = ireader.GetValue(6).ToString();
                obj.ICD10Out = ireader.GetValue(7).ToString();
                obj.AnesthesiaName = ireader.GetValue(8).ToString();
                obj.ComplicationsName = ireader.GetValue(9).ToString();
                obj.SituationName = ireader.GetValue(10).ToString();
                obj.Content = ireader.GetValue(11).ToString();
                obj.Note = ireader.GetValue(12).ToString();
                obj.EmployeeName = ireader.GetValue(13).ToString();
                obj.ObjectCode = Convert.ToInt32(ireader.GetValue(14).ToString());
                obj.PatientType = Convert.ToInt32(ireader.GetValue(15).ToString());
                obj.DepartmentName = ireader.GetValue(16).ToString();
                obj.DiagnosisCustomOn = ireader.GetValue(17).ToString();
                obj.DiagnosisCustomOut = ireader.GetValue(18).ToString();
                obj.ServiceName = ireader.GetValue(19).ToString();
                obj.SuggestedReceiptID = (decimal)ireader.GetValue(20);
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_SurgicalCrewInf> ListSurgicalCrew(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_SurgicalCrewInf> list = new List<hsba_SurgicalCrewInf>();
            string query = "prohsba_GetSurgicalCrew";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_SurgicalCrewInf obj = new hsba_SurgicalCrewInf();
                obj.PatientReceiveID = ireader.GetValue(0).ToString();
                obj.SurgeriesCode = ireader.GetValue(1).ToString();
                obj.EmployeeName = ireader.GetValue(2).ToString();
                obj.PositionName = ireader.GetValue(3).ToString();
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_LaboratoryEntryInf> ListLaboratoryEntry(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_LaboratoryEntryInf> list = new List<hsba_LaboratoryEntryInf>();
            string query = "prohsba_GetLaboratoryEntry";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_LaboratoryEntryInf obj = new hsba_LaboratoryEntryInf();
                obj.IDLaboratoryEntry = Convert.ToDecimal(ireader.GetValue(0).ToString());
                obj.PatientReceiveID = ireader.GetValue(1).ToString();
                obj.AppointmentDate = ireader.GetValue(2).ToString();
                obj.AppointmentNote = ireader.GetValue(3).ToString();
                obj.Conclusion = ireader.GetValue(4).ToString();
                obj.Proposal = ireader.GetValue(5).ToString();
                obj.PostingDate = Convert.ToDateTime(ireader.GetValue(6).ToString());
                obj.ServiceCategoryName = ireader.GetValue(7).ToString();
                obj.IDTemplate = ireader.GetValue(8).ToString();
                obj.ObjectCode = Convert.ToInt32(ireader.GetValue(9).ToString());
                obj.EmployeeName = ireader.GetValue(10).ToString();
                obj.PostingDateResult = ireader.GetValue(11).ToString();
                obj.DepartmentNameOrder = ireader.GetValue(12).ToString();
                obj.OrderDate = Convert.ToDateTime(ireader.GetValue(13).ToString());
                obj.EmployeeDoctorNameOrder = ireader.GetValue(14).ToString();
                obj.Status_ = ireader.GetValue(15).ToString();
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        private static IList<hsba_LaboratoryDetailInf> ListLaboratoryDetail(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<hsba_LaboratoryDetailInf> list = new List<hsba_LaboratoryDetailInf>();
            string query = "prohsba_GetLaboratoryDetail";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
            param[0].Value = patientReceiveID;
            param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
            param[1].Value = patientCode;
            IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, query, param);
            while (ireader.Read())
            {
                hsba_LaboratoryDetailInf obj = new hsba_LaboratoryDetailInf();
                obj.PatientReceiveID = ireader.GetValue(0).ToString();
                obj.IDLaboratoryEntry = Convert.ToDecimal(ireader.GetValue(1).ToString());
                obj.ServiceName = ireader.GetValue(2).ToString();
                obj.UnitValues = ireader.GetValue(3).ToString();
                obj.ValuesEntry = ireader.GetValue(4).ToString();
                obj.ValuedFemale = ireader.GetValue(5).ToString();
                obj.ValuedMale = ireader.GetValue(6).ToString();
                obj.Normal = Convert.ToInt32(ireader.GetValue(7).ToString());
                obj.LaboratoryName = ireader.GetValue(8).ToString();
                obj.Serial = Convert.ToInt32(ireader.GetValue(9).ToString());
                obj.SuggestedReceiptID = (decimal)ireader.GetValue(10);
                list.Add(obj);
            }
            if (!ireader.IsClosed)
            {
                ireader.Close();
                ireader.Dispose();
            }
            return list;
        }

        public static bool isUpdComfirmHSBA(decimal patientReceiveID, string patientCode)
        {
            try
            {
                ConnectDB cn = new ConnectDB();
                List<hsba_LaboratoryDetailInf> list = new List<hsba_LaboratoryDetailInf>();
                string query = "update PatientReceive set ConfirmHSBA=1 where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
                param[1].Value = patientCode;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) > 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public static DataTable TableGet_KetQuaDieuTri(string dtFrom, string dtTo, string department, int iType, int comfirmHSBA)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[0].Value = iType;
                param[1] = new SqlParameter("@frDate", SqlDbType.Char);
                param[1].Value = dtFrom;
                param[2] = new SqlParameter("@toDate", SqlDbType.Char);
                param[2].Value = dtTo;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.NVarChar);
                param[3].Value = department;
                param[4] = new SqlParameter("@ConfirmHSBA", SqlDbType.Int);
                param[4].Value = comfirmHSBA;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "prohsba_ViewKetQuaDieuTri", param);
                return dtResult;
            }
            catch { return null; }
        }
    }
}
