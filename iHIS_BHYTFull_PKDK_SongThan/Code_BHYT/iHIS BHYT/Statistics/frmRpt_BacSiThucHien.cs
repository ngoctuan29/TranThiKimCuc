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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmRpt_BacSiThucHien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sGroup = string.Empty;
        private String sCate = string.Empty;
        private String sService = string.Empty;
        private String sDoctor = string.Empty;
        private string employeeCode = string.Empty;
        public frmRpt_BacSiThucHien(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmRpt_BacSiThucHien_Load(object sender, EventArgs e)
        {
            try
            {
                chkList_Doctor.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
                chkList_Doctor.DisplayMember = "EmployeeName";
                chkList_Doctor.ValueMember = "EmployeeCode";
                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
                chkList_Group.DataSource = lstGroup;
                chkList_Group.ValueMember = "ServiceGroupCode";
                chkList_Group.DisplayMember = "ServiceGroupName";

                var listDepart = (from p in DepartmentBLL.ListDepartment("") where p.Hide == 0 select new { p.DepartmentCode, p.DepartmentName }).ToList();
                cbDepartment.Properties.DataSource = listDepart;
                cbDepartment.Properties.DisplayMember = "DepartmentName";
                cbDepartment.Properties.ValueMember = "DepartmentCode";

                lkPatientType.Properties.DataSource = PatientsBLL.DT_PatientType();
                lkPatientType.Properties.DisplayMember = "TypeName";
                lkPatientType.Properties.ValueMember = "RowID";
                this.mnoTitle.Text = "THỐNG KÊ CA THỰC HIỆN";
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                sService = string.Empty;
                foreach (ServiceInf inf in chkList_Service.CheckedItems)
                {
                    sService += inf.ServiceCode + ",";
                }
                sDoctor = string.Empty;
                foreach (EmployeeViewInf inf in chkList_Doctor.CheckedItems)
                {
                    sDoctor += inf.EmployeeCode + ",";
                }
                DataTable tableResult = new DataTable();
                tableResult = rpt_General_BLL.TableTotalSuggestedForDoctorForDoing(dtNgay.TN, dtNgay.DN, sCate.Replace("'", "").TrimEnd(','), sDoctor.TrimEnd(','), 1, sGroup.Replace("'", "").TrimEnd(','), 1, sService.TrimEnd(','));
                if (tableResult != null && tableResult.Rows.Count > 0)
                {
                    if (rd01.Checked)
                    {
                        //Reports.view_BacSiChiDinh rpt = new Reports.view_BacSiChiDinh();
                        //rpt.DataSource = tableResult;
                        //rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                        //rpt.Parameters["fromdate"].Value = dtNgay.TN;
                        //rpt.Parameters["todate"].Value = dtNgay.DN;
                        //rpt.CreateDocument();
                        //rpt.ShowRibbonPreviewDialog();
                        ////
                        DataSet dsTemp = new DataSet("table");
                        dsTemp.Merge(tableResult);
                        dsTemp.WriteXmlSchema(@"..\\..\xml\\view_BacSiChiDinh.xml");
                        Reports.view_BacSiThucHien rpt = new Reports.view_BacSiThucHien();
                        rpt.DataSource = dsTemp;
                        rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                        rpt.Parameters["fromdate"].Value = dtNgay.TN;
                        rpt.Parameters["todate"].Value = dtNgay.DN;
                        //rpt.CreateDocument();
                        rpt.ShowRibbonPreviewDialog();
                    }
                    else if (rd02.Checked)
                    {
                        Reports.view_BacSiChiDinhTH rpt = new Reports.view_BacSiChiDinhTH();
                        rpt.DataSource = tableResult;
                        rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                        rpt.Parameters["fromdate"].Value = dtNgay.TN;
                        rpt.Parameters["todate"].Value = dtNgay.DN;
                        rpt.CreateDocument();
                        rpt.ShowRibbonPreviewDialog();
                    }
                    else if (rd03.Checked)
                    {
                        Reports.view_BacSiChiDinhTH01 rpt = new Reports.view_BacSiChiDinhTH01();
                        rpt.DataSource = tableResult;
                        rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                        rpt.Parameters["fromdate"].Value = dtNgay.TN;
                        rpt.Parameters["todate"].Value = dtNgay.DN;
                        rpt.CreateDocument();
                        rpt.ShowRibbonPreviewDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Vui lòng chọn mẫu báo cáo để xem thống kê!", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void chkList_Group_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                sGroup = string.Empty;
                foreach (ServiceGroupInf inf in chkList_Group.CheckedItems)
                {
                    sGroup += "'" + inf.ServiceGroupCode + "',";
                }
                chkList_Category.DataSource = ServiceCategoryBLL.rptListServiceCategory(sGroup.TrimEnd(','), "");
                chkList_Category.ValueMember = "ServiceCategoryCode";
                chkList_Category.DisplayMember = "ServiceCategoryName";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chkList_Category_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                sCate = string.Empty;
                foreach (ServiceCategoryInf inf in chkList_Category.CheckedItems)
                {
                    sCate += "'" + inf.ServiceCategoryCode + "',";
                }
                chkList_Service.DataSource = ServiceBLL.rptListService(sGroup.TrimEnd(','), sCate.TrimEnd(','));
                chkList_Service.ValueMember = "ServiceCode";
                chkList_Service.DisplayMember = "ServiceName";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
    }
}