using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicModel;
namespace Ps.Clinic.Master
{
    public partial class frmViTriNhanVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable dt = new DataTable();
        public frmViTriNhanVien()
        {
            InitializeComponent();
        }

        private void frmViTriNhanVien_Load(object sender, EventArgs e)
        {
            //dt = ServiceGroupBLL.DTServiceGroup("");
            gridControl_Position.DataSource = dt;
        }

        private void gridView_Position_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                bool bVali = true;
                if (gridView_Position.GetRowCellValue(e.RowHandle, "PositionName").ToString() == "")
                {
                    bVali = false;
                    sErr = sErr + "Vui lòng nhập tên vị trí!";
                }
                if (bVali)
                {
                    EmployeePositionInf inf = new EmployeePositionInf();
                    inf.PositionCode = Int32.Parse(gridView_Position.GetRowCellValue(e.RowHandle, "PositionCode").ToString());
                    inf.PositionName = gridView_Position.GetRowCellValue(e.RowHandle, "PositionName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (EmployeePositionBLL.InsEmployeePosition(inf, true) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm chưa được vị trí!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (EmployeePositionBLL.InsEmployeePosition(inf, false) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                }
                else
                {
                    e.Valid = false;
                    XtraMessageBox.Show(sErr, "Bệnh viện điện tử .NET");
                }
            }
            catch { }
        }

        private void gridControl_Position_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Position.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa vị trí này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        EmployeePositionBLL.DelEmployeePosition(gridView_Position.GetRowCellValue(gridView_Position.FocusedRowHandle, "PositionCode").ToString());
                        gridView_Position.DeleteSelectedRows();
                    }
                    catch { return; }
                }
            }
        }
    }
}