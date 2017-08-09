using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicModel;
using ClinicLibrary;

namespace Ps.Clinic.Master
{
    public partial class frmLimitForService : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable tableService;
        private string employeeCode = string.Empty;
        private DevExpress.Utils.WaitDialogForm waiting = null;
        public frmLimitForService(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmLimitForService_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable tainhSex = new DataTable();
                tainhSex.Columns.Add(new DataColumn("StatusCode", typeof(Int32)));
                tainhSex.Columns.Add(new DataColumn("StatusName", typeof(string)));
                tainhSex.Rows.Add(new object[] { "0", "Nữ" });
                tainhSex.Rows.Add(new object[] { "1", "Nam" });
                this.ref_status_sex.DataSource = tainhSex;
                this.ref_status_sex.DisplayMember = "StatusName";
                this.ref_status_sex.ValueMember = "StatusCode";

                this.ref_status_position.DataSource = EmployeePositionBLL.DTEmployeePosition(0);
                this.ref_status_position.DisplayMember = "PositionName";
                this.ref_status_position.ValueMember = "PositionCode";

                this.ref_Department.DataSource = DepartmentBLL.DTDepartment(string.Empty);
                this.ref_Department.DisplayMember = "DepartmentName";
                this.ref_Department.ValueMember = "DepartmentCode";
                this.gridControl_Employee.DataSource = EmployeeBLL.DTEmployee(string.Empty, false);
                this.tableService = ServiceBLL.DTServiceReal();
                this.gridControl_Service.DataSource = this.tableService;

            }
            catch { }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            this.waiting = new DevExpress.Utils.WaitDialogForm("Waiting ...", "Bệnh viện điện tử .NET");
            try
            {
                if (this.gridView_Employee.RowCount > 0)
                {
                    string employeeCodeTemp = this.gridView_Employee.GetRowCellValue(this.gridView_Employee.FocusedRowHandle, col_EmployeeCode).ToString();
                    if (this.gridView_Employee.GetFocusedRow() != null)
                    {
                        string msg = string.Empty;
                        DataTable tableTemp = this.tableService.Select("Chon=1", "Chon desc").CopyToDataTable();
                        ServiceBLL.DelServiceLimitAll(employeeCodeTemp);
                        foreach (DataRow row in tableTemp.Rows)
                        {
                            ServiceLimitInf inf = new ServiceLimitInf();
                            inf.ServiceCode = row["ServiceCode"].ToString();
                            inf.EmployeeCode = employeeCodeTemp;
                            inf.IEmployeeCode = this.employeeCode;
                            Int32 result = ServiceBLL.InsServiceLimit(inf);
                            if (result <= 0)
                                msg += row["ServiceName"].ToString() + ";";
                        }
                        if (string.IsNullOrEmpty(msg))
                            XtraMessageBox.Show(" Cập nhật thông tin giới hạn dịch vụ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show(" Các dịch vụ: " + msg.TrimEnd(';') + " cập nhật không thành công. Hãy thực hiện lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.tableService = ServiceBLL.TableServiceLimitForEmployee(employeeCodeTemp);
                        this.gridControl_Service.DataSource = this.tableService;
                    }
                    this.waiting.Close();
                }
                else
                {
                    this.waiting.Close();
                    XtraMessageBox.Show(" Chưa chọn menu giới hạn chỉ định!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch {
                this.waiting.Close(); 
                return;
            }
        }

        private void gridView_Employee_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView_Employee_Click(object sender, EventArgs e)
        {
            try
            {
                this.tableService = new DataTable();
                this.chkAll.Checked = false;
                if (this.gridView_Employee.RowCount > 0)
                {
                    string employeeCodeTemp = this.gridView_Employee.GetRowCellValue(this.gridView_Employee.FocusedRowHandle, col_EmployeeCode).ToString();
                    if (this.gridView_Employee.GetFocusedRow() != null)
                    {
                        this.tableService = ServiceBLL.TableServiceLimitForEmployee(employeeCodeTemp);
                        this.gridControl_Service.DataSource = this.tableService;
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
            catch
            {
                return;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkAll.Text = this.chkAll.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
                if (this.chkAll.Checked)
                {
                    foreach (DataRow dr in this.tableService.Rows)
                    {
                        dr["Chon"] = 1;
                    }
                }
                else
                {
                    foreach (DataRow dr in this.tableService.Rows)
                    {
                        dr["Chon"] = 0;
                    }
                }
            }
            catch { }
        }

    }
}