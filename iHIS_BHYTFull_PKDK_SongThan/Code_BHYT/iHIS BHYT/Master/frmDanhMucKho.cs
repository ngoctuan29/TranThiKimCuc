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
    public partial class frmDanhMucKho : DevExpress.XtraEditors.XtraForm
    {
        private string s_Employee = string.Empty;
        public frmDanhMucKho(string _Employee)
        {
            InitializeComponent();
            s_Employee = _Employee;
            rep_RepositoryGroup.DataSource = RepositoryCatalog_BLL.DT_ListRepositoryGroup();
            rep_RepositoryGroup.DisplayMember = "RepositoryGroupName";
            rep_RepositoryGroup.ValueMember = "RepositoryGroupCode";
        }

        private void frmDanhMucKho_Load(object sender, EventArgs e)
        {
            try
            {
                gridControl_Data.DataSource = RepositoryCatalog_BLL.DTListRepositoryAll(-1);
            }
            catch  {  }
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo kho!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Data_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RepositoryName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RepositoryName, " Tên kho thuốc không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RepositoryGroupCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RepositoryGroupCode, " Chọn nhóm kho!");
                }
                if (e.Valid == true)
                {
                    RepositoryCatalog_Inf inf = new RepositoryCatalog_Inf();
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "RepositoryCode") != null)
                        inf.RepositoryCode = gridView_Data.GetRowCellValue(e.RowHandle, "RepositoryCode").ToString();
                    else
                        inf.RepositoryCode = "";
                    inf.RepositoryName = gridView_Data.GetRowCellValue(e.RowHandle, "RepositoryName").ToString();
                    if (!string.IsNullOrEmpty(gridView_Data.GetRowCellValue(e.RowHandle, "Hide").ToString()))
                        inf.Hide = Int32.Parse(gridView_Data.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    else
                        inf.Hide = 0;
                    if (!string.IsNullOrEmpty(gridView_Data.GetRowCellValue(e.RowHandle, "RepositoryGroupCode").ToString()))
                        inf.RepositoryGroupCode = Int32.Parse(gridView_Data.GetRowCellValue(e.RowHandle, "RepositoryGroupCode").ToString());
                    inf.EmployeeCode = s_Employee;
                    if (!string.IsNullOrEmpty(gridView_Data.GetRowCellValue(e.RowHandle, "DateReport").ToString()))
                        inf.DateReport = Convert.ToDateTime(gridView_Data.GetRowCellValue(e.RowHandle, "DateReport").ToString());
                    else
                        inf.DateReport = DateTime.Now;
                    if (e.RowHandle < 0)
                    {
                        if (RepositoryCatalog_BLL.Ins(inf) == 1)
                            XtraMessageBox.Show("Thêm danh mục kho thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Thêm danh mục kho thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (RepositoryCatalog_BLL.Ins(inf) == 1)
                            XtraMessageBox.Show("Cập nhật danh mục kho thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Cập nhật danh mục kho thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                this.gridControl_Data.DataSource = RepositoryCatalog_BLL.DTListRepositoryAll(-1);
            }
            catch  { }
        }

        private void gridControl_Data_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Data.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa kho này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            if (RepositoryCatalog_BLL.Del(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "RepositoryCode").ToString()) == 1)
                                gridControl_Data.DataSource = RepositoryCatalog_BLL.DTListRepositoryAll(-1);
                            else
                            {
                                XtraMessageBox.Show(" Kho đã sử dụng không cho phép xóa !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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