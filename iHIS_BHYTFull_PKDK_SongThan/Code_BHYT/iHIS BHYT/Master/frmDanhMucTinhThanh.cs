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

namespace Ps.Clinic.Master
{
    public partial class frmDanhMucTinhThanh : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty;
        public frmDanhMucTinhThanh(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmDanhMucTinhThanh_Load(object sender, EventArgs e)
        {
            try
            {
                this.replkupRegion.DataSource = CatalogProvincialBLL.DTRegionAll();
                this.replkupRegion.DisplayMember = "RegionName";
                this.replkupRegion.ValueMember = "RegionID";
                this.LoadData();
            }
            catch {  }
        }

        private void LoadData()
        {
            try
            {
                this.gridControl_Provincial.DataSource = CatalogProvincialBLL.DTListProvincial("");
            }
            catch { }
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo Tỉnh/T.Phố !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Object_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ProvincialName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ProvincialName, " Tên tỉnh thành không được để trống!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RegionID)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RegionID, " Chọn vùng miền khi khai báo tỉnh thành!");
                }
                if (e.Valid == true)
                {
                    CatalogProvincialInf inf = new CatalogProvincialInf();
                    if (gridView_Provincial.GetRowCellValue(e.RowHandle, "ProvincialCode").ToString() != "")
                        inf.ProvincialCode = gridView_Provincial.GetRowCellValue(e.RowHandle, "ProvincialCode").ToString();
                    else
                        inf.ProvincialCode = "";
                    if (gridView_Provincial.GetRowCellValue(e.RowHandle, "STT").ToString() != "")
                        inf.STT = int.Parse(gridView_Provincial.GetRowCellValue(e.RowHandle, "STT").ToString());
                    else
                        inf.STT = 1;
                    inf.ProvincialName = gridView_Provincial.GetRowCellValue(e.RowHandle, "ProvincialName").ToString();
                    inf.EmployeeCode = userID;
                    if (gridView_Provincial.GetRowCellValue(e.RowHandle, "RegionID").ToString() != "")
                        inf.RegionID = Int32.Parse(gridView_Provincial.GetRowCellValue(e.RowHandle, "RegionID").ToString());
                    else
                        inf.RegionID = 0;
                    inf.ProvincialIDBHYT = this.gridView_Provincial.GetRowCellValue(e.RowHandle, "ProvincialIDBHYT").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (CatalogProvincialBLL.InsProvincial(inf))
                        {
                            XtraMessageBox.Show(" Thêm thành công tỉnh/thành phố!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Thêm tỉnh/thành phố không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        CatalogProvincialBLL provincial = new CatalogProvincialBLL();
                        if (CatalogProvincialBLL.InsProvincial(inf))
                        {
                            XtraMessageBox.Show(" Cập nhật tỉnh/thành phố thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Cập nhật tỉnh/thành phố không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.LoadData();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void gridControl_Object_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Provincial.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show(" Bạn có muốn xóa tỉnh/thành phố hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            int result = CatalogProvincialBLL.DelProvincial(gridView_Provincial.GetRowCellValue(gridView_Provincial.FocusedRowHandle, "ProvincialCode").ToString());
                            if ( result == 1)
                                this.LoadData();
                            else if (result == -3)
                            {
                                XtraMessageBox.Show(" Xóa không thành công tỉnh/thành phố!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Phát sinh lỗi khi xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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