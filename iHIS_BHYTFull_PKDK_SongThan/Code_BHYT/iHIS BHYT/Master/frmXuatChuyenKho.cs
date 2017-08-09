using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Data.Linq;
using System.Linq;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmXuatChuyenKho : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUser = string.Empty;
        private string sExpCode = string.Empty;
        private DataTable dtDetail = new DataTable();
        private string sWareCode = string.Empty;

        private List<RepositoryCatalog_Inf> lstKhoX = new List<RepositoryCatalog_Inf>();
        private List<RepositoryCatalog_Inf> lstKhoN = new List<RepositoryCatalog_Inf>();
        public frmXuatChuyenKho(string _User)
        {
            InitializeComponent();
            this.sUser = _User;
        }

        private void frmXuatChuyenKho_Load(object sender, EventArgs e)
        {
            try
            {
                this.ClearText();
                this.EnableText(false);
                this.EnableButton(true);
                this.lstKhoX = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.sUser);
                this.lkupKhoXuat.Properties.DataSource = this.lstKhoX;
                this.lkupKhoXuat.Properties.DisplayMember = "RepositoryName";
                this.lkupKhoXuat.Properties.ValueMember = "RepositoryCode";

                this.lstKhoN = RepositoryCatalog_BLL.ListRepositoryForExport(0, "1", this.sUser);
                this.lkupKhoNhan.Properties.DataSource = this.lstKhoN;
                this.lkupKhoNhan.Properties.DisplayMember = "RepositoryName";
                this.lkupKhoNhan.Properties.ValueMember = "RepositoryCode";
                this.gridView_Detail.OptionsBehavior.ReadOnly = true;
                this.gridView_Detail.OptionsBehavior.Editable = false;

                this.searchLkupEmployee.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition(string.Empty);
                this.searchLkupEmployee.Properties.DisplayMember = "EmployeeName";
                this.searchLkupEmployee.Properties.ValueMember = "EmployeeName";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadRepositoryDetail()
        { 
            try
            {
                if (this.chkNhaThuoc.Checked)
                {
                    this.lstKhoN = RepositoryCatalog_BLL.ListRepositoryForExport(0, "1", this.sUser).Where(p => p.RepositoryCode != (this.lkupKhoXuat.EditValue == null ? string.Empty : this.lkupKhoXuat.EditValue.ToString())).ToList();
                    this.lkupKhoNhan.Properties.DataSource = this.lstKhoN;
                    this.lkupKhoNhan.Properties.DisplayMember = "RepositoryName";
                    this.lkupKhoNhan.Properties.ValueMember = "RepositoryCode";
                }
                else
                {
                    this.lstKhoN = RepositoryCatalog_BLL.ListRepositoryForExport(0, "1", this.sUser).Where(p => p.RepositoryCode != (this.lkupKhoXuat.EditValue == null ? string.Empty : this.lkupKhoXuat.EditValue.ToString())).ToList();
                    this.lkupKhoNhan.Properties.DataSource = this.lstKhoN;
                    this.lkupKhoNhan.Properties.DisplayMember = "RepositoryName";
                    this.lkupKhoNhan.Properties.ValueMember = "RepositoryCode";
                }
                this.dtDetail = Warehousing_BLL.DT_ListDetailExport(this.lkupKhoXuat.EditValue == null ? string.Empty : this.lkupKhoXuat.EditValue.ToString(), sExpCode);
                this.gridControl_Detail.DataSource = this.dtDetail;
                if (this.dtDetail.Rows.Count > 0)
                {
                    this.gridView_Detail.OptionsBehavior.ReadOnly = false;
                    this.gridView_Detail.OptionsBehavior.Editable = true;
                    this.chkAll.Properties.ReadOnly = false;
                    this.chkCoppy.Properties.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try 
            {
                DataTable dtTemp = new DataTable();
                dtTemp = dtDetail.Select("Chon=1","Chon asc").CopyToDataTable();
                bool bCheckNumber = true;
                bool bCheckQuantity = true;
                string sItemError = string.Empty, sErrorRealQuantity = string.Empty;
                if (this.dtNgayXuat.EditValue == null)
                {
                    XtraMessageBox.Show(" Ngày xuất không được để trống!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtNgayXuat.Focus();
                    return;
                }
                if (this.lkupKhoXuat.EditValue == null)
                {
                    XtraMessageBox.Show(" Chưa chọn kho xuất!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKhoXuat.Focus();
                    return;
                }
                if (this.lkupKhoNhan.EditValue == null)
                {
                    XtraMessageBox.Show(" Chưa chọn kho nhận!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKhoNhan.Focus();
                    return;
                }
                if (dtTemp == null || dtTemp.Rows.Count <= 0)
                {
                    XtraMessageBox.Show(" Chi tiết thuốc chuyển kho không có!, vui lòng xem lại!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        if (Convert.ToDecimal(r["AmountExist"].ToString()) < Convert.ToDecimal(r["RealQuantity"].ToString()))
                        {
                            sItemError += r["ItemName"].ToString() + ";";
                            bCheckNumber = false;
                        }
                        if (Convert.ToDecimal(r["RealQuantity"].ToString()) <= 0)
                        {
                            sErrorRealQuantity += r["ItemName"].ToString() + ";";
                            bCheckQuantity = false;
                        }
                    }
                    if (!bCheckQuantity)
                    {
                        XtraMessageBox.Show(" Những thuốc sau chưa nhập số lượng xuất: " + sErrorRealQuantity + " Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!bCheckNumber)
                    {
                        XtraMessageBox.Show(" Những thuốc sau không đủ tồn: " + sItemError + " Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (ExportWarehousingBLL.Del(sExpCode) < 0)
                        {
                            XtraMessageBox.Show(" Phiếu xuất kho có thuốc đã xuất bán, Không được phép xóa hoặc sửa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            ExportWarehousingInf ExpInf = new ExportWarehousingInf();
                            ExpInf.ExpWarehousingCode = sExpCode;
                            ExpInf.ExportDate = Utils.StringToDate(this.dtNgayXuat.Text);
                            ExpInf.ExpRepositoryCode = this.lkupKhoXuat.EditValue.ToString();
                            ExpInf.ImpRepositoryCode = this.lkupKhoNhan.EditValue.ToString();
                            ExpInf.Note = this.txtGhichu.Text;
                            ExpInf.EmployeeCode = sUser;
                            ExpInf.Type = 1;
                            ExpInf.EmployeeNameReceive = this.searchLkupEmployee.Text;
                            if (ExportWarehousingBLL.Ins(ExpInf, ref sExpCode) >= 1)
                            {
                                Int32 iCount = 0;
                                foreach (DataRow r in dtTemp.Rows)
                                {
                                    ExportWarehousingDetailInf mdelExp = new ExportWarehousingDetailInf();
                                    mdelExp.RowIDGumshoe = Convert.ToDecimal(r["RowID"].ToString());
                                    mdelExp.RepositoryReceiveCode = lkupKhoNhan.EditValue.ToString();
                                    mdelExp.RepositoryExportCode = lkupKhoXuat.EditValue.ToString();
                                    mdelExp.AmountRealExport = Convert.ToDecimal(r["RealQuantity"].ToString());
                                    mdelExp.ExpWarehousingCode = sExpCode;
                                    if (ExportWarehousingBLL.InsDetail(mdelExp) < 1)
                                    {
                                        ExportWarehousingBLL.Del(sExpCode);
                                        XtraMessageBox.Show(" Lỗi trong quá trình chuyển kho! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                    else
                                        iCount++;

                                    InventoryGeneralInf modelGen = new InventoryGeneralInf
                                    {
                                        ItemCode = r["ItemCode"].ToString(),
                                        RepositoryCode = lkupKhoNhan.EditValue.ToString(),
                                        AmountImpot = Convert.ToDecimal(r["RealQuantity"].ToString()),
                                    };
                                    InventoryBLL.Ins_InventoryGeneral(modelGen, lkupKhoXuat.EditValue.ToString(), sWareCode);
                                }
                                if (iCount >= dtTemp.Rows.Count)
                                {
                                    XtraMessageBox.Show(" Chuyển kho thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EnableButton(true);
                                    EnableText(false);
                                    gridView_Detail.OptionsBehavior.ReadOnly = true;
                                    gridView_Detail.OptionsBehavior.Editable = false;
                                    LoadRepositoryDetail();
                                    return;
                                }
                                else
                                {
                                    XtraMessageBox.Show(" Xuất chuyển kho không thành công! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(" Chuyển kho không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                EnableText(true);
                                EnableButton(false);
                                return;
                            }
                        }
                    }
                }
            }
            catch 
            {
                XtraMessageBox.Show("Lỗi Chưa chọn thuốc chuyển kho! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            try
            {
                sWareCode = sExpCode = string.Empty;
                dtDetail.Clear();
                ClearText();
                EnableText(true);
                EnableButton(false);
                gridView_Detail.OptionsBehavior.ReadOnly = false;
                gridView_Detail.OptionsBehavior.Editable = true;
                //gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearText()
        {
            dtNgayXuat.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            lkupKhoXuat.EditValue = null;
            lkupKhoNhan.EditValue = null;
            txtGhichu.Text = string.Empty;
            this.chkAll.Checked = false;
            this.chkCoppy.Checked = false;
        }

        private void EnableText(bool b)
        {
            this.dtNgayXuat.Enabled = b;
            this.lkupKhoXuat.Enabled = b;
            this.lkupKhoNhan.Enabled = b;
            this.txtGhichu.Enabled = b;
            this.chkAll.Properties.ReadOnly = true;
            this.chkCoppy.Properties.ReadOnly = true;
            this.searchLkupEmployee.ReadOnly = !b;
        }

        private void EnableButton(bool b)
        {
            this.butImport.Enabled = b;
            this.butSave.Enabled = !b;
            this.butDelete.Enabled = false;
            this.butEdit.Enabled = false;
            this.butIgnore.Enabled = !b;
            this.butPrint.Enabled = true;
        }

        private void butIgnore_Click(object sender, EventArgs e)
        {
            try
            {
                ClearText();
                EnableText(false);
                EnableButton(true);
                /*
                gridView_Detail.OptionsBehavior.ReadOnly = true;
                gridView_Detail.OptionsBehavior.Editable = false;
                gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                 */
            }
            catch { }
        }

        private void gridView_Detail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            
            decimal _UnitPrice = 0;
            decimal _Quantity = 0;
            decimal _Tax = 0;
            if (view.GetFocusedRowCellValue(col_Details_UnitPrice).ToString() != string.Empty)
                _UnitPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_UnitPrice));
            if (view.GetFocusedRowCellValue(col_Details_AmountImport).ToString() != string.Empty)
                _Quantity = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Details_AmountImport));
            
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if (this.dtfrom.EditValue == null)
            {
                XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtfrom.Focus();
                return;
            }
            if (this.dtto.EditValue == null)
            {
                XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtto.Focus();
                return;
            }
            this.gridControl_Search.DataSource = ExportWarehousingBLL.ListForDate(this.dtfrom.Text, this.dtto.Text, 1, this.sUser);
        }

        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_Search.GetFocusedRow() != null)
                {
                    this.xtabMain.SelectedTabPageIndex = 0;
                    sExpCode = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_search_ExpWarehousingCode).ToString();
                    this.dtNgayXuat.EditValue = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_Search_ImportDate).ToString();
                    this.txtGhichu.Text = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_Search_Note).ToString();
                    this.lkupKhoNhan.EditValue = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_Search_ImpRepositoryCode).ToString();
                    this.lkupKhoXuat.EditValue = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_Search_ExpRepositoryCode).ToString();
                    this.searchLkupEmployee.EditValue = this.gridView_Search.GetRowCellValue(this.gridView_Search.FocusedRowHandle, this.col_Search_EmployeeNameReceive).ToString();

                    this.EnableText(false);
                    this.EnableButton(true);
                    this.butEdit.Enabled = true;
                    this.LoadRepositoryDetail();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void xtabMain_Click(object sender, EventArgs e)
        {
            if (xtabMain.SelectedTabPageIndex == 1)
            {
                dtfrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                dtto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(" Bạn chắc chắn muốn hủy bỏ phiếu chuyển kho \n\t Số lượng thuốc trong kho sẽ thay đổi sau khi hủy phiếu!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    Int32 iResult = ExportWarehousingBLL.Del(sExpCode);
                    if (iResult >= 1)
                    {
                        XtraMessageBox.Show(" Hủy thành công phiếu chuyển kho !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearText();
                        this.EnableText(false);
                        this.EnableButton(true);
                        this.dtDetail.Clear();
                    }
                    else if (iResult == -2)
                    {
                        XtraMessageBox.Show(" Thuốc đã xuất, không được phép hủy !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Hủy không thành công !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch { }
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
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_AmountImport)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_RealQuantity, " Chưa nhập số lượng xuất !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_UnitPrice)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_UnitPrice, " Hãy nhập giá thuốc !");
                }
                
            }
            catch (Exception) { }
        }

        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh Viện Điện Tử .Net";
            e.ErrorText = " Bạn nhập thiếu thông tin chi tiết phiếu nhập !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            if (ExportWarehousingBLL.CheckEdit(sExpCode) == 0)
            {
                this.EnableText(true);
                this.EnableButton(false);
                this.butDelete.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show(" Phiếu xuất kho có thuốc đã xuất bán, Không được phép xóa hoặc sửa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupKhoXuat_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadRepositoryDetail();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsTemp = new DataSet("Report");
                dsTemp.Clear();
                DataTable tableGeneral = ExportWarehousingBLL.rpt_PrintWarehousingExport(sExpCode);
                if (tableGeneral != null && tableGeneral.Rows.Count > 0)
                {
                    DataTable dtct = new DataTable("ResultExportDetail");
                    dtct = ExportWarehousingBLL.rpt_PrintWarehousingExportDetail(sExpCode);
                    dsTemp.Tables.Add(tableGeneral);
                    dsTemp.Tables.Add(dtct);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptXuatKho.xml");
                    Reports.rptXuatKho rptShow = new Reports.rptXuatKho();
                    rptShow.Parameters["paraAmountTotal"].Value = tableGeneral.Rows[0]["AmountTotal"].ToString();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "XuatKho", "Xuất kho");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu chưa có, vui lòng xem lại!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkAll.Text = chkAll.Checked ? "Bỏ chọn" : "Chọn tất cả";
                if (this.chkAll.Checked)
                {
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["Chon"] = 1;
                    }
                }
                else
                {
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["Chon"] = 0;
                    }
                }
            }
            catch { }
        }

        private void chkCoppy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkCoppy.Text = chkCoppy.Checked ? "Không coppy số lượng" : "Coppy tất cả số lượng";
                if (this.chkCoppy.Checked)
                {
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["RealQuantity"] = dr["AmountExist"];
                    }
                    this.gridControl_Detail.DataSource = dtDetail;
                }
                else
                {
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["RealQuantity"] = 0;
                    }
                    this.gridControl_Detail.DataSource = dtDetail;
                }
            }
            catch { }
        }
        
        private void chkNhaThuoc_CheckedChanged(object sender, EventArgs e)
        {
            this.lkupKhoNhan.EditValue = this.lkupKhoXuat.EditValue = null;
            if (this.chkNhaThuoc.Checked)
            {
                this.lstKhoX = RepositoryCatalog_BLL.ListRepositoryForImport(0, "2,4", this.sUser);
                this.lkupKhoXuat.Properties.DataSource = this.lstKhoX;
                this.lkupKhoXuat.Properties.DisplayMember = "RepositoryName";
                this.lkupKhoXuat.Properties.ValueMember = "RepositoryCode";

                this.lstKhoN = RepositoryCatalog_BLL.ListRepositoryForExport(0, "1", this.sUser);
                this.lkupKhoNhan.Properties.DataSource = this.lstKhoN;
                this.lkupKhoNhan.Properties.DisplayMember = "RepositoryName";
                this.lkupKhoNhan.Properties.ValueMember = "RepositoryCode";
            }
            else
            {
                this.lstKhoX = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.sUser);
                this.lkupKhoXuat.Properties.DataSource = this.lstKhoX;
                this.lkupKhoXuat.Properties.DisplayMember = "RepositoryName";
                this.lkupKhoXuat.Properties.ValueMember = "RepositoryCode";

                this.lstKhoN = RepositoryCatalog_BLL.ListRepositoryForExport(0, "1", this.sUser);
                this.lkupKhoNhan.Properties.DataSource = this.lstKhoN;
                this.lkupKhoNhan.Properties.DisplayMember = "RepositoryName";
                this.lkupKhoNhan.Properties.ValueMember = "RepositoryCode";
            }
        }
        
    }
}