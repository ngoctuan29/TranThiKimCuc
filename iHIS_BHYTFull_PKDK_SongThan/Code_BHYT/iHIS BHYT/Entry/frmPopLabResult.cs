using System;
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
using DevExpress.XtraReports.UI;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ps.Clinic.ViewPopup;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Diagnostics;
using DirectX.Capture;
using DShowNET;
using System.Runtime.InteropServices;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.API.Native;

namespace Ps.Clinic.Entry
{
    public partial class frmPopLabResult : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty;
        private string serviceCode = string.Empty, patientCode = string.Empty, referenceCode = string.Empty;
        private decimal rowIDRadiologyEntry = 0, patientReceiveID = 0, suggestedID = 0;
        private string employeeCodeDoctor = string.Empty, employeeCodeDoctorCurrently = string.Empty;
        private string shiftWork = string.Empty;
        public frmPopLabResult(string _employeeCode, decimal _rowIDRadiologyEntry, string _serviceName, string _serviceCode, decimal _patientReceiveID, string _patientCode, string _referenceCode, decimal _suggestedID, string _shiftWork)
        {
            InitializeComponent();
            this.Text = "KẾT QUẢ XÉT NGHIỆM: " + _serviceName.ToUpper();
            this.rowIDRadiologyEntry = _rowIDRadiologyEntry;
            this.employeeCode = _employeeCode;
            this.serviceCode = _serviceCode;
            this.patientReceiveID = _patientReceiveID;
            this.patientCode = _patientCode;
            this.referenceCode = _referenceCode;
            this.suggestedID = _suggestedID;
            this.employeeCodeDoctorCurrently = _employeeCode;
            this.shiftWork = _shiftWork;
        }

        private void frmPopLabResult_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceRadiologyEntryInf radEntry = ServiceRadiologyBLL.ObjRadiologyEntry(rowIDRadiologyEntry);
                if (radEntry != null && radEntry.RowID > 0)
                {
                    this.txtContent.RtfText = radEntry.Contents;
                    //this.txtConclusion.RtfText = radEntry.Conclusion;
                    //this.txtProposal.Text = radEntry.Proposal;
                    this.EnableText(true);
                    this.butCancel.Enabled = this.butEdit.Enabled = this.butPrint.Enabled = true;
                    this.butUndo.Enabled = this.butSave.Enabled = this.butCapture.Enabled = false;
                    this.GetImageLabResult();
                    this.employeeCodeDoctor = radEntry.EmployeeCodeDoctor;
                }
                else
                {
                    DataTable tableTemplate = TemplateDescriptionBLL.TableListTemplateForService(this.serviceCode, string.Empty);
                    if (tableTemplate != null && tableTemplate.Rows.Count > 0)
                    {
                        this.txtContent.RtfText = tableTemplate.Rows[0]["Contents"].ToString();
                    }
                    this.butSave.Enabled = this.butCapture.Enabled = true;
                    this.butUndo.Enabled = this.butEdit.Enabled = this.butPrint.Enabled = this.butCancel.Enabled = false;
                }
                this.ribbon.Minimized = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void butCapture_Click(object sender, EventArgs e)
        {
            try
            {
                ViewPopup.frmCapTure frm = new frmCapTure(patientReceiveID, patientCode, "XN", null);
                frm.ShowDialog();
                frm.ShowInTaskbar = false;
                DataSet dsTemp = this.ProcessControlImage(frm.pnListImage);
                frm.pnListImage.Dispose();
                frm.Dispose();
                if (dsTemp.Tables[0].Rows.Count > 0)
                {
                    DataTable dtAccept = dsTemp.Tables[0].Select("Chon=1", "Chon desc").CopyToDataTable();
                    this.f_UpdatePanelImage(dtAccept);
                    dsTemp.Dispose();
                }
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show(" Load form capture fail: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dRadiologyRowID = 0;
                FileStream fstr;
                byte[] imagedata;
                if (this.suggestedID > 0)
                {
                    if (this.pnListImage.Controls.Count >= 0)
                    {
                        var doInsertService = new ServiceRadiologyEntryInf();
                        {
                            doInsertService.ServiceCode = serviceCode;
                            doInsertService.PatientCode = patientCode;
                            doInsertService.ReferenceCode = referenceCode;
                            doInsertService.AppointmentDate = DateTime.Now.Date;
                            doInsertService.AppointmentNote = string.Empty;
                            doInsertService.Contents = txtContent.RtfText;
                            doInsertService.Conclusion = string.Empty;
                            doInsertService.Proposal = string.Empty;
                            doInsertService.PostingDate = Utils.DateTimeServer();
                            doInsertService.PatientReceiveID = patientReceiveID;
                            doInsertService.Done = 1;
                            doInsertService.EmployeeCode = this.employeeCode;
                            doInsertService.SuggestedID = this.suggestedID;
                            doInsertService.EmployeeCodeDoctor = this.employeeCode;
                            doInsertService.ShiftWork = this.shiftWork;
                        };
                        int iresult = ServiceRadiologyBLL.InsRadiologyEntry(doInsertService, ref dRadiologyRowID, "XN");
                        if (iresult > 0 && dRadiologyRowID > 0)
                        {
                            DataSet dsTmp = ProcessControlImage(pnListImage);
                            int iSelectImg = 0;
                            int iCountImage = 0;
                            var strExpr = "Chon = 1";
                            var strSort = " Chon DESC";
                            if (dsTmp != null)
                            {
                                iCountImage = dsTmp.Tables[0].Select(strExpr, strSort).Length;
                                if (iCountImage > 0)
                                {
                                    ServiceRadiologyBLL.DelRadiologyDetailEntry(dRadiologyRowID);
                                    foreach (DataRow r in dsTmp.Tables[0].Select("Control='System.Windows.Forms.CheckBox'"))
                                    {
                                        iSelectImg = int.Parse(r["Chon"].ToString());
                                        if (iSelectImg == 1)
                                        {
                                            fstr = new FileStream(r["Tag"].ToString(), FileMode.Open, FileAccess.Read);
                                            imagedata = new byte[fstr.Length];
                                            fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
                                            fstr.Close();
                                            var doInsertServiceDetail = new ServiceRadiologyDetailEntryInf();
                                            {
                                                doInsertServiceDetail.RadiologyRowID = dRadiologyRowID;
                                                doInsertServiceDetail.Image = imagedata;
                                                doInsertServiceDetail.PostingDate = DateTime.Now.Date;
                                            };
                                            ServiceRadiologyBLL.InsRadiologyDetailEntry(doInsertServiceDetail, 1);
                                        }
                                    }
                                }
                            }
                            XtraMessageBox.Show(" Lưu thành công kết quả xét nghiệm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.EnableText(true);
                            this.butCancel.Enabled = this.butEdit.Enabled = this.butPrint.Enabled = true;
                            this.butUndo.Enabled = this.butSave.Enabled = this.butCapture.Enabled = false;
                        }
                        else
                        {
                            XtraMessageBox.Show(" Lưu kết quả xét nghiệm không thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Hình ảnh trả kết quả xét nghiệm không tồn tại!\t ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Tên & nội dung cận lâm sàng không được để trống !\t ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch {
                XtraMessageBox.Show("Result save fail:" + e.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void EnableText(bool ena)
        {
            this.txtContent.ReadOnly = ena;
            //this.txtConclusion.ReadOnly = this.txtProposal.Properties.ReadOnly = ena;
        }

        private DataSet ProcessControlImage(Panel pnListImg)
        {
            DataSet dsImageTmp = new DataSet();
            try
            {
                dsImageTmp.Tables.Add("tblImage");
                dsImageTmp.Tables[0].Columns.Add("Control", typeof(string));
                dsImageTmp.Tables[0].Columns.Add("Tag", typeof(string));
                dsImageTmp.Tables[0].Columns.Add("Chon", typeof(decimal)).DefaultValue = 0;
                string strTagimage = string.Empty;
                DataRow rowImage;
                int iChonimage = 0;
                foreach (Control ctrl in pnListImg.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    {
                        CheckBox chkImage = (CheckBox)ctrl;
                        iChonimage = chkImage.Checked ? 1 : 0;
                        strTagimage = ctrl.Tag.ToString();
                        rowImage = dsImageTmp.Tables[0].NewRow();
                        rowImage["Control"] = ctrl.GetType().ToString();
                        rowImage["Tag"] = strTagimage;
                        rowImage["Chon"] = iChonimage;
                        dsImageTmp.Tables[0].Rows.Add(rowImage);
                    }

                }
                dsImageTmp.AcceptChanges();
            }
            catch { dsImageTmp = null; }
            return dsImageTmp;
        }

        private void f_UpdatePanelImage(DataTable dtImage)
        {
            try
            {
                this.pnListImage.Controls.Clear();
                int x = 0, y = 0;
                int i_Hinh = 1;
                string afilename = "";
                foreach (DataRow dr in dtImage.Rows)
                {
                    PictureBox b = new PictureBox();
                    afilename = dr["Tag"].ToString();
                    Bitmap bm = new Bitmap(afilename);
                    b.Image = (Bitmap)bm;
                    b.Width = 100;
                    b.Height = 100;
                    CheckBox chk = new CheckBox();
                    chk.ForeColor = Color.Black;
                    chk.Text = "Hình " + i_Hinh.ToString();
                    chk.AutoSize = true;
                    chk.Checked = true;
                    b.SizeMode = PictureBoxSizeMode.StretchImage;
                    b.Location = new System.Drawing.Point(x, y);
                    chk.Location = new Point(x, y + 100);
                    y += b.Height + 20;

                    b.BorderStyle = BorderStyle.Fixed3D;
                    b.Tag = afilename;
                    chk.Tag = b.Tag.ToString();
                    b.Cursor = Cursors.Hand;
                    b.Click += new System.EventHandler(this.pic1_Click);
                    chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                    pnListImage.Controls.Add(b);
                    pnListImage.Controls.Add(chk);
                    i_Hinh += 1;
                }
            }
            catch
            {
                return;
            }
        }

        private void pic1_Click(object sender, System.EventArgs e)
        {
            try
            {
                PictureBox l = (PictureBox)(sender);
                decimal dRowID = Convert.ToDecimal(l.Name.ToString());
                ViewPopup.frmViewImage frm = new frmViewImage(l.Image, this.patientCode, this.patientReceiveID, dRowID, this.rowIDRadiologyEntry);
                frm.ShowDialog();
                l.Image = frm.img;
                if (frm.img == null)
                {
                    this.pnListImage.Controls.RemoveByKey(dRowID.ToString());
                    this.pnListImage.Controls.RemoveByKey("ck" + dRowID.ToString());
                }
            }
            catch
            {
                return;
            }

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)(sender);
            if (c.Checked) c.ForeColor = Color.Red;
            else c.ForeColor = Color.White;
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            this.butSave.Enabled = this.butCapture.Enabled = this.butUndo.Enabled = true;
            this.butEdit.Enabled = false;
            this.EnableText(false);
        }

        private void GetImageLabResult()
        {
            try
            {
                this.pnListImage.Controls.Clear();
                var imageList = ServiceRadiologyBLL.ListRadiologyDetail(this.rowIDRadiologyEntry);
                int x = 0, y = 0;
                int i_H = 1;
                foreach (ServiceRadiologyDetailEntryInf image in imageList)
                {
                    PictureBox l = new PictureBox();
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(image.Image.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    l.Image = (Bitmap)b;
                    l.Width = 100;
                    l.Height = 100;
                    l.Location = new System.Drawing.Point(x, y);
                    l.BorderStyle = BorderStyle.Fixed3D;
                    l.SizeMode = PictureBoxSizeMode.StretchImage;
                    l.Cursor = Cursors.Hand;
                    l.Tag = "db";
                    l.Name = image.RowID.ToString();
                    l.DoubleClick += new System.EventHandler(this.pic1_Click);
                    CheckBox chk = new CheckBox();
                    chk.ForeColor = Color.Red;
                    chk.Text = "Hình " + i_H.ToString();
                    chk.AutoSize = true;
                    chk.Name = "ck" + image.RowID.ToString();
                    //chk.Location = new Point(x, y + 70);
                    //x += l.Width;
                    chk.Location = new Point(x, y + 100);
                    y += l.Height + 20;
                    chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
                    pnListImage.Controls.Add(l);
                    pnListImage.Controls.Add(chk);
                    i_H += 1;
                }
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceCode != string.Empty && patientCode != string.Empty)
                {
                    DataTable dtClinic = new DataTable("ClinicInfo");
                    dtClinic = ClinicInformationBLL.DT_Information(1);
                    DataTable dtResult = new DataTable("Result");
                    dtResult = ServiceRadiologyBLL.DT_ResultRadiology(this.suggestedID, this.patientReceiveID);

                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\XNKetquaTemplate.xml");
                    Reports.rpt_XN_KQTemplate rptShow = new Reports.rpt_XN_KQTemplate();
                    rptShow.Parameters["prRadiologyRowID"].Value = this.suggestedID.ToString();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "KQXetNghiem","Kết quả xét nghiệm");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt thực hiện từ danh sách để in phiếu KQ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            this.butCancel.Enabled = this.butEdit.Enabled = this.butPrint.Enabled = true;
            this.butUndo.Enabled = this.butSave.Enabled = this.butCapture.Enabled = false;
            this.EnableText(true);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.employeeCodeDoctorCurrently == this.employeeCodeDoctor)
                {
                    if (XtraMessageBox.Show(" Bạn thật sự muốn xóa kết quả xét nghiệm này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        Int32 iResult = 0;
                        ServiceRadiologyBLL.DelRadiologyEntry(this.suggestedID, ref iResult);
                        if (iResult == 1)
                        {
                            XtraMessageBox.Show(" Hủy kết quả thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtContent.RtfText = string.Empty;
                            this.pnListImage.Controls.Clear();
                            this.butCancel.Enabled = this.butPrint.Enabled = false;
                        }
                        else if (iResult == -1)
                        {
                            XtraMessageBox.Show(" Kết quả xét nghiệm chưa có! Vui lòng kiểm tra lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show(" Hủy kết quả không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                        return;
                }
                else
                {
                    XtraMessageBox.Show(" Khác bác sĩ đọc kết quả xét nghiệm, không cho phép hủy kết quả! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(" Error delete result laboratory", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}