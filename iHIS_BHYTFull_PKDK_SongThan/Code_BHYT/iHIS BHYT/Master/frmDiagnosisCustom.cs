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
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Master
{
    public partial class frmDiagnosisCustom : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userid = string.Empty;
        public frmDiagnosisCustom(string _userid)
        {
            InitializeComponent();
            this.userid = _userid;
        }

        private void frmDiagnosisCustom_Load(object sender, EventArgs e)
        {
            this.gridControl_List.DataSource = DiagnosisCustomBLL.TableDiagnosisCustom(0);
        }
        
        private void gridView_List_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = " Bạn nhập thiếu thông tin khai báo chẩn đoán bệnh!\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_List_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_DiagnosisName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_DiagnosisName, " Nhập tên chẩn đoán bệnh! ");
                }
                if (e.Valid)
                {
                    Int32 rowid=0;
                    if (this.gridView_List.GetRowCellValue(e.RowHandle, "RowID").ToString() != string.Empty)
                        rowid = Convert.ToInt32(this.gridView_List.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        rowid = 0;
                    string diagnosisName = this.gridView_List.GetRowCellValue(e.RowHandle, "DiagnosisName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (DiagnosisCustomBLL.Ins(rowid, diagnosisName, this.userid) == 1)
                        {
                            XtraMessageBox.Show(" Thêm mới chẩn đoán bệnh thành công! ", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show(" Thêm mới không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.gridView_List.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (DiagnosisCustomBLL.Ins(rowid, diagnosisName, this.userid) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật chẩn đoán bệnh thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                this.gridControl_List.DataSource = DiagnosisCustomBLL.TableDiagnosisCustom(0);
            }
            catch (Exception) { }
        }

        private void gridControl_List_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.gridView_List.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa chẩn đoán bệnh này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (DiagnosisCustomBLL.Del(Convert.ToInt32(this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, "RowID").ToString())) == 1)
                            this.gridView_List.DeleteSelectedRows();
                    }
                    catch { return; }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtResult = CareerBLL.DTCareer("");
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtResult);
                dsTemp.WriteXmlSchema(@"..\..\xml\rptDMChanDoan.xml");
                Reports.rptDMChanDoan rpt = new Reports.rptDMChanDoan();
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch { }
        }

    }
}