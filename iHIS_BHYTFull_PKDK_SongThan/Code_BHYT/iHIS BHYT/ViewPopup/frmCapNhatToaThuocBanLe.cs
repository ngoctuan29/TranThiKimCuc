using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.IO;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmCapNhatToaThuocBanLe : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string retailCode = string.Empty, userID = string.Empty;
        public bool isResult = false;
        public string fullname = string.Empty, birthyear = string.Empty, address = string.Empty, diagnosis = string.Empty, numberOfDrugCoal = string.Empty, serialNumber = string.Empty, invoiceNumber = string.Empty;
        public frmCapNhatToaThuocBanLe(string _retailCode, string _userID)
        {
            InitializeComponent();
            this.retailCode = _retailCode;
            this.userID = _userID;
        }

        private void frmCapNhatToaThuocBanLe_Load(object sender, EventArgs e)
        {
            MedicinesRetailInf inf = MedicinesRetailBLL.ObjRetail(this.retailCode);
            if (inf != null && inf.RetailCode != string.Empty)
            {
                this.txtRetailCode.Text = inf.RetailCode;
                this.txtHoten.Text = inf.FullName;
                this.txtNamsinh.Text = inf.Birthyear;
                this.txtDiachi.Text = inf.Address;
                this.txtChandoan.Text = inf.Diagnosis;
                this.txtSothang.Text = inf.NumberOfDrugCoal;
                this.txtSohieu.Text = inf.SerialNumber;
                this.txtSobienlai.Text = inf.InvoiceNumber;
            }
        }

        private void toolbtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtRetailCode.Text.Trim()))
                {
                    XtraMessageBox.Show(" Xin vui lòng nhập họ tên bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtRetailCode.Focus();
                    return;
                }
                else
                {
                    MedicinesRetailInf inf = new MedicinesRetailInf();
                    inf.RetailCode = this.txtRetailCode.Text.Trim();
                    inf.FullName = this.txtHoten.Text.Trim();
                    inf.Birthyear = this.txtNamsinh.Text.Trim();
                    inf.Address = this.txtDiachi.Text.Trim();
                    inf.Diagnosis = this.txtChandoan.Text.Trim();
                    inf.NumberOfDrugCoal = this.txtSothang.Text.Trim();
                    inf.SerialNumber = this.txtSohieu.Text.Trim();
                    inf.InvoiceNumber = this.txtSobienlai.Text.Trim();
                    if (MedicinesRetailBLL.UpdMedicinesRetailInfo(inf) >= 1)
                    {
                        XtraMessageBox.Show(" Cập nhật thông tin bệnh nhân thành công", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isResult = true;
                        this.fullname = inf.FullName;
                        this.birthyear = inf.Birthyear;
                        this.address = inf.Address;
                        this.diagnosis = inf.Diagnosis;
                        this.numberOfDrugCoal = inf.NumberOfDrugCoal;
                        this.serialNumber = inf.SerialNumber;
                        this.invoiceNumber = inf.InvoiceNumber;
                        this.Close();
                    }
                    else
                        isResult = false;
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show(" Lỗi cập nhật thông tin toa thuốc: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isResult = false;
                return;
            }
        }

        private void toolbtUndo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}