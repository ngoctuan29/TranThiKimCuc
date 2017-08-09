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
using DevExpress.XtraCharts;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmChartCDHA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String sGroup = string.Empty;
        private String sCate = string.Empty;
        private String sDoctor = string.Empty;
        private List<view_DoctorAppointedInf> lst = new List<view_DoctorAppointedInf>();
        private List<view_DoctorAppointedInf> lstprint = new List<view_DoctorAppointedInf>();
        public frmChartCDHA()
        {
            InitializeComponent();
        }

        private void frmChartCDHA_Load(object sender, EventArgs e)
        {
            try
            {
                chkList_Doctor.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
                chkList_Doctor.DisplayMember = "EmployeeName";
                chkList_Doctor.ValueMember = "EmployeeCode";

                List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup("").FindAll(x => x.ServiceModuleCode != "THUOC");
                lkupNhomDV.Properties.DataSource = lstGroup;
                lkupNhomDV.Properties.ValueMember = "ServiceGroupCode";
                lkupNhomDV.Properties.DisplayMember = "ServiceGroupName";

                var listDepart = (from p in DepartmentBLL.ListDepartment("") where p.Hide == 0 select new { p.DepartmentCode, p.DepartmentName }).ToList();
                cbDepartment.Properties.DataSource = listDepart;
                cbDepartment.Properties.DisplayMember = "DepartmentName";
                cbDepartment.Properties.ValueMember = "DepartmentCode";

                lkPatientType.Properties.DataSource = PatientsBLL.DT_PatientType();
                lkPatientType.Properties.DisplayMember = "TypeName";
                lkPatientType.Properties.ValueMember = "RowID";
            }
            catch { }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                List<view_DoctorAppointedInf> lstGroup = new List<view_DoctorAppointedInf>();
                DataTable dtChart = new DataTable();
                dtChart.Columns.Add("ServiceGroupName", typeof(string));
                dtChart.Columns.Add("Quantity", typeof(Int32));
                sCate = string.Empty;
                sDoctor = string.Empty;
                foreach (ServiceCategoryInf inf in chkList_Category.CheckedItems)
                {
                    sCate += "'" + inf.ServiceCategoryCode + "',";
                }
                foreach (EmployeeViewInf inf in chkList_Doctor.CheckedItems)
                {
                    sDoctor += "'" + inf.EmployeeCode + "',";
                }
                string sDepartment = cbDepartment.EditValue.ToString();
                string[] arrKp;
                if (sDepartment.Length > 0)
                    arrKp = sDepartment.Split(',');
                else
                    arrKp = null;
                if (arrKp != null)
                {
                    sDepartment = string.Empty;
                    for (Int32 i = 0; i < arrKp.Length; i++)
                    {
                        sDepartment += "'" + arrKp[i].ToString().Trim() + "',";
                    }
                }
                if (sGroup == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn nhóm dịch vụ.", "Bệnh viện điện tử .NET");
                    return;
                }
                lst = rpt_Medicines_BLL.View_BSChiDinh(sDoctor.TrimEnd(','), dllNgay.tungay.Text, dllNgay.denngay.Text, "", sDepartment.TrimEnd(','), sCate.TrimEnd(','), sGroup.TrimEnd(','), Convert.ToInt32(lkPatientType.EditValue), "", -1, 0, string.Empty);
                if (lst != null && lst.Count > 0)
                {
                    if (sGroup == string.Empty)
                    {
                        sGroup = "'" + lkupNhomDV.EditValue.ToString() + "'";
                    }
                    List<ServiceCategoryInf> lsrCate = new List<ServiceCategoryInf>();
                    lsrCate = ServiceCategoryBLL.rptListServiceCategory(sGroup.TrimEnd(','), sCate.TrimEnd(','));
                    Int32 iCount = 0;
                    foreach (ServiceCategoryInf cate in lsrCate)
                    {
                        iCount = lst.FindAll(x => x.ServiceCategoryName == cate.ServiceCategoryName).Count;
                        dtChart.Rows.Add(cate.ServiceCategoryName, iCount);
                    }
                    if (sGroup == "'XN'")
                        GetDoughnutChart(dtChart);
                    else
                        GetPieChart(dtChart);
                    gridControl_Result.DataSource = lst;
                    gridView_Result.Columns["ServiceGroupName"].Group();
                    gridView_Result.Columns["ServiceCategoryName"].Group();
                    gridView_Result.ExpandAllGroups();
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch
            {
                return;
            }
        }
               
        private void GetPieChart(DataTable dttemp)
        {
            try
            {
                ChartControl PieChart3D = new ChartControl();
                Legend legend = PieChart3D.Legend;
                Series series1 = new Series("Chart", ViewType.Pie3D);
                foreach (DataRow r in dttemp.Rows)
                {
                    series1.Points.Add(new SeriesPoint(r["ServiceGroupName"].ToString(), Convert.ToDecimal(r["Quantity"].ToString())));
                }
                
                PieChart3D.Series.Add(series1);
                series1.LegendPointOptions.Pattern = "{A}:{V}";
                series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                series1.PointOptions.ValueNumericOptions.Precision = 2;
                
                ((Pie3DSeriesView)series1.View).Depth = 15;
                ((Pie3DSeriesView)series1.View).ExplodedPoints.Add(series1.Points[0]);
                ((Pie3DSeriesView)series1.View).ExplodedDistancePercentage = 30;

                ((SimpleDiagram3D)PieChart3D.Diagram).RotationType = RotationType.UseAngles;
                ((SimpleDiagram3D)PieChart3D.Diagram).RotationAngleX = -30;

                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Biểu Đồ CĐHA PIECHART";
                chartTitle1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                PieChart3D.Titles.Add(chartTitle1);

                // Display the chart control's legend.
                legend.Visible = true;
                // Define its margins and alignment relative to the diagram.
                //legend.Margins.All = 8;
                legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
                legend.AlignmentVertical = LegendAlignmentVertical.Bottom;
                // Define the layout of items within the legend.
                legend.Direction = LegendDirection.LeftToRight;
                legend.EquallySpacedItems = true;
                legend.HorizontalIndent = 8;
                legend.VerticalIndent = 8;
                legend.TextVisible = true;
                legend.TextOffset = 8;
                legend.MarkerVisible = true;
                legend.MarkerSize = new Size(20, 20);
                legend.Padding.All = 4;
                // Define the limits for the legend to occupy the chart's space.
                legend.MaxHorizontalPercentage = 100;
                legend.MaxVerticalPercentage = 100;
                // Customize the legend appearance.
                legend.BackColor = Color.Beige;
                legend.FillStyle.FillMode = FillMode.Gradient;
                ((RectangleGradientFillOptions)legend.FillStyle.Options).Color2 = Color.Bisque;
                legend.Border.Visible = true;
                legend.Border.Color = Color.DarkBlue;
                legend.Border.Thickness = 1;
                legend.Shadow.Visible = true;
                legend.Shadow.Color = Color.LightGray;
                legend.Shadow.Size = 1;
                // Customize the legend text properties.
                legend.Antialiasing = false;
                legend.Font = new Font("Arial", 7, FontStyle.Regular);
                legend.TextColor = Color.DarkBlue;

                PieChart3D.Dock = DockStyle.Fill;
                
                this.pnchart.Controls.Add(PieChart3D);
            }
            catch { }
        }

        private void GetDoughnutChart(DataTable dttemp)
        {
            try
            {
                ChartControl DoughnutChart3D = new ChartControl();
                Legend legend = DoughnutChart3D.Legend;
                Series series1 = new Series("Doughnut Series 1", ViewType.Doughnut3D);

                foreach (DataRow r in dttemp.Rows)
                {
                    series1.Points.Add(new SeriesPoint(r["ServiceGroupName"].ToString(), Convert.ToDecimal(r["Quantity"].ToString())));
                }

                DoughnutChart3D.Series.Add(series1);
                series1.LegendPointOptions.Pattern = "{A}:{V}";
                series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                series1.PointOptions.ValueNumericOptions.Precision = 2;

                ((Doughnut3DSeriesView)series1.View).HoleRadiusPercent = 30;
                ((Doughnut3DSeriesView)series1.View).ExplodedPoints.Add(series1.Points[0]);

                ((SimpleDiagram3D)DoughnutChart3D.Diagram).RotationType = RotationType.UseAngles;
                ((SimpleDiagram3D)DoughnutChart3D.Diagram).RotationAngleX = -35;

                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Biểu Đồ XN DOUGHCHART";
                chartTitle1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                DoughnutChart3D.Titles.Add(chartTitle1);

                // Display the chart control's legend.
                legend.Visible = true;
                // Define its margins and alignment relative to the diagram.
                //legend.Margins.All = 8;
                legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
                legend.AlignmentVertical = LegendAlignmentVertical.Top;
                // Define the layout of items within the legend.
                legend.Direction = LegendDirection.TopToBottom;
                legend.EquallySpacedItems = true;
                legend.HorizontalIndent = 8;
                legend.VerticalIndent = 8;
                legend.TextVisible = true;
                legend.TextOffset = 8;
                legend.MarkerVisible = true;
                legend.MarkerSize = new Size(20, 20);
                legend.Padding.All = 4;
                // Define the limits for the legend to occupy the chart's space.
                legend.MaxHorizontalPercentage = 100;
                legend.MaxVerticalPercentage = 100;
                // Customize the legend appearance.
                legend.BackColor = Color.Beige;
                legend.FillStyle.FillMode = FillMode.Gradient;
                ((RectangleGradientFillOptions)legend.FillStyle.Options).Color2 = Color.Bisque;
                legend.Border.Visible = true;
                legend.Border.Color = Color.White;
                legend.Border.Thickness = 1;
                legend.Shadow.Visible = true;
                legend.Shadow.Color = Color.LightGray;
                legend.Shadow.Size = 1;
                // Customize the legend text properties.
                legend.Antialiasing = false;
                legend.Font = new Font("Arial", 8, FontStyle.Regular);
                legend.TextColor = Color.DarkBlue;

                DoughnutChart3D.Dock = DockStyle.Fill;

                this.pnchart.Controls.Add(DoughnutChart3D);
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdCT.Checked)
                {
                    Reports.view_BacSiChiDinhTH rpt = new Reports.view_BacSiChiDinhTH();
                    rpt.DataSource = lst;
                    rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                    rpt.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                    rpt.Parameters["todate"].Value = dllNgay.denngay.Text;
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else if (rdTH.Checked)
                {
                    Reports.view_ChartCDHA_01 rpt = new Reports.view_ChartCDHA_01();
                    rpt.DataSource = lst;
                    rpt.Parameters["title"].Value = mnoTitle.Text.Trim();
                    rpt.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                    rpt.Parameters["todate"].Value = dllNgay.denngay.Text;
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Vui lòng chọn mẫu báo cáo để xem thống kê!", "Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch { }
        }

        private void lkupNhomDV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sGroup = "'" + lkupNhomDV.EditValue.ToString() + "'";
                chkList_Category.DataSource = ServiceCategoryBLL.rptListServiceCategory(sGroup.TrimEnd(','), "");
                chkList_Category.ValueMember = "ServiceCategoryCode";
                chkList_Category.DisplayMember = "ServiceCategoryName";
            }
            catch { }
        }
               

    }
}