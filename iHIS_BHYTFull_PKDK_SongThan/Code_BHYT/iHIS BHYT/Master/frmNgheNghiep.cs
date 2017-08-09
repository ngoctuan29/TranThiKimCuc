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
    public partial class frmNgheNghiep : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmNgheNghiep()
        {
            InitializeComponent();
        }

        private void frmNgheNghiep_Load(object sender, EventArgs e)
        {
            gridControl_List.DataSource = CareerBLL.DTCareer("");
        }
        
        private void gridView_List_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = " Bạn nhập thiếu thông tin khai báo nghề nghiệp!\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_List_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_CareerName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_CareerName, " Tên nghề nghiệp không được để trống ! ");
                }
                if (e.Valid)
                {
                    CareerInf inf = new CareerInf();
                    inf.CareerCode = gridView_List.GetRowCellValue(e.RowHandle, "CareerCode").ToString();
                    inf.CareerName = gridView_List.GetRowCellValue(e.RowHandle, "CareerName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (CareerBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show(" Thêm mới nghề nghiệp thành công! ", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show(" Thêm mới nghề nghiệp thất bại! ", "Bệnh viện điện tử .NET");
                            gridView_List.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (CareerBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật nghề nghiệp thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật nghề nghiệp thất bại!", "Bệnh viện điện tử .NET");
                        }
                    }
                }
                gridControl_List.DataSource = CareerBLL.DTCareer("");
            }
            catch (Exception) { }
        }

        private void gridControl_List_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_List.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa nghề nghiệp này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        if (CareerBLL.Del(gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, "CareerCode").ToString()) == 1)
                            gridView_List.DeleteSelectedRows();
                        else
                        {
                            XtraMessageBox.Show(" Nghề nghiệp đã được sử dụng! Không được xóa.", "Bệnh viện điện tử .NET");
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
                DataTable dtResult = CareerBLL.DTCareer("");
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptDMNgheNghiep.xml");
                Reports.rptDMNgheNghiep rptShow = new Reports.rptDMNgheNghiep();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DMNgheNghiep","Danh mục nghề nghiệp");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}