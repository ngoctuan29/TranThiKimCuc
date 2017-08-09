using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraCharts;
using System.Reflection;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_ThongKeDoanhThu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string groupCode = string.Empty;
        private string cateCode = string.Empty;
        private DataTable dtTH = new DataTable();
        private DataTable dtResultDetail = new DataTable();
        private string employeeCode = string.Empty;
        private DateTime dtWorking = new DateTime();

        private Excel.Application oxl;
        private Excel._Workbook owb;
        private Excel._Worksheet osheet;
        private Excel.Range orange;

        public frmBaoCao_ThongKeDoanhThu(string _employeeCode, DateTime _dtWorking)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.dtWorking = _dtWorking;
        }

        private void frmBaoCao_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup(string.Empty);//.FindAll(x => x.ServiceModuleCode != "THUOC");
                this.cbGroup.Properties.DataSource = lstGroup;
                this.cbGroup.Properties.ValueMember = "ServiceGroupCode";
                this.cbGroup.Properties.DisplayMember = "ServiceGroupName";
                this.butPrint.Enabled = this.butPrintGrid.Enabled = this.btnExcel.Enabled = false;
            }
            catch { }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceCode = string.Empty;
                foreach (ServiceInf inf in this.chkList_Service.CheckedItems)
                {
                    serviceCode += inf.ServiceCode + ",";
                }
                if (this.cbList.Checked == true)
                {
                    this.dtTH = BanksAccountBLL.DT_StatisticBankTotal(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.groupCode.Replace("'", "").TrimEnd(','), this.cateCode.Replace("'", "").TrimEnd(','), serviceCode);
                    this.gridControl_List.DataSource = dtTH;
                }
                if (this.cbDetail.Checked == true)
                {
                    this.dtResultDetail = BanksAccountBLL.TableStatisticBankDetail(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.groupCode.Replace("'", "").TrimEnd(','), this.cateCode.Replace("'", "").TrimEnd(','), this.employeeCode, serviceCode);
                    this.gridControl_result.DataSource = this.dtResultDetail;
                    this.gridView_result.Columns["GroupName"].Group();
                    this.gridView_result.Columns["CategoryName"].Group();
                }
                if (this.cbBI.Checked == true)
                {
                    this.rptChartForDate();
                    this.rptChartForMonth();
                }
                if ((this.dtTH != null && this.dtTH.Rows.Count > 0) || (this.dtResultDetail != null && this.dtResultDetail.Rows.Count > 0))
                    this.butPrint.Enabled = this.butPrintGrid.Enabled = this.btnExcel.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbList.Checked)
                {
                    DataSet dsTemp = new DataSet("table");
                    dsTemp.Merge(dtTH);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_VP_TKeDoanhThuTH.xml");
                    Reports.rpt_VP_TKeDoanhThuTH rptShow = new Reports.rpt_VP_TKeDoanhThuTH();
                    rptShow.Parameters["title"].Value = "BẢNG KÊ TIỀN DỊCH VỤ, THUỐC TRONG NGÀY";
                    rptShow.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                    rptShow.Parameters["todate"].Value = dllNgay.denngay.Text;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BẢNG KÊ TIỀN DỊCH VỤ, THUỐC TRONG NGÀY", "BẢNG KÊ TIỀN DỊCH VỤ, THUỐC TRONG NGÀY");
                    rpt.ShowDialog();
                }
                else if (cbDetail.Checked)
                {
                    DataSet dsTemp = new DataSet("table");
                    dsTemp.Merge(dtResultDetail);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_VP_TKeDoanhThuCT.xml");
                    Reports.rpt_VP_TKeDoanhThuCT rptShow = new Reports.rpt_VP_TKeDoanhThuCT();
                    rptShow.Parameters["title"].Value = "BÁO CÁO CHI TIẾT DOANH THU";
                    rptShow.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                    rptShow.Parameters["todate"].Value = dllNgay.denngay.Text;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BÁO CÁO CHI TIẾT DOANH THU","Báo cáo chi tiết doanh thu");
                    rpt.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbDetail_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 1;
        }

        private void cbList_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 0;
        }

        private void cbBI_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 2;
        }

        private void rptChartForDate()
        {
            DataTable dt = rpt_Banking_BLL.DT_Chart_DoanhThuNgay(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text);
            this.chartforDate.DataSource = dt;
            this.chartforDate.Series[0].ArgumentDataMember = "PostingDate";
            this.chartforDate.Series[0].ValueDataMembers.AddRange(new string[] { "TotalReal" });
            this.chartforDate.Series[0].ValueScaleType = ScaleType.Numerical;
        }

        private void rptChartForMonth()
        {
            try
            {
                chartforMonth.Series.Clear();
                DataTable dtChart = new DataTable("result");
                dtChart = rpt_Banking_BLL.DT_Chart_DoanhThuThang();
                chartforMonth.DataSource = dtChart;
                Series series1 = new Series("Biểu đồ thống kê", ViewType.Bar);
                chartforMonth.Series.Add(series1);
                series1.ArgumentDataMember = "MM";
                series1.ValueDataMembers.AddRange(new string[] { "TotalReal" });
                ((BarSeriesView)series1.View).ColorEach = true;
                series1.LegendPointOptions.Pattern = "{A}";

            }
            catch { }
        }

        private void cbGroup_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.groupCode = string.Empty;
                string tempCode = cbGroup.EditValue.ToString();
                string[] arrGroup;
                if (tempCode.Trim() != string.Empty)
                {
                    arrGroup = tempCode.Split(',');
                    for (Int32 i = 0; i < arrGroup.Length; i++)
                    {
                        this.groupCode += "'" + arrGroup.GetValue(i).ToString().Trim(' ') + "',";
                    }
                    this.cbCategory.Properties.DataSource = rpt_Banking_BLL.rptListCategoryGeneral(this.groupCode.TrimEnd(','));
                    this.cbCategory.Properties.ValueMember = "ServiceCategoryCode";
                    this.cbCategory.Properties.DisplayMember = "ServiceCategoryName";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrintGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbList.Checked)
                {
                    this.gridControl_List.ShowRibbonPrintPreview();
                }
                else if (cbDetail.Checked)
                {
                    this.gridControl_result.ShowRibbonPrintPreview();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbCategory_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.cateCode = string.Empty;
                string sTemp = cbCategory.EditValue.ToString();
                string[] arrsCate;
                if (sTemp.Trim() != string.Empty)
                {
                    arrsCate = sTemp.Split(',');
                    for (Int32 i = 0; i < arrsCate.Length; i++)
                    {
                        this.cateCode += "'" + arrsCate.GetValue(i).ToString().Trim(' ') + "',";
                    }
                    this.chkList_Service.DataSource = ServiceBLL.rptListService(this.groupCode.TrimEnd(','), this.cateCode.TrimEnd(','));
                    this.chkList_Service.ValueMember = "ServiceCode";
                    this.chkList_Service.DisplayMember = "ServiceName";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup(string.Empty);//.FindAll(x => x.ServiceModuleCode != "THUOC");
            this.cbGroup.Properties.DataSource = lstGroup;
            this.cbGroup.Properties.ValueMember = "ServiceGroupCode";
            this.cbGroup.Properties.DisplayMember = "ServiceGroupName";
            this.dllNgay.tungay.Value = this.dllNgay.denngay.Value = this.dtWorking;
            this.chkList_Service.DataSource = null;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbList.Checked)
                {
                    ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
                    frmPath.ShowDialog();
                    if (frmPath.reloaded)
                    {
                        DataSet dsTemp = new DataSet("table");
                        dsTemp.Merge(dtTH);
                        dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_VP_TKeDoanhThuTH.xml");
                        Reports.rpt_VP_TKeDoanhThuTH rpt = new Reports.rpt_VP_TKeDoanhThuTH();
                        rpt.DataSource = dsTemp;
                        rpt.Parameters["title"].Value = "BẢNG KÊ TIỀN DỊCH VỤ, THUỐC TRONG NGÀY";
                        rpt.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                        rpt.Parameters["todate"].Value = dllNgay.denngay.Text;
                        rpt.ExportOptions.Xlsx.ShowGridLines = true;
                        rpt.ExportOptions.Xls.SheetName = "BangKeChiTietDoanhThu";
                        rpt.ExportToXls(frmPath.pathName);
                        oxl = new Excel.Application();
                        owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                        osheet = (Excel._Worksheet)owb.ActiveSheet;
                        oxl.ActiveWindow.DisplayGridlines = false;
                        oxl.ActiveWindow.DisplayZeros = false;
                        oxl.Visible = true;
                    }

                }
                else if (this.cbDetail.Checked)
                {
                    if (this.dtResultDetail != null && this.dtResultDetail.Rows.Count > 0)
                    {
                        DataTable tableResult = new DataTable("BangKeChiTiet");
                        tableResult.Columns.Add("SoPhieu", typeof(string));
                        tableResult.Columns.Add("Ngay", typeof(string));
                        tableResult.Columns.Add("MaKhachHang", typeof(string));
                        tableResult.Columns.Add("TenKhachHang", typeof(string));
                        tableResult.Columns.Add("BacSy", typeof(string));
                        tableResult.Columns.Add("KTV", typeof(string));
                        tableResult.Columns.Add("DD", typeof(string));
                        tableResult.Columns.Add("MaHang", typeof(string));
                        tableResult.Columns.Add("TenHang", typeof(string));
                        tableResult.Columns.Add("DVT", typeof(string));
                        tableResult.Columns.Add("SoLuong", typeof(Decimal));
                        tableResult.Columns.Add("GiaBan", typeof(Decimal));
                        tableResult.Columns.Add("ThanhTien", typeof(Decimal));
                        foreach (DataRow row in this.dtResultDetail.Rows)
                        {
                            DataRow rownew = tableResult.NewRow();
                            rownew["SoPhieu"] = row["BanksAccountCode"].ToString();
                            rownew["Ngay"] = Convert.ToDateTime(row["PostingDate"]).ToString("dd/MM/yyyy");
                            rownew["MaKhachHang"] = "KHACHLE";
                            rownew["TenKhachHang"] = row["PatientName"].ToString();
                            rownew["BacSy"] = string.Empty;
                            rownew["KTV"] = string.Empty;
                            rownew["DD"] = string.Empty;
                            rownew["MaHang"] = string.Empty;
                            rownew["TenHang"] = row["ServiceName"].ToString();
                            rownew["DVT"] = row["UnitOfMeasureName"].ToString();
                            rownew["SoLuong"] = row["Quantity"];
                            rownew["GiaBan"] = row["UnitPrice"];
                            rownew["ThanhTien"] = row["Amount"];
                            tableResult.Rows.Add(rownew);
                        }
                        DataSet datasetResult = new DataSet("BangKeChiTiet");
                        datasetResult.Tables.Add(tableResult);
                        datasetResult.Tables[0].Columns["SoPhieu"].ColumnName = "Số Phiêu";
                        datasetResult.Tables[0].Columns["Ngay"].ColumnName = "Ngày";
                        datasetResult.Tables[0].Columns["MaKhachHang"].ColumnName = "Mã Khách Hàng";
                        datasetResult.Tables[0].Columns["TenKhachHang"].ColumnName = "Tên Khách Hàng";
                        datasetResult.Tables[0].Columns["BacSy"].ColumnName = "Bác Sỹ";
                        datasetResult.Tables[0].Columns["KTV"].ColumnName = "KTV";
                        datasetResult.Tables[0].Columns["DD"].ColumnName = "ĐD";
                        datasetResult.Tables[0].Columns["MaHang"].ColumnName = "Mã Hàng";
                        datasetResult.Tables[0].Columns["TenHang"].ColumnName = "Tên";
                        datasetResult.Tables[0].Columns["DVT"].ColumnName = "ĐVT";
                        datasetResult.Tables[0].Columns["SoLuong"].ColumnName = "Số Lượng";
                        datasetResult.Tables[0].Columns["GiaBan"].ColumnName = "Giá Bán";
                        datasetResult.Tables[0].Columns["ThanhTien"].ColumnName = "Thành Tiền";
                        this.ExpToExcel(datasetResult, "vp_TKDoanhThuChiTiet", "5", "BÁO CÁO CHI TIẾT DOANH THU");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void ExpToExcel(DataSet dataset, string filename, string col_delimiter, string titleReport)
        {
            try
            {
                Utils.Check_Process_Excel();
                string ssoyte = string.Empty, simage = string.Empty, hisName = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref hisName, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
                string afile = Utils.Export_Excel(dataset.Tables[0], filename).Replace("//", "\\");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(afile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;
                oxl.ActiveWindow.DisplayZeros = true;
                oxl.Visible = true;

                int asocot = dataset.Tables[0].Columns.Count;
                int asodong = dataset.Tables[0].Rows.Count;
                int colLeft = asocot - 1;
                //if (!string.IsNullOrEmpty(col_delimiter))
                //{
                //    foreach (string atmp in col_delimiter.Split('~'))
                //    {
                //        osheet.get_Range(Utils.GetIndex(int.Parse(atmp)) + "2", Utils.GetIndex(int.Parse(atmp)) + (asodong + 2).ToString()).NumberFormat = "#,##0";
                //    }
                //}
                osheet.get_Range(Utils.GetIndex(colLeft) + "2", Utils.GetIndex(asocot - 1) + (asodong + 2).ToString()).NumberFormat = "#,##0";
                osheet.get_Range(Utils.GetIndex(colLeft) + "2", Utils.GetIndex(asocot - 2) + (asodong + 2).ToString()).NumberFormat = "#,##0";
                osheet.get_Range(Utils.GetIndex(asocot - 1) + "2", Utils.GetIndex(asocot - 1) + (asodong + 1).ToString()).Font.Bold = true;
                //osheet.get_Range(Utils.GetIndex(asocot - 2) + "2", Utils.GetIndex(asocot - 2) + (asodong + 1).ToString()).Font.Bold = true;

                osheet.Cells[asodong + 2, 1] = "CỘNG:";
                orange = osheet.get_Range(Utils.GetIndex(0) + (asodong + 2).ToString(), Utils.GetIndex(colLeft - 1) + (asodong + 2).ToString());
                orange.Select();
                orange.Merge(false);
                orange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                for (int i = colLeft + 1; i <= dataset.Tables[0].Columns.Count; i++)
                {
                    osheet.Cells[asodong + 2, i] = "=SUM(" + Utils.GetIndex(i - 1) + "2:" + Utils.GetIndex(i - 1) + (asodong + 1).ToString() + ")";
                }

                osheet.get_Range(Utils.GetIndex(0) + "" + (1).ToString(), Utils.GetIndex(asocot - 1) + (asodong + 2).ToString()).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                osheet.Cells[asodong + 3, asocot - 3] = "Ngày " + this.dtWorking.ToString("dd") + " tháng " + this.dtWorking.ToString("MM") + " năm " + this.dtWorking.ToString("yyyy");

                osheet.Cells[asodong + 4, asocot - 3] = "Người Lập Biểu";
                //osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 4).ToString(), Utils.GetIndex(asocot - 1) + "" + (asodong + 4).ToString()).Font.Bold = true;
                osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 4).ToString(), Utils.GetIndex(asocot - 1) + (asodong + 4).ToString()).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;

                //osheet.Cells[asodong + 6, asocot - 3] = string.Empty;
                //osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 6).ToString(), Utils.GetIndex(asocot - 1) + "" + (asodong + 6).ToString()).Font.Bold = true;
                //osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 6).ToString(), Utils.GetIndex(asocot - 1) + (asodong + 6).ToString()).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;

                orange = osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 4).ToString(), Utils.GetIndex(1) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(2) + "" + (asodong + 4).ToString(), Utils.GetIndex(3) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(5) + "" + (asodong + 4).ToString(), Utils.GetIndex(6) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(7) + "" + (asodong + 4).ToString(), Utils.GetIndex(8) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 6).ToString(), Utils.GetIndex(1) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(2) + "" + (asodong + 6).ToString(), Utils.GetIndex(3) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(5) + "" + (asodong + 6).ToString(), Utils.GetIndex(6) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(7) + "" + (asodong + 6).ToString(), Utils.GetIndex(8) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(7) + "" + (asodong + 3).ToString(), Utils.GetIndex(8) + (asodong + 3).ToString());
                orange.Select();
                orange.Merge(false);

                for (int i = 1; i <= 4; i++)
                {
                    osheet.get_Range(Utils.GetIndex(0) + "" + i.ToString(), Utils.GetIndex(0) + "" + i.ToString()).EntireRow.Insert(Missing.Value);
                }
                osheet.Cells[1, 1] = ssoyte;
                osheet.Cells[2, 1] = hisName;
                osheet.Cells[3, 1] = titleReport;
                osheet.Cells[1, asocot] = "PHÒNG TÀI CHÁNH KẾ TOÁN";
                
                orange = osheet.get_Range(Utils.GetIndex(asocot - 3) + "1", Utils.GetIndex(asocot - 1) + "3");
                orange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                orange.Font.Bold = true;

                orange = osheet.get_Range(Utils.GetIndex(0) + "1", Utils.GetIndex(4) + "1");
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(0) + "2", Utils.GetIndex(4) + "2");
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(asocot - 4) + "1", Utils.GetIndex(asocot - 1) + "1");
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(asocot - 4) + "2", Utils.GetIndex(asocot - 1) + "2");
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(0) + "1", Utils.GetIndex(3) + "3");
                orange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                orange.Font.Bold = true;

                orange = osheet.get_Range(Utils.GetIndex(0) + "3", Utils.GetIndex(asocot - 1) + "3");
                orange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 18;
                orange.Font.Bold = true;
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.GetIndex(1) + "" + (4).ToString(), Utils.GetIndex(asocot) + (asodong + 2).ToString());
                orange.Font.Size = 9;
                orange.Font.Name = "Tahoma";
                //orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros = false;
                osheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA3;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}