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
using iHISOpenImageDicom;

namespace Ps.Clinic.Entry
{
    public partial class frmXQuang : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private string patientCode, patientName = string.Empty;
        private string serviceCode = string.Empty;
        private string serviceName = string.Empty;
        private string sReferenceCode = string.Empty;
        private decimal dPatientReceiveID, dReceiptCode = 0;
        private Int32 iStatus = 0, iObjectCode = 0;
        private string imageCode = string.Empty;
        public string path_image_full = @"\\temp\\Image";
        public string path_video_full = @"\\temp\\Video";
        public string path_resize = @"\\temp\\Resize";
        public string fname = string.Empty;
        private string sTheBHYT = string.Empty;
        private int iTraituyen = 0;
        private decimal dRadiologyEntryID = 0;
        private string s_makp = string.Empty, s_namekp = string.Empty;
        private string s_uSerid = string.Empty, shiftWork = string.Empty, employeeCodeDoctor = string.Empty;
        private List<DiagnosisAbbreviationsInf> ListAbb = new List<DiagnosisAbbreviationsInf>();
        private DateTime dtWorking = new DateTime();
        private int iMenu = 0;
        private List<ListFileDicom> listFileDCMData = new List<ListFileDicom>();
        private bool isAdmin = false;
        private bool isEmployeeCodeOther = false;
        private string printPaper = string.Empty;
        private DataTable tableTemplateHeader = new DataTable();
        public frmXQuang(string _spk, string _uSerid, int _Menu, string _namekp, string _employeeCodeDoctor, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            grWaitingList.Visible = true;
            grWaitingList.Dock = DockStyle.Fill;
            grPrevious.Visible = false;
            grPrevious.Dock = DockStyle.None;
            s_makp = _spk;
            s_uSerid = _uSerid;
            iMenu = _Menu;
            s_namekp = _namekp;
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
        private void frmXQuang_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = this.dtWorking;
                this.loadListPatientWaitingCompleted(0);
                this.EnableField(false);
                this.ListAbb = DiagnosisAbbreviationsBLL.ListAbb(this.s_uSerid);
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
                #endregion
            }
            catch { }
        }

        public void EnableField(bool ena)
        {
            this.lbTemplateCode.Enabled = ena;
            this.txtTemplateCode.Properties.ReadOnly = this.txtContent.ReadOnly = this.txtConclusion.ReadOnly = this.txtProposal.Properties.ReadOnly = !ena;
            this.txtNote.Properties.ReadOnly = !ena;
            ///this.txtServiceName.Properties.ReadOnly = !ena;
        }

        public void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butSave.Enabled = !b;
            this.butUndo.Enabled = !b;
            this.butEdit.Enabled = false;
            this.butPrint.Enabled = false;
            this.butCancel.Enabled = false;
            this.butImage.Enabled = !b;
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
                    var queryTemplate = TemplateDescriptionBLL.ObjTemplate(templateCode);///.FirstOrDefault();
                    if (queryTemplate != null)
                    {
                        this.txtNote.Text = queryTemplate.TemplateHeaderName;
                        this.txtContent.RtfText = queryTemplate.Contents;
                        this.txtConclusion.RtfText = queryTemplate.Conclusion;
                        this.txtProposal.Text = queryTemplate.Proposal;
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
        
        private void DelPathImage()
        {
            try
            {
                string apath_thumuc = "", ayymmdd = "";
                ayymmdd = DateTime.Now.Date.Year.ToString().Substring(2) + DateTime.Now.Date.Month.ToString().PadLeft(2, '0') + DateTime.Now.Date.Day.ToString().PadLeft(2, '0');
                apath_thumuc = path_image_full + "\\" + ayymmdd;
                if (Directory.Exists(apath_thumuc))
                {
                    string[] filePaths = Directory.GetFiles(apath_thumuc);
                    foreach (string file in filePaths)
                        File.Delete(file);
                }
            }
            catch { }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dReceiptCode != 0)
                {
                    if (iStatus == 0)
                    {
                        //this.CleanerField();
                        this.EnableField(true);
                        this.EnableButton(false);
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
                if (this.txtContent.Text != string.Empty && dReceiptCode != 0)
                {
                    var doInsertService = new ServiceRadiologyEntryInf();
                    {
                        doInsertService.ServiceCode = this.serviceCode;
                        doInsertService.PatientCode = this.patientCode;
                        doInsertService.ReferenceCode = this.sReferenceCode;
                        doInsertService.AppointmentDate = Convert.ToDateTime("01/01/1990");
                        doInsertService.AppointmentNote = string.Empty;
                        doInsertService.Contents = this.txtContent.RtfText.ToString();
                        doInsertService.Conclusion = this.txtConclusion.RtfText.ToString();
                        doInsertService.Proposal = this.txtProposal.Text.ToString();
                        doInsertService.PostingDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                        doInsertService.PatientReceiveID = this.dPatientReceiveID;
                        doInsertService.Done = 1;
                        doInsertService.EmployeeCode = this.s_uSerid;
                        doInsertService.SuggestedID = this.dReceiptCode;
                        doInsertService.EmployeeCodeDoctor = this.employeeCodeDoctor;
                        doInsertService.ShiftWork = this.shiftWork;
                        doInsertService.Note = this.txtNote.Text;
                    };
                    int iresult = ServiceRadiologyBLL.InsRadiologyEntry(doInsertService, ref this.dRadiologyEntryID, "CDHA");
                    if (iresult > 0 && this.dRadiologyEntryID > 0)
                    {
                        ServiceRadiologyBLL.DelRadiologyDetailEntry(dRadiologyEntryID);
                        if (this.listFileDCMData != null && this.listFileDCMData.Count > 0)
                        {
                            foreach (var dicom in this.listFileDCMData)
                            {
                                var doInsertServiceDetail = new ServiceRadiologyDetailEntryInf();
                                {
                                    doInsertServiceDetail.RadiologyRowID = dRadiologyEntryID;
                                    doInsertServiceDetail.Image = this.ImageToByte(dicom.Img);
                                    doInsertServiceDetail.PostingDate = DateTime.Now.Date;
                                    doInsertServiceDetail.Checked = false;
                                };
                                ServiceRadiologyBLL.InsRadiologyDetailEntry(doInsertServiceDetail, iStatus);
                            }
                        }
                        XtraMessageBox.Show(" Lưu kết quả X - Quang thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gridControl_PreviousList.Visible = true;
                        this.EnableField(false);
                        this.EnableButton(true);
                        this.txtTemplateCode.Properties.ReadOnly = true;
                        this.butSave.Enabled = this.butNew.Enabled = this.butUndo.Enabled = this.butImage.Enabled = false;
                        this.butEdit.Enabled = this.butPrint.Enabled = true;
                        this.GetHistoryPatient();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Lưu kết quả X - Quang không thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên & nội dung X - Quang không được để trống !\t\n - " + txtServiceName.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                ServiceRadiologyBLL.DelRadiologyDetailEntry(this.dRadiologyEntryID);
                XtraMessageBox.Show("Lỗi phát sinh khi lưu kết quả X - Quang!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            this.grWaitingList.Visible = true;
            this.grPrevious.Visible = false;
            this.dPatientReceiveID = 0;
            this.dReceiptCode = 0;
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

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceCode != string.Empty && patientCode != string.Empty && txtServiceName.Text != string.Empty)
                {
                    DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                    DataTable dtResult = ServiceRadiologyBLL.DT_ResultRadiology(this.dReceiptCode, this.dPatientReceiveID);
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaXQuang.xml");
                    if (this.printPaper.Equals("A4"))
                    {
                        Reports.rptCLS_XQuang rptShow = new Reports.rptCLS_XQuang(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "X-Quang", "Kết quả X-Quang");
                        rpt.ShowDialog();
                    }
                    else if (this.printPaper.Equals("A4Rotate"))
                    {
                        Reports.rptCLS_XQuangRotate rptShow = new Reports.rptCLS_XQuangRotate(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "X-Quang", "Kết quả X-Quang");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        Reports.rptCLS_XQuangA5 rptShow = new Reports.rptCLS_XQuangA5(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "X-Quang", "Kết quả X-Quang");
                        rpt.ShowDialog();
                    }
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
                this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingService(Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), iStatus, s_makp, objSys.Values, iMenu, this.employeeCodeDoctor);
            }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grWaitingList.Dock = DockStyle.Fill;
                this.grPrevious.Visible = false;
                this.grPrevious.Dock = DockStyle.None;
                this.grMain.Text = "Quản lý đọc trả kết quả X - Quang!";
                this.butReload_Click(sender, e);
                this.tabMain.SelectedTabPageIndex = 0;
                this.EnableField(false);
                this.patientCode = this.patientName = this.serviceCode = this.serviceName = this.sReferenceCode = this.lbSTT.Text = string.Empty;
                this.dPatientReceiveID = this.dRadiologyEntryID = 0;
                this.iStatus = 0;
                this.listFileDCMData = new List<ListFileDicom>();
                this.iObjectCode = 0;
                this.imageCode = string.Empty;
                this.txtNote.Text = this.txtServiceName.Text = string.Empty;
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
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
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void CleanerField()
        {
            this.txtTemplateCode.EditValue = null;
            this.txtContent.RtfText = string.Empty;
            this.txtProposal.Text = string.Empty;
            this.txtConclusion.RtfText = string.Empty;
        }

        private void GetTemplate(string sServiceCode)
        {
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

                        dPatientReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RefID).ToString());
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
                        if (iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dPatientReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                sTheBHYT = lstBHYT[0].Serial;
                                this.lbSothe.Text = lstBHYT[0].Serial;
                                this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                this.iTraituyen = lstBHYT[0].TraiTuyen;
                                if (this.iTraituyen == 1)
                                    this.chkTraiTuyen.Checked = true;
                                else
                                    this.chkTraiTuyen.Checked = false;
                                this.lbNoiDKKCB.Text = lstBHYT[0].Serial03 + "-" + lstBHYT[0].KCBBDCode.ToString();
                                this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                this.GetCardInfo(lstBHYT[0].Serial);
                            }
                        }
                        else
                        {
                            lbTileBHYT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                        }
                        this.GetTemplate(serviceCode);
                        this.GetInfoPatient(this.patientCode);
                        this.GetHistoryPatient();
                        if (this.CheckCompleted.Checked)
                        {
                            int rowHandle = this.gridView_PreviousList.LocateByValue("SuggestedID", this.dReceiptCode);
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
        
        private void GetCardInfo(string sCard)
        {
            try
            {
                string maBHYT = sCard.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(maBHYT);
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
        
        private void GetHistoryPatient()
        {
            this.gridControl_PreviousList.DataSource = ServiceRadiologyBLL.ListPrevious(this.patientCode, iMenu);
        }

        private void GetInfoPatient(string sPatient)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(sPatient, this.dPatientReceiveID);
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
                    if (gridView_PreviousList.GetFocusedRow() != null)
                    {
                        serviceCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                        String smployeeCodeDoctorTemp = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_EmployeeCodeDoctor).ToString(), string.Empty);
                        if (smployeeCodeDoctorTemp == this.employeeCodeDoctor)
                        {
                            if (serviceCode != string.Empty)
                            {
                                gridControl_PreviousList.Visible = true;
                                txtTemplateCode.Properties.ReadOnly = true;
                                txtTemplateCode.Enabled = txtServiceName.Enabled = txtContent.Enabled = txtConclusion.Enabled = txtProposal.Enabled = true;
                                this.EnableField(true);
                                this.butSave.Enabled = this.butUndo.Enabled = this.butImage.Enabled = true;
                                this.butEdit.Enabled = this.butPrint.Enabled = false;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Chọn kết quả cần sửa lại thông tin! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.loadListPatientWaitingCompleted(0);
                }
                if (CheckCompleted.Checked == true)
                {
                    this.loadListPatientWaitingCompleted(1);
                }
                EnableButton(true);
                butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void frmXQuang_KeyDown(object sender, KeyEventArgs e)
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

        private void butImage_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListFileDicom> lsttem = new List<ListFileDicom>();
                foreach (var item in this.listFileDCMData)
                {
                    ListFileDicom datalst = new ListFileDicom();
                    datalst.ID = item.ID;
                    datalst.Img = item.Img;
                    datalst.NameControl = item.NameControl;
                    datalst.PatientName = item.PatientName;
                    datalst.Technique = item.Technique;
                    lsttem.Add(datalst);
                }
                iHISOpenImageDicom.frmOpenFileDicom frmDicom = new frmOpenFileDicom(lsttem);
                frmDicom.ShowDialog();
                if (frmDicom.listFileDCM != null)
                    this.listFileDCMData = frmDicom.listFileDCM;
                frmDicom.Dispose();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void picRelation_Click(object sender, EventArgs e)
        {
            if (this.patientCode.Trim().Length > 0)
            {
                frmRelationPatient frm = new frmRelationPatient(this.dPatientReceiveID, this.s_uSerid, this.patientCode);
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
            if (this.patientCode == string.Empty || this.dPatientReceiveID == 0)
            {
                XtraMessageBox.Show(" Chọn bệnh nhân để đính kèm file văn bản hình ảnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.dPatientReceiveID, this.patientCode);
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

        private void gridView_PreviousList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null)
                    {
                        serviceCode = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, col_ServiceCode).ToString(), string.Empty);
                        this.dRadiologyEntryID = ISDBNULL2DECIMAL(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, col_RowID).ToString(), string.Empty);
                        this.lbSTT.Text = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_STT).ToString();
                        if (serviceCode != string.Empty && dReceiptCode > 0)
                        {
                            ServiceRadiologyEntryInf first = ServiceRadiologyBLL.ObjRadiologyEntry(this.dRadiologyEntryID);
                            this.CleanerField();
                            butEdit.Enabled = true;
                            butPrint.Enabled = true;
                            butCancel.Enabled = true;
                            if (first != null && first.RowID > 0)
                            {
                                this.txtServiceName.Text = ISDBNULL2STRING(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, col_ServiceName).ToString(), string.Empty);
                                this.txtContent.RtfText = first.Contents;
                                this.txtConclusion.RtfText = first.Conclusion;
                                this.txtProposal.Text = first.Proposal;
                                this.txtNote.Text = first.Note;
                                dReceiptCode = first.SuggestedID;
                                sReferenceCode = first.ReferenceCode;
                                dPatientReceiveID = first.PatientReceiveID;
                            }
                            else
                            {
                                if (this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "'").Length > 0)
                                {
                                    DataTable tableTemplate = this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "'").CopyToDataTable();
                                    if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                                        this.printPaper = tableTemplate.Rows[0]["PrintPaper"].ToString();
                                }
                                else
                                    this.txtContent.Text = this.txtProposal.Text = this.txtConclusion.Text = string.Empty;
                            }
                            var imageList = ServiceRadiologyBLL.ListRadiologyDetail(dRadiologyEntryID);
                            this.listFileDCMData = new List<ListFileDicom>();
                            foreach (var detail in imageList)
                            {
                                ListFileDicom dicom = new ListFileDicom();
                                dicom.ID = detail.RowID.ToString();
                                dicom.Img = this.BytesToBitmap(detail.Image);
                                dicom.PatientName = this.lbHoten01.Text;
                                dicom.Technique = this.txtServiceName.Text.Trim();
                                this.listFileDCMData.Add(dicom);
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
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
        
        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_PreviousList.RowCount > 0)
                {
                    if (gridView_PreviousList.GetFocusedRow() != null && txtServiceName.Text != string.Empty)
                    {
                        String employeeCodeDoctorTemp = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, col_EmployeeCodeDoctor).ToString(), string.Empty);
                        if (employeeCodeDoctorTemp == this.employeeCodeDoctor || this.isAdmin || this.isEmployeeCodeOther)
                        {
                            Int32 iResult = 0;
                            ServiceRadiologyBLL.DelRadiologyEntry(dReceiptCode, ref iResult);
                            if (iResult == 1)
                            {
                                XtraMessageBox.Show(" Hủy kết quả thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                butContinues_Click(sender, e);
                                CleanerField();
                                EnableButton(true);
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

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public Bitmap BytesToBitmap(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Bitmap img = (Bitmap)Image.FromStream(ms);
                return img;
            }
        }
    }
}