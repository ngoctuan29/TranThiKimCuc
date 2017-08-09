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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmToaBacSiPK : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string sPatientCode = string.Empty;
        private string exportCode = string.Empty;
        public string sMedicalCode = string.Empty;
        public decimal dReceiveID = 0;
        public string diagnosisName = string.Empty, diagnosisCustom = string.Empty;
        public DataTable dtMedicalDetail = new DataTable();
        private decimal dRowIDMedicines = 0;
        private int iObjectCode = 0;
        public string sPatientName = string.Empty;
        public string sAddRess = string.Empty;
        public string sBirthyear = string.Empty;
        public string ngaysinh = string.Empty;
        public int patientGenderCode = -1;
        public string employeeCodeDoctor = string.Empty;
        public frmToaBacSiPK()
        {
            InitializeComponent();
            this.dtfrom.EditValue = this.dtTo.EditValue = Utils.DateServer();
        }

        public void loadWaitingList()
        {
            try
            {
                this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowseForDate(0, this.dtfrom.Text.Trim(), this.dtTo.Text.Trim(), this.chkDone.Checked);
            }
            catch { this.gridControl_WaitingList.DataSource = null; }
        }

        private void frmToaBacSiPK_Load(object sender, EventArgs e)
        {
            this.loadWaitingList();
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.loadWaitingList();
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            this.butSave_Click(sender, e);
        }

        public void LoadList()
        {
            this.dtMedicalDetail = MedicalRecord_BLL.DTMedicalRecordApprove(this.sMedicalCode, this.iObjectCode, 0, this.dRowIDMedicines);
            this.gridControl_List.DataSource = this.dtMedicalDetail;
        }

        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }

        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }

        private void frmToaBacSiPK_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3: butSave_Click(sender, e); break;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMedicalDetail != null && dtMedicalDetail.Rows.Count > 0)
                {
                    this.Close();
                    GC.Collect();
                }
                else
                {
                    XtraMessageBox.Show(" Đơn thuốc chưa có! Vui lòng chọn lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void gridView_WaitingList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.sPatientCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString();
                        this.sMedicalCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_MedicalRecordCode).ToString();
                        this.diagnosisName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_DiagnosisName).ToString();
                        this.diagnosisCustom = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_DiagnosisCustom).ToString();
                        this.dReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientReceiveID).ToString());
                        this.iObjectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode).ToString());
                        this.dRowIDMedicines = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_RowIDMedicinesFor).ToString());
                        this.sPatientName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientName).ToString();
                        this.sAddRess = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, this.col_List_PatientAddress).ToString().Replace("không xác định,", "").Replace("Không xác định,", "");
                        this.sBirthyear = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientBirthyear).ToString();
                        this.ngaysinh = Convert.ToDateTime(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientBirthday).ToString()).ToString("dd/MM/yyyy");
                        this.patientGenderCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientGender).ToString());
                        this.employeeCodeDoctor = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, this.col_List_EmployeeCodeDoctor).ToString();
                        if (this.sPatientCode != string.Empty && this.dReceiveID != 0 && this.sMedicalCode != string.Empty && this.iObjectCode != 0)
                        {
                            this.LoadList();
                            this.butSave.Focus();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi xảy ra khi chọn đơn thuốc: \t\n" + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void repbutUnShow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridView_WaitingList.GetFocusedRowCellValue(this.col_List_MedicalRecordCode).ToString()))
            {
                Int32 result = MedicalRecord_BLL.UpdMedicalRecordForHide(this.gridView_WaitingList.GetFocusedRowCellValue(this.col_List_MedicalRecordCode).ToString());
                if (result > 0)
                    this.loadWaitingList();
            }
            else
            {
                XtraMessageBox.Show(" Hãy chọn toa thuốc cần ẩn!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}