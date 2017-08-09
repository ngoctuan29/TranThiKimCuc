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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Globalization;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace Ps.Clinic.Entry
{
    public partial class frmPhieuThuTienTamUng : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private decimal patientReceiveID = 0;
        private string userid = string.Empty, theBHYT = string.Empty;
        private int iTraituyen = 0, iCapcuu = 0, iChuyenvien = 0;
        private Int32 iObjectCode = 0, iTile = 0, iPatientType = 0, iPaid = 0;
        private string objectName = string.Empty;
        private string shiftWork = string.Empty;
        private int rowIDNoteBook = 0;
        private bool bAdmin = false;
        private DateTime dtimePostingDate = new DateTime();
        private string employeeCodeOld = string.Empty;
        private DateTime dtimeServer = new DateTime();
        private DataTable tableDetail;
        private DateTime dtWorking = new DateTime();
        public frmPhieuThuTienTamUng(string _userid, string _shiftWork, int _rowIDNoteBook, DateTime _dtWorking, string _symbol)
        {
            InitializeComponent();
            this.userid = _userid;
            this.shiftWork = _shiftWork;
            this.rowIDNoteBook = _rowIDNoteBook;
            this.dtWorking = _dtWorking;
            this.txtNoteBook.Text = _symbol;
        }

        private void frmPhieuThuTienTamUng_Load(object sender, EventArgs e)
        {
            try
            {
                this.lkupEmployee.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("4");
                this.lkupEmployee.Properties.DisplayMember = "EmployeeName";
                this.lkupEmployee.Properties.ValueMember = "EmployeeCode";

                List<EmployeeInf> lstEmployee = EmployeeBLL.ListEmployee(string.Empty);
                this.repLKupPayment_Employee.DataSource = lstEmployee;
                this.repLKupPayment_Employee.DisplayMember = "EmployeeName";
                this.repLKupPayment_Employee.ValueMember = "EmployeeCode";

                this.repLKupPayment_EmployeeRePaid.DataSource = lstEmployee;
                this.repLKupPayment_EmployeeRePaid.DisplayMember = "EmployeeName";
                this.repLKupPayment_EmployeeRePaid.ValueMember = "EmployeeCode";

                this.lkupEmployee.EditValue = this.userid;
                this.bAdmin = EmployeeBLL.CheckUserAdmin(this.userid);
                this.EnableButton(true);
                this.dtfrom.EditValue = this.dtTo.EditValue = this.dtSearchFrom.EditValue = this.dtSearchTo.EditValue = this.dtimePostingDate = this.dtimeServer = Utils.DateServer();
                this.CreateTableDetail();
                this.GetPatientWaiting();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tableDetail.Select("Check=1").Length > 0)
                {
                    foreach(DataRow row in this.tableDetail.Select("Check=1"))
                    {
                        Fee_Advance_PaymentViewDetailInf modelDetail = new Fee_Advance_PaymentViewDetailInf();
                        modelDetail.RowID = Convert.ToDecimal(row["RowID"]);
                        modelDetail.PatientReceiveID = Convert.ToDecimal(row["PatientReceiveID"]);
                        modelDetail.PatientCode = row["PatientCode"].ToString();
                        modelDetail.WorkingDateOrder = row["WorkingDateOrder"].ToString();
                        modelDetail.AmountOrder = Convert.ToDecimal(row["AmountOrder"]);
                        modelDetail.EmployeeCodeOrder = row["EmployeeCodeOrder"].ToString();
                        modelDetail.DepartmentCodeOrder = row["DepartmentCodeOrder"].ToString();
                        modelDetail.ObjectCode = Convert.ToInt32(row["ObjectCode"]);
                        modelDetail.Done = Convert.ToInt32(row["Done"]);
                        modelDetail.Paid = Convert.ToInt32(row["Paid"]);
                        modelDetail.EmployeeCode = row["EmployeeCode"].ToString();
                        modelDetail.AmountReal = Convert.ToDecimal(row["AmountReal"]);
                        modelDetail.WorkingDate = row["WorkingDate"].ToString();
                        modelDetail.RowIDNoteBook = Convert.ToInt32(row["RowIDNoteBook"]);
                        modelDetail.EmployeeCodeRePaid = row["EmployeeCodeRePaid"].ToString();
                        modelDetail.WorkingDateRePaid = row["WorkingDateRePaid"].ToString();
                        modelDetail.ReceiptNumber = Convert.ToInt32(row["ReceiptNumber"]);
                        modelDetail.NoteRePaid = row["NoteRePaid"].ToString();
                        modelDetail.BanksAccountCode = row["BanksAccountCode"].ToString();
                        if (!Fee_Advance_PaymentBLL.InsFee_AdvancePayment(modelDetail))
                        {
                            XtraMessageBox.Show("Lưu không thành công! Vui lòng kiểm tra lại chi tiết thu tạm ứng.", "Bệnh viện điện tử .NET!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    Fee_Advance_PaymentBLL.UpdCountsFee_AdvancePayment(this.patientReceiveID, this.txtMabn.Text, Convert.ToInt32(this.txtReceiptNumber.EditValue));
                    this.PrintBank();
                    this.butNew_Click(sender, e);
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng nhập số tiền tạm ứng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PrintBank()
        {
            try
            {
                DataTable tablePayment = Fee_Advance_PaymentBLL.TableAdvance_PaymentPrint(this.patientReceiveID, this.txtMabn.Text, Convert.ToInt32(this.txtReceiptNumber.EditValue), this.dtimePostingDate.ToString("dd/MM/yyyy"), this.rowIDNoteBook);
                if (tablePayment!=null && tablePayment.Rows.Count > 0)
                {
                    DataSet dsResult = new DataSet("Result");
                    dsResult.Tables.Add(tablePayment);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptVP_ThuTamUng.xml");
                    if (dsResult.Tables.Count > 0)
                    {
                        decimal totalAmount = 0;
                        foreach(DataRow row in tablePayment.Rows)
                        {
                            totalAmount += Convert.ToDecimal(row["AmountReal"]);
                        }
                        Reports.rptVP_PTTamUngA5 rpt = new Reports.rptVP_PTTamUngA5();
                        rpt.Parameters["prTotalReal"].Value = totalAmount;
                        rpt.DataSource = dsResult;
                        rpt.ShowPreviewDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chi tiết phiếu thu chưa phát sinh!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết phiếu thu chưa phát sinh!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butSave.Enabled = !b;
            this.butIgnore.Enabled = !b;
            this.butCancel.Enabled = false;
            this.butInPT.Enabled = !b;
            this.txtMabn.Properties.ReadOnly = b;
            this.spinAmountAdd.Properties.ReadOnly = b;
            this.butAddAmount.Enabled = !b;
        }

        private void GetInfoPatient(decimal patientReceiveIDTemp)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.txtMabn.Text.Trim().ToUpper(), patientReceiveIDTemp);
                if (objPatient != null && !string.IsNullOrEmpty(objPatient.PatientCode))
                {
                    this.lbHoten01.Text = objPatient.PatientName;
                    this.lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        this.lbGioitinh01.Text = "Nữ";
                    else
                        this.lbGioitinh01.Text = "Nam";
                    this.lbNamsinh01.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
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
                if (iObjectCode == 1)
                {
                    List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                    if (lstBHYT != null && lstBHYT.Count > 0)
                    {
                        this.theBHYT = lstBHYT[0].Serial;
                        this.lbSothe.Text = lstBHYT[0].Serial;
                        this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                        this.iTraituyen = lstBHYT[0].TraiTuyen;
                        this.iCapcuu = lstBHYT[0].Capcuu;
                        this.iChuyenvien = lstBHYT[0].ReferralPaper;
                        this.chkTraiTuyen.Checked = lstBHYT[0].TraiTuyen == 1 ? true : false;
                        this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                        this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                        this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCodeFull.ToString();
                        this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                        this.GetCardInfo(lstBHYT[0].Serial);
                    }
                }
                else
                {
                    this.iTraituyen = 0;
                    this.iCapcuu = 0;
                    this.iChuyenvien = 0;
                    this.lbSothe.Text = string.Empty;
                    this.lbTungay.Text = string.Empty;
                    this.lbNoiDKKCB.Text = string.Empty;
                    this.lbDenngay.Text = string.Empty;
                    this.lbTileBHYT.Text = this.objectName;
                }
            }
            catch { }
        }
        
        private void GetCardInfo(string sCard)
        {
            string sMaBHYT = sCard.Substring(0, 3);
            RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
            if (model != null || model.RateCard != string.Empty)
            {
                if (this.chkTraiTuyen.Checked)
                {
                    if (this.chkGiayChuyenVien.Checked || this.chkCapCuu.Checked)
                    {
                        this.iTile = model.RateTrue;
                        this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                    }
                    else
                    {
                        this.iTile = model.RateFalse;
                        this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                    }
                }
                else
                {
                    this.iTile = model.RateTrue;
                    this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                }
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            this.ClearData();
            this.EnableButton(false);
            this.gridView_BankList.OptionsBehavior.ReadOnly = false;
            this.gridView_BankList.OptionsBehavior.Editable = true;
            this.txtMabn.Focus();
            this.GetSerialNumberNoteBook();
        }
        
        private void ClearData()
        {
            this.patientReceiveID = 0;
            this.iTraituyen = this.iObjectCode = this.iTile = this.iPatientType = this.iPaid = this.iChuyenvien = this.iCapcuu = 0;
            this.objectName = string.Empty;
            this.theBHYT = string.Empty;
            this.txtMabn.Text = this.lbHoten01.Text = this.lbNgayvao.Text = this.lbNamsinh01.Text = this.lbTuoi01.Text = this.lbGioitinh01.Text = this.lbDiachi01.Text = this.lbSothe.Text = string.Empty;
            this.lbTungay.Text = this.lbDenngay.Text = this.lbNoiDKKCB.Text = string.Empty;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = this.chkCapCuu.Checked = false;
            this.lbTileBHYT.Text = string.Empty;
            this.spinAmountAdd.EditValue = this.txtAmount.EditValue = this.txtAmountReal.EditValue = 0;
            this.lkNgayVaoVien.Properties.DataSource = null;
            this.gridControl_List.DataSource = null;
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            this.picPatient.Image = (Bitmap)b;
            this.CreateTableDetail();
        }

        private void butIgnore_Click(object sender, EventArgs e)
        {
            this.EnableButton(true);
            this.gridView_BankList.OptionsBehavior.ReadOnly = true;
            this.gridView_BankList.OptionsBehavior.Editable = false;
            this.butNew.Focus();
        }
        
        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string paid = "0,1";
                if (this.chkHDHoan.Checked)
                    paid = "-1";
                this.gridControl_BankList.DataSource = Fee_Advance_PaymentBLL.TableAdvance_PaymentForSearchFinish(this.dtSearchFrom.Text, this.dtSearchTo.Text, paid);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_BankList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.xtraTabControl1.SelectedTabPageIndex = 0;
                string patientCode = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "PatientCode").ToString();
                this.patientReceiveID = Convert.ToDecimal(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "PatientReceiveID").ToString());
                this.txtReceiptNumber.Text = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "ReceiptNumber").ToString();
                this.dtimePostingDate = Convert.ToDateTime(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "WorkingDate"));
                this.employeeCodeOld = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "EmployeeCode").ToString();
                this.txtAmount.EditValue = this.txtAmountReal.EditValue = Convert.ToDecimal(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "AmountReal")).ToString("N0");
                this.iPaid = Convert.ToInt32(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "Paid").ToString());
                this.txtMabn.Text = patientCode;
                this.GetNumberReceive();
                this.tableDetail = Fee_Advance_PaymentBLL.TableAdvance_PaymentDetail(this.patientReceiveID, patientCode, Convert.ToInt32(this.txtReceiptNumber.Text), this.dtimePostingDate.ToString("dd/MM/yyyy"));
                this.gridControl_List.DataSource = this.tableDetail;
                this.EnableButton(true);
                if (this.iPaid != 0)
                    this.butInPT.Enabled = this.butCancel.Enabled = false;
                else
                    this.butCancel.Enabled = this.butInPT.Enabled = true;
                this.gridView_BankList.OptionsBehavior.ReadOnly = true;
                this.gridView_BankList.OptionsBehavior.Editable = false;
                this.gridView_List.OptionsBehavior.ReadOnly = true;
                this.gridView_List.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                this.butSearch_Click(sender, e);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtimePostingDate.Date != this.dtimeServer.Date && !this.bAdmin)
                {
                    XtraMessageBox.Show("Khác ngày việc không được phép hoàn trả biên lai tạm ứng!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(this.iPaid.Equals(1))
                {
                    XtraMessageBox.Show("Biên lai tạm ứng đã thanh toán trong đợt điều trị. \n\r Không được phép hoàn trả.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.iPaid.Equals(-1))
                {
                    XtraMessageBox.Show("Biên lai tạm ứng đã được hoàn ứng trước đó. \n\r Không được phép hoàn trả.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.bAdmin || this.userid == this.employeeCodeOld)
                {
                    ViewPopup.frmLyDoHuyPhieuThu frmCancel = new ViewPopup.frmLyDoHuyPhieuThu();
                    frmCancel.ShowDialog();
                    if (string.IsNullOrEmpty(frmCancel.reason))
                        return;
                    else
                    {
                        if (this.tableDetail.Rows.Count > 0)
                        {
                            int result = 0;
                            bool isSuccess = true;
                            foreach(DataRow row in this.tableDetail.Rows)
                            {
                                result = Fee_Advance_PaymentBLL.UpdCancelFee_AdvancePayment(Convert.ToDecimal(row["RowID"]), Convert.ToDecimal(row["PatientReceiveID"]), Convert.ToInt32(row["Done"]), -1, this.userid, Utils.DateTimeServer().ToString("dd/MM/yyyy HH:mm"), frmCancel.reason);
                                if (result <= 0)
                                {
                                    isSuccess = false;
                                    break;
                                }
                            }
                            if (result.Equals(-1))
                                XtraMessageBox.Show(" Hoàn ứng không thành công!\n\r Biên lai tạm ứng đã thanh toán trong đợt điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else if (result.Equals(-2) || result.Equals(0))
                                XtraMessageBox.Show(" Hoàn ứng không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else if (isSuccess && result > 0)
                            {
                                this.butCancel.Enabled = this.butInPT.Enabled = false;
                                XtraMessageBox.Show(" Hoàn ứng biên lai tạm ứng thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            XtraMessageBox.Show(" Chọn biên lai tạm ứng để hoàn ứng.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("User không có quyền hoàn biên lai tạm ứng này! Vui lòng liên hệ quản trị hệ thống.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                SendKeys.Send("{Tab}{F4}");	
        }
        
        private void butInPT_Click(object sender, EventArgs e)
        {
            this.PrintBank();
        }
        
        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.GetPatientWaiting();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetPatientWaiting()
        {
            this.gridControl_WaitingList.DataSource = Fee_Advance_PaymentBLL.ListAdvance_PaymentWaiting(this.dtfrom.Text.Trim(), this.dtTo.Text.Trim());
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.butNew_Click(sender, e);
                string patientCodeTemp = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, "PatientCode").ToString();
                this.patientReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, "PatientReceiveID").ToString());
                this.txtMabn.Text = patientCodeTemp;
                if (!string.IsNullOrEmpty(patientCodeTemp))
                    this.txtMabn_Validated(sender, e);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void txtMabn_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtMabn.Text.Trim()))
                {
                    this.GetNumberReceive();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetNumberReceive()
        {
            List<PatientReceive_ViewInf> lstReceive = PatientReceiveBLL.ListPatientView(this.txtMabn.Text.Trim(), this.patientReceiveID);
            if (lstReceive.Count > 0 && lstReceive != null && this.patientReceiveID > 0)
            {
                this.patientReceiveID = lstReceive[0].PatientReceiveID;
                this.lkNgayVaoVien.Properties.DataSource = lstReceive;
                this.lkNgayVaoVien.Properties.DisplayMember = "DateIn";
                this.lkNgayVaoVien.Properties.ValueMember = "PatientReceiveID";
                if (this.patientReceiveID > 0)
                    this.lkNgayVaoVien.EditValue = this.patientReceiveID;
                this.iObjectCode = lstReceive[0].ObjectCode;
                this.iPatientType = lstReceive[0].PatientType;
                this.objectName = lstReceive[0].ObjectName;
                this.lbNgayvao.Text = lstReceive[0].DateIn.ToString("dd/MM/yyyy HH:mm");
                this.GetInfoPatient(lstReceive[0].PatientReceiveID);
                this.spinAmountAdd.Focus();
            }
            else
            {
                XtraMessageBox.Show(" Đợt điều trị không tồn tại! \n\r Xem lại mã bệnh nhân.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butInBangKeHD_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableResult = Fee_Advance_PaymentBLL.TableAdvance_PaymentViewReport(this.dtSearchFrom.Text, this.dtSearchTo.Text, this.chkHDHoan.Checked ? -1 : 0);
                if (tableResult != null && tableResult.Rows.Count > 0)
                {
                    DataSet dsResult = new DataSet("Result");
                    dsResult.Tables.Add(tableResult);
                    dsResult.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_ThuTamUng.xml");
                    if (dsResult != null && dsResult.Tables.Count > 0)
                    {
                        decimal totalReal = 0;
                        foreach(DataRow row in tableResult.Rows)
                        {
                            totalReal += Convert.ToDecimal(row["AmountReal"].ToString());
                        }
                        Reports.rptVP_TU_BangKeHD rpt = new Reports.rptVP_TU_BangKeHD();
                        rpt.Parameters["fromdate"].Value = this.dtSearchFrom.Text;
                        rpt.Parameters["todate"].Value = this.dtSearchTo.Text;
                        rpt.Parameters["title"].Value = this.chkHDHoan.Checked ? "BẢNG KÊ HOÁ ĐƠN HOÀN" : "BẢNG KÊ HOÁ ĐƠN TẠM ỨNG";
                        rpt.Parameters["prTotalReal"].Value = totalReal;
                        rpt.DataSource = dsResult;
                        rpt.ShowPreviewDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Bảng kê chưa phát sinh chi phí thu!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Bảng kê chưa phát sinh chi phí thu!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void spinAmountAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butAddAmount.Focus();
        }

        private void butAddAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }
                
        private void butAddAmount_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.spinAmountAdd.EditValue) > 0)
                {
                    DataRow row = this.tableDetail.NewRow();
                    row["Check"] = 1;
                    row["RowID"] = 0;
                    row["PatientReceiveID"] = this.patientReceiveID;
                    row["PatientCode"] = this.txtMabn.Text;
                    row["WorkingDateOrder"] = this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer();
                    row["AmountOrder"] = Convert.ToDecimal(this.spinAmountAdd.EditValue);
                    row["EmployeeCodeOrder"] = this.userid;
                    row["DepartmentCodeOrder"] = string.Empty;
                    row["ObjectCode"] = this.iObjectCode;
                    row["Done"] = 1;
                    row["Paid"] = 0;
                    row["EmployeeCode"] = this.userid;
                    row["AmountReal"] = Convert.ToDecimal(this.spinAmountAdd.EditValue);
                    row["WorkingDate"] = this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer();
                    row["RowIDNoteBook"] = this.rowIDNoteBook;
                    row["EmployeeCodeRePaid"] = string.Empty;
                    row["WorkingDateRePaid"] = string.Empty;
                    row["ReceiptNumber"] = Convert.ToInt32(this.txtReceiptNumber.EditValue);
                    row["NoteRePaid"] = string.Empty;
                    row["BanksAccountCode"] = string.Empty;
                    this.tableDetail.Rows.Add(row);
                    this.tableDetail.AcceptChanges();
                    this.LoadDataDetail();
                    this.spinAmountAdd.EditValue = 0;
                }
                else
                {
                    XtraMessageBox.Show("Nhập số tiền cần thu tạm ứng.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.spinAmountAdd.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadDataDetail()
        {
            this.gridControl_List.DataSource = this.tableDetail;
            decimal totalAmount = 0, totalAmountReal = 0;
            foreach(DataRow row in this.tableDetail.Rows)
            {
                totalAmount += Convert.ToDecimal(row["AmountOrder"]);
                totalAmountReal += Convert.ToDecimal(row["AmountReal"]);
            }
            this.txtAmount.EditValue = totalAmount;
            this.txtAmountReal.EditValue = totalAmountReal;
        }

        private void GetSerialNumberNoteBook()
        {
            List<Fee_NoteBookInf> lstNotebook = Fee_NoteBookBLL.ListNoteBook(this.rowIDNoteBook);
            if (lstNotebook != null && lstNotebook[0].RowID > 0 && lstNotebook[0].WriteNumber < lstNotebook[0].ToNumber)
                this.txtReceiptNumber.EditValue = lstNotebook[0].WriteNumber + 1;
            else
            {
                XtraMessageBox.Show("Số hoá đơn không không hợp lệ, hoặc số hoá đơn của quyển sổ đã hết.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CreateTableDetail()
        {
            this.tableDetail = new DataTable();
            this.tableDetail.Columns.Add("Check", typeof(int));
            this.tableDetail.Columns.Add("RowID", typeof(decimal));
            this.tableDetail.Columns.Add("PatientReceiveID", typeof(decimal));
            this.tableDetail.Columns.Add("PatientCode", typeof(string));
            this.tableDetail.Columns.Add("WorkingDateOrder", typeof(string));
            this.tableDetail.Columns.Add("AmountOrder", typeof(decimal));
            this.tableDetail.Columns.Add("EmployeeCodeOrder", typeof(string));
            this.tableDetail.Columns.Add("DepartmentCodeOrder", typeof(string));
            this.tableDetail.Columns.Add("ObjectCode", typeof(int));
            this.tableDetail.Columns.Add("Done", typeof(int));
            this.tableDetail.Columns.Add("Paid", typeof(int));
            this.tableDetail.Columns.Add("EmployeeCode", typeof(string));
            this.tableDetail.Columns.Add("AmountReal", typeof(decimal));
            this.tableDetail.Columns.Add("WorkingDate", typeof(string));
            this.tableDetail.Columns.Add("RowIDNoteBook", typeof(int));
            this.tableDetail.Columns.Add("EmployeeCodeRePaid", typeof(string));
            this.tableDetail.Columns.Add("WorkingDateRePaid", typeof(string));
            this.tableDetail.Columns.Add("ReceiptNumber", typeof(int));
            this.tableDetail.Columns.Add("NoteRePaid", typeof(string));
            this.tableDetail.Columns.Add("BanksAccountCode", typeof(string));
        }
    }
}