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

namespace Ps.Clinic.Master
{
    public partial class frmDMVietTat : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userid = string.Empty;
        public frmDMVietTat(string _userid)
        {
            InitializeComponent();
            this.userid = _userid;
        }

        private void frmDMVietTat_Load(object sender, EventArgs e)
        {
            this.LoadAbbre();   
        }

        private void LoadAbbre()
        {
            this.gridControl_DiagnosisAbbre.DataSource = DiagnosisAbbreviationsBLL.TableAbbreviations(this.userid);
        }

        private void gridView_DiagnosisAbbre_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo danh mục viết tắt!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_DiagnosisAbbre_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_CharacterCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_CharacterCode, " Chưa khai báo mã viết tắt! ");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_CharacterName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_CharacterName, " Chưa nhập tên viết tắt! ");
                }
                if (e.Valid == true)
                {
                    DiagnosisAbbreviationsInf inf = new DiagnosisAbbreviationsInf();
                    inf.CharacterCode = gridView_DiagnosisAbbre.GetRowCellValue(e.RowHandle, "CharacterCode").ToString();
                    inf.CharacterName = gridView_DiagnosisAbbre.GetRowCellValue(e.RowHandle, "CharacterName").ToString();
                    if (gridView_DiagnosisAbbre.GetRowCellValue(e.RowHandle, "RowID").ToString() != string.Empty)
                        inf.RowID = Convert.ToInt32(gridView_DiagnosisAbbre.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.EmployeeCode = this.userid;
                    if (e.RowHandle < 0)
                    {
                        if (DiagnosisAbbreviationsBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show(" Thêm thành công ký tự viết tắt! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(" Không thêm được viết tắt, có thể ký tự đã tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (DiagnosisAbbreviationsBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show(" Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(" Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.LoadAbbre();
                }
            }
            catch (Exception) { }
        }

        private void gridControl_DiagnosisAbbre_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_DiagnosisAbbre.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show(" Bạn có muốn xóa mã viết tắt này hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            if (DiagnosisAbbreviationsBLL.Del(Convert.ToInt32(gridView_DiagnosisAbbre.GetRowCellValue(gridView_DiagnosisAbbre.FocusedRowHandle, "RowID").ToString())) == 1)
                                this.LoadAbbre();
                        }
                        catch { return; }
                    }
                }
                
            }
            catch { }
        }
    }
}