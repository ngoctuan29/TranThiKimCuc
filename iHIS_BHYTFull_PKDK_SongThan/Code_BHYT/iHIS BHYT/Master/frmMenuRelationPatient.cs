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
    public partial class frmMenuRelationPatient : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userID = string.Empty;
        public frmMenuRelationPatient(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmMenuRelationPatient_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            PatientsRelationMenuBLL menu = new PatientsRelationMenuBLL();
            this.gridControl_Data.DataSource = menu.TableRelationMenu();
        }

        private void gridView_Symptoms_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo thông tin gia đình !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        //private void gridView_Symptoms_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (gridView_Data.RowCount > 0)
        //    {
        //        if (gridView_Data.GetFocusedRow() != null)
        //        {
        //            if (e.KeyValue == 46)
        //            {
        //                if (XtraMessageBox.Show("Bạn có muốn xóa nội dung đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
        //                {
        //                    try
        //                    {
        //                        GridView view = sender as GridView;
        //                        string title = view.GetFocusedRowCellValue(col_RelationTitle).ToString();
        //                        int rowid = Convert.ToInt32(view.GetFocusedRowCellValue(col_RowID).ToString());
        //                        PatientsRelationMenuBLL menu = new PatientsRelationMenuBLL();
        //                        if (menu.DelPatientsRelationMenu(rowid))
        //                        {
        //                            this.LoadData();
        //                            XtraMessageBox.Show("Đã xóa thông tin: " + title.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        }
        //                    }
        //                    catch { return; }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        private void gridView_Symptoms_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RelationTitle)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RelationTitle, "Nhập thông tin quan hệ gia đình!");
                }
                if (e.Valid)
                {
                    PatientsRelationMenuInf inf = new PatientsRelationMenuInf();
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = Int32.Parse(gridView_Data.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.RelationTitle = gridView_Data.GetRowCellValue(e.RowHandle, "RelationTitle").ToString();
                    inf.EmployeeCode = userID;
                    PatientsRelationMenuBLL menu = new PatientsRelationMenuBLL();
                    if (e.RowHandle < 0)
                    {
                        if (menu.InsPatientsRelationMenu(inf) >= 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (menu.InsPatientsRelationMenu(inf) >= 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.LoadData();
                }
            }
            catch (Exception) { }
        }

        

        private void gridControl_Symptom_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Data.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa nội dung đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            PatientsRelationMenuBLL menu = new PatientsRelationMenuBLL();
                            if (menu.DelPatientsRelationMenu(int.Parse(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "RowID").ToString())))
                                this.LoadData();
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}