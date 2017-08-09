namespace Ps.Clinic.Master
{
    partial class frmShipmentDateEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShipmentDateEnd));
            this.gridControl_Item = new DevExpress.XtraGrid.GridControl();
            this.gridView_Item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ShipmentNew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateEndNew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repColDateEnd = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_Shipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repColDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repColDateEnd.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Item
            // 
            this.gridControl_Item.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Item.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Item.MainView = this.gridView_Item;
            this.gridControl_Item.Name = "gridControl_Item";
            this.gridControl_Item.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEdit_Delete,
            this.repColDateEnd});
            this.gridControl_Item.Size = new System.Drawing.Size(1020, 536);
            this.gridControl_Item.TabIndex = 2;
            this.gridControl_Item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Item});
            // 
            // gridView_Item
            // 
            this.gridView_Item.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Item.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Item.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCode,
            this.col_ItemName,
            this.col_Active,
            this.col_UnitOfMeasureName,
            this.col_ItemCategoryName,
            this.col_GroupName,
            this.col_ShipmentNew,
            this.col_DateEndNew,
            this.col_Delete,
            this.col_Shipment,
            this.col_DateEnd});
            this.gridView_Item.GridControl = this.gridControl_Item;
            this.gridView_Item.Name = "gridView_Item";
            this.gridView_Item.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Item.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Item.OptionsFind.FindFilterColumns = "ItemName";
            this.gridView_Item.OptionsView.ColumnAutoWidth = false;
            this.gridView_Item.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Item.OptionsView.ShowFooter = true;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_ItemCode.AppearanceCell.Options.UseFont = true;
            this.col_ItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_ItemCode.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.AllowFocus = false;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Width = 62;
            // 
            // col_ItemName
            // 
            this.col_ItemName.Caption = "Tên - nội dung";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.OptionsColumn.AllowFocus = false;
            this.col_ItemName.OptionsColumn.AllowMove = false;
            this.col_ItemName.OptionsColumn.ReadOnly = true;
            this.col_ItemName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Count: {0:#,#}")});
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 2;
            this.col_ItemName.Width = 202;
            // 
            // col_Active
            // 
            this.col_Active.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Active.Caption = "Hoạt chất";
            this.col_Active.FieldName = "Active";
            this.col_Active.Name = "col_Active";
            this.col_Active.OptionsColumn.AllowFocus = false;
            this.col_Active.OptionsColumn.AllowMove = false;
            this.col_Active.OptionsColumn.ReadOnly = true;
            this.col_Active.Visible = true;
            this.col_Active.VisibleIndex = 3;
            this.col_Active.Width = 112;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.Caption = "ĐVT";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.OptionsColumn.AllowFocus = false;
            this.col_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 4;
            this.col_UnitOfMeasureName.Width = 98;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.Caption = "Loại thuốc";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.OptionsColumn.AllowFocus = false;
            this.col_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 1;
            this.col_ItemCategoryName.Width = 200;
            // 
            // col_GroupName
            // 
            this.col_GroupName.Caption = "Nhóm thuốc";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.OptionsColumn.AllowFocus = false;
            this.col_GroupName.OptionsColumn.ReadOnly = true;
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 0;
            this.col_GroupName.Width = 172;
            // 
            // col_ShipmentNew
            // 
            this.col_ShipmentNew.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ShipmentNew.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ShipmentNew.Caption = "Lô";
            this.col_ShipmentNew.FieldName = "ShipmentNew";
            this.col_ShipmentNew.Name = "col_ShipmentNew";
            this.col_ShipmentNew.Visible = true;
            this.col_ShipmentNew.VisibleIndex = 5;
            this.col_ShipmentNew.Width = 99;
            // 
            // col_DateEndNew
            // 
            this.col_DateEndNew.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DateEndNew.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DateEndNew.Caption = "Hạn dùng";
            this.col_DateEndNew.ColumnEdit = this.repColDateEnd;
            this.col_DateEndNew.FieldName = "DateEndNew";
            this.col_DateEndNew.Name = "col_DateEndNew";
            this.col_DateEndNew.Visible = true;
            this.col_DateEndNew.VisibleIndex = 6;
            this.col_DateEndNew.Width = 82;
            // 
            // repColDateEnd
            // 
            this.repColDateEnd.AutoHeight = false;
            this.repColDateEnd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repColDateEnd.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repColDateEnd.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repColDateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repColDateEnd.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repColDateEnd.Name = "repColDateEnd";
            // 
            // col_Delete
            // 
            this.col_Delete.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Delete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Delete.Caption = "Chọn";
            this.col_Delete.ColumnEdit = this.ItemCheckEdit_Delete;
            this.col_Delete.FieldName = "Delete";
            this.col_Delete.Name = "col_Delete";
            this.col_Delete.Visible = true;
            this.col_Delete.VisibleIndex = 7;
            // 
            // ItemCheckEdit_Delete
            // 
            this.ItemCheckEdit_Delete.AutoHeight = false;
            this.ItemCheckEdit_Delete.DisplayValueChecked = "1";
            this.ItemCheckEdit_Delete.DisplayValueGrayed = "0";
            this.ItemCheckEdit_Delete.DisplayValueUnchecked = "0";
            this.ItemCheckEdit_Delete.Name = "ItemCheckEdit_Delete";
            this.ItemCheckEdit_Delete.ValueChecked = 1;
            this.ItemCheckEdit_Delete.ValueGrayed = 0;
            this.ItemCheckEdit_Delete.ValueUnchecked = 0;
            // 
            // col_Shipment
            // 
            this.col_Shipment.Caption = "Shipment";
            this.col_Shipment.FieldName = "Shipment";
            this.col_Shipment.Name = "col_Shipment";
            // 
            // col_DateEnd
            // 
            this.col_DateEnd.Caption = "DateEnd";
            this.col_DateEnd.FieldName = "DateEnd";
            this.col_DateEnd.Name = "col_DateEnd";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1024, 600);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh sách thuốc ( lô - hạn dùng )";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl_Item);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 536);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butSave);
            this.panel1.Controls.Add(this.btRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 39);
            this.panel1.TabIndex = 3;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(944, 9);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(73, 24);
            this.butSave.TabIndex = 23;
            this.butSave.Text = "Cập nhật";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.Location = new System.Drawing.Point(870, 9);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(73, 24);
            this.btRefresh.TabIndex = 22;
            this.btRefresh.Text = "Xem";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // frmShipmentDateEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShipmentDateEnd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh sách thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShipmentDateEnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repColDateEnd.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repColDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Item;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Item;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Active;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit_Delete;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ShipmentNew;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateEndNew;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.Columns.GridColumn col_Delete;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repColDateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_Shipment;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateEnd;
    }
}