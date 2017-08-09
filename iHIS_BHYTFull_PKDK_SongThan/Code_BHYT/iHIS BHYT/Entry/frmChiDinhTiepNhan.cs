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
    public partial class frmChiDinhTiepNhan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult = new DataTable();
        private string shiftWork = string.Empty;
        private DateTime dtimeWorking = new DateTime();
        private string userID = string.Empty;
        public frmChiDinhTiepNhan(string _userID, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.shiftWork = _shiftWork;
            this.dtimeWorking = _dtWorking;
            this.userID = _userID;
        }

        private void frmChiDinhTiepNhan_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = Utils.DateServer();
                this.LoadData();
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
                
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
                if (this.dtResult == null && this.dtResult.Rows.Count > 0)
                {
                    XtraMessageBox.Show("Không có số liệu phát sinh!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadData()
        {
            this.dtResult = PatientReceiveBLL.DT_View_PatientReceiveForDate(Convert.ToDateTime(this.dtimeFrom.Text), Convert.ToDateTime(this.dtimeTo.Text), this.chkStatus.Checked ? 1 : 0);
            this.gridControl_result.DataSource = this.dtResult;
        }
        
        private void gridView_result_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_result.GetFocusedRow() != null && this.gridView_result.RowCount > 0)
                {
                    string refPatientCode = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientCode).ToString();
                    Decimal refPatientReceiveId = Convert.ToDecimal(this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientReceiveID).ToString());
                    int refObjectCode = Convert.ToInt32(this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_ObjectCode).ToString());
                    string refReferenceCode = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_ReferenceCode).ToString();
                    int refPatientType = Convert.ToInt32(this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientType).ToString());
                    ViewPopup.frmChiDinhDichVu frm = new ViewPopup.frmChiDinhDichVu(refPatientReceiveId, refPatientCode, this.userID, refObjectCode, string.Empty, 0, refReferenceCode, refPatientType, "KP0000", string.Empty, string.Empty, this.shiftWork, this.dtimeWorking);
                    frm.ShowDialog();
                    this.LoadData();
                }
                else
                    XtraMessageBox.Show("Vui lòng chọn bệnh nhân chỉ định dịch vụ.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}