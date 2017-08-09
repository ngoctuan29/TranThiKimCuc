namespace Ps.Clinic.Master
{
    partial class frmLabPatternAttach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabPatternAttach));
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_List = new DevExpress.XtraGrid.GridControl();
            this.gridView_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.lkupLabPatholo = new DevExpress.XtraEditors.LookUpEdit();
            this.txtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butDelete = new DevExpress.XtraEditors.SimpleButton();
            this.butEdit = new DevExpress.XtraEditors.SimpleButton();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.lkupLabPatholo.Properties)).BeginInit();
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
            this.groupList.Text = "Xét nghiệm khai mẫu";
            // 
            // gridControl_List
            // 
            this.gridControl_List.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.col_ServiceCategoryCode,
            this.col_ServiceCategoryName});
            this.gridView_List.GridControl = this.gridControl_List;
            this.gridView_List.Name = "gridView_List";
            this.gridView_List.OptionsFind.FindFilterColumns = "Template_Header_Name";
            this.gridView_List.OptionsView.ShowFooter = true;
            this.gridView_List.OptionsView.ShowGroupPanel = false;
            this.gridView_List.Click += new System.EventHandler(this.gridView_List_Click);
            // 
            // col_ServiceCategoryCode
            // 
            this.col_ServiceCategoryCode.Caption = "Loại xét nghiệm";
            this.col_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.col_ServiceCategoryCode.Name = "col_ServiceCategoryCode";
            // 
            // col_ServiceCategoryName
            // 
            this.col_ServiceCategoryName.Caption = "Loại xét nghiệm";
            this.col_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_ServiceCategoryName.Name = "col_ServiceCategoryName";
            this.col_ServiceCategoryName.OptionsColumn.AllowEdit = false;
            this.col_ServiceCategoryName.OptionsColumn.AllowFocus = false;
            this.col_ServiceCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ServiceCategoryName.Visible = true;
            this.col_ServiceCategoryName.VisibleIndex = 0;
            this.col_ServiceCategoryName.Width = 208;
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.lkupLabPatholo);
            this.grDetails.Controls.Add(this.txtContent);
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
            // lkupLabPatholo
            // 
            this.lkupLabPatholo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupLabPatholo.EditValue = "";
            this.lkupLabPatholo.Location = new System.Drawing.Point(22, 45);
            this.lkupLabPatholo.Name = "lkupLabPatholo";
            this.lkupLabPatholo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupLabPatholo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LabPathologicalName", "Bệnh phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LabPathologicalID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupLabPatholo.Properties.NullText = "";
            this.lkupLabPatholo.Properties.Tag = "";
            this.lkupLabPatholo.Size = new System.Drawing.Size(627, 20);
            this.lkupLabPatholo.TabIndex = 16;
            // 
            // txtContent
            // 
            this.txtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Appearance.Text.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Appearance.Text.Options.UseFont = true;
            this.txtContent.EnableToolTips = true;
            this.txtContent.Location = new System.Drawing.Point(22, 129);
            this.txtContent.Name = "txtContent";
            this.txtContent.Options.Bookmarks.AllowNameResolution = false;
            this.txtContent.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.txtContent.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.txtContent.Size = new System.Drawing.Size(630, 433);
            this.txtContent.TabIndex = 15;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butDelete);
            this.panelControl1.Controls.Add(this.butEdit);
            this.panelControl1.Controls.Add(this.butSave);
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
            this.butDelete.Location = new System.Drawing.Point(172, 3);
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
            this.butEdit.Location = new System.Drawing.Point(96, 3);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(75, 23);
            this.butEdit.TabIndex = 3;
            this.butEdit.Text = "Sửa";
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butSave
            // 
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(20, 3);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // lbNoiDung
            // 
            this.lbNoiDung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiDung.Location = new System.Drawing.Point(25, 110);
            this.lbNoiDung.Name = "lbNoiDung";
            this.lbNoiDung.Size = new System.Drawing.Size(45, 13);
            this.lbNoiDung.TabIndex = 6;
            this.lbNoiDung.Text = "Nội dung ";
            // 
            // txtTemplate_Name
            // 
            this.txtTemplate_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplate_Name.Location = new System.Drawing.Point(22, 86);
            this.txtTemplate_Name.Name = "txtTemplate_Name";
            this.txtTemplate_Name.Size = new System.Drawing.Size(627, 20);
            this.txtTemplate_Name.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(25, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Bệnh phẩm";
            // 
            // lbTenMau
            // 
            this.lbTenMau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenMau.Location = new System.Drawing.Point(25, 69);
            this.lbTenMau.Name = "lbTenMau";
            this.lbTenMau.Size = new System.Drawing.Size(71, 13);
            this.lbTenMau.TabIndex = 4;
            this.lbTenMau.Text = "Tên mẫu mô tả";
            // 
            // frmLabPatternAttach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLabPatternAttach";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLabPatternAttach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            this.grDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupLabPatholo.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryCode;
        private DevExpress.XtraEditors.LabelControl lbTenMau;
        private DevExpress.XtraEditors.TextEdit txtTemplate_Name;
        private DevExpress.XtraEditors.LabelControl lbNoiDung;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butDelete;
        private DevExpress.XtraRichEdit.RichEditControl txtContent;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryName;
        private DevExpress.XtraEditors.SimpleButton butEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkupLabPatholo;
    }
}