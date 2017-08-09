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
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_NXT_TH : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtRep = new DataTable();
        private DataTable dtResult = new DataTable();
        private DevExpress.Utils.WaitDialogForm waiting = null;
        public frmBaoCao_NXT_TH()
        {
            InitializeComponent();
        }
                
        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lkupKho.EditValue == null || this.lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem báo cáo.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else
                {
                    this.gridControl_Result.DataSource = null;
                    string itemCode = string.Empty;
                    if (this.lkupItem.EditValue != null)
                        itemCode = this.lkupItem.EditValue.ToString();
                    this.waiting = new DevExpress.Utils.WaitDialogForm("Chờ xử lý...", "Bệnh viện điện tử .NET");

                    #region  code nxt old
                    //this.group = Convert.ToInt32(lkupKho.GetColumnValue("RepositoryGroupCode"));
                    //if (this.group == 1)
                    //{
                    //    this.dtResult = rpt_Medicines_BLL.DT_View_XNT_TH(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 1, itemCode);
                    //    this.gridControl_Result.DataSource = dtResult;
                    //    this.gridView_Result.Columns["GroupName"].Group();
                    //    this.gridView_Result.Columns["ItemCategoryName"].Group();
                    //    this.gridView_Result.ExpandAllGroups();
                    //}
                    //else if (this.group == 2)
                    //{
                    //    this.dtResult = rpt_Medicines_BLL.DT_View_XNT_NB(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 1, itemCode);
                    //    this.gridControl_Result.DataSource = dtResult;
                    //    this.gridView_Result.Columns["GroupName"].Group();
                    //    this.gridView_Result.Columns["ItemCategoryName"].Group();
                    //    this.gridView_Result.ExpandAllGroups();
                    //}
                    //else if (this.group == 3)
                    //{
                    //    this.dtResult = rpt_Medicines_BLL.DT_View_XNT_TuTruc(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 1, itemCode);
                    //    this.gridControl_Result.DataSource = dtResult;
                    //    this.gridView_Result.Columns["GroupName"].Group();
                    //    this.gridView_Result.Columns["ItemCategoryName"].Group();
                    //    this.gridView_Result.ExpandAllGroups();
                    //}
                    //else if (this.group == 4)
                    //{
                    //    this.dtResult = rpt_Medicines_BLL.DT_View_XNT_NhaThuoc(lkupKho.EditValue.ToString(), dtNgay.TN.ToString(), dtNgay.DN.ToString(), 1, itemCode);
                    //    this.gridControl_Result.DataSource = dtResult;
                    //    this.gridView_Result.Columns["GroupName"].Group();
                    //    this.gridView_Result.Columns["ItemCategoryName"].Group();
                    //    this.gridView_Result.ExpandAllGroups();
                    //}
                    #endregion

                    #region code nxt new
                    DataTable tableTemp = rpt_Medicines_BLL.DT_View_XNT_General(this.lkupKho.EditValue.ToString(), this.dtNgay.TN.ToString(), this.dtNgay.DN.ToString(), itemCode);
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
                    this.advBandedGridView1.Columns["GroupName"].Group();
                    //this.gridView_Result.Columns["ItemCategoryName"].Group();
                    this.advBandedGridView1.ExpandAllGroups();
                    #endregion

                    this.waiting.Close();
                }
            }
            catch
            {
                this.waiting.Close();
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.gridControl_Result.ShowRibbonPrintPreview();
        }

        private void frmBaoCao_NXT_TH_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.dtRep = RepositoryCatalog_BLL.DTListRepositoryAll(0);
                this.lkupKho.Properties.DataSource = this.dtRep;
                this.lkupKho.Properties.DisplayMember = "RepositoryName";
                this.lkupKho.Properties.ValueMember = "RepositoryCode";
            }
            catch { }
        }
        
        private void gridView_Result_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Decimal dAmountEnd = 0;
                Decimal dSafelyQuantity = 0;
                if (e.RowHandle >= 0)
                {
                    dAmountEnd = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, "TotalQuantityEnd").ToString());
                    dSafelyQuantity = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, "SafelyQuantity").ToString());
                    //dAmountEnd = Convert.ToDecimal(View.GetRowCellDisplayText(e.RowHandle, View.Columns["AmountEnd"].ToString()));
                    //dSafelyQuantity = Convert.ToDecimal(View.GetRowCellDisplayText(e.RowHandle, View.Columns["SafelyQuantity"]));
                    if ((dAmountEnd + 5) <= dSafelyQuantity)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                        View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void butPrintBC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Merge(dtResult);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_NhapXuatTonTH.xml");
                    Reports.rpt_NhapXuatTonTH rpt = new Reports.rpt_NhapXuatTonTH();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["prKho"].Value = this.lkupKho.Text.ToUpper();
                    rpt.Parameters["fromdate"].Value = dtNgay.TN;
                    rpt.Parameters["todate"].Value = dtNgay.DN;
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh! Vui lòng xem lại thông tin.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lkupKho.Focus();
                }
            }
            catch { }
        }

        private void lkupKho_EditValueChanged(object sender, EventArgs e)
        {
            this.lkupItem.Properties.DataSource = ItemsBLL.DT_ListItemsRefForRepCode(0, this.lkupKho.EditValue.ToString());
            this.lkupItem.Properties.DisplayMember = "ItemName";
            this.lkupItem.Properties.ValueMember = "ItemCode";
        }
        
    }
}