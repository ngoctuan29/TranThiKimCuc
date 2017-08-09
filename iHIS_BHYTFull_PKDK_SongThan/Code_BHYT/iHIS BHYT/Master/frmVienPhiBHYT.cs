using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using DevExpress.XtraEditors.Controls;

namespace Ps.Clinic.Master
{
    public partial class frmVienPhiBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userid = string.Empty;
        public frmVienPhiBHYT(string _userid)
        {
            InitializeComponent();
            this.s_userid = _userid;
        }

        private void frmVienPhiBHYT_Load(object sender, EventArgs e)
        {
            this.fLoaddata();
        }

        private void fLoaddata()
        {
            this.gridControl_Service.DataSource = Catalog_BHYTBLL.TableService_BHYT();
        }

        private void gridView_Service_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 hide = 0;
                if (e.RowHandle >= 0)
                {
                    hide = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Hide"]));
                    if (hide == 1)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                        View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void gridView_Service_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            //e.WindowCaption = "Bệnh viện điện tử .NET";
            //e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo giá viện phí !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Service_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;
            //    int rowfocus = e.RowHandle;
            //    if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Service_Group_Code))))
            //    {
            //        e.Valid = false;
            //        view.SetColumnError(col_Service_Group_Code, "Nhóm viện phí không tồn tại. Yêu cầu qua khai báo!");
            //    }
            //    if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Service_Category_Code))))
            //    {
            //        e.Valid = false;
            //        view.SetColumnError(col_Service_Group_Code, "Chọn loại của nhóm viện phí.!");
            //    }
            //    //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Service_Code))))
            //    //{
            //    //    e.Valid = false;
            //    //    view.SetColumnError(col_Service_Code, "Mã viện phí không được để trống !");
            //    //}
            //    //if (ISDBNULL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Unit_Price)),1 ) < 0)
            //    //{
            //    //    e.Valid = false;
            //    //    view.SetColumnError(col_Unit_Price, "Đơn giá phải lớn hơn không (0) !");
            //    //}
            //    if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Service_Name))))
            //    {
            //        e.Valid = false;
            //        view.SetColumnError(col_Service_Name, "Tên viện phí không được để trống !");
            //    }
            //    if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitOf))))
            //    {
            //        e.Valid = false;
            //        view.SetColumnError(col_UnitOf, "Chưa chọn đơn vị tính!");
            //    }
            //    if (e.Valid == true)
            //    {
            //        ServiceInf inf = new ServiceInf();
            //        inf.ServiceGroupCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceGroupCode").ToString();
            //        inf.ServiceCategoryCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceCategoryCode").ToString();
            //        inf.ServiceCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceCode").ToString();
            //        inf.ServiceName = Utils.ToUpperCharacterFisrt(this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceName").ToString());
            //        inf.DepartmentCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "DepartmentCode").ToString();
            //        if (this.gridView_Service.GetRowCellValue(e.RowHandle, "Hide").ToString() != "")
            //            inf.Hide = Int32.Parse(this.gridView_Service.GetRowCellValue(e.RowHandle, "Hide").ToString());
            //        else
            //            inf.Hide = 0;
            //        inf.EmployeeCode = s_userid;
            //        inf.PatientType = this.gridView_Service.GetRowCellValue(e.RowHandle, "PatientType").ToString();
            //        if (this.gridView_Service.GetRowCellValue(e.RowHandle, "Serial").ToString() != "")
            //            inf.Serial = Convert.ToInt32(gridView_Service.GetRowCellValue(e.RowHandle, "Serial").ToString());
            //        else
            //            inf.Serial = 0;
            //        inf.UnitOfMeasureCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "UnitOfMeasureCode").ToString();
            //        if (this.gridView_Service.GetRowCellValue(e.RowHandle, "SampleTransfer").ToString() != "")
            //            inf.SampleTransfer = Int32.Parse(this.gridView_Service.GetRowCellValue(e.RowHandle, "SampleTransfer").ToString());
            //        else
            //            inf.SampleTransfer = 0;
            //        //inf.GroupID_BHYT = -1;
            //        //inf.MaTuongDuong_BHYT = string.Empty;
            //        //inf.MaCK_BHYT = string.Empty;
            //        //inf.MaDK_BHYT = string.Empty;
            //        //inf.Note = string.Empty;
            //        if (e.RowHandle < 0)
            //        {
            //            if (ServiceBLL.InsService(inf) != 1)
            //            {
            //                XtraMessageBox.Show("Thêm chưa được danh mục viện phí!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                //XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            //else
            //            //{
            //            //    XtraMessageBox.Show("Thêm chưa được danh mục viện phí!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            //}
            //        }
            //        else
            //        {
            //            if (ServiceBLL.InsService(inf) != 1)
            //            {
            //                XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                //XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            //else
            //            //{
            //            //    XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            //}
            //        }
            //        this.fLoaddata();
            //    }
                
            //}
            //catch (Exception) { }
        }

        private void gridView_Service_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view.FocusedColumn.FieldName == "ServiceCategoryCode")
            //{
            //    if (e.Value != null)
            //    {
            //        string sGrCode = ServiceCategoryBLL.ServiceGroupCode("", e.Value.ToString());
            //        view.SetFocusedRowCellValue(col_Service_Group_Code, sGrCode);
            //    }
            //}
        }

        private void gridControl_Service_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete && gridView_Service.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            //{
            //    if (XtraMessageBox.Show(" Bạn có muốn xóa dịch vụ đang chọn hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            //    {
            //        try
            //        {
            //            string sCode = gridView_Service.GetRowCellValue(gridView_Service.FocusedRowHandle, "ServiceCode").ToString();
            //            if (ServiceBLL.DelService(sCode) >= 1)
            //                this.fLoaddata();
            //            else
            //            {
            //                XtraMessageBox.Show(" Dịch vụ đã sử dụng không cho phép xóa !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //        }
            //        catch { return; }
            //    }
            //}
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            //this.gridView_Service.ShowRibbonPrintPreview();
        }
    }
}