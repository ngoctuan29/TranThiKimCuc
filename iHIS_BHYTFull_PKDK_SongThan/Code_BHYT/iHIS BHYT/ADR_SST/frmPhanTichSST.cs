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

namespace Ps.Clinic.ADR_SST
{
    public partial class frmPhanTichSST : DevExpress.XtraEditors.XtraForm
    {
        private int IdPhieu = 0;
        private string userID = string.Empty;
        private string StateBtn = string.Empty;
        private OpenFileDialog ofdgGetFile = new OpenFileDialog();
        private DateTime dtServer = new DateTime();
        private DataTable dtChiTietPhieu = new DataTable();
        private DataTable dtChiTietPhieuOld = new DataTable();
        private DataTable dtReport01 = new DataTable();
        private DataTable dtReport02 = new DataTable();
        private DataTable dtReport03 = new DataTable();
        private string path = string.Empty;
        public frmPhanTichSST(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }
        private void frmPhanTichSST_Load(object sender, EventArgs e)
        {
            try
            {
                this.path = Utils.CurrentPathApplication();
                this.dteNgay.EditValue = this.dtServer = Utils.DateServer();
                this.dteToDate01.EditValue = this.dteFromDate01.EditValue = this.dtServer;
                this.dteToDate02.EditValue = this.dteFromDate02.EditValue = this.dtServer;
                this.dteToDate03.EditValue = this.dteFromDate03.EditValue = this.dtServer;

                btnAddNew.Enabled = true;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                this.ReadOnlyText(true);
                this.LoadData();
                this.LoadPanel();
                this.ofdgGetFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdgGetFile_FileOk);
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
            txtMaBC.ReadOnly = en;
            dteNgay.ReadOnly = en;
            txtDonViBaoCao.ReadOnly = en;
            txtTongLuot.ReadOnly = en;
            txtGhiChu.ReadOnly = en;
        }
        private void LoadData()
        {
            this.gridControl_PhieuBC.DataSource = SSTBLL.GetListSaiSotThuoc(0);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            ReadOnlyText(false);
            ResetTextEdit();
            this.StateBtn = "Add";
            this.IdPhieu = 0;
            txtMaBC.Focus();
        }
        public void ResetTextEdit()
        {
            txtMaBC.Text = string.Empty;
            dteNgay.EditValue = this.dtServer;
            txtDonViBaoCao.Text = string.Empty;
            txtTongLuot.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAddNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            ReadOnlyText(false);
            this.StateBtn = "Edit";
            txtMaBC.ReadOnly = true;
            dteNgay.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaBC.Text))
                {
                    XtraMessageBox.Show("Nhập mã số báo cáo!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int result = 0;
                SaiSot_PhieuBaoCaoInf model = new SaiSot_PhieuBaoCaoInf();
                model.NoiBaoCao = txtDonViBaoCao.Text;
                model.MaSoBaoCao = txtMaBC.Text;
                model.NgayNhapPhieu = Convert.ToDateTime(dteNgay.EditValue);
                model.Ghichu = txtGhiChu.Text;
                model.TongLuotKham = txtTongLuot.Value.ToString();
                if (this.StateBtn.Equals("Add"))
                {
                    if (SSTBLL.CheckExistId(model.MaSoBaoCao) == 1)
                    {
                        XtraMessageBox.Show("Mã đã tồn tại!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    model.Id = 0;
                    if (SSTBLL.InsUpd_SaiSotThuoc(model) == 1)
                        XtraMessageBox.Show("Thêm dữ liệu thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        result = -1;
                }
                else if (this.StateBtn.Equals("Edit") && this.IdPhieu != 0)
                {
                    model.Id = this.IdPhieu;
                    if (SSTBLL.InsUpd_SaiSotThuoc(model) == 1)
                        XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        result = -1;
                }
                if (result == -1)
                {
                    XtraMessageBox.Show("Cập nhật không thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReFresh();
            }
            btnAddNew.Enabled = true;
            if (this.IdPhieu == 0)
                btnEdit.Enabled = false;
            else
                btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = true;
            ReadOnlyText(true);
            LoadData();
        }
        private void ReFresh()
        {
            btnAddNew.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            ReadOnlyText(true);
            ResetTextEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.StateBtn.Equals("Add"))
            {
                ReFresh();
            }
            else
            {
                btnAddNew.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
                ReadOnlyText(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                if (this.IdPhieu != 0)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa dữ liệu này hay không?", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        result = SSTBLL.Del_SaiSotThuoc(this.IdPhieu);
                        if (result == 1)
                            XtraMessageBox.Show("Xóa dữ liệu thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Xóa dữ liệu không thành công!", "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ReFresh();
                        this.LoadData();
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHis - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ReFresh();
            }
        }

        private void gridView_PhieuBC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PhieuBC.RowCount > 0 && this.gridView_PhieuBC.GetFocusedRow() != null)
                {
                    this.IdPhieu = Convert.ToInt32(gridView_PhieuBC.GetRowCellValue(gridView_PhieuBC.FocusedRowHandle, col_bc_Id).ToString());
                    SaiSot_PhieuBaoCaoInf model = SSTBLL.GetChiTietPhieu(this.IdPhieu);
                    txtMaBC.Text = model.MaSoBaoCao;
                    dteNgay.EditValue = model.NgayNhapPhieu;
                    txtDonViBaoCao.Text = model.NoiBaoCao;
                    txtTongLuot.Text = model.TongLuotKham;
                    txtGhiChu.Text = model.Ghichu;
                    ReadOnlyText(true);
                    btnAddNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridView_PhieuBC_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PhieuBC.RowCount > 0 && this.gridView_PhieuBC.GetFocusedRow() != null)
                {
                    this.dtChiTietPhieuOld = null;
                    this.IdPhieu = Convert.ToInt32(gridView_PhieuBC.GetRowCellValue(gridView_PhieuBC.FocusedRowHandle, col_bc_Id).ToString());
                    tabArd.SelectedTabPage = tabPage_ChiTietPhieu;
                    LoadChiTiet(this.IdPhieu);
                    this.dtChiTietPhieuOld = SSTBLL.GetListDetailSaiSotThuoc(this.IdPhieu);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void LoadChiTiet(int idPhieu)
        {
            this.dtChiTietPhieu = SSTBLL.GetListDetailSaiSotThuoc(idPhieu);
            this.gridControl_ChiTietPhieu.DataSource = this.dtChiTietPhieu;
        }

        private void btnAddFromExcel_Click(object sender, EventArgs e)
        {
            string path = (Application.StartupPath).Substring(0, (Application.StartupPath).Length - 10);
            ofdgGetFile.ShowHelp = true;
            ofdgGetFile.FileName = path;
            ofdgGetFile.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            ofdgGetFile.ShowDialog();
        }
        private void ofdgGetFile_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string filePath = ofdgGetFile.FileName;
                DataTable dtNew = Utils.ReadFileExcel(filePath, 3);
                this.dtChiTietPhieu.Merge(dtNew);
                this.gridControl_ChiTietPhieu.DataSource = this.dtChiTietPhieu;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSaveGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IdPhieu != 0)
                {
                    if (this.dtChiTietPhieu.Rows.Count > 0)
                    {
                        List<SaiSot_DanhSach> lstModel = new List<SaiSot_DanhSach>();
                        foreach (DataRow row in this.dtChiTietPhieu.Rows)
                        {
                            SaiSot_DanhSach model = new SaiSot_DanhSach();
                            model.Id = string.IsNullOrEmpty(row["Id"].ToString()) ? 0 : Convert.ToInt32(row["Id"].ToString());
                            model.IdPhieuBaoCao = this.IdPhieu;
                            model.NgayBaoCao = Convert.ToDateTime(row["NgayBaoCao"].ToString());
                            model.NguoiBaoCao = row["NguoiBaoCao"].ToString();
                            model.ThoiGianXayRaSuCo = row["ThoiGianXayRaSuCo"].ToString();
                            model.KhoaPhong_DiaDiemXayRa = row["KhoaPhong_DiaDiemXayRa"].ToString();
                            model.MoTaSuCo = row["MoTaSuCo"].ToString();
                            model.HauQuaXayRa = row["HauQuaXayRa"].ToString();
                            model.CachXuTriTucThoi = row["CachXuTriTucThoi"].ToString();
                            model.CapBaoCao = row["CapBaoCao"].ToString();
                            model.GiaiPhapKhacPhuc = row["GiaiPhapKhacPhuc"].ToString();
                            model.TrachNhiem = row["TrachNhiem"].ToString();
                            model.DanhGiaLai = row["DanhGiaLai"].ToString();
                            model.Ghichu = row["Ghichu"].ToString();
                            model.HinhThucSaiSot = row["HinhThucSaiSot"].ToString();
                            model.PhanLoai = row["PhanLoai"].ToString();
                            lstModel.Add(model);
                        }
                        SSTBLL.InsMulti_DetailSaiSotThuoc(lstModel);
                    }
                    XtraMessageBox.Show("Dữ liệu cập nhật thành công!", "iHis - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChiTiet(this.IdPhieu);
                }
                else
                {
                    XtraMessageBox.Show(" Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCancelChitiet_Click(object sender, EventArgs e)
        {
            this.dtChiTietPhieu.Clear();
            this.gridControl_ChiTietPhieu.DataSource = null;
            tabArd.SelectedTabPage = tabPage_Phieu;
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa tất cả dữ liệu này hay không?", "iHis - Bệnh viện điện tử", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    SSTBLL.Del_AllDanhSachSaiSotThuoc(this.IdPhieu);
                    this.dtChiTietPhieu.Clear();
                    this.gridControl_ChiTietPhieu.DataSource = null;
                    XtraMessageBox.Show("Dữ liệu xóa thành công!", "iHis - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #region bao cao sst khoa phong
        
        private void btnView_01_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtReport01 = SSTBLL.Report_SSTKhoaPhong(Convert.ToDateTime(dteFromDate01.EditValue), Convert.ToDateTime(dteToDate01.EditValue));
                this.gridControl_report01.DataSource = this.dtReport01;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        private void btnReport_01_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport01.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet dsTemp = new DataSet("tableDanhSach");
                this.dtReport01.TableName = "tbDanhSach";
                dsTemp.Merge(this.dtReport01);
                dsTemp.WriteXml(this.path + @"\\xml\\rptSSTKhoaPhong.xml");
                Reports.rptSSTKhoaPhong rpt = new Reports.rptSSTKhoaPhong(Convert.ToDateTime(this.dteFromDate01.EditValue), Convert.ToDateTime(this.dteToDate01.EditValue));
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        private void btnPrintExcel_01_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport01.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Utils.Export_Excel(this.dtReport01, "Sai sót thuốc theo khoa phòng");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region bao cao hinh thuc sai sot lien quan den thuoc
        private void btnView02_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtReport02 = SSTBLL.Report_HinhThucSST(Convert.ToDateTime(dteFromDate02.EditValue), Convert.ToDateTime(dteToDate02.EditValue));
                gridControl_report02.DataSource = this.dtReport02;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnReport02_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport02.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet dsTemp = new DataSet("tableDanhSach");
                this.dtReport02.TableName = "tbDanhSach";
                dsTemp.Merge(this.dtReport02);
                dsTemp.WriteXml(this.path + @"\\Xml\\rptHinhThucSST.xml");
                Reports.rptHinhThucSST rpt = new Reports.rptHinhThucSST(Convert.ToDateTime(this.dteFromDate02.EditValue), Convert.ToDateTime(this.dteToDate02.EditValue));
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        private void btnPrintExcel02_Click(object sender, EventArgs e)
        {
            if (this.dtReport02.Rows.Count < 1)
            {
                XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Utils.Export_Excel(this.dtReport02, "Hình thức sai sót thuốc");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region Bao cao lien quan den muc do nghiem trong
        private void btnView03_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtReport03 = SSTBLL.Report_PhanLoaiSST(Convert.ToDateTime(dteFromDate03.EditValue), Convert.ToDateTime(dteToDate03.EditValue));
                gridControl_report03.DataSource = this.dtReport03;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        private void btnReport03_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtReport03.Rows.Count < 1)
                {
                    XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet dsTemp = new DataSet("tableDanhSach");
                this.dtReport03.TableName = "tbDanhSach";
                dsTemp.Merge(this.dtReport03);
                dsTemp.WriteXml(this.path + @"\\xml\\rptPhanLoaiSST.xml");
                Reports.rptPhanLoaiSST rpt = new Reports.rptPhanLoaiSST(Convert.ToDateTime(this.dteFromDate03.EditValue), Convert.ToDateTime(this.dteToDate03.EditValue));
                rpt.DataSource = dsTemp;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        private void btnPrintExcel_Click(object sender, EventArgs e)
        {
            if (this.dtReport03.Rows.Count < 1)
            {
                XtraMessageBox.Show(" Chưa có danh sách để thực hiện! ", "iHIS - Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Utils.Export_Excel(this.dtReport03, "Phân loại sai sót thuốc");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKhoaPhong = SSTBLL.Report_SSTKhoaPhong(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtHinhThuc = SSTBLL.Report_HinhThucSST(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));
                DataTable dtPhanLoai = SSTBLL.Report_PhanLoaiSST(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue));

                DataSet dsTemp = new DataSet("tableDanhSach");
                dtKhoaPhong.TableName = "dtKhoaPhong";
                dtHinhThuc.TableName = "dtHinhThuc";
                dtPhanLoai.TableName = "dtPhanLoai";
                dsTemp.Merge(dtKhoaPhong);
                dsTemp.Merge(dtHinhThuc);
                dsTemp.Merge(dtPhanLoai);

                dsTemp.WriteXml(this.path + @"\\Xml\\rptTongKetSST.xml");
                Reports.ADR.rptTongKetSST rpt = new Reports.ADR.rptTongKetSST(Convert.ToDateTime(dteFrom.EditValue), Convert.ToDateTime(dteTo.EditValue), dtHinhThuc, dtPhanLoai, dtKhoaPhong);
                rpt.DataSource = dsTemp;
                this.ExportToDOC(DocumentFormat.OpenXml, rpt, "Báo cáo sai sót thuốc");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, " Bệnh viện điện tử .NET. ", MessageBoxButtons.OK);
            }
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
                if (MessageBox.Show("Bạn có muốn mở file lên không?", " Export", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }
    }
}