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
using ClinicBLL;
using ClinicModel;
using ClinicLibrary;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
namespace Ps.Clinic.Master
{
    public partial class frmDMGoi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string packageCode = string.Empty, s_userid = string.Empty;
        private DataTable dtsvice = new DataTable();
        private DataTable dtPackageDetail = new DataTable();
        public frmDMGoi(string _userid)
        {
            InitializeComponent();
            this.s_userid = _userid;
        }

        private void frmDMGoi_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadPackage();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadPackage()
        {
            this.dtsvice = ServiceBLL.DTServiceReal();
            this.gridControl_List.DataSource = ServicePackageBLL.DTServicePackage(string.Empty);
        }

        private void gridView_List_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo gói!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_List_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ServicePackageName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ServicePackageName, "Hãy nhập tên gói!");
                }
                if (e.Valid)
                {
                    ServicePackageInf inf = new ServicePackageInf();
                    inf.ServicePackageCode = gridView_List.GetRowCellValue(e.RowHandle, "ServicePackageCode").ToString();
                    inf.ServicePackageName = gridView_List.GetRowCellValue(e.RowHandle, "ServicePackageName").ToString();
                    inf.EmployeeCode = s_userid;
                    if (e.RowHandle < 0)
                    {
                        if (ServicePackageBLL.InsServicePackage(inf) == 1)
                        {
                            XtraMessageBox.Show("Khai báo gói thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Khai báo gói thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (ServicePackageBLL.InsServicePackage(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật lại gói thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật lại gói thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                this.gridControl_List.DataSource = ServicePackageBLL.DTServicePackage(string.Empty);
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void gridView_Package_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Chưa chọn viện phí khi khai báo chi tiết gói!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Package_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, coldetail_ServiceCode))))
                {
                    e.Valid = false;
                    view.SetColumnError(coldetail_ServiceCode, "Chọn viện phí!");
                }
                if (string.IsNullOrEmpty(packageCode))
                {
                    e.Valid = false;
                    view.SetColumnError(coldetail_ServiceCode, "Chưa chọn gói khai báo!");
                }
                if (e.Valid)
                {
                    ServicePackageDetailInf inf = new ServicePackageDetailInf();
                    inf.ServicePackageCode = packageCode;
                    inf.ServiceCode = gridView_Package_Detail.GetRowCellValue(e.RowHandle, "ServiceCode").ToString();
                    inf.EmployeeCode = s_userid;
                    if (gridView_Package_Detail.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = decimal.Parse(gridView_Package_Detail.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    if (gridView_Package_Detail.GetRowCellValue(e.RowHandle, "Serial").ToString() != "")
                        inf.Serial = Convert.ToInt32(gridView_Package_Detail.GetRowCellValue(e.RowHandle, "Serial").ToString());
                    else
                        inf.Serial = 1;
                    if (this.gridView_Package_Detail.GetRowCellValue(e.RowHandle, "ServicePrice").ToString() != string.Empty)
                        inf.ServicePrice = decimal.Parse(gridView_Package_Detail.GetRowCellValue(e.RowHandle, "ServicePrice").ToString());
                    else
                        inf.ServicePrice = 0;
                    if (e.RowHandle < 0)
                    {
                        if (ServicePackageDetailBLL.InsServicePackageDetail(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm chi tiết gói thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.gridControl_Package_Detail.DataSource = ServicePackageDetailBLL.DTServicePackage(packageCode);
                        }
                        else
                        {
                            XtraMessageBox.Show("Chưa thêm được dịch vụ vào chi tiết gói, Dịch vụ có thể đã thêm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.gridView_Package_Detail.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (ServicePackageDetailBLL.InsServicePackageDetail(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật chi tiết gói thành công!", "Bệnh viện điện tử .NET");
                            this.gridControl_Package_Detail.DataSource = ServicePackageDetailBLL.DTServicePackage(packageCode);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thất bại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_List_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_List.RowCount > 0)
                {
                    if (this.gridView_List.GetFocusedRow() != null)
                    {
                        this.packageCode = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, this.col_ServicePackageCode).ToString();
                        if (packageCode == "" || packageCode == null)
                        {
                            XtraMessageBox.Show("Gói chưa khai báo!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            this.rep_Service.DataSource = this.dtsvice;
                            this.rep_Service.DisplayMember = "ServiceName";
                            this.rep_Service.ValueMember = "ServiceCode";
                            this.dtPackageDetail = ServicePackageDetailBLL.DTServicePackage(packageCode);
                            this.gridControl_Package_Detail.DataSource = this.dtPackageDetail;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridControl_List_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_List.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa gói khai báo này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (ServicePackageBLL.DelServicePackage(gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, "ServicePackageCode").ToString()) >= 1)
                        {
                            this.gridControl_Package_Detail.DataSource = null;
                            this.LoadPackage();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsxml = new DataSet();
                DataTable tbResult = ServicePackageDetailBLL.TablePackageDetail(this.packageCode);
                if (tbResult != null && tbResult.Rows.Count > 0)
                {
                    dsxml.Tables.Add(tbResult);
                    dsxml.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_DanhMucGoi.xml");
                    Reports.rptVP_DanhMucGoi rptShow = new Reports.rptVP_DanhMucGoi();
                    rptShow.DataSource = dsxml;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DMGoi","Danh mục gói");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsxml = new DataSet();
                DataTable tbResult = ServicePackageDetailBLL.TablePackageDetail(string.Empty);
                if (tbResult != null && tbResult.Rows.Count > 0)
                {
                    dsxml.Tables.Add(tbResult);
                    dsxml.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_DanhMucGoi.xml");
                    Reports.rptVP_DanhMucGoi rptShow = new Reports.rptVP_DanhMucGoi();
                    rptShow.DataSource = dsxml;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DMGoi","Danh mục gói");
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void rep_Service_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string servicecode = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceCode").ToString();
                DataRow r = Utils.GetPriceRowbyCode(this.dtPackageDetail, "ServiceCode='" + servicecode + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Dịch vụ đã tồn tại trong trong gói!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Package_Detail.SetFocusedRowCellValue(this.coldetail_ServiceCode, null);
                    this.gridView_Package_Detail.SetFocusedRowCellValue(this.coldetail_ServicePrice, 0);
                }
                else
                {
                    decimal unitprice = 0;
                    List<ServicePriceInf> list = ServicePriceBLL.ListServicePriceReal(servicecode, 2);
                    if (list != null && list.Count > 0)
                        unitprice = list[0].UnitPrice;
                    this.gridView_Package_Detail.SetFocusedRowCellValue(this.coldetail_ServicePrice, unitprice);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridControl_Package_Detail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Package_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa dịch vụ này trong gói đã khai báo?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (ServicePackageDetailBLL.DelServicePackageDetail(decimal.Parse(gridView_Package_Detail.GetRowCellValue(gridView_Package_Detail.FocusedRowHandle, "RowID").ToString())) == 1)
                            this.gridView_List_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }
    }
}