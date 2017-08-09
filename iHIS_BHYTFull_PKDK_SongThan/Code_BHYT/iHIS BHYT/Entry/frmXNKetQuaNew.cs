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
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Entry
{
    public partial class frmXNKetQuaNew : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_makp = string.Empty, s_userCode = string.Empty;
        private string patientCode = string.Empty;
        private decimal patientReceiveID = 0;
        private int objectCode = 0;
        private string serviceGroupCode = "XN";
        private string dateOrder = string.Empty, employeeCodeOrder = string.Empty, employeeDoctorCodeOrder = string.Empty;
        private DataTable dtbResult = new DataTable();
        private DataTable dtbMachine = new DataTable();
        private string pathTemp = string.Empty;
        private string shiftWork = string.Empty;
        private bool bAutoResult = false;
        private string cateAutoResult = string.Empty;
        private string machineCode = string.Empty;
        private bool bEditEmployeeDoctor = false;
        private DateTime dtWorking = new DateTime();
        public frmXNKetQuaNew(string smakp, string userCode, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.s_makp = smakp;
            this.s_userCode = userCode;
            this.shiftWork = _shiftWork;
            this.dtWorking = _dtWorking;
        }

        private void frmXNKetQuaNew_Load(object sender, EventArgs e)
        {
            try
            {
                this.EnableField(true);
                this.dateStart.EditValue = this.dateEnd.EditValue = this.dtWorking.Date;
                DataTable dtResultTemp = LaboratoryResultDescriptionBLL.DT_LabResultDescription();
                foreach (DataRow dr in dtResultTemp.Rows)
                {
                    this.ref_Description_Result.Items.Add(dr["DescriptionResult"].ToString());
                }
                this.repLab_LabPathological.DataSource = LabPathologicalBLL.TableLabPathological();
                this.repLab_LabPathological.DisplayMember = "LabPathologicalName";
                this.repLab_LabPathological.ValueMember = "LabPathologicalID";
                this.GetPatientWaiting(string.Empty);
                this.dateResult.EditValue = this.dtWorking;
                this.txtSTT.Enabled = false;
                this.gridView_Laboratory.Columns["Printer"].Visible = false;
                this.gridView_WaitingList.Columns["OrderDate"].Visible = true;
                this.gridView_WaitingList.Columns["ResultDate"].Visible = false;

                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(401);
                if (objSys != null && objSys.Values == 1)
                {
                    bAutoResult = true;
                    cateAutoResult = objSys.Description;
                }
                objSys = SystemParameterBLL.ObjParameter(402);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.bEditEmployeeDoctor = true;
                    else
                        this.bEditEmployeeDoctor = false;
                }
                this.butHenTraKQ.Enabled = false;
                this.searchLKup_EmployeeCode.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("3,7,8"); ;
                this.searchLKup_EmployeeCode.Properties.DisplayMember = "EmployeeName";
                this.searchLKup_EmployeeCode.Properties.ValueMember = "EmployeeCode";
                this.toolStrip_Options_btnPrintA4.Checked = true;
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetMachine(string categoryCode)
        {
            try
            {
                this.dtbMachine = MachineListsBLL.TableMachineListsForGroup(categoryCode);
                this.cbxMachine.DataSource = this.dtbMachine;
                this.cbxMachine.DisplayMember = "MechineName";
                this.cbxMachine.ValueMember = "RowID";
            }
            catch { return; }
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
            if (this.patientReceiveID != 0 && this.patientCode != string.Empty)
            {
                string categoryCode = this.ISDBNULL2STRING(this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_ServiceCategoryCode).ToString(), string.Empty);
                Int32 labPathologicalID = Convert.ToInt32(this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_LabPathologicalID).ToString());
                if (string.IsNullOrEmpty(this.txtSTT.Text.Trim()) || this.txtSTT.Text.Trim() == "0")
                {
                    XtraMessageBox.Show(" Chưa nhập số barcode lấy mẫu - kết quả xét nghiệm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtSTT.Focus();
                    return;
                }
                if (ServiceLaboratoryEntryBLL.ExistsSTTForLaboratory(categoryCode, Convert.ToInt32(this.txtSTT.Text)) && this.checkWaiting.Checked)
                {
                    if (XtraMessageBox.Show(" ID Mẫu hiện tại đã tồn tại! \r\n Phần mềm tự động cấp lại ID mẫu khác cho bệnh nhân. \r\n [YES] - Phát sinh ID mẫu tiếp theo \r\n [NO] - Nhập ID mẫu theo KTV quản lý. ", "Bệnh viện điện tử .NET.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        this.txtSTT.Text = ServiceLaboratoryEntryBLL.GetIDPatternForReceive(categoryCode, this.patientCode, this.patientReceiveID, labPathologicalID).ToString();
                    else
                    {
                        this.txtSTT.Focus();
                        return;
                    }
                }
                //if (this.searchLKup_EmployeeCode.EditValue == null || string.IsNullOrEmpty(this.searchLKup_EmployeeCode.EditValue.ToString()))
                //{
                //    XtraMessageBox.Show("Chọn bác sỹ trả kết quả xét nghiệm.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.searchLKup_EmployeeCode.Focus();
                //    return;
                //}
                if (this.gridView_Result.RowCount > 0)
                {
                    try
                    {
                        decimal rowIDLaboratory = ISDBNULL2DECIMAL(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_RowIDLaboratory).ToString(), string.Empty);
                        string referenceCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_ReferenceCode).ToString(), string.Empty);
                        //string categoryCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_ServiceCategoryCode).ToString(), string.Empty);
                        int status = Convert.ToInt32(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_Status).ToString());
                        string departmentCodeOrder = this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_DepartmentCodeOrder).ToString();
                        ServiceLaboratoryEntryINF LaboratoryEntry = new ServiceLaboratoryEntryINF();
                        {
                            LaboratoryEntry.RowID = rowIDLaboratory;
                            LaboratoryEntry.PatientCode = this.patientCode;
                            LaboratoryEntry.ReferenceCode = referenceCode;
                            LaboratoryEntry.Conclusion = this.txtConclusion.RtfText;
                            LaboratoryEntry.Proposal = string.Empty;
                            LaboratoryEntry.PostingDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                            LaboratoryEntry.PatientReceiveID = this.patientReceiveID;
                            LaboratoryEntry.ServiceCategoryCode = categoryCode;
                            if (checkCompleted.Checked)
                                LaboratoryEntry.Status = 1;
                            else
                                LaboratoryEntry.Status = 2;
                            LaboratoryEntry.EmployeeCode = this.s_userCode;
                            LaboratoryEntry.ObjectCode = this.objectCode;
                            LaboratoryEntry.STT = txtSTT.Text.Trim();
                            LaboratoryEntry.DepartmentCodeOrder = departmentCodeOrder;
                            LaboratoryEntry.LabPathologicalID = labPathologicalID;
                            LaboratoryEntry.OrderDate = this.dateOrder;
                            LaboratoryEntry.EmployeeCodeOrder = this.employeeCodeOrder;
                            LaboratoryEntry.EmployeeDoctorCodeOrder = this.employeeDoctorCodeOrder;
                            LaboratoryEntry.ShiftWork = this.shiftWork;
                            LaboratoryEntry.DepartmentCode = this.s_makp;
                            if (this.cbxMachine.SelectedValue != null)
                                LaboratoryEntry.IDMachine = Convert.ToInt32(this.cbxMachine.SelectedValue.ToString());
                            else
                                LaboratoryEntry.IDMachine = -1;
                            LaboratoryEntry.EmployeeCodeDoctor = this.searchLKup_EmployeeCode.EditValue == null ? this.s_userCode : this.searchLKup_EmployeeCode.EditValue.ToString();
                        };
                        if (ServiceLaboratoryEntryBLL.InsLaboratoryEntry(LaboratoryEntry, ref rowIDLaboratory) > 0)
                        {
                            ServiceLaboratoryEntryBLL.DelLaboratoryDetail(rowIDLaboratory);
                            Int32 orderNumber = 0;
                            foreach (DataRow dr in this.dtbResult.Rows)
                            {
                                orderNumber++;
                                ServiceLaboratoryDetailINF InsertDetail = new ServiceLaboratoryDetailINF();
                                {
                                    InsertDetail.RowIDLaboratoryEnTry = rowIDLaboratory;
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
                                    InsertDetail.STT = orderNumber;// Convert.ToInt32(dr["STT"].ToString());
                                    InsertDetail.ParameterMachine = dr["ParameterMachine"].ToString();
                                };
                                ServiceLaboratoryEntryBLL.InsLaboratoryDetail(InsertDetail, 1);
                            }
                            if (checkCompleted.Checked)
                            {
                                ServiceLaboratoryEntryBLL.UpdSuggestedServiceReceipt(rowIDLaboratory, 1);
                                ServiceLaboratoryEntryBLL.UpdLaboratoryEntry(rowIDLaboratory, 1);
                            }
                            else
                            {
                                ServiceLaboratoryEntryBLL.UpdSuggestedServiceReceipt(rowIDLaboratory, 2);
                                ServiceLaboratoryEntryBLL.UpdLaboratoryEntry(rowIDLaboratory, 2);
                            }

                            XtraMessageBox.Show(" Lưu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //if (File.Exists(this.pathTemp))
                            //    File.Delete(this.pathTemp);
                            this.EnableField(true);
                            this.butPrint.Enabled = true;
                            //if (checkCompleted.Checked)
                            //    this.PrintLaboratoryResult(rowIDLaboratory, referenceCode, categoryCode);
                            this.gridView_Laboratory.SetFocusedRowCellValue(this.col_lab_RowIDLaboratory, rowIDLaboratory);
                            this.gridView_Result.OptionsBehavior.ReadOnly = true;
                            this.gridView_Result.OptionsBehavior.Editable = false;
                            this.txtConclusion.ReadOnly = true;
                            //this.GetLaboratoryForPatient(0, string.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi khi lưu kết quả xét nghiệm!\t\nYêu cầu kiểm tra lại thông tin trước khi lưu: " + ex.Message, "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Vui lòng chọn loại xét nghiệm trả kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Chọn loại xét nghiệm cần trả kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.GetPatientWaiting(string.Empty);
        }

        private void GetPatientWaiting(string idmau)
        {
            try
            {
                this.gridControl_Laboratory.DataSource = null;
                this.gridControl_Result.DataSource = null;
                int paid = 0;
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(505);
                if (objSys != null && objSys.RowID > 0)
                    paid = objSys.Values;
                if (string.IsNullOrEmpty(idmau))
                    this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DataWaitingLaboratory(Convert.ToDateTime(dateStart.EditValue), Convert.ToDateTime(dateEnd.EditValue), this.checkCompleted.Checked ? 1 : 0, idmau, paid);
                else
                    this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DataWaitingLaboratory(Convert.ToDateTime(this.dateResult.EditValue), Convert.ToDateTime(this.dateResult.EditValue), this.checkCompleted.Checked ? 1 : 0, idmau, paid);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Get data waiting fail: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void EnableField(bool ena)
        {
            this.butSave.Enabled = this.butDelete.Enabled = this.butEdit.Enabled = !ena;
            this.butContinues.Enabled = ena;
            this.butPrint.Enabled = false;
            this.txtConclusion.ReadOnly = ena;
            this.searchLKup_EmployeeCode.Enabled = ena;
        }

        public void CleanerField()
        {
            this.txtSTT.EditValue = "0";
            this.dtbResult.Clear();
            this.gridControl_Result.DataSource = this.dtbResult;
            this.patientReceiveID = 0;
            this.patientCode = this.pathTemp = this.employeeCodeOrder = this.employeeDoctorCodeOrder = this.dateOrder = string.Empty;
            this.txtConclusion.RtfText = string.Empty;
            this.chkUndoResult.Checked = false;
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grWaitingList.Dock = DockStyle.Fill;
                this.EnableField(true);
                this.butSave.Enabled = this.butDelete.Enabled = this.butHenTraKQ.Enabled = false;
                this.GetLaboratoryForPatient("0", string.Empty);
                this.dateResult.EditValue = this.dtWorking;
                this.CleanerField();
            }
            catch (Exception) {
                //XtraMessageBox.Show(" Click continue fail: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmXNKetQuaNew_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: this.butReload_Click(sender, e); break;                    //F5 - Refresh
                case Keys.F1: this.butContinues_Click(sender, e); break;                 //F1 - Bệnh nhân tiếp
                case Keys.F3: this.butSave_Click(sender, e); break;                      //F3 - Lưu
                case Keys.F6: this.butPrint_Click(sender, e); break;                   //F6 - In toa
            }
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
        
        private void GetLaboratoryForPatient(string stt, string postingDate)
        {
            string departmentCodeOrder = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_DepartmentCodeOrder).ToString();
            this.gridControl_Laboratory.DataSource = LaboratoryBLL.DataLaboratoryForPatient(this.patientReceiveID, this.patientCode, this.checkWaiting.Checked ? 0 : 1, stt, this.dateStart.Text, this.dateEnd.Text, departmentCodeOrder);
        }

        private void GetLaboratoryDetail(string referenceCode, int status, string categoryCode, decimal rowIDLaboratory, string employeeCode, string departmentCodeOrde)
        {
            try
            {
                this.dtbResult = ServiceLaboratoryEntryBLL.DT_Get_LaboratoryPackageDetail(patientReceiveID, patientCode, referenceCode, status, categoryCode, rowIDLaboratory, departmentCodeOrde);
                #region Lay ket qua tu iLAB
                //if (status == 2)
                //{
                try
                {
                    if (this.bAutoResult && this.cateAutoResult.Contains(categoryCode))
                    {
                        this.GetMachine(categoryCode);

                        if (this.dtbMachine != null && this.dtbMachine.Rows.Count > 0)
                        {
                            this.machineCode = this.dtbMachine.Select("RowID=" + (this.cbxMachine.SelectedValue == null ? "-1" : this.cbxMachine.SelectedValue.ToString())).CopyToDataTable().Rows[0]["MechineCode"].ToString();
                        }
                        DataTable tableResultMachine = new DataTable();
                        if ((status.Equals(2) || status.Equals(0)) || (status.Equals(1) && this.chkUndoResult.Checked))
                            tableResultMachine = iLABGetResultBLL.TableResult_iLab(this.dateResult.Text.Trim(), this.txtSTT.Text.Trim(), this.machineCode);
                        if (tableResultMachine != null && tableResultMachine.Rows.Count > 0)
                        {
                            foreach (DataRow row in this.dtbResult.Rows)
                            {
                                DataRow row1 = Utils.GetPriceRowbyCode(tableResultMachine, "TestCode='" + row["ParameterMachine"].ToString() + "'");
                                if (row1 != null)
                                {
                                    row["ValuesEntry"] = row1["ValueMachine"];
                                    row["Normal"] = this.CheckNormalResult(row1["ValueMachine"].ToString(), row["MinValuedMale"].ToString(), row["MaxValuedMale"].ToString(), row["MinValuedFemale"].ToString(), row["MaxValuedFemale"].ToString());
                                }
                            }
                        }
                    }
                }
                catch(Exception ex) {
                    XtraMessageBox.Show("Load result auto machine: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //}
                #endregion

                this.gridControl_Result.DataSource = dtbResult;
                this.gridView_Result.BeginSort();
                //this.gridView_Result.ClearGrouping();
                //this.gridView_Result.Columns["ServiceName"].GroupIndex = 1;
                //this.gridView_Result.Columns[1].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                if (this.dtbResult == null || this.dtbResult.Rows.Count <= 0)
                {
                    //XtraMessageBox.Show("Bộ thông số kết quả xét nghiệm chưa khai báo, vui lòng khai báo!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.EnableField(true);
                }
                else
                {
                    if (this.checkCompleted.Checked)
                    {
                        string stt = gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_STT).ToString();
                        ///Get file form tech machine
                        //string cateMachine = cbxMachine.SelectedValue.ToString();
                        //if (status == 2)
                        //    this.GetFileResult(stt, cateMachine);
                    }
                    if (employeeCode != string.Empty && employeeCode != s_userCode)
                    {
                        this.EnableField(true);
                        this.butEdit.Enabled = true;
                        this.butPrint.Enabled = true;
                        this.gridView_Result.OptionsBehavior.ReadOnly = true;
                        this.gridView_Result.OptionsBehavior.Editable = false;
                        this.txtConclusion.ReadOnly = true;
                    }
                    else
                    {
                        ////this.EnableField(false);
                        if (status == 1)
                            this.butEdit.Enabled = true;
                        if (status == 2 || status == 1)
                        {
                            this.butEdit.Enabled = true;
                            this.butSave.Enabled = false;
                            this.butPrint.Enabled = true;
                            this.gridView_Result.OptionsBehavior.ReadOnly = true;
                            this.gridView_Result.OptionsBehavior.Editable = false;
                            this.txtConclusion.ReadOnly = true;
                        }
                        if (status == 0)
                        {
                            this.butEdit.Enabled = false;
                            this.butPrint.Enabled = false;
                            this.gridView_Result.OptionsBehavior.ReadOnly = false;
                            this.gridView_Result.OptionsBehavior.Editable = true;
                            this.txtConclusion.ReadOnly = false;
                        }
                        this.butDelete.Enabled = false;
                        this.butContinues.Enabled = true;
                        
                    }
                }
                if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
                    this.pageResult.Appearance.Header.BackColor = System.Drawing.Color.Red;
                else
                    this.pageResult.Appearance.Header.BackColor = System.Drawing.Color.Black;
            }
            catch {
            }
            finally
            {
                this.gridView_Result.EndSort();
            }
        }

        private void GetFileResult(string stt, string categoryMachine)
        {
            try
            {
                SystemParameterInf objParameter = new SystemParameterInf();
                objParameter = SystemParameterBLL.ObjParameter(400);
                string dateTemp = Convert.ToDateTime(dateResult.EditValue).ToString("yyMMdd");
                string pathFolder = objParameter.Description;
                string pathFile = pathFolder + "\\" + dateTemp + "\\" + stt + "_" + categoryMachine + ".txt";
                if (objParameter.Description.ToString().TrimEnd() != string.Empty)
                {
                    if (!Directory.Exists(pathFolder))
                    {
                        XtraMessageBox.Show("Đường dẫn kết quả xét nghiệm không tồn tại. Hãy kiểm tra lại đường dẫn: " + pathFolder, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (File.Exists(pathFile))
                    {
                        string temp = string.Empty;
                        string values = string.Empty;
                        foreach (DataRow row in this.dtbResult.Rows)
                        {
                            var streamReader = new StreamReader(pathFile);
                            while (!streamReader.EndOfStream)
                            {
                                var line = streamReader.ReadLine();
                                temp = this.GetResultFile(line, ref values);
                                if (row["ParameterMachine"].ToString().Trim() == temp.Trim())
                                {
                                    row["ValuesEntry"] = values;
                                    break;
                                }
                            }
                            streamReader.Dispose();
                            streamReader.Close();
                        }
                        this.dtbResult.AcceptChanges();
                        this.pathTemp = pathFile;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Kết quả xét nghiệm chưa có! Kiểm tra lại đường dẫn file kết quả: " + pathFile, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đường dẫn kết quả xét nghiệm chưa khai báo. Vui lòng liên hệ admin!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { return; }
        }

        private string GetResultFile(string temp,ref string values)
        {
            string parameter = string.Empty;
            string[] arrResult = temp.Split(':');
            try
            {
                if (arrResult.Length > 0)
                {
                    parameter = arrResult[1].ToString();
                    values = arrResult[2].ToString();
                }
            }
            catch { parameter = ""; }
            return parameter;
        }

        private void gridView_Laboratory_Click(object sender, EventArgs e)
        {
            try
            {
                string referenceCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, this.col_lab_ReferenceCode).ToString(), string.Empty);
                int status = Convert.ToInt32(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, this.col_lab_Status).ToString());
                string categoryCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, this.col_lab_ServiceCategoryCode).ToString(), string.Empty);
                decimal rowIDLaboratory = ISDBNULL2DECIMAL(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, this.col_lab_RowIDLaboratory).ToString(), string.Empty);
                string departmentCodeOrder = this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_DepartmentCodeOrder).ToString();
                Int32 labPathologicalID = Convert.ToInt32(this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_LabPathologicalID).ToString());                
                this.employeeDoctorCodeOrder = this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_EmployeeDoctorCodeOrder).ToString();
                string employeeDoctorCodeTemp = this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_EmployeeCodeDoctor).ToString();
                if (this.checkWaiting.Checked)
                {
                    ////this.txtSTT.Text = ServiceLaboratoryEntryBLL.GetSTT(categoryCode).ToString();
                    this.txtSTT.Text = ServiceLaboratoryEntryBLL.GetIDPatternForReceive(categoryCode, this.patientCode, this.patientReceiveID, labPathologicalID).ToString();
                    if (status == 2 || status == 1)
                        this.butSave.Enabled = false;
                    else
                        this.butSave.Enabled = true;
                }
                else
                {
                    this.txtSTT.Text = this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_STT).ToString();
                    if (status == 2)
                    {
                        this.gridView_Result.OptionsBehavior.ReadOnly = true;
                        this.gridView_Result.OptionsBehavior.Editable = false;
                        this.txtConclusion.ReadOnly = true;
                        //this.butDelete.Enabled = true;
                        //this.butSave.Enabled = true;
                        this.butDelete.Text = "Hủy Mẫu";
                    }
                    else if (status == 1)
                    {
                        this.gridView_Result.OptionsBehavior.ReadOnly = true;
                        this.gridView_Result.OptionsBehavior.Editable = false;
                        this.txtConclusion.ReadOnly = true;
                        //this.butSave.Enabled = false;
                        //this.butEdit.Enabled = true;
                        this.butDelete.Text = "Hủy KQ";
                    }
                    this.searchLKup_EmployeeCode.EditValue = employeeDoctorCodeTemp;
                }
                this.txtSTT.Enabled = true;
                string employeeCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_EmployeeCode).ToString(), string.Empty);
                if (!string.IsNullOrEmpty(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_PostingDate).ToString()))
                    this.dateResult.EditValue = Convert.ToDateTime(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_PostingDate).ToString());
                else
                    this.dateResult.EditValue = this.dtWorking;                
                this.GetLaboratoryDetail(referenceCode, status, categoryCode, rowIDLaboratory, employeeCode, departmentCodeOrder);
                this.ResultTemplateLabo(referenceCode, categoryCode);
                if (this.checkWaiting.Checked)
                {
                    LabPatternAttachInf objPattern = LabPatternAttachBLL.ObjLabPattern(categoryCode);
                    this.txtConclusion.RtfText = objPattern.LabPatternContent;
                }
                else
                {
                    ServiceLaboratoryEntryINF objLabEntry = ServiceLaboratoryEntryBLL.ObjLaboratoryEntry(rowIDLaboratory);
                    this.txtConclusion.RtfText = objLabEntry.Conclusion;
                }
            }
            catch { return; }
        }

        private void gridView_Result_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                //int normal = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Normal"]));
                //if (normal == 1)
                //{
                //    e.Appearance.ForeColor = Color.Red;
                //}
                if (e.RowHandle >= 0)
                {
                    int normal = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Normal"]));
                    if (normal == 1)
                    {
                        e.Appearance.ForeColor = Color.Red;
                        //View.ActiveEditor.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void ref_Description_Result_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBoxEdit cbEdit = sender as ComboBoxEdit;
                this.CheckNormal(cbEdit.Text.ToString());
            }
            catch { }
        }

        private void CheckNormal(string values)
        {
            decimal dValue = 0;
            string sNormalMale = string.Empty, sNormalFeMale = string.Empty;
            decimal dMinMale = 0, dMaxMale = 0;
            decimal dMinFeMale = 0, dMaxFeMale = 0;
            if (CheckNumber(values, ref dValue))
            {
                if (objectCode == 1)
                {
                    dMinMale = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MinValuedMale).ToString(), string.Empty);
                    dMaxMale = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MaxValuedMale).ToString(), string.Empty);
                    if (dMaxMale == 0 && dValue > dMinMale)
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                    else if (dMinMale == 0 && dValue < dMaxMale)
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 0);
                    else if (dValue < dMinMale || dValue > dMaxMale)
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                    else
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 0);
                }
                else
                {
                    dMinFeMale = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MinValuedFemale).ToString(), string.Empty);
                    dMaxFeMale = ISDBNULL2DECIMAL(gridView_Result.GetRowCellValue(gridView_Result.FocusedRowHandle, col_MaxValuedFemale).ToString(), string.Empty);
                    if (dMaxFeMale == 0 && dValue > dMinFeMale)
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                    else if (dMinFeMale == 0 && dValue < dMaxFeMale)
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 0);
                    else if (dValue < dMinFeMale || dValue > dMaxFeMale)
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 1);
                    else
                        gridView_Result.SetFocusedRowCellValue(col_Normal, 0);
                }
            }
        }

        private int CheckNormalResult(string values, string minValuedMale, string maxValuedMale, string minValuedFemale, string maxValuedFemale)
        {
            decimal dValue = 0;
            string sNormalMale = string.Empty, sNormalFeMale = string.Empty;
            decimal dMinMale = 0, dMaxMale = 0;
            decimal dMinFeMale = 0, dMaxFeMale = 0;
            int result = 0;
            if (CheckNumber(values, ref dValue))
            {
                if (objectCode == 1)
                {
                    dMinMale = ISDBNULL2DECIMAL(minValuedMale, string.Empty);
                    dMaxMale = ISDBNULL2DECIMAL(maxValuedMale, string.Empty);
                    if (dMaxMale == 0 && dValue > dMinMale)
                        result = 1;
                    else if (dMinMale == 0 && dValue < dMaxMale)
                        result = 0;
                    else if (dValue < dMinMale || dValue > dMaxMale)
                        result = 1;
                    else
                        result = 0;
                }
                else
                {
                    dMinFeMale = ISDBNULL2DECIMAL(minValuedFemale, string.Empty);
                    dMaxFeMale = ISDBNULL2DECIMAL(maxValuedFemale, string.Empty);
                    if (dMaxFeMale == 0 && dValue > dMinFeMale)
                        result = 1;
                    else if (dMinFeMale == 0 && dValue < dMaxFeMale)
                        result = 0;
                    else if (dValue < dMinFeMale || dValue > dMaxFeMale)
                        result = 1;
                    else
                        result = 0;
                }
            }
            return result;
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                decimal rowIDLaboratory = ISDBNULL2DECIMAL(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_RowIDLaboratory).ToString(), string.Empty);
                string referenceCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_ReferenceCode).ToString(), string.Empty);
                string categoryCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_ServiceCategoryCode).ToString(), string.Empty);
                string laboratoryTemp = string.Empty;
                bool boolCheck = false;
                for (Int32 item = 0; item < this.gridControl_Laboratory.DefaultView.DataRowCount; item++)
                {
                    Int32 printer = Convert.ToInt32(this.gridView_Laboratory.GetRowCellValue(item, this.col_lab_Printer).ToString());
                    decimal rowIDLaboratoryTemp = Convert.ToDecimal(this.gridView_Laboratory.GetRowCellValue(item, this.col_lab_RowIDLaboratory).ToString());
                    if (printer == 1)
                    {
                        laboratoryTemp += rowIDLaboratoryTemp + ",";
                        boolCheck = true;
                    }
                    if (!boolCheck)
                        laboratoryTemp = string.Empty;
                }
                if (rowIDLaboratory > 0)
                {
                    this.butPrint.Enabled = true;
                    this.PrintLaboratoryResult(boolCheck ? laboratoryTemp.TrimEnd(',') : rowIDLaboratory.ToString(), referenceCode, categoryCode);
                }
                else
                    this.butPrint.Enabled = false;
            }
            catch { return; }
        }

        private void PrintLaboratoryResult(string rowIDLaboratory, string referenceCode, string categoryCode)
        {
            try
            {
                string categoryName = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_ServiceCategoryName).ToString(), string.Empty);
                if (this.patientCode != string.Empty && rowIDLaboratory != "0")
                {
                    DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                    //DataTable dtResult = new DataTable("LabResult");
                    //dtResult = ServiceLaboratoryEntryBLL.TableResultLaboratory(rowIDLaboratory, referenceCode, categoryCode, this.patientReceiveID);
                    DataTable dtResultDetail = ServiceLaboratoryEntryBLL.TableResultLaboratoryDetailForPrinter(rowIDLaboratory, this.patientReceiveID);
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    ///dsTemp.Tables.Add(dtResult);
                    dsTemp.Tables.Add(dtResultDetail);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_XN_General.xml");
                    if (this.toolStrip_Options_btnPrintA4.Checked)
                    {
                        Reports.rptXN_General_A4 rptShow = new Reports.rptXN_General_A4(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "KQXetNghiem", "Kết quả xét nghiệm");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        Reports.rptXN_General_A5 rptShow = new Reports.rptXN_General_A5(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "KQXetNghiem", "Kết quả xét nghiệm");
                        rpt.ShowDialog();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Kết quả xét nghiệm chưa có! Vui lòng nhập kết quả xét nghiệm.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridControl_Result.DataSource = null;
                    this.txtConclusion.RtfText = string.Empty;
                    this.GetLaboratoryForPatient("0", string.Empty);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi in phiếu kết quả!\t\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string userCodeOld = this.ISDBNULL2STRING(this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_EmployeeCodeDoctor).ToString(), string.Empty);
                string userCodeNew = this.searchLKup_EmployeeCode.EditValue == null ? string.Empty : this.searchLKup_EmployeeCode.EditValue.ToString();
                if (!this.bEditEmployeeDoctor)
                {
                    //if (s_userCode != userCodeOld)
                    //{
                    //    XtraMessageBox.Show(" Khác bác sĩ đọc trả kết quả. Không được phép sửa kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    if (!userCodeOld.Equals(userCodeNew))
                    {
                        XtraMessageBox.Show(" Khác bác sĩ đọc trả kết quả (Mã BS: " + userCodeOld + ") Không được phép sửa kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.butSave.Enabled = this.butDelete.Enabled = true;
                this.butEdit.Enabled = this.butPrint.Enabled = false;
                this.gridView_Result.OptionsBehavior.ReadOnly = false;
                this.gridView_Result.OptionsBehavior.Editable = true;
                this.txtConclusion.ReadOnly = false;
            }
            catch
            {
                XtraMessageBox.Show("Chọn bác sỹ trả kết quả xét nghiệm.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void checkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkCompleted.Checked)
                {
                    this.GetPatientWaiting(string.Empty);
                    this.txtSTT.Enabled = true;
                    this.butSave.Text = "F3 - Lưu KQ";
                    this.butPrint.Text = "F6 - In KQ";
                    this.butDelete.Text = "Hủy KQ";
                    this.gridView_Laboratory.Columns["Printer"].Visible = true;
                    this.gridView_WaitingList.Columns["OrderDate"].Visible = false;
                    this.gridView_WaitingList.Columns["ResultDate"].Visible = true;
                }
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message); }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkWaiting.Checked)
                {
                    this.GetPatientWaiting(string.Empty);
                    this.txtSTT.Enabled = false;
                    this.butSave.Text = "F3 - Lưu mẫu";
                    this.butPrint.Text = "F6 - In mẫu";
                    this.butDelete.Text = "Hủy mẫu";
                    this.gridView_Laboratory.Columns["Printer"].Visible = false;
                    this.gridView_WaitingList.Columns["OrderDate"].Visible = true;
                    this.gridView_WaitingList.Columns["ResultDate"].Visible = false;
                }
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message); }
        }

        private void txtSTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void ResultTemplateLabo(string referenceCode, string serviceCategoryCode)
        {
            try
            {
                DataTable tableTemplate = new DataTable();
                tableTemplate = ServiceLaboratoryEntryBLL.TableLabServiceTemplate(this.patientReceiveID, this.patientCode, referenceCode, this.serviceGroupCode, serviceCategoryCode, this.checkCompleted.Checked ? 1 : 0);
                this.gridControl_LabResultTemplate.DataSource = tableTemplate;
                if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                    this.pageTemplate.Appearance.Header.BackColor = System.Drawing.Color.Red;
                else
                    this.pageTemplate.Appearance.Header.BackColor = System.Drawing.Color.Black;
            }
            catch (Exception ex){
                XtraMessageBox.Show(" Load result template fail: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_LabResultTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DevExpress.Utils.WaitDialogForm loading = new DevExpress.Utils.WaitDialogForm("Loading...", "Bệnh viện điện tử .NET");
                decimal rowIDRadiologyEntry = 0, suggestedIDTemp = 0;
                string serviceName = string.Empty, serviceCode = string.Empty, referenceCodeTemp = string.Empty, serviceCategoryCode = string.Empty;
                rowIDRadiologyEntry = Convert.ToDecimal(this.gridView_LabResultTemplate.GetRowCellValue(this.gridView_LabResultTemplate.FocusedRowHandle, this.colResult_RowIDRadiologyEntry).ToString());
                serviceName = this.gridView_LabResultTemplate.GetRowCellValue(this.gridView_LabResultTemplate.FocusedRowHandle, this.colResult_ServiceName).ToString();
                serviceCode = this.gridView_LabResultTemplate.GetRowCellValue(this.gridView_LabResultTemplate.FocusedRowHandle, this.colResult_ServiceCode).ToString();
                referenceCodeTemp = this.gridView_LabResultTemplate.GetRowCellValue(this.gridView_LabResultTemplate.FocusedRowHandle, this.colResult_ReferenceCode).ToString();
                suggestedIDTemp = Convert.ToDecimal(this.gridView_LabResultTemplate.GetRowCellValue(this.gridView_LabResultTemplate.FocusedRowHandle, this.colResult_ReceiptID).ToString());
                referenceCodeTemp = this.gridView_LabResultTemplate.GetRowCellValue(this.gridView_LabResultTemplate.FocusedRowHandle, this.colResult_ServiceCategoryCode).ToString();
                loading.Close();
                frmPopLabResult frmResult = new frmPopLabResult(this.s_userCode, rowIDRadiologyEntry, serviceName, serviceCode, this.patientReceiveID, this.patientCode, referenceCodeTemp, suggestedIDTemp, this.shiftWork);
                frmResult.ShowDialog();
                frmResult.ShowInTaskbar = false;
                this.ResultTemplateLabo(referenceCodeTemp, serviceCategoryCode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Doule click result template fail: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                decimal rowIDLaboratory = ISDBNULL2DECIMAL(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_RowIDLaboratory).ToString(), string.Empty);
                int status = Convert.ToInt32(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_Status).ToString());
                string userCodeOld = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_EmployeeCodeDoctor).ToString(), string.Empty);
                string userCodeNew = this.searchLKup_EmployeeCode.EditValue == null ? string.Empty : this.searchLKup_EmployeeCode.EditValue.ToString();
                if (!this.bEditEmployeeDoctor)
                {
                    //if (s_userCode != userCodeOld)
                    //{
                    //    XtraMessageBox.Show(" Khác bác sĩ đọc trả kết quả. Không được phép hủy kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}
                    if (!userCodeOld.Equals(userCodeNew))
                    {
                        XtraMessageBox.Show(" Khác bác sĩ đọc trả kết quả (Mã BS: " + userCodeOld + ") Không được phép sửa kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (userCodeOld == string.Empty)
                {
                    XtraMessageBox.Show(" Kết quả xét nghiệm chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn thật sự muốn hủy kết quả xét nghiệm?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    bool bResult = true;
                    if (bResult)
                    {
                        if (checkWaiting.Checked)
                        {
                            if (ServiceLaboratoryEntryBLL.DelLaboratoryDetail(rowIDLaboratory) > 0)
                            {
                                ServiceLaboratoryEntryBLL.DelLaboratory(rowIDLaboratory);
                                ServiceLaboratoryEntryBLL.UpdSuggestedServiceReceipt(rowIDLaboratory, 0);
                                XtraMessageBox.Show(" Hủy lấy mẫu xét nghiệm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                gridControl_Result.DefaultView.ClearDocument();
                                butContinues_Click(sender, e);
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy lấy mẫu xét nghiệm không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (checkCompleted.Checked)
                        {
                            if (ServiceLaboratoryEntryBLL.ClearResultLaboratoryDetail(rowIDLaboratory) > 0)
                            {
                                if (status == 1)
                                {
                                    ServiceLaboratoryEntryBLL.UpdSuggestedServiceReceipt(rowIDLaboratory, 2);
                                    ServiceLaboratoryEntryBLL.UpdLaboratoryEntry(rowIDLaboratory, 2);
                                }
                                else if (status == 2)
                                {
                                    ServiceLaboratoryEntryBLL.UpdSuggestedServiceReceipt(rowIDLaboratory, 0);
                                    ServiceLaboratoryEntryBLL.DelLaboratoryDetail(rowIDLaboratory);
                                    ServiceLaboratoryEntryBLL.DelLaboratory(rowIDLaboratory);
                                }
                                XtraMessageBox.Show(" Hủy kết quả xét nghiệm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.gridControl_Result.DefaultView.ClearDocument();
                                this.butContinues_Click(sender, e);
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy kết quả xét nghiệm không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Thuốc - VTTH đã thanh toán, hoặc đã được duyệt. Không được phép hủy kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                    return;
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_WaitingList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.gridControl_Laboratory.DataSource = null;
                        this.patientCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString();
                        this.patientReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientReceiveId).ToString());
                        this.objectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode).ToString());
                        this.dateOrder = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_OrderDate).ToString();
                        //this.employeeCodeOrder = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_EmployeeCodeOrder).ToString();
                        //this.employeeDoctorCodeOrder = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_EmployeeDoctorCodeOrder).ToString();

                        ////this.GetLaboratoryForPatient(0, dateResult.Text.Trim());
                        if (this.checkCompleted.Checked)
                            this.GetLaboratoryForPatient("0", this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ResultDate).ToString());
                        else
                            this.GetLaboratoryForPatient("0", this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_OrderDate).ToString());
                        this.gridControl_Result.DataSource = null;
                        this.gridControl_LabResultTemplate.DataSource = null;
                        this.txtConclusion.RtfText = string.Empty;
                        this.butHenTraKQ.Enabled = true;
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi chọn bệnh nhân:\t\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void repbutViewHSBA_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridView_WaitingList.GetFocusedRowCellValue(this.col_List_PatientCode).ToString()))
            {
                ViewPopup.frmKB_HSBA frm = new ViewPopup.frmKB_HSBA(this.gridView_WaitingList.GetFocusedRowCellValue(this.col_List_PatientCode).ToString());
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show(" Chọn bệnh nhân cần xem hồ sơ bệnh án.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void butHenTraKQ_Click(object sender, EventArgs e)
        {
            string patientName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString();
            string genderName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString();
            string patientBirthyear = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString();
            string objectName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
            string departmentName = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_DepartmentName).ToString();
            string result = "Mã BN: " + this.patientCode + " - Họ và Tên: " + patientName + " - Giới tính: " + genderName + " - Năm sinh: " + patientBirthyear + " - Đối tượng: " + objectName + " - Phòng: " + departmentName;
            string categoryCode = ISDBNULL2STRING(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, col_lab_ServiceCategoryCode).ToString(), string.Empty);
            frmXNHenTraKetQua frm = new frmXNHenTraKetQua(this.patientCode, this.patientReceiveID, result, categoryCode, this.s_userCode);
            frm.ShowDialog();
        }

        private void toolStrip_Options_btnPrintA5_Click(object sender, EventArgs e)
        {
            if (this.toolStrip_Options_btnPrintA5.Checked)
            {
                this.toolStrip_Options_btnPrintA5.Checked = false;
                this.toolStrip_Options_btnPrintA4.Checked = true;
            }
            else
            {
                this.toolStrip_Options_btnPrintA5.Checked = true;
                this.toolStrip_Options_btnPrintA4.Checked = false;
            }
        }

        private void toolStrip_Options_btnPrintA4_Click(object sender, EventArgs e)
        {
            if (this.toolStrip_Options_btnPrintA4.Checked)
            {
                this.toolStrip_Options_btnPrintA4.Checked = false;
                this.toolStrip_Options_btnPrintA5.Checked = true;
            }
            else
            {
                this.toolStrip_Options_btnPrintA4.Checked = true;
                this.toolStrip_Options_btnPrintA5.Checked = false;
            }
        }

        private void txtSTT_Validated(object sender, EventArgs e)
        {
            try
            {
                string categoryCode = ISDBNULL2STRING(this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, this.col_lab_ServiceCategoryCode).ToString(), string.Empty);
                if (this.checkWaiting.Checked)
                {
                    if (this.txtSTT.Text.Trim() != string.Empty && this.txtSTT.Text.Trim() != "0")
                    {
                        if (ServiceLaboratoryEntryBLL.ExistsSTTForLaboratory(categoryCode, Convert.ToInt32(this.txtSTT.Text)))
                        {
                            XtraMessageBox.Show(" ID Mẫu đã tồn tại! Vui lòng nhập ID mẫu khác.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtSTT.Focus();
                        }
                    }
                    else
                        XtraMessageBox.Show(" ID lấy mẫu không hợp lệ! Không được nhập các ký tự đặc biệt.\n Vui lòng nhập lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.GetPatientWaiting(this.txtSTT.EditValue.ToString());
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.gridView_WaitingList_Click(sender, e);
                        this.gridView_Laboratory_Click(sender, e);
                    }
                    else
                        return;
                }
            }
            catch { return; }
        }

        private void repLab_Printer_CheckedChanged(object sender, EventArgs e)
        {
            this.butPrint.Enabled = true;
        }

        private void gridControl_Result_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (this.gridControl_Result.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }            
        }
        
    }
}