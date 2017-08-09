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
using Ps.Clinic.ViewPopup;
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
    public partial class frmXuatTuTruc : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUserCode = string.Empty, shiftWork = string.Empty;
        private string patientCode = string.Empty;
        private Int32 iStatus = 0, iPatientType = 0;
        private string sMedicalCode = string.Empty;
        private string sBankCode = string.Empty;
        private string sExportCode = string.Empty;
        private decimal dReceiveID = 0;
        private string sMakp = string.Empty;
        private int iObjectCode = 0;
        private DataTable dtMedicalRecord_Material = new DataTable();
        private string sTheBHYT = string.Empty;
        private int iTraituyen = 0;
        private DateTime dtReceive = new DateTime();
        private DataTable lstItem_Tutruc = new DataTable();
        private decimal dRealID = 0;
        private DataView clone = null;
        private DateTime dtWorking = new DateTime();
        public frmXuatTuTruc(string _smakp, string _suserCode, decimal _dReceiveID, string _patientCode, Int32 _iObjectCode, string _sMedicalCode, Int32 _iPatientType, string _sTheBHYT, Int32 _iTraituyen, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.sMakp = _smakp;
            this.sUserCode = _suserCode;
            this.dReceiveID = _dReceiveID;
            this.patientCode = _patientCode;
            this.iObjectCode = _iObjectCode;
            this.sMedicalCode = _sMedicalCode;
            this.iPatientType = _iPatientType;
            this.sTheBHYT = _sTheBHYT;
            this.iTraituyen = _iTraituyen;
            this.shiftWork = _shiftWork;
            this.ref_Material_UoM.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty,"I");
            this.ref_Material_UoM.DisplayMember = "UnitOfMeasureName";
            this.ref_Material_UoM.ValueMember = "UnitOfMeasureCode";
            this.dtWorking = Convert.ToDateTime(_dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
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
        
        private void frmXuatTuTruc_Load(object sender, EventArgs e)
        {
            try
            {
                this.ref_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.ref_ObjectCode.DisplayMember = "ObjectName";
                this.ref_ObjectCode.ValueMember = "ObjectCode";
                this.repMaterial_Usage.DataSource = UsageBLL.ListUsage(string.Empty);
                this.repMaterial_Usage.DisplayMember = "UsageName";
                this.repMaterial_Usage.ValueMember = "UsageCode";
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(206);
                if (objSys != null && objSys.RowID > 0)
                {
                    txtDate.Properties.ReadOnly = false;
                }
                this.GetInfoPatient(this.patientCode);
                this.Load_TreeView();
                List<InstructionInf> lstInstruc = InstructionBLL.ListInstruction(0);
                foreach (var v in lstInstruc)
                {
                    this.rep_Out_Instruction.Items.Add(v.InstructionName);
                }
                this.LoadRepository();
                this.gridView_Material.OptionsBehavior.ReadOnly = true;
                this.gridView_Material.OptionsBehavior.Editable = false;
                this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.dtReceive = Utils.DateTimeServer();
                this.txtDate.EditValue = this.dtWorking;
                this.EnableButton(true);
                this.LoadMedicalRecord();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Lỗi phát sinh khi khám bệnh\t\n-Liên hệ admin để kiểm tra lỗi: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void EnableButton(bool b)
        {
            try
            {
                this.butPrintPrescription.Enabled = b;
                this.butNew.Enabled = b;
                this.butSave.Enabled = !b;
                this.butUndo.Enabled = !b;
                this.butCancel.Enabled = false;
                this.butPrintPrescription.Enabled = b;
                this.butEdit.Enabled = false;
            }
            catch { }
        }

        private void frmXuatTuTruc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2: butNew_Click(sender, e); break;                   //F2 - Moi
                case Keys.F3: butSave_Click(sender, e); break;                  //F3 - Lưu
                case Keys.F6: butPrintPrescription_Click(sender, e); break;     //F6 - In toa
                case Keys.F5: CoppyMedicines(); break;                          //F5 - Coppy toa thuoc
            }
        }

        private void butPrintPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.iObjectCode.Equals(1))
                {
                    this.PrintPrescription(1);
                    this.PrintPrescription_Out(2);
                    this.PrintPrescription_Out(5);
                }
                else
                {
                    this.PrintPrescription_Out(this.iObjectCode);
                    this.PrintPrescription_Out(5);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void PrintPrescription(int objectCodeTemp)
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtEmergency = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergency(sMedicalCode, this.patientCode, dReceiveID, this.iPatientType);
                if (dtEmergency.Rows.Count > 0)
                {
                    DataTable dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(dRealID, objectCodeTemp, true);
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(sMedicalCode,this.patientCode, this.dReceiveID);
                    DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(dReceiveID);
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtEmergency);
                    dsTemp.Tables.Add(dtEmergencyDetail);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.Tables.Add(dtBHYT);
                    if (dtEmergencyDetail != null && dtEmergencyDetail.Rows.Count > 0)
                    {
                        if (this.iPatientType.Equals(1))
                        {
                            dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptThuocTuTruc.xml");
                            Reports.rptThuocTuTruc rptShow = new Reports.rptThuocTuTruc();
                            rptShow.Parameters["prObjectCode"].Value = this.iObjectCode;
                            rptShow.DataSource = dsTemp;
                            Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ThuocTuTruc","Thuốc tủ trực");
                            rpt.ShowDialog();
                        }
                        else
                        {
                            dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptThuocTuTruc.xml");
                            Reports.rptThuocTuTrucCC rptShow = new Reports.rptThuocTuTrucCC();
                            rptShow.Parameters["prObjectCode"].Value = this.iObjectCode;
                            rptShow.DataSource = dsTemp;
                            Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ThuocTuTruc", "Thuốc tủ trực");
                            rpt.ShowDialog();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Không có dữ liệu phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            butSave.Enabled = butUndo.Enabled = butCancel.Enabled = true;
            butNew.Enabled = txtDate.Enabled = butPrintPrescription.Enabled = butEdit.Enabled = false;
            gridView_Material.OptionsBehavior.ReadOnly = false;
            gridView_Material.OptionsBehavior.Editable = true;
            gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.butUndo.Enabled = this.butSave.Enabled = false;
                if (iStatus == 1)
                    this.butPrintPrescription.Enabled = true;
                else
                    this.butPrintPrescription.Enabled = false;
                this.butNew.Enabled = true;
                this.EnableButton(true);
                this.txtDate.EditValue = Utils.DateTimeServer();
                this.txtDate.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtMedicalRecord_Material.Rows.Count > 0)
                {
                    if (this.UpdateMaterial_RealMedicines(this.sMedicalCode))
                    {
                        this.Load_TreeView();
                        this.gridView_Material.OptionsBehavior.ReadOnly = true;
                        this.gridView_Material.OptionsBehavior.Editable = false;
                        this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        this.txtDate.EditValue = Utils.DateTimeServer();
                        this.txtDate.Enabled = true;
                        this.LoadRepository();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Không có thuốc phát sinh! Hãy nhập thuốc trước khi lưu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtDate.Text.Trim()))
                {
                    this.LoadMedicalRecord();
                    if (this.dtMedicalRecord_Material.Rows.Count > 0)
                    {
                        this.butSave.Enabled = this.butNew.Enabled = false;
                        this.butPrintPrescription.Enabled = true;
                    }
                    else
                    {
                        this.butSave.Enabled = this.butPrintPrescription.Enabled = false;
                    }
                    this.gridView_Material.OptionsBehavior.ReadOnly = false;
                    this.gridView_Material.OptionsBehavior.Editable = true;
                    this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    this.LoadRepository();
                    this.EnableButton(false);
                    this.txtDate.Enabled = false;
                }
                else
                {
                    this.dtMedicalRecord_Material.Clear();
                    this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
                    XtraMessageBox.Show(" Chọn ngày cấp toa thuốc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void LoadMedicalRecord()
        {
            this.dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicinesForEmergency(this.sMedicalCode, this.iObjectCode, this.sMakp, 3, Convert.ToDateTime(this.txtDate.Text.Trim()), ref dRealID);
            this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
            if (this.dtMedicalRecord_Material != null && this.dtMedicalRecord_Material.Rows.Count > 0)
                this.butEdit.Enabled = true;
        }

        private void LoadRepository()
        {
            this.lstItem_Tutruc = ItemsBLL.DT_ListItemsRef(0, this.sMakp, "3");
            this.repsearchMaterial_Item.DataSource = this.lstItem_Tutruc;
            this.repsearchMaterial_Item.DisplayMember = "ItemName";
            this.repsearchMaterial_Item.ValueMember = "ItemCode";
        }
        
        private void GetInfoPatient(string sPatient)
        {
            PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.dReceiveID);
            if (objPatient != null && objPatient.PatientCode != null)
            {
                //lbMabn01.Text = objPatient.PatientCode;
                //lbHoten01.Text = objPatient.PatientName;
                //lbNamsinh01.Text = objPatient.PatientBirthyear.ToString();
                //lbTuoi01.Text = objPatient.PatientAge.ToString();
                string genderName = string.Empty;
                if (objPatient.PatientGender == 0)
                    genderName = "Nữ";
                else
                    genderName = "Nam";
                //lbDiachi01.Text = objPatient.PatientAddress;
                this.groupInfoMedical.Text = "Mã BN: " + objPatient.PatientCode + " | Họ tên: " + objPatient.PatientName + " NS: " + objPatient.PatientBirthyear.ToString() + " Tuổi( " + objPatient.PatientAge.ToString() + ") - Giới tính: " + genderName + " | Địa chỉ: " + objPatient.PatientAddress + ", " + objPatient.WardName + ", " + objPatient.DistrictName + ", " + objPatient.ProvincialName;

                //if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                //{
                //    Byte[] imageadata = new Byte[0];
                //    imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                //    MemoryStream memo = new MemoryStream(imageadata);
                //    Bitmap b = new Bitmap(Image.FromStream(memo));
                //    picPatient.Image = (Bitmap)b;
                //}
            }
            else
                return;
        }

        private void gridView_Material_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            int rowfocus = e.RowHandle;
            try
            {
                string stempItemcode = view.GetRowCellValue(rowfocus, col_Material_ItemCode).ToString();
                if (stempItemcode == null || stempItemcode == "")
                {
                    e.Valid = false;
                    view.SetColumnError(col_Material_ItemCode, " Chọn thuốc cần kê toa!");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Material_Quantity, " Số lượng yêu cầu lớn hơn 0!");
                }
                //if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_UnitPrice)), 1) <= 0)
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_Material_UnitPrice, "Chưa khai đơn giá cho vật tư tiêu hao!");
                //}
                if (e.Valid)
                {
                    decimal unitPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_UnitPrice));
                    decimal salesPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_SalesPrice));
                    decimal bhytPriceTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_BHYTPrice));
                    decimal quantityTemp = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Material_Quantity));
                    Int32 listBHYTTemp = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Material_ListBHYT));
                    if (this.iObjectCode.Equals(1) || this.iObjectCode.Equals(5))
                    {
                        if (listBHYTTemp.Equals(1))
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * bhytPriceTemp);
                        else
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * salesPriceTemp);
                    }
                    else
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, quantityTemp * salesPriceTemp);
                }
            }
            catch { return; }
        }

        private void gridView_Material_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Quantity")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }   
        }

        private void gridView_Material_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int checkPaid = Convert.ToInt32(this.gridView_Material.GetRowCellValue(this.gridView_Material.FocusedRowHandle, this.col_Material_Paid).ToString());
                    if (checkPaid <= 0)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa thuốc đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            decimal tempRealID = Convert.ToDecimal(gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_RealRowID).ToString());
                            string tempItemCode = gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_ItemCode).ToString();
                            decimal tempRowID = Convert.ToDecimal(gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_RowID).ToString());
                            Int32 iResult = RealMedicinesForPatientsBLL.DelRealDetailForItems(tempRealID, tempItemCode, tempRowID);
                            if (iResult >= 1)
                            {
                                this.LoadMedicalRecord();
                                if (this.dtMedicalRecord_Material.Rows.Count <= 0)
                                    this.EnableButton(true);
                                this.Load_TreeView();
                            }
                            else
                            {
                                XtraMessageBox.Show("Thuốc đang chọn đã thanh toán! Không cho phép xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Thuốc đang chọn đã thanh toán! Không cho phép xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Material_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Phiếu xuất thuốc thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private bool UpdateMaterial_RealMedicines(string sMedicalCode)
        {
            try
            {
                bool success = false;
                if (this.gridView_Material.RowCount != 0)
                {
                    decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                    bool bcheckInventory = true, bImportDate = false, bShipment = false, bDateEnd = false;
                    bool bcheckQuantity = true;
                    string sMsgError = string.Empty, sMsgErrorQuantity = string.Empty;
                    foreach (DataRow r in this.dtMedicalRecord_Material.Rows)
                    {
                        if (Convert.ToInt32(r["New"].ToString()) == 0)
                        {
                            dQuantity = dAmountEnd = dQuantityReq = 0;
                            dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                            dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, r["RepositoryCode"].ToString(), ref dAmountEnd);
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
                        RealMedicinesForPatientsINF infReal = new RealMedicinesForPatientsINF();
                        {
                            infReal.RowID = dRealID;
                            infReal.RefCode = sMedicalCode;
                            infReal.PatientReceiveID = dReceiveID;
                            infReal.PatientCode = this.patientCode;
                            infReal.EmployeeCode = sUserCode;
                            infReal.ObjectCode = iObjectCode;
                            infReal.PatientType = this.iPatientType;
                            infReal.VoteRowID = 1;
                            infReal.Status = 1;
                            infReal.DepartmentCode = this.sMakp;
                            infReal.ShiftWork = this.shiftWork;
                            infReal.DateApproved = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                        };
                        if (RealMedicinesForPatientsBLL.InsReal(infReal, ref dRealID) > 0)
                        {
                            bool bResult = true;
                            //RealMedicinesForPatientsBLL.DelRealDetailOnly(dRealID);
                            if (this.dtMedicalRecord_Material != null && this.dtMedicalRecord_Material.Rows.Count > 0)
                            {
                                bool isGiaThuocDanhMuc = false;
                                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
                                if (objSys != null && objSys.RowID > 0)
                                {
                                    isGiaThuocDanhMuc = objSys.Values.Equals(1) ? true : false;
                                }
                                foreach (DataRow r in this.dtMedicalRecord_Material.Rows)
                                {
                                    if (Convert.ToInt32(r["New"].ToString()) == 0 && Convert.ToInt32(r["Paid"].ToString()) == 0)
                                    {
                                        decimal dQuantityRequest = Convert.ToDecimal(r["Quantity"].ToString());
                                        decimal dQuantityReal = 0;
                                        sItemCode = r["ItemCode"].ToString();
                                        List<InventoryGumshoeInf> lst = InventoryBLL.ListInventoryGumshoe(sItemCode, r["RepositoryCode"].ToString(), sSort.TrimEnd(','), isGiaThuocDanhMuc);
                                        if (lst != null && lst.Count > 0)
                                        {
                                            RealMedicinesForPatientsDetailINF mDetail = new RealMedicinesForPatientsDetailINF();
                                            foreach (var v in lst)
                                            {
                                                dQuantityReal = v.AmountImport - v.AmountExport;
                                                if (dQuantityReal >= dQuantityRequest)
                                                {
                                                    mDetail.RealRowID = dRealID;
                                                    mDetail.ItemCode = r["ItemCode"].ToString();
                                                    mDetail.Quantity = dQuantityRequest;
                                                    mDetail.SalesPrice = Convert.ToDecimal(r["SalesPrice"].ToString());
                                                    mDetail.BHYTPrice = v.BHYTPrice;
                                                    ///mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                                    mDetail.RowIDInventoryGumshoe = v.RowID;
                                                    mDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                                    mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                                    ///mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                                    if (mDetail.ObjectCode.Equals(1) || mDetail.ObjectCode.Equals(5))
                                                        mDetail.UnitPrice = v.BHYTPrice;
                                                    else
                                                        mDetail.UnitPrice = mDetail.SalesPrice;
                                                    mDetail.Amount = dQuantityRequest * mDetail.UnitPrice;
                                                    mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                                    mDetail.Instruction = r["Instruction"].ToString();
                                                    if (r["RowID"].ToString() != string.Empty)
                                                        mDetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                                                    else
                                                        mDetail.RowID = 0;
                                                    RealMedicinesForPatientsBLL.InsRealDetail(mDetail);
                                                    break;
                                                }
                                                else
                                                {
                                                    mDetail.RealRowID = dRealID;
                                                    mDetail.ItemCode = v.ItemCode;
                                                    mDetail.Quantity = dQuantityReal;
                                                    mDetail.SalesPrice = Convert.ToDecimal(r["SalesPrice"].ToString());
                                                    mDetail.BHYTPrice = v.BHYTPrice;
                                                    ///mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                                    mDetail.RowIDInventoryGumshoe = v.RowID;
                                                    mDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                                    mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                                    mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                                    if (mDetail.ObjectCode.Equals(1) || mDetail.ObjectCode.Equals(5))
                                                        mDetail.UnitPrice = v.BHYTPrice;
                                                    else
                                                        mDetail.UnitPrice = v.SalesPrice;
                                                    mDetail.Amount = dQuantityReal * mDetail.UnitPrice;
                                                    mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                                    mDetail.Instruction = r["Instruction"].ToString();
                                                    if (r["RowID"].ToString() != string.Empty)
                                                        mDetail.RowID = Convert.ToDecimal(r["RowID"].ToString());
                                                    else
                                                        mDetail.RowID = 0;
                                                    RealMedicinesForPatientsBLL.InsRealDetail(mDetail);
                                                    dQuantityRequest = dQuantityRequest - dQuantityReal;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            bResult = false;
                                            RealMedicinesForPatientsBLL.DelRealDetailAll(dRealID);
                                            XtraMessageBox.Show(" Tồn kho không đủ để cấp thuốc, liên hệ quản trị! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            success = false;
                                        }
                                    }
                                }
                            }
                            if (bResult)
                            {
                                XtraMessageBox.Show(" Lưu thành công đơn thuốc! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.butSave.Enabled = false;
                                this.butNew.Enabled = this.butPrintPrescription.Enabled = this.butUndo.Enabled = true;
                                success = true;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Lưu đơn thuốc không thành công! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.butSave.Enabled = false;
                                this.butNew.Enabled = this.butPrintPrescription.Enabled = this.butUndo.Enabled = true;
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
                return success;
            }
            catch { return false; }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_TreeView()
        {
            try
            {
                treeHistory.Nodes.Clear();
                TreeNode node, node1;
                List<RealMedicinesForPatientsINF> lst = RealMedicinesForPatientsBLL.ListForPatientsHistory(sMedicalCode, dReceiveID, this.patientCode);
                foreach (var v in lst)
                {
                    //node = new TreeNode(" Toa thuốc :" + v.DateApproved.ToString("dd/MM/yyyy HH:mm:ss"));
                    node = new TreeNode(" Toa thuốc :" + v.DateApproved.ToString("dd/MM/yyyy HH:mm"));
                    node.Tag = v.RowID + ":" + v.RefCode + ":" + v.DateApproved.ToString("dd/MM/yyyy HH:mm");
                    treeHistory.Nodes.Add(node);
                    ///DataTable dtTemp = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(sMedicalCode, this.patientCode, dReceiveID, v.DateApproved);
                    DataTable dtTemp = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(v.RowID, -1, false);
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        node1 = new TreeNode(r["ItemName"].ToString() + "(" + r["Quantity"].ToString() + ")");
                        node1.Tag = r["RealRowID"].ToString() + v.RefCode + v.DateApproved.ToString("dd/MM/yyyy");
                        node.Nodes.Add(node1);
                    }
                }
            }
            catch { }
        }

        private void treeHistory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //txtDate.Text = treeHistory.SelectedNode.Tag.ToString().Split(':')[1];
                //dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicinesForEmergency(sMedicalCode, iObjectCode, sMakp, 3, Utils.StringToDate(txtDate.Text));
                dRealID = Convert.ToDecimal(this.treeHistory.SelectedNode.Tag.ToString().Split(':')[0]);
                this.dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicinesForEmergency(this.dRealID);
                this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
                if (dtMedicalRecord_Material.Rows.Count > 0)
                {
                    this.butSave.Enabled = this.butNew.Enabled = this.butCancel.Enabled = false;
                    this.butPrintPrescription.Enabled = this.butEdit.Enabled = this.butUndo.Enabled = true;
                    this.txtDate.Enabled = false;
                }
                else
                {
                    this.butSave.Enabled = this.butPrintPrescription.Enabled = this.butEdit.Enabled = false;
                }
            }
            catch { }
        }

        private void CoppyMedicines()
        {
            try
            {
                dRealID = Convert.ToDecimal(treeHistory.SelectedNode.Tag.ToString().Split(':')[0]);
                dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicinesForEmergencyCoppy(dRealID);
                this.gridControl_Material.DataSource = dtMedicalRecord_Material;
                dRealID = 0;
                if (dtMedicalRecord_Material.Rows.Count > 0)
                {
                    this.butSave.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = this.butPrintPrescription.Enabled = true;
                    this.butNew.Enabled = this.txtDate.Enabled = false;
                    this.gridView_Material.OptionsBehavior.ReadOnly = false;
                    this.gridView_Material.OptionsBehavior.Editable = true;
                    this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                }
                else
                {
                    this.butSave.Enabled = this.butPrintPrescription.Enabled = this.butCancel.Enabled = false;
                }
            }
            catch { }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 iResult = 0;
                foreach (DataRow dr in dtMedicalRecord_Material.Rows)
                {
                    if (Convert.ToInt32(dr["Chon"].ToString()) == 1 && Convert.ToInt32(dr["New"].ToString()) == 1)
                        iResult = RealMedicinesForPatientsBLL.DelRealDetailForItems(Convert.ToDecimal(dr["RealRowID"].ToString()), dr["ItemCode"].ToString(), Convert.ToDecimal(dr["RowID"].ToString()));
                }
                if (iResult == 1)
                {
                    XtraMessageBox.Show(" Xóa thành công !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicinesForEmergency(dRealID);
                    gridControl_Material.DataSource = dtMedicalRecord_Material;
                    Load_TreeView();
                    return;
                }
                else if (iResult == -1)
                {
                    XtraMessageBox.Show(" Bệnh nhân đã thanh toán! Không được phép xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(" Chọn thuốc đã cấp để xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void gridView_Material_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is SearchLookUpEdit)
                {
                    DevExpress.XtraEditors.SearchLookUpEdit searchEdit;
                    searchEdit = (SearchLookUpEdit)view.ActiveEditor;
                    DataTable table = this.repsearchMaterial_Item.DataSource as DataTable;
                    this.clone = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    this.clone.RowFilter = "AmountEnd >0 ";
                    searchEdit.Properties.DataSource = this.clone;
                }
                else if (view.FocusedColumn.FieldName == "ObjectCode" && view.ActiveEditor is LookUpEdit)
                {
                    DevExpress.XtraEditors.LookUpEdit objectEdit;
                    objectEdit = (LookUpEdit)view.ActiveEditor;
                    DataTable table = this.ref_ObjectCode.DataSource as DataTable;
                    DataView viewOject = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    if (!this.iObjectCode.Equals(1))
                        viewOject.RowFilter = "ObjectCode <>1";
                    objectEdit.Properties.DataSource = viewOject;
                }
            }
            catch { }
        }
        
        private void gridView_Material_HiddenEditor(object sender, EventArgs e)
        {
            if (clone != null)
            {
                clone.Dispose();
                clone = null;
            }
        }

        private void repsearchMaterial_Item_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string itemCodeoOld = this.gridView_Material.GetFocusedRowCellValue(col_Material_ItemCode).ToString();
                string itemCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemCode").ToString();
                string activeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active").ToString();
                decimal amountEndTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("AmountEnd").ToString());
                decimal safelyQuantityTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SafelyQuantity").ToString());
                string unitOfMeasureCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode").ToString();
                string repositoryNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryName").ToString();
                string repositoryCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryCode").ToString();
                decimal bhytPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("BHYTPrice").ToString());
                decimal salesPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice").ToString());
                Int32 rateBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("RateBHYT").ToString());
                Int32 listBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("ListBHYT").ToString());
                string itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
                string noteTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Note").ToString();
                string usageCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UsageCode").ToString();
                decimal unitPriceTemp = 0;
                int paidTemp = 0;
                if (!string.IsNullOrEmpty(this.gridView_Material.GetFocusedRowCellValue(col_Material_Paid).ToString()))
                    paidTemp = Convert.ToInt32(this.gridView_Material.GetFocusedRowCellValue(col_Material_Paid).ToString());
                if (paidTemp.Equals(1))
                {
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, itemCodeoOld);
                    return;
                }
                DataRow r = Utils.GetPriceRowbyCode(this.dtMedicalRecord_Material, "ItemCode='" + itemCodeTemp + "' and RepositoryCode='" + repositoryCodeTemp + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê trong toa thuốc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, null);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 0);
                }
                else
                {
                    if (amountEndTemp <= safelyQuantityTemp)
                    {
                        if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục cho thuốc ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_SalesPrice, salesPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_BHYTPrice, bhytPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_RateBHYT, rateBHYTTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryCode, repositoryCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryName, repositoryNameTemp);
                            if (this.iObjectCode == 1)
                            {
                                if (listBHYTTemp == 1)
                                {
                                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, this.iObjectCode);
                                    unitPriceTemp = bhytPriceTemp;
                                }
                                else
                                {
                                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, 2);
                                    unitPriceTemp = salesPriceTemp;
                                }
                            }
                            else
                            {
                                this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, iObjectCode);
                                unitPriceTemp = salesPriceTemp;
                            }
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitPrice, unitPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, unitPriceTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemName, itemNameTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Chon, 0);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_New, 0);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_ListBHYT, listBHYTTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Usage, usageCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_Paid, 0);
                        }
                        return;
                    }
                    else if (amountEndTemp == 0)
                    {
                        XtraMessageBox.Show(" Thuốc trong kho đã hết!\t\n Xin vui lòng kê thuôc khác ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_SalesPrice, salesPriceTemp );
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_BHYTPrice, bhytPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_RateBHYT, rateBHYTTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryCode, repositoryCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryName, repositoryNameTemp);
                        if (this.iObjectCode == 1)
                        {
                            if (listBHYTTemp == 1)
                            {
                                this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, this.iObjectCode);
                                unitPriceTemp = bhytPriceTemp;
                            }
                            else
                            {
                                this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, 2);
                                unitPriceTemp = salesPriceTemp;
                            }
                        }
                        else
                        {
                            this.gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, iObjectCode);
                            unitPriceTemp = salesPriceTemp;
                        }
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_UnitPrice, unitPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Amount, unitPriceTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemName, itemNameTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Chon, 0);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_New, 0);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_ListBHYT, listBHYTTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Usage, usageCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(col_Material_Paid, 0);
                    }
                }
                this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
            }
            catch { }
        }

        private void PrintPrescription_Out(int objectCodeTemp)
        {
            DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
            DataTable dtEmergency = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergency(sMedicalCode, this.patientCode, dReceiveID, this.iPatientType);
            if (dtEmergency.Rows.Count > 0)
            {
                DataTable dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(dRealID, objectCodeTemp, true);
                DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(sMedicalCode,this.patientCode, this.dReceiveID);
                DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(dReceiveID);
                DataSet dsTemp = new DataSet("Result");
                dsTemp.Tables.Add(dtClinic);
                dsTemp.Tables.Add(dtEmergency);
                dsTemp.Tables.Add(dtEmergencyDetail);
                dsTemp.Tables.Add(dtSurviveSign);
                dsTemp.Tables.Add(dtBHYT);
                if (dtEmergencyDetail != null && dtEmergencyDetail.Rows.Count > 0)
                {
                    if (this.iPatientType.Equals(1))
                    {
                        dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptThuocTuTruc.xml");
                        string prObjectName = string.Empty;
                        if (objectCodeTemp.Equals(2))
                            prObjectName = "Thu Phí";
                        else if (objectCodeTemp.Equals(5))
                            prObjectName = "Hao Phí";
                        else
                            prObjectName = "Thu Phí";
                        Reports.rptThuocTuTrucThuPhi rptShow = new Reports.rptThuocTuTrucThuPhi();
                        rptShow.Parameters["prObjectName"].Value = prObjectName;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ThuocTuTruc","Dược-Thuốc tủ trực");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptThuocTuTruc.xml");
                        string prObjectName = string.Empty;
                        if (objectCodeTemp.Equals(2))
                            prObjectName = "Thu Phí";
                        else if (objectCodeTemp.Equals(5))
                            prObjectName = "Hao Phí";
                        else
                            prObjectName = "Thu Phí";
                        Reports.rptThuocTuTrucCCThuPhi rptShow = new Reports.rptThuocTuTrucCCThuPhi();
                        rptShow.Parameters["prObjectName"].Value = prObjectName;
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ThuocTuTruc", "Dược-Thuốc tủ trực");
                        rpt.ShowDialog();
                    }
                }                
            }
            else
            {
                XtraMessageBox.Show(" Không có dữ liệu phát sinh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void repositoryItemSearchLookUpEdit1View_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 listBHYT = 0;
                if (e.RowHandle >= 0)
                {
                    listBHYT = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ListBHYT"]));
                    if (listBHYT.Equals(0))
                        e.Appearance.ForeColor = Color.Blue;
                }
            }
            catch { }
        }

        private void gridView_Material_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 paidTemp = 0;
                if (e.RowHandle >= 0)
                {
                    paidTemp = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Paid"]));
                    if (paidTemp == 1)
                    {
                        e.Appearance.ForeColor = Color.Salmon;
                        View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
        }

    }
}