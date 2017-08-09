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

namespace Ps.Clinic.VenABC
{
    public partial class frmCacPhanTichLienQuanABC : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tbDanhSach = new DataTable();
        private OpenFileDialog ofdImportFile = new OpenFileDialog();
        private DataTable tableData;
        private string userID = string.Empty;
        private string path = string.Empty;
        public frmCacPhanTichLienQuanABC(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmCacPhanTichLienQuanABC_Load(object sender, EventArgs e)
        {
            try
            {
                this.path = Utils.CurrentPathApplication();
                this.CreateTableColumn();
                this.lktInventory.Properties.DataSource = RepositoryCatalog_BLL.ListRepository(0);
                this.lktInventory.Properties.ValueMember = "RepositoryCode";
                this.lktInventory.Properties.DisplayMember = "RepositoryName";
                this.cbxNhomVEN.EditValue = "VEN";
                this.dteFrom.EditValue = this.dteTo.EditValue = Utils.DateServer();
                this.ofdImportFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdImportFile_FileOk);
                this.Load_Phieu();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void btnXem_Click(object sender, EventArgs e)
        {
            if(this.lktPhieuABC.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phiếu để thực hiện", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.tbDanhSach = Ven_AnalistBLL.GetThongKeABC(this.cbxNhomVEN.EditValue.ToString(), this.lktPhieuABC.EditValue.ToString());
            this.grdDanhSach.DataSource = this.tbDanhSach;
        }

        private void btnPTAABC_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.grdDanhSach.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieuABC.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichABC frmAbc = new frmPhanTichABC(this.tbDanhSach, Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]));
                    frmAbc.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMaTran_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.grdDanhSach.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieuABC.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichMaTranABCVEN frmMaTranAbc = new frmPhanTichMaTranABCVEN(this.tbDanhSach, Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]));
                    frmMaTranAbc.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTNABC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbxNhomVEN.EditValue.ToString() == "N")
                {
                    this.tbDanhSach = (DataTable)this.grdDanhSach.DataSource;

                    DataTable timeFormTo = new DataTable();
                    timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieuABC.EditValue.ToString());

                    if (this.tbDanhSach != null)
                    {
                        frmPhanTichNABC frmNAbc = new frmPhanTichNABC(this.tbDanhSach, Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]));
                        frmNAbc.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Phải chọn nhóm N để tính tỷ lệ %", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbxNhomVEN.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDMABC_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.grdDanhSach.DataSource;
                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieuABC.EditValue.ToString());
                if (this.tbDanhSach != null)
                {
                    DataSet dsResult = new DataSet("tableDanhSach");
                    dsResult.Merge(this.tbDanhSach.Select("[ABC] = 'A' or [ABC] = 'B' or [ABC] = 'C' "));
                    dsResult.WriteXml(this.path + @"\\Xml\\rptThongKeABC.xml");
                    Reports.rptThongKeAABC rpt = new Reports.rptThongKeAABC();
                    rpt.DataSource = dsResult;
                    rpt.Parameters["fromdate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]);
                    rpt.Parameters["todate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]);
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDMNABC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbxNhomVEN.EditValue.ToString() == "N")
                {
                    this.tbDanhSach = (DataTable)this.grdDanhSach.DataSource;
                    DataTable timeFormTo = new DataTable();
                    timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieuABC.EditValue.ToString());
                    if (this.tbDanhSach != null)
                    {
                        DataSet dsResult = new DataSet("tableDanhSach");
                        dsResult.Merge(this.tbDanhSach.Select("[VEN] = 'N'"));
                        dsResult.WriteXml(this.path + @"\\Xml\\rptThongKeNABC.xml");
                        Reports.rptThongKeNBAC rpt = new Reports.rptThongKeNBAC();
                        rpt.DataSource = dsResult;
                        rpt.Parameters["fromdate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]);
                        rpt.Parameters["todate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]);
                        rpt.CreateDocument();
                        rpt.ShowRibbonPreviewDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Phải chọn nhóm N để tính tỷ lệ %", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxNhomVEN.Focus();
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDMABCVEN_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.grdDanhSach.DataSource;
                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieuABC.EditValue.ToString());
                if (this.tbDanhSach != null)
                {
                    DataSet dsTemp = new DataSet("tableDanhSach");
                    dsTemp.Merge(this.tbDanhSach);
                    dsTemp.WriteXml(this.path + @"\\Xml\\rptThongKeMaTran.xml");
                    Reports.rptThongKeMaTran rpt = new Reports.rptThongKeMaTran();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["fromdate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]);
                    rpt.Parameters["todate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]);
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Load_Phieu()
        {
            DataTable tbAnalist = Ven_AnalistBLL.GetListVENABC_Analist();
            this.lktPhieuABC.Properties.DataSource = tbAnalist;
            this.lktPhieuABC.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieuABC.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu_NoiNgoai.Properties.DataSource = tbAnalist;
            this.lktPhieu_NoiNgoai.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu_NoiNgoai.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu_ATC.Properties.DataSource = tbAnalist;
            this.lktPhieu_ATC.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu_ATC.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu_VEN.Properties.DataSource = tbAnalist;
            this.lktPhieu_VEN.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu_VEN.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu1_by2Time.Properties.DataSource = tbAnalist;
            this.lktPhieu1_by2Time.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu1_by2Time.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu2_by2Time.Properties.DataSource = tbAnalist;
            this.lktPhieu2_by2Time.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu2_by2Time.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu1_VenBy2Time.Properties.DataSource = tbAnalist;
            this.lktPhieu1_VenBy2Time.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu1_VenBy2Time.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu2_VenBy2Time.Properties.DataSource = tbAnalist;
            this.lktPhieu2_VenBy2Time.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu2_VenBy2Time.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu1_ChiSoHQ.Properties.DataSource = tbAnalist;
            this.lktPhieu1_ChiSoHQ.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu1_ChiSoHQ.Properties.ValueMember = "VENABC_Code";

            this.lktPhieu2_ChiSoHQ.Properties.DataSource = tbAnalist;
            this.lktPhieu2_ChiSoHQ.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieu2_ChiSoHQ.Properties.ValueMember = "VENABC_Code";
        }
        
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_Result.DataSource = null;
                this.CreateTableColumn();
                if (this.lktInventory.EditValue == null || string.IsNullOrEmpty(this.lktInventory.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng chọn kho để xem số liệu tồn.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lktInventory.Focus();
                    return;
                }
                else
                {
                    this.LoadDataRepository();
                    this.txtPhieu.Text = this.dteFrom.Text.Substring(3, 2) + "." + this.dteFrom.Text.Substring(6, 4);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_NoiNgoai_Click(object sender, EventArgs e)
        {
            if (this.lktPhieu_NoiNgoai.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phiếu để thực hiện", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.tbDanhSach = Ven_AnalistBLL.GetThongKeABCVENTheoThuocNoiNgoai(this.lktPhieu_NoiNgoai.EditValue.ToString());
            this.gridControl_ABC_NoiNgoai.DataSource = this.tbDanhSach;
        }

        private void btnPTTheoChungLoai_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ABC_NoiNgoai.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu_NoiNgoai.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichTyLeSuDungThuocNoiVaNgoai frmAbcNoiNgoai = new frmPhanTichTyLeSuDungThuocNoiVaNgoai(this.tbDanhSach, Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]));
                    frmAbcNoiNgoai.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTTheoGiaTri_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ABC_NoiNgoai.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu_NoiNgoai.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichTyLeSuDungThuocNoiVaNgoaiByValue frmAbcNoiNgoai = new frmPhanTichTyLeSuDungThuocNoiVaNgoaiByValue(this.tbDanhSach, Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]));
                    frmAbcNoiNgoai.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_ATC_Click(object sender, EventArgs e)
        {
            if (this.lktPhieu_ATC.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phiếu để thực hiện", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.tbDanhSach = Ven_AnalistBLL.GetThongKeABCTheoATC(lktPhieu_ATC.EditValue.ToString());
            this.gridControl_ATC.DataSource = this.tbDanhSach;
        }

        private void btnInDMATC_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ATC.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu_ATC.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    DataSet dsTemp = new DataSet("tableDanhSach");
                    //dsTemp.Tables.Add(dtResult);
                    dsTemp.Merge(this.tbDanhSach);
                    dsTemp.WriteXml(this.path + @"\\Xml\\rptPhanTichATC.xml");
                    Reports.rptPhanTichATC rpt = new Reports.rptPhanTichATC();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["fromdate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]);
                    rpt.Parameters["todate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]);
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTATC_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ATC.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu_ATC.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichATC frmATC = new frmPhanTichATC(Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]), this.lktPhieu_ATC.EditValue.ToString());
                    frmATC.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_VEN_Click(object sender, EventArgs e)
        {
            if (this.lktPhieu_VEN.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phiếu để thực hiện", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.tbDanhSach = Ven_AnalistBLL.ThongKeABCVENTheoThoiGian(this.lktPhieu_VEN.EditValue.ToString());
            this.gridControl_VEN.DataSource = this.tbDanhSach;
        }

        private void btnInDM_VEN_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_VEN.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu_VEN.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    DataSet dsTemp = new DataSet("tableDanhSach");
                    dsTemp.Merge(this.tbDanhSach.Select("[VEN] = 'V' or [VEN] = 'E' or [VEN] = 'N' "));
                    dsTemp.WriteXml(this.path + @"\\Xml\\rptThongKeVEN.xml");
                    Reports.rptThongKeVEN rpt = new Reports.rptThongKeVEN();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["fromdate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]);
                    rpt.Parameters["todate"].Value = Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]);
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("Dữ liệu không phát sinh.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTVEN_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_VEN.DataSource;

                DataTable timeFormTo = new DataTable();
                timeFormTo = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu_VEN.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichVenByTime frmVEN = new frmPhanTichVenByTime(this.tbDanhSach, Convert.ToDateTime(timeFormTo.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo.Rows[0]["ToDate"]));
                    frmVEN.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_ABCby2Time_Click(object sender, EventArgs e)
        {
            if (this.lktPhieu1_by2Time.EditValue == null || this.lktPhieu2_by2Time.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phiểu để thực hiện", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.tbDanhSach = Ven_AnalistBLL.GetThongKeABCVEN2Time(this.lktPhieu1_by2Time.EditValue.ToString(), this.lktPhieu2_by2Time.EditValue.ToString());
            this.gridControl_ABCby2Time.DataSource = this.tbDanhSach;
        }

        private void btnPTABCbyChungLoai_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ABCby2Time.DataSource;

                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_by2Time.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_by2Time.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPTABCbyChungLoai frmABC = new frmPTABCbyChungLoai(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmABC.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTABCByValue_Click(object sender, EventArgs e)
        {
            try {
                this.tbDanhSach = (DataTable)this.gridControl_ABCby2Time.DataSource;

                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_by2Time.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_by2Time.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPTABCbyValue frmABC = new frmPTABCbyValue(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmABC.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTABCVENbyChungLoai_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ABCby2Time.DataSource;

                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_by2Time.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_by2Time.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPTABCVENbyChungLoai frmABC = new frmPTABCVENbyChungLoai(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmABC.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTABCVENByValue_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ABCby2Time.DataSource;

                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_by2Time.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_by2Time.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPTABCVENbyValue frmABC = new frmPTABCVENbyValue(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmABC.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_VenBy2Time_Click(object sender, EventArgs e)
        {
            if (this.lktPhieu1_VenBy2Time.EditValue == null || this.lktPhieu2_VenBy2Time.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phiếu để thực hiện", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.tbDanhSach = Ven_AnalistBLL.GetABCVENTheoThoiGian2Time(this.lktPhieu1_VenBy2Time.EditValue.ToString(), this.lktPhieu2_VenBy2Time.EditValue.ToString());
            this.gridControl_VenBy2Time.DataSource = this.tbDanhSach;
        }

        private void btnPTVENbyChungLoai_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_VenBy2Time.DataSource;

                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_VenBy2Time.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_VenBy2Time.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichVENbyChungLoai frmVEN = new frmPhanTichVENbyChungLoai(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmVEN.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPTVENByValue_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_VenBy2Time.DataSource;

                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_VenBy2Time.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_VenBy2Time.EditValue.ToString());

                if (this.tbDanhSach != null)
                {
                    frmPhanTichVenbyValue frmVEN = new frmPhanTichVenbyValue(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmVEN.Show();
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_ChiSoHQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lktPhieu1_ChiSoHQ.EditValue == null || this.lktPhieu2_ChiSoHQ.EditValue == null)
                {
                    XtraMessageBox.Show("Chọn phiếu để xem phân tích.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lktPhieu1_ChiSoHQ.Focus();
                    return;
                }
                this.tbDanhSach = Ven_AnalistBLL.GetChiSoHieuQua(this.lktPhieu1_ChiSoHQ.EditValue.ToString(), this.lktPhieu2_ChiSoHQ.EditValue.ToString());
                this.gridControl_ChiSoHQ.DataSource = tbDanhSach;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPhantich_ChiSoHQ_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbDanhSach = (DataTable)this.gridControl_ChiSoHQ.DataSource;
                DataTable timeFormTo1 = new DataTable();
                timeFormTo1 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu1_ChiSoHQ.EditValue.ToString());
                DataTable timeFormTo2 = new DataTable();
                timeFormTo2 = Ven_AnalistBLL.GetVENABC_AnalistByVENcode(this.lktPhieu2_ChiSoHQ.EditValue.ToString());
                if (this.tbDanhSach != null)
                {
                    frmPhanTich frmChiSo = new frmPhanTich(this.tbDanhSach,
                                                                            Convert.ToDateTime(timeFormTo1.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo1.Rows[0]["ToDate"]),
                                                                            Convert.ToDateTime(timeFormTo2.Rows[0]["FromDate"]), Convert.ToDateTime(timeFormTo2.Rows[0]["ToDate"]));
                    frmChiSo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rdRepository_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdRepository.Checked)
            {
                this.lktInventory.Properties.ReadOnly = false;
                this.btnView.Enabled = true;
            }
            else
            {
                this.lktInventory.Properties.ReadOnly = true;
                this.btnView.Enabled = false;
            }
        }

        private void rdImpFileExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdImpFileExcel.Checked)
                this.btnPathExcel.Enabled = true;
            else
                this.btnPathExcel.Enabled = false;
        }

        private void btnPathExcel_Click(object sender, EventArgs e)
        {
            this.gridControl_Result.DataSource = null;
            this.CreateTableColumn();
            this.ofdImportFile.ShowHelp = true;
            this.ofdImportFile.FileName = string.Empty;
            this.ofdImportFile.Filter = "Excel Sheet(*.xls)|*.xlsx|All Files(*.*)|*.*";
            this.ofdImportFile.ShowDialog();
        }

        private void ofdImportFile_FileOk(object sender, CancelEventArgs e)
        {
            this.txtPathName.Text = this.ofdImportFile.FileName;
            this.LoadDataFileExcel();
            this.txtPhieu.Text = this.dteFrom.Text.Substring(3, 2) + "." + this.dteFrom.Text.Substring(6, 4);
        }

        private void LoadDataRepository()
        {
            DataTable tableTemp = rpt_Medicines_BLL.DT_View_XNT_General(this.lktInventory.EditValue.ToString(), this.dteFrom.Text, this.dteTo.Text, string.Empty);
            if (tableTemp != null && tableTemp.Rows.Count > 0)
            {
                if (tableTemp.Select("Generic_BD='B' and TotalQuantityEnd>0").Length > 0)
                {
                    DataTable table_B = tableTemp.Select("Generic_BD='B' and TotalQuantityEnd>0").CopyToDataTable();
                    foreach (DataRow row in table_B.Rows)
                    {
                        DataRow row_add_B = this.tableData.NewRow();
                        row_add_B["ItemName"] = row["ItemName"];
                        row_add_B["Active"] = row["Active"];
                        row_add_B["BietDuoc"] = row["Generic_BD"];
                        row_add_B["Generic"] = string.Empty;
                        row_add_B["VENCode"] = row["VENCode"];
                        row_add_B["CountryName"] = row["CountryName"];
                        row_add_B["ATCCode"] = row["ATCCode"];
                        row_add_B["UnitOfMeasureName"] = row["UnitOfMeasureName"];
                        row_add_B["Quantity"] = row["TotalQuantityEnd"];
                        row_add_B["UnitPriceVAT"] = row["SalesPrice"];
                        this.tableData.Rows.Add(row_add_B);
                    }  
                }

                if (tableTemp.Select("Generic_BD='G' and TotalQuantityEnd>0").Length > 0)
                {
                    DataTable table_G = tableTemp.Select("Generic_BD='G' and TotalQuantityEnd>0").CopyToDataTable();
                    foreach (DataRow row in table_G.Rows)
                    {
                        DataRow row_add_G = this.tableData.NewRow();
                        row_add_G["ItemName"] = row["ItemName"];
                        row_add_G["Active"] = row["Active"];
                        row_add_G["BietDuoc"] = string.Empty;
                        row_add_G["Generic"] = row["Generic_BD"];
                        row_add_G["VENCode"] = row["VENCode"];
                        row_add_G["CountryName"] = row["CountryName"];
                        row_add_G["ATCCode"] = row["ATCCode"];
                        row_add_G["UnitOfMeasureName"] = row["UnitOfMeasureName"];
                        row_add_G["Quantity"] = row["TotalQuantityEnd"];
                        row_add_G["UnitPriceVAT"] = row["SalesPrice"];
                        this.tableData.Rows.Add(row_add_G);
                    }     
                }
            }
            this.gridControl_Result.DataSource = this.tableData;
        }

        private void LoadDataFileExcel()
        {
            DataTable tableTemp = Utils.ReadFileExcel(this.txtPathName.Text);
            if (tableTemp != null && tableTemp.Rows.Count > 0)
            {
                foreach(DataRow row in tableTemp.Rows)
                {
                    DataRow row_add = this.tableData.NewRow();
                    row_add["ItemName"] = row[0];
                    row_add["Active"] = row[1];
                    row_add["BietDuoc"] = row[2];
                    row_add["Generic"] = row[3];
                    row_add["VENCode"] = row[4];
                    row_add["CountryName"] = row[5];
                    row_add["ATCCode"] = row[6];
                    row_add["UnitOfMeasureName"] = row[7];
                    row_add["Quantity"] = row[8];
                    row_add["UnitPriceVAT"] = row[9];
                    this.tableData.Rows.Add(row_add);
                }
            }
            this.gridControl_Result.DataSource = this.tableData;
        }

        private void CreateTableColumn()
        {
            this.tableData = new DataTable();
            this.tableData.Columns.Add("ItemName", typeof(string));
            this.tableData.Columns.Add("Active", typeof(string));
            this.tableData.Columns.Add("BietDuoc", typeof(string));
            this.tableData.Columns.Add("Generic", typeof(string));
            this.tableData.Columns.Add("VENCode", typeof(string));
            this.tableData.Columns.Add("CountryName", typeof(string));
            this.tableData.Columns.Add("ATCCode", typeof(string));
            this.tableData.Columns.Add("UnitOfMeasureName", typeof(string));
            this.tableData.Columns.Add("Quantity", typeof(decimal));
            this.tableData.Columns.Add("UnitPriceVAT", typeof(decimal));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtPhieu.Text))
                {
                    XtraMessageBox.Show("Phiếu không được bỏ trống.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPhieu.Focus();
                    return;
                }
                if (this.tableData.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu phân tích chưa phát sinh!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPhieu.Focus();
                    return;
                }
                string venCode = Ven_AnalistBLL.Ins_VENABC_Analist(this.txtPhieu.Text.Trim(), this.dteFrom.EditValue.ToString(), this.dteTo.EditValue.ToString(), this.userID);
                if (!string.IsNullOrEmpty(venCode))
                {
                    if (!venCode.Equals("exist"))
                    {
                        bool isInsert = true;
                        foreach(DataRow row in this.tableData.Rows)
                        {
                            if (Ven_AnalistBLL.Ins_VENABC_AnalistDetail(this.txtPhieu.Text.Trim(), row["ItemName"].ToString(), row["UnitOfMeasureName"].ToString(), row["Active"].ToString(), row["BietDuoc"].ToString(), row["Generic"].ToString(), row["VENCode"].ToString(), row["CountryName"].ToString(), row["ATCCode"].ToString(), Convert.ToDecimal(row["Quantity"]), Convert.ToDecimal(row["UnitPriceVAT"])) < 1)
                            {
                                isInsert = false;
                                break;
                            }
                        }
                        if (!isInsert)
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu phiếu không thành công.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Ven_AnalistBLL.Delete_VENABC_Analist(this.txtPhieu.Text.Trim());
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật dữ liệu phiếu thành công.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.gridControl_Result.DataSource = Ven_AnalistBLL.GetViewInventory(this.txtPhieu.Text.Trim());
                        }
                        this.Load_Phieu();
                    }
                    else
                        XtraMessageBox.Show("Số phiếu đã tồn tại.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelPhieu_Click(object sender, EventArgs e)
        {
            frmDelPhieu frm = new frmDelPhieu();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                this.Load_Phieu();
        }
    }
}