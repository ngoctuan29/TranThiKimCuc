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
using DevExpress.XtraRichEdit.Commands;
using System.Runtime.InteropServices;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Master
{
    public partial class frmVienPhiGia : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userid = string.Empty;
        private string serviceCode = string.Empty;
        private int hide = 0;
        public frmVienPhiGia(string _userid)
        {
            InitializeComponent();
            this.s_userid = _userid;
        }

        private void frmVienPhiGia_Load(object sender, EventArgs e)
        {
            Item_ServiceCode.DataSource =  ServiceBLL.ListService(string.Empty, string.Empty, this.hide);
            Item_ServiceCode.DisplayMember = "ServiceName";
            Item_ServiceCode.ValueMember = "ServiceCode";

            rep_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
            rep_ObjectCode.DisplayMember = "ObjectName";
            rep_ObjectCode.ValueMember = "ObjectCode";
            this.LoadDataService();
            
        }

        private void LoadDataPrice()
        {
            this.gridControl_ServicePrice.DataSource = ServicePriceBLL.DTServicePriceList(this.serviceCode);
            //gridView_ServicePrice.Columns["ServiceCategoryName"].Group();
            //gridView_ServicePrice.ExpandAllGroups();
        }
        private void LoadDataService()
        {
            this.gridControl_Service.DataSource = ServiceBLL.ListServiceRealFullName().Select(p => new { p.ServiceCode, p.ServiceName, p.ServiceGroupName, p.ServiceCategoryName }).ToList();
            this.gridView_Service.Columns["ServiceGroupName"].Group();
            this.gridView_Service.Columns["ServiceCategoryName"].Group();
            //gridView_Service.ExpandAllGroups();
        }
        private void gridView_ServicePrice_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    Int32 iHide = Convert.ToInt32(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Hide"]));
                    if (iHide == 1)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            catch { }
        }

        private void gridView_ServicePrice_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "iHIS Bệnh Viện Điện Tử";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo giá viện phí !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void gridView_ServicePrice_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(this.serviceCode)))
                {
                    e.Valid = false;
                    view.SetColumnError(col_ServiceCode, "Đề nghị chọn viện phí khai báo giá!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitPrice))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_UnitPrice, "Đề nghị nhập giá!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_ObjectCode))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_ObjectCode, "Chưa chọn đối tượng theo giá!");
                }
                //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_DateOfApplication))))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_DateOfApplication, "Chưa gia hạn ngày áp dụng!");
                //}
                //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_DisparityPrice))))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_DateOfApplication, "Chưa nhập giá đóng chênh lệch!");
                //}
                if (e.Valid == true)
                {
                    ServicePriceInf inf = new ServicePriceInf();
                    inf.ServiceCode = this.serviceCode;// gridView_ServicePrice.GetRowCellValue(e.RowHandle, "ServiceCode").ToString();
                    if (gridView_ServicePrice.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.Rowid = decimal.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.Rowid = 0;
                    if (gridView_ServicePrice.GetRowCellValue(e.RowHandle, "UnitPrice").ToString() != "")
                        inf.UnitPrice = decimal.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "UnitPrice").ToString());
                    else
                        inf.UnitPrice = 0;
                    inf.ObjectCode = int.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "ObjectCode").ToString());
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DateOfApplication").ToString() != string.Empty)
                        inf.DateOfApplication = DateTime.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DateOfApplication").ToString());
                    else
                        inf.DateOfApplication = DateTime.Now.Date;
                    if (gridView_ServicePrice.GetRowCellValue(e.RowHandle, "Hide").ToString() != "")
                        inf.Hide = Int32.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    else
                        inf.Hide = 0;
                    inf.EmployeeCode = s_userid;
                    if (gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DisparityPrice").ToString() != string.Empty)
                        inf.DisparityPrice = decimal.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DisparityPrice").ToString());
                    else
                        inf.DisparityPrice = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "PerDiscountIntro").ToString() != string.Empty)
                        inf.PerDiscountIntro = Int32.Parse(this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "PerDiscountIntro").ToString());
                    else
                        inf.PerDiscountIntro = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DiscountIntro").ToString() != string.Empty)
                        inf.DiscountIntro = Convert.ToDecimal(this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DiscountIntro").ToString());
                    else
                        inf.DiscountIntro = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "PerDiscountDoctorDone").ToString() != string.Empty)
                        inf.PerDiscountDoctorDone = Int32.Parse(this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "PerDiscountDoctorDone").ToString());
                    else
                        inf.PerDiscountDoctorDone = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DiscountDoctorDone").ToString() != string.Empty)
                        inf.DiscountDoctorDone = Convert.ToDecimal(this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DiscountDoctorDone").ToString());
                    else
                        inf.DiscountDoctorDone = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "PerDiscountDoctor").ToString() != string.Empty)
                        inf.PerDiscountDoctor = Int32.Parse(this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "PerDiscountDoctor").ToString());
                    else
                        inf.PerDiscountDoctor = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DiscountDoctor").ToString() != string.Empty)
                        inf.DiscountDoctor = Convert.ToDecimal(this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DiscountDoctor").ToString());
                    else
                        inf.DiscountDoctor = 0;
                    if (this.gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DateOfApplicationEnd").ToString() != string.Empty)
                        inf.DateOfApplicationEnd = DateTime.Parse(gridView_ServicePrice.GetRowCellValue(e.RowHandle, "DateOfApplicationEnd").ToString());
                    else
                        inf.DateOfApplicationEnd = DateTime.Now.Date.AddDays(30);
                    if (e.RowHandle < 0)
                    {
                        if (ServicePriceBLL.InsServicePrice(inf) == 1)
                        {
                            XtraMessageBox.Show("Khai báo thành công giá viện phí!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Viện phí đã thêm hoặc nhập chưa đủ thông tin!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (ServicePriceBLL.InsServicePrice(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công giá viện phí!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật giá viện phí không thành công!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    this.LoadDataPrice();
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_ServicePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_ServicePrice.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show(" Bạn có muốn xóa giá dịch vụ đang chọn hay không? ", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            decimal dRowID = Convert.ToDecimal(gridView_ServicePrice.GetRowCellValue(gridView_ServicePrice.FocusedRowHandle, "RowID").ToString());
                            if (ServicePriceBLL.DelServicePrice(dRowID) >= 1)
                                this.LoadDataPrice();
                            else
                            {
                                XtraMessageBox.Show(" Giá viện phí đã sử dụng không cho phép xóa !", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }

        private void tStripPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.rptDMDichVuGia rpt = new Reports.rptDMDichVuGia();
                rpt.DataSource = ServicePriceBLL.ListPrintMapService();
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch { }
        }
        
        private void gridView_Service_Click(object sender, EventArgs e)
        {
            try
            {
                this.serviceCode = this.gridView_Service.GetRowCellValue(this.gridView_Service.FocusedRowHandle, this.col_lst_ServiceCode).ToString();
                this.LoadDataPrice();
            }
            catch { }
        }

        private void gridView_ServicePrice_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "PerDiscountIntro")
                {
                    if (e.Value != null)
                    {
                        Int32 percent = Convert.ToInt32(e.Value);
                        decimal unitPrice = Convert.ToDecimal(Convert.ToString(view.GetFocusedRowCellValue("UnitPrice")));
                        view.SetFocusedRowCellValue(col_DiscountIntro, (unitPrice * percent) / 100);
                    }
                }
                if (view.FocusedColumn.FieldName == "PerDiscountDoctorDone")
                {
                    if (e.Value != null)
                    {
                        Int32 percent = Convert.ToInt32(e.Value);
                        decimal unitPrice = Convert.ToDecimal(Convert.ToString(view.GetFocusedRowCellValue("UnitPrice")));
                        view.SetFocusedRowCellValue(col_DiscountDoctorDone, (unitPrice * percent) / 100);
                    }
                }
                if (view.FocusedColumn.FieldName == "PerDiscountDoctor")
                {
                    if (e.Value != null)
                    {
                        Int32 percent = Convert.ToInt32(e.Value);
                        decimal unitPrice = Convert.ToDecimal(Convert.ToString(view.GetFocusedRowCellValue("UnitPrice")));
                        view.SetFocusedRowCellValue(col_DiscountDoctor, (unitPrice * percent) / 100);
                    }
                }
            }
            catch { return; }
        }

        private void toolbtnRefesh_Click(object sender, EventArgs e)
        {
            this.serviceCode = string.Empty;
            this.gridControl_ServicePrice.DataSource = null;
            this.LoadDataService();
        }
    }
}