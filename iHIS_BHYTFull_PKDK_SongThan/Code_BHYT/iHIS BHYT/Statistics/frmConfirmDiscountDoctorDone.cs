using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraCharts;
using System.Reflection;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.Statistics
{
    public partial class frmConfirmDiscountDoctorDone : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty, shiftWork = string.Empty;
        private string groupCode = string.Empty;
        private DataTable tableServices = new DataTable();
        private DateTime dtimePosting;
        private DataTable tableDicount = new DataTable();
        private DataTable tableResult = new DataTable();
        private string employeeCodeDoctor = string.Empty;
        private DevExpress.Utils.WaitDialogForm Starting = null;
        public frmConfirmDiscountDoctorDone(string _userID, string _shiftWork)
        {
            InitializeComponent();
            this.userID = _userID;
            this.shiftWork = _shiftWork;
        }

        private void frmConfirmDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadData()
        {
            this.dtimePosting = Utils.DateServer();
            this.dtSearchForm.EditValue = this.dtSearchTo.EditValue = this.dateReportForm.EditValue = this.dateReportTo.EditValue = this.dtimePosting;
            List<ServiceGroupInf> listGroup = ServiceGroupBLL.ListServiceGroup(string.Empty).FindAll(x => x.ServiceModuleCode != "THUOC" && x.ServiceGroupCode != "TC" && x.ServiceGroupCode != "XN");
            ///List<ServiceGroupInf> listGroup = ServiceGroupBLL.ListServiceGroup("KCB");
            this.lkupServiceGroup.Properties.DataSource = listGroup;
            this.lkupServiceGroup.Properties.ValueMember = "ServiceGroupCode";
            this.lkupServiceGroup.Properties.DisplayMember = "ServiceGroupName";
            this.lkupServiceGroupReport.Properties.DataSource = listGroup;
            this.lkupServiceGroupReport.Properties.ValueMember = "ServiceGroupCode";
            this.lkupServiceGroupReport.Properties.DisplayMember = "ServiceGroupName";
            
            List<EmployeeViewInf> lstEmployee = EmployeeBLL.ListEmployeeForPosition("2,3");
            this.searchLKupDoctorFilter.Properties.DataSource = lstEmployee;
            this.searchLKupDoctorFilter.Properties.DisplayMember = "EmployeeName";
            this.searchLKupDoctorFilter.Properties.ValueMember = "EmployeeCode";
            this.searchLKupDoctorResult.Properties.DataSource = lstEmployee;
            this.searchLKupDoctorResult.Properties.DisplayMember = "EmployeeName";
            this.searchLKupDoctorResult.Properties.ValueMember = "EmployeeCode";
            this.repSearchLKup_EmployeeCodeDoing.DataSource = lstEmployee;
            this.repSearchLKup_EmployeeCodeDoing.ValueMember = "EmployeeCode";
            this.repSearchLKup_EmployeeCodeDoing.DisplayMember = "EmployeeName";
        }

        private void butSearchFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                this.GetServiceGroup();
                this.gridControl_ListDoctorFilter.DataSource = ReportDiscountBLL.GetPatientReceiveForDoctor(this.dtSearchForm.Text, this.dtSearchTo.Text, this.searchLKupDoctorFilter.EditValue.ToString(), this.groupCode, "DONE");
                this.gridControl_ListPatients.DataSource = null;
                Starting.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void GetServiceGroup()
        {
            try
            {
                this.groupCode = string.Empty;
                string tempGroup = this.lkupServiceGroup.EditValue.ToString();
                string[] arrGroup;
                if (tempGroup.Trim() != string.Empty)
                {
                    arrGroup = tempGroup.Split(',');
                    for (Int32 i = 0; i < arrGroup.Length; i++)
                    {
                        this.groupCode += arrGroup.GetValue(i).ToString().Trim(' ') + ",";
                    }
                }
                this.groupCode = this.groupCode.TrimEnd(',');
            }
            catch
            {
                this.groupCode = string.Empty;
            }
        }

        private void gridView_ListDoctorFilter_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                this.GetServiceGroup();
                this.employeeCodeDoctor = this.gridView_ListDoctorFilter.GetRowCellValue(this.gridView_ListDoctorFilter.FocusedRowHandle, this.colListFilter_EmployeeCode).ToString();
                this.LoadDataForDoctor();
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error : " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadDataForDoctor()
        {
            this.tableServices = ReportDiscountBLL.GetSuggestedServiceForDoctorDetail(this.dtSearchForm.Text, this.dtSearchTo.Text, this.employeeCodeDoctor, this.groupCode.Trim(), "DONE");
            this.gridControl_ListPatients.DataSource = this.tableServices;
        }

        private void butClearFilter_Click(object sender, EventArgs e)
        {
            try
            {
                this.lkupServiceGroup.EditValue = string.Empty;
                this.searchLKupDoctorFilter.EditValue = string.Empty;
                this.dtSearchForm.EditValue = dtSearchTo.EditValue = this.dtimePosting;
                this.gridControl_ListDoctorFilter.DataSource = null;
                this.gridControl_ListPatients.DataSource = null;
                this.tableServices.Clear();
                this.LoadData();
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error : " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_ListPatients_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                decimal servicePrice = Convert.ToDecimal(view.GetFocusedRowCellValue(this.col_ListDetail_ServicePrice));
                if (view.FocusedColumn.FieldName == "DiscountPer")
                {
                    if (e.Value != null)
                    {
                        Int32 discountPer = Convert.ToInt32(e.Value);
                        decimal discountAmount = (discountPer * servicePrice) / 100;
                        view.SetFocusedRowCellValue(this.col_ListDetail_DiscountAmount, discountAmount);
                    }
                }
            }
            catch { }
        }

        private void butSaveIntro_Click(object sender, EventArgs e)
        {
            try
            {
                bool bResult = true;
                //DataTable tableResult = this.tableServices.Select("Check=1").CopyToDataTable();
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                foreach (DataRow row in this.tableServices.Rows)
                {
                    if (MedicalRecord_BLL.UpdMedicalRecordForDone(Convert.ToDecimal(row["ReceiptID"]), Convert.ToDecimal(row["DiscountAmount"]), row["EmployeeCodeDoing"].ToString(), Convert.ToInt32(row["DiscountPer"]), Convert.ToInt32(row["Check"])) < 1)
                    {
                        bResult = false;
                        Starting.Close();
                        break;
                    }
                }
                Starting.Close();
                if (bResult)
                {
                    XtraMessageBox.Show("Cập nhật thành công.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadDataForDoctor();
                    this.gridControl_ListPatients.DataSource = this.tableServices;
                }
                else
                {
                    XtraMessageBox.Show(" Cập nhật không thành công! Vui lòng xem lại thông tin trước khi cập nhật.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butSearchReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.pivotGridResult.DataSource = null;
                this.pivotGridResult.Fields.Clear();
                this.pivotGridDetail.DataSource = null;
                this.pivotGridDetail.Fields.Clear();
                this.pivotGridGeneral.DataSource = null;
                this.pivotGridGeneral.Fields.Clear();
                if (this.lkupServiceGroupReport.EditValue != null)
                    this.groupCode = this.lkupServiceGroupReport.EditValue.ToString();
                else
                    this.groupCode = string.Empty;
                string employeeCodeTemp = string.Empty;
                if (this.searchLKupDoctorResult.EditValue != null)
                    employeeCodeTemp = this.searchLKupDoctorResult.EditValue.ToString();
                else
                    employeeCodeTemp = string.Empty;
                if (this.cbDetail.Checked == true)
                {
                    Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                    this.tableDicount = rpt_General_BLL.TableDiscountForDoctor(Convert.ToDateTime(this.dateReportForm.EditValue), Convert.ToDateTime(dateReportTo.EditValue), string.Empty, this.userID, this.groupCode, this.searchLKupDoctorResult.EditValue.ToString(), "RS1");
                    Starting.Close();
                    if (this.tableDicount != null && this.tableDicount.Rows.Count > 0)
                    {
                        if (this.tableDicount != null && this.tableDicount.Rows.Count > 0)
                        {
                            this.pivotGridDetail.DataSource = this.tableDicount;
                            PivotGridField fieldIntroName = new PivotGridField("EmployeeName", PivotArea.RowArea);
                            fieldIntroName.Caption = "Bác sỹ";
                            fieldIntroName.Width = 200;

                            PivotGridField fieldCategoryName = new PivotGridField("ServiceCategoryName", PivotArea.ColumnArea);
                            fieldCategoryName.Caption = "Loại dịch vụ";
                            PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.ColumnArea);
                            fieldServiceName.Caption = "Tên dịch vụ";
                            PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
                            fieldQuantity.Caption = "Tổng số ca";
                            fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            fieldQuantity.CellFormat.FormatString = "#,#";

                            //PivotGridField fieldAmount = new PivotGridField("TotalAmount", PivotArea.DataArea);
                            //fieldAmount.Caption = "Tổng tiền";
                            //fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            //fieldAmount.CellFormat.FormatString = "#,#";
                            this.pivotGridDetail.Fields.AddRange(new PivotGridField[] { fieldIntroName, fieldCategoryName, fieldServiceName, fieldQuantity });
                        }
                    }
                }
                else if (this.cbDiscount.Checked == true)
                {
                    Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                    this.tableDicount = rpt_General_BLL.TableDiscountForDoctor(Convert.ToDateTime(this.dateReportForm.EditValue), Convert.ToDateTime(dateReportTo.EditValue), string.Empty, this.userID, this.groupCode, employeeCodeTemp, "RS1");
                    Starting.Close();
                    if (this.tableDicount != null && this.tableDicount.Rows.Count > 0)
                    {
                        this.pivotGridResult.DataSource = this.tableDicount;
                        PivotGridField fieldPostingDate = new PivotGridField("PostingDate", PivotArea.RowArea);
                        fieldPostingDate.Caption = "Ngày";
                        PivotGridField fieldIntroName = new PivotGridField("EmployeeName", PivotArea.RowArea);
                        fieldIntroName.Caption = "Bác sỹ";
                        fieldIntroName.Width = 200;

                        PivotGridField fieldCategoryName = new PivotGridField("ServiceCategoryName", PivotArea.FilterArea);///ColumnArea
                        fieldCategoryName.Caption = "Loại dịch vụ";
                        PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.FilterArea);///ColumnArea
                        fieldServiceName.Caption = "Tên dịch vụ";
                        PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
                        fieldQuantity.Caption = "Tổng số ca";
                        fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldQuantity.CellFormat.FormatString = "#,#";

                        PivotGridField fieldAmount = new PivotGridField("TotalAmount", PivotArea.DataArea);
                        fieldAmount.Caption = "Tổng tiền";
                        fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldAmount.CellFormat.FormatString = "#,#";

                        PivotGridField fieldPatientName = new PivotGridField("PatientName", PivotArea.FilterArea);
                        fieldPatientName.Caption = "Họ và tên";
                        fieldPatientName.Width = 150;
                        PivotGridField fieldPatientBirthyear = new PivotGridField("PatientBirthyear", PivotArea.FilterArea);
                        fieldPatientBirthyear.Caption = "Năm sinh";
                        PivotGridField fieldPatientGender = new PivotGridField("PatientGenderName", PivotArea.FilterArea);
                        fieldPatientGender.Caption = "Giới tính";
                        PivotGridField fieldPatientAddress = new PivotGridField("PatientAddress", PivotArea.FilterArea);
                        fieldPatientAddress.Caption = "Địa chỉ";
                        fieldPatientAddress.Width = 200;
                        PivotGridField fieldPatientMobile = new PivotGridField("PatientMobile", PivotArea.FilterArea);
                        fieldPatientMobile.Caption = "Số ĐT";

                        this.pivotGridResult.Fields.AddRange(new PivotGridField[] { fieldPostingDate, fieldIntroName, fieldCategoryName, fieldServiceName, fieldQuantity, fieldAmount, fieldPatientName, fieldPatientBirthyear, fieldPatientGender, fieldPatientAddress, fieldPatientMobile });
                    }
                }
                else if (this.cbGeneral.Checked == true)
                {
                    Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                    this.tableDicount = rpt_General_BLL.TableDiscountForDoctor(Convert.ToDateTime(this.dateReportForm.EditValue), Convert.ToDateTime(dateReportTo.EditValue), string.Empty, this.userID, this.groupCode, employeeCodeTemp, "G3");
                    Starting.Close();
                    if (this.tableDicount != null && this.tableDicount.Rows.Count > 0)
                    {
                        this.pivotGridGeneral.DataSource = this.tableDicount;
                        PivotGridField fieldIntroName = new PivotGridField("EmployeeName", PivotArea.RowArea);
                        fieldIntroName.Caption = "BÁC SỸ";
                        //fieldIntroName.Width = 200;

                        PivotGridField fieldCategoryName = new PivotGridField("ServiceGroupName", PivotArea.ColumnArea);
                        fieldCategoryName.Caption = "Dịch vụ";

                        PivotGridField fieldAmount = new PivotGridField("TotalAmount", PivotArea.DataArea);
                        fieldAmount.Caption = "Tổng tiền";
                        fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldAmount.CellFormat.FormatString = "#,#";
                        this.pivotGridGeneral.Fields.AddRange(new PivotGridField[] { fieldIntroName, fieldCategoryName, fieldAmount });
                        this.pivotGridGeneral.BestFit();
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error : " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.tabMain.SelectedTabPageIndex == 1)
            {
                this.dateReportForm.EditValue = this.dtSearchForm.EditValue;
                this.dateReportTo.EditValue = this.dtSearchTo.EditValue;
            }
        }

        private void tab_Click(object sender, EventArgs e)
        {
            if (this.tab.SelectedTabPageIndex == 0)
            {
                this.cbDetail.Checked = true;
                this.butSearchReport_Click(sender, e);
            }
            else if (this.tab.SelectedTabPageIndex == 1)
            {
                this.cbDiscount.Checked = true;
                this.butSearchReport_Click(sender, e);
            }
            else if (this.tab.SelectedTabPageIndex == 2)
            {
                this.cbGeneral.Checked = true;
                this.butSearchReport_Click(sender, e);
            }
        }

        private void cbDetail_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 0;
            this.butSearchReport_Click(sender, e);
        }

        private void cbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 1;
            this.butSearchReport_Click(sender, e);
        }

        private void cbGeneral_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 2;
            this.butSearchReport_Click(sender, e);
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbDetail.Checked)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                        this.pivotGridDetail.ExportToXlsx(frm.pathName);
                }
                else if (this.cbDiscount.Checked)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                        this.pivotGridResult.ExportToXlsx(frm.pathName);
                }
                else if (this.cbGeneral.Checked)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                        this.pivotGridGeneral.ExportToXlsx(frm.pathName);
                }
            }
            catch { }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            this.dateReportForm.EditValue = this.dateReportTo.EditValue = this.dtimePosting;
            this.lkupServiceGroupReport.EditValue = string.Empty;
            this.searchLKupDoctorResult.EditValue = string.Empty;
            this.mnoTitle.Text = string.Empty;
            this.pivotGridResult.DataSource = null;
            this.pivotGridResult.Fields.Clear();
            this.pivotGridGeneral.DataSource = null;
            this.pivotGridGeneral.Fields.Clear();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAll.Text = chkAll.Checked ? "UnCheck" : "Check All";
            if (this.chkAll.Checked)
            {
                foreach (DataRow dr in this.tableServices.Rows)
                {
                    dr["Check"] = 1;
                }
            }
            else
            {
                foreach (DataRow dr in this.tableServices.Rows)
                {
                    dr["Check"] = 0;
                }
            }
        }

    }
}