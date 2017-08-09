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
using DevExpress.XtraTab;
using DevExpress.XtraReports.UI;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.Statistics
{
    public partial class frmExcelTest : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string groupCode = string.Empty;
        private string categoryCode = string.Empty, userID = string.Empty;
        private DataTable tableListDetail = new DataTable();
        public frmExcelTest(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmKB_TKeTheoCa_Load(object sender, EventArgs e)
        {
            List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
            this.lkupNhomDV.Properties.DataSource = lstGroup;
            this.lkupNhomDV.Properties.ValueMember = "ServiceGroupCode";
            this.lkupNhomDV.Properties.DisplayMember = "ServiceGroupName";

            //this.tableListDetail.Columns.Add("ServiceName", typeof(string));
            //this.tableListDetail.Columns.Add("Ca1", typeof(Int32));
            //this.tableListDetail.Columns.Add("Ca2", typeof(Int32));
            //for (Int32 count = 0; count < 20; count++)
            //{
            //    DataRow row = this.tableListDetail.NewRow();
            //    row["ServiceName"] = "Dịch vụ: " + count;
            //    row["Ca1"] = 5 + count;
            //    row["Ca2"] = count;
            //    this.tableListDetail.Rows.Add(row);
            //}

            Worksheet worksheet = this.sheetResult.Document.Worksheets[0];
            worksheet.DeleteCells(worksheet.Cells, DeleteMode.ShiftCellsLeft);
            worksheet.MergeCells(worksheet.Range["A1:F1"], MergeCellsMode.ByRows);
            worksheet.Range["A1:C1"].Value = "Thống Kê Số Lượng Khám Từng Ngày";
            
            //ImportDataTable();
            //CreateTable();

            
            //Worksheet worksheet = this.sheetResult.Document.Worksheets[0];
            //Range range = worksheet.Tables[0].Range;
        }

        void CreateTable()
        {

            Worksheet worksheet = this.sheetResult.Document.Worksheets[0];

            // Insert a table in the worksheet.
            Table table = worksheet.Tables.Add(worksheet["B2:F5"], true);

            // Format the table by applying a built-in table style.
            table.Style = this.sheetResult.Document.TableStyles[BuiltInTableStyleId.TableStyleMedium27];

            // Access table columns.
            TableColumn productColumn = table.Columns[0];
            TableColumn priceColumn = table.Columns[1];
            TableColumn quantityColumn = table.Columns[2];
            TableColumn discountColumn = table.Columns[3];
            TableColumn amountColumn = table.Columns[4];

            // Set the name of the last column. 
            amountColumn.Name = "Amount";

            // Set the formula to calculate the amount per product 
            // and display results in the "Amount" column.
            amountColumn.Formula = "=[Price]*[Quantity]*(1-[Discount])";

            // Display the total row in the table.
            table.ShowTotals = true;

            // Set the label and function to display the sum of the "Amount" column.
            discountColumn.TotalRowLabel = "Total:";
            amountColumn.TotalRowFunction = TotalRowFunction.Sum;

            // Specify the number format for each column.
            priceColumn.DataRange.NumberFormat = "$#,##0.00";
            discountColumn.DataRange.NumberFormat = "0.0%";
            amountColumn.Range.NumberFormat = "$#,##0.00;$#,##0.00;\"\";@";

            // Specify horizontal alignment for header and total rows of the table.
            table.HeaderRowRange.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            table.TotalRowRange.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            // Specify horizontal alignment to display data in all columns except the first one.
            for (int i = 1; i < table.Columns.Count; i++)
            {
                table.Columns[i].DataRange.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            }

            // Set the width of table columns.
            table.Range.ColumnWidthInCharacters = 10;
        }

        void ImportDataTable()
        {

            Worksheet worksheet = this.sheetResult.Document.Worksheets[0];
            
            // Create a "Products" DataTable object with four columns.
            DataTable sourceTable = new DataTable("Products");
            sourceTable.Columns.Add("Product", typeof(string));
            sourceTable.Columns.Add("Price", typeof(float));
            sourceTable.Columns.Add("Quantity", typeof(Int32));
            sourceTable.Columns.Add("Discount", typeof(float));

            sourceTable.Rows.Add("Chocolade", 5, 15, 0.03);
            sourceTable.Rows.Add("Konbu", 9, 55, 0.1);
            sourceTable.Rows.Add("Geitost", 15, 70, 0.07);

            // Import data from the data table into the worksheet and insert it, starting with the B2 cell.
            worksheet.Import(sourceTable, true, 1, 1);
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                //this.tableListDetail = PatientReceiveBLL.DT_ListReportReceive(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.lkupNhomDV.EditValue.ToString(), this.chkGetReceive.Checked ? true : false);
                //if (this.tableListDetail != null && this.tableListDetail.Rows.Count > 0)
                //{
                //    //this.gridControl_result.DataSource = this.tableListDetail;
                //    //this.gridView_result.Columns["PatientName"].Group();
                //    //this.gridView_result.ExpandAllGroups();
                //}
                //else
                //{
                //    XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.sheetResult.Document.BeginUpdate();
            try
            {
                Worksheet worksheet = this.sheetResult.Document.Worksheets[0];
                worksheet.Clear(worksheet.GetUsedRange());
                worksheet.Cells["A1"].ColumnWidthInCharacters = 35;
                worksheet.Cells["A1"].Value = "Import data from List vertically:";
                ImportList();
            }
            finally
            {
                this.sheetResult.Document.EndUpdate();
            }

            if (this.tableListDetail != null && this.tableListDetail.Rows.Count > 0)
            {
                DataSet dsTemp = new DataSet();
                dsTemp.Merge(this.tableListDetail);
                dsTemp.WriteXmlSchema(@"..\..\xml\view_KB_ListPatientReceiveDetail.xml");
                //if (!this.chkPrintGroup.Checked)
                //{
                //    Reports.view_KB_ListPatientReceiveDetail rpt = new Reports.view_KB_ListPatientReceiveDetail();
                //    rpt.DataSource = dsTemp;
                //    rpt.Parameters["fromdate"].Value = "";
                //    rpt.Parameters["todate"].Value = "";
                //    rpt.ShowRibbonPreviewDialog();
                //}
                //else
                //{
                //    Reports.view_KB_ListPatientReceiveDetailGroup rpt = new Reports.view_KB_ListPatientReceiveDetailGroup();
                //    rpt.DataSource = dsTemp;
                //    rpt.ShowRibbonPreviewDialog();
                //}
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void ImportList()
        {
            Worksheet worksheet = this.sheetResult.Document.Worksheets[0];
            #region #ImportList
            // Create a List object containing string values.
            List<string> cities = new List<string>();
            cities.Add("New York");
            cities.Add("Rome");
            cities.Add("Beijing");
            cities.Add("Delhi");

            // Import the list into the worksheet and insert it vertically, starting with the B1 cell.
            worksheet.Import(cities, 0, 1, true);
            #endregion #ImportList
        }
    }
}