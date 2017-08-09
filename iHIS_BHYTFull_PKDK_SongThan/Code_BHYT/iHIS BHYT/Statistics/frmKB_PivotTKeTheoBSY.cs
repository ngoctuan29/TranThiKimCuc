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
using DevExpress.XtraCharts;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraPivotGrid;

namespace Ps.Clinic.Statistics
{
    public partial class frmKB_PivotTKeTheoBSY : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String groupCode = string.Empty;
        private String categoryCode = string.Empty;
        private String doctorCode = string.Empty;
        private DataTable tableResult = new DataTable();
        private string employeeCode = string.Empty;

        public frmKB_PivotTKeTheoBSY(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmKB_PivotTKeTheoBSY_Load(object sender, EventArgs e)
        {
            try
            {
                this.chkList_Doctor.DataSource = EmployeeBLL.ListEmployeeForPosition("3");
                this.chkList_Doctor.DisplayMember = "EmployeeName";
                this.chkList_Doctor.ValueMember = "EmployeeCode";

                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
                this.cbxNhomDV.Properties.DataSource = lstGroup;
                this.cbxNhomDV.Properties.ValueMember = "ServiceGroupCode";
                this.cbxNhomDV.Properties.DisplayMember = "ServiceGroupName";
            }
            catch { }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.pivotGridResult.DataSource = null;
                this.pivotGridResult.Fields.Clear();
                this.categoryCode = string.Empty;
                this.doctorCode = string.Empty;
                //if (this.groupCode.TrimEnd(',') == string.Empty)
                //{
                //    XtraMessageBox.Show(" Chọn nhóm dịch vụ xem báo cáo thống kê!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.cbxNhomDV.Focus();
                //    return;
                //}
                foreach (ServiceCategoryInf inf in chkList_Category.CheckedItems)
                {
                    this.categoryCode += inf.ServiceCategoryCode + ",";
                }
                foreach (EmployeeViewInf inf in chkList_Doctor.CheckedItems)
                {
                    this.doctorCode += inf.EmployeeCode + ",";
                }
                this.tableResult = rpt_General_BLL.TableTotalSuggestedForDoctor(this.dllNgay.tungay.Value, this.dllNgay.denngay.Value, this.categoryCode.TrimEnd(','), this.doctorCode.TrimEnd(','), this.chkPaid.Checked ? 1 : 0, this.groupCode.Replace("'", "").TrimEnd(','), this.chkDone.Checked ? 1 : 0);
                if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                {
                    if (!this.chkDone.Checked)
                    {
                        this.pivotGridResult.DataSource = this.tableResult;
                        PivotGridField fieldDate = new PivotGridField("WorkDate", PivotArea.RowArea);
                        fieldDate.Caption = "Ngày";
                        PivotGridField fieldShiftWork = new PivotGridField("ShiftWork", PivotArea.RowArea);
                        fieldShiftWork.Caption = "Ca";
                        PivotGridField fieldDW = new PivotGridField("DW", PivotArea.RowArea);
                        fieldDW.Caption = "Thứ";
                        PivotGridField fieldEmployeeNameDoctor = new PivotGridField("EmployeeNameDoctor", PivotArea.RowArea);
                        fieldEmployeeNameDoctor.Caption = "Bác sỹ";

                        PivotGridField fieldCategoryName = new PivotGridField("ServiceCategoryName", PivotArea.ColumnArea);
                        fieldCategoryName.Caption = "Loại dịch vụ";
                        PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.ColumnArea);
                        fieldServiceName.Caption = "Tên dịch vụ";
                        PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
                        fieldQuantity.Caption = "Số lượng";
                        fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldQuantity.CellFormat.FormatString = "#,#";

                        ////PivotGridField fieldServicePrice = new PivotGridField("ServicePrice", PivotArea.DataArea);
                        ////fieldServicePrice.Caption = "Đơn giá";
                        ////fieldServicePrice.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        ////fieldServicePrice.CellFormat.FormatString = "#,#";
                        PivotGridField fieldAmount = new PivotGridField("Amount", PivotArea.DataArea);
                        fieldAmount.Caption = "Thành Tiền";
                        fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldAmount.CellFormat.FormatString = "#,#";
                        this.pivotGridResult.Fields.AddRange(new PivotGridField[] { fieldEmployeeNameDoctor, fieldDate, fieldShiftWork, fieldDW, fieldCategoryName, fieldServiceName, fieldQuantity, fieldAmount });
                    }
                    else
                    {
                        this.pivotGridResult.DataSource = this.tableResult;
                        PivotGridField fieldEmployeeNameDoctor = new PivotGridField("EmployeeNameDoctor", PivotArea.RowArea);
                        fieldEmployeeNameDoctor.Caption = "Bác sỹ";
                        PivotGridField fieldDate = new PivotGridField("WorkDate", PivotArea.RowArea);
                        fieldDate.Caption = "Ngày";
                        PivotGridField fieldPatientName = new PivotGridField("PatientName", PivotArea.RowArea);
                        fieldPatientName.Caption = "Họ và tên";
                        PivotGridField fieldPatientGenderName = new PivotGridField("PatientGenderName", PivotArea.RowArea);
                        fieldPatientGenderName.Caption = "Gới tính";
                        PivotGridField fieldPatientBirthyear = new PivotGridField("PatientBirthyear", PivotArea.RowArea);
                        fieldPatientBirthyear.Caption = "Năm sinh";
                        PivotGridField fieldPatientAddress = new PivotGridField("PatientAddress", PivotArea.RowArea);
                        fieldPatientAddress.Caption = "Địa chỉ";
                        PivotGridField fieldNoInvoice = new PivotGridField("NoInvoice", PivotArea.RowArea);
                        fieldNoInvoice.Caption = "Số HĐ";

                        PivotGridField fieldCategoryName = new PivotGridField("ServiceCategoryName", PivotArea.ColumnArea);
                        fieldCategoryName.Caption = "Loại dịch vụ";
                        PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.ColumnArea);
                        fieldServiceName.Caption = "Tên dịch vụ";
                        //PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
                        //fieldQuantity.Caption = "Số lượng";
                        //fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //fieldQuantity.CellFormat.FormatString = "#,#";

                        PivotGridField fieldServicePrice = new PivotGridField("ServicePrice", PivotArea.DataArea);
                        fieldServicePrice.Caption = "Đơn giá";
                        fieldServicePrice.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldServicePrice.CellFormat.FormatString = "#,#";
                        //PivotGridField fieldAmount = new PivotGridField("Amount", PivotArea.DataArea);
                        //fieldAmount.Caption = "Thành Tiền";
                        //fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //fieldAmount.CellFormat.FormatString = "#,#";

                        this.pivotGridResult.Fields.AddRange(new PivotGridField[] { fieldEmployeeNameDoctor, fieldDate, fieldPatientName, fieldPatientGenderName, fieldPatientBirthyear, fieldPatientAddress, fieldNoInvoice, fieldCategoryName, fieldServiceName, fieldServicePrice });
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!\n\t Xem lại thông tin lấy báo cáo thống kê.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                    {
                        this.pivotGridResult.ExportToXlsx(frm.pathName);
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!\n\t Xem lại thông tin lấy báo cáo thống kê.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void cbxNhomDV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.groupCode = string.Empty;
                string sTemp = this.cbxNhomDV.EditValue.ToString();
                string[] arrGroup;
                if (sTemp.Trim() != string.Empty)
                {
                    arrGroup = sTemp.Split(',');
                    for (Int32 i = 0; i < arrGroup.Length; i++)
                    {
                        this.groupCode += "'" + arrGroup.GetValue(i).ToString().Trim(' ') + "',";
                    }
                }
                ///this.groupCode = "'" + this.cbxNhomDV.EditValue.ToString() + "'";
                this.chkList_Category.DataSource = ServiceCategoryBLL.rptListServiceCategory(this.groupCode.TrimEnd(','), "");
                this.chkList_Category.ValueMember = "ServiceCategoryCode";
                this.chkList_Category.DisplayMember = "ServiceCategoryName";
            }
            catch { }
        }

    }
}