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
using DevExpress.XtraGrid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmDanhMucVTTH : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUser = "";
        private string sServiceCode = string.Empty;
        private DataTable dtDetail = new DataTable();
        public frmDanhMucVTTH(string _User)
        {
            InitializeComponent();
            sUser = _User;
        }

        private void frmDanhMucVTTH_Load(object sender, EventArgs e)
        {
            rep_UoM.DataSource = UnitOfMeasureBLL.DTUnit("","I");
            rep_UoM.DisplayMember = "UnitOfMeasureName";
            rep_UoM.ValueMember = "UnitOfMeasureCode";

            ref_Item.DataSource = ItemsBLL.ListItems(0);
            ref_Item.DisplayMember = "ItemName";
            ref_Item.ValueMember = "ItemCode";
            List<ServiceFullNameInf> lstTemp = new List<ServiceFullNameInf>();
            lstTemp = ServiceBLL.ListServiceRealFullName().Where(p => p.ServiceGroupCode.Equals("XN")).ToList();
            gridControl_Service.DataSource = lstTemp.Select(p => new { p.ServiceCode, p.ServiceName, p.ServiceGroupName, p.ServiceCategoryName }).ToList();
            gridView_Service.Columns["ServiceGroupName"].Group();
            gridView_Service.Columns["ServiceCategoryName"].Group();
            floadDetail();
        }

        private void floadDetail()
        {
            dtDetail = TemplateItemNormsBLL.dtItemNormsDetail(sServiceCode);
            gridControl_Detail.DataSource = dtDetail;
        }

        private void gridView_Service_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_Service.RowCount > 0)
                {
                    if (gridView_Service.GetFocusedRow() != null)
                    {
                        sServiceCode = gridView_Service.GetRowCellValue(gridView_Service.FocusedRowHandle, col_lst_ServiceCode).ToString();
                        floadDetail();
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
            catch
            {
                return;
            }
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (sServiceCode == string.Empty)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(" Chưa chọn dịch vụ khai bóa định mức thuốc-VTTH!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (view.GetRowCellValue(rowfocus, col_tem_ItemCode).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_tem_ItemCode, " Chọn thuốc, VTTH để khai báo định mức!");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_tem_Quantity, "Số lượng yêu cầu lớn hơn 0 !");
                }
                if (e.Valid)
                {
                    decimal dQuantity = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_Quantity));
                    TemplateItemNormsInf obj = new TemplateItemNormsInf();
                    obj.NormsCode = "";
                    obj.ServiceCode = sServiceCode;
                    obj.EmployeeCode = sUser;
                    obj.EmployeeCodeUpd = sUser;
                    string srefCode = string.Empty;
                    if (e.RowHandle < 0)
                    {
                        if (TemplateItemNormsBLL.Ins(obj, ref srefCode) == 1)
                        {
                            TemplateItemNormsDetailInf objdetail = new TemplateItemNormsDetailInf();
                            if (view.GetRowCellValue(rowfocus, col_tem_RowID).ToString() != string.Empty)
                                objdetail.RowID = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_RowID));
                            else
                                objdetail.RowID = 0;
                            objdetail.NormsCode = srefCode;
                            objdetail.ItemCode = view.GetRowCellValue(rowfocus, col_tem_ItemCode).ToString();
                            objdetail.Quantity = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_Quantity));
                            objdetail.UnitPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_UnitPrice));
                            objdetail.SalesPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_SalesPrice));
                            objdetail.BHYTPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_BHYTPrice));
                            objdetail.Instruction = view.GetRowCellValue(rowfocus, col_tem_Instruction).ToString();
                            TemplateItemNormsBLL.InsDetail(objdetail);
                            XtraMessageBox.Show(" Khai báo thành công định mức thuốc - VTTH!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khai báo không thành công định mức thuốc - VTTH?", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (TemplateItemNormsBLL.Ins(obj, ref srefCode) == 1)
                        {
                            TemplateItemNormsDetailInf objdetail = new TemplateItemNormsDetailInf();
                            objdetail.RowID = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_RowID));
                            objdetail.NormsCode = srefCode;
                            objdetail.ItemCode = view.GetRowCellValue(rowfocus, col_tem_ItemCode).ToString();
                            objdetail.Quantity = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_Quantity));
                            objdetail.UnitPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_UnitPrice));
                            objdetail.SalesPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_SalesPrice));
                            objdetail.BHYTPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_tem_BHYTPrice));
                            objdetail.Instruction = view.GetRowCellValue(rowfocus, col_tem_Instruction).ToString();
                            TemplateItemNormsBLL.InsDetail(objdetail);
                            XtraMessageBox.Show(" Cập nhật thành công định mức thuốc - VTTH!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show(" Cập nhật không thành công định mức thuốc - VTTH!", "Bệnh viện điện tử .NET");
                        }
                    }
                    floadDetail();
                }
            }
            catch { }
        }

        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }

        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = " Chi tiết định mức thuốc - VTTH khai thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n "; 
        }

        private void ref_Item_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LookUpEdit LEdit = sender as LookUpEdit;
                string stemp = LEdit.GetColumnValue("ItemName").ToString();
                DataRow r = Utils.GetPriceRowbyCode(dtDetail, "ItemCode='" + LEdit.GetColumnValue("ItemCode").ToString() + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc -VTTH đã có trong phiếu định mức!", "Bệnh viện điện tử .NET");
                    return;
                }
                else
                {
                    gridView_Detail.SetFocusedRowCellValue(col_tem_UnitOfMeasureCode, LEdit.GetColumnValue("UnitOfMeasureCode"));
                    gridView_Detail.SetFocusedRowCellValue(col_tem_Quantity, 0);
                    gridView_Detail.SetFocusedRowCellValue(col_tem_SalesPrice, LEdit.GetColumnValue("SalesPrice"));
                    gridView_Detail.SetFocusedRowCellValue(col_tem_UnitPrice, LEdit.GetColumnValue("UnitPrice"));
                    gridView_Detail.SetFocusedRowCellValue(col_tem_BHYTPrice, LEdit.GetColumnValue("BHYTPrice"));
                    gridView_Detail.SetFocusedRowCellValue(col_tem_Instruction, "");
                }
                gridControl_Detail.DataSource = dtDetail;
            }
            catch { }
        }

        private void gridView_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show(" Bạn thật sự muốn xóa thuốc - VTTH này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        decimal dRowID = Convert.ToDecimal(gridView_Detail.GetRowCellValue(gridView_Detail.FocusedRowHandle, col_tem_RowID).ToString());
                        Int32 iresult = TemplateItemNormsBLL.DelDetail(sServiceCode, dRowID);
                        if (iresult == 1)
                        {
                            floadDetail();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Xóa không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi xóa thuốc", "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void gridView_Service_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (sServiceCode != string.Empty)
                    {
                        if (XtraMessageBox.Show(" Bạn thật sự muốn xóa định mức thuốc - VTTH của dịch vụ này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            Int32 iresult = TemplateItemNormsBLL.Del(sServiceCode);
                            if (iresult == 1)
                            {
                                floadDetail();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Xóa không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Vui lòng chọn dịch vụ để xóa định mức thuốc - VTTH.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi xóa thuốc", "Bệnh viện điện tử .NET");
                return;
            }
        }


    }
}