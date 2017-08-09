namespace Ps.Clinic.Master
{
    partial class frmMauMoTa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMauMoTa));
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_List = new DevExpress.XtraGrid.GridControl();
            this.gridView_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_TemplateHeaderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TemplateHeaderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ApplyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Apply = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PrintPaper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceMenuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.lkupServiceMenu = new DevExpress.XtraEditors.LookUpEdit();
            this.cbxPrinter = new System.Windows.Forms.ComboBox();
            this.searchlkDoctor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridViewDoctor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDoctor_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoctor_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtConclusion = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.searchlkService = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ser_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_ServiceGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butDelete = new DevExpress.XtraEditors.SimpleButton();
            this.butEdit = new DevExpress.XtraEditors.SimpleButton();
            this.butUndo = new DevExpress.XtraEditors.SimpleButton();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.butNew = new DevExpress.XtraEditors.SimpleButton();
            this.txtProposal = new DevExpress.XtraEditors.MemoEdit();
            this.lbDeNghi = new DevExpress.XtraEditors.LabelControl();
            this.lbNoiDung = new DevExpress.XtraEditors.LabelControl();
            this.txtTemplate_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbTenMau = new DevExpress.XtraEditors.LabelControl();
            this.cbAll = new System.Windows.Forms.RadioButton();
            this.cbWoman = new System.Windows.Forms.RadioButton();
            this.lbApdung = new DevExpress.XtraEditors.LabelControl();
            this.cbMen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).BeginInit();
            this.pnTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupServiceMenu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchlkDoctor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchlkService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProposal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplate_Name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTemplate
            // 
            this.pnTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnTemplate.Name = "pnTemplate";
            this.pnTemplate.Panel1.Controls.Add(this.groupList);
            this.pnTemplate.Panel1.Text = "Panel1";
            this.pnTemplate.Panel2.Controls.Add(this.grDetails);
            this.pnTemplate.Panel2.Text = "Panel2";
            this.pnTemplate.Size = new System.Drawing.Size(1024, 600);
            this.pnTemplate.SplitterPosition = 355;
            this.pnTemplate.TabIndex = 5;
            this.pnTemplate.Text = "splitContainerControl1";
            // 
            // groupList
            // 
            this.groupList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupList.AppearanceCaption.Options.UseFont = true;
            this.groupList.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupList.CaptionImage")));
            this.groupList.Controls.Add(this.gridControl_List);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(355, 600);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "Danh sách mẫu mô tả";
            // 
            // gridControl_List
            // 
            this.gridControl_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_List.Location = new System.Drawing.Point(2, 23);
            this.gridControl_List.MainView = this.gridView_List;
            this.gridControl_List.Name = "gridControl_List";
            this.gridControl_List.Size = new System.Drawing.Size(351, 575);
            this.gridControl_List.TabIndex = 0;
            this.gridControl_List.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_List});
            // 
            // gridView_List
            // 
            this.gridView_List.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_List.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_List.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_List.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_List.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TemplateHeaderCode,
            this.col_TemplateHeaderName,
            this.col_ApplyName,
            this.col_Apply,
            this.col_ServiceCode,
            this.col_PrintPaper,
            this.col_ServiceMenuName});
            this.gridView_List.GridControl = this.gridControl_List;
            this.gridView_List.Name = "gridView_List";
            this.gridView_List.OptionsFind.FindFilterColumns = "Template_Header_Name";
            this.gridView_List.OptionsView.ShowFooter = true;
            this.gridView_List.OptionsView.ShowGroupPanel = false;
            this.gridView_List.Click += new System.EventHandler(this.gridView_List_Click);
            // 
            // col_TemplateHeaderCode
            // 
            this.col_TemplateHeaderCode.Caption = "Mã mẫu mô tả";
            this.col_TemplateHeaderCode.FieldName = "TemplateHeaderCode";
            this.col_TemplateHeaderCode.Name = "col_TemplateHeaderCode";
            // 
            // col_TemplateHeaderName
            // 
            this.col_TemplateHeaderName.Caption = "Tên mẫu mô tả";
            this.col_TemplateHeaderName.FieldName = "TemplateHeaderName";
            this.col_TemplateHeaderName.Name = "col_TemplateHeaderName";
            this.col_TemplateHeaderName.OptionsColumn.AllowEdit = false;
            this.col_TemplateHeaderName.OptionsColumn.AllowFocus = false;
            this.col_TemplateHeaderName.OptionsColumn.ReadOnly = true;
            this.col_TemplateHeaderName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TemplateHeaderCode", "Tổng: {0:#,#}")});
            this.col_TemplateHeaderName.Visible = true;
            this.col_TemplateHeaderName.VisibleIndex = 0;
            this.col_TemplateHeaderName.Width = 242;
            // 
            // col_ApplyName
            // 
            this.col_ApplyName.AppearanceCell.Options.UseTextOptions = true;
            this.col_ApplyName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ApplyName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ApplyName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ApplyName.Caption = "Áp dụng";
            this.col_ApplyName.FieldName = "ApplyName";
            this.col_ApplyName.Name = "col_ApplyName";
            this.col_ApplyName.OptionsColumn.AllowEdit = false;
            this.col_ApplyName.OptionsColumn.AllowFocus = false;
            this.col_ApplyName.OptionsColumn.ReadOnly = true;
            this.col_ApplyName.Visible = true;
            this.col_ApplyName.VisibleIndex = 1;
            this.col_ApplyName.Width = 50;
            // 
            // col_Apply
            // 
            this.col_Apply.Caption = "Đối tượng";
            this.col_Apply.FieldName = "Apply";
            this.col_Apply.Name = "col_Apply";
            this.col_Apply.OptionsColumn.AllowEdit = false;
            this.col_Apply.OptionsColumn.AllowFocus = false;
            this.col_Apply.OptionsColumn.ReadOnly = true;
            this.col_Apply.Width = 65;
            // 
            // col_ServiceCode
            // 
            this.col_ServiceCode.Caption = "Mã DV";
            this.col_ServiceCode.FieldName = "ServiceCode";
            this.col_ServiceCode.Name = "col_ServiceCode";
            // 
            // col_PrintPaper
            // 
            this.col_PrintPaper.Caption = "Giấy in";
            this.col_PrintPaper.FieldName = "PrintPaper";
            this.col_PrintPaper.Name = "col_PrintPaper";
            this.col_PrintPaper.OptionsColumn.AllowEdit = false;
            this.col_PrintPaper.OptionsColumn.AllowFocus = false;
            this.col_PrintPaper.OptionsColumn.ReadOnly = true;
            this.col_PrintPaper.Width = 78;
            // 
            // col_ServiceMenuName
            // 
            this.col_ServiceMenuName.Caption = "CLS";
            this.col_ServiceMenuName.FieldName = "ServiceMenuName";
            this.col_ServiceMenuName.Name = "col_ServiceMenuName";
            this.col_ServiceMenuName.OptionsColumn.AllowEdit = false;
            this.col_ServiceMenuName.OptionsColumn.AllowFocus = false;
            this.col_ServiceMenuName.OptionsColumn.ReadOnly = true;
            this.col_ServiceMenuName.Visible = true;
            this.col_ServiceMenuName.VisibleIndex = 2;
            this.col_ServiceMenuName.Width = 43;
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.lkupServiceMenu);
            this.grDetails.Controls.Add(this.cbxPrinter);
            this.grDetails.Controls.Add(this.searchlkDoctor);
            this.grDetails.Controls.Add(this.txtConclusion);
            this.grDetails.Controls.Add(this.txtContent);
            this.grDetails.Controls.Add(this.searchlkService);
            this.grDetails.Controls.Add(this.panelControl1);
            this.grDetails.Controls.Add(this.txtProposal);
            this.grDetails.Controls.Add(this.lbDeNghi);
            this.grDetails.Controls.Add(this.lbNoiDung);
            this.grDetails.Controls.Add(this.txtTemplate_Name);
            this.grDetails.Controls.Add(this.labelControl1);
            this.grDetails.Controls.Add(this.labelControl4);
            this.grDetails.Controls.Add(this.labelControl3);
            this.grDetails.Controls.Add(this.labelControl2);
            this.grDetails.Controls.Add(this.lbTenMau);
            this.grDetails.Controls.Add(this.cbAll);
            this.grDetails.Controls.Add(this.cbWoman);
            this.grDetails.Controls.Add(this.lbApdung);
            this.grDetails.Controls.Add(this.cbMen);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(664, 600);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "Chi tiết mẫu";
            // 
            // lkupServiceMenu
            // 
            this.lkupServiceMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupServiceMenu.Location = new System.Drawing.Point(413, 96);
            this.lkupServiceMenu.Name = "lkupServiceMenu";
            this.lkupServiceMenu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupServiceMenu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceMenuName", "CLS"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceMenuID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupServiceMenu.Properties.NullText = "";
            this.lkupServiceMenu.Size = new System.Drawing.Size(111, 20);
            this.lkupServiceMenu.TabIndex = 19;
            // 
            // cbxPrinter
            // 
            this.cbxPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPrinter.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cbxPrinter.FormattingEnabled = true;
            this.cbxPrinter.Location = new System.Drawing.Point(573, 95);
            this.cbxPrinter.Name = "cbxPrinter";
            this.cbxPrinter.Size = new System.Drawing.Size(86, 21);
            this.cbxPrinter.TabIndex = 18;
            this.cbxPrinter.TabStop = false;
            // 
            // searchlkDoctor
            // 
            this.searchlkDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchlkDoctor.Location = new System.Drawing.Point(102, 96);
            this.searchlkDoctor.Name = "searchlkDoctor";
            this.searchlkDoctor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchlkDoctor.Properties.NullText = "Bác sỹ đọc trả kết quả";
            this.searchlkDoctor.Properties.View = this.gridViewDoctor;
            this.searchlkDoctor.Size = new System.Drawing.Size(245, 20);
            this.searchlkDoctor.TabIndex = 17;
            this.searchlkDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchlkDoctor_KeyDown);
            // 
            // gridViewDoctor
            // 
            this.gridViewDoctor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDoctor_EmployeeCode,
            this.colDoctor_EmployeeName});
            this.gridViewDoctor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDoctor.Name = "gridViewDoctor";
            this.gridViewDoctor.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDoctor.OptionsView.ShowGroupPanel = false;
            // 
            // colDoctor_EmployeeCode
            // 
            this.colDoctor_EmployeeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDoctor_EmployeeCode.AppearanceHeader.Options.UseFont = true;
            this.colDoctor_EmployeeCode.Caption = "Mã B.Sỹ";
            this.colDoctor_EmployeeCode.FieldName = "EmployeeCode";
            this.colDoctor_EmployeeCode.Name = "colDoctor_EmployeeCode";
            this.colDoctor_EmployeeCode.Visible = true;
            this.colDoctor_EmployeeCode.VisibleIndex = 0;
            this.colDoctor_EmployeeCode.Width = 104;
            // 
            // colDoctor_EmployeeName
            // 
            this.colDoctor_EmployeeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDoctor_EmployeeName.AppearanceHeader.Options.UseFont = true;
            this.colDoctor_EmployeeName.Caption = "Họ và Tên";
            this.colDoctor_EmployeeName.FieldName = "EmployeeName";
            this.colDoctor_EmployeeName.Name = "colDoctor_EmployeeName";
            this.colDoctor_EmployeeName.Visible = true;
            this.colDoctor_EmployeeName.VisibleIndex = 1;
            this.colDoctor_EmployeeName.Width = 592;
            // 
            // txtConclusion
            // 
            this.txtConclusion.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConclusion.EnableToolTips = true;
            this.txtConclusion.Location = new System.Drawing.Point(102, 523);
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.Options.Bookmarks.AllowNameResolution = false;
            this.txtConclusion.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.txtConclusion.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.txtConclusion.Size = new System.Drawing.Size(557, 43);
            this.txtConclusion.TabIndex = 16;
            // 
            // txtContent
            // 
            this.txtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Appearance.Text.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Appearance.Text.Options.UseFont = true;
            this.txtContent.EnableToolTips = true;
            this.txtContent.Location = new System.Drawing.Point(102, 118);
            this.txtContent.Name = "txtContent";
            this.txtContent.Options.Bookmarks.AllowNameResolution = false;
            this.txtContent.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.txtContent.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.txtContent.Size = new System.Drawing.Size(557, 403);
            this.txtContent.TabIndex = 15;
            this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyDown);
            // 
            // searchlkService
            // 
            this.searchlkService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchlkService.EditValue = "";
            this.searchlkService.Location = new System.Drawing.Point(102, 52);
            this.searchlkService.Name = "searchlkService";
            this.searchlkService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchlkService.Properties.NullText = "Dịch vụ khai báo mẫu mô tả";
            this.searchlkService.Properties.View = this.searchLookUpEdit1View;
            this.searchlkService.Size = new System.Drawing.Size(557, 20);
            this.searchlkService.TabIndex = 14;
            this.searchlkService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchlkService_KeyDown);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ser_RowID,
            this.col_ser_ServiceCategoryCode,
            this.col_ser_ServiceCategoryName,
            this.col_ser_ServiceCode,
            this.col_ser_ServiceName,
            this.col_ser_DepartmentCode,
            this.col_ser_Hide,
            this.col_ser_ServiceGroupCode});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // col_ser_RowID
            // 
            this.col_ser_RowID.Caption = "RowID";
            this.col_ser_RowID.FieldName = "RowID";
            this.col_ser_RowID.Name = "col_ser_RowID";
            // 
            // col_ser_ServiceCategoryCode
            // 
            this.col_ser_ServiceCategoryCode.Caption = "ServiceCategoryCode";
            this.col_ser_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.col_ser_ServiceCategoryCode.Name = "col_ser_ServiceCategoryCode";
            // 
            // col_ser_ServiceCategoryName
            // 
            this.col_ser_ServiceCategoryName.Caption = "Loại dịch vụ";
            this.col_ser_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_ser_ServiceCategoryName.Name = "col_ser_ServiceCategoryName";
            this.col_ser_ServiceCategoryName.Visible = true;
            this.col_ser_ServiceCategoryName.VisibleIndex = 1;
            // 
            // col_ser_ServiceCode
            // 
            this.col_ser_ServiceCode.Caption = "ServiceCode";
            this.col_ser_ServiceCode.Name = "col_ser_ServiceCode";
            // 
            // col_ser_ServiceName
            // 
            this.col_ser_ServiceName.Caption = "Dịch vụ";
            this.col_ser_ServiceName.FieldName = "ServiceName";
            this.col_ser_ServiceName.Name = "col_ser_ServiceName";
            this.col_ser_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ser_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_ser_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_ser_ServiceName.Visible = true;
            this.col_ser_ServiceName.VisibleIndex = 0;
            // 
            // col_ser_DepartmentCode
            // 
            this.col_ser_DepartmentCode.Caption = "DepartmentCode";
            this.col_ser_DepartmentCode.FieldName = "DepartmentCode";
            this.col_ser_DepartmentCode.Name = "col_ser_DepartmentCode";
            // 
            // col_ser_Hide
            // 
            this.col_ser_Hide.Caption = "Hide";
            this.col_ser_Hide.FieldName = "Hide";
            this.col_ser_Hide.Name = "col_ser_Hide";
            // 
            // col_ser_ServiceGroupCode
            // 
            this.col_ser_ServiceGroupCode.Caption = "ServiceGroupCode";
            this.col_ser_ServiceGroupCode.FieldName = "ServiceGroupCode";
            this.col_ser_ServiceGroupCode.Name = "col_ser_ServiceGroupCode";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butDelete);
            this.panelControl1.Controls.Add(this.butEdit);
            this.panelControl1.Controls.Add(this.butUndo);
            this.panelControl1.Controls.Add(this.butSave);
            this.panelControl1.Controls.Add(this.butNew);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 568);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(660, 30);
            this.panelControl1.TabIndex = 12;
            // 
            // butDelete
            // 
            this.butDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butDelete.Image = ((System.Drawing.Image)(resources.GetObject("butDelete.Image")));
            this.butDelete.Location = new System.Drawing.Point(405, 4);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 4;
            this.butDelete.Text = "Hủy";
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butEdit
            // 
            this.butEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butEdit.Image = ((System.Drawing.Image)(resources.GetObject("butEdit.Image")));
            this.butEdit.Location = new System.Drawing.Point(329, 4);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(75, 23);
            this.butEdit.TabIndex = 3;
            this.butEdit.Text = "Sửa";
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butUndo
            // 
            this.butUndo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butUndo.Image = ((System.Drawing.Image)(resources.GetObject("butUndo.Image")));
            this.butUndo.Location = new System.Drawing.Point(253, 4);
            this.butUndo.Name = "butUndo";
            this.butUndo.Size = new System.Drawing.Size(75, 23);
            this.butUndo.TabIndex = 2;
            this.butUndo.Text = "Bỏ qua";
            this.butUndo.Click += new System.EventHandler(this.butUndo_Click);
            // 
            // butSave
            // 
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(177, 4);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butNew
            // 
            this.butNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butNew.Image = ((System.Drawing.Image)(resources.GetObject("butNew.Image")));
            this.butNew.Location = new System.Drawing.Point(101, 4);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 23);
            this.butNew.TabIndex = 0;
            this.butNew.Text = "Mới";
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // txtProposal
            // 
            this.txtProposal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProposal.Location = new System.Drawing.Point(22, 297);
            this.txtProposal.Name = "txtProposal";
            this.txtProposal.Size = new System.Drawing.Size(35, 45);
            this.txtProposal.TabIndex = 11;
            this.txtProposal.Visible = false;
            this.txtProposal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProposal_KeyDown);
            // 
            // lbDeNghi
            // 
            this.lbDeNghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDeNghi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeNghi.Location = new System.Drawing.Point(54, 525);
            this.lbDeNghi.Name = "lbDeNghi";
            this.lbDeNghi.Size = new System.Drawing.Size(46, 13);
            this.lbDeNghi.TabIndex = 10;
            this.lbDeNghi.Text = "Kết luận :";
            // 
            // lbNoiDung
            // 
            this.lbNoiDung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiDung.Location = new System.Drawing.Point(50, 121);
            this.lbNoiDung.Name = "lbNoiDung";
            this.lbNoiDung.Size = new System.Drawing.Size(49, 13);
            this.lbNoiDung.TabIndex = 6;
            this.lbNoiDung.Text = "Nội dung :";
            // 
            // txtTemplate_Name
            // 
            this.txtTemplate_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplate_Name.Location = new System.Drawing.Point(102, 74);
            this.txtTemplate_Name.Name = "txtTemplate_Name";
            this.txtTemplate_Name.Size = new System.Drawing.Size(557, 20);
            this.txtTemplate_Name.TabIndex = 5;
            this.txtTemplate_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemplate_Name_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(58, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Dịch vụ :";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(353, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Mẫu mô tả :";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(530, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "In giấy :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(62, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Bác sỹ :";
            // 
            // lbTenMau
            // 
            this.lbTenMau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenMau.Location = new System.Drawing.Point(22, 77);
            this.lbTenMau.Name = "lbTenMau";
            this.lbTenMau.Size = new System.Drawing.Size(78, 13);
            this.lbTenMau.TabIndex = 4;
            this.lbTenMau.Text = "Tên mẫu mô tả :";
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(217, 26);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(47, 17);
            this.cbAll.TabIndex = 3;
            this.cbAll.Text = "Cả 2";
            this.cbAll.UseVisualStyleBackColor = true;
            // 
            // cbWoman
            // 
            this.cbWoman.AutoSize = true;
            this.cbWoman.Location = new System.Drawing.Point(164, 26);
            this.cbWoman.Name = "cbWoman";
            this.cbWoman.Size = new System.Drawing.Size(39, 17);
            this.cbWoman.TabIndex = 2;
            this.cbWoman.Text = "Nữ";
            this.cbWoman.UseVisualStyleBackColor = true;
            // 
            // lbApdung
            // 
            this.lbApdung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApdung.Location = new System.Drawing.Point(33, 28);
            this.lbApdung.Name = "lbApdung";
            this.lbApdung.Size = new System.Drawing.Size(67, 13);
            this.lbApdung.TabIndex = 1;
            this.lbApdung.Text = "Áp dụng cho :";
            // 
            // cbMen
            // 
            this.cbMen.AutoSize = true;
            this.cbMen.Checked = true;
            this.cbMen.Location = new System.Drawing.Point(104, 26);
            this.cbMen.Name = "cbMen";
            this.cbMen.Size = new System.Drawing.Size(46, 17);
            this.cbMen.TabIndex = 0;
            this.cbMen.TabStop = true;
            this.cbMen.Text = "Nam";
            this.cbMen.UseVisualStyleBackColor = true;
            // 
            // frmMauMoTa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMauMoTa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMauMoTa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            this.grDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupServiceMenu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchlkDoctor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchlkService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProposal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplate_Name.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl pnTemplate;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraGrid.GridControl gridControl_List;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_List;
        private DevExpress.XtraGrid.Columns.GridColumn col_TemplateHeaderCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_TemplateHeaderName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Apply;
        private DevExpress.XtraEditors.LabelControl lbApdung;
        private System.Windows.Forms.RadioButton cbMen;
        private System.Windows.Forms.RadioButton cbAll;
        private System.Windows.Forms.RadioButton cbWoman;
        private DevExpress.XtraEditors.LabelControl lbTenMau;
        private DevExpress.XtraEditors.TextEdit txtTemplate_Name;
        private DevExpress.XtraEditors.LabelControl lbNoiDung;
        private DevExpress.XtraEditors.MemoEdit txtProposal;
        private DevExpress.XtraEditors.LabelControl lbDeNghi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butNew;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butUndo;
        private DevExpress.XtraEditors.SimpleButton butEdit;
        private DevExpress.XtraEditors.SimpleButton butDelete;
        private DevExpress.XtraGrid.Columns.GridColumn col_ApplyName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCode;
        private DevExpress.XtraEditors.SearchLookUpEdit searchlkService;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_ServiceCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_DepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_ServiceGroupCode;
        private DevExpress.XtraRichEdit.RichEditControl txtContent;
        private DevExpress.XtraRichEdit.RichEditControl txtConclusion;
        private DevExpress.XtraGrid.Columns.GridColumn col_ser_ServiceCategoryName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit searchlkDoctor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor_EmployeeName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox cbxPrinter;
        private DevExpress.XtraGrid.Columns.GridColumn col_PrintPaper;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkupServiceMenu;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceMenuName;
    }
}