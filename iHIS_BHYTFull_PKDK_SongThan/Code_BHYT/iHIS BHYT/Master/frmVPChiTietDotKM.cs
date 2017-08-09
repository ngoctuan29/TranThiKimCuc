using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Globalization;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace Ps.Clinic.Master
{
    public partial class frmVPChiTietDotKM : DevExpress.XtraEditors.XtraForm
    {
        private int rowid = -1;
        private string employeeCode = string.Empty;
        private DataTable tableDetail = new DataTable();
        public frmVPChiTietDotKM(int _rowid, string _employeeCode)
        {
            this.rowid = _rowid;
            this.employeeCode = _employeeCode;
            InitializeComponent();
        }

        private void frmVPChiTietDotKM_Load(object sender, EventArgs e)
        {
            try
            {
                this.repSearch_ServiceCode.DataSource = ServiceBLL.DTServiceReal();
                this.repSearch_ServiceCode.ValueMember = "ServiceCode";
                this.repSearch_ServiceCode.DisplayMember = "ServiceName";
                this.LoadDataDetail();
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void LoadDataDetail()
        {
            try
            {
                this.tableDetail = ServiceSalesBLL.TableServiceSalesDetail(this.rowid);
                this.gridControl_Data.DataSource = this.tableDetail;
            }
            catch (Exception)
            {
                this.gridControl_Data.DataSource = null;
                return;
            }
        }

        private void repSearch_ServiceCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string servicecode = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceCode").ToString();
                DataRow r = Utils.GetPriceRowbyCode(tableDetail, "ServiceCode='" + servicecode + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Dịch vụ đã tồn tại trong đợt khuyến mãi này!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Data.SetFocusedRowCellValue(this.col_ServiceCode, null);
                    this.gridView_Data.SetFocusedRowCellValue(this.col_UnitPrice, 0);
                    this.gridView_Data.SetFocusedRowCellValue(this.col_RateSales, 0);
                    this.gridView_Data.SetFocusedRowCellValue(this.col_UnitPriceSales, 0);
                }
                else
                {
                    decimal unitprice = 0;
                    List<ServicePriceInf> list = ServicePriceBLL.ListServicePriceReal(servicecode, 2);
                    if (list != null && list.Count > 0)
                        unitprice = list[0].UnitPrice;
                    this.gridView_Data.SetFocusedRowCellValue(col_UnitPrice, unitprice);
                    this.gridView_Data.SetFocusedRowCellValue(col_RateSales, 0);
                    this.gridView_Data.SetFocusedRowCellValue(col_UnitPriceSales, 0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridView_Data_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            decimal unitprice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_UnitPrice));
            int rate = Convert.ToInt32(view.GetFocusedRowCellValue(col_RateSales));
            if (view.FocusedColumn.FieldName == "UnitPrice")
            {
                if (e.Value != null)
                {
                    if (Utils.CheckNumber(e.Value.ToString()))
                    {
                        unitprice = Convert.ToDecimal(e.Value.ToString());
                        view.SetFocusedRowCellValue(col_UnitPriceSales, Math.Round((unitprice * rate) / 100, MidpointRounding.AwayFromZero));
                    }
                    else
                    {
                        view.SetFocusedRowCellValue(col_UnitPriceSales, 0);
                    }
                }
            }
            if (view.FocusedColumn.FieldName == "RateSales")
            {
                if (e.Value != null)
                {
                    if (Utils.CheckNumber(e.Value.ToString()))
                    {
                        rate = Convert.ToInt32(e.Value.ToString());
                        view.SetFocusedRowCellValue(col_UnitPriceSales, Math.Round((unitprice * rate) / 100, MidpointRounding.AwayFromZero));
                    }
                    else
                        view.SetFocusedRowCellValue(col_UnitPriceSales, 0);
                }
            }
            if (view.FocusedColumn.FieldName == "UnitPriceSales")
            {
                if (e.Value != null)
                {
                    if (Utils.CheckNumber(e.Value.ToString()))
                    {
                        view.SetFocusedRowCellValue(col_UnitPriceSales, Math.Round(Convert.ToDecimal(e.Value.ToString()), MidpointRounding.AwayFromZero));
                        view.SetFocusedRowCellValue(col_RateSales, 0);
                    }
                    else
                        view.SetFocusedRowCellValue(col_UnitPriceSales, 0);
                }
            }
        }

        private void gridView_Data_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Kiểm tra lại thông tin đợt dịch vụ khai báo đợt khuyến mãi.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Data_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ServiceCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ServiceCode, "Chọn dịch vụ!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitPrice)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_UnitPrice, "Nhập giá trước khuyến mãi.");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitPriceSales)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_UnitPriceSales, "Nhập giá khuyến mãi!");
                }
                if (e.Valid)
                {
                    ServiceSalesDetailInf inf = new ServiceSalesDetailInf();
                    inf.IDSales = this.rowid;
                    inf.ServiceCode = gridView_Data.GetRowCellValue(e.RowHandle, "ServiceCode").ToString();
                    inf.UnitPrice = Convert.ToDecimal(gridView_Data.GetRowCellValue(e.RowHandle, "UnitPrice").ToString());
                    inf.RateSales = Convert.ToInt32(gridView_Data.GetRowCellValue(e.RowHandle, "RateSales").ToString());
                    inf.UnitPriceSales = Convert.ToInt32(gridView_Data.GetRowCellValue(e.RowHandle, "UnitPriceSales").ToString());
                    inf.EmployeeCode = this.employeeCode;
                    if (e.RowHandle < 0)
                    {
                        if (ServiceSalesBLL.InsServiceSalesDetail(inf) != 1)
                        {
                            XtraMessageBox.Show("Khai báo không thành công! \r\n Vui lòng xem lại thông tin nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (ServiceSalesBLL.InsServiceSalesDetail(inf) != 1)
                        {
                            XtraMessageBox.Show("Cập nhật không thành công! \r\n Vui lòng xem lại thông tin nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    this.LoadDataDetail();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl_Data_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Data.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa dịch vụ trong đợt khuyến mãi này.", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        int result = ServiceSalesBLL.DelServiceSalesDetail(this.rowid, this.gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "ServiceCode").ToString());
                        if (result == -1)
                            XtraMessageBox.Show(" Dịch vụ đã áp dụng không được phép xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (result == 404)
                            XtraMessageBox.Show("Xóa không thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.LoadDataDetail();
                    }
                    catch { return; }
                }
            }
        }
    }
}