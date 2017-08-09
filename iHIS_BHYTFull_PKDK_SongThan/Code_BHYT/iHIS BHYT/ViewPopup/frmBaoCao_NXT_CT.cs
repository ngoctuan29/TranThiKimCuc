using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_NXT_CT : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtRep = new DataTable();
        private DataTable dtResult = new DataTable();
        private DevExpress.Utils.WaitDialogForm waiting = null;
        public frmBaoCao_NXT_CT()
        {
            InitializeComponent();
        }

        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lkupKho.EditValue == null || this.lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem báo cáo.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else
                {
                    string itemCode = string.Empty;
                    if (this.lkupItem.EditValue != null)
                        itemCode = this.lkupItem.EditValue.ToString();
                    this.waiting = new DevExpress.Utils.WaitDialogForm("Chờ xử lý...", "Bệnh viện điện tử .NET");
                    #region code nxt old
                    //Int32 iGroup = Convert.ToInt32(lkupKho.GetColumnValue("RepositoryGroupCode"));
                    //if (iGroup == 1)
                    //{
                    //    dtResult = rpt_Medicines_BLL.DT_View_XNT_TH(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 0, itemCode);
                    //    gridControl_Result.DataSource = dtResult;
                    //    gridView_Result.Columns["GroupName"].Group();
                    //    gridView_Result.Columns["ItemCategoryName"].Group();
                    //    gridView_Result.ExpandAllGroups();
                    //}
                    //else if (iGroup == 2)
                    //{
                    //    dtResult = rpt_Medicines_BLL.DT_View_XNT_NB(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 0, itemCode);
                    //    gridControl_Result.DataSource = dtResult;
                    //    gridView_Result.Columns["GroupName"].Group();
                    //    gridView_Result.Columns["ItemCategoryName"].Group();
                    //    gridView_Result.ExpandAllGroups();
                    //}
                    //else if (iGroup == 3)
                    //{
                    //    dtResult = rpt_Medicines_BLL.DT_View_XNT_TuTruc(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 0, itemCode);
                    //    gridControl_Result.DataSource = dtResult;
                    //    gridView_Result.Columns["GroupName"].Group();
                    //    gridView_Result.Columns["ItemCategoryName"].Group();
                    //    gridView_Result.ExpandAllGroups();
                    //}
                    //else if (iGroup == 4)
                    //{
                    //    dtResult = rpt_Medicines_BLL.DT_View_XNT_NhaThuoc(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 0, itemCode);
                    //    gridControl_Result.DataSource = dtResult;
                    //    gridView_Result.Columns["GroupName"].Group();
                    //    gridView_Result.Columns["ItemCategoryName"].Group();
                    //    gridView_Result.ExpandAllGroups();
                    //}
                    #endregion
                    #region code nxt new
                    DataTable tableTemp = new DataTable();
                    tableTemp = rpt_Medicines_BLL.DT_View_XNT_GeneralDetail(this.lkupKho.EditValue.ToString(), this.dtNgay.TN.ToString(), this.dtNgay.DN.ToString(), itemCode);
                    if (this.chkQuantity.Checked)
                    {
                        if (tableTemp.Select("TotalQuantityEnd>0").Length > 0)
                        {
                            this.dtResult = tableTemp.Select("TotalQuantityEnd>0").CopyToDataTable();
                        }
                    }
                    else
                    {
                        this.dtResult = tableTemp.Copy();
                    }
                    this.gridControl_Result.DataSource = this.dtResult;
                    this.gridView_Result.Columns["GroupName"].Group();
                    //this.gridView_Result.Columns["ItemCategoryName"].Group();
                    this.gridView_Result.ExpandAllGroups();
                    #endregion
                    this.waiting.Close();
                }
            }
            catch {
                this.waiting.Close();
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
            
        }

        private void frmBaoCao_NXT_CT_Load(object sender, EventArgs e)
        {
            dtRep = RepositoryCatalog_BLL.DTListRepositoryAll(0);
            this.lkupKho.Properties.DataSource = dtRep;
            this.lkupKho.Properties.DisplayMember = "RepositoryName";
            this.lkupKho.Properties.ValueMember = "RepositoryCode";
        }

        public static DateTime GetFirstDayOfMonth(int _MM)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, _MM, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }

        public static DateTime GetLastDayOfMonth(int _MM)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, _MM, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }

        private void butPrintBC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Merge(dtResult);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rpt_NhapXuatTonCT.xml");
                    Reports.rpt_NhapXuatTonCT rpt = new Reports.rpt_NhapXuatTonCT();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["prKho"].Value = this.lkupKho.Text;
                    rpt.Parameters["fromdate"].Value = this.dtNgay.TN;
                    rpt.Parameters["todate"].Value = this.dtNgay.DN;
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh! Vui lòng xem lại thông tin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupKho_EditValueChanged(object sender, EventArgs e)
        {
            this.lkupItem.Properties.DataSource = ItemsBLL.DT_ListItemsRefForRepCode(0, this.lkupKho.EditValue.ToString());
            this.lkupItem.Properties.DisplayMember = "ItemName";
            this.lkupItem.Properties.ValueMember = "ItemCode";
        }
    }
}