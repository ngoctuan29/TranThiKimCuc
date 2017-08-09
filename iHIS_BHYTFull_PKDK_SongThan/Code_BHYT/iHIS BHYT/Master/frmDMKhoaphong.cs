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
using DevExpress.XtraReports.UI;

namespace Ps.Clinic.Master
{
    public partial class frmDMKhoaphong : DevExpress.XtraEditors.XtraForm
    {
        List<RepositoryCatalog_Inf> lstRep = new List<RepositoryCatalog_Inf>();
        private string sUserid = string.Empty;
        public frmDMKhoaphong(string _Userid)
        {
            InitializeComponent();
            sUserid = _Userid;
        }

        private void frmDMKhoaphong_Load(object sender, EventArgs e)
        {
            try
            {
                lstRep = RepositoryCatalog_BLL.ListRepositoryForDepartment(0);
                chkRepository.DataSource = lstRep;
                chkRepository.DisplayMember = "RepositoryName";
                chkRepository.ValueMember = "RepositoryCode";

                this.repLoaiKhoa.Items.Add("0");
                this.repLoaiKhoa.Items.Add("1");
                this.repLoaiKhoa.Items.Add("2");

                this.rep_List_Depart.DataSource = ServiceGroupBLL.DTServiceGroup(string.Empty);
                this.rep_List_Depart.ValueMember = "ServiceGroupCode";
                this.rep_List_Depart.DisplayMember = "ServiceGroupName";

                this.rep_List_departBHYT.DataSource = DepartmentBLL.DTDepartmentBHYT();
                this.rep_List_departBHYT.ValueMember = "MaKhoa";
                this.rep_List_departBHYT.DisplayMember = "TenKhoa";

                this.rep_List_LoaiKhoa.DataSource = DepartmentBLL.DTLoaiKhoa();
                this.rep_List_LoaiKhoa.ValueMember = "Id";
                this.rep_List_LoaiKhoa.DisplayMember = "TenLoai";
                this.LoadDataDepartment();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void LoadDataDepartment()
        {
            DataTable tableData = DepartmentBLL.DTDepartment(string.Empty);
            DataTable tableResult = new DataTable();
            if (this.chkKhoa.Checked)
            {
                if (tableData != null && tableData.Rows.Count > 0 && tableData.Select("Hide=1").Length > 0)
                    tableResult = tableData.Select("Hide=1").CopyToDataTable();
            }
            else
            {
                if (tableData != null && tableData.Rows.Count > 0 && tableData.Select("Hide=0").Length > 0)
                    tableResult = tableData.Select("Hide=0").CopyToDataTable();
            }
            this.gridControl_Depart.DataSource = tableResult;
        }

        private void gridView_Depart_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                this.chkRepository.UnCheckAll();
                DataTable dtTemp = DepartmentBLL.DT_DepartmentForRepository(this.gridView_Depart.GetRowCellValue(this.gridView_Depart.FocusedRowHandle, "DepartmentCode").ToString());
                foreach (DataRow dr in dtTemp.Rows)
                {
                    for (int i = 0; i < this.chkRepository.ItemCount; i++)
                    {
                        if (this.chkRepository.GetItemValue(i).ToString() == dr["RepositoryCode"].ToString())
                            this.chkRepository.SetItemChecked(i, true);
                    }
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sDepartmentCode = gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "DepartmentCode").ToString();
                string sDepartmentName = gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "DepartmentName").ToString();
                string sServiceGroupCode = gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "ServiceGroupCode").ToString();
                string sHide = gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "Hide").ToString();
                string sIdBv = gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "IdBv").ToString();
                string sKBHYT = gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "KBHYT").ToString();
                int iHide=0;
                if (sHide != "")
                    iHide = Convert.ToInt32(gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "Hide").ToString());
                int iIdBv = 0;
                if (sIdBv != "")
                    iIdBv = Convert.ToInt32(gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "IdBv").ToString());
                if (sDepartmentName == string.Empty)
                {
                    gridView_Depart.SetColumnError(col_List_DepartmentName, "Tên phòng không được để trống !");
                    return;
                }
                if (sServiceGroupCode == string.Empty)
                {
                    gridView_Depart.SetColumnError(col_List_ServiceGroupCode, "Chọn phân hệ!");
                    return;
                }
                else
                {
                    DepartmentInf inf = new DepartmentInf();
                    inf.DepartmentCode = sDepartmentCode;
                    inf.DepartmentName = sDepartmentName;
                    inf.ServiceGroupCode = sServiceGroupCode;
                    inf.Hide = iHide;
                    inf.IdBv = iIdBv;
                    inf.KBHYT = sKBHYT;
                    DepartmentBLL.DelDepartmentForRepository(sDepartmentCode);
                    if (DepartmentBLL.InsDepartment(inf) == 1)
                    {
                        for (int i = 0; i < lstRep.Count; i++)
                        {
                            if (chkRepository.GetItemChecked(i) == true)
                                DepartmentBLL.InsDepartmentForRepository(inf.DepartmentCode, chkRepository.GetItemValue(i).ToString(), sUserid);
                        }
                        XtraMessageBox.Show(" Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show(" Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.LoadDataDepartment();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridControl_Depart_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Depart.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa phòng khám này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            if (DepartmentBLL.DelDepartment(gridView_Depart.GetRowCellValue(gridView_Depart.FocusedRowHandle, "DepartmentCode").ToString()) == 1)
                                this.LoadDataDepartment();
                        }
                        catch { return; }
                    }
                }
                
            }
            catch { return; }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtResult = DepartmentBLL.DTDepartment(string.Empty);
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptDMKhoaPhong.xml");
                Reports.rptDMKhoaPhong rptShow = new Reports.rptDMKhoaPhong();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DMKhoaPhong","Danh mục khoa phòng");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.LoadDataDepartment();
        }
    }
}