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
using System.Runtime.InteropServices;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.API.Native;
using System.Threading;
using DirectX.Capture;
using DShowNET;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;

namespace Ps.Clinic.Entry
{
    public partial class frmNoiSoiGeneral : DevExpress.XtraEditors.XtraForm
    {
        private string patientCode, patientName = string.Empty;
        private string serviceCode = string.Empty;
        private string serviceName = string.Empty;
        private string sReferenceCode = string.Empty;
        private decimal patientReceiveID, receiptCode = 0;
        private Int32 iStatus = 0, iObjectCode = 0, patientType = 1;
        private string imageCode = string.Empty;
        public string fname = string.Empty;
        private string sTheBHYT = string.Empty;
        private int iTraituyen = 0;
        private string s_makp = string.Empty, s_namekp = string.Empty;
        private string s_uSerid = string.Empty;
        private List<DiagnosisAbbreviationsInf> ListAbb = new List<DiagnosisAbbreviationsInf>();
        private int iMenu = 0;
        private decimal dRadiologyEntryID = 0;
        private string employeeCodeDoctor = string.Empty;
        private string shiftWork = string.Empty;
        private DateTime dtWorking = new DateTime();
        private DataTable tableTemplateHeader = new DataTable();
        private DataSet dsetImage;
        private bool isAdmin = false;
        private bool isEmployeeCodeOther = false;
        private string printPaper = string.Empty;
        private DateTime dtResult = new DateTime();
        private DateTime dtServer = new DateTime();
        private bool isImageSaveAll = false;
        private DataSet dsConfigCapture = new DataSet();
        private int positionCardCaptureSelected = 0;
        public frmNoiSoiGeneral(string _spk, string _uSerid, Int32 _Menu, string _namekp, string _employeeCodeDoctor, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.grWaitingList.Visible = true;
            this.grWaitingList.Dock = DockStyle.Fill;
            this.pnPrevious.Visible = false;
            this.pnPrevious.Dock = DockStyle.None;
            this.s_makp = _spk;
            this.s_uSerid = _uSerid;
            this.iMenu = _Menu;
            this.s_namekp = _namekp;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.shiftWork = _shiftWork;
            this.dtWorking = this.dtResult = _dtWorking;
        }

        private void frmNoiSoiGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = this.dtWorking;
                this.LoadListPatientWaitingCompleted(0);
                this.EnableField(false);
                this.ListAbb = DiagnosisAbbreviationsBLL.ListAbb(this.employeeCodeDoctor);
                //this.AudioViaPci = this.menuAudioViaPci1.Checked;
                this.EnableButton(true);
                this.butNew.Enabled = false;
                this.tableTemplateHeader = TemplateDescriptionBLL.DT_ListTemplateForMenuID(this.iMenu);
                this.txtTemplateCode.Properties.DataSource = this.tableTemplateHeader;
                this.txtTemplateCode.Properties.ValueMember = "TemplateHeaderCode";
                this.txtTemplateCode.Properties.DisplayMember = "TemplateHeaderName";

                #region Kiem tra xem User dc quyen xoa, admin
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(301);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.isEmployeeCodeOther = true;
                }
                this.isAdmin = EmployeeBLL.CheckUserAdmin(this.s_uSerid);
                objSys = SystemParameterBLL.ObjParameter(302);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.isImageSaveAll = true;
                }
                #endregion

                this.dtServer = Utils.DateTimeServer();
                this.txtContent.Appearance.Text.Options.UseFont = false;
                #region Capture
                string pathName = Directory.GetCurrentDirectory();
                this.toolSaveFile_SaveImage.Text = pathName + "\\temp\\Image";
                this.toolSaveFile_SaveVideo.Text = pathName + "\\temp\\Video";
                this.path_resize = pathName + "\\temp\\Resize";
                this.splitContainerControl1.Panel1.MinSize = 755;
                #region Xoa thu muc hinh cu
                //string yymmdd = this.dtServer.AddDays(-1).Date.Year.ToString().Substring(2) + this.dtServer.AddDays(-1).Date.Month.ToString().PadLeft(2, '0') + this.dtServer.AddDays(-1).Date.Day.ToString().PadLeft(2, '0');
                //this.path_thumuc = this.path_image_full + "\\" + yymmdd;
                //if (Directory.Exists(this.path_thumuc))
                //{
                //    System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(this.path_thumuc);
                //    directory.Delete(true);
                //}
                #endregion
                this.dsConfigCapture.ReadXml(pathName + "\\xml\\CaptureConfig.xml");
                if (this.dsConfigCapture != null && this.dsConfigCapture.Tables.Count > 0)
                {
                    string pathConfigImage = this.dsConfigCapture.Tables[0].Rows[0]["pathimage"].ToString();
                    string pathConfigVideo = this.dsConfigCapture.Tables[0].Rows[0]["pathvideo"].ToString();
                    this.positionCardCaptureSelected = string.IsNullOrEmpty(this.dsConfigCapture.Tables[0].Rows[0]["pathvideo"].ToString()) ? 0 : Convert.ToInt32(this.dsConfigCapture.Tables[0].Rows[0]["positionCardCapture"].ToString());
                    if (!string.IsNullOrEmpty(pathConfigImage) && Directory.Exists(pathConfigImage))
                        this.toolSaveFile_SaveImage.Text = pathConfigImage;
                    if (!string.IsNullOrEmpty(pathConfigVideo) && Directory.Exists(pathConfigVideo))
                        this.toolSaveFile_SaveVideo.Text = pathConfigVideo;
                }
                string yymmdd = this.dtServer.Date.Year.ToString().Substring(2) + this.dtServer.Date.Month.ToString().PadLeft(2, '0') + this.dtServer.Date.Day.ToString().PadLeft(2, '0');
                this.path_thumuc = this.toolSaveFile_SaveImage.Text + "\\" + yymmdd + "\\" + this.patientCode;
                #endregion
                this.capture = null;
                this.filters = new Filters();
                this.UpdateMenuConfig();
                this.AutoChooseAudio();
                this.menuAllowSampleGrabber1_Click(sender, e);
                this.mnuVideoDevices_Click(sender, e);
                this.menuSampleGrabber_Click(sender, e);
                this.mnuPreview_Click(sender, e);
            }
            catch (Exception)
            {
                //XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

        private void GetTemplate()
        {
            //if (this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "' and EmployeeDoctorCode='" + this.employeeCodeDoctor + "'").Length > 0)
            //{
            //    DataTable tableTemplate = this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "' and EmployeeDoctorCode='" + this.employeeCodeDoctor + "'").CopyToDataTable();
            //    if (tableTemplate != null && tableTemplate.Rows.Count > 0)
            //        this.txtTemplateCode.EditValue = this.serviceCode;
            //}
            if (this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "'").Length > 0)
            {
                DataTable tableTemplate = this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "'").CopyToDataTable();
                if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                {
                    this.txtTemplateCode.EditValue = tableTemplate.Rows[0][0].ToString();
                    this.printPaper = tableTemplate.Rows[0]["PrintPaper"].ToString();
                }
                else
                    this.txtContent.Text = this.txtProposal.Text = this.txtConclusion.Text = this.printPaper = string.Empty;
            }
            else
                this.txtContent.Text = this.txtProposal.Text = this.txtConclusion.Text = string.Empty;
        }

        public void EnableField(bool ena)
        {
            this.lbTemplateCode.Enabled = ena;
            this.txtTemplateCode.Properties.ReadOnly = this.txtContent.ReadOnly = this.txtConclusion.ReadOnly = this.txtProposal.Properties.ReadOnly = !ena;
            ///this.txtServiceName.Properties.ReadOnly = !ena;
            this.tool_Devices.Enabled = this.tool_Option.Enabled = this.tool_Photo.Enabled = this.tool_SelectImages.Enabled = this.tool_CaptureVideos.Enabled = this.tool_PathSaveFile.Enabled = ena;
        }

        public void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butSave.Enabled = !b;
            this.butUndo.Enabled = !b;
            this.butEdit.Enabled = false;
            this.butPrint.Enabled = false;
            this.pnListImage.Enabled = !b;
            this.butHandPoint.Enabled = !b;
            this.butCancel.Enabled = false;
            this.btChangeDepart.Enabled = false;
        }

        private void txtTemplateCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string templateCode = ISDBNULL2STRING(this.txtTemplateCode.EditValue, string.Empty);
                if (string.IsNullOrEmpty(templateCode))
                    return;
                else
                {
                    var queryTemplate = TemplateDescriptionBLL.ObjTemplate(templateCode);///.FirstOrDefault();
                    if (queryTemplate != null && queryTemplate.TemplateHeaderCode != null)
                    {
                        ///txtServiceName.Text = queryTemplate.TemplateHeaderName;
                        this.txtContent.RtfText = queryTemplate.Contents;
                        this.txtConclusion.RtfText = queryTemplate.Conclusion;
                        this.txtProposal.Text = queryTemplate.Proposal;
                    }
                    else
                        return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.receiptCode != 0)
                {
                    if (this.iStatus == 0)
                    {
                        this.EnableField(true);
                        this.EnableButton(false);
                        //this.CleanerField();
                        this.gridControl_PreviousList.Visible = false;
                        this.txtTemplateCode.Properties.ReadOnly = false;
                        //this.DelPathImage();
                    }
                    else
                    {
                        XtraMessageBox.Show("Đã có kết quả cận lâm sàng!\t\nChỉ được xem và sửa nội dung.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký cận lâm sàng!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (this.txtContent.Text != string.Empty && this.receiptCode != 0)
                {
                    if (this.pnListImage.Controls.Count >= 0)
                    {
                        try
                        {
                            var doInsertService = new ServiceRadiologyEntryInf();
                            {
                                doInsertService.ServiceCode = serviceCode;
                                doInsertService.PatientCode = patientCode;
                                doInsertService.ReferenceCode = sReferenceCode;
                                doInsertService.AppointmentDate = Convert.ToDateTime("01/01/1990");
                                doInsertService.AppointmentNote = string.Empty;
                                doInsertService.Contents = this.txtContent.RtfText;
                                doInsertService.Conclusion = this.txtConclusion.RtfText;
                                doInsertService.Proposal = this.txtProposal.Text.ToString();
                                doInsertService.PostingDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                                doInsertService.PatientReceiveID = this.patientReceiveID;
                                doInsertService.Done = 1;
                                doInsertService.EmployeeCode = this.s_uSerid;
                                doInsertService.SuggestedID = this.receiptCode;
                                doInsertService.EmployeeCodeDoctor = this.employeeCodeDoctor;
                                doInsertService.ShiftWork = this.shiftWork;
                                doInsertService.Note = string.Empty;
                            };
                            int iresult = ServiceRadiologyBLL.InsRadiologyEntry(doInsertService, ref dRadiologyEntryID, "CDHA");
                            if (iresult > 0 && this.dRadiologyEntryID > 0)
                            {
                                ServiceRadiologyBLL.DelRadiologyDetailEntry(dRadiologyEntryID);
                                if (this.listPicture != null && this.listPicture.Count > 0)
                                {
                                    foreach (var img in this.listPicture)
                                    {
                                        if (this.isImageSaveAll)
                                        {
                                            var doInsertServiceDetail = new ServiceRadiologyDetailEntryInf();
                                            {
                                                doInsertServiceDetail.RadiologyRowID = dRadiologyEntryID;
                                                doInsertServiceDetail.Image = img.imagebyte;
                                                doInsertServiceDetail.PostingDate = DateTime.Now;
                                                doInsertServiceDetail.Checked = img.check;
                                            };
                                            ServiceRadiologyBLL.InsRadiologyDetailEntry(doInsertServiceDetail, iStatus);
                                        }
                                        else
                                        {
                                            if (img.check)
                                            {
                                                var doInsertServiceDetail = new ServiceRadiologyDetailEntryInf();
                                                {
                                                    doInsertServiceDetail.RadiologyRowID = dRadiologyEntryID;
                                                    doInsertServiceDetail.Image = img.imagebyte;
                                                    doInsertServiceDetail.PostingDate = DateTime.Now;
                                                    doInsertServiceDetail.Checked = true;
                                                };
                                                ServiceRadiologyBLL.InsRadiologyDetailEntry(doInsertServiceDetail, iStatus);
                                            }
                                        }
                                    }
                                }
                                //XtraMessageBox.Show(" Lưu kết quả cận lâm sàng thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.gridControl_PreviousList.Visible = true;
                                //picPreview.Image = null;
                                this.EnableField(false);
                                this.EnableButton(true);
                                this.txtTemplateCode.Properties.ReadOnly = true;
                                this.butSave.Enabled = this.butNew.Enabled = this.butUndo.Enabled = this.butHandPoint.Enabled = false;
                                this.butEdit.Enabled = this.butPrint.Enabled = true;
                                this.GetHistoryPatient();
                                this.butPrint_Click(sender, e);
                            }
                            else
                            {
                                XtraMessageBox.Show(" Lưu kết quả cận lâm sàng không thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Lỗi xảy ra khi lưu kết quả cận lâm sàng!\t\t-Liên hệ Admin để kiểm tra lỗi." + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //picCapturePro.Refresh();
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Chưa phát sinh hình ảnh cho cận lâm sàng !\t\n- " + txtServiceName.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên & nội dung cận lâm sàng không được để trống !\t\n - " + txtServiceName.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi lưu kết quả cận lâm sàng !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.pnPrevious.Visible = false;
                this.patientReceiveID = 0;
                this.receiptCode = 0;
                this.sReferenceCode = string.Empty;
                this.patientCode = string.Empty;
                this.serviceName = string.Empty;
                this.iStatus = 0;
                this.grMain.Text = string.Empty;
                this.CleanerField();
                this.EnableField(false);
                this.txtTemplateCode.Properties.ReadOnly = true;
                this.EnableButton(true);
                this.butNew.Enabled = false;
            }
            catch
            {
                //picCapturePro.Refresh();
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceCode != string.Empty && patientCode != string.Empty)
                {
                    DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                    DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(this.receiptCode, this.patientReceiveID);
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaNoisoi.xml");

                    if (this.printPaper.Equals("A4"))
                    {
                        Reports.rptCLS_NoisoiA4 rptShow = new Reports.rptCLS_NoisoiA4();
                        rptShow.Parameters["RadiologyRowID"].Value = this.receiptCode.ToString();
                        rptShow.Parameters["prDateResult"].Value = this.dtResult;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "NoiSoi", "CLS-Kết quả nội soi");
                        rpt.ShowDialog();
                    }
                    else if (this.printPaper.Equals("A5"))
                    {
                        Reports.rptCLS_NoisoiA5 rptShow = new Reports.rptCLS_NoisoiA5();
                        rptShow.Parameters["RadiologyRowID"].Value = this.receiptCode.ToString();
                        rptShow.Parameters["prDateResult"].Value = this.dtResult;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "NoiSoi", "CLS-Kết quả nội soi");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        Reports.rptCLS_NoisoiA4Rotate rptShow = new Reports.rptCLS_NoisoiA4Rotate();
                        rptShow.Parameters["RadiologyRowID"].Value = this.receiptCode.ToString();
                        rptShow.Parameters["prDateResult"].Value = this.dtResult;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "NoiSoi", "CLS-Kết quả nội soi");
                        rpt.ShowDialog();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt thực hiện từ danh sách để in phiếu kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(504);
            if (objSys != null && objSys.RowID > 0)
            {
                this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingService(Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), iStatus, s_makp, objSys.Values, iMenu, this.employeeCodeDoctor);
            }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grWaitingList.Dock = DockStyle.Fill;
                this.pnPrevious.Visible = false;
                this.pnPrevious.Dock = DockStyle.None;
                this.grMain.Text = "Trả kết quả Nội Soi";
                this.tabMain.SelectedTabPageIndex = 0;
                this.EnableField(false);
                this.CleanerField();
                this.patientCode = this.patientName = this.serviceCode = this.serviceName = this.sReferenceCode = string.Empty;
                this.patientReceiveID = this.dRadiologyEntryID = 0;
                this.iStatus = 0;
                this.iObjectCode = 0;
                this.patientType = 1;
                this.imageCode = string.Empty;
                this.txtServiceName.Text = string.Empty;
                //this.txtTemplateCode.EditValue = -1;
                this.butReload_Click(sender, e);
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
                this.dsetImage = new DataSet();
                this.printPaper = string.Empty;
                this.dtResult = this.dtWorking;
                this.splitContainerControl1.Panel1.MinSize = 755;
                //this.listPicture.Clear();
                //this.DisposeCapture();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadListPatientWaitingCompleted(0);
                this.btChangeDepart.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CheckCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadListPatientWaitingCompleted(1);
                this.btChangeDepart.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void CleanerField()
        {
            this.txtTemplateCode.EditValue = -1;
            this.pnListImage.Controls.Clear();
            this.txtContent.Text = string.Empty;
            this.txtProposal.Text = string.Empty;
            this.txtConclusion.Text = string.Empty;
            this.lbSTT.Text = string.Empty;
            this.listPicture = new List<PictureInf>();
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.splitContainerControl1.Panel1.MinSize = 315;

                        this.gridControl_PreviousList.Visible = true;
                        this.CleanerField();
                        this.grWaitingList.Visible = false;
                        this.grWaitingList.Dock = DockStyle.None;
                        this.pnPrevious.Visible = true;
                        this.pnPrevious.Dock = DockStyle.Fill;

                        this.patientReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RefID).ToString());
                        this.receiptCode = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReceiptID).ToString());
                        this.sReferenceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString();
                        this.patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        this.serviceCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString(), string.Empty);
                        this.serviceName = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceName).ToString(), string.Empty);
                        this.iStatus = ISDBNULL2INT32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Status), 404);
                        this.iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                        this.patientType = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientType));
                        this.lbSTT.Text = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_STT).ToString();

                        string name = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString(), string.Empty);
                        string gender = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString(), string.Empty);
                        string year = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString(), string.Empty);
                        string address = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientAddress).ToString(), string.Empty);
                        this.grMain.Text = s_namekp + " | " + Convert.ToString(serviceName + " - Họ tên: " + name + " | Giới tính: " + gender + " | Năm sinh: " + year + " | Địa chỉ: " + address);

                        if (iStatus == 0)
                            this.butNew.Enabled = true;
                        this.txtServiceName.Text = serviceName;
                        //picCapturePro.Refresh();
                        this.GetInfoPatient(this.patientCode);
                        this.GetHistoryPatient();
                        this.GetTemplate();
                        //this.TotalMoney();
                        if (this.CheckCompleted.Checked)
                        {
                            int rowHandle = this.gridView_PreviousList.LocateByValue("SuggestedID", this.receiptCode);
                            this.gridView_PreviousList.FocusedRowHandle = rowHandle;
                            this.gridView_PreviousList_DoubleClick(sender, e);
                        }
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

        private void GetHistoryPatient()
        {
            this.gridControl_PreviousList.DataSource = ServiceRadiologyBLL.ListPrevious(this.patientCode, iMenu);
        }

        private void GetInfoPatient(string sPatient)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(sPatient, this.patientReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    this.lbMabn01.Text = objPatient.PatientCode;
                    this.lbHoten01.Text = objPatient.PatientName;
                    this.lbNamsinh01.Text = objPatient.PatientBirthday.ToString().Substring(0, 10); //objPatient.PatientBirthyear.ToString();
                    this.lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    this.lbDiachi01.Text = objPatient.PatientAddress.TrimEnd(',');
                    if (!string.IsNullOrEmpty(objPatient.WardName))
                        this.lbDiachi01.Text += ", " + objPatient.WardName;
                    if (!string.IsNullOrEmpty(objPatient.DistrictName))
                        this.lbDiachi01.Text += ", " + objPatient.DistrictName;
                    if (!string.IsNullOrEmpty(objPatient.ProvincialName))
                        this.lbDiachi01.Text += ", " + objPatient.ProvincialName;
                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        picPatient.Image = (Bitmap)b;
                    }
                    else
                    {
                        Bitmap b1 = new Bitmap("NoImgPatient.jpeg");
                        this.picPatient.Image = (Bitmap)b1;
                    }
                }
                else
                    return;
            }
            catch { return; }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null && txtServiceName.Text != string.Empty)
                    {
                        serviceCode = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                        String employeeCodeDoctorTemp = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, col_EmployeeCodeDoctor).ToString(), string.Empty);
                        if (employeeCodeDoctorTemp == this.employeeCodeDoctor)
                        {
                            if (serviceCode != string.Empty)
                            {
                                this.gridControl_PreviousList.Visible = true;
                                this.txtTemplateCode.Properties.ReadOnly = true;
                                this.txtTemplateCode.Enabled = txtServiceName.Enabled = txtContent.Enabled = txtConclusion.Enabled = txtProposal.Enabled = true;
                                this.EnableField(true);
                                this.butSave.Enabled = this.butUndo.Enabled = this.pnListImage.Enabled = this.butHandPoint.Enabled = true;
                                this.butEdit.Enabled = this.butPrint.Enabled = false;
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
                if (this.checkWaiting.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(0);
                }
                if (this.CheckCompleted.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(1);
                }
                this.EnableButton(true);
                this.butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void frmNoiSoiGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: this.butReload_Click(sender, e); break;                  //F5 - Refresh
                    case Keys.F1: this.butContinues_Click(sender, e); break;               //F1 - Bệnh nhân tiếp
                    case Keys.F2: this.butNew_Click(sender, e); break;                     //F2 - Thực hiện
                    case Keys.F3: this.butSave_Click(sender, e); break;                    //F3 - Lưu
                    case Keys.F6: this.butPrint_Click(sender, e); break;                   //F6 - In toa
                    case Keys.F10: //F10 - chup hinh
                        if (this.patientReceiveID > 0)
                            this.CapturePicture(); break;
                    case Keys.F11: //F11 - Brower Image
                        if (this.patientReceiveID > 0)
                            this.tool_SelectImages_Click(sender, e); break;
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
                    strSource = this.f_Get_AutoRichText(txt);
                    auto = this.SearchCharecter(strSource);
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
            try
            {
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
            }
            catch { }
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

        private string f_Get_AutoRichText(DevExpress.XtraRichEdit.RichEditControl txt)
        {
            int iSelect = 0;
            int iStart = 0;
            int chieudai = 0;
            string str = string.Empty, strFind = string.Empty, strSource = string.Empty;
            strSource = txt.Text;
            //strSource = strSource.Replace("\n", " ");
            //strSource = strSource.Replace("\r", " ");
            //strSource = strSource.Replace("\t", " ");
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

        private void SelectCurrentLine(DevExpress.XtraRichEdit.RichEditControl txt)
        {
            StartOfLineCommand startOfLineCommand = new StartOfLineCommand(txt);
            EndOfLineCommand endOfLineCommand = new EndOfLineCommand(txt);

            startOfLineCommand.Execute();
            int selectStart = txt.Document.Selection.Start.ToInt();
            int start = txt.Document.CaretPosition.ToInt();
            endOfLineCommand.Execute();
            int length = txt.Document.CaretPosition.ToInt() - start;
            DocumentRange range = txt.Document.CreateRange(start, length);
            DocumentRange range2 = txt.Document.CreateRange(start, length + 1);
            string text = txt.Document.GetText(range2);

            //if (text.EndsWith(Environment.NewLine))
            //    this.txtContent.Document.Selection = range2;
            //else
            //    this.txtContent.Document.Selection = range;
        }

        private void txtProposal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.MemoEdit txt = (DevExpress.XtraEditors.MemoEdit)(sender);
                string auto = "", s1 = "", s2 = "", strSource = "";
                if (e.KeyChar == ' ')
                {
                    strSource = this.f_Get_Auto(txt);
                    auto = this.SearchCharecter(strSource);
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
                string auto = string.Empty, s1 = string.Empty, s2 = string.Empty, strSource = string.Empty;
                if (e.KeyChar == ' ')
                {
                    //Document documenttest = txt.Document;
                    //documenttest.BeginUpdate();
                    //DocumentRange range01 = documenttest.Selection;
                    //int tempStart = range01.Start.ToInt();
                    //int tempEnd = range01.End.ToInt();
                    //int tempLength = range01.Length;
                    //documenttest.Replace(range, " test text ");
                    //documenttest.Selection = range;
                    //string chuoiTemp = txt.Document.Text.Substring(tempStart - 5, 5).ToString();

                    //string temp = txt.Text;
                    strSource = this.f_Get_AutoRichText(txt);
                    auto = this.SearchCharecter(strSource);
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
            catch { return; }
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

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null && this.txtServiceName.Text != string.Empty)
                    {
                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn huỷ kết quả đọc trả này?", "Bệnh viện điện tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            String employeeCodeDoctorTemp = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_EmployeeCodeDoctor).ToString(), string.Empty);
                            if (employeeCodeDoctorTemp == this.employeeCodeDoctor || this.isAdmin || this.isEmployeeCodeOther)
                            {
                                Int32 iResult = 0;
                                ServiceRadiologyBLL.DelRadiologyEntry(this.receiptCode, ref iResult);
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
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butHandPoint_Click(object sender, EventArgs e)
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
                    doInsertService.Proposal = txtProposal.Text.ToString();
                    doInsertService.PostingDate = Utils.DateTimeServer();
                    doInsertService.PatientReceiveID = this.patientReceiveID;
                    doInsertService.Done = 1;
                    doInsertService.EmployeeCode = s_uSerid;
                    doInsertService.SuggestedID = this.receiptCode;
                    doInsertService.EmployeeCodeDoctor = this.employeeCodeDoctor;
                    doInsertService.ShiftWork = this.shiftWork;
                };
                int iresult = ServiceRadiologyBLL.InsRadiologyEntry(doInsertService, ref this.dRadiologyEntryID, "CDHA");
                if (iresult > 0 && this.dRadiologyEntryID > 0)
                {
                    frmChiDinhDichVu frm = new frmChiDinhDichVu(this.patientReceiveID, this.patientCode, this.s_uSerid, iObjectCode, this.sTheBHYT, this.iTraituyen, sReferenceCode, this.patientType, this.s_makp, this.s_uSerid, this.serviceCode, this.shiftWork, this.dtWorking);
                    frm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Lưu kết quả " + txtServiceName.Text.ToUpper() + " không thành công! \t\n Hãy kiểm tra lại thông tin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btChangeDepart_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceGroupCode = "'CDHA'", serviceCategoryCode = "'LO0002'";
                string tempServiceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString();
                string tempPatientCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString();
                Int32 tempObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                decimal tempReceiptID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReceiptID).ToString());
                Int32 tempPaid = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Paid));
                string tempReferenceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString();
                frmDepartmentOther frmDepartment = new frmDepartmentOther(this.s_uSerid, this.s_makp, tempPatientCode, this.patientReceiveID, tempServiceCode, tempObjectCode, this.patientType, tempReferenceCode, tempPaid, tempReceiptID, serviceGroupCode, serviceCategoryCode, this.employeeCodeDoctor, this.CheckCompleted.Checked ? 1 : 0, this.shiftWork);
                frmDepartment.ShowDialog();
                if (frmDepartment.reload)
                    this.butReload_Click(sender, e);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_PreviousList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null)
                    {
                        //this.CleanerField();
                        this.serviceCode = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_ServiceCode).ToString(), string.Empty);
                        this.dRadiologyEntryID = ISDBNULL2DECIMAL(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_RowID).ToString(), string.Empty);
                        this.lbSTT.Text = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_STT).ToString();
                        if (this.serviceCode != string.Empty && this.receiptCode > 0)
                        {
                            ServiceRadiologyEntryInf first = ServiceRadiologyBLL.ObjRadiologyEntry(this.dRadiologyEntryID);
                            this.butEdit.Enabled = true;
                            this.butPrint.Enabled = true;
                            this.butCancel.Enabled = true;
                            if (first != null && !string.IsNullOrEmpty(first.PatientCode))
                            {
                                this.txtServiceName.Text = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, this.col_ServiceName).ToString(), string.Empty);
                                this.txtContent.RtfText = first.Contents;
                                string stemp = txtContent.HtmlText;
                                this.txtConclusion.RtfText = first.Conclusion;
                                this.txtProposal.Text = first.Proposal;
                                this.receiptCode = first.SuggestedID;
                                this.sReferenceCode = first.ReferenceCode;
                                this.patientReceiveID = first.PatientReceiveID;
                                this.dtResult = first.PostingDate;
                            }
                            else
                            {
                                    this.txtContent.Text = this.txtProposal.Text = this.txtConclusion.Text = string.Empty;
                            }
                            //if (this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "'").Length > 0)
                            //{
                            //    DataTable tableTemplate = this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "'").CopyToDataTable();
                            //    if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                            //        this.printPaper = tableTemplate.Rows[0]["PrintPaper"].ToString();
                            //}
                            this.pnListImage.Controls.Clear();
                            var imageList = ServiceRadiologyBLL.ListRadiologyDetail(dRadiologyEntryID);
                            if (imageList.ToList().Count > 0)
                            {
                                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                                {
                                    PictureInf imgInf = new PictureInf { id = image.RadiologyRowID + "_" + image.RowID, pathPicture = string.Empty, imagebyte = image.Image, check = image.Checked };
                                    this.listPicture.Add(imgInf);
                                }
                                this.LoadPanelPicture();
                            }
                        }
                        else
                        {
                            this.serviceCode = string.Empty;
                            return;
                        }
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #region Capture news

        //private string path_image_full = string.Empty;
        //private string path_video_full = string.Empty;

        public string path_resize = string.Empty;
        private string path_thumuc = string.Empty;
        private DirectX.Capture.Capture capture = null;
        private Filters filters = null;
        private bool sampleGrabber = false;
        private int iCardNumber = 0;
        private string idPicfocus = string.Empty;
        private List<PictureInf> listPicture = new List<PictureInf>();
        private bool SampleGrabber
        {
            get { return this.sampleGrabber; }
            set
            {
                if ((this.capture != null) && (this.capture.AllowSampleGrabber))
                    this.sampleGrabber = value;
                else
                    this.sampleGrabber = false;
                this.menuSampleGrabber.Checked = this.sampleGrabber;
                if (this.sampleGrabber)
                {
                    if (this.capture != null)
                        this.capture.FrameEvent2 += new DirectX.Capture.Capture.HeFrame(this.CaptureDone);
                }
                else
                {
                    if (this.capture != null)
                    {
                        this.capture.DisableEvent();
                        this.capture.FrameEvent2 -= new DirectX.Capture.Capture.HeFrame(this.CaptureDone);
                    }
                }
            }
        }

        private void InitMenu()
        {
            if (this.capture != null)
            {
                this.capture.AllowSampleGrabber = this.menuAllowSampleGrabber1.Checked;
                this.menuSampleGrabber.Enabled = this.menuAllowSampleGrabber1.Checked;
                this.menuSampleGrabber.Visible = this.menuAllowSampleGrabber1.Checked;
                this.capture.VideoSource = this.capture.VideoSource;
            }
        }
        
        private void UpdateMenuConfig()
        {
            ToolStripMenuItem newChild;
            Source s;
            Source current;
            Filter f;
            PropertyPage p;
            Control oldPreviewWindow = null;

            // Disable preview to avoid additional flashes (optional)
            if (capture != null)
            {
                oldPreviewWindow = capture.PreviewWindow;
                capture.PreviewWindow = null;
            }

            // Load video devices
            Filter videoDevice = null;
            if (capture != null)
                videoDevice = capture.VideoDevice;
            mnuVideoDevices.DropDownItems.Clear();
            newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuVideoDevices_Click));
            newChild.Checked = (videoDevice == null);
            mnuVideoDevices.DropDownItems.Add(newChild);
            for (int c = 0; c < filters.VideoInputDevices.Count; c++)
            {
                f = filters.VideoInputDevices[c];
                newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuVideoDevices_Click));
                newChild.Checked = (videoDevice == f);
                newChild.Tag = c;
                mnuVideoDevices.DropDownItems.Add(newChild);
            }
            mnuVideoDevices.Enabled = (filters.VideoInputDevices.Count > 0);

            // Load audio devices
            try
            {
                Filter audioDevice = null;
                if (capture != null)
                    audioDevice = capture.AudioDevice;
                mnuAudioDevices.DropDownItems.Clear();
                newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuAudioDevices_Click));
                newChild.Checked = (audioDevice == null);
                mnuAudioDevices.DropDownItems.Add(newChild);
                for (int c = 0; c < filters.AudioInputDevices.Count; c++)
                {
                    f = filters.AudioInputDevices[c];
                    newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuAudioDevices_Click));
                    newChild.Checked = (audioDevice == f);
                    mnuAudioDevices.DropDownItems.Add(newChild);
                }
                mnuAudioDevices.Enabled = (filters.AudioInputDevices.Count > 0);
            }
            catch { }

            // Load video compressors
            try
            {
                mnuVideoCompressors.DropDownItems.Clear();
                newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuVideoCompressors_Click));
                newChild.Checked = (capture.VideoCompressor == null);
                mnuVideoCompressors.DropDownItems.Add(newChild);
                for (int c = 0; c < filters.VideoCompressors.Count; c++)
                {
                    f = filters.VideoCompressors[c];
                    newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuVideoCompressors_Click));
                    newChild.Checked = (capture.VideoCompressor == f);
                    mnuVideoCompressors.DropDownItems.Add(newChild);
                }
                mnuVideoCompressors.Enabled = ((capture.VideoDevice != null) && (filters.VideoCompressors.Count > 0));
            }
            catch { mnuVideoCompressors.Enabled = false; }

            // Load audio compressors
            try
            {
                mnuAudioCompressors.DropDownItems.Clear();
                newChild = new ToolStripMenuItem("(None)", null, new EventHandler(mnuAudioCompressors_Click));
                newChild.Checked = (capture.AudioCompressor == null);
                mnuAudioCompressors.DropDownItems.Add(newChild);
                for (int c = 0; c < filters.AudioCompressors.Count; c++)
                {
                    f = filters.AudioCompressors[c];
                    newChild = new ToolStripMenuItem(f.Name, null, new EventHandler(mnuAudioCompressors_Click));
                    newChild.Checked = (capture.AudioCompressor == f);
                    mnuAudioCompressors.DropDownItems.Add(newChild);
                }
                mnuAudioCompressors.Enabled = ((this.capture.AudioAvailable) && (this.filters.AudioCompressors.Count > 0));
            }
            catch { mnuAudioCompressors.Enabled = false; }

            // Load video sources
            try
            {
                mnuVideoSources.DropDownItems.Clear();
                capture.VideoSources = null;
                current = capture.VideoSource;
                for (int c = 0; c < capture.VideoSources.Count; c++)
                {
                    s = capture.VideoSources[c];
                    newChild = new ToolStripMenuItem(s.Name, null, new EventHandler(mnuVideoSources_Click));
                    newChild.Checked = (current == s);
                    mnuVideoSources.DropDownItems.Add(newChild);
                }
                mnuVideoSources.Enabled = (capture.VideoSources.Count > 0);
                if (current != null)
                {
                    capture.VideoSource = current;
                }
            }
            catch { mnuVideoSources.Enabled = false; }

            // Load audio sources
            try
            {
                mnuAudioSources.DropDownItems.Clear();
                this.capture.AudioSources = null;
                current = capture.AudioSource;
                for (int c = 0; c < capture.AudioSources.Count; c++)
                {
                    s = capture.AudioSources[c];
                    newChild = new ToolStripMenuItem(s.Name, null, new EventHandler(mnuAudioSources_Click));
                    newChild.Checked = (current == s);
                    mnuAudioSources.DropDownItems.Add(newChild);
                }
                mnuAudioSources.Enabled = (capture.AudioSources.Count > 0);
            }
            catch { mnuAudioSources.Enabled = false; }

            // Start of new Brian's Low code, with some modifcations to make it more usable,
            // such as listing the available video standards and color spaces only.
            // Load video standards
            menuVideoStandard1.DropDownItems.Clear();
            if ((this.capture != null) &&
                (this.capture.dxUtils != null) && (this.capture.dxUtils.VideoDecoderAvail))
            {
                try
                {
                    menuVideoStandard1.DropDownItems.Clear();
                    DShowNET.AnalogVideoStandard currentStandard = capture.dxUtils.VideoStandard;
                    DShowNET.AnalogVideoStandard availableStandards = capture.dxUtils.AvailableVideoStandards;
                    int mask = 1;
                    while (mask <= (int)DShowNET.AnalogVideoStandard.PAL_N_COMBO)
                    {
                        int avs = mask & (int)availableStandards;
                        if (avs != 0)
                        {
                            newChild = new ToolStripMenuItem(((DShowNET.AnalogVideoStandard)avs).ToString(), null, new EventHandler(menuVideoStandard1_Click));
                            newChild.Checked = (currentStandard == (DShowNET.AnalogVideoStandard)avs);
                            menuVideoStandard1.DropDownItems.Add(newChild);
                        }
                        mask *= 2;
                    }
                    menuVideoStandard1.Enabled = true;
                }
                catch { menuVideoStandard1.Enabled = false; }
            }
            else
            {
                menuVideoStandard1.Enabled = false;
            }

            // Load color spaces
            menuColorSpace1.DropDownItems.Clear();
            if ((this.capture != null) && (this.capture.dxUtils != null))
            {
                try
                {
                    DxUtils.ColorSpaceEnum currentColorSpace = capture.ColorSpace;
                    string[] names = this.capture.dxUtils.SubTypeList;
                    foreach (string name in names)
                    {
                        newChild = new ToolStripMenuItem(name, null, new EventHandler(menuColorSpace1_Click));
                        newChild.Checked = (currentColorSpace == (DxUtils.ColorSpaceEnum)Enum.Parse(typeof(DxUtils.ColorSpaceEnum), name));
                        menuColorSpace1.DropDownItems.Add(newChild);
                    }
                    menuColorSpace1.Enabled = true;
                }
                catch { menuColorSpace1.Enabled = false; }
            }
            else
            {
                menuColorSpace1.Enabled = false;
            }
            // End of new Brian's Low code

            // Load frame rates
            try
            {
                mnuFrameRates.DropDownItems.Clear();
                int frameRate = (int)(capture.FrameRate * 1000);
                newChild = new ToolStripMenuItem("15 fps", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 15000);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("24 fps (Film)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 24000);
                mnuFrameRates.DropDownItems.Add(newChild);

                newChild = new ToolStripMenuItem("25 fps (PAL)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 25000);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("29.997 fps (NTSC)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 29997);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("30 fps (~NTSC)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 30000);
                mnuFrameRates.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("59.994 fps (2xNTSC)", null, new EventHandler(mnuFrameRates_Click));
                newChild.Checked = (frameRate == 59994);
                mnuFrameRates.DropDownItems.Add(newChild);
                mnuFrameRates.Enabled = true;
            }
            catch { mnuFrameRates.Enabled = false; }

            // Load frame sizes
            try
            {
                mnuFrameSizes.DropDownItems.Clear();
                Size frameSize = capture.FrameSize;
                newChild = new ToolStripMenuItem("160 x 120", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(160, 120));

                mnuFrameSizes.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("320 x 240", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(320, 240));

                mnuFrameSizes.DropDownItems.Add(newChild);

                // Added a Pal format ...
                newChild = new ToolStripMenuItem("352 x 288", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(352, 288));

                mnuFrameSizes.DropDownItems.Add(newChild);

                newChild = new ToolStripMenuItem("640 x 480", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(640, 480));

                mnuFrameSizes.DropDownItems.Add(newChild);

                // Added a Ntsc format ...
                newChild = new ToolStripMenuItem("720 x 480", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(720, 480));

                mnuFrameSizes.DropDownItems.Add(newChild);
                mnuFrameSizes.Enabled = true;

                // Added some Pal formats ...
                newChild = new ToolStripMenuItem("720 x 576", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(720, 576));
                mnuFrameSizes.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("768 x 576", null, new EventHandler(mnuFrameSizes_Click));
                newChild.Checked = (frameSize == new Size(768, 576));
                mnuFrameSizes.DropDownItems.Add(newChild);
            }
            catch { mnuFrameSizes.Enabled = false; }

            // Load audio channels
            //try
            //{
            //    mnuAudioChannels.DropDownItems.Clear();
            //    short audioChannels = capture.AudioChannels;
            //    newChild = new ToolStripMenuItem("Mono", null, new EventHandler(mnuAudioChannels_Click));
            //    newChild.Checked = (audioChannels == 1);
            //    mnuAudioChannels.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem("Stereo", null, new EventHandler(mnuAudioChannels_Click));
            //    newChild.Checked = (audioChannels == 2);
            //    mnuAudioChannels.DropDownItems.Add(newChild);
            //    mnuAudioChannels.Enabled = true;
            //    capture.AudioSources = null;
            //}
            //catch { mnuAudioChannels.Enabled = false; }

            // Load audio sampling rate
            //try
            //{
            //    mnuAudioSamplingRate.DropDownItems.Clear();
            //    int samplingRate = capture.AudioSamplingRate;
            //    newChild = new ToolStripMenuItem("8 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
            //    newChild.Checked = (samplingRate == 8000);
            //    mnuAudioSamplingRate.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem("11,025 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
            //    newChild.Checked = (capture.AudioSamplingRate == 11025);
            //    mnuAudioSamplingRate.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem("22,05 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
            //    newChild.Checked = (capture.AudioSamplingRate == 22050);
            //    mnuAudioSamplingRate.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem("32 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
            //    newChild.Checked = (capture.AudioSamplingRate == 32000);
            //    mnuAudioSamplingRate.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem("44,1 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
            //    newChild.Checked = (capture.AudioSamplingRate == 44100);
            //    mnuAudioSamplingRate.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem("48 kHz", null, new EventHandler(mnuAudioSamplingRate_Click));
            //    newChild.Checked = (capture.AudioSamplingRate == 48000);
            //    mnuAudioSamplingRate.DropDownItems.Add(newChild);
            //    mnuAudioSamplingRate.Enabled = true;
            //}
            //catch { mnuAudioSamplingRate.Enabled = false; }

            // Load audio sample sizes
            try
            {
                mnuAudioSampleSizes.DropDownItems.Clear();
                short sampleSize = capture.AudioSampleSize;
                newChild = new ToolStripMenuItem("8 bit", null, new EventHandler(mnuAudioSampleSizes_Click));
                newChild.Checked = (sampleSize == 8);
                mnuAudioSampleSizes.DropDownItems.Add(newChild);
                newChild = new ToolStripMenuItem("16 bit", null, new EventHandler(mnuAudioSampleSizes_Click));
                newChild.Checked = (sampleSize == 16);
                mnuAudioSampleSizes.DropDownItems.Add(newChild);
                mnuAudioSampleSizes.Enabled = true;
            }
            catch { mnuAudioSampleSizes.Enabled = false; }

            // Load property pages
            try
            {
                this.mnuPropertyPages.DropDownItems.Clear();
                for (int c = 0; c < this.capture.PropertyPages.Count; c++)
                {
                    p = this.capture.PropertyPages[c];
                    newChild = new ToolStripMenuItem(p.Name + "...", null, new EventHandler(this.mnuPropertyPages_Click));
                    this.mnuPropertyPages.DropDownItems.Add(newChild);
                }
                this.mnuPropertyPages.Enabled = (this.capture.PropertyPages.Count > 0);
            }
            catch
            {
                this.mnuPropertyPages.Enabled = false;
            }

            // Load TV Tuner channels
            //try
            //{
            //    mnuChannel.DropDownItems.Clear();
            //    if (this.TunerModeType == AMTunerModeType.TV)
            //    {
            //        int current_channel = this.tvSelections.CurrentChannel;

            //        for (int c = 1; c <= this.tvSelections.NbrTunerChannels; c++)
            //        {
            //            this.tvSelections.CurrentChannel = c;
            //            newChild = new ToolStripMenuItem(this.tvSelections.GetChannelName.ToString(),null, new EventHandler(mnuChannel_Click));
            //            newChild.Checked = ((current_channel == c) && (this.capture.Tuner.Channel == this.tvSelections.GetChannelNumber));
            //            mnuChannel.DropDownItems.Add(newChild);
            //        }

            //        this.tvSelections.CurrentChannel = current_channel;
            //        //this.capture.Tuner.Channel = this.tvSelections.GetChannelNumber;

            //        mnuChannel.Enabled = true;
            //    }
            //    else
            //    {
            //        mnuChannel.Enabled = false;
            //    }
            //}
            //catch { mnuChannel.Enabled = false; }

            // Load Tuner Modes (such as TV and FM Radio
            //try
            //{
            //    this.menuTunerModes1.DropDownItems.Clear();
            //    if ((this.capture.Tuner.AvailableAudioModes.TV) &&
            //        (this.capture.Tuner.AvailableAudioModes.FMRadio))
            //    {
            //        newChild = new ToolStripMenuItem(AMTunerModeType.TV.ToString(), null, new EventHandler(menuTunerModes1_Click));
            //        newChild.Checked = (this.TunerModeType == AMTunerModeType.TV);
            //        this.menuTunerModes1.DropDownItems.Add(newChild);
            //        newChild = new ToolStripMenuItem(AMTunerModeType.FMRadio.ToString(), null, new EventHandler(menuTunerModes1_Click));
            //        newChild.Checked = (this.TunerModeType == AMTunerModeType.FMRadio);
            //        newChild.Enabled = false;
            //        this.menuTunerModes1.DropDownItems.Add(newChild);

            //        this.menuTunerModes1.Enabled = true;
            //        this.menuTunerModes1.Visible = true;

            //    }
            //    else
            //    {
            //        this.menuTunerModes1.Enabled = false;
            //        this.menuTunerModes1.Visible = false;
            //    }

            //}
            //catch
            //{
            //    this.menuTunerModes1.Enabled = false;
            //    this.menuTunerModes1.Visible = false;
            //}

            // Load TV Tuner input types
            //try
            //{
            //    mnuInputType.DropDownItems.Clear();
            //    newChild = new ToolStripMenuItem(TunerInputType.Cable.ToString(), null, new EventHandler(mnuInputType_Click));
            //    newChild.Checked = (capture.Tuner.InputType == TunerInputType.Cable);
            //    mnuInputType.DropDownItems.Add(newChild);
            //    newChild = new ToolStripMenuItem(TunerInputType.Antenna.ToString(), null, new EventHandler(mnuInputType_Click));
            //    newChild.Checked = (capture.Tuner.InputType == TunerInputType.Antenna);
            //    mnuInputType.DropDownItems.Add(newChild);
            //    mnuInputType.Enabled = true;
            //}
            //catch { mnuInputType.Enabled = false; }

            // Load audio/video recording file modes
            try
            {
                this.menuAVRecFileModes.DropDownItems.Clear();
                // Fill in all file modes, use enumerations also as string (and file extension)
                for (int i = 0; i < 3; i++)
                {
                    newChild = new ToolStripMenuItem(((DirectX.Capture.Capture.RecFileModeType)i).ToString(), null, new EventHandler(this.menuAVRecFileModes_Click));
                    newChild.Checked = (i == (int)this.capture.RecFileMode);
                    this.menuAVRecFileModes.DropDownItems.Add(newChild);
                }
                this.menuAVRecFileModes.Enabled = true;
            }
            catch
            {
                this.menuAVRecFileModes.Enabled = false;
            }

            // Enable/disable caps
            this.mnuVideoCaps.Enabled = ((this.capture != null) && (this.capture.VideoCaps != null));
            this.menuPreviewCaps.Enabled = ((this.capture != null) && (this.capture.PreviewCaps != null));
            //mnuAudioCaps.Enabled = ((capture != null) && (capture.AudioCaps != null));

            // Check Preview menu option
            this.mnuPreview.Checked = (oldPreviewWindow != null);
            this.mnuPreview.Enabled = (this.capture != null);

            // Reenable preview if it was enabled before
            if (this.capture != null)
                this.capture.PreviewWindow = oldPreviewWindow;
        }
        private bool audioViaPci = false;
        public bool AudioViaPci
        {
            get { return this.audioViaPci; }
            set
            {
                this.audioViaPci = value;
            }
        }
        private void OnCaptureComplete(object sender, EventArgs e)
        {
            Debug.WriteLine("Capture complete.");
        }
        private void mnuVideoDevices_Click(object sender, EventArgs e)
        {
            try
            {
                Filter videoDevice = null;
                Filter audioDevice = null;
                this.SampleGrabber = false;
                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }
                int index = 0;
                this.iCardNumber = mnuVideoDevices.DropDownItems.Count;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                    videoDevice = (index > 0 ? filters.VideoInputDevices[index - 1] : null);
                }
                else if (this.iCardNumber > 0)
                    videoDevice = (iCardNumber > 0 ? filters.VideoInputDevices[this.positionCardCaptureSelected - 1] : null);//videoDevice = (iCardNumber > 0 ? filters.VideoInputDevices[0] : null);
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new DirectX.Capture.Capture(videoDevice, audioDevice, AudioViaPci);
                    this.capture.RecFileMode = DirectX.Capture.Capture.RecFileModeType.Wmv;
                    capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    capture.Filename = this.txtFilename.Text;
                    this.InitMenu();
                }
                this.UpdateMenuConfig();
                if (item != null)
                {
                    this.positionCardCaptureSelected = index;
                    this.dsConfigCapture.Tables[0].Rows[0]["positionCardCapture"] = this.positionCardCaptureSelected;
                    this.menuSampleGrabber_Click(sender, e);
                    this.mnuPreview_Click(sender, e);
                    this.WriteFileConfigCapture();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Video device not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuAudioDevices_Click(object sender, EventArgs e)
        {
            try
            {
                Filter videoDevice = null;
                Filter audioDevice = null;
                this.SampleGrabber = false;
                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                audioDevice = (index > 0 ? filters.AudioInputDevices[index - 1] : null);
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new DirectX.Capture.Capture(videoDevice, audioDevice, AudioViaPci);
                    capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    capture.Filename = this.txtFilename.Text;
                    this.InitMenu();
                }
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Audio device not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuVideoCompressors_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.VideoCompressor = (index > 0 ? filters.VideoCompressors[index - 1] : null);
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Video compressor not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void menuColorSpace1_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                DxUtils.ColorSpaceEnum c = (DxUtils.ColorSpaceEnum)Enum.Parse(typeof(DxUtils.ColorSpaceEnum), item.Text);
                this.capture.ColorSpace = c;
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to set color space.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuFrameRates_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split(' ');
                capture.FrameRate = double.Parse(s[0]);
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Frame rate not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void menuAVRecFileModes_Click(object sender, System.EventArgs e)
        {
            try
            {
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.RecFileMode = (DirectX.Capture.Capture.RecFileModeType)index;
                this.txtFilename.Text = this.capture.Filename;
                switch (capture.RecFileMode)
                {
                    case DirectX.Capture.Capture.RecFileModeType.Wmv:
                    case DirectX.Capture.Capture.RecFileModeType.Wma:
                        break;
                    case DirectX.Capture.Capture.RecFileModeType.Avi:
                        break;
                    default:
                        break;
                }
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Audio sample size not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuFrameSizes_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool preview = (this.capture.PreviewWindow != null);
                this.capture.PreviewWindow = null;
                // Update the frame size
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split('x');
                Size size = new Size(int.Parse(s[0]), int.Parse(s[1]));
                this.capture.FrameSize = size;
                //this.pnCapture.Size = size;
                this.ptb_Capture.Size = size;
                // Restore previous preview setting
                //this.capture.PreviewWindow = (preview ? this.pnCapture : null);
                this.capture.PreviewWindow = (preview ? this.ptb_Capture : null);
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Frame size not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuAudioSampleSizes_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string[] s = item.Text.Split(' ');
                short sampleSize = short.Parse(s[0]);
                capture.AudioSampleSize = sampleSize;
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Audio sample size not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuPropertyPages_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    int index = 0;
            //    ToolStripMenuItem item = sender as ToolStripMenuItem;
            //    if (item != null)
            //    {
            //        index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
            //    }
            //    this.capture.PropertyPages = null;
            //    capture.PropertyPages[index].Show(this);

            //    if (this.mnuPropertyPages.DropDownItems[index].Text == "TV Tuner...")
            //    {
            //        this.DefaultChannel = this.capture.Tuner.Channel;
            //        this.DefaultCountryCode = this.capture.Tuner.CountryCode;
            //        this.DefaultTuningSpace = this.capture.Tuner.TuningSpace;
            //        this.tunerInputType = this.capture.Tuner.InputType;
            //    }
            //    this.UpdateMenuConfig();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show("Unable display property page. Please submit a bug report.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        private void menuVideoStandard1_Click(object sender, System.EventArgs e)
        {
            if ((this.capture == null) || (this.capture.dxUtils == null))
            {
                return;
            }
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                AnalogVideoStandard a = (AnalogVideoStandard)Enum.Parse(typeof(AnalogVideoStandard), item.Text);
                capture.dxUtils.VideoStandard = a;
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to set video standard.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuAudioCompressors_Click(object sender, EventArgs e)
        {
            try
            {
                // Change the audio compressor
                // We subtract 1 from m.Index beacuse the first item is (None)
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                capture.AudioCompressor = (index > 0 ? filters.AudioCompressors[index - 1] : null);
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Audio compressor not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuAudioSources_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Choose the audio source
                // If the device only has one source, this menu item will be disabled
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                this.capture.AudioSources = null;
                capture.AudioSource = capture.AudioSources[index];
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to set audio source. Please submit bug report.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void mnuVideoSources_Click(object sender, EventArgs e)
        {
            try
            {
                // Choose the video source
                // If the device only has one source, this menu item will be disabled
                int index = 0;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item != null)
                {
                    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                }
                this.capture.VideoSources = null;
                capture.VideoSource = capture.VideoSources[index];
                this.UpdateMenuConfig();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to set video source. Please submit bug report.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void menuAllowSampleGrabber1_Click(object sender, EventArgs e)
        {
            this.menuAllowSampleGrabber1.Checked = !this.menuAllowSampleGrabber1.Checked;
        }
        private void menuSampleGrabber_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SampleGrabber)
                {
                    this.SampleGrabber = false;
                }
                else
                {
                    this.SampleGrabber = true;
                }
            }
            catch { return; }
        }
        private void mnuPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture.PreviewWindow == null)
                {
                    //capture.PreviewWindow = this.pnCapture;
                    capture.PreviewWindow = this.ptb_Capture;
                    mnuPreview.Checked = true;
                }
                else
                {
                    capture.PreviewWindow = null;
                    mnuPreview.Checked = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to enable/disable preview. Please submit a bug report.\n\n" + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CaptureDone(System.Drawing.Bitmap e)
        {
            this.ptb_Capture.Image = e;
        }
        private void tool_SelectImages_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.RestoreDirectory = true;
                opf.Multiselect = true;
                opf.Filter = "All (*.*)|*.*|*.gif|*.gif|*.jpg|*.jpg|*.bmp|*.bmp";
                opf.RestoreDirectory = true;
                DialogResult dr = opf.ShowDialog();
                int imageNumber = this.pnListImage.Controls.Count + 1;
                if (dr == DialogResult.OK && opf.FileNames.Length > 0)
                {
                    for (int i = 0; i < opf.FileNames.Length; i++)
                    {
                        imageNumber += 1;
                        if (!this.listPicture.Exists(p => p.pathPicture == opf.FileNames[i].ToString()))
                        {
                            PictureInf pic = new PictureInf();
                            pic.id = this.patientCode + "_" + "Image" + imageNumber.ToString().PadLeft(2, '0') + "jpg";
                            pic.pathPicture = opf.FileNames[i].ToString();
                            pic.check = false;
                            FileStream fstr;
                            byte[] imagedata;
                            fstr = new FileStream(pic.pathPicture, FileMode.Open, FileAccess.Read);
                            imagedata = new byte[fstr.Length];
                            fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            pic.imagebyte = imagedata;
                            this.listPicture.Add(pic);
                            this.LoadPanelPicture();
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void LoadPanelPicture()
        {
            this.pnListImage.Controls.Clear();
            int y = 1;
            int numberImg = 1;
            foreach (var item in this.listPicture)
            {
                UscThumbnailImage pic = new UscThumbnailImage();
                pic.id = item.id;
                pic.Size = new Size(this.pnListImage.Height + 20, this.pnListImage.Height - 2);
                Point localtion = new Point(y, 1);
                pic.Location = localtion;
                //pic.pictureBox.Image = Image.FromFile(item.pathPicture);
                Byte[] imageadata = new Byte[0];
                imageadata = (Byte[])(item.imagebyte.ToArray());
                MemoryStream memo = new MemoryStream(imageadata);
                Bitmap b = new Bitmap(Image.FromStream(memo));
                pic.pictureBox.Image = (Bitmap)b;
                pic.pictureBox.MouseUp += PictureBox_MouseUp;
                pic.pictureBox.DoubleClick += PictureBox_DoubleClick;
                pic.pictureBox.Tag = item.id;
                pic.chkImg.Text = "H " + numberImg.ToString();
                pic.chkImg.Checked = item.check;
                pic.chkImg.Tag = item.id;
                pic.chkImg.ForeColor = Color.Blue;
                pic.chkImg.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                this.pnListImage.Controls.Add(pic);
                y += pic.Size.Height + 24;
                numberImg++;
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBox pic = sender as PictureBox;
                this.idPicfocus = pic.Tag.ToString();
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    Point location = pic.PointToScreen(e.Location);
                    this.popupMenuCapture.ShowPopup(location);
                }
            }
            catch { return; }
        }

        private void tool_Photo_Click(object sender, EventArgs e)
        {
            try
            {
                this.CapturePicture();
            }
            catch
            {
                //XtraMessageBox.Show(this, "Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox pbox = sender as PictureBox;
                Bitmap bm = (Bitmap)pbox.Image;
                frmViewImage frm = new frmViewImage(bm);
                frm.ShowDialog();
            }
            catch { return; }
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)(sender);
            string idImg = c.Tag.ToString();
            if (c.Checked)
            {
                c.ForeColor = Color.Red;
                foreach (var img in this.listPicture)
                {
                    if (img.id == idImg)
                    {
                        img.check = true;
                        break;
                    }
                }
            }
            else
            {
                c.ForeColor = Color.Blue;
                foreach (var img in this.listPicture)
                {
                    if (img.id == idImg)
                    {
                        img.check = false;
                        break;
                    }
                }
            }
        }

        private void btnXemhinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Image imga = Image.FromFile(this.listPicture.FirstOrDefault(p => p.id == this.idPicfocus).pathPicture);
                //Bitmap bm = (Bitmap)imga;
                //Image<Rgb, Byte> img = new Image<Rgb, byte>(bm);
                //frmPopupViewPictureEmgu frm = new frmPopupViewPictureEmgu(img);
                //frm.ShowDialog();

                Byte[] imageadata = new Byte[0];
                imageadata = (Byte[])(this.listPicture.FirstOrDefault(p => p.id == this.idPicfocus).imagebyte.ToArray());
                MemoryStream memo = new MemoryStream(imageadata);
                Bitmap bm = new Bitmap(Image.FromStream(memo));
                frmViewImage frm = new frmViewImage(bm);
                frm.ShowDialog();
            }
            catch { return; }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string idImg = this.idPicfocus;
                if (!(idImg.Trim().Equals(string.Empty)))
                {
                    this.listPicture.RemoveAll(p => p.id == idImg);
                    this.LoadPanelPicture();
                }
            }
            catch { return; }
        }

        private void frmNoiSoiGeneral_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.capture != null)
                this.capture.Dispose();
            this.Close();
        }

        private void butStartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.capture == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                if (this.patientCode != string.Empty)
                {
                    string yyyyMMdd = this.dtServer.ToString("yyyyMMdd");
                    string pathVideo = this.toolSaveFile_SaveVideo.Text + "\\" + yyyyMMdd + "_" + this.patientCode;
                    if (!Directory.Exists(pathVideo))
                        Directory.CreateDirectory(pathVideo);
                    //fname = filename + ".avi";
                    fname = pathVideo + "_" + System.DateTime.Now.Millisecond.ToString() + ".wmv";
                    //if (File.Exists(fname))
                    //    fname = filename + "_" + System.DateTime.Now.Millisecond.ToString() + ".wmv";
                    this.Cursor = Cursors.Default;
                }
                if (!this.capture.Cued)
                    this.capture.Filename = fname;
                this.capture.Start();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(" Please select a video and/or audio device." + "\n\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butStopRecording_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.capture == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                this.capture.Stop();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Please select a video and / or audio device. \n\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTemplateCode_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }
        
        private void btnXoaTatCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa hết không?", "Bệnh viện điện tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.listPicture.Clear();
                this.LoadPanelPicture();
            }
        }

        private void CapturePicture()
        {
            //string pathName = Directory.GetCurrentDirectory();
            //this.toolSaveFile_SaveImage.Text = pathName + "\\Image";
            //this.toolSaveFile_SaveVideo.Text = pathName + "\\Video";

            string yyyymmdd = this.dtServer.Date.Year.ToString() + this.dtServer.Date.Month.ToString().PadLeft(2, '0') + this.dtServer.Date.Day.ToString().PadLeft(2, '0');
            this.path_thumuc = this.toolSaveFile_SaveImage.Text + "\\" + yyyymmdd + "\\" + this.patientCode;
            string file_name = string.Empty;
            if (!Directory.Exists(this.path_thumuc))
                Directory.CreateDirectory(this.path_thumuc);
            if (!Directory.Exists(this.path_resize))
                Directory.CreateDirectory(this.path_resize);
            if (!Directory.Exists(this.toolSaveFile_SaveImage.Text))
                Directory.CreateDirectory(this.toolSaveFile_SaveImage.Text);
            int slImage = this.GetSTTHinh(this.path_thumuc, this.patientCode, string.Empty);
            if (slImage > 25)
            {
                XtraMessageBox.Show(this, " Số lượng hình cho phép lưu trữ tối đa 25 hình! ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (this.capture != null)
                {
                    file_name = this.patientCode + "_" + "Image" + slImage.ToString().PadLeft(2, '0') + ".jpg";
                    file_name = this.path_thumuc + "\\" + file_name;
                    this.capture.GrapImg();
                    if (System.IO.Directory.Exists(this.path_thumuc) && System.IO.Directory.Exists(this.path_resize))
                    {
                        int milliseconds = 200;
                        Thread.Sleep(milliseconds);
                        this.ptb_Capture.Image.Save(file_name, ImageFormat.Jpeg);
                        if (!this.listPicture.Exists(p => p.pathPicture == file_name))
                        {
                            PictureInf pic = new PictureInf();
                            pic.id = this.patientCode + "_" + "Image" + slImage.ToString().PadLeft(2, '0') + "img";
                            pic.pathPicture = file_name;
                            pic.check = false;
                            FileStream fstr;
                            byte[] imagedata;
                            fstr = new FileStream(file_name, FileMode.Open, FileAccess.Read);
                            imagedata = new byte[fstr.Length];
                            fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            pic.imagebyte = imagedata;
                            this.listPicture.Add(pic);
                            this.LoadPanelPicture();
                        }
                        //this.ptb_Capture.Dispose();
                    }
                    else
                    {
                        XtraMessageBox.Show(this, "Không tìm thấy đường dẫn để lưu hình\n" + path_thumuc + "\nChọn đường dẫn khác không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        capture = null;
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(this, "Chưa kết nối với thiết bị. \n\nCác bước để lưu ảnh:\n- Kết nối với thiết bị thành công.\n- Chọn \"Lưu ảnh\" để tiến hành lưu ảnh hiện tại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    capture = null;
                    return;
                }
            }
        }
        
        private int GetSTTHinh(string athumuc, string amabn, string id_hinh)
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

        private void btnEditImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Byte[] imageadata = new Byte[0];
            imageadata = (Byte[])(this.listPicture.FirstOrDefault(p => p.id == this.idPicfocus).imagebyte.ToArray());
            MemoryStream memo = new MemoryStream(imageadata);
            Bitmap bm = new Bitmap(Image.FromStream(memo));
            frmViewImage_Edit frm = new frmViewImage_Edit(bm);
            frm.ShowDialog();
            if(frm.isSave)
            {
                this.listPicture.FirstOrDefault(p => p.id == this.idPicfocus).imagebyte = this.ImageToByte(frm.img);
                this.LoadPanelPicture();
            }
        }

        private void SaveJPEG(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // Jpeg image codec
            ImageCodecInfo jpegCodec = this.GetEncoderInfo("image/jpeg");
            if (jpegCodec == null)
                return;
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }

        private void menuAudioViaPci1_Click(object sender, EventArgs e)
        {
            this.AudioViaPci = !this.AudioViaPci;
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
        private void AutoChooseAudio()
        {
            try
            {
                Filter videoDevice = null;
                Filter audioDevice = null;
                this.SampleGrabber = false;
                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }
                int index = 0;
                var item = mnuAudioDevices;
                index = item.DropDown.Items.Count - 1;

                //if (item != null)
                //{
                //    index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                //}

                audioDevice = (index > 0 ? filters.AudioInputDevices[index - 1] : null);
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new DirectX.Capture.Capture(videoDevice, audioDevice, AudioViaPci);
                    capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    capture.Filename = this.txtFilename.Text;
                    this.InitMenu();
                }
                this.UpdateMenuConfig();
            }
            catch (Exception)
            {
                //XtraMessageBox.Show("Audio device not supported.\n\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void toolSaveFile_SaveVideo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.toolSaveFile_SaveVideo.Text = folderDlg.SelectedPath;
                this.dsConfigCapture.Tables[0].Rows[0]["pathvideo"] = folderDlg.SelectedPath;
                this.WriteFileConfigCapture();
            }
        }

        private void toolSaveFile_SaveImage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.toolSaveFile_SaveImage.Text = folderDlg.SelectedPath;
                this.dsConfigCapture.Tables[0].Rows[0]["pathimage"] = folderDlg.SelectedPath;
                this.WriteFileConfigCapture();
            }
        }

        private void WriteFileConfigCapture()
        {
            this.dsConfigCapture.WriteXml(Directory.GetCurrentDirectory() + "\\xml\\CaptureConfig.xml");
        }

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        #endregion

    }
}