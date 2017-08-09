namespace Ps.Clinic.Master
{
    partial class frmMedicalPattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicalPattern));
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_List = new DevExpress.XtraGrid.GridControl();
            this.gridView_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.collist_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collist_Title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collist_Contents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collist_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collist_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.txtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.searchlkService = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ser_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ser_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.lbNoiDung = new DevExpress.XtraEditors.LabelControl();
            this.txtTemplate_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbTenMau = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).BeginInit();
            this.pnTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchlkService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.groupList.Text = "Danh sách mẫu khám bệnh";
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
            this.collist_RowID,
            this.collist_Title,
            this.collist_Contents,
            this.collist_ServiceCode,
            this.collist_ServiceName});
            this.gridView_List.GridControl = this.gridControl_List;
            this.gridView_List.Name = "gridView_List";
            this.gridView_List.OptionsFind.FindFilterColumns = "Template_Header_Name";
            this.gridView_List.OptionsView.ShowFooter = true;
            this.gridView_List.OptionsView.ShowGroupPanel = false;
            this.gridView_List.Click += new System.EventHandler(this.gridView_List_Click);
            // 
            // collist_RowID
            // 
            this.collist_RowID.Caption = "Mã mẫu mô tả";
            this.collist_RowID.FieldName = "RowID";
            this.collist_RowID.Name = "collist_RowID";
            this.collist_RowID.OptionsColumn.AllowEdit = false;
            this.collist_RowID.OptionsColumn.ReadOnly = true;
            // 
            // collist_Title
            // 
            this.collist_Title.Caption = "Tên mẫu khám bệnh";
            this.collist_Title.FieldName = "Title";
            this.collist_Title.Name = "collist_Title";
            this.collist_Title.OptionsColumn.AllowEdit = false;
            this.collist_Title.OptionsColumn.AllowFocus = false;
            this.collist_Title.OptionsColumn.ReadOnly = true;
            this.collist_Title.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowID", "Count: {0:#,#}")});
            this.collist_Title.Visible = true;
            this.collist_Title.VisibleIndex = 0;
            this.collist_Title.Width = 484;
            // 
            // collist_Contents
            // 
            this.collist_Contents.Caption = "Nội dung";
            this.collist_Contents.FieldName = "Content";
            this.collist_Contents.Name = "collist_Contents";
            this.collist_Contents.OptionsColumn.AllowEdit = false;
            this.collist_Contents.OptionsColumn.AllowFocus = false;
            this.collist_Contents.OptionsColumn.ReadOnly = true;
            // 
            // collist_ServiceCode
            // 
            this.collist_ServiceCode.FieldName = "ServiceCode";
            this.collist_ServiceCode.Name = "collist_ServiceCode";
            // 
            // collist_ServiceName
            // 
            this.collist_ServiceName.Caption = "Công khám";
            this.collist_ServiceName.FieldName = "ServiceName";
            this.collist_ServiceName.Name = "collist_ServiceName";
            this.collist_ServiceName.OptionsColumn.AllowEdit = false;
            this.collist_ServiceName.OptionsColumn.AllowFocus = false;
            this.collist_ServiceName.OptionsColumn.ReadOnly = true;
            this.collist_ServiceName.Visible = true;
            this.collist_ServiceName.VisibleIndex = 1;
            this.collist_ServiceName.Width = 220;
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.txtContent);
            this.grDetails.Controls.Add(this.searchlkService);
            this.grDetails.Controls.Add(this.panelControl1);
            this.grDetails.Controls.Add(this.lbNoiDung);
            this.grDetails.Controls.Add(this.txtTemplate_Name);
            this.grDetails.Controls.Add(this.labelControl1);
            this.grDetails.Controls.Add(this.lbTenMau);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(664, 600);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "Chi tiết mẫu";
            // 
            // txtContent
            // 
            this.txtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.EnableToolTips = true;
            this.txtContent.Location = new System.Drawing.Point(89, 70);
            this.txtContent.Name = "txtContent";
            this.txtContent.Options.Bookmarks.AllowNameResolution = false;
            this.txtContent.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.txtContent.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.txtContent.Size = new System.Drawing.Size(563, 492);
            this.txtContent.TabIndex = 15;
            // 
            // searchlkService
            // 
            this.searchlkService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchlkService.EditValue = "...";
            this.searchlkService.Location = new System.Drawing.Point(89, 26);
            this.searchlkService.Name = "searchlkService";
            this.searchlkService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchlkService.Properties.NullText = "...";
            this.searchlkService.Properties.View = this.searchLookUpEdit1View;
            this.searchlkService.Size = new System.Drawing.Size(563, 20);
            this.searchlkService.TabIndex = 14;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ser_RowID,
            this.col_ser_ServiceCategoryCode,
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
            this.butDelete.Location = new System.Drawing.Point(392, 4);
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
            this.butEdit.Location = new System.Drawing.Point(316, 4);
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
            this.butUndo.Location = new System.Drawing.Point(240, 4);
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
            this.butSave.Location = new System.Drawing.Point(164, 4);
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
            this.butNew.Location = new System.Drawing.Point(88, 4);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 23);
            this.butNew.TabIndex = 0;
            this.butNew.Text = "Mới";
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // lbNoiDung
            // 
            this.lbNoiDung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiDung.Location = new System.Drawing.Point(37, 73);
            this.lbNoiDung.Name = "lbNoiDung";
            this.lbNoiDung.Size = new System.Drawing.Size(49, 13);
            this.lbNoiDung.TabIndex = 6;
            this.lbNoiDung.Text = "Nội dung :";
            // 
            // txtTemplate_Name
            // 
            this.txtTemplate_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplate_Name.Location = new System.Drawing.Point(89, 48);
            this.txtTemplate_Name.Name = "txtTemplate_Name";
            this.txtTemplate_Name.Size = new System.Drawing.Size(563, 20);
            this.txtTemplate_Name.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(26, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Công khám :";
            // 
            // lbTenMau
            // 
            this.lbTenMau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenMau.Location = new System.Drawing.Point(8, 51);
            this.lbTenMau.Name = "lbTenMau";
            this.lbTenMau.Size = new System.Drawing.Size(78, 13);
            this.lbTenMau.TabIndex = 4;
            this.lbTenMau.Text = "Tên mẫu mô tả :";
            // 
            // frmMedicalPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicalPattern";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMedicalPattern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            this.grDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchlkService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplate_Name.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl pnTemplate;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraGrid.GridControl gridControl_List;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_List;
        private DevExpress.XtraGrid.Columns.GridColumn collist_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn collist_Title;
        private DevExpress.XtraGrid.Columns.GridColumn collist_Contents;
        private DevExpress.XtraEditors.LabelControl lbTenMau;
        private DevExpress.XtraEditors.TextEdit txtTemplate_Name;
        private DevExpress.XtraEditors.LabelControl lbNoiDung;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butNew;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butUndo;
        private DevExpress.XtraEditors.SimpleButton butEdit;
        private DevExpress.XtraEditors.SimpleButton butDelete;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn collist_ServiceCode;
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
        private DevExpress.XtraGrid.Columns.GridColumn collist_ServiceName;
    }
}