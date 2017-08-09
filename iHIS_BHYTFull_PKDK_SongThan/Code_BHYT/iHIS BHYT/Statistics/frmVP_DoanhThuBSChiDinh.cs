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

namespace Ps.Clinic.Statistics
{
    public partial class frmVP_DoanhThuBSChiDinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sGroup = string.Empty;
        private String sCate = string.Empty;
        private String sDoctor = string.Empty;
        private List<view_DoctorAppointedInf> lst = new List<view_DoctorAppointedInf>();
        private List<view_DoctorAppointedInf> lstprint = new List<view_DoctorAppointedInf>();
        private string employeeCode = string.Empty;
        public frmVP_DoanhThuBSChiDinh(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmVP_DoanhThuBSChiDinh_Load(object sender, EventArgs e)
        {
            try
            {
                chkList_Doctor.DataSource = EmployeeBLL.ListEmployeeForPosition("3");
                chkList_Doctor.DisplayMember = "EmployeeName";
                chkList_Doctor.ValueMember = "EmployeeCode";

                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
                lkupNhomDV.Properties.DataSource = lstGroup;
                lkupNhomDV.Properties.ValueMember = "ServiceGroupCode";
                lkupNhomDV.Properties.DisplayMember = "ServiceGroupName";

                var listDepart = (from p in DepartmentBLL.ListDepartment("") where p.Hide == 0 select new { p.DepartmentCode, p.DepartmentName }).ToList();
                cbDepartment.Properties.DataSource = listDepart;
                cbDepartment.Properties.DisplayMember = "DepartmentName";
                cbDepartment.Properties.ValueMember = "DepartmentCode";

                lkPatientType.Properties.DataSource = PatientsBLL.DT_PatientType();
                lkPatientType.Properties.DisplayMember = "TypeName";
                lkPatientType.Properties.ValueMember = "RowID";
            }
            catch { }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                List<view_DoctorAppointedInf> lstGroup = new List<view_DoctorAppointedInf>();
                DataTable dtChart = new DataTable();
                dtChart.Columns.Add("ServiceGroupName", typeof(string));
                dtChart.Columns.Add("Quantity", typeof(Int32));
                sCate = string.Empty;
                sDoctor = string.Empty;
                foreach (ServiceCategoryInf inf in chkList_Category.CheckedItems)
                {
                    sCate += "'" + inf.ServiceCategoryCode + "',";
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
                if (lkupNhomDV.EditValue.ToString().Equals("0"))
                    sGroup = string.Empty;

                //if (sGroup == string.Empty)
                //{
                //    XtraMessageBox.Show(" Chọn nhóm dịch vụ.", "Bệnh viện điện tử .NET");
                //    return;
                //}
                if (rdChidinh.Checked)
                    lst = rpt_Medicines_BLL.View_BSChiDinh(sDoctor.TrimEnd(','), dllNgay.tungay.Text, dllNgay.denngay.Text, "", sDepartment.TrimEnd(','), sCate.TrimEnd(','), sGroup.TrimEnd(','), Convert.ToInt32(lkPatientType.EditValue), "", -1, 0, this.employeeCode);
                else if (rdThucHien.Checked)
                    lst = rpt_Medicines_BLL.View_BSChiDinh(sDoctor.TrimEnd(','), dllNgay.tungay.Text, dllNgay.denngay.Text, "", sDepartment.TrimEnd(','), sCate.TrimEnd(','), sGroup.TrimEnd(','), Convert.ToInt32(lkPatientType.EditValue), "", 1, 0, this.employeeCode);
                else if (rdThanhtoan.Checked)
                    lst = rpt_Medicines_BLL.View_BSChiDinh(sDoctor.TrimEnd(','), dllNgay.tungay.Text, dllNgay.denngay.Text, "", sDepartment.TrimEnd(','), sCate.TrimEnd(','), sGroup.TrimEnd(','), Convert.ToInt32(lkPatientType.EditValue), "", -1, 1, this.employeeCode);
                if (lst != null && lst.Count > 0)
                {
                    if (sGroup == string.Empty)
                    {
                        sGroup = "'" + lkupNhomDV.EditValue.ToString() + "'";
                    }
                    List<ServiceCategoryInf> lsrCate = new List<ServiceCategoryInf>();
                    lsrCate = ServiceCategoryBLL.rptListServiceCategory(sGroup.TrimEnd(','), sCate.TrimEnd(','));
                    Int32 iCount = 0;
                    foreach (ServiceCategoryInf cate in lsrCate)
                    {
                        iCount = lst.FindAll(x => x.ServiceCategoryName == cate.ServiceCategoryName).Count;
                        dtChart.Rows.Add(cate.ServiceCategoryName, iCount);
                    }
                    gridControl_Result.DataSource = lst;
                    gridView_Result.Columns["ServiceGroupName"].Group();
                    gridView_Result.Columns["ServiceCategoryName"].Group();
                    gridView_Result.Columns["EmployeeNameOrder"].Group();
                    //  gridView_Result.ExpandAllGroups();
                    gridView_Result.ExpandGroupLevel(3);
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (lst != null && lst.Count > 0)
                {
                    Reports.rpt_VP_BacSiChiDinh rpt = new Reports.rpt_VP_BacSiChiDinh();
                    rpt.DataSource = lst;
                    rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                    rpt.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                    rpt.Parameters["todate"].Value = dllNgay.denngay.Text;
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
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

        private void lkupNhomDV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sGroup = "'" + lkupNhomDV.EditValue.ToString() + "'";
                chkList_Category.DataSource = ServiceCategoryBLL.rptListServiceCategory(sGroup.TrimEnd(','), "");
                chkList_Category.ValueMember = "ServiceCategoryCode";
                chkList_Category.DisplayMember = "ServiceCategoryName";
            }
            catch { }
        }

        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }
    }
}