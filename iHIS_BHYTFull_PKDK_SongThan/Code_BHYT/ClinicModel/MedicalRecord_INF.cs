using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicalRecord_INF
    {
        public decimal RowID { get; set; }
        public string MedicalRecordCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string DepartmentCode { get; set; }
        public string EmployeeCode { get; set; }
        public decimal DiagnosisCode { get; set; }
        public string DescriptionNode { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ReferenceCode { get; set; }
        public string Symptoms { get; set; }
        public int Status { get; set; }
        public int ObjectCode { get; set; }
        public string Advices { get; set; }
        public decimal DiagnosisEnclosed { get; set; }
        public int TackleCode { get; set; }
        public int RowIDMedicalPattern { get; set; }
        public string ContentMedicalPattern { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public string DiagnosisCustom { get; set; }
        public int TypeMedical { get; set; }
        public decimal ReceiptID { get; set; }
        public string ShiftWork { get; set; }
        public string Treatments { get; set; }
        public int Pregnant { get; set; }
        public int Breastfeeding { get; set; }
        public int Use_Smoking { get; set; }
        public int Use_Alcohol { get; set; }
        public string EmployeeCodeDoing { get; set; }
        public string ICD10_Custom { get; set; }
        public string ICD10Name_Custom { get; set; }
    }

    public class MedicalPrescriptionDetail_INF
    {
        public decimal RowID { get; set; }
        public string MedicalRecordCode { get; set; }
        public string EmployeeCode { get; set; }
        public string ItemCode { get; set; }
        public int DateOfIssues { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public decimal Quantity { get; set; }
        public string Instruction { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public DateTime PostingDate { get; set; }
        public int Status { get; set; }
        public int New { get; set; }
        public string RepositoryCode { get; set; }
        public int ObjectCode { get; set; }
        public int DoseOf { get; set; }
        public string DoseOfPills { get; set; }
        public int BHYT { get; set; }
        public string UnitOfMeasureCode_Medi { get; set; }
    }

    public class Model_Prescription
    {
        public string MedicalRecordCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public string ItemCode { get; set; }
        public int DateOfIssues { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public decimal Quantity { get; set; }
        public string Instruction { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string RepositoryCode { get; set; }
    }

    public class MedicalRecordViewInBank
    {
        public string MedicalRecordCode { get; set; }
        public string PatientCode { get; set; }
        public decimal ReceiveID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DisparityPrice { get; set; }
        public decimal PatientPay { get; set; }
        public decimal BHYTPay { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public int Paid { get; set; }
        public int ObjectCode { get; set; }
    }

    public class MedicalRecordHistoryModel
    {
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public DateTime PostingDate { get; set; }
        public string PatientName { get; set; }
        public Int32 Statusrv { get; set; }
        public Int32 PatientBirthyear { get; set; }
        public Int32 PatientAge { get; set; }
        public string PatientAddress { get; set; }
        public string ObjectName { get; set; }
        public string GenderName { get; set; }
        public Int32 ObjectCode { get; set; }
        public Int32 ObjectCard { get; set; }
        public Int32 PatientType { get; set; }
        public string MedicalRecordCode { get; set; }
        public string ServiceCode { get; set; }
        public Int32 Status { get; set; }
        public string DepartmentName { get; set; }
        public string DiagnosisCode { get; set; }
        public string Symptoms { get; set; }
        public string DiagnosisName { get; set; }
        public string DiagnosisCustom { get; set; }
        public string EmployeeNameDoctor { get; set; }
        public int STT { get; set; }
    }

    public class MedicalRecord_WaitingBrowseModel
    {
        public string MedicalRecordCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string DepartmentName { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public Int32 PatientAge { get; set; }
        public Int32 PatientBirthyear { get; set; }
        public string PatientGenderName { get; set; }
        public Int32 ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public decimal RowIDMedicinesFor { get; set; }
        public string DateApproved { get; set; }
        public string PatientAddress { get; set; }
        public string PostingDate { get; set; }
        public string DiagnosisName { get; set; }
        public string DiagnosisCustom { get; set; }
        public Int32 Printer { get; set; }
        public string EmployeeName{get;set;}
        public DateTime PatientBirthday { get; set; }
        public int PatientGender { get; set; }
        public string EmployeeCodeDoctor { get; set; }
        public string EmployeeNameDoctor { get; set; }

    }

    public class MedicalRecordEmergencyINF
    {
        public string MedicalRecordCode { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string DepartmentCode { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime PostingDate { get; set; }
        public string ReferenceCode { get; set; }
        public int Status { get; set; }
        public int ObjectCode { get; set; }
        public Int32 Paid { get; set; }
        public string BanksAccountCode { get; set; }
    }

    public class MedicalEmergencyHistoryModel
    {
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public DateTime PostingDate { get; set; }
        public string PatientName { get; set; }
        public Int32 PatientAge { get; set; }
        public string ObjectName { get; set; }
        public string Symptoms { get; set; }
        public string ICD10 { get; set; }
        public string DepartmentName { get; set; }
    }

    public class MedicalRecord_ANCINF
    {
        public string MedicalRecordCode { get; set; }
        public string EmployeeCode { get; set; }
        public string TienSuSinhDe { get; set; }
        public string NgayKinhCuoiCung { get; set; }
        public string TuanThai { get; set; }
        public string NgaySinhDuKien { get; set; }
        public int LanCoThai { get; set; }
        public string TrongLuongMe { get; set; }
        public string ChieuCaoMe { get; set; }
        public string HuyetAp { get; set; }
        public string HuyetAp1 { get; set; }
        public string ChieuCaoTC { get; set; }
        public string VongBung { get; set; }
        public string KhungChau { get; set; }
        public string ThieuMau { get; set; }
        public string Protein { get; set; }
        public string XNHIV { get; set; }
        public string XNKhac { get; set; }
        public string TienLuongDe { get; set; }
        public int SoMuiTiem { get; set; }
        public bool UongVien { get; set; }
        public string TimThai { get; set; }
        public string NgoiThai { get; set; }
        public string GhiChu { get; set; }
        public DateTime WorkDate { get; set; }
    }
    public class MedicalRecord_AbortionsINF
    {
        public string MedicalRecordCode { get; set; }
        public string EmployeeCode { get; set; }
        public int TTHonNhan { get; set; }
        public int SoConHienCo { get; set; }
        public string NgayKinhCuoiCung { get; set; }
        public string ChuanDoanThai { get; set; }
        public string PPPhaThai { get; set; }
        public string KetQuaSoiMo { get; set; }
        public int TaiBienMac { get; set; }
        public int TaiBienChet { get; set; }
        public string KhamLai { get; set; }
        public string GhiChu { get; set; }
        public DateTime WorkDate { get; set; }
    }
    public class MedicalRecord_ChildbirthINF
    {
        public string MedicalRecordCode { get; set; }
        public string EmployeeCode { get; set; }
        public string QLThai { get; set; }
        public string TiemUV { get; set; }
        public bool KT3Lan { get; set; }
        public bool KT4Lan { get; set; }
        public string XNHIVMangThai { get; set; }
        public string XNHIVChuyenDa { get; set; }
        public Int32 SLDeDuThang { get; set; }
        public Int32 SLDeNon { get; set; }
        public Int32 SLPhaThai { get; set; }
        public Int32 SLConHienTai { get; set; }
        public string CachThucDe { get; set; }
        public Int32 TaiBienMac { get; set; }
        public Int32 TaiBienTV { get; set; }
        public string CanNang { get; set; }
        public int GioiTinh { get; set; }
        public string TinhTrangCon { get; set; }
        public string TVThaiNhi { get; set; }
        public string NguoiDoDe { get; set; }
        public string BuGioDau { get; set; }
        public bool TiemViataminK1 { get; set; }
        public bool TiemVXViemGanB { get; set; }
        public string KhamTuanDau { get; set; }
        public string KhamSauDe { get; set; }
        public string GhiChu { get; set; }
        public DateTime WorkDate { get; set; }
    }
}
