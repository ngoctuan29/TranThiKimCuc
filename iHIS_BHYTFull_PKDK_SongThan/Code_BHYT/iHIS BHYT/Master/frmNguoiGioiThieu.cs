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
using DevExpress.XtraReports.UI;
namespace Ps.Clinic.Master
{
    public partial class frmNguoiGioiThieu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUserid = string.Empty;
        public frmNguoiGioiThieu(string refUserid)
        {
            InitializeComponent();
            sUserid = refUserid;
        }

        private void frmNguoiGioiThieu_Load(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dt = new DataTable();
                DataTable dtCareer = new DataTable();
                dt.Columns.Add(new DataColumn("StatusCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("StatusName", typeof(string)));
                dt.Rows.Add(new object[] { "0", "Nữ" });
                dt.Rows.Add(new object[] { "1", "Nam" });
                ref_status_sex.DataSource = dt;
                ref_status_sex.DisplayMember = "StatusName";
                ref_status_sex.ValueMember = "StatusCode";

                dtCareer = CareerBLL.DTCareer("");
                ref_Career.DataSource = dtCareer;
                ref_Career.DisplayMember = "CareerName";
                ref_Career.ValueMember = "CareerCode";
                gridControl_NguoiGT.DataSource = IntroducerBLL.DTIntroducer("");
            }
            catch { }
        }

        private void gridView_NguoiGT_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText =  " Xem lại thông tin khai báo người giới thiệu !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_NguoiGT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_IntroName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_IntroName, "Họ tên người giới thiệu không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Sex))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sex, "Chưa chọn giới tính!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Career))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Career, "Chưa chọn nghề nghiệp!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Birthday))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Birthday, "Vui lòng chọn ngày sinh!");
                }
                if (e.Valid)
                {
                    IntroducerInf inf = new IntroducerInf();
                    inf.IntroCode = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "IntroCode").ToString();
                    inf.IntroName = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "IntroName").ToString();
                    if (gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Sex").ToString() != "")
                        inf.Sex = int.Parse(gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Sex").ToString());
                    inf.Mobile = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Mobile").ToString();
                    inf.IDCard = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "IDCard").ToString();
                    inf.Address = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Address").ToString();
                    inf.Birthday = DateTime.Parse(gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Birthday").ToString());
                    inf.CareerCode = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "CareerCode").ToString();
                    inf.EmployeeCode = sUserid;
                    inf.Note = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Note").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (IntroducerBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm mới thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (IntroducerBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thất bại!", "Bệnh viện điện tử .NET");
                        }
                    }
                    gridControl_NguoiGT.DataSource = IntroducerBLL.DTIntroducer("");
                }
            }
            catch (Exception) { }
        }

        private void gridControl_NguoiGT_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_NguoiGT.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn thật sự muốn xóa ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        if (IntroducerBLL.Del(gridView_NguoiGT.GetRowCellValue(gridView_NguoiGT.FocusedRowHandle, "IntroCode").ToString()) == 1)
                            gridView_NguoiGT.DeleteSelectedRows();
                        else
                        {
                            XtraMessageBox.Show(" Không cho phép xóa!", "Bệnh viện điện tử .NET");
                            return;
                        }
                    }
                    catch { return; }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl_NguoiGT.ShowRibbonPrintPreview();
            }
            catch { }
        }

    }
}