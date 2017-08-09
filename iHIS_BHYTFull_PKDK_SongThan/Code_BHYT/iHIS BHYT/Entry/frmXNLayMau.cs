using System;
using System.IO;
using System.Threading;
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
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Entry
{
    public partial class frmXNLayMau : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private decimal RowIDLaboratory = 0;
        private string patientCode = string.Empty;
        private string patientGenderName = string.Empty;
        private string CategoryCode = string.Empty;
        private decimal PatientReceiveID = 0;
        private string ReferenceCode = string.Empty;

        private Int32 iStatus = 0, iObjectCode = 0;
        private string s_makp = string.Empty, s_userCode = string.Empty, s_loaixn = string.Empty;
        
        private DataTable dtResult = new DataTable();
        private string sBankCode = string.Empty;

        private string s_module = "XN";

        public frmXNLayMau(string smakp, string userCode)
        {
            InitializeComponent();
            s_makp = smakp;
            s_userCode = userCode;
            //s_loaixn = loaixn;

            grWaitingList.Visible = true;
            grWaitingList.Dock = DockStyle.Fill;
            
            gridView_Result.OptionsBehavior.ReadOnly = true;
            gridView_Result.OptionsBehavior.Editable = false;

            txtSTT.Properties.ReadOnly = true;
            butNew.Enabled = butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;
        }

        private void frmXNLayMau_Load(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dtResultTemp = LaboratoryResultDescriptionBLL.DT_LabResultDescription();
                foreach (DataRow dr in dtResultTemp.Rows)
                {
                    ref_Description_Result.Items.Add(dr["DescriptionResult"].ToString());
                }
                lkXetNghiem.Properties.DataSource = ServiceCategoryBLL.ListServiceCategory(s_module, "");
                lkXetNghiem.Properties.DisplayMember = "ServiceCategoryName";
                lkXetNghiem.Properties.ValueMember = "ServiceCategoryCode";
            }
            catch { }
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
        
        private void butSave_Click(object sender, EventArgs e)
        {
            if (PatientReceiveID != 0 && patientCode != string.Empty)
            {
                if (txtSTT.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Chưa nhập số thứ tự khi lấy mẫu.", "Bệnh viện điện tử .NET");
                    txtSTT.Focus();
                    return;
                }
                if (gridView_Result.RowCount > 0)
                {
                    try
                    {
                        ServiceLaboratoryEntryINF LaboratoryEntry = new ServiceLaboratoryEntryINF();
                        {
                            LaboratoryEntry.RowID = RowIDLaboratory;
                            LaboratoryEntry.PatientCode = patientCode;
                            LaboratoryEntry.ReferenceCode = ReferenceCode;
                            LaboratoryEntry.Conclusion = txtConclusion.Text;
                            LaboratoryEntry.Proposal = txtProposal.Text;
                            LaboratoryEntry.PostingDate = DateTime.Now;
                            LaboratoryEntry.PatientReceiveID = PatientReceiveID;
                            LaboratoryEntry.ServiceCategoryCode = CategoryCode;
                            LaboratoryEntry.Status = 2;
                            LaboratoryEntry.EmployeeCode = s_userCode;
                            LaboratoryEntry.ObjectCode = iObjectCode;
                            LaboratoryEntry.STT = this.txtSTT.Text.Trim();
                        };
                        if (ServiceLaboratoryEntryBLL.InsLaboratoryEntry(LaboratoryEntry, ref RowIDLaboratory) > 0)
                        {
                            foreach (DataRow dr in dtResult.Rows)
                            {
                                ServiceLaboratoryDetailINF InsertDetail = new ServiceLaboratoryDetailINF();
                                {
                                    InsertDetail.RowIDLaboratoryEnTry = RowIDLaboratory;
                                    InsertDetail.ServiceCode = dr["ServiceCode"].ToString();
                                    InsertDetail.UnitValues = dr["UnitValues"].ToString();
                                    InsertDetail.ValuesEntry = dr["ValuesEntry"].ToString();
                                    InsertDetail.ValuedFemale = dr["ValuedFemale"].ToString();
                                    InsertDetail.ValuedMale = dr["ValuedMale"].ToString();
                                    InsertDetail.MinValuedFemale = Convert.ToDecimal(dr["MinValuedFemale"].ToString());
                                    InsertDetail.MaxValuedFemale = Convert.ToDecimal(dr["MaxValuedFemale"].ToString());
                                    InsertDetail.MinValuedMale = Convert.ToDecimal(dr["MinValuedMale"].ToString());
                                    InsertDetail.MaxValuedMale = Convert.ToDecimal(dr["MaxValuedMale"].ToString());
                                    InsertDetail.LaboratoryName = dr["LaboratoryName"].ToString();
                                    InsertDetail.Normal = Convert.ToInt32(dr["Normal"].ToString());
                                };
                                ServiceLaboratoryEntryBLL.InsLaboratoryDetail(InsertDetail, 2);
                            }
                            ServiceLaboratoryEntryBLL.UpdSuggestedServiceReceipt(RowIDLaboratory, 2);
                        }

                        XtraMessageBox.Show(" Đã lưu lấy mẫu xét nghiệm!\t\n-OK.", "Bệnh viện điện tử .NET");
                        enableField(false);
                        PatientReceiveID = 0; 
                        patientCode = string.Empty;
                        butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;
                        butNew.Enabled = true;
                        gridView_Result.OptionsBehavior.ReadOnly = true;
                        gridView_Result.OptionsBehavior.Editable = false;
                        dtResult.Clear();
                        //gridControl_Result.DataSource = dtResult;
                        butReload_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi khi lưu lấy mẫu xét nghiệm!\t\nYêu cầu kiểm tra lại thông tin trước khi lưu: " + ex.Message, "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Yêu cầu chọn gói xét nghiệm.", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn đợt thực hiện để sửa thông tin!", "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (patientCode != string.Empty && CategoryCode != string.Empty && PatientReceiveID > 0 && ReferenceCode != string.Empty)
                {
                    if (iStatus == 0)
                    {
                        
                        enableField(true);
                        cleanerField();
                        GetLaboratoryDetail();
                        txtSTT.Text = ServiceLaboratoryEntryBLL.GetSTT(s_loaixn).ToString();
                        gridView_Result.OptionsBehavior.AutoPopulateColumns = true;
                        gridView_Result.OptionsBehavior.ReadOnly = false;
                        gridView_Result.OptionsBehavior.Editable = true;
                        
                        butNew.Enabled = butCancel.Enabled = false;
                        butSave.Enabled = butUndo.Enabled = true;
                        
                    }
                    else
                    {
                        XtraMessageBox.Show("Đã lẫy mẫu xét nghiệm!\t\nChỉ được xem và sửa nội dung.", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Bệnh nhân chưa qua đăng ký xét nghiệm!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký lại.", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi nhập trả kết quả: " + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        public void loadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(500);
            if (objSys != null && objSys.RowID > 0)
            {
                s_loaixn = lkXetNghiem.EditValue.ToString();
                gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingGetTemplate(DateTime.Now, iStatus, s_makp, objSys.Values, s_loaixn);
            }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkWaiting.Checked)
                    loadListPatientWaitingCompleted(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void CheckCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckCompleted.Checked)
                    loadListPatientWaitingCompleted(2);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn: " + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkWaiting.Checked == true)
                {
                    loadListPatientWaitingCompleted(0);
                }
                if (CheckCompleted.Checked == true)
                {
                    loadListPatientWaitingCompleted(2);
                }
            }
            catch
            {
                return;
            }
        }

        public void enableField(bool ena)
        {
            txtConclusion.Enabled = txtProposal.Enabled = txtSTT.Enabled = ena;
        }

        public void cleanerField()
        {
            gridControl_Result.DataSource = null;
            txtConclusion.Text = txtProposal.Text = string.Empty;
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            grWaitingList.Visible = true;
            grWaitingList.Dock = DockStyle.Fill;

            grMain.Text = "Quản lý lấy mẫu xét nghiệm!";
            butReload_Click(sender, e);
            enableField(false);
            cleanerField();
            checkWaiting.Checked = true;
            loadListPatientWaitingCompleted(0);
            butNew.Enabled = butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_WaitingList.RowCount > 0)
                {
                    if (gridView_WaitingList.GetFocusedRow() != null)
                    {
                       
                        //grWaitingList.Visible = false;
                        //grWaitingList.Dock = DockStyle.None;
                        
                        RowIDLaboratory = ISDBNULL2DECIMAL(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RowIDLaboratory).ToString(), string.Empty);
                        patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        patientGenderName = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString(), string.Empty);
                        CategoryCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ServiceCategoryCode).ToString(), string.Empty);
                        iStatus = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Status));
                        PatientReceiveID = ISDBNULL2DECIMAL(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RefID).ToString(), string.Empty);
                        ReferenceCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString(), string.Empty);
                        iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                        txtSTT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_STT).ToString();
                        string name = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString(), string.Empty);
                        string year = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString(), string.Empty);
                        string address = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientAddress).ToString(), string.Empty);
                        string ObjectName = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString(), string.Empty);
                        grMain.Text = "Họ tên: " + name + " | Giới tính: " + patientGenderName + " | Năm sinh: " + year + " | Địa chỉ: " + address + " | " + "Đối tượng: " + ObjectName;
                        
                        if (iStatus == 0)
                            butNew.Enabled = true;
                        else
                            butUndo.Enabled = butCancel.Enabled = true;
                        GetLaboratoryDetail();
                        
                        gridView_Result.OptionsBehavior.AutoPopulateColumns = true;
                        gridView_Result.OptionsBehavior.ReadOnly = false;
                        gridView_Result.OptionsBehavior.Editable = true;

                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn bệnh nhân:\t\n" + ex.Message, "Bệnh viện điện tử .NET");
                return;
            }
        }

        private void GetLaboratoryDetail()
        {
            try
            {
                dtResult = ServiceLaboratoryEntryBLL.DT_Get_LaboratoryPackageDetail(PatientReceiveID, patientCode, ReferenceCode, iStatus, CategoryCode, RowIDLaboratory, string.Empty);
                gridControl_Result.DataSource = dtResult;
                gridView_Result.BeginSort();
                gridView_Result.ClearGrouping();
                gridView_Result.Columns["ServiceName"].GroupIndex = 1;
                gridView_Result.Columns[1].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            }
            catch { }
            finally
            {
                gridView_Result.EndSort();
            }
        }

        private void frmXNLayMau_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: butReload_Click(sender, e); break;                    //F5 - Refresh
                case Keys.F1: butContinues_Click(sender, e); break;                 //F1 - Bệnh nhân tiếp
                case Keys.F2: butNew_Click(sender, e); break;                       //F2 - Thực hiện
                case Keys.F3: butSave_Click(sender, e); break;                      //F3 - Lưu
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                txtConclusion.Text = txtProposal.Text = string.Empty;
                txtConclusion.Enabled = txtProposal.Enabled = false;                
                
                butNew.Enabled = butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;

                gridControl_Result.DataSource = null;
                gridView_Result.OptionsBehavior.ReadOnly = true;
                gridView_Result.OptionsBehavior.Editable = false;

                cleanerField();
                enableField(true);
            }
            catch
            {
                return;
            }
        }
                
        private decimal ParseQuantity(string qty)
        {
            decimal sl1 = 0;
            string[] arr;
            if (!string.IsNullOrEmpty(qty.Trim()))
            {
                arr = qty.Trim().Split('/');
                if (arr.Length == 2)
                {
                    try
                    {
                        int tu = int.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                        int mau = int.Parse(arr[1].Trim() == "" ? "1" : arr[1].Trim());
                        sl1 = (decimal)(tu * (1M) / mau);
                    }
                    catch { }
                }
                else
                    if (arr.Length > 0)
                    {
                        try
                        {
                            sl1 = decimal.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                        }
                        catch { }
                    }
            }
            return sl1;
        }

        private void ref_Description_Result_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBoxEdit cbEdit = sender as ComboBoxEdit;
                decimal dValue = 0;
                string sNormalMale = string.Empty, sNormalFeMale = string.Empty;
                decimal dMinMale = 0, dMaxMale = 0;
                decimal dMinFeMale = 0, dMaxFeMale = 0;
                if (CheckNumber(cbEdit.Text.ToString(), ref dValue))
                {
                    if (patientGenderName == "Nam")
                    {
                        dMinMale = RowIDLaboratory = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MinValuedMale).ToString(), string.Empty);
                        dMaxMale = RowIDLaboratory = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MaxValuedMale).ToString(), string.Empty);
                        if (dMaxMale == 0 && dValue > dMinMale)
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                        else if (dMinMale == 0 && dValue < dMaxMale)
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                        else if (dValue < dMinMale || dValue > dMaxMale)
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                        else
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 0);
                    }
                    else
                    {
                        dMinFeMale = RowIDLaboratory = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MinValuedFemale).ToString(), string.Empty);
                        dMaxFeMale = RowIDLaboratory = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MaxValuedFemale).ToString(), string.Empty);
                        if (dMaxFeMale == 0 && dValue > dMinFeMale)
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                        else if (dMinFeMale == 0 && dValue < dMaxFeMale)
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                        else if (dValue < dMinFeMale || dValue > dMaxFeMale)
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                        else
                            gridView_Result.SetFocusedRowCellValue(col_Normal, 0);
                    }
                }
            }
            catch { }
        }

        private bool CheckNumber(string sValue, ref decimal dValue)
        {
            try
            {
                decimal dNumber;
                bool isNum = decimal.TryParse(sValue, out dNumber);
                if (isNum)
                {
                    dValue = dNumber;
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        private void txtSTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch { return; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (RowIDLaboratory > 0 && patientCode != string.Empty && PatientReceiveID != 0)
                {
                    if (ServiceLaboratoryEntryBLL.DelLaboratoryTemplate(RowIDLaboratory) == 1)
                    {
                        XtraMessageBox.Show(" Hủy lấy mẫu xét nghiệm thành công!", "Bệnh viện điện tử .NET");
                        butNew.Enabled = butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Mẫu xét nghiệm đã đọc trả kết quả không được phép hủy!", "Bệnh viện điện tử .NET");
                        butNew.Enabled = butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chưa chọn bệnh nhân hủy kết quả lấy mẫu!", "Bệnh viện điện tử .NET");
                    butNew.Enabled = butSave.Enabled = butUndo.Enabled = butCancel.Enabled = false;
                }
                
            }
            catch { }
        }

        private void lkXetNghiem_EditValueChanged(object sender, EventArgs e)
        {
            butReload_Click(sender, e);
        }

    }
}