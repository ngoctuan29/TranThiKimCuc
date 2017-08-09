using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using Ps.Clinic.Reports;
using DevExpress.XtraRichEdit;
using System.IO;
using System.Net.Mail;
using ClinicLibrary;
using System.Net;

namespace Ps.Clinic.ADR_SST
{
	public partial class frmPatientDetail : DevExpress.XtraEditors.XtraForm
	{
		private DataTable dtReport = new DataTable();
		private ADR_BenhNhanInf model = new ADR_BenhNhanInf();
        private string path = string.Empty;
        public int getIdBn { get; set; }
		public frmPatientDetail()
		{
			InitializeComponent();
		}
		private void loadData()
		{
			model = patientDetail(getIdBn);
			GC_PatientDetail.DataSource = ADRBLL.GetListThuoc(getIdBn);

			lbcTenDonVi.Text = model.TenDonVi;
			lbcMaSoBaoCaoCuaDonVi.Text = model.MaSoBaoCaoCuaDonVi;
			lbcName.Text = model.HoTen;
			lbcDob.Text = model.NgaySinh;
			lbcWeight.Text = model.CanNang;

			txtDateApear.Text = model.NgayXuatHienPhanUng;
			txtBaoLau.Text = model.PhanUngXuatHienSau;

			memoBieuHien.Text = model.MoTaBieuHien;
			memoCachXuLi.Text = model.CachXuTri;
			memoTienSu.Text = model.TienSu;
			memoXetNghiemPg.Text = model.CacXetNghiemLienQuan;

			if(model.GioiTinh.ToLower().Equals("nam"))
			{
				checkNam.Checked = true;
				checkNu.Checked = false;
			}
			checkTuVong.Checked = Convert.ToBoolean(model.MucDo_TuVong);
			checkDeDoaTinhMang.Checked = Convert.ToBoolean(model.MucDo_DeDoaTinhMang);
			checkNhapVienKeoDai.Checked = Convert.ToBoolean(model.MucDo_DeDoaTinhMang);
			checkTanTat.Checked = Convert.ToBoolean(model.MucDo_TanTat);
			checkDiTat.Checked = Convert.ToBoolean(model.MucDo_DiTat);
			checkKhongNghiemTrong.Checked = Convert.ToBoolean(model.MucDo_KhongNghiemTrong);

			checkTuVongADR.Checked = Convert.ToBoolean(model.KetQua_TuVongDoADR);
			checkTuVongKlq.Checked = Convert.ToBoolean(model.KetQua_TuVongKoLienQuan);
			checkChuaPhucHoi.Checked = Convert.ToBoolean(model.KetQua_ChuaPhucHoi);
			checkDangPhucHoi.Checked = Convert.ToBoolean(model.KetQua_DangHoiPhuc);
			checkHoiPhucCoDiChung.Checked = Convert.ToBoolean(model.KetQua_HoiPhucCoDiChung);
			checkHoiPhucKoCoDiChung.Checked = Convert.ToBoolean(model.KetQua_HoiPhucKoDiChung);
			checkKhongRo.Checked = Convert.ToBoolean(model.KetQua_KoRo);


        }
		private ADR_BenhNhanInf setDataSave()
		{
			model.HoTen = lbcName.Text;
			model.NgaySinh = lbcDob.Text;
			model.CanNang = lbcWeight.Text;

			model.NgayXuatHienPhanUng = txtDateApear.Text;
			model.PhanUngXuatHienSau = txtBaoLau.Text;

			model.MoTaBieuHien = memoBieuHien.Text;
			model.CachXuTri = memoCachXuLi.Text;
			model.TienSu = memoTienSu.Text;
			model.CacXetNghiemLienQuan = memoXetNghiemPg.Text;

			model.GioiTinh = checkNam.Checked ? "Nam" : "Nữ";
			model.MucDo_TuVong = checkTuVong.Checked;
			model.MucDo_DeDoaTinhMang = checkDeDoaTinhMang.Checked;
			model.MucDo_NhapVien = checkNhapVienKeoDai.Checked;
			model.MucDo_TanTat = checkTanTat.Checked ;
			model.MucDo_DiTat = checkDiTat.Checked;
			model.MucDo_KhongNghiemTrong = checkKhongNghiemTrong.Checked;

			model.KetQua_TuVongDoADR = checkTuVongADR.Checked;
			model.KetQua_TuVongKoLienQuan = checkTuVongKlq.Checked;
			model.KetQua_ChuaPhucHoi = checkChuaPhucHoi.Checked;
			model.KetQua_DangHoiPhuc = checkDangPhucHoi.Checked;
			model.KetQua_HoiPhucCoDiChung = checkHoiPhucCoDiChung.Checked;
			model.KetQua_HoiPhucKoDiChung = checkHoiPhucKoCoDiChung.Checked;
			model.KetQua_KoRo = checkKhongRo.Checked;

			return model;
		}
		private void frm_PatientDetail_Load(object sender, EventArgs e)
		{
            this.path = Utils.CurrentPathApplication();
			this.loadData();
		}
		private ADR_BenhNhanInf patientDetail(int idBn)
		{
			DataTable dt = ADRBLL.getBenhNhan(idBn);
            ADR_BenhNhanInf bn = new ADR_BenhNhanInf();
			foreach(DataRow dr in dt.Rows)
			{
				bn.Id = idBn;
				bn.GioiTinh = dr["GioiTinh"].ToString().Trim();
				bn.HoTen = dr["HoTen"].ToString().Trim();
				bn.NgaySinh = dr["NgaySinh"].ToString().Trim();
				bn.CanNang = dr["CanNang"].ToString().Trim();
				bn.NgayXuatHienPhanUng = dr["NgayXuatHienPhanUng"].ToString().Trim();
				bn.PhanUngXuatHienSau = dr["PhanUngXuatHienSau"].ToString().Trim();
				bn.MoTaBieuHien = dr["MoTaBieuHien"].ToString().Trim();
				bn.CacXetNghiemLienQuan = dr["CacXetNghiemLienQuan"].ToString().Trim();
				bn.TienSu = dr["TienSu"].ToString().Trim();
				bn.CachXuTri = dr["CachXuTri"].ToString().Trim();

				bn.MucDo_TuVong = Convert.ToBoolean(dr["MucDo_TuVong"].ToString().Trim());
				bn.MucDo_TanTat = Convert.ToBoolean(dr["MucDo_TanTat"].ToString().Trim());
				bn.MucDo_NhapVien = Convert.ToBoolean(dr["MucDo_NhapVien"].ToString().Trim());
				bn.MucDo_KhongNghiemTrong = Convert.ToBoolean(dr["MucDo_KhongNghiemTrong"].ToString().Trim());
				bn.MucDo_DeDoaTinhMang = Convert.ToBoolean(dr["MucDo_DeDoaTinhMang"].ToString().Trim());
				bn.MucDo_DiTat = Convert.ToBoolean(dr["MucDo_DiTat"].ToString().Trim());

				bn.KetQua_ChuaPhucHoi = Convert.ToBoolean(dr["KetQua_ChuaPhucHoi"].ToString().Trim());
				bn.KetQua_DangHoiPhuc = Convert.ToBoolean(dr["KetQua_DangHoiPhuc"].ToString().Trim());
				bn.KetQua_HoiPhucCoDiChung = Convert.ToBoolean(dr["KetQua_HoiPhucCoDiChung"].ToString().Trim());
				bn.KetQua_HoiPhucKoDiChung = Convert.ToBoolean(dr["KetQua_HoiPhucKoDiChung"].ToString().Trim());
				bn.KetQua_KoRo = Convert.ToBoolean(dr["KetQua_KoRo"].ToString().Trim());
				bn.KetQua_TuVongDoADR = Convert.ToBoolean(dr["KetQua_TuVongDoADR"].ToString().Trim());
				bn.KetQua_TuVongKoLienQuan = Convert.ToBoolean(dr["KetQua_TuVongKoLienQuan"].ToString().Trim());

				bn.TenDonVi = dr["NoiBaoCao"].ToString().Trim();
                bn.MaSoBaoCao = txtMaSoBaoCao.Text;
                bn.MaSoBaoCaoCuaDonVi = dr["MaSoBaoCao"].ToString().Trim();

                bn.NgayBaoCao = Convert.ToDateTime(dr["NgayBaoCao"]).ToString("dd/MM/yyyy").Trim();
                bn.NguoiBaoCao = dr["NguoiBaoCao"].ToString().Trim();
                bn.NgheNghiep = dr["NgheNghiep"].ToString().Trim();
                bn.SoDienThoai = dr["SoDienThoai"].ToString().Trim();
                if (!dr["DangBaoCao"].ToString().Trim().Equals("Lần đầu"))
                {
                    bn.DangBaoCaoLD = false;
                }
                else { bn.DangBaoCaoLD = true; }
            }
			return bn;
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			setDataSave();
			DialogResult choose = MessageBox.Show("Bạn muốn lưu dữ liệu thay đổi?", "iHIS - Bệnh viện điện tử", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if(choose == DialogResult.Yes)
			{
				if(ADRBLL.Update_BenhNhan(model).Equals(1))
				{
					MessageBox.Show("Đã lưu thành công!", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void checkNu_CheckedChanged(object sender, EventArgs e)
		{
			if(checkNu.Checked)
			{
				checkNam.Checked = false;
			}
			else
			{
				checkNam.Checked = true;
			}
		}

		private void checkNam_CheckedChanged(object sender, EventArgs e)
		{
			if(checkNam.Checked)
			{
				checkNu.Checked = false;
			}
			else
			{
				checkNu.Checked = true;
			}
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
            loadData();
            dtReport = ADRBLL.GetListThuoc(getIdBn);

            DataSet dsTemp = new DataSet("table");
            this.dtReport.TableName = "tableThuoc";
            dsTemp.Merge(this.dtReport);
            dsTemp.WriteXml(this.path + @"\\Xml\\rptADR_PhanUngCoHaiCuaThuoc.xml");
            rptADR_PhanUngCoHaiCuaThuoc rpt = new rptADR_PhanUngCoHaiCuaThuoc(model);
            rpt.DataSource = dsTemp;
            this.ExportToDOC(DocumentFormat.OpenXml, rpt, "Báo cáo bệnh nhân ADR");
        }
        
        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
                frmEntryEmail frm = new frmEntryEmail("ReportADR.doc");
                frm.ShowDialog();
                if(frm.DialogResult == DialogResult.OK)
                {
                    //thông tin
                    dtReport = ADRBLL.GetListThuoc(getIdBn);
                    DataSet dsTemp = new DataSet("table");
                    this.dtReport.TableName = "tableThuoc";
                    dsTemp.Merge(this.dtReport);
                    dsTemp.WriteXml(this.path + @"\\Xml\\rptADR_PhanUngCoHaiCuaThuoc.xml");
                    rptADR_PhanUngCoHaiCuaThuoc rpt = new rptADR_PhanUngCoHaiCuaThuoc(model);
                    rpt.DataSource = dsTemp;
                    if (File.Exists(Application.StartupPath + "\\ReportADR.doc"))
                    {
                        File.Delete(Application.StartupPath + "\\ReportADR.doc");
                    }
                    using (RichEditDocumentServer docServer = new RichEditDocumentServer())
                    {
                        rpt.ExportToRtf("file.rtf");
                        docServer.LoadDocument("file.rtf", DocumentFormat.Rtf);
                        docServer.SaveDocument(Application.StartupPath + "\\ReportADR.doc", DocumentFormat.OpenXml);
                    }
                    File.Delete("file.rtf");

                    string SMTP = STM(frm.stm);
                    string fromEmail = frm.EmailFrom + frm.stm;
                    if (!IsValid(fromEmail))
                    {
                        XtraMessageBox.Show(@"Định dạng Email người gửi không đúng!\nNhập tài khoản rồi chọn loại Email đúng.", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!IsValid(frm.Emailto))
                    {
                        XtraMessageBox.Show("Định dạng Email người nhận không đúng!\nVD: example@gmail.com, example@yahoo.com ., ", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(fromEmail);
                        mail.To.Add(frm.Emailto);
                        mail.Subject = frm.Title;
                        mail.Body = string.Empty;
                        mail.IsBodyHtml = true;
                        try
                        {
                            mail.Attachments.Add(new Attachment(Application.StartupPath + "\\ReportADR.doc"));
                        }
                        catch
                        {
                            XtraMessageBox.Show("Lỗi File hoặc đường dẫn ", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        try
                        {
                            using (SmtpClient smtp = new SmtpClient(SMTP, 587))
                            {
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new NetworkCredential(fromEmail, frm.Password);
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                            }
                            XtraMessageBox.Show("Đã gửi mail thành công!", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            XtraMessageBox.Show("Tài khoản hoặc mật khẩu Email không đúng!\nHoặc Email chưa cung cấp quyền truy cập cho ứng dụng. \n ", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "Error sending a report \n" + ex.Message);
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private string STM(string stm)
        {
            string result = string.Empty;
            switch (stm)
            {
                case "@gmail.com":
                    result = "smtp.gmail.com";
                    break;
                case "@yahoo.com":
                    result = "smtp.mail.yahoo.com";
                    break;
                case "@hotmail.com":
                    result = "smtp.live.com";
                    break;
            }
            return result;
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