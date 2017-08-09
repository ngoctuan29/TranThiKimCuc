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
using DevExpress.XtraGrid.Views.Grid;
using ClinicLibrary;
using ClinicBLL;
using ClinicModel;
namespace Ps.Clinic.Master
{
    public partial class frmDDLoaiNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public frmDDLoaiNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmDDLoaiNguyenLieu_Load(object sender, EventArgs e)
        {
            gridControl_FoodCategory.DataSource = FoodCategoryBLL.DTListFoodCategory();
            
        }

        private void gridView_FoodCategory_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo loại vật tư !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";    
        }

        private void gridView_FoodCategory_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_FoodCategoryName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_FoodCategoryName, "Nhập tên - nội dung loại vật tư!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_FoodCategorySTT))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_FoodCategorySTT, "Nhập STT cho loại vật tư!");
                }
                if (e.Valid == true)
                {
                    FoodCategoryINF inf = new FoodCategoryINF();
                    if (gridView_FoodCategory.GetRowCellValue(e.RowHandle, "FoodCategoryID").ToString() != string.Empty)
                        inf.FoodCategoryID = Convert.ToInt32(gridView_FoodCategory.GetRowCellValue(e.RowHandle, "FoodCategoryID").ToString());
                    else
                        inf.FoodCategoryID = 0;
                    inf.FoodCategoryName = gridView_FoodCategory.GetRowCellValue(e.RowHandle, "FoodCategoryName").ToString();
                    if (gridView_FoodCategory.GetRowCellValue(e.RowHandle, "STT").ToString() != string.Empty)
                        inf.STT = Convert.ToInt32(gridView_FoodCategory.GetRowCellValue(e.RowHandle, "STT").ToString());
                    else
                        inf.STT = 1;
                    if (e.RowHandle < 0)
                    {
                        if (FoodCategoryBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show(" Khai báo loại vật tư thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khai báo loại vật tư không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (FoodCategoryBLL.Upd(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật loại vật tư thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật loại vật tư không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    gridControl_FoodCategory.DataSource = FoodCategoryBLL.DTListFoodCategory();
                }
            }
            catch (Exception) { }
        }

        private void gridControl_FoodCategory_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_FoodCategory.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa loại vật tư này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        if (FoodCategoryBLL.Del(Convert.ToInt32(gridView_FoodCategory.GetRowCellValue(gridView_FoodCategory.FocusedRowHandle, "FoodCategoryID").ToString())) == 1)
                            gridView_FoodCategory.DeleteSelectedRows();
                    }
                    catch { return; }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_FoodCategory.ShowRibbonPrintPreview();
        }

    }
}