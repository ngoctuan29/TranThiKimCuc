namespace Ps.Clinic.Entry
{
    partial class frmRelationPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelationPatient));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tabPage01 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_Detail = new DevExpress.XtraGrid.GridControl();
            this.gridView_Detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Detail_RowIDMenu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_RelationMenu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Detail_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_RelationContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_PatientReceiveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_Age = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_CareerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Detail_MedicalHistory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage02 = new DevExpress.XtraTab.XtraTabPage();
            this.txtContentPattern = new DevExpress.XtraRichEdit.RichEditControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lkupMedicalPattern = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_RelationMenu)).BeginInit();
            this.tabPage02.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupMedicalPattern.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 562);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(898, 31);
            // 
            // ribbon
            // 
            this.ribbon.AllowMdiChildButtons = false;
            this.ribbon.AllowMinimizeRibbon = false;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(898, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(348, 3);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 25);
            this.butExit.TabIndex = 1030;
            this.butExit.Text = "Thoát";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFooter.Controls.Add(this.butSave);
            this.panelFooter.Controls.Add(this.butExit);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 530);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(898, 32);
            this.panelFooter.TabIndex = 1035;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(424, 3);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(138, 25);
            this.butSave.TabIndex = 1031;
            this.butSave.Text = "Lưu tiền sử trẻ sơ sinh";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.tabMain);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 49);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(898, 481);
            this.panelHeader.TabIndex = 1036;
            // 
            // tabMain
            // 
            this.tabMain.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.tabMain.Appearance.Options.UseFont = true;
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tabPage01;
            this.tabMain.Size = new System.Drawing.Size(894, 477);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPage01,
            this.tabPage02});
            // 
            // tabPage01
            // 
            this.tabPage01.Controls.Add(this.gridControl_Detail);
            this.tabPage01.Name = "tabPage01";
            this.tabPage01.Size = new System.Drawing.Size(888, 448);
            this.tabPage01.Text = "Tiền sử gia đình";
            // 
            // gridControl_Detail
            // 
            this.gridControl_Detail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Detail.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Detail.MainView = this.gridView_Detail;
            this.gridControl_Detail.Name = "gridControl_Detail";
            this.gridControl_Detail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_RelationMenu});
            this.gridControl_Detail.Size = new System.Drawing.Size(888, 448);
            this.gridControl_Detail.TabIndex = 1;
            this.gridControl_Detail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Detail});
            this.gridControl_Detail.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Detail_ProcessGridKey);
            // 
            // gridView_Detail
            // 
            this.gridView_Detail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Detail_RowIDMenu,
            this.col_Detail_RowID,
            this.col_Detail_RelationContent,
            this.col_Detail_EmployeeCode,
            this.col_Detail_PatientReceiveID,
            this.col_Detail_Age,
            this.col_Detail_CareerName,
            this.col_Detail_MedicalHistory});
            this.gridView_Detail.GridControl = this.gridControl_Detail;
            this.gridView_Detail.Name = "gridView_Detail";
            this.gridView_Detail.NewItemRowText = "Thêm mới thông tin gia đình ...";
            this.gridView_Detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Detail.OptionsView.ShowFooter = true;
            this.gridView_Detail.OptionsView.ShowGroupPanel = false;
            this.gridView_Detail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Detail_InvalidRowException);
            this.gridView_Detail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Detail_ValidateRow);
            // 
            // col_Detail_RowIDMenu
            // 
            this.col_Detail_RowIDMenu.Caption = "Quan hệ GĐ";
            this.col_Detail_RowIDMenu.ColumnEdit = this.rep_RelationMenu;
            this.col_Detail_RowIDMenu.FieldName = "RowIDMenu";
            this.col_Detail_RowIDMenu.Name = "col_Detail_RowIDMenu";
            this.col_Detail_RowIDMenu.Visible = true;
            this.col_Detail_RowIDMenu.VisibleIndex = 0;
            this.col_Detail_RowIDMenu.Width = 195;
            // 
            // rep_RelationMenu
            // 
            this.rep_RelationMenu.AutoHeight = false;
            this.rep_RelationMenu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_RelationMenu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RelationTitle", 50, "Nội dung"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeCode", "EmployeeCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.rep_RelationMenu.Name = "rep_RelationMenu";
            this.rep_RelationMenu.NullText = "..";
            this.rep_RelationMenu.ShowFooter = false;
            this.rep_RelationMenu.ShowHeader = false;
            // 
            // col_Detail_RowID
            // 
            this.col_Detail_RowID.Caption = "RowID";
            this.col_Detail_RowID.FieldName = "RowID";
            this.col_Detail_RowID.Name = "col_Detail_RowID";
            this.col_Detail_RowID.Width = 406;
            // 
            // col_Detail_RelationContent
            // 
            this.col_Detail_RelationContent.Caption = "Nội dung";
            this.col_Detail_RelationContent.FieldName = "RelationContent";
            this.col_Detail_RelationContent.Name = "col_Detail_RelationContent";
            this.col_Detail_RelationContent.OptionsColumn.AllowSize = false;
            this.col_Detail_RelationContent.Visible = true;
            this.col_Detail_RelationContent.VisibleIndex = 4;
            this.col_Detail_RelationContent.Width = 404;
            // 
            // col_Detail_EmployeeCode
            // 
            this.col_Detail_EmployeeCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_EmployeeCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_EmployeeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_EmployeeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Detail_EmployeeCode.Caption = "EmployeeCode";
            this.col_Detail_EmployeeCode.FieldName = "EmployeeCode";
            this.col_Detail_EmployeeCode.Name = "col_Detail_EmployeeCode";
            this.col_Detail_EmployeeCode.OptionsColumn.AllowSize = false;
            this.col_Detail_EmployeeCode.Width = 39;
            // 
            // col_Detail_PatientReceiveID
            // 
            this.col_Detail_PatientReceiveID.Caption = "PatientReceiveID";
            this.col_Detail_PatientReceiveID.FieldName = "PatientReceiveID";
            this.col_Detail_PatientReceiveID.Name = "col_Detail_PatientReceiveID";
            // 
            // col_Detail_Age
            // 
            this.col_Detail_Age.AppearanceCell.Options.UseTextOptions = true;
            this.col_Detail_Age.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Detail_Age.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Detail_Age.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Detail_Age.Caption = "Tuổi";
            this.col_Detail_Age.FieldName = "Age";
            this.col_Detail_Age.Name = "col_Detail_Age";
            this.col_Detail_Age.Visible = true;
            this.col_Detail_Age.VisibleIndex = 1;
            this.col_Detail_Age.Width = 77;
            // 
            // col_Detail_CareerName
            // 
            this.col_Detail_CareerName.Caption = "Nghề nghiệp";
            this.col_Detail_CareerName.FieldName = "CareerName";
            this.col_Detail_CareerName.Name = "col_Detail_CareerName";
            this.col_Detail_CareerName.Visible = true;
            this.col_Detail_CareerName.VisibleIndex = 2;
            this.col_Detail_CareerName.Width = 147;
            // 
            // col_Detail_MedicalHistory
            // 
            this.col_Detail_MedicalHistory.Caption = "Tiền sử bệnh";
            this.col_Detail_MedicalHistory.FieldName = "MedicalHistory";
            this.col_Detail_MedicalHistory.Name = "col_Detail_MedicalHistory";
            this.col_Detail_MedicalHistory.Visible = true;
            this.col_Detail_MedicalHistory.VisibleIndex = 3;
            this.col_Detail_MedicalHistory.Width = 257;
            // 
            // tabPage02
            // 
            this.tabPage02.Controls.Add(this.txtContentPattern);
            this.tabPage02.Controls.Add(this.panel1);
            this.tabPage02.Name = "tabPage02";
            this.tabPage02.Size = new System.Drawing.Size(888, 448);
            this.tabPage02.Text = "Tiền sử trẻ sơ sinh";
            // 
            // txtContentPattern
            // 
            this.txtContentPattern.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtContentPattern.Appearance.Text.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContentPattern.Appearance.Text.Options.UseFont = true;
            this.txtContentPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContentPattern.EnableToolTips = true;
            this.txtContentPattern.Location = new System.Drawing.Point(0, 32);
            this.txtContentPattern.MenuManager = this.ribbon;
            this.txtContentPattern.Name = "txtContentPattern";
            this.txtContentPattern.Options.Bookmarks.AllowNameResolution = false;
            this.txtContentPattern.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.txtContentPattern.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.txtContentPattern.Size = new System.Drawing.Size(888, 416);
            this.txtContentPattern.TabIndex = 1005;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.lkupMedicalPattern);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 32);
            this.panel1.TabIndex = 1004;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl6.Location = new System.Drawing.Point(11, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(121, 14);
            this.labelControl6.TabIndex = 1003;
            this.labelControl6.Text = "Mẫu khai báo tiền sử :";
            // 
            // lkupMedicalPattern
            // 
            this.lkupMedicalPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupMedicalPattern.Location = new System.Drawing.Point(138, 6);
            this.lkupMedicalPattern.Name = "lkupMedicalPattern";
            this.lkupMedicalPattern.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lkupMedicalPattern.Properties.Appearance.Options.UseFont = true;
            this.lkupMedicalPattern.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupMedicalPattern.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MedicalHistoryName", "Tên mẫu bệnh án")});
            this.lkupMedicalPattern.Properties.NullText = "";
            this.lkupMedicalPattern.Size = new System.Drawing.Size(745, 20);
            this.lkupMedicalPattern.TabIndex = 1002;
            this.lkupMedicalPattern.EditValueChanged += new System.EventHandler(this.lkupMedicalPattern_EditValueChanged);
            // 
            // frmRelationPatient
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 593);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelationPatient";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Thông tin tiền sử gia đình và tiền sử trẻ sơ sinh";
            this.Load += new System.EventHandler(this.frmRelationPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_RelationMenu)).EndInit();
            this.tabPage02.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupMedicalPattern.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraGrid.GridControl gridControl_Detail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_RelationContent;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_RelationMenu;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_PatientReceiveID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_RowIDMenu;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_Age;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_CareerName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Detail_MedicalHistory;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tabPage01;
        private DevExpress.XtraTab.XtraTabPage tabPage02;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lkupMedicalPattern;
        private DevExpress.XtraRichEdit.RichEditControl txtContentPattern;
        private DevExpress.XtraEditors.SimpleButton butSave;
    }
}