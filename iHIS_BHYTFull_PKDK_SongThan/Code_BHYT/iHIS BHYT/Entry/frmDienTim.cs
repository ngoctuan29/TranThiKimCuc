using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ps.Clinic.ViewPopup;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Diagnostics;
using DirectX.Capture;
using DShowNET; // DsEvCode
using System.Runtime.InteropServices;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.API.Native;

namespace Ps.Clinic.Entry
{
    public partial class frmDienTim : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private string patientCode, patientName = string.Empty;
        private string serviceCode = string.Empty;
        private string serviceName = string.Empty;
        private string sReferenceCode = string.Empty;
        private decimal patientReceiveID = 0, dReceiptCode = 0, dRadiologyEntryID = 0;
        private Int32 iStatus = 0, iObjectCode = 0;
        private string imageCode = string.Empty;
        public string path_image_full = @"\\temp\\Image";
        public string path_video_full = @"\\temp\\Video";
        public string path_resize = @"\\temp\\Resize";
        public string fname = string.Empty;
        private string sTheBHYT = string.Empty;
        private int iTraituyen = 0;
        private string s_makp = string.Empty, s_namekp = string.Empty;
        private string s_uSerid = string.Empty;
        private List<DiagnosisAbbreviationsInf> ListAbb = new List<DiagnosisAbbreviationsInf>();
        private DataSet dsetImage = new DataSet();
        private int iMenu = 0;
        private string employeeCodeDoctor = string.Empty;
        private string shiftWork = string.Empty;
        private DateTime dtWorking = new DateTime();
        private bool isAdmin = false;
        private bool isEmployeeCodeOther = false;
        public frmDienTim(string _spk, string _uSerid, int _Menu, string _namekp, string _employeeCodeDoctor, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.grWaitingList.Visible = true;
            this.grWaitingList.Dock = DockStyle.Fill;
            this.grPrevious.Visible = false;
            this.grPrevious.Dock = DockStyle.None;
            this.s_makp = _spk;
            this.s_uSerid = _uSerid;
            this.iMenu = _Menu;
            this.s_namekp = _namekp;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.shiftWork = _shiftWork;
            this.dtWorking = _dtWorking;
        }

        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }
        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }
        private Int32 ISDBNULL2INT32(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToInt32(b);
            }
            else
                return Convert.ToInt32(a);
        }
        private void frmDienTim_Load(object sender, EventArgs e)
        {
            try
            {
                this.loadListPatientWaitingCompleted(0);
                enableField(false);
                ListAbb = DiagnosisAbbreviationsBLL.ListAbb(s_uSerid);
                this.txtTemplateCode.Properties.DataSource = TemplateDescriptionBLL.DT_ListTemplate(string.Empty);
                this.txtTemplateCode.Properties.ValueMember = "TemplateHeaderCode";
                this.txtTemplateCode.Properties.DisplayMember = "TemplateHeaderName";
                this.EnableButton(true);
                this.butNew.Enabled = false;

                #region Kiem tra xem User dc quyen xoa, admin
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(301);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.isEmployeeCodeOther = true;
                }
                this.isAdmin = EmployeeBLL.CheckUserAdmin(this.s_uSerid);
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void enableField(bool ena)
        {
            
            lbTemplateCode.Enabled = ena;
            txtTemplateCode.Properties.ReadOnly = txtServiceName.Properties.ReadOnly = txtContent.ReadOnly = txtConclusion.ReadOnly = !ena;
            //txtProposal.Properties.ReadOnly = !ena;
        }

        public void EnableButton(bool b)
        {
            butNew.Enabled = b;
            butSave.Enabled = !b;
            butUndo.Enabled = !b;
            butEdit.Enabled = false;
            butPrint.Enabled = false;
            butCapture.Enabled = !b;
            pnListImage.Enabled = !b;
            butCancel.Enabled = false;
        }
                
        private int f_Get_STT_Hinh(string athumuc, string amabn, string id_hinh)
        {
            int k = 0;
            string adk = "";
            adk = amabn + "_" + id_hinh;
            adk = adk + "*";
            string[] sf = System.IO.Directory.GetFiles(athumuc, adk);
            string FNAME = "";
            try
            {
                for (int i = 0; i < sf.Length; i++)
                {
                    FNAME = sf[i].Substring(sf[i].LastIndexOf("\\") + 1);
                    if (FNAME.IndexOf(".jpg") != -1 && FNAME.IndexOf(".bmp") != 1)
                    {
                        k++;
                    }
                }
            }
            catch
            {
                k = 1;
            }
            return k + 1;
        }
        private Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            try
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)Width / (float)sourceWidth);
                nPercentH = ((float)Height / (float)sourceHeight);

                //if we have to pad the height pad both the top and the bottom
                //with the difference between the scaled height and the desired height
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = (int)((Width - (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = (int)((Height - (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.Red);
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                return bmPhoto;
            }
            catch { };
            return null;

        }

        private void ImageResize(string OriginalFileName, string ResizedFileName, int newWidth, int newHeight)
        {
            /* Định lại kích thước của 1 file ảnh */
            string oldImage = OriginalFileName;
            string newImage = ResizedFileName;

            Image currentImage = Image.FromFile(oldImage);
            Image imgPhoto = null;

            imgPhoto = FixedSize(currentImage, newWidth, newHeight);
            imgPhoto.Save(newImage, System.Drawing.Imaging.ImageFormat.Jpeg);
            imgPhoto.Dispose();
        }

        private void pic1_Click(object sender, System.EventArgs e)
        {
            try
            {
                PictureBox l = (PictureBox)(sender);
                decimal dRowID = Convert.ToDecimal(l.Name.ToString());
                ViewPopup.frmViewImage frm = new frmViewImage(l.Image, patientCode, patientReceiveID, dRadiologyEntryID, dRowID);
                frm.ShowDialog();
                l.Image = frm.img;
            }
            catch
            {
                return;
            }
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)(sender);
            if (c.Checked) c.ForeColor = Color.Red;
            else c.ForeColor = Color.White;
        }
       
        private void txtTemplateCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string templateCode = ISDBNULL2STRING(txtTemplateCode.EditValue, string.Empty);
                if (string.IsNullOrEmpty(templateCode))
                {
                    return;
                }
                else
                {
                    ///var queryTemplate = TemplateDescriptionBLL.ListTemplate(templateCode).FirstOrDefault();
                    var queryTemplate = TemplateDescriptionBLL.ObjTemplate(templateCode);
                    if (queryTemplate != null)
                    {
                        this.txtContent.RtfText = queryTemplate.Contents;
                        this.txtConclusion.RtfText = queryTemplate.Conclusion;
                        //this.txtProposal.Text = queryTemplate.Proposal;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }
                
        private void butReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView_PreviousList_Click(object sender, EventArgs e)
        {
            if (gridView_PreviousList.RowCount > 0)
            {
                if (gridView_PreviousList.GetFocusedRow() != null)
                {
                    serviceCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                    decimal dRowID = ISDBNULL2DECIMAL(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_RowID).ToString(), string.Empty);
                    this.lbSTT.Text = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_STT).ToString();
                    if (serviceCode != string.Empty && dReceiptCode > 0)
                    {
                        ServiceRadiologyEntryInf first = ServiceRadiologyBLL.ObjRadiologyEntry(dRowID);
                        CleanerField();
                        butEdit.Enabled = true;
                        butPrint.Enabled = true;
                        butCancel.Enabled = true;
                        if (first != null)
                        {
                            txtServiceName.Text = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceName).ToString(), string.Empty);
                            txtContent.RtfText = first.Contents;
                            txtConclusion.RtfText = first.Conclusion;
                            //txtProposal.Text = first.Proposal;
                            dReceiptCode = first.SuggestedID;
                            sReferenceCode = first.ReferenceCode;
                            patientReceiveID = first.PatientReceiveID;
                        }

                        try
                        {
                            pnListImage.Controls.Clear();

                            var imageList = ServiceRadiologyBLL.ListRadiologyDetail(dRowID);
                            int x = 0, y = 0;
                            int i_H = 1;

                            if (imageList.ToList().Count > 0)
                            {
                                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                                {
                                    PictureBox l = new PictureBox();
                                    Byte[] imageadata = new Byte[0];
                                    imageadata = (Byte[])(image.Image.ToArray());
                                    MemoryStream memo = new MemoryStream(imageadata);
                                    Bitmap b = new Bitmap(Image.FromStream(memo));
                                    l.Image = (Bitmap)b;
                                    l.Width = 100;
                                    l.Height = 100;
                                    l.Location = new System.Drawing.Point(x, y);
                                    l.BorderStyle = BorderStyle.Fixed3D;
                                    l.SizeMode = PictureBoxSizeMode.StretchImage;
                                    l.Cursor = Cursors.Hand;
                                    l.Tag = "db";
                                    l.DoubleClick += new System.EventHandler(this.pic1_Click);

                                    CheckBox chk = new CheckBox();
                                    chk.ForeColor = Color.White;
                                    chk.Text = "Hình " + i_H.ToString();
                                    chk.AutoSize = true;
                                    //chk.Location = new Point(x, y + 70);
                                    //x += l.Width;
                                    chk.Location = new Point(x, y + 100);
                                    y += l.Height + 20;
                                    chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                                    pnListImage.Controls.Add(l);
                                    pnListImage.Controls.Add(chk);
                                    i_H += 1;
                                }
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                    else
                    {
                        serviceCode = string.Empty;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void butChooseImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.RestoreDirectory = true;
                opf.Multiselect = true;
                opf.Filter = "All (*.*)|*.*|*.gif|*.gif|*.jpg|*.jpg|*.bmp|*.bmp";
                opf.RestoreDirectory = true;

                DialogResult dr = opf.ShowDialog();
                int i_Hinh = 1;
                if (dr == DialogResult.OK && opf.FileNames.Length > 0)
                {
                    pnListImage.Controls.Clear();
                    //int x = 0, y = 0; // theo chieu ngang
                    int x = 5, y = 0; // theo chieu doc
                    for (int i = 0; i < opf.FileNames.Length; i++)
                    {
                        PictureBox pic = new PictureBox();
                        Bitmap b = new Bitmap(opf.FileNames[i].ToString());
                        CheckBox chk = new CheckBox();
                        chk.ForeColor = Color.White;
                        chk.Text = "Hình " + i_Hinh.ToString();
                        pic.Image = (Bitmap)b;
                        pic.Width = 100;
                        pic.Height = 100;
                        pic.Location = new System.Drawing.Point(x, y);
                        pic.BorderStyle = BorderStyle.Fixed3D;
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Cursor = Cursors.Hand;
                        pic.Tag = opf.FileNames[i].ToString();
                        //Hien thi hinh theo chieu ngang
                        //chk.Location = new Point(x, y + 70);
                        //x += pic.Width;
                        //Hien thi hinh theo chieu doc
                        chk.Location = new Point(x, y + 100);
                        y += pic.Height + 20;

                        i_Hinh += 1;
                        chk.AutoSize = true;
                        chk.Tag = opf.FileNames[i].ToString();
                        pic.Click += new System.EventHandler(this.pic1_Click);
                        chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                        pnListImage.Controls.Add(pic);
                        pnListImage.Controls.Add(chk);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void DelPathImage()
        {
            try
            {
                string apath_thumuc = "", ayymmdd = "";
                ayymmdd = DateTime.Now.Date.Year.ToString().Substring(2) + DateTime.Now.Date.Month.ToString().PadLeft(2, '0') + DateTime.Now.Date.Day.ToString().PadLeft(2, '0');
                apath_thumuc = path_image_full + "\\" + ayymmdd;
                string[] filePaths = Directory.GetFiles(apath_thumuc);
                foreach (string file in filePaths)
                    File.Delete(file);
            }
            catch { }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (dReceiptCode != 0)
                {
                    if (iStatus == 0)
                    {
                        CleanerField();
                        enableField(true);
                        EnableButton(false);
                        gridControl_PreviousList.Visible = false;
                        txtTemplateCode.Properties.ReadOnly = false;
                        DelPathImage();
                    }
                    else
                    {
                        XtraMessageBox.Show("Đã có kết quả !\t\nChỉ được xem và sửa nội dung.", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký !\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký lại.", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dRadiologyRowID = 0;
                FileStream fstr;
                byte[] imagedata;
                if (txtContent.Text != string.Empty && dReceiptCode != 0)
                {
                    if (pnListImage.Controls.Count >= 0)
                    {
                        try
                        {
                            var doInsertService = new ServiceRadiologyEntryInf();
                            {
                                doInsertService.ServiceCode = serviceCode;
                                doInsertService.PatientCode = patientCode;
                                doInsertService.ReferenceCode = sReferenceCode;
                                doInsertService.AppointmentDate = DateTime.Now.Date;
                                doInsertService.AppointmentNote = string.Empty;
                                doInsertService.Contents = txtContent.RtfText;
                                doInsertService.Conclusion = txtConclusion.RtfText;
                                //doInsertService.Proposal = txtProposal.Text.ToString();
                                doInsertService.PostingDate = DateTime.Now;
                                doInsertService.PatientReceiveID = patientReceiveID;
                                doInsertService.Done = 1;
                                doInsertService.EmployeeCode = s_uSerid;
                                doInsertService.SuggestedID = dReceiptCode;
                            };
                            int iresult = ServiceRadiologyBLL.InsRadiologyEntry(doInsertService, ref dRadiologyRowID, "CDHA");
                            if (iresult > 0 && dRadiologyRowID > 0)
                            {
                                DataSet dsTmp = ProcessControlImage(pnListImage);
                                int iSelectImg = 0;
                                int iCountImage = 0;
                                var strExpr = "Chon = 1";
                                var strSort = " Chon DESC";
                                if (dsTmp != null)
                                {
                                    iCountImage = dsTmp.Tables[0].Select(strExpr, strSort).Length;
                                    if (iCountImage > 0)
                                    {
                                        ServiceRadiologyBLL.DelRadiologyDetailEntry(dRadiologyRowID);
                                        foreach (DataRow r in dsTmp.Tables[0].Select("Control='System.Windows.Forms.CheckBox'"))
                                        {
                                            iSelectImg = int.Parse(r["Chon"].ToString());
                                            if (iSelectImg == 1)
                                            {
                                                fstr = new FileStream(r["Tag"].ToString(), FileMode.Open, FileAccess.Read);
                                                imagedata = new byte[fstr.Length];
                                                fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                                                fstr.Close();
                                                var doInsertServiceDetail = new ServiceRadiologyDetailEntryInf();
                                                {
                                                    doInsertServiceDetail.RadiologyRowID = dRadiologyRowID;
                                                    doInsertServiceDetail.Image = imagedata;
                                                    doInsertServiceDetail.PostingDate = DateTime.Now.Date;
                                                };
                                                ServiceRadiologyBLL.InsRadiologyDetailEntry(doInsertServiceDetail, iStatus);
                                            }
                                        }
                                    }
                                }

                                XtraMessageBox.Show(" Lưu kết quả thăm dò chức năng !\t\nOK", "Bệnh viện điện tử .NET");
                                gridControl_PreviousList.Visible = true;
                                enableField(false);
                                EnableButton(true);
                                txtTemplateCode.Properties.ReadOnly = true;
                                butSave.Enabled = butNew.Enabled = butUndo.Enabled = butCapture.Enabled = false;
                                butEdit.Enabled = true;
                                butPrint.Enabled = true;
                                GetHistoryPatient(patientCode);
                            }
                            else
                            {
                                XtraMessageBox.Show(" Lưu kết quả không thành công !\t\nOK", "Bệnh viện điện tử .NET");
                                return;
                            }

                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Lỗi xảy ra khi lưu kết quả thực hiện!\t\t-Liên hệ Admin để kiểm tra lỗi." + ex.Message, "Bệnh viện điện tử .NET");
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Chưa phát sinh hình ảnh cho cận lâm sàng !\t\n- " + txtServiceName.Text.ToUpper(), "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên & nội dung cận lâm sàng không được để trống !\t\n - " + txtServiceName.Text.ToUpper(), "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi lưu kết quả cận lâm sàng !", "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grPrevious.Visible = false;

                this.patientReceiveID = 0;
                this.dReceiptCode = 0;
                this.sReferenceCode = string.Empty;
                this.patientCode = string.Empty;

                this.serviceName = string.Empty;
                this.iStatus = 0;
                this.grMain.Text = string.Empty;

                this.CleanerField();
                this.enableField(false);
                this.txtTemplateCode.Properties.ReadOnly = true;
                this.EnableButton(true);
                this.butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceCode != string.Empty && patientCode != string.Empty)
                {
                    DataTable dtClinic = new DataTable("ClinicInfo");
                    dtClinic = ClinicInformationBLL.DT_Information(1);
                    DataTable dtResult = new DataTable("KetquaCLS");
                    dtResult = ServiceRadiologyBLL.DT_ResultRadiology(dReceiptCode, this.patientReceiveID);
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaDientim.xml");
                    Reports.rptDientim rptShow = new Reports.rptDientim();
                    rptShow.Parameters["RadiologyRowID"].Value = dReceiptCode.ToString();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DienTim", "Kết quả điện tim");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt thực hiện từ danh sách để in phiếu KQ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        public void loadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(504);
            if (objSys != null && objSys.RowID > 0)
            {
                gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingService(DateTime.Now, iStatus, s_makp, objSys.Values, iMenu);
            }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                grWaitingList.Visible = true;
                grWaitingList.Dock = DockStyle.Fill;
                grPrevious.Visible = false;
                grPrevious.Dock = DockStyle.None;
                grMain.Text = "Trả Kết Quả Điện Tâm Đồ!";
                tabMain.SelectedTabPageIndex = 0;
                if (checkWaiting.Checked == true)
                {
                    loadListPatientWaitingCompleted(0);
                }
                if (CheckCompleted.Checked == true)
                {
                    loadListPatientWaitingCompleted(1);
                }
                this.enableField(false);
                this.CleanerField();
                patientCode = patientName = serviceCode = serviceName = sReferenceCode = string.Empty;
                txtServiceName.Text = string.Empty;
                patientReceiveID = dRadiologyEntryID = 0;
                iStatus = 0;
                iObjectCode = 0;
                imageCode = string.Empty;
                butReload_Click(sender, e);
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                picPatient.Image = (Bitmap)b;
                this.dsetImage = new DataSet();
            }
            catch { }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                loadListPatientWaitingCompleted(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void CheckCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                loadListPatientWaitingCompleted(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        public void CleanerField()
        {
            //this.txtConclusion.EditValue = string.Empty;
            this.txtTemplateCode.EditValue = null;
            this.txtContent.Text = txtConclusion.Text = string.Empty;
            //this.txtProposal.Text = string.Empty;
            this.pnListImage.Controls.Clear();
            this.lbSTT.Text = string.Empty;
        }

        private void GetTemplate()
        {
            DataTable tableTemplate = TemplateDescriptionBLL.TableListTemplateForService(this.serviceCode, this.employeeCodeDoctor);
            if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                this.txtTemplateCode.EditValue = this.serviceCode;
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_WaitingList.RowCount > 0)
                {
                    if (gridView_WaitingList.GetFocusedRow() != null)
                    {
                        gridControl_PreviousList.Visible = true;
                        CleanerField();
                        grWaitingList.Visible = false;
                        grWaitingList.Dock = DockStyle.None;
                        grPrevious.Visible = true;
                        grPrevious.Dock = DockStyle.Fill;

                        patientReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RefID).ToString());
                        dReceiptCode = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReceiptID).ToString());
                        sReferenceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString();
                        patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        serviceCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString(), string.Empty);
                        serviceName = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceName).ToString(), string.Empty);
                        iStatus = ISDBNULL2INT32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Status), 404);
                        iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                        this.lbSTT.Text = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_STT).ToString();

                        string name = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString(), string.Empty);
                        string gender = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString(), string.Empty);
                        string year = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString(), string.Empty);
                        string address = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientAddress).ToString(), string.Empty);
                        grMain.Text = s_namekp + " | " + Convert.ToString(serviceName + " - Họ tên: " + name + " | Giới tính: " + gender + " | Năm sinh: " + year + " | Địa chỉ: " + address);
                        
                        if (iStatus == 0)
                        {
                            butNew.Enabled = true;
                        }
                        txtServiceName.Text = serviceName;
                        
                        //picCapturePro.Refresh();
                        if (iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = new List<BHYTInf>();
                            lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(patientReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                sTheBHYT = lstBHYT[0].Serial;
                                lbSothe.Text = lstBHYT[0].Serial;
                                lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                iTraituyen = lstBHYT[0].TraiTuyen;
                                if (iTraituyen == 1)
                                    chkTraiTuyen.Checked = true;
                                else
                                    chkTraiTuyen.Checked = false;
                                lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                GetCardInfo(lstBHYT[0].Serial);
                                VisableBHYT(true);
                            }
                        }
                        else
                        {
                            lbTileBHYT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                            VisableBHYT(false);
                        }
                        this.GetTemplate();
                        this.GetInfoPatient(patientCode);
                        this.GetHistoryPatient(patientCode);
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }
        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 2);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (chkTraiTuyen.Checked == true)
                        lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                    else
                        lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                }
            }
            catch { }
        }

        private void VisableBHYT(bool b)
        {
            this.lbSothe.Visible = b;
            this.lbTungay.Visible = b;
            this.chkTraiTuyen.Visible = b;
            this.lbNoiDKKCB.Visible = b;
            this.lbDenngay.Visible = b;
        }

        private void GetHistoryPatient(string sPatient)
        {
            try
            {
                gridControl_PreviousList.DataSource = ServiceRadiologyBLL.ListPrevious(patientCode, iMenu);

            }
            catch { }
        }

        private void GetInfoPatient(string sPatient)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(sPatient, this.patientReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    lbMabn01.Text = objPatient.PatientCode;
                    lbHoten01.Text = objPatient.PatientName;
                    lbNamsinh01.Text = objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    lbDiachi01.Text = objPatient.PatientAddress;

                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        picPatient.Image = (Bitmap)b;
                    }
                }
                else
                    return;
            }
            catch { }
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_PreviousList.RowCount > 0)
                {
                    if (gridView_PreviousList.GetFocusedRow() != null && txtServiceName.Text != string.Empty)
                    {
                        serviceCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                        String employeeCodeDoctorTemp = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_EmployeeCode).ToString(), string.Empty);
                        if (employeeCodeDoctorTemp == this.employeeCodeDoctor || this.isAdmin || this.isEmployeeCodeOther)
                        {
                            if (serviceCode != string.Empty)
                            {
                                gridControl_PreviousList.Visible = true;
                                txtTemplateCode.Properties.ReadOnly = true;
                                txtTemplateCode.Enabled = txtServiceName.Enabled = txtContent.Enabled = txtConclusion.Enabled = true;
                                //txtProposal.Enabled = true;
                                enableField(true);
                                butSave.Enabled = butUndo.Enabled = pnListImage.Enabled = butCapture.Enabled = true;
                                butEdit.Enabled = butPrint.Enabled = false;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Chọn đợt thực hiện cần sửa lại thông tin! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khác bác sĩ đọc kết quả cận lâm sàng, không cho phép sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chọn đợt thực hiện cần sửa lại thông tin! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa có kêt quả cận lâm sàng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkWaiting.Checked == true)
                {
                    loadListPatientWaitingCompleted(0);
                }
                if (CheckCompleted.Checked == true)
                {
                    loadListPatientWaitingCompleted(1);
                }
                EnableButton(true);
                butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void frmDienTim_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: butReload_Click(sender, e); break;                    //F5 - Refresh
                    case Keys.F1: butContinues_Click(sender, e); break;                 //F1 - Bệnh nhân tiếp
                    case Keys.F2: butNew_Click(sender, e); break;                     //F2 - Thực hiện
                    case Keys.F3: butSave_Click(sender, e); break;                    //F3 - Lưu
                    case Keys.F6: butPrint_Click(sender, e); break;                   //F6 - In toa
                }
            }
            catch
            {
                return;
            }
        }

        private void txtConclusion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DevExpress.XtraRichEdit.RichEditControl txt = (DevExpress.XtraRichEdit.RichEditControl)(sender);
                string auto = "", s1 = "", s2 = "", strSource = "";
                if (e.KeyChar == ' ')
                {
                    strSource = f_Get_AutoRichText(txt);
                    auto = SearchCharecter(strSource);
                    if (!string.IsNullOrEmpty(auto))
                    {
                        s1 = auto.Split('©')[0];
                        s2 = auto.Split('©')[1];
                        int start = txt.Document.CaretPosition.ToInt();
                        Document document = txt.Document;
                        document.BeginUpdate();
                        try
                        {
                            DocumentRange range = txt.Document.CreateRange(start - s2.Length, s2.Length);
                            string text = txt.Document.GetText(range);
                            document.Delete(range);
                            document.Replace(range, s1);
                            document.Selection = range;
                        }
                        catch
                        {
                        }
                        finally
                        {
                            document.EndUpdate();
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private string SearchCharecter(string strsource)
        {
            string stemp = "";
            var v_Viettat = from p in ListAbb where p.CharacterCode == strsource select new { p.CharacterName };
            stemp = v_Viettat.FirstOrDefault().CharacterName;
            strsource = strsource.ToLower().Trim();
            try
            {
                stemp += "©" + strsource;
            }
            catch
            {
                stemp = string.Empty;
            }
            return stemp;
        }

        private string f_Get_Auto(DevExpress.XtraEditors.MemoEdit txt)
        {
            int iSelect = 0;
            int iStart = 0;
            int chieudai = 0;
            string str = "", strFind = "", strSource = "";
            strSource = txt.Text;
            strSource = strSource.Replace("\n", " ");
            strSource = strSource.Replace("\r", " ");
            strSource = strSource.Replace("\t", " ");

            iSelect = txt.SelectionStart;
            for (int i = iSelect - 1; i > 0; i--)
            {
                iStart = i;
                str = strSource.Substring(iStart, 1);
                if (str == " ")
                {
                    chieudai = iSelect - 1 - i;
                    strFind = txt.Text.Substring(iSelect - chieudai, chieudai);
                    break;
                }
            }
            try
            {
                if (strFind == "" && strFind.Length < 10) strFind = txt.Text;
            }
            catch
            {
                strFind = string.Empty;
            }
            return strFind;
        }

        private void txtProposal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.MemoEdit txt = (DevExpress.XtraEditors.MemoEdit)(sender);
                string auto = "", s1 = "", s2 = "", strSource = "";

                if (e.KeyChar == ' ')
                {
                    strSource = f_Get_Auto(txt);
                    auto = SearchCharecter(strSource);
                    if (!string.IsNullOrEmpty(auto))
                    {
                        s1 = auto.Split('©')[0];
                        s2 = auto.Split('©')[1];
                        int iSecStar = txt.SelectionStart;
                        txt.SelectionStart = iSecStar - s2.TrimStart().Length;
                        txt.SelectionLength = s2.TrimStart().Length;
                        txt.SelectedText = "" + s1;
                        txt.Refresh();
                    }
                }
            }
            catch { return; }
        }

        private void txtContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DevExpress.XtraRichEdit.RichEditControl txt = (DevExpress.XtraRichEdit.RichEditControl)(sender);
                string auto = "", s1 = "", s2 = "", strSource = "";
                if (e.KeyChar == ' ')
                {
                    strSource = f_Get_AutoRichText(txt);
                    auto = SearchCharecter(strSource);
                    if (!string.IsNullOrEmpty(auto))
                    {
                        s1 = auto.Split('©')[0];
                        s2 = auto.Split('©')[1];
                        int start = txt.Document.CaretPosition.ToInt();
                        Document document = txt.Document;
                        document.BeginUpdate();
                        try
                        {
                            DocumentRange range = txt.Document.CreateRange(start - s2.Length, s2.Length);
                            string text = txt.Document.GetText(range);
                            document.Delete(range);
                            document.Replace(range, s1);
                            document.Selection = range;
                        }
                        catch
                        {
                        }
                        finally
                        {
                            document.EndUpdate();
                        }
                    }
                }
            }
            catch { }
        }

        private void picRelation_Click(object sender, EventArgs e)
        {
            if (this.patientCode.Trim().Length > 0)
            {
                frmRelationPatient frm = new frmRelationPatient(this.patientReceiveID, this.s_uSerid, this.patientCode);
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để khai báo thông tin gia đình!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void picCaptureDocument_Click(object sender, EventArgs e)
        {
            if (this.patientCode == string.Empty || this.patientReceiveID == 0)
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để đính kèm file văn bản hình ảnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.patientReceiveID, this.patientCode);
                frm.ShowDialog();
            }
        }

        private void picHSBA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.patientCode))
            {
                frmKB_HSBA frm = new frmKB_HSBA(this.patientCode);
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show(" Chưa có thông tin mã bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private string f_Get_AutoRichText(DevExpress.XtraRichEdit.RichEditControl txt)
        {
            int iSelect = 0;
            int iStart = 0;
            int chieudai = 0;
            string str = "", strFind = "", strSource = "";
            strSource = txt.Text;
            strSource = strSource.Replace("\n", " ");
            strSource = strSource.Replace("\r", " ");
            strSource = strSource.Replace("\t", " ");
            iSelect = txt.Document.Selection.Start.ToInt();

            for (int i = iSelect - 1; i > 0; i--)
            {
                iStart = i;
                str = strSource.Substring(iStart, 1);
                if (str == " ")
                {
                    chieudai = iSelect - 1 - i;
                    strFind = txt.Text.Substring(iSelect - chieudai, chieudai);
                    break;
                }
            }
            try
            {
                if (strFind == "" && strFind.Length < 10) strFind = txt.Text;
            }
            catch
            {
                strFind = string.Empty;
            }
            return strFind;
        }

        private DataSet ProcessControlImage(Panel pnListImg)
        {
            DataSet dsImageTmp = new DataSet();
            try
            {
                dsImageTmp.Tables.Add("tblImage");
                dsImageTmp.Tables[0].Columns.Add("Control", typeof(string));
                dsImageTmp.Tables[0].Columns.Add("Tag", typeof(string));
                dsImageTmp.Tables[0].Columns.Add("Chon", typeof(decimal)).DefaultValue = 0;
                string strTagimage = "";
                DataRow rowImage;
                int iChonimage = 0;
                foreach (Control ctrl in pnListImg.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    {
                        CheckBox chkImage = (CheckBox)ctrl;
                        iChonimage = chkImage.Checked ? 1 : 0; 
                        strTagimage = ctrl.Tag.ToString();
                        rowImage = dsImageTmp.Tables[0].NewRow();
                        rowImage["Control"] = ctrl.GetType().ToString();
                        rowImage["Tag"] = strTagimage;
                        rowImage["Chon"] = iChonimage;
                        dsImageTmp.Tables[0].Rows.Add(rowImage);
                    }

                }
                dsImageTmp.AcceptChanges();
            }
            catch { dsImageTmp = null; }
            return dsImageTmp;
        }
                       
        private void butCapture_Click(object sender, EventArgs e)
        {
            try
            {
                ViewPopup.frmCapTure frm = new frmCapTure(this.patientReceiveID, patientCode, "CDHA", this.dsetImage);
                frm.ShowDialog();
                frm.ShowInTaskbar = false;
                this.dsetImage = this.ProcessControlImage(frm.pnListImage);
                frm.pnListImage.Dispose();
                frm.Dispose();
                if (this.dsetImage.Tables[0].Rows.Count > 0)
                {
                    DataTable dtAccept = this.dsetImage.Tables[0].Select("Chon=1", "Chon desc").CopyToDataTable();
                    this.f_UpdatePanelImage(dtAccept);
                }
            }
            catch { }
        }

        private void f_UpdatePanelImage(DataTable dtImage)
        {
            try
            {
                pnListImage.Controls.Clear();
                int x = 0, y = 0;
                int i_Hinh = 1;
                string afilename = string.Empty;
                foreach (DataRow dr in dtImage.Rows)
                {
                    PictureBox b = new PictureBox();
                    afilename = dr["Tag"].ToString();
                    Bitmap bm = new Bitmap(afilename);
                    b.Image = (Bitmap)bm;
                    b.Width = 120;
                    b.Height = 110;
                    CheckBox chk = new CheckBox();
                    chk.ForeColor = Color.Black;
                    chk.Text = "Hình " + i_Hinh.ToString();
                    chk.AutoSize = true;
                    chk.Checked = true;
                    b.SizeMode = PictureBoxSizeMode.StretchImage;
                    b.Location = new System.Drawing.Point(x, y);
                    chk.Location = new Point(x, y + 110);
                    y += b.Height + 20;

                    b.BorderStyle = BorderStyle.Fixed3D;
                    b.Tag = afilename;
                    chk.Tag = b.Tag.ToString();
                    b.Cursor = Cursors.Hand;
                    b.Click += new System.EventHandler(this.pic1_Click);
                    chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                    pnListImage.Controls.Add(b);
                    pnListImage.Controls.Add(chk);
                    i_Hinh += 1;
                }
            }
            catch
            {
                return;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null && this.txtServiceName.Text != string.Empty)
                    {
                        String employeeCodeDoctorTemp = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_EmployeeCode).ToString(), string.Empty);
                        if (employeeCodeDoctorTemp == this.employeeCodeDoctor || this.isAdmin || this.isEmployeeCodeOther)
                        {
                            Int32 iResult = 0;
                            ServiceRadiologyBLL.DelRadiologyEntry(dReceiptCode, ref iResult);
                            if (iResult == 1)
                            {
                                XtraMessageBox.Show(" Hủy kết quả thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.butContinues_Click(sender, e);
                                this.CleanerField();
                                this.EnableButton(true);
                                return;
                            }
                            else if (iResult == -1)
                            {
                                XtraMessageBox.Show(" Kết quả cận lâm sàn chưa có ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy kết quả không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khác bác sĩ đọc kết quả cận lâm sàng, không cho phép hủy kết quả! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chọn đợt thực hiện cần hủy kết quả! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa có kêt quả cận lâm sàng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

    }
}