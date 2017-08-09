using System;
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
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmPhanLoaiThuoc : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPhanLoaiThuoc()
        {
            InitializeComponent();
        }

        private void frmPhanLoaiThuoc_Load(object sender, EventArgs e)
        {
            rep_GroupCode.DataSource = ItemGroupBLL.DTListItemGroup(string.Empty);
            rep_GroupCode.ValueMember = "GroupCode";
            rep_GroupCode.DisplayMember = "GroupName";
            gridControl_Item_Category.DataSource = ItemCategoryBLL.DTItemCategory(string.Empty);
        }
        private void gridView_Item_Category_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo phân loại thuốc, vtyt !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }
        private void gridView_Item_Category_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ItemCategoryName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ItemCategoryName, "Nhập tên phân loại thuốc !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_GroupCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_GroupCode, "Chọn nhóm thuốc !");
                }
                if (e.Valid)
                {
                    ItemCategoryInf inf = new ItemCategoryInf();
                    inf.ItemCategoryCode = gridView_Item_Category.GetRowCellValue(e.RowHandle, "ItemCategoryCode").ToString();
                    inf.ItemCategoryName = gridView_Item_Category.GetRowCellValue(e.RowHandle, "ItemCategoryName").ToString();
                    inf.GroupCode = gridView_Item_Category.GetRowCellValue(e.RowHandle, "GroupCode").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (ItemCategoryBLL.InsItemCategory(inf) == 1)
                        {
                            //XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET");
                            gridControl_Item_Category.DataSource = ItemCategoryBLL.DTItemCategory(string.Empty);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            gridView_Item_Category.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (ItemCategoryBLL.InsItemCategory(inf) == 1)
                        {
                            //XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                            gridControl_Item_Category.DataSource = ItemCategoryBLL.DTItemCategory(string.Empty);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            gridView_Item_Category.DeleteRow(rowfocus);
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void gridControl_Item_Category_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Item_Category.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa loại thuốc này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (ItemCategoryBLL.DelItemCategory(gridView_Item_Category.GetRowCellValue(gridView_Item_Category.FocusedRowHandle, "ItemCategoryCode").ToString()) == 1)
                                gridView_Item_Category.DeleteSelectedRows();
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}