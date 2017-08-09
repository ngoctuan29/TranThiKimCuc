using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Security.Cryptography;
using System.Globalization;
using Newtonsoft.Json;
using System.Net.Http;

namespace iHISPortalBHYT
{
    public class FuncPortalBHYT
    {
        private readonly string httpGetToken = @"http://egw.baohiemxahoi.gov.vn/api/token/take";
        private readonly string httpLichSuKCB = @"http://egw.baohiemxahoi.gov.vn/api/egw/nhanLichSuKCB?token={0}&id_token={1}&username={2}&password={3}";
        private readonly string httpNhanHoSoKCBChiTiet = @"http://egw.baohiemxahoi.gov.vn/api/egw/nhanHoSoKCBChiTiet?token={0}&id_token={1}&username={2}&password={3}&maHoSo={4}";
        
        #region Tai khoan test
        //string json = @"{"username":79024_BV,"password":Bvnd115@22789}"; // BV 115
        //string json = @"{"username":79514_BV,"password":pktt@4423}"; // PK TanTao
        //string json = @"{"username":74163_TC,"password":1qaz2wsx2016}"; // PK PAK
        #endregion

        #region Lay lich su KCB cua benh nhan
        public ModelGDBHYT.ResultHistoryExaminationPatient GetHistoryExaminationPatient(ModelGDBHYT.QueryParameterHistoryExaminationPatient dataquery, ModelGDBHYT.DataHistoryExaminationPatient data)
        {
            ModelGDBHYT.ResultHistoryExaminationPatient result = new ModelGDBHYT.ResultHistoryExaminationPatient();
            try
            {                
                ModelGDBHYT.ResultGetToken token = GetToken(dataquery.userName, dataquery.passWord);
                if (token.APIKey != null)
                {
                    if (token.APIKey.username != dataquery.userName)
                    {
                        result.maKetQua = "900"; //  báo lỗi get sai token 
                        return result;
                    }
                    string url = string.Format(this.httpLichSuKCB, token.APIKey.access_token, token.APIKey.id_token, dataquery.userName, Common.MD5Encode(dataquery.passWord));

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.Timeout = 165000;
                    httpWebRequest.ContentType = "application/json; charset=utf-8";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string jsonstr = new JavaScriptSerializer().Serialize(data);
                        streamWriter.Write(jsonstr);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        JavaScriptSerializer javaScript = new JavaScriptSerializer();
                        result = javaScript.Deserialize<ModelGDBHYT.ResultHistoryExaminationPatient>(streamReader.ReadToEnd());
                    }
                }
                else
                {
                    result.maKetQua = "999"; // báo lỗi time out hoặc sai định dạng nhận dữ liệu do cấu trúc ResultHistoryExaminationPatient
                }
            }
            catch
            { }
            return result;
        }

        public ModelGDBHYT.ResultHistoryExaminationPatientDetail GetHistoryExaminationPatientDetail(ModelGDBHYT.QueryParameterHistoryExaminationPatientDetail dataquery)
        {
            ModelGDBHYT.ResultHistoryExaminationPatientDetail result = new ModelGDBHYT.ResultHistoryExaminationPatientDetail();
            try
            {
                if (dataquery != null && !string.IsNullOrEmpty(dataquery.maHoSo))
                {
                    ModelGDBHYT.ResultGetToken token = GetToken(dataquery.userName, dataquery.passWord);
                    if (token.APIKey != null)
                    {
                        if (token.APIKey.username != dataquery.userName)
                        {
                            result.maKetQua = "900"; //  báo lỗi get sai token 
                            return result;
                        }
                        string url = string.Format(this.httpNhanHoSoKCBChiTiet, token.APIKey.access_token, token.APIKey.id_token, dataquery.userName, Common.MD5Encode(dataquery.passWord), dataquery.maHoSo);
                        //int leng = url.Length;// chõ này test xem leng bao nhiêu mà bị báo lỗi Length Required khi get response
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                        httpWebRequest.Timeout = 165000;
                        httpWebRequest.ContentLength = 0;
                        httpWebRequest.ContentType = "application/json; charset=utf-8";
                        httpWebRequest.Method = "POST";
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            // string strstream = streamReader.ReadToEnd().ToString(); // chỗ này để test, khi nào chạy thật thì xóa sau
                            JavaScriptSerializer javaScript = new JavaScriptSerializer();
                            result = javaScript.Deserialize<ModelGDBHYT.ResultHistoryExaminationPatientDetail>(streamReader.ReadToEnd());
                        }
                    }
                    else
                    {
                        result.maKetQua = "999"; // báo lỗi time out hoặc sai định dạng nhận dữ liệu do cấu trúc ResultHistoryExaminationPatient
                    }
                }
            }
            catch
            { }
            return result;
        }

        public List<ModelGDBHYT.LichSuKhamBenh> GetDataViewLichSuKhamBenh(string userName, string passWord, ModelGDBHYT.DataHistoryExaminationPatient dataTheBHYT)
        {
            List<ModelGDBHYT.LichSuKhamBenh> dsLichSuKCB = new List<ModelGDBHYT.LichSuKhamBenh>();
            ModelGDBHYT.QueryParameterHistoryExaminationPatientDetail dataquerydetail = new ModelGDBHYT.QueryParameterHistoryExaminationPatientDetail();
            ModelGDBHYT.QueryParameterHistoryExaminationPatient dataquery = new ModelGDBHYT.QueryParameterHistoryExaminationPatient();
            dataquery.userName = userName;
            dataquery.passWord = passWord;
            dataquerydetail.userName = userName;
            dataquerydetail.passWord = passWord;
            if (dsLichSuKCB.Count > 0)
                dsLichSuKCB.Clear();
            ModelGDBHYT.ResultHistoryExaminationPatient datahistory = GetHistoryExaminationPatient(dataquery, dataTheBHYT);
            if (datahistory.dsLichSuKCB != null)
            {
                List<ModelGDBHYT.ResultHistoryExaminationPatientDetail> list = new List<ModelGDBHYT.ResultHistoryExaminationPatientDetail>();
                foreach (var item in datahistory.dsLichSuKCB)
                {
                    ModelGDBHYT.LichSuKhamBenh lichSuKCB = new ModelGDBHYT.LichSuKhamBenh();
                    lichSuKCB.denNgay = item.denNgay;
                    lichSuKCB.tinhTrang = (short)int.Parse(item.tinhTrang);
                    lichSuKCB.maHoSo = item.maHoSo;
                    lichSuKCB.maCSKCB = item.maCSKCB;
                    lichSuKCB.maHoSo = item.maHoSo;
                    lichSuKCB.tuNgay = item.tuNgay;
                    dataquerydetail.maHoSo = item.maHoSo;
                    ModelGDBHYT.ResultHistoryExaminationPatientDetail data = new ModelGDBHYT.ResultHistoryExaminationPatientDetail();
                    data = GetHistoryExaminationPatientDetail(dataquerydetail);
                    if (data.hoSoKCB != null)
                    {
                        lichSuKCB.tenBenhNhan = data.hoSoKCB.xml1.HO_TEN;
                        lichSuKCB.maICD = data.hoSoKCB.xml1.MA_BENH;
                        lichSuKCB.maLK = data.hoSoKCB.xml1.MA_LK;
                        lichSuKCB.ketQua = data.hoSoKCB.xml1.KET_QUA_DTRI ?? 1;
                        lichSuKCB.tinhTrang = data.hoSoKCB.xml1.TINH_TRANG_RV ?? 1;
                        lichSuKCB.gioiTinh = data.hoSoKCB.xml1.GIOI_TINH ?? 1;
                        lichSuKCB.ngaySinh = data.hoSoKCB.xml1.NGAY_SINH;
                        lichSuKCB.tenBenh = data.hoSoKCB.xml1.TEN_BENH + "(" + data.hoSoKCB.xml1.MA_BENH + ")" + (string.IsNullOrEmpty(data.hoSoKCB.xml1.MA_BENHKHAC) ? "" : ";" + data.hoSoKCB.xml1.MA_BENHKHAC);
                        lichSuKCB.diaChi = data.hoSoKCB.xml1.DIA_CHI;
                        if (data.hoSoKCB.dsXml2 != null)
                        {
                            List<ModelGDBHYT.xml2> lstxml2 = new List<ModelGDBHYT.xml2>();
                            foreach (var itemxml2 in data.hoSoKCB.dsXml2)
                            {
                                ModelGDBHYT.xml2 xml2 = new ModelGDBHYT.xml2();
                                xml2.soDKThuoc = itemxml2.SO_DANG_KY;
                                xml2.tenThuoc = itemxml2.TEN_THUOC;
                                lstxml2.Add(xml2);
                            }
                            lichSuKCB.dsThuoc = lstxml2;
                        }
                        if (data.hoSoKCB.dsXml3 != null)
                        {
                            List<ModelGDBHYT.xml3> lstxml3 = new List<ModelGDBHYT.xml3>();
                            foreach (var itemxml3 in data.hoSoKCB.dsXml3)
                            {
                                ModelGDBHYT.xml3 xml3 = new ModelGDBHYT.xml3();
                                xml3.maDichVu = itemxml3.MA_DICH_VU;
                                xml3.maVatTu = itemxml3.MA_VAT_TU;
                                xml3.tenDichVu = itemxml3.TEN_DICH_VU;
                                lstxml3.Add(xml3);

                            }
                            lichSuKCB.dsDichvu = lstxml3;
                        }
                    }
                    dsLichSuKCB.Add(lichSuKCB);
                }
            }
            return dsLichSuKCB;
        }

        #endregion

        #region Kiem tra the BHYT
        public ModelGDBHYT.ResultCheckTheBHYT CheckTheBHYT(string userNameTC,string passWordTC, ModelGDBHYT.DataHistoryExaminationPatient dataTheBHYT)
        {
            ModelGDBHYT.ResultCheckTheBHYT value = new ModelGDBHYT.ResultCheckTheBHYT();
            ModelGDBHYT.QueryParameterHistoryExaminationPatient dataquery = new ModelGDBHYT.QueryParameterHistoryExaminationPatient();
            dataquery.userName = userNameTC;
            dataquery.passWord = passWordTC;
            try
            {
                var result = GetHistoryExaminationPatient(dataquery, dataTheBHYT);
                if (result.maKetQua != null)
                {
                    if (result.maKetQua.Equals("00"))
                    {
                        value.maKetQua = "00";
                        value.ketQua = "Thẻ chính xác";
                    }
                    else if (result.maKetQua.Equals("01"))
                    {
                        value.maKetQua = "01";
                        value.ketQua = "Thẻ hết giá trị sử dụng";
                    }
                    else if (result.maKetQua.Equals("02"))
                    {
                        value.maKetQua = "02";
                        value.ketQua = "Thẻ chưa đến thời gian sử dụng";
                    }
                    else if (result.maKetQua.Equals("03"))
                    {
                        value.maKetQua = "03";
                        value.ketQua = "Thẻ hết hạn khi chưa ra viện";
                    }
                    else if (result.maKetQua.Equals("04"))
                    {
                        value.maKetQua = "04";
                        value.ketQua = "Thẻ có giá trị khi đang nằm viện";
                    }
                    else if (result.maKetQua.Equals("05"))
                    {
                        value.maKetQua = "05";
                        value.ketQua = "Mã thẻ không có trong dữ liệu thẻ";
                    }
                    else if (result.maKetQua.Equals("06"))
                    {
                        value.maKetQua = "06";
                        value.ketQua = "Thẻ sai họ tên";
                    }
                    else if (result.maKetQua.Equals("07"))
                    {
                        value.maKetQua = "07";
                        value.ketQua = "Thẻ sai ngày sinh";
                    }
                    else if (result.maKetQua.Equals("08"))
                    {
                        value.maKetQua = "08";
                        value.ketQua = "Thẻ sai giới tính";
                    }
                    else if (result.maKetQua.Equals("09"))
                    {
                        value.maKetQua = "09";
                        value.ketQua = "Thẻ sai nơi khám chữa bệnh ban đầu";
                    }
                }
                else
                {
                    value.maKetQua = "10";
                    value.ketQua = "Lỗi gửi thông tin check thẻ BHYT";
                }
            }
            catch(Exception ex)
            {
                value.maKetQua = "10";
                value.ketQua = "Error: " + ex.Message;
            }
            return value;
        }
        #endregion

        #region Hàm lấy phiên làm việc
        public ModelGDBHYT.ResultGetToken GetToken(string userName, string passWord)
        {
            ModelGDBHYT.ResultGetToken result = new ModelGDBHYT.ResultGetToken() ;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(this.httpGetToken);
                httpWebRequest.ContentType = "application/json;charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    ModelGDBHYT.APIToken json = new ModelGDBHYT.APIToken();
                    json.username = userName;
                    json.password = Common.MD5Encode(passWord);
                    string jsonstr = new JavaScriptSerializer().Serialize(json);
                    streamWriter.Write(jsonstr);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    JavaScriptSerializer javaScript = new JavaScriptSerializer();
                    result = javaScript.Deserialize<ModelGDBHYT.ResultGetToken>(streamReader.ReadToEnd());
                }
            }
            catch
            { }
            return result;
        }
        #endregion

        #region Ham gửi hồ sơ giám định
        public void SendFile_GDBHXH(string userName, string passWord, string matinh, string maCSKCB, byte[] buffer, ref string result)
        {
            try
            {
                string httpGuiHS_GDBHXH = @"api/egw/guiHoSoGiamDinh?token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}";
                ModelGDBHYT.ResultGetToken token = GetToken(userName, passWord);
                if (token.APIKey != null)
                {
                    if (token.APIKey.username != userName)
                    {
                        result = "Token không hợp lệ!";
                    }
                    string urldata = string.Format(httpGuiHS_GDBHXH, token.APIKey.access_token, token.APIKey.id_token, userName, Common.MD5Encode(passWord), 3, matinh, maCSKCB);
                    #region Net Framework 4.5
                    //using (var clientPost = new System.Net.Http.HttpClient())
                    //{
                    //    clientPost.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                    //    clientPost.DefaultRequestHeaders.Accept.Clear();
                    //    clientPost.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //    clientPost.MaxResponseContentBufferSize = 2000005000;
                    //    HttpResponseMessage respone = clientPost.PostAsJsonAsync(urldata, buffer).Result;
                    //}
                    #endregion

                    #region Net Framework 4.0
                    using (var clientPost = new System.Net.Http.HttpClient())
                    {
                        clientPost.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                        clientPost.DefaultRequestHeaders.Accept.Clear();
                        clientPost.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        clientPost.MaxResponseContentBufferSize = 2000005000;
                        //HttpResponseMessage respone = clientPost.PostAsJsonAsync(urldata, buffer).Result;
                        var response = clientPost.PostAsync(urldata, new StringContent(new JavaScriptSerializer().Serialize(buffer), Encoding.UTF8, "application/json")).Result;
                    }
                    #endregion

                }
                else
                {
                    result = "Token null";
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }            
        }
        #endregion
    }
}
