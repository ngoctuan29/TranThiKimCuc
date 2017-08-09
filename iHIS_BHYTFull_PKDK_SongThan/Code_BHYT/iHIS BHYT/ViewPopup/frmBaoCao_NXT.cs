using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_NXT : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCao_NXT()
        {
            InitializeComponent();
            txtFromDate.EditValue = DateTime.Now.Date;
            txtToDate.EditValue = DateTime.Now.Date;
        }

        public static string SQLTODATE(string sDate, int IsToDate)
        {
            if (sDate == "") return " CAST(NULL AS DATETIME) ";
            if (IsToDate == 1)
                return string.Format("'{0}'", Convert.ToDateTime(sDate).Date.ToString(("yyyy-MM-dd")));
            else
                return string.Format("'{0}'", Convert.ToDateTime(sDate).Date.ToString(("yyyy-MM-dd")));
        }

        private void butCount_Click(object sender, EventArgs e)
        {
            string sql = "SELECT T.[Item Code],T.[Item Name], T.[Unit Of Measure Name], CAST(ROUND(sum(DauKi),0) AS DECIMAL(18,0))  DauKi,CAST(ROUND(sum(Nhap),0) AS DECIMAL(18,0)) Nhap ,CAST(ROUND(sum(Xuat),0) AS DECIMAL(18,0)) Xuat from ";
            sql += " (";
            sql += " SELECT A.[Item Code],B.[Item Name], C.[Unit Of Measure Name],sum([Quantity]) as DauKi,0 Nhap ,0 Xuat FROM [Value Entry] A WITH (NOLOCK) ";
            sql += " INNER JOIN Items B ON A.[Item Code] = B.[Item Code] ";
            sql += " INNER JOIN [Unit Of Measure] C ON B.[Unit Of Measure Code] = C.[Unit Of Measure Code] ";
            sql += " WHERE A.[Posting Date] < " + SQLTODATE(txtFromDate.EditValue.ToString(), 0);
            sql += " GROUP BY A.[Item Code],B.[Item Name],C.[Unit Of Measure Name]";
            sql += " UNION ";
            sql += " SELECT A.[Item Code],B.[Item Name], C.[Unit Of Measure Name], 0 as DauKi,sum([Quantity]) Nhap ,0 Xuat FROM [Value Entry] A WITH (NOLOCK) ";
            sql += " INNER JOIN Items B ON A.[Item Code] = B.[Item Code] ";
            sql += " INNER JOIN [Unit Of Measure] C ON B.[Unit Of Measure Code] = C.[Unit Of Measure Code] ";
            sql += " WHERE A.[Posting Date] BETWEEN " + SQLTODATE(txtFromDate.EditValue.ToString(), 0) + " and " + SQLTODATE(txtToDate.EditValue.ToString(), 1);
            sql += " AND A.[Quantity] > 0";
            sql += " GROUP BY A.[Item Code],B.[Item Name],C.[Unit Of Measure Name] ";

            sql += " UNION ";
            sql += " SELECT A.[Item Code],B.[Item Name], C.[Unit Of Measure Name], 0 as DauKi,0 Nhap ,-sum([Quantity]) Xuat FROM [Value Entry] A WITH (NOLOCK) ";
            sql += " INNER JOIN Items B ON A.[Item Code] = B.[Item Code] ";
            sql += " INNER JOIN [Unit Of Measure] C ON B.[Unit Of Measure Code] = C.[Unit Of Measure Code] ";
            sql += " WHERE A.[Posting Date] BETWEEN " + SQLTODATE(txtFromDate.EditValue.ToString(), 0) + " and " + SQLTODATE(txtToDate.EditValue.ToString(), 1);
            sql += " AND A.[Quantity] < 0";
            sql += " GROUP BY A.[Item Code],B.[Item Name],C.[Unit Of Measure Name] ";

            sql += " ) as T";
            sql += " GROUP BY T.[Item Code],T.[Item Name],T.[Unit Of Measure Name] ORDER BY T.[Item Name]";

            //gridControl_Result.DataSource = dao.get_Data(sql).Tables[0];
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }
    }
}