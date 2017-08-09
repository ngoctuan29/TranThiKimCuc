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
    public partial class frmBNLogDieuTri : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtbResultDV = new DataTable();
        private DataTable dtbResultTH = new DataTable();
        private Int32 pReceiveID = 0;
        private string pPatientCode = string.Empty;
        public frmBNLogDieuTri()
        {
            InitializeComponent();
        }

        private void frmVP_ThongKeDoanhThuNgay_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtfrom.EditValue = this.dtTo.EditValue = Utils.DateServer();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_WaitingList.DataSource = BanksAccountBLL.TableWaitingForDateBN(this.dtfrom.Text.Trim(), this.dtTo.Text.Trim());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            this.pPatientCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_search_PatientCode ).ToString();
            this.pReceiveID = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_search_PatientReceiveID).ToString());
            this.dtbResultDV = rpt_General_BLL.TableChiTietBenhNhanDV(this.dtfrom.Text.Trim(), this.dtTo.Text.Trim(), pPatientCode, pReceiveID);
            this.dtbResultTH = rpt_General_BLL.TableChiTietBenhNhanTH(this.dtfrom.Text.Trim(), this.dtTo.Text.Trim(), pPatientCode, pReceiveID);
            gridControl_Result.DataSource = this.dtbResultDV;
            gridControl_ResultDetail.DataSource = this.dtbResultTH;
        }
    }
}