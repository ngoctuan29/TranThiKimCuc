using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Xml.Serialization;
using System.Xml;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmTheoDoiSinhTon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sMedicalEmergency = string.Empty;
        private decimal dReceiveID = 0;
        private string spatientCode = string.Empty;
        private string s_userCode = string.Empty;
        private DataTable dtSurviveSign = new DataTable();
        private List<SurviveSignInf> lstSign = new List<SurviveSignInf>();
        public frmTheoDoiSinhTon(string _MedicalEmergency, decimal _ReceiveID, string _patientCode, string _userCode)
        {
            InitializeComponent();
            this.sMedicalEmergency = _MedicalEmergency;
            this.dReceiveID = _ReceiveID;
            this.spatientCode = _patientCode;
            this.s_userCode = _userCode;
        }

        private void frmTheoDoiSinhTon_Load(object sender, EventArgs e)
        {
            try
            {
                GetSurviveSign();
                GetStatistic();
            }
            catch { }
        }

        private void gridView_Sign_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_CreateDate)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_CreateDate, " Chọn ngày theo dõi sinh hiệu.... !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_Pulse)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_Pulse, " Mạch không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_Temperature)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_Temperature, "  Nhiệt độ không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_BloodPressure)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_BloodPressure, "  Huyết áp không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_BloodPressure1)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_BloodPressure1, "  Huyết áp không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_Breath)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_Breath, "  Nhịp thở không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_Weight)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_Weight, "  Vui lòng nhập cân nặng!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Sign_Hight)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sign_Hight, "  Vui lòng nhập chiều cao!");
                }
                if (e.Valid)
                {
                    SurviveSignInf infsur = new SurviveSignInf();
                    if (gridView_Sign.GetRowCellValue(e.RowHandle, "RowID").ToString() != string.Empty)
                        infsur.RowID = Convert.ToDecimal(gridView_Sign.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        infsur.RowID = 0;
                    infsur.PatientCode = spatientCode;
                    infsur.Pulse = gridView_Sign.GetRowCellValue(e.RowHandle, "Pulse").ToString();
                    infsur.Temperature = gridView_Sign.GetRowCellValue(e.RowHandle, "Temperature").ToString();
                    infsur.BloodPressure = gridView_Sign.GetRowCellValue(e.RowHandle, "BloodPressure").ToString();
                    infsur.BloodPressure1 = gridView_Sign.GetRowCellValue(e.RowHandle, "BloodPressure1").ToString();
                    infsur.Weight = gridView_Sign.GetRowCellValue(e.RowHandle, "Weight").ToString();
                    infsur.Hight = gridView_Sign.GetRowCellValue(e.RowHandle, "Hight").ToString();
                    infsur.Breath = gridView_Sign.GetRowCellValue(e.RowHandle, "Breath").ToString();
                    infsur.EmployeeCode = s_userCode;
                    infsur.RefID = dReceiveID;
                    infsur.ReferenceCode = sMedicalEmergency;
                    infsur.CreateDate = Convert.ToDateTime(gridView_Sign.GetRowCellValue(e.RowHandle, "CreateDate").ToString());
                    SurviveSignBLL.InsSurviveSign(infsur);
                    //if (e.RowHandle < 0)
                    //{
                    //    SurviveSignBLL.InsSurviveSign(infsur);
                    //}
                    GetSurviveSign();
                    GetStatistic();
                }
            }
            catch (Exception) { }
        }

        private void GetSurviveSign()
        {
            this.dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(sMedicalEmergency);
            this.gridControl_Sign.DataSource = this.dtSurviveSign;
        }

        private void GetStatistic()
        {
            try
            {
                lstSign = SurviveSignBLL.ListSurviveSignForRefID(dReceiveID);
                chartControl1.Series.Clear();
                Series series1 = new Series("Mạch", ViewType.SwiftPlot);
                Series series2 = new Series("Nhiệt độ", ViewType.SwiftPlot);
                Series series3 = new Series("Huyết áp", ViewType.SwiftPlot);
                Series series4 = new Series("Nặng", ViewType.SwiftPlot);
                Series series5 = new Series("Cao", ViewType.SwiftPlot);
                Series series6 = new Series("Nhịp thở", ViewType.SwiftPlot);
                string sDate = string.Empty;
                foreach (var v in lstSign)
                {
                    sDate = v.CreateDate.ToString("dd/MM HH:mm");
                    if (v.Pulse.Trim() != string.Empty)
                        series1.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Pulse) }));
                    else
                        series1.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Temperature.Trim() != string.Empty)
                        series2.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Temperature) }));
                    else
                        series2.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.BloodPressure.Trim() != string.Empty)
                        series3.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.BloodPressure) }));
                    else
                        series3.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Weight.Trim() != string.Empty)
                        series4.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Weight) }));
                    else
                        series4.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Hight.Trim() != string.Empty)
                        series5.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Hight) }));
                    else
                        series5.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Breath.Trim() != string.Empty)
                        series6.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Breath) }));
                    else
                        series6.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                }
                chartControl1.Series.Add(series1);
                chartControl1.Series.Add(series2);
                chartControl1.Series.Add(series3);
                chartControl1.Series.Add(series4);
                chartControl1.Series.Add(series5);
                chartControl1.Series.Add(series6);
                chartControl1.Legend.Visible = true;
            }
            catch { }
        }

        private void rep_CreateDate_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}