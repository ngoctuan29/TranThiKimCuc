using System;
using System.IO;
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
using Ps.Clinic.ViewPopup;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmVP_VTTHKemTheo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUserCode = string.Empty;
        private DataTable dtMedicalRecord_Material = new DataTable();
        private DateTime dtWorking = new DateTime();
        private string serviceCode = string.Empty;

        public frmVP_VTTHKemTheo(string _suserCode, string _serviceCode, DateTime _dtWorking)
        {
            InitializeComponent();
            this.sUserCode = _suserCode;
            this.serviceCode = _serviceCode;
            this.dtWorking = _dtWorking;
        }

        private void frmVP_VTTHKemTheo_Load(object sender, EventArgs e)
        {
            try
            {
                this.ref_Material_UoM.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.ref_Material_UoM.DisplayMember = "UnitOfMeasureName";
                this.ref_Material_UoM.ValueMember = "UnitOfMeasureCode";

                this.ref_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.ref_ObjectCode.DisplayMember = "ObjectName";
                this.ref_ObjectCode.ValueMember = "ObjectCode";

                this.repMaterial_Usage.DataSource = UsageBLL.ListUsage(string.Empty);
                this.repMaterial_Usage.DisplayMember = "UsageName";
                this.repMaterial_Usage.ValueMember = "UsageCode";
                
                this.repsearchMaterial_Item.DataSource = ItemsBLL.ListItemsRef(-1);
                this.repsearchMaterial_Item.DisplayMember = "ItemName";
                this.repsearchMaterial_Item.ValueMember = "ItemCode";

                this.gridView_Material.OptionsBehavior.ReadOnly = true;
                this.gridView_Material.OptionsBehavior.Editable = false;
                this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.GetDataServiceItems();
                if (this.dtMedicalRecord_Material.Rows.Count > 0 && this.dtMedicalRecord_Material != null)
                    this.butNew.Enabled = this.butSave.Enabled = this.butCancel.Enabled = false;

                else
                    this.EnableButton(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butSave.Enabled = !b;
            this.butCancel.Enabled = false;
            this.butEdit.Enabled = false;
        }

        private void frmVP_VTTHKemTheo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2: butNew_Click(sender, e); break;                //F2 - Moi
                case Keys.F3: butSave_Click(sender, e); break;               //F3 - Lưu
            }
        }
                
        private void GetDataServiceItems()
        {
            this.dtMedicalRecord_Material = Utils.ListToDataTable(ServiceBLL.ListViewServiceItemAttach(this.serviceCode));
            this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            this.butSave.Enabled = this.butCancel.Enabled = true;
            this.butNew.Enabled = this.butEdit.Enabled = false;
            this.gridView_Material.OptionsBehavior.ReadOnly = false;
            this.gridView_Material.OptionsBehavior.Editable = true;
            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }
        
        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtMedicalRecord_Material.Rows.Count > 0)
                {
                    int stt = 1;
                    bool isSuccess = true;
                    foreach (DataRow row in this.dtMedicalRecord_Material.Rows)
                    {
                        Service_Item_AttachInf inf = new Service_Item_AttachInf { ServiceCode = this.serviceCode, ItemCode = row["ItemCode"].ToString(), ObjectCode = Convert.ToInt32(row["ObjectCode"].ToString()), Quantity = Convert.ToDecimal(row["Quantity"].ToString()), EmployeeCode = this.sUserCode, STT=stt, Note = row["Note"].ToString() };
                        if (ServiceBLL.InsServiceItemAttach(inf) <= 0)
                        {
                            isSuccess = false;
                            XtraMessageBox.Show("Lưu không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ServiceBLL.DelServiceItemAttachAll(this.serviceCode);
                            break;
                        }
                        stt++;
                    }
                    if(isSuccess)
                    {
                        this.gridView_Material.OptionsBehavior.ReadOnly = true;
                        this.gridView_Material.OptionsBehavior.Editable = false;
                        this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        this.butCancel.Enabled = this.butEdit.Enabled = true;
                        this.butSave.Enabled = this.butNew.Enabled = false;
                        ServiceBLL.UpdServiceItemAttach(true, this.serviceCode);
                        XtraMessageBox.Show("Lưu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.GetDataServiceItems();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Không có thuốc phát sinh! Hãy nhập thuốc trước khi lưu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

        private void gridView_Material_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            int rowfocus = e.RowHandle;
            try
            {
                string stempItemcode = view.GetRowCellValue(rowfocus, col_Material_ItemCode).ToString();
                if (stempItemcode == null || stempItemcode == "")
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Material_ItemCode, " Chọn Thuốc, VTTH kèm theo dịch vụ!");
                }
                if (this.ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Material_Quantity, " Số lượng yêu cầu lớn hơn 0!");
                }
                if (e.Valid)
                {
                    //decimal unitPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_UnitPrice));
                    //decimal salesPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_SalesPrice));
                    //decimal bhytPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_BHYTPrice));
                    //decimal quantityTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_Quantity));
                    //Int32 listBHYTTemp = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Material_ListBHYT));
                    //if (this.iObjectCode.Equals(1) || this.iObjectCode.Equals(5))
                    //{
                    //    if (listBHYTTemp.Equals(1))
                    //        this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * bhytPriceTemp);
                    //    else
                    //        this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * salesPriceTemp);
                    //}
                    //else
                    //    this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * salesPriceTemp);
                }
            }
            catch { return; }
        }

        private void gridView_Material_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Quantity")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }   
        }

        private void gridView_Material_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa thuốc - vtth đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        string tempItemCode = this.gridView_Material.GetRowCellValue(this.gridView_Material.FocusedRowHandle, this.col_Material_ItemCode).ToString();
                        if (!string.IsNullOrEmpty(tempItemCode))
                        {
                            if (ServiceBLL.DelServiceItemAttachAll(this.serviceCode, tempItemCode) > 0)
                            {
                                this.GetDataServiceItems();
                                if (this.dtMedicalRecord_Material.Rows.Count <= 0)
                                    ServiceBLL.UpdServiceItemAttach(false, this.serviceCode);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Vui lòng chọn thuốc - vtth để xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Material_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Phiếu xuất thuốc thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }
        
        private void butExit_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn hủy tất cả Thuốc - VTTH ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    bool isScuccess = true;
                    string itemcodeTemp = string.Empty;
                    foreach (DataRow row in dtMedicalRecord_Material.Rows)
                    {
                        if (ServiceBLL.DelServiceItemAttachAll(this.serviceCode, row["ItemCode"].ToString()) < 0)
                        {
                            isScuccess = false;
                            itemcodeTemp = row["ItemCode"].ToString();
                            break;
                        }
                    }
                    if (isScuccess)
                    {
                        this.gridView_Material.OptionsBehavior.ReadOnly = true;
                        this.gridView_Material.OptionsBehavior.Editable = false;
                        this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        ServiceBLL.UpdServiceItemAttach(false, this.serviceCode);
                        XtraMessageBox.Show(" Hủy Thuốc - VTTH thành công !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.EnableButton(true);
                        this.GetDataServiceItems();
                    }
                    else
                        XtraMessageBox.Show(" Hủy Thuốc - VTTH: " + itemcodeTemp + " không thành công !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void repsearchMaterial_Item_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string itemCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemCode").ToString();
                string activeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active").ToString();
                string unitOfMeasureCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode").ToString();
                string usageCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UsageCode").ToString();
                DataRow r = Utils.GetPriceRowbyCode(this.dtMedicalRecord_Material, "ItemCode='" + itemCodeTemp + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê khai.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, null);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 0);
                }
                else
                {
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, 5);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_Usage, usageCodeTemp);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butNew_Click(object sender, EventArgs e)
        {
            this.gridView_Material.OptionsBehavior.ReadOnly = false;
            this.gridView_Material.OptionsBehavior.Editable = true;
            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.EnableButton(false);
        }
        
    }
}