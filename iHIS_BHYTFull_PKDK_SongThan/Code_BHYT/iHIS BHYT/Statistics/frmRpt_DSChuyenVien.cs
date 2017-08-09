using System;
using System.IO;
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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmRpt_DSChuyenVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        public frmRpt_DSChuyenVien()
        {
            InitializeComponent();
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                dtResult = new DataTable();
                dtResult = HospitalTransferBLL.DSTransfer(dllNgay.tungay.Text, dllNgay.denngay.Text);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    gridControl_result.DataSource = dtResult;
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET");
                    return;
                }
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
                gridControl_result.ShowPrintPreview();
            }
            catch { }
        }
    }
}