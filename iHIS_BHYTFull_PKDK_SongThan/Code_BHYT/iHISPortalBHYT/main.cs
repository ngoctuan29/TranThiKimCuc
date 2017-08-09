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

namespace GiamDinhBHYT
{
    public partial class main : DevExpress.XtraEditors.XtraForm
    {
        public main()
        {
            InitializeComponent();
           // this.Getdetailhistory();
        }
        private string userName = "79024_BV";
        private string passWord = "Bvnd115@22789";
        private string userNameTC = "79163_TC";
        private string passWordTC = "1qaz2wsx";
        private List<ModelGDBHYT.LichSuKhamBenh> dsLichSuKCB = new List<ModelGDBHYT.LichSuKhamBenh>();

        
        private void Getdetailhistory()
        {
            //ModelGDBHYT.QueryParameterHistoryExaminationPatientDetail dataquery = new ModelGDBHYT.QueryParameterHistoryExaminationPatientDetail();
            //dataquery.userName = this.userName;
            //dataquery.passWord = this.passWord;
            //if (dsLichSuKCB.Count > 0)
            //    dsLichSuKCB.Clear();
            //ModelGDBHYT.ResultHistoryExaminationPatient datahistory = this.GetHistory();
            //if( datahistory.dsLichSuKCB!= null)
            //{
            //    List<ModelGDBHYT.ResultHistoryExaminationPatientDetail> list = new List<ModelGDBHYT.ResultHistoryExaminationPatientDetail>();
            //    foreach(var item in datahistory.dsLichSuKCB)
            //    {
            //        ModelGDBHYT.LichSuKhamBenh lichSuKCB = new ModelGDBHYT.LichSuKhamBenh();
            //        lichSuKCB.denNgay = item.denNgay;
            //        lichSuKCB.tinhTrang = (short)int.Parse(item.tinhTrang);
            //        lichSuKCB.maHoSo = item.maHoSo;
            //        lichSuKCB.maCSKCB = item.maCSKCB;
            //        lichSuKCB.maHoSo = item.maHoSo;
            //        lichSuKCB.tuNgay = item.tuNgay;
            //        dataquery.maHoSo = item.maHoSo;
            //        ModelGDBHYT.ResultHistoryExaminationPatientDetail data = new ModelGDBHYT.ResultHistoryExaminationPatientDetail();
            //        data = FunctionGDBHYT.GetHistoryExaminationPatientDetail(dataquery);
            //        if (data.hoSoKCB != null)
            //        {
            //            lichSuKCB.tenBenhNhan = data.hoSoKCB.xml1.HoTen;
            //            lichSuKCB.maICD = data.hoSoKCB.xml1.MaBenh;
            //            lichSuKCB.maLK = data.hoSoKCB.xml1.MaLk;
            //            lichSuKCB.ketQua = data.hoSoKCB.xml1.KetQuaDtri??1;
            //            lichSuKCB.tinhTrang = data.hoSoKCB.xml1.TinhTrangRv ?? 1;
            //            lichSuKCB.gioiTinh = data.hoSoKCB.xml1.GioiTinh??1;
            //            lichSuKCB.ngaySinh = data.hoSoKCB.xml1.NgaySinh;
            //            lichSuKCB.tenBenh = data.hoSoKCB.xml1.TenBenh;
            //            if(data.hoSoKCB.dsXml2!=null)
            //            {
            //                List<ModelGDBHYT.xml2> lstxml2 = new List<ModelGDBHYT.xml2>();
            //                foreach (var itemxml2 in data.hoSoKCB.dsXml2)
            //                {
            //                    ModelGDBHYT.xml2 xml2 = new ModelGDBHYT.xml2();
            //                    xml2.soDKThuoc = itemxml2.SoDangKy;
            //                    xml2.tenThuoc = itemxml2.TenThuoc;
            //                    lstxml2.Add(xml2);

            //                }
            //                lichSuKCB.dsThuoc = lstxml2;
            //            }
            //            if (data.hoSoKCB.dsXml3 != null)
            //            {
            //                List<ModelGDBHYT.xml3> lstxml3 = new List<ModelGDBHYT.xml3>();
            //                foreach (var itemxml3 in data.hoSoKCB.dsXml3)
            //                {
            //                    ModelGDBHYT.xml3 xml3 = new ModelGDBHYT.xml3();
            //                    xml3.maDichVu = itemxml3.MaDichVu;
            //                    xml3.maVatTu = itemxml3.MaVatTu;
            //                    xml3.tenDichVu = itemxml3.TenDichVu;
            //                    lstxml3.Add(xml3);

            //                }
            //                lichSuKCB.dsDichvu = lstxml3;
            //            }
            //        }
            //        dsLichSuKCB.Add(lichSuKCB);
            //    }
            if (dsLichSuKCB.Count > 0)
                dsLichSuKCB.Clear();

            ModelGDBHYT.DataHistoryExaminationPatient data = new ModelGDBHYT.DataHistoryExaminationPatient();
            data.gioiTinh = txtBHYTGioiTinh.SelectedIndex < 0 ? txtBHYTGioiTinh.SelectedIndex + 1 : txtBHYTGioiTinh.SelectedIndex + 1;
            data.hoTen = txtBHYTten.Text;//"Võ Trần Mộng Thu";//"Nguyễn Vũ Minh Duy";//"Trần Ngọc Tuấn"; //
            data.maCSKCB = txtHBYTMaCSKCBBD.Text;// "79024";//"79057";//
            data.maThe = txtBHYTMathe.Text;// "HC4790707200012";//"HC4790055500504";//"SV4790002002188";//
            data.ngayBD = txtBHYTTuNgay.Text.ToString();//"01/10/2016";
            data.ngayKT = txtBHYTDenNgay.Text.ToString();//"31/12/2016";
            data.ngaySinh = txtBHYTNgaySinh.Text;// "08/0/1972"; //"29/03/1990";
            dsLichSuKCB = FunctionGDBHYT.GetDataViewLichSuKhamBenh(this.userName, this.passWord, data);
                if(dsLichSuKCB.Count>0)
                {
                    treeViewLichSuKCB.Nodes.Clear();
                    TreeNode rootNode = new TreeNode("Lịch sử khám bệnh");
                    rootNode.ExpandAll();
                    foreach(var item in dsLichSuKCB)
                    {
                        TreeNode childNode = new TreeNode(item.tuNgay);
                        childNode.Tag = item.maLK;
                        rootNode.Nodes.Add(childNode);
                    }
                    this.treeViewLichSuKCB.Nodes.Add(rootNode);
                this.treeViewLichSuKCB.SelectedNode = treeViewLichSuKCB.Nodes[0].Nodes[0];
                }
            }

        private void CheckThe()
        {
            //ModelGDBHYT.QueryParameterHistoryExaminationPatient dataquery = new ModelGDBHYT.QueryParameterHistoryExaminationPatient();
            //dataquery.userName = this.userNameTC;
            //dataquery.passWord = this.passWordTC;
            ModelGDBHYT.DataHistoryExaminationPatient data = new ModelGDBHYT.DataHistoryExaminationPatient();
            data.gioiTinh = txtBHYTGioiTinh.SelectedIndex<0 ? txtBHYTGioiTinh.SelectedIndex + 1: txtBHYTGioiTinh.SelectedIndex + 1;
            data.hoTen = txtBHYTten.Text;//"Võ Trần Mộng Thu";//"Nguyễn Vũ Minh Duy";//"Trần Ngọc Tuấn"; //
            data.maCSKCB = txtHBYTMaCSKCBBD.Text;// "79024";//"79057";//
            data.maThe = txtBHYTMathe.Text;// "HC4790707200012";//"HC4790055500504";//"SV4790002002188";//
            data.ngayBD = txtBHYTTuNgay.Text.ToString();//"01/10/2016";
            data.ngayKT = txtBHYTDenNgay.Text.ToString();//"31/12/2016";
            data.ngaySinh = txtBHYTNgaySinh.Text;// "08/0/1972"; //"29/03/1990";
            ModelGDBHYT.ResultCheckTheBHYT result = FunctionGDBHYT.CheckTheBHYT(this.userNameTC,this.passWordTC, data);
            XtraMessageBox.Show(result.ketQua, "iHIS Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeViewLichSuKCB_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeView nodeselect = (TreeView)sender;
                string maLK = string.Empty;
                maLK = nodeselect.SelectedNode.Tag.ToString();
                if(!string.IsNullOrEmpty(maLK))
                { this.DisplaySelectNode(maLK);
                    this.xtraTabThongTinKhamBenh.SelectedTabPageIndex = 1;
                }
            }
            catch(Exception ex)
            { }
        }
        private void DisplaySelectNode(string maLK)
        {
            var data = dsLichSuKCB.FirstOrDefault(p => p.maLK == maLK);
            if (data != null)
            { try
                {
                    this.txtHoTen.Text = data.tenBenhNhan;
                    this.TxtBenh.Text = data.tenBenh;
                    this.txtKetQua.SelectedIndex = data.ketQua - 1;
                    this.txtGioiTinh.SelectedIndex = data.gioiTinh-1;
                    this.txtMaHoSo.Text = data.maHoSo;
                    this.txtCoSoKCB.EditValue = data.maCSKCB;
                    this.dtTuNgay.EditValue = data.tuNgay;
                    this.dtDenNgay.EditValue = data.denNgay;
                    this.TxtBenh.Text = data.tenBenh;
                    this.txtTinhTrang.SelectedIndex = data.tinhTrang - 1;
                    this.txtDiaChi.Text = data.diaChi;
                    this.txtNgaySinh.EditValue = FunctionGDBHYT.CoverStringtoDate(data.ngaySinh);
                }
                catch (Exception ex){ }
                }
            if(data.dsThuoc.Count>0)
            {
                this.GCThuoc.DataSource = data.dsThuoc;
            }
            if(data.dsDichvu.Count>0)
            {
                this.GCDichVu.DataSource = data.dsDichvu;
            }
               
        }

        private void main_Load(object sender, EventArgs e)
        {
            //  this.Getdetailhistory();
            // this.CheckThe();
            txtBHYTGioiTinh.SelectedIndex = 0;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.CheckThe();
            this.Getdetailhistory();
        }
    }
}