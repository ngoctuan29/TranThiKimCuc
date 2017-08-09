using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;

namespace iHISPortalBHYT
{
    public partial class frmGetHistoryPatients : DevExpress.XtraEditors.XtraForm
    {
        private string userName_BV = string.Empty, passWord_BV = string.Empty;
        private List<ModelGDBHYT.LichSuKhamBenh> dsLichSuKCB = new List<ModelGDBHYT.LichSuKhamBenh>();
        private DataTable listDataKCBBD = new DataTable();
        private ModelGDBHYT.DataHistoryExaminationPatient dataCard = new ModelGDBHYT.DataHistoryExaminationPatient();
        public frmGetHistoryPatients(DataTable DataKCBBD, string userNameGiamDinh, string passWordGiamDinh, ModelGDBHYT.DataHistoryExaminationPatient _dataCard)
        {
            InitializeComponent();
            this.userName_BV = userNameGiamDinh;
            this.passWord_BV = passWordGiamDinh;
            this.listDataKCBBD = DataKCBBD;
            this.dataCard = _dataCard;
        }
        private void Getdetailhistory()
        {
            if (this.dsLichSuKCB.Count > 0)
                this.dsLichSuKCB.Clear();
            FuncPortalBHYT portal = new FuncPortalBHYT();
            this.dsLichSuKCB = portal.GetDataViewLichSuKhamBenh(this.userName_BV, this.passWord_BV, this.dataCard);
            if (this.dsLichSuKCB.Count > 0)
            {
                this.treeViewLichSuKCB.Nodes.Clear();
                TreeNode rootNode = new TreeNode("Lịch sử khám bệnh");
                rootNode.ExpandAll();
                foreach (var item in this.dsLichSuKCB)
                {
                    TreeNode childNode = new TreeNode(item.tuNgay);
                    childNode.Tag = item.maLK;
                    rootNode.Nodes.Add(childNode);
                }
                this.treeViewLichSuKCB.Nodes.Add(rootNode);
                this.treeViewLichSuKCB.SelectedNode = this.treeViewLichSuKCB.Nodes[0].Nodes[0];
            }
        }
        private void treeViewLichSuKCB_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeView nodeselect = (TreeView)sender;
                string maLK = string.Empty;
                maLK = nodeselect.SelectedNode.Tag.ToString();
                if (!string.IsNullOrEmpty(maLK))
                {
                    this.DisplaySelectNode(maLK);
                    this.xtraTabThongTinKhamBenh.SelectedTabPageIndex = 1;
                }
            }
            catch
            { }
        }
        private void DisplaySelectNode(string maLK)
        {
            var data = dsLichSuKCB.FirstOrDefault(p => p.maLK == maLK);
            if (data != null)
            {
                try
                {
                    this.txtHoTen.Text = data.tenBenhNhan;
                    this.TxtBenh.Text = data.tenBenh;
                    this.txtKetQua.SelectedIndex = data.ketQua - 1;
                    this.txtGioiTinh.SelectedIndex = data.gioiTinh - 1;
                    this.txtMaHoSo.Text = data.maHoSo;
                    this.txtCoSoKCB.EditValue = data.maCSKCB;
                    this.dtTuNgay.EditValue = data.tuNgay;
                    this.dtDenNgay.EditValue = data.denNgay;
                    this.TxtBenh.Text = data.tenBenh;
                    this.txtTinhTrang.SelectedIndex = data.tinhTrang - 1;
                    this.txtDiaChi.Text = data.diaChi;
                    this.txtNgaySinh.EditValue = Common.CoverStringtoDate(data.ngaySinh);
                }
                catch { }
            }
            if (data.dsThuoc.Count > 0)
            {
                this.GCThuoc.DataSource = data.dsThuoc;
            }
            if (data.dsDichvu.Count > 0)
            {
                this.GCDichVu.DataSource = data.dsDichvu;
            }
        }
        private void main_Load(object sender, EventArgs e)
        {
            this.Getdetailhistory();
        }
    }
}