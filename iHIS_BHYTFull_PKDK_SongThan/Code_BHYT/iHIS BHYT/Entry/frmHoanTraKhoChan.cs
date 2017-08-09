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

namespace Ps.Clinic.Entry
{
    public partial class frmHoanTraKhoChan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUser = string.Empty;
        private string sExpCode = string.Empty;
        private DataTable dtDetail = new DataTable();
        private string sWareCode = string.Empty;

        private List<RepositoryCatalog_Inf> lstKhoX = new List<RepositoryCatalog_Inf>();
        private List<RepositoryCatalog_Inf> lstKhoN = new List<RepositoryCatalog_Inf>();
        private DateTime dtimeServer = new DateTime();
        public frmHoanTraKhoChan(string _User)
        {
            InitializeComponent();
            sUser = _User;
        }

        private void frmHoanTraThuaPK_Load(object sender, EventArgs e)
        {
            try
            {
                ClearText();
                EnableText(false);
                EnableButton(true);

                lstKhoX = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.sUser);
                lkupKhoNhan.Properties.DataSource = lstKhoX;
                lkupKhoNhan.Properties.DisplayMember = "RepositoryName";
                lkupKhoNhan.Properties.ValueMember = "RepositoryCode";

                lstKhoN = RepositoryCatalog_BLL.ListRepositoryForExport(0, "1", this.sUser);
                lkupKhoHoanTra.Properties.DataSource = lstKhoN;
                lkupKhoHoanTra.Properties.DisplayMember = "RepositoryName";
                lkupKhoHoanTra.Properties.ValueMember = "RepositoryCode";

                gridView_Detail.OptionsBehavior.ReadOnly = true;
                gridView_Detail.OptionsBehavior.Editable = false;
                this.dtimeServer = Utils.DateServer();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadRepositoryDetail()
        {
            this.dtDetail = Warehousing_BLL.DT_ListDetailExport(this.lkupKhoHoanTra.EditValue.ToString(), this.sExpCode);
            this.gridControl_Detail.DataSource = this.dtDetail;
            if (this.dtDetail.Rows.Count > 0)
            {
                this.gridView_Detail.OptionsBehavior.ReadOnly = false;
                this.gridView_Detail.OptionsBehavior.Editable = true;
                this.chkAll.Properties.ReadOnly = false;
                this.chkCoppy.Properties.ReadOnly = false;
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
                if (dtNgayXuat.EditValue == null)
                {
                    XtraMessageBox.Show(" Ngày xuất không được để trống!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgayXuat.Focus();
                    return;
                }
                if (lkupKhoNhan.EditValue == null)
                {
                    XtraMessageBox.Show(" Chưa chọn kho xuất hoàn trả!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lkupKhoNhan.Focus();
                    return;
                }
                if (lkupKhoHoanTra.EditValue == null)
                {
                    XtraMessageBox.Show(" Chưa chọn kho nhận hoàn trả!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lkupKhoHoanTra.Focus();
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
                            XtraMessageBox.Show(" Phiếu hoàn trả có thuốc đã xuất, Không được phép xóa hoặc sửa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            ExportWarehousingInf ExpInf = new ExportWarehousingInf();
                            ExpInf.ExpWarehousingCode = sExpCode;
                            ExpInf.ExportDate = Utils.StringToDate(dtNgayXuat.Text);
                            ExpInf.ExpRepositoryCode = lkupKhoHoanTra.EditValue.ToString();
                            ExpInf.ImpRepositoryCode = lkupKhoNhan.EditValue.ToString();
                            ExpInf.Note = txtGhichu.Text;
                            ExpInf.EmployeeCode = sUser;
                            ExpInf.Type = 2;
                            ExpInf.EmployeeNameReceive = string.Empty;
                            if (ExportWarehousingBLL.Ins(ExpInf, ref sExpCode) >= 1)
                            {
                                Int32 iCount = 0;
                                foreach (DataRow r in dtTemp.Rows)
                                {
                                    ExportWarehousingDetailInf mdelExp = new ExportWarehousingDetailInf();
                                    mdelExp.RowIDGumshoe = Convert.ToDecimal(r["RowID"].ToString());
                                    mdelExp.RepositoryExportCode = lkupKhoHoanTra.EditValue.ToString();
                                    mdelExp.RepositoryReceiveCode = lkupKhoNhan.EditValue.ToString();
                                    mdelExp.AmountRealExport = Convert.ToDecimal(r["RealQuantity"].ToString());
                                    mdelExp.ExpWarehousingCode = sExpCode;
                                    if (ExportWarehousingBLL.InsDetail(mdelExp) < 1)
                                    {
                                        ExportWarehousingBLL.Del(sExpCode);
                                        XtraMessageBox.Show(" Lỗi trong quá trình hoàn trả thuốc về kho! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    InventoryBLL.Ins_InventoryGeneral(modelGen, lkupKhoHoanTra.EditValue.ToString(), sWareCode);
                                }
                                if (iCount >= dtTemp.Rows.Count)
                                {
                                    XtraMessageBox.Show(" Hoàn trả thuốc về kho thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EnableButton(true);
                                    EnableText(false);
                                    gridView_Detail.OptionsBehavior.ReadOnly = true;
                                    gridView_Detail.OptionsBehavior.Editable = false;
                                    LoadRepositoryDetail();
                                    return;
                                }
                                else
                                {
                                    XtraMessageBox.Show(" Hoàn trả kho không thành công! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hoàn trả kho không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                XtraMessageBox.Show("Lỗi Chưa chọn thuốc chuyển kho! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //Warehousing_BLL.Del(sWareCode); 
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.sWareCode = this.sExpCode = string.Empty;
                this.dtDetail.Clear();
                this.ClearText();
                this.EnableText(true);
                this.EnableButton(false);
                this.gridView_Detail.OptionsBehavior.ReadOnly = false;
                this.gridView_Detail.OptionsBehavior.Editable = true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearText()
        {
            this.dtNgayXuat.EditValue = this.dtimeServer;
            this.lkupKhoNhan.EditValue = string.Empty;
            this.lkupKhoHoanTra.EditValue = string.Empty;
            this.txtGhichu.Text = string.Empty;
        }

        private void EnableText(bool b)
        {
            dtNgayXuat.Enabled = b;
            lkupKhoNhan.Enabled = b;
            lkupKhoHoanTra.Enabled = b;
            txtGhichu.Enabled = b;
            chkAll.Properties.ReadOnly = true;
            chkCoppy.Properties.ReadOnly = true;
        }

        private void EnableButton(bool b)
        {
            butImport.Enabled = b;
            butSave.Enabled = !b;
            butDelete.Enabled = false;
            butEdit.Enabled = false;
            butIgnore.Enabled = !b;
            butPrint.Enabled = true;
        }

        private void butIgnore_Click(object sender, EventArgs e)
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
            if (dtfrom.EditValue == null)
            {
                XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtfrom.Focus();
                return;
            }
            if (dtto.EditValue == null)
            {
                XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtto.Focus();
                return;
            }
            gridControl_Search.DataSource = ExportWarehousingBLL.ListForDate(dtfrom.Text, dtto.Text, 2, this.sUser);
        }

        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_Search.GetFocusedRow() != null)
                {
                    xtabMain.SelectedTabPageIndex = 0;
                    sExpCode = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_search_ExpWarehousingCode).ToString();
                    dtNgayXuat.EditValue = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_ImportDate).ToString();
                    txtGhichu.Text = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_Note).ToString();
                    lkupKhoHoanTra.EditValue = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_ExpRepositoryCode).ToString();
                    lkupKhoNhan.EditValue = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_ImpRepositoryCode).ToString();
                    EnableText(false);
                    EnableButton(true);
                    butEdit.Enabled = true;
                    LoadRepositoryDetail();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void xtabMain_Click(object sender, EventArgs e)
        {
            if (xtabMain.SelectedTabPageIndex == 1)
            {
                dtfrom.Text = dtto.Text = this.dtimeServer.ToString("dd/MM/yyyy");
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
                        XtraMessageBox.Show(" Hủy thành công phiếu hoàn trả kho !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearText();
                        EnableText(false);
                        EnableButton(true);
                        dtDetail.Clear();
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
            e.ErrorText = " Bạn nhập thiếu thông tin chi tiết phiếu hoàn trả !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            if (ExportWarehousingBLL.CheckEdit(sExpCode) == 0)
            {
                EnableText(true);
                EnableButton(false);
                butDelete.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show(" Phiếu hoàn trả kho có thuốc đã xuất, Không được phép xóa hoặc sửa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsTemp = new DataSet("Report");
                dsTemp.Clear();
                DataTable tableGeneral = new DataTable("ResultExport");
                tableGeneral = ExportWarehousingBLL.rpt_PrintWarehousingExport(sExpCode);
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
                    XtraMessageBox.Show("Số liệu chưa có, vui lòng xem lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupKhoHoanTra_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadRepositoryDetail();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAll.Text = chkAll.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
            if (this.chkAll.Checked)
            {
                foreach (DataRow dr in this.dtDetail.Rows)
                {
                    dr["Chon"] = 1;
                }
            }
            else
            {
                foreach (DataRow dr in this.dtDetail.Rows)
                {
                    dr["Chon"] = 0;
                }
            }
        }

        private void chkCoppy_CheckedChanged(object sender, EventArgs e)
        {
            this.chkCoppy.Text = chkCoppy.Checked ? "Không coppy số lượng" : "Coppy tất cả số lượng";
            if (this.chkCoppy.Checked)
            {
                foreach (DataRow dr in this.dtDetail.Rows)
                {
                    dr["RealQuantity"] = dr["AmountExist"];
                }
                this.gridControl_Detail.DataSource = this.dtDetail;
            }
            else
            {
                foreach (DataRow dr in this.dtDetail.Rows)
                {
                    dr["RealQuantity"] = 0;
                }
                this.gridControl_Detail.DataSource = this.dtDetail;
            }
        }   
    }
}