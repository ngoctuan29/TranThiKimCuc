using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmCoSoTuTruc : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCode = string.Empty;
        private DataTable tableInventory = new DataTable();
        public frmCoSoTuTruc(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lkupKho.EditValue == null || string.IsNullOrEmpty(this.lkupKho.Text.Trim()))
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem cơ số tủ trực.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else
                {
                    this.LoadDataInventory();
                }
            }
            catch { }
        }

        private void LoadDataInventory()
        {
            this.tableInventory = RepositoryCatalog_BLL.TableViewInventoryLimited(this.lkupKho.EditValue.ToString());
            this.gridControl_Safety.DataSource = this.tableInventory;
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.gridControl_Safety.ShowRibbonPrintPreview();
        }

        private void gridView_Safety_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Limited)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Limited, " Nhập cơ số cho tủ trực!");
                }
                if (e.Valid == true)
                {
                    InventoryLimitedInf objLimited = new InventoryLimitedInf();
                    objLimited.RepositoryCode = this.lkupKho.EditValue.ToString();
                    objLimited.ItemCode = gridView_Safety.GetRowCellValue(e.RowHandle, "ItemCode").ToString();
                    Int32 limited = 0;
                    if (!string.IsNullOrEmpty(gridView_Safety.GetRowCellValue(e.RowHandle, "Quantity").ToString()))
                        limited = Convert.ToInt32(gridView_Safety.GetRowCellValue(e.RowHandle, "Quantity").ToString());
                    objLimited.Quantity = limited;
                    objLimited.EmployeeCode = this.employeeCode;
                    objLimited.IEmployeeCode = this.employeeCode;
                    if (e.RowHandle < 0)
                    {
                        int result = InventoryBLL.InsInventoryLimited(objLimited);
                        if (result > 0)
                        {
                            XtraMessageBox.Show("Thêm thành công cơ số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadDataInventory();
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm cơ số không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        int result = InventoryBLL.InsInventoryLimited(objLimited);
                        if (result > 0)
                        {
                            XtraMessageBox.Show("Cập nhật thành công cơ số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadDataInventory();
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật cơ số không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch { }
        }

        private void gridView_Safety_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Nhập cơ số tủ trực cho kho!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void frmCoSoTuTruc_Load(object sender, EventArgs e)
        {
            this.lkupKho.Properties.DataSource = RepositoryCatalog_BLL.ListRepositoryForImport(0, "3", this.employeeCode);
            this.lkupKho.Properties.DisplayMember = "RepositoryName";
            this.lkupKho.Properties.ValueMember = "RepositoryCode";
            this.repSearchBHYT_ItemCode.DataSource = ItemsBLL.ListItems(0);
            this.repSearchBHYT_ItemCode.ValueMember = "ItemCode";
            this.repSearchBHYT_ItemCode.DisplayMember = "ItemName";
            this.refUoM.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
            this.refUoM.DisplayMember = "UnitOfMeasureName";
            this.refUoM.ValueMember = "UnitOfMeasureCode";
            this.repUsage.DataSource = UsageBLL.ListUsage(string.Empty);
            this.repUsage.DisplayMember = "UsageName";
            this.repUsage.ValueMember = "UsageCode";
        }

        private void lkupKho_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadDataInventory();
        }
  
    }
}