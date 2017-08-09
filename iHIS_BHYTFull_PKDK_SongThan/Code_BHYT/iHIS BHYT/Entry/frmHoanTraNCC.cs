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
    public partial class frmHoanTraNCC : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUser = string.Empty;
        private string sExpCode = string.Empty;
        private DataTable dtDetail = new DataTable();
        private string sVenCode = string.Empty;
        private Int32 iCancel = 0;
        private List<RepositoryCatalog_Inf> lstKhoX = new List<RepositoryCatalog_Inf>();
        private List<VendorInf> lstVendor = new List<VendorInf>();
        private string sUserOld = string.Empty;
        public frmHoanTraNCC(string _User)
        {
            InitializeComponent();
            this.sUser = _User;
        }

        private void frmHoanTraNCC_Load(object sender, EventArgs e)
        {
            ClearText();
            EnableText(false);
            EnableButton(true);
            
            lstKhoX = RepositoryCatalog_BLL.ListRepositoryForImport(0, "1", this.sUser);
            lkupKhoXuat.Properties.DataSource = lstKhoX;
            lkupKhoXuat.Properties.DisplayMember = "RepositoryName";
            lkupKhoXuat.Properties.ValueMember = "RepositoryCode";

            lstVendor = VendorBLL.ListVendor("");
            lkupVendor.Properties.DataSource = lstVendor.Select(p => new { p.VendorCode, p.VendorName, p.Address });
            lkupVendor.Properties.DisplayMember = "VendorName";
            lkupVendor.Properties.ValueMember = "VendorCode";

            gridView_Detail.OptionsBehavior.ReadOnly = true;
            gridView_Detail.OptionsBehavior.Editable = false;
        }

        private void LoadRepositoryDetail()
        { 
            try
            {
                dtDetail = ExportVendorBLL.DT_ListDetailExport(lkupKhoXuat.EditValue.ToString(), sExpCode);
                gridControl_Detail.DataSource = dtDetail;
                if (dtDetail.Rows.Count > 0)
                {
                    gridView_Detail.OptionsBehavior.ReadOnly = false;
                    gridView_Detail.OptionsBehavior.Editable = true;
                    chkAll.Properties.ReadOnly = false;
                    chkCoppy.Properties.ReadOnly = false;
                }
            }
            catch { }
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
                    XtraMessageBox.Show(" Ngày xuất hoàn trả không được để trống!", "Bệnh viện điện tử .NET");
                    dtNgayXuat.Focus();
                    return;
                }
                if (lkupKhoXuat.EditValue == null)
                {
                    XtraMessageBox.Show(" Chưa chọn kho xuất!", "Bệnh viện điện tử .NET");
                    lkupKhoXuat.Focus();
                    return;
                }
                if (lkupVendor.EditValue == null)
                {
                    XtraMessageBox.Show(" Chưa chọn nhà cung cấp!", "Bệnh viện điện tử .NET");
                    lkupVendor.Focus();
                    return;
                }
                if (dtTemp == null || dtTemp.Rows.Count <= 0)
                {
                    XtraMessageBox.Show(" Chi tiết thuốc chuyển kho không có!, vui lòng xem lại!", "Bệnh viện điện tử .NET");
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
                        XtraMessageBox.Show(" Những thuốc sau chưa nhập số lượng xuất: " + sErrorRealQuantity + " Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET");
                        return;
                    }
                    if (!bCheckNumber)
                    {
                        XtraMessageBox.Show(" Những thuốc sau không đủ tồn: " + sItemError + " Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET");
                        return;
                    }
                    else
                    {
                        ExportVendorInf ExpInf = new ExportVendorInf();
                        ExpInf.ExportVendorCode = sExpCode;
                        ExpInf.ExportDate = Utils.StringToDate(dtNgayXuat.Text);
                        ExpInf.ExpRepositoryCode = lkupKhoXuat.EditValue.ToString();
                        ExpInf.VendorCode = lkupVendor.EditValue.ToString();
                        ExpInf.Note = txtGhichu.Text;
                        ExpInf.EmployeeCode = sUser;
                        ExpInf.Cancel = iCancel;
                        if (ExportVendorBLL.Ins(ExpInf, ref sExpCode) >= 1)
                        {
                            Int32 iCount = 0;
                            ExportVendorBLL.Deltail(sExpCode);
                            foreach (DataRow r in dtTemp.Rows)
                            {
                                ExportVendorDetailInf mdelExp = new ExportVendorDetailInf();
                                mdelExp.RowIDGumshoe = Convert.ToDecimal(r["RowID"].ToString());
                                mdelExp.AmountRealExport = Convert.ToDecimal(r["RealQuantity"].ToString());
                                mdelExp.ExportVendorCode = sExpCode;
                                if (ExportVendorBLL.InsDetail(mdelExp, lkupKhoXuat.EditValue.ToString()) < 1)
                                {
                                    ExportVendorBLL.Del(sExpCode);
                                    XtraMessageBox.Show(" Xuất hoàn trả nhà cung cấp không thành công! Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET");
                                    break;
                                }
                                else
                                    iCount++;
                            }
                            if (iCount >= dtTemp.Rows.Count)
                            {
                                XtraMessageBox.Show(" Hoàn trả thuốc thành công!", "Bệnh viện điện tử .NET");
                                this.EnableButton(true);
                                this.EnableText(false);
                                this.gridView_Detail.OptionsBehavior.ReadOnly = true;
                                this.gridView_Detail.OptionsBehavior.Editable = false;
                                this.LoadRepositoryDetail();
                                return;
                            }
                            //else
                            //{
                            //    ExportVendorBLL.Del(sExpCode);
                            //    XtraMessageBox.Show(" Xuất hoàn trả nhà cung cấp không thành công! Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET");
                            //    return;
                            //}

                        }
                        else
                        {
                            XtraMessageBox.Show(" Xuất hoàn trả nhà cung cấp không thành công!", "Bệnh viện điện tử .NET");
                            EnableText(true);
                            EnableButton(false);
                            return;
                        }
                    }
                }
            }
            catch 
            {
                XtraMessageBox.Show(" Lỗi Chưa chọn thuốc hoàn trả nhà cung cấp! Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            try
            {
                sVenCode = sExpCode = string.Empty;
                dtDetail.Clear();
                ClearText();
                EnableText(true);
                EnableButton(false);
                gridView_Detail.OptionsBehavior.ReadOnly = false;
                gridView_Detail.OptionsBehavior.Editable = true;
            }
            catch { }
        }

        private void ClearText()
        {
            dtNgayXuat.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            lkupKhoXuat.EditValue = null;
            lkupVendor.EditValue = null;
            txtGhichu.Text = string.Empty;
        }

        private void EnableText(bool b)
        {
            dtNgayXuat.Enabled = b;
            lkupKhoXuat.Enabled = b;
            lkupVendor.Enabled = b;
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

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtfrom.EditValue == null)
                {
                    XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtfrom.Focus();
                    return;
                }
                if (dtto.EditValue == null)
                {
                    XtraMessageBox.Show(" Chọn ngày để tìm kiếm! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtto.Focus();
                    return;
                }
                gridControl_Search.DataSource = ExportVendorBLL.ListForDate(dtfrom.Text, dtto.Text);
            }
            catch { }
        }

        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_Search.GetFocusedRow() != null)
                {
                    xtabMain.SelectedTabPageIndex = 0;
                    sExpCode = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_search_ExportVendorCode).ToString();
                    dtNgayXuat.EditValue = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_ImportDate).ToString();
                    txtGhichu.Text = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_Note).ToString();
                    lkupVendor.EditValue = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_VendorCode).ToString();
                    lkupKhoXuat.EditValue = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_ExpRepositoryCode).ToString();
                    iCancel = Convert.ToInt32(gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_search_Cancel).ToString());
                    sUserOld = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_Search_EmployeeCode).ToString();
                    EnableText(false);
                    EnableButton(true);
                    butEdit.Enabled = true;
                    LoadRepositoryDetail();
                }
            }
                catch{}
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
                if (XtraMessageBox.Show(" Bạn chắc chắn muốn hủy bỏ phiếu hoàn trả nhà cung cấp này \n\t Số lượng thuốc trong kho sẽ thay đổi sau khi hủy phiếu!", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    Int32 iResult = ExportVendorBLL.Del(sExpCode);
                    if (iResult >= 1)
                    {
                        XtraMessageBox.Show(" Đã hủy phiếu hoàn trả nhà cung cấp!", "Bệnh viện điện tử .NET");
                        ClearText();
                        EnableText(false);
                        EnableButton(true);
                        dtDetail.Clear();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Hủy phiếu hoàn trả không thành công !", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
            }
            catch { }
        }

        
        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = " Bạn nhập thiếu thông tin chi tiết phiếu hoàn trả nhà cung cấp!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            if (sUserOld == sUser)
            {
                EnableText(true);
                EnableButton(false);
                butDelete.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show(" Khác người lập phiếu hoàn trả nhà cung cấp không được phép xóa hoặc sửa!", "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void lkupKhoXuat_EditValueChanged(object sender, EventArgs e)
        {
            LoadRepositoryDetail();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsTemp = new DataSet("Report");
                dsTemp.Clear();
                DataTable dtll = new DataTable("ResultExport");
                dtll = ExportVendorBLL.rpt_PrintExportVendor(sExpCode);
                if (dtll != null && dtll.Rows.Count > 0)
                {
                    DataTable dtct = new DataTable("ResultExportDetail");
                    dtct = ExportVendorBLL.rpt_PrintExportVendorDetail(sExpCode);
                    dsTemp.Tables.Add(dtll);
                    dsTemp.Tables.Add(dtct);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptHoantraNCC.xml");
                    Reports.rptXuatKhoTraNCC rptShow = new Reports.rptXuatKhoTraNCC();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "HoanTraNCC","Dược - Hoàn trả nhà cung cấp");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu chưa có, vui lòng xem lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chkCoppy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkCoppy.Text = chkCoppy.Checked ? "Không coppy số lượng" : "Coppy tất cả số lượng";
                if (chkCoppy.Checked)
                {
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["RealQuantity"] = dr["AmountExist"];
                    }
                    gridControl_Detail.DataSource = dtDetail;
                }
                else
                {
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["RealQuantity"] = 0;
                    }
                    gridControl_Detail.DataSource = dtDetail;
                }
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkAll.Text = chkAll.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
                if (chkAll.Checked)
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
    }
}