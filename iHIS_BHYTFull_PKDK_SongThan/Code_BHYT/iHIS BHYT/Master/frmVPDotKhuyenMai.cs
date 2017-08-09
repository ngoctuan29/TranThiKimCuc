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
    public partial class frmVPDotKhuyenMai : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty;
        public frmVPDotKhuyenMai(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void gridView_Data_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Name)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Name, "Nhập nội dung đợt giảm giá!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_DateFrom)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_DateFrom, "Chọn ngày bắt đầu áp dụng!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_DateTo)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_DateTo, "Chọn ngày kết thúc khuyến mãi!");
                }
                if (e.Valid)
                {
                    ServiceSalesInf inf = new ServiceSalesInf();
                    if (!string.IsNullOrEmpty(gridView_Data.GetRowCellValue(e.RowHandle, "RowID").ToString()))
                        inf.RowID = Convert.ToInt32(gridView_Data.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.Name = gridView_Data.GetRowCellValue(e.RowHandle, "Name").ToString();
                    inf.DateFrom = Convert.ToDateTime(gridView_Data.GetRowCellValue(e.RowHandle, "DateFrom").ToString());
                    inf.DateTo = Convert.ToDateTime(gridView_Data.GetRowCellValue(e.RowHandle, "DateTo").ToString());
                    if (this.gridView_Data.GetRowCellValue(e.RowHandle, "Hide").ToString() != "")
                        inf.Hide = Int32.Parse(this.gridView_Data.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    else
                        inf.Hide = 0;
                    inf.EmployeeCode = this.employeeCode;
                    if (e.RowHandle < 0)
                    {
                        if (ServiceSalesBLL.InsServiceSales(inf) == 1)
                        {
                            XtraMessageBox.Show("Khai báo thành công đợt khuyến mãi!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Khai báo không thành công! \r\n Vui lòng xem lại thông tin nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //this.gridView_Data.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (ServiceSalesBLL.InsServiceSales(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công đợt khuyến mãi!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công! \r\n Vui lòng xem lại thông tin nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    this.LoadData();
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_Data_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Kiểm tra lại thông tin khai báo đợt khuyến mãi.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void frmVPDotKhuyenMai_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.gridControl_Data.DataSource = ServiceSalesBLL.TableServiceSales(0);
        }
        private void gridControl_Data_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Data.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa đợt khuyến mãi này.", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        int result = ServiceSalesBLL.DelServiceSales(Convert.ToInt32(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "RowID").ToString()));
                        if (result == -1)
                            XtraMessageBox.Show("Đợt khuyến mãi đã áp dụng không được phép xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (result == 404)
                            XtraMessageBox.Show("Xóa không thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.LoadData();
                    }
                    catch { return; }
                }
            }
        }

        private void gridView_Data_DoubleClick(object sender, EventArgs e)
        {
            int rowid = Convert.ToInt32(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "RowID").ToString());
            frmVPChiTietDotKM frm = new frmVPChiTietDotKM(rowid, this.employeeCode);
            frm.ShowDialog();
        }
    }
}