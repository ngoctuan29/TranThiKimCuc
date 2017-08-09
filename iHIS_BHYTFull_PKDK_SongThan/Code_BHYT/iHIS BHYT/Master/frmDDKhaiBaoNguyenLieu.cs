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
    public partial class frmDDKhaiBaoNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private string sEmplyeeCode = string.Empty;
        public frmDDKhaiBaoNguyenLieu(string _EmployeeCode)
        {
            InitializeComponent();
            sEmplyeeCode = _EmployeeCode;
        }

        private void frmDDKhaiBaoNguyenLieu_Load(object sender, EventArgs e)
        {
            rep_FoodCategory.DataSource = FoodCategoryBLL.DTListFoodCategory();
            rep_FoodCategory.ValueMember = "FoodCategoryID";
            rep_FoodCategory.DisplayMember = "FoodCategoryName";
            rep_UnitOfRaw.DataSource = UnitOfRawBLL.DT_UnitOfRaw(0);
            rep_UnitOfRaw.ValueMember = "UnitOfRawID";
            rep_UnitOfRaw.DisplayMember = "UnitOfRawName";

            gridControl_FoodCategory.DataSource = Catalog_FoodBLL.DT_ListCatalog_Food();
            //gridView_FoodCategory.Columns["FoodCategoryID"].Group();
            //gridView_FoodCategory.ExpandAllGroups();
            
        }

        private void gridView_FoodCategory_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo vật tư suất ăn!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";    
        }

        private void gridView_FoodCategory_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_list_Catalog_FoodName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_list_Catalog_FoodName, "Nhập tên - nội dung vật tư suất ăn!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_list_FoodCategoryID))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_list_FoodCategoryID, " Chọn loại vật tư!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_list_UnitOfRawID))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_list_UnitOfRawID, " Chọn đơn vị tính nguyên liệu!");
                }
                if (e.Valid == true)
                {
                    Catalog_FoodINF inf = new Catalog_FoodINF();
                    if (gridView_FoodCategory.GetRowCellValue(e.RowHandle, "FoodCategoryID").ToString() != string.Empty)
                        inf.FoodCategoryID = Convert.ToInt32(gridView_FoodCategory.GetRowCellValue(e.RowHandle, "FoodCategoryID").ToString());
                    else
                        inf.FoodCategoryID = 0;
                    inf.Catalog_FoodCode = gridView_FoodCategory.GetRowCellValue(e.RowHandle, "Catalog_FoodCode").ToString();
                    inf.Catalog_FoodName = gridView_FoodCategory.GetRowCellValue(e.RowHandle, "Catalog_FoodName").ToString();
                    inf.UnitOfRawID = Convert.ToInt32(gridView_FoodCategory.GetRowCellValue(e.RowHandle, "UnitOfRawID").ToString());
                    inf.EmployeeCode = sEmplyeeCode;
                    if (e.RowHandle < 0)
                    {
                        if (Catalog_FoodBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show(" Khai báo vật tư thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khai báo vật tư không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (Catalog_FoodBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật vật tư thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật vật tư không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    gridControl_FoodCategory.DataSource = Catalog_FoodBLL.DT_ListCatalog_Food();
                    //gridView_FoodCategory.Columns["FoodCategoryID"].Group();
                    //gridView_FoodCategory.ExpandAllGroups();
                }
            }
            catch (Exception) { }
        }
        
        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_FoodCategory.ShowRibbonPrintPreview();
        }

        private void rep_Del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridView_FoodCategory.GetFocusedRowCellValue(col_list_Catalog_FoodCode).ToString() == "")
                {
                    gridView_FoodCategory.CancelUpdateCurrentRow();
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa vật tư suất ăn này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            Int32 iResult = Catalog_FoodBLL.Del(gridView_FoodCategory.GetFocusedRowCellValue(col_list_Catalog_FoodCode).ToString());
                            if (iResult == 1)
                            {
                                gridView_FoodCategory.DeleteSelectedRows();
                                gridView_FoodCategory.RefreshData();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Vật tư đã sử dụng không cho phép xóa!", "Bệnh viện điện tử .NET");
                                gridView_FoodCategory.RefreshData();
                                return;
                            }
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }

    }
}