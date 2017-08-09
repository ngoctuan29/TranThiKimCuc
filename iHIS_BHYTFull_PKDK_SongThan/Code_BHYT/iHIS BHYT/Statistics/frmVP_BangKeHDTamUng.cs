using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmVP_BangKeHDTamUng : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataSet dsResult = new DataSet();
        private string userID = string.Empty;
        private DateTime dtWorking = new DateTime();
        public frmVP_BangKeHDTamUng(string _userID, DateTime _dtWorking)
        {
            InitializeComponent();
            this.userID = _userID;
            this.dtWorking = _dtWorking;
        }
        private void frmVP_BangKeHDTamUng_Load(object sender, EventArgs e)
        {
            try
            {
                this.chkList_Employee.DataSource = EmployeeBLL.ListEmployeeForPosition("4");
                this.chkList_Employee.DisplayMember = "EmployeeName";
                this.chkList_Employee.ValueMember = "EmployeeCode";
                this.repLKEmployeeOrder.DataSource = EmployeeBLL.ListEmployee("");
                this.repLKEmployeeRePaid.DataSource = EmployeeBLL.ListEmployee("");
                this.chkList_Object.DataSource = ObjectBLL.ListObject(0).Where(o => o.ObjectCode != 5).ToList();
                this.chkList_Object.DisplayMember = "ObjectName";
                this.chkList_Object.ValueMember = "ObjectCode";

                this.datePrint.EditValue = Utils.DateServer();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                //this.gridView_Data.Columns.Clear();
                List<Fee_Advance_PaymentView> list_Fee = new List<Fee_Advance_PaymentView>();
                
                string employeeCode = string.Empty;
                foreach (EmployeeInf inf in this.chkList_Employee.CheckedItems)
                {
                    employeeCode += "'" + inf.EmployeeCode + "',";
                }
                string objectCode = string.Empty;
                foreach (ObjectInf inf in this.chkList_Object.CheckedItems)
                {
                    objectCode += inf.ObjectCode + ",";
                }
                list_Fee = Fee_Advance_PaymentBLL.Report_Fee_Advance_Payment(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, employeeCode, objectCode);

             if(list_Fee.Count>0)
                {
                    this.gridControl_Data.DataSource = list_Fee; 
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void butExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dsResult != null && this.dsResult.Tables.Count > 0)
                {
                    this.gridView_Data.ShowPrintPreview();
                    //this.butExcel.Enabled = false;
                    //if (!System.IO.Directory.Exists("..//..//ExportToExcel"))
                    //{
                    //    System.IO.Directory.CreateDirectory("..//..//ExportToExcel");
                    //}
                    //string pathExcel = Application.ExecutablePath;
                    //pathExcel = pathExcel.Substring(0, pathExcel.LastIndexOf("\\"));
                    //pathExcel = pathExcel.Substring(0, pathExcel.LastIndexOf("\\"));
                    //pathExcel = pathExcel.Substring(0, pathExcel.LastIndexOf("\\"));
                    //pathExcel = pathExcel.Replace("\\", "//");
                    //pathExcel += "//ExportToExcel//vp_baocaotamung";
                    //string title = "BÁO CÁO THU TẠM ỨNG";
                    //DataSet dsForm = new DataSet();
                    ////if (this.rdBienLai.Checked)
                    ////    dsForm = this.CreateTemplateForInvoice();
                    ////else
                    //if (this.rdTheoNgay.Checked)
                    //    dsForm = this.CreateTemplateForDate();
                    //else if (this.rdNhanVien.Checked)
                    //    dsForm = this.CreateTemplateForUser();
                    //this.Export_Excel(this.dsResult, dsForm, this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, pathExcel, title);
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.butExcel.Enabled = true;
            }
        }
        private DataSet CreateTemplateForInvoice()
        {
            DataSet dsForm = new DataSet();
            dsForm.Tables.Add("Tables");
            dsForm.Tables[0].Columns.Add("ID");
            dsForm.Tables[0].Columns.Add("Names");
            dsForm.Tables[0].Rows.Add(new string[] { "PatientCode", "Mã BN" });
            dsForm.Tables[0].Rows.Add(new string[] { "PatientName", "Họ và tên" });
            dsForm.Tables[0].Rows.Add(new string[] { "PatientGenderName", "Giới tính" });
            dsForm.Tables[0].Rows.Add(new string[] { "PatientBirthyear", "Năm sinh" });
            dsForm.Tables[0].Rows.Add(new string[] { "ReceiptNumber", "Số biên lai" });
            dsForm.Tables[0].Rows.Add(new string[] { "NoteBookName", "Quyển sổ" });
            dsForm.Tables[0].Rows.Add(new string[] { "EmployeeName", "Nhân viên thu" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountReal", "Số tiền" });
            dsForm.Tables[0].Rows.Add(new string[] { "WorkingDate", "Ngày thu" });
            dsForm.Tables[0].Rows.Add(new string[] { "WorkingTime", "Giờ thu" });
            dsForm.Tables[0].Rows.Add(new string[] { "EmployeeNameRepaid", "Nhân viên hoàn" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountRepaidReal", "Số tiền hoàn" });
            dsForm.Tables[0].Rows.Add(new string[] { "WorkingDateRePaid", "Ngày hoàn" });
            return dsForm;
        }
        private DataSet CreateTemplateForDate()
        {
            DataSet dsForm = new DataSet();
            dsForm.Tables.Add("Tables");
            dsForm.Tables[0].Columns.Add("ID");
            dsForm.Tables[0].Columns.Add("Names");
            dsForm.Tables[0].Rows.Add(new string[] { "WorkingDate", "Ngày thu" });
            dsForm.Tables[0].Rows.Add(new string[] { "TotalInvoice", "Tổng số HĐ" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountTotal", "Tổng tiền" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountBHYT", "T.Tiền BHYT" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountThuPhi", "T.Tiền Thu phí" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountMien", "T.Tiền miễn" });
            return dsForm;
        }
        private DataSet CreateTemplateForUser()
        {
            DataSet dsForm = new DataSet();
            dsForm.Tables.Add("Tables");
            dsForm.Tables[0].Columns.Add("ID");
            dsForm.Tables[0].Columns.Add("Names");
            dsForm.Tables[0].Rows.Add(new string[] { "EmployeeName", "Nhân viên thu" });
            dsForm.Tables[0].Rows.Add(new string[] { "TotalInvoice", "Tổng số HĐ" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountTotal", "Tổng tiền" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountBHYT", "T.Tiền BHYT" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountThuPhi", "T.Tiền Thu phí" });
            dsForm.Tables[0].Rows.Add(new string[] { "AmountMien", "T.Tiền miễn" });
            return dsForm;
        }
        public void Export_Excel(DataSet dsData, DataSet dsDesign, string fromdate, string todate, string filePath, string title)
        {
            filePath = filePath + ".xls";
            try
            {
                string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
                Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);

                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8);
                string astr = string.Empty;
                astr = "<Table border=0>";
                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + ssoyte;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + names;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=40 align=center style=\"font-family: Arial; font-size: 14pt; font-weight: bold\" colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + title;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "(Từ ngày" + " " + fromdate + " Đến ngày " + todate + ")";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "</Table>";
                sw.Write(astr);

                astr = "<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal\">";
                astr = astr + "<tr>";
                for (int i = 0; i < dsDesign.Tables[0].Rows.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + dsDesign.Tables[0].Rows[i]["Names"].ToString();
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                //Dong so thu tu
                astr = astr + "<tr>";
                for (int i = 0; i < dsDesign.Tables[0].Rows.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + (i + 1).ToString();
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);

                string at = string.Empty;
                for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < dsDesign.Tables[0].Rows.Count; j++)
                    {
                        for (int k = 0; k < dsData.Tables[0].Columns.Count; k++)
                        {
                            if (dsData.Tables[0].Columns[k].ColumnName.ToUpper() == dsDesign.Tables[0].Rows[j]["ID"].ToString().ToUpper())
                            {
                                if (dsData.Tables[0].Columns[k].DataType.ToString() == "System.Decimal")
                                {
                                    try
                                    {
                                        at = decimal.Parse(dsData.Tables[0].Rows[i][k].ToString()).ToString("###,###,##0.##");
                                    }
                                    catch
                                    {
                                        at = string.Empty;
                                    }
                                    if (at == "0")
                                    {
                                        at = string.Empty;
                                    }
                                    if (i == dsData.Tables[0].Rows.Count - 1)
                                    {
                                        astr = astr + "<td align=right style=\"font-family: Arial; font-size: 9pt; font-weight: bold\">";
                                    }
                                    else
                                    {
                                        astr = astr + "<td align=right>";
                                    }
                                    astr = astr + at;
                                    astr = astr + "</td>";
                                }
                                else
                                {
                                    if (i == dsData.Tables[0].Rows.Count - 1)
                                    {
                                        astr = astr + "<td align=left style=\"font-family: Arial; font-size: 9pt; font-weight: bold\">";
                                    }
                                    else
                                    {
                                        astr = astr + "<td align=left>";
                                    }
                                    string atmp = string.Empty;
                                    if ((dsData.Tables[0].Columns[k].ColumnName.ToUpper() == "PatientCode") && (i != dsData.Tables[0].Rows.Count - 1))
                                    {
                                        atmp = "'";//(i+1).ToString()+" - ";
                                    }
                                    astr = astr + atmp + dsData.Tables[0].Rows[i][k].ToString();
                                    astr = astr + "</td>";
                                }
                                //break;
                            }
                        }
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }

                astr = "</table>";
                sw.Write(astr);

                astr = "<table boder=0>";
                astr = astr + "<tr>";
                astr = astr + "<th align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "Ngày " + this.datePrint.Text.Substring(0, 2) + " tháng " + this.datePrint.Text.Substring(3, 2) + " " + "năm " + this.datePrint.Text.Substring(6);
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + dsDesign.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + ""; //User print
                astr = astr + "</th>";
                astr = astr + "</tr>";
                astr = astr + "</Table>";
                sw.Write(astr);
                sw.Close();
                System.Diagnostics.Process.Start(filePath);
                this.butExcel.Enabled = true;
            }
            catch
            {
                throw new Exception();
            }
        }
       
    }
}