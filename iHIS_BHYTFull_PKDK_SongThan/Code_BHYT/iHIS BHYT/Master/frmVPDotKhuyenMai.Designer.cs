namespace Ps.Clinic.Master
{
    partial class frmVPDotKhuyenMai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVPDotKhuyenMai));
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDate_DateFrom = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_DateTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDate_DateTo = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChk_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateFrom.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateTo.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChk_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChk_Hide,
            this.repDate_DateFrom,
            this.repDate_DateTo});
            this.gridControl_Data.Size = new System.Drawing.Size(692, 441);
            this.gridControl_Data.TabIndex = 2;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            this.gridControl_Data.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Data_ProcessGridKey);
            // 
            // gridView_Data
            // 
            this.gridView_Data.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Data.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Name,
            this.col_RowID,
            this.col_DateFrom,
            this.col_DateTo,
            this.col_Hide,
            this.col_EmployeeCode});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "Thêm mới đợt khuyến mãi ...";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Data_InvalidRowException);
            this.gridView_Data.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Data_ValidateRow);
            this.gridView_Data.DoubleClick += new System.EventHandler(this.gridView_Data_DoubleClick);
            // 
            // col_Name
            // 
            this.col_Name.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Name.AppearanceHeader.Options.UseFont = true;
            this.col_Name.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Name.Caption = "Nội dung khuyến mãi";
            this.col_Name.FieldName = "Name";
            this.col_Name.Name = "col_Name";
            this.col_Name.Visible = true;
            this.col_Name.VisibleIndex = 1;
            this.col_Name.Width = 273;
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RowID.AppearanceHeader.Options.UseFont = true;
            this.col_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.Caption = "ID Đợt";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowEdit = false;
            this.col_RowID.OptionsColumn.AllowFocus = false;
            this.col_RowID.OptionsColumn.ReadOnly = true;
            this.col_RowID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowID", "Khoản: {#,##}")});
            this.col_RowID.Visible = true;
            this.col_RowID.VisibleIndex = 0;
            this.col_RowID.Width = 49;
            // 
            // col_DateFrom
            // 
            this.col_DateFrom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DateFrom.AppearanceHeader.Options.UseFont = true;
            this.col_DateFrom.Caption = "Ngày bắt đầu";
            this.col_DateFrom.ColumnEdit = this.repDate_DateFrom;
            this.col_DateFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_DateFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_DateFrom.FieldName = "DateFrom";
            this.col_DateFrom.Name = "col_DateFrom";
            this.col_DateFrom.Visible = true;
            this.col_DateFrom.VisibleIndex = 2;
            this.col_DateFrom.Width = 79;
            // 
            // repDate_DateFrom
            // 
            this.repDate_DateFrom.AutoHeight = false;
            this.repDate_DateFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDate_DateFrom.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDate_DateFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repDate_DateFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repDate_DateFrom.EditFormat.FormatString = "dd/MM/yyyy";
            this.repDate_DateFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repDate_DateFrom.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repDate_DateFrom.Mask.EditMask = "dd/MM/yyyy";
            this.repDate_DateFrom.Name = "repDate_DateFrom";
            this.repDate_DateFrom.NullDate = new System.DateTime(2016, 7, 6, 1, 24, 37, 513);
            this.repDate_DateFrom.NullDateCalendarValue = new System.DateTime(2016, 7, 6, 1, 39, 22, 0);
            this.repDate_DateFrom.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Multiple;
            this.repDate_DateFrom.TodayDate = new System.DateTime(2016, 7, 6, 1, 52, 28, 0);
            // 
            // col_DateTo
            // 
            this.col_DateTo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DateTo.AppearanceHeader.Options.UseFont = true;
            this.col_DateTo.Caption = "Ngày kết thúc";
            this.col_DateTo.ColumnEdit = this.repDate_DateTo;
            this.col_DateTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_DateTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_DateTo.FieldName = "DateTo";
            this.col_DateTo.Name = "col_DateTo";
            this.col_DateTo.Visible = true;
            this.col_DateTo.VisibleIndex = 3;
            this.col_DateTo.Width = 82;
            // 
            // repDate_DateTo
            // 
            this.repDate_DateTo.AutoHeight = false;
            this.repDate_DateTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDate_DateTo.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDate_DateTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repDate_DateTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repDate_DateTo.EditFormat.FormatString = "dd/MM/yyyy";
            this.repDate_DateTo.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repDate_DateTo.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repDate_DateTo.Mask.EditMask = "dd/MM/yyyy";
            this.repDate_DateTo.Name = "repDate_DateTo";
            this.repDate_DateTo.NullDate = new System.DateTime(2016, 7, 6, 1, 29, 33, 948);
            this.repDate_DateTo.NullDateCalendarValue = new System.DateTime(2016, 7, 6, 1, 39, 33, 0);
            this.repDate_DateTo.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Multiple;
            this.repDate_DateTo.TodayDate = new System.DateTime(2016, 7, 6, 1, 52, 41, 0);
            // 
            // col_Hide
            // 
            this.col_Hide.AppearanceCell.Options.UseTextOptions = true;
            this.col_Hide.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Hide.AppearanceHeader.Options.UseFont = true;
            this.col_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.Caption = "Hết khuyến mãi";
            this.col_Hide.ColumnEdit = this.repChk_Hide;
            this.col_Hide.FieldName = "Hide";
            this.col_Hide.Name = "col_Hide";
            this.col_Hide.Visible = true;
            this.col_Hide.VisibleIndex = 4;
            this.col_Hide.Width = 91;
            // 
            // repChk_Hide
            // 
            this.repChk_Hide.AutoHeight = false;
            this.repChk_Hide.DisplayValueChecked = "1";
            this.repChk_Hide.DisplayValueGrayed = "0";
            this.repChk_Hide.DisplayValueUnchecked = "0";
            this.repChk_Hide.Name = "repChk_Hide";
            this.repChk_Hide.ValueChecked = 1;
            this.repChk_Hide.ValueGrayed = 0;
            this.repChk_Hide.ValueUnchecked = 0;
            // 
            // col_EmployeeCode
            // 
            this.col_EmployeeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_EmployeeCode.AppearanceHeader.Options.UseFont = true;
            this.col_EmployeeCode.Caption = "User Cập Nhật";
            this.col_EmployeeCode.FieldName = "EmployeeCode";
            this.col_EmployeeCode.Name = "col_EmployeeCode";
            this.col_EmployeeCode.OptionsColumn.AllowEdit = false;
            this.col_EmployeeCode.OptionsColumn.AllowFocus = false;
            this.col_EmployeeCode.OptionsColumn.ReadOnly = true;
            this.col_EmployeeCode.Visible = true;
            this.col_EmployeeCode.VisibleIndex = 5;
            this.col_EmployeeCode.Width = 102;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Data);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(696, 466);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Khuyễn Mãi Giảm Giá";
            // 
            // frmVPDotKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 466);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVPDotKhuyenMai";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo hướng dẫn dùng thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVPDotKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateFrom.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateTo.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate_DateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChk_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateFrom;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateTo;
        private DevExpress.XtraGrid.Columns.GridColumn col_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChk_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repDate_DateFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repDate_DateTo;
    }
}