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
using DevExpress.XtraTab;
using DevExpress.XtraReports.UI;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_ThongKeBenhNhan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sGroup = string.Empty;
        private string sCate = string.Empty, userID = string.Empty;
        private DataTable tableListDetail = new DataTable();
        public frmBaoCao_ThongKeBenhNhan(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmBaoCao_ThongKeBenhNhan_Load(object sender, EventArgs e)
        {
            List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
            this.lkupNhomDV.Properties.DataSource = lstGroup;
            this.lkupNhomDV.Properties.ValueMember = "ServiceGroupCode";
            this.lkupNhomDV.Properties.DisplayMember = "ServiceGroupName";
        }
        
        private void butPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridControl_result.ShowPrintPreview();
        }

        private void butReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceCodeTemp = this.cbxService.EditValue.ToString();
                string serviceCode = string.Empty;
                string[] arrTemp = serviceCodeTemp.Split(',');
                for (int i = 0; i < arrTemp.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arrTemp[i].ToString()))
                        serviceCode += "'" + arrTemp[i].ToString().Trim() + "',";
                }
                if (TabMain.SelectedTabPage.Name == "pageSummary")
                {
                    this.gridControl_Summary.DataSource = PatientReceiveBLL.DT_ReportReceive(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.chkGetReceive.Checked ? true : false, this.lkupNhomDV.EditValue.ToString(), serviceCode.TrimEnd(','));
                }
                else if (TabMain.SelectedTabPage.Name == "pageList")
                {
                    this.tableListDetail = PatientReceiveBLL.DT_ListReportReceive(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.lkupNhomDV.EditValue.ToString(), this.chkGetReceive.Checked ? true : false, serviceCode.TrimEnd(','));
                    if (this.tableListDetail != null && this.tableListDetail.Rows.Count > 0)
                    {
                        this.gridControl_result.DataSource = this.tableListDetail;
                        this.gridView_result.Columns["PatientName"].Group();
                        this.gridView_result.ExpandAllGroups();
                    }
                    else
                    {
                        this.gridControl_result.DataSource = this.tableListDetail;
                        XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (this.TabMain.SelectedTabPage.Name == "pageSummary")
            {
                this.gridControl_Summary.ShowRibbonPrintPreview();
            }
            if (this.TabMain.SelectedTabPage.Name == "pageList")
            {
                ///view_KB_ListPatientReceiveDetail
                if (this.tableListDetail != null && this.tableListDetail.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Merge(this.tableListDetail);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\view_KB_ListPatientReceiveDetail.xml");
                    if (!this.chkPrintGroup.Checked)
                    {
                        Reports.view_KB_ListPatientReceiveDetail rptShow = new Reports.view_KB_ListPatientReceiveDetail();
                        rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                        rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DSTiepNhan","Danh sách tiếp nhận");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        Reports.view_KB_ListPatientReceiveDetailGroup rptShow = new Reports.view_KB_ListPatientReceiveDetailGroup();
                        rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                        rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DSTiepNhan", "Danh sách tiếp nhận");
                        rpt.ShowDialog();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void TabMain_Click(object sender, EventArgs e)
        {
            this.butOK_Click(sender, e);
        }

        private void lkupNhomDV_EditValueChanged(object sender, EventArgs e)
        {
            this.cbxService.Properties.DataSource = ServiceBLL.ListService(this.lkupNhomDV.EditValue.ToString(), string.Empty, 0);
            this.cbxService.Properties.ValueMember = "ServiceCode";
            this.cbxService.Properties.DisplayMember = "ServiceName";
        }

        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            this.gridControl_result.ShowRibbonPrintPreview();
        }

    }
}