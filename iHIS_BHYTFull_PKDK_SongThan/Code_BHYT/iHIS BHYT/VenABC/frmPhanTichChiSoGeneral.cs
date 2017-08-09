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
using System.Data.OleDb;
using System.Diagnostics;

namespace Ps.Clinic.VenABC
{
    public partial class frmPhanTichChiSoGeneral : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tbDanhSach = new DataTable();
        private OpenFileDialog ofdImportFile_ChiSo = new OpenFileDialog();
        private OpenFileDialog ofdViewFile_ChiSo = new OpenFileDialog();

        private OpenFileDialog ofdImportFile_ToanVien = new OpenFileDialog();
        private OpenFileDialog ofdViewFile_ToanVien = new OpenFileDialog();

        private OpenFileDialog ofdImportFile_TrongVien = new OpenFileDialog();
        private OpenFileDialog ofdViewFile_TrongVien = new OpenFileDialog();

        private OpenFileDialog ofdImportFile_Ngay = new OpenFileDialog();
        private OpenFileDialog ofdViewFile_Ngay = new OpenFileDialog();

        private string userID = string.Empty;
        public frmPhanTichChiSoGeneral(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmPhanTichChiSoGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dtServer = Utils.DateServer();
                this.dteFrom_ChiSo.EditValue = this.dteTo_ChiSo.EditValue = dtServer;
                this.dteFrom_ToanVien.EditValue = this.dteTo_ToanVien.EditValue = dtServer;
                this.dteFrom_TrongVien.EditValue = this.dteTo_TrongVien.EditValue = dtServer;
                this.dte_Ngay.EditValue = dtServer;

                this.ofdImportFile_ChiSo.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdImportFile_ChiSo_FileOk);
                this.ofdViewFile_ChiSo.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdViewFile_ChiSo_FileOk);

                this.ofdImportFile_ToanVien.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdImportFile_ToanVien_FileOk);
                this.ofdViewFile_ToanVien.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdViewFile_ToanVien_FileOk);

                this.ofdImportFile_TrongVien.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdImportFile_TrongVien_FileOk);
                this.ofdViewFile_TrongVien.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdViewFile_TrongVien_FileOk);

                this.ofdImportFile_Ngay.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdImportFile_Ngay_FileOk);
                this.ofdViewFile_Ngay.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdViewFile_Ngay_FileOk);

                LoadFormatGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void LoadFormatGrid()
        {
            DataTable dtChiSoKeDon = new DataTable();
            dtChiSoKeDon.Columns.Add("TongToa", typeof(Int32));
            dtChiSoKeDon.Columns.Add("TongThuocTrongToa", typeof(Int32));
            dtChiSoKeDon.Columns.Add("SLThuocTrongToa_G", typeof(Int32));
            dtChiSoKeDon.Columns.Add("SLThuocTrongToa_B", typeof(Double));
            dtChiSoKeDon.Columns.Add("TongToa_KS", typeof(Int32));
            dtChiSoKeDon.Columns.Add("TongToa_Tiem", typeof(Int32));
            dtChiSoKeDon.Columns.Add("TongToa_Vit", typeof(Int32));
            dtChiSoKeDon.Columns.Add("SLThuocTrongToa_TT45", typeof(Int32));
            dtChiSoKeDon.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);

            DataTable dtThuocToanDien = new DataTable();
            dtThuocToanDien.Columns.Add("TongLuot", typeof(Int32));
            dtThuocToanDien.Columns.Add("TongLuotKhongThuoc", typeof(Int32));
            dtThuocToanDien.Columns.Add("TongToa", typeof(Int32));
            dtThuocToanDien.Columns.Add("TongGiaTriThuoc", typeof(Double));
            dtThuocToanDien.Columns.Add("TongGiaTri_KS", typeof(Double));
            dtThuocToanDien.Columns.Add("TongGiaTri_Tiem", typeof(Double));
            dtThuocToanDien.Columns.Add("TongGiaTri_Vit", typeof(Double));
            dtThuocToanDien.Rows.Add(0, 0, 0, 0, 0, 0, 0);

            DataTable dtThuocBenhVienTheoNgay = new DataTable();
            dtThuocBenhVienTheoNgay.Columns.Add("TongSoLuot", typeof(Int32));
            dtThuocBenhVienTheoNgay.Columns.Add("TongSoNgayNamVien", typeof(Int32));
            dtThuocBenhVienTheoNgay.Columns.Add("TongSoThuoc", typeof(Int32));
            dtThuocBenhVienTheoNgay.Columns.Add("TongSoThuoc_KS", typeof(Int32));
            dtThuocBenhVienTheoNgay.Columns.Add("TongSoThuoc_Tiem", typeof(Int32));
            dtThuocBenhVienTheoNgay.Columns.Add("TongGiaTriThuoc", typeof(Double));
            dtThuocBenhVienTheoNgay.Rows.Add(0, 0, 0, 0, 0, 0);

            DataTable dtThuocBenhVien = new DataTable();
            dtThuocBenhVien.Columns.Add("TongSoLuot", typeof(Int32));
            dtThuocBenhVien.Columns.Add("TongSoNgayNamVien", typeof(Int32));
            dtThuocBenhVien.Columns.Add("TongSoThuoc", typeof(Int32));
            dtThuocBenhVien.Columns.Add("TongSoThuoc_KS", typeof(Int32));
            dtThuocBenhVien.Columns.Add("TongSoThuoc_Tiem", typeof(Int32));
            dtThuocBenhVien.Columns.Add("TongGiaTriThuoc", typeof(Double));
            dtThuocBenhVien.Rows.Add(0, 0, 0, 0, 0, 0);

            gridControl_ChiSoKeDon.DataSource = dtChiSoKeDon;
            gridControl_ToanVien.DataSource = dtThuocToanDien;
            gridControl_TrongVien.DataSource = dtThuocBenhVien;
            gridControl_Ngay.DataSource = dtThuocBenhVienTheoNgay;
        }

        #region Phân tich chỉ số kê đơn
        private void ofdImportFile_ChiSo_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.ofdImportFile_ChiSo.FileName;
            this.gridControl_ChiSoKeDon.DataSource = Utils.ReadFileExcel(filePath);
        }

        private void ofdViewFile_ChiSo_FileOk(object sender, CancelEventArgs e)
        {
            Process.Start(this.ofdViewFile_ChiSo.FileName);
        }

        private void btnFileExcelTemplate_ChiSo_Click(object sender, EventArgs e)
        {
            this.ofdViewFile_ChiSo.ShowHelp = true;
            this.ofdViewFile_ChiSo.FileName = "PhanTichChiSoKeDon.xls";
            this.ofdViewFile_ChiSo.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdViewFile_ChiSo.ShowDialog();
        }

        private void btnImpFileExcel_ChiSo_Click(object sender, EventArgs e)
        {
            this.ofdImportFile_ChiSo.ShowHelp = true;
            this.ofdImportFile_ChiSo.FileName = string.Empty;
            this.ofdImportFile_ChiSo.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdImportFile_ChiSo.ShowDialog();
        }

        private void btnPhanTich_ChiSo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbDanhSach = new DataTable();
                tbDanhSach = (DataTable)this.gridControl_ChiSoKeDon.DataSource;
                if (tbDanhSach != null)
                {
                    frmPhanTichChiSoKeDon frmChiSo = new frmPhanTichChiSoKeDon(tbDanhSach, Convert.ToDateTime(this.dteFrom_ChiSo.EditValue), Convert.ToDateTime(this.dteTo_ChiSo.EditValue));
                    frmChiSo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Dữ liệu chưa phát sinh phân tích.", "Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region Su dung thuoc toan dien
        private void ofdImportFile_ToanVien_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.ofdImportFile_ToanVien.FileName;
            this.gridControl_ToanVien.DataSource = Utils.ReadFileExcel(filePath);
        }

        private void ofdViewFile_ToanVien_FileOk(object sender, CancelEventArgs e)
        {
            Process.Start(this.ofdViewFile_ToanVien.FileName);
        }
        
        private void btnFileExcelTemplate_ToanVien_Click(object sender, EventArgs e)
        {
            this.ofdViewFile_ToanVien.ShowHelp = true;
            this.ofdViewFile_ToanVien.FileName = "PhanTichChiSoSuDungThuocToanDien.xls";
            this.ofdViewFile_ToanVien.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdViewFile_ToanVien.ShowDialog();
        }

        private void btnImpFileExcel_ToanVien_Click(object sender, EventArgs e)
        {
            this.ofdImportFile_ToanVien.ShowHelp = true;
            this.ofdImportFile_ToanVien.FileName = string.Empty;
            this.ofdImportFile_ToanVien.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdImportFile_ToanVien.ShowDialog();
        }

        private void btnPhanTich_ToanVien_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbDanhSach = new DataTable();
                tbDanhSach = (DataTable)this.gridControl_ToanVien.DataSource;
                if (tbDanhSach != null)
                {
                    frmPhanTichChiSoToanDien frmChiSo = new frmPhanTichChiSoToanDien(tbDanhSach, Convert.ToDateTime(this.dteFrom_ToanVien.EditValue), Convert.ToDateTime(this.dteTo_ToanVien.EditValue));
                    frmChiSo.Show();
                }
                else
                {
                    MessageBox.Show("Dữ liệu chưa phát sinh phân tích.", "Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Sử dụng thuốc trong bệnh viện
        private void ofdImportFile_TrongVien_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.ofdImportFile_TrongVien.FileName;
            this.gridControl_TrongVien.DataSource = Utils.ReadFileExcel(filePath);
        }

        private void ofdViewFile_TrongVien_FileOk(object sender, CancelEventArgs e)
        {
            Process.Start(this.ofdViewFile_TrongVien.FileName);
        }
        
        private void btnFileExcelTemplate_TrongVien_Click(object sender, EventArgs e)
        {
            this.ofdViewFile_TrongVien.ShowHelp = true;
            this.ofdViewFile_TrongVien.FileName = "PhanTichChiSoLuaChonSuDungTrongBenhVien.xls";
            this.ofdViewFile_TrongVien.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdViewFile_TrongVien.ShowDialog();
        }

        private void btnImpFileExcel_TrongVien_Click(object sender, EventArgs e)
        {
            this.ofdImportFile_TrongVien.ShowHelp = true;
            this.ofdImportFile_TrongVien.FileName = string.Empty;
            this.ofdImportFile_TrongVien.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdImportFile_TrongVien.ShowDialog();
        }
        
        private void btnPhanTich_TrongVien_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbDanhSach = new DataTable();
                tbDanhSach = (DataTable)this.gridControl_TrongVien.DataSource;
                if (tbDanhSach != null)
                {
                    frmPhanTichChiSoSuDungTrongBenhVien frmChiSo = new frmPhanTichChiSoSuDungTrongBenhVien(tbDanhSach, Convert.ToDateTime(this.dteFrom_TrongVien.EditValue), Convert.ToDateTime(this.dteTo_TrongVien.EditValue));
                    frmChiSo.Show();
                }
                else
                {
                    MessageBox.Show("Dữ liệu chưa phát sinh phân tích.", "Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Su dung thuoc trong benh vien theo ngay
        private void ofdImportFile_Ngay_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.ofdImportFile_Ngay.FileName;
            this.gridControl_Ngay.DataSource = Utils.ReadFileExcel(filePath);
        }

        private void ofdViewFile_Ngay_FileOk(object sender, CancelEventArgs e)
        {
            Process.Start(this.ofdViewFile_Ngay.FileName);
        }
        
        private void btnFileExcelTemplate_Ngay_Click(object sender, EventArgs e)
        {
            this.ofdViewFile_Ngay.ShowHelp = true;
            this.ofdViewFile_Ngay.FileName = "PhanTichChiSoLuaChonSuDungTrongBenhVienTrongNgay.xls";
            this.ofdViewFile_Ngay.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdViewFile_Ngay.ShowDialog();
        }

        private void btnImpFileExcel_Ngay_Click(object sender, EventArgs e)
        {
            this.ofdImportFile_Ngay.ShowHelp = true;
            this.ofdImportFile_Ngay.FileName = string.Empty;
            this.ofdImportFile_Ngay.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            this.ofdImportFile_Ngay.ShowDialog();
        }

        private void btnPhanTich_Ngay_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbDanhSach = new DataTable();
                tbDanhSach = (DataTable)this.gridControl_Ngay.DataSource;
                if (tbDanhSach != null)
                {
                    frmPhanTichChiSoSuDungTrongBenhVienTungNgay frmChiSo = new frmPhanTichChiSoSuDungTrongBenhVienTungNgay(tbDanhSach, Convert.ToDateTime(this.dte_Ngay.EditValue));
                    frmChiSo.Show();
                }
                else
                {
                    MessageBox.Show("Dữ liệu chưa phát sinh phân tích.", "Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        
        private void rdRepository_ChiSo_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rdRepository_ChiSo.Checked)
            {
                this.btnFileExcelTemplate_ChiSo.Enabled = this.btnImpFileExcel_ChiSo.Enabled = false;
            }
        }

        private void rdImpFileExcel_ChiSo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdImpFileExcel_ChiSo.Checked)
            {
                this.btnFileExcelTemplate_ChiSo.Enabled = this.btnImpFileExcel_ChiSo.Enabled = true;
            }
        }

        private void rdImpFileExcel_ToanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdImpFileExcel_ToanVien.Checked)
            {
                this.btnFileExcelTemplate_ToanVien.Enabled = this.btnImpFileExcel_ToanVien.Enabled = true;
            }
        }

        private void rdRepository_ToanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdRepository_ToanVien.Checked)
            {
                this.btnFileExcelTemplate_ToanVien.Enabled = this.btnImpFileExcel_ToanVien.Enabled = false;
            }
        }

        private void rdImpFileExcel_TrongVien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdImpFileExcel_TrongVien.Checked)
            {
                this.btnFileExcelTemplate_TrongVien.Enabled = this.btnImpFileExcel_TrongVien.Enabled = true;
            }
        }

        private void rdRepository_TrongVien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdRepository_TrongVien.Checked)
            {
                this.btnFileExcelTemplate_TrongVien.Enabled = this.btnImpFileExcel_TrongVien.Enabled = false;
            }
        }

        private void rdImpFileExcel_Ngay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdImpFileExcel_Ngay.Checked)
            {
                this.btnFileExcelTemplate_Ngay.Enabled = this.btnImpFileExcel_Ngay.Enabled = true;
            }
        }

        private void rdRepository_Ngay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdRepository_Ngay.Checked)
            {
                this.btnFileExcelTemplate_Ngay.Enabled = this.btnImpFileExcel_Ngay.Enabled = false;
            }
        }
    }
}