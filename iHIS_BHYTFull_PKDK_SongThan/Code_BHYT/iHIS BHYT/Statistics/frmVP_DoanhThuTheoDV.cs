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
    public partial class frmVP_DoanhThuTheoDV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sGroup = string.Empty;
        private String sCate = string.Empty;
        private String sDoctor = string.Empty;
        private List<view_DoctorAppointedInf> lst = new List<view_DoctorAppointedInf>();
        private List<view_DoctorAppointedInf> lstprint = new List<view_DoctorAppointedInf>();
        private string employeeCode = string.Empty;
        public frmVP_DoanhThuTheoDV(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmVP_DoanhThuBSChiDinh_Load(object sender, EventArgs e)
        {
            try
            {
                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode == "KCB");
                lkupNhomDV.Properties.DataSource = lstGroup;
                lkupNhomDV.Properties.ValueMember = "ServiceGroupCode";
                lkupNhomDV.Properties.DisplayMember = "ServiceGroupName";
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
                if (sGroup == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn nhóm dịch vụ.", "Bệnh viện điện tử .NET");
                    return;
                }
                
                 lst = rpt_Medicines_BLL.View_ChiDinhKCB( dllNgay.tungay.Text, dllNgay.denngay.Text,  sGroup.TrimEnd(','), 1);
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
                    gridView_Result.Columns["ServiceName"].Group();
                    gridView_Result.ExpandAllGroups();
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
        private void lkupNhomDV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sGroup = "'" + lkupNhomDV.EditValue.ToString() + "'";
            }
            catch { }
        }

        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }
    }
}