using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using iHISPortalBHYT;
using DevExpress.XtraSplashScreen;

namespace Ps.Clinic.Entry
{
    public partial class frmUploadHSGDBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty;
        private OpenFileDialog openXML1 = new OpenFileDialog();
        private OpenFileDialog openXML2 = new OpenFileDialog();
        private OpenFileDialog openXML3 = new OpenFileDialog();
        private OpenFileDialog openXML4 = new OpenFileDialog();
        private OpenFileDialog openXML5 = new OpenFileDialog();
        private FolderBrowserDialog browser = new FolderBrowserDialog();
        
        private DateTime dtimeServer = new DateTime();
        private string userName_BV = string.Empty, passWord_BV = string.Empty, maCSKCB = string.Empty;
        private string pathFileXML_GDBHXH = string.Empty, pathExportFileXML = string.Empty;
        private string matinh = string.Empty;
        public bool isSendFileResult = false;

        public frmUploadHSGDBHYT(string _employeeCode, string _pathExportFileXML)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.pathExportFileXML = _pathExportFileXML;
        }
        private void frmUploadHSGDBHYT_Load(object sender, EventArgs e)
        {
            try
            {
                this.openXML1.FileOk += openXML1_FileOk;
                this.openXML2.FileOk += openXML2_FileOk;
                this.openXML3.FileOk += openXML3_FileOk;
                this.openXML4.FileOk += openXML4_FileOk;
                this.openXML5.FileOk += openXML5_FileOk;

                this.dtimeServer = ClinicLibrary.Utils.DateTimeServer();
                ClinicInformationInf hisInfo = ClinicInformationBLL.ObjInformation(1);
                if (hisInfo != null && hisInfo.ClinicCode > 0)
                {
                    this.userName_BV = hisInfo.UserName_BV;
                    this.passWord_BV = hisInfo.PassWord_BV;
                    this.matinh = hisInfo.Province;
                    this.maCSKCB = hisInfo.KCBBDCode.Replace("-", "");
                }
                if (File.Exists(this.pathExportFileXML + "\\XML1.xml"))
                    this.txtPathXML1.Text = this.pathExportFileXML + "\\XML1.xml";
                if (File.Exists(this.pathExportFileXML + "\\XML2.xml"))
                    this.txtPathXML2.Text = this.pathExportFileXML + "\\XML2.xml";
                if (File.Exists(this.pathExportFileXML + "\\XML3.xml"))
                    this.txtPathXML3.Text = this.pathExportFileXML + "\\XML3.xml";
                if (File.Exists(this.pathExportFileXML + "\\XML4.xml"))
                    this.txtPathXML4.Text = this.pathExportFileXML + "\\XML4.xml";
                if (File.Exists(this.pathExportFileXML + "\\XML5.xml"))
                    this.txtPathXML5.Text = this.pathExportFileXML + "\\XML5.xml";
                this.txtPathSaveFile.Text = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\xml_9324";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS-Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void butCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openXML1_FileOk(object sender, CancelEventArgs e)
        {
            this.txtPathXML1.Text = this.openXML1.FileName;            
            //this.gridControl_ListPatient.DataSource = this.tablePatientList;
        }
        private void openXML2_FileOk(object sender, CancelEventArgs e)
        {
            this.txtPathXML2.Text = this.openXML2.FileName;
        }
        private void openXML3_FileOk(object sender, CancelEventArgs e)
        {
            this.txtPathXML3.Text = this.openXML3.FileName;
        }
        private void openXML4_FileOk(object sender, CancelEventArgs e)
        {
            this.txtPathXML4.Text = this.openXML4.FileName;
        }
        private void openXML5_FileOk(object sender, CancelEventArgs e)
        {
            this.txtPathXML5.Text = this.openXML5.FileName;
        }
        private void butPathXML1_Click(object sender, EventArgs e)
        {
            this.openXML1.ShowHelp = true;
            this.openXML1.FileName = string.Empty;
            //this.openXML1.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            this.openXML1.Filter = "XML Files|*.xml";
            this.openXML1.ShowDialog();
        }

        private void butPathXML2_Click(object sender, EventArgs e)
        {
            this.openXML2.ShowHelp = true;
            this.openXML2.FileName = string.Empty;
            this.openXML2.Filter = "XML Files|*.xml";
            this.openXML2.ShowDialog();
        }

        private void butPathXML3_Click(object sender, EventArgs e)
        {
            this.openXML3.ShowHelp = true;
            this.openXML3.FileName = string.Empty;
            this.openXML3.Filter = "XML Files|*.xml";
            this.openXML3.ShowDialog();
        }

        private void butPathXML4_Click(object sender, EventArgs e)
        {
            this.openXML4.ShowHelp = true;
            this.openXML4.FileName = string.Empty;
            this.openXML4.Filter = "XML Files|*.xml";
            this.openXML4.ShowDialog();
        }

        private void butPathXML5_Click(object sender, EventArgs e)
        {
            this.openXML5.ShowHelp = true;
            this.openXML5.FileName = string.Empty;
            this.openXML5.Filter = "XML Files|*.xml";
            this.openXML5.ShowDialog();
        }

        private void butPathSaveFile_Click(object sender, EventArgs e)
        {
            if (this.browser.ShowDialog() == DialogResult.OK)
            {
                this.txtPathSaveFile.Text = browser.SelectedPath;
            }
        }

        private void btnCheckFile_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadWaiting();
                string msg = string.Empty;
                this.btnSendFile.Enabled = false;
                this.pathFileXML_GDBHXH = string.Empty;
                this.pnResult.Controls.Clear();
                DataSet dsxml1 = new DataSet("FileXML1");
                DataSet dsxml2 = new DataSet("FileXML2");
                DataSet dsxml3 = new DataSet("FileXML3");
                DataSet dsxml4 = new DataSet("FileXML4");
                DataSet dsxml5 = new DataSet("FileXML5");
                decimal totalAmountXML1 = 0, totalAmountXML2 = 0, totalAmountXML3 = 0;
                if (!string.IsNullOrEmpty(this.txtPathXML1.Text))
                    dsxml1.ReadXml(this.txtPathXML1.Text);
                if (!string.IsNullOrEmpty(this.txtPathXML2.Text))
                    dsxml2.ReadXml(this.txtPathXML2.Text);
                if (!string.IsNullOrEmpty(this.txtPathXML3.Text))
                    dsxml3.ReadXml(this.txtPathXML3.Text);
                if (!string.IsNullOrEmpty(this.txtPathXML4.Text))
                    dsxml4.ReadXml(this.txtPathXML4.Text);
                if (!string.IsNullOrEmpty(this.txtPathXML5.Text))
                    dsxml5.ReadXml(this.txtPathXML5.Text);
                #region Check data file
                if (dsxml1 != null && dsxml1.Tables[0].Rows.Count > 0)
                {
                    bool isresult = true;
                    List<ModelGDBHYT.HOSO> lstHS = new List<ModelGDBHYT.HOSO>();
                    foreach (DataRow row1 in dsxml1.Tables[0].Rows)
                    {
                        ModelGDBHYT.HOSO hoso = new ModelGDBHYT.HOSO();
                        hoso.Add(this.FileHS_XML1(row1));

                        totalAmountXML1 = Convert.ToDecimal(row1["T_TONGCHI"]);
                        string ma_lk = "'" + row1["MA_LK"].ToString() + "'";
                        totalAmountXML2 = totalAmountXML3 = 0;
                        if (dsxml2 != null && dsxml2.Tables.Count > 0)
                        {
                            if (dsxml2.Tables[0].Select("MA_LK=" + ma_lk).Length > 0)
                            {
                                foreach (DataRow row2 in dsxml2.Tables[0].Select("MA_LK=" + ma_lk).CopyToDataTable().Rows)
                                {
                                    totalAmountXML2 += Convert.ToDecimal(row2["SO_LUONG"]) * Convert.ToDecimal(row2["DON_GIA"]); //Convert.ToDecimal(row2["THANH_TIEN"]);
                                }
                                /// Convert base 64 file xml2
                                hoso.Add(this.FileHS_XML2(dsxml2.Tables[0].Select("MA_LK=" + ma_lk).CopyToDataTable()));
                            }
                        }
                        if (dsxml3 != null && dsxml3.Tables.Count > 0)
                        {
                            if (dsxml3.Tables[0].Select("MA_LK=" + ma_lk).Length > 0)
                            {
                                foreach (DataRow row3 in dsxml3.Tables[0].Select("MA_LK=" + ma_lk).CopyToDataTable().Rows)
                                {
                                    totalAmountXML3 += Convert.ToDecimal(row3["SO_LUONG"]) * Convert.ToDecimal(row3["DON_GIA"]); //Convert.ToDecimal(row3["THANH_TIEN"]);
                                }
                                /// Convert base 64 file xml3
                                hoso.Add(this.FileHS_XML3(dsxml3.Tables[0].Select("MA_LK=" + ma_lk).CopyToDataTable()));
                            }
                        }
                        if (dsxml4 != null && dsxml4.Tables.Count > 0)
                        {
                            if (dsxml4.Tables[0].Select("MA_LK=" + ma_lk).Length > 0)
                            {
                                /// Convert base 64 file xml4
                                hoso.Add(this.FileHS_XML4(dsxml4.Tables[0].Select("MA_LK=" + ma_lk).CopyToDataTable()));
                            }
                        }
                        if (dsxml5 != null && dsxml5.Tables.Count > 0)
                        {
                            if (dsxml5.Tables[0].Select("MA_LK=" + ma_lk).Length > 0)
                            {
                                /// Convert base 64 file xml5
                                hoso.Add(this.FileHS_XML5(dsxml5.Tables[0].Select("MA_LK=" + ma_lk).CopyToDataTable()));
                            }
                        }
                        if (!totalAmountXML1.Equals(totalAmountXML2 + totalAmountXML3))
                        {
                            msg = "Mã hồ sơ: " + ma_lk + " - T.Tiền file XML1(" + totalAmountXML1.ToString("N0") + ") khác với T.Tiền file XML2(" + totalAmountXML2.ToString("N0") + ") + T.Tiền file XML3(" + totalAmountXML3.ToString("N0") + ")";
                            this.AddControlMsg(msg, true);
                            isresult = false;
                        }
                        lstHS.Add(hoso);
                    }
                    if (isresult)
                    {
                        this.btnSendFile.Enabled = true;
                        this.CreateFileXMLBase64_GDBHXH(lstHS);
                        msg = "Dữ liệu trong file XML1,XML2,XML3 hợp lệ! Bạn hãy click 'Gửi HS giám định' để upload file lên cổng giám định BHXH.";
                        this.AddControlMsg(msg, false);
                    }
                }
                else
                {
                    msg = "Dữ liệu trong file XML1 không phát sinh chi phí khám chữa bệnh.";
                    this.AddControlMsg(msg, true);
                }
                #endregion
                this.CloseWaiting();
            }
            catch (Exception ex)
            {
                this.CloseWaiting();
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS-Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void AddControlMsg(string msg, bool isError)
        {
            int y = 0, x = 5;
            Label lbresult = new Label();
            lbresult.Text = msg;
            if (!isError)
                lbresult.ForeColor = Color.Blue;
            else
                lbresult.ForeColor = Color.Red;
            lbresult.AutoSize = true;
            lbresult.Font = new Font("Arial", 8, FontStyle.Regular);
            foreach (Control control in pnResult.Controls)
            {
                if(control is Label)
                {
                    y += control.Height;
                }
            }
            lbresult.Location = new Point(x, y);
            this.pnResult.Controls.Add(lbresult);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnResult.Controls.Clear();
                this.LoadWaiting();
                if (ClinicLibrary.Utils.CheckConnectInternet())
                {
                    FileInfo file = new FileInfo(this.pathFileXML_GDBHXH);
                    iHISPortalBHYT.FuncPortalBHYT portal = new iHISPortalBHYT.FuncPortalBHYT();
                    byte[] buffer = null;
                    if (file != null && file.Length > 0)
                    {
                        using (FileStream fs = file.OpenRead())
                        {
                            using (var memory = new MemoryStream())
                            {
                                fs.CopyTo(memory);
                                buffer = memory.ToArray();
                            }
                        }
                        string result = string.Empty;
                        portal.SendFile_GDBHXH(this.userName_BV, this.passWord_BV, this.matinh, this.maCSKCB, buffer, ref result);
                        if (string.IsNullOrEmpty(result))
                        {
                            this.isSendFileResult = true;
                            this.AddControlMsg("Gửi hồ sơ giám định thành công.", true);
                        }
                        else
                            this.AddControlMsg(result, true);
                    }
                }
                else
                    this.AddControlMsg("Không có kết nối internet! \n\r Vui lòng kết nối Interner để upload hồ sơ giám định BHXH.", true);
                this.CloseWaiting();
            }
            catch (Exception ex)
            {
                this.CloseWaiting();
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS-Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void picClearResult_Click(object sender, EventArgs e)
        {
            this.pnResult.Controls.Clear();
        }

        private void CreateFileXMLBase64_GDBHXH(List<ModelGDBHYT.HOSO> lstHS)
        {

            ModelGDBHYT.GIAMDINHHS hsgd = new ModelGDBHYT.GIAMDINHHS();
            #region Thong Tin Don Vi
            ModelGDBHYT.THONGTINDONVI donvi = new ModelGDBHYT.THONGTINDONVI { MACSKCB = this.maCSKCB };//ma cs KCB
            #endregion

            #region  Thong Tin Ho So

            ModelGDBHYT.THONGTINHOSO thongtinHS = new ModelGDBHYT.THONGTINHOSO();
            thongtinHS.NGAYLAP = this.dtimeServer.ToString("yyyyMMdd");
            thongtinHS.SOLUONGHOSO = lstHS.Count;
            thongtinHS.DANHSACHHOSO = lstHS;

            hsgd.THONGTINDONVI = donvi;
            hsgd.THONGTINHOSO = thongtinHS;
            string pathSave_XML = this.txtPathSaveFile.Text + "\\"+ this.dtimeServer.ToString("yyyyMMdd");
            if (!Directory.Exists(pathSave_XML))
                Directory.CreateDirectory(pathSave_XML);
            this.pathFileXML_GDBHXH = pathSave_XML + "\\" + "KCB" + this.maCSKCB + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            iHISPortalBHYT.Common.WriteToXmlFile(this.pathFileXML_GDBHXH, "GIAMDINHHS", hsgd, false);
            #endregion

        }
        
        private ModelGDBHYT.FILEHOSO FileHS_XML1(DataRow row)
        {
            ModelGDBHYT.TONG_HOP xml1 = new ModelGDBHYT.TONG_HOP();
            xml1.MA_LK = row["MA_LK"].ToString();
            xml1.STT = Convert.ToInt32(row["STT"].ToString());
            xml1.MA_BN = row["MA_BN"].ToString();
            xml1.HO_TEN = row["HO_TEN"].ToString();
            xml1.NGAY_SINH = row["NGAY_SINH"].ToString();
            xml1.GIOI_TINH = Convert.ToInt16(row["GIOI_TINH"].ToString());
            xml1.DIA_CHI = row["DIA_CHI"].ToString();
            xml1.MA_THE = row["MA_THE"].ToString();
            xml1.MA_DKBD = row["MA_DKBD"].ToString();
            xml1.GT_THE_TU = row["GT_THE_TU"].ToString();
            xml1.GT_THE_DEN = row["GT_THE_DEN"].ToString();
            xml1.TEN_BENH = row["TEN_BENH"].ToString();
            xml1.MA_BENH = row["MA_BENH"].ToString();
            xml1.MA_BENHKHAC = row["MA_BENHKHAC"].ToString();
            xml1.MA_LYDO_VVIEN = Convert.ToInt16(row["MA_LYDO_VVIEN"].ToString());
            xml1.MA_NOI_CHUYEN = row["MA_NOI_CHUYEN"].ToString();
            xml1.MA_TAI_NAN = row["MA_TAI_NAN"].ToString();
            xml1.NGAY_VAO = row["NGAY_VAO"].ToString();
            xml1.NGAY_RA = row["NGAY_RA"].ToString();
            xml1.SO_NGAY_DTRI = Convert.ToInt32(row["SO_NGAY_DTRI"].ToString());
            xml1.KET_QUA_DTRI = Convert.ToInt16(row["KET_QUA_DTRI"].ToString());
            xml1.TINH_TRANG_RV = Convert.ToInt16(row["TINH_TRANG_RV"].ToString());
            xml1.NGAY_TTOAN = row["NGAY_TTOAN"].ToString();
            xml1.MUC_HUONG = Convert.ToInt32(row["MUC_HUONG"].ToString());
            xml1.T_THUOC = Convert.ToDecimal(row["T_THUOC"].ToString());
            xml1.T_VTYT = Convert.ToDecimal(row["T_VTYT"].ToString());
            xml1.T_TONGCHI = Convert.ToDecimal(row["T_TONGCHI"].ToString());
            xml1.T_BNTT = Convert.ToDecimal(row["T_BNTT"].ToString());
            xml1.T_BHTT = Convert.ToDecimal(row["T_BHTT"].ToString());
            xml1.T_NGUONKHAC = Convert.ToDecimal(row["T_NGUONKHAC"].ToString());
            xml1.T_NGOAIDS = Convert.ToDecimal(row["T_NGOAIDS"].ToString());
            xml1.NAM_QT = Convert.ToInt32(row["NAM_QT"].ToString());
            xml1.THANG_QT = Convert.ToInt32(row["THANG_QT"].ToString());
            xml1.MA_LOAI_KCB = Convert.ToInt16(row["MA_LOAI_KCB"].ToString());
            xml1.MA_KHOA = row["MA_KHOA"].ToString();
            xml1.MA_CSKCB = row["MA_CSKCB"].ToString();
            xml1.MA_KHUVUC = row["MA_KHUVUC"].ToString();
            xml1.MA_PTTT_QT = row["MA_PTTT_QT"].ToString();
            if (!string.IsNullOrEmpty(row["CAN_NANG"].ToString()))
                xml1.CAN_NANG = Convert.ToDouble(row["CAN_NANG"].ToString()).ToString("N0");
            else
                xml1.CAN_NANG = string.Empty;
            string xmlString = iHISPortalBHYT.Common.ConvertObjectToXMLString(xml1, "TONG_HOP");
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var contentBase64 = Convert.ToBase64String(bytes);
            ModelGDBHYT.FILEHOSO hoso = new ModelGDBHYT.FILEHOSO { LOAIHOSO = "XML1", NOIDUNGFILE = contentBase64 };
            return hoso;
        }
        private ModelGDBHYT.FILEHOSO FileHS_XML2(DataTable dtFile)
        {
            List<ModelGDBHYT.CHI_TIET_THUOC> lstXML2 = new List<ModelGDBHYT.CHI_TIET_THUOC>();
            ModelGDBHYT.CHI_TIET_THUOC xml2 = new ModelGDBHYT.CHI_TIET_THUOC();
            if (dtFile == null || dtFile.Rows.Count <= 0)
                return null;
            foreach (DataRow row in dtFile.Rows)
            {
                xml2.MA_LK = row["MA_LK"].ToString();
                xml2.STT = Convert.ToInt32(row["STT"].ToString());
                xml2.MA_THUOC = row["MA_THUOC"].ToString();
                xml2.MA_NHOM = row["MA_NHOM"].ToString();
                xml2.TEN_THUOC = row["TEN_THUOC"].ToString();
                xml2.DON_VI_TINH = row["DON_VI_TINH"].ToString();
                xml2.HAM_LUONG = row["HAM_LUONG"].ToString();
                xml2.DUONG_DUNG = row["DUONG_DUNG"].ToString();
                xml2.LIEU_DUNG = row["LIEU_DUNG"].ToString();
                xml2.SO_DANG_KY = row["SO_DANG_KY"].ToString();
                xml2.SO_LUONG = Convert.ToDecimal(row["SO_LUONG"].ToString());
                xml2.DON_GIA = Convert.ToDecimal(row["DON_GIA"].ToString());
                xml2.TYLE_TT = Convert.ToInt32(row["TYLE_TT"].ToString());
                xml2.THANH_TIEN = Convert.ToDecimal(row["THANH_TIEN"].ToString());
                xml2.MA_KHOA = row["MA_KHOA"].ToString();
                xml2.MA_BAC_SI = row["MA_BAC_SI"].ToString();
                xml2.MA_BENH = row["MA_BENH"].ToString();
                xml2.NGAY_YL = row["NGAY_YL"].ToString();
                xml2.MA_PTTT = row["MA_PTTT"].ToString();
                lstXML2.Add(xml2);
            }
            string xmlString = iHISPortalBHYT.Common.ConvertObjectToXMLString(lstXML2, "DSACH_CHI_TIET_THUOC");
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var contentBase64 = Convert.ToBase64String(bytes);

            ModelGDBHYT.FILEHOSO hoso = new ModelGDBHYT.FILEHOSO { LOAIHOSO = "XML2", NOIDUNGFILE = contentBase64 };
            return hoso;
        }
        private ModelGDBHYT.FILEHOSO FileHS_XML3(DataTable dtFile)
        {
            List<ModelGDBHYT.CHI_TIET_DVKT> lstXML3 = new List<ModelGDBHYT.CHI_TIET_DVKT>();
            ModelGDBHYT.CHI_TIET_DVKT xml3 = new ModelGDBHYT.CHI_TIET_DVKT();
            if (dtFile == null || dtFile.Rows.Count <= 0)
                return null;
            foreach (DataRow row in dtFile.Rows)
            {
                xml3.MA_LK = row["MA_LK"].ToString();
                xml3.STT = Convert.ToInt32(row["STT"].ToString());
                xml3.MA_DICH_VU = row["MA_DICH_VU"].ToString();
                xml3.MA_VAT_TU = row["MA_VAT_TU"].ToString();
                xml3.MA_NHOM = row["MA_NHOM"].ToString();
                xml3.TEN_DICH_VU = row["TEN_DICH_VU"].ToString();
                xml3.DON_VI_TINH = row["DON_VI_TINH"].ToString();
                xml3.SO_LUONG = Convert.ToDecimal(row["SO_LUONG"].ToString());
                xml3.DON_GIA = Convert.ToDecimal(row["DON_GIA"].ToString());
                xml3.TYLE_TT = Convert.ToInt32(row["TYLE_TT"].ToString());
                xml3.THANH_TIEN = Convert.ToDecimal(row["THANH_TIEN"].ToString());
                xml3.MA_KHOA = row["MA_KHOA"].ToString();
                xml3.MA_BAC_SI = row["MA_BAC_SI"].ToString();
                xml3.MA_BENH = row["MA_BENH"].ToString();
                xml3.NGAY_YL = row["NGAY_YL"].ToString();
                xml3.NGAY_KQ = row["NGAY_KQ"].ToString();
                xml3.MA_PTTT = row["MA_PTTT"].ToString();
                lstXML3.Add(xml3);
            }
            string xmlString = iHISPortalBHYT.Common.ConvertObjectToXMLString(lstXML3, "DSACH_CHI_TIET_DVKT");
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var contentBase64 = Convert.ToBase64String(bytes);
            ModelGDBHYT.FILEHOSO hoso = new ModelGDBHYT.FILEHOSO { LOAIHOSO = "XML3", NOIDUNGFILE = contentBase64 };
            return hoso;
        }
        private ModelGDBHYT.FILEHOSO FileHS_XML4(DataTable dtFile)
        {
            List<ModelGDBHYT.CHI_TIET_CLS> lstXML4 = new List<ModelGDBHYT.CHI_TIET_CLS>();
            ModelGDBHYT.CHI_TIET_CLS xml4 = new ModelGDBHYT.CHI_TIET_CLS();
            if (dtFile == null || dtFile.Rows.Count <= 0)
                return null;
            foreach (DataRow row in dtFile.Rows)
            {
                xml4.MA_LK = row["MA_LK"].ToString();
                xml4.STT = Convert.ToInt32(row["STT"].ToString());
                xml4.MA_DICH_VU = row["MA_DICH_VU"].ToString();
                xml4.MA_CHI_SO = row["MA_CHI_SO"].ToString();
                xml4.TEN_CHI_SO = row["TEN_CHI_SO"].ToString();
                xml4.GIA_TRI = row["GIA_TRI"].ToString();
                xml4.MA_MAY = row["MA_MAY"].ToString();
                xml4.MO_TA = row["MO_TA"].ToString();
                xml4.KET_LUAN = row["KET_LUAN"].ToString();
                xml4.NGAY_KQ = row["NGAY_KQ"].ToString();
                lstXML4.Add(xml4);
            }
            string xmlString = iHISPortalBHYT.Common.ConvertObjectToXMLString(lstXML4, "DSACH_CHI_TIET_CLS");
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var contentBase64 = Convert.ToBase64String(bytes);
            ModelGDBHYT.FILEHOSO hoso = new ModelGDBHYT.FILEHOSO { LOAIHOSO = "XML4", NOIDUNGFILE = contentBase64 };
            return hoso;
        }
        private ModelGDBHYT.FILEHOSO FileHS_XML5(DataTable dtFile)
        {
            List<ModelGDBHYT.CHI_TIET_DIEN_BIEN_BENH> lstXML5 = new List<ModelGDBHYT.CHI_TIET_DIEN_BIEN_BENH>();
            ModelGDBHYT.CHI_TIET_DIEN_BIEN_BENH xml5 = new ModelGDBHYT.CHI_TIET_DIEN_BIEN_BENH();
            if (dtFile == null || dtFile.Rows.Count <= 0)
                return null;
            foreach (DataRow row in dtFile.Rows)
            {
                xml5.MA_LK = row["MA_LK"].ToString();
                xml5.STT = Convert.ToInt32(row["STT"].ToString());
                xml5.DIEN_BIEN = row["DIEN_BIEN"].ToString();
                xml5.HOI_CHAN = row["HOI_CHAN"].ToString();
                xml5.PHAU_THUAT = row["PHAU_THUAT"].ToString();
                xml5.NGAY_YL = row["NGAY_YL"].ToString();
                lstXML5.Add(xml5);
            }
            string xmlString = iHISPortalBHYT.Common.ConvertObjectToXMLString(lstXML5, "DSACH_CHI_TIET_DIEN_BIEN_BENH");
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var contentBase64 = Convert.ToBase64String(bytes);
            ModelGDBHYT.FILEHOSO hoso = new ModelGDBHYT.FILEHOSO { LOAIHOSO = "XML5", NOIDUNGFILE = contentBase64 };
            return hoso;
        }
        
        private void LoadWaiting()
        {
            SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
        }
        private void CloseWaiting()
        {
            SplashScreenManager.CloseForm(false);
        }
    }
    
}