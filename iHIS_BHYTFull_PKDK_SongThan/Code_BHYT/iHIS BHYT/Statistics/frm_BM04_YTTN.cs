using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Windows.Forms;
using System.Reflection;

namespace Ps.Clinic.Statistics
{
    public partial class frm_BM04_YTTN : Form
    {

        private DataTable dtbResult = new DataTable();
        private DevExpress.Utils.WaitDialogForm Starting = null;

        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        public frm_BM04_YTTN()
        {
            InitializeComponent();
            
        }

        private void butRefesh_Click(object sender, EventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                this.dtbResult = rpt_General_BLL.TableTHTC(Convert.ToDateTime(this.controlDatetime.TN.ToString()), Convert.ToDateTime(this.controlDatetime.DN.ToString()));
                Starting.Close();
                this.gridControl_Result.DataSource = this.dtbResult;
            }
            catch
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
            frmPath.ShowDialog();
            if (frmPath.reloaded)
            {
                Utils.Check_Process_Excel();
                DataSet dsTemp = new DataSet();
                dsTemp.Merge(this.dtbResult);
                dsTemp.WriteXmlSchema(@"..\..\xml\view_BCTHTC.xml");
                Reports.rpt_THTC rpt = new Reports.rpt_THTC();
                rpt.DataSource = dsTemp;
                rpt.Parameters["fromdate"].Value = this.controlDatetime.TN.ToString();
                rpt.Parameters["todate"].Value = this.controlDatetime.DN.ToString();
                rpt.ExportOptions.Xls.ShowGridLines = true;
                rpt.ExportOptions.Xls.SheetName = "THTC";
                rpt.ExportToXls(frmPath.pathName);
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = false;
                oxl.ActiveWindow.DisplayZeros = false;
                oxl.Visible = true;
            }
        }
    }
}
