using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Linq;
using System.Linq;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors.Controls;

namespace Ps.Clinic.Master
{
    public partial class frmUpdateInventory : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userid = string.Empty;
        private DataTable dtDetail = new DataTable();
        public frmUpdateInventory(string _userid)
        {
            InitializeComponent();
            userid = _userid;
        }

        private void frmUpdateInventory_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            this.ref_Item.DataSource = ItemsBLL.ListItemsRef(0);
            this.ref_Item.DisplayMember = "ItemName";
            this.ref_Item.ValueMember = "ItemCode";

            this.ref_UoM.DataSource = UnitOfMeasureBLL.DTUnit(string.Empty,"I");
            this.ref_UoM.DisplayMember = "UnitOfMeasureName";
            this.ref_UoM.ValueMember = "UnitOfMeasureCode";
        }
        
        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtfrom.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtfrom.Focus();
                    return;
                }
                if (this.dtto.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtto.Focus();
                    return;
                }
                this.gridControl_Search.DataSource = Warehousing_BLL.ListSearch(dtfrom.Text, dtto.Text, this.userid);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void gridView_Detail_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                decimal _UnitPrice = 0, _SalesPrice = 0, _Amount = 0;
                decimal _Quantity = 0;
                decimal _Tax = 0;
                if (view.GetFocusedRowCellValue(col_Details_UnitPrice).ToString() != string.Empty)
                    _UnitPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_UnitPrice));
                if (view.GetFocusedRowCellValue(col_Details_Quantity).ToString() != string.Empty)
                    _Quantity = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_Quantity));
                if (view.GetFocusedRowCellValue(col_Details_Tax).ToString() != string.Empty)
                    _Tax = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_Tax));
                if (view.GetFocusedRowCellValue(col_Details_SalesPrice).ToString() != string.Empty)
                    _SalesPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_SalesPrice));
                if (view.GetFocusedRowCellValue(col_Details_Amount).ToString() != string.Empty)
                    _Amount = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_Amount));
                decimal _Scot = 0;
                decimal _TotalTax = 0;

                if (view.FocusedColumn.FieldName == "Quantity")
                {
                    if (_UnitPrice > 0)
                    {
                        view.SetFocusedRowCellValue(col_Details_Amount, _UnitPrice * Convert.ToDecimal(e.Value));
                        _Scot = ((_UnitPrice * Convert.ToDecimal(e.Value)) * _Tax) / 100;
                        _TotalTax = (_UnitPrice * Convert.ToDecimal(e.Value)) + _Scot;
                        view.SetFocusedRowCellValue(col_Details_Scot, _Scot);
                        view.SetFocusedRowCellValue(col_Details_TotalTax, _TotalTax);
                        view.SetFocusedRowCellValue(col_Details_SalesPrice, _TotalTax / _Quantity);
                    }
                }
                if (view.FocusedColumn.FieldName == "UnitPrice")
                {
                    if (_Quantity > 0)
                    {
                        decimal dTemp = Convert.ToDecimal(e.Value);
                        view.SetFocusedRowCellValue(col_Details_Amount, _Quantity * dTemp);
                        SystemParameterInf objSys = SystemParameterBLL.ObjParameter(205);
                        if (objSys.Values == 1)
                        {
                            _Tax = BracketPrice_BLL.SearchRateOf(dTemp);
                        }
                        _Scot = ((_Quantity * Convert.ToDecimal(e.Value)) * _Tax) / 100;
                        _TotalTax = (_Quantity * Convert.ToDecimal(e.Value)) + _Scot;
                        view.SetFocusedRowCellValue(col_Details_Tax, _Tax);
                        view.SetFocusedRowCellValue(col_Details_Scot, _Scot);
                        view.SetFocusedRowCellValue(col_Details_TotalTax, _TotalTax);
                        view.SetFocusedRowCellValue(col_Details_SalesPrice, _TotalTax / _Quantity);
                    }
                }
                if (view.FocusedColumn.FieldName == "Amount")
                {
                    if (_Quantity > 0)
                    {
                        //view.SetFocusedRowCellValue(col_Details_Amount, _Quantity * Convert.ToDecimal(e.Value));
                        decimal dTemp = Convert.ToDecimal(e.Value);
                        SystemParameterInf objSys = SystemParameterBLL.ObjParameter(205);
                        if (objSys.Values == 1)
                        {
                            _Tax = BracketPrice_BLL.SearchRateOf(dTemp / _Quantity);
                        }
                        _Scot = (Convert.ToDecimal(e.Value) * _Tax) / 100;
                        _TotalTax = Convert.ToDecimal(e.Value) + _Scot;
                        view.SetFocusedRowCellValue(col_Details_Scot, _Scot);
                        view.SetFocusedRowCellValue(col_Details_Tax, _Tax);
                        view.SetFocusedRowCellValue(col_Details_TotalTax, _TotalTax);
                        view.SetFocusedRowCellValue(col_Details_SalesPrice, _TotalTax / _Quantity);
                        view.SetFocusedRowCellValue(col_Details_UnitPrice, _TotalTax / _Quantity);

                    }
                }
                if (view.FocusedColumn.FieldName == "Tax")
                {
                    _Tax = Convert.ToDecimal(e.Value);
                    _Scot = ((_Quantity * _UnitPrice) * _Tax) / 100;
                    _TotalTax = (_Quantity * _UnitPrice) + _Scot;
                    view.SetFocusedRowCellValue(col_Details_Scot, _Scot);
                    view.SetFocusedRowCellValue(col_Details_TotalTax, _TotalTax);
                    view.SetFocusedRowCellValue(col_Details_SalesPrice, _TotalTax / _Quantity);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_UnitOfMeasure))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_UnitOfMeasure, "Nhập đơn vị tính.");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_Quantity))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_Quantity, "Nhập số lượng.");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_UnitPrice))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_UnitPrice, "Nhập đơn giá.");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_SalesPrice))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_SalesPrice, "Nhập giá bán.");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_Amount))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_Amount, "Nhập tổng tiền.");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_DateEnd))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_DateEnd, "Nhập hạng dùng.");
                }
                if (e.Valid == true)
                {
                    string warehousingCode = string.Empty, repositoryCode = string.Empty, itemCode = string.Empty, unitOfMeasureCode = string.Empty, shipment = string.Empty;
                    decimal rowID = 0, quantity = 0, unitPrice = 0, bhytPrice = 0, amount = 0, scot = 0, totalTax = 0, salesPrice = 0;
                    DateTime dateEnd;
                    int tax = 0;
                    warehousingCode = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_search_WarehousingCode).ToString();
                    repositoryCode = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_Search_RepositoryCode).ToString();
                    itemCode = this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_ItemCode).ToString();
                    unitOfMeasureCode = this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_UnitOfMeasure).ToString();
                    shipment = this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_Shipment).ToString();
                    rowID = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_RowID).ToString());
                    quantity = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_Quantity).ToString());
                    unitPrice = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_UnitPrice).ToString());
                    bhytPrice = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_BHYTPrice).ToString());
                    amount = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_Amount).ToString());
                    scot = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_Scot).ToString());
                    totalTax = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_TotalTax).ToString());
                    salesPrice = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_SalesPrice).ToString());
                    dateEnd = Convert.ToDateTime(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_DateEnd).ToString());
                    tax = Convert.ToInt32(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Details_Tax).ToString());
                    Int32 result = InventoryBLL.Upd_WarehousingInven(warehousingCode, rowID, repositoryCode, itemCode, unitOfMeasureCode, quantity, unitPrice, bhytPrice, amount, tax, scot, totalTax, salesPrice, shipment, dateEnd);
                    if (result <= 0)
                    {
                        string message = string.Empty;
                        if (result == -1)
                            message = "Thuốc đã xuất cho bệnh nhân trong kho tủ trực.";
                        else if (result == -1)
                            message = "Thuốc đã duyệt cấp toa cho bệnh nhân.";
                        else if (result == -3)
                            message = "Thuốc xuất bán.";
                        else if (result == -4)
                            message = "Thuốc đã xuất chuyển kho.";
                        else if (result == -5)
                            message = "Mã thuốc không tồn tại trong table theo dõi.";
                        else if (result == -6)
                            message = "Mã phiếu nhập không tồn tại.";
                        XtraMessageBox.Show(message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        this.dtDetail = Warehousing_BLL.DT_ListDetail(warehousingCode);
                        this.gridControl_Detail.DataSource = this.dtDetail;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string warehousingCode = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_search_WarehousingCode).ToString();
                this.dtDetail = Warehousing_BLL.DT_ListDetail(warehousingCode);
                this.gridControl_Detail.DataSource = this.dtDetail;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}