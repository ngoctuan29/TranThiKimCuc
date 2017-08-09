using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmCachDung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCachDung()
        {
            InitializeComponent();
        }

        private void gridView_Instruction_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_InstructionName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_InstructionName, "Nhập tên - nội dung cách dùng !");
                }
                if (e.Valid)
                {
                    InstructionInf inf = new InstructionInf();
                    if (!string.IsNullOrEmpty(gridView_Instruction.GetRowCellValue(e.RowHandle, "RowID").ToString()))
                        inf.RowID = decimal.Parse(gridView_Instruction.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.InstructionName = gridView_Instruction.GetRowCellValue(e.RowHandle, "InstructionName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (InstructionBLL.InsInstruction(inf) == 1)
                        {
                            XtraMessageBox.Show("Khai báo cách dùng thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Khai báo cách dùng thất bại!", "Bệnh viện điện tử .NET");
                            gridView_Instruction.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (InstructionBLL.InsInstruction(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật cách dùng thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật cách dùng thất bại!", "Bệnh viện điện tử .NET");
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void gridView_Instruction_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo hướng dẫn sử dụng thuốc, vtyt !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void frmCachDung_Load(object sender, EventArgs e)
        {
            gridControl_Instruction.DataSource = InstructionBLL.DTInstruction(0);
        }
        
        private void gridControl_Instruction_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Instruction.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa dịch vụ này trong gói đã khai báo?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        if (InstructionBLL.DelInstruction(decimal.Parse(gridView_Instruction.GetRowCellValue(gridView_Instruction.FocusedRowHandle, "RowID").ToString())) == 1)
                            gridView_Instruction.DeleteSelectedRows();
                    }
                    catch { return; }
                }
            }
        }
    }
}