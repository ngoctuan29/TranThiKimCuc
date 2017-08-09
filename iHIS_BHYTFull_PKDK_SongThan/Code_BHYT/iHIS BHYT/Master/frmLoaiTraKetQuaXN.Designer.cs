namespace Ps.Clinic.Master
{
    partial class frmLoaiTraKetQuaXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiTraKetQuaXN));
            this.pn01 = new DevExpress.XtraEditors.PanelControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Laboratory = new DevExpress.XtraGrid.GridControl();
            this.gridView_Laboratory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pn02 = new DevExpress.XtraEditors.PanelControl();
            this.lkupTypeResult = new DevExpress.XtraEditors.LookUpEdit();
            this.butRemove = new DevExpress.XtraEditors.SimpleButton();
            this.butAdd = new DevExpress.XtraEditors.SimpleButton();
            this.pn03 = new DevExpress.XtraEditors.PanelControl();
            this.group03 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_LabResult = new DevExpress.XtraGrid.GridControl();
            this.gridView_LabResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResult_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_TypeResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItem_TypeResult = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colResult_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butRefesh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pn01)).BeginInit();
            this.pn01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Laboratory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Laboratory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pn02)).BeginInit();
            this.pn02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTypeResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pn03)).BeginInit();
            this.pn03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group03)).BeginInit();
            this.group03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_LabResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LabResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem_TypeResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pn01
            // 
            this.pn01.Controls.Add(this.groupList);
            this.pn01.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn01.Location = new System.Drawing.Point(0, 0);
            this.pn01.Name = "pn01";
            this.pn01.Size = new System.Drawing.Size(353, 454);
            this.pn01.TabIndex = 0;
            // 
            // groupList
            // 
            this.groupList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupList.AppearanceCaption.Options.UseFont = true;
            this.groupList.Controls.Add(this.butRefesh);
            this.groupList.Controls.Add(this.gridControl_Laboratory);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(2, 2);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(349, 450);
            this.groupList.TabIndex = 1;
            this.groupList.Text = "Danh sách bộ xét nghiệm";
            // 
            // gridControl_Laboratory
            // 
            this.gridControl_Laboratory.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Laboratory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Laboratory.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Laboratory.MainView = this.gridView_Laboratory;
            this.gridControl_Laboratory.Name = "gridControl_Laboratory";
            this.gridControl_Laboratory.Size = new System.Drawing.Size(345, 428);
            this.gridControl_Laboratory.TabIndex = 0;
            this.gridControl_Laboratory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Laboratory});
            // 
            // gridView_Laboratory
            // 
            this.gridView_Laboratory.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Laboratory.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Laboratory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServiceCode,
            this.col_ServiceName,
            this.col_ServiceCategoryName,
            this.col_ServiceCategoryCode});
            this.gridView_Laboratory.GridControl = this.gridControl_Laboratory;
            this.gridView_Laboratory.Name = "gridView_Laboratory";
            this.gridView_Laboratory.NewItemRowText = "Tạo mới bộ xét nghiệm!";
            this.gridView_Laboratory.OptionsView.ShowFooter = true;
            this.gridView_Laboratory.OptionsView.ShowGroupPanel = false;
            this.gridView_Laboratory.Click += new System.EventHandler(this.gridView_Laboratory_Click);
            // 
            // col_ServiceCode
            // 
            this.col_ServiceCode.Caption = "Mã xét nghiệm";
            this.col_ServiceCode.FieldName = "ServiceCode";
            this.col_ServiceCode.Name = "col_ServiceCode";
            this.col_ServiceCode.Width = 90;
            // 
            // col_ServiceName
            // 
            this.col_ServiceName.Caption = "Tên bộ xét nghiệm";
            this.col_ServiceName.FieldName = "ServiceName";
            this.col_ServiceName.Name = "col_ServiceName";
            this.col_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_ServiceName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_ServiceName.Visible = true;
            this.col_ServiceName.VisibleIndex = 0;
            // 
            // col_ServiceCategoryName
            // 
            this.col_ServiceCategoryName.Caption = "Loại XN";
            this.col_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_ServiceCategoryName.Name = "col_ServiceCategoryName";
            this.col_ServiceCategoryName.OptionsColumn.AllowEdit = false;
            this.col_ServiceCategoryName.OptionsColumn.AllowFocus = false;
            this.col_ServiceCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ServiceCategoryName.Visible = true;
            this.col_ServiceCategoryName.VisibleIndex = 1;
            // 
            // col_ServiceCategoryCode
            // 
            this.col_ServiceCategoryCode.Caption = "ServiceCategoryCode";
            this.col_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.col_ServiceCategoryCode.Name = "col_ServiceCategoryCode";
            // 
            // pn02
            // 
            this.pn02.Controls.Add(this.lkupTypeResult);
            this.pn02.Controls.Add(this.butRemove);
            this.pn02.Controls.Add(this.butAdd);
            this.pn02.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn02.Location = new System.Drawing.Point(353, 0);
            this.pn02.Name = "pn02";
            this.pn02.Size = new System.Drawing.Size(155, 454);
            this.pn02.TabIndex = 1;
            // 
            // lkupTypeResult
            // 
            this.lkupTypeResult.Location = new System.Drawing.Point(6, 162);
            this.lkupTypeResult.Name = "lkupTypeResult";
            this.lkupTypeResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupTypeResult.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Title", "Loại mô tả"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "value", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupTypeResult.Properties.NullText = "Loại trả kết quả XN";
            this.lkupTypeResult.Size = new System.Drawing.Size(143, 20);
            this.lkupTypeResult.TabIndex = 2;
            this.lkupTypeResult.EditValueChanged += new System.EventHandler(this.lkupTypeResult_EditValueChanged);
            // 
            // butRemove
            // 
            this.butRemove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butRemove.Image = ((System.Drawing.Image)(resources.GetObject("butRemove.Image")));
            this.butRemove.Location = new System.Drawing.Point(35, 216);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(84, 30);
            this.butRemove.TabIndex = 1;
            this.butRemove.Text = "Remove";
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // butAdd
            // 
            this.butAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.Location = new System.Drawing.Point(35, 185);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(84, 30);
            this.butAdd.TabIndex = 1;
            this.butAdd.Text = "Add";
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // pn03
            // 
            this.pn03.Controls.Add(this.group03);
            this.pn03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn03.Location = new System.Drawing.Point(508, 0);
            this.pn03.Name = "pn03";
            this.pn03.Size = new System.Drawing.Size(280, 454);
            this.pn03.TabIndex = 2;
            // 
            // group03
            // 
            this.group03.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.group03.AppearanceCaption.Options.UseFont = true;
            this.group03.Controls.Add(this.gridControl_LabResult);
            this.group03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group03.Location = new System.Drawing.Point(2, 2);
            this.group03.Name = "group03";
            this.group03.Size = new System.Drawing.Size(276, 450);
            this.group03.TabIndex = 1;
            this.group03.Text = "Danh sách xét nghiệm trả kết quả";
            // 
            // gridControl_LabResult
            // 
            this.gridControl_LabResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_LabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_LabResult.Location = new System.Drawing.Point(2, 20);
            this.gridControl_LabResult.MainView = this.gridView_LabResult;
            this.gridControl_LabResult.Name = "gridControl_LabResult";
            this.gridControl_LabResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItem_TypeResult});
            this.gridControl_LabResult.Size = new System.Drawing.Size(272, 428);
            this.gridControl_LabResult.TabIndex = 0;
            this.gridControl_LabResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_LabResult});
            // 
            // gridView_LabResult
            // 
            this.gridView_LabResult.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_LabResult.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_LabResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResult_ServiceCode,
            this.colResult_TypeResult,
            this.colResult_ServiceCategoryName,
            this.colResult_ServiceName});
            this.gridView_LabResult.GridControl = this.gridControl_LabResult;
            this.gridView_LabResult.Name = "gridView_LabResult";
            this.gridView_LabResult.NewItemRowText = "Nhập mới thông số xét nghiệm!";
            this.gridView_LabResult.OptionsBehavior.Editable = false;
            this.gridView_LabResult.OptionsView.ShowFooter = true;
            this.gridView_LabResult.OptionsView.ShowGroupPanel = false;
            this.gridView_LabResult.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_LabResult.Click += new System.EventHandler(this.gridView_LabResult_Click);
            // 
            // colResult_ServiceCode
            // 
            this.colResult_ServiceCode.Caption = "Mã XN";
            this.colResult_ServiceCode.FieldName = "ServiceCode";
            this.colResult_ServiceCode.Name = "colResult_ServiceCode";
            // 
            // colResult_TypeResult
            // 
            this.colResult_TypeResult.Caption = "Hình thức";
            this.colResult_TypeResult.ColumnEdit = this.repItem_TypeResult;
            this.colResult_TypeResult.FieldName = "TypeResult";
            this.colResult_TypeResult.Name = "colResult_TypeResult";
            this.colResult_TypeResult.Visible = true;
            this.colResult_TypeResult.VisibleIndex = 1;
            // 
            // repItem_TypeResult
            // 
            this.repItem_TypeResult.AutoHeight = false;
            this.repItem_TypeResult.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItem_TypeResult.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Title", "Loại mô tả"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value")});
            this.repItem_TypeResult.Name = "repItem_TypeResult";
            this.repItem_TypeResult.NullText = "...";
            // 
            // colResult_ServiceCategoryName
            // 
            this.colResult_ServiceCategoryName.Caption = "Loại xét nghiệm";
            this.colResult_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.colResult_ServiceCategoryName.Name = "colResult_ServiceCategoryName";
            this.colResult_ServiceCategoryName.Visible = true;
            this.colResult_ServiceCategoryName.VisibleIndex = 2;
            // 
            // colResult_ServiceName
            // 
            this.colResult_ServiceName.Caption = "Xét nghiệm";
            this.colResult_ServiceName.FieldName = "ServiceName";
            this.colResult_ServiceName.Name = "colResult_ServiceName";
            this.colResult_ServiceName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServiceCode", "{0:#,#}")});
            this.colResult_ServiceName.Visible = true;
            this.colResult_ServiceName.VisibleIndex = 0;
            // 
            // butRefesh
            // 
            this.butRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.butRefesh.Image = ((System.Drawing.Image)(resources.GetObject("butRefesh.Image")));
            this.butRefesh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.butRefesh.Location = new System.Drawing.Point(329, 1);
            this.butRefesh.Name = "butRefesh";
            this.butRefesh.Size = new System.Drawing.Size(17, 18);
            this.butRefesh.TabIndex = 6;
            this.butRefesh.Click += new System.EventHandler(this.butRefesh_Click);
            // 
            // frmLoaiTraKetQuaXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 454);
            this.Controls.Add(this.pn03);
            this.Controls.Add(this.pn02);
            this.Controls.Add(this.pn01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoaiTraKetQuaXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo bộ xét nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoaiTraKetQuaXN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pn01)).EndInit();
            this.pn01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Laboratory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Laboratory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pn02)).EndInit();
            this.pn02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkupTypeResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pn03)).EndInit();
            this.pn03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group03)).EndInit();
            this.group03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_LabResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LabResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem_TypeResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pn01;
        private DevExpress.XtraEditors.PanelControl pn02;
        private DevExpress.XtraEditors.SimpleButton butRemove;
        private DevExpress.XtraEditors.SimpleButton butAdd;
        private DevExpress.XtraEditors.LookUpEdit lkupTypeResult;
        private DevExpress.XtraEditors.PanelControl pn03;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraGrid.GridControl gridControl_Laboratory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Laboratory;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryCode;
        private DevExpress.XtraEditors.GroupControl group03;
        private DevExpress.XtraGrid.GridControl gridControl_LabResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_LabResult;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_TypeResult;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceCategoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItem_TypeResult;
        private DevExpress.XtraGrid.Columns.GridColumn colResult_ServiceName;
        private DevExpress.XtraEditors.SimpleButton butRefesh;
    }
}