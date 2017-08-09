using System;

using ClinicModel;

namespace Ps.Clinic.Reports
{
    public partial class rptADR_PhanUngCoHaiCuaThuoc : DevExpress.XtraReports.UI.XtraReport
	{
		private ADR_BenhNhanInf model = new ADR_BenhNhanInf();
        public rptADR_PhanUngCoHaiCuaThuoc(ADR_BenhNhanInf bnRpt)
		{
			this.model = bnRpt;
			InitializeComponent();
		}

        private string AddText(string text)
        {
            string textResult = string.Empty;
            textResult = "..." + text + "....";
            return textResult;
        }

		private void ADR_BaoCaoPhanUngCoHaiCuaThuoc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			lblTenDonVi.Text = AddText(model.TenDonVi);
			lblMaSoBaoCao.Text = AddText(model.MaSoBaoCao);
			lblMaSoBaoCaoCuaDonVi.Text = AddText(model.MaSoBaoCaoCuaDonVi);
			lblHoTen.Text = AddText(model.HoTen);
			lblNgaySinh.Text = AddText(model.NgaySinh);
			lblCanNang.Text = AddText(model.CanNang);

			lblNgayXuatHien.Text = AddText(model.NgayXuatHienPhanUng);
			lblPhanUngSau.Text = AddText(model.PhanUngXuatHienSau);

			lblMoTa.Text = model.MoTaBieuHien;
			lblCachXuTri.Text = AddText(model.CachXuTri);
			lblTienXu.Text = AddText(model.TienSu);
			lblXetNghiemLienQuan.Text = AddText(model.CacXetNghiemLienQuan);
			lblGioiTinh.Text = AddText(model.GioiTinh);

			check_MD_TuVong.Checked = Convert.ToBoolean(model.MucDo_TuVong);
			check_MD_DeDoaTinhMang.Checked = Convert.ToBoolean(model.MucDo_DeDoaTinhMang);
			check_MD_NhapVien.Checked = Convert.ToBoolean(model.MucDo_DeDoaTinhMang);
			check_MD_TanTat.Checked = Convert.ToBoolean(model.MucDo_TanTat);
			check_MD_DiTat.Checked = Convert.ToBoolean(model.MucDo_DiTat);
			check_MD_KhongNghiemTrong.Checked = Convert.ToBoolean(model.MucDo_KhongNghiemTrong);

			check_KQ_TuVongADR.Checked = Convert.ToBoolean(model.KetQua_TuVongDoADR);
			check_KQ_TuVongKLQ.Checked = Convert.ToBoolean(model.KetQua_TuVongKoLienQuan);
			check_KQ_ChuaHoiPhuc.Checked = Convert.ToBoolean(model.KetQua_ChuaPhucHoi);
			check_KQ_DangHoiPhuc.Checked = Convert.ToBoolean(model.KetQua_DangHoiPhuc);
			check_KQ_HoiPhucCoDiChung.Checked = Convert.ToBoolean(model.KetQua_HoiPhucCoDiChung);
			check_KQ_HoiPhucKoDiChung.Checked = Convert.ToBoolean(model.KetQua_HoiPhucKoDiChung);
			check_KQ_KhongRo.Checked = Convert.ToBoolean(model.KetQua_KoRo);

            lblNBC_Name.Text = AddText(model.NguoiBaoCao);
            lblNBC_NgheNghiep.Text = AddText(model.NgheNghiep);
            lblNBC_SDT.Text = AddText(model.SoDienThoai);
            lblNBC_Ngay.Text = AddText(model.NgayBaoCao);
            if (!model.DangBaoCaoLD)
            {
                checkBaoCaoLD.Checked = false;
                checkBCBS.Checked = true;
            }
		}
    }
}
