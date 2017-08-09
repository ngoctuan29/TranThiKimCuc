namespace Ps.Clinic.Entry
{
    partial class frmXNHenTraKetQua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXNHenTraKetQua));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lbPatientInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.butRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.lkupTransfer = new DevExpress.XtraEditors.LookUpEdit();
            this.lkupStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.butPrintPrescription = new DevExpress.XtraEditors.SimpleButton();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtIDMau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtimeTo = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.butDelete = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repchk_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_ReceiptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SampleTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repchk_SampleTransfer = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkupXetNghiem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTransfer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDMau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_Chon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_SampleTransfer)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupXetNghiem.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 565);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(724, 31);
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
            this.ribbon.Size = new System.Drawing.Size(724, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // lbPatientInfo
            // 
            this.lbPatientInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPatientInfo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbPatientInfo.Location = new System.Drawing.Point(78, 30);
            this.lbPatientInfo.Name = "lbPatientInfo";
            this.lbPatientInfo.Size = new System.Drawing.Size(117, 13);
            this.lbPatientInfo.TabIndex = 1034;
            this.lbPatientInfo.Text = "Thông Tin Bệnh Nhân";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(8, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nội dung hẹn";
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(8, 53);
            this.txtContent.Name = "txtContent";
            this.txtContent.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Properties.Appearance.Options.UseFont = true;
            this.txtContent.Size = new System.Drawing.Size(707, 43);
            this.txtContent.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl4.Location = new System.Drawing.Point(439, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 14);
            this.labelControl4.TabIndex = 1040;
            this.labelControl4.Text = "Mẫu gửi :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl3.Location = new System.Drawing.Point(235, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(105, 14);
            this.labelControl3.TabIndex = 1039;
            this.labelControl3.Text = "Tình trạng T.Hiện :";
            // 
            // butRefesh
            // 
            this.butRefesh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butRefesh.Appearance.Options.UseFont = true;
            this.butRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butRefesh.Image = ((System.Drawing.Image)(resources.GetObject("butRefesh.Image")));
            this.butRefesh.Location = new System.Drawing.Point(588, 13);
            this.butRefesh.Name = "butRefesh";
            this.butRefesh.Size = new System.Drawing.Size(98, 23);
            this.butRefesh.TabIndex = 1038;
            this.butRefesh.Text = "Lấy Dữ Liệu";
            this.butRefesh.Click += new System.EventHandler(this.butRefesh_Click);
            // 
            // lkupTransfer
            // 
            this.lkupTransfer.EditValue = "";
            this.lkupTransfer.Location = new System.Drawing.Point(492, 14);
            this.lkupTransfer.Name = "lkupTransfer";
            this.lkupTransfer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupTransfer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tình Trạng")});
            this.lkupTransfer.Properties.NullText = "";
            this.lkupTransfer.Size = new System.Drawing.Size(92, 20);
            this.lkupTransfer.TabIndex = 1037;
            // 
            // lkupStatus
            // 
            this.lkupStatus.EditValue = "";
            this.lkupStatus.Location = new System.Drawing.Point(345, 14);
            this.lkupStatus.MenuManager = this.ribbon;
            this.lkupStatus.Name = "lkupStatus";
            this.lkupStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tình trạng")});
            this.lkupStatus.Properties.NullText = "";
            this.lkupStatus.Size = new System.Drawing.Size(92, 20);
            this.lkupStatus.TabIndex = 1037;
            // 
            // butPrintPrescription
            // 
            this.butPrintPrescription.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butPrintPrescription.Appearance.Options.UseFont = true;
            this.butPrintPrescription.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrintPrescription.Image = ((System.Drawing.Image)(resources.GetObject("butPrintPrescription.Image")));
            this.butPrintPrescription.Location = new System.Drawing.Point(248, 4);
            this.butPrintPrescription.Name = "butPrintPrescription";
            this.butPrintPrescription.Size = new System.Drawing.Size(106, 23);
            this.butPrintPrescription.TabIndex = 1035;
            this.butPrintPrescription.Text = "In Phiếu Hẹn";
            this.butPrintPrescription.ToolTip = "In Phiếu Hẹn";
            this.butPrintPrescription.Click += new System.EventHandler(this.butPrintPrescription_Click);
            // 
            // butExit
            // 
            this.butExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butExit.Appearance.Options.UseFont = true;
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(431, 4);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 1030;
            this.butExit.Text = "Thoát";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butSave
            // 
            this.butSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butSave.Appearance.Options.UseFont = true;
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(184, 4);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(63, 23);
            this.butSave.TabIndex = 1029;
            this.butSave.Text = "Lưu";
            this.butSave.ToolTip = "Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl16);
            this.panelControl2.Controls.Add(this.txtIDMau);
            this.panelControl2.Controls.Add(this.txtContent);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.labelControl17);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.dtimeFrom);
            this.panelControl2.Controls.Add(this.dtimeTo);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(3, 17);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(718, 118);
            this.panelControl2.TabIndex = 1038;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl16.Location = new System.Drawing.Point(8, 7);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(80, 14);
            this.labelControl16.TabIndex = 1032;
            this.labelControl16.Text = "Ngày lấy mẫu :";
            // 
            // txtIDMau
            // 
            this.txtIDMau.EditValue = "";
            this.txtIDMau.Location = new System.Drawing.Point(492, 5);
            this.txtIDMau.Name = "txtIDMau";
            this.txtIDMau.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtIDMau.Properties.Appearance.Options.UseForeColor = true;
            this.txtIDMau.Properties.NullText = "0";
            this.txtIDMau.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIDMau.Size = new System.Drawing.Size(89, 20);
            this.txtIDMau.TabIndex = 1042;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl17.Location = new System.Drawing.Point(240, 7);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(100, 14);
            this.labelControl17.TabIndex = 1031;
            this.labelControl17.Text = "Ngày trả kết quả :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl5.Location = new System.Drawing.Point(444, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 14);
            this.labelControl5.TabIndex = 1041;
            this.labelControl5.Text = "ID Mẫu :";
            // 
            // dtimeFrom
            // 
            this.dtimeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeFrom.Location = new System.Drawing.Point(94, 4);
            this.dtimeFrom.Name = "dtimeFrom";
            this.dtimeFrom.Size = new System.Drawing.Size(98, 21);
            this.dtimeFrom.TabIndex = 1034;
            // 
            // dtimeTo
            // 
            this.dtimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeTo.Location = new System.Drawing.Point(343, 4);
            this.dtimeTo.Name = "dtimeTo";
            this.dtimeTo.Size = new System.Drawing.Size(94, 21);
            this.dtimeTo.TabIndex = 1033;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Location = new System.Drawing.Point(8, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 14);
            this.labelControl2.TabIndex = 1043;
            this.labelControl2.Text = "Các xét nghiệm";
            // 
            // butDelete
            // 
            this.butDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butDelete.Appearance.Options.UseFont = true;
            this.butDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butDelete.Image = ((System.Drawing.Image)(resources.GetObject("butDelete.Image")));
            this.butDelete.Location = new System.Drawing.Point(355, 4);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 1036;
            this.butDelete.Text = "Hủy Hẹn";
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repchk_Chon,
            this.repchk_SampleTransfer});
            this.gridControl_Result.Size = new System.Drawing.Size(718, 301);
            this.gridControl_Result.TabIndex = 1;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServiceCode,
            this.col_ServiceName,
            this.col_Chon,
            this.col_ReceiptID,
            this.col_Status,
            this.col_SampleTransfer});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Result.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView_Result.OptionsView.ShowGroupPanel = false;
            this.gridView_Result.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Result.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // col_ServiceCode
            // 
            this.col_ServiceCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.col_ServiceCode.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceCode.Caption = "Mả XN";
            this.col_ServiceCode.FieldName = "ServiceCode";
            this.col_ServiceCode.Name = "col_ServiceCode";
            // 
            // col_ServiceName
            // 
            this.col_ServiceName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_ServiceName.AppearanceCell.Options.UseFont = true;
            this.col_ServiceName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.col_ServiceName.AppearanceHeader.Options.UseFont = true;
            this.col_ServiceName.Caption = " Xét nghiệm";
            this.col_ServiceName.FieldName = "ServiceName";
            this.col_ServiceName.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.col_ServiceName.Name = "col_ServiceName";
            this.col_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_ServiceName.Visible = true;
            this.col_ServiceName.VisibleIndex = 0;
            this.col_ServiceName.Width = 458;
            // 
            // col_Chon
            // 
            this.col_Chon.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_Chon.AppearanceCell.Options.UseFont = true;
            this.col_Chon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.col_Chon.AppearanceHeader.Options.UseFont = true;
            this.col_Chon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Chon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Chon.Caption = "Chọn";
            this.col_Chon.ColumnEdit = this.repchk_Chon;
            this.col_Chon.FieldName = "Chon";
            this.col_Chon.Name = "col_Chon";
            this.col_Chon.Visible = true;
            this.col_Chon.VisibleIndex = 3;
            this.col_Chon.Width = 55;
            // 
            // repchk_Chon
            // 
            this.repchk_Chon.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.repchk_Chon.AppearanceReadOnly.Options.UseFont = true;
            this.repchk_Chon.AutoHeight = false;
            this.repchk_Chon.DisplayValueChecked = "True";
            this.repchk_Chon.DisplayValueGrayed = "False";
            this.repchk_Chon.DisplayValueUnchecked = "False";
            this.repchk_Chon.Name = "repchk_Chon";
            this.repchk_Chon.ValueGrayed = false;
            // 
            // col_ReceiptID
            // 
            this.col_ReceiptID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.col_ReceiptID.AppearanceCell.Options.UseFont = true;
            this.col_ReceiptID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.col_ReceiptID.AppearanceHeader.Options.UseFont = true;
            this.col_ReceiptID.Caption = "ID Chỉ định";
            this.col_ReceiptID.FieldName = "ReceiptID";
            this.col_ReceiptID.Name = "col_ReceiptID";
            // 
            // col_Status
            // 
            this.col_Status.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_Status.AppearanceCell.Options.UseFont = true;
            this.col_Status.AppearanceCell.Options.UseTextOptions = true;
            this.col_Status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Status.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.col_Status.AppearanceHeader.Options.UseFont = true;
            this.col_Status.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Status.Caption = "Tình Trạng";
            this.col_Status.FieldName = "Status";
            this.col_Status.Name = "col_Status";
            this.col_Status.OptionsColumn.AllowEdit = false;
            this.col_Status.OptionsColumn.AllowFocus = false;
            this.col_Status.OptionsColumn.ReadOnly = true;
            this.col_Status.Visible = true;
            this.col_Status.VisibleIndex = 1;
            this.col_Status.Width = 93;
            // 
            // col_SampleTransfer
            // 
            this.col_SampleTransfer.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_SampleTransfer.AppearanceCell.Options.UseFont = true;
            this.col_SampleTransfer.AppearanceCell.Options.UseTextOptions = true;
            this.col_SampleTransfer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SampleTransfer.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.col_SampleTransfer.AppearanceHeader.Options.UseFont = true;
            this.col_SampleTransfer.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SampleTransfer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SampleTransfer.Caption = "Mẫu gửi";
            this.col_SampleTransfer.ColumnEdit = this.repchk_SampleTransfer;
            this.col_SampleTransfer.FieldName = "SampleTransfer";
            this.col_SampleTransfer.Name = "col_SampleTransfer";
            this.col_SampleTransfer.OptionsColumn.AllowEdit = false;
            this.col_SampleTransfer.OptionsColumn.AllowFocus = false;
            this.col_SampleTransfer.OptionsColumn.ReadOnly = true;
            this.col_SampleTransfer.Visible = true;
            this.col_SampleTransfer.VisibleIndex = 2;
            this.col_SampleTransfer.Width = 58;
            // 
            // repchk_SampleTransfer
            // 
            this.repchk_SampleTransfer.AutoHeight = false;
            this.repchk_SampleTransfer.DisplayValueChecked = "1";
            this.repchk_SampleTransfer.DisplayValueGrayed = "0";
            this.repchk_SampleTransfer.DisplayValueUnchecked = "0";
            this.repchk_SampleTransfer.Name = "repchk_SampleTransfer";
            this.repchk_SampleTransfer.ValueChecked = 1;
            this.repchk_SampleTransfer.ValueGrayed = 0;
            this.repchk_SampleTransfer.ValueUnchecked = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkupXetNghiem);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.lkupStatus);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.lkupTransfer);
            this.groupBox1.Controls.Add(this.butRefesh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 40);
            this.groupBox1.TabIndex = 1042;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc Dữ Liệu";
            // 
            // lkupXetNghiem
            // 
            this.lkupXetNghiem.EditValue = "";
            this.lkupXetNghiem.Location = new System.Drawing.Point(90, 14);
            this.lkupXetNghiem.MenuManager = this.ribbon;
            this.lkupXetNghiem.Name = "lkupXetNghiem";
            this.lkupXetNghiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupXetNghiem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryCode", "ServiceCategoryCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryName", "Xét Nghiệm")});
            this.lkupXetNghiem.Properties.NullText = "";
            this.lkupXetNghiem.Size = new System.Drawing.Size(142, 20);
            this.lkupXetNghiem.TabIndex = 1042;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl6.Location = new System.Drawing.Point(15, 17);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(71, 14);
            this.labelControl6.TabIndex = 1041;
            this.labelControl6.Text = "Xét nghiệm :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panelControl3);
            this.groupBox2.Controls.Add(this.panelControl1);
            this.groupBox2.Controls.Add(this.panelControl2);
            this.groupBox2.Location = new System.Drawing.Point(0, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 471);
            this.groupBox2.TabIndex = 1042;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Hẹn Trả Kết Quả";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.gridControl_Result);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 135);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(718, 301);
            this.panelControl3.TabIndex = 1040;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.butSave);
            this.panelControl1.Controls.Add(this.butPrintPrescription);
            this.panelControl1.Controls.Add(this.butExit);
            this.panelControl1.Controls.Add(this.butDelete);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(3, 436);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(718, 32);
            this.panelControl1.TabIndex = 1039;
            // 
            // frmXNHenTraKetQua
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbPatientInfo);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXNHenTraKetQua";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Hẹn Trả Kết Quả Xét Nghiệm";
            this.Load += new System.EventHandler(this.frmXNHenTraKetQua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTransfer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDMau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_Chon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_SampleTransfer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupXetNghiem.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.LabelControl lbPatientInfo;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butPrintPrescription;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repchk_Chon;
        private DevExpress.XtraGrid.Columns.GridColumn col_ReceiptID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repchk_SampleTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn col_SampleTransfer;
        private DevExpress.XtraEditors.LookUpEdit lkupStatus;
        private DevExpress.XtraEditors.LookUpEdit lkupTransfer;
        private DevExpress.XtraEditors.SimpleButton butRefesh;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton butDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit txtIDMau;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.DateTimePicker dtimeFrom;
        private System.Windows.Forms.DateTimePicker dtimeTo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lkupXetNghiem;
    }
}