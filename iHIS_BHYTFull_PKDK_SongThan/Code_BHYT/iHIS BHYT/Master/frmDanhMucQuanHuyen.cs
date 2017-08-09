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
    public partial class frmDanhMucQuanHuyen : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty;
        public frmDanhMucQuanHuyen(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmDanhMucQuanHuyen_Load(object sender, EventArgs e)
        {
            try
            {
                this.replkupProvincial.DataSource = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.replkupProvincial.DisplayMember = "ProvincialName";
                this.replkupProvincial.ValueMember = "ProvincialCode";
                this.LoadData();
            }
            catch {  }
        }

        private void LoadData()
        {
            try
            {
                CatalogDistrictBLL district = new CatalogDistrictBLL();
                this.gridControl_Data.DataSource = district.DTListDistrict("", "");
            }
            catch { }
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo Quận/Huyện !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Object_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_DistrictName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_DistrictName, " Tên quận/huyện không được để trống!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ProvincialCode)).ToString() == string.Empty || view.GetRowCellValue(rowfocus, col_ProvincialCode) == null)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ProvincialCode, " Chọn tỉnh thành khai báo quận/huyện!");
                }
                if (e.Valid == true)
                {
                    CatalogDistrictInf inf = new CatalogDistrictInf();
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "DistrictCode").ToString() != "")
                        inf.DistrictCode = gridView_Data.GetRowCellValue(e.RowHandle, "DistrictCode").ToString();
                    else
                        inf.DistrictCode = "";
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "STT").ToString() != "")
                        inf.STT = int.Parse(gridView_Data.GetRowCellValue(e.RowHandle, "STT").ToString());
                    else
                        inf.STT = 1;
                    inf.DistrictName = gridView_Data.GetRowCellValue(e.RowHandle, "DistrictName").ToString();
                    inf.EmployeeCode = userID;
                    inf.ProvincialCode = gridView_Data.GetRowCellValue(e.RowHandle, "ProvincialCode").ToString();
                    if (e.RowHandle < 0)
                    {
                        CatalogDistrictBLL district = new CatalogDistrictBLL();
                        if (district.InsDistrict(inf))
                        {
                            XtraMessageBox.Show(" Thêm thành công quận/huyện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Thêm quận/huyện không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        CatalogDistrictBLL district = new CatalogDistrictBLL();
                        if (district.InsDistrict(inf))
                        {
                            XtraMessageBox.Show(" Cập nhật quận/huyện thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Cập nhật quận/huyện không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (e.KeyCode == Keys.Delete && gridView_Data.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show(" Bạn có muốn xóa quận/huyện này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            CatalogDistrictBLL district = new CatalogDistrictBLL();
                            int result = district.DelDistrict(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "DistrictCode").ToString());
                            if ( result == 1)
                                this.LoadData();
                            else if (result == -3)
                            {
                                XtraMessageBox.Show(" Xóa không thành công quận/huyện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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