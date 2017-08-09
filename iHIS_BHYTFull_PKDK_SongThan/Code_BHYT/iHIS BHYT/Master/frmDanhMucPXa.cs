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
    public partial class frmDanhMucPXa : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty;
        private string provincialCode = string.Empty;
        private string districtCode = string.Empty;
        public frmDanhMucPXa(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmDanhMucPXa_Load(object sender, EventArgs e)
        {
            try
            {
                this.replkupProvincial.DataSource = CatalogProvincialBLL.DTListProvincial(string.Empty);
                this.replkupProvincial.DisplayMember = "ProvincialName";
                this.replkupProvincial.ValueMember = "ProvincialCode";

                this.LoadListDistrict();
                this.LoadListWard();
            }
            catch {  }
        }

        private void LoadListWard()
        {
            try
            {
                CatalogWardBLL ward = new CatalogWardBLL();
                this.gridControl_Data.DataSource = ward.DTListWard("", this.districtCode, this.provincialCode);
            }
            catch { }
        }

        private void LoadListDistrict()
        {
            try
            {
                CatalogDistrictBLL district = new CatalogDistrictBLL();
                this.replkupDistrict.DataSource = district.DTListDistrict(districtCode, provincialCode);
                this.replkupDistrict.DisplayMember = "DistrictName";
                this.replkupDistrict.ValueMember = "DistrictCode";
            }
            catch { return; }
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo phường, xã !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Object_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_WardName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_WardName, " Tên phường, xã không được để trống!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_DistrictCode)).ToString() == string.Empty || view.GetRowCellValue(rowfocus, col_DistrictCode) == null)
                {
                    e.Valid = false;
                    view.SetColumnError(col_DistrictCode, " Chọn quận/huyện khi khai báo phường/xã!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ProvincialCode)).ToString() == string.Empty || view.GetRowCellValue(rowfocus, col_ProvincialCode) == null)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ProvincialCode, " Chọn tỉnh thành khi khai báo phường/xã!");
                }
                if (e.Valid == true)
                {
                    CatalogWardInf inf = new CatalogWardInf();
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "WardCode").ToString() != "")
                        inf.WardCode = gridView_Data.GetRowCellValue(e.RowHandle, "WardCode").ToString();
                    else
                        inf.WardCode = "";
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "STT").ToString() != "")
                        inf.STT = int.Parse(gridView_Data.GetRowCellValue(e.RowHandle, "STT").ToString());
                    else
                        inf.STT = 1;
                    inf.WardName = gridView_Data.GetRowCellValue(e.RowHandle, "WardName").ToString();
                    inf.EmployeeCode = userID;
                    inf.DistrictCode = gridView_Data.GetRowCellValue(e.RowHandle, "DistrictCode").ToString();
                    inf.ShortFor = gridView_Data.GetRowCellValue(e.RowHandle, "ShortFor").ToString();
                    if (e.RowHandle < 0)
                    {
                        CatalogWardBLL ward = new CatalogWardBLL();
                        if (ward.InsWard(inf))
                        {
                            XtraMessageBox.Show(" Thêm thành công phường/xã!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadListWard();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Thêm phường/xã không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        CatalogWardBLL ward = new CatalogWardBLL();
                        if (ward.InsWard(inf))
                        {
                            XtraMessageBox.Show(" Cập nhật phường/xã thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadListWard();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Cập nhật phường/xã không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.LoadListWard();
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
                    if (XtraMessageBox.Show(" Bạn có muốn xóa phường/xã này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            CatalogWardBLL ward = new CatalogWardBLL();
                            int result = ward.DelWard(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "WardCode").ToString());
                            if ( result == 1)
                                this.LoadListWard();
                            else if (result == -3)
                            {
                                XtraMessageBox.Show(" Xóa không thành công phường/xã!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                 
        private void gridView_Data_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ProvincialCode")
                {
                    if (e.Value != null)
                    {
                        this.provincialCode = view.EditingValue.ToString();
                        view.SetFocusedRowCellValue(col_ProvincialCode, this.provincialCode);
                        CatalogDistrictBLL district = new CatalogDistrictBLL();
                        this.replkupDistrict.DataSource = district.DTListDistrictForProvincial(this.provincialCode);
                        this.replkupDistrict.DisplayMember = "DistrictName";
                        this.replkupDistrict.ValueMember = "DistrictCode";
                    }
                }
            }
            catch { return; }
        }

    }
}