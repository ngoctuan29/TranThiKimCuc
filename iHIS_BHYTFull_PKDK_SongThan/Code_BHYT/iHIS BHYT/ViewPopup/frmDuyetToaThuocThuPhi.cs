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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmDuyetToaThuocThuPhi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty;
        private string exportCode = string.Empty;
        private string medicalCode = string.Empty;
        private decimal dReceiveID = 0;
        private string userid = string.Empty, sTheBHYT = string.Empty;
        private DataTable dtMedicalDetail = new DataTable();
        private DataTable dtMedicalDetail_Check = new DataTable();
        private List<DrugChecked> listCheckTemp = new List<DrugChecked>();
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
        private DataTable dtotalBHYT = new DataTable();
        private decimal amountBHYTtemp = 0;
        private List<SuggestedViewInf> lstViewDV = new List<SuggestedViewInf>();
        private List<SuggestedViewMedicinesInf> lstViewThuoc = new List<SuggestedViewMedicinesInf>();
        private Int32 iTile = 0;
        private DataTable tableDetailPayment = new DataTable();
        private int  iCapcuu = 0, iChuyenvien = 0;
        private class DrugChecked
        {
            public string itemCode { get; set; }
            public decimal  Quality { get; set; }
            public decimal Amount { get; set; }
        }
        public frmDuyetToaThuocThuPhi(string _user, string _repositoryCode, string _shiftWork)
        {
            InitializeComponent();
            this.userid = _user;
            this.repositoryCode = _repositoryCode;
            this.shiftWork = _shiftWork;
        }

        private void ClearInfo()
        {
            try
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
                this.dtMedicalDetail = MedicalRecord_BLL.DTMedicalRecordApprove(this.medicalCode, this.iObjectCode, this.repositoryCode, iStatus, this.dRowIDMedicines, this.chkObjectCode.Checked ? 1 : -1);
                this.gridControl_List.DataSource = this.dtMedicalDetail;
            }
            catch { }
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

        private void frmDuyetToaThuocThuPhi_Load(object sender, EventArgs e)
        {
            try
            {
                this.replkup_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.replkup_ObjectCode.DisplayMember = "ObjectName";
                this.replkup_ObjectCode.ValueMember = "ObjectCode";
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

        //private void GetCardInfo(string sCard)
        //{
        //    try
        //    {
        //        string sMaBHYT = sCard.Substring(0, 3);
        //        RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
        //        if (model != null || model.RateCard != string.Empty)
        //        {
        //            if (chkTraiTuyen.Checked == true)
        //                lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
        //            else
        //                lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
        //        }
        //    }
        //    catch { }
        //}
        private void GetCardInfo(string cardBHYT, ref int rateBHYT)
        {
            try
            {
                string sMaBHYT = cardBHYT.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (this.chkTraiTuyen.Checked)
                    {
                        if (this.chkGiayChuyenVien.Checked || this.chkCapCuu.Checked)
                        {
                            this.iTile = model.RateTrue;
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                        }
                        else
                        {
                            this.iTile = model.RateFalse;
                            this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                        }
                    }
                    else
                    {
                        this.iTile = model.RateTrue;
                        this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                    }
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
        private void AddItemCodeToListCheckTemp(DrugChecked drug)
        {
            if(!string.IsNullOrEmpty(drug.itemCode))
            {
                try {
                    if (this.listCheckTemp.Count > 0)
                    {
                        var temp = this.listCheckTemp.FirstOrDefault(p => p.itemCode == drug.itemCode);
                        if (temp ==null)
                        {
                            this.listCheckTemp.Add(drug);
                        }
                    }
                    else { this.listCheckTemp.Add(drug); }
                }catch(Exception ex) { }
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
                    decimal Quality = 0;
                    decimal Amount = 0;
                    try
                    {
                       
                        itemcode = this.gridView_List.GetRowCellValue(index, this.col_ItemCode).ToString();
                        Quality = Convert.ToDecimal(( this.gridView_List.GetRowCellValue(index, this.col_Quantity)??0).ToString());
                        Amount = Convert.ToDecimal((this.gridView_List.GetRowCellValue(index, this.col_Amount) ?? 0).ToString());
                        if (!string.IsNullOrEmpty(itemcode))
                        {
                            DrugChecked drug = new DrugChecked();
                            drug.itemCode = itemcode;
                            drug.Quality = Quality;
                            drug.Amount = Amount;
                            this.AddItemCodeToListCheckTemp(drug);
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
                if (!string.IsNullOrEmpty(itemcodeTemp.itemCode))
                {
                    // string itemcode = string.Empty;
                    try
                    {
                        // itemcode = this.gridView_List.GetRowCellValue(index, this.col_ItemCode).ToString();
                        string strque = "ItemCode = '{0}'";
                        DataRow result = dtMedicalDetail.Select(string.Format(strque, itemcodeTemp.itemCode)).FirstOrDefault();
                        if (result != null)
                        {
                            {
                                result["Quantity"] = itemcodeTemp.Quality;
                                result["Amount"] = itemcodeTemp.Amount;
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
                    this.GetListItemMedicalChecked(); //Tuấn thêm
                    string sMsgError = string.Empty;
                    decimal dAmountEnd = 0, dQuantity = 0, dAmountExp = 0;
                    if (this.dtMedicalDetail_Check.Rows.Count < 1)
                        return;
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
                                            //MediDetail.ObjectCode = iObjectCode;
                                            MediDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
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
                                            //MediDetail.ObjectCode = iObjectCode;
                                            MediDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
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
                            bool isPaid = false;
                            foreach (DataRow row in this.dtMedicalDetail.Rows)
                            {
                                if (row["Paid"].ToString().Equals("1"))
                                {
                                    isPaid = true;
                                    break;
                                }
                            }
                           
                            if (!isPaid)
                            {
                                Int32 result = MedicinesForPatientsBLL.Del(this.medicalCode, dRowIDMedicines, this.userid);
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

        private void chkObjectCode_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.lstViewDV.Clear();
                        this.patientCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientCode).ToString();
                        this.medicalCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_MedicalRecordCode).ToString();
                        this.dReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientReceiveID).ToString());
                        this.iObjectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectCode).ToString());
                        this.dRowIDMedicines = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, this.col_List_RowIDMedicinesFor).ToString());
                        if (patientCode != string.Empty && dReceiveID != 0 && this.medicalCode != string.Empty && iObjectCode != 0)
                        {
                            this.LoadList();
                            this.gridView_List.SelectAll(); 
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
                                    int rateBHYT = 0;
                                    this.GetCardInfo(lstBHYT[0].Serial, ref rateBHYT);
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
                            this.chkObjectCode.Checked = false;
                          this.GetTotalServiceMedical();
                            this.col_Quantity.OptionsColumn.AllowEdit = false;
                            if(rdNo.Checked ==true)
                            this.btnSuaSoLuongThuoc.Enabled = true;
                            else
                                this.btnSuaSoLuongThuoc.Enabled = false;
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
            if (this.rdYes.Checked)
            {
                this.LoadWaitingList();
                this.chkObjectCode.ReadOnly = true;
                this.chkObjectCode.Checked = false;
            }
        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdNo.Checked)
            {
                this.LoadWaitingList();
                this.chkObjectCode.ReadOnly = false;
            }
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

        private void btnSuaSoLuongThuoc_Click(object sender, EventArgs e)
        {
            this.col_Quantity.OptionsColumn.AllowEdit = true;
          this.col_Quantity.OptionsColumn.ReadOnly = false;
            this.btnSuaSoLuongThuoc.Enabled = false;
        }

        private void gridView_List_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            decimal _quantity = 0;
            decimal _itemPrice = 0;
          
            try
            {
                GridView view = sender as GridView;
                if (view.SelectedRowsCount > 0)
                {

                    int focusindex = view.FocusedRowHandle;
                    //int[] lstchecked = this.gridView_List.GetSelectedRows();
                    //if (lstchecked.FindIndex(focusindex))
                    if (this.gridView_List.GetSelectedRows().Contains(focusindex))
                    {
                        if (view.FocusedColumn.FieldName == "Quantity")
                        {
                            _quantity = Convert.ToDecimal(e.Value);
                            _itemPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_UnitPrice));
                            decimal _Amount = _quantity * _itemPrice;
                            view.SetFocusedRowCellValue(col_Amount, _Amount);
                        }
                    }
                    else
                    {
                        view.SetFocusedRowCellValue(col_Amount, 0);
                    }
                       
                    
                }
            }
            catch { }
            }

        private void gridView_List_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try {

                GridView view = sender as GridView;
                if (e.Action == CollectionChangeAction.Add)
                {
                    decimal _quantity = 0;
                    decimal _itemPrice = 0;



                    _quantity = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Quantity));
                    _itemPrice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_UnitPrice));
                    decimal _Amount = _quantity * _itemPrice;
                    view.SetFocusedRowCellValue(col_Amount, _Amount);
                }
                else if (e.Action == CollectionChangeAction.Remove)
                {
                    view.SetFocusedRowCellValue(this.col_Amount, 0);
                    this.gridView_List.RefreshData();
                }
            }
            catch { }

        }

        private void GetTotalServiceMedical()
        {
            decimal amountBHYTTotal = 0;
            decimal amountBHYTTotalObject = 0;
            
            this.dtotalBHYT = SuggestedServiceReceiptBLL.CheckTotalBHYT(this.dReceiveID);
            foreach (DataRow dr in dtotalBHYT.Rows)
            {
                amountBHYTTotalObject += Convert.ToDecimal(dr["TotalBHYT"].ToString());
            }
            this.amountBHYTtemp = amountBHYTTotalObject;
            // lay lai tong tien amountBHYTTotal
            this.ListService(ref amountBHYTTotal, true);
            this.ListMedical(ref amountBHYTTotal, true);
            #region tinh lai BHYT cho dich vu va thuoc
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var v in this.lstViewDV)
                    {
                        if (v.ObjectCode == 1)
                        {
                            v.BHYTPay = v.Quantity * v.ServicePrice;
                            v.PatientPay = 0;
                            v.PatientPayReal = v.Quantity * v.DisparityPrice;
                        }
                    }
                }
            }
            //this.gridControl_ListBanksAccount.DataSource = this.lstViewDV;
            //this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
            //this.gridView_ListBanksAccount.ExpandAllGroups();
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var items in this.lstViewThuoc)
                    {
                        if (items.ObjectCode == 1)
                        {
                            items.BHYTPay = items.Quantity * items.UnitPrice;
                            items.PatientPay = 0;
                        }
                    }
                }
            }
          //  this.gridControl_List.DataSource = this.lstViewThuoc;
            #endregion

            // Lấy toa bán lẻ vào thu viện phí.
            //this.ListMedicinesRetail();

            //Load bien lai tam ung cua bn
            this.LoadDataFeePaymentDetail();
            this.SumAmountTotal(string.Empty);
            //this.txtAmountBHYT_BHYTPay.Text = amountBHYTTotal.ToString("N0");
        }
        private void LoadDataFeePaymentDetail()
        {
            this.tableDetailPayment = Fee_Advance_PaymentBLL.TableAdvance_PaymentDetail(this.dReceiveID, this.patientCode, 0, 1);
          //  this.gridControl_FeePayment.DataSource = this.tableDetailPayment;
            decimal totalAmountReal = 0;
            foreach (DataRow row in this.tableDetailPayment.Rows)
            {
                totalAmountReal += Convert.ToDecimal(row["AmountReal"]);
            }
          //  this.txtTotalPayment.EditValue = totalAmountReal.ToString("N0");
        }
        public void ListService(ref decimal amountTotalService, bool isReset)
        {
            try
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (this.lstViewDV.Count <= 0)
                    this.lstViewDV = SuggestedServiceReceiptBLL.ListView(this.patientCode, this.dReceiveID, 0,string.Empty, this.amountBHYTtemp, bhytpara.BHYTUnderPrice);
                decimal dBHYT = 0;
                foreach (var v in this.lstViewDV)
                {
                    if (v.Check.Equals(1))
                    {
                        if (this.iObjectCode == 1)
                        {
                            if (v.ObjectCode == 1)
                            {
                                if (isReset)
                                {
                                    dBHYT = (((v.Quantity * v.ServicePrice) * this.iTile) / 100);
                                    v.BHYTPay = dBHYT;
                                    v.PatientPay = (v.Quantity * v.ServicePrice) - dBHYT - v.ServicePriceSalesOff;
                                    v.Amount = (v.Quantity * v.ServicePrice);
                                    v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                                    amountTotalService += (v.Quantity * v.ServicePrice);
                                }
                                else
                                {
                                    amountTotalService += (v.Quantity * v.ServicePrice);
                                }
                            }
                            else
                            {
                                v.PatientPay = (v.Quantity * v.ServicePrice) - v.ServicePriceSalesOff;
                                v.BHYTPay = 0;
                                v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                                v.Amount = (v.Quantity * v.ServicePrice);
                            }
                        }
                        else
                        {
                            v.PatientPay = (v.Quantity * v.ServicePrice) - v.ServicePriceSalesOff;
                            v.BHYTPay = 0;
                            v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                            v.Amount = (v.Quantity * v.ServicePrice);
                        }
                    }
                }
            }
            catch { }
        }

        private void ListMedical(ref decimal amountTotalMedical, bool isReset)
        {
            try
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (this.lstViewThuoc.Count <= 0)
                    this.lstViewThuoc = SuggestedServiceReceiptBLL.ListMedicalView(this.patientCode, this.dReceiveID, 0, string.Empty, this.amountBHYTtemp, bhytpara.BHYTUnderPrice);
                List<SuggestedViewMedicinesInf> lstViewThuocReal = this.lstViewThuoc.Where(p => p.Check == 1).ToList();
                decimal dBHYTReal = 0, dPatientReal = 0;
                foreach (var v in lstViewThuocReal)
                {
                    if (iObjectCode == 1)
                    {
                        if (v.ObjectCode == 1)
                        {
                            if (isReset)
                            {
                                dBHYTReal = ((v.BHYTPay * iTile) / 100);
                                dPatientReal = (v.PatientPay + v.BHYTPay - dBHYTReal);
                                v.PatientPay = dPatientReal - v.ServicePriceSalesOff;
                                v.BHYTPay = dBHYTReal;
                                v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                                amountTotalMedical += v.Quantity * v.UnitPrice;
                            }
                            else
                                amountTotalMedical += v.Quantity * v.UnitPrice;
                        }
                        else
                        {
                            dBHYTReal = v.Amount;
                            dPatientReal = v.Amount - v.ServicePriceSalesOff;
                            v.PatientPay = dPatientReal;
                            v.BHYTPay = 0;
                            v.PatientPayReal = dPatientReal + (v.DisparityPrice * v.Quantity);
                        }
                    }
                    else
                    {
                        dBHYTReal = v.Amount;
                        dPatientReal = v.Amount - v.ServicePriceSalesOff;
                        v.PatientPay = dPatientReal;
                        v.BHYTPay = 0;
                        v.PatientPayReal = dPatientReal + (v.DisparityPrice * v.Quantity);
                    }
                }
            }
            catch { }
        }
        public void SumAmountTotal(string rowIDSuggested)
        {
            decimal dCDHA = 0, dKCB = 0, dPTTT = 0, dXN = 0, dKhac = 0, dMau = 0, dVC = 0, dGiuong = 0;
            decimal dDVDisparity = 0, dDVTotal = 0, dDVBHYTToal = 0;
            decimal dThuocBHYTChiTra = 0, dThuocThuPhi = 0, dThuocBHYTTotal = 0, dThuocBHYT_BNChiTra = 0;
            decimal totalPayBHYT = 0, totalDVThuPhi = 0, totalDiscount = 0, totalBHYT_PatientPay = 0;
            try
            {
                // lay theo check tren grid
                ////txtDiscount.Value = txtAmountDiscount.Value = 0;
                //DataTable dtAmountService = new DataTable();
                //dtAmountService = BanksAccountBLL.TableSumAmountServiceDetail(this.dPatientReceiveID, this.txtMabn.Text.Trim().ToUpper(), rowIDSuggested, this.iPaid, this.bankEntryCode);
                List<SuggestedViewInf> lstViewReal = this.lstViewDV.Where(p => p.Check.Equals(1)).ToList();
                List<SuggestedViewMedicinesInf> lstMedicinesReal = this.lstViewThuoc.Where(p => p.Check.Equals(1)).ToList();
                //foreach (DataRow dr in dtAmountService.Rows)
                //{
                foreach (var v in lstViewReal)
                {
                    dDVDisparity += v.DisparityPrice * v.Quantity;
                    if (v.ServiceModuleCode == "CDHA")
                        dCDHA += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "KCB")
                        dKCB += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "PTTT")
                        dPTTT += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "XN")
                        dXN += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "VC")
                        dVC += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "GIUONG")
                        dGiuong += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "MAU")
                        dMau += v.ServicePrice * v.Quantity;
                    else
                        dKhac += v.ServicePrice * v.Quantity;
                }
                //}
                //this.lbCDHA_TDCN.Text = dCDHA.ToString("N0");
                //this.lbKCB.Text = dKCB.ToString("N0");
                //this.lbPT_TT.Text = dPTTT.ToString("N0");
                //this.lbXN.Text = dXN.ToString("N0");
                //this.lbKhac.Text = dKhac.ToString("N0");
                //this.lbVC.Text = dVC.ToString("N0");
                //this.lbGiuong.Text = dGiuong.ToString("N0");
                //this.lbMau.Text = dMau.ToString("N0");
                //this.lbTHUOC_VTYT.Text = "0";
                foreach (var vservice in lstViewReal)
                {
                    if (vservice.ObjectCode == 1)
                    {
                        dDVBHYTToal += (vservice.Quantity * vservice.ServicePrice);
                        totalBHYT_PatientPay += vservice.Amount - vservice.BHYTPay;
                    }
                    else
                        totalDVThuPhi += (vservice.Quantity * vservice.ServicePrice);
                    totalPayBHYT += vservice.BHYTPay;
                    totalDiscount += vservice.ServicePriceSalesOff;
                }
                //if (!this.chkService.Checked)
                //{
                    if (lstMedicinesReal.Count > 0)
                    {
                        foreach (var items in lstMedicinesReal)
                        {
                            if (items.ObjectCode != 5 && items.ObjectCode.Equals(1))
                            {
                                dThuocBHYTChiTra += items.BHYTPay;
                                dThuocBHYT_BNChiTra += items.PatientPay;
                                dThuocBHYTTotal += items.BHYTPay + items.PatientPay;
                            }
                            else if (items.ObjectCode != 5 && !items.ObjectCode.Equals(1))
                                dThuocThuPhi += items.PatientPay;
                            // totalPayBHYT += items.BHYTPay;
                            dDVDisparity += items.DisparityPrice * items.Quantity;
                        }
                    //    this.lbTHUOC_VTYT.Text = (dThuocBHYTChiTra + dThuocThuPhi + dThuocBHYT_BNChiTra).ToString("N0");
                    }
               // }
                dDVTotal = (dCDHA + dKCB + dPTTT + dXN + dKhac + dMau + dVC + dGiuong);
                this.txtAmount.Text = (dDVTotal + dThuocBHYTChiTra + dThuocThuPhi + dThuocBHYT_BNChiTra + dDVDisparity).ToString("N0");
                this.txtAmountBHYT.EditValue = dDVBHYTToal + dThuocBHYTTotal;
                this.txtAmountThuphi.Text = (totalDVThuPhi + dThuocThuPhi).ToString("N0");
                this.txtAmountBHYT_BHYTPay.EditValue = (totalPayBHYT + dThuocBHYTChiTra).ToString("N0");
                this.txtAmountBHYT_PatientPay.EditValue = totalBHYT_PatientPay + dThuocBHYT_BNChiTra;
                this.txtAmountReal.Text = (totalDVThuPhi + dThuocThuPhi + dDVDisparity).ToString("N0");
                this.txtAmountDiscount.Value = totalDiscount;
                this.txtAmountPhuthu.Text = dDVDisparity.ToString("N0");
                if (this.iObjectCode.Equals(1))
                {
                    BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                    if ((dDVBHYTToal + dThuocBHYTTotal) <= bhytpara.BHYTUnderPrice && iTraituyen == 0)
                    {
                        this.txtAmountReal.Text = dDVDisparity.ToString("N0");
                        this.txtAmountBHYT_PatientPay.Text = "0";
                    }
                    else if ((dDVBHYTToal + dThuocBHYTTotal) > bhytpara.BHYTUnderPrice && (dDVBHYTToal + dThuocBHYTTotal) <= bhytpara.BHYTOnPrice)
                        this.txtAmountReal.Text = (totalDVThuPhi + dThuocThuPhi + dDVDisparity).ToString("N0");
                    else if ((dDVBHYTToal + dThuocBHYTTotal) >= bhytpara.BHYTOnPrice)
                        this.txtAmountReal.Text = ((totalDVThuPhi + dThuocThuPhi + dDVDisparity) - bhytpara.BHYTOnPrice).ToString("N0");
                }
                this.txtAmountReal.EditValue = Convert.ToDecimal(this.txtAmountBHYT_PatientPay.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountThuphi.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountPhuthu.EditValue.ToString()) - Convert.ToDecimal(this.txtAmountDiscount.EditValue.ToString()) - Convert.ToDecimal(this.txtTotalPayment.EditValue);
                if (Convert.ToDecimal(this.txtAmountReal.EditValue) < 0)
                    this.lbAmountReal.Text = "Hoàn trả :";
                else
                    this.lbAmountReal.Text = "Thực thu :";
            }
            catch { }
        }
    }
}