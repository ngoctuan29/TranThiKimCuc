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
    public partial class frmDuyetToaThuocBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty;
        private string exportCode = string.Empty;
        private string medicalCode = string.Empty;
        private decimal dReceiveID = 0;
        private string userid = string.Empty, sTheBHYT = string.Empty;
        private DataTable dtMedicalDetail = new DataTable();
        private DataTable dtMedicalDetail_Check = new DataTable();
        private List<string> listCheckTemp = new List<string>();
        private bool bcheckInventory = true;
        private bool bImportDate = false;
        private bool bShipment = false;
        private bool bDateEnd = false;
        private decimal dVirtual = 0;
        private decimal dRowIDMedicines = 0;
        private int iObjectCode = 0, iTraituyen = 0, typeMedical = 0;
        private string repositoryCode = string.Empty, shiftWork = string.Empty;
        private bool bAdmin = false;
        private string objectCodeRepository = "0";
        
        public frmDuyetToaThuocBHYT(string _user, string _repositoryCode, string _shiftWork)
        {
            InitializeComponent();
            this.userid = _user;
            this.repositoryCode = _repositoryCode;
            this.shiftWork = _shiftWork;
        }

        private void ClearInfo()
        {
            this.patientCode = this.exportCode = this.medicalCode = this.sTheBHYT = string.Empty;
            this.iObjectCode = this.iTraituyen = 0;
            this.dRowIDMedicines = this.dReceiveID = 0;
            this.lbTileBHYT.Text = this.lbMabn01.Text = this.lbHoten01.Text = this.lbNamsinh01.Text = this.lbTuoi01.Text = this.lbGioitinh01.Text = this.lbDiachi01.Text = string.Empty;
            this.lbSothe.Text = this.lbTungay.Text = this.lbNoiDKKCB.Text = this.lbTungay.Text = this.lbDenngay.Text = this.lbTongchiphi01.Text = this.lbBHYTTra01.Text = this.lbBenhNhantra01.Text = string.Empty;
            this.chkTraiTuyen.Checked = false;
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            this.picPatient.Image = (Bitmap)b;
        }
        
        public void LoadList()
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
            this.dtMedicalDetail = MedicalRecord_BLL.DTMedicalRecordApprove(this.medicalCode, this.iObjectCode, this.repositoryCode, iStatus, this.dRowIDMedicines);
            this.gridControl_List.DataSource = this.dtMedicalDetail;
        }

        public void LoadWaitingList()
        {
            this.gridControl_List.DataSource = null;
            this.ClearInfo();
            if (this.rdYes.Checked)
            {
                this.butOK.Enabled = false;
                this.butCancel.Enabled = true;
                this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowseForBHYT(1, this.repositoryCode, this.typeMedical, this.rdDone.Checked ? 1 : 0, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), this.objectCodeRepository);
                this.gridView_WaitingList.Columns["Done"].Visible = false;
                this.gridView_WaitingList.Columns["Done"].Caption = "Cấp phát";
            }
            else if (this.rdNo.Checked)
            {
                this.butOK.Enabled = true;
                this.butCancel.Enabled = false;
                this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowseForBHYT(0, this.repositoryCode, this.typeMedical, this.rdDone.Checked ? 1 : 0, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue), this.objectCodeRepository);
                this.gridView_WaitingList.Columns["Done"].Visible = false;
            }
            else
            {
                this.butOK.Enabled = false;
                this.butCancel.Enabled = false;
                this.gridControl_WaitingList.DataSource = MedicalRecord_BLL.ListPatient_WaitingBrowse(1, this.repositoryCode, this.typeMedical, this.rdDone.Checked ? 1 : 0, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue));
                this.gridView_WaitingList.Columns["Done"].Visible = true;
                this.gridView_WaitingList.Columns["Done"].Caption = "Hủy cấp";
            }
        }

        private void frmDuyetToaThuocBHYT_Load(object sender, EventArgs e)
        {
            try
            {
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(212);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.objectCodeRepository = objSys.Description;
                }
                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = Utils.DateServer();
                this.LoadWaitingList();
                this.bAdmin = EmployeeBLL.CheckUserAdmin(this.userid);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
        private void AddItemCodeToListCheckTemp(string itemcode)
        {
            if (!string.IsNullOrEmpty(itemcode))
            {
                try
                {
                    if (this.listCheckTemp.Count > 0)
                    {
                        var temp = this.listCheckTemp.Contains(itemcode);
                        if (!temp)
                        {
                            this.listCheckTemp.Add(itemcode);
                        }
                    }
                    else { this.listCheckTemp.Add(itemcode); }
                }
                catch (Exception ex) { }
            }
        }
        private void getListCheckOnGridViewMedicalDetail()
        {
            this.listCheckTemp.Clear();
            int[] lstchecked = this.gridView_List.GetSelectedRows();
            foreach (var index in lstchecked)
            {
                if (index >= 0)
                {
                    string itemcode = string.Empty;
                    try
                    {
                        itemcode = this.gridView_List.GetRowCellValue(index, this.col_ItemCode).ToString();
                        if (!string.IsNullOrEmpty(itemcode))
                        {
                            this.AddItemCodeToListCheckTemp(itemcode);
                        }
                    }
                    catch { }
                }
            }
        }
        private void GetListItemMedicalChecked()
        {
            this.dtMedicalDetail_Check = this.dtMedicalDetail.Clone();
            this.dtMedicalDetail_Check.Clear();

            foreach (var itemcodeTemp in this.listCheckTemp)
            {
                if (!string.IsNullOrEmpty(itemcodeTemp))
                {
                    // string itemcode = string.Empty;
                    try
                    {
                        // itemcode = this.gridView_List.GetRowCellValue(index, this.col_ItemCode).ToString();
                        string strque = "ItemCode = '{0}'";
                        DataRow result = dtMedicalDetail.Select(string.Format(strque, itemcodeTemp)).FirstOrDefault();
                        if (result != null)
                        {
                            {
                                DataRow row = result;


                                this.dtMedicalDetail_Check.Rows.Add(row.ItemArray);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(" Lỗi khi lấy dữ liệu duyệt thuốc " + itemcodeTemp + " !\n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.getListCheckOnGridViewMedicalDetail();
                this.LoadList();
                if (this.gridView_List.RowCount > 0)
                {
                    this.GetListItemMedicalChecked();
                    string sMsgError = string.Empty;
                    decimal dAmountEnd = 0, dQuantity = 0, dAmountExp = 0;
                    foreach (DataRow r in dtMedicalDetail_Check.Rows)
                    {
                        dAmountExp = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dVirtual, repositoryCode, ref dAmountEnd);
                        if (dQuantity > dAmountEnd)
                        {
                            sMsgError += r["ItemName"].ToString() + " tồn hiện tại: " + dAmountEnd.ToString("N0");
                            bcheckInventory = false;
                        }
                    }
                    if (bcheckInventory)
                    {
                        SystemParameterInf para = new SystemParameterInf();
                        para = SystemParameterBLL.ObjParameter(200);
                        string sSort = string.Empty;
                        if (para != null && para.Values == 1)
                        {
                            bImportDate = true;
                            sSort += "DateImport,";
                        }
                        para = SystemParameterBLL.ObjParameter(201);
                        if (para != null && para.Values == 1)
                        {
                            bShipment = true;
                            sSort += "Shipment,";
                        }
                        para = SystemParameterBLL.ObjParameter(202);
                        if (para != null && para.Values == 1)
                        {
                            bDateEnd = true;
                            sSort += "DateEnd,";
                        }
                        string sItemCode = string.Empty;
                        MedicinesForPatients Medi = new MedicinesForPatients();
                        Medi.MedicalRecordCode = this.medicalCode;
                        Medi.PatientReceiveID = dReceiveID;
                        Medi.PatientCode = patientCode;
                        Medi.EmployeeCode = this.userid;
                        Medi.MM = DateTime.Now.Month;
                        Medi.YYYY = DateTime.Now.Year;
                        Medi.ObjectCode = iObjectCode;
                        Medi.RowID = 0;
                        Medi.shiftWork = this.shiftWork;
                        //Medi.DateApproved = DateTime.Now;
                        if (MedicinesForPatientsBLL.Ins(Medi, ref dRowIDMedicines) >= 1)
                        {
                            bool isGiaThuocDanhMuc = false;
                            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
                            if (objSys != null && objSys.RowID > 0)
                            {
                                isGiaThuocDanhMuc = objSys.Values.Equals(1) ? true : false;
                            }
                            decimal dQuanReal = 0, dQuanRequest = 0;
                            foreach (DataRow r in dtMedicalDetail_Check.Rows)
                            {
                                dQuanRequest = Convert.ToDecimal(r["Quantity"].ToString());
                                dQuanReal = 0;
                                sItemCode = r["ItemCode"].ToString();
                                List<InventoryGumshoeInf> lst = InventoryBLL.ListInventoryGumshoe(sItemCode, repositoryCode, sSort.TrimEnd(','), isGiaThuocDanhMuc);
                                if (lst != null && lst.Count > 0)
                                {
                                    MedicinesForPatientsDetail MediDetail = new MedicinesForPatientsDetail();
                                    MediDetail.MedicalRecordCode = this.medicalCode;
                                    foreach (var v in lst)
                                    {
                                        dQuanReal = v.AmountImport - v.AmountExport;
                                        if (dQuanReal >= dQuanRequest && dQuanReal > 0)
                                        {
                                            MediDetail.ItemCode = v.ItemCode;
                                            MediDetail.DateOfIssues = Convert.ToInt32(r["DateOfIssues"].ToString());
                                            MediDetail.ObjectCode = iObjectCode;
                                            MediDetail.Quantity = dQuanRequest;
                                            MediDetail.QuantityExport = dQuanRequest;
                                            MediDetail.SalesPrice = v.SalesPrice;
                                            MediDetail.BHYTPrice = v.BHYTPrice;
                                            if (MediDetail.ObjectCode.Equals(1) || MediDetail.ObjectCode.Equals(5))
                                                MediDetail.UnitPrice = MediDetail.BHYTPrice;
                                            else
                                                MediDetail.UnitPrice = MediDetail.SalesPrice;
                                            MediDetail.Amount = dQuanRequest * MediDetail.UnitPrice;
                                            MediDetail.RowIDInventoryGumshoe = v.RowID;
                                            MediDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                            MediDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                            MediDetail.RowIDMedicines = dRowIDMedicines;
                                            MediDetail.RowIDMedicalPrescription = Convert.ToDecimal(r["RowID"].ToString());
                                            MedicinesForPatientsBLL.InsDetail(MediDetail);
                                            break;
                                        }
                                        else if (dQuanReal > 0)
                                        {
                                            MediDetail.ItemCode = v.ItemCode;
                                            MediDetail.DateOfIssues = Convert.ToInt32(r["DateOfIssues"].ToString());
                                            MediDetail.Quantity = dQuanReal;
                                            MediDetail.QuantityExport = dQuanReal;
                                            MediDetail.ObjectCode = iObjectCode;
                                            MediDetail.SalesPrice = v.SalesPrice;
                                            MediDetail.BHYTPrice = v.BHYTPrice;
                                            if (MediDetail.ObjectCode.Equals(1) || MediDetail.ObjectCode.Equals(5))
                                                MediDetail.UnitPrice = MediDetail.BHYTPrice;
                                            else
                                                MediDetail.UnitPrice = MediDetail.SalesPrice;
                                            MediDetail.Amount = dQuanReal * MediDetail.UnitPrice;
                                            MediDetail.RowIDInventoryGumshoe = v.RowID;
                                            MediDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                            MediDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                            MediDetail.RowIDMedicines = dRowIDMedicines;
                                            MediDetail.RowIDMedicalPrescription = Convert.ToDecimal(r["RowID"].ToString());
                                            MedicinesForPatientsBLL.InsDetail(MediDetail);
                                            dQuanRequest = dQuanRequest - dQuanReal;
                                        }
                                    }
                                }
                                else
                                {
                                    MedicinesForPatientsBLL.Del(this.medicalCode, dRowIDMedicines, this.userid);
                                    XtraMessageBox.Show(" Lỗi khi trừ tồn kho, liên hệ quản trị ! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            XtraMessageBox.Show(" Duyệt thuốc thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ClearInfo();
                            this.dtMedicalDetail.Clear();
                            this.dtMedicalDetail_Check.Clear();
                            this.LoadWaitingList();
                            this.butOK.Enabled = false;
                        }
                        else
                        {
                            MedicinesForPatientsBLL.Del(this.medicalCode, dRowIDMedicines, this.userid);
                            XtraMessageBox.Show(" Lỗi khi duyệt toa, xem lại thông tin toa thuốc.!\n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Những thuốc sau không đủ tồn: \n\t" + sMsgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Toa thuốc kê không phát sinh thuốc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadWaitingList();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.medicalCode))
                {
                    if (XtraMessageBox.Show("Bạn có muốn hủy phiếu duyệt kho này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            bool isPaid = true;
                            foreach (DataRow row in this.dtMedicalDetail.Rows)
                            {
                                if (row["Paid"].ToString().Equals("1"))
                                {
                                    isPaid = false;
                                    break;
                                }
                            }
                            Int32 result = MedicinesForPatientsBLL.Del(this.medicalCode, dRowIDMedicines, this.userid);
                            if (isPaid)
                            {
                                if (result == 1)
                                {
                                    XtraMessageBox.Show(" Hủy duyệt toa thuốc thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.dtMedicalDetail.Clear();
                                    this.ClearInfo();
                                    this.LoadWaitingList();
                                    this.butCancel.Enabled = false;
                                    return;
                                }
                                else if (result == -2)
                                {
                                    XtraMessageBox.Show(" Toa thuốc đã phát cho bệnh nhân, không được phép hủy.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else if (result == -3)
                                {
                                    XtraMessageBox.Show(" Chỉ cho phép hủy khi user đó duyệt, tài khoản này không phải người duyệt toa trước đó!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    XtraMessageBox.Show(" Bệnh nhân đã thanh toán không cho phép hủy.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(" Bệnh nhân đã thanh toán không cho phép hủy.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        catch { return; }
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chọn bệnh nhân để hủy phiếu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

      

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.patientCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientCode).ToString();
                        this.medicalCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_MedicalRecordCode).ToString();
                        this.dReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientReceiveID).ToString());
                        this.iObjectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectCode).ToString());
                        this.dRowIDMedicines = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, this.col_List_RowIDMedicinesFor).ToString());
                        if (patientCode != string.Empty && dReceiveID != 0 && this.medicalCode != string.Empty && iObjectCode != 0)
                        {
                            this.LoadList();
                            if (iObjectCode == 1)
                            {
                                List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dReceiveID);
                                if (lstBHYT != null && lstBHYT.Count > 0)
                                {
                                    sTheBHYT = lstBHYT[0].Serial;
                                    this.lbSothe.Text = lstBHYT[0].Serial;
                                    this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                    this.iTraituyen = lstBHYT[0].TraiTuyen;
                                    this.chkTraiTuyen.Checked = iTraituyen == 1 ? true : false;
                                    this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                    this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                    this.GetCardInfo(lstBHYT[0].Serial);
                                    this.VisableBHYT(true);
                                }
                            }
                            this.GetInfoPatient();
                            if (this.rdDone.Checked)
                            {
                                this.butOK.Enabled = false;
                                this.butCancel.Enabled = false;
                            }
                            if (this.rdNo.Checked)
                                this.butOK.Enabled = true;
                            else if (this.rdYes.Checked)
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
                XtraMessageBox.Show("Chọn bệnh nhân đã cấp toa để hủy cấp phát toa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Int32 result = 0;
            result = MedicinesForPatientsBLL.UpdForDone(this.medicalCode, this.dRowIDMedicines, this.userid, this.rdDone.Checked ? 0 : 1, this.dReceiveID);
            if (result == 1)
            {
                this.LoadWaitingList();
            }
            if (result == -2)
            {
                XtraMessageBox.Show("Bệnh nhân đã kết thúc điều trị, không được duyệt cấp toa BHYT!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                XtraMessageBox.Show("Chỉ cho phép hủy khi user đó duyệt, tài khoản này không phải người duyệt toa trước đó!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}