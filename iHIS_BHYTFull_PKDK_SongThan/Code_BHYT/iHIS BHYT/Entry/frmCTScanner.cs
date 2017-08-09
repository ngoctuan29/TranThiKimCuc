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
    public partial class frmCTScanner : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private string patientCode, patientName = string.Empty;
        private string serviceCode = string.Empty;
        private string serviceName = string.Empty;
        private string referenceCode = string.Empty;
        private decimal patientReceiveID, receiptCode = 0;
        private Int32 iStatus = 0, iObjectCode = 0;
        private string imageCode = string.Empty;

        private string path_image_full = string.Empty;
        //private string path_video_full = @"\\temp\\Video";
        //private string path_resize = @"\\temp\\Resize";

        public string fname = string.Empty, employeeCodeDoctor = string.Empty;
        private string sTheBHYT = string.Empty, shiftWork = string.Empty;
        private int iTraituyen = 0, iMenu = 0;

        private string s_makp = string.Empty, s_namekp = string.Empty;
        private string s_uSerid = string.Empty;
        private List<DiagnosisAbbreviationsInf> ListAbb = new List<DiagnosisAbbreviationsInf>();
        private DateTime dtWorking = new DateTime();
        private DataTable tableTemplateHeader = new DataTable();
        private bool isAdmin = false;
        private bool isEmployeeCodeOther = false;

        public frmCTScanner(string _spk, string _uSerid, int _Menu, string _namekp, string _employeeCodeDoctor, string _shiftWork, DateTime _dtWorking)
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
        
        private void frmCTScanner_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadListPatientWaitingCompleted(0);
                this.EnableField(false);
                this.ListAbb = DiagnosisAbbreviationsBLL.ListAbb(this.employeeCodeDoctor);
                this.tableTemplateHeader = TemplateDescriptionBLL.DT_ListTemplate(string.Empty);
                this.txtTemplateCode.Properties.DataSource = this.tableTemplateHeader;
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
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void GetTemplate()
        {
            if (this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "' and EmployeeDoctorCode='" + this.employeeCodeDoctor + "'").Length > 0)
            {
                DataTable tableTemplate = this.tableTemplateHeader.Select("ServiceCode='" + this.serviceCode + "' and EmployeeDoctorCode='" + this.employeeCodeDoctor + "'").CopyToDataTable();
                if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                    this.txtTemplateCode.EditValue = this.serviceCode;
            }
        }
        public void EnableField(bool ena)
        {
            this.lbTemplateCode.Enabled = ena;
            this.txtTemplateCode.Properties.ReadOnly = this.txtServiceName.Properties.ReadOnly = this.txtConclusion.ReadOnly = this.txtContent.ReadOnly = !ena;
            //this.txtProposal.Properties.ReadOnly = 
        }

        public void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butSave.Enabled = !b;
            this.butUndo.Enabled = !b;
            this.butEdit.Enabled = false;
            this.butPrint.Enabled = false;
            this.butCancel.Enabled = false;
        }

        private void txtTemplateCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string templateCode = this.txtTemplateCode.EditValue.ToString();
                if (string.IsNullOrEmpty(templateCode))
                {
                    return;
                }
                else
                {
                    ///var queryTemplate = TemplateDescriptionBLL.ObjTemplate(templateCode).FirstOrDefault();
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
            if (this.gridView_PreviousList.RowCount > 0)
            {
                if (this.gridView_PreviousList.GetFocusedRow() != null)
                {
                    this.serviceCode = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_ServiceCode).ToString();
                    decimal dRowID = Convert.ToDecimal(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_RowID).ToString());
                    if (this.serviceCode != string.Empty && this.receiptCode > 0)
                    {
                        ServiceRadiologyEntryInf first = ServiceRadiologyBLL.ObjRadiologyEntry(dRowID);
                        this.CleanerField();
                        this.butEdit.Enabled = true;
                        this.butPrint.Enabled = true;
                        this.butCancel.Enabled = true;
                        if (first != null)
                        {
                            this.txtServiceName.Text = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_ServiceName).ToString();
                            this.txtContent.RtfText = first.Contents;
                            this.txtConclusion.RtfText = first.Conclusion;
                            //txtProposal.Text = first.Proposal;
                            this.receiptCode = first.SuggestedID;
                            this.referenceCode = first.ReferenceCode;
                            this.patientReceiveID = first.PatientReceiveID;
                        }
                    }
                    else
                    {
                        this.serviceCode = string.Empty;
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

        private void DelPathImage()
        {
            try
            {
                string apath_thumuc = string.Empty, ayymmdd = string.Empty;
                ayymmdd = this.dtWorking.Year.ToString().Substring(2) + this.dtWorking.Month.ToString().PadLeft(2, '0') + this.dtWorking.Day.ToString().PadLeft(2, '0');
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
                if (this.receiptCode != 0)
                {
                    if (iStatus == 0)
                    {
                        this.CleanerField();
                        this.EnableField(true);
                        this.EnableButton(false);
                        this.gridControl_PreviousList.Visible = false;
                        this.txtTemplateCode.Properties.ReadOnly = false;
                        this.DelPathImage();
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
                decimal dRadiologyRowID = 0;
                if (this.txtContent.Text != string.Empty && this.receiptCode != 0)
                {
                    var doInsertService = new ServiceRadiologyEntryInf();
                    {
                        doInsertService.ServiceCode = this.serviceCode;
                        doInsertService.PatientCode = this.patientCode;
                        doInsertService.ReferenceCode = this.referenceCode;
                        doInsertService.AppointmentDate = DateTime.Now.Date;
                        doInsertService.AppointmentNote = string.Empty;
                        doInsertService.Contents = txtContent.RtfText;
                        doInsertService.Conclusion = txtConclusion.RtfText;
                        //doInsertService.Proposal = txtProposal.Text.ToString();
                        doInsertService.PostingDate = Convert.ToDateTime(this.dtWorking.Date + " " + Utils.TimeServer());
                        doInsertService.PatientReceiveID = this.patientReceiveID;
                        doInsertService.Done = 1;
                        doInsertService.EmployeeCode = this.s_uSerid;
                        doInsertService.SuggestedID = this.receiptCode;
                    };
                    int iresult = ServiceRadiologyBLL.InsRadiologyEntry(doInsertService, ref dRadiologyRowID, "CDHA");
                    if (iresult > 0 && dRadiologyRowID > 0)
                    {
                        XtraMessageBox.Show(" Lưu kết quả cận lâm sàn thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gridControl_PreviousList.Visible = true;
                        this.EnableField(false);
                        this.EnableButton(true);
                        this.txtTemplateCode.Properties.ReadOnly = true;
                        this.butSave.Enabled = this.butNew.Enabled = this.butUndo.Enabled = false;
                        this.butEdit.Enabled = true;
                        this.butPrint.Enabled = true;
                        this.GetHistoryPatient(this.patientCode);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Lưu kết quả cận lâm sàng không thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên & nội dung cận lâm sàng không được để trống !\t\n - " + txtServiceName.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                this.receiptCode = 0;
                this.referenceCode = string.Empty;
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
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.serviceCode != string.Empty && this.patientCode != string.Empty)
                {
                    DataTable dtClinic = new DataTable("ClinicInfo");
                    dtClinic = ClinicInformationBLL.DT_Information(1);
                    DataTable dtResult = new DataTable("KetquaCLS");
                    dtResult = ServiceRadiologyBLL.DT_ResultRadiology(this.receiptCode, this.patientReceiveID);
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetquaCTScanner.xml");
                    Reports.rptCTScanner rptShow = new Reports.rptCTScanner();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "CTSCanner","Kêt quả CT");
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

        public void LoadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(500);
            if (objSys != null && objSys.RowID > 0)
            {
                gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingService(DateTime.Now, iStatus, s_makp, objSys.Values, iMenu);
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

                this.grMain.Text = "Quản lý thực hiện cận lâm sàng.";
                this.EnableField(false);
                this.CleanerField();
                this.patientCode = patientName = this.serviceCode = this.serviceName = this.referenceCode = string.Empty;
                this.patientReceiveID = 0;
                this.iStatus = 0;
                this.iObjectCode = 0;
                this.imageCode = string.Empty;
                this.butReload_Click(sender, e);
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
            }
            catch { }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadListPatientWaitingCompleted(0);
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void CleanerField()
        {
            this.txtTemplateCode.EditValue = null;
            //this.txtProposal.Text = string.Empty;
            this.txtContent.Text = string.Empty;
            this.txtConclusion.Text = string.Empty;
            this.lbSTT.Text = string.Empty;
        }
        
        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.gridControl_PreviousList.Visible = true;
                        this.CleanerField();
                        this.grWaitingList.Visible = false;
                        this.grWaitingList.Dock = DockStyle.None;
                        this.grPrevious.Visible = true;
                        this.grPrevious.Dock = DockStyle.Fill;

                        this.patientReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_RefID).ToString());
                        this.receiptCode = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ReceiptID).ToString());
                        this.referenceCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ReferenceCode).ToString();
                        this.patientCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientCode).ToString();
                        this.serviceCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ServiceCode).ToString();
                        this.serviceName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ServiceName).ToString();
                        this.iStatus = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_Status));
                        this.iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectCode));

                        string name = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString();
                        string gender = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString();
                        string year = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString();
                        string address = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientAddress).ToString();
                        this.grMain.Text = s_namekp +" | " + Convert.ToString(serviceName + " - Họ tên: " + name + " | Giới tính: " + gender + " | Năm sinh: " + year + " | Địa chỉ: " + address);
                        
                        if (iStatus == 0)
                        {
                            this.butNew.Enabled = true;
                        }
                        this.txtServiceName.Text = this.serviceName;
                        
                        //picCapturePro.Refresh();
                        if (this.iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
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
                            this.lbTileBHYT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                            this.VisableBHYT(false);
                        }
                        this.GetTemplate();
                        this.GetInfoPatient(this.patientCode);
                        this.GetHistoryPatient(this.patientCode);
                        if (this.CheckCompleted.Checked)
                            this.gridView_PreviousList_Click(sender, e);
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
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null )
                    {
                        this.serviceCode = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_ServiceCode).ToString();
                        String employeeCodeDoctorTemp = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_EmployeeCode).ToString();
                        if (employeeCodeDoctorTemp == this.employeeCodeDoctor || this.isAdmin || this.isEmployeeCodeOther)
                        {
                            if (this.serviceCode != string.Empty)
                            {
                                this.gridControl_PreviousList.Visible = true;
                                this.txtTemplateCode.Properties.ReadOnly = true;
                                this.txtTemplateCode.Enabled = txtServiceName.Enabled = txtConclusion.Enabled = txtContent.Enabled = true;
                                //txtProposal.Enabled = true;
                                this.EnableField(true);
                                this.butSave.Enabled = this.butUndo.Enabled = true;
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

        private void frmCTScanner_KeyDown(object sender, KeyEventArgs e)
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
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null && txtServiceName.Text != string.Empty)
                    {
                        String employeeCodeDoctorTemp = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.col_EmployeeCode).ToString();
                        if (employeeCodeDoctorTemp == this.employeeCodeDoctor || this.isAdmin || this.isEmployeeCodeOther)
                        {
                            Int32 iResult = 0;
                            ServiceRadiologyBLL.DelRadiologyEntry(this.receiptCode, ref iResult);
                            if (iResult == 1)
                            {
                                XtraMessageBox.Show(" Hủy kết quả thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
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