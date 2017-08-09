using System;
using System.IO;
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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmCapPhatToaBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty;
        private string exportCode = string.Empty;
        private string MedicalCode = string.Empty;
        private decimal dReceiveID = 0;
        private string sUserid = string.Empty, sTheBHYT = string.Empty;
        private DataTable dtMedicalDetail = new DataTable();
        private bool bcheckInventory = true;
        private bool bImportDate = false;
        private bool bShipment = false;
        private bool bDateEnd = false;
        private decimal dVirtual = 0;
        private decimal dRowIDMedicines = 0;
        private int iObjectCode = 0, iTraituyen = 0, typeMedical = 0;
        private string sRepositoryCode = string.Empty, shiftWork = string.Empty;
        public frmCapPhatToaBHYT(string _User, string _RepositoryCode, string _shiftWork)
        {
            InitializeComponent();
            sUserid = _User;
            sRepositoryCode = _RepositoryCode;
            this.shiftWork = _shiftWork;
        }

        private void ClearInfo()
        {
            try
            {
                this.patientCode = this.exportCode = this.MedicalCode = this.sTheBHYT = string.Empty;
                this.iObjectCode = this.iTraituyen = 0;
                this.dRowIDMedicines = this.dReceiveID = 0;
                this.lbTileBHYT.Text = this.lbMabn01.Text = this.lbHoten01.Text = this.lbNamsinh01.Text = this.lbTuoi01.Text = this.lbGioitinh01.Text = this.lbDiachi01.Text = string.Empty;
                this.lbSothe.Text = this.lbTungay.Text = this.lbNoiDKKCB.Text = this.lbTungay.Text = this.lbDenngay.Text = this.lbTongchiphi01.Text = this.lbBHYTTra01.Text = this.lbBenhNhantra01.Text = string.Empty;
                this.chkTraiTuyen.Checked = false;
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
            }
            catch { }
        }
        
        public void LoadList()
        {
            try
            {
                Int32 iStatus = 0;
                if (this.rdNo.Checked)
                {
                    iStatus = 0;
                    this.gridView_WaitingList.Columns["Done"].Visible = false;
                }
                else if (this.rdYes.Checked)
                {
                    iStatus = 1;
                    this.gridView_WaitingList.Columns["Done"].Visible = true;
                    this.gridView_WaitingList.Columns["Done"].Caption = "Cấp phát";
                }
                else if (this.rdDone.Checked)
                {
                    iStatus = 1;
                    this.gridView_WaitingList.Columns["Done"].Visible = true;
                    this.gridView_WaitingList.Columns["Done"].Caption = "Hủy cấp";
                }
                this.dtMedicalDetail = MedicalRecord_BLL.DTMedicalRecordApprove(this.MedicalCode, this.iObjectCode, this.sRepositoryCode, iStatus, this.dRowIDMedicines, -1);
                this.gridControl_List.DataSource = dtMedicalDetail;
            }
            catch { }
        }

        public void LoadWaitingList()
        {
            try
            {
                string objectCodeWhere = string.Empty;
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(212);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        objectCodeWhere = objSys.Description;
                }
                this.gridControl_List.DataSource = null;
                this.ClearInfo();
                if (this.rdYes.Checked)
                {
                    this.butOK.Enabled = false;
                    this.butCancel.Enabled = false;
                    this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowseForBHYT(1, this.sRepositoryCode, this.typeMedical, this.rdDone.Checked ? 1 : 0, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), objectCodeWhere);
                    this.gridView_WaitingList.Columns["Done"].Visible = true;
                    this.gridView_WaitingList.Columns["Done"].Caption = "Cấp phát";
                }
                else if(this.rdNo.Checked)
                {
                    this.butOK.Enabled = true;
                    this.butCancel.Enabled = false;
                    this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowseForBHYT(0, this.sRepositoryCode, this.typeMedical, this.rdDone.Checked ? 1 : 0, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), objectCodeWhere);
                    this.gridView_WaitingList.Columns["Done"].Visible = false;
                }
                else
                {
                    this.butOK.Enabled = false;
                    this.butCancel.Enabled = false;
                    this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowse(1, this.sRepositoryCode, this.typeMedical, this.rdDone.Checked ? 1 : 0, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue));
                    this.gridView_WaitingList.Columns["Done"].Visible = true;
                    this.gridView_WaitingList.Columns["Done"].Caption = "Hủy cấp";
                }
            }
            catch { }
        }

        private void frmCapToa_Load(object sender, EventArgs e)
        {
            this.dtimeFrom.EditValue = this.dtimeTo.EditValue = Utils.DateServer();
            this.LoadWaitingList();
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
        
        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (chkTraiTuyen.Checked == true)
                        lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                    else
                        lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                }
            }
            catch { }
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.dReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    lbMabn01.Text = objPatient.PatientCode;
                    lbHoten01.Text = objPatient.PatientName;
                    lbNamsinh01.Text = objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    lbDiachi01.Text = objPatient.PatientAddress + ", " + objPatient.DistrictName + ", " + objPatient.DistrictName + ", " + objPatient.ProvincialName;
                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        picPatient.Image = (Bitmap)b;
                    }
                }
                else
                    return;
            }
            catch { }
        }

        private void VisableBHYT(bool b)
        {
            lbSothe.Visible = b;
            lbTungay.Visible = b;
            chkTraiTuyen.Visible = b;
            lbNoiDKKCB.Visible = b;
            lbDenngay.Visible = b;
            lbTongchiphi.Visible = lbTongchiphi01.Visible = true;
            lbBHYTTra.Visible = lbBHYTTra01.Visible = true;
            lbBenhNhantra.Visible = lbBenhNhantra01.Visible = true;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_List.RowCount > 0)
                {
                    if(MedicinesForPatientsBLL.UpdateDone(this.dReceiveID, 1))
                    {
                        this.dtMedicalDetail.Clear();
                        this.ClearInfo();
                        this.LoadWaitingList();
                        XtraMessageBox.Show("Cấp phát thành công", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Cấp phát thất bại", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
                else
                {
                    XtraMessageBox.Show("Toa thuốc kê không phát sinh thuốc", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { return; }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadWaitingList();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(MedicalCode))
                {
                    if (XtraMessageBox.Show("Bạn có muốn hủy cấp phát toa này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            if(MedicinesForPatientsBLL.UpdateDone(this.dReceiveID, 0))
                            {
                                XtraMessageBox.Show(" Hủy cấp phát toa thuốc thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.dtMedicalDetail.Clear();
                                this.ClearInfo();
                                this.LoadWaitingList();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy cấp phát toa thuốc thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                        catch
                        {
                            XtraMessageBox.Show(" Thao tác thất bại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chọn bệnh nhân để hủy phiếu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_WaitingList.RowCount > 0)
                {
                    if (gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.patientCode = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientCode).ToString(), string.Empty);
                        this.MedicalCode = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_MedicalRecordCode).ToString(), string.Empty);
                        this.dReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientReceiveID).ToString());
                        this.iObjectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectCode).ToString());
                        this.dRowIDMedicines = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, this.col_List_RowIDMedicinesFor).ToString());
                        if (patientCode != string.Empty && dReceiveID != 0 && MedicalCode != string.Empty && iObjectCode != 0)
                        {
                            this.LoadList();
                            if (iObjectCode == 1)
                            {
                                List<BHYTInf> lstBHYT = new List<BHYTInf>();
                                lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dReceiveID);
                                if (lstBHYT.Count > 0)
                                {
                                    sTheBHYT = lstBHYT[0].Serial;
                                    lbSothe.Text = lstBHYT[0].Serial;
                                    lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                    iTraituyen = lstBHYT[0].TraiTuyen;
                                    if (iTraituyen == 1)
                                        chkTraiTuyen.Checked = true;
                                    else
                                        chkTraiTuyen.Checked = false;
                                    lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                    lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                    GetCardInfo(lstBHYT[0].Serial);
                                    VisableBHYT(true);
                                }
                            }
                            this.GetInfoPatient();
                            if (this.rdDone.Checked)
                            {
                                this.butOK.Enabled = false;
                                this.butCancel.Enabled = false;
                            }
                            if (this.rdYes.Checked)
                            {
                                this.butOK.Enabled = true;
                            }
                            else if (this.rdDone.Checked)
                                this.butCancel.Enabled = true;
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
                XtraMessageBox.Show("Lỗi xảy ra khi chọn bệnh nhân duyệt đơn thuốc: \t\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void rdYes_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadWaitingList();
        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadWaitingList();
        }

        private void repbtnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.patientCode) || this.dReceiveID == 0)
            {
                XtraMessageBox.Show("Chọn bệnh nhân đã duyệt toa để hủy cấp phát toa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Int32 result = 0;
            result = MedicinesForPatientsBLL.UpdForDone(this.MedicalCode, this.dRowIDMedicines, this.sUserid, this.rdDone.Checked ? 0 : 1, this.dReceiveID);
            if (result == 1)
            {
                this.LoadWaitingList();
            }
            if (result == -2)
            {
                XtraMessageBox.Show("Bệnh nhân đã kết thúc điều trị, không được duyệt cấp phát toa BHYT!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                XtraMessageBox.Show("Chỉ cho phép hủy khi user đó duyệt cấp toa, tài khoản này không phải người duyệt cấp toa trước đó!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}