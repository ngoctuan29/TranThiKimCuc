namespace Ps.Clinic.Master
{
    partial class frmTienSuBenh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTienSuBenh));
            this.gridControl_Medical_History = new DevExpress.XtraGrid.GridControl();
            this.gridView_Medical_History = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_Medical_History_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtContentPattern = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butEdit = new DevExpress.XtraEditors.SimpleButton();
            this.butCancel = new DevExpress.XtraEditors.SimpleButton();
            this.butContinues = new DevExpress.XtraEditors.SimpleButton();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Medical_History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Medical_History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Medical_History
            // 
            this.gridControl_Medical_History.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Medical_History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Medical_History.Location = new System.Drawing.Point(3, 17);
            this.gridControl_Medical_History.MainView = this.gridView_Medical_History;
            this.gridControl_Medical_History.Name = "gridControl_Medical_History";
            this.gridControl_Medical_History.Size = new System.Drawing.Size(276, 304);
            this.gridControl_Medical_History.TabIndex = 2;
            this.gridControl_Medical_History.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Medical_History});
            // 
            // gridView_Medical_History
            // 
            this.gridView_Medical_History.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Medical_History.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Medical_History.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Medical_History.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Medical_History.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.Col_Medical_History_Name});
            this.gridView_Medical_History.GridControl = this.gridControl_Medical_History;
            this.gridView_Medical_History.Name = "gridView_Medical_History";
            this.gridView_Medical_History.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Tiền sử bệnh).";
            this.gridView_Medical_History.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Medical_History.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Medical_History.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Medical_History.OptionsView.ShowFooter = true;
            this.gridView_Medical_History.OptionsView.ShowGroupPanel = false;
            this.gridView_Medical_History.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_Medical_History_RowClick);
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.Caption = "Mã";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowEdit = false;
            this.col_RowID.OptionsColumn.AllowFocus = false;
            this.col_RowID.OptionsColumn.ReadOnly = true;
            this.col_RowID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_RowID.Width = 64;
            // 
            // Col_Medical_History_Name
            // 
            this.Col_Medical_History_Name.Caption = "Tiền sử bệnh";
            this.Col_Medical_History_Name.FieldName = "MedicalHistoryName";
            this.Col_Medical_History_Name.Name = "Col_Medical_History_Name";
            this.Col_Medical_History_Name.OptionsColumn.AllowEdit = false;
            this.Col_Medical_History_Name.OptionsColumn.AllowFocus = false;
            this.Col_Medical_History_Name.OptionsColumn.ReadOnly = true;
            this.Col_Medical_History_Name.Visible = true;
            this.Col_Medical_History_Name.VisibleIndex = 0;
            this.Col_Medical_History_Name.Width = 940;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(706, 349);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục tiền sử bệnh";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtContentPattern);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Controls.Add(this.labelControl6);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(284, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 324);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết";
            // 
            // txtContentPattern
            // 
            this.txtContentPattern.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtContentPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContentPattern.Appearance.Text.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContentPattern.Appearance.Text.Options.UseFont = true;
            this.txtContentPattern.EnableToolTips = true;
            this.txtContentPattern.Location = new System.Drawing.Point(57, 40);
            this.txtContentPattern.Name = "txtContentPattern";
            this.txtContentPattern.Options.Bookmarks.AllowNameResolution = false;
            this.txtContentPattern.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.txtContentPattern.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.txtContentPattern.Size = new System.Drawing.Size(357, 237);
            this.txtContentPattern.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(57, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(357, 20);
            this.txtName.TabIndex = 0;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 1005;
            this.labelControl1.Text = "Nội dung :";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 17);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 13);
            this.labelControl6.TabIndex = 1004;
            this.labelControl6.Text = "Tiền sử :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butEdit);
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Controls.Add(this.butContinues);
            this.panel1.Controls.Add(this.butSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 38);
            this.panel1.TabIndex = 0;
            // 
            // butEdit
            // 
            this.butEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butEdit.Image = ((System.Drawing.Image)(resources.GetObject("butEdit.Image")));
            this.butEdit.Location = new System.Drawing.Point(207, 6);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(65, 25);
            this.butEdit.TabIndex = 4;
            this.butEdit.Text = "Sửa";
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.Location = new System.Drawing.Point(273, 6);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 25);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Hủy";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butContinues
            // 
            this.butContinues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butContinues.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butContinues.Image = ((System.Drawing.Image)(resources.GetObject("butContinues.Image")));
            this.butContinues.Location = new System.Drawing.Point(55, 6);
            this.butContinues.Name = "butContinues";
            this.butContinues.Size = new System.Drawing.Size(75, 25);
            this.butContinues.TabIndex = 2;
            this.butContinues.Text = " Mới";
            this.butContinues.Click += new System.EventHandler(this.butContinues_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(131, 6);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 25);
            this.butSave.TabIndex = 3;
            this.butSave.Text = " Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl_Medical_History);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(2, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 324);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // frmTienSuBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 349);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTienSuBenh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tiền xử bệnh lý";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTienSuBenh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Medical_History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Medical_History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Medical_History;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Medical_History;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Medical_History_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton butCancel;
        private DevExpress.XtraEditors.SimpleButton butContinues;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraRichEdit.RichEditControl txtContentPattern;
        private DevExpress.XtraEditors.SimpleButton butEdit;
    }
}