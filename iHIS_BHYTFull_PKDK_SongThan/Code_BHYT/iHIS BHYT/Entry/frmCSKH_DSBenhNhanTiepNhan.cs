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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Entry
{
    public partial class frmCSKH_DSBenhNhanTiepNhan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        public frmCSKH_DSBenhNhanTiepNhan()
        {
            InitializeComponent();
        }

        private void frmCSKH_DSBenhNhanTiepNhan_Load(object sender, EventArgs e)
        {
            try
            {
                this.slkupPatientType.Properties.DataSource = PatientTypeBLL.ListPatientType();
                this.slkupPatientType.Properties.DisplayMember = "TypeName";
                this.slkupPatientType.Properties.ValueMember = "RowID";
            }
            catch { throw new Exception(); }
        }
        

        private void butPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridControl_result.ShowPrintPreview();
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {   
                this.dtResult = PatientReceiveBLL.DT_View_PatientReceive(Convert.ToDateTime(this.dllNgay.tungay.Text),Convert.ToDateTime(this.dllNgay.denngay.Text), Convert.ToInt32(this.slkupPatientType.EditValue), "F");
                if (this.dtResult != null && this.dtResult.Rows.Count > 0)
                {
                    this.gridControl_result.DataSource = this.dtResult;
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu phát sinh!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsTemp = new DataSet("table");
                //dsTemp.Tables.Add(dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptDanhSachTiepNhan.xml");
                Reports.rptDanhSachTiepNhan rpt = new Reports.rptDanhSachTiepNhan();
                rpt.DataSource = dsTemp;
                rpt.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rpt.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch { throw new Exception(); }
        }
        
    }
}