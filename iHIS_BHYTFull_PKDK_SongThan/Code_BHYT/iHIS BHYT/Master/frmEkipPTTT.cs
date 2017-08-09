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
    public partial class frmEkipPTTT : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public frmEkipPTTT()
        {
            InitializeComponent();
        }

        private void frmEkipPTTT_Load(object sender, EventArgs e)
        {
            dt = Catalog_SurgicalCrewBLL.DT_List();
            gridControl_SurgicalCrew.DataSource = dt;
            ref_EmployeeCode.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
            ref_EmployeeCode.DisplayMember = "EmployeeName";
            ref_EmployeeCode.ValueMember = "EmployeeCode";

            ref_PositionCode.DataSource = EmployeePositionBLL.DTEmployeePosition(0);
            ref_PositionCode.DisplayMember = "PositionName";
            ref_PositionCode.ValueMember = "PositionCode";
        }

        private void gridView_SurgicalCrew_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai Ekip thực hiện !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";    
        }

        private void gridView_SurgicalCrew_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Sur_PositionCode))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sur_PositionCode, "Chọn vị trí!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Sur_EmployeeCode))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sur_EmployeeCode, "Chọn Bác sĩ, kỹ thuật viên!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Sur_STT))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sur_STT, " Nhập số thứ tự!");
                }
                if (e.Valid == true)
                {
                    Catalog_SurgicalCrewINF inf = new Catalog_SurgicalCrewINF();
                    if (gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = Convert.ToInt32(gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.EmployeeName = gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "EmployeeName").ToString();
                    inf.Role = gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "Role").ToString();
                    inf.STT = Convert.ToInt32(gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "STT").ToString());
                    inf.EmployeeCode = gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "EmployeeCode").ToString();
                    inf.PositionCode = Convert.ToInt32(gridView_SurgicalCrew.GetRowCellValue(e.RowHandle, "PositionCode").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (Catalog_SurgicalCrewBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Lỗi khi thêm EKip PT - TT!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (Catalog_SurgicalCrewBLL.Ins(inf) == 1)
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

        private void gridControl_Service_Category_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_SurgicalCrew.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa nhân viên này ra khỏi Ekip PT - TT?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        Catalog_SurgicalCrewBLL.Del(Convert.ToInt32(gridView_SurgicalCrew.GetRowCellValue(gridView_SurgicalCrew.FocusedRowHandle, "RowID").ToString()));
                        gridView_SurgicalCrew.DeleteSelectedRows();
                        //dt.Rows.RemoveAt(gridView_ServiceGroup.FocusedRowHandle);
                    }
                    catch { return; }
                }
            }
        }

    }
}