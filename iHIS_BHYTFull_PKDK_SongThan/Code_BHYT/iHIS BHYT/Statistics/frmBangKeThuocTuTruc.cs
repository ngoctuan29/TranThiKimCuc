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
using DevExpress.XtraReports.UI;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ps.Clinic.ViewPopup;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Diagnostics;
using System.Reflection;
//using Excel;
namespace Ps.Clinic.Statistics
{
    public partial class frmBangKeThuocTuTruc : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtResult;
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        Excel.Range orange;
        public frmBangKeThuocTuTruc()
        {
            InitializeComponent();
            
        }
        
        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                dtResult = new DataTable();
                if (this.lkupKho.EditValue == null || this.lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem thống kê.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupKho.Focus();
                }
                else if (this.frmDate.Text.Trim() == string.Empty || this.toDate.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show("Chọn ngày xem cấp toa tủ trực!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmDate.Focus();
                }
                else
                {
                    if (tabMain.SelectedTabPageIndex == 0)
                    {
                        dtResult = rpt_Medicines_BLL.DT_View_RealMedicinesTH(lkupKho.EditValue.ToString(), Utils.StringToDate(frmDate.Text.Trim()), Utils.StringToDate(toDate.Text.Trim()));
                        gridControl_Result.DataSource = dtResult;
                    }
                    else
                    {
                        gridControl_ResultDetail.DataSource = rpt_Medicines_BLL.DT_View_RealMedicinesDetail(lkupKho.EditValue.ToString(), Utils.StringToDate(frmDate.Text.Trim()), Utils.StringToDate(toDate.Text.Trim()));
                        gridView_ResultDetail.Columns[0].Group();
                        gridView_ResultDetail.Columns[1].Group();
                        gridView_ResultDetail.ExpandAllGroups();
                        gridView_ResultDetail.OptionsBehavior.ReadOnly = true;
                        gridView_ResultDetail.OptionsBehavior.Editable = false;
                    }
                }
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabMain.SelectedTabPageIndex == 0)
                {
                    DataSet dsTemp = new DataSet();
                    if (this.dtResult.Rows.Count > 0)
                    {
                        dsTemp.Merge(this.dtResult);
                        this.excel_ds(dsTemp, "excelTKeThuocXuatTuTrucTH", string.Empty);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Không có dữ liệu phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    this.gridView_ResultDetail.ShowRibbonPrintPreview();
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void excel_ds(DataSet v_ds, string v_filename, string v_col_delimiter_numer)
        {
            try
            {
                Utils.Check_Process_Excel();
                string afile = Utils.Export_Excel(v_ds.Tables[0], v_filename).Replace("//", "\\");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(afile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = false;
                oxl.ActiveWindow.DisplayZeros = false;
                oxl.Visible = true;

                int asocot = v_ds.Tables[0].Columns.Count;
                int asodong = v_ds.Tables[0].Rows.Count;

                if (v_col_delimiter_numer != "")
                {
                    foreach (string atmp in v_col_delimiter_numer.Split('~'))
                    {
                        osheet.get_Range(Utils.GetIndex(int.Parse(atmp)) + "2", Utils.GetIndex(int.Parse(atmp)) + (asodong + 2).ToString()).NumberFormat = "#,##0";
                    }
                }
                osheet.Cells[asodong + 6, asocot - 6] = "NGÀY IN " + Utils.DateServer().ToString("dd/MM/yyyy");
                //osheet.Cells[asodong + 6, 3] = "TỔ TRƯỞNG VP" + " ";
                //osheet.Cells[asodong + 6, 5] = "TP TÀI CHÁNH KẾ TOÁN" + " ";
                //osheet.Cells[asodong + 6, 7] = "GIÁM ĐỐC" + " ";
                
                osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 6).ToString(), Utils.GetIndex(asocot + 6) + "" + (asodong + 6).ToString()).Font.Bold = true;
                osheet.get_Range(Utils.GetIndex(0) + "" + (asodong + 6).ToString(), Utils.GetIndex(asocot + 6) + "" + (asodong + 6).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;
                /*
                orange = osheet.get_Range(Utils.getIndex(0) + "" + (asodong + 4).ToString(), Utils.getIndex(1) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(2) + "" + (asodong + 4).ToString(), Utils.getIndex(3) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(5) + "" + (asodong + 4).ToString(), Utils.getIndex(6) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(7) + "" + (asodong + 4).ToString(), Utils.getIndex(8) + (asodong + 4).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(0) + "" + (asodong + 6).ToString(), Utils.getIndex(1) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(2) + "" + (asodong + 6).ToString(), Utils.getIndex(3) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(5) + "" + (asodong + 6).ToString(), Utils.getIndex(6) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(7) + "" + (asodong + 6).ToString(), Utils.getIndex(8) + (asodong + 6).ToString());
                orange.Select();
                orange.Merge(false);

                orange = osheet.get_Range(Utils.getIndex(7) + "" + (asodong + 3).ToString(), Utils.getIndex(8) + (asodong + 3).ToString());
                orange.Select();
                orange.Merge(false);
                */
                ///Merge in tieu de
                for (int i = 1; i <= 4; i++)
                {
                    osheet.get_Range(Utils.GetIndex(0) + "" + i.ToString(), Utils.GetIndex(0) + "" + i.ToString()).EntireRow.Insert(Missing.Value);//,Missing.Value);
                }
                osheet.Cells[1, 1] = string.Empty;
                osheet.Cells[2, 1] = string.Empty;
                osheet.Cells[3, 1] = "BÁO CÁO TỔNG HỢP ĐỢT";
                osheet.Cells[1, asocot] = string.Empty;
                osheet.Cells[2, asocot] = " ,ngày " + Utils.DateServer().ToString("dd/MM/yyyy");

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
                orange.EntireColumn.AutoFit();
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
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmBangKeThuocTuTruc_Load(object sender, EventArgs e)
        {
            try
            {
                lkupKho.Properties.DataSource = RepositoryCatalog_BLL.ListRepositoryForBHYT(0, 3);
                lkupKho.Properties.DisplayMember = "RepositoryName";
                lkupKho.Properties.ValueMember = "RepositoryCode";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}