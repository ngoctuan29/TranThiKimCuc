using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.Master
{
    public partial class frmChiPhiBHYTTra : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCode = string.Empty;
        public frmChiPhiBHYTTra(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmChiPhiBHYTTra_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_BHYTPay.DataSource = BHYTParametersBLL.DT_ListParameters(1);
            }
            catch{  }
        }

        private void gridView_BHYTPay_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin giới hạn chi phí BHYT trả!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_BHYTPay_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RowID)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RowID, "Id Chưa phát sinh!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_BHYTUnderPrice)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RowID, "Mức bắt đầu chi trả không được đê trống!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_BHYTOnPrice)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RowID, "Mức chi trả cao nhất không được để trống!");
                }
                if (e.Valid == true)
                {
                    BHYTParametersInf inf = new BHYTParametersInf();
                    inf.RowID = int.Parse(gridView_BHYTPay.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    if (!string.IsNullOrEmpty(gridView_BHYTPay.GetRowCellValue(e.RowHandle, "BHYTUnderPrice").ToString()))
                        inf.BHYTUnderPrice = decimal.Parse(gridView_BHYTPay.GetRowCellValue(e.RowHandle, "BHYTUnderPrice").ToString());
                    else
                        inf.BHYTUnderPrice = 0;
                    if (!string.IsNullOrEmpty(gridView_BHYTPay.GetRowCellValue(e.RowHandle, "BHYTOnPrice").ToString()))
                        inf.BHYTOnPrice = decimal.Parse(gridView_BHYTPay.GetRowCellValue(e.RowHandle, "BHYTOnPrice").ToString());
                    else
                        inf.BHYTOnPrice = 0;
                    if (e.RowHandle < 0)
                    {
                        if (BHYTParametersBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (BHYTParametersBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                this.gridControl_BHYTPay.DataSource = BHYTParametersBLL.DT_ListParameters(1);
            }
            catch (Exception) { }
        }
    }
}