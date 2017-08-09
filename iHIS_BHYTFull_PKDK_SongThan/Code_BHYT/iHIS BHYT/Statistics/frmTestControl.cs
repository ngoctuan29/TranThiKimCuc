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
using DevExpress.XtraReports;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraPivotGrid;
using DevExpress.LookAndFeel;

namespace Ps.Clinic.Statistics
{
    public partial class frmTestControl : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTestControl()
        {
            InitializeComponent();
        }

        private void frmTestControl_Load(object sender, EventArgs e)
        {

            ////this.pivotGridResult.DataSource = rpt_General_BLL.TableTotalSuggestedForCategory(DateTime.Now, DateTime.Now);
            PivotGridField fieldDate = new PivotGridField("WorkDate", PivotArea.RowArea);
            fieldDate.Caption = "Ngày";
            PivotGridField fieldShiftWork = new PivotGridField("ShiftWork", PivotArea.RowArea);
            fieldShiftWork.Caption = "Ca";

            PivotGridField fieldCategoryName = new PivotGridField("ServiceCategoryName", PivotArea.ColumnArea);
            fieldCategoryName.Caption = "Dịch vụ";
            PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.ColumnArea);
            fieldServiceName.Caption = "Ten dich vụ";

            PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
            fieldQuantity.Caption = "Số lượng";
            fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            fieldQuantity.CellFormat.FormatString = "#,#";

            PivotGridField fieldServicePrice = new PivotGridField("ServicePrice", PivotArea.DataArea);
            fieldServicePrice.Caption = "Đơn giá";
            fieldServicePrice.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            fieldServicePrice.CellFormat.FormatString = "#,#";
            PivotGridField fieldAmount = new PivotGridField("Amount", PivotArea.DataArea);
            fieldAmount.Caption = "Thành Tiền";
            fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            fieldAmount.CellFormat.FormatString = "#,#";

            this.pivotGridResult.Fields.AddRange(new PivotGridField[] { fieldDate, fieldShiftWork, fieldCategoryName, fieldServiceName, fieldQuantity, fieldServicePrice, fieldAmount });

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
            frm.ShowDialog();
            if (frm.reloaded)
            {
                this.pivotGridResult.ExportToXlsx(frm.pathName);
            }
        }
    }
}