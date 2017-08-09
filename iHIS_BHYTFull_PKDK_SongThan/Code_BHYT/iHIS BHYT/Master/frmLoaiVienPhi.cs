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
    public partial class frmLoaiVienPhi : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbServiceCategory = new DataTable();
        private string userID = string.Empty;
        public frmLoaiVienPhi(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmLoaiVienPhi_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtbServiceCategory = ServiceCategoryBLL.DTServiceCategory("", "");
                this.gridControl_Service_Category.DataSource = dtbServiceCategory;
                this.ref_Service_Group_Code.DataSource = ServiceGroupBLL.ListServiceGroup("");
                this.ref_Service_Group_Code.DisplayMember = "ServiceGroupName";
                this.ref_Service_Group_Code.ValueMember = "ServiceGroupCode";
            }
            catch { return; }
        }

        private void gridView_Service_Category_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo nhóm viện phí !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";    
        }

        private void gridView_Service_Category_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Service_Group_Code))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Service_Group_Code, "Chọn nhóm viện phí!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_ServiceCategoryName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_ServiceCategoryName, "Nhập tên - nội dung loại viện phí!");
                }
                if (e.Valid == true)
                {
                    ServiceCategoryInf inf = new ServiceCategoryInf();
                    inf.ServiceGroupCode = gridView_Service_Category.GetRowCellValue(e.RowHandle, "ServiceGroupCode").ToString();
                    inf.ServiceCategoryCode = gridView_Service_Category.GetRowCellValue(e.RowHandle, "ServiceCategoryCode").ToString();
                    inf.ServiceCategoryName = gridView_Service_Category.GetRowCellValue(e.RowHandle, "ServiceCategoryName").ToString();
                    inf.STT = Convert.ToInt32(gridView_Service_Category.GetRowCellValue(e.RowHandle, "STT").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (ServiceCategoryBLL.InsServiceCategory(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm chưa được loại viện phí!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (ServiceCategoryBLL.InsServiceCategory(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void gridControl_Service_Category_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Service_Category.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa loại dịch vụ này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        ServiceCategoryBLL.DelServiceCategory(gridView_Service_Category.GetRowCellValue(gridView_Service_Category.FocusedRowHandle, "ServiceCategoryCode").ToString());
                        gridView_Service_Category.DeleteSelectedRows();
                    }
                    catch { return; }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_Service_Category.ShowRibbonPrintPreview();
        }
    }
}