namespace Ps.Clinic.Statistics
{
    partial class frmVP_DoanhThuTheoDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_DoanhThuTheoDV));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dllNgay = new UserControlDate.dllNgay();
            this.btnPrintGrid = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_result_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PatientAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ServicePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_DisparityPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_WorkDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_DepartmentNameOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_BanksAccountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PatientBirthyear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_DateIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_DateOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_EmployeeNameOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.lkupNhomDV = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.xtraTabControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(897, 546);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông tin tìm kiếm";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 21);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(893, 523);
            this.xtraTabControl1.TabIndex = 1050;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.dllNgay);
            this.xtraTabPage1.Controls.Add(this.btnPrintGrid);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Controls.Add(this.butOK);
            this.xtraTabPage1.Controls.Add(this.lkupNhomDV);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(887, 495);
            this.xtraTabPage1.Text = "Kết quả";
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(5, 2);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(293, 73);
            this.dllNgay.TabIndex = 1051;
            // 
            // btnPrintGrid
            // 
            this.btnPrintGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintGrid.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPrintGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGrid.Image")));
            this.btnPrintGrid.Location = new System.Drawing.Point(196, 102);
            this.btnPrintGrid.Name = "btnPrintGrid";
            this.btnPrintGrid.Size = new System.Drawing.Size(100, 26);
            this.btnPrintGrid.TabIndex = 1050;
            this.btnPrintGrid.Text = "In theo Grid";
            this.btnPrintGrid.Click += new System.EventHandler(this.btnPrintGrid_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Nhóm dịch vụ:";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_Result);
            this.panelControl1.Location = new System.Drawing.Point(302, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(585, 495);
            this.panelControl1.TabIndex = 1044;
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(585, 495);
            this.gridControl_Result.TabIndex = 2;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_result_PatientCode,
            this.col_result_PatientName,
            this.col_result_PatientAge,
            this.col_result_ObjectName,
            this.col_result_PatientGenderName,
            this.col_result_ServiceName,
            this.col_result_ServicePrice,
            this.col_result_DisparityPrice,
            this.col_result_ServiceCategoryName,
            this.col_result_ServiceGroupName,
            this.col_result_WorkDate,
            this.col_result_DepartmentName,
            this.col_result_DepartmentNameOrder,
            this.col_result_BanksAccountCode,
            this.col_result_PatientAddress,
            this.col_result_PatientBirthyear,
            this.col_result_DateIn,
            this.col_result_DateOut,
            this.col_result_EmployeeNameOrder});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServicePrice", null, "{0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.AllowFindPanel = false;
            this.gridView_Result.OptionsFind.FindFilterColumns = "";
            // 
            // col_result_PatientCode
            // 
            this.col_result_PatientCode.Caption = "Mã BN";
            this.col_result_PatientCode.FieldName = "PatientCode";
            this.col_result_PatientCode.Name = "col_result_PatientCode";
            this.col_result_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_result_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_result_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_result_PatientCode.Visible = true;
            this.col_result_PatientCode.VisibleIndex = 0;
            this.col_result_PatientCode.Width = 44;
            // 
            // col_result_PatientName
            // 
            this.col_result_PatientName.Caption = "Họ và tên";
            this.col_result_PatientName.FieldName = "PatientName";
            this.col_result_PatientName.Name = "col_result_PatientName";
            this.col_result_PatientName.OptionsColumn.AllowEdit = false;
            this.col_result_PatientName.OptionsColumn.AllowFocus = false;
            this.col_result_PatientName.OptionsColumn.ReadOnly = true;
            this.col_result_PatientName.Visible = true;
            this.col_result_PatientName.VisibleIndex = 1;
            this.col_result_PatientName.Width = 52;
            // 
            // col_result_PatientAge
            // 
            this.col_result_PatientAge.Caption = "Tuổi";
            this.col_result_PatientAge.FieldName = "PatientAge";
            this.col_result_PatientAge.Name = "col_result_PatientAge";
            this.col_result_PatientAge.OptionsColumn.AllowEdit = false;
            this.col_result_PatientAge.OptionsColumn.AllowFocus = false;
            this.col_result_PatientAge.OptionsColumn.ReadOnly = true;
            this.col_result_PatientAge.Visible = true;
            this.col_result_PatientAge.VisibleIndex = 2;
            this.col_result_PatientAge.Width = 43;
            // 
            // col_result_ObjectName
            // 
            this.col_result_ObjectName.Caption = "Đối tượng";
            this.col_result_ObjectName.FieldName = "ObjectName";
            this.col_result_ObjectName.Name = "col_result_ObjectName";
            this.col_result_ObjectName.OptionsColumn.AllowEdit = false;
            this.col_result_ObjectName.OptionsColumn.AllowFocus = false;
            this.col_result_ObjectName.OptionsColumn.ReadOnly = true;
            this.col_result_ObjectName.Visible = true;
            this.col_result_ObjectName.VisibleIndex = 4;
            this.col_result_ObjectName.Width = 43;
            // 
            // col_result_PatientGenderName
            // 
            this.col_result_PatientGenderName.Caption = "Giới tính";
            this.col_result_PatientGenderName.FieldName = "PatientGenderName";
            this.col_result_PatientGenderName.Name = "col_result_PatientGenderName";
            this.col_result_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.col_result_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.col_result_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.col_result_PatientGenderName.Visible = true;
            this.col_result_PatientGenderName.VisibleIndex = 3;
            this.col_result_PatientGenderName.Width = 43;
            // 
            // col_result_ServiceName
            // 
            this.col_result_ServiceName.Caption = "Dịch vụ";
            this.col_result_ServiceName.FieldName = "ServiceName";
            this.col_result_ServiceName.Name = "col_result_ServiceName";
            this.col_result_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_result_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_result_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_result_ServiceName.Visible = true;
            this.col_result_ServiceName.VisibleIndex = 5;
            this.col_result_ServiceName.Width = 43;
            // 
            // col_result_ServicePrice
            // 
            this.col_result_ServicePrice.Caption = "Giá";
            this.col_result_ServicePrice.DisplayFormat.FormatString = "#,#.####";
            this.col_result_ServicePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_ServicePrice.FieldName = "ServicePrice";
            this.col_result_ServicePrice.Name = "col_result_ServicePrice";
            this.col_result_ServicePrice.OptionsColumn.AllowEdit = false;
            this.col_result_ServicePrice.OptionsColumn.AllowFocus = false;
            this.col_result_ServicePrice.OptionsColumn.ReadOnly = true;
            this.col_result_ServicePrice.Visible = true;
            this.col_result_ServicePrice.VisibleIndex = 6;
            this.col_result_ServicePrice.Width = 43;
            // 
            // col_result_DisparityPrice
            // 
            this.col_result_DisparityPrice.Caption = "Chênh lệch";
            this.col_result_DisparityPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_result_DisparityPrice.FieldName = "DisparityPrice";
            this.col_result_DisparityPrice.Name = "col_result_DisparityPrice";
            this.col_result_DisparityPrice.OptionsColumn.AllowEdit = false;
            this.col_result_DisparityPrice.OptionsColumn.AllowFocus = false;
            this.col_result_DisparityPrice.OptionsColumn.ReadOnly = true;
            this.col_result_DisparityPrice.Width = 43;
            // 
            // col_result_ServiceCategoryName
            // 
            this.col_result_ServiceCategoryName.Caption = "Loại dịch vụ";
            this.col_result_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_result_ServiceCategoryName.Name = "col_result_ServiceCategoryName";
            this.col_result_ServiceCategoryName.OptionsColumn.AllowEdit = false;
            this.col_result_ServiceCategoryName.OptionsColumn.AllowFocus = false;
            this.col_result_ServiceCategoryName.OptionsColumn.ReadOnly = true;
            this.col_result_ServiceCategoryName.Visible = true;
            this.col_result_ServiceCategoryName.VisibleIndex = 8;
            this.col_result_ServiceCategoryName.Width = 43;
            // 
            // col_result_ServiceGroupName
            // 
            this.col_result_ServiceGroupName.Caption = "Nhóm dịch vụ";
            this.col_result_ServiceGroupName.FieldName = "ServiceGroupName";
            this.col_result_ServiceGroupName.Name = "col_result_ServiceGroupName";
            this.col_result_ServiceGroupName.OptionsColumn.AllowEdit = false;
            this.col_result_ServiceGroupName.OptionsColumn.AllowFocus = false;
            this.col_result_ServiceGroupName.OptionsColumn.ReadOnly = true;
            this.col_result_ServiceGroupName.Visible = true;
            this.col_result_ServiceGroupName.VisibleIndex = 9;
            this.col_result_ServiceGroupName.Width = 43;
            // 
            // col_result_WorkDate
            // 
            this.col_result_WorkDate.Caption = "Ngày";
            this.col_result_WorkDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_result_WorkDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_result_WorkDate.FieldName = "WorkDate";
            this.col_result_WorkDate.Name = "col_result_WorkDate";
            this.col_result_WorkDate.OptionsColumn.AllowEdit = false;
            this.col_result_WorkDate.OptionsColumn.AllowFocus = false;
            this.col_result_WorkDate.OptionsColumn.ReadOnly = true;
            this.col_result_WorkDate.Visible = true;
            this.col_result_WorkDate.VisibleIndex = 7;
            this.col_result_WorkDate.Width = 43;
            // 
            // col_result_DepartmentName
            // 
            this.col_result_DepartmentName.Caption = "Phòng thực hiện";
            this.col_result_DepartmentName.FieldName = "DepartmentName";
            this.col_result_DepartmentName.Name = "col_result_DepartmentName";
            this.col_result_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_result_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_result_DepartmentName.OptionsColumn.ReadOnly = true;
            this.col_result_DepartmentName.Width = 43;
            // 
            // col_result_DepartmentNameOrder
            // 
            this.col_result_DepartmentNameOrder.Caption = "Phòng chỉ định";
            this.col_result_DepartmentNameOrder.FieldName = "DepartmentNameOrder";
            this.col_result_DepartmentNameOrder.Name = "col_result_DepartmentNameOrder";
            this.col_result_DepartmentNameOrder.OptionsColumn.AllowEdit = false;
            this.col_result_DepartmentNameOrder.OptionsColumn.AllowFocus = false;
            this.col_result_DepartmentNameOrder.OptionsColumn.ReadOnly = true;
            this.col_result_DepartmentNameOrder.Visible = true;
            this.col_result_DepartmentNameOrder.VisibleIndex = 10;
            this.col_result_DepartmentNameOrder.Width = 43;
            // 
            // col_result_BanksAccountCode
            // 
            this.col_result_BanksAccountCode.Caption = "Phiếu thu";
            this.col_result_BanksAccountCode.FieldName = "BanksAccountCode";
            this.col_result_BanksAccountCode.Name = "col_result_BanksAccountCode";
            // 
            // col_result_PatientAddress
            // 
            this.col_result_PatientAddress.Caption = "Địa chỉ";
            this.col_result_PatientAddress.FieldName = "PatientAddress";
            this.col_result_PatientAddress.Name = "col_result_PatientAddress";
            // 
            // col_result_PatientBirthyear
            // 
            this.col_result_PatientBirthyear.Caption = "Năm sinh";
            this.col_result_PatientBirthyear.FieldName = "PatientBirthyear";
            this.col_result_PatientBirthyear.Name = "col_result_PatientBirthyear";
            // 
            // col_result_DateIn
            // 
            this.col_result_DateIn.Caption = "Ngày vào";
            this.col_result_DateIn.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_result_DateIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_result_DateIn.FieldName = "DateIn";
            this.col_result_DateIn.Name = "col_result_DateIn";
            this.col_result_DateIn.OptionsColumn.AllowEdit = false;
            this.col_result_DateIn.OptionsColumn.AllowFocus = false;
            this.col_result_DateIn.OptionsColumn.ReadOnly = true;
            this.col_result_DateIn.Width = 43;
            // 
            // col_result_DateOut
            // 
            this.col_result_DateOut.Caption = "Ngày ra";
            this.col_result_DateOut.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_result_DateOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_result_DateOut.FieldName = "DateOut";
            this.col_result_DateOut.Name = "col_result_DateOut";
            this.col_result_DateOut.OptionsColumn.AllowEdit = false;
            this.col_result_DateOut.OptionsColumn.AllowFocus = false;
            this.col_result_DateOut.OptionsColumn.ReadOnly = true;
            this.col_result_DateOut.Visible = true;
            this.col_result_DateOut.VisibleIndex = 12;
            this.col_result_DateOut.Width = 50;
            // 
            // col_result_EmployeeNameOrder
            // 
            this.col_result_EmployeeNameOrder.Caption = "User Chỉ định";
            this.col_result_EmployeeNameOrder.FieldName = "EmployeeNameOrder";
            this.col_result_EmployeeNameOrder.Name = "col_result_EmployeeNameOrder";
            this.col_result_EmployeeNameOrder.OptionsColumn.AllowEdit = false;
            this.col_result_EmployeeNameOrder.OptionsColumn.AllowFocus = false;
            this.col_result_EmployeeNameOrder.OptionsColumn.ReadOnly = true;
            this.col_result_EmployeeNameOrder.Visible = true;
            this.col_result_EmployeeNameOrder.VisibleIndex = 11;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(76, 102);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(95, 26);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Xem số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // lkupNhomDV
            // 
            this.lkupNhomDV.EditValue = "0";
            this.lkupNhomDV.Location = new System.Drawing.Point(79, 76);
            this.lkupNhomDV.Name = "lkupNhomDV";
            this.lkupNhomDV.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lkupNhomDV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupNhomDV.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupCode", "ServiceGroupCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceGroupName", "Nhóm dịch vụ")});
            this.lkupNhomDV.Properties.NullText = "";
            this.lkupNhomDV.Size = new System.Drawing.Size(219, 20);
            this.lkupNhomDV.TabIndex = 1049;
            this.lkupNhomDV.EditValueChanged += new System.EventHandler(this.lkupNhomDV_EditValueChanged);
            // 
            // frmVP_DoanhThuTheoDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 546);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVP_DoanhThuTheoDV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVP_DoanhThuBSChiDinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientAge;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ServicePrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_DisparityPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ServiceGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_WorkDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_DepartmentNameOrder;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_BanksAccountCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientBirthyear;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_DateIn;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_DateOut;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnPrintGrid;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_EmployeeNameOrder;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.LookUpEdit lkupNhomDV;
    }
}