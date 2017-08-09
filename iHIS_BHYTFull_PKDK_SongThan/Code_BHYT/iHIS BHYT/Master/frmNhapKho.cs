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
using Ps.Clinic.ViewPopup;
using DevExpress.XtraGrid.Views.Grid;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmNhapKho : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userID = string.Empty;
        private DataTable dtDetail = new DataTable();
        private string sWareCode = string.Empty;
        private Int32 iStatus = 0;
        private bool bKhaibaoton = false;
        private string shiftWork = string.Empty;
        private List<RepositoryCatalog_Inf> lstKho = new List<RepositoryCatalog_Inf>();
        private bool isSalesPrice = false;
        public frmNhapKho(string _User, string _shiftWork)
        {
            InitializeComponent();
            this.userID = _User;
            this.shiftWork = _shiftWork;
            this.lkupNhacc.Properties.DataSource = VendorBLL.DTVendorList(string.Empty);
            this.lkupNhacc.Properties.DisplayMember = "VendorName";
            this.lkupNhacc.Properties.ValueMember = "VendorCode";
            this.lkupNguon.Properties.DataSource = MedicalSuppliesBLL.ListSupplies();
            this.lkupNguon.Properties.DisplayMember = "SuppliesName";
            this.lkupNguon.Properties.ValueMember = "RowID";
            this.lkupLydo.Properties.DataSource = MedicalReasonBLL.ListReason();
            this.lkupLydo.Properties.DisplayMember = "ReasonName";
            this.lkupLydo.Properties.ValueMember = "RowID";
            SystemParameterInf objPara = SystemParameterBLL.ObjParameter(203);
            if (objPara.Values == 1)
                this.bKhaibaoton = true;
            else
                this.bKhaibaoton = false;
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                this.ClearText();
                this.EnableText(false);
                this.EnableButton(true);
                //this.LoadDataItem();
                this.ref_UoM.DataSource = UnitOfMeasureBLL.DTUnit(string.Empty, "I");
                this.ref_UoM.DisplayMember = "UnitOfMeasureName";
                this.ref_UoM.ValueMember = "UnitOfMeasureCode";
                this.lstKho = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.userID);
                this.lkupKho.Properties.DataSource = this.lstKho;
                this.lkupKho.Properties.DisplayMember = "RepositoryName";
                this.lkupKho.Properties.ValueMember = "RepositoryCode";
                this.LoadHousingDetail();
                this.dtNgaynhap.EditValue = this.dtNgaykk.EditValue = this.dtNgayhd.EditValue = Utils.DateServer().ToString("dd/MM/yyyy");
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(205);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.isSalesPrice = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadDataItem()
        {
            this.repSearch_Item.DataSource = ItemsBLL.ListItemsRef(0, this.lkupKho.EditValue == null ? string.Empty : this.lkupKho.EditValue.ToString());
            this.repSearch_Item.DisplayMember = "ItemName";
            this.repSearch_Item.ValueMember = "ItemCode";
        }

        private void LoadHousingDetail()
        {

            this.dtDetail = Warehousing_BLL.DT_ListDetail(this.sWareCode);
            this.gridControl_Detail.DataSource = this.dtDetail;
            this.gridView_Detail.OptionsBehavior.ReadOnly = true;
            this.gridView_Detail.OptionsBehavior.Editable = false;
            this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        } 

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtNgaynhap.EditValue == null || this.dtNgaynhap.EditValue.ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Ngày nhập không được để trống!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgaynhap.Focus();
                    return;
                }
                //if (string.IsNullOrEmpty(this.txtFormNo.Text.ToString()))
                //{
                //    XtraMessageBox.Show("Chưa nhập mẫu số hóa đơn!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtFormNo.Focus();
                //    return;
                //}
                if (string.IsNullOrEmpty(this.txtSohd.Text.ToString()))
                {
                    XtraMessageBox.Show("Chưa nhập số hóa đơn!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtSohd.Focus();
                    return;
                }
                //if (string.IsNullOrEmpty(this.txtSeri.Text.ToString()))
                //{
                //    XtraMessageBox.Show("Chưa nhập ký hiệu hóa đơn!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtSeri.Focus();
                //    return;
                //}
                if (this.lkupKho.EditValue == null)
                {
                    XtraMessageBox.Show("Chưa chọn kho!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                    return;
                }
                if (this.lkupNguon.EditValue == null)
                {
                    XtraMessageBox.Show("Chưa chọn nguồn nhập!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupNguon.Focus();
                    return;
                }
                if (this.lkupNhacc.EditValue == null || this.lkupNhacc.EditValue.ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Chưa chọn nhà cung cấp!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupNhacc.Focus();
                    return;
                }
                if (this.lkupLydo.EditValue == null || this.lkupLydo.EditValue.ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Chưa chọn lý do!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lkupLydo.Focus();
                    return;
                }
                if (dtDetail == null || dtDetail.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("Chưa nhập chi tiết hóa đơn mua hàng!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Detail.Focus();
                    return;
                }
                else
                {
                    Warehousing_INF Whousing = new Warehousing_INF();
                    Whousing.WarehousingCode = sWareCode;
                    Whousing.ImportDate = Utils.StringToDate(dtNgaynhap.EditValue.ToString());
                    Whousing.Seri = txtSeri.Text;
                    Whousing.InvoiceNnumber = txtSohd.Text;
                    if (dtNgayhd.Text.Trim() != "")
                        Whousing.InvoiceDate = dtNgayhd.Text.TrimEnd();
                    Whousing.ReportNumber = txtbbkso.Text;
                    if (dtNgaykk.Text.Trim() != "")
                        Whousing.ReportDate = dtNgaykk.Text.TrimEnd();
                    Whousing.VendorCode = lkupNhacc.EditValue.ToString();
                    Whousing.Discount = Convert.ToInt32(txtChietkhau.EditValue);
                    Whousing.Shipper = txtNguoigiao.Text;
                    Whousing.Supplies = Convert.ToInt32(lkupNguon.EditValue);
                    Whousing.RepositoryCode = lkupKho.EditValue.ToString();
                    Whousing.Reason = Convert.ToInt32(lkupLydo.EditValue);
                    Whousing.Note = txtGhichu.Text;
                    Whousing.EmployeeCode = this.userID;
                    Whousing.Status = iStatus;
                    Whousing.InventoryStaff = txtNhanvienkiem.Text.Trim();
                    Whousing.ShiftWork = this.shiftWork;
                    Whousing.FormNo = this.txtFormNo.Text.Trim();
                    Whousing.VAT = Convert.ToInt32(this.spinVATTotal.EditValue);
                    Whousing.Depreciated = Convert.ToDecimal(this.spinKhauHao.EditValue.ToString());
                    if (Warehousing_BLL.Ins(Whousing, ref sWareCode) == 1)
                    {
                        //InventoryBLL.Del_GumshoeForHousingCode(sWareCode);
                        decimal dRefRowID = 0;
                        bool bResult = true;
                        foreach (DataRow r in dtDetail.Rows)
                        {
                            WarehousingDetail_INF mdetail = new WarehousingDetail_INF();
                            if (r["RowID"].ToString() != "" && r["RowID"] != null)
                                mdetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                            else
                                mdetail.RowID = 0;
                            mdetail.WarehousingCode = sWareCode;
                            mdetail.ItemCode = r["ItemCode"].ToString();
                            mdetail.Active = r["Active"].ToString();
                            mdetail.UnitOfMeasureCode = r["UnitOfMeasureCode"].ToString();
                            mdetail.Quantity = Convert.ToDecimal(r["Quantity"].ToString());
                            mdetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            mdetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                            mdetail.Tax = Convert.ToInt32(r["Tax"].ToString());
                            mdetail.Scot = Convert.ToDecimal(r["Scot"].ToString());
                            mdetail.TotalTax = Convert.ToDecimal(r["TotalTax"].ToString());
                            mdetail.SalesPrice = decimal.Parse(r["SalesPrice"].ToString());
                            mdetail.BHYTPrice = decimal.Parse(r["BHYTPrice"].ToString());
                            mdetail.Shipment = r["Shipment"].ToString();
                            mdetail.DateEnd = Convert.ToDateTime(r["DateEnd"].ToString());
                            //mdetail.ProducerCode = r["ProducerCode"].ToString();
                            //mdetail.Country = r["Country"].ToString();
                            mdetail.UnitPriceNoVAT = Convert.ToDecimal(r["UnitPriceNoVAT"].ToString());
                            mdetail.PerSalesPrice = Convert.ToInt32(r["PerSalesPrice"].ToString());
                            mdetail.QtyOfMeasure = Convert.ToDecimal(r["QtyOfMeasure"].ToString());
                            mdetail.QuantityInput = Convert.ToDecimal(r["QuantityInput"].ToString());
                            if (Warehousing_BLL.InsDetail(mdetail, ref dRefRowID) <= 0)
                            {
                                bResult = false;
                                break;
                            }
                        }
                        if (bResult)
                        {
                            XtraMessageBox.Show(" Lưu thành công đơn nhập hàng!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.EnableButton(true);
                            this.EnableText(false);
                            this.GetWarehousingInfo();
                            return;
                        }
                        else
                        {
                            Warehousing_BLL.Del(sWareCode);
                            XtraMessageBox.Show(" Lưu không thành công đơn nhập hàng! Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Warehousing_BLL.Del(sWareCode);
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            this.sWareCode = string.Empty;
            this.txtSophieu.Text = string.Empty;
            this.iStatus = 0;
            this.dtDetail.Clear();
            this.ClearText();
            this.EnableText(true);
            this.EnableButton(false);
            this.gridView_Detail.OptionsBehavior.ReadOnly = false;
            this.gridView_Detail.OptionsBehavior.Editable = true;
            this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            //gridControl_Detail.Enabled = true;
            this.dtNgayhd.Focus();
            this.lkupKho.EditValue = null;
        }

        private void ClearText()
        {
            this.dtNgaynhap.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtSeri.Text = string.Empty;
            this.txtSohd.Text = string.Empty;
            this.dtNgayhd.EditValue = null;
            this.txtbbkso.Text = string.Empty;
            this.dtNgaykk.EditValue = null;
            this.lkupKho.EditValue = null;
            this.txtChietkhau.EditValue = 0;
            this.txtNguoigiao.Text = string.Empty;
            this.lkupNguon.EditValue = null;
            this.lkupNhacc.EditValue = null;
            this.lkupLydo.EditValue = string.Empty;
            this.txtGhichu.Text = string.Empty;
            this.txtNhanvienkiem.Text = string.Empty;
            this.txtFormNo.Text = string.Empty;
            this.spinVATTotal.EditValue = 0;
            this.spinKhauHao.EditValue = 0;
        }

        private void EnableText(bool b)
        {
            this.txtSophieu.Enabled = b;
            this.dtNgaynhap.Enabled = b;
            this.txtSeri.Enabled = b;
            this.txtSohd.Enabled = b;
            this.dtNgayhd.Enabled = b;
            this.txtbbkso.Enabled = b;
            this.dtNgaykk.Enabled = b;
            this.lkupKho.Enabled = b;
            this.txtChietkhau.Enabled = b;
            this.txtNguoigiao.Enabled = b;
            this.lkupNguon.Enabled = b;
            this.lkupNhacc.Enabled = b;
            this.lkupLydo.Enabled = b;
            this.txtGhichu.Enabled = b;
            this.txtNhanvienkiem.Enabled = b;
            this.txtFormNo.Enabled = b;
            this.spinVATTotal.Enabled = b;
            this.spinKhauHao.Enabled = b;
        }

        private void EnableButton(bool b)
        {
            butImport.Enabled = b;
            butSave.Enabled = !b;
            butEdit.Enabled = false;
            butDelete.Enabled = !b;
            butIgnore.Enabled = !b;
            butUpdateInventory.Enabled = false;
            butPrintPrescription.Enabled = true;
        }

        private void butIgnore_Click(object sender, EventArgs e)
        {
            this.ClearText();
            this.EnableText(false);
            this.EnableButton(true);
            this.gridView_Detail.OptionsBehavior.ReadOnly = true;
            this.gridView_Detail.OptionsBehavior.Editable = false;
            this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void gridView_Detail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
               {
                GridView view = sender as GridView;
                decimal _unitPrice = 0, _salesPrice = 0, _amount = 0;
                decimal _quantity = 0, _unitPriceInput = 0;
                decimal _perSalesPrice = 0, _tax = 0, _quantityInput = 0, qtyOfMeasure = 0;
               
                if (view.GetFocusedRowCellValue(col_Details_QtyOfMeasure).ToString() != string.Empty)
                    qtyOfMeasure = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_QtyOfMeasure));
                if (view.GetFocusedRowCellValue(col_Details_UnitPrice).ToString() != string.Empty)
                    _unitPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_UnitPrice));
                if (view.GetFocusedRowCellValue(col_Details_QuantityInput).ToString() != string.Empty)
                    _quantityInput = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_QuantityInput)); //Sl Nhập
                if (view.GetFocusedRowCellValue(col_Details_Quantity).ToString() != string.Empty)
                    _quantity = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_Quantity)); //Sl Quy đổi
                if (view.GetFocusedRowCellValue(col_Details_Tax).ToString() != string.Empty)
                    _tax = Convert.ToInt32(view.GetFocusedRowCellValue(col_Details_Tax));
                if (view.GetFocusedRowCellValue(col_Details_SalesPrice).ToString() != string.Empty)
                    _salesPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_SalesPrice));
                if (view.GetFocusedRowCellValue(col_Details_UnitPriceNoVAT).ToString() != string.Empty)
                    _unitPriceInput = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_UnitPriceNoVAT));
                if (view.GetFocusedRowCellValue(col_Details_PerSalesPrice).ToString() != string.Empty)
                    _perSalesPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_PerSalesPrice));
                if (view.GetFocusedRowCellValue(col_Details_Amount).ToString() != string.Empty)
                    _amount = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_Amount));

                decimal _scot = 0;
                decimal _totalTax = 0;
                if (view.FocusedColumn.FieldName == "UnitPriceNoVAT")
                {
                    _unitPriceInput = Convert.ToDecimal(e.Value);   // Gia nhap theo sl đóng gói
                    _perSalesPrice = this.GetPercentSalesPrice(_unitPriceInput); // tính giá bán theo khung gia nhập
                    _scot = (_unitPriceInput * _tax) / 100; // tien thue
                    _totalTax = _quantityInput * _scot;    // tong tien thue
                    _unitPrice = ((_unitPriceInput * _quantityInput) / _quantity) + _scot; // Gia mua
                    view.SetFocusedRowCellValue(col_Details_Scot, _totalTax);
                    view.SetFocusedRowCellValue(col_Details_UnitPrice, _unitPrice);   // gia mua
                    view.SetFocusedRowCellValue(col_Details_BHYTPrice, _unitPrice);   // gia BHYT
                    decimal salesPriceTemp = (_perSalesPrice * _unitPrice) / 100;
                    //view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + salesPriceTemp);   // gia ban
                    view.SetFocusedRowCellValue(col_Details_SalesPrice, _salesPrice);
                    view.SetFocusedRowCellValue(col_Details_Amount, (_unitPriceInput * _quantityInput));  //  tong tien truoc thue
                    view.SetFocusedRowCellValue(col_Details_TotalTax, (_unitPriceInput + _scot) * _quantityInput);  //tong tien sau thue
                    view.SetFocusedRowCellValue(col_Details_PerSalesPrice, _perSalesPrice);  //Khung Giá Tuấn Viết thêm cho Bạch Đằng
                }
                if (view.FocusedColumn.FieldName == "QuantityInput")
                {
                    _perSalesPrice = this.GetPercentSalesPrice(_unitPriceInput); // tính giá bán theo khung gia nhập
                    _quantityInput = Convert.ToDecimal(e.Value); //sl
                    _quantity = _quantityInput * qtyOfMeasure; // donvitinh
                    _scot = (_unitPriceInput * _tax) / 100; // tien thue
                    _totalTax = _quantity * _scot;    // tong tien thue
                    view.SetFocusedRowCellValue(col_Details_Quantity, _quantity);
                    view.SetFocusedRowCellValue(col_Details_Scot, _totalTax);
                    _unitPrice = ((_unitPriceInput * _quantity) / _quantity) + _scot;
                    view.SetFocusedRowCellValue(col_Details_UnitPrice, _unitPrice);   // gia mua
                    view.SetFocusedRowCellValue(col_Details_BHYTPrice, _unitPrice);   // gia BHYT
                    //decimal salesPriceTemp = (_perSalesPrice * _unitPrice) / 100;
                    //view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + salesPriceTemp);   // gia ban
                    view.SetFocusedRowCellValue(col_Details_SalesPrice, _salesPrice);   // gia ban
                    view.SetFocusedRowCellValue(col_Details_Amount, (_unitPriceInput * _quantity));  //  tong tien truoc thue
                    view.SetFocusedRowCellValue(col_Details_TotalTax, (_unitPriceInput + _scot) * _quantity);  //tong tien sau thue
                    view.SetFocusedRowCellValue(col_Details_PerSalesPrice, _perSalesPrice);  //Khung Giá Tuấn Viết thêm cho Bạch Đằng
                }
                if (view.FocusedColumn.FieldName == "Quantity")
                {
                    _perSalesPrice = this.GetPercentSalesPrice(_unitPriceInput); // tính giá bán theo khung gia nhập
                    decimal quantityCurrent = Convert.ToDecimal(e.Value);
                    _scot = (_unitPrice * _tax) / 100;      // tien thue
                    _totalTax = quantityCurrent * _scot;    // tong tien thue
                    view.SetFocusedRowCellValue(col_Details_Scot, _totalTax);
                    view.SetFocusedRowCellValue(col_Details_UnitPrice, _unitPrice);     // gia mua
                    view.SetFocusedRowCellValue(col_Details_BHYTPrice, _unitPrice);     // gia BHYT
                    decimal salesPriceTemp = (_perSalesPrice * (_unitPrice + _scot)) / 100;
                    view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + _scot + salesPriceTemp);   // gia ban
                    view.SetFocusedRowCellValue(col_Details_Amount, (_unitPriceInput * quantityCurrent));  //  tong tien truoc thue
                    view.SetFocusedRowCellValue(col_Details_TotalTax, (_unitPrice + _scot) * quantityCurrent);  //tong tien sau thue

                    view.SetFocusedRowCellValue(col_Details_PerSalesPrice, _perSalesPrice);  //Khung Giá Tuấn Viết thêm cho Bạch Đằng
                }
                if (view.FocusedColumn.FieldName == "Tax")
                {
                    _perSalesPrice = this.GetPercentSalesPrice(_unitPriceInput); // tính giá bán theo khung gia nhập
                    _tax = Convert.ToDecimal(e.Value);
                    _scot = (_unitPriceInput * _tax) / 100; // tien thue
                    _totalTax = _quantityInput * _scot;    // tong tien thue
                    _unitPrice = ((_unitPriceInput * _quantityInput) / _quantity) + _scot;
                    view.SetFocusedRowCellValue(col_Details_Scot, _totalTax);
                    view.SetFocusedRowCellValue(col_Details_UnitPrice, _unitPrice);   // gia mua
                    view.SetFocusedRowCellValue(col_Details_BHYTPrice, _unitPrice);   // gia BHYT
                    //decimal salesPriceTemp = (_perSalesPrice * _unitPrice) / 100;
                    //view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + salesPriceTemp);   // gia ban
                    view.SetFocusedRowCellValue(col_Details_SalesPrice, _salesPrice);
                    view.SetFocusedRowCellValue(col_Details_Amount, (_unitPriceInput * _quantityInput));  //  tong tien truoc thue
                    view.SetFocusedRowCellValue(col_Details_TotalTax, (_unitPriceInput + _scot) * _quantityInput); //tong tien sau thue
                    view.SetFocusedRowCellValue(col_Details_PerSalesPrice, _perSalesPrice);  //Khung Giá Tuấn Viết thêm cho Bạch Đằng
                }
                //if (view.FocusedColumn.FieldName == "UnitPrice")
                //{
                //    _unitPrice = Convert.ToDecimal(e.Value);
                //    _scot = (_unitPrice * _tax) / 100; // tien thue
                //    _totalTax = _quantityInput * _scot;    // tong tien thue
                //    view.SetFocusedRowCellValue(col_Details_Scot, _totalTax);
                //    view.SetFocusedRowCellValue(col_Details_UnitPrice, _unitPrice);   // gia mua
                //    view.SetFocusedRowCellValue(col_Details_BHYTPrice, _unitPrice);   // gia BHYT
                //    decimal salesPriceTemp = (_perSalesPrice * (_unitPrice + _scot)) / 100;
                //    view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + _scot + salesPriceTemp);   // gia ban
                //    view.SetFocusedRowCellValue(col_Details_Amount, (_unitPriceInput * _quantityInput));  //  tong tien truoc thue
                //    view.SetFocusedRowCellValue(col_Details_TotalTax, (_unitPrice + _scot) * _quantityInput);  //tong tien sau thue
                //}

                //decimal _salesPriceTemp = (_perSalesPrice * _unitPrice) / 100;
                //view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + _salesPriceTemp);

                if (view.FocusedColumn.FieldName == "PerSalesPrice")
                {
                    _perSalesPrice = Convert.ToDecimal(e.Value);
                    decimal salesPriceTemp = (_perSalesPrice * _unitPrice) / 100;
                    view.SetFocusedRowCellValue(col_Details_SalesPrice, _unitPrice + salesPriceTemp);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private decimal GetPercentSalesPrice(decimal unitPriceInput)
        {
            decimal _perSalesPrice = 0;
            if (this.isSalesPrice)
            {
                if (unitPriceInput < 1001)
                {
                    _perSalesPrice = 100;
                }
                else if (unitPriceInput < 10001 && unitPriceInput > 1000)
                    _perSalesPrice = 30;
                else _perSalesPrice = 20;
            }
            return _perSalesPrice;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtfrom.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtfrom.Focus();
                    return;
                }
                if (this.dtto.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtto.Focus();
                    return;
                }
                this.gridControl_Search.DataSource = Warehousing_BLL.ListSearch(this.dtfrom.Text, this.dtto.Text, this.userID);
            }
            catch { }
        }

        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            if (gridView_Search.GetFocusedRow() != null)
            {
                this.xtabMain.SelectedTabPageIndex = 0;
                this.sWareCode = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_search_WarehousingCode).ToString();
                txtSophieu.Text = sWareCode;
                this.GetWarehousingInfo();
            }
        }

        private void GetWarehousingInfo()
        {
            try
            {
                List<Warehousing_INF> lstHousing = Warehousing_BLL.List(sWareCode);
                if (lstHousing != null && lstHousing.Count > 0)
                {
                    this.txtSophieu.Text = lstHousing[0].WarehousingCode;
                    this.dtNgaynhap.EditValue = lstHousing[0].ImportDate.ToString("dd/MM/yyyy");
                    this.txtSeri.Text = lstHousing[0].Seri;
                    this.txtSohd.Text = lstHousing[0].InvoiceNnumber;
                    this.dtNgayhd.EditValue = lstHousing[0].InvoiceDate;
                    this.txtbbkso.Text = lstHousing[0].ReportNumber;
                    this.dtNgaykk.EditValue = lstHousing[0].ReportDate;
                    this.lkupNhacc.EditValue = lstHousing[0].VendorCode;
                    this.txtChietkhau.EditValue = lstHousing[0].Discount;
                    this.txtNguoigiao.Text = lstHousing[0].Shipper;
                    lkupNguon.EditValue = lstHousing[0].Supplies;
                    lkupKho.EditValue = lstHousing[0].RepositoryCode;
                    lkupLydo.EditValue = lstHousing[0].Reason;
                    txtGhichu.Text = lstHousing[0].Note;
                    iStatus = lstHousing[0].Status;
                    txtNhanvienkiem.Text = lstHousing[0].InventoryStaff;
                    this.txtFormNo.Text = lstHousing[0].FormNo;
                    this.spinVATTotal.EditValue = lstHousing[0].VAT;
                    this.spinKhauHao.EditValue = lstHousing[0].Depreciated;
                }
                this.LoadHousingDetail();
                this.EnableText(false);
                this.butEdit.Enabled = true;
                if (this.iStatus == 0)
                    this.butUpdateInventory.Enabled = true;
                else
                    this.butUpdateInventory.Enabled = false;
                this.gridView_Detail.OptionsBehavior.ReadOnly = true;
                this.gridView_Detail.OptionsBehavior.Editable = false;
                this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            catch { return; }
        }

        private void xtabMain_Click(object sender, EventArgs e)
        {
            if (xtabMain.SelectedTabPageIndex == 1)
            {
                this.butSearch_Click(sender, e);
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (iStatus == 1)
                {
                    XtraMessageBox.Show(" Phiếu nhập đã cập nhật vào kho, không được phép sửa!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (iStatus == 2)
                {
                    XtraMessageBox.Show(" Phiếu đã xuất chuyển kho, không được phép sửa!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    EnableText(true);
                    EnableButton(false);
                    //gridControl_Detail.Enabled = true;
                    gridView_Detail.OptionsBehavior.ReadOnly = false;
                    gridView_Detail.OptionsBehavior.Editable = true;
                    gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (iStatus == 1)
                {
                    XtraMessageBox.Show(" Phiếu nhập đã cập nhật vào kho, không được phép hủy!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (iStatus == 2)
                {
                    XtraMessageBox.Show(" Phiếu xuất chuyển kho, không được phép hủy!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (XtraMessageBox.Show(" Bạn chắc chắn muốn hủy đơn hàng này!", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (Warehousing_BLL.Del(sWareCode) >= 1)
                        {
                            XtraMessageBox.Show(" Xóa thành công đơn hàng!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ClearText();
                            EnableText(false);
                            EnableButton(true);
                        }
                    }
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lkupLydo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.bKhaibaoton)
                {
                    if (lkupLydo.EditValue.ToString() == "4")
                    {
                        lstKho = RepositoryCatalog_BLL.ListRepositoryForImport(0, string.Empty, this.userID);
                        lkupKho.Properties.DataSource = lstKho;
                        lkupKho.Properties.DisplayMember = "RepositoryName";
                        lkupKho.Properties.ValueMember = "RepositoryCode";
                    }
                    else
                    {
                        lstKho = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.userID);
                        lkupKho.Properties.DataSource = lstKho;
                        lkupKho.Properties.DisplayMember = "RepositoryName";
                        lkupKho.Properties.ValueMember = "RepositoryCode";
                    }
                }
                else
                {
                    lstKho = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.userID);
                    lkupKho.Properties.DataSource = lstKho;
                    lkupKho.Properties.DisplayMember = "RepositoryName";
                    lkupKho.Properties.ValueMember = "RepositoryCode";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_ItemCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                 
                    view.SetColumnError(col_Details_ItemCode, " Chưa chọn thuốc !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_DateEnd)).ToString() == string.Empty)
                {
                    e.Valid = false; 
                    view.SetColumnError(col_Details_DateEnd, " Chưa chọn hạn dùng !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_Quantity)).ToString() == string.Empty)
                {
                    e.Valid = false; 
                    view.SetColumnError(col_Details_Quantity, " Chưa nhập số lượng !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_UnitPrice)).ToString() == string.Empty)
                {
                    e.Valid = false; 
                    view.SetColumnError(col_Details_UnitPrice, " Hãy nhập giá thuốc !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_Amount)).ToString() == string.Empty)
                {
                    e.Valid = false; 
                    view.SetColumnError(col_Details_Amount, " Thành tiền không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_Tax)).ToString() == string.Empty)
                {
                    e.Valid = false; 
                    view.SetColumnError(col_Details_Tax, " Nhập thuế !");
                }
                
            }
            catch { return; }
        }

        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET.";
            e.ErrorText = " Vui lòng nhập đầy đủ thông tin phiếu nhập kho !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void butUpdateInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.iStatus == 1)
                {
                    XtraMessageBox.Show(" Phiếu đã cập nhật tồn kho!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.EnableButton(false);
                    return;
                }
                else
                {
                    if (XtraMessageBox.Show(" Bạn có muốn chuyển số lượng thuốc từ phiếu nhập vào kho? ", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        bool bResult = true;
                        foreach (DataRow row in this.dtDetail.Rows)
                        {
                            #region Code new, update table InventoryGeneral
                            InventoryGumshoeInf modelInven = new InventoryGumshoeInf();
                            modelInven.RowID = 0;
                            modelInven.DateImport = Utils.StringToDate(this.dtNgaynhap.EditValue.ToString());
                            modelInven.MM = Utils.StringToDate(this.dtNgaynhap.EditValue.ToString()).Month;
                            modelInven.YYYY = Utils.StringToDate(this.dtNgaynhap.EditValue.ToString()).Year;
                            modelInven.ItemCode = row["ItemCode"].ToString();
                            modelInven.AmountImport = Convert.ToDecimal(row["Quantity"].ToString());
                            modelInven.WarehousingCode = this.sWareCode;
                            modelInven.DateEnd = Convert.ToDateTime(row["DateEnd"].ToString());
                            modelInven.SalesPrice = Convert.ToDecimal(row["SalesPrice"].ToString());
                            modelInven.UnitPrice = Convert.ToDecimal(row["UnitPrice"].ToString());
                            modelInven.BHYTPrice = Convert.ToDecimal(row["BHYTPrice"].ToString());
                            modelInven.Shipment = row["Shipment"].ToString();
                            modelInven.RepositoryCode = lkupKho.EditValue.ToString();
                            modelInven.IDWarehousingDetail = Convert.ToDecimal(row["RowID"].ToString());
                            if (InventoryBLL.Ins_InventoryGumshoe(modelInven) < 1)
                            {
                                bResult = false;
                                break;
                            }
                            #endregion

                            #region Code old
                            //InventoryGeneralInf modelGen = new InventoryGeneralInf
                            //{
                            //    ItemCode = row["ItemCode"].ToString(),
                            //    //MM = Utils.StringToDate(dtNgaynhap.EditValue.ToString()).Month,
                            //    //YYYY = Utils.StringToDate(dtNgaynhap.EditValue.ToString()).Year,
                            //    RepositoryCode = this.lkupKho.EditValue.ToString(),
                            //    AmountImpot = Convert.ToDecimal(row["Quantity"].ToString()),
                            //};
                            //InventoryBLL.Upd_InventoryWareHousing(modelGen, this.lkupKho.EditValue.ToString(), this.txtSophieu.Text.Trim());
                            #endregion
                        }
                        if (bResult)
                        {
                            Warehousing_BLL.Upd_StatusWarehousing(1, this.txtSophieu.Text.Trim());
                            XtraMessageBox.Show(" Số lượng thuốc của phiếu nhập đã cập nhật vào tồn kho thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            InventoryBLL.Del_GumshoeForHousingCode(this.lkupKho.EditValue.ToString(), sWareCode);
                            XtraMessageBox.Show(" Cập nhật số lượng vào kho không thành công! Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        this.EnableButton(true);
                    }
                    else
                        this.EnableButton(false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtSohd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtSeri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtNguoigiao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtChietkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void lkupNhacc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void lkupNguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void lkupKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void lkupLydo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtGhichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtbbkso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void dtNgaykk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void txtNhanvienkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");
        }

        private void gridView_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (iStatus == 1)
                    {
                        XtraMessageBox.Show(" Phiếu nhập đã cập nhật vào kho, không được phép xóa hay sửa!", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa thuốc này khỏi phiếu nhập?", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            string sItemCode = gridView_Detail.GetRowCellValue(gridView_Detail.FocusedRowHandle, "ItemCode").ToString();
                            string sHousingCode = gridView_Detail.GetRowCellValue(gridView_Detail.FocusedRowHandle, "WarehousingCode").ToString();
                            int iResult = Warehousing_BLL.Del(sHousingCode, sItemCode);
                            this.gridView_Detail.DeleteSelectedRows();
                            this.dtDetail.AcceptChanges();
                        }
                    }
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        private void butPrintPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                List<ViewWarehousingInf> listWare = Warehousing_BLL.ListViewWarehousing(this.sWareCode);
                if (listWare != null && listWare.Count > 0)
                {
                    Reports.rptNhapKho rpt = new Reports.rptNhapKho();
                    rpt.DataSource = listWare;
                    rpt.Parameters["prAmountTotal"].Value = listWare[0].AmountTotal - listWare[0].Depreciated;
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("Số liệu chưa phát sinh! Vui lòng xem lại thông tin.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void repSearch_Item_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_UnitOfMeasure, searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode"));
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_Active, searchEdit.Properties.View.GetFocusedRowCellValue("Active"));
                //this.gridView_Detail.SetFocusedRowCellValue(col_Details_UnitPrice, searchEdit.Properties.View.GetFocusedRowCellValue("UnitPrice"));
                //this.gridView_Detail.SetFocusedRowCellValue(col_Details_BHYTPrice, searchEdit.Properties.View.GetFocusedRowCellValue("BHYTPrice"));
                //this.gridView_Detail.SetFocusedRowCellValue(col_Details_SalesPrice, searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice"));
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_UnitPrice, searchEdit.Properties.View.GetFocusedRowCellValue("UnitPrice"));
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_BHYTPrice, 0);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_SalesPrice, searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice"));
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_Packed, searchEdit.Properties.View.GetFocusedRowCellValue("Packed"));
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_Tax, this.spinVATTotal.EditValue);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_Scot, 0);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_Amount, 0);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_TotalTax, 0);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_UnitPriceNoVAT, searchEdit.Properties.View.GetFocusedRowCellValue("UnitPrice"));
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_PerSalesPrice, 0);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_DateEnd, DateTime.Now.Date);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_QuantityInput, 0);
                this.gridView_Detail.SetFocusedRowCellValue(col_Details_QtyOfMeasure, searchEdit.Properties.View.GetFocusedRowCellValue("QtyOfMeasure"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupKho_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadDataItem();
        }

        
    }
}