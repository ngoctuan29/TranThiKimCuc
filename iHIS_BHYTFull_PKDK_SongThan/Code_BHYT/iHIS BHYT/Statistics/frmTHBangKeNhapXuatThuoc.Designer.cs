namespace Ps.Clinic.Statistics
{
    partial class frmTHBangKeNhapXuatThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTHBangKeNhapXuatThuoc));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_InvoiceNnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_InvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Shipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RepositoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExport = new DevExpress.XtraEditors.CheckEdit();
            this.controlDate = new UserControlDateTimes.UserControlDateTimes();
            this.butPrintBC = new DevExpress.XtraEditors.SimpleButton();
            this.lbRepository = new DevExpress.XtraEditors.LabelControl();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.cbxRepository = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRepository.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.Controls.Add(this.gridControl_Result);
            this.grMain.Controls.Add(this.panelControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1015, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Báo cáo";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(2, 56);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(1011, 468);
            this.gridControl_Result.TabIndex = 1;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_InvoiceNnumber,
            this.col_InvoiceDate,
            this.col_ImportDate,
            this.col_ItemCode,
            this.col_ItemName,
            this.col_UnitOfMeasureName,
            this.col_ItemCategoryName,
            this.col_GroupName,
            this.col_Quantity,
            this.col_UnitPrice,
            this.col_Amount,
            this.col_Shipment,
            this.col_DateEnd,
            this.col_VendorName,
            this.col_RepositoryName});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // col_InvoiceNnumber
            // 
            this.col_InvoiceNnumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_InvoiceNnumber.AppearanceHeader.Options.UseFont = true;
            this.col_InvoiceNnumber.Caption = "Số HĐ";
            this.col_InvoiceNnumber.FieldName = "InvoiceNnumber";
            this.col_InvoiceNnumber.Name = "col_InvoiceNnumber";
            this.col_InvoiceNnumber.OptionsColumn.AllowEdit = false;
            this.col_InvoiceNnumber.OptionsColumn.AllowFocus = false;
            this.col_InvoiceNnumber.OptionsColumn.ReadOnly = true;
            this.col_InvoiceNnumber.Visible = true;
            this.col_InvoiceNnumber.VisibleIndex = 0;
            this.col_InvoiceNnumber.Width = 124;
            // 
            // col_InvoiceDate
            // 
            this.col_InvoiceDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_InvoiceDate.AppearanceHeader.Options.UseFont = true;
            this.col_InvoiceDate.Caption = "Ngày HĐ";
            this.col_InvoiceDate.FieldName = "InvoiceDate";
            this.col_InvoiceDate.Name = "col_InvoiceDate";
            this.col_InvoiceDate.OptionsColumn.AllowEdit = false;
            this.col_InvoiceDate.OptionsColumn.AllowFocus = false;
            this.col_InvoiceDate.OptionsColumn.ReadOnly = true;
            this.col_InvoiceDate.Visible = true;
            this.col_InvoiceDate.VisibleIndex = 1;
            this.col_InvoiceDate.Width = 112;
            // 
            // col_ImportDate
            // 
            this.col_ImportDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ImportDate.AppearanceHeader.Options.UseFont = true;
            this.col_ImportDate.Caption = "Ngày nhập kho";
            this.col_ImportDate.FieldName = "ImportDate";
            this.col_ImportDate.Name = "col_ImportDate";
            this.col_ImportDate.OptionsColumn.AllowEdit = false;
            this.col_ImportDate.OptionsColumn.AllowFocus = false;
            this.col_ImportDate.OptionsColumn.ReadOnly = true;
            this.col_ImportDate.Visible = true;
            this.col_ImportDate.VisibleIndex = 2;
            this.col_ImportDate.Width = 112;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCode.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 3;
            this.col_ItemCode.Width = 90;
            // 
            // col_ItemName
            // 
            this.col_ItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemName.Caption = "Tên thuốc - vtyt";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.OptionsColumn.AllowEdit = false;
            this.col_ItemName.OptionsColumn.AllowFocus = false;
            this.col_ItemName.OptionsColumn.ReadOnly = true;
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 4;
            this.col_ItemName.Width = 245;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseFont = true;
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.Caption = "ĐVT";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.col_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.col_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 5;
            this.col_UnitOfMeasureName.Width = 70;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCategoryName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCategoryName.Caption = "Loại";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.OptionsColumn.AllowEdit = false;
            this.col_ItemCategoryName.OptionsColumn.AllowFocus = false;
            this.col_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 12;
            this.col_ItemCategoryName.Width = 129;
            // 
            // col_GroupName
            // 
            this.col_GroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GroupName.AppearanceHeader.Options.UseFont = true;
            this.col_GroupName.Caption = "Nhóm";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.OptionsColumn.AllowEdit = false;
            this.col_GroupName.OptionsColumn.AllowFocus = false;
            this.col_GroupName.OptionsColumn.ReadOnly = true;
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 11;
            this.col_GroupName.Width = 203;
            // 
            // col_Quantity
            // 
            this.col_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Quantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Quantity.AppearanceHeader.Options.UseFont = true;
            this.col_Quantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Quantity.Caption = "Số lượng";
            this.col_Quantity.DisplayFormat.FormatString = "#,#.##";
            this.col_Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Quantity.FieldName = "Quantity";
            this.col_Quantity.Name = "col_Quantity";
            this.col_Quantity.OptionsColumn.AllowEdit = false;
            this.col_Quantity.OptionsColumn.AllowFocus = false;
            this.col_Quantity.OptionsColumn.ReadOnly = true;
            this.col_Quantity.Visible = true;
            this.col_Quantity.VisibleIndex = 6;
            this.col_Quantity.Width = 112;
            // 
            // col_UnitPrice
            // 
            this.col_UnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitPrice.AppearanceHeader.Options.UseFont = true;
            this.col_UnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.Caption = "Đơn giá";
            this.col_UnitPrice.DisplayFormat.FormatString = "#,#.##";
            this.col_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPrice.FieldName = "UnitPrice";
            this.col_UnitPrice.Name = "col_UnitPrice";
            this.col_UnitPrice.OptionsColumn.AllowEdit = false;
            this.col_UnitPrice.OptionsColumn.AllowFocus = false;
            this.col_UnitPrice.OptionsColumn.ReadOnly = true;
            this.col_UnitPrice.Visible = true;
            this.col_UnitPrice.VisibleIndex = 7;
            this.col_UnitPrice.Width = 102;
            // 
            // col_Amount
            // 
            this.col_Amount.AppearanceCell.Options.UseTextOptions = true;
            this.col_Amount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Amount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Amount.AppearanceHeader.Options.UseFont = true;
            this.col_Amount.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Amount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Amount.Caption = "Thành tiền";
            this.col_Amount.DisplayFormat.FormatString = "#,#.##";
            this.col_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Amount.FieldName = "Amount";
            this.col_Amount.Name = "col_Amount";
            this.col_Amount.OptionsColumn.AllowEdit = false;
            this.col_Amount.OptionsColumn.AllowFocus = false;
            this.col_Amount.OptionsColumn.ReadOnly = true;
            this.col_Amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#}")});
            this.col_Amount.Visible = true;
            this.col_Amount.VisibleIndex = 8;
            this.col_Amount.Width = 112;
            // 
            // col_Shipment
            // 
            this.col_Shipment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Shipment.AppearanceHeader.Options.UseFont = true;
            this.col_Shipment.Caption = "Số lô";
            this.col_Shipment.FieldName = "Shipment";
            this.col_Shipment.Name = "col_Shipment";
            this.col_Shipment.OptionsColumn.AllowEdit = false;
            this.col_Shipment.OptionsColumn.AllowFocus = false;
            this.col_Shipment.OptionsColumn.ReadOnly = true;
            this.col_Shipment.Visible = true;
            this.col_Shipment.VisibleIndex = 9;
            this.col_Shipment.Width = 98;
            // 
            // col_DateEnd
            // 
            this.col_DateEnd.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DateEnd.AppearanceHeader.Options.UseFont = true;
            this.col_DateEnd.Caption = "Hạn dùng";
            this.col_DateEnd.FieldName = "DateEnd";
            this.col_DateEnd.Name = "col_DateEnd";
            this.col_DateEnd.OptionsColumn.AllowEdit = false;
            this.col_DateEnd.OptionsColumn.AllowFocus = false;
            this.col_DateEnd.OptionsColumn.ReadOnly = true;
            this.col_DateEnd.Visible = true;
            this.col_DateEnd.VisibleIndex = 10;
            this.col_DateEnd.Width = 97;
            // 
            // col_VendorName
            // 
            this.col_VendorName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_VendorName.AppearanceHeader.Options.UseFont = true;
            this.col_VendorName.Caption = "Đơn vị cung cấp";
            this.col_VendorName.FieldName = "VendorName";
            this.col_VendorName.Name = "col_VendorName";
            this.col_VendorName.OptionsColumn.AllowEdit = false;
            this.col_VendorName.OptionsColumn.AllowFocus = false;
            this.col_VendorName.OptionsColumn.ReadOnly = true;
            this.col_VendorName.Visible = true;
            this.col_VendorName.VisibleIndex = 13;
            this.col_VendorName.Width = 121;
            // 
            // col_RepositoryName
            // 
            this.col_RepositoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RepositoryName.AppearanceHeader.Options.UseFont = true;
            this.col_RepositoryName.Caption = "Kho";
            this.col_RepositoryName.FieldName = "RepositoryName";
            this.col_RepositoryName.Name = "col_RepositoryName";
            this.col_RepositoryName.OptionsColumn.AllowEdit = false;
            this.col_RepositoryName.OptionsColumn.AllowFocus = false;
            this.col_RepositoryName.OptionsColumn.ReadOnly = true;
            this.col_RepositoryName.Visible = true;
            this.col_RepositoryName.VisibleIndex = 14;
            this.col_RepositoryName.Width = 128;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkExport);
            this.panelControl1.Controls.Add(this.controlDate);
            this.panelControl1.Controls.Add(this.butPrintBC);
            this.panelControl1.Controls.Add(this.lbRepository);
            this.panelControl1.Controls.Add(this.butCount);
            this.panelControl1.Controls.Add(this.cbxRepository);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1011, 36);
            this.panelControl1.TabIndex = 0;
            // 
            // chkExport
            // 
            this.chkExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExport.Location = new System.Drawing.Point(751, 8);
            this.chkExport.Name = "chkExport";
            this.chkExport.Properties.Caption = "Xuất kho";
            this.chkExport.Size = new System.Drawing.Size(68, 19);
            this.chkExport.TabIndex = 16;
            this.chkExport.CheckedChanged += new System.EventHandler(this.chkExport_CheckedChanged);
            // 
            // controlDate
            // 
            this.controlDate.Location = new System.Drawing.Point(5, 5);
            this.controlDate.Name = "controlDate";
            this.controlDate.Size = new System.Drawing.Size(638, 25);
            this.controlDate.TabIndex = 15;
            // 
            // butPrintBC
            // 
            this.butPrintBC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrintBC.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrintBC.Image = ((System.Drawing.Image)(resources.GetObject("butPrintBC.Image")));
            this.butPrintBC.Location = new System.Drawing.Point(905, 6);
            this.butPrintBC.Name = "butPrintBC";
            this.butPrintBC.Size = new System.Drawing.Size(103, 23);
            this.butPrintBC.TabIndex = 14;
            this.butPrintBC.Text = "Xuất File excel";
            this.butPrintBC.Click += new System.EventHandler(this.butPrintBC_Click);
            // 
            // lbRepository
            // 
            this.lbRepository.Location = new System.Drawing.Point(649, 11);
            this.lbRepository.Name = "lbRepository";
            this.lbRepository.Size = new System.Drawing.Size(52, 13);
            this.lbRepository.TabIndex = 12;
            this.lbRepository.Text = "Kho nhập :";
            // 
            // butCount
            // 
            this.butCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(821, 6);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(83, 23);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Lấy dữ liệu";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // cbxRepository
            // 
            this.cbxRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRepository.EditValue = "";
            this.cbxRepository.Location = new System.Drawing.Point(709, 8);
            this.cbxRepository.Name = "cbxRepository";
            this.cbxRepository.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxRepository.Properties.NullText = "Chọn Kho";
            this.cbxRepository.Size = new System.Drawing.Size(39, 20);
            this.cbxRepository.TabIndex = 11;
            // 
            // frmTHBangKeNhapXuatThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 526);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTHBangKeNhapXuatThuoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo nhập xuất tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoCao_NXT_TH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRepository.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraEditors.LabelControl lbRepository;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraEditors.SimpleButton butPrintBC;
        private UserControlDateTimes.UserControlDateTimes controlDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceNnumber;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ImportDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_Shipment;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorName;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbxRepository;
        private DevExpress.XtraEditors.CheckEdit chkExport;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryName;
    }
}