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
    public partial class frmTheoDoi_ThuocVTTH : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string banksAccountCode = string.Empty;
        private int quantity = 0;
        private decimal receiptID = 0;
        private string patientCode = string.Empty;
        private string serviceCode = string.Empty;
        private string exportCode = string.Empty;
        private string referenceCode = string.Empty;
        private decimal dReceiveID = 0;
        private string employeeCode = string.Empty;
        private string departmentCodeOrder = string.Empty;
        private int patientType = 0, paid = 0;
        private string sUserid = string.Empty, sTheBHYT = string.Empty;
        private decimal dRowIDMedicines = 0;
        private int iObjectCode = 0,iTraituyen = 0;
        private string repositoryCode = string.Empty, shiftWork = string.Empty;
        private decimal dRealID = 0;
        private DataTable dtMedicalDetail = new DataTable();
        public frmTheoDoi_ThuocVTTH(string _userID, string _repositoryCode, string _shiftWork)
        {
            InitializeComponent();
            this.sUserid = _userID;
            this.repositoryCode = _repositoryCode;
            this.shiftWork = _shiftWork;
        }

        private void ClearInfo()
        {
            try
            {
                this.patientCode = this.exportCode = this.referenceCode = this.sTheBHYT = string.Empty;
                this.iObjectCode = this.iTraituyen = 0;
                this.dRowIDMedicines = this.dReceiveID = 0;
                this.lbTileBHYT.Text = this.lbMabn01.Text = this.lbHoten01.Text = this.lbNamsinh01.Text = this.lbTuoi01.Text = this.lbGioitinh01.Text = this.lbDiachi01.Text = string.Empty;
                this.lbSothe.Text = this.lbTungay.Text = this.lbNoiDKKCB.Text = this.lbTungay.Text = this.lbDenngay.Text = this.lbTongchiphi01.Text = this.lbBHYTTra01.Text = this.lbBenhNhantra01.Text = string.Empty;
                this.chkTraiTuyen.Checked = false;
                Bitmap b = new Bitmap("NoImgPatient.jpeg");
                this.picPatient.Image = (Bitmap)b;
                this.gridControl_List.DataSource = null;
            }
            catch { }
        }
        
        private void frmCapToa_Load(object sender, EventArgs e)
        {
            try {

                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = Utils.DateServer();
                this.LoadPatient();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
        
        private void butOK_Click(object sender, EventArgs e)
        {
           
            try
            {
                bool success = false;
                if (this.gridView_List.RowCount > 0 && this.dtMedicalDetail.Select("Checks=1").Length>0)
                {
                    DataTable tableDetail_Real = this.dtMedicalDetail.Select("Checks=1").CopyToDataTable();
                    decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                    bool bcheckInventory = true, bImportDate = false, bShipment = false, bDateEnd = false;
                    bool bcheckQuantity = true;
                    string sMsgError = string.Empty, sMsgErrorQuantity = string.Empty;
                    foreach (DataRow r in this.dtMedicalDetail.Rows)
                    {
                        if(Convert.ToInt32(r["Checks"].ToString())==1)
                        {
                            dQuantity = dAmountEnd = dQuantityReq = 0;
                            dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                            dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, this.repositoryCode, ref dAmountEnd);
                            if (dQuantityReq <= 0)
                            {
                                sMsgErrorQuantity += r["ItemName"].ToString() + " số lượng: " + dQuantityReq.ToString("N0");
                                bcheckQuantity = false;
                            }
                            if (dAmountEnd < dQuantityReq)
                            {
                                sMsgError += r["ItemName"].ToString() + " tồn hiện tại: " + dAmountEnd.ToString("N0");
                                bcheckInventory = false;
                            }
                        }
                        
                    }
                    if (!bcheckQuantity)
                    {
                        XtraMessageBox.Show(" Những thuốc sau chưa nhập số lượng \n\t" + sMsgErrorQuantity, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (bcheckInventory)
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
                        RealMedicinesForPatients_VTTH_AttachInf infReal = new RealMedicinesForPatients_VTTH_AttachInf();
                        {
                            infReal.RowID = dRealID;
                            infReal.RefCode = this.referenceCode;
                            infReal.PatientReceiveID = dReceiveID;
                            infReal.PatientCode = this.patientCode;
                            infReal.EmployeeCode = this.sUserid;
                            infReal.ObjectCode = iObjectCode;
                            infReal.PatientType = this.patientType;                      
                            infReal.Status = 1;
                            infReal.DepartmentCode = this.departmentCodeOrder;
                            infReal.ShiftWork = this.shiftWork;
                            infReal.DateApproved = Utils.DateTimeServer();
                            infReal.ServiceCode = this.serviceCode;
                            infReal.SuggestedID = this.receiptID;
                            infReal.BanksAccountCode = this.banksAccountCode;
                        };
                        if (RealMedicinesForPatients_VTTH_AttachBLL.InsReal(infReal, ref dRealID) > 0)
                        {
                            bool bResult = true;
                            //RealMedicinesForPatientsBLL.DelRealDetailOnly(dRealID);
                            if (this.dtMedicalDetail != null && this.dtMedicalDetail.Rows.Count > 0)
                            {
                                bool isGiaThuocDanhMuc = false;
                                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
                                if (objSys != null && objSys.RowID > 0)
                                {
                                    isGiaThuocDanhMuc = objSys.Values.Equals(1) ? true : false;
                                }
                                foreach (DataRow r in tableDetail_Real.Rows)
                                {
                                    decimal dQuantityRequest = Convert.ToDecimal(r["Quantity"].ToString());
                                    decimal dQuantityReal = 0;
                                    sItemCode = r["ItemCode"].ToString();
                                    List<InventoryGumshoeInf> lst = InventoryBLL.ListInventoryGumshoe(sItemCode, this.repositoryCode, sSort.TrimEnd(','), isGiaThuocDanhMuc);
                                    if (lst != null && lst.Count > 0)
                                    {
                                        RealMedicinesForPatients_VTTH_Attach_DetailInf mDetail = new RealMedicinesForPatients_VTTH_Attach_DetailInf();
                                        foreach (var v in lst)
                                        {
                                            dQuantityReal = v.AmountImport - v.AmountExport;
                                            if (dQuantityReal >= dQuantityRequest)
                                            {
                                                mDetail.RealRowID = dRealID;
                                                mDetail.ItemCode = r["ItemCode"].ToString();
                                                mDetail.Quantity = dQuantityRequest;
                                                mDetail.SalesPrice = v.SalesPrice;
                                                mDetail.BHYTPrice = v.BHYTPrice;
                                                ///mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                                mDetail.RowIDInventoryGumshoe = v.RowID;
                                                //mDetail.RateBHYT = GetCardInfo();
                                                mDetail.RateBHYT = 0;
                                                mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                                ///mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                                if (mDetail.ObjectCode.Equals(1) || mDetail.ObjectCode.Equals(5))
                                                    mDetail.UnitPrice = v.BHYTPrice;
                                                else
                                                    mDetail.UnitPrice = mDetail.SalesPrice;
                                                mDetail.Amount = dQuantityRequest * mDetail.UnitPrice;
                                                mDetail.RepositoryCode = this.repositoryCode;
                                                mDetail.Instruction = string.Empty;
                                                if (r["RowID"].ToString() != string.Empty)
                                                    mDetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                                                else
                                                    mDetail.RowID = 0;
                                                mDetail.BanksAccountCode = this.banksAccountCode;
                                                mDetail.Paid = this.paid;
                                                RealMedicinesForPatients_VTTH_AttachBLL.InsRealDetail(mDetail);
                                                break;
                                        }
                                            else
                                            {
                                            mDetail.RealRowID = dRealID;
                                            mDetail.ItemCode = v.ItemCode;
                                            mDetail.Quantity = dQuantityReal;
                                            mDetail.SalesPrice = v.SalesPrice;
                                            mDetail.BHYTPrice = v.BHYTPrice;
                                            ///mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                            mDetail.RowIDInventoryGumshoe = v.RowID;
                                            mDetail.RateBHYT = 0;
                                            mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                            mDetail.UnitPrice = v.UnitPrice;
                                            if (mDetail.ObjectCode.Equals(1) || mDetail.ObjectCode.Equals(5))
                                                mDetail.UnitPrice = v.BHYTPrice;
                                            else
                                                mDetail.UnitPrice = v.SalesPrice;
                                            mDetail.Amount = dQuantityReal * mDetail.UnitPrice;
                                            mDetail.RepositoryCode = this.repositoryCode;
                                            mDetail.Instruction = string.Empty;
                                            if (r["RowID"].ToString() != string.Empty)
                                                mDetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                                            else
                                                mDetail.RowID = 0;
                                             mDetail.BanksAccountCode = this.banksAccountCode;
                                             mDetail.Paid = this.paid;
                                                RealMedicinesForPatients_VTTH_AttachBLL.InsRealDetail(mDetail);
                                            dQuantityRequest = dQuantityRequest - dQuantityReal;
                                        }
                                    }
                                    }
                                    else
                                    {
                                        //bResult = false;
                                        //RealMedicinesForPatientsBLL.DelRealDetailAll(dRealID);
                                        //XtraMessageBox.Show(" Tồn kho không đủ để cấp thuốc, liên hệ quản trị! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        //success = false;
                                    }
                                }
                            }
                            if (bResult)
                            {
                                XtraMessageBox.Show(" Lưu thành công đơn thuốc! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                success = true;
                                ClearInfo();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Lưu đơn thuốc không thành công! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                success = false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(" Lưu đơn thuốc không thành công ! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            success = false;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Thuốc không đủ tồn : \n\t" + sMsgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        success = false;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chọn vật tư tiêu hao cần duyệt!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex) {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadPatient();
        }
        
        private void LoadPatient()
        {
            try
            {            
                this.gridControl_WaitingList.DataSource = null;
                this.ClearInfo();
                int paid = 0;
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(505);
                if (objSys != null && objSys.RowID > 0)
                    paid = objSys.Values;
                 if(this.rdYes.Checked==true)
                {
                    this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DataWaitingDV(Convert.ToDateTime(dtimeFrom.EditValue), Convert.ToDateTime(dtimeTo.EditValue), 0, paid);
                    this.butOK.Enabled = true;
                    this.butCancel.Enabled = false;
                }
                else
                {
                    this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DataWaitingDV(Convert.ToDateTime(dtimeFrom.EditValue), Convert.ToDateTime(dtimeTo.EditValue), 1, paid);
                    this.butOK.Enabled = false;
                    this.butCancel.Enabled = true;
                }                            
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Get data waiting fail: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void butCancel_Click(object sender, EventArgs e)
        {          
            try
            {
                Int32 iResult = 0;
                this.dtMedicalDetail = RealMedicinesForPatients_VTTH_AttachBLL.DTRealMedicinesForPatients_VTTH_Attach_Detail(this.serviceCode);
                foreach (DataRow dr in dtMedicalDetail.Rows)
                {
                    if (Convert.ToInt32(dr["Checks"].ToString()) == 1)
                        iResult = RealMedicinesForPatients_VTTH_AttachBLL.Del_RealMedicinesForPatients_VTTH_Attach_Detail(Convert.ToDecimal(dr["RealRowID"].ToString()), dr["ItemCode"].ToString(), Convert.ToDecimal(dr["RowID"].ToString()));
                }
                if (iResult == 1)
                {
                    XtraMessageBox.Show(" Xóa thành công !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dtMedicalDetail = RealMedicinesForPatients_VTTH_AttachBLL.DTRealMedicinesForEmergency_VTTH_Attach_Detail(this.dRealID);
                    gridControl_List.DataSource = this.dtMedicalDetail;
                    LoadDetail();
                    ClearInfo();
                    //butOK.Visible=true;
                    //butCancel.Visible = false;
                    return;
                }
                else if (iResult == -1)
                {
                    XtraMessageBox.Show(" Xoá không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(" Chọn thuốc đã cấp để xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(" Error" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
  
        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.receiptID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_ReceiptID).ToString());
                this.quantity = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_Quantity).ToString());
                this.serviceCode= gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_ServiceCode).ToString();
                this.patientCode= gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString();               
                this.patientType = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_PatientType).ToString());
                this.departmentCodeOrder = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_DepartmentCodeOrder).ToString();  
                this.referenceCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_ReferenceCode).ToString();
                this.banksAccountCode = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_BanksAccountCode).ToString();
                this.paid = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_Paid).ToString());
                if (gridView_WaitingList.RowCount > 0)
                {
                    if (gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.patientCode = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientCode).ToString(), string.Empty);
                        this.iObjectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectCode).ToString());                        
                        this.dReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_PatientReceiveID).ToString());
                        this.GetInfoPatient();
                        this.LoadDetail();
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
        private void LoadDetail()
        {
            this.dtMedicalDetail = TemplateItemNormsBLL.dtItemNormsDetail(this.serviceCode);
            this.gridControl_List.DataSource = this.dtMedicalDetail;
        }
    }
}