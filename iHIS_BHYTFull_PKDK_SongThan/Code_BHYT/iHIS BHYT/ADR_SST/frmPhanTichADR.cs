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
using Ps.Clinic.VenABC.PhanTichABCTheoThuocNoiNgoai;
using Ps.Clinic.VenABC.PhanTichVen;
using Ps.Clinic.VenABC.PhanTichABCBy2Time;
using DevExpress.XtraCharts;
using DevExpress.XtraRichEdit;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraPrinting.Preview;

namespace Ps.Clinic.ADR_SST
{
    public partial class frmPhanTichADR : DevExpress.XtraEditors.XtraForm
    {
        private int IdPhieu = 0;
        private int idBenhNhan = 0;
        private string StateBtn = string.Empty;
        private DataTable dtBenhNhan = new DataTable();
        private string userID = string.Empty;
        private OpenFileDialog ofdgGetFile = new OpenFileDialog();
        private DataTable dtReport01 = new DataTable();
        private DataTable dtReport02 = new DataTable();
        private DataTable dtGioiTinh02 = new DataTable();
        private DateTime dtServer = new DateTime();
        private string path = string.Empty;
        private DataTable dtDuongDung = new DataTable();
        private DataTable dtATC = new DataTable();
        private DataTable dtNghiNgo = new DataTable();

        public frmPhanTichADR(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }
        private void frmPhanTichADR_Load(object sender, EventArgs e)
        {
            try
            {
                this.path = Utils.CurrentPathApplication();
                this.ofdgGetFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdgGetFile_FileOk);
                //this.txtNoiBaoCao.Properties.DataSource = ADRBLL.GetListDonVi(0);
                //this.txtNoiBaoCao.Properties.DisplayMember = "TenDonVi";
                //this.txtNoiBaoCao.Properties.ValueMember = "Id";
                this.btnAddNew.Enabled = true;
                this.btnEdit.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.btnDelete.Enabled = false;
                this.ReadOnlyText(true);
                this.LoadData();
                LoadPanel();
                this.dtServer = Utils.DateServer();
                this.dteToDate_01.EditValue = this.dteFromDate_01.EditValue = this.dtServer;
                this.dteToDate02.EditValue = this.dteFromDate02.EditValue = this.dtServer;
                this.dteToDate03.EditValue = this.dteFromDate03.EditValue = this.dtServer;

                this.repositoryItemLookUpEdit_ATC.DataSource = ADRBLL.Get_Catalog_ATC();
                this.repositoryItemLookUpEdit_ATC.ValueMember = "RowID";
                this.repositoryItemLookUpEdit_ATC.DisplayMember = "ATCCode";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadPanel()
        {
            pnlTK.Left = (this.tabPage05.Width - pnlTK.Width) / 2;
            pnlTK.Top = (this.tabPage05.Height - pnlTK.Height) / 2;
        }

        public void ReadOnlyText(bool en)
        {
            this.txtMaPhieu.ReadOnly = en;
            this.dteNgay.ReadOnly = en;
            this.txtNoiBaoCao.ReadOnly = en;
            this.txtHoTen.ReadOnly = en;
            this.txtNgheNghiep.ReadOnly = en;
            this.txtPhone.ReadOnly = en;
            this.cbxDangBC.ReadOnly = en;
        }
        private void LoadData()
        {
            this.gridControl_ADR.DataSource = ADRBLL.GetDanhSachPhieu(0);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.btnAddNew.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnDelete.Enabled = false;
            this.ReadOnlyText(false);
            this.ResetTextEdit();
            this.StateBtn = "Add";
            this.IdPhieu = 0;
            this.txtMaPhieu.Focus();
        }

        public void ResetTextEdit()
        {
            this.txtMaPhieu.Text = string.Empty;
            this.dteNgay.EditValue = Utils.DateServer();
            this.txtNoiBaoCao.Text = string.Empty;
            this.txtHoTen.Text = string.Empty;
            this.txtNgheNghiep.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.cbxDangBC.Text = string.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnAddNew.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnDelete.Enabled = false;
            this.ReadOnlyText(false);
            this.StateBtn = "Edit";
            this.txtMaPhieu.ReadOnly = true;
            this.dteNgay.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtMaPhieu.Text))
                {
                    XtraMessageBox.Show("Nhập mã số báo cáo!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int result = 0;
                ADR_PhieuBaoCaoInf model = new ADR_PhieuBaoCaoInf();
                model.NoiBaoCao = txtNoiBaoCao.Text;
                model.MasoBaoCao = this.txtMaPhieu.Text;
                model.NgayBaoCao = Convert.ToDateTime(this.dteNgay.EditValue);
                model.NguoiBaoCao = this.txtHoTen.Text;
                model.NgheNghiep = this.txtNgheNghiep.Text;
                model.SoDienThoai = this.txtPhone.Text;
                model.DangBaoCao = this.cbxDangBC.Text;
                if (this.StateBtn.Equals("Add"))
                {
                    if (ADRBLL.CheckExistId(model.MasoBaoCao) == 1)
                    {
                        XtraMessageBox.Show("Mã đã tồn tại!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    model.Id = 0;
                    if (ADRBLL.InsUpd_ADR(model) == 1)
                        XtraMessageBox.Show("Thêm dữ liệu thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        result = -1;
                }
                else if (this.StateBtn.Equals("Edit") && this.IdPhieu != 0)
                {
                    model.Id = this.IdPhieu;
                    if (ADRBLL.InsUpd_ADR(model) == 1)
                        XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        result = -1;
                }
                if (result == -1)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu không thành công!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin.\n\r Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ReFresh();
            }
            this.btnAddNew.Enabled = true;
            if (this.IdPhieu == 0)
                this.btnEdit.Enabled = false;
            else
                this.btnEdit.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnDelete.Enabled = true;
            this.ReadOnlyText(true);
            this.LoadData();
        }

        private void ReFresh()
        {
            this.btnAddNew.Enabled = true;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnDelete.Enabled = false;
            this.ReadOnlyText(true);
            this.ResetTextEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.StateBtn.Equals("Add"))
            {
                this.ReFresh();
            }
            else
            {
                this.btnAddNew.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.btnDelete.Enabled = true;
                this.ReadOnlyText(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                if (this.IdPhieu != 0)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa dữ liệu này hay không?", "Bệnh viện điện tử .Net.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        result = ADRBLL.Del_ADR(this.IdPhieu);
                        if (result == 1)
                            XtraMessageBox.Show("Xóa dữ liệu thành công!", "Bệnh viện điện tử .Net.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Xóa dữ liệu không thành công!", "Bệnh viện điện tử .Net.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ReFresh();
                        this.LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ReFresh();
            }
        }

        private void btnAddBN_Click(object sender, EventArgs e)
        {
            if (this.IdPhieu != 0)
            {
                frmPatientsADR frm = new frmPatientsADR(this.IdPhieu);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.LoadChiTiet(this.IdPhieu);
                }
            }
            else
            {
                XtraMessageBox.Show("Không tìm thấy mã phiếu!", "Bệnh viện điện tử .Net.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddFromExcel_Click(object sender, EventArgs e)
        {
            string path = (Application.StartupPath).Substring(0, (Application.StartupPath).Length - 10);
            this.ofdgGetFile.ShowHelp = true;
            this.ofdgGetFile.FileName = path;
            this.ofdgGetFile.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            this.ofdgGetFile.ShowDialog();
        }
        private void LoadChiTiet(int id)
        {
            this.dtBenhNhan = ADRBLL.GetListBenhNhan(id);
            this.gridControl_BenhNhan.DataSource = this.dtBenhNhan;
        }
        private void ofdgGetFile_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string filePath = this.ofdgGetFile.FileName;
                DataTable dtNew = Utils.ReadFileExcel(filePath, 3);
                this.dtBenhNhan.Merge(dtNew);
                this.gridControl_BenhNhan.DataSource = this.dtBenhNhan;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnBnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IdPhieu != 0)
                {
                    if (this.dtBenhNhan.Rows.Count > 0)
                    {
                        List<ADR_BenhNhanInf> lstModel = new List<ADR_BenhNhanInf>();
                        foreach (DataRow row in this.dtBenhNhan.Rows)
                        {
                            ADR_BenhNhanInf model = new ADR_BenhNhanInf();
                            model.Id = string.IsNullOrEmpty(row["Id"].ToString()) ? 0 : Convert.ToInt32(row["Id"].ToString());
                            model.IdPhieuBaoCao = this.IdPhieu;
                            model.HoTen = row["HoTen"].ToString();
                            model.NgaySinh = row["NgaySinh"].ToString();
                            model.GioiTinh = row["GioiTinh"].ToString();
                            model.CanNang = row["CanNang"].ToString();
                            model.NgayXuatHienPhanUng = row["NgayXuatHienPhanUng"].ToString();
                            model.MoTaBieuHien = row["MoTaBieuHien"].ToString();
                            lstModel.Add(model);
                        }
                        ADRBLL.InsMulti_BenhNhan(lstModel);
                    }
                    XtraMessageBox.Show("Dữ liệu cập nhật thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadChiTiet(this.IdPhieu);
                }
                else
                    XtraMessageBox.Show("Mã phiếu không tồn tại.", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnBnCancel_Click(object sender, EventArgs e)
        {
            this.dtBenhNhan = null;
            this.gridControl_BenhNhan.DataSource = null;
            this.gridControl_Thuoc.DataSource = null;
            this.gridControl_Ngung.DataSource = null;
            this.gridControl_XuatHien.DataSource = null;
            this.IdPhieu = 0;
            this.tabArd.SelectedTabPage = this.tabPage_Phieu;
        }

        private void gridView_BenhNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_BenhNhan.RowCount > 0 && this.gridView_BenhNhan.GetFocusedRow() != null)
                {
                    this.idBenhNhan = Convert.ToInt32(this.gridView_BenhNhan.GetRowCellValue(this.gridView_BenhNhan.FocusedRowHandle, this.col_bn_Id).ToString());
                    LoadThuoc(this.idBenhNhan);
                }
            }
            catch
            {
            }
        }

        private void LoadThuoc(int id)
        {
            try
            {
                DataTable dtThuoc = ADRBLL.GetListThuoc(id);
                this.gridControl_Thuoc.DataSource = dtThuoc;
                this.gridControl_Ngung.DataSource = dtThuoc;
                this.gridControl_XuatHien.DataSource = dtThuoc;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_ADR_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_ADR.RowCount > 0 && this.gridView_ADR.GetFocusedRow() != null)
                {
                    this.IdPhieu = Convert.ToInt32(this.gridView_ADR.GetRowCellValue(this.gridView_ADR.FocusedRowHandle, this.col_th_Id).ToString());
                    ADR_PhieuBaoCaoInf model = ADRBLL.GetChiTietPhieu(this.IdPhieu);
                    this.txtMaPhieu.Text = model.MasoBaoCao;
                    this.dteNgay.EditValue = model.NgayBaoCao;
                    this.txtNoiBaoCao.Text = model.NoiBaoCao;
                    this.txtHoTen.Text = model.NguoiBaoCao;
                    this.txtNgheNghiep.Text = model.NgheNghiep;
                    this.txtPhone.Text = model.SoDienThoai;
                    this.cbxDangBC.Text = model.DangBaoCao;
                    this.ReadOnlyText(true);
                    this.btnAddNew.Enabled = true;
                    this.btnEdit.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_ADR_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView_ADR.RowCount > 0 && this.gridView_ADR.GetFocusedRow() != null)
            {
                this.IdPhieu = Convert.ToInt32(this.gridView_ADR.GetRowCellValue(this.gridView_ADR.FocusedRowHandle, this.col_th_Id).ToString());
                this.tabArd.SelectedTabPage = this.tabPage_ChiTietPhieu;
                this.LoadChiTiet(this.IdPhieu);
                this.gridControl_Thuoc.DataSource = null;
                this.gridControl_Ngung.DataSource = null;
                this.gridControl_XuatHien.DataSource = null;
            }
        }

        private void gridControl_BenhNhan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && this.gridView_BenhNhan.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa dữ liệu này hay không?", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            if (ADRBLL.Del_DanhSachBenhNhan(Convert.ToInt32(this.gridView_BenhNhan.GetRowCellValue(this.gridView_BenhNhan.FocusedRowHandle, "Id").ToString())) >= 1)
                            {
                                this.LoadChiTiet(this.IdPhieu);
                                this.gridControl_Thuoc.DataSource = null;
                                this.gridControl_Ngung.DataSource = null;
                                this.gridControl_XuatHien.DataSource = null;
                            }
                            else
                                XtraMessageBox.Show(" Xóa dữ liệu thất bại!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            XtraMessageBox.Show(" Xóa dữ liệu thất bại!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region So luong bao cao theo thang
        private void btnView_01_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtReport01 = ADRBLL.Report_PhanLoaiSST(Convert.ToDateTime(this.dteFromDate_01.EditValue), Convert.ToDateTime(this.dteToDate_01.EditValue));
                if (this.dtReport01 == null || this.dtReport01.Rows.Count < 1)
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.gridControl_Report01.DataSource = this.dtReport01;
                // chart
                this.chartReport01.DataSource = this.dtReport01;
                Series series1 = new Series("Số lượng", ViewType.Line);
                chartReport01.Series.Add(series1);
                series1.ArgumentDataMember = "Thang";
                series1.ValueDataMembers.AddRange(new string[] { "SoLuong" });
                //ket luan
                DataRow[] drMax = this.dtReport01.Select("[SoLuong] = MAX([SoLuong])");
                DataRow[] drMin = this.dtReport01.Select("[SoLuong] = Min([SoLuong])");
                this.txtNhanXet01.Text = "Số lượng báo cáo ARD ghi nhận ít nhất vào tháng " + drMin[0][1].ToString() + "\r\n" +
                "Số lượng báo cáo ARD nhiều nhất vào tháng " + drMax[0][1].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport_01_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport01 == null || this.dtReport01.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet dsTemp = new DataSet("tableDanhSach");
                this.dtReport01.TableName = "tbDanhSach";
                dsTemp.Merge(this.dtReport01);
                dsTemp.WriteXml(this.path + @"\\xml\\rptARD_SLBC.xml");
                Reports.rptARD_SLBC rpt = new Reports.rptARD_SLBC(Convert.ToDateTime(this.dteFromDate_01.EditValue), Convert.ToDateTime(this.dteToDate_01.EditValue), this.dtReport01);
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintExcel_01_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport01 == null || this.dtReport01.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Utils.Export_Excel(this.dtReport01, "Hình thức sai sót thuốc");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Bao cao thong tin benh nhan
        private void btnView02_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtReport02 = ADRBLL.Report_Tuoi(Convert.ToDateTime(dteFromDate02.EditValue), Convert.ToDateTime(dteToDate02.EditValue));
                this.dtGioiTinh02 = ADRBLL.Report_GioiTInh(Convert.ToDateTime(dteFromDate02.EditValue), Convert.ToDateTime(dteToDate02.EditValue));

                if (this.dtReport02.Rows.Count < 1 || this.dtGioiTinh02.Rows.Count < 1)
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.gridControl_Report02.DataSource = this.dtReport02;
                this.gridControl_GioiTinh02.DataSource = this.dtGioiTinh02;
                //ket luan
                DataRow[] drMaxOld = this.dtReport02.Select("[SoLuong] = MAX([SoLuong])");
                this.txtNhanXetTuoi02.Text = "Nhận thấy, ADR thường được ghi nhận nhiều nhất ở nhóm đối tượng " + drMaxOld[0][1].ToString() + " chiếm " + drMaxOld[0][3].ToString() + "%";

                DataRow[] drMaxSex = this.dtGioiTinh02.Select("[SoLuong] = MAX([SoLuong])");
                this.txtNhanXetGioiTinh02.Text = "Nhận thấy, ADR thường được ghi nhận nhiều nhất ở giới " + drMaxSex[0][1].ToString() + " chiếm " + drMaxSex[0][3].ToString() + "%";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport02_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport02.Rows.Count < 1 || this.dtGioiTinh02.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet dsTemp = new DataSet("table");
                this.dtReport02.TableName = "tableTuoi";
                this.dtGioiTinh02.TableName = "tableGioiTinh";
                dsTemp.Merge(this.dtReport02);
                dsTemp.Merge(this.dtGioiTinh02);
                dsTemp.WriteXml(this.path + @"\\xml\\rptADR_InfoPatient.xml");
                Reports.rptADR_InfoPatient rpt = new Reports.rptADR_InfoPatient(Convert.ToDateTime(this.dteFromDate02.EditValue), Convert.ToDateTime(this.dteToDate02.EditValue), this.dtReport02, this.dtGioiTinh02);
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintExcel02_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport02.Rows.Count < 1 || this.dtGioiTinh02.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Utils.Export_Excel(this.dtReport02, "Báo cáo theo tuổi");
                Utils.Export_Excel(this.dtGioiTinh02, "Báo cáo theo Giới tính");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Thong tin nghi ngo
        private void btnView03_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtDuongDung = ADRBLL.Report_DuongDung(Convert.ToDateTime(dteFromDate03.EditValue), Convert.ToDateTime(dteToDate03.EditValue));
                this.dtATC = ADRBLL.Report_ATC(Convert.ToDateTime(dteFromDate03.EditValue), Convert.ToDateTime(dteToDate03.EditValue));
                this.dtNghiNgo = ADRBLL.Report_ThuocNghiNgo(Convert.ToDateTime(dteFromDate03.EditValue), Convert.ToDateTime(dteToDate03.EditValue));

                if (this.dtDuongDung.Rows.Count < 1 || this.dtATC.Rows.Count < 1 || this.dtNghiNgo.Rows.Count < 1)
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.gridControl_DuongDung.DataSource = this.dtDuongDung;
                this.gridControl_report_ATC.DataSource = this.dtATC;
                this.gridControl_NghiNgo.DataSource = this.dtNghiNgo;

                //ket luan
                DataRow[] drMaxDuongDung = dtDuongDung.Select("[SoLuong] = MAX([SoLuong])");
                string klDuongDung = "Nhận thấy, phản ứng có hại xảy ra nhiều nhất khi dùng thuốc ";
                for (int i = 0; i < drMaxDuongDung.Count(); i++)
                {
                    klDuongDung += drMaxDuongDung[i][1].ToString() + " ,";
                }
                klDuongDung = klDuongDung.TrimEnd(',');
                klDuongDung += "chiếm " + drMaxDuongDung[0][3].ToString() + "%";
                txtNhanXetDuongDung.Text = klDuongDung;

                DataRow[] drMaxATC = dtATC.Select("[SoLuong] = MAX([SoLuong])");
                string klATC = "Nhận thấy, nhóm ";
                for (int i = 0; i < drMaxATC.Count(); i++)
                {
                    klATC += drMaxATC[i][2].ToString() + " ,";
                }
                klATC = klATC.TrimEnd(',');
                klATC += "ghi nhận nhiều nhất, chiếm tỷ lệ " + drMaxATC[0][4].ToString() + "%";
                txtNhanXetATC.Text = klATC;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport03_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtDuongDung.Rows.Count < 1 || this.dtATC.Rows.Count < 1 || this.dtNghiNgo.Rows.Count < 1)
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet dsTemp = new DataSet("table");
                this.dtDuongDung.TableName = "tableDuongDung";
                this.dtATC.TableName = "tableATC";
                this.dtNghiNgo.TableName = "tableNghiNgo";
                dsTemp.Merge(this.dtDuongDung);
                dsTemp.Merge(this.dtATC);
                dsTemp.Merge(this.dtNghiNgo);
                dsTemp.WriteXml(this.path + @"\\xml\\rptADR_NghiNgoThuoc.xml");
                Reports.rptADR_NghiNgoThuoc rpt = new Reports.rptADR_NghiNgoThuoc(Convert.ToDateTime(this.dteFromDate03.EditValue), Convert.ToDateTime(this.dteToDate03.EditValue), this.dtDuongDung, this.dtATC, this.dtNghiNgo);
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dtTungThang = ADRBLL.Report_PhanLoaiSST(Convert.ToDateTime(this.dteFrom.EditValue), Convert.ToDateTime(this.dteTo.EditValue));
                DataTable dtTuoi = ADRBLL.Report_Tuoi(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtGioiTinh = ADRBLL.Report_GioiTInh(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtDuongDung = ADRBLL.Report_DuongDung(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtATC = ADRBLL.Report_ATC(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable NghiNgo = ADRBLL.Report_ThuocNghiNgo(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));

                DataSet dsTemp = new DataSet("tableDanhSach");
                dtTungThang.TableName = "dtTungThang";
                dtTuoi.TableName = "dtTuoi";
                dtGioiTinh.TableName = "dtGioiTinh";
                dtDuongDung.TableName = "dtDuongDung";
                dtATC.TableName = "dtATC";
                NghiNgo.TableName = "NghiNgo";
                dsTemp.Merge(dtTungThang);
                dsTemp.Merge(dtTuoi);
                dsTemp.Merge(dtGioiTinh);
                dsTemp.Merge(dtDuongDung);
                dsTemp.Merge(dtATC);
                dsTemp.Merge(NghiNgo);

                dsTemp.WriteXml(this.path +  @"\\xml\\rptTongKetADR.xml");
                Reports.ADR.rptTongKetADR rpt = new Reports.ADR.rptTongKetADR(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue), dtTungThang, dtTuoi, dtGioiTinh, dtDuongDung, dtATC, dtNghiNgo);
                rpt.DataSource = dsTemp;
                //
                //ReportPrintTool rptPrv = new ReportPrintTool(rpt);
                //rpt.CreateDocument();
                //rptPrv.PreviewForm.Shown += new EventHandler(PreviewForm_Shown);

                //rptPrv.ShowPreviewDialog();
                rpt.ShowRibbonPreviewDialog();
            }
            catch
            {
                XtraMessageBox.Show("Lỗi hoặc Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        //-----
        //void PreviewForm_Shown(object sender, EventArgs e)
        //{
        //    PrintPreviewFormEx form = (PrintPreviewFormEx)sender;
        //    PrintPreviewBarItem item = (PrintPreviewBarItem)form.PrintBarManager.GetBarItemByCommand(PrintingSystemCommand.ExportFile);
        //    PopupMenu control = (PopupMenu)((DevExpress.XtraBars.BarButtonItem)(item)).DropDownControl;
        //    BarButtonItem barItem = new BarButtonItem();
        //    barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick);
        //    barItem.Caption = "DOC File";
        //    control.AddItem(barItem);

        //    barItem = new BarButtonItem();
        //    barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick2);
        //    barItem.Caption = "DOCX File";
        //    control.AddItem(barItem);
        //}
        //void barItem_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    ExportToDOC2("doc", DocumentFormat.Doc);
        //}
        //void barItem_ItemClick2(object sender, ItemClickEventArgs e)
        //{
        //    ExportToDOC2("docx", DocumentFormat.OpenXml);
        //}

        //private void ExportToDOC2(string extension, DocumentFormat df)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    DataTable dtTungThang = ADRBLL.Report_PhanLoaiSST(Convert.ToDateTime(this.dteFrom.EditValue), Convert.ToDateTime(this.dteTo.EditValue));
        //    DataTable dtTuoi = ADRBLL.Report_Tuoi(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
        //    DataTable dtGioiTinh = ADRBLL.Report_GioiTInh(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
        //    DataTable dtDuongDung = ADRBLL.Report_DuongDung(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
        //    DataTable dtATC = ADRBLL.Report_ATC(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
        //    DataTable NghiNgo = ADRBLL.Report_ThuocNghiNgo(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));

        //    DataSet dsTemp = new DataSet("tableDanhSach");
        //    dtTungThang.TableName = "dtTungThang";
        //    dtTuoi.TableName = "dtTuoi";
        //    dtGioiTinh.TableName = "dtGioiTinh";
        //    dtDuongDung.TableName = "dtDuongDung";
        //    dtATC.TableName = "dtATC";
        //    NghiNgo.TableName = "NghiNgo";
        //    dsTemp.Merge(dtTungThang);
        //    dsTemp.Merge(dtTuoi);
        //    dsTemp.Merge(dtGioiTinh);
        //    dsTemp.Merge(dtDuongDung);
        //    dsTemp.Merge(dtATC);
        //    dsTemp.Merge(NghiNgo);

        //    dsTemp.WriteXml(this.path + @"\\xml\\rptTongKetADR.xml");
        //    Reports.ADR.rptTongKetADR_W rpt = new Reports.ADR.rptTongKetADR_W(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue), dtTungThang, dtTuoi, dtGioiTinh, dtDuongDung, dtATC, dtNghiNgo);
        //    rpt.DataSource = dsTemp;
        //    sfd.FileName = Environment.CurrentDirectory + "\\" + rpt.ExportOptions.PrintPreview.DefaultFileName + "." + extension;
        //    sfd.Filter = extension + " File|*.doc";

        //    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        using (RichEditDocumentServer docServer = new RichEditDocumentServer())
        //        {
        //            rpt.ExportToHtml("test.html", new HtmlExportOptions() { ExportMode = HtmlExportMode.SingleFile, EmbedImagesInHTML = true });
        //            docServer.LoadDocument("test.html", DocumentFormat.Html);
        //            docServer.SaveDocument(sfd.FileName, df);
        //        }
        //        File.Delete("test.html");
        //        if (MessageBox.Show("Would you like to open file exported file?", extension + " export", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            Process.Start(sfd.FileName);
        //        }
        //    }
        //}
        //--------
        private void gridView_Thuoc_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if(this.idBenhNhan == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn bệnh nhân để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_thuoc_TenThuoc))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_thuoc_TenThuoc, "Tên thuốc không được để trống!");
                }
                if (e.Valid)
                {
                    ADR_ThongTinThuoc inf = new ADR_ThongTinThuoc();
                    inf.Id = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "Id").ToString()) ? Convert.ToInt32(gridView_Thuoc.GetRowCellValue(e.RowHandle, "Id").ToString()) : 0;
                    inf.ThuocNghiADR = !string.IsNullOrEmpty(gridView_Thuoc.GetRowCellValue(e.RowHandle, "ThuocNghiADR").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "ThuocNghiADR").ToString()) : false;
                    inf.TenThuoc = gridView_Thuoc.GetRowCellValue(e.RowHandle, "TenThuoc").ToString();
                    inf.DangBaoChe = gridView_Thuoc.GetRowCellValue(e.RowHandle, "DangBaoChe").ToString();
                    inf.NhaSanXuat = gridView_Thuoc.GetRowCellValue(e.RowHandle, "NhaSanXuat").ToString();
                    inf.SoLo = gridView_Thuoc.GetRowCellValue(e.RowHandle, "SoLo").ToString();
                    inf.LieuDung1Lan = gridView_Thuoc.GetRowCellValue(e.RowHandle, "LieuDung1Lan").ToString();
                    inf.SoLanDung1Ngay = gridView_Thuoc.GetRowCellValue(e.RowHandle, "SoLanDung1Ngay").ToString();
                    inf.DuongDung = gridView_Thuoc.GetRowCellValue(e.RowHandle, "DuongDung").ToString();
                    inf.NgayDT_BatDau = gridView_Thuoc.GetRowCellValue(e.RowHandle, "NgayDT_BatDau").ToString();
                    inf.NgayDT_KetThuc = gridView_Thuoc.GetRowCellValue(e.RowHandle, "NgayDT_KetThuc").ToString();
                    inf.LyDoDungThuoc = gridView_Thuoc.GetRowCellValue(e.RowHandle, "LyDoDungThuoc").ToString();
                    inf.IdBenhNhan = this.idBenhNhan;

                    inf.CaiThienKhiNgung_Co = false;
                    inf.CaiThienKhiNgung_Khong = false;
                    inf.CaiThienKhiNgung_KoNgung = false;
                    inf.CaiThienKhiNgung_KoCoThongTin = false;
                    inf.XuatHienPhanUngLai_Co = false;
                    inf.XuatHienPhanUngLai_Khong = false;
                    inf.XuatHienPhanUngLai_KoTaiSuDung = false;
                    inf.XuatHienPhanUngLai_KoCoThongTin = false;
                    //inf.CaiThienKhiNgung_Co = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Co").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Co").ToString()) : false;
                    //inf.CaiThienKhiNgung_Khong = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Khong").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Khong").ToString()) : false;
                    //inf.CaiThienKhiNgung_KoNgung = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoNgung").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoNgung").ToString()) : false;
                    //inf.CaiThienKhiNgung_KoCoThongTin = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoCoThongTin").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoCoThongTin").ToString()) : false;
                    //inf.XuatHienPhanUngLai_Co = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Co").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Co").ToString()) : false;
                    //inf.XuatHienPhanUngLai_Khong = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Khong").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Khong").ToString()) : false;
                    //inf.XuatHienPhanUngLai_KoTaiSuDung = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoTaiSuDung").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoTaiSuDung").ToString()) : false;
                    //inf.XuatHienPhanUngLai_KoCoThongTin = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoCoThongTin").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoCoThongTin").ToString()) : false;
                    inf.MaPhanLoaiATC = !string.IsNullOrEmpty(gridView_Thuoc.GetRowCellValue(e.RowHandle, "RowID").ToString()) ? Convert.ToInt32(gridView_Thuoc.GetRowCellValue(e.RowHandle, "RowID").ToString()) : 0;
                    if (e.RowHandle < 0)
                    {
                        if (ADRBLL.InsThuoc(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm mới dữ liệu thành công!", "PowerMED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThuoc(this.idBenhNhan);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm dữ liệu thất bại!", "PowerMED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (ADRBLL.UpdThuoc(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "PowerMED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu thất bại!", "PowerMED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(Exception ex) { XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gridView_Ngung_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (this.idBenhNhan == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn bệnh nhân để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (e.Valid)
                {
                    ADR_ThongTinThuoc inf = new ADR_ThongTinThuoc();
                    inf.Id = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "Id").ToString()) ? Convert.ToInt32(gridView_Thuoc.GetRowCellValue(e.RowHandle, "Id").ToString()) : 0;
                    inf.CaiThienKhiNgung_Co = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Co").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Co").ToString()) : false;
                    inf.CaiThienKhiNgung_Khong = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Khong").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_Khong").ToString()) : false;
                    inf.CaiThienKhiNgung_KoNgung = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoNgung").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoNgung").ToString()) : false;
                    inf.CaiThienKhiNgung_KoCoThongTin = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoCoThongTin").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "CaiThienKhiNgung_KoCoThongTin").ToString()) : false;
                    if (e.RowHandle >= 0)
                    {
                        if (ADRBLL.UpdThuoc_Ngung(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThuoc(this.idBenhNhan);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu thất bại!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gridView_XuatHien_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (this.idBenhNhan == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn bệnh nhân để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (e.Valid)
                {
                    ADR_ThongTinThuoc inf = new ADR_ThongTinThuoc();
                    inf.Id = !string.IsNullOrEmpty(gridView_Ngung.GetRowCellValue(e.RowHandle, "Id").ToString()) ? Convert.ToInt32(gridView_Thuoc.GetRowCellValue(e.RowHandle, "Id").ToString()) : 0;
                    inf.XuatHienPhanUngLai_Co = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Co").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Co").ToString()) : false;
                    inf.XuatHienPhanUngLai_Khong = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Khong").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_Khong").ToString()) : false;
                    inf.XuatHienPhanUngLai_KoTaiSuDung = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoTaiSuDung").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoTaiSuDung").ToString()) : false;
                    inf.XuatHienPhanUngLai_KoCoThongTin = !string.IsNullOrEmpty(gridView_XuatHien.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoCoThongTin").ToString()) ? Convert.ToBoolean(gridView_Thuoc.GetRowCellValue(e.RowHandle, "XuatHienPhanUngLai_KoCoThongTin").ToString()) : false;
                    if (e.RowHandle >= 0)
                    {
                        if (ADRBLL.UpdThuoc_XuatHien(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThuoc(this.idBenhNhan);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu thất bại!", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void gridControl_Thuoc_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Thuoc.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa dữ liệu này hay không?", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (ADRBLL.DelThuoc(Convert.ToInt32(gridView_Thuoc.GetRowCellValue(gridView_Thuoc.FocusedRowHandle, "Id").ToString())) >= 1)
                            LoadThuoc(idBenhNhan);
                    }
                    catch { return; }
                }
            }
        }

        private void ExportWord_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTungThang = ADRBLL.Report_PhanLoaiSST(Convert.ToDateTime(this.dteFrom.EditValue), Convert.ToDateTime(this.dteTo.EditValue));
                DataTable dtTuoi = ADRBLL.Report_Tuoi(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtGioiTinh = ADRBLL.Report_GioiTInh(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtDuongDung = ADRBLL.Report_DuongDung(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtATC = ADRBLL.Report_ATC(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable NghiNgo = ADRBLL.Report_ThuocNghiNgo(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));

                DataSet dsTemp = new DataSet("tableDanhSach");
                dtTungThang.TableName = "dtTungThang";
                dtTuoi.TableName = "dtTuoi";
                dtGioiTinh.TableName = "dtGioiTinh";
                dtDuongDung.TableName = "dtDuongDung";
                dtATC.TableName = "dtATC";
                NghiNgo.TableName = "NghiNgo";
                dsTemp.Merge(dtTungThang);
                dsTemp.Merge(dtTuoi);
                dsTemp.Merge(dtGioiTinh);
                dsTemp.Merge(dtDuongDung);
                dsTemp.Merge(dtATC);
                dsTemp.Merge(NghiNgo);

                dsTemp.WriteXml(this.path + @"\\xml\\rptTongKetADR.xml");
                Reports.ADR.rptTongKetADR rpt = new Reports.ADR.rptTongKetADR(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue), dtTungThang, dtTuoi, dtGioiTinh, dtDuongDung, dtATC, dtNghiNgo);
                rpt.DataSource = dsTemp;
                this.ExportToDOC(DocumentFormat.OpenXml, rpt, "Báo cáo ADR");
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, " Bệnh viện điện tử .NET. ", MessageBoxButtons.OK);
            }
        }

        private void gridView_BenhNhan_DoubleClick(object sender, EventArgs e)
        {
            frmPatientDetail frmPatien = new frmPatientDetail();
            frmPatien.getIdBn = Convert.ToInt32(gridView_BenhNhan.GetRowCellValue(gridView_BenhNhan.FocusedRowHandle, col_bn_Id).ToString());
            frmPatien.ShowDialog();
            LoadChiTiet(IdPhieu);
        }

        private void ExportToDOC(DocumentFormat df, XtraReport report, string fileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = fileName;
            sfd.Filter = " File|*.doc";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (DevExpress.XtraRichEdit.RichEditDocumentServer docServer = new DevExpress.XtraRichEdit.RichEditDocumentServer())
                {
                    report.ExportToRtf("test.rtf");
                    docServer.LoadDocument("test.rtf", DocumentFormat.Rtf);
                    docServer.SaveDocument(sfd.FileName, df);
                }
                File.Delete("test.rtf");
                if (XtraMessageBox.Show("Bạn có muốn mở file lên không?", " Export", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Process.Start(sfd.FileName);
                }
            }
        }
    }
}