using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Linq;
using System.Linq;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Master
{
    public partial class frmThuoc : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string codeTemp = string.Empty; 
        private string sUserid = string.Empty;
        private bool bHide = false;
        public frmThuoc(string _Userid)
        {
            InitializeComponent();
            this.sUserid = _Userid;
        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            try
            {
                this.rep_Check_RepositoryCode.DataSource = RepositoryCatalog_BLL.ListRepository(0);
                this.rep_Check_RepositoryCode.DisplayMember = "RepositoryName";
                this.rep_Check_RepositoryCode.ValueMember = "RepositoryCode";
                this.ItemGridLookUpEdit_Usage.DataSource = UsageBLL.ListUsage(string.Empty);
                this.ItemGridLookUpEdit_Usage.DisplayMember = "UsageName";
                this.ItemGridLookUpEdit_Usage.ValueMember = "UsageCode";

                List < UnitOfMeasureInf > lstUnit = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.ItemGridLookUpEdit_UoM.DataSource = lstUnit;
                this.ItemGridLookUpEdit_UoM.DisplayMember = "UnitOfMeasureName";
                this.ItemGridLookUpEdit_UoM.ValueMember = "UnitOfMeasureCode";

                this.ItemGridLookUpEdit_Packed.DataSource = lstUnit;
                this.ItemGridLookUpEdit_Packed.DisplayMember = "UnitOfMeasureName";
                this.ItemGridLookUpEdit_Packed.ValueMember = "UnitOfMeasureName";

                this.repSlkup_UnitOfMeasureCode_Medi.DataSource = lstUnit;
                this.repSlkup_UnitOfMeasureCode_Medi.DisplayMember = "UnitOfMeasureName";
                this.repSlkup_UnitOfMeasureCode_Medi.ValueMember = "UnitOfMeasureCode";

                this.ItemGridLookUpEdit_Item_Category.DataSource = ItemCategoryBLL.ListItemCategory(string.Empty);
                this.ItemGridLookUpEdit_Item_Category.DisplayMember = "ItemCategoryName";
                this.ItemGridLookUpEdit_Item_Category.ValueMember = "ItemCategoryCode";
                this.repSearch_Country.DataSource = CountryBLL.DTCountry(string.Empty);
                this.repSearch_Country.DisplayMember = "CountryName";
                this.repSearch_Country.ValueMember = "CountryCode";
                this.repSearch_Producer.DataSource = Producer_BLL.DTProducer(string.Empty);
                this.repSearch_Producer.DisplayMember = "ProducerName";
                this.repSearch_Producer.ValueMember = "ProducerCode";
                this.rep_Check_VendorCode.DataSource = VendorBLL.DTVendorList(string.Empty);
                this.rep_Check_VendorCode.DisplayMember = "VendorName";
                this.rep_Check_VendorCode.ValueMember = "VendorCode";

                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(209);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        bHide = true;
                }
                this.repLkup_VEN.DataSource = Ven_AnalistBLL.DataVen();
                this.repLkup_VEN.ValueMember = "VENCode";
                this.repLkup_VEN.DisplayMember = "VENName";
                
                this.repLKupItems_BHYT.DataSource = ItemsBLL.ListItemsBHYT();
                this.repLKupItems_BHYT.DisplayMember = "SO_DANG_KY";
                this.repLKupItems_BHYT.ValueMember = "SO_DANG_KY";

                this.LoadDataItem();

                //this.repSchLKup_ActiveBHYT.DataSource = ItemsBLL.TableActive_BHYT();
                //this.repSchLKup_ActiveBHYT.ValueMember = "Active_Code";
                //this.repSchLKup_ActiveBHYT.DisplayMember = "Active_Code";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_Item_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo tên thuốc-vtyt !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Item_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 status = 0;
                if (e.RowHandle >= 0)
                {
                    status = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status"]));
                    if (status == 1)
                    {
                        e.Appearance.ForeColor = Color.Red;
                        //View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private decimal ISDBNULL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }

        private void gridView_Item_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ItemName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ItemName, "Nhập tên thuốc !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_UsageCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_UsageCode, "Chọn đường dùng!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitOfMeasureCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_UnitOfMeasureCode, "Chọn đơn vị tính !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ItemCategoryCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ItemCategoryCode, "Chọn phân nhóm thuốc-vtyt !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RepositoryCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RepositoryCode, " Chọn kho !");
                }
                //if (Convert.ToString(view.GetRowCellValue(rowfocus, col_CountryCode)).ToString() == string.Empty)
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_CountryCode, " Chọn nước sản xuất !");
                //}
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ProducerCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ProducerCode, " Chọn hãng sản xuất !");
                }
                if (e.Valid)
                {
                    Items_Ins model = new Items_Ins();
                    if (gridView_Item.GetRowCellValue(e.RowHandle, "ItemCode") != null)
                        model.ItemCode = gridView_Item.GetRowCellValue(e.RowHandle, "ItemCode").ToString();
                    else
                        model.ItemCode = string.Empty;
                    model.ItemName = Utils.ToUpperCharacterFisrt(this.gridView_Item.GetRowCellValue(e.RowHandle, "ItemName").ToString());
                    model.ItemContent = this.gridView_Item.GetRowCellValue(e.RowHandle, "ItemContent").ToString();
                    model.Active = Utils.ToUpperCharacterFisrt(gridView_Item.GetRowCellValue(e.RowHandle, "Active").ToString());
                    model.UsageCode = gridView_Item.GetRowCellValue(e.RowHandle, "UsageCode").ToString();
                    model.Packed = gridView_Item.GetRowCellValue(e.RowHandle, "Packed").ToString();

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "QtyOfMeasure").ToString()))
                        model.QtyOfMeasure = Convert.ToInt32(gridView_Item.GetRowCellValue(e.RowHandle, "QtyOfMeasure"));
                    else
                        model.QtyOfMeasure = 1;
                    model.UnitOfMeasureCode = gridView_Item.GetRowCellValue(e.RowHandle, "UnitOfMeasureCode").ToString();
                    model.ItemCategoryCode = gridView_Item.GetRowCellValue(e.RowHandle, "ItemCategoryCode").ToString();

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "UnitPrice").ToString()))
                        model.UnitPrice = Convert.ToDecimal(gridView_Item.GetRowCellValue(e.RowHandle, "UnitPrice"));
                    else
                        model.UnitPrice = 0;

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "Status").ToString()))
                        model.Status = Convert.ToInt32(gridView_Item.GetRowCellValue(e.RowHandle, "Status"));
                    else
                        model.Status = 0;

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "SalesPrice").ToString()))
                        model.SalesPrice = Convert.ToDecimal(gridView_Item.GetRowCellValue(e.RowHandle, "SalesPrice"));
                    else
                        model.SalesPrice = 0;

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "SafelyQuantity").ToString()))
                        model.SafelyQuantity = Convert.ToInt32(gridView_Item.GetRowCellValue(e.RowHandle, "SafelyQuantity"));
                    else
                        model.SafelyQuantity = 0;

                    model.RepositoryCode = gridView_Item.GetRowCellValue(e.RowHandle, "RepositoryCode").ToString();
                    model.EmployeeCode = sUserid;
                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "ListBHYT").ToString()))
                        model.ListBHYT = Convert.ToInt32(gridView_Item.GetRowCellValue(e.RowHandle, "ListBHYT").ToString());
                    else
                        model.ListBHYT = 0;

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "BHYTPrice").ToString()))
                        model.BHYTPrice = Convert.ToDecimal(gridView_Item.GetRowCellValue(e.RowHandle, "BHYTPrice"));
                    else
                        model.BHYTPrice = 0;

                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "RateBHYT").ToString()))
                        model.RateBHYT = Convert.ToInt32(gridView_Item.GetRowCellValue(e.RowHandle, "RateBHYT"));
                    else
                        model.RateBHYT = 0;
                    if (!string.IsNullOrEmpty(this.gridView_Item.GetRowCellValue(e.RowHandle, "ListService").ToString()))
                        model.ListService = Convert.ToInt32(gridView_Item.GetRowCellValue(e.RowHandle, "ListService"));
                    else
                        model.ListService = 0;

                    model.CountryCode = "NSX001";/// gridView_Item.GetRowCellValue(e.RowHandle, "CountryCode").ToString();
                    model.ProducerCode = gridView_Item.GetRowCellValue(e.RowHandle, "ProducerCode").ToString();
                    model.Note = gridView_Item.GetRowCellValue(e.RowHandle, "Note").ToString();
                    if (!string.IsNullOrEmpty(this.gridView_Item.GetRowCellValue(e.RowHandle, "DisparityPrice").ToString().Trim()))
                        model.DisparityPrice = Convert.ToDecimal(this.gridView_Item.GetRowCellValue(e.RowHandle, "DisparityPrice"));
                    else
                        model.DisparityPrice = 0;
                    model.VendorCode = this.gridView_Item.GetRowCellValue(e.RowHandle, "VendorCode").ToString();
                    model.STTBCBHYT = this.gridView_Item.GetRowCellValue(e.RowHandle, "STTBCBHYT").ToString();
                    model.SODKGP = this.gridView_Item.GetRowCellValue(e.RowHandle, "SODKGP").ToString();
                    model.STTQDPK = this.gridView_Item.GetRowCellValue(e.RowHandle, "STTQDPK").ToString();
                    model.QUYCACH = this.gridView_Item.GetRowCellValue(e.RowHandle, "QUYCACH").ToString();
                    model.Generic_BD = this.gridView_Item.GetRowCellValue(e.RowHandle, "Generic_BD").ToString();
                    model.VENCode = this.gridView_Item.GetRowCellValue(e.RowHandle, "VENCode").ToString();
                    model.Active_TT40 = this.gridView_Item.GetRowCellValue(e.RowHandle, "Active_TT40").ToString();
                    if (!string.IsNullOrEmpty(gridView_Item.GetRowCellValue(e.RowHandle, "SalesPrice_Retail").ToString()))
                        model.SalesPrice_Retail = Convert.ToDecimal(gridView_Item.GetRowCellValue(e.RowHandle, "SalesPrice_Retail"));
                    else
                        model.SalesPrice_Retail = 0;
                    model.UnitOfMeasureCode_Medi = this.gridView_Item.GetRowCellValue(e.RowHandle, "UnitOfMeasureCode_Medi").ToString();
                    model.Converted_Medi = gridView_Item.GetRowCellValue(e.RowHandle, "Converted_Medi").ToString() == "True" ? true : false;
                    if (e.RowHandle < 0)
                    {
                        model.udate = model.idate = Utils.DateTimeServer();
                        if (ItemsBLL.Ins(model) == 1)
                        {
                            XtraMessageBox.Show("Thêm thuốc mới thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thuốc mới không thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.gridView_Item.DeleteRow(rowfocus);
                        }
                        this.LoadDataItem();
                    }
                    else
                    {
                        model.udate = DateTime.Now;
                        if (ItemsBLL.Ins(model) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thuốc " + model.ItemName + " thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thuốc " + model.ItemName + " thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        this.LoadDataItem();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadDataItem()
        {
            if (this.bHide)
            {
                this.gridControl_Item.DataSource = Utils.ListToDataTable(ItemsBLL.ListItems(-1));
                this.chkHide.Enabled = false;
            }
            else
            {
                this.gridControl_Item.DataSource = Utils.ListToDataTable(ItemsBLL.ListItems(this.chkHide.Checked ? 1 : 0));
                this.chkHide.Enabled = true;
            }
        }

        private void gridControl_Item_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Item.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa thuốc-vtyt đang chọn hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    string itemCode = gridView_Item.GetRowCellValue(gridView_Item.FocusedRowHandle, "ItemCode").ToString();
                    string itemNameTemp = gridView_Item.GetRowCellValue(gridView_Item.FocusedRowHandle, "ItemName").ToString();
                    if (ItemsBLL.Del(itemCode) >= 1)
                        this.LoadDataItem();
                    else
                    {
                        XtraMessageBox.Show("Thuốc-vtyt : " + itemNameTemp.ToUpper() + " đã sử dụng không cho phép xóa !", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtResult = ItemsBLL.TablePrintItem(this.chkHide.Checked ? 1 : 0);
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptDMThuoc.xml");
                Reports.rptDMThuoc rptShow = new Reports.rptDMThuoc();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DMThuoc","Danh mục thuốc");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnInGird_Click(object sender, EventArgs e)
        {
            this.gridControl_Item.ShowPrintPreview();
        }

        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHide.Checked)
                this.chkHide.Text = "DM không dùng";
            else
                this.chkHide.Text = "DM đang dùng";
            this.LoadDataItem();
        }
    }
}