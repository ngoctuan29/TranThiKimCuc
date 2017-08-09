using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmTheKho : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.Utils.WaitDialogForm starting = null;
        private DataTable dtRep = new DataTable();
        private DataTable tableItems = new DataTable();
        private DataTable tableResultDetail;

        public frmTheKho()
        {
            InitializeComponent();
            this.dtRep = RepositoryCatalog_BLL.DTListRepositoryAll(0);
            this.lkupKho.Properties.DataSource = dtRep;
            this.lkupKho.Properties.DisplayMember = "RepositoryName";
            this.lkupKho.Properties.ValueMember = "RepositoryCode";
            this.dateFrom.EditValue = this.dateTo.EditValue = Utils.DateServer();
        }
        
        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                tableResultDetail = new DataTable();
                this.butPrint.Enabled = false;
                int countItems = this.tableItems.Select("CheckAll=1", "CheckAll desc").Length;
                if (this.lkupKho.EditValue == null || this.lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem thẻ kho.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else
                {
                    this.starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
                    if (countItems > 0)
                    {
                        DataTable tableItemTemp = new DataTable();
                        DataTable tableResultForItem = new DataTable();
                        tableItemTemp = this.tableItems.Select("CheckAll=1", "CheckAll desc").CopyToDataTable();
                        foreach (DataRow row in tableItemTemp.Rows)
                        {
                            tableResultForItem = InventoryBLL.TableTagRepositoryGeneral(this.lkupKho.EditValue.ToString(), Convert.ToDateTime(this.dateFrom.EditValue), Convert.ToDateTime(this.dateTo.EditValue), row["ItemCode"].ToString());
                            if (tableResultForItem.Rows.Count > 0)
                                this.tableResultDetail.Merge(tableResultForItem.Copy());
                        }
                    }
                    else
                        this.tableResultDetail = InventoryBLL.TableTagRepositoryGeneral(this.lkupKho.EditValue.ToString(), Convert.ToDateTime(this.dateFrom.EditValue), Convert.ToDateTime(this.dateTo.EditValue), "");
                    this.gridControl_Result.DataSource = this.tableResultDetail;
                    this.gridView_Result.Columns["ItemCode"].Group();
                    this.gridView_Result.ExpandAllGroups();
                    this.starting.Close();
                    if (this.tableResultDetail != null && this.tableResultDetail.Rows.Count > 0)
                        this.butPrint.Enabled = true;
                }
            }
            catch { return; }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReport = new DataSet();
                DataTable tableTemp = this.tableResultDetail.Copy();
                dsReport.Tables.Add(tableTemp);
                dsReport.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptTag.xml");
                Reports.rpt_Thuoc_TheKho rptShow = new Reports.rpt_Thuoc_TheKho();
                rptShow.Parameters["fromdate"].Value = this.dateFrom.Text;
                rptShow.Parameters["todate"].Value = this.dateTo.Text;
                rptShow.DataSource = dsReport;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "TheKho","Thẻ kho");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupKho_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tableItems = InventoryBLL.TableTagWarehousing(this.lkupKho.EditValue.ToString());
                this.gridControl_ItemList.DataSource = this.tableItems;
                //this.gridView_ItemList.Columns["GroupName"].Group();
                //this.gridView_ItemList.Columns["ItemCategoryName"].Group();
                //this.gridView_Result.ExpandAllGroups();
            }
            catch { }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.tableItems = InventoryBLL.TableTagWarehousing(this.lkupKho.EditValue.ToString());
            this.gridControl_ItemList.DataSource = this.tableItems;
        }

        private void ViewGrid_Click(object sender, EventArgs e)
        {
            this.gridView_Result.ShowPrintPreview();
        }
    }
}