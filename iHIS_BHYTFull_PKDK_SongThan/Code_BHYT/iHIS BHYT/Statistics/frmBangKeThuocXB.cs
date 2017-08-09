using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using System.Reflection;

namespace Ps.Clinic.Statistics
{
    public partial class frmBangKeThuocXB : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tableResult = new DataTable();
        public frmBangKeThuocXB()
        {
            InitializeComponent();
        }
        
        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Merge(this.tableResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\xmlVviewTH_BangKeXuatBanThuoc.xml");
                    Reports.rpt_TH_BangKeXBThuoc rptShow = new Reports.rpt_TH_BangKeXBThuoc();
                    rptShow.Parameters["fromdate"].Value = this.txtDatefrom.Text;
                    rptShow.Parameters["todate"].Value = this.txtDateto.Text;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BangKeXuatBanThuoc","Bảng kê xuất bán thuốc");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Số liệu báo cáo không có! Vui lòng xem lại thông tin báo cáo.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch{
                XtraMessageBox.Show("Lỗi khi xuất file, vui lòng kiểm tra lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmBangKeThuocXB_Load(object sender, EventArgs e)
        {
            try
            {
                this.lkupKho.Properties.DataSource = RepositoryCatalog_BLL.ListRepositoryForBHYT(0, 4);
                this.lkupKho.Properties.DisplayMember = "RepositoryName";
                this.lkupKho.Properties.ValueMember = "RepositoryCode";

                this.sLookupItem.Properties.DataSource = ItemsBLL.ListItemsRef(0).Select(p => new { p.ItemName, p.ItemCode, p.ItemCategoryName }).ToList();
                this.sLookupItem.Properties.DisplayMember = "ItemName";
                this.sLookupItem.Properties.ValueMember = "ItemCode";
                this.txtDatefrom.EditValue = this.txtDateto.EditValue = Utils.DateServer();
                this.rep_LK_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.rep_LKDocTor.DataSource = EmployeeBLL.ListEmployee(string.Empty);
                this.repLK_Usage.DataSource = UsageBLL.DTUsageList(string.Empty);
            }
            catch { }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.lkupKho.EditValue.ToString()))
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem thống kê.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else if (this.txtDatefrom.Text.Trim() == string.Empty || this.txtDateto.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show("Chọn ngày xem toa thuốc xuất bán!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDatefrom.Focus();
                }
                else
                {
                    if (this.sLookupItem.EditValue != null && !string.IsNullOrEmpty(this.sLookupItem.EditValue.ToString()))
                        this.tableResult = MedicinesRetailBLL.DT_Exp_RetailForPatients(lkupKho.EditValue.ToString(), txtDatefrom.Text.Trim(), txtDateto.Text.Trim(), sLookupItem.EditValue.ToString(), this.chkCancel.Checked ? -1 : 1);
                    else
                        this.tableResult = MedicinesRetailBLL.DT_Exp_RetailForPatients(lkupKho.EditValue.ToString(), txtDatefrom.Text.Trim(), txtDateto.Text.Trim(), "", this.chkCancel.Checked ? -1 : 1);
                    this.gridControl_Result.DataSource = this.tableResult;
                }
            }
            catch { }
        }

        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }
    }
}