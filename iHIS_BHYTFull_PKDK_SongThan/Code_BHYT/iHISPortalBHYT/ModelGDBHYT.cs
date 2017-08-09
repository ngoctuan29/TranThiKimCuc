using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace iHISPortalBHYT
{
   public class ModelGDBHYT
    {
        public class ResultGetToken
        {
            public string maKetQua { get; set; }
            public APIKey APIKey { get; set; }
        }
        public class ResultCheckTheBHYT
        {
            public string maKetQua { get; set; }
            public string ketQua { get; set; }
        }
        public class APIKey
        {
            public string access_token { get; set; }
            public string id_token { get; set; }
            public string expires_in { get; set; }
            public string token_type { get; set; }
            public string username { get; set; }
        }
        public class APIToken
        {
            public string username { get; set; }
            public  string password { get; set; }
        }
        public class DataSendInspectionRecords
        {
            public byte[] fileHS { get; set; } // dạng byte của file XML
        }
        public class QueryParameterSendSyntheticRecords // Gửi hồ sơ tổng hợp báo cáo hàng tháng/quý (1.3 công văn 917)
        {
            public string loaiHoSo { get; set; } // Loại hồ sơ: Hồ sơ 79a/80a: 5, Mẫu 19/BHYT: 6, Mẫu 20/BHYT: 7,Mẫu 21/BHYT: 8
            public string maCSKCB { get; set; }
            public string userName { get; set; }
            public string passWord { get; set; }
        }
        public class DataSendSyntheticRecords
        {
            public byte[] fileHS { get; set; } // Dạng bytes của File excel
        }
        public class ResultSendSyntheticRecords
        {
            public string maKetQua { get; set; }
            public string maGiaoDich { get; set; } // luu lai mã này để sử dụng cho mục đích tìm kiếm sau này
        }

        public class QueryParameterHistoryExaminationPatient
        {
            public string userName { get; set; }
            public string passWord { get; set; }
        }
        public class DataHistoryExaminationPatient  // thông tin kiểm tra lịch sử khám chữa bệnh
        {
            public string maThe { get; set; }
            public string hoTen { get; set; }
            public string ngaySinh { get; set; } //(DD/MM/YYYY)
            public int gioiTinh { get; set; } // 1 : Nam, 2: Nữ
            public string maCSKCB { get; set; }
            public string ngayBD { get; set; }
            public string ngayKT { get; set; }

        }
        public class ResultHistoryExaminationPatient
        {
            public string maKetQua { get; set; }
            public IList<HistoryExaminationPatient> dsLichSuKCB { get; set; }
        }
        public class HistoryExaminationPatient
        {
            public string maHoSo { get; set; }
            public string maCSKCB { get; set; }
            public string tuNgay { get; set; }
            public string denNgay { get; set; }
            public string tenBenh { get; set; }
            public string tinhTrang { get; set; }
            public string kqDieuTri { get; set; }
        }
        public class QueryParameterHistoryExaminationPatientDetail // lịch sử khám chữa bệnh chi tiết
        {
            public string maHoSo { get; set; } // nhận từ hàm HistoryExaminationPatientDetail trong class HistoryExaminationPatient
            public string userName { get; set; }
            public string passWord { get; set; }
        }
        public class ResultHistoryExaminationPatientDetail
        {
            public string maKetQua { get; set; }
            public HistoryExaminationPatientDetail hoSoKCB { get; set; }
        }
        public class HistoryExaminationPatientDetail
        {
            public TONG_HOP xml1 { get; set; }
            public IList<CHI_TIET_THUOC> dsXml2 { get; set; }
            public IList<CHI_TIET_DVKT> dsXml3 { get; set; }
            public IList<CHI_TIET_CLS> dsXml4 { get; set; }
            public IList<CHI_TIET_DIEN_BIEN_BENH> dsXml5 { get; set; }
        }

        [XmlRoot(ElementName ="TONG_HOP")]
        //XM1_9324, QD 917
        public class TONG_HOP
        {
            public  string MA_LK { get; set; }
            public  int? STT { get; set; }
            public  string MA_BN { get; set; }
            public  string HO_TEN { get; set; }
            public string NGAY_SINH { get; set; }
            public  short? GIOI_TINH { get; set; }
            public  string DIA_CHI { get; set; }
            public  string MA_THE { get; set; }
            public  string MA_DKBD { get; set; }
            public string GT_THE_TU { get; set; }
            public string GT_THE_DEN { get; set; }
            public  string TEN_BENH { get; set; }
            public  string MA_BENH { get; set; }
            public  string MA_BENHKHAC { get; set; }
            public  short? MA_LYDO_VVIEN { get; set; }
            public  string MA_NOI_CHUYEN { get; set; }
            public  string MA_TAI_NAN { get; set; }
            public string NGAY_VAO { get; set; }
            public string NGAY_RA { get; set; }
            public  int? SO_NGAY_DTRI { get; set; }
            public  short? KET_QUA_DTRI { get; set; }
            public  short? TINH_TRANG_RV { get; set; }
            public  string NGAY_TTOAN { get; set; }
            public  int? MUC_HUONG { get; set; }
            public  decimal? T_THUOC { get; set; }
            public decimal? T_VTYT { get; set; }
            public decimal? T_TONGCHI { get; set; }
            public decimal? T_BNTT { get; set; }
            public decimal? T_BHTT { get; set; }
            public decimal? T_NGUONKHAC { get; set; }
            public decimal? T_NGOAIDS { get; set; }
            public  int? NAM_QT { get; set; }
            public  int? THANG_QT { get; set; }
            public  short? MA_LOAI_KCB { get; set; }
            public  string MA_KHOA { get; set; }
            public  string MA_CSKCB { get; set; }
            public  string MA_KHUVUC { get; set; }
            public  string MA_PTTT_QT { get; set; }
            public  string CAN_NANG { get; set; }
        }

        [Serializable, XmlRoot("DSACH_CHI_TIET_THUOC")]
        //XML2_9324, QD 917
        public class CHI_TIET_THUOC
        {
            public  string MA_LK { get; set; }
            public  int? STT { get; set; }
            public  string MA_THUOC { get; set; }
            public  string MA_NHOM { get; set; }
            public  string TEN_THUOC { get; set; }
            public  string DON_VI_TINH { get; set; }
            public  string HAM_LUONG { get; set; }
            public  string DUONG_DUNG { get; set; }
            public  string LIEU_DUNG { get; set; }
            public  string SO_DANG_KY { get; set; }
            public  decimal? SO_LUONG { get; set; }
            public  decimal? DON_GIA { get; set; }
            public  double? TYLE_TT { get; set; }
            public  decimal? THANH_TIEN { get; set; }
            public  string MA_KHOA { get; set; }
            public  string MA_BAC_SI { get; set; }
            public  string MA_BENH { get; set; }
            public string NGAY_YL { get; set; }
            public  string MA_PTTT { get; set; }
        }

        [Serializable, XmlRoot("DSACH_CHI_TIET_DVKT")]
        //XML3_9324, QD 917
        public class CHI_TIET_DVKT
        {
            public  string MA_LK { get; set; }
            public  int? STT { get; set; }
            public  string MA_DICH_VU { get; set; }
            public  string MA_VAT_TU { get; set; }
            public  string MA_NHOM { get; set; }
            public  string TEN_DICH_VU { get; set; }
            public  string DON_VI_TINH { get; set; }
            public  decimal SO_LUONG { get; set; }
            public decimal DON_GIA { get; set; }
            public  int TYLE_TT { get; set; }
            public decimal THANH_TIEN { get; set; }
            public  string MA_KHOA { get; set; }
            public  string MA_BAC_SI { get; set; }
            public string MA_BENH { get; set; }
            public string NGAY_YL { get; set; }
            public string NGAY_KQ { get; set; }
            public string MA_PTTT { get; set; }

        }
        [Serializable, XmlRoot("DSACH_CHI_TIET_CLS")]
        //XML4_9324, QD 917
        public class CHI_TIET_CLS
        {
            public  string MA_LK { get; set; }
            public  int? STT { get; set; }
            public string MA_DICH_VU { get; set; }
            public string MA_CHI_SO { get; set; }
            public string TEN_CHI_SO { get; set; }
            public string GIA_TRI { get; set; }
            public string MA_MAY { get; set; }
            public string MO_TA { get; set; }
            public string KET_LUAN { get; set; }
            public string NGAY_KQ { get; set; }
        }
        [Serializable, XmlRoot("DSACH_CHI_TIET_DIEN_BIEN_BENH")]
        //XML5_9324, QD 917
        public class CHI_TIET_DIEN_BIEN_BENH
        {
            public  string MA_LK { get; set; }
            public  int? STT { get; set; }
            public string DIEN_BIEN { get; set; }
            public string HOI_CHAN { get; set; }
            public string PHAU_THUAT { get; set; }
            public string NGAY_YL { get; set; }
        }
        public class LichSuKhamBenh
        {
            public string maLK { get; set; }
            public string maHoSo { get; set; }
            public string maCSKCB { get; set; }
            public string tenBenhNhan { get; set; }
            public string diaChi { get; set; }
            public string ngaySinh { get; set; }
            public short gioiTinh { get; set; }
            public string maICD { get; set; }
            public string denNgay { get; set; }
            public string tuNgay { get; set; }
            public short  tinhTrang { get; set; }
            public string tenBenh { get; set; }
            public short ketQua { get; set; }
            public List<xml2> dsThuoc { get; set; }
            public List<xml3> dsDichvu { get; set; }
        }
        public class xml2
        {
            public string soDKThuoc { get; set; }
            public string tenThuoc { get; set; }
        }
        public class xml3
        {
            public string maDichVu { get; set; }
            public string maVatTu { get; set; }
            public string tenDichVu { get; set; }
        }

        #region Giam Dinh HoSo
        public class GIAMDINHHS    //  Gửi hồ sơ giám định (1.2 công văn 917)
        {
            // loại hồ sơ : 3 : KCB
            public THONGTINDONVI THONGTINDONVI { get; set; }
            public THONGTINHOSO THONGTINHOSO { get; set; }

        }
        public class THONGTINDONVI{
            public string MACSKCB { get; set; }
        }
        public class THONGTINHOSO
        {
            public string NGAYLAP { get; set; }
            public int SOLUONGHOSO { get; set; }
            public List<HOSO> DANHSACHHOSO { get; set; }
        }

        //[XmlRootAttribute(ElementName = "TTT")]
        [XmlType(TypeName = "HOSO")]
        public class HOSO : List<FILEHOSO> {
        }

        public class FILEHOSO { 
            public string LOAIHOSO { get; set; }
            public string NOIDUNGFILE { get; set; }
        }
        
        public class KQ_GIAMDINH
        {
            public string maKetQua { get; set; }
            public string maGiaoDich { get; set; } // luu lai mã này để sử dụng cho mục đích tìm kiếm sau này
        }
        #endregion
    }
}
