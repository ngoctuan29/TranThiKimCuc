namespace Ps.Clinic.Entry
{
    partial class frmHen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHen));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.repCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_WaitingList = new DevExpress.XtraGrid.GridControl();
            this.gridView_WaitingList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_List_MedicalRecordCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientReceiveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientGenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientBirthyear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_RowIDMedicinesFor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_List_DateApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
            this.dtfrom = new DevExpress.XtraEditors.DateEdit();
            this.butReload = new DevExpress.XtraEditors.SimpleButton();
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_WaitingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_WaitingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            this.SuspendLayout();
            // 
            // repCheck
            // 
            this.repCheck.AutoHeight = false;
            this.repCheck.DisplayValueChecked = "1";
            this.repCheck.DisplayValueGrayed = "0";
            this.repCheck.DisplayValueUnchecked = "0";
            this.repCheck.Name = "repCheck";
            this.repCheck.ValueChecked = 1;
            this.repCheck.ValueGrayed = 0;
            this.repCheck.ValueUnchecked = 0;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1086, 27);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 562);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1086, 33);
            this.panelControl1.TabIndex = 12;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(501, 6);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(84, 23);
            this.butSave.TabIndex = 2;
            this.butSave.Text = "Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl_WaitingList);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grMain);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1086, 535);
            this.splitContainerControl1.SplitterPosition = 398;
            this.splitContainerControl1.TabIndex = 16;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_WaitingList
            // 
            this.gridControl_WaitingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_WaitingList.Location = new System.Drawing.Point(0, 30);
            this.gridControl_WaitingList.MainView = this.gridView_WaitingList;
            this.gridControl_WaitingList.Name = "gridControl_WaitingList";
            this.gridControl_WaitingList.Size = new System.Drawing.Size(398, 505);
            this.gridControl_WaitingList.TabIndex = 9;
            this.gridControl_WaitingList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_WaitingList});
            // 
            // gridView_WaitingList
            // 
            this.gridView_WaitingList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_List_MedicalRecordCode,
            this.col_List_PatientReceiveID,
            this.col_List_DepartmentName,
            this.col_List_PatientCode,
            this.col_List_PatientName,
            this.col_List_PatientGenderName,
            this.col_List_PatientBirthyear,
            this.col_List_PatientAge,
            this.col_List_PatientAddress,
            this.col_List_ObjectCode,
            this.col_List_ObjectName,
            this.col_List_RowIDMedicinesFor,
            this.col_List_DateApproved});
            this.gridView_WaitingList.GridControl = this.gridControl_WaitingList;
            this.gridView_WaitingList.Name = "gridView_WaitingList";
            this.gridView_WaitingList.OptionsFind.ShowClearButton = false;
            this.gridView_WaitingList.OptionsView.ColumnAutoWidth = false;
            this.gridView_WaitingList.OptionsView.ShowFooter = true;
            this.gridView_WaitingList.OptionsView.ShowGroupPanel = false;
            this.gridView_WaitingList.OptionsView.ShowIndicator = false;
            this.gridView_WaitingList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_WaitingList.DoubleClick += new System.EventHandler(this.gridView_WaitingList_DoubleClick);
            // 
            // col_List_MedicalRecordCode
            // 
            this.col_List_MedicalRecordCode.Caption = "Receipt_Code";
            this.col_List_MedicalRecordCode.FieldName = "MedicalRecordCode";
            this.col_List_MedicalRecordCode.Name = "col_List_MedicalRecordCode";
            this.col_List_MedicalRecordCode.OptionsColumn.AllowEdit = false;
            this.col_List_MedicalRecordCode.OptionsColumn.AllowFocus = false;
            this.col_List_MedicalRecordCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_MedicalRecordCode.OptionsColumn.ReadOnly = true;
            // 
            // col_List_PatientReceiveID
            // 
            this.col_List_PatientReceiveID.Caption = "Id Tiếp nhận";
            this.col_List_PatientReceiveID.FieldName = "PatientReceiveID";
            this.col_List_PatientReceiveID.Name = "col_List_PatientReceiveID";
            this.col_List_PatientReceiveID.OptionsColumn.AllowEdit = false;
            this.col_List_PatientReceiveID.OptionsColumn.AllowFocus = false;
            this.col_List_PatientReceiveID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientReceiveID.OptionsColumn.ReadOnly = true;
            // 
            // col_List_DepartmentName
            // 
            this.col_List_DepartmentName.Caption = "Phòng khám";
            this.col_List_DepartmentName.FieldName = "DepartmentName";
            this.col_List_DepartmentName.Name = "col_List_DepartmentName";
            this.col_List_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_List_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_List_DepartmentName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_DepartmentName.OptionsColumn.ReadOnly = true;
            this.col_List_DepartmentName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_List_DepartmentName.Visible = true;
            this.col_List_DepartmentName.VisibleIndex = 5;
            this.col_List_DepartmentName.Width = 149;
            // 
            // col_List_PatientCode
            // 
            this.col_List_PatientCode.Caption = "Mã bn";
            this.col_List_PatientCode.FieldName = "PatientCode";
            this.col_List_PatientCode.Name = "col_List_PatientCode";
            this.col_List_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_List_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_List_PatientCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_List_PatientCode.Visible = true;
            this.col_List_PatientCode.VisibleIndex = 0;
            this.col_List_PatientCode.Width = 92;
            // 
            // col_List_PatientName
            // 
            this.col_List_PatientName.Caption = "Họ tên";
            this.col_List_PatientName.FieldName = "PatientName";
            this.col_List_PatientName.Name = "col_List_PatientName";
            this.col_List_PatientName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientName.Visible = true;
            this.col_List_PatientName.VisibleIndex = 1;
            this.col_List_PatientName.Width = 135;
            // 
            // col_List_PatientGenderName
            // 
            this.col_List_PatientGenderName.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientGenderName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientGenderName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientGenderName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientGenderName.Caption = "Giới tính";
            this.col_List_PatientGenderName.FieldName = "PatientGenderName";
            this.col_List_PatientGenderName.Name = "col_List_PatientGenderName";
            this.col_List_PatientGenderName.OptionsColumn.AllowEdit = false;
            this.col_List_PatientGenderName.OptionsColumn.AllowFocus = false;
            this.col_List_PatientGenderName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientGenderName.OptionsColumn.ReadOnly = true;
            this.col_List_PatientGenderName.Visible = true;
            this.col_List_PatientGenderName.VisibleIndex = 2;
            this.col_List_PatientGenderName.Width = 61;
            // 
            // col_List_PatientBirthyear
            // 
            this.col_List_PatientBirthyear.AppearanceCell.Options.UseTextOptions = true;
            this.col_List_PatientBirthyear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthyear.AppearanceHeader.Options.UseTextOptions = true;
            this.col_List_PatientBirthyear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_List_PatientBirthyear.Caption = "Năm sinh";
            this.col_List_PatientBirthyear.FieldName = "PatientBirthyear";
            this.col_List_PatientBirthyear.Name = "col_List_PatientBirthyear";
            this.col_List_PatientBirthyear.OptionsColumn.AllowEdit = false;
            this.col_List_PatientBirthyear.OptionsColumn.AllowFocus = false;
            this.col_List_PatientBirthyear.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientBirthyear.OptionsColumn.ReadOnly = true;
            this.col_List_PatientBirthyear.Visible = true;
            this.col_List_PatientBirthyear.VisibleIndex = 3;
            // 
            // col_List_PatientAge
            // 
            this.col_List_PatientAge.Caption = "Tuổi";
            this.col_List_PatientAge.FieldName = "PatientAge";
            this.col_List_PatientAge.Name = "col_List_PatientAge";
            this.col_List_PatientAge.OptionsColumn.AllowEdit = false;
            this.col_List_PatientAge.OptionsColumn.AllowFocus = false;
            this.col_List_PatientAge.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientAge.OptionsColumn.ReadOnly = true;
            this.col_List_PatientAge.Visible = true;
            this.col_List_PatientAge.VisibleIndex = 4;
            this.col_List_PatientAge.Width = 39;
            // 
            // col_List_PatientAddress
            // 
            this.col_List_PatientAddress.Caption = "Địa chỉ";
            this.col_List_PatientAddress.FieldName = "PatientAddress";
            this.col_List_PatientAddress.Name = "col_List_PatientAddress";
            this.col_List_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_List_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_List_PatientAddress.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_PatientAddress.OptionsColumn.ReadOnly = true;
            this.col_List_PatientAddress.Width = 135;
            // 
            // col_List_ObjectCode
            // 
            this.col_List_ObjectCode.Caption = "Mã Đối Tượng";
            this.col_List_ObjectCode.FieldName = "ObjectCode";
            this.col_List_ObjectCode.Name = "col_List_ObjectCode";
            this.col_List_ObjectCode.OptionsColumn.AllowEdit = false;
            this.col_List_ObjectCode.OptionsColumn.AllowFocus = false;
            this.col_List_ObjectCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_List_ObjectCode.OptionsColumn.ReadOnly = true;
            // 
            // col_List_ObjectName
            // 
            this.col_List_ObjectName.Caption = "Đối tượng";
            this.col_List_ObjectName.FieldName = "ObjectName";
            this.col_List_ObjectName.Name = "col_List_ObjectName";
            // 
            // col_List_RowIDMedicinesFor
            // 
            this.col_List_RowIDMedicinesFor.Caption = "RowIDMedicinesFor";
            this.col_List_RowIDMedicinesFor.FieldName = "RowIDMedicinesFor";
            this.col_List_RowIDMedicinesFor.Name = "col_List_RowIDMedicinesFor";
            // 
            // col_List_DateApproved
            // 
            this.col_List_DateApproved.Caption = "Ngày duyệt";
            this.col_List_DateApproved.DisplayFormat.FormatString = "dd/MM/yy HH:mm:ss";
            this.col_List_DateApproved.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_List_DateApproved.FieldName = "DateApproved";
            this.col_List_DateApproved.Name = "col_List_DateApproved";
            this.col_List_DateApproved.OptionsColumn.AllowEdit = false;
            this.col_List_DateApproved.OptionsColumn.AllowFocus = false;
            this.col_List_DateApproved.OptionsColumn.ReadOnly = true;
            this.col_List_DateApproved.Width = 111;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl38);
            this.panelControl2.Controls.Add(this.dtTo);
            this.panelControl2.Controls.Add(this.labelControl39);
            this.panelControl2.Controls.Add(this.dtfrom);
            this.panelControl2.Controls.Add(this.butReload);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(398, 30);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl38
            // 
            this.labelControl38.Location = new System.Drawing.Point(6, 8);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(44, 13);
            this.labelControl38.TabIndex = 1024;
            this.labelControl38.Text = "Từ ngày:";
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(225, 5);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtTo.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.dtTo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtTo.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dtTo.Size = new System.Drawing.Size(116, 20);
            this.dtTo.TabIndex = 1022;
            // 
            // labelControl39
            // 
            this.labelControl39.Location = new System.Drawing.Point(171, 8);
            this.labelControl39.Name = "labelControl39";
            this.labelControl39.Size = new System.Drawing.Size(51, 13);
            this.labelControl39.TabIndex = 1023;
            this.labelControl39.Text = "Đến ngày:";
            // 
            // dtfrom
            // 
            this.dtfrom.EditValue = null;
            this.dtfrom.Location = new System.Drawing.Point(53, 5);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtfrom.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.dtfrom.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtfrom.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.dtfrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtfrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtfrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtfrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtfrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtfrom.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dtfrom.Size = new System.Drawing.Size(116, 20);
            this.dtfrom.TabIndex = 1021;
            // 
            // butReload
            // 
            this.butReload.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butReload.Dock = System.Windows.Forms.DockStyle.Right;
            this.butReload.Image = ((System.Drawing.Image)(resources.GetObject("butReload.Image")));
            this.butReload.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.butReload.Location = new System.Drawing.Point(347, 2);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(49, 26);
            this.butReload.TabIndex = 0;
            this.butReload.TabStop = false;
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.schedulerControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(683, 535);
            this.grMain.TabIndex = 3;
            this.grMain.Text = "Thông tin hẹn khám";
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Location = new System.Drawing.Point(15, 23);
            this.schedulerControl1.MenuManager = this.ribbon;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(656, 247);
            this.schedulerControl1.Start = new System.DateTime(2014, 9, 2, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.AllDayAreaScrollBarVisible = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.AllDayAreaScrollBarVisible = false;
            this.schedulerControl1.Views.TimelineView.TimelineScrollBarVisible = false;
            this.schedulerControl1.Views.WorkWeekView.AllDayAreaScrollBarVisible = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.InplaceEditorShowing += new DevExpress.XtraScheduler.InplaceEditorEventHandler(this.schedulerControl1_InplaceEditorShowing);
            // 
            // frmHen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 595);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHen";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Hẹn Khám Bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_WaitingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_WaitingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheck;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton butReload;
        private DevExpress.XtraGrid.GridControl gridControl_WaitingList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_WaitingList;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_MedicalRecordCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientReceiveID;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientGenderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientBirthyear;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientAge;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_ObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_RowIDMedicinesFor;
        private DevExpress.XtraGrid.Columns.GridColumn col_List_DateApproved;
        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.DateEdit dtfrom;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
    }
}