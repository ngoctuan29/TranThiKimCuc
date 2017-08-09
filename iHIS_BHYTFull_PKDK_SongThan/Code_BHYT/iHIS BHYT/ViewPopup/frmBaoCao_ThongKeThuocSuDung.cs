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
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_ThongKeThuocSuDung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int MM = 1;
        public frmBaoCao_ThongKeThuocSuDung()
        {
            InitializeComponent();
            MM = DateTime.Now.Date.Month;
        }

        private void frmBaoCao_ThongKeThuocSuDung_Load(object sender, EventArgs e)
        {
            txtFrom.EditValue = GetFirstDayOfMonth(this.MM);
            txtTo.EditValue = GetLastDayOfMonth(this.MM);

        }
        public static DateTime GetFirstDayOfMonth(int _MM)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, _MM, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(int _MM)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, _MM, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }

        private void butPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl_result.ShowPrintPreview();
        }

        private void butReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty)
                {
                    DataTable dtResult = MedicinesForPatientsBLL.DT_StatisticMedicinesForPatients(Convert.ToDateTime(txtFrom.EditValue), Convert.ToDateTime(txtTo.EditValue));
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        gridControl_result.DataSource = dtResult;
                    }
                    else
                    {
                        XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
                else
                {
                    DataTable dtResult = MedicinesForPatientsBLL.DT_StatisticMedicinesForPatients(DateTime.Now.Date, DateTime.Now.Date);
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        gridControl_result.DataSource = dtResult;
                    }
                    else
                    {
                        XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {

        }
    }
}