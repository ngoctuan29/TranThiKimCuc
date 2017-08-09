using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class MedicalRecordOutputInf
    {
        public decimal RowID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string DepartmentCode { get; set; }
        public string ShiftWork { get; set; }
        public string EmployeeCode { get; set; }
        public string MedicalRecordCode { get; set; }
        public int ObjectCode { get; set; }
        public string FullNameFamily { get; set; }
        public string MobileFamily { get; set; }
        public string HourIn { get; set; }
        public string DateIn { get; set; }
        public string DiagnosisIntroduce { get; set; }
        public bool isYTe { get; set; }
        public bool isTuDen { get; set; }
        public string ReasonIn { get; set; }
        public string Pathological_Process { get; set; }
        public string Anamnesis_Personal { get; set; }
        public string Anamnesis_Family { get; set; }
        public string KB_Totality { get; set; }
        public string KB_Parts { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string BloodPressure1 { get; set; }
        public string Weight_ { get; set; }
        public string Hight { get; set; }
        public string Breath { get; set; }
        public string CLS_Brief { get; set; }
        public string Initial_DiagnosisName { get; set; }
        public string Drug_Brief { get; set; }
        public int ICD10_Out { get; set; }
        public string ICD10_OutName { get; set; }
        public string Treatment_DateFrom { get; set; }
        public string Treatment_DateTo { get; set; }
        public string BenhAn_DienBienLamSang { get; set; }
        public string BenhAn_TomTatXetNghiem { get; set; }
        public int BenhAn_BenhChinh { get; set; }
        public string BenhAn_BenhChinhTen { get; set; }
        public string BenhAn_BenhKemTheo { get; set; }
        public string BenhAn_BenhKemTheoTen { get; set; }
        public string BenhAn_PPDieuTri { get; set; }
        public string BenhAn_TTRaVien { get; set; }
        public string BenhAn_HuongDieuTri { get; set; }
        public string BenhAn_HSXQuang { get; set; }
        public string BenhAn_HSCTScanner { get; set; }
        public string BenhAn_HSSieuAm { get; set; }
        public string BenhAn_HSXetNghiem { get; set; }
        public string BenhAn_HSKhac { get; set; }
        public string BenhAn_NguoiGiaoHS { get; set; }
        public string BenhAn_NguoiNhanHS { get; set; }
        public string EmployeeDoctorCode { get; set; }
        public DateTime DateWorking { get; set; }
        public int SoLuuTru { get; set; }
        public bool Cancel { get; set; }
        public string Workplace { get; set; }
        public string Serial01 { get; set; }
        public string Serial02 { get; set; }
        public string Serial03 { get; set; }
        public string Serial04 { get; set; }
        public string Serial05 { get; set; }
        public string Serial06 { get; set; }
        public string EndDate_BHYT { get; set; }

    }
}
