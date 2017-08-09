namespace Ps.Clinic.Statistics
{
    partial class frmRpt_DSGuiMauXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_DSGuiMauXN));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_WorkDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientReceiveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SampleTransferPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dllNgay = new UserControlDate.dllNgay();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(880, 487);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông Tin Lọc Dữ Liệu";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(316, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(562, 464);
            this.panelControl1.TabIndex = 1040;
            // 
            // gridControl_result
            // 
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChon});
            this.gridControl_result.Size = new System.Drawing.Size(562, 464);
            this.gridControl_result.TabIndex = 6;
            this.gridControl_result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_result});
            // 
            // gridView_result
            // 
            this.gridView_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_WorkDate,
            this.col_PatientReceiveID,
            this.col_PatientCode,
            this.col_PatientName,
            this.col_PatientMobile,
            this.col_PatientBirthday,
            this.col_PatientAddress,
            this.col_GenderName,
            this.col_ServiceName,
            this.col_UnitPrice,
            this.col_SampleTransferPrice});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsView.ColumnAutoWidth = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            // 
            // col_WorkDate
            // 
            this.col_WorkDate.Caption = "Ngày gửi mẫu";
            this.col_WorkDate.DisplayFormat.FormatString = "{dd/mm/yyy}";
            this.col_WorkDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_WorkDate.FieldName = "WorkDate";
            this.col_WorkDate.Name = "col_WorkDate";
            this.col_WorkDate.OptionsColumn.AllowEdit = false;
            this.col_WorkDate.OptionsColumn.AllowFocus = false;
            this.col_WorkDate.OptionsColumn.ReadOnly = true;
            this.col_WorkDate.Visible = true;
            this.col_WorkDate.VisibleIndex = 0;
            this.col_WorkDate.Width = 88;
            // 
            // col_PatientReceiveID
            // 
            this.col_PatientReceiveID.Caption = "PatientReceiveID";
            this.col_PatientReceiveID.FieldName = "PatientReceiveID";
            this.col_PatientReceiveID.Name = "col_PatientReceiveID";
            this.col_PatientReceiveID.OptionsColumn.AllowEdit = false;
            this.col_PatientReceiveID.OptionsColumn.AllowFocus = false;
            this.col_PatientReceiveID.OptionsColumn.ReadOnly = true;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.Caption = "Mã bệnh nhân";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PatientCode", "{0}")});
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 1;
            this.col_PatientCode.Width = 84;
            // 
            // col_PatientName
            // 
            this.col_PatientName.Caption = "Tên bệnh nhân";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.OptionsColumn.AllowEdit = false;
            this.col_PatientName.OptionsColumn.AllowFocus = false;
            this.col_PatientName.OptionsColumn.ReadOnly = true;
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 2;
            this.col_PatientName.Width = 132;
            // 
            // col_PatientMobile
            // 
            this.col_PatientMobile.Caption = "Số điện thoại";
            this.col_PatientMobile.FieldName = "PatientMobile";
            this.col_PatientMobile.Name = "col_PatientMobile";
            this.col_PatientMobile.OptionsColumn.AllowEdit = false;
            this.col_PatientMobile.OptionsColumn.AllowFocus = false;
            this.col_PatientMobile.OptionsColumn.ReadOnly = true;
            this.col_PatientMobile.Visible = true;
            this.col_PatientMobile.VisibleIndex = 5;
            this.col_PatientMobile.Width = 96;
            // 
            // col_PatientBirthday
            // 
            this.col_PatientBirthday.Caption = "Ngày sinh";
            this.col_PatientBirthday.DisplayFormat.FormatString = "{dd/mm/yyyy}";
            this.col_PatientBirthday.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_PatientBirthday.FieldName = "PatientBirthday";
            this.col_PatientBirthday.Name = "col_PatientBirthday";
            this.col_PatientBirthday.OptionsColumn.AllowEdit = false;
            this.col_PatientBirthday.OptionsColumn.AllowFocus = false;
            this.col_PatientBirthday.OptionsColumn.ReadOnly = true;
            this.col_PatientBirthday.Visible = true;
            this.col_PatientBirthday.VisibleIndex = 4;
            // 
            // col_PatientAddress
            // 
            this.col_PatientAddress.Caption = "Địa chỉ";
            this.col_PatientAddress.FieldName = "PatientAddress";
            this.col_PatientAddress.Name = "col_PatientAddress";
            this.col_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_PatientAddress.OptionsColumn.ReadOnly = true;
            this.col_PatientAddress.Visible = true;
            this.col_PatientAddress.VisibleIndex = 6;
            this.col_PatientAddress.Width = 147;
            // 
            // col_GenderName
            // 
            this.col_GenderName.Caption = "Giới tính";
            this.col_GenderName.FieldName = "GenderName";
            this.col_GenderName.Name = "col_GenderName";
            this.col_GenderName.OptionsColumn.AllowEdit = false;
            this.col_GenderName.OptionsColumn.AllowFocus = false;
            this.col_GenderName.OptionsColumn.ReadOnly = true;
            this.col_GenderName.Visible = true;
            this.col_GenderName.VisibleIndex = 3;
            this.col_GenderName.Width = 48;
            // 
            // col_ServiceName
            // 
            this.col_ServiceName.Caption = "Tên dịch vụ";
            this.col_ServiceName.FieldName = "ServiceName";
            this.col_ServiceName.Name = "col_ServiceName";
            this.col_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_ServiceName.Visible = true;
            this.col_ServiceName.VisibleIndex = 7;
            this.col_ServiceName.Width = 181;
            // 
            // col_UnitPrice
            // 
            this.col_UnitPrice.Caption = "Giá phòng khám";
            this.col_UnitPrice.DisplayFormat.FormatString = "#,#";
            this.col_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPrice.FieldName = "UnitPrice";
            this.col_UnitPrice.Name = "col_UnitPrice";
            this.col_UnitPrice.OptionsColumn.AllowEdit = false;
            this.col_UnitPrice.OptionsColumn.AllowFocus = false;
            this.col_UnitPrice.OptionsColumn.ReadOnly = true;
            this.col_UnitPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnitPrice", "{0:#,#}")});
            this.col_UnitPrice.Visible = true;
            this.col_UnitPrice.VisibleIndex = 8;
            this.col_UnitPrice.Width = 91;
            // 
            // col_SampleTransferPrice
            // 
            this.col_SampleTransferPrice.Caption = "Giá gửi mẫu";
            this.col_SampleTransferPrice.DisplayFormat.FormatString = "#,#";
            this.col_SampleTransferPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SampleTransferPrice.FieldName = "SampleTransferPrice";
            this.col_SampleTransferPrice.Name = "col_SampleTransferPrice";
            this.col_SampleTransferPrice.OptionsColumn.AllowEdit = false;
            this.col_SampleTransferPrice.OptionsColumn.AllowFocus = false;
            this.col_SampleTransferPrice.OptionsColumn.ReadOnly = true;
            this.col_SampleTransferPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SampleTransferPrice", "{0:#,#}")});
            this.col_SampleTransferPrice.Visible = true;
            this.col_SampleTransferPrice.VisibleIndex = 9;
            this.col_SampleTransferPrice.Width = 84;
            // 
            // repChon
            // 
            this.repChon.AutoHeight = false;
            this.repChon.DisplayValueChecked = "1";
            this.repChon.DisplayValueGrayed = "0";
            this.repChon.DisplayValueUnchecked = "0";
            this.repChon.Name = "repChon";
            this.repChon.ValueChecked = 1;
            this.repChon.ValueGrayed = 0;
            this.repChon.ValueUnchecked = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Controls.Add(this.butPrint);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(314, 464);
            this.panelControl2.TabIndex = 1039;
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(10, 3);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(296, 73);
            this.dllNgay.TabIndex = 1036;
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(67, 82);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(102, 23);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(203, 82);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(94, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In theo Gird";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // frmRpt_DSGuiMauXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 487);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRpt_DSGuiMauXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRpt_DSDotDieuTri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChon;
        private DevExpress.XtraGrid.Columns.GridColumn col_WorkDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientReceiveID;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientMobile;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_GenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_SampleTransferPrice;
    }
}