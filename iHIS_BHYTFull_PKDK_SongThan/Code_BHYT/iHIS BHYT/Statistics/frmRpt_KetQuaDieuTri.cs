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

namespace Ps.Clinic.Statistics
{
    public partial class frmRpt_KetQuaDieuTri : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        public frmRpt_KetQuaDieuTri()
        {
            InitializeComponent();
        }

        private void frmRpt_KetQuaDieuTri_Load(object sender, EventArgs e)
        {
            try
            {
                slkupPatientType.Properties.DataSource = PatientTypeBLL.ListPatientType();
                slkupPatientType.Properties.DisplayMember = "TypeName";
                slkupPatientType.Properties.ValueMember = "RowID";

                slkupDepartment.Properties.DataSource = DepartmentBLL.ListDepartmentFull();
                slkupDepartment.Properties.DisplayMember = "DepartmentName";
                slkupDepartment.Properties.ValueMember = "DepartmentCode";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                dtResult = new DataTable();
                dtResult = rpt_General_BLL.DT_Get_KetQuaDieuTri(dllNgay.tungay.Text, dllNgay.denngay.Text, slkupDepartment.EditValue.ToString(), Convert.ToInt32(slkupPatientType.EditValue));
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    gridControl_result.DataSource = dtResult;
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptKetQuaDieuTri.xml");
                Reports.rptKetQuaDieuTri rptShow = new Reports.rptKetQuaDieuTri();
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "KQDieuTri","Kết quả điều trị");
                rpt.ShowDialog();
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
    }
}