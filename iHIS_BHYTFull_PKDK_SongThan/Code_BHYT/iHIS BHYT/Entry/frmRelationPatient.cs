using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.Entry
{
    public partial class frmRelationPatient : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private decimal patientReceiveID = 0;
        private string userID = string.Empty;
        private string patientCode = string.Empty;
        public frmRelationPatient(decimal _patientReceiveID, string _userID, string _patientCode)
        {
            InitializeComponent();
            this.patientReceiveID = _patientReceiveID;
            this.userID = _userID;
            this.patientCode = _patientCode;
        }
        
        private void gridControl_Detail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.gridView_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa nội dung này hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        PatientsRelationBLL relation = new PatientsRelationBLL();
                        decimal rowID = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Detail_RowID).ToString());
                        if (relation.DelPatientsRelation(rowID))
                        {
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Xóa không thành công! Vui lòng thực hiện lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch { return; }
                }
            }
        }

        private void frmRelationPatient_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch { return; }
        }

        private void LoadData()
        {
            PatientsRelationMenuBLL relationMenu = new PatientsRelationMenuBLL();
            this.rep_RelationMenu.DataSource = relationMenu.TableRelationMenu();
            this.rep_RelationMenu.ValueMember = "RowID";
            this.rep_RelationMenu.DisplayMember = "RelationTitle";

            PatientsRelationBLL relation = new PatientsRelationBLL();
            this.gridControl_Detail.DataSource = relation.TableRelation(this.patientCode);

            this.lkupMedicalPattern.Properties.DataSource = MedicalHistoryBLL.TableMedicalHistory(0);
            this.lkupMedicalPattern.Properties.DisplayMember = "MedicalHistoryName";
            this.lkupMedicalPattern.Properties.ValueMember = "RowID";
            PatientsInf patient = new PatientsInf();
            patient = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
            this.txtContentPattern.RtfText = patient.MedicalHistoryChildren;
        }

        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = " Vui lòng nhập đủ thông tin trước khi lưu !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_RowIDMenu)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Detail_RowIDMenu, " Chọn thông tin gia đình( cha, mẹ, ...)!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_RelationContent)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Detail_RelationContent, " Nhập thông tin gia đình!");
                }
                if (e.Valid == true)
                {
                    PatientsRelationInf inf = new PatientsRelationInf();
                    inf.PatientCode = this.patientCode;
                    inf.RowIDMenu = Convert.ToInt32(this.gridView_Detail.GetRowCellValue(e.RowHandle, "RowIDMenu").ToString());
                    inf.RelationContent = this.gridView_Detail.GetRowCellValue(e.RowHandle, "RelationContent").ToString();
                    if (this.gridView_Detail.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = Convert.ToDecimal(this.gridView_Detail.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.EmployeeCode = this.userID;
                    inf.PatientReceiveID = this.patientReceiveID;
                    inf.PatientCode = this.patientCode;
                    inf.Age = this.gridView_Detail.GetRowCellValue(e.RowHandle, "Age").ToString();
                    inf.CareerName = this.gridView_Detail.GetRowCellValue(e.RowHandle, "CareerName").ToString();
                    inf.MedicalHistory = this.gridView_Detail.GetRowCellValue(e.RowHandle, "MedicalHistory").ToString();
                    PatientsRelationBLL relation = new PatientsRelationBLL();
                    if (e.RowHandle < 0)
                    {
                        if (relation.InsPatientsRelation(inf) <= 0)
                        {
                            XtraMessageBox.Show("Thêm thông tin gia đình không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (relation.InsPatientsRelation(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thông tin gia đình thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thông tin gia đình không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.LoadData();
                }
            }
            catch { }
        }

        private void lkupMedicalPattern_EditValueChanged(object sender, EventArgs e)
        {
            decimal rowidMedical = Convert.ToDecimal(this.lkupMedicalPattern.EditValue.ToString());
            DataTable tableMedical = MedicalHistoryBLL.TableMedicalHistory(rowidMedical);
            if (tableMedical.Rows.Count > 0)
                this.txtContentPattern.RtfText = tableMedical.Rows[0]["MedicalHistoryContent"].ToString();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 result = PatientsBLL.UpdPatientsForMedicalHistoryChildren(this.patientCode, this.txtContentPattern.RtfText.Trim());
                if (result == 1)
                {
                    XtraMessageBox.Show("Cập nhật thông tin tiền sử trẻ sơ sinh thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật thông tin tiền sử trẻ sơ sinh không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtContentPattern.Focus();
                    return;
                }
            }
            catch { }
        }
    }
}