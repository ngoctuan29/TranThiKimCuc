using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Reflection;
using System.IO;

namespace Ps.Clinic.Reports
{
    public partial class frmReportEditGeneral : DevExpress.XtraEditors.XtraForm
    {
        //private DataSet dsResult = new DataSet();
        private DevExpress.XtraReports.UI.XtraReport rpt = new DevExpress.XtraReports.UI.XtraReport();   
        private Excel.Application oxl;
        private Excel._Workbook owb;
        private Excel._Worksheet osheet;
        private string fromdate = string.Empty, todate = string.Empty, sheetname = string.Empty;
        private string title = string.Empty;
        public frmReportEditGeneral(DevExpress.XtraReports.UI.XtraReport _rpt, string _sheetname, string _title)
        {
            InitializeComponent();
            this.rpt = _rpt;
            this.sheetname = _sheetname;
            this.title = _title;
        }
        private void barItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (new EditDesignReport(rpt).ShowpageEditDesign())
            {
                rpt.LoadLayout("EditReport\\" + this.rpt.GetType().Name + ".repx");
                rpt.CreateDocument();
            }
        }

        private void barItem_XuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
            frmPath.ShowDialog();
            if (frmPath.reloaded)
            {
                Utils.Check_Process_Excel();
                //rpt.DataSource = this.dsResult;
                rpt.ExportOptions.Xls.ShowGridLines = true;
                rpt.ExportOptions.Xls.SheetName = this.sheetname;
                rpt.ExportToXls(frmPath.pathName);
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = false;
                oxl.ActiveWindow.DisplayZeros = false;
                oxl.Visible = true;
            }
        }

        private void frmReportEditGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                string path = "EditReport\\" + this.rpt.GetType().Name + ".repx";
                if (File.Exists(path))
                    this.rpt.LoadLayout(path);
                this.Text = this.title != string.Empty ? this.title : "Chỉnh sửa mẫu báo cáo";
            }
            catch 
            { }
            //this.rpt.DataSource = this.dsResult;
            this.documentView.DocumentSource = this.rpt;
            this.rpt.CreateDocument(true);
        }
    }
}