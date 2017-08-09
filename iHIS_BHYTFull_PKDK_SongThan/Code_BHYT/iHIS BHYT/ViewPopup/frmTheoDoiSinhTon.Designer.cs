namespace Ps.Clinic.ViewPopup
{
    partial class frmTheoDoiSinhTon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.ToolTipRelativePosition toolTipRelativePosition1 = new DevExpress.XtraCharts.ToolTipRelativePosition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheoDoiSinhTon));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pnImageView = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Sign = new DevExpress.XtraGrid.GridControl();
            this.gridView_Sign = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Sign_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_Pulse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_Temperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_BloodPressure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_BloodPressure1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_Hight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_RefID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_ReferenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_CreateDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_Sign_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sign_Breath = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnImageView)).BeginInit();
            this.pnImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Sign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Sign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_CreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_CreateDate.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 529);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(982, 31);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(982, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // pnImageView
            // 
            this.pnImageView.Controls.Add(this.groupControl1);
            this.pnImageView.Controls.Add(this.panelControl1);
            this.pnImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnImageView.Location = new System.Drawing.Point(0, 49);
            this.pnImageView.Name = "pnImageView";
            this.pnImageView.Size = new System.Drawing.Size(982, 480);
            this.pnImageView.TabIndex = 179;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chartControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 248);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(978, 230);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Biểu Đồ Sinh Hiệu";
            // 
            // chartControl1
            // 
            this.chartControl1.EmptyChartText.Font = new System.Drawing.Font("Tahoma", 8F);
            this.chartControl1.Location = new System.Drawing.Point(2, 21);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            swiftPlotSeriesView1.LineStyle.Thickness = 2;
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView1;
            this.chartControl1.Size = new System.Drawing.Size(974, 207);
            this.chartControl1.SmallChartText.Font = new System.Drawing.Font("Tahoma", 8F);
            this.chartControl1.TabIndex = 1038;
            this.chartControl1.ToolTipOptions.ToolTipPosition = toolTipRelativePosition1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl_Sign);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(978, 246);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl_Sign
            // 
            this.gridControl_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Sign.Location = new System.Drawing.Point(2, 2);
            this.gridControl_Sign.MainView = this.gridView_Sign;
            this.gridControl_Sign.Name = "gridControl_Sign";
            this.gridControl_Sign.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_CreateDate});
            this.gridControl_Sign.Size = new System.Drawing.Size(974, 242);
            this.gridControl_Sign.TabIndex = 1036;
            this.gridControl_Sign.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Sign});
            // 
            // gridView_Sign
            // 
            this.gridView_Sign.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Sign.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Sign.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Sign.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Sign.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Sign.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Sign_RowID,
            this.col_Sign_Pulse,
            this.col_Sign_Temperature,
            this.col_Sign_BloodPressure,
            this.col_Sign_BloodPressure1,
            this.col_Sign_Weight,
            this.col_Sign_Hight,
            this.col_Sign_RefID,
            this.col_Sign_ReferenceCode,
            this.col_Sign_CreateDate,
            this.col_Sign_PatientCode,
            this.col_Sign_Breath});
            this.gridView_Sign.GridControl = this.gridControl_Sign;
            this.gridView_Sign.Name = "gridView_Sign";
            this.gridView_Sign.NewItemRowText = "Nhập, thêm mới dấu sinh tồn";
            this.gridView_Sign.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Sign.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Sign.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Sign.OptionsView.ShowFooter = true;
            this.gridView_Sign.OptionsView.ShowGroupPanel = false;
            this.gridView_Sign.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_Sign_CreateDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_Sign.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Sign_ValidateRow);
            // 
            // col_Sign_RowID
            // 
            this.col_Sign_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_Sign_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_RowID.Caption = "ID";
            this.col_Sign_RowID.FieldName = "RowID";
            this.col_Sign_RowID.Name = "col_Sign_RowID";
            this.col_Sign_RowID.OptionsColumn.AllowEdit = false;
            this.col_Sign_RowID.OptionsColumn.AllowSize = false;
            this.col_Sign_RowID.Width = 84;
            // 
            // col_Sign_Pulse
            // 
            this.col_Sign_Pulse.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_Pulse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_Pulse.Caption = "Mạch";
            this.col_Sign_Pulse.CustomizationCaption = "#,#";
            this.col_Sign_Pulse.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_Pulse.FieldName = "Pulse";
            this.col_Sign_Pulse.Name = "col_Sign_Pulse";
            this.col_Sign_Pulse.OptionsColumn.AllowMove = false;
            this.col_Sign_Pulse.Visible = true;
            this.col_Sign_Pulse.VisibleIndex = 1;
            this.col_Sign_Pulse.Width = 34;
            // 
            // col_Sign_Temperature
            // 
            this.col_Sign_Temperature.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_Temperature.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_Temperature.Caption = "N.Độ";
            this.col_Sign_Temperature.DisplayFormat.FormatString = "#,#.##";
            this.col_Sign_Temperature.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_Temperature.FieldName = "Temperature";
            this.col_Sign_Temperature.Name = "col_Sign_Temperature";
            this.col_Sign_Temperature.OptionsColumn.AllowMove = false;
            this.col_Sign_Temperature.Visible = true;
            this.col_Sign_Temperature.VisibleIndex = 2;
            this.col_Sign_Temperature.Width = 35;
            // 
            // col_Sign_BloodPressure
            // 
            this.col_Sign_BloodPressure.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_BloodPressure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_BloodPressure.Caption = "H.Áp";
            this.col_Sign_BloodPressure.DisplayFormat.FormatString = "#,#";
            this.col_Sign_BloodPressure.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_BloodPressure.FieldName = "BloodPressure";
            this.col_Sign_BloodPressure.Name = "col_Sign_BloodPressure";
            this.col_Sign_BloodPressure.OptionsColumn.AllowMove = false;
            this.col_Sign_BloodPressure.Visible = true;
            this.col_Sign_BloodPressure.VisibleIndex = 3;
            this.col_Sign_BloodPressure.Width = 28;
            // 
            // col_Sign_BloodPressure1
            // 
            this.col_Sign_BloodPressure1.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_BloodPressure1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_BloodPressure1.Caption = "H.Áp";
            this.col_Sign_BloodPressure1.DisplayFormat.FormatString = "#,#";
            this.col_Sign_BloodPressure1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_BloodPressure1.FieldName = "BloodPressure1";
            this.col_Sign_BloodPressure1.Name = "col_Sign_BloodPressure1";
            this.col_Sign_BloodPressure1.OptionsColumn.AllowMove = false;
            this.col_Sign_BloodPressure1.Visible = true;
            this.col_Sign_BloodPressure1.VisibleIndex = 4;
            this.col_Sign_BloodPressure1.Width = 28;
            // 
            // col_Sign_Weight
            // 
            this.col_Sign_Weight.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_Weight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_Weight.Caption = "Nặng";
            this.col_Sign_Weight.DisplayFormat.FormatString = "#,#.##";
            this.col_Sign_Weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_Weight.FieldName = "Weight";
            this.col_Sign_Weight.Name = "col_Sign_Weight";
            this.col_Sign_Weight.OptionsColumn.AllowMove = false;
            this.col_Sign_Weight.Visible = true;
            this.col_Sign_Weight.VisibleIndex = 5;
            this.col_Sign_Weight.Width = 33;
            // 
            // col_Sign_Hight
            // 
            this.col_Sign_Hight.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_Hight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_Hight.Caption = "Cao";
            this.col_Sign_Hight.DisplayFormat.FormatString = "#,#.##";
            this.col_Sign_Hight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_Hight.FieldName = "Hight";
            this.col_Sign_Hight.Name = "col_Sign_Hight";
            this.col_Sign_Hight.OptionsColumn.AllowMove = false;
            this.col_Sign_Hight.Visible = true;
            this.col_Sign_Hight.VisibleIndex = 6;
            this.col_Sign_Hight.Width = 34;
            // 
            // col_Sign_RefID
            // 
            this.col_Sign_RefID.Caption = "RefID";
            this.col_Sign_RefID.FieldName = "RefID";
            this.col_Sign_RefID.Name = "col_Sign_RefID";
            // 
            // col_Sign_ReferenceCode
            // 
            this.col_Sign_ReferenceCode.Caption = "ReferenceCode";
            this.col_Sign_ReferenceCode.FieldName = "ReferenceCode";
            this.col_Sign_ReferenceCode.Name = "col_Sign_ReferenceCode";
            // 
            // col_Sign_CreateDate
            // 
            this.col_Sign_CreateDate.Caption = "Ngày";
            this.col_Sign_CreateDate.ColumnEdit = this.rep_CreateDate;
            this.col_Sign_CreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.col_Sign_CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_Sign_CreateDate.FieldName = "CreateDate";
            this.col_Sign_CreateDate.Name = "col_Sign_CreateDate";
            this.col_Sign_CreateDate.Visible = true;
            this.col_Sign_CreateDate.VisibleIndex = 0;
            this.col_Sign_CreateDate.Width = 86;
            // 
            // rep_CreateDate
            // 
            this.rep_CreateDate.AutoHeight = false;
            this.rep_CreateDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_CreateDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rep_CreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.rep_CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rep_CreateDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.rep_CreateDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rep_CreateDate.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.rep_CreateDate.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.rep_CreateDate.Name = "rep_CreateDate";
            this.rep_CreateDate.EditValueChanged += new System.EventHandler(this.rep_CreateDate_EditValueChanged);
            // 
            // col_Sign_PatientCode
            // 
            this.col_Sign_PatientCode.Caption = "Mã BN";
            this.col_Sign_PatientCode.FieldName = "PatientCode";
            this.col_Sign_PatientCode.Name = "col_Sign_PatientCode";
            // 
            // col_Sign_Breath
            // 
            this.col_Sign_Breath.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sign_Breath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sign_Breath.Caption = "N.Thở";
            this.col_Sign_Breath.DisplayFormat.FormatString = "#,#";
            this.col_Sign_Breath.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sign_Breath.FieldName = "Breath";
            this.col_Sign_Breath.Name = "col_Sign_Breath";
            this.col_Sign_Breath.Visible = true;
            this.col_Sign_Breath.VisibleIndex = 7;
            this.col_Sign_Breath.Width = 40;
            // 
            // frmTheoDoiSinhTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 560);
            this.Controls.Add(this.pnImageView);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTheoDoiSinhTon";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Theo dõi dấu hiệu sinh tồn";
            this.Load += new System.EventHandler(this.frmTheoDoiSinhTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnImageView)).EndInit();
            this.pnImageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Sign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Sign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_CreateDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_CreateDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl pnImageView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Sign;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Sign;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_Pulse;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_Temperature;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_BloodPressure;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_BloodPressure1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_Weight;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_Hight;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_RefID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_ReferenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_CreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sign_Breath;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rep_CreateDate;
        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}