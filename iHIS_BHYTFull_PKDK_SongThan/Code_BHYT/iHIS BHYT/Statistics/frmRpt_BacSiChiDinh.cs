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
    public partial class frmRpt_BacSiChiDinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sGroup = string.Empty;
        private String sCate = string.Empty;
        private String sService = string.Empty;
        private String sDoctor = string.Empty;
        private string employeeCode = string.Empty;
        public frmRpt_BacSiChiDinh(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmRpt_BacSiChiDinh_Load(object sender, EventArgs e)
        {
            try
            {
                this.chkList_Doctor.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
                this.chkList_Doctor.DisplayMember = "EmployeeName";
                this.chkList_Doctor.ValueMember = "EmployeeCode";

                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
                this.chkList_Group.DataSource = lstGroup;
                this.chkList_Group.ValueMember = "ServiceGroupCode";
                this.chkList_Group.DisplayMember = "ServiceGroupName";

                var listDepart = (from p in DepartmentBLL.ListDepartment(string.Empty) where p.Hide == 0 select new { p.DepartmentCode, p.DepartmentName }).ToList();
                this.cbDepartment.Properties.DataSource = listDepart;
                this.cbDepartment.Properties.DisplayMember = "DepartmentName";
                this.cbDepartment.Properties.ValueMember = "DepartmentCode";

                this.lkPatientType.Properties.DataSource = PatientsBLL.DT_PatientType();
                this.lkPatientType.Properties.DisplayMember = "TypeName";
                this.lkPatientType.Properties.ValueMember = "RowID";
                this.mnoTitle.Text = "THỐNG KÊ CA CHỈ ĐỊNH";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                List<view_DoctorAppointedInf> lst = new List<view_DoctorAppointedInf>();
                sService = string.Empty;
                sDoctor = string.Empty;
                foreach (ServiceInf inf in chkList_Service.CheckedItems)
                {
                    sService += "'" + inf.ServiceCode + "',";
                }
                foreach (EmployeeViewInf inf in chkList_Doctor.CheckedItems)
                {
                    sDoctor += "'" + inf.EmployeeCode + "',";
                }
                string sDepartment = cbDepartment.EditValue.ToString();
                string[] arrKp;
                if (sDepartment.Length > 0)
                    arrKp = sDepartment.Split(',');
                else
                    arrKp = null;
                if (arrKp != null)
                {
                    sDepartment = string.Empty;
                    for (Int32 i = 0; i < arrKp.Length; i++)
                    {
                        sDepartment += "'" + arrKp[i].ToString().Trim() + "',";
                    }
                }
                lst = rpt_Medicines_BLL.View_BSChiDinh(sDoctor.TrimEnd(','), dtNgay.TN, dtNgay.DN, sDepartment.TrimEnd(','), "", sCate.TrimEnd(','), sGroup.TrimEnd(','), Convert.ToInt32(lkPatientType.EditValue), sService.TrimEnd(','), -1, 0, this.employeeCode);
                if (lst != null && lst.Count > 0)
                {
                    if (rd01.Checked)
                    {
                        Reports.view_BacSiChiDinh rpt = new Reports.view_BacSiChiDinh();
                        rpt.DataSource = lst;
                        rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                        rpt.Parameters["fromdate"].Value = dtNgay.TN;
                        rpt.Parameters["todate"].Value = dtNgay.DN;
                        rpt.CreateDocument();
                        rpt.ShowRibbonPreviewDialog();
                    }
                    else if (rd02.Checked)
                    {
                        Reports.view_BacSiChiDinhTH rpt = new Reports.view_BacSiChiDinhTH();
                        rpt.DataSource = lst;
                        rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                        rpt.Parameters["fromdate"].Value = dtNgay.TN;
                        rpt.Parameters["todate"].Value = dtNgay.DN;
                        rpt.CreateDocument();
                        rpt.ShowRibbonPreviewDialog();
                    }
                    else if (rd03.Checked)
                    {
                        Reports.view_BacSiChiDinhTH01 rpt = new Reports.view_BacSiChiDinhTH01();
                        rpt.DataSource = lst;
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
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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