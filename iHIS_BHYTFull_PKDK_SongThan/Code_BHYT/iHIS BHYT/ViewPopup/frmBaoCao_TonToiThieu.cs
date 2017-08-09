using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicLibrary;
using ClinicBLL;
using ClinicModel;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_TonToiThieu : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtRep = new DataTable();
        public frmBaoCao_TonToiThieu()
        {
            InitializeComponent();
            this.dtRep = RepositoryCatalog_BLL.DTListRepositoryAll(0);
            this.lkupKho.Properties.DataSource = dtRep;
            this.lkupKho.Properties.DisplayMember = "RepositoryName";
            this.lkupKho.Properties.ValueMember = "RepositoryCode";
        }

        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lkupKho.EditValue == null || this.lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem tồn kho.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else
                {
                    DataTable tableResult = new DataTable();
                    tableResult = RepositoryCatalog_BLL.DT_ViewInventory(this.lkupKho.EditValue.ToString());
                    if(this.chkWarning.Checked)
                    {
                        if (tableResult.Select("AmountEnd>0").Length > 0)
                            this.gridControl_Safety.DataSource = tableResult.Select("AmountEnd>0").CopyToDataTable();
                        else
                            this.gridControl_Safety.DataSource = tableResult;
                    }
                    else
                        this.gridControl_Safety.DataSource = tableResult;
                }
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.gridControl_Safety.ShowRibbonPrintPreview();
        }

        private void gridView_Safety_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                decimal safelyQuantityTemp = 0;
                decimal amountEndTemp = 0;
                if (e.RowHandle >= 0)
                {
                    amountEndTemp = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, "AmountEnd").ToString());
                    safelyQuantityTemp = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, "SafelyQuantity").ToString());
                    if (amountEndTemp < safelyQuantityTemp)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                    }
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show(" Error: "+ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; }
        }
        
    }
}