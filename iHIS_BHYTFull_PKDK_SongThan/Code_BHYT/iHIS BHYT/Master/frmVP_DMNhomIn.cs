using ClinicBLL;
using ClinicModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ps.Clinic.Master
{
    public partial class frmVP_DMNhomIn : Form
    {
        public frmVP_DMNhomIn()
        {
            InitializeComponent();
        }

        private void frmVP_DMNhomIn_Load(object sender, EventArgs e)
        {
            this.GetDataGroup();
        }

        private void gridView_nhomIn_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_print_TenNhomIn))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_print_TenNhomIn, "Tên danh mục không được để trống!");
                }
                if (e.Valid)
                {
                    VP_ServiceGroupPrintInf inf = new VP_ServiceGroupPrintInf();
                    inf.GroupName = gridView_nhomIn.GetRowCellValue(e.RowHandle, "GroupName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (VP_ServiceGroupPrintBLL.InsUpdNhomIn(inf))
                            XtraMessageBox.Show("Thêm mới danh mục thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Thêm danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        inf.ID = Convert.ToInt32(gridView_nhomIn.GetRowCellValue(e.RowHandle, "ID").ToString());
                        if (VP_ServiceGroupPrintBLL.InsUpdNhomIn(inf))
                        {
                            XtraMessageBox.Show("Cập nhật danh mục thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.GetDataGroup();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi! \n" + ex.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gridView_nhomIn.DeleteRow(e.RowHandle);
            }
        }

        private void GetDataGroup()
        {
            this.gridControl_nhomIn.DataSource = VP_ServiceGroupPrintBLL.GetListNhomIn();
        }

        private void gridControl_nhomIn_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.gridView_nhomIn.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (VP_ServiceGroupPrintBLL.DelNhomIn(Convert.ToInt32(this.gridView_nhomIn.GetRowCellValue(this.gridView_nhomIn.FocusedRowHandle, "ID").ToString())))
                            this.GetDataGroup();
                        else
                            XtraMessageBox.Show("Xóa danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch { XtraMessageBox.Show("Xóa danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);  return; }
                }
            }
        }
    }
}
