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
    public partial class frmDoiTuong : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiTuong()
        {
            InitializeComponent();
        }

        private void frmDoiTuong_Load(object sender, EventArgs e)
        {
            try
            {                
                gridControl_Object.DataSource = ObjectBLL.DTObjectList(0);
            }
            catch {  }
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo đối tượng!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Object_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ObjectName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ObjectName, "Tên đối tượng không được để trống !");
                }
                
                if (e.Valid == true)
                {
                    ObjectInf inf = new ObjectInf();
                    if (gridView_Object.GetRowCellValue(e.RowHandle, "ObjectCode").ToString() != "")
                        inf.ObjectCode = int.Parse(gridView_Object.GetRowCellValue(e.RowHandle, "ObjectCode").ToString());
                    else
                        inf.ObjectCode = 0;
                    inf.ObjectName = gridView_Object.GetRowCellValue(e.RowHandle, "ObjectName").ToString();
                    if (gridView_Object.GetRowCellValue(e.RowHandle, "ObjectCard").ToString() != "")
                        inf.ObjectCard = Int32.Parse(gridView_Object.GetRowCellValue(e.RowHandle, "ObjectCard").ToString());
                    else
                        inf.ObjectCard = 0;
                    if (e.RowHandle < 0)
                    {
                        if (ObjectBLL.InsObject(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm chưa được đối tượng!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (ObjectBLL.InsObject(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET");
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
                if (e.KeyCode == Keys.Delete && gridView_Object.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa đối tượng này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (ObjectBLL.DelObject(int.Parse(gridView_Object.GetRowCellValue(gridView_Object.FocusedRowHandle, "ObjectCode").ToString())) == 1)
                                gridView_Object.DeleteSelectedRows();
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}